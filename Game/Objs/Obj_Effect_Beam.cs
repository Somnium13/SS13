// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Beam : Obj_Effect {

		public string def_zone = "";
		public int damage = 0;
		public string damage_type = "fire";
		public Obj_Effect_Beam master = null;
		public ByTable children = new ByTable();
		public dynamic next = null;
		public Ent_Static target = null;
		public double max_range = Double.PositiveInfinity;
		public bool bumped = false;
		public bool stepped = false;
		public int steps = 0;
		public bool am_connector = false;
		public string targetMoveKey = null;
		public string targetDestroyKey = null;
		public Ent_Static targetContactLoc = null;
		public dynamic sources = new ByTable();
		public bool _re_emit = true;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.unacidable = true;
			this.anchored = 1;
			this.pass_flags = 7;
		}

		public Obj_Effect_Beam ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: vgstation13.dme
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			return false;
		}

		// Function from file: beam.dm
		public override double singularity_act( double? current_size = null, Obj_Machinery_Singularity S = null ) {
			this._re_emit = false;
			base.singularity_act( current_size, S );
			return 0;
		}

		// Function from file: beam.dm
		public override bool singularity_pull( Obj S = null, double? current_size = null, int? radiations = null ) {
			return false;
		}

		// Function from file: beam.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			Obj_Effect_Beam ourselves = null;
			Obj_Effect_Beam ourmaster = null;
			Obj_Machinery_Mirror M = null;
			Obj_Machinery_FieldGenerator F = null;
			Obj_Machinery_Prism P = null;
			Obj_Machinery_Power_Photocollector PC = null;
			Obj_Effect_Beam B = null;

			ourselves = this;
			ourmaster = this.get_master();

			if ( this.target != null ) {
				
				if ( this.target.beams != null ) {
					this.target.beams.Remove( ourselves );
				}
			}

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.mirror_list, typeof(Obj_Machinery_Mirror) )) {
				M = _a;
				

				if ( !( M != null ) ) {
					continue;
				}

				if ( M.beams.Contains( ourselves ) ) {
					M.beams.Remove( ourselves );
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.field_gen_list, typeof(Obj_Machinery_FieldGenerator) )) {
				F = _b;
				

				if ( !( F != null ) ) {
					continue;
				}

				if ( F.beams.Contains( ourselves ) ) {
					F.beams.Remove( ourselves );
				}
			}

			foreach (dynamic _c in Lang13.Enumerate( GlobalVars.prism_list, typeof(Obj_Machinery_Prism) )) {
				P = _c;
				

				if ( ourselves == P.beam ) {
					P.beam = null;
				}

				if ( P.beams.Contains( ourselves ) ) {
					P.beams.Remove( ourselves );
				}
			}

			foreach (dynamic _d in Lang13.Enumerate( GlobalVars.photocollector_list, typeof(Obj_Machinery_Power_Photocollector) )) {
				PC = _d;
				

				if ( PC.beams.Contains( ourselves ) ) {
					PC.beams.Remove( ourselves );
				}
			}

			if ( !this.am_connector && !( this.master != null ) ) {
				this.disconnect( false );
			}

			if ( this.master != null ) {
				
				if ( this.master.target != null && this.master.target.beams != null ) {
					this.master.target.beams.Remove( ourselves );
				}

				foreach (dynamic _e in Lang13.Enumerate( this.master.children, typeof(Obj_Effect_Beam) )) {
					B = _e;
					

					if ( B.next == ourselves ) {
						B.next = null;
					}
				}

				if ( this.master.next == ourselves ) {
					this.master.next = null;
				}
				this.master.children.Remove( ourselves );
				this.master = null;
			} else if ( this.children != null && this.children.len != 0 ) {
				this.killKids();
			}

			if ( Lang13.Bool( this.next ) ) {
				this.next._re_emit = false;
				GlobalFuncs.qdel( this.next );
				this.next = null;
			}
			base.Destroy( (object)(brokenup) );

			if ( ourselves._re_emit && ourmaster._re_emit ) {
				ourmaster.emit( ourmaster.sources );
			}
			return null;
		}

		// Function from file: beam.dm
		public override dynamic Bump(Ent_Static Obstacle = null, dynamic yes = null) {
			
			if ( !( this.master != null ) ) {
				return null;
			}
			this.bumped = true;

			if ( Obstacle != null ) {
				this.connect_to( Obstacle );
				this.am_connector = true;
			}
			return 1;
		}

		// Function from file: beam.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			Obj_Effect_Beam OB = null;

			
			if ( !( this.master != null ) || !( O != null ) ) {
				return null;
			}

			if ( O is Obj_Effect_Beam || !O.density && !( O is Obj_Effect_Blob ) ) {
				return null;
			}

			if ( this.master.target != null ) {
				this.disconnect( false );
			}
			this.am_connector = true;
			OB = this.master;

			if ( !( OB != null ) ) {
				OB = this;
			}
			this._re_emit = false;
			GlobalFuncs.qdel( this );
			OB.connect_to( O );
			return null;
		}

		// Function from file: beam.dm
		public override bool blob_act( dynamic severity = null ) {
			dynamic B = null;

			B = Lang13.FindIn( typeof(Obj_Effect_Blob), this.loc );

			if ( Lang13.Bool( B ) ) {
				this.Crossed( B );
			}
			return false;
		}

		// Function from file: beam.dm
		public override bool Bumped( Ent_Static AM = null, dynamic yes = null ) {
			Obj_Effect_Beam OB = null;

			
			if ( !( this.master != null ) || !( AM != null ) ) {
				return false;
			}

			if ( AM is Obj_Effect_Beam || !AM.density ) {
				return false;
			}
			this.am_connector = true;
			OB = this.master;

			if ( !( OB != null ) ) {
				OB = this;
			}
			this._re_emit = false;
			GlobalFuncs.qdel( this );
			OB.connect_to( AM );
			return false;
		}

		// Function from file: beam.dm
		public virtual dynamic spawn_child(  ) {
			dynamic B = null;

			
			if ( this.steps >= 50 ) {
				return null;
			}
			B = Lang13.Call( this.type, this.loc );
			B.steps = this.steps + 1;
			B.dir = this.dir;
			B.master = this.get_master();

			if ( B.master != B ) {
				B.master.children.Add( B );
			}
			return B;
		}

		// Function from file: beam.dm
		public void emit( dynamic spawn_by = null, double? _range = null ) {
			_range = _range ?? -1;

			
			if ( spawn_by is ByTable ) {
				this.sources = spawn_by;
			} else {
				this.sources |= spawn_by;
			}

			if ( _range == -1 ) {
				_range = this.max_range;
			}

			if ( Lang13.Bool( this.next ) && this.next.loc != null ) {
				((Obj_Effect_Beam)this.next).emit( this.sources, ( _range ??0) - 1 );
				return;
			}

			if ( !( this.loc != null ) ) {
				this._re_emit = false;
				GlobalFuncs.qdel( this );
				return;
			}

			if ( this.x == 1 || this.x == Game13.map_size_x || this.y == 1 || this.y == Game13.map_size_y ) {
				this._re_emit = false;
				GlobalFuncs.qdel( this );
				return;
			}
			this.invisibility = 0;

			if ( !( this.master != null ) && !this.stepped ) {
				this.stepped = true;
				this.invisibility = 101;
			}

			if ( !this.stepped ) {
				this.density = true;
				this.bumped = false;
				Map13.Step( this, this.dir );
				this.density = false;

				if ( this.bumped ) {
					this._re_emit = false;
					GlobalFuncs.qdel( this );
					return;
				}
				this.stepped = true;

				if ( ( _range-- ??0) < 1 ) {
					this._re_emit = false;
					GlobalFuncs.qdel( this );
					return;
				}
			}
			this.update_icon();
			this.next = this.spawn_child();

			if ( Lang13.Bool( this.next ) ) {
				((Obj_Effect_Beam)this.next).emit( this.sources, _range );
			}
			return;
		}

		// Function from file: beam.dm
		public dynamic HasSource( Obj source = null ) {
			return this.sources.Contains( source );
		}

		// Function from file: beam.dm
		public void disconnect( bool? re_emit = null ) {
			re_emit = re_emit ?? true;

			Obj_Effect_Beam _master = null;

			_master = this.get_master();

			if ( _master.target != null ) {
				_master.target.on_moved.Remove( _master.targetMoveKey );
				_master.target.on_destroyed.Remove( _master.targetDestroyKey );
				_master.target.beam_disconnect( _master );
				_master.target = null;
				_master.targetMoveKey = null;
				_master.targetDestroyKey = null;

				if ( re_emit == true ) {
					_master.emit( this.sources );
				}
			}
			return;
		}

		// Function from file: beam.dm
		public void killKids(  ) {
			Obj_Effect_Beam child = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.children, typeof(Obj_Effect_Beam) )) {
				child = _a;
				

				if ( child != null ) {
					this.children.Remove( child );
					child._re_emit = false;
					GlobalFuncs.qdel( child );
				}
			}
			this.children.len = 0;
			return;
		}

		// Function from file: beam.dm
		public void connect_to( Ent_Static AM = null ) {
			Obj_Effect_Beam BM = null;

			
			if ( !( AM != null ) ) {
				return;
			}
			BM = this.get_master();

			if ( BM.target == AM ) {
				return;
			}

			if ( BM.target != null ) {
				BM.disconnect( false );
			}
			BM.target = AM;
			BM.targetMoveKey = AM.on_moved.Add( BM, "target_moved" );
			BM.targetDestroyKey = AM.on_destroyed.Add( BM, "target_destroyed" );
			BM.targetContactLoc = AM.loc;
			AM.beam_connect( BM );
			return;
		}

		// Function from file: beam.dm
		public virtual Image get_machine_underlay( int mdir = 0 ) {
			return new Image( this.icon, null, "" + this.icon_state + " underlay", null, mdir );
		}

		// Function from file: beam.dm
		public virtual int get_damage(  ) {
			return this.damage;
		}

		// Function from file: beam.dm
		public Obj_Effect_Beam get_master(  ) {
			
			if ( this.master != null ) {
				return this.master;
			}
			return this;
		}

		// Function from file: beam.dm
		public void target_destroyed( dynamic args = null ) {
			dynamic E = null;

			
			if ( this.master != null ) {
				this.master.target_destroyed( args );
				return;
			}
			E = args["event"];

			if ( !Lang13.Bool( this.targetDestroyKey ) ) {
				E.handlers.Remove( new Txt().Ref( this ).str( ":target_destroyed" ).ToString() );
				return;
			}

			if ( E.holder != this.target ) {
				E.handlers.Remove( new Txt().Ref( this ).str( ":target_destroyed" ).ToString() );
				return;
			}
			this.disconnect();
			return;
		}

		// Function from file: beam.dm
		public void target_moved( dynamic args = null ) {
			dynamic E = null;
			Ent_Static T = null;

			
			if ( this.master != null ) {
				this.master.target_moved( args );
				return;
			}
			E = args["event"];

			if ( !Lang13.Bool( this.targetMoveKey ) ) {
				E.handlers.Remove( new Txt().Ref( this ).str( ":target_moved" ).ToString() );
				return;
			}
			T = args["loc"];

			if ( E.holder != this.target ) {
				E.handlers.Remove( new Txt().Ref( this ).str( ":target_moved" ).ToString() );
				return;
			}

			if ( T != this.targetContactLoc && T != this.loc ) {
				this.disconnect();
			}
			return;
		}

		// Function from file: beam.dm
		public override dynamic resetVariables( string args = null, params object[] _ ) {
			ByTable _args = new ByTable( new object[] { args } ).Extend(_);

			base.resetVariables( "sources", "children", (object)(_args) );
			this.children = new ByTable();
			this.sources = new ByTable();
			return null;
		}

	}

}