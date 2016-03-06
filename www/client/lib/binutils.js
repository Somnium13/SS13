(function() {
	var CHUNK_SIZE = 512;
	
	var conv_array = new ArrayBuffer(8);
	
	var conv_byte = new Uint8Array(conv_array);
	var conv_float = new Float32Array(conv_array);
	var conv_double = new Float64Array(conv_array);
	
	function BinWriter() {
		this.index = 0;
		this.array = new ArrayBuffer(CHUNK_SIZE);
		this.view = new Uint8Array(this.array);
	}

	function growArray(br) {
		var old = br.view;
		br.array = new ArrayBuffer(br.array.byteLength+CHUNK_SIZE);
		br.view = new Uint8Array(br.array);
		for (var i=0;i<old.byteLength;i++) {
			br.view[i] = old[i];
		}
	}
	
	BinWriter.prototype.writeBool = function(b) {
		this.writeByte(b?1:0);
	}
	
	BinWriter.prototype.writeByte = function(n) {
		if (this.index >= this.array.byteLength)
			growArray(this);
		this.view[this.index++] = n;
	}
	
	BinWriter.prototype.writeShort = function(n) {
		this.writeByte(n & 255);
		this.writeByte(n >> 8);
	}
	
	BinWriter.prototype.writeInt = function(n) {
		this.writeByte(n & 255);
		this.writeByte((n >> 8) & 255);
		this.writeByte((n >> 16) & 255);
		this.writeByte(n >> 24);
	}
	
	BinWriter.prototype.writeFloat = function(n) {
		conv_float[0] = n;
		this.writeByte(conv_byte[0]);
		this.writeByte(conv_byte[1]);
		this.writeByte(conv_byte[2]);
		this.writeByte(conv_byte[3]);
	}
	
	BinWriter.prototype.writeDouble = function(n) {
		conv_double[0] = n;
		this.writeByte(conv_byte[0]);
		this.writeByte(conv_byte[1]);
		this.writeByte(conv_byte[2]);
		this.writeByte(conv_byte[3]);
		this.writeByte(conv_byte[4]);
		this.writeByte(conv_byte[5]);
		this.writeByte(conv_byte[6]);
		this.writeByte(conv_byte[7]);
	}
	
	BinWriter.prototype.writeULEB128 = function(n) {
		do {
			var b = n & 0x7F;
			n >>= 7;
			if (n > 0)
				b |= 0x80;
			this.writeByte(b);
		} while (n > 0);
	}
	
	BinWriter.prototype.writeString = function(s) {
		// UTF8
		var raw = unescape(encodeURIComponent(s));
		// WRITE ULEB128 LENGTH
		this.writeULEB128(raw.length);
		// WRITE BYTES
		for (var i = 0; i< raw.length; i++) {
			this.writeByte(raw.charCodeAt(i));
		}
	}

	BinWriter.prototype.getData = function() {
		return new Uint8Array(this.array,0,this.index);
	}
	
	window.BinWriter = BinWriter;
	
	function BinReader(array) {
		this.index = 0;
		this.array = array;
		this.view = new Uint8Array(this.array);
	}
	
	BinReader.prototype.readBool = function() {
		return this.readByte() != 0;
	}
	
	BinReader.prototype.readByte = function() {
		return this.view[this.index++];
	}
	
	BinReader.prototype.readSByte = function() {
		var b = this.readByte();
		if (b > 127)
			return -(256-b);
		return b;
	}
	
	BinReader.prototype.readUShort = function() {
		return this.readByte() + (this.readByte() << 8);
	}
	
	BinReader.prototype.readShort = function() {
		return this.readByte() + (this.readSByte() << 8);
	}
	
	BinReader.prototype.readUInt = function() {
		return this.readByte() + (this.readByte() << 8) + (this.readByte() << 16) + (this.readByte() << 24);
	}
	
	BinReader.prototype.readInt = function() {
		return this.readByte() + (this.readByte() << 8) + (this.readByte() << 16) + (this.readSByte() << 24);
	}
	
	BinReader.prototype.readFloat = function() {
		conv_byte[0] = this.readByte();
		conv_byte[1] = this.readByte();
		conv_byte[2] = this.readByte();
		conv_byte[3] = this.readByte();
		return conv_float[0];
	}
	
	BinReader.prototype.readDouble = function() {
		conv_byte[0] = this.readByte();
		conv_byte[1] = this.readByte();
		conv_byte[2] = this.readByte();
		conv_byte[3] = this.readByte();
		conv_byte[4] = this.readByte();
		conv_byte[5] = this.readByte();
		conv_byte[6] = this.readByte();
		conv_byte[7] = this.readByte();
		return conv_double[0];
	}
	
	BinReader.prototype.readULEB128 = function() {
		var n = 0;
		var shift = 0;
		do {
			var b = this.readByte();
			n += (b & 0x7F)<<shift;
			shift+=7;
		} while ((b & 0x80) != 0);
		return n;
	}
	
	BinReader.prototype.readString = function() {
		var len = this.readULEB128();
		var raw = "";
		for (var i=0;i<len;i++)
			raw+= String.fromCharCode(this.readByte());
		return decodeURIComponent(escape(raw));
	}
	
	window.BinReader = BinReader;
})();