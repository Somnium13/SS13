// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GameMode_Traitor_Autotraitor : GameMode_Traitor {

		public ByTable possible_traitors = null;
		public int v_num_players = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "AutoTraitor";
			this.config_tag = "autotraitor";
		}

		// Function from file: autotraitor.dm
		public override void latespawn( Mob_Living_Carbon_Human mob = null ) {
			int playercount = 0;
			int traitorcount = 0;
			Mob_Living player = null;
			int max_traitors = 0;
			int traitor_prob = 0;
			dynamic wikiroute = null;
			int obj_count = 0;
			Objective objective = null;

			base.latespawn( mob );

			if ( GlobalVars.emergency_shuttle.departed ) {
				return;
			}

			if ( mob.client != null && Lang13.Bool( mob.client.desires_role( "traitor" ) ) && !Lang13.Bool( GlobalFuncs.jobban_isbanned( mob, "Syndicate" ) ) ) {
				playercount = 0;
				traitorcount = 0;

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.mob_list, typeof(Mob_Living) )) {
					player = _a;
					

					if ( player.z == GlobalVars.map.zCentcomm ) {
						continue;
					}

					if ( player.client != null && player.stat != 2 ) {
						playercount += 1;
					}

					if ( player.client != null && player.mind != null && Lang13.Bool( player.mind.special_role ) && player.stat != 2 ) {
						traitorcount += 1;
					}
				}
				max_traitors = 2;
				traitor_prob = 0;
				max_traitors = Num13.Floor( playercount / 10 ) + 1;
				traitor_prob = ( playercount - ( max_traitors - 1 ) * 10 ) * 5;

				if ( traitorcount < max_traitors - 1 ) {
					traitor_prob += 50;
				}

				if ( traitorcount < max_traitors ) {
					
					if ( Rand13.PercentChance( traitor_prob ) ) {
						GlobalFuncs.message_admins( "New traitor roll passed.  Making a new Traitor." );
						this.forge_traitor_objectives( mob.mind );
						this.equip_traitor( mob );
						this.traitors.Add( mob.mind );

						if ( this.mixed ) {
							GlobalVars.ticker.mode.traitors.Or( mob.mind );
							GlobalVars.ticker.mode.modePlayer.Or( mob.mind );
						}
						wikiroute = GlobalVars.role_wiki["traitor"];
						GlobalFuncs.to_chat( mob, new Txt( "<span class='danger'>You are the traitor.</span> <span class='info'><a HREF='?src=" ).Ref( mob ).str( ";getwiki=" ).item( wikiroute ).str( "'>(Wiki Guide)</a></span>" ).ToString() );
						mob.mind.special_role = "traitor";
						obj_count = 1;
						GlobalFuncs.to_chat( mob, "<span class='notice'>Your current objectives:</span>" );

						foreach (dynamic _b in Lang13.Enumerate( mob.mind.objectives, typeof(Objective) )) {
							objective = _b;
							
							GlobalFuncs.to_chat( mob, "<B>Objective #" + obj_count + "</B>: " + objective.explanation_text );
							obj_count++;
						}
						GlobalFuncs.to_chat( mob, new Sound( "sound/voice/syndicate_intro.ogg" ) );
					}
				}
			}
			return;
		}

		// Function from file: autotraitor.dm
		public void traitorcheckloop(  ) {
			int playercount = 0;
			int traitorcount = 0;
			ByTable possible_traitors = null;
			Mob_Living player = null;
			Mind player2 = null;
			dynamic job = null;
			int max_traitors = 0;
			int traitor_prob = 0;
			dynamic traitor_body = null;
			Mind traitor_mind = null;

			Task13.Schedule( 9000, (Task13.Closure)(() => {
				
				if ( GlobalVars.emergency_shuttle.departed ) {
					return;
				}
				playercount = 0;
				traitorcount = 0;
				possible_traitors = new ByTable( 0 );

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.mob_list, typeof(Mob_Living) )) {
					player = _a;
					

					if ( player.z == GlobalVars.map.zCentcomm ) {
						continue;
					}

					if ( player.client != null && player.stat != 2 ) {
						playercount += 1;
					}

					if ( player.client != null && player.mind != null && Lang13.Bool( player.mind.special_role ) && player.stat != 2 ) {
						traitorcount += 1;
					}

					if ( player.client != null && player.mind != null && !Lang13.Bool( player.mind.special_role ) && player.stat != 2 && player.client != null && Lang13.Bool( player.client.desires_role( "traitor" ) ) && !Lang13.Bool( GlobalFuncs.jobban_isbanned( player, "Syndicate" ) ) && !( player is Mob_Living_Silicon_Robot_Mommi ) ) {
						possible_traitors.Add( player );
					}
				}

				foreach (dynamic _c in Lang13.Enumerate( possible_traitors, typeof(Mind) )) {
					player2 = _c;
					

					if ( this.mixed && GlobalVars.ticker.mode.modePlayer.Contains( player2 ) ) {
						possible_traitors.Remove( player2 );
						continue;
					}

					foreach (dynamic _b in Lang13.Enumerate( this.restricted_jobs )) {
						job = _b;
						

						if ( player2.assigned_role == job ) {
							possible_traitors.Remove( player2 );
						}
					}
				}
				max_traitors = 1;
				traitor_prob = 0;
				max_traitors = Num13.Floor( playercount / 10 ) + 1;
				traitor_prob = ( playercount - ( max_traitors - 1 ) * 10 ) * 5;

				if ( traitorcount < max_traitors - 1 ) {
					traitor_prob += 50;
				}

				if ( traitorcount < max_traitors ) {
					
					if ( Rand13.PercentChance( traitor_prob ) ) {
						GlobalFuncs.message_admins( "AUTOTRAITOR: making someone traitor" );

						if ( possible_traitors.len > 0 ) {
							traitor_body = Rand13.PickFromTable( possible_traitors );

							if ( Lang13.Bool( traitor_body ) ) {
								traitor_mind = traitor_body.mind;

								if ( traitor_mind != null ) {
									
									if ( traitor_mind.make_traitor() == true ) {
										GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "" + GlobalFuncs.key_name( traitor_body ) + " has been auto traitor'ed." ) ) );
										GlobalFuncs.message_admins( "AUTOTRAITOR: " + GlobalFuncs.key_name_admin( traitor_body ) + " is now a traitor" );
									}
								}
							}
						} else {
							GlobalFuncs.message_admins( "AUTOTRAITOR: no potential traitors, mission is kill" );
						}
					}
				}
				this.traitorcheckloop();
				return;
			}));
			return;
		}

		// Function from file: autotraitor.dm
		public override bool post_setup(  ) {
			
			if ( !this.mixed ) {
				base.post_setup();
			}
			GlobalVars.abandon_allowed = true;
			this.traitorcheckloop();
			return false;
		}

		// Function from file: autotraitor.dm
		public override bool pre_setup(  ) {
			Mind player = null;
			dynamic job = null;
			int? num_traitors = null;
			int max_traitors = 0;
			int traitor_prob = 0;
			int? i = null;
			dynamic traitor = null;
			Mind traitor2 = null;

			
			if ( GlobalVars.ticker.mode is GameMode_Mixed ) {
				this.mixed = true;
			}

			if ( GlobalVars.config.protect_roles_from_antagonist ) {
				this.restricted_jobs.Add( this.protected_jobs );
			}
			this.possible_traitors = this.get_players_for_role( "traitor" );

			foreach (dynamic _b in Lang13.Enumerate( this.possible_traitors, typeof(Mind) )) {
				player = _b;
				

				if ( this.mixed && GlobalVars.ticker.mode.modePlayer.Contains( player ) ) {
					this.possible_traitors.Remove( player );
					continue;
				}

				foreach (dynamic _a in Lang13.Enumerate( this.restricted_jobs )) {
					job = _a;
					

					if ( player.assigned_role == job ) {
						this.possible_traitors.Remove( player );
						continue;
					}
				}
			}
			this.v_num_players = this.num_players();
			num_traitors = 1;
			max_traitors = 1;
			traitor_prob = 0;
			max_traitors = Num13.Floor( this.v_num_players / 10 ) + 1;
			traitor_prob = ( this.v_num_players - ( max_traitors - 1 ) * 10 ) * 10;

			if ( !( this.possible_traitors.len != 0 ) ) {
				GlobalFuncs.log_admin( "Failed to set-up a round of AutoTraitor. Couldn't find any volunteers to be traitor." );
				GlobalFuncs.message_admins( "Failed to set-up a round of AutoTraitor. Couldn't find any volunteers to be traitor." );
				return false;
			}

			if ( GlobalVars.config.traitor_scaling ) {
				num_traitors = max_traitors - 1 + ( Rand13.PercentChance( traitor_prob ) ?1:0);

				if ( this.mixed ) {
					num_traitors = Num13.MinInt( 3, num_traitors ??0 );
				}
			} else {
				num_traitors = Num13.MaxInt( 1, Num13.MinInt( this.num_players(), this.traitors_possible ) );
			}
			i = null;
			i = 0;

			while (( i ??0) < ( num_traitors ??0)) {
				traitor = Rand13.PickFromTable( this.possible_traitors );

				if ( Lang13.Bool( traitor.special_role ) ) {
					this.possible_traitors.Remove( traitor );
				} else {
					this.traitors.Add( traitor );
					this.possible_traitors.Remove( traitor );
				}
				i++;
			}

			foreach (dynamic _c in Lang13.Enumerate( this.traitors, typeof(Mind) )) {
				traitor2 = _c;
				

				if ( !( traitor2 != null ) || !( traitor2 is Mind ) ) {
					this.traitors.Remove( traitor2 );
					continue;
				}

				if ( traitor2 is Mind ) {
					traitor2.special_role = "traitor";
				}
			}

			if ( this.mixed ) {
				GlobalVars.ticker.mode.modePlayer.Add( this.traitors );
				GlobalVars.ticker.mode.traitors.Add( this.traitors );
			}
			GlobalFuncs.log_admin( "Starting a round of AutoTraitor with " + this.traitors.len + " starting traitors." );
			GlobalFuncs.message_admins( "Starting a round of AutoTraitor with " + this.traitors.len + " starting traitors." );
			return true;
		}

		// Function from file: autotraitor.dm
		public override void announce(  ) {
			base.announce();
			GlobalFuncs.to_chat( typeof(Game13), "<B>Game mode is AutoTraitor. Traitors will be added to the round automagically as needed.<br>Expect bugs.</B>" );
			return;
		}

	}

}