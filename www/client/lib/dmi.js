var DMI = (function() {
	var icons = {};
	
	function draw(ctx, x, y, path, state, dir, t) {
		path = "/content/"+path;
		
		var icon = icons[path];
		if (icon==null) {
			icon = {};
			icons[path] = icon;
			load(path);
		}
		
		if (icon.img==null) {
			if (icon.loadfail) {
				ctx.fillStyle = "red";
				ctx.fillRect(x, y, 32, 32);
			}
		} else {
			state = icon["$"+state];
			
			if (state==null) {
				ctx.fillStyle = "orange";
				ctx.fillRect(x, y, 32, 32);
				return;
			}
			
			var icon_w = icon.w;
			var icon_h = icon.h;
			
			var count_x = icon.img.width/icon_w;
			
			var n = state.start;
			
			if (state.dirs==4) {
				switch(dir) {
					case 1: n++; break;		// N
					case 8: n+=2; break;	// E
					case 2: break;			// S
					case 4: n+=3; break;	// W
					default: console.log("BAD DIR FOR 4: "+dir);
				}
			} else if (state.dirs==8) {
				switch(dir) {
					case 1: n++; break;		// N
					case 9: n+=6; break;	// NE
					case 8: n+=2; break;	// E
					case 10: n+=4; break;	// SE
					case 2: break;			// S
					case 6: n+=5; break;	// SW
					case 4: n+=3; break;	// W
					case 5: n+=7; break;	// NW
					default: console.log("BAD DIR FOR 8: "+dir);
				}
			}
			
			if (state.frames) {
				var frame_count = state.frames.length;
				var frame_stride = state.dirs || 1;
				
				t %= state.time;
				
				var base_t = t;
				
				for (var i=0;i<frame_count;i++) {
					t -= state.frames[i];
					if (t<0)
						break;
					n += frame_stride;
				}
			}
			
			var sx = (n%count_x)*icon_w;
			var sy = Math.floor(n/count_x)*icon_h;
			
			ctx.drawImage(icon.img,sx,sy,icon_w,icon_h,x,y,icon_w,icon_h);
		}
	}
	
	function load(path) {
		var xhr = new XMLHttpRequest();

		xhr.onload = function(e){
			if (xhr.status == 200){
				var metadata = read_md(xhr.response);
				if (metadata==null) {
					console.error("DMI.js ~ File '"+path+"' is an invalid PNG!");
					icons[path].loadfail = true;
				} else if (metadata.Description==null) {
					console.error("DMI.js ~ File '"+path+"' is missing DMI metadata!");
					icons[path].loadfail = true;
				} else {
					var icon = parse_dmi(metadata.Description);
					icon.img = new Image();
					icon.img.src = "data:image/png;base64,"+_arrayBufferToBase64(xhr.response);
					icons[path] = icon;
				}
			} else {
				console.error("DMI.js ~ File '"+path+"' could not be found!");
				icons[path].loadfail = true;
			}
		}
		
		xhr.open("GET", path);
		xhr.responseType = "arraybuffer";
		xhr.send();
	}
	
	// wew stackoverflow http://stackoverflow.com/questions/9267899/arraybuffer-to-base64-encoded-string
	function _arrayBufferToBase64( buffer ) {
		var binary = '';
		var bytes = new Uint8Array( buffer );
		var len = bytes.byteLength;
		for (var i = 0; i < len; i++) {
			binary += String.fromCharCode( bytes[ i ] );
		}
		return window.btoa( binary );
	}
	
	function read_md(raw) {
		var result = {};
		
		var data = new Uint8Array(raw);
		var header = [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A];
		var i=0;
		// Verfiy that we're dealing with a PNG!
		while (i<header.length) {
			if (data[i]!=header[i++]) {
				return;
			}
		}
		// Read them chunks!
		while (i<data.length) {
			var len = data[i++]*16777216;
			len += data[i++]*65536;
			len += data[i++]*256;
			len += data[i++];
			
			var id = String.fromCharCode(data[i++],data[i++],data[i++],data[i++]);
			
			if (id=="zTXt") {
				var key = "";
				var j=i;
				for (;;) {
					var c = data[j++];
					if (c==0) break;
					key += String.fromCharCode(c);
				}
				
				if (data[j++]==0) { // This is the only compression method in the spec.
					result[key] = pako.inflate(new Uint8Array(raw, j, len-(j-i-1)),{to: "string"});
				}
			}
			
			i += len+4; // fuck the crc
		}
		
		return result;
	}
	
	// THIS IS NOT MEANT TO BE A ROBUST PARSEER. IT IS MEANT TO PARSE THE TEXT GENERATED BY DM.
	function parse_dmi(src) {
		var result = {};
		var lines = src.split("\n");
		if (lines[0]!="# BEGIN DMI" || lines[1]!="version = 4.0")
			return;
		
		var matchW = lines[2].match(/\twidth = (\d+)/);
		if (matchW==null)
			return;
		result.w = parseInt(matchW[1]);
		
		var matchH = lines[3].match(/\theight = (\d+)/);
		if (matchH==null)
			return;
		result.h = parseInt(matchH[1]);
		
		var i=4;
		var j=0;
		for (;;) {
			var matchS = lines[i].match(/state = "(.*)"/);
			if (matchS!=null) {
				var state = matchS[1];
				
				var this_state = {};
				this_state.start = j;
				
				var stride = 1;
				
				i++;
				
				var matchD = lines[i].match(/\tdirs = (\d+)/);
				if (matchD!=null) {
					if (matchD[1]!="1") {
						this_state.dirs = parseInt(matchD[1]);
						stride *= this_state.dirs;
					}
					i++;
				}
				
				var matchF = lines[i].match(/\tframes = (\d+)/);
				if (matchF!=null) {
					i++;
				}
				
				var matchT = lines[i].match(/\tdelay = (.+)/);
				if (matchT!=null) {
					this_state.frames = matchT[1].split(",").map(function(s) {return parseInt(s);});
					this_state.time = this_state.frames.reduce(function(a,b) {return a+b;},0);
					stride *= this_state.frames.length;
					i++;
				}
				
				var matchR = lines[i].match(/\trewind = 1/);
				if (matchR!=null) {
					this_state.rewind = true;
					i++;
				}
				
				var matchP = lines[i].match(/\thotspot = (.+)/);
				if (matchP!=null) {
					this_state.hotspot = matchP[1].split(",").map(function(s) {return parseInt(s);});
					i++;
				}
				
				var matchL = lines[i].match(/\tloop = (.+)/);
				if (matchL!=null) {
					this_state.loop = parseInt(matchL[1]);
					i++;
				}
				
				if (result["$"+state] == null) // if there are two states that share a name, the first will be used!
					result["$"+state] = this_state;
				
				j+=stride;
			} else if (lines[i]=="# END DMI") {
				break;
			} else {
				console.log(">>"+lines[i]);
				return;
			}
		}

		return result;
	}
	
	return {draw: draw};
}());