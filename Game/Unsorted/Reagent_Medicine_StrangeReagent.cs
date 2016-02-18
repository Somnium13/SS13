// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Medicine_StrangeReagent : Reagent_Medicine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Strange Reagent";
			this.id = "strange_reagent";
			this.description = "A miracle drug capable of bringing the dead back to life. Only functions if the target has less than 100 brute and burn damage (independent of one another), and causes slight damage to the living.";
			this.color = "#C8A5DC";
			this.metabolization_rate = 0.2;
		}

		// Function from file: medicine_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			((Mob_Living)M).adjustBruteLoss( 0.5 );
			((Mob_Living)M).adjustFireLoss( 0.5 );
			base.on_mob_life( (object)(M) );
			return false;
		}

		// Function from file: medicine_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			
			if ( Convert.ToInt32( M.stat ) == 2 ) {
				
				if ( ((Mob_Living)M).getBruteLoss() >= 100 || ((Mob_Living)M).getFireLoss() >= 100 ) {
					((Ent_Static)M).visible_message( "<span class='warning'>" + M + "'s body convulses a bit, and then falls still once more.</span>" );
					return 0;
				}
				((Ent_Static)M).visible_message( "<span class='warning'>" + M + "'s body convulses a bit.</span>" );

				if ( !Lang13.Bool( M.suiciding ) && !Lang13.Bool( M.disabilities & 128 ) ) {
					
					if ( !Lang13.Bool( M ) ) {
						return 0;
					}

					if ( ((Mob)M).notify_ghost_cloning( null, null, M ) != null ) {
						Task13.Schedule( 100, (Task13.Closure)(() => {
							return;
							return;
						}));
					} else {
						((Mob_Living)M).adjustOxyLoss( -20 );
						((Mob_Living)M).adjustToxLoss( -20 );

						if ( Convert.ToDouble( M.health ) > ( GlobalVars.config.health_threshold_dead ??0) && Lang13.Bool( ((Mob)M).getorgan( typeof(Obj_Item_Organ_Internal_Brain) ) ) ) {
							M.stat = 1;
							((Mob)M).blind_eyes( 1 );
							GlobalVars.dead_mob_list.Remove( M );
							GlobalVars.living_mob_list.Or( new ByTable(new object [] { M }) );
							((Mob)M).emote( "gasp" );
							GlobalFuncs.add_logs( M, M, "revived", this );
						}
					}
				}
			}
			base.reaction_mob( (object)(M), method, reac_volume, show_message, (object)(touch_protection), O );
			return 0;
		}

	}

}