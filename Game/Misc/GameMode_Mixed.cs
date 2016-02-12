// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GameMode_Mixed : GameMode {

		public ByTable modes = null;
		public ByTable picked_antags = null;
		public int prob_int_murder_target = 50;
		public int prob_right_murder_target_l = 25;
		public int prob_right_murder_target_h = 50;
		public int prob_int_item = 50;
		public int prob_right_item_l = 25;
		public int prob_right_item_h = 50;
		public int prob_int_sab_target = 50;
		public int prob_right_sab_target_l = 25;
		public int prob_right_sab_target_h = 50;
		public int prob_right_killer_l = 25;
		public int prob_right_killer_h = 50;
		public int prob_right_objective_l = 25;
		public int prob_right_objective_h = 50;
		public int waittime_l = 600;
		public int waittime_h = 1800;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "mixed";
			this.config_tag = "mixed";
			this.required_players = 20;
			this.required_players_secret = 25;
		}

		// Function from file: mixed.dm
		public override void remove_cultist( Mind cult_mind = null, bool? show_message = null, bool? log = null ) {
			show_message = show_message ?? true;
			log = log ?? true;

			dynamic cult_round = null;

			cult_round = GlobalFuncs.find_active_mode( "cult" );

			if ( Lang13.Bool( cult_round ) ) {
				base.remove_cultist(cult_mind, show_message, log);
				((GameMode)cult_round).remove_cultist( cult_mind, show_message, log );
			} else {
				base.remove_cultist( cult_mind, show_message, log );
			}
			return;
		}

		// Function from file: mixed.dm
		public override bool add_cultist( dynamic cult_mind = null ) {
			dynamic cult_round = null;

			cult_round = GlobalFuncs.find_active_mode( "cult" );

			if ( Lang13.Bool( cult_round ) ) {
				((GameMode)cult_round).add_cultist( base.add_cultist( (object)(cult_mind) ) );
			} else {
				base.add_cultist( (object)(cult_mind) );
			}
			return false;
		}

		// Function from file: mixed.dm
		public override bool declare_completion( bool? ragin = null ) {
			GameMode M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.modes, typeof(GameMode) )) {
				M = _a;
				
				M.declare_completion();
			}
			return false;
		}

		// Function from file: mixed.dm
		public override bool check_finished(  ) {
			GameMode M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.modes, typeof(GameMode) )) {
				M = _a;
				

				if ( M.check_finished() ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: mixed.dm
		public override bool post_setup(  ) {
			GameMode M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.modes, typeof(GameMode) )) {
				M = _a;
				
				Task13.Schedule( 0, (Task13.Closure)(() => {
					M.post_setup();
					return;
				}));
			}
			Task13.Schedule( Rand13.Int( GlobalVars.waittime_l, GlobalVars.waittime_h ), (Task13.Closure)(() => {
				
				if ( !this.mixed ) {
					this.send_intercept();
				}
				return;
			}));
			return false;
		}

		// Function from file: mixed.dm
		public override bool pre_setup(  ) {
			bool _default = false;

			dynamic M = null;
			dynamic GM = null;
			dynamic possible = null;
			dynamic ourmode = null;
			dynamic M2 = null;
			dynamic keylist = null;
			Mind mind = null;

			_default = true;
			this.modes = new ByTable();
			this.picked_antags = new ByTable();

			if ( GlobalVars.mixed_modes.len != 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.mixed_modes )) {
					M = _a;
					
					GM = GlobalVars.config.pick_mode( M );
					GM.mixed = true;

					if ( ((GameMode)GM).pre_setup() ) {
						this.modes.Add( GM );
					} else {
						GlobalFuncs.qdel( GM );
					}
				}
			} else {
				possible = Lang13.GetTypes( typeof(GameMode) ) - new ByTable(new object [] { 
					typeof(GameMode), 
					typeof(GameMode_Mixed), 
					typeof(GameMode_Malfunction), 
					typeof(GameMode_Traitor), 
					typeof(GameMode_Traitor_DoubleAgents), 
					typeof(GameMode_Sandbox), 
					typeof(GameMode_Revolution), 
					typeof(GameMode_Meteor), 
					typeof(GameMode_Extended), 
					typeof(GameMode_Heist), 
					typeof(GameMode_Nuclear), 
					typeof(GameMode_Traitor_Changeling), 
					typeof(GameMode_Wizard_Raginmages), 
					typeof(GameMode_Blob)
				 });

				while (this.modes.len < 3) {
					
					if ( !( possible.len != 0 ) ) {
						break;
					}
					ourmode = Rand13.PickFromTable( possible );
					possible -= ourmode;
					M2 = Lang13.Call( ourmode );
					M2.mixed = true;

					if ( !((GameMode)M2).pre_setup() ) {
						GlobalFuncs.qdel( M2 );
						continue;
					}
					this.modes.Add( M2 );
				}
			}

			if ( !( this.modes.len != 0 ) ) {
				_default = false;
			} else {
				keylist = null;

				foreach (dynamic _b in Lang13.Enumerate( this.modePlayer, typeof(Mind) )) {
					mind = _b;
					
					keylist += mind;
				}
				GlobalFuncs.log_admin( new Txt( "The gamemode setup for mixed started with " ).item( this.modes.len ).str( " mode" ).s().str( " " ).item( GlobalFuncs.list2text( this.modes, " " ) ).str( " with " ).item( GlobalFuncs.list2text( keylist, " " ) ).str( " as antag" ).s().str( "." ).ToString() );
				GlobalFuncs.message_admins( new Txt( "The gamemode setup for mixed started with " ).item( this.modes.len ).str( " mode" ).s().str( "." ).ToString() );
				Game13.log.WriteMsg( new Txt( "The gamemode setup for mixed started with " ).item( this.modes.len ).str( " mode" ).s().str( " " ).item( GlobalFuncs.list2text( this.modes, " " ) ).str( " with " ).item( GlobalFuncs.list2text( keylist, " " ) ).str( " as antag" ).s().str( "." ).ToString() );
			}
			return _default;
		}

		// Function from file: mixed.dm
		public override void announce(  ) {
			GlobalFuncs.to_chat( typeof(Game13), "<B>The current game mode is - Mixed!</B>" );
			GlobalFuncs.to_chat( typeof(Game13), "<B>Anything can happen!</B>" );
			return;
		}

	}

}