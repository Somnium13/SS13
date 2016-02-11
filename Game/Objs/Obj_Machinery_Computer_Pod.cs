// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Pod : Obj_Machinery_Computer {

		public ByTable id_tags = new ByTable();
		public ByTable door_only_tags = new ByTable();
		public ByTable synced = new ByTable();
		public ByTable timings = new ByTable();
		public ByTable times = new ByTable();
		public ByTable maxtimes = new ByTable();
		public ByTable powers = new ByTable();
		public ByTable loopings = new ByTable();
		public int default_time = 30;
		public bool default_loop = false;
		public bool default_timings = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.circuit = typeof(Obj_Item_Weapon_Circuitboard_Pod);
			this.light_color = "#7DE1E1";
			this.icon_state = "mass_drivers";
		}

		// Function from file: pod.dm
		public Obj_Machinery_Computer_Pod ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 5, (Task13.Closure)(() => {
				this.driver_sync();
				return;
			}));
			GlobalVars.machines.Add( this );
			return;
		}

		// Function from file: pod.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic new_id_tag = null;
			dynamic ident_tag = null;
			ByTable choices = null;
			Obj_Machinery_Computer_Pod D = null;
			dynamic ident_tag2 = null;
			string ident_tag3 = null;
			double? t = null;
			Obj_Machinery_MassDriver M = null;
			dynamic ident_tag4 = null;
			dynamic ident_tag5 = null;
			dynamic ident_tag6 = null;
			double? tp = null;
			dynamic ident_tag7 = null;
			Obj_Machinery_Door_Poddoor M2 = null;
			dynamic new_title = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return 1;
			} else {
				Task13.User.set_machine( this );

				if ( Lang13.Bool( href_list["add"] ) ) {
					new_id_tag = Interface13.Input( "Enter a new id_tag", "Mass Driver Controls", "id_tag", null, null, InputType.Any );

					if ( !this.id_tags.Contains( new_id_tag ) ) {
						this.id_tags.Add( new_id_tag );
						this.solo_sync( new_id_tag );
					}
				}

				if ( Lang13.Bool( href_list["remove"] ) ) {
					ident_tag = href_list["driver"];

					if ( this.synced.Contains( ident_tag ) ) {
						this.synced.Remove( ident_tag );
					}

					if ( this.door_only_tags.Contains( ident_tag ) ) {
						this.door_only_tags.Remove( ident_tag );
					}
					this.timings.Remove( ident_tag );
					this.times.Remove( ident_tag );
					this.powers.Remove( ident_tag );
					this.loopings.Remove( ident_tag );
					this.id_tags.Remove( ident_tag );
				}

				if ( Lang13.Bool( href_list["teleporter"] ) ) {
					choices = new ByTable(new object [] { 0 });
					choices.Add( GlobalVars.accessable_z_levels );
					D = this;
					((dynamic)D).teleporter_dest = Interface13.Input( "Enter the destination Z-Level. The mechs will arrive from the East. Leave 0 if you don't want to set a specific ZLevel", "Mass Driver Controls", "ZLevel", null, choices, InputType.Any );
				}

				if ( Lang13.Bool( href_list["massfire"] ) ) {
					
					foreach (dynamic _a in Lang13.Enumerate( this.synced )) {
						ident_tag2 = _a;
						
						Task13.Schedule( 0, (Task13.Closure)(() => {
							this.launch_sequence( ident_tag2 );
							return;
						}));
					}
				}

				if ( Lang13.Bool( href_list["power"] ) ) {
					ident_tag3 = href_list["driver"];
					t = String13.ParseNumber( href_list["power"] );
					t = Num13.MinInt( Num13.MaxInt( ((int)( 0.25 )), ((int)( t ??0 )) ), 16 );

					foreach (dynamic _b in Lang13.Enumerate( GlobalVars.mass_drivers, typeof(Obj_Machinery_MassDriver) )) {
						M = _b;
						

						if ( M.id_tag == ident_tag3 ) {
							M.power = t;
						}
					}
					this.powers[ident_tag3] = t;
				}

				if ( Lang13.Bool( href_list["launch"] ) ) {
					this.launch_sequence( href_list["driver"] );
				}

				if ( Lang13.Bool( href_list["time"] ) ) {
					ident_tag4 = href_list["driver"];
					this.timings[ident_tag4] = String13.ParseNumber( href_list["time"] );
				}

				if ( Lang13.Bool( href_list["loop"] ) ) {
					ident_tag5 = href_list["driver"];
					this.loopings[ident_tag5] = String13.ParseNumber( href_list["loop"] );
				}

				if ( Lang13.Bool( href_list["sync"] ) ) {
					this.driver_sync();
				}

				if ( Lang13.Bool( href_list["tp"] ) ) {
					ident_tag6 = href_list["driver"];
					tp = String13.ParseNumber( href_list["tp"] );
					this.maxtimes[ident_tag6] += tp;
					this.maxtimes[ident_tag6] = Num13.MinInt( Num13.MaxInt( Num13.Floor( Convert.ToDouble( this.maxtimes[ident_tag6] ) ), 0 ), 120 );
				}

				if ( Lang13.Bool( href_list["door"] ) ) {
					ident_tag7 = href_list["driver"];

					foreach (dynamic _c in Lang13.Enumerate( GlobalVars.poddoors, typeof(Obj_Machinery_Door_Poddoor) )) {
						M2 = _c;
						

						if ( M2.z != this.z ) {
							continue;
						}

						if ( M2.id_tag == ident_tag7 ) {
							Task13.Schedule( 0, (Task13.Closure)(() => {
								
								if ( M2.density ) {
									M2.open();
								} else {
									M2.close();
								}
								return;
							}));
						}
					}
				}

				if ( Lang13.Bool( href_list["rename"] ) ) {
					new_title = Interface13.Input( "Enter a new title", "" + this.name, "" + this.name, null, null, InputType.Any );

					if ( Lang13.Bool( new_title ) ) {
						this.name = new_title;
					}
				}
				this.updateUsrDialog();
			}
			return null;
		}

		// Function from file: pod.dm
		public override dynamic process(  ) {
			bool timing = false;
			dynamic ident_tag = null;

			
			if ( !Lang13.Bool( base.process() ) ) {
				return null;
			}
			timing = false;

			foreach (dynamic _a in Lang13.Enumerate( this.id_tags )) {
				ident_tag = _a;
				

				if ( Lang13.Bool( this.timings[ident_tag] ) ) {
					
					if ( Convert.ToDouble( this.times[ident_tag] ) > 0 ) {
						this.times[ident_tag] = Num13.Floor( Convert.ToDouble( this.times[ident_tag] ) ) - 1;
						timing = true;
					} else {
						Task13.Schedule( 0, (Task13.Closure)(() => {
							this.launch_sequence( ident_tag );
							return;
						}));

						if ( Lang13.Bool( this.loopings[ident_tag] ) ) {
							this.times[ident_tag] = this.maxtimes[ident_tag];
						} else {
							this.times[ident_tag] = 0;
							this.timings[ident_tag] = 0;
						}
					}
				} else {
					this.times[ident_tag] = this.maxtimes[ident_tag];
				}
				this.updateDialog();
			}

			if ( this.icon_state != "old" ) {
				
				if ( timing ) {
					this.icon_state = "mass_drivers_timing";
				} else {
					this.icon_state = "mass_drivers";
				}
			}
			return null;
		}

		// Function from file: pod.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string dat = null;
			dynamic ident_tag = null;
			string d2 = null;
			dynamic second = null;
			dynamic minute = null;
			dynamic maxsecond = null;
			dynamic maxminute = null;
			string temp = null;
			ByTable L = null;
			dynamic t = null;
			dynamic ident_tag2 = null;

			
			if ( Lang13.Bool( base.attack_hand( (object)(a), (object)(b), (object)(c) ) ) ) {
				return null;
			}
			dat = new Txt( "<HTML><BODY><TT><B>" ).item( this.name ).str( "</B>(<A href='?src=" ).Ref( this ).str( ";rename=1'>rename</A>)" ).ToString();
			((Mob)a).set_machine( this );
			dat += new Txt( "<BR><A href = '?src=" ).Ref( this ).str( ";sync=1'>Reset Connections</A><BR>" ).ToString();

			if ( this.synced.len != 0 ) {
				dat += new Txt( "<BR><A href = '?src=" ).Ref( this ).str( ";massfire=1'><B>Fire All Connected Drivers</B></A><BR>" ).ToString();
			}

			if ( this is Obj_Machinery_Computer_Pod_Deathsquad ) {
				dat += new Txt( "<BR><A href = '?src=" ).Ref( this ).str( ";teleporter=1'><B>Set Teleporter Destination Z-Level</B></A><BR>" ).ToString();
			}

			foreach (dynamic _b in Lang13.Enumerate( this.id_tags )) {
				ident_tag = _b;
				

				if ( !this.door_only_tags.Contains( ident_tag ) ) {
					dat += new Txt( "<BR><BR><B>" ).item( ident_tag ).str( "</B> <A href='?src=" ).Ref( this ).str( ";remove=1;driver=" ).item( ident_tag ).str( "'>remove</A>" ).ToString();
				}

				if ( this.synced.Contains( ident_tag ) ) {
					d2 = "";

					if ( Lang13.Bool( this.timings[ident_tag] ) ) {
						d2 = new Txt( "<A href='?src=" ).Ref( this ).str( ";time=0;driver=" ).item( ident_tag ).str( "'>Stop Time Launch</A>" ).ToString();
					} else {
						d2 = new Txt( "<A href='?src=" ).Ref( this ).str( ";time=1;driver=" ).item( ident_tag ).str( "'>Initiate Time Launch</A>" ).ToString();
					}
					second = this.times[ident_tag] % 60;
					minute = ( this.times[ident_tag] - second ) / 60;
					maxsecond = this.maxtimes[ident_tag] % 60;
					maxminute = ( this.maxtimes[ident_tag] - maxsecond ) / 60;
					dat += new Txt( "<HR>\nTimer System: " ).item( d2 ).str( "\nTime Left: " ).item( ( Lang13.Bool( minute ) ? "" + minute + ":" : null ) ).item( second ).str( "/" ).item( ( Lang13.Bool( maxminute ) ? "" + maxminute + ":" : null ) ).item( maxsecond ).str( " <A href='?src=" ).Ref( this ).str( ";tp=-30;driver=" ).item( ident_tag ).str( "'>-</A> <A href='?src=" ).Ref( this ).str( ";tp=-1;driver=" ).item( ident_tag ).str( "'>-</A> <A href='?src=" ).Ref( this ).str( ";tp=1;driver=" ).item( ident_tag ).str( "'>+</A> <A href='?src=" ).Ref( this ).str( ";tp=30;driver=" ).item( ident_tag ).str( "'>+</A>" ).ToString();
					dat += "<BR>Set timer to loop: " + ( Lang13.Bool( this.loopings[ident_tag] ) ? new Txt( "<A href = '?src=" ).Ref( this ).str( ";loop=0;driver=" ).item( ident_tag ).str( "'>Yes</A>" ).ToString() : new Txt( "<A href = '?src=" ).Ref( this ).str( ";loop=1;driver=" ).item( ident_tag ).str( "'>No</A>" ).ToString() );
					temp = "";
					L = new ByTable(new object [] { 0.25, 0.5, 1, 2, 4, 8, 16 });

					foreach (dynamic _a in Lang13.Enumerate( L )) {
						t = _a;
						

						if ( this.powers[ident_tag] == t ) {
							temp += new Txt( "<B><A href = '?src=" ).Ref( this ).str( ";power=" ).item( t ).str( ";driver=" ).item( ident_tag ).str( "'>" ).item( t ).str( "</A></B> " ).ToString();
						} else {
							temp += new Txt( "<A href = '?src=" ).Ref( this ).str( ";power=" ).item( t ).str( ";driver=" ).item( ident_tag ).str( "'>" ).item( t ).str( "</A> " ).ToString();
						}
					}
					dat += new Txt( "<HR>\nPower Level: " ).item( temp ).str( "<BR>\n<A href = '?src=" ).Ref( this ).str( ";launch=1;driver=" ).item( ident_tag ).str( "'><B>Fire Drive!</B></A><BR>\n<A href = '?src=" ).Ref( this ).str( ";door=1;driver=" ).item( ident_tag ).str( "'>Toggle Pod Doors</A><BR>" ).ToString();
				}
			}

			foreach (dynamic _c in Lang13.Enumerate( this.door_only_tags )) {
				ident_tag2 = _c;
				
				dat += new Txt( "<BR><BR><B>" ).item( ident_tag2 ).str( "</B> <A href='?src=" ).Ref( this ).str( ";remove=1;driver=" ).item( ident_tag2 ).str( "'>remove</A>" ).ToString();
				dat += new Txt( "<BR>\n<A href = '?src=" ).Ref( this ).str( ";door=1;driver=" ).item( ident_tag2 ).str( "'>Toggle Pod Doors</A><BR>" ).ToString();
			}
			dat += new Txt( "<BR><A href='?src=" ).Ref( this ).str( ";add=1'>add another id_tag</A>" ).ToString();
			dat += new Txt( "<BR><BR><A href='?src=" ).Ref( a ).str( ";mach_close=computer'>Close</A></TT></BODY></HTML>" ).ToString();
			Interface13.Browse( a, dat, "window=computer;size=400x500" );
			this.add_fingerprint( Task13.User );
			GlobalFuncs.onclose( a, "computer" );
			return null;
		}

		// Function from file: pod.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: pod.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.add_hiddenprint( user );
			return this.attack_hand( user );
		}

		// Function from file: pod.dm
		public virtual void launch_sequence( dynamic ident_tag = null ) {
			bool anydriver = false;
			Obj_Machinery_MassDriver M = null;
			Obj_Machinery_Door_Poddoor M2 = null;
			Obj_Machinery_MassDriver M3 = null;
			Obj_Machinery_Door_Poddoor M4 = null;

			
			if ( ( this.stat & 3 ) != 0 ) {
				return;
			}
			anydriver = false;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.mass_drivers, typeof(Obj_Machinery_MassDriver) )) {
				M = _a;
				

				if ( M.z != this.z ) {
					continue;
				}

				if ( M.id_tag == ident_tag ) {
					anydriver = true;
				}
			}

			if ( !anydriver ) {
				this.visible_message( "Cannot locate any mass driver of that ID. Cancelling firing sequence!" );
				return;
			}

			if ( this.icon_state != "old" ) {
				Icon13.Flick( "mass_drivers_timing", this );
			}

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.poddoors, typeof(Obj_Machinery_Door_Poddoor) )) {
				M2 = _b;
				

				if ( M2.z != this.z ) {
					continue;
				}

				if ( M2.id_tag == ident_tag ) {
					Task13.Schedule( 0, (Task13.Closure)(() => {
						M2.open();
						return;
					}));
				}
			}
			Task13.Sleep( 20 );

			foreach (dynamic _c in Lang13.Enumerate( GlobalVars.mass_drivers, typeof(Obj_Machinery_MassDriver) )) {
				M3 = _c;
				

				if ( M3.z != this.z ) {
					continue;
				}

				if ( M3.id_tag == ident_tag ) {
					M3.drive();
				}
			}
			Task13.Sleep( 50 );

			foreach (dynamic _d in Lang13.Enumerate( GlobalVars.poddoors, typeof(Obj_Machinery_Door_Poddoor) )) {
				M4 = _d;
				

				if ( M4.z != this.z ) {
					continue;
				}

				if ( M4.id_tag == ident_tag ) {
					Task13.Schedule( 0, (Task13.Closure)(() => {
						M4.close();
						return;
					}));
				}
			}
			return;
		}

		// Function from file: pod.dm
		public void solo_sync( dynamic ident_tag = null ) {
			Obj_Machinery_MassDriver M = null;
			Obj_Machinery_Door_Poddoor M2 = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.mass_drivers, typeof(Obj_Machinery_MassDriver) )) {
				M = _a;
				

				if ( M.z != this.z ) {
					continue;
				}

				if ( M.id_tag == ident_tag && !this.synced.Contains( ident_tag ) ) {
					this.synced.Add( ident_tag );
					this.timings.Add( ident_tag );
					this.timings[ident_tag] = 0;
					this.times.Add( ident_tag );
					this.times[ident_tag] = this.default_time;
					this.maxtimes.Add( ident_tag );
					this.maxtimes[ident_tag] = this.default_time;
					this.powers.Add( ident_tag );
					this.powers[ident_tag] = 1;
					this.loopings.Add( ident_tag );
					this.loopings[ident_tag] = this.default_loop;
					break;
				}
			}

			if ( !this.synced.Contains( ident_tag ) ) {
				
				foreach (dynamic _b in Lang13.Enumerate( GlobalVars.poddoors, typeof(Obj_Machinery_Door_Poddoor) )) {
					M2 = _b;
					

					if ( M2.z != this.z ) {
						continue;
					}

					if ( M2.id_tag == ident_tag && !this.synced.Contains( ident_tag ) && !this.door_only_tags.Contains( ident_tag ) ) {
						this.door_only_tags.Add( ident_tag );
						break;
					}
				}
			}
			return;
		}

		// Function from file: pod.dm
		public void driver_sync(  ) {
			Obj_Machinery_MassDriver M = null;
			dynamic ident_tag = null;
			Obj_Machinery_Door_Poddoor M2 = null;
			dynamic ident_tag2 = null;

			this.timings = new ByTable();
			this.times = new ByTable();
			this.synced = new ByTable();

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.mass_drivers, typeof(Obj_Machinery_MassDriver) )) {
				M = _b;
				

				if ( M.z != this.z ) {
					continue;
				}

				foreach (dynamic _a in Lang13.Enumerate( this.id_tags )) {
					ident_tag = _a;
					

					if ( M.id_tag == ident_tag && !this.synced.Contains( ident_tag ) ) {
						this.synced.Add( ident_tag );
						this.timings.Add( ident_tag );
						this.timings[ident_tag] = this.default_timings;
						this.times.Add( ident_tag );
						this.times[ident_tag] = this.default_time;
						this.maxtimes.Add( ident_tag );
						this.maxtimes[ident_tag] = this.default_time;
						this.powers.Add( ident_tag );
						this.powers[ident_tag] = 1;
						this.loopings.Add( ident_tag );
						this.loopings[ident_tag] = this.default_loop;
						break;
					}
				}
			}

			foreach (dynamic _d in Lang13.Enumerate( GlobalVars.poddoors, typeof(Obj_Machinery_Door_Poddoor) )) {
				M2 = _d;
				

				if ( M2.z != this.z ) {
					continue;
				}

				foreach (dynamic _c in Lang13.Enumerate( this.id_tags )) {
					ident_tag2 = _c;
					

					if ( M2.id_tag == ident_tag2 && !this.synced.Contains( ident_tag2 ) && !this.door_only_tags.Contains( ident_tag2 ) ) {
						this.door_only_tags.Add( ident_tag2 );
						break;
					}
				}
			}
			return;
		}

	}

}