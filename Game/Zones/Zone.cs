// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Zone : Base_Zone {

		public bool global_uid = false;
		public int uid = 0;
		public ByTable ambientsounds = new ByTable(new object [] { 
											"sound/ambience/ambigen1.ogg", 
											"sound/ambience/ambigen3.ogg", 
											"sound/ambience/ambigen4.ogg", 
											"sound/ambience/ambigen5.ogg", 
											"sound/ambience/ambigen6.ogg", 
											"sound/ambience/ambigen7.ogg", 
											"sound/ambience/ambigen8.ogg", 
											"sound/ambience/ambigen9.ogg", 
											"sound/ambience/ambigen10.ogg", 
											"sound/ambience/ambigen11.ogg", 
											"sound/ambience/ambigen12.ogg", 
											"sound/ambience/ambigen14.ogg"
										 });
		public string map_name = null;
		public bool valid_territory = true;
		public bool blob_allowed = true;
		public bool eject = false;
		public bool fire = false;
		public bool atmos = true;
		public int atmosalm = 0;
		public bool poweralm = true;
		public bool party = false;
		public bool lightswitch = true;
		public bool requires_power = true;
		public bool always_unpowered = false;
		public bool power_equip = true;
		public bool power_light = true;
		public bool power_environ = true;
		public string music = null;
		public double used_equip = 0;
		public double used_light = 0;
		public double used_environ = 0;
		public dynamic static_equip = null;
		public double static_light = 0;
		public dynamic static_environ = null;
		public bool has_gravity = false;
		public bool safe = false;
		public dynamic no_air = null;
		public Zone master = null;
		public ByTable related = null;
		public ByTable air_vent_names = new ByTable();
		public ByTable air_scrub_names = new ByTable();
		public ByTable air_vent_info = new ByTable();
		public ByTable air_scrub_info = new ByTable();
		public int lighting_use_dynamic = 1;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.invisibility = 20;
			this.icon = "icons/turf/areas.dmi";
			this.icon_state = "unknown";
			this.layer = 10;
		}

		// Function from file: areas.dm
		public Zone ( dynamic loc = null ) : base( (object)(loc) ) {
			this.icon_state = "";
			this.layer = 10;
			this.master = this;
			this.uid = ++GlobalVars.global_uid;
			this.related = new ByTable(new object [] { this });
			this.map_name = this.name;

			if ( this.requires_power ) {
				this.luminosity = 0;
			} else {
				this.power_light = true;
				this.power_equip = true;
				this.power_environ = true;

				if ( this.lighting_use_dynamic != 2 ) {
					this.lighting_use_dynamic = 0;
				}
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.power_change();
			this.blend_mode = GlobalVars.BLEND_MULTIPLY;
			return;
		}

		// Function from file: lighting_system.dm
		public override void SetLuminosity( dynamic new_luminosity = null, int? new_cap = null ) {
			this.luminosity = !( !Lang13.Bool( new_luminosity ) ) ?1:0;
			return;
		}

		// Function from file: areas.dm
		public override dynamic Entered( Ent_Dynamic Obj = null, Ent_Static oldloc = null ) {
			Ent_Dynamic L = null;
			dynamic sound = null;

			
			if ( !( Obj is Mob_Living ) ) {
				return null;
			}
			L = Obj;

			if ( !Lang13.Bool( ((dynamic)L).ckey ) ) {
				return null;
			}

			if ( Lang13.Bool( ((dynamic)L).client ) && !((dynamic)L).client.ambience_playing && Lang13.Bool( ((dynamic)L).client.prefs.toggles & 256 ) ) {
				((dynamic)L).client.ambience_playing = true;
				((dynamic)L).WriteMsg( new Sound( "sound/ambience/shipambience.ogg", true, false, 2, 35 ) );
			}

			if ( !( Lang13.Bool( ((dynamic)L).client ) && Lang13.Bool( ((dynamic)L).client.prefs.toggles & 4 ) ) ) {
				return null;
			}

			if ( Rand13.PercentChance( 35 ) ) {
				sound = Rand13.PickFromTable( this.ambientsounds );

				if ( !((dynamic)L).client.played ) {
					((dynamic)L).WriteMsg( new Sound( sound, false, false, 1, 25 ) );
					((dynamic)L).client.played = true;
					Task13.Schedule( 600, (Task13.Closure)(() => {
						
						if ( L != null && Lang13.Bool( ((dynamic)L).client ) ) {
							((dynamic)L).client.played = false;
						}
						return;
					}));
				}
			}
			return null;
		}

		// Function from file: adjacent.dm
		public override bool Adjacent( dynamic neighbor = null, dynamic recurse = null ) {
			Task13.Crash( "Call to /area/Adjacent(), unimplemented proc" );
			return false;
		}

		// Function from file: power.dm
		public Obj_Machinery_Power_Apc get_apc(  ) {
			Obj_Machinery_Power_Apc APC = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.apcs_list, typeof(Obj_Machinery_Power_Apc) )) {
				APC = _a;
				

				if ( APC.area == this ) {
					return APC;
				}
			}
			return null;
		}

		// Function from file: lighting_system.dm
		public void SetDynamicLighting(  ) {
			if ( this.lighting_use_dynamic == 0 ) {
				this.lighting_use_dynamic = 1;
			}
			this.luminosity = 0;

			foreach (Tile T in Lang13.Enumerate( this.contents, typeof(Tile) )) {
				
				T.init_lighting();
				T.update_lumcount( 0 );
			}
			return;
		}

		// Function from file: area_copy.dm
		public dynamic copy_contents_to( dynamic A = null, bool? platingRequired = null, bool? nerf_weapons = null ) {
			platingRequired = platingRequired ?? false;
			nerf_weapons = nerf_weapons ?? false;

			ByTable turfs_src = null;
			ByTable turfs_trg = null;
			int src_min_x = 0;
			int src_min_y = 0;
			ByTable refined_src = null;
			dynamic T = null;
			dynamic T2 = null;
			int trg_min_x = 0;
			int trg_min_y = 0;
			ByTable refined_trg = null;
			dynamic T3 = null;
			dynamic T4 = null;
			ByTable toupdate = null;
			ByTable copiedobjs = null;
			Tile_Simulated T5 = null;
			dynamic coordstring = null;
			dynamic B = null;
			int old_dir1 = 0;
			string old_icon_state1 = null;
			string old_icon1 = null;
			dynamic X = null;
			Obj O = null;
			dynamic O2 = null;
			dynamic M = null;
			dynamic SM = null;
			dynamic V = null;
			Tile_Simulated T1 = null;

			
			if ( !Lang13.Bool( A ) || !( this != null ) ) {
				return 0;
			}
			turfs_src = GlobalFuncs.get_area_turfs( this.type );
			turfs_trg = GlobalFuncs.get_area_turfs( A.type );
			src_min_x = 99999;
			src_min_y = 99999;
			refined_src = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( turfs_src )) {
				T = _a;
				
				src_min_x = Num13.MinInt( src_min_x, Convert.ToInt32( T.x ) );
				src_min_y = Num13.MinInt( src_min_y, Convert.ToInt32( T.y ) );
			}

			foreach (dynamic _b in Lang13.Enumerate( turfs_src )) {
				T2 = _b;
				
				refined_src[T2] = "" + ( T2.x - src_min_x ) + "." + ( T2.y - src_min_y );
			}
			trg_min_x = 99999;
			trg_min_y = 99999;
			refined_trg = new ByTable();

			foreach (dynamic _c in Lang13.Enumerate( turfs_trg )) {
				T3 = _c;
				
				trg_min_x = Num13.MinInt( trg_min_x, Convert.ToInt32( T3.x ) );
				trg_min_y = Num13.MinInt( trg_min_y, Convert.ToInt32( T3.y ) );
			}

			foreach (dynamic _d in Lang13.Enumerate( turfs_trg )) {
				T4 = _d;
				
				refined_trg["" + ( T4.x - trg_min_x ) + "." + ( T4.y - trg_min_y )] = T4;
			}
			toupdate = new ByTable();
			copiedobjs = new ByTable();

			foreach (dynamic _h in Lang13.Enumerate( refined_src, typeof(Tile_Simulated) )) {
				T5 = _h;
				
				coordstring = refined_src[T5];
				B = refined_trg[coordstring];

				if ( !( B is Tile ) ) {
					continue;
				}

				if ( platingRequired == true ) {
					
					if ( B is Tile_Space ) {
						continue;
					}
				}
				old_dir1 = T5.dir;
				old_icon_state1 = T5.icon_state;
				old_icon1 = T5.icon;
				X = Lang13.Call( T5.type, B );
				X.dir = old_dir1;
				X.icon = old_icon1;
				X.icon_state = old_icon_state1;

				foreach (dynamic _e in Lang13.Enumerate( T5, typeof(Obj) )) {
					O = _e;
					
					O2 = GlobalFuncs.DuplicateObject( O, true, null, X, nerf_weapons );

					if ( !Lang13.Bool( O2 ) ) {
						continue;
					}
					copiedobjs.Add( ((Ent_Static)O2).GetAllContents() );
				}

				foreach (dynamic _f in Lang13.Enumerate( T5 )) {
					M = _f;
					

					if ( M is Mob_Camera ) {
						continue;
					}
					SM = GlobalFuncs.DuplicateObject( M, true, null, X );
					copiedobjs.Add( ((Ent_Static)SM).GetAllContents() );
				}

				foreach (dynamic _g in Lang13.Enumerate( T5.vars - GlobalVars.forbidden_vars )) {
					V = _g;
					

					if ( V == "air" ) {
						X.air.copy_from( T5.air );
						continue;
					}
					X.vars[V] = T5.vars[V];
				}
				toupdate.Add( X );
			}

			if ( toupdate.len != 0 ) {
				
				foreach (dynamic _i in Lang13.Enumerate( toupdate, typeof(Tile_Simulated) )) {
					T1 = _i;
					
					T1.CalculateAdjacentTurfs();
					GlobalVars.SSair.add_to_active( T1, true );
				}
			}
			return copiedobjs;
		}

		// Function from file: areas.dm
		public void setup( string a_name = null ) {
			this.name = a_name;
			this.power_equip = false;
			this.power_light = false;
			this.power_environ = false;
			this.always_unpowered = false;
			this.valid_territory = false;
			this.addSorted();
			return;
		}

		// Function from file: areas.dm
		public virtual dynamic use_power( dynamic amount = null, dynamic chan = null ) {
			
			dynamic _a = chan; // Was a switch-case, sorry for the mess.
			if ( _a==1 ) {
				this.master.used_equip += Convert.ToDouble( amount );
			} else if ( _a==2 ) {
				this.master.used_light += Convert.ToDouble( amount );
			} else if ( _a==3 ) {
				this.master.used_environ += Convert.ToDouble( amount );
			}
			return null;
		}

		// Function from file: areas.dm
		public void clear_usage(  ) {
			this.master.used_equip = 0;
			this.master.used_light = 0;
			this.master.used_environ = 0;
			return;
		}

		// Function from file: areas.dm
		public virtual dynamic addStaticPower( dynamic value = null, dynamic powerchannel = null ) {
			
			dynamic _a = powerchannel; // Was a switch-case, sorry for the mess.
			if ( _a==5 ) {
				this.static_equip += value;
			} else if ( _a==6 ) {
				this.static_light += Convert.ToDouble( value );
			} else if ( _a==7 ) {
				this.static_environ += value;
			}
			return null;
		}

		// Function from file: areas.dm
		public virtual dynamic usage( int chan = 0 ) {
			double used = 0;

			used = 0;

			switch ((int)( chan )) {
				case 2:
					used += this.master.used_light;
					break;
				case 1:
					used += this.master.used_equip;
					break;
				case 3:
					used += this.master.used_environ;
					break;
				case 4:
					used += this.master.used_light + this.master.used_equip + this.master.used_environ;
					break;
				case 5:
					used += Convert.ToDouble( this.master.static_equip );
					break;
				case 6:
					used += this.master.static_light;
					break;
				case 7:
					used += Convert.ToDouble( this.master.static_environ );
					break;
			}
			return used;
		}

		// Function from file: areas.dm
		public void power_change(  ) {
			dynamic RA = null;
			Obj_Machinery M = null;

			
			foreach (dynamic _b in Lang13.Enumerate( this.related )) {
				RA = _b;
				

				foreach (dynamic _a in Lang13.Enumerate( RA, typeof(Obj_Machinery) )) {
					M = _a;
					
					M.power_change();
				}
				RA.updateicon();
			}
			return;
		}

		// Function from file: areas.dm
		public virtual dynamic powered( dynamic chan = null ) {
			
			if ( !this.master.requires_power ) {
				return 1;
			}

			if ( this.master.always_unpowered ) {
				return 0;
			}

			dynamic _a = chan; // Was a switch-case, sorry for the mess.
			if ( _a==1 ) {
				return this.master.power_equip;
			} else if ( _a==2 ) {
				return this.master.power_light;
			} else if ( _a==3 ) {
				return this.master.power_environ;
			}
			return 0;
		}

		// Function from file: areas.dm
		public virtual void updateicon(  ) {
			
			if ( ( this.fire || this.eject || this.party ) && ( !this.requires_power || this.power_environ ) ) {
				
				if ( this.fire && !this.eject && !this.party ) {
					this.icon_state = "blue";
				} else if ( !this.fire && this.eject && !this.party ) {
					this.icon_state = "red";
				} else if ( this.party && !this.fire && !this.eject ) {
					this.icon_state = "party";
				} else {
					this.icon_state = "blue-red";
				}
				this.invisibility = 20;
			} else {
				this.icon_state = null;
				this.invisibility = 100;
			}
			return;
		}

		// Function from file: areas.dm
		public void partyreset(  ) {
			Obj_Machinery_Door_Firedoor D = null;

			
			if ( this.party ) {
				this.party = false;
				this.mouse_opacity = 0;
				this.updateicon();

				foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj_Machinery_Door_Firedoor) )) {
					D = _a;
					

					if ( !D.blocked ) {
						
						if ( D.operating ) {
							D.nextstate = 1;
						} else if ( D.density ) {
							Task13.Schedule( 0, (Task13.Closure)(() => {
								D.open();
								return;
							}));
						}
					}
				}
			}
			return;
		}

		// Function from file: areas.dm
		public void partyalert(  ) {
			
			if ( this.name == "Space" ) {
				return;
			}

			if ( !this.party ) {
				this.party = true;
				this.updateicon();
				this.mouse_opacity = 0;
			}
			return;
		}

		// Function from file: areas.dm
		public void readyreset(  ) {
			
			if ( this.eject ) {
				this.eject = false;
				this.updateicon();
			}
			return;
		}

		// Function from file: areas.dm
		public void readyalert(  ) {
			
			if ( this.name == "Space" ) {
				return;
			}

			if ( !this.eject ) {
				this.eject = true;
				this.updateicon();
			}
			return;
		}

		// Function from file: areas.dm
		public void set_fire_alarm_effect(  ) {
			this.fire = true;
			this.updateicon();
			this.mouse_opacity = 0;
			return;
		}

		// Function from file: areas.dm
		public void burglaralert( Obj trigger = null ) {
			ByTable cameras = null;
			dynamic RA = null;
			Obj_Machinery_Door_Airlock DOOR = null;
			Obj_Machinery_Camera C = null;
			Mob_Living_Silicon SILICON = null;

			
			if ( this.always_unpowered ) {
				return;
			}
			cameras = new ByTable();

			foreach (dynamic _c in Lang13.Enumerate( this.related )) {
				RA = _c;
				
				((Zone)RA).set_fire_alarm_effect();

				foreach (dynamic _a in Lang13.Enumerate( RA, typeof(Obj_Machinery_Door_Airlock) )) {
					DOOR = _a;
					
					Task13.Schedule( 0, (Task13.Closure)(() => {
						DOOR.close();

						if ( DOOR.density ) {
							DOOR.locked = true;
							DOOR.update_icon();
						}
						return;
					}));
				}

				foreach (dynamic _b in Lang13.Enumerate( RA, typeof(Obj_Machinery_Camera) )) {
					C = _b;
					
					cameras.Add( C );
				}
			}

			foreach (dynamic _d in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon) )) {
				SILICON = _d;
				

				if ( SILICON.triggerAlarm( "Burglar", this, cameras, trigger ) ) {
					Task13.Schedule( 600, (Task13.Closure)(() => {
						SILICON.cancelAlarm( "Burglar", this, trigger );
						return;
					}));
				}
			}
			return;
		}

		// Function from file: areas.dm
		public void firereset( Obj_Machinery source = null ) {
			dynamic RA = null;
			Obj_Machinery_Door_Firedoor D = null;
			Obj_Machinery_Firealarm F = null;
			Mob_Living_Silicon aiPlayer = null;
			Obj_Machinery_Computer_StationAlert a = null;
			Mob_Living_SimpleAnimal_Drone D2 = null;

			
			foreach (dynamic _c in Lang13.Enumerate( this.related )) {
				RA = _c;
				

				if ( RA.fire ) {
					RA.fire = false;
					RA.mouse_opacity = 0;
					((Zone)RA).updateicon();

					foreach (dynamic _a in Lang13.Enumerate( RA, typeof(Obj_Machinery_Door_Firedoor) )) {
						D = _a;
						

						if ( !D.blocked ) {
							
							if ( D.operating ) {
								D.nextstate = 1;
							} else if ( D.density ) {
								Task13.Schedule( 0, (Task13.Closure)(() => {
									D.open();
									return;
								}));
							}
						}
					}

					foreach (dynamic _b in Lang13.Enumerate( RA, typeof(Obj_Machinery_Firealarm) )) {
						F = _b;
						
						F.update_icon();
					}
				}
			}

			foreach (dynamic _d in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon) )) {
				aiPlayer = _d;
				
				aiPlayer.cancelAlarm( "Fire", this, source );
			}

			foreach (dynamic _e in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Computer_StationAlert) )) {
				a = _e;
				
				a.cancelAlarm( "Fire", this, source );
			}

			foreach (dynamic _f in Lang13.Enumerate( GlobalVars.mob_list, typeof(Mob_Living_SimpleAnimal_Drone) )) {
				D2 = _f;
				
				D2.cancelAlarm( "Fire", this, source );
			}
			return;
		}

		// Function from file: areas.dm
		public void firealert( Obj_Machinery source = null ) {
			ByTable cameras = null;
			dynamic RA = null;
			Obj_Machinery_Door_Firedoor D = null;
			Obj_Machinery_Firealarm F = null;
			Obj_Machinery_Camera C = null;
			Obj_Machinery_Computer_StationAlert a = null;
			Mob_Living_Silicon aiPlayer = null;
			Mob_Living_SimpleAnimal_Drone D2 = null;

			
			if ( this.always_unpowered ) {
				return;
			}
			cameras = new ByTable();

			foreach (dynamic _d in Lang13.Enumerate( this.related )) {
				RA = _d;
				

				if ( !RA.fire ) {
					((Zone)RA).set_fire_alarm_effect();

					foreach (dynamic _a in Lang13.Enumerate( RA, typeof(Obj_Machinery_Door_Firedoor) )) {
						D = _a;
						

						if ( !D.blocked ) {
							
							if ( D.operating ) {
								D.nextstate = GlobalVars.CLOSED;
							} else if ( !D.density ) {
								Task13.Schedule( 0, (Task13.Closure)(() => {
									D.close();
									return;
								}));
							}
						}
					}

					foreach (dynamic _b in Lang13.Enumerate( RA, typeof(Obj_Machinery_Firealarm) )) {
						F = _b;
						
						F.update_icon();
					}
				}

				foreach (dynamic _c in Lang13.Enumerate( RA, typeof(Obj_Machinery_Camera) )) {
					C = _c;
					
					cameras.Add( C );
				}
			}

			foreach (dynamic _e in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Computer_StationAlert) )) {
				a = _e;
				
				a.triggerAlarm( "Fire", this, cameras, source );
			}

			foreach (dynamic _f in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon) )) {
				aiPlayer = _f;
				
				aiPlayer.triggerAlarm( "Fire", this, cameras, source );
			}

			foreach (dynamic _g in Lang13.Enumerate( GlobalVars.mob_list, typeof(Mob_Living_SimpleAnimal_Drone) )) {
				D2 = _g;
				
				D2.triggerAlarm( "Fire", this, cameras, source );
			}
			return;
		}

		// Function from file: areas.dm
		public bool atmosalert( int danger_level = 0, Obj source = null ) {
			ByTable cameras = null;
			dynamic RA = null;
			Obj_Machinery_Camera C = null;
			Mob_Living_Silicon aiPlayer = null;
			Obj_Machinery_Computer_StationAlert a = null;
			Mob_Living_SimpleAnimal_Drone D = null;
			Mob_Living_Silicon aiPlayer2 = null;
			Obj_Machinery_Computer_StationAlert a2 = null;
			Mob_Living_SimpleAnimal_Drone D2 = null;

			
			if ( danger_level != this.atmosalm ) {
				
				if ( danger_level == 2 ) {
					cameras = new ByTable();

					foreach (dynamic _b in Lang13.Enumerate( this.related )) {
						RA = _b;
						

						foreach (dynamic _a in Lang13.Enumerate( RA, typeof(Obj_Machinery_Camera) )) {
							C = _a;
							
							cameras.Add( C );
						}
					}

					foreach (dynamic _c in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon) )) {
						aiPlayer = _c;
						
						aiPlayer.triggerAlarm( "Atmosphere", this, cameras, source );
					}

					foreach (dynamic _d in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Computer_StationAlert) )) {
						a = _d;
						
						a.triggerAlarm( "Atmosphere", this, cameras, source );
					}

					foreach (dynamic _e in Lang13.Enumerate( GlobalVars.mob_list, typeof(Mob_Living_SimpleAnimal_Drone) )) {
						D = _e;
						
						D.triggerAlarm( "Atmosphere", this, cameras, source );
					}
				} else if ( this.atmosalm == 2 ) {
					
					foreach (dynamic _f in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon) )) {
						aiPlayer2 = _f;
						
						aiPlayer2.cancelAlarm( "Atmosphere", this, source );
					}

					foreach (dynamic _g in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Computer_StationAlert) )) {
						a2 = _g;
						
						a2.cancelAlarm( "Atmosphere", this, source );
					}

					foreach (dynamic _h in Lang13.Enumerate( GlobalVars.mob_list, typeof(Mob_Living_SimpleAnimal_Drone) )) {
						D2 = _h;
						
						D2.cancelAlarm( "Atmosphere", this, source );
					}
				}
				this.atmosalm = danger_level;
				return true;
			}
			return false;
		}

		// Function from file: areas.dm
		public virtual void poweralert( bool state = false, Obj_Machinery_Power_Apc source = null ) {
			ByTable cameras = null;
			Obj_Machinery_Camera C = null;
			Mob_Living_Silicon aiPlayer = null;
			Obj_Machinery_Computer_StationAlert a = null;
			Mob_Living_SimpleAnimal_Drone D = null;

			
			if ( state != this.poweralm ) {
				this.poweralm = state;

				if ( source is Obj ) {
					cameras = new ByTable();

					foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj_Machinery_Camera) )) {
						C = _a;
						
						cameras.Add( C );
					}

					foreach (dynamic _b in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon) )) {
						aiPlayer = _b;
						

						if ( state ) {
							aiPlayer.cancelAlarm( "Power", this, source );
						} else {
							aiPlayer.triggerAlarm( "Power", this, cameras, source );
						}
					}

					foreach (dynamic _c in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Computer_StationAlert) )) {
						a = _c;
						

						if ( state ) {
							a.cancelAlarm( "Power", this, source );
						} else {
							a.triggerAlarm( "Power", this, cameras, source );
						}
					}

					foreach (dynamic _d in Lang13.Enumerate( GlobalVars.mob_list, typeof(Mob_Living_SimpleAnimal_Drone) )) {
						D = _d;
						

						if ( state ) {
							D.cancelAlarm( "Power", this, source );
						} else {
							D.triggerAlarm( "Power", this, cameras, source );
						}
					}
				}
			}
			return;
		}

		// Function from file: unsorted.dm
		public void addSorted(  ) {
			GlobalVars.sortedAreas.Add( this );
			GlobalFuncs.sortTim( GlobalVars.sortedAreas, typeof(GlobalFuncs).GetMethod( "cmp_name_asc" ) );
			return;
		}

	}

}