// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GameMode_Traitor_Changeling : GameMode_Traitor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "traitor+changeling";
			this.config_tag = "traitorchan";
			this.traitors_possible = 3;
			this.restricted_jobs = new ByTable(new object [] { "AI", "Cyborg", "Mobile MMI" });
			this.required_players = 1;
			this.required_players_secret = 15;
			this.required_enemies = 2;
			this.recommended_enemies = 3;
		}

		// Function from file: vgstation13.dme
		public override bool post_setup(  ) {
			Mind changeling = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.changelings, typeof(Mind) )) {
				changeling = _a;
				
				this.grant_changeling_powers( changeling.current );
				changeling.special_role = "Changeling";
				this.forge_changeling_objectives( changeling );
				this.greet_changeling( changeling );
			}
			base.post_setup();
			return false;
		}

		// Function from file: traitor_chan.dm
		public override bool pre_setup(  ) {
			bool _default = false;

			ByTable possible_changelings = null;
			Mind player = null;
			dynamic job = null;
			dynamic changeling = null;
			Mind P = null;

			
			if ( GlobalVars.ticker.mode is GameMode_Mixed ) {
				this.mixed = true;
			}

			if ( GlobalVars.config.protect_roles_from_antagonist ) {
				this.restricted_jobs.Add( this.protected_jobs );
			}
			possible_changelings = this.get_players_for_role( "changeling" );

			foreach (dynamic _b in Lang13.Enumerate( possible_changelings, typeof(Mind) )) {
				player = _b;
				

				if ( this.mixed && GlobalVars.ticker.mode.modePlayer.Contains( player ) ) {
					possible_changelings.Remove( player );
					continue;
				}

				foreach (dynamic _a in Lang13.Enumerate( this.restricted_jobs )) {
					job = _a;
					

					if ( player.assigned_role == job ) {
						possible_changelings.Remove( player );
					}
				}
			}

			if ( possible_changelings.len > 0 ) {
				changeling = Rand13.PickFromTable( possible_changelings );
				this.changelings.Add( changeling );
				this.modePlayer.Add( this.changelings );

				if ( this.mixed ) {
					GlobalVars.ticker.mode.modePlayer.Add( this.changelings );
					GlobalVars.ticker.mode.changelings.Add( this.changelings );
				}
				_default = base.pre_setup();

				if ( !_default && this.mixed ) {
					
					foreach (dynamic _c in Lang13.Enumerate( this.modePlayer, typeof(Mind) )) {
						P = _c;
						
						GlobalVars.ticker.mode.modePlayer.Remove( P );
						GlobalVars.ticker.mode.changelings.Remove( P );
					}
				} else {
					GlobalVars.ticker.mode.modePlayer.Add( this.traitors );
					GlobalVars.ticker.mode.traitors.Add( this.traitors );
				}
				return _default;
			} else {
				return false;
			}
		}

		// Function from file: traitor_chan.dm
		public override void announce(  ) {
			GlobalFuncs.to_chat( typeof(Game13), "<B>The current game mode is - Traitor+Changeling!</B>" );
			GlobalFuncs.to_chat( typeof(Game13), "<B>There is an alien creature on the station along with some syndicate operatives out for their own gain! Do not let the changeling and the traitors succeed!</B>" );
			return;
		}

	}

}