// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class HookHandler_Soundmanager : HookHandler {

		// Function from file: mediamanager.dm
		public void OnMobAreaChange( dynamic args = null ) {
			dynamic M = null;

			M = args["mob"];

			if ( Lang13.Bool( M.client ) && M.client.media != null && !M.client.media.forced ) {
				M.update_music();
			}
			return;
		}

		// Function from file: mediamanager.dm
		public void OnReboot( dynamic args = null ) {
			GlobalFuncs.log_startup_progress( "Stopping all playing media..." );
			GlobalFuncs.stop_all_media();
			Task13.Sleep( 10 );
			return;
		}

		// Function from file: mediamanager.dm
		public void OnLogin( dynamic args = null ) {
			Client C = null;

			C = args["client"];
			C.media = new MediaManager( args["mob"] );
			C.media.open();
			C.media.update_music();
			return;
		}

	}

}