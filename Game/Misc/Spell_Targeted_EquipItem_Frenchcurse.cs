// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Spell_Targeted_EquipItem_Frenchcurse : Spell_Targeted_EquipItem {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "French Curse";
			this.desc = "This curse will silence your target for a very long time.";
			this.charge_max = 300;
			this.invocation = "FU'K Y'U D'NY";
			this.invocation_type = "shout";
			this.range = 1;
			this.spell_flags = 0;
			this.cooldown_min = 50;
			this.sparks_spread = true;
			this.sparks_amt = 4;
			this.compatible_mobs = new ByTable(new object [] { typeof(Mob_Living_Carbon_Human) });
			this.hud_state = "wiz_mime";
		}

		// Function from file: frenchcurse.dm
		public Spell_Targeted_EquipItem_Frenchcurse (  ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.equipped_summons = new ByTable().Set( "" + 2, typeof(Obj_Item_Clothing_Mask_Gas_Mime) ).Set( "" + 14, typeof(Obj_Item_Clothing_Under_Mime) );
			return;
		}

		// Function from file: frenchcurse.dm
		public override dynamic summon_item( dynamic newtype = null ) {
			dynamic new_item = null;
			dynamic M = null;

			new_item = Lang13.Call( newtype );
			new_item.unacidable = 1;
			new_item.canremove = false;

			if ( new_item is Obj_Item_Clothing_Mask_Gas_Mime ) {
				M = new_item;
				M.can_flip = false;
				M.muted = 1;
			}
			return new_item;
		}

		// Function from file: frenchcurse.dm
		public override bool cast( ByTable targets = null, Mob user = null ) {
			user = user ?? Task13.User;

			Mob_Living_Carbon_Human target = null;

			base.cast( targets, user );

			foreach (dynamic _a in Lang13.Enumerate( targets, typeof(Mob_Living_Carbon_Human) )) {
				target = _a;
				
				Icon13.Flick( "e_flash", target.flash );
				target.miming = true;
				target.add_spell( new Spell_AoeTurf_Conjure_Forcewall_Mime() );
			}
			return false;
		}

	}

}