// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Zone_Lavaland_Surface : Zone_Lavaland {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ambientsounds = new ByTable(new object [] { "sound/ambience/ambimine.ogg" });
			this.icon_state = "explored";
		}

		public Zone_Lavaland_Surface ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}