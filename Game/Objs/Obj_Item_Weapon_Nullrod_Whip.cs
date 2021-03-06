// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Nullrod_Whip : Obj_Item_Weapon_Nullrod {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "chain";
			this.slot_flags = 512;
			this.attack_verb = new ByTable(new object [] { "whipped", "lashed" });
			this.icon_state = "chain";
		}

		public Obj_Item_Weapon_Nullrod_Whip ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: holy_weapons.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic H = null;
			dynamic phrase = null;

			
			if ( !( proximity_flag == true ) ) {
				return false;
			}

			if ( target is Mob_Living_Carbon_Human ) {
				H = target;

				if ( GlobalFuncs.is_shadow( H ) ) {
					phrase = Rand13.Pick(new object [] { "Die monster! You don't belong in this world!!!", "You steal men's souls and make them your slaves!!!", "Your words are as empty as your soul!!!", "Mankind ill needs a savior such as you!!!" });
					((Ent_Dynamic)user).say( "" + phrase );
					((Mob_Living)H).adjustBruteLoss( 8 );
				}
			}
			return false;
		}

	}

}