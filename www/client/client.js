


document.forms["login"].onsubmit = function() {
	var name = this.elements["name"].value;
	
	var socket = new WebSocket("ws://"+window.location.host+"/service/connect","Somnium13");
	socket.binaryType = "arraybuffer";
	
	var connected=false;
	
	function TxAuth() {
		var writer = new BinWriter();
		writer.writeByte(0);
		writer.writeString(name);
		socket.send(writer.getData());
	}
	
	function RxAccept(reader) {
		//document.body.style.overflow = "hidden";
		
		var main_ui = document.createElement("iframe");
		main_ui.setAttribute("src","/client/main_ui.html");
		main_ui.setAttribute("style","border: none; width: 100%; height: 100%; position: absolute;");
		document.body.appendChild(main_ui);
	}
	
	socket.onopen = function(e) {
		connected = true;
		console.log("connected",e);
		// Delete all the login crap.
		document.querySelector("style").remove();
		document.body.innerHTML = "";
		
		// Make them good memes.

		TxAuth();
	}
	
	socket.onclose = function(e) {
		if (connected)
			alert("Socket closed!");
		else
			alert("Failed to connect! Maybe the server is not ready?");
		console.log("ws close",e);
	}
	
	socket.onmessage = function(e) {
		var reader = new BinReader(e.data);
		var msg_type = reader.readByte();
		
		switch (msg_type) {
			case 0:
				RxAccept(reader);
				break;
			default:
				alert("Unknown net msg #"+msg_type);
		}
		
		//console.log(s.length,s);
		
		//console.log("ws msg",e.data,e.data.length);
	}
	
	socket.onerror = function(e) {
		console.log("ws err",e);
	}
	
	return false;
}