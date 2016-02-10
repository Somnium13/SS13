// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Condensedcapsaicin : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Condensed Capsaicin";
			this.id = "condensedcapsaicin";
			this.description = "This shit goes in pepperspray.";
			this.reagent_state = 2;
			this.color = "#B31008";
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}

			if ( Rand13.PercentChance( 5 ) ) {
				M.visible_message( "<span class='warning'>" + M + " " + Rand13.Pick(new object [] { "dry heaves!", "coughs!", "splutters!" }) + "</span>" );
			}
			return false;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool reaction_mob( dynamic M = null, int? method = null, double volume = 0 ) {
			method = method ?? GlobalVars.TOUCH;

			dynamic H = null;
			dynamic mouth_covered = null;
			dynamic eyes_covered = null;

			
			if ( base.reaction_mob( (object)(M), method, volume ) ) {
				return true;
			}

			if ( method == GlobalVars.TOUCH ) {
				
				if ( M is Mob_Living_Carbon_Human ) {
					H = M;
					mouth_covered = ((Mob_Living_Carbon_Human)H).get_body_part_coverage( 4096 );
					eyes_covered = ((Mob_Living_Carbon_Human)H).get_body_part_coverage( 2048 );

					if ( Lang13.Bool( eyes_covered ) && Lang13.Bool( mouth_covered ) ) {
						H.WriteMsg( "<span class='warning'>Your " + ( mouth_covered == eyes_covered ? "" + mouth_covered + " protects" : "" + mouth_covered + " and " + eyes_covered + " protect" ) + " you from the pepperspray!</span>" );
						return false;
					} else if ( Lang13.Bool( mouth_covered ) ) {
						H.WriteMsg( "<span class='warning'>Your " + mouth_covered + " protects your mouth from the pepperspray!</span>" );
						H.eye_blurry = Num13.MaxInt( Convert.ToInt32( M.eye_blurry ), 15 );
						H.eye_blind = Num13.MaxInt( M.eye_blind, 5 );
						((Mob)H).Paralyse( 1 );
						H.drop_item();
						return false;
					} else if ( Lang13.Bool( eyes_covered ) ) {
						H.WriteMsg( "<span class='warning'>Your " + eyes_covered + " protects your eyes from the pepperspray!</span>" );
						((Mob)H).emote( "scream", null, null, true );
						H.eye_blurry = Num13.MaxInt( Convert.ToInt32( M.eye_blurry ), 5 );
						return false;
					} else {
						((Mob)H).emote( "scream", null, null, true );
						H.WriteMsg( "<span class='danger'>You are sprayed directly in the eyes with pepperspray!</span>" );
						H.eye_blurry = Num13.MaxInt( Convert.ToInt32( M.eye_blurry ), 25 );
						H.eye_blind = Num13.MaxInt( M.eye_blind, 10 );
						((Mob)H).Paralyse( 1 );
						H.drop_item();
					}
				}
			}
			return false;
		}

	}

}