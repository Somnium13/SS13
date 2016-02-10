// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RcdSchematic_Gsensor : RcdSchematic {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Gas sensor";
			this.category = "Devices";
			this.flags = 6;
		}

		public RcdSchematic_Gsensor ( dynamic n_master = null ) : base( (object)(n_master) ) {
			
		}

		// Function from file: pipe.dm
		public override dynamic attack( dynamic A = null, dynamic user = null ) {
			
			if ( !( A is Tile ) ) {
				return null;
			}
			GlobalFuncs.to_chat( user, "Building gas sensor..." );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this.master ), "sound/machines/click.ogg", 50, 1 );

			if ( !GlobalFuncs.do_after( user, A, 20 ) ) {
				return 1;
			}
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this.master ), "sound/items/Deconstruct.ogg", 50, 1 );
			new Obj_Item_PipeGsensor( A );
			return null;
		}

	}

}