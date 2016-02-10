// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Spellbook_Oneuse_Blind : Obj_Item_Weapon_Spellbook_Oneuse {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.spell = typeof(Spell_Targeted_Genetic_Blind);
			this.spellname = "blind";
			this.icon_state = "bookblind";
		}

		public Obj_Item_Weapon_Spellbook_Oneuse_Blind ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: spellbook.dm
		public override void recoil( dynamic user = null ) {
			base.recoil( (object)(user) );
			GlobalFuncs.to_chat( user, "<span class='warning'>You go blind!</span>" );
			user.eye_blind = 10;
			return;
		}

	}

}