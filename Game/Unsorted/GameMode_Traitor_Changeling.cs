// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GameMode_Traitor_Changeling : GameMode_Traitor {

		public ByTable possible_changelings = new ByTable();
		public bool changeling_amount = true;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "traitor+changeling";
			this.config_tag = "traitorchan";
			this.traitors_possible = 3;
			this.restricted_jobs = new ByTable(new object [] { "AI", "Cyborg" });
			this.recommended_enemies = 3;
		}

		// Function from file: traitor_chan.dm
		public override void make_antag_chance( Mob_Living_Carbon_Human character = null ) {
			int changelingcap = 0;

			changelingcap = Num13.MinInt( Num13.Floor( GlobalVars.joined_player_list.len / ( ( GlobalVars.config.changeling_scaling_coeff ??0) * 4 ) ) + 2, Num13.Floor( GlobalVars.joined_player_list.len / ( ( GlobalVars.config.changeling_scaling_coeff ??0) * 2 ) ) );

			if ( GlobalVars.ticker.mode.changelings.len >= changelingcap ) {
				base.make_antag_chance( character );
				return;
			}

			if ( GlobalVars.ticker.mode.changelings.len <= changelingcap - 2 || Rand13.PercentChance( ((int)( 100 / ( ( GlobalVars.config.changeling_scaling_coeff ??0) * 4 ) )) ) ) {
				
				if ( character.client.prefs.be_special.Contains( "changeling" ) ) {
					
					if ( !GlobalFuncs.jobban_isbanned( character.client, "changeling" ) && !GlobalFuncs.jobban_isbanned( character.client, "Syndicate" ) ) {
						
						if ( this.age_check( character.client ) ) {
							
							if ( !this.restricted_jobs.Contains( character.job ) ) {
								character.mind.make_Changling();
							}
						}
					}
				}
			}
			base.make_antag_chance( character );
			return;
		}

		// Function from file: traitor_chan.dm
		public override bool post_setup( bool? report = null ) {
			Mind changeling = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.changelings, typeof(Mind) )) {
				changeling = _a;
				
				((Mob)changeling.current).make_changeling(  );
				changeling.special_role = "Changeling";
				this.forge_changeling_objectives( changeling );
				this.greet_changeling( changeling );
			}
			base.post_setup( report );
			return false;
		}

		// Function from file: traitor_chan.dm
		public override bool pre_setup(  ) {
			ByTable possible_changelings = null;
			int? num_changelings = null;
			int? j = null;
			dynamic changeling = null;

			
			if ( GlobalVars.config.protect_roles_from_antagonist ) {
				this.restricted_jobs.Add( this.protected_jobs );
			}

			if ( GlobalVars.config.protect_assistant_from_antagonist ) {
				this.restricted_jobs.Add( "Assistant" );
			}
			possible_changelings = this.get_players_for_role( "changeling" );
			num_changelings = 1;

			if ( Lang13.Bool( GlobalVars.config.changeling_scaling_coeff ) ) {
				num_changelings = Num13.MaxInt( 1, Num13.MinInt( Num13.Floor( this.num_players() / ( ( GlobalVars.config.changeling_scaling_coeff ??0) * 4 ) ) + 2, Num13.Floor( this.num_players() / ( ( GlobalVars.config.changeling_scaling_coeff ??0) * 2 ) ) ) );
			} else {
				num_changelings = Num13.MaxInt( 1, Num13.MinInt( this.num_players(), ((int)( 0.5 )) ) );
			}

			if ( possible_changelings.len > 0 ) {
				j = null;
				j = 0;

				while (( j ??0) < ( num_changelings ??0)) {
					
					if ( !( possible_changelings.len != 0 ) ) {
						break;
					}
					changeling = Rand13.PickFromTable( possible_changelings );
					possible_changelings.Remove( changeling );
					this.changelings.Add( changeling );
					this.modePlayer.Add( this.changelings );
					changeling.restricted_roles = this.restricted_jobs;
					j++;
				}
				return base.pre_setup();
			} else {
				return false;
			}
		}

		// Function from file: traitor_chan.dm
		public override bool can_start(  ) {
			
			if ( !base.can_start() ) {
				return false;
			}
			this.possible_changelings = this.get_players_for_role( "changeling" );

			if ( this.possible_changelings.len < this.required_enemies ) {
				return false;
			}
			return true;
		}

		// Function from file: traitor_chan.dm
		public override void announce(  ) {
			Game13.WriteMsg( "<B>The current game mode is - Traitor+Changeling!</B>" );
			Game13.WriteMsg( "<B>There are alien creatures on the station along with some syndicate operatives out for their own gain! Do not let the changelings or the traitors succeed!</B>" );
			return;
		}

	}

}