// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Security_Telescreen : Obj_Machinery_Computer_Security {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.network = new ByTable(new object [] { "thunder" });
			this.icon_state = "telescreen";
		}

		public Obj_Machinery_Computer_Security_Telescreen ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: camera.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			this.icon_state = Lang13.Initial( this, "icon_state" );

			if ( ( this.stat & 1 ) != 0 ) {
				this.icon_state += "b";
			}
			return null;
		}

		// Function from file: camera.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );
			GlobalFuncs.to_chat( user, "Looks like the current channel is \"<span class='info'>" + this.current.c_tag + "</span>\"" );
			return null;
		}

		// Function from file: trash_machinery.dm
		public override dynamic cultify(  ) {
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}