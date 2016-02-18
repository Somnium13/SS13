// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class DataPdaMsg : Game_Data {

		public string recipient = "Unspecified";
		public string sender = "Unspecified";
		public string message = "Blank";
		public dynamic photo = null;

		// Function from file: message_server.dm
		public DataPdaMsg ( string param_rec = null, string param_sender = null, string param_message = null, dynamic param_photo = null ) {
			param_rec = param_rec ?? "";
			param_sender = param_sender ?? "";
			param_message = param_message ?? "";

			
			if ( Lang13.Bool( param_rec ) ) {
				this.recipient = param_rec;
			}

			if ( Lang13.Bool( param_sender ) ) {
				this.sender = param_sender;
			}

			if ( Lang13.Bool( param_message ) ) {
				this.message = param_message;
			}

			if ( Lang13.Bool( param_photo ) ) {
				this.photo = param_photo;
			}
			return;
		}

		// Function from file: message_server.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			Mob M = null;

			base.Topic( href, href_list, (object)(hsrc) );

			if ( Lang13.Bool( href_list["photo"] ) ) {
				M = Task13.User;
				Interface13.CacheBrowseResource( M, this.photo, "pda_photo.png" );
				Interface13.Browse( M, "<html><head><title>PDA Photo</title></head><body style='overflow:hidden;margin:0;text-align:center'><img src='pda_photo.png' width='192' style='-ms-interpolation-mode:nearest-neighbor' /></body></html>", "window=book;size=192x192" );
				GlobalFuncs.onclose( M, "PDA Photo" );
			}
			return null;
		}

		// Function from file: message_server.dm
		public string get_photo_ref(  ) {
			
			if ( Lang13.Bool( this.photo ) ) {
				return new Txt( "<a href='byond://?src=" ).Ref( this ).str( ";photo=1'>(Photo)</a>" ).ToString();
			}
			return "";
		}

	}

}