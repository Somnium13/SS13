// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Spell_Targeted_EquipItem_Robesummon : Spell_Targeted_EquipItem {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Summon Robes	";
			this.desc = "A spell which will summon you a new set of robes.";
			this.charge_max = 300;
			this.invocation = "I PUT ON MY ROBE AND WIZARD HAT!";
			this.invocation_type = "shout";
			this.range = -1;
			this.spell_flags = 64;
			this.delete_old = false;
			this.cooldown_min = 50;
			this.compatible_mobs = new ByTable(new object [] { typeof(Mob_Living_Carbon_Human) });
			this.hud_state = "wiz_robesummon";
		}

		// Function from file: robesummon.dm
		public override bool cast( ByTable targets = null, Mob user = null ) {
			user = user ?? Task13.User;

			
			dynamic _a = Rand13.Pick(new object [] { "blue", "red", "marisa" }); // Was a switch-case, sorry for the mess.
			if ( _a=="blue" ) {
				this.equipped_summons = new ByTable().Set( "" + 11, typeof(Obj_Item_Clothing_Head_Wizard) ).Set( "" + 13, typeof(Obj_Item_Clothing_Suit_Wizrobe) ).Set( "" + 12, typeof(Obj_Item_Clothing_Shoes_Sandal) );
			} else if ( _a=="red" ) {
				this.equipped_summons = new ByTable().Set( "" + 11, typeof(Obj_Item_Clothing_Head_Wizard_Red) ).Set( "" + 13, typeof(Obj_Item_Clothing_Suit_Wizrobe_Red) ).Set( "" + 12, typeof(Obj_Item_Clothing_Shoes_Sandal) );
			} else if ( _a=="marisa" ) {
				this.equipped_summons = new ByTable().Set( "" + 11, typeof(Obj_Item_Clothing_Head_Wizard_Marisa) ).Set( "" + 13, typeof(Obj_Item_Clothing_Suit_Wizrobe_Marisa) ).Set( "" + 12, typeof(Obj_Item_Clothing_Shoes_Sandal_Marisa) );
			}
			Task13.User.visible_message( "<span class='danger'>" + Task13.User + " puts on his robe and wizard hat!</span>", "<span class='danger'>You put on your robe and wizard hat!</span>" );
			base.cast( targets, user );
			return false;
		}

	}

}