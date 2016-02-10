// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SocketTalk : Game_Data {

		public double? enabled = 0;
		public string dll = "./DLLSocket.so";

		// Function from file: socket_talk.dm
		public SocketTalk (  ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.enabled = GlobalVars.config.socket_talk;

			if ( Lang13.Bool( this.enabled ) ) {
				Lang13.Call( Lang13.BindFunc( this.dll, "establish_connection" ), "127.0.0.1", "8019" );
			}
			return;
		}

		// Function from file: socket_talk.dm
		public dynamic set_ticker_state( dynamic state = null ) {
			return this.send_raw( "type=ticker_state&message=" + state );
		}

		// Function from file: socket_talk.dm
		public dynamic send_keepalive(  ) {
			return this.send_raw( "type=keepalive" );
		}

		// Function from file: socket_talk.dm
		public dynamic send_log( dynamic log = null, dynamic message = null ) {
			return this.send_raw( "type=log&log=" + log + "&message=" + message );
		}

		// Function from file: socket_talk.dm
		public dynamic receive_raw(  ) {
			
			if ( Lang13.Bool( this.enabled ) ) {
				return Lang13.Call( Lang13.BindFunc( this.dll, "recv_message" ) );
			}
			return null;
		}

		// Function from file: socket_talk.dm
		public dynamic send_raw( string message = null ) {
			
			if ( Lang13.Bool( this.enabled ) ) {
				return Lang13.Call( Lang13.BindFunc( this.dll, "send_message" ), message );
			}
			return null;
		}

	}

}