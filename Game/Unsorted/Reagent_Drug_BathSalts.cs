// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Drug_BathSalts : Reagent_Drug {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Bath Salts";
			this.id = "bath_salts";
			this.description = "Makes you nearly impervious to stuns and grants a stamina regeneration buff, but you will be a nearly uncontrollable tramp-bearded raving lunatic.";
			this.color = "#60A584";
			this.overdose_threshold = 20;
			this.addiction_threshold = 10;
		}

		// Function from file: drug_reagents.dm
		public override void addiction_act_stage4( dynamic M = null ) {
			int? i = null;

			M.hallucination += 40;

			if ( Lang13.Bool( M.canmove ) && !( M.loc is Ent_Dynamic ) ) {
				i = null;
				i = 0;

				while (( i ??0) < 16) {
					Map13.Step( M, Convert.ToInt32( Rand13.PickFromTable( GlobalVars.cardinal ) ) );
					i++;
				}
			}
			((Mob)M).Jitter( 50 );
			((Mob)M).Dizzy( 50 );
			((Mob_Living)M).adjustToxLoss( 5 );
			((Mob_Living)M).adjustBrainLoss( 10 );

			if ( Rand13.PercentChance( 50 ) ) {
				((Mob)M).emote( Rand13.Pick(new object [] { "twitch", "drool", "moan" }) );
			}
			base.addiction_act_stage4( (object)(M) );
			return;
		}

		// Function from file: drug_reagents.dm
		public override void addiction_act_stage3( dynamic M = null ) {
			int? i = null;

			M.hallucination += 30;

			if ( Lang13.Bool( M.canmove ) && !( M.loc is Ent_Dynamic ) ) {
				i = null;
				i = 0;

				while (( i ??0) < 12) {
					Map13.Step( M, Convert.ToInt32( Rand13.PickFromTable( GlobalVars.cardinal ) ) );
					i++;
				}
			}
			((Mob)M).Jitter( 15 );
			((Mob)M).Dizzy( 15 );
			((Mob_Living)M).adjustBrainLoss( 10 );

			if ( Rand13.PercentChance( 40 ) ) {
				((Mob)M).emote( Rand13.Pick(new object [] { "twitch", "drool", "moan" }) );
			}
			base.addiction_act_stage3( (object)(M) );
			return;
		}

		// Function from file: drug_reagents.dm
		public override void addiction_act_stage2( dynamic M = null ) {
			int? i = null;

			M.hallucination += 20;

			if ( Lang13.Bool( M.canmove ) && !( M.loc is Ent_Dynamic ) ) {
				i = null;
				i = 0;

				while (( i ??0) < 8) {
					Map13.Step( M, Convert.ToInt32( Rand13.PickFromTable( GlobalVars.cardinal ) ) );
					i++;
				}
			}
			((Mob)M).Jitter( 10 );
			((Mob)M).Dizzy( 10 );
			((Mob_Living)M).adjustBrainLoss( 10 );

			if ( Rand13.PercentChance( 30 ) ) {
				((Mob)M).emote( Rand13.Pick(new object [] { "twitch", "drool", "moan" }) );
			}
			base.addiction_act_stage2( (object)(M) );
			return;
		}

		// Function from file: drug_reagents.dm
		public override void addiction_act_stage1( dynamic M = null ) {
			int? i = null;

			M.hallucination += 10;

			if ( Lang13.Bool( M.canmove ) && !( M.loc is Ent_Dynamic ) ) {
				i = null;
				i = 0;

				while (( i ??0) < 8) {
					Map13.Step( M, Convert.ToInt32( Rand13.PickFromTable( GlobalVars.cardinal ) ) );
					i++;
				}
			}
			((Mob)M).Jitter( 5 );
			((Mob_Living)M).adjustBrainLoss( 10 );

			if ( Rand13.PercentChance( 20 ) ) {
				((Mob)M).emote( Rand13.Pick(new object [] { "twitch", "drool", "moan" }) );
			}
			base.addiction_act_stage1( (object)(M) );
			return;
		}

		// Function from file: drug_reagents.dm
		public override void overdose_process( dynamic M = null ) {
			int? i = null;
			dynamic I = null;

			M.hallucination += 10;

			if ( Lang13.Bool( M.canmove ) && !( M.loc is Ent_Dynamic ) ) {
				i = null;
				i = 0;

				while (( i ??0) < 8) {
					Map13.Step( M, Convert.ToInt32( Rand13.PickFromTable( GlobalVars.cardinal ) ) );
					i++;
				}
			}

			if ( Rand13.PercentChance( 20 ) ) {
				((Mob)M).emote( Rand13.Pick(new object [] { "twitch", "drool", "moan" }) );
			}

			if ( Rand13.PercentChance( 33 ) ) {
				I = ((Mob)M).get_active_hand();

				if ( Lang13.Bool( I ) ) {
					((Mob)M).drop_item();
				}
			}
			base.overdose_process( (object)(M) );
			return;
		}

		// Function from file: drug_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			dynamic high_message = null;

			high_message = Rand13.Pick(new object [] { "You feel amped up.", "You feel ready.", "You feel like you can push it to the limit." });

			if ( Rand13.PercentChance( 5 ) ) {
				M.WriteMsg( "<span class='notice'>" + high_message + "</span>" );
			}
			((Mob)M).AdjustParalysis( -3 );
			((Mob)M).AdjustStunned( -3 );
			((Mob)M).AdjustWeakened( -3 );
			((Mob_Living)M).adjustStaminaLoss( -5 );
			((Mob_Living)M).adjustBrainLoss( 0.5 );
			((Mob_Living)M).adjustToxLoss( 0.1 );
			M.hallucination += 10;

			if ( Lang13.Bool( M.canmove ) && !( M.loc is Ent_Dynamic ) ) {
				Map13.Step( M, Convert.ToInt32( Rand13.PickFromTable( GlobalVars.cardinal ) ) );
				Map13.Step( M, Convert.ToInt32( Rand13.PickFromTable( GlobalVars.cardinal ) ) );
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}