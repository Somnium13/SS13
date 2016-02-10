// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Mirror : Obj_Machinery {

		public string base_state = "base";
		public string mirror_state = "mirror";
		public int nsplits = 1;
		public ByTable emitted_beams = new ByTable( 4 );
		public ByTable powerchange_hooks = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.use_power = 0;
			this.machine_flags = 14;
			this.icon = "icons/obj/machines/optical/beamsplitter.dmi";
			this.icon_state = "mirror";
		}

		// Function from file: mirror.dm
		public Obj_Machinery_Mirror ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.mirror_list.Add( this );
			this.icon_state = this.base_state;
			this.overlays.Add( this.mirror_state );
			this.component_parts = new ByTable(new object [] { new Obj_Item_Stack_Sheet_Glass_Rglass( this, 5 ) });
			return;
		}

		// Function from file: mirror.dm
		public override void beam_disconnect( Obj_Effect_Beam B = null ) {
			
			if ( B is Obj_Effect_Beam_Emitter ) {
				
				if ( Lang13.Bool( B.HasSource( this ) ) ) {
					return;
				}
				base.beam_disconnect( B );
				((dynamic)B).power_change.Remove( this.powerchange_hooks[B] );
				this.powerchange_hooks.Remove( B );
				this.update_beams();
			}
			return;
		}

		// Function from file: mirror.dm
		public override bool beam_connect( Obj_Effect_Beam B = null ) {
			
			if ( B is Obj_Effect_Beam_Emitter ) {
				
				if ( Lang13.Bool( B.HasSource( this ) ) ) {
					return false;
				}
				base.beam_connect( B );
				this.powerchange_hooks[B] = ((dynamic)B).power_change.Add( this, "on_power_change" );
				this.update_beams();
			}
			return false;
		}

		// Function from file: mirror.dm
		public override int wrenchAnchor( dynamic user = null ) {
			int _default = 0;

			_default = base.wrenchAnchor( (object)(user) );

			if ( _default == 1 ) {
				
				if ( this.beams != null && this.beams.len != 0 ) {
					this.kill_all_beams();
					this.update_beams();
				}
			}
			return _default;
		}

		// Function from file: mirror.dm
		public override void dropFrame(  ) {
			Obj_Structure_MirrorFrame MF = null;

			MF = new Obj_Structure_MirrorFrame( this.loc );
			MF.anchored = this.anchored;
			return;
		}

		// Function from file: mirror.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			this.kill_all_beams();
			GlobalVars.mirror_list.Remove( this );
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: mirror.dm
		public void update_beams(  ) {
			ByTable beam_dirs = null;
			int i = 0;
			ByTable spawners = null;
			Obj_Effect_Beam B = null;
			int beamdir = 0;
			ByTable deflections = null;
			double splitpower = 0;
			Obj_Effect_Beam EB = null;
			dynamic splitdir = null;
			int diridx = 0;
			dynamic dirdata = null;
			int cdir = 0;
			ByTable dirdata2 = null;
			bool delbeam = false;
			dynamic beam = null;
			dynamic beamtype = null;
			bool newbeam = false;
			dynamic EB2 = null;
			dynamic EB3 = null;

			this.overlays.len = 0;
			beam_dirs = new ByTable( 4 );
			i = 0;
			i = 1;

			while (i <= 4) {
				beam_dirs[i] = new ByTable();
				i++;
			}
			spawners = new ByTable(new object [] { this });

			if ( this.beams.len > 0 && Lang13.Bool( this.anchored ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.beams, typeof(Obj_Effect_Beam) )) {
					B = _a;
					

					if ( Lang13.Bool( B.HasSource( this ) ) ) {
						Game13.log.WriteMsg( "## WARNING: " + ( "Ignoring beam " + B + " due to recursion." ) );
						continue;
					}
					spawners.Or( B.sources );
					beamdir = Map13.GetDistance( this, B );
					this.overlays.Add( B.get_machine_underlay( beamdir ) );
					deflections = this.get_deflections( beamdir );
					splitpower = 1;

					if ( B is Obj_Effect_Beam_Emitter ) {
						EB = B;
						splitpower = Num13.Round( Convert.ToDouble( ((dynamic)EB).power / this.nsplits ), 0.1 );
					}

					if ( splitpower < 0.1 ) {
						continue;
					}
					i = 1;

					while (i <= this.nsplits) {
						splitdir = deflections[i];
						diridx = GlobalVars.cardinal.Find( splitdir );
						dirdata = beam_dirs[diridx];
						Interface13.Stat( null, dirdata.Contains( B.type ) );

						if ( !false ) {
							dirdata[B.type] = splitpower;
						} else {
							dirdata[B.type] = dirdata[B.type] + splitpower;
						}
						beam_dirs[diridx] = dirdata;
						i++;
					}
				}
			}

			if ( this.emitted_beams.len < 4 ) {
				this.emitted_beams.len = 4;
			}
			i = 1;

			while (i <= 4) {
				cdir = Convert.ToInt32( GlobalVars.cardinal[i] );
				dirdata2 = beam_dirs[i];
				delbeam = false;
				beam = null;

				if ( dirdata2.len > 0 ) {
					
					foreach (dynamic _b in Lang13.Enumerate( dirdata2 )) {
						beamtype = _b;
						
						newbeam = false;
						beam = this.emitted_beams[i];

						if ( Lang13.Bool( beam ) && beam.type != beamtype ) {
							GlobalFuncs.qdel( beam );
							this.emitted_beams[i] = null;
							beam = null;
						}

						if ( !Lang13.Bool( beam ) ) {
							beam = Lang13.Call( beamtype, this.loc );
							this.emitted_beams[i] = beam;
							beam.dir = cdir;
							newbeam = true;
						}

						if ( beam is Obj_Effect_Beam_Emitter ) {
							EB2 = beam;
							EB2.power = dirdata2[beamtype];
						}
						this.overlays.Add( ((Obj_Effect_Beam)beam).get_machine_underlay( cdir ) );

						if ( newbeam ) {
							((Obj_Effect_Beam)beam).emit( spawners );
						} else if ( beam is Obj_Effect_Beam_Emitter ) {
							EB3 = beam;
							((Obj_Effect_Beam_Emitter)EB3).set_power( Lang13.IntNullable( EB3.power ) );
						}
						break;
					}
				} else {
					delbeam = true;
				}
				beam = this.emitted_beams[i];

				if ( delbeam && Lang13.Bool( beam ) ) {
					GlobalFuncs.qdel( beam );
					this.emitted_beams[i] = null;
				}
				i++;
			}
			this.overlays.Add( this.mirror_state );
			return;
		}

		// Function from file: mirror.dm
		public void kill_all_beams(  ) {
			int? i = null;
			dynamic beam = null;

			i = null;
			i = 1;

			while (( i ??0) <= 4) {
				
				if ( ( i ??0) > this.emitted_beams.len ) {
					break;
				}
				beam = this.emitted_beams[i];
				GlobalFuncs.qdel( beam );
				this.emitted_beams[i] = null;
				beam = null;
				i++;
			}
			this.emitted_beams.len = 4;
			return;
		}

		// Function from file: mirror.dm
		public void on_power_change( dynamic args = null ) {
			this.update_beams();
			return;
		}

		// Function from file: mirror.dm
		public virtual ByTable get_deflections( int in_dir = 0 ) {
			Interface13.Stat( null, new ByTable(new object [] { GlobalVars.EAST, GlobalVars.WEST }).Contains( this.dir ) );

			if ( false ) {
				
				switch ((int)( in_dir )) {
					case 1:
						return new ByTable(new object [] { GlobalVars.EAST });
						break;
					case 2:
						return new ByTable(new object [] { GlobalVars.WEST });
						break;
					case 4:
						return new ByTable(new object [] { GlobalVars.NORTH });
						break;
					case 8:
						return new ByTable(new object [] { GlobalVars.SOUTH });
						break;
				}
			} else {
				
				switch ((int)( in_dir )) {
					case 1:
						return new ByTable(new object [] { GlobalVars.WEST });
						break;
					case 2:
						return new ByTable(new object [] { GlobalVars.EAST });
						break;
					case 4:
						return new ByTable(new object [] { GlobalVars.SOUTH });
						break;
					case 8:
						return new ByTable(new object [] { GlobalVars.NORTH });
						break;
				}
			}
			return null;
		}

		// Function from file: mirror.dm
		[Verb]
		[VerbInfo( name: "Rotate (Counter-Clockwise)", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public bool rotate_ccw(  ) {
			
			if ( Lang13.Bool( this.anchored ) ) {
				GlobalFuncs.to_chat( Task13.User, "It is fastened to the floor!" );
				return false;
			}
			this.dir = Num13.Rotate( this.dir, 90 );
			this.kill_all_beams();
			this.update_beams();
			return true;
		}

		// Function from file: mirror.dm
		[Verb]
		[VerbInfo( name: "Rotate (Clockwise)", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public bool rotate_cw(  ) {
			
			if ( Lang13.Bool( this.anchored ) ) {
				GlobalFuncs.to_chat( Task13.User, "It is fastened to the floor!" );
				return false;
			}
			this.dir = Num13.Rotate( this.dir, -90 );
			this.kill_all_beams();
			this.update_beams();
			return true;
		}

	}

}