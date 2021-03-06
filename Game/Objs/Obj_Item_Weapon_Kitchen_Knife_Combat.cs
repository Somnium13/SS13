// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Kitchen_Knife_Combat : Obj_Item_Weapon_Kitchen_Knife {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "knife";
			this.force = 20;
			this.throwforce = 20;
			this.origin_tech = "materials=2;combat=4";
			this.attack_verb = new ByTable(new object [] { "slashed", "stabbed", "sliced", "torn", "ripped", "cut" });
			this.icon_state = "buckknife";
		}

		public Obj_Item_Weapon_Kitchen_Knife_Combat ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}