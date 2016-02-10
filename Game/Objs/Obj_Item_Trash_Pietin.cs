// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Trash_Pietin : Obj_Item_Trash {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.siemens_coefficient = 2;
			this.melt_temperature = 1687;
			this.icon_state = "pietin";
		}

		public Obj_Item_Trash_Pietin ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: trash.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Obj_Item_Clothing_Head_Tinfoil I = null;

			
			if ( a is Obj_Item_Trash_Pietin ) {
				I = new Obj_Item_Clothing_Head_Tinfoil( GlobalFuncs.get_turf( this ) );
				GlobalFuncs.qdel( a );
				GlobalFuncs.qdel( this );
				((Mob)b).put_in_hands( I );
			}
			return null;
		}

	}

}