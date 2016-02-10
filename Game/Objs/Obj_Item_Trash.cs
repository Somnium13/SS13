// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Trash : Obj_Item {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 1;
			this.autoignition_temperature = 519.1500244140625;
			this.fire_fuel = 1;
			this.icon = "icons/obj/trash.dmi";
		}

		// Function from file: trash.dm
		public Obj_Item_Trash ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.trash_items.Add( this );
			return;
		}

		// Function from file: trash.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			GlobalVars.trash_items.Remove( this );
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: trash.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			return null;
		}

	}

}