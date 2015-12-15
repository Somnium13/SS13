using System;
using Game13;

namespace Som13 {
	partial class BaseStatic : Base13 {

		public int smooth = 0;
		public dynamic top_left_corner = null;
		public dynamic top_right_corner = null;
		public dynamic bottom_left_corner = null;
		public dynamic bottom_right_corner = null;
		public int can_be_unanchored = 0;
		public dynamic canSmoothWith = null;
		public ByTable suit_fibers = null;
		public int level = 2;
		public int flags = 0;
		public ByTable fingerprints = null;
		public ByTable fingerprintshidden = null;
		public dynamic fingerprintslast = null;
		public ByTable blood_DNA = null;
		public Reagents reagents = null;
		public dynamic hud_list = null;
		public dynamic hud_possible = null;
		public int explosion_block = 0;
		public LightSource light = null;

		public BaseStatic( dynamic _loc = null ) {
			this.loc = _loc;
			if ( ( GlobalVars._preloader != null ) && this.type == GlobalVars._preloader.target_path ) {
				GlobalVars._preloader.load( this );
			}
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
		}

		public dynamic Stat(  ) {
			dynamic _default = null;
			_default = base.Stat();
			Thread13.sleep( 1 );
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
		}

		public int Click( dynamic location = null, dynamic control = null, dynamic _params = null ) {
			Misc13.thread_user.ClickOn( this, _params );
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
		}

		public void create_reagents( dynamic max_vol = null ) {
			if ( this.reagents != null ) {
				GlobalFuncs.qdel( this.reagents );
			}
			this.reagents = new Reagents( max_vol );
			this.reagents.my_atom = this;
		}

		public dynamic ninjadrain_act(  ) {
			return "INVALID";
		}

		public void swarmer_act( dynamic S = null ) {
			S.DisIntegrate( this );
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
		}

		public dynamic update_pipe_vision( dynamic new_loc = null ) {
			if ( new_loc == null ) {
				new_loc = null;
			}
			return null;
		}

		public void audible_message( dynamic message = null, dynamic deaf_message = null, dynamic hearing_distance = null ) {
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
		}

		public void visible_message( dynamic message = null, dynamic blind_message = null ) {
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
		}

		public void prepare_huds(  ) {
			dynamic hud = null;
			hud = null;
			foreach (dynamic _a in this.hud_possible ) {
				hud = _a;
				this.hud_list[hud] = new Image( new ByRsc(229), this, "" );
			};
		}

		public dynamic get_light_range( dynamic radius = null ) {
			return Misc13.min( radius, 8 );
		}

		public void UpdateAffectingLights(  ) {
			
		}

		public int SetOpacity( bool new_opacity = false ) {
			if ( new_opacity == null ) {
				new_opacity = !Misc13.isValid( this.opacity );
			} else if ( this.opacity == new_opacity ) {
				return 0;
			}
			this.opacity = new_opacity;
			this.UpdateAffectingLights();
			return 1;
		}

		public void AddLuminosity( dynamic delta_luminosity = null ) {
			if ( this.light != null ) {
				this.SetLuminosity( this.light.radius + delta_luminosity );
			} else {
				this.SetLuminosity( delta_luminosity );
			}
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
		}

		public void transfer_fingerprints_to( dynamic A = null ) {
			if ( !Misc13.isValid( ByTable.IsInstanceOfType( A.fingerprints ) ) ) {
				A.fingerprints = new ByTable();
			}
			if ( !Misc13.isValid( ByTable.IsInstanceOfType( A.fingerprintshidden ) ) ) {
				A.fingerprintshidden = new ByTable();
			}
			if ( !Misc13.isValid( ByTable.IsInstanceOfType( this.fingerprints ) ) ) {
				this.fingerprints = new ByTable();
			}
			if ( !Misc13.isValid( ByTable.IsInstanceOfType( this.fingerprintshidden ) ) ) {
				this.fingerprintshidden = new ByTable();
			}
			if ( this.fingerprints != null ) {
				A.fingerprints |= this.fingerprints.Copy();
			}
			if ( this.fingerprintshidden != null ) {
				A.fingerprintshidden |= this.fingerprintshidden.Copy();
			}
			A.fingerprintslast = this.fingerprintslast;
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
				if ( this.fingerprintshidden == null ) {
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

		public int add_hiddenprint( dynamic M = null ) {
			dynamic H = null;
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
			string fibertext = null;
			double item_multiplier = 0;
			if ( Misc13.isValid( M.gloves ) && M.gloves is Ent_Item_Clothing ) {
				G = M.gloves;
				if ( G.transfer_blood > 1 ) {
					if ( this.add_blood( G.bloody_hands_mob ) != 0 ) {
						G.transfer_blood--;
					}
				}
			} else if ( M.bloody_hands > 1 ) {
				if ( this.add_blood( M.bloody_hands_mob ) != 0 ) {
					M.bloody_hands--;
				}
			}
			if ( this.suit_fibers == null ) {
				this.suit_fibers = new ByTable();
			}
			item_multiplier = this is Ent_Item ? 1.2000000476837158 : 1;
			if ( Misc13.isValid( M.wear_suit ) ) {
				fibertext = new Txt( "Material from " ).a( M.wear_suit ).item().str( "." );
				if ( Misc13.isValid( Rand.chance( item_multiplier * 10 ) ) && !Misc13.isValid( this.suit_fibers.HasValue( fibertext ) ) ) {
					this.suit_fibers += fibertext;
				}
				if ( !Misc13.isValid( M.wear_suit.body_parts_covered & 2 ) ) {
					if ( Misc13.isValid( M.w_uniform ) ) {
						fibertext = new Txt( "Fibers from " ).a( M.w_uniform ).item().str( "." );
						if ( Misc13.isValid( Rand.chance( item_multiplier * 12 ) ) && !Misc13.isValid( this.suit_fibers.HasValue( fibertext ) ) ) {
							this.suit_fibers += fibertext;
						}
					}
				}
				if ( !Misc13.isValid( M.wear_suit.body_parts_covered & 1536 ) ) {
					if ( Misc13.isValid( M.gloves ) ) {
						fibertext = "Material from a pair of " + M.gloves.name + ".";
						if ( Misc13.isValid( Rand.chance( item_multiplier * 20 ) ) && !Misc13.isValid( this.suit_fibers.HasValue( fibertext ) ) ) {
							this.suit_fibers += fibertext;
						}
					}
				}
			} else if ( Misc13.isValid( M.w_uniform ) ) {
				fibertext = new Txt( "Fibers from " ).a( M.w_uniform ).item().str( "." );
				if ( Misc13.isValid( Rand.chance( item_multiplier * 15 ) ) && !Misc13.isValid( this.suit_fibers.HasValue( fibertext ) ) ) {
					this.suit_fibers += fibertext;
				}
				if ( Misc13.isValid( M.gloves ) ) {
					fibertext = "Material from a pair of " + M.gloves.name + ".";
					if ( Misc13.isValid( Rand.chance( item_multiplier * 20 ) ) && !Misc13.isValid( this.suit_fibers.HasValue( fibertext ) ) ) {
						this.suit_fibers += "Material from a pair of " + M.gloves.name + ".";
					}
				}
			} else if ( Misc13.isValid( M.gloves ) ) {
				fibertext = "Material from a pair of " + M.gloves.name + ".";
				if ( Misc13.isValid( Rand.chance( item_multiplier * 20 ) ) && !Misc13.isValid( this.suit_fibers.HasValue( fibertext ) ) ) {
					this.suit_fibers += "Material from a pair of " + M.gloves.name + ".";
				}
			}
		}

		public void investigate_log( dynamic message = null, dynamic subject = null ) {
			File F = null;
			if ( !Misc13.isValid( message ) ) {
				return;
			}
			F = GlobalFuncs.investigate_subject2file( subject );
			if ( F == null ) {
				return;
			}
			F.write( new Txt( "<small>" ).item( GlobalFuncs.time_stamp() ).str( " " ).Ref( this ).str( " (" ).item( this.x ).str( "," ).item( this.y ).str( "," ).item( this.z ).str( ")</small> || " ).item( this ).str( " " ).item( message ).str( "<br>" ) );
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

		public int mech_melee_attack( dynamic M = null ) {
			return 0;
		}

		public Signal telecomms_process(  ) {
			Signal signal = null;
			dynamic pos = null;
			dynamic R = null;
			signal = new Signal();
			signal.transmission_method = 2;
			pos = GlobalFuncs.get_turf( this );
			signal.data = new ByTable().set( "level", pos.z ).set( "done", 0 ).set( "reject", 0 ).set( "type", 4 ).set( "traffic", 0 ).set( "compression", Rand.Int( 45, 50 ) ).set( "message", "TEST" ).set( "slow", 0 );
			signal.frequency = 1459;
			R = null;
			foreach (dynamic _a in GlobalVars.telecomms_list ) {
				R = _a;
				if ( !( R is Ent_Machinery_Telecomms_Receiver ) ) {
					continue;
				}
				R.receive_signal( signal );
			};
			Thread13.sleep( Rand.Int( 10, 25 ) );
			return signal;
		}

		public dynamic test_telecomms(  ) {
			Signal signal = null;
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
		}

		public void playsound_local( dynamic turf_source = null, dynamic soundin = null, dynamic vol = null, dynamic vary = null, dynamic frequency = null, dynamic falloff = null, int surround = 0 ) {
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
			if ( Misc13.isValid( vary ) ) {
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
		}

		public void handle_atom_del( dynamic A = null ) {
			
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
		}

		public dynamic get_global_map_pos(  ) {
			int cur_x = 0;
			dynamic cur_y = null;
			dynamic y_arr = null;
			if ( !Misc13.isValid( ByTable.IsInstanceOfType( GlobalVars.global_map ) ) || ( GlobalFuncs.isemptylist( GlobalVars.global_map ) != 0 ) ) {
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
		}

		public int clean_blood(  ) {
			if ( Misc13.isValid( ByTable.IsInstanceOfType( this.blood_DNA ) ) ) {
				this.blood_DNA = null;
				return 1;
			}
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
					_this.icon_state = "vomittox_" + Rand.pick(new object [] { 1, 4 });
				}
			}
		}

		public int rejects_blood(  ) {
			return 0;
		}

		public int add_blood( dynamic M = null ) {
			dynamic H = null;
			if ( !Misc13.isValid( M ) || !Misc13.isValid( M.has_dna() ) || ( this.rejects_blood() != 0 ) ) {
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
			if ( !Misc13.isValid( ByTable.IsInstanceOfType( this.blood_DNA ) ) ) {
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
			if ( Misc13.isValid( this.density ) && ( GlobalFuncs.has_gravity( AM ) == 0 ) ) {
				Thread13.schedule( 2, (Thread13.Closure)(() => {
					Misc13.step( AM, Misc13.turn( AM.dir, 180 ) );
					return 0;
				}));
			}
		}

		public int fire_act(  ) {
			return 0;
		}

		public int blob_act(  ) {
			return 0;
		}

		public int ex_act( dynamic severity = null, dynamic target = null ) {
			this.contents_explosion( severity, target );
		}

		public void contents_explosion( dynamic severity = null, dynamic target = null ) {
			dynamic A = null;
			A = null;
			foreach (dynamic _a in this.contents ) {
				A = _a;
				if ( !( A is BaseStatic ) ) {
					continue;
				}
				A.ex_act( severity, target );
			};
		}

		public int relaymove(  ) {
			return 0;
		}

		public int examine( dynamic user = null ) {
			string f_name = null;
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
			if ( ( this.reagents != null ) && ( this.is_open_container() != 0 ) ) {
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
		}

		public Beam Beam( dynamic BeamTarget = null, string icon_state = null, ByRsc icon = null, int time = 0, int maxdistance = 0, Type beam_type = null ) {
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
				return null;
			}));
			return newbeam;
		}

		public ByTable search_contents_for( dynamic path = null, dynamic filter_path = null ) {
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
			int _default = null;
			_default = P.on_hit( this, 0, def_zone );
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

		public int attackby( dynamic W = null, dynamic user = null, dynamic _params = null ) {
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
		}

		public void BorgShiftClick( dynamic user = null ) {
			this.ShiftClick( user );
		}

		public void BorgCtrlShiftClick( dynamic user = null ) {
			this.CtrlShiftClick( user );
		}

		public void CtrlShiftClick( dynamic user = null ) {
			return;
		}

		public int AltClick( dynamic user = null ) {
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

		public void CtrlClick( dynamic user = null ) {
			return;
		}

		public void ShiftClick( dynamic user = null ) {
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
			while (processing_list.len) {
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
			dynamic m120 = null;
			dynamic m240 = null;
			dynamic m360 = null;
			if ( speed == null ) {
				speed = 10;
			}
			if ( loops == null ) {
				loops = -1;
			}
			m120 = Misc13.call( GlobalVars.undefined, this.transform );
			m120.Turn( 120 );
			m240 = Misc13.call( GlobalVars.undefined, this.transform );
			m240.Turn( 240 );
			m360 = Misc13.call( GlobalVars.undefined, this.transform );
			speed /= 3;
			Misc13.call( GlobalVars.undefined, new ByTable().set( 4, loops ).set( "time", speed ).set( "transform", m120 ).set( 1, this ) );
			Misc13.call( GlobalVars.undefined, new ByTable().set( "time", speed ).set( "transform", m240 ) );
			Misc13.call( GlobalVars.undefined, new ByTable().set( "time", speed ).set( "transform", m360 ) );
		}

		public int DrawPixelOn( dynamic colour = null, dynamic drawX = null, dynamic drawY = null ) {
			Icon I = null;
			int J = 0;
			I = new Icon( this.icon );
			J = GlobalFuncs.DrawPixel( I, colour, drawX, drawY );
			if ( J != 0 ) {
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
		}

	}

	partial class Image : Base13 {

		public void ResetVars(  ) {
			base.ResetVars();
			this.loc = null;
		}

	}

}