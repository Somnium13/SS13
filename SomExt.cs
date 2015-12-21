using System;
using Game13;

namespace Som13 {
	partial class BaseData {

		public dynamic gc_destroyed = null;

		public void ResetVars(  ) {
			ByTable excluded = null;
			dynamic V = null;
			excluded = new ByTable(new object [] { "animate_movement", "contents", "loc", "locs", "parent_type", "vars", "verbs", "type" });
			V = null;
			foreach (dynamic _a in this.vars ) {
				V = _a;
				if ( Misc13.isValid( excluded.HasValue( V ) ) ) {
					continue;
				}
				this.vars[V] = Misc13.initial( this.vars[V] );
			};
			return;
		}

		public int process(  ) {
			GlobalVars.SSobj.processing.Remove( this );
			return 0;
		}

		public int Destroy(  ) {
			this.tag = null;
			return 0;
		}

	}

	partial class BaseStatic : BaseData {

		public int smooth = 0;
		public dynamic top_left_corner = null;
		public dynamic top_right_corner = null;
		public dynamic bottom_left_corner = null;
		public dynamic bottom_right_corner = null;
		public int can_be_unanchored = 0;
		public dynamic canSmoothWith = null;
		public dynamic suit_fibers = null;
		public int level = 2;
		public int flags = 0;
		public ByTable fingerprints = null;
		public dynamic fingerprintshidden = null;
		public dynamic fingerprintslast = null;
		public ByTable blood_DNA = null;
		public Reagents reagents = null;
		public dynamic hud_list = null;
		public dynamic hud_possible = null;
		public int explosion_block = 0;
		public LightSource light = null;

		public BaseStatic ( dynamic _loc = null ) {
			this.loc = _loc;
			if ( ( GlobalVars._preloader != null ) && this.type == GlobalVars._preloader.target_path ) {
				GlobalVars._preloader.load( this );
			}
			throw "Ctor fault.";
			return;
		}

		public void Read( dynamic S = null ) {
			dynamic l = null;
			dynamic ic = null;
			if ( Misc13.isValid( this.contents.len ) ) {
				l = this.contents;
			}
			base.Read();
			if ( !Misc13.isValid( this.icon ) && Misc13.isValid( S.dir.HasValue( "icon" ) ) ) {
				ic = S["icon"].read();
				if ( ic is string ) {
					this.icon = GlobalVars.swapmaps_iconcache[ic];
				}
			}
			if ( Misc13.isValid( l ) && this.contents != l ) {
				this.contents += l;
				GlobalFuncs.qdel( l );
			}
			return;
		}

		public void Write( dynamic S = null ) {
			dynamic V = null;
			dynamic M = null;
			dynamic l = null;
			V = null;
			foreach (dynamic _a in this.vars - "x" - "y" - "z" - "contents" - "icon" - "overlays" - "underlays" ) {
				V = _a;
				if ( Misc13.isValid( Misc13.call( GlobalVars.undefined, this.vars[V] ) ) ) {
					if ( this.vars[V] != Misc13.initial( this.vars[V] ) ) {
						S[V].write( this.vars[V] );
					} else {
						S.dir.Remove( V );
					}
				}
			};
			if ( this.icon != Misc13.initial( this.icon ) ) {
				if ( Misc13.isValid( GlobalVars.swapmaps_iconcache ) && Misc13.isValid( GlobalVars.swapmaps_iconcache[this.icon] ) ) {
					S["icon"].write( GlobalVars.swapmaps_iconcache[this.icon] );
				} else {
					S["icon"].write( this.icon );
				}
			}
			M = null;
			foreach (dynamic _b in this ) {
				M = _b;
				if ( Misc13.isValid( M.key ) ) {
					break;
				}
			};
			if ( Misc13.isValid( this.overlays.len ) ) {
				S["overlays"].write( this.overlays );
			}
			if ( Misc13.isValid( this.underlays.len ) ) {
				S["underlays"].write( this.underlays );
			}
			if ( Misc13.isValid( this.contents.len ) && !( this is Zone ) ) {
				l = this.contents;
				if ( Misc13.isValid( M ) ) {
					l = l.Copy();
					foreach (dynamic _c in this ) {
						M = _c;
						if ( Misc13.isValid( M.key ) ) {
							l -= M;
						}
					};
				}
				if ( Misc13.isValid( l.len ) ) {
					S["contents"].write( l );
				}
				if ( l != this.contents ) {
					GlobalFuncs.qdel( l );
				}
			}
			return;
		}

		public dynamic Stat(  ) {
			dynamic _default = null;
			_default = base.Stat();
			Thread13.sleep( 1 );
			return null;
			return _default;
		}

		public int MouseDrop( dynamic over = null, dynamic src_location = null, dynamic over_location = null, dynamic src_control = null, dynamic over_control = null, dynamic _params = null ) {
			if ( !Misc13.isValid( Misc13.thread_user ) || !Misc13.isValid( over ) ) {
				return 0;
			}
			if ( over == this ) {
				return Misc13.thread_user.client.Click( this, src_location, src_control, _params );
			}
			if ( !Misc13.isValid( this.Adjacent( Misc13.thread_user ) ) || !Misc13.isValid( over.Adjacent( Misc13.thread_user ) ) ) {
				return 0;
			}
			over.MouseDrop_T( this, Misc13.thread_user );
			return 0;
		}

		public void DblClick( dynamic location = null, dynamic control = null, dynamic _params = null ) {
			Misc13.thread_user.DblClickOn( this, _params );
			return;
		}

		public int Click( dynamic location = null, dynamic control = null, dynamic _params = null ) {
			Misc13.thread_user.ClickOn( this, _params );
			return 0;
		}

		public void shuttleRotate( dynamic rotation = null ) {
			dynamic turntimes = null;
			dynamic oldPX = null;
			dynamic oldPY = null;
			this.dir = GlobalFuncs.angle2dir( rotation + GlobalFuncs.dir2angle( this.dir ) );
			if ( this.smooth != 0 ) {
				GlobalFuncs.smooth_icon( this );
			}
			if ( Misc13.isValid( this.pixel_x ) || Misc13.isValid( this.pixel_y ) ) {
				if ( rotation < 0 ) {
					rotation += 360;
				}
				turntimes = null;
				turntimes = rotation / 90;
				while (turntimes > 0) {
					oldPX = this.pixel_x;
					oldPY = this.pixel_y;
					this.pixel_x = oldPY;
					this.pixel_y = oldPX * -1;
					turntimes--;
				}
			}
			return;
		}

		public void create_reagents( int max_vol = 0 ) {
			if ( this.reagents != null ) {
				GlobalFuncs.qdel( this.reagents );
			}
			this.reagents = new Reagents( max_vol );
			this.reagents.my_atom = this;
			return;
		}

		public dynamic ninjadrain_act(  ) {
			return "INVALID";
		}

		public void swarmer_act( dynamic S = null ) {
			S.DisIntegrate( this );
			return;
		}

		public void move_camera_by_click(  ) {
			dynamic AI = null;
			if ( Misc13.thread_user is Mob_Living_Silicon_Ai ) {
				AI = Misc13.thread_user;
				if ( Misc13.isValid( AI.eyeobj ) && AI.client.eye == AI.eyeobj ) {
					AI.cameraFollow = null;
					if ( this.loc is Tile || this is Tile ) {
						AI.eyeobj.setLoc( this );
					}
				}
			}
			return;
		}

		public dynamic update_pipe_vision( dynamic new_loc = null ) {
			if ( new_loc == null ) {
				new_loc = null;
			}
			return null;
		}

		public void audible_message( string message = "", string deaf_message = "", dynamic hearing_distance = null ) {
			int range = 0;
			dynamic M = null;
			range = 7;
			if ( Misc13.isValid( hearing_distance ) ) {
				range = hearing_distance;
			}
			M = null;
			foreach (dynamic _a in GlobalFuncs.get_hearers_in_view( range, this ) ) {
				M = _a;
				M.show_message( message, 2, deaf_message, 1 );
			};
			return;
		}

		public void visible_message( string message = "", string blind_message = "" ) {
			ByTable mob_viewers = null;
			ByTable possible_viewers = null;
			dynamic heard = null;
			dynamic A = null;
			dynamic B = null;
			dynamic T = null;
			dynamic M = null;
			ByTable mob_hearers = null;
			dynamic C = null;
			dynamic MOB = null;
			mob_viewers = new ByTable();
			possible_viewers = new ByTable();
			mob_viewers |= Misc13.viewers( this, null );
			heard = GlobalFuncs.get_hear( 7, this );
			A = null;
			foreach (dynamic _a in heard ) {
				A = _a;
				if ( !( A is BaseDynamic ) ) {
					continue;
				}
				possible_viewers |= GlobalFuncs.recursive_hear_check( A );
			};
			B = null;
			foreach (dynamic _b in possible_viewers ) {
				B = _b;
				if ( Misc13.isValid( mob_viewers.HasValue( B ) ) ) {
					continue;
				}
				if ( B.loc is Tile ) {
					continue;
				}
				T = GlobalFuncs.get_turf( B );
				if ( Misc13.isValid( Misc13.view( T, null ).HasValue( this ) ) ) {
					mob_viewers |= B;
				}
			};
			M = null;
			foreach (dynamic _c in mob_viewers ) {
				M = _c;
				M.show_message( message, 1 );
			};
			if ( Misc13.isValid( blind_message ) ) {
				mob_hearers = new ByTable();
				C = null;
				foreach (dynamic _d in GlobalFuncs.get_hearers_in_view( 7, this ) ) {
					C = _d;
					if ( Misc13.isValid( mob_viewers.HasValue( C ) ) ) {
						continue;
					}
					mob_hearers |= C;
				};
				MOB = null;
				foreach (dynamic _e in mob_hearers ) {
					MOB = _e;
					MOB.show_message( blind_message, 2 );
				};
			}
			return;
		}

		public void prepare_huds(  ) {
			dynamic hud = null;
			hud = null;
			foreach (dynamic _a in this.hud_possible ) {
				hud = _a;
				this.hud_list[hud] = new Image( new ByRsc(229), this, "" );
			};
			return;
		}

		public dynamic get_light_range( dynamic radius = null ) {
			return Misc13.min( radius, 8 );
		}

		public void UpdateAffectingLights(  ) {
			return;
		}

		public int SetOpacity( dynamic new_opacity = null ) {
			if ( new_opacity == null ) {
				new_opacity = !Misc13.isValid( this.opacity );
			} else if ( this.opacity == new_opacity ) {
				return 0;
			}
			this.opacity = new_opacity;
			this.UpdateAffectingLights();
			return 1;
		}

		public void AddLuminosity( int delta_luminosity = 0 ) {
			if ( this.light != null ) {
				this.SetLuminosity( this.light.radius + delta_luminosity );
			} else {
				this.SetLuminosity( delta_luminosity );
			}
			return;
		}

		public void SetLuminosity( int new_luminosity = 0 ) {
			if ( new_luminosity < 0 ) {
				new_luminosity = 0;
			}
			if ( this.light == null ) {
				if ( new_luminosity == 0 ) {
					return;
				}
				this.light = new LightSource( this );
			} else if ( this.light.radius == new_luminosity ) {
				return;
			}
			this.light.radius = new_luminosity;
			this.luminosity = new_luminosity;
			this.light.f_changed();
			return;
		}

		public void transfer_fingerprints_to( Ent_Item_Stack_Rods A = null ) {
			if ( !Misc13.isValid( typeof(ByTable).IsInstanceOfType( A.fingerprints ) ) ) {
				A.fingerprints = new ByTable();
			}
			if ( !Misc13.isValid( typeof(ByTable).IsInstanceOfType( A.fingerprintshidden ) ) ) {
				A.fingerprintshidden = new ByTable();
			}
			if ( !Misc13.isValid( typeof(ByTable).IsInstanceOfType( this.fingerprints ) ) ) {
				this.fingerprints = new ByTable();
			}
			if ( !Misc13.isValid( typeof(ByTable).IsInstanceOfType( this.fingerprintshidden ) ) ) {
				this.fingerprintshidden = new ByTable();
			}
			if ( this.fingerprints != null ) {
				A.fingerprints |= this.fingerprints.Copy();
			}
			if ( Misc13.isValid( this.fingerprintshidden ) ) {
				A.fingerprintshidden |= this.fingerprintshidden.Copy();
			}
			A.fingerprintslast = this.fingerprintslast;
			return;
		}

		public int add_fingerprint( dynamic M = null, int ignoregloves = 0 ) {
			dynamic H = null;
			dynamic G = null;
			dynamic full_print = null;
			if ( ignoregloves == null ) {
				ignoregloves = 0;
			}
			if ( M == null ) {
				return 0;
			}
			if ( M.key == null ) {
				return 0;
			}
			if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				if ( !Misc13.isValid( this.fingerprintshidden ) ) {
					this.fingerprintshidden = new ByTable();
				}
				this.add_fibers( H );
				if ( Misc13.isValid( H.gloves ) ) {
					G = H.gloves;
					if ( Misc13.isValid( G.transfer_prints ) ) {
						ignoregloves = 1;
					}
				}
				if ( ignoregloves == 0 ) {
					if ( Misc13.isValid( H.gloves ) && H.gloves != this ) {
						if ( this.fingerprintslast != H.ckey ) {
							this.fingerprintshidden += "[" + GlobalFuncs.time_stamp() + "](Wearing gloves). Real name: " + H.real_name + ", Key: " + H.key;
							this.fingerprintslast = H.ckey;
						}
						H.gloves.add_fingerprint( M );
						return 0;
					}
				}
				if ( this.fingerprintslast != H.ckey ) {
					this.fingerprintshidden += "[" + GlobalFuncs.time_stamp() + "]Real name: " + H.real_name + ", Key: " + H.key;
					this.fingerprintslast = H.ckey;
				}
				if ( this.fingerprints == null ) {
					this.fingerprints = new ByTable();
				}
				full_print = Misc13.call( GlobalVars.undefined, H.dna.uni_identity );
				this.fingerprints[full_print] = full_print;
				return 1;
			} else if ( this.fingerprintslast != M.ckey ) {
				this.fingerprintshidden += "[" + GlobalFuncs.time_stamp() + "]Real name: " + M.real_name + ", Key: " + M.key;
				this.fingerprintslast = M.ckey;
			}
			return 0;
		}

		public int add_hiddenprint( Mob_Living_Silicon_Ai M = null ) {
			Mob_Living_Silicon_Ai H = null;
			if ( M == null ) {
				return 0;
			}
			if ( M.key == null ) {
				return 0;
			}
			if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				if ( Misc13.isValid( H.gloves ) ) {
					if ( this.fingerprintslast != H.ckey ) {
						this.fingerprintshidden += "[" + GlobalFuncs.time_stamp() + "] (Wearing gloves). Real name: " + H.real_name + ", Key: " + H.key;
						this.fingerprintslast = H.ckey;
					}
					return 0;
				}
				if ( this.fingerprints == null ) {
					if ( this.fingerprintslast != H.ckey ) {
						this.fingerprintshidden += "[" + GlobalFuncs.time_stamp() + "] Real name: " + H.real_name + ", Key: " + H.key;
						this.fingerprintslast = H.ckey;
					}
					return 1;
				}
			} else if ( this.fingerprintslast != M.ckey ) {
				this.fingerprintshidden += "[" + GlobalFuncs.time_stamp() + "] Real name: " + M.real_name + ", Key: " + M.key;
				this.fingerprintslast = M.ckey;
			}
			return 0;
		}

		public void add_fibers( dynamic M = null ) {
			dynamic G = null;
			string fibertext = "";
			double item_multiplier = 0;
			if ( Misc13.isValid( M.gloves ) && M.gloves is Ent_Item_Clothing ) {
				G = M.gloves;
				if ( G.transfer_blood > 1 ) {
					if ( Misc13.isValid( this.add_blood( G.bloody_hands_mob ) ) ) {
						G.transfer_blood--;
					}
				}
			} else if ( M.bloody_hands > 1 ) {
				if ( Misc13.isValid( this.add_blood( M.bloody_hands_mob ) ) ) {
					M.bloody_hands--;
				}
			}
			if ( !Misc13.isValid( this.suit_fibers ) ) {
				this.suit_fibers = new ByTable();
			}
			item_multiplier = this is Ent_Item ? 1.2000000476837158 : 1;
			if ( Misc13.isValid( M.wear_suit ) ) {
				fibertext = new Txt( "Material from " ).a( M.wear_suit ).item().str( "." );
				if ( Misc13.isValid( Rand13.chance( item_multiplier * 10 ) ) && !Misc13.isValid( this.suit_fibers.HasValue( fibertext ) ) ) {
					this.suit_fibers += fibertext;
				}
				if ( !Misc13.isValid( M.wear_suit.body_parts_covered & 2 ) ) {
					if ( Misc13.isValid( M.w_uniform ) ) {
						fibertext = new Txt( "Fibers from " ).a( M.w_uniform ).item().str( "." );
						if ( Misc13.isValid( Rand13.chance( item_multiplier * 12 ) ) && !Misc13.isValid( this.suit_fibers.HasValue( fibertext ) ) ) {
							this.suit_fibers += fibertext;
						}
					}
				}
				if ( !Misc13.isValid( M.wear_suit.body_parts_covered & 1536 ) ) {
					if ( Misc13.isValid( M.gloves ) ) {
						fibertext = "Material from a pair of " + M.gloves.name + ".";
						if ( Misc13.isValid( Rand13.chance( item_multiplier * 20 ) ) && !Misc13.isValid( this.suit_fibers.HasValue( fibertext ) ) ) {
							this.suit_fibers += fibertext;
						}
					}
				}
			} else if ( Misc13.isValid( M.w_uniform ) ) {
				fibertext = new Txt( "Fibers from " ).a( M.w_uniform ).item().str( "." );
				if ( Misc13.isValid( Rand13.chance( item_multiplier * 15 ) ) && !Misc13.isValid( this.suit_fibers.HasValue( fibertext ) ) ) {
					this.suit_fibers += fibertext;
				}
				if ( Misc13.isValid( M.gloves ) ) {
					fibertext = "Material from a pair of " + M.gloves.name + ".";
					if ( Misc13.isValid( Rand13.chance( item_multiplier * 20 ) ) && !Misc13.isValid( this.suit_fibers.HasValue( fibertext ) ) ) {
						this.suit_fibers += "Material from a pair of " + M.gloves.name + ".";
					}
				}
			} else if ( Misc13.isValid( M.gloves ) ) {
				fibertext = "Material from a pair of " + M.gloves.name + ".";
				if ( Misc13.isValid( Rand13.chance( item_multiplier * 20 ) ) && !Misc13.isValid( this.suit_fibers.HasValue( fibertext ) ) ) {
					this.suit_fibers += "Material from a pair of " + M.gloves.name + ".";
				}
			}
			return;
		}

		public void investigate_log( string message = "", string subject = "" ) {
			dynamic F = null;
			if ( !Misc13.isValid( message ) ) {
				return;
			}
			F = GlobalFuncs.investigate_subject2file( subject );
			if ( !Misc13.isValid( F ) ) {
				return;
			}
			F.write( new Txt( "<small>" ).item( GlobalFuncs.time_stamp() ).str( " " ).Ref( this ).str( " (" ).item( this.x ).str( "," ).item( this.y ).str( "," ).item( this.z ).str( ")</small> || " ).item( this ).str( " " ).item( message ).str( "<br>" ) );
			return;
		}

		public dynamic CanPass( dynamic mover = null, dynamic target = null, double height = 0 ) {
			if ( height == null ) {
				height = 1.5;
			}
			return !Misc13.isValid( this.density ) || ( height == 0 );
		}

		public void temperature_expose( dynamic air = null, dynamic exposed_temperature = null, dynamic exposed_volume = null ) {
			return;
		}

		public int transfer_ai( dynamic interaction = null, dynamic user = null, dynamic AI = null, dynamic card = null ) {
			if ( card is Ent_Item_Device_Aicard ) {
				if ( Misc13.isValid( card.flush ) ) {
					user.write( "<span class='boldannounce'>ERROR</span>: AI flush is in progress, cannot execute transfer protocol." );
					return 0;
				}
			}
			return 1;
		}

		public int rad_act( dynamic severity = null ) {
			return 1;
		}

		public int mech_melee_attack( Ent_Mecha M = null ) {
			return 0;
		}

		public Signal telecomms_process(  ) {
			Signal signal = null;
			dynamic pos = null;
			dynamic R = null;
			signal = new Signal();
			signal.transmission_method = 2;
			pos = GlobalFuncs.get_turf( this );
			signal.data = new ByTable().set( "level", pos.z ).set( "done", 0 ).set( "reject", 0 ).set( "type", 4 ).set( "traffic", 0 ).set( "compression", Rand13.Int( 45, 50 ) ).set( "message", "TEST" ).set( "slow", 0 );
			signal.frequency = 1459;
			R = null;
			foreach (dynamic _a in GlobalVars.telecomms_list ) {
				R = _a;
				if ( !( R is Ent_Machinery_Telecomms_Receiver ) ) {
					continue;
				}
				R.receive_signal( signal );
			};
			Thread13.sleep( Rand13.Int( 10, 25 ) );
			return signal;
		}

		public dynamic test_telecomms(  ) {
			dynamic signal = null;
			dynamic position = null;
			signal = this.telecomms_process();
			position = GlobalFuncs.get_turf( this );
			return Misc13.isValid( signal.data["level"] ) && Misc13.isValid( signal.data["done"] ).HasValue( position.z );
		}

		public void auto_turn(  ) {
			dynamic T = null;
			int i = 0;
			T = null;
			i = 0;
			i = 1;
			while (i <= 8) {
				T = GlobalFuncs.get_ranged_target_turf( this, i, 1 );
				if ( T is Tile_Simulated_Wall ) {
					dynamic _a = i; // Was a switch-case, sorry for the mess.
					if ( _a==1 ) {
						this.dir = GlobalVars.SOUTH;
					} else if ( _a==2 ) {
						this.dir = GlobalVars.NORTH;
					} else if ( _a==8 ) {
						this.dir = GlobalVars.EAST;
					} else if ( _a==4 ) {
						this.dir = GlobalVars.WEST;
					};
					break;
				}
				i += i;
			}
			return;
		}

		public void playsound_local( dynamic turf_source = null, dynamic soundin = null, int vol = 0, int vary = 0, dynamic frequency = null, dynamic falloff = null, int surround = 0 ) {
			Sound S = null;
			dynamic T = null;
			int pressure_factor = 0;
			dynamic hearer_env = null;
			dynamic source_env = null;
			dynamic pressure = null;
			dynamic distance = null;
			dynamic dx = null;
			dynamic dz = null;
			if ( surround == null ) {
				surround = 1;
			}
			soundin = GlobalFuncs.get_sfx( soundin );
			S = new Sound( soundin );
			S.wait = 0;
			S.channel = 0;
			S.volume = vol;
			if ( vary != 0 ) {
				if ( Misc13.isValid( frequency ) ) {
					S.frequency = frequency;
				} else {
					S.frequency = GlobalFuncs.get_rand_frequency();
				}
			}
			if ( turf_source is Tile ) {
				T = GlobalFuncs.get_turf( this );
				pressure_factor = 1;
				hearer_env = T.return_air();
				source_env = turf_source.return_air();
				if ( Misc13.isValid( hearer_env ) && Misc13.isValid( source_env ) ) {
					pressure = Misc13.min( hearer_env.return_pressure(), source_env.return_pressure() );
					if ( pressure < 101.32499694824219 ) {
						pressure_factor = Misc13.max( ( pressure - 10 ) / 91.32499694824219, 0 );
					}
				} else {
					pressure_factor = 0;
				}
				distance = Misc13.get_dist( T, turf_source );
				if ( distance <= 1 ) {
					pressure_factor = Misc13.max( pressure_factor, 0.15000000596046448 );
				}
				S.volume *= pressure_factor;
				if ( S.volume <= 0 ) {
					return;
				}
				if ( surround != 0 ) {
					dx = turf_source.x - T.x;
					S.x = Misc13.round( Misc13.max( -7, Misc13.min( 7, dx ) ), 1 );
					dz = turf_source.y - T.y;
					S.z = Misc13.round( Misc13.max( -7, Misc13.min( 7, dz ) ), 1 );
				}
				S.y = 1;
				S.falloff = Misc13.isValid( falloff ) ? falloff : 1;
			}
			this.write( S );
			return;
		}

		public void remove_from_all_data_huds(  ) {
			dynamic hud = null;
			hud = null;
			foreach (dynamic _a in GlobalVars.huds ) {
				hud = _a;
				if ( !( hud is AtomHud_Data ) ) {
					continue;
				}
				hud.remove_from_hud( this );
			};
			return;
		}

		public void add_to_all_human_data_huds(  ) {
			dynamic hud = null;
			hud = null;
			foreach (dynamic _a in GlobalVars.huds ) {
				hud = _a;
				if ( !( hud is AtomHud_Data_Human ) ) {
					continue;
				}
				hud.add_to_hud( this );
			};
			return;
		}

		public void handle_atom_del( dynamic A = null ) {
			return;
		}

		public int storage_contents_dump_act( dynamic src_object = null, dynamic user = null ) {
			return 0;
		}

		public void narsie_act(  ) {
			return;
		}

		public int emag_act(  ) {
			return 0;
		}

		public int acid_act( dynamic acidpwr = null, dynamic toxpwr = null, dynamic acid_volume = null ) {
			return 0;
		}

		public void singularity_pull(  ) {
			return;
		}

		public int singularity_act(  ) {
			return 0;
		}

		public int handle_slip(  ) {
			return 0;
		}

		public void handle_fall(  ) {
			return;
		}

		public int isinspace(  ) {
			if ( GlobalFuncs.get_turf( this ) is Tile_Space ) {
				return 1;
			} else {
				return 0;
			}
			return 0;
		}

		public dynamic get_global_map_pos(  ) {
			int cur_x = 0;
			dynamic cur_y = null;
			dynamic y_arr = null;
			if ( !Misc13.isValid( typeof(ByTable).IsInstanceOfType( GlobalVars.global_map ) ) || Misc13.isValid( GlobalFuncs.isemptylist( GlobalVars.global_map ) ) ) {
				return null;
			}
			cur_x = 0;
			cur_y = null;
			y_arr = null;
			cur_x = 1;
			while (cur_x <= GlobalVars.global_map.len) {
				y_arr = GlobalVars.global_map[cur_x];
				cur_y = y_arr.Find( this.z );
				if ( Misc13.isValid( cur_y ) ) {
					break;
				}
				cur_x++;
			}
			if ( ( cur_x != 0 ) && Misc13.isValid( cur_y ) ) {
				return new ByTable().set( "y", cur_y ).set( "x", cur_x );
			} else {
				return 0;
			}
			return null;
		}

		public int clean_blood(  ) {
			if ( Misc13.isValid( typeof(ByTable).IsInstanceOfType( this.blood_DNA ) ) ) {
				this.blood_DNA = null;
				return 1;
			}
			return 0;
		}

		public void add_blood_floor( dynamic M = null ) {
			dynamic B = null;
			if ( this is Tile_Simulated ) {
				if ( Misc13.isValid( M.has_dna() ) ) {
					B = Misc13.locate_in( typeof(Ent_Effect_Decal_Cleanable_Blood), this.contents );
					if ( !Misc13.isValid( B ) ) {
						GlobalFuncs.blood_splatter( this, M, 1 );
						B = Misc13.locate_in( typeof(Ent_Effect_Decal_Cleanable_Blood), this.contents );
					}
					B.blood_DNA[M.dna.unique_enzymes] = M.dna.blood_type;
				} else if ( M is Mob_Living_Carbon_Alien ) {
					B = Misc13.locate_in( typeof(Ent_Effect_Decal_Cleanable_Xenoblood), this.contents );
					if ( B == null ) {
						B = new Ent_Effect_Decal_Cleanable_Xenoblood( this );
					}
					B.blood_DNA["UNKNOWN BLOOD"] = "X*";
				} else if ( M is Mob_Living_Silicon_Robot ) {
					B = Misc13.locate_in( typeof(Ent_Effect_Decal_Cleanable_Oil), this.contents );
					if ( B == null ) {
						B = new Ent_Effect_Decal_Cleanable_Oil( this );
					}
				}
			}
			return;
		}

		public void add_vomit_floor( dynamic M = null, int toxvomit = 0 ) {
			Ent_Effect_Decal_Cleanable_Vomit _this = null;
			if ( toxvomit == null ) {
				toxvomit = 0;
			}
			if ( this is Tile_Simulated ) {
				_this = new Ent_Effect_Decal_Cleanable_Vomit( this );
				if ( Misc13.isValid( M.reagents ) ) {
					M.reagents.trans_to( _this, M.reagents.total_volume / 10 );
				}
				if ( toxvomit != 0 ) {
					_this.icon_state = "vomittox_" + Rand13.pick(new object [] { 1, 4 });
				}
			}
			return;
		}

		public int rejects_blood(  ) {
			return 0;
		}

		public int add_blood( dynamic M = null ) {
			dynamic H = null;
			if ( !Misc13.isValid( M ) || !Misc13.isValid( M.has_dna() ) || Misc13.isValid( this.rejects_blood() ) ) {
				return 0;
			}
			if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				if ( Misc13.isValid( H.dna.species.specflags.HasValue( 1024 ) ) ) {
					return 0;
				}
			}
			return 1;
		}

		public int add_blood_list( dynamic M = null ) {
			if ( !Misc13.isValid( typeof(ByTable).IsInstanceOfType( this.blood_DNA ) ) ) {
				this.blood_DNA = new ByTable();
			}
			if ( Misc13.isValid( this.blood_DNA[M.dna.unique_enzymes] ) ) {
				return 0;
			}
			this.blood_DNA[M.dna.unique_enzymes] = M.dna.blood_type;
			return 1;
		}

		public dynamic blood_splatter_index(  ) {
			return new Txt().Ref( Misc13.initial( this.icon ) ).str( "-" ).item( Misc13.initial( this.icon_state ) );
		}

		public int hitby( dynamic AM = null, dynamic skipcatch = null, dynamic hitpush = null, dynamic blocked = null ) {
			if ( Misc13.isValid( this.density ) && !Misc13.isValid( GlobalFuncs.has_gravity( AM ) ) ) {
				Thread13.schedule( 2, (Thread13.Closure)(() => {
					Misc13.step( AM, Misc13.turn( AM.dir, 180 ) );
					return;
				}));
			}
			return 0;
		}

		public int fire_act(  ) {
			return 0;
		}

		public int blob_act(  ) {
			return 0;
		}

		public int ex_act( int severity = 0, dynamic target = null ) {
			this.contents_explosion( severity, target );
			return 0;
		}

		public void contents_explosion( int severity = 0, dynamic target = null ) {
			dynamic A = null;
			A = null;
			foreach (dynamic _a in this.contents ) {
				A = _a;
				if ( !( A is BaseStatic ) ) {
					continue;
				}
				A.ex_act( severity, target );
			};
			return;
		}

		public int relaymove(  ) {
			return 0;
		}

		public dynamic examine( Mob user = null ) {
			string f_name = "";
			dynamic R = null;
			f_name = new Txt().a( this ).item().str( "." );
			if ( ( this.blood_DNA != null ) && !( this is Ent_Effect_Decal ) ) {
				if ( this.gender == GlobalVars.PLURAL ) {
					f_name = "some ";
				} else {
					f_name = "a ";
				}
				f_name += "<span class='danger'>blood-stained</span> " + this.name + "!";
			}
			user.write( new Txt().icon( this ).str( " That's " ).item( f_name ) );
			if ( Misc13.isValid( this.desc ) ) {
				user.write( this.desc );
			}
			if ( ( this.reagents != null ) && Misc13.isValid( this.is_open_container() ) ) {
				user.write( "It contains:" );
				if ( Misc13.isValid( this.reagents.reagent_list.len ) ) {
					R = null;
					foreach (dynamic _a in this.reagents.reagent_list ) {
						R = _a;
						if ( !( R is Reagent ) ) {
							continue;
						}
						user.write( "" + R.volume + " units of " + R.name );
					};
				} else {
					user.write( "Nothing." );
				}
			}
			return null;
		}

		public Beam Beam( dynamic BeamTarget = null, string icon_state = "", ByRsc icon = null, int time = 0, int maxdistance = 0, Type beam_type = null ) {
			Beam newbeam = null;
			if ( icon_state == null ) {
				icon_state = "b_beam";
			}
			if ( icon == null ) {
				icon = new ByRsc(98);
			}
			if ( time == null ) {
				time = 50;
			}
			if ( maxdistance == null ) {
				maxdistance = 10;
			}
			if ( beam_type == null ) {
				beam_type = typeof(Ent_Effect_Ebeam);
			}
			newbeam = new Beam( this, BeamTarget, icon, icon_state, time, maxdistance, beam_type );
			Thread13.schedule( 0, (Thread13.Closure)(() => {
				newbeam.Start();
				return;
			}));
			return newbeam;
		}

		public ByTable search_contents_for( Type path = null, dynamic filter_path = null ) {
			ByTable found = null;
			dynamic A = null;
			int pass = 0;
			dynamic type = null;
			if ( filter_path == null ) {
				filter_path = null;
			}
			found = new ByTable();
			A = null;
			foreach (dynamic _b in this ) {
				A = _b;
				if ( !( A is BaseStatic ) ) {
					continue;
				}
				if ( Misc13.isValid( path.IsInstanceOfType( A ) ) ) {
					found += A;
				}
				if ( Misc13.isValid( filter_path ) ) {
					pass = 0;
					type = null;
					foreach (dynamic _a in filter_path ) {
						type = _a;
						pass |= type.IsInstanceOfType( A );
					};
					if ( pass == 0 ) {
						continue;
					}
				}
				if ( Misc13.isValid( A.contents.len ) ) {
					found += A.search_contents_for( path, filter_path );
				}
			};
			return found;
		}

		public int in_contents_of( dynamic container = null ) {
			if ( container is Type ) {
				if ( Misc13.isValid( container.IsInstanceOfType( this.loc ) ) ) {
					return 1;
				}
			} else if ( Misc13.isValid( container.HasValue( this ) ) ) {
				return 1;
			}
			return 0;
		}

		public int bullet_act( dynamic P = null, dynamic def_zone = null ) {
			int _default = 0;
			_default = P.on_hit( this, 0, def_zone );
			return 0;
			return _default;
		}

		public int emp_act( dynamic severity = null ) {
			return 0;
		}

		public int HasProximity( dynamic AM = null ) {
			return 0;
		}

		public dynamic CheckExit(  ) {
			return 1;
		}

		public int allow_drop(  ) {
			return 1;
		}

		public int is_open_container(  ) {
			return this.flags & 4096;
		}

		public int Bumped( dynamic AM = null ) {
			return 0;
		}

		public void on_reagent_change(  ) {
			return;
		}

		public dynamic check_eye( dynamic user = null ) {
			if ( user is Mob_Living_Silicon_Ai ) {
				return 1;
			}
			return null;
		}

		public GasMixture return_air(  ) {
			if ( Misc13.isValid( this.loc ) ) {
				return this.loc.return_air();
			} else {
				return null;
			}
			return null;
		}

		public GasMixture remove_air( dynamic amount = null ) {
			return null;
		}

		public int assume_air( dynamic giver = null ) {
			GlobalFuncs.qdel( giver );
			return 0;
		}

		public void CheckParts(  ) {
			return;
		}

		public int attack_hulk( dynamic hulk = null, int do_attack_animation = 0 ) {
			if ( do_attack_animation == null ) {
				do_attack_animation = 0;
			}
			if ( do_attack_animation != 0 ) {
				hulk.changeNext_move( 8 );
				GlobalFuncs.add_logs( hulk, this, "punched", "hulk powers" );
				hulk.do_attack_animation( this );
			}
			return 0;
		}

		public int onSyndieBase(  ) {
			dynamic T = null;
			T = GlobalFuncs.get_turf( this );
			if ( !Misc13.isValid( T ) ) {
				return 0;
			}
			if ( T.z != 2 ) {
				return 0;
			}
			if ( Misc13.isValid( new ByArea(2753).IsInstanceOfType( T.loc ) ) || Misc13.isValid( new ByArea(2766).IsInstanceOfType( T.loc ) ) ) {
				return 1;
			}
			return 0;
		}

		public int onCentcom(  ) {
			dynamic T = null;
			dynamic centcom_shuttle = null;
			dynamic M = null;
			T = GlobalFuncs.get_turf( this );
			if ( !Misc13.isValid( T ) ) {
				return 0;
			}
			if ( T.z != 2 ) {
				return 0;
			}
			centcom_shuttle = null;
			foreach (dynamic _a in new ByTable(new object [] { "emergency", "pod1", "pod2", "pod3", "pod4", "ferry" }) ) {
				centcom_shuttle = _a;
				M = GlobalVars.SSshuttle.getShuttle( centcom_shuttle );
				if ( Misc13.isValid( M.areaInstance.HasValue( T ) ) ) {
					return 1;
				}
			};
			return new ByArea(2763).IsInstanceOfType( T.loc );
		}

		public dynamic attack_self_tk( dynamic user = null ) {
			return null;
		}

		public dynamic attack_tk( dynamic user = null ) {
			if ( Misc13.isValid( user.stat ) ) {
				return null;
			}
			user.UnarmedAttack( this, 0 );
			return null;
		}

		public int attack_slime( dynamic user = null ) {
			return 0;
		}

		public int attack_larva( dynamic user = null ) {
			return 0;
		}

		public int attack_alien( dynamic user = null ) {
			this.attack_paw( user );
			return 0;
		}

		public int attack_paw( dynamic user = null ) {
			return 0;
		}

		public int attack_animal( dynamic user = null ) {
			return 0;
		}

		public int attack_hand( dynamic user = null ) {
			return 0;
		}

		public void attack_ghost( dynamic user = null ) {
			if ( Misc13.isValid( user.client ) && Misc13.isValid( user.client.inquisitive_ghost ) ) {
				user.examinate( this );
			}
			return;
		}

		public int attackby( dynamic W = null, Mob user = null, dynamic _params = null ) {
			return 0;
		}

		public int MouseDrop_T( dynamic dropping = null, dynamic user = null ) {
			return 0;
		}

		public dynamic attack_robot( dynamic user = null ) {
			this.attack_ai( user );
			return null;
		}

		public void BorgAltClick( dynamic user = null ) {
			this.AltClick( user );
			return;
		}

		public void BorgCtrlClick( dynamic user = null ) {
			this.CtrlClick( user );
			return;
		}

		public void BorgShiftClick( dynamic user = null ) {
			this.ShiftClick( user );
			return;
		}

		public void BorgCtrlShiftClick( dynamic user = null ) {
			this.CtrlShiftClick( user );
			return;
		}

		public void CtrlShiftClick( Mob user = null ) {
			return;
		}

		public int AltClick( Mob user = null ) {
			dynamic T = null;
			T = GlobalFuncs.get_turf( this );
			if ( Misc13.isValid( T ) && Misc13.isValid( user.TurfAdjacent( T ) ) ) {
				if ( user.listed_turf == T ) {
					user.listed_turf = null;
				} else {
					user.listed_turf = T;
					user.client.statpanel = T.name;
				}
			}
			return 0;
		}

		public void CtrlClick( Mob user = null ) {
			return;
		}

		public void ShiftClick( Mob user = null ) {
			if ( Misc13.isValid( user.client ) && user.client.eye == user || user.client.eye == user.loc ) {
				user.examinate( this );
			}
			return;
		}

		public void AICtrlShiftClick(  ) {
			return;
		}

		public void AIShiftClick(  ) {
			return;
		}

		public void AIAltClick( dynamic user = null ) {
			this.AltClick( user );
			return;
		}

		public void AICtrlClick(  ) {
			return;
		}

		public int attack_ai( dynamic user = null ) {
			return 0;
		}

		public dynamic Adjacent( dynamic neighbor = null ) {
			return 0;
		}

		public dynamic GetTypeInAllContents( dynamic typepath = null ) {
			ByTable processing_list = null;
			ByTable processed = null;
			dynamic found = null;
			dynamic A = null;
			dynamic a = null;
			processing_list = new ByTable(new object [] { this });
			processed = new ByTable();
			found = null;
			while (Misc13.isValid( processing_list.len ) && found == null) {
				A = processing_list[1];
				if ( Misc13.isValid( typepath.IsInstanceOfType( A ) ) ) {
					found = A;
				}
				processing_list -= A;
				a = null;
				foreach (dynamic _a in A ) {
					a = _a;
					if ( !( a is BaseStatic ) ) {
						continue;
					}
					if ( !Misc13.isValid( processed.HasValue( a ) ) ) {
						processing_list |= a;
					}
				};
				processed |= A;
			}
			return found;
		}

		public ByTable GetAllContents(  ) {
			ByTable processing_list = null;
			ByTable assembled = null;
			dynamic A = null;
			dynamic a = null;
			processing_list = new ByTable(new object [] { this });
			assembled = new ByTable();
			while (Misc13.isValid( processing_list.len )) {
				A = processing_list[1];
				processing_list -= A;
				a = null;
				foreach (dynamic _a in A ) {
					a = _a;
					if ( !( a is BaseStatic ) ) {
						continue;
					}
					if ( !Misc13.isValid( assembled.HasValue( a ) ) ) {
						processing_list |= a;
					}
				};
				assembled |= A;
			}
			return assembled;
		}

		public void SpinAnimation( int speed = 0, int loops = 0 ) {
			Matrix m120 = null;
			Matrix m240 = null;
			Matrix m360 = null;
			if ( speed == null ) {
				speed = 10;
			}
			if ( loops == null ) {
				loops = -1;
			}
			m120 = new Matrix( this.transform );
			m120.Turn( 120 );
			m240 = new Matrix( this.transform );
			m240.Turn( 240 );
			m360 = new Matrix( this.transform );
			speed /= 3;
			Misc13.animate_listcall( new ByTable().set( 4, loops ).set( "time", speed ).set( "transform", m120 ).set( 1, this ) );
			Misc13.animate_listcall( new ByTable().set( "time", speed ).set( "transform", m240 ) );
			Misc13.animate_listcall( new ByTable().set( "time", speed ).set( "transform", m360 ) );
			return;
		}

		public int DrawPixelOn( dynamic colour = null, dynamic drawX = null, dynamic drawY = null ) {
			Icon I = null;
			dynamic J = null;
			I = new Icon( this.icon );
			J = GlobalFuncs.DrawPixel( I, colour, drawX, drawY );
			if ( Misc13.isValid( J ) ) {
				this.icon = J;
				return J;
			}
			return 0;
		}

		public void clear_smooth_overlays(  ) {
			this.overlays -= this.top_left_corner;
			this.overlays -= this.top_right_corner;
			this.overlays -= this.bottom_right_corner;
			this.overlays -= this.bottom_left_corner;
			return;
		}

	}

	partial class Image : BaseData {

		public void ResetVars(  ) {
			base.ResetVars();
			this.loc = null;
			return;
		}

	}

	partial class Mob : BaseDynamic {

		public dynamic glide_size = 8;
		public dynamic mouse_drag_pointer = 1;

		public double next_click = 0;
		public int next_move_adjust = 0;
		public int next_move_modifier = 1;
		public dynamic skincmds = null;
		public int suiciding = 0;
		public dynamic open_uis = null;
		public dynamic alerts = null;
		public HSB sandbox = null;
		public int bloody_hands = 0;
		public dynamic bloody_hands_mob = null;
		public Mind mind = null;
		public int stat = 0;
		public Ent_Screen flash = null;
		public Ent_Screen blind = null;
		public Ent_Screen_Robot_Module hands = null;
		public Ent_Screen_Pull pullin = null;
		public Ent_Screen_Internals internals = null;
		public dynamic i_select = null;
		public dynamic m_select = null;
		public Ent_Screen healths = null;
		public dynamic throw_icon = null;
		public Ent_Screen damageoverlay = null;
		public dynamic zone_sel = null;
		public Ent_Screen_Alien_Leap leap_icon = null;
		public Ent_Screen healthdoll = null;
		public int damageoverlaytemp = 0;
		public dynamic computer_id = null;
		public dynamic lastattacker = null;
		public dynamic lastattacked = null;
		public string attack_log = "";
		public dynamic machine = null;
		public dynamic other_mobs = null;
		public string memory = "";
		public int disabilities = 0;
		public BaseDynamic pulling = null;
		public double next_move = 0;
		public int notransform = 0;
		public dynamic hand = null;
		public int eye_blind = 0;
		public int eye_blurry = 0;
		public int ear_deaf = 0;
		public int ear_damage = 0;
		public int stuttering = 0;
		public int slurring = 0;
		public dynamic real_name = null;
		public int druggy = 0;
		public int confused = 0;
		public int sleeping = 0;
		public dynamic resting = 0;
		public dynamic lying = 0;
		public dynamic lying_prev = 0;
		public dynamic canmove = 1;
		public int eye_stat = 0;
		public int lastpuke = 0;
		public dynamic name_archive = null;
		public double timeofdeath = 0;
		public int cpr_time = 1;
		public double bodytemperature = 310.05499267578125;
		public int drowsyness = 0;
		public int dizziness = 0;
		public int jitteriness = 0;
		public int nutrition = 400;
		public int satiety = 0;
		public int overeatduration = 0;
		public int paralysis = 0;
		public int stunned = 0;
		public int weakened = 0;
		public int losebreath = 0;
		public int shakecamera = 0;
		public string a_intent = "help";
		public string m_intent = "run";
		public dynamic lastKnownIP = null;
		public dynamic buckled = null;
		public dynamic l_hand = null;
		public dynamic r_hand = null;
		public dynamic s_active = null;
		public int seer = 0;
		public int see_override = 0;
		public Hud hud_used = null;
		public int research_scanner = 0;
		public dynamic scanner = null;
		public dynamic grabbed_by = null;
		public dynamic requests = null;
		public dynamic mapobjs = null;
		public int in_throw_mode = 0;
		public string music_lastplayed = "null";
		public dynamic job = null;
		public int radiation = 0;
		public string voice_name = "unidentifiable voice";
		public ByTable faction = null;
		public int move_on_shuttle = 1;
		public dynamic LAssailant = null;
		public dynamic mob_spell_list = null;
		public ByTable viruses = null;
		public dynamic resistances = null;
		public dynamic virus = null;
		public int status_flags = 15;
		public dynamic lastarea = null;
		public int digitalcamo = 0;
		public int digitalinvis = 0;
		public dynamic digitaldisguise = null;
		public int weakeyes = 0;
		public int has_unlimited_silicon_privilege = 0;
		public int force_compose = 0;
		public dynamic control_object = null;
		public dynamic remote_control = null;
		public dynamic listed_turf = null;
		public dynamic permanent_huds = null;
		public int permanent_sight_flags = 0;
		public int resize = 1;

		public int flags = 16;
		public dynamic hud_possible = "UNKNOWABLE: EEEEE 62 5372 3942 42 16640 0 undefined undefined";

		public Mob ( dynamic _loc = null ) : base( _loc ) {
			this.tag = "mob_" + GlobalVars.next_mob_id++;
			GlobalVars.mob_list += this;
			if ( this.stat == 2 ) {
				GlobalVars.dead_mob_list += this;
			} else {
				GlobalVars.living_mob_list += this;
			}
			this.prepare_huds();
			return;
		}

		public void pipe_eject( dynamic direction = null ) {
			if ( Misc13.isValid( this.client ) ) {
				this.client.perspective = GlobalVars.MOB_PERSPECTIVE;
				this.client.eye = this;
			}
			return;
		}

		public int Process_Spacemove( int movement_dir = 0 ) {
			dynamic dense_object_backup = null;
			dynamic A = null;
			dynamic turf = null;
			dynamic AM = null;
			if ( movement_dir == null ) {
				movement_dir = 0;
			}
			if ( Misc13.isValid( base.Process_Spacemove() ) ) {
				return 1;
			}
			A = null;
			foreach (dynamic _a in Misc13.orange( 1, GlobalFuncs.get_turf( this ) ) ) {
				A = _a;
				if ( !( A is BaseStatic ) ) {
					continue;
				}
				if ( A is Zone ) {
					continue;
				} else if ( A is Tile ) {
					turf = A;
					if ( turf is Tile_Space ) {
						continue;
					}
					if ( !Misc13.isValid( turf.density ) && !Misc13.isValid( this.mob_negates_gravity() ) ) {
						continue;
					}
					return 1;
				} else {
					AM = A;
					if ( AM == this.buckled ) {
						continue;
					}
					if ( Misc13.isValid( AM.density ) ) {
						if ( Misc13.isValid( AM.anchored ) ) {
							return 1;
						}
						if ( this.pulling == AM ) {
							continue;
						}
						dense_object_backup = AM;
					}
				}
			};
			if ( ( movement_dir != 0 ) && Misc13.isValid( dense_object_backup ) ) {
				if ( Misc13.isValid( dense_object_backup.newtonian_move( Misc13.turn( movement_dir, 180 ) ) ) ) {
					this.write( "<span class='info'>You push off of " + dense_object_backup + " to propel yourself.</span>" );
				}
				return 1;
			}
			return 0;
		}

		public dynamic CanPass( dynamic mover = null, dynamic target = null, int height = 0 ) {
			dynamic moving_mob = null;
			if ( height == null ) {
				height = 0;
			}
			if ( height == 0 ) {
				return 1;
			}
			if ( mover is Ent_Item_Projectile || Misc13.isValid( mover.throwing ) ) {
				return !Misc13.isValid( this.density ) || Misc13.isValid( this.lying );
			}
			if ( Misc13.isValid( mover.checkpass( 16 ) ) ) {
				return 1;
			}
			if ( this.buckled == mover ) {
				return 1;
			}
			if ( mover is Mob ) {
				moving_mob = mover;
				if ( Misc13.isValid( this.other_mobs ) && Misc13.isValid( moving_mob.other_mobs ) ) {
					return 1;
				}
				if ( mover == this.buckled_mob ) {
					return 1;
				}
			}
			return !Misc13.isValid( mover.density ) || !Misc13.isValid( this.density ) || Misc13.isValid( this.lying );
		}

		public void post_buckle_mob( dynamic M = null ) {
			dynamic height = null;
			if ( M == this.buckled_mob ) {
				height = M.get_mob_buckling_height( this );
				M.pixel_y = Misc13.initial( M.pixel_y ) + height;
				if ( M.layer < this.layer ) {
					M.layer = this.layer + 0.10000000149011612;
				}
			} else {
				M.layer = Misc13.initial( M.layer );
				M.pixel_y = Misc13.initial( M.pixel_y );
			}
			return;
		}

		public int buckle_mob( dynamic M = null, int force = 0 ) {
			dynamic T = null;
			dynamic old_density = null;
			dynamic can_step = null;
			if ( force == null ) {
				force = 0;
			}
			if ( Misc13.isValid( M.buckled ) ) {
				return 0;
			}
			T = GlobalFuncs.get_turf( this );
			if ( M.loc != T ) {
				old_density = this.density;
				this.density = 0;
				Misc13.step_towards( M, T );
				can_step = null;
				this.density = old_density;
				if ( !Misc13.isValid( can_step ) ) {
					return 0;
				}
			}
			return base.buckle_mob();
		}

		public void shuttleRotate( dynamic rotation = null ) {
			this.dir = GlobalFuncs.angle2dir( rotation + GlobalFuncs.dir2angle( this.dir ) );
			return;
		}


//FAILURE

		public int MouseDrop( dynamic M = null ) {
			base.MouseDrop();
			if ( M != Misc13.thread_user ) {
				return 0;
			}
			if ( Misc13.thread_user == this ) {
				return 0;
			}
			if ( !Misc13.isValid( this.Adjacent( Misc13.thread_user ) ) ) {
				return 0;
			}
			if ( M is Mob_Living_Silicon_Ai ) {
				return 0;
			}
			this.show_inv( Misc13.thread_user );
			return 0;
		}

		public int Topic( dynamic href = null, dynamic href_list = null ) {
			string t1 = "";
			dynamic slot = null;
			dynamic what = null;
			if ( Misc13.isValid( href_list["mach_close"] ) ) {
				t1 = "window=" + href_list["mach_close"];
				this.unset_machine();
				Misc13.browse( this, null, t1 );
			}
			if ( Misc13.isValid( href_list["refresh"] ) ) {
				if ( Misc13.isValid( this.machine ) && Misc13.get_dist( this, Misc13.thread_user ) <= 1 ) {
					this.show_inv( this.machine );
				}
			}
			if ( Misc13.isValid( Misc13.thread_user.canUseTopic( this, 1, 1 ) ) ) {
				if ( Misc13.isValid( href_list["item"] ) ) {
					slot = Misc13.parseNumber( href_list["item"] );
					what = this.get_item_by_slot( slot );
					if ( Misc13.isValid( what ) ) {
						Misc13.thread_user.stripPanelUnequip( what, this, slot );
					} else {
						Misc13.thread_user.stripPanelEquip( what, this, slot );
					}
				}
			}
			if ( Misc13.thread_user.machine == this ) {
				if ( Misc13.isValid( this.Adjacent( Misc13.thread_user ) ) ) {
					this.show_inv( Misc13.thread_user );
				} else {
					Misc13.browse( Misc13.thread_user, null, new Txt( "window=mob" ).Ref( this ) );
				}
			}
			return 0;
		}

		public void audible_message( dynamic message = null, dynamic deaf_message = null, dynamic hearing_distance = null, dynamic self_message = null ) {
			int range = 0;
			dynamic M = null;
			dynamic msg = null;
			range = 7;
			if ( Misc13.isValid( hearing_distance ) ) {
				range = hearing_distance;
			}
			M = null;
			foreach (dynamic _a in GlobalFuncs.get_hearers_in_view( range, this ) ) {
				M = _a;
				msg = message;
				if ( Misc13.isValid( self_message ) && M == this ) {
					msg = self_message;
				}
				M.show_message( msg, 2, deaf_message, 1 );
			};
			return;
		}

		public void visible_message( dynamic message = null, dynamic self_message = null, dynamic blind_message = null ) {
			ByTable mob_viewers = null;
			ByTable possible_viewers = null;
			dynamic heard = null;
			dynamic A = null;
			dynamic B = null;
			dynamic T = null;
			dynamic M = null;
			dynamic msg = null;
			ByTable mob_hearers = null;
			dynamic C = null;
			dynamic MOB = null;
			mob_viewers = new ByTable();
			possible_viewers = new ByTable();
			mob_viewers |= this;
			mob_viewers |= Misc13.viewers( this, null );
			heard = GlobalFuncs.get_hear( 7, this );
			A = null;
			foreach (dynamic _a in heard ) {
				A = _a;
				if ( !( A is BaseDynamic ) ) {
					continue;
				}
				possible_viewers |= GlobalFuncs.recursive_hear_check( A );
			};
			B = null;
			foreach (dynamic _b in possible_viewers ) {
				B = _b;
				if ( Misc13.isValid( mob_viewers.HasValue( B ) ) ) {
					continue;
				}
				if ( B.loc is Tile ) {
					continue;
				}
				T = GlobalFuncs.get_turf( B );
				if ( Misc13.isValid( Misc13.view( T, null ).HasValue( this ) ) ) {
					mob_viewers |= B;
				}
			};
			M = null;
			foreach (dynamic _c in mob_viewers ) {
				M = _c;
				if ( M.see_invisible < this.invisibility ) {
					continue;
				}
				msg = message;
				if ( Misc13.isValid( self_message ) && M == this ) {
					msg = self_message;
				}
				M.show_message( msg, 1 );
			};
			if ( Misc13.isValid( blind_message ) ) {
				mob_hearers = new ByTable();
				C = null;
				foreach (dynamic _d in GlobalFuncs.get_hearers_in_view( 7, this ) ) {
					C = _d;
					if ( Misc13.isValid( mob_viewers.HasValue( C ) ) ) {
						continue;
					}
					mob_hearers |= C;
				};
				MOB = null;
				foreach (dynamic _e in mob_hearers ) {
					MOB = _e;
					MOB.show_message( blind_message, 2 );
				};
			}
			return;
		}

		public int Destroy(  ) {
			dynamic infection = null;
			GlobalVars.mob_list -= this;
			GlobalVars.dead_mob_list -= this;
			GlobalVars.living_mob_list -= this;
			GlobalFuncs.qdel( this.hud_used );
			if ( ( this.mind != null ) && this.mind.current == this ) {
				this.spellremove( this );
			}
			infection = null;
			foreach (dynamic _a in this.viruses ) {
				infection = _a;
				GlobalFuncs.qdel( infection );
			};
			this.ghostize();
			return base.Destroy();
		}

		public int Logout(  ) {
			dynamic admins_number = null;
			string cheesy_message = "";
			dynamic Loc = null;
			GlobalVars.SSnano.user_logout( this );
			GlobalVars.player_list -= this;
			GlobalFuncs.log_access( "Logout: " + GlobalFuncs.key_name( this ) );
			if ( Misc13.isValid( GlobalVars.admin_datums[this.ckey] ) ) {
				if ( ( GlobalVars.ticker != null ) && GlobalVars.ticker.current_state == 3 ) {
					admins_number = GlobalVars.admins.len;
					if ( admins_number == 0 ) {
						cheesy_message = Rand13.pick( new ByTable(new object [] { "I have no admins online!", "I'm all alone :(", "I'm feeling lonely :(", "I'm so lonely :(", "Why does nobody love me? :(", "I want a man :(", "Where has everyone gone?", "I need a hug :(", "Someone come hold me :(", "I need someone on me :(", "What happened? Where has everyone gone?", "Forever alone :(" }) );
						if ( Misc13.isValid( cheesy_message ) ) {
							cheesy_message += " (No admins online)";
						}
						GlobalFuncs.send2irc( "Server", "" + cheesy_message );
					}
				}
			}
			base.Logout();
			if ( this.loc is Entity ) {
				Loc = this.loc;
				Loc.on_log();
			}
			return 1;
		}

		public dynamic Login(  ) {
			dynamic Loc = null;
			GlobalVars.player_list |= this;
			this.update_Login_details();
			Game.update_status();
			this.client.images = null;
			this.client.screen = new ByTable();
			if ( this.hud_used != null ) {
				GlobalFuncs.qdel( this.hud_used );
			}
			this.hud_used = new Hud( this );
			this.next_move = 1;
			this.sight |= GlobalVars.SEE_SELF;
			base.Login();
			if ( Misc13.isValid( this.loc ) && !( this.loc is Tile ) ) {
				this.client.eye = this.loc;
				this.client.perspective = GlobalVars.EYE_PERSPECTIVE;
			} else {
				this.client.eye = this;
				this.client.perspective = GlobalVars.MOB_PERSPECTIVE;
			}
			if ( this.loc is Entity ) {
				Loc = this.loc;
				Loc.on_log();
			}
			this.reload_huds();
			if ( Misc13.isValid( GlobalVars.deadmins.HasValue( this.ckey ) ) ) {
				this.verbs += typeof(Client).GetMethod( "readmin" );
			}
			this.client.screen += GlobalVars._void;
			return null;
		}

		public dynamic get_light_range( dynamic radius = null ) {
			return Misc13.min( radius, 5 );
		}

		public void playsound_local( dynamic turf_source = null, dynamic soundin = null, dynamic vol = null, dynamic vary = null, dynamic frequency = null, dynamic falloff = null, int surround = 0 ) {
			if ( surround == null ) {
				surround = 1;
			}
			if ( !Misc13.isValid( this.client ) || this.ear_deaf > 0 ) {
				return;
			}
			base.playsound_local();
			return;
		}

		public dynamic attack_tk( dynamic user = null ) {
			return null;
		}

		public void hotkey_help(  ) {
			string hotkey_mode = "";
			string other = "";
			hotkey_mode = "<font color='purple'>\nHotkey-Mode: (hotkey-mode must be on)\n	TAB = toggle hotkey-mode\n	a = left\n	s = down\n	d = right\n	w = up\n	q = drop\n	e = equip\n	r = throw\n	m = me\n	t = say\n	o = OOC\n	b = resist\n	x = swap-hand\n	z = activate held object (or y)\n	f = cycle-intents-left\n	g = cycle-intents-right\n	1 = help-intent\n	2 = disarm-intent\n	3 = grab-intent\n	4 = harm-intent\n</font>";
			other = "<font color='purple'>\nAny-Mode: (hotkey doesn't need to be on)\n	Ctrl+a = left\n	Ctrl+s = down\n	Ctrl+d = right\n	Ctrl+w = up\n	Ctrl+q = drop\n	Ctrl+e = equip\n	Ctrl+r = throw\n	Ctrl+b = resist\n	Ctrl+O = OOC\n	Ctrl+x = swap-hand\n	Ctrl+z = activate held object (or Ctrl+y)\n	Ctrl+f = cycle-intents-left\n	Ctrl+g = cycle-intents-right\n	Ctrl+1 = help-intent\n	Ctrl+2 = disarm-intent\n	Ctrl+3 = grab-intent\n	Ctrl+4 = harm-intent\n	DEL = pull\n	INS = cycle-intents-right\n	HOME = drop\n	PGUP = swap-hand\n	PGDN = activate held object\n	END = throw\n</font>";
			this.write( hotkey_mode );
			this.write( other );
			return;
		}

		public dynamic getlimb(  ) {
			return null;
		}

		public dynamic getorganslot( dynamic slot = null ) {
			return null;
		}

		public ByTable getorganszone( dynamic zone = null ) {
			return null;
		}

		public dynamic getorgan( dynamic typepath = null ) {
			return null;
		}

		public void throw_item( BaseStatic target = null ) {
			return;
		}

		public int binarycheck(  ) {
			return 0;
		}

		public ByTable get_contents(  ) {
			return null;
		}

		public Mob_Dead_Observer ghostize( int can_reenter_corpse = 0 ) {
			Mob_Dead_Observer ghost = null;
			if ( can_reenter_corpse == null ) {
				can_reenter_corpse = 1;
			}
			if ( Misc13.isValid( this.key ) ) {
				if ( !Misc13.isValid( Misc13.str_cmp( "@", Misc13.str_sub( this.key, 1, 2 ) ) ) ) {
					ghost = new Mob_Dead_Observer( this );
					ghost.can_reenter_corpse = can_reenter_corpse;
					ghost.key = this.key;
					return ghost;
				}
			}
			return null;
		}

		public void update_inv_ears(  ) {
			return;
		}

		public void update_inv_pockets(  ) {
			return;
		}

		public void update_inv_s_store(  ) {
			return;
		}

		public void update_inv_glasses(  ) {
			return;
		}

		public void update_inv_shoes(  ) {
			return;
		}

		public void update_inv_wear_id(  ) {
			return;
		}

		public void update_inv_gloves(  ) {
			return;
		}

		public void update_hair(  ) {
			return;
		}

		public dynamic update_inv_head(  ) {
			return null;
		}

		public void update_inv_belt(  ) {
			return;
		}

		public void update_inv_w_uniform(  ) {
			return;
		}

		public void update_inv_wear_suit(  ) {
			return;
		}

		public dynamic update_inv_wear_mask(  ) {
			return null;
		}

		public void update_inv_r_hand(  ) {
			return;
		}

		public void update_inv_l_hand(  ) {
			return;
		}

		public dynamic update_inv_back(  ) {
			return null;
		}

		public void update_inv_legcuffed(  ) {
			return;
		}

		public int update_inv_handcuffed(  ) {
			return 0;
		}

		public dynamic update_transform(  ) {
			return null;
		}

		public int update_hud(  ) {
			return 0;
		}

		public void update_icons(  ) {
			return;
		}

		public int regenerate_icons(  ) {
			return 0;
		}

		public int safe_animal( dynamic MP = null ) {
			if ( !Misc13.isValid( MP ) ) {
				return 0;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Construct) ) ) ) {
				return 0;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Pet_Cat) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Pet_Dog_Corgi) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Crab) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Hostile_Carp) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Hostile_Mushroom) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Shade) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Hostile_Killertomato) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Mouse) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Hostile_Bear) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Parrot) ) ) ) {
				return 1;
			}
			return 0;
		}

		public dynamic Animalize(  ) {
			dynamic _default = null;
			dynamic mobtypes = null;
			dynamic mobpath = null;
			dynamic new_mob = null;
			mobtypes = Misc13.types( typeof(Mob_Living_SimpleAnimal) );
			mobpath = Misc13.input( "Which type of mob should " + this + " turn into?", "Choose a type", null, null, mobtypes, 0 );
			if ( !Misc13.isValid( this.safe_animal( mobpath ) ) ) {
				Misc13.thread_user.write( "<span class='danger'>Sorry but this mob type is currently unavailable.</span>" );
				return null;
			}
			new_mob = Misc13.call( mobpath, this.loc );
			new_mob.key = this.key;
			new_mob.a_intent = "harm";
			new_mob.write( "You feel more... animalistic" );
			new_mob.update_pipe_vision();
			_default = new_mob;
			GlobalFuncs.qdel( this );
			return null;
			return _default;
		}

		public Mob_Living_Silicon_Ai AIize(  ) {
			Mob_Living_Silicon_Ai _default = null;
			Mob_Living_Silicon_Ai O = null;
			dynamic loc_landmark = null;
			dynamic sloc = null;
			dynamic tripai = null;
			dynamic comm = null;
			if ( Misc13.isValid( this.client ) ) {
				this.stopLobbySound();
			}
			O = new Mob_Living_Silicon_Ai( this.loc, null, null, 1 );
			O.invisibility = 0;
			O.aiRestorePowerRoutine = 0;
			if ( this.mind != null ) {
				this.mind.transfer_to( O );
			} else {
				O.key = this.key;
			}
			O.update_pipe_vision();
			sloc = null;
			foreach (dynamic _a in GlobalVars.landmarks_list ) {
				sloc = _a;
				if ( !( sloc is Ent_Effect_Landmark_Start ) ) {
					continue;
				}
				if ( sloc.name != "AI" ) {
					continue;
				}
				if ( Misc13.isValid( Misc13.locate_in( typeof(Mob_Living), sloc.loc ) ) ) {
					continue;
				}
				loc_landmark = sloc;
			};
			if ( !Misc13.isValid( loc_landmark ) ) {
				tripai = null;
				foreach (dynamic _b in GlobalVars.landmarks_list ) {
					tripai = _b;
					if ( !( tripai is Ent_Effect_Landmark ) ) {
						continue;
					}
					if ( tripai.name == "tripai" ) {
						if ( Misc13.isValid( Misc13.locate_in( typeof(Mob_Living), tripai.loc ) ) ) {
							continue;
						}
						loc_landmark = tripai;
					}
				};
			}
			if ( !Misc13.isValid( loc_landmark ) ) {
				O.write( "Oh god sorry we can't find an unoccupied AI spawn location, so we're spawning you on top of someone." );
				sloc = null;
				foreach (dynamic _c in GlobalVars.landmarks_list ) {
					sloc = _c;
					if ( !( sloc is Ent_Effect_Landmark_Start ) ) {
						continue;
					}
					if ( sloc.name == "AI" ) {
						loc_landmark = sloc;
					}
				};
			}
			O.loc = loc_landmark.loc;
			comm = null;
			foreach (dynamic _d in O.loc ) {
				comm = _d;
				if ( !( comm is Ent_Item_Device_Radio_Intercom ) ) {
					continue;
				}
				comm.ai += O;
			};
			O.write( "<B>You are playing the station's AI. The AI cannot move, but can interact with many objects while viewing them (through cameras).</B>" );
			O.write( "<B>To look at other parts of the station, click on yourself to get a camera menu.</B>" );
			O.write( "<B>While observing through a camera, you can use most (networked) devices which you can see, such as computers, APCs, intercoms, doors, etc.</B>" );
			O.write( "To use something, simply click on it." );
			O.write( "Use say \":b to speak to your cyborgs through binary." );
			O.write( "For department channels, use the following say commands:" );
			O.write( ":o - AI Private, :c - Command, :s - Security, :e - Engineering, :u - Supply, :v - Service, :m - Medical, :n - Science." );
			if ( !( ( GlobalVars.ticker != null ) && Misc13.isValid( GlobalVars.ticker.mode ) && Misc13.isValid( GlobalVars.ticker.mode.malf_ai.HasValue( O.mind ) ) ) ) {
				O.show_laws();
				O.write( "<b>These laws may be changed by other players, or by you being the traitor.</b>" );
			}
			O.verbs += typeof(Mob_Living_Silicon_Ai).GetMethod( "show_laws_verb" );
			O.verbs += typeof(Mob_Living_Silicon_Ai).GetMethod( "ai_statuschange" );
			O.job = "AI";
			O.rename_self( "ai", 1 );
			_default = O;
			GlobalFuncs.qdel( this );
			return null;
			return _default;
		}

		public int lingcheck(  ) {
			return 0;
		}

		public int hivecheck(  ) {
			return 0;
		}

		public void emote( dynamic act = null ) {
			return;
		}

		public void say_dead( dynamic message = null ) {
			dynamic name = null;
			string alt_name = "";
			string rendered = "";
			dynamic M = null;
			name = this.real_name;
			alt_name = "";
			if ( Misc13.isValid( GlobalVars.say_disabled ) ) {
				Misc13.thread_user.write( "<span class='danger'>Speech is currently admin-disabled.</span>" );
				return;
			}
			if ( ( this.mind != null ) && Misc13.isValid( this.mind.name ) ) {
				name = "" + this.mind.name;
			} else {
				name = this.real_name;
			}
			if ( name != this.real_name ) {
				alt_name = " (died as " + this.real_name + ")";
			}
			message = this.say_quote( message, this.get_spans() );
			rendered = "<span class='game deadsay'><span class='prefix'>DEAD:</span> <span class='name'>" + name + "</span>" + alt_name + " <span class='message'>" + message + "</span></span>";
			M = null;
			foreach (dynamic _a in GlobalVars.player_list ) {
				M = _a;
				if ( M is Mob_NewPlayer ) {
					continue;
				}
				if ( Misc13.isValid( M.client ) && Misc13.isValid( M.client.holder ) && Misc13.isValid( ( M.client.prefs.chat_toggles & 2 ) ) ) {
					M.write( rendered );
				} else if ( M.stat == 2 ) {
					M.write( rendered );
				}
			};
			return;
		}

		public dynamic change_mob_type( dynamic new_type = null, dynamic location = null, dynamic new_name = null, int delete_old_mob = 0 ) {
			dynamic M = null;
			Mob C = null;
			dynamic D = null;
			dynamic H = null;
			if ( new_type == null ) {
				new_type = null;
			}
			if ( location == null ) {
				location = null;
			}
			if ( new_name == null ) {
				new_name = null;
			}
			if ( delete_old_mob == null ) {
				delete_old_mob = 0;
			}
			if ( this is Mob_NewPlayer ) {
				Misc13.thread_user.write( "<span class='danger'>cannot convert players who have not entered yet.</span>" );
				return null;
			}
			if ( !Misc13.isValid( new_type ) ) {
				new_type = Misc13.input( "Mob type path:", "Mob type", null, null, null, 132 );
			}
			if ( new_type is string ) {
				new_type = Misc13.findType( new_type );
			}
			if ( !( new_type is Type ) ) {
				Misc13.thread_user.write( "Invalid type path (new_type = " + new_type + ") in change_mob_type(). Contact a coder." );
				return null;
			}
			if ( new_type == typeof(Mob_NewPlayer) ) {
				Misc13.thread_user.write( "<span class='danger'>cannot convert into a new_player mob type.</span>" );
				return null;
			}
			if ( location is Tile ) {
				M = Misc13.call( new_type, location );
			} else {
				M = Misc13.call( new_type, this.loc );
			}
			if ( !Misc13.isValid( M ) || !( M is Mob ) ) {
				Misc13.thread_user.write( "Type path is not a mob (new_type = " + new_type + ") in change_mob_type(). Contact a coder." );
				GlobalFuncs.qdel( M );
				return null;
			}
			if ( new_name is string ) {
				M.name = new_name;
				M.real_name = new_name;
			} else {
				M.name = this.name;
				M.real_name = this.real_name;
			}
			if ( Misc13.isValid( this.has_dna() ) && Misc13.isValid( M.has_dna() ) ) {
				C = this;
				D = M;
				C.dna.transfer_identity( D );
				new ByTable().set( "mutations_overlay_update", 1 ).set( "mutcolor_update", 1 ).apply( D.GetType().GetMethod( "updateappearance" ) );
			} else if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				this.client.prefs.copy_to( H );
				H.dna.update_dna_identity();
			}
			if ( ( this.mind != null ) && M is Mob_Living ) {
				this.mind.transfer_to( M );
			} else {
				M.key = this.key;
			}
			if ( delete_old_mob != 0 ) {
				Thread13.schedule( 1, (Thread13.Closure)(() => {
					GlobalFuncs.qdel( this );
					return;
				}));
			}
			return M;
		}

		public void update_gravity(  ) {
			return;
		}

		public int slip( dynamic s_amount = null, dynamic w_amount = null, dynamic O = null, dynamic lube = null ) {
			return 0;
		}

		public void Move_Pulled( dynamic A = null ) {
			BaseDynamic M = null;
			dynamic t = null;
			if ( !Misc13.isValid( this.canmove ) || Misc13.isValid( this.restrained() ) || ( this.pulling == null ) ) {
				return;
			}
			if ( Misc13.isValid( this.pulling.anchored ) ) {
				return;
			}
			if ( !Misc13.isValid( this.pulling.Adjacent( this ) ) ) {
				return;
			}
			if ( A == this.loc && Misc13.isValid( this.pulling.density ) ) {
				return;
			}
			if ( !Misc13.isValid( this.Process_Spacemove( Misc13.get_dist2( this.pulling.loc, A ) ) ) ) {
				return;
			}
			if ( this.pulling is Mob ) {
				M = this.pulling;
				t = M.pulling;
				M.stop_pulling();
				Misc13.step( this.pulling, Misc13.get_dist2( this.pulling.loc, A ) );
				if ( M != null ) {
					M.start_pulling( t );
				}
			} else {
				Misc13.step( this.pulling, Misc13.get_dist2( this.pulling.loc, A ) );
			}
			return;
		}

		public dynamic mob_negates_gravity(  ) {
			return 0;
		}

		public dynamic mob_has_gravity( dynamic T = null ) {
			return GlobalFuncs.has_gravity( this, T );
		}

		public int reagent_check( dynamic R = null ) {
			return 1;
		}

		public int abiotic( int full_body = 0 ) {
			if ( full_body == null ) {
				full_body = 0;
			}
			if ( Misc13.isValid( this.l_hand ) && !Misc13.isValid( this.l_hand.flags ) & 128 || Misc13.isValid( this.r_hand ) && !Misc13.isValid( this.r_hand.flags ) & 128 ) {
				return 1;
			}
			return 0;
		}

		public int can_unbuckle(  ) {
			return 1;
		}

		public int f_can_buckle(  ) {
			return 1;
		}

		public int get_mob_buckling_height( dynamic seat = null ) {
			dynamic L = null;
			if ( seat is Mob_Living ) {
				L = seat;
				if ( L.mob_size <= 1 ) {
					return 0;
				}
			}
			return 9;
		}

		public void AddSpell( dynamic spell = null ) {
			this.mob_spell_list += spell;
			if ( !Misc13.isValid( spell.action ) ) {
				spell.action = new Action_SpellAction();
				spell.action.target = spell;
				spell.action.name = spell.name;
				spell.action.button_icon = spell.action_icon;
				spell.action.button_icon_state = spell.action_icon_state;
				spell.action.background_icon_state = spell.action_background_icon_state;
			}
			if ( this is Mob_Living ) {
				spell.action.Grant( this );
			}
			return;
		}

		public void setEarDamage(  ) {
			return;
		}

		public void adjustEarDamage(  ) {
			return;
		}

		public dynamic notify_ghost_cloning( string message = "", ByRsc sound = null, dynamic source = null ) {
			dynamic ghost = null;
			if ( message == null ) {
				message = "Someone is trying to revive you. Re-enter your corpse if you want to be revived!";
			}
			if ( sound == null ) {
				sound = new ByRsc(231);
			}
			if ( source == null ) {
				source = null;
			}
			ghost = this.get_ghost();
			if ( Misc13.isValid( ghost ) ) {
				ghost.notify_cloning( message, sound, source );
				return ghost;
			}
			return null;
		}

		public dynamic get_ghost( int even_if_they_cant_reenter = 0 ) {
			dynamic G = null;
			if ( even_if_they_cant_reenter == null ) {
				even_if_they_cant_reenter = 0;
			}
			if ( this.mind != null ) {
				G = null;
				foreach (dynamic _a in GlobalVars.dead_mob_list ) {
					G = _a;
					if ( !( G is Mob_Dead_Observer ) ) {
						continue;
					}
					if ( G.mind == this.mind ) {
						if ( Misc13.isValid( G.can_reenter_corpse ) || ( even_if_they_cant_reenter != 0 ) ) {
							return G;
						}
						break;
					}
				};
			}
			return null;
		}

		public int assess_threat(  ) {
			return 0;
		}

		public void AdjustResting( dynamic amount = null ) {
			this.resting = Misc13.max( this.resting + amount, 0 );
			this.update_canmove();
			return;
		}

		public void SetResting( dynamic amount = null ) {
			this.resting = Misc13.max( amount, 0 );
			this.update_canmove();
			return;
		}

		public void Resting( dynamic amount = null ) {
			this.resting = Misc13.max( Misc13.max( this.resting, amount ), 0 );
			this.update_canmove();
			return;
		}

		public void AdjustSleeping( dynamic amount = null ) {
			this.sleeping = Misc13.max( this.sleeping + amount, 0 );
			this.update_canmove();
			return;
		}

		public void SetSleeping( dynamic amount = null ) {
			this.sleeping = Misc13.max( amount, 0 );
			this.update_canmove();
			return;
		}

		public void Sleeping( dynamic amount = null ) {
			this.sleeping = Misc13.max( Misc13.max( this.sleeping, amount ), 0 );
			this.update_canmove();
			return;
		}

		public void AdjustParalysis( int amount = 0 ) {
			if ( ( this.status_flags & 4 ) != 0 ) {
				this.paralysis = Misc13.max( this.paralysis + amount, 0 );
				this.update_canmove();
			}
			return;
		}

		public void SetParalysis( int amount = 0 ) {
			if ( ( this.status_flags & 4 ) != 0 ) {
				this.paralysis = Misc13.max( amount, 0 );
				this.update_canmove();
			}
			return;
		}

		public void Paralyse( int amount = 0 ) {
			if ( ( this.status_flags & 4 ) != 0 ) {
				this.paralysis = Misc13.max( Misc13.max( this.paralysis, amount ), 0 );
				this.update_canmove();
			}
			return;
		}

		public void AdjustWeakened( int amount = 0 ) {
			if ( ( this.status_flags & 2 ) != 0 ) {
				this.weakened = Misc13.max( this.weakened + amount, 0 );
				this.update_canmove();
			}
			return;
		}

		public void SetWeakened( int amount = 0 ) {
			if ( ( this.status_flags & 2 ) != 0 ) {
				this.weakened = Misc13.max( amount, 0 );
				this.update_canmove();
			}
			return;
		}

		public void Weaken( int amount = 0, int ignore_canweaken = 0 ) {
			if ( ignore_canweaken == null ) {
				ignore_canweaken = 0;
			}
			if ( ( ( this.status_flags & 2 ) != 0 ) || ( ignore_canweaken != 0 ) ) {
				this.weakened = Misc13.max( Misc13.max( this.weakened, amount ), 0 );
				this.update_canmove();
			}
			return;
		}

		public void AdjustStunned( int amount = 0 ) {
			if ( ( this.status_flags & 1 ) != 0 ) {
				this.stunned = Misc13.max( this.stunned + amount, 0 );
				this.update_canmove();
			}
			return;
		}

		public void SetStunned( int amount = 0 ) {
			if ( ( this.status_flags & 1 ) != 0 ) {
				this.stunned = Misc13.max( amount, 0 );
				this.update_canmove();
			}
			return;
		}

		public void Stun( int amount = 0 ) {
			if ( ( this.status_flags & 1 ) != 0 ) {
				this.stunned = Misc13.max( Misc13.max( this.stunned, amount ), 0 );
				this.update_canmove();
			}
			return;
		}

		public void Dizzy( int amount = 0 ) {
			this.dizziness = Misc13.max( this.dizziness, amount, 0 );
			return;
		}

		public void Jitter( int amount = 0 ) {
			this.jitteriness = Misc13.max( this.jitteriness, amount, 0 );
			return;
		}

		public void activate_hand( dynamic selhand = null ) {
			return;
		}

		public void swap_hand(  ) {
			return;
		}

		public int IsAdvancedToolUser(  ) {
			return 0;
		}

		public void fall( bool forced = false ) {
			this.drop_l_hand();
			this.drop_r_hand();
			return;
		}

		public dynamic update_canmove(  ) {
			bool ko = false;
			bool buckle_lying = false;
			ko = ( this.weakened != 0 ) || ( this.paralysis != 0 ) || ( this.stat != 0 ) || ( ( this.status_flags & 8192 ) != 0 );
			buckle_lying = !( Misc13.isValid( this.buckled ) && !Misc13.isValid( this.buckled.buckle_lying ) );
			if ( ko || Misc13.isValid( this.resting ) || ( this.stunned != 0 ) ) {
				this.drop_r_hand();
				this.drop_l_hand();
			} else {
				this.lying = 0;
				this.canmove = 1;
			}
			if ( Misc13.isValid( this.buckled ) ) {
				this.lying = buckle_lying * 90;
			} else if ( ( ko || Misc13.isValid( this.resting ) ) && !Misc13.isValid( this.lying ) ) {
				this.fall( ko );
			}
			this.canmove = !( ko || Misc13.isValid( this.resting ) || ( this.stunned != 0 ) || Misc13.isValid( this.buckled ) );
			this.density = !Misc13.isValid( this.lying );
			if ( Misc13.isValid( this.lying ) ) {
				if ( this.layer == Misc13.initial( this.layer ) ) {
					this.layer = 3.799999952316284;
				}
			} else if ( this.layer == 3.799999952316284 ) {
				this.layer = Misc13.initial( this.layer );
			}
			this.update_transform();
			this.lying_prev = this.lying;
			return this.canmove;
		}

		public int canface(  ) {
			if ( !Misc13.isValid( this.canmove ) ) {
				return 0;
			}
			if ( Misc13.isValid( this.client.moving ) ) {
				return 0;
			}
			if ( Game.time < this.client.move_delay ) {
				return 0;
			}
			if ( this.stat == 2 ) {
				return 0;
			}
			if ( Misc13.isValid( this.anchored ) ) {
				return 0;
			}
			if ( this.notransform != 0 ) {
				return 0;
			}
			if ( Misc13.isValid( this.restrained() ) ) {
				return 0;
			}
			return 1;
		}

		public void add_stings_to_statpanel( dynamic stings = null ) {
			dynamic S = null;
			S = null;
			foreach (dynamic _a in stings ) {
				S = _a;
				if ( !( S is Ent_Effect_ProcHolder_Changeling ) ) {
					continue;
				}
				if ( S.chemical_cost >= 0 && Misc13.isValid( S.can_be_used_by( this ) ) ) {
					Misc13.call( GlobalVars.undefined, "" + S.panel, S.chemical_cost > 0 ? "" + S.chemical_cost : "", S );
				}
			};
			return;
		}

		public void add_spells_to_statpanel( dynamic spells = null ) {
			dynamic S = null;
			S = null;
			foreach (dynamic _b in spells ) {
				S = _b;
				if ( !( S is Ent_Effect_ProcHolder_Spell ) ) {
					continue;
				}
				if ( Misc13.isValid( S.can_be_cast_by( this ) ) ) {
					dynamic _a = S.charge_type; // Was a switch-case, sorry for the mess.
					if ( _a=="recharge" ) {
						Misc13.call( GlobalVars.undefined, "" + S.panel, "" + S.charge_counter / 10 + "/" + S.charge_max / 10, S );
					} else if ( _a=="charges" ) {
						Misc13.call( GlobalVars.undefined, "" + S.panel, "" + S.charge_counter + "/" + S.charge_max, S );
					} else if ( _a=="holdervar" ) {
						Misc13.call( GlobalVars.undefined, "" + S.panel, "" + S.holder_var_type + " " + S.holder_var_amount, S );
					};
				}
			};
			return;
		}

		public void show_viewers( dynamic message = null ) {
			dynamic M = null;
			M = null;
			foreach (dynamic _a in Misc13.viewers( null, null ) ) {
				M = _a;
				M.see( message );
			};
			return;
		}

		public int see( dynamic message = null ) {
			if ( !Misc13.isValid( this.is_active() ) ) {
				return 0;
			}
			this.write( message );
			return 1;
		}

		public dynamic is_muzzled(  ) {
			return 0;
		}

		public dynamic is_active(  ) {
			return 0 >= Misc13.thread_user.stat;
		}

		public int can_use_hands(  ) {
			return 0;
		}

		public int stripPanelEquip( dynamic what = null, dynamic who = null ) {
			return 0;
		}

		public void stripPanelUnequip( dynamic what = null, dynamic who = null ) {
			return;
		}

		public void store_memory( dynamic msg = null, dynamic popup = null, int sane = 0 ) {
			if ( sane == null ) {
				sane = 1;
			}
			msg = Misc13.str_sub( msg, 1, 1024 );
			if ( sane != 0 ) {
				msg = GlobalFuncs.sanitize( msg );
			}
			if ( this.memory.Length == 0 ) {
				this.memory += msg;
			} else {
				this.memory += "<BR>" + msg;
			}
			if ( Misc13.isValid( popup ) ) {
				this.f_memory();
			}
			return;
		}

		public void start_pulling( BaseDynamic AM = null ) {
			BaseDynamic M = null;
			if ( ( AM == null ) || ( this == null ) || this == AM || !( AM.loc is Tile ) ) {
				return;
			}
			if ( !Misc13.isValid( AM.anchored ) ) {
				AM.add_fingerprint( this );
				if ( this.pulling != null ) {
					if ( AM == this.pulling ) {
						return;
					}
					this.stop_pulling();
				}
				this.pulling = AM;
				AM.pulledby = this;
				if ( this.pullin != null ) {
					this.pullin.update_icon( this );
				}
				if ( AM is Mob ) {
					M = AM;
					if ( !( this is Mob_Living_Carbon ) ) {
						M.LAssailant = null;
					} else {
						M.LAssailant = Misc13.thread_user;
					}
				}
			}
			return;
		}

		public void show_inv( dynamic user = null ) {
			return;
		}

		public void reset_view( dynamic A = null ) {
			if ( Misc13.isValid( this.client ) ) {
				if ( A is BaseDynamic ) {
					this.client.perspective = GlobalVars.EYE_PERSPECTIVE;
					this.client.eye = A;
				} else if ( this.loc is Tile ) {
					this.client.eye = this.client.mob;
					this.client.perspective = GlobalVars.MOB_PERSPECTIVE;
				} else {
					this.client.perspective = GlobalVars.EYE_PERSPECTIVE;
					this.client.eye = this.loc;
				}
			}
			return;
		}

		public int equip_to_appropriate_slot( dynamic W = null ) {
			dynamic slot = null;
			if ( !( W is Ent_Item ) ) {
				return 0;
			}
			slot = null;
			foreach (dynamic _a in GlobalVars.slot_equipment_priority ) {
				slot = _a;
				if ( Misc13.isValid( this.equip_to_slot_if_possible( W, slot, 0, 1, 1 ) ) ) {
					return 1;
				}
			};
			return 0;
		}

		public void equip_to_slot_or_del( dynamic W = null, dynamic slot = null ) {
			this.equip_to_slot_if_possible( W, slot, 1, 1, 0 );
			return;
		}

		public int equip_to_slot( dynamic W = null, dynamic slot = null ) {
			return 0;
		}

		public int equip_to_slot_if_possible( dynamic W = null, dynamic slot = null, int qdel_on_fail = 0, int disable_warning = 0, int redraw_mob = 0 ) {
			if ( qdel_on_fail == null ) {
				qdel_on_fail = 0;
			}
			if ( disable_warning == null ) {
				disable_warning = 0;
			}
			if ( redraw_mob == null ) {
				redraw_mob = 1;
			}
			if ( !( W is Ent_Item ) ) {
				return 0;
			}
			if ( !Misc13.isValid( W.mob_can_equip( this, slot, disable_warning ) ) ) {
				if ( qdel_on_fail != 0 ) {
					GlobalFuncs.qdel( W );
				} else if ( disable_warning == 0 ) {
					this.write( "<span class='warning'>You are unable to equip that!</span>" );
				}
				return 0;
			}
			this.equip_to_slot( W, slot, redraw_mob );
			return 1;
		}

		public int put_in_any_hand_if_possible( dynamic W = null, int qdel_on_fail = 0, int disable_warning = 0, int redraw_mob = 0 ) {
			if ( qdel_on_fail == null ) {
				qdel_on_fail = 0;
			}
			if ( disable_warning == null ) {
				disable_warning = 1;
			}
			if ( redraw_mob == null ) {
				redraw_mob = 1;
			}
			if ( Misc13.isValid( this.equip_to_slot_if_possible( W, 4, qdel_on_fail, disable_warning, redraw_mob ) ) ) {
				return 1;
			} else if ( Misc13.isValid( this.equip_to_slot_if_possible( W, 5, qdel_on_fail, disable_warning, redraw_mob ) ) ) {
				return 1;
			}
			return 0;
		}

		public int attack_ui( dynamic slot = null ) {
			dynamic W = null;
			dynamic I = null;
			W = this.get_active_hand();
			if ( W is Ent_Item ) {
				if ( Misc13.isValid( this.equip_to_slot_if_possible( W, slot, 0, 0, 0 ) ) ) {
					return 1;
				}
			}
			if ( !Misc13.isValid( W ) ) {
				I = this.get_item_by_slot( slot );
				if ( I is Ent_Item ) {
					I.attack_hand( this );
				}
			}
			return 0;
		}

		public int incapacitated(  ) {
			return 0;
		}

		public int restrained(  ) {
			return 0;
		}

		public ByTable ret_grab( Ent_Effect_ListContainer_Mobl L = null, int flag = 0 ) {
			dynamic G = null;
			ByTable temp = null;
			if ( !( this.l_hand is Ent_Item_Weapon_Grab ) && !( this.r_hand is Ent_Item_Weapon_Grab ) ) {
				if ( L == null ) {
					return null;
				} else {
					return L.container;
				}
			} else {
				if ( L == null ) {
					L = new Ent_Effect_ListContainer_Mobl( null );
					L.container += this;
					L.master = this;
				}
				if ( this.l_hand is Ent_Item_Weapon_Grab ) {
					G = this.l_hand;
					if ( !Misc13.isValid( L.container.Find( G.affecting ) ) ) {
						L.container += G.affecting;
						if ( Misc13.isValid( G.affecting ) ) {
							G.affecting.ret_grab( L, 1 );
						}
					}
				}
				if ( this.r_hand is Ent_Item_Weapon_Grab ) {
					G = this.r_hand;
					if ( !Misc13.isValid( L.container.Find( G.affecting ) ) ) {
						L.container += G.affecting;
						if ( Misc13.isValid( G.affecting ) ) {
							G.affecting.ret_grab( L, 1 );
						}
					}
				}
				if ( flag == 0 ) {
					if ( L.master == this ) {
						temp = new ByTable();
						temp += L.container;
						GlobalFuncs.qdel( L );
						return temp;
					} else {
						return L.container;
					}
				}
			}
			return null;
		}

		public dynamic get_item_by_slot( int slot_id = 0 ) {
			dynamic _a = slot_id; // Was a switch-case, sorry for the mess.
			if ( _a==4 ) {
				return this.l_hand;
			} else if ( _a==5 ) {
				return this.r_hand;
			};
			return null;
		}

		public int Life(  ) {
			return 0;
		}

		public int movement_delay(  ) {
			return 0;
		}

		public void show_message( string msg = "", int type = 0, string alt = "", int alt_type = 0 ) {
			if ( !Misc13.isValid( this.client ) ) {
				return;
			}
			msg = Misc13.str_sub( msg, 1, 1024 );
			if ( type != 0 ) {
				if ( ( ( type & 1 ) != 0 ) && ( ( ( this.disabilities & 1 ) != 0 ) || ( this.paralysis != 0 ) ) ) {
					if ( !Misc13.isValid( alt ) ) {
						return;
					} else {
						msg = alt;
						type = alt_type;
					}
				}
				if ( ( ( type & 2 ) != 0 ) && ( this.ear_deaf != 0 ) ) {
					if ( !Misc13.isValid( alt ) ) {
						return;
					} else {
						msg = alt;
						type = alt_type;
						if ( ( ( type & 1 ) != 0 ) && ( ( this.disabilities & 1 ) != 0 ) ) {
							return;
						}
					}
				}
			}
			if ( this.stat == 1 || this.sleeping > 0 ) {
				this.write( "<I>... You can almost hear someone talking ...</I>" );
			} else {
				this.write( msg );
			}
			return;
		}

		public int Cell(  ) {
			dynamic environment = null;
			string t = "";
			dynamic trace_gas = null;
			if ( !Misc13.isValid( this.loc ) ) {
				return 0;
			}
			environment = this.loc.return_air();
			t = "<span class='notice'>Coordinates: " + this.x + "," + this.y + " \n</span>";
			t += "<span class='danger'>Temperature: " + environment.temperature + " \n</span>";
			t += "<span class='notice'>Nitrogen: " + environment.nitrogen + " \n</span>";
			t += "<span class='notice'>Oxygen: " + environment.oxygen + " \n</span>";
			t += "<span class='notice'>Plasma : " + environment.toxins + " \n</span>";
			t += "<span class='notice'>Carbon Dioxide: " + environment.carbon_dioxide + " \n</span>";
			trace_gas = null;
			foreach (dynamic _a in environment.trace_gases ) {
				trace_gas = _a;
				if ( !( trace_gas is Gas ) ) {
					continue;
				}
				t += "<span class='notice'>" + trace_gas.type + ": " + trace_gas.moles + " \n</span>";
			};
			Misc13.thread_user.show_message( t, 1 );
			return 0;
		}

		public void sac_act( dynamic R = null, dynamic victim = null ) {
			return;
		}

		public void update_normal_mode(  ) {
			Misc13.winset( this, null, "mainwindow.macro=macro hotkey_toggle.is-checked=false input.focus=true input.background-color=#D3B5B5" );
			return;
		}

		public void update_hotkey_mode(  ) {
			Misc13.winset( this, null, "mainwindow.macro=hotkeymode hotkey_toggle.is-checked=true mapwindow.map.focus=true input.background-color=#F0F0F0" );
			return;
		}

		public void update_interface(  ) {
			if ( Misc13.isValid( this.client ) ) {
				if ( Misc13.winget( this, "mainwindow.hotkey_toggle", "is-checked" ) == "true" ) {
					this.update_hotkey_mode();
				} else {
					this.update_normal_mode();
				}
			}
			return;
		}

		public void update_Login_details(  ) {
			dynamic M = null;
			string matches = "";
			this.lastKnownIP = this.client.address;
			this.computer_id = this.client.computer_id;
			GlobalFuncs.log_access( "Login: " + GlobalFuncs.key_name( this ) + " from " + ( Misc13.isValid( this.lastKnownIP ) ? this.lastKnownIP : "localhost" ) + "-" + this.computer_id + " || BYOND v" + this.client.byond_version );
			if ( Misc13.isValid( GlobalVars.config.log_access ) ) {
				M = null;
				foreach (dynamic _a in GlobalVars.player_list ) {
					M = _a;
					if ( M == this ) {
						continue;
					}
					if ( Misc13.isValid( M.key ) && M.key != this.key ) {
						matches = null;
						if ( M.lastKnownIP == this.client.address ) {
							matches += "IP (" + this.client.address + ")";
						}
						if ( M.computer_id == this.client.computer_id ) {
							if ( Misc13.isValid( matches ) ) {
								matches += " and ";
							}
							matches += "ID (" + this.client.computer_id + ")";
							Thread13.schedule( 0, (Thread13.Closure)(() => {
								Misc13.alert( "You have logged in already with another key this round, please log out of this one NOW or risk being banned!", null, null, null, null, null );
								return;
							}));
						}
						if ( Misc13.isValid( matches ) ) {
							if ( Misc13.isValid( M.client ) ) {
								GlobalFuncs.message_admins( "<font color='red'><B>Notice: </B><font color='blue'>" + GlobalFuncs.key_name_admin( this ) + " has the same " + matches + " as " + GlobalFuncs.key_name_admin( M ) + ".</font>" );
								GlobalFuncs.log_access( "Notice: " + GlobalFuncs.key_name( this ) + " has the same " + matches + " as " + GlobalFuncs.key_name( M ) + "." );
							} else {
								GlobalFuncs.message_admins( "<font color='red'><B>Notice: </B><font color='blue'>" + GlobalFuncs.key_name_admin( this ) + " has the same " + matches + " as " + GlobalFuncs.key_name_admin( M ) + " (no longer logged in). </font>" );
								GlobalFuncs.log_access( "Notice: " + GlobalFuncs.key_name( this ) + " has the same " + matches + " as " + GlobalFuncs.key_name( M ) + " (no longer logged in)." );
							}
						}
					}
				};
			}
			return;
		}

		public dynamic get_equipped_items(  ) {
			dynamic items = null;
			items = new ByTable();
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "back" ) ) ) {
				if ( Misc13.isValid( this.back ) ) {
					items += this.back;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "belt" ) ) ) {
				if ( Misc13.isValid( this.belt ) ) {
					items += this.belt;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "ears" ) ) ) {
				if ( Misc13.isValid( this.ears ) ) {
					items += this.ears;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "glasses" ) ) ) {
				if ( Misc13.isValid( this.glasses ) ) {
					items += this.glasses;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "gloves" ) ) ) {
				if ( Misc13.isValid( this.gloves ) ) {
					items += this.gloves;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "head" ) ) ) {
				if ( Misc13.isValid( this.head ) ) {
					items += this.head;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "shoes" ) ) ) {
				if ( Misc13.isValid( this.shoes ) ) {
					items += this.shoes;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "wear_id" ) ) ) {
				if ( Misc13.isValid( this.wear_id ) ) {
					items += this.wear_id;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "wear_mask" ) ) ) {
				if ( Misc13.isValid( this.wear_mask ) ) {
					items += this.wear_mask;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "wear_suit" ) ) ) {
				if ( Misc13.isValid( this.wear_suit ) ) {
					items += this.wear_suit;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "w_uniform" ) ) ) {
				if ( Misc13.isValid( this.w_uniform ) ) {
					items += this.w_uniform;
				}
			}
			return items;
		}

		public int remove_from_mob( dynamic O = null ) {
			this.unEquip( O );
			O.screen_loc = null;
			return 1;
		}

		public int unEquip( dynamic I = null, int force = 0 ) {
			if ( !Misc13.isValid( I ) ) {
				return 1;
			}
			if ( Misc13.isValid( ( I.flags & 2 ) ) && ( force == 0 ) ) {
				return 0;
			}
			if ( I == this.r_hand ) {
				this.r_hand = null;
				this.update_inv_r_hand();
			} else if ( I == this.l_hand ) {
				this.l_hand = null;
				this.update_inv_l_hand();
			}
			if ( Misc13.isValid( I ) ) {
				if ( Misc13.isValid( this.client ) ) {
					this.client.screen -= I;
				}
				I.loc = this.loc;
				I.dropped( this );
				if ( Misc13.isValid( I ) ) {
					I.layer = Misc13.initial( I.layer );
				}
			}
			return 1;
		}

		public int canUnEquip( dynamic I = null, dynamic force = null ) {
			if ( !Misc13.isValid( I ) ) {
				return 1;
			}
			if ( Misc13.isValid( ( I.flags & 2 ) ) && !Misc13.isValid( force ) ) {
				return 0;
			}
			return 1;
		}

		public dynamic drop_item(  ) {
			if ( Misc13.isValid( this.hand ) ) {
				return this.drop_l_hand();
			} else {
				return this.drop_r_hand();
			}
			return null;
		}

		public dynamic drop_r_hand(  ) {
			if ( !Misc13.isValid( this.loc.allow_drop() ) ) {
				return null;
			}
			return this.unEquip( this.r_hand );
		}

		public dynamic drop_l_hand(  ) {
			if ( !Misc13.isValid( this.loc.allow_drop() ) ) {
				return null;
			}
			return this.unEquip( this.l_hand );
		}

		public int drop_item_v(  ) {
			if ( this.stat == 0 && this.loc is Tile ) {
				return this.drop_item();
			}
			return 0;
		}

		public int put_in_hands( Ent_Item_Weapon_Melee_ArmBlade_False W = null ) {
			if ( W == null ) {
				return 0;
			}
			if ( Misc13.isValid( this.put_in_active_hand( W ) ) ) {
				return 1;
			} else if ( Misc13.isValid( this.put_in_inactive_hand( W ) ) ) {
				return 1;
			} else {
				W.loc = GlobalFuncs.get_turf( this );
				W.layer = Misc13.initial( W.layer );
				W.dropped( this );
				return 0;
			}
			return 0;
		}

		public dynamic put_in_inactive_hand( Ent_Item_Weapon_Melee_ArmBlade_False W = null ) {
			if ( Misc13.isValid( this.hand ) ) {
				return this.put_in_r_hand( W );
			} else {
				return this.put_in_l_hand( W );
			}
			return null;
		}

		public dynamic put_in_active_hand( dynamic W = null ) {
			if ( Misc13.isValid( this.hand ) ) {
				return this.put_in_l_hand( W );
			} else {
				return this.put_in_r_hand( W );
			}
			return null;
		}

		public int put_in_hand_check( dynamic W = null ) {
			if ( Misc13.isValid( this.lying ) && !Misc13.isValid( W.flags & 128 ) ) {
				return 0;
			}
			if ( !( W is Ent_Item ) ) {
				return 0;
			}
			return 1;
		}

		public int put_in_r_hand( dynamic W = null ) {
			if ( !Misc13.isValid( this.put_in_hand_check( W ) ) ) {
				return 0;
			}
			if ( !Misc13.isValid( this.r_hand ) ) {
				W.loc = this;
				this.r_hand = W;
				W.layer = 20;
				W.equipped( this, 5 );
				if ( Misc13.isValid( this.client ) ) {
					this.client.screen |= W;
				}
				if ( this.pulling == W ) {
					this.stop_pulling();
				}
				this.update_inv_r_hand();
				W.pixel_x = Misc13.initial( W.pixel_x );
				W.pixel_y = Misc13.initial( W.pixel_y );
				return 1;
			}
			return 0;
		}

		public int put_in_l_hand( dynamic W = null ) {
			if ( !Misc13.isValid( this.put_in_hand_check( W ) ) ) {
				return 0;
			}
			if ( !Misc13.isValid( this.l_hand ) ) {
				W.loc = this;
				this.l_hand = W;
				W.layer = 20;
				W.equipped( this, 4 );
				if ( Misc13.isValid( this.client ) ) {
					this.client.screen |= W;
				}
				if ( this.pulling == W ) {
					this.stop_pulling();
				}
				this.update_inv_l_hand();
				W.pixel_x = Misc13.initial( W.pixel_x );
				W.pixel_y = Misc13.initial( W.pixel_y );
				return 1;
			}
			return 0;
		}

		public int can_equip( Ent_Item I = null, dynamic slot = null, int disable_warning = 0 ) {
			if ( disable_warning == null ) {
				disable_warning = 0;
			}
			return 0;
		}

		public dynamic get_inactive_hand(  ) {
			if ( Misc13.isValid( this.hand ) ) {
				return this.r_hand;
			} else {
				return this.l_hand;
			}
			return null;
		}

		public dynamic get_active_hand(  ) {
			if ( Misc13.isValid( this.hand ) ) {
				return this.l_hand;
			} else {
				return this.r_hand;
			}
			return null;
		}

		public int death( dynamic gibbed = null ) {
			return 0;
		}

		public void dust(  ) {
			return;
		}

		public dynamic gib(  ) {
			return null;
		}

		public void on_forcemove( dynamic newloc = null ) {
			return;
		}

		public void set_machine( dynamic O = null ) {
			if ( Misc13.isValid( this.machine ) ) {
				this.unset_machine();
			}
			this.machine = O;
			if ( O is Entity ) {
				O.in_use = 1;
			}
			return;
		}

		public void unset_machine(  ) {
			this.machine = null;
			return;
		}

		public void clearmap(  ) {
			dynamic O = null;
			this.client.screen -= this.mapobjs;
			O = null;
			foreach (dynamic _a in this.mapobjs ) {
				O = _a;
				if ( !( O is Ent_Screen ) ) {
					continue;
				}
				GlobalFuncs.qdel( O );
			};
			this.mapobjs = null;
			this.unset_machine();
			return;
		}

		public int canUseTopic(  ) {
			return 0;
		}

		public int casting(  ) {
			if ( !( Misc13.thread_user.wear_suit is Ent_Item_Clothing_Suit_Wizrobe ) ) {
				Misc13.thread_user.write( "I don't feel strong enough without my robe." );
				return 0;
			}
			if ( !( Misc13.thread_user.shoes is Ent_Item_Clothing_Shoes_Sandal ) ) {
				Misc13.thread_user.write( "I don't feel strong enough without my sandals." );
				return 0;
			}
			if ( !( Misc13.thread_user.head is Ent_Item_Clothing_Head_Wizard ) ) {
				Misc13.thread_user.write( "I don't feel strong enough without my hat." );
				return 0;
			} else {
				return 1;
			}
			return 0;
		}

		public void spellremove( dynamic M = null ) {
			dynamic spell_to_remove = null;
			if ( this.mind == null ) {
				return;
			}
			spell_to_remove = null;
			foreach (dynamic _a in this.mind.spell_list ) {
				spell_to_remove = _a;
				if ( !( spell_to_remove is Ent_Effect_ProcHolder_Spell ) ) {
					continue;
				}
				GlobalFuncs.qdel( spell_to_remove );
				this.mind.spell_list -= spell_to_remove;
			};
			return;
		}

		public void sandbox_panel(  ) {
			if ( this.sandbox != null ) {
				this.sandbox.update();
			}
			return;
		}

		public void CanBuild(  ) {
			if ( GlobalVars.master_mode == "sandbox" ) {
				this.sandbox = new HSB();
				this.sandbox.owner = this.ckey;
				if ( Misc13.isValid( this.client.holder ) ) {
					this.sandbox.admin = 1;
				}
				this.verbs += Misc13.call( typeof(Mob).GetMethod( "sandbox_panel" ) );
			}
			return;
		}

		public int null_rod_check(  ) {
			dynamic N = null;
			N = Misc13.locate_in( typeof(Ent_Item_Weapon_Nullrod), this );
			if ( Misc13.isValid( N ) ) {
				return 1;
			}
			return 0;
		}

		public void cult_add_comm(  ) {
			this.verbs += typeof(Mob_Living).GetMethod( "cult_innate_comm" );
			return;
		}

		public void remove_changeling_powers( int keep_free_powers = 0 ) {
			dynamic p = null;
			if ( keep_free_powers == null ) {
				keep_free_powers = 0;
			}
			if ( this is Mob_Living_Carbon_Human || this is Mob_Living_Carbon_Monkey ) {
				if ( ( this.mind != null ) && ( this.mind.changeling != null ) ) {
					this.mind.changeling.changeling_speak = 0;
					this.mind.changeling.reset();
					p = null;
					foreach (dynamic _a in this.mind.changeling.purchasedpowers ) {
						p = _a;
						if ( !( p is Ent_Effect_ProcHolder_Changeling ) ) {
							continue;
						}
						if ( p.dna_cost == 0 && ( keep_free_powers != 0 ) ) {
							continue;
						}
						this.mind.changeling.purchasedpowers -= p;
						p.on_refund( this );
					};
				}
				if ( this.hud_used != null ) {
					this.hud_used.lingstingdisplay.icon_state = null;
					this.hud_used.lingstingdisplay.invisibility = 101;
				}
			}
			return;
		}

		public int make_changeling(  ) {
			dynamic path = null;
			dynamic S = null;
			Mob C = null;
			dynamic prof = null;
			if ( this.mind == null ) {
				return 0;
			}
			if ( !( this is Mob_Living_Carbon_Human ) && !( this is Mob_Living_Carbon_Monkey ) ) {
				return 0;
			}
			if ( this.mind.changeling == null ) {
				this.mind.changeling = new Changeling( this.gender );
			}
			if ( !Misc13.isValid( GlobalVars.sting_paths ) ) {
				GlobalVars.sting_paths = GlobalFuncs.init_paths( typeof(Ent_Effect_ProcHolder_Changeling) );
			}
			if ( Misc13.isValid( this.mind.changeling.purchasedpowers ) ) {
				this.remove_changeling_powers( 1 );
			}
			path = null;
			foreach (dynamic _a in GlobalVars.sting_paths ) {
				path = _a;
				S = Misc13.call( path );
				if ( !Misc13.isValid( S.dna_cost ) ) {
					if ( !Misc13.isValid( this.mind.changeling.has_sting( S ) ) ) {
						this.mind.changeling.purchasedpowers += S;
					}
					S.on_purchase( this );
				}
			};
			C = this;
			if ( C is Mob_Living_Carbon_Human ) {
				prof = this.mind.changeling.add_profile( C );
				this.mind.changeling.first_prof = prof;
			}
			return 1;
		}

		public void stopLobbySound(  ) {
			this.write( new ByTable().set( "channel", 1 ).set( "volume", 85 ).set( "wait", 0 ).set( "repeat", 0 ).set( 1, null ).applyCtor( typeof(Sound) ) );
			return;
		}

		public void domutcheck(  ) {
			return;
		}

		public Dna has_dna(  ) {
			return null;
		}

		public void set_species( dynamic mrace = null, int icon_update = 0 ) {
			if ( icon_update == null ) {
				icon_update = 1;
			}
			return;
		}

		public int ForceContractDisease( dynamic D = null ) {
			if ( !Misc13.isValid( this.CanContractDisease( D ) ) ) {
				return 0;
			}
			this.AddDisease( D );
			return 0;
		}

		public void AddDisease( dynamic D = null ) {
			dynamic DD = null;
			ByTable skipped = null;
			dynamic V = null;
			dynamic L = null;
			DD = D.type( 1, D, 0 );
			this.viruses += DD;
			DD.affected_mob = this;
			DD.holder = this;
			skipped = new ByTable(new object [] { "affected_mob", "holder", "carrier", "stage", "type", "parent_type", "vars", "transformed" });
			V = null;
			foreach (dynamic _a in DD.vars ) {
				V = _a;
				if ( Misc13.isValid( skipped.HasValue( V ) ) ) {
					continue;
				}
				if ( Misc13.isValid( typeof(ByTable).IsInstanceOfType( DD.vars[V] ) ) ) {
					L = D.vars[V];
					DD.vars[V] = L.Copy();
				} else {
					DD.vars[V] = D.vars[V];
				}
			};
			DD.affected_mob.med_hud_set_status();
			return;
		}

		public int ContractDisease( dynamic D = null ) {
			if ( !Misc13.isValid( this.CanContractDisease( D ) ) ) {
				return 0;
			}
			this.AddDisease( D );
			return 0;
		}

		public int CanContractDisease( dynamic D = null ) {
			if ( this.stat == 2 ) {
				return 0;
			}
			if ( Misc13.isValid( this.resistances.HasValue( D.GetDiseaseID() ) ) ) {
				return 0;
			}
			if ( Misc13.isValid( this.HasDisease( D ) ) ) {
				return 0;
			}
			if ( !Misc13.isValid( D.viable_mobtypes.HasValue( this.type ) ) ) {
				return 0;
			}
			if ( GlobalFuncs.count_by_type( this.viruses, typeof(Disease_Advance) ) >= 3 ) {
				return 0;
			}
			return 1;
		}

		public int HasDisease( dynamic D = null ) {
			dynamic DD = null;
			DD = null;
			foreach (dynamic _a in this.viruses ) {
				DD = _a;
				if ( !( DD is Disease ) ) {
					continue;
				}
				if ( Misc13.isValid( D.IsSame( DD ) ) ) {
					return 1;
				}
			};
			return 0;
		}

		public void mind_initialize(  ) {
			if ( this.mind != null ) {
				this.mind.key = this.key;
			} else {
				this.mind = new Mind( this.key );
				if ( GlobalVars.ticker != null ) {
					GlobalVars.ticker.minds += this.mind;
				} else {
					Thread13.schedule( 0, (Thread13.Closure)(() => {
						throw new Exception( "mind_initialize(): No ticker ready", "code/datums/mind.dm", 1496 );
						return;
					}));
				}
			}
			if ( !Misc13.isValid( this.mind.name ) ) {
				this.mind.name = this.real_name;
			}
			this.mind.current = this;
			return;
		}

		public void sync_mind(  ) {
			this.mind_initialize();
			this.mind.active = 1;
			return;
		}

		public void reload_huds(  ) {
			ByTable gang_huds = null;
			dynamic G = null;
			dynamic hud = null;
			gang_huds = new ByTable();
			if ( Misc13.isValid( GlobalVars.ticker.mode ) ) {
				G = null;
				foreach (dynamic _a in GlobalVars.ticker.mode.gangs ) {
					G = _a;
					if ( !( G is Gang ) ) {
						continue;
					}
					gang_huds += G.ganghud;
				};
			}
			hud = null;
			foreach (dynamic _b in GlobalVars.huds | gang_huds ) {
				hud = _b;
				if ( !( hud is AtomHud ) ) {
					continue;
				}
				if ( Misc13.isValid( hud.hudusers.HasValue( this ) ) ) {
					hud.add_hud_to( this );
				}
			};
			return;
		}

		public void browse_rsc_icon( dynamic icon = null, dynamic icon_state = null, int dir = 0 ) {
			if ( dir == null ) {
				dir = -1;
			}
			return;
		}

		public int clear_alert( string category = "" ) {
			dynamic alert = null;
			alert = this.alerts[category];
			if ( !Misc13.isValid( alert ) ) {
				return 0;
			}
			this.alerts -= category;
			if ( Misc13.isValid( this.client ) && ( this.hud_used != null ) ) {
				this.hud_used.reorganize_alerts();
				this.client.screen -= alert;
			}
			GlobalFuncs.qdel( alert );
			return 0;
		}

		public dynamic throw_alert( string category = "", Type type = null, int severity = 0, dynamic new_master = null ) {
			dynamic alert = null;
			dynamic old_layer = null;
			if ( !Misc13.isValid( category ) ) {
				return null;
			}
			if ( Misc13.isValid( this.alerts[category] ) ) {
				alert = this.alerts[category];
				if ( Misc13.isValid( new_master ) && new_master != alert.master ) {
					GlobalFuncs.warning( "" + ( "" + this + " threw alert " + category + " with new_master " + new_master + " while already having that alert with master " + alert.master ) + " in " + "code/_onclick/hud/alert.dm" + " at line " + 27 + " src: " + this + " usr: " + Misc13.thread_user + "." );
					this.clear_alert( category );
					return undefined._BROKEN_INDEX_();
				} else if ( alert.type == type && ( ( severity == 0 ) || severity == alert.severity ) ) {
					if ( Misc13.isValid( alert.timeout ) ) {
						this.clear_alert( category );
						return undefined._BROKEN_INDEX_();
					} else {
						return 0;
					}
				}
			} else {
				alert = GlobalFuncs.PoolOrNew( type );
			}
			if ( Misc13.isValid( new_master ) ) {
				old_layer = new_master.layer;
				new_master.layer = GlobalVars.FLOAT_LAYER;
				alert.overlays += new_master;
				new_master.layer = old_layer;
				alert.icon_state = "template";
				alert.master = new_master;
			} else {
				alert.icon_state = "" + Misc13.initial( alert.icon_state ) + severity;
				alert.severity = severity;
			}
			this.alerts[category] = alert;
			if ( Misc13.isValid( this.client ) && ( this.hud_used != null ) ) {
				this.hud_used.reorganize_alerts();
			}
			alert.transform = new Matrix( 32, 6, 7 );
			Misc13.animate_listcall( new ByTable().set( "easing", 3 ).set( "time", 2.5 ).set( "transform", new Matrix() ).set( 1, alert ) );
			if ( Misc13.isValid( alert.timeout ) ) {
				Thread13.schedule( alert.timeout, (Thread13.Closure)(() => {
					if ( Misc13.isValid( alert.timeout ) && this.alerts[category] == alert && Game.time >= alert.timeout ) {
						this.clear_alert( category );
					}
					return;
				}));
				alert.timeout = Game.time + alert.timeout - Game.tick_lag;
			}
			return alert;
		}

		public void update_action_buttons(  ) {
			return;
		}

		public void face_atom( BaseStatic A = null ) {
			dynamic dx = null;
			dynamic dy = null;
			if ( Misc13.isValid( this.buckled ) || this.stat != 0 || ( A == null ) || !Misc13.isValid( this.x ) || !Misc13.isValid( this.y ) || !Misc13.isValid( A.x ) || !Misc13.isValid( A.y ) ) {
				return;
			}
			dx = A.x - this.x;
			dy = A.y - this.y;
			if ( !Misc13.isValid( dx ) && !Misc13.isValid( dy ) ) {
				if ( A.pixel_y > 16 ) {
					this.dir = GlobalVars.NORTH;
				} else if ( A.pixel_y < -16 ) {
					this.dir = GlobalVars.SOUTH;
				} else if ( A.pixel_x > 16 ) {
					this.dir = GlobalVars.EAST;
				} else if ( A.pixel_x < -16 ) {
					this.dir = GlobalVars.WEST;
				}
				return;
			}
			if ( Math.Abs( dx ) < Math.Abs( dy ) ) {
				if ( dy > 0 ) {
					this.dir = GlobalVars.NORTH;
				} else {
					this.dir = GlobalVars.SOUTH;
				}
			} else if ( dx > 0 ) {
				this.dir = GlobalVars.EAST;
			} else {
				this.dir = GlobalVars.WEST;
			}
			return;
		}

		public void LaserEyes( dynamic A = null ) {
			return;
		}

		public void CtrlShiftClickOn( BaseStatic A = null ) {
			A.CtrlShiftClick( this );
			return;
		}

		public bool TurfAdjacent( dynamic T = null ) {
			return T.Adjacent( this );
		}

		public void AltClickOn( BaseStatic A = null ) {
			A.AltClick( this );
			return;
		}

		public void CtrlClickOn( BaseStatic A = null ) {
			A.CtrlClick( this );
			return;
		}

		public void ShiftClickOn( BaseStatic A = null ) {
			A.ShiftClick( this );
			return;
		}

		public void MiddleClickOn( BaseStatic A = null ) {
			return;
		}

		public int RestrainedClickOn( BaseStatic A = null ) {
			return 0;
		}

		public void RangedAttack( BaseStatic A = null, dynamic _params = null ) {
			return;
		}

		public void UnarmedAttack( BaseStatic A = null, int proximity_flag = 0 ) {
			if ( A is Mob ) {
				this.changeNext_move( 8 );
			}
			return;
		}

		public void DblClickOn( dynamic A = null, dynamic _params = null ) {
			return;
		}

		public dynamic ClickOn( BaseStatic A = null, dynamic _params = null ) {
			dynamic modifiers = null;
			dynamic M = null;
			dynamic W = null;
			dynamic resolved = null;
			if ( Game.time <= this.next_click ) {
				return null;
			}
			this.next_click = Game.time + 1;
			if ( Misc13.isValid( this.client.buildmode ) ) {
				GlobalFuncs.build_click( this, this.client.buildmode, _params, A );
				return null;
			}
			modifiers = Misc13.conv_params2list( _params );
			if ( Misc13.isValid( modifiers["shift"] ) && Misc13.isValid( modifiers["ctrl"] ) ) {
				this.CtrlShiftClickOn( A );
				return null;
			}
			if ( Misc13.isValid( modifiers["middle"] ) ) {
				this.MiddleClickOn( A );
				return null;
			}
			if ( Misc13.isValid( modifiers["shift"] ) ) {
				this.ShiftClickOn( A );
				return null;
			}
			if ( Misc13.isValid( modifiers["alt"] ) ) {
				this.AltClickOn( A );
				return null;
			}
			if ( Misc13.isValid( modifiers["ctrl"] ) ) {
				this.CtrlClickOn( A );
				return null;
			}
			if ( ( this.stat != 0 ) || ( this.paralysis != 0 ) || ( this.stunned != 0 ) || ( this.weakened != 0 ) ) {
				return null;
			}
			this.face_atom( A );
			if ( this.next_move > Game.time ) {
				return null;
			}
			if ( this.loc is Ent_Mecha ) {
				M = this.loc;
				return M.click_action( A, this );
			}
			if ( Misc13.isValid( this.restrained() ) ) {
				this.changeNext_move( 10 );
				this.RestrainedClickOn( A );
				return null;
			}
			if ( this.in_throw_mode != 0 ) {
				this.throw_item( A );
				return null;
			}
			W = this.get_active_hand();
			if ( W == A ) {
				W.attack_self( this );
				if ( Misc13.isValid( this.hand ) ) {
					this.update_inv_l_hand( 0 );
				} else {
					this.update_inv_r_hand( 0 );
				}
				return null;
			}
			if ( !( A is Tile ) && A == this.loc || Misc13.isValid( this.contents.HasValue( A ) ) || Misc13.isValid( this.contents.HasValue( A.loc ) ) || Misc13.isValid( A.loc ) && Misc13.isValid( this.contents.HasValue( A.loc.loc ) ) ) {
				if ( Misc13.isValid( W ) ) {
					resolved = A.attackby( W, this );
					if ( !Misc13.isValid( resolved ) && ( A != null ) && Misc13.isValid( W ) ) {
						W.afterattack( A, this, 1, _params );
					}
				} else {
					if ( A is Mob ) {
						this.changeNext_move( 8 );
					}
					this.UnarmedAttack( A );
				}
				return null;
			}
			if ( !( this.loc is Tile ) ) {
				return null;
			}
			if ( A is Tile || A.loc is Tile || Misc13.isValid( A.loc ) && A.loc.loc is Tile ) {
				if ( Misc13.isValid( A.Adjacent( this ) ) ) {
					if ( Misc13.isValid( W ) ) {
						resolved = A.attackby( W, this, _params );
						if ( !Misc13.isValid( resolved ) && ( A != null ) && Misc13.isValid( W ) ) {
							W.afterattack( A, this, 1, _params );
						}
					} else {
						if ( A is Mob ) {
							this.changeNext_move( 8 );
						}
						this.UnarmedAttack( A, 1 );
					}
					return null;
				} else if ( Misc13.isValid( W ) ) {
					W.afterattack( A, this, 0, _params );
				} else {
					this.RangedAttack( A, _params );
				}
			}
			return null;
		}

		public void changeNext_move( int num = 0 ) {
			this.next_move = Game.time + ( num + this.next_move_adjust ) * this.next_move_modifier;
			return;
		}

		public void rename_self( string role = "", int allow_numbers = 0 ) {
			dynamic oldname = null;
			dynamic newname = null;
			int loop = 0;
			int safety = 0;
			dynamic M = null;
			Mob A = null;
			if ( allow_numbers == null ) {
				allow_numbers = 0;
			}
			oldname = this.real_name;
			loop = 1;
			safety = 0;
			while (( loop != 0 ) && safety < 5) {
				if ( Misc13.isValid( this.client ) && Misc13.isValid( this.client.prefs.custom_names[role] ) && ( safety == 0 ) ) {
					newname = this.client.prefs.custom_names[role];
				} else {
					dynamic _a = role; // Was a switch-case, sorry for the mess.
					if ( _a=="clown" ) {
						newname = Rand13.pick( GlobalVars.clown_names );
					} else if ( _a=="mime" ) {
						newname = Rand13.pick( GlobalVars.mime_names );
					} else if ( _a=="ai" ) {
						newname = Rand13.pick( GlobalVars.ai_names );
					} else {
						return;
					};
				}
				M = null;
				foreach (dynamic _b in GlobalVars.player_list ) {
					M = _b;
					if ( !( M is Mob_Living ) ) {
						continue;
					}
					if ( M == this ) {
						continue;
					}
					if ( !Misc13.isValid( newname ) || M.real_name == newname ) {
						newname = null;
						loop++;
						break;
					}
				};
				loop--;
				safety++;
			}
			if ( this is Mob_Living_Silicon_Ai ) {
				oldname = null;
			}
			if ( Misc13.isValid( newname ) ) {
				this.fully_replace_character_name( oldname, newname );
				if ( this is Mob_Living_Silicon_Robot ) {
					A = this;
					A.custom_name = newname;
				}
			}
			return;
		}

		public int fully_replace_character_name( dynamic oldname = null, dynamic newname = null ) {
			Mob C = null;
			Mob AI = null;
			dynamic Slave = null;
			Mob R = null;
			dynamic L = null;
			dynamic searching = null;
			int search_id = 0;
			int search_pda = 0;
			dynamic A = null;
			dynamic ID = null;
			dynamic PDA = null;
			dynamic T = null;
			dynamic obj = null;
			if ( !Misc13.isValid( newname ) ) {
				return 0;
			}
			this.real_name = newname;
			this.name = newname;
			if ( this.mind != null ) {
				this.mind.name = newname;
			}
			if ( this is Mob_Living_Carbon ) {
				C = this;
				if ( Misc13.isValid( C.dna ) ) {
					C.dna.real_name = this.real_name;
				}
			}
			if ( this is Mob_Living_Silicon_Ai ) {
				AI = this;
				if ( oldname != this.real_name ) {
					if ( Misc13.isValid( AI.eyeobj ) ) {
						AI.eyeobj.name = "" + newname + " (AI Eye)";
					}
					if ( Misc13.isValid( AI.aiPDA ) ) {
						AI.aiPDA.owner = newname;
						AI.aiPDA.name = newname + " (" + AI.aiPDA.ownjob + ")";
					}
					Slave = null;
					foreach (dynamic _a in AI.connected_robots ) {
						Slave = _a;
						if ( !( Slave is Mob_Living_Silicon_Robot ) ) {
							continue;
						}
						Slave.show_laws();
					};
				}
			}
			if ( this is Mob_Living_Silicon_Robot ) {
				R = this;
				if ( oldname != this.real_name ) {
					R.notify_ai( 3, oldname, newname );
				}
				if ( Misc13.isValid( R.camera ) ) {
					R.camera.c_tag = this.real_name;
				}
			}
			if ( Misc13.isValid( oldname ) ) {
				L = null;
				foreach (dynamic _b in new ByTable(new object [] { GlobalVars.data_core.general, GlobalVars.data_core.medical, GlobalVars.data_core.security, GlobalVars.data_core.locked }) ) {
					L = _b;
					if ( !Misc13.isValid( typeof(ByTable).IsInstanceOfType( L ) ) ) {
						continue;
					}
					R = GlobalFuncs.find_record( "name", oldname, L );
					if ( Misc13.isValid( R ) ) {
						R.fields["name"] = newname;
					}
				};
				searching = this.GetAllContents();
				search_id = 1;
				search_pda = 1;
				A = null;
				foreach (dynamic _c in searching ) {
					A = _c;
					if ( ( search_id != 0 ) && A is Ent_Item_Weapon_Card_Id ) {
						ID = A;
						if ( ID.registered_name == oldname ) {
							ID.registered_name = newname;
							ID.update_label();
							if ( search_pda == 0 ) {
								break;
							}
							search_id = 0;
						}
					} else if ( ( search_pda != 0 ) && A is Ent_Item_Device_Pda ) {
						PDA = A;
						if ( PDA.owner == oldname ) {
							PDA.owner = newname;
							PDA.update_label();
							if ( search_id == 0 ) {
								break;
							}
							search_pda = 0;
						}
					}
				};
				T = null;
				foreach (dynamic _e in GlobalVars.ticker.minds ) {
					T = _e;
					if ( !( T is Mind ) ) {
						continue;
					}
					obj = null;
					foreach (dynamic _d in T.objectives ) {
						obj = _d;
						if ( !( obj is Objective ) ) {
							continue;
						}
						if ( Misc13.isValid( obj.target ) && Misc13.isValid( obj.target.current ) && obj.target.current.real_name == this.name ) {
							obj.update_explanation_text();
						}
					};
				};
			}
			return 1;
		}

		public void AddCamoOverlay( dynamic A = null ) {
			Icon opacity_icon = null;
			dynamic alpha_mask = null;
			int i = 0;
			dynamic I = null;
			opacity_icon = new Icon( A.icon, A.icon_state );
			alpha_mask = GlobalFuncs.getIconMask( this );
			opacity_icon.AddAlphaMask( alpha_mask );
			opacity_icon.ChangeOpacity( 0.4000000059604645 );
			i = 0;
			i = 0;
			while (i < 5) {
				I = new ByTable().set( "layer", this.layer + 0.800000011920929 ).set( "icon_state", A.icon_state ).set( "icon", opacity_icon ).applyCtor( typeof(Image) );
				dynamic _a = i; // Was a switch-case, sorry for the mess.
				if ( _a==1 ) {
					I.pixel_x--;
				} else if ( _a==2 ) {
					I.pixel_x++;
				} else if ( _a==3 ) {
					I.pixel_y--;
				} else if ( _a==4 ) {
					I.pixel_y++;
				};
				this.overlays += I;
				i++;
			}
			return;
		}

	}

}