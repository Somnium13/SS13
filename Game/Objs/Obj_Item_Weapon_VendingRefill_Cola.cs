// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_VendingRefill_Cola : Obj_Item_Weapon_VendingRefill {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.machine_name = "Robust Softdrinks";
			this.charges = new ByTable(new object [] { 20, 2, 0 });
			this.init_charges = new ByTable(new object [] { 20, 2, 0 });
			this.icon_state = "refill_cola";
		}

		public Obj_Item_Weapon_VendingRefill_Cola ( dynamic amt = null ) : base( (object)(amt) ) {
			
		}

	}

}