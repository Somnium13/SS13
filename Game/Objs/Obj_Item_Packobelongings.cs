// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Packobelongings : Obj_Item {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/storage.dmi";
			this.icon_state = "belongings";
		}

		// Function from file: adminbus_powers.dm
		public Obj_Item_Packobelongings ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.pixel_x = Rand13.Int( -5, 5 );
			this.pixel_y = Rand13.Int( -5, 5 );
			return;
		}

		// Function from file: adminbus_powers.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic T = null;
			Obj O = null;

			T = GlobalFuncs.get_turf( user );

			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj) )) {
				O = _a;
				
				O.loc = T;
			}
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}