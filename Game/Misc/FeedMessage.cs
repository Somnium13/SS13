// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class FeedMessage : Game_Data {

		public dynamic author = "";
		public dynamic body = "";
		public dynamic backup_body = "";
		public string backup_author = "";
		public bool is_admin_message = false;
		public dynamic img = null;
		public dynamic backup_img = null;
		public string img_info = "";

		// Function from file: newscaster.dm
		public void clear(  ) {
			this.author = "";
			this.body = "";
			this.backup_body = "";
			this.backup_author = "";
			this.img = null;
			this.backup_img = null;
			return;
		}

	}

}