// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Bikehorn_Rubberducky : Obj_Item_Weapon_Bikehorn {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "rubberducky";
			this.attack_verb = new ByTable(new object [] { "quacked" });
			this.hitsound = "sound/items/quack.ogg";
			this.honk_delay = 10;
			this.icon = "icons/obj/watercloset.dmi";
			this.icon_state = "rubberducky";
		}

		public Obj_Item_Weapon_Bikehorn_Rubberducky ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}