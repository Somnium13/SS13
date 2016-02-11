// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Pipe_Simple : Obj_Machinery_Atmospherics_Pipe {

		public Obj_Machinery_Atmospherics node1 = null;
		public Obj_Machinery_Atmospherics node2 = null;
		public int minimum_temperature_difference = 300;
		public double thermal_conductivity = 0;
		public double maximum_pressure = 10132.5;
		public double fatigue_pressure = 8106;
		public Type burst_type = typeof(Obj_Machinery_Atmospherics_Unary_Vent_Burstpipe);

		protected override void __FieldInit() {
			base.__FieldInit();

			this.color = "#B4B4B4";
			this.volume = 70;
			this.initialize_directions = 3;
			this.can_be_coloured = true;
			this.level = 1;
			this.icon = "icons/obj/pipes.dmi";
			this.icon_state = "intact";
		}

		// Function from file: pipes.dm
		public Obj_Machinery_Atmospherics_Pipe_Simple ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			switch ((int)( this.dir )) {
				case 2:
					this.initialize_directions = 3;
					break;
				case 4:
					this.initialize_directions = 12;
					break;
				case 5:
					this.initialize_directions = 5;
					break;
				case 9:
					this.initialize_directions = 9;
					break;
				case 6:
					this.initialize_directions = 6;
					break;
				case 10:
					this.initialize_directions = 10;
					break;
			}
			return;
		}

		// Function from file: pipes.dm
		public override dynamic disconnect( Obj_Machinery_Atmospherics reference = null ) {
			
			if ( reference == this.node1 ) {
				
				if ( this.node1 is Obj_Machinery_Atmospherics_Pipe && !( this.parent == null ) ) {
					GlobalFuncs.returnToPool( this.parent );
				}
				this.node1 = null;
			}

			if ( reference == this.node2 ) {
				
				if ( this.node2 is Obj_Machinery_Atmospherics_Pipe && !( this.parent == null ) ) {
					GlobalFuncs.returnToPool( this.parent );
				}
				this.node2 = null;
			}
			this.update_icon();
			return null;
		}

		// Function from file: pipes.dm
		public override bool initialize( bool? suppress_icon_check = null ) {
			suppress_icon_check = suppress_icon_check ?? false;

			Ent_Static T = null;

			this.normalize_dir();
			this.findAllConnections( this.initialize_directions );
			T = this.loc;
			this.hide( Lang13.BoolNullable( ((dynamic)T).intact ) );

			if ( !( suppress_icon_check == true ) ) {
				this.update_icon();
			}
			return false;
		}

		// Function from file: pipes.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			ByTable node_list = null;
			Obj_Machinery_Atmospherics node = null;

			node_list = new ByTable(new object [] { this.node1, this.node2 });

			if ( !( this.node1 != null ) || !( this.node2 != null ) ) {
				this.icon_state = "exposed";
				base.update_icon( (object)(location), node_list );
			} else {
				this.underlays.Cut();
				this.icon_state = "intact";
				this.alpha = ( this.invisibility != 0 ? 128 : 255 );

				if ( !Lang13.Bool( location ) ) {
					
					foreach (dynamic _a in Lang13.Enumerate( node_list, typeof(Obj_Machinery_Atmospherics) )) {
						node = _a;
						

						if ( node.update_icon_ready && !( node is Obj_Machinery_Atmospherics_Pipe_Simple ) ) {
							node.update_icon( 1 );
						}
					}
				}
			}

			if ( !( this.node1 != null ) && !( this.node2 != null ) ) {
				GlobalFuncs.qdel( this );
			}
			return null;
		}

		// Function from file: pipes.dm
		public override ByTable pipeline_expansion(  ) {
			return new ByTable(new object [] { this.node1, this.node2 });
		}

		// Function from file: pipes.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( this.node1 != null ) {
				this.node1.disconnect( this );
			}

			if ( this.node2 != null ) {
				this.node2.disconnect( this );
			}
			this.node1 = null;
			this.node2 = null;
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: pipes.dm
		public void normalize_dir(  ) {
			
			if ( this.dir == 3 ) {
				this.dir = 1;
			} else if ( this.dir == 12 ) {
				this.dir = 4;
			}
			return;
		}

		// Function from file: pipes.dm
		public void burst(  ) {
			dynamic T = null;
			dynamic A = null;
			Obj_Machinery_Atmospherics node = null;
			int node_id = 0;
			dynamic direction = null;
			Obj_Machinery_Atmospherics found = null;
			bool node_type = false;
			Obj_Machinery_Atmospherics_Unary_Vent_Burstpipe BP = null;

			this.visible_message( new Txt( "<span class='danger'>" ).The( this ).item().str( " bursts!</span>" ).ToString() );
			T = GlobalFuncs.get_turf( this );
			GlobalFuncs.message_admins( "Pipe burst in area " + GlobalFuncs.formatJumpTo( T ) );
			A = GlobalFuncs.get_area_master( this );
			GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "Pipe burst in area " + A.name + " " ) ) );

			foreach (dynamic _a in Lang13.Enumerate( this.pipeline_expansion(), typeof(Obj_Machinery_Atmospherics) )) {
				node = _a;
				

				if ( node != null ) {
					node.disconnect( this );
					node = null;
				}
			}
			this.loc = null;

			if ( Rand13.PercentChance( 50 ) ) {
				GlobalFuncs.explosion( T, -1, 1, 2, null, 0 );
			} else {
				GlobalFuncs.explosion( T, 0, 1, 2, null, 0 );
			}
			node_id = 0;

			foreach (dynamic _c in Lang13.Enumerate( GlobalVars.cardinal )) {
				direction = _c;
				

				if ( ( ((int)( this.initialize_directions ??0 )) & Convert.ToInt32( direction ) ) != 0 ) {
					node_id++;
					found = null;
					node_type = this.getNodeType( node_id );

					switch ((bool)( node_type )) {
						case false:
							found = this.findConnecting( direction );
							break;
						case true:
							found = this.findConnectingHE( direction );
							break;
						default:
							GlobalFuncs.error( "UNKNOWN RESPONSE FROM " + this.type + "/getNodeType(" + node_id + "): " + node_type );
							return;
							break;
					}

					if ( !( found != null ) ) {
						continue;
					}
					BP = new ByTable().Set( 1, T ).Set( "setdir", direction ).Apply( this.burst_type );
					BP.color = this.color;
					BP.invisibility = this.invisibility;
					BP.level = this.level;
					BP.do_connect();
				}
			}
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: pipes.dm
		public void groan(  ) {
			this.visible_message( new Txt( "<span class='warning'>" ).The( this ).item().str( " groans from the pressure!</span>" ).ToString() );
			return;
		}

		// Function from file: pipes.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );
			GlobalFuncs.to_chat( user, "<span class='info'>This " + this.name + " is rated up to " + GlobalFuncs.format_num( this.alert_pressure ) + " kPa.</span>" );
			return null;
		}

		// Function from file: pipes.dm
		public override bool check_pressure( dynamic pressure = null ) {
			GasMixture environment = null;
			dynamic pressure_difference = null;

			
			if ( !( this.loc != null ) ) {
				return false;
			}
			environment = this.loc.return_air();
			pressure_difference = pressure - environment.return_pressure();

			if ( Convert.ToDouble( pressure_difference ) > this.maximum_pressure && Rand13.PercentChance( 1 ) ) {
				this.burst();
			} else if ( Convert.ToDouble( pressure_difference ) > this.fatigue_pressure && Rand13.PercentChance( 1 ) ) {
				this.groan();
			} else {
				return true;
			}
			return false;
		}

		// Function from file: pipes.dm
		public override dynamic process(  ) {
			dynamic _default = null;

			
			if ( !( this.parent != null ) ) {
				_default = base.process();
			}
			GlobalVars.atmos_machines.Remove( this );
			return _default;
		}

		// Function from file: pipes.dm
		public override void hide( bool? h = null ) {
			
			if ( this.level == 1 && this.loc is Tile_Simulated ) {
				this.invisibility = ( h == true ? 101 : 0 );
			}
			this.update_icon();
			return;
		}

		// Function from file: pipes.dm
		public override bool? buildFrom( Mob usr = null, Obj_Item_Pipe pipe = null ) {
			Ent_Static T = null;

			this.dir = pipe.dir;
			this.initialize_directions = pipe.get_pipe_dir();
			T = this.loc;
			this.level = ( Lang13.Bool( ((dynamic)T).intact ) ? 2 : 1 );
			this.initialize( true );

			if ( !( this.node1 != null ) && !( this.node2 != null ) ) {
				GlobalFuncs.to_chat( usr, "<span class='warning'>There's nothing to connect this pipe section to! A pipe segment must be connected to at least one other object!</span>" );
				return false;
			}
			this.update_icon();
			this.build_network();

			if ( this.node1 != null ) {
				this.node1.initialize();
				this.node1.build_network();
			}

			if ( this.node2 != null ) {
				this.node2.initialize();
				this.node2.build_network();
			}
			return true;
		}

	}

}