// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable_Condensedcapsaicin : Reagent_Consumable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Condensed Capsaicin";
			this.id = "condensedcapsaicin";
			this.description = "A chemical agent used for self-defense and in police work.";
			this.color = "#B31008";
		}

		// Function from file: food_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			
			if ( Rand13.PercentChance( 5 ) ) {
				((Ent_Static)M).visible_message( "<span class='warning'>" + M + " " + Rand13.Pick(new object [] { "dry heaves!", "coughs!", "splutters!" }) + "</span>" );
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

		// Function from file: food_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			dynamic victim = null;
			bool mouth_covered = false;
			bool eyes_covered = false;
			dynamic safe_thing = null;
			dynamic H = null;

			
			if ( !( M is Mob_Living_Carbon_Human ) && !( M is Mob_Living_Carbon_Monkey ) ) {
				return 0;
			}
			victim = M;

			if ( method == GlobalVars.TOUCH || method == GlobalVars.VAPOR ) {
				mouth_covered = false;
				eyes_covered = false;
				safe_thing = null;

				if ( Lang13.Bool( victim.wear_mask ) ) {
					
					if ( Lang13.Bool( victim.wear_mask.flags_cover & 2 ) ) {
						eyes_covered = true;
						safe_thing = victim.wear_mask;
					}

					if ( Lang13.Bool( victim.wear_mask.flags_cover & 8 ) ) {
						mouth_covered = true;
						safe_thing = victim.wear_mask;
					}
				}

				if ( victim is Mob_Living_Carbon_Human ) {
					H = victim;

					if ( Lang13.Bool( H.head ) ) {
						
						if ( Lang13.Bool( H.head.flags_cover & 2 ) ) {
							eyes_covered = true;
							safe_thing = H.head;
						}

						if ( Lang13.Bool( H.head.flags_cover & 8 ) ) {
							mouth_covered = true;
							safe_thing = H.head;
						}
					}

					if ( Lang13.Bool( H.glasses ) ) {
						eyes_covered = true;

						if ( !Lang13.Bool( safe_thing ) ) {
							safe_thing = H.glasses;
						}
					}
				}

				if ( eyes_covered && mouth_covered ) {
					return 0;
				} else if ( mouth_covered ) {
					
					if ( Rand13.PercentChance( 5 ) ) {
						((Mob)victim).emote( "scream" );
					}
					((Mob)victim).adjust_blurriness( 3 );
					((Mob)victim).adjust_blindness( 1 );
					victim.confused = Num13.MaxInt( ((int)( M.confused )), 3 );
					victim.damageoverlaytemp = 60;
					((Mob)victim).Weaken( 3 );
					victim.drop_item();
					return 0;
				} else if ( eyes_covered ) {
					((Mob)victim).adjust_blurriness( 3 );
					victim.damageoverlaytemp = 30;
					return 0;
				} else {
					
					if ( Rand13.PercentChance( 5 ) ) {
						((Mob)victim).emote( "scream" );
					}
					((Mob)victim).adjust_blurriness( 5 );
					((Mob)victim).adjust_blindness( 2 );
					victim.confused = Num13.MaxInt( ((int)( M.confused )), 6 );
					victim.damageoverlaytemp = 75;
					((Mob)victim).Weaken( 5 );
					victim.drop_item();
				}
				((Mob_Living)victim).update_damage_hud();
			}
			return 0;
		}

	}

}