// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Disposalpipe : Obj_Structure {

		public int dpdir = 0;
		public int health = 10;
		public string base_icon_state = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.level = 1;
			this.icon = "icons/obj/pipes/disposal.dmi";
			this.layer = 2.3;
		}

		// Function from file: disposal.dm
		public Obj_Structure_Disposalpipe ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.base_icon_state = this.icon_state;
			return;
		}

		// Function from file: disposal.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Ent_Static T = null;
			dynamic W = null;
			Ent_Static uloc = null;
			Ent_Static wloc = null;

			T = this.loc;

			if ( Lang13.Bool( ((dynamic)T).intact ) ) {
				return null;
			}
			this.add_fingerprint( b );

			if ( a is Obj_Item_Weapon_Weldingtool ) {
				W = a;

				if ( Lang13.Bool( W.remove_fuel( 0, b ) ) ) {
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/welder2.ogg", 100, 1 );
					uloc = b.loc;
					wloc = W.loc;
					GlobalFuncs.to_chat( b, "Slicing the disposal pipe." );
					Task13.Sleep( 30 );

					if ( !((Obj_Item_Weapon_Weldingtool)W).isOn() ) {
						return null;
					}

					if ( b.loc == uloc && wloc == W.loc ) {
						this.welded();
					} else {
						GlobalFuncs.to_chat( b, "You must stay still while welding the pipe." );
					}
				} else {
					GlobalFuncs.to_chat( b, "You need more welding fuel to cut the pipe." );
					return null;
				}
			}
			return null;
		}

		// Function from file: disposal.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((double?)( severity )) {
				case 1:
					this.broken( false );
					return false;
					break;
				case 2:
					this.health -= Rand13.Int( 5, 15 );
					this.healthcheck();
					return false;
					break;
				case 3:
					this.health -= Rand13.Int( 0, 15 );
					this.healthcheck();
					return false;
					break;
			}
			return false;
		}

		// Function from file: disposal.dm
		public override void hide( bool? h = null ) {
			this.invisibility = ( h == true ? 101 : 0 );
			this.updateicon();
			return;
		}

		// Function from file: disposal.dm
		public virtual void welded(  ) {
			Obj_Structure_Disposalconstruct C = null;

			C = new Obj_Structure_Disposalconstruct( this.loc );

			switch ((string)( this.base_icon_state )) {
				case "pipe-s":
					C.ptype = 0;
					break;
				case "pipe-c":
					C.ptype = 1;
					break;
				case "pipe-j1":
					C.ptype = 2;
					break;
				case "pipe-j2":
					C.ptype = 3;
					break;
				case "pipe-y":
					C.ptype = 4;
					break;
				case "pipe-t":
					C.ptype = 5;
					break;
				case "pipe-j1s":
					C.ptype = 9;
					break;
				case "pipe-j2s":
					C.ptype = 10;
					break;
			}
			this.transfer_fingerprints_to( C );
			C.change_dir( this.dir );
			C.density = false;
			C.anchored = 1;
			C.update();
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: disposal.dm
		public void healthcheck(  ) {
			
			if ( this.health < -2 ) {
				this.broken( false );
			} else if ( this.health < 1 ) {
				this.broken( true );
			}
			return;
		}

		// Function from file: disposal.dm
		public void broken( bool? remains = null ) {
			remains = remains ?? false;

			dynamic D = null;
			Obj_Structure_Disposalpipe_Broken P = null;
			dynamic H = null;
			Ent_Static T = null;
			Ent_Dynamic AM = null;

			
			if ( remains == true ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.cardinal )) {
					D = _a;
					

					if ( Lang13.Bool( D & this.dpdir ) ) {
						P = new Obj_Structure_Disposalpipe_Broken( this.loc );
						P.dir = Convert.ToInt32( D );
					}
				}
			}
			this.invisibility = 101;
			H = Lang13.FindIn( typeof(Obj_Structure_Disposalholder), this );

			if ( Lang13.Bool( H ) ) {
				H.active = 0;
				T = this.loc;

				if ( T.density ) {
					
					foreach (dynamic _b in Lang13.Enumerate( H, typeof(Ent_Dynamic) )) {
						AM = _b;
						
						AM.forceMove( T );
						AM.pipe_eject( 0 );
					}
					GlobalFuncs.qdel( H );
					return;
				}

				if ( Lang13.Bool( H ) ) {
					this.expel( H, T, 0 );
				}
			}
			Task13.Schedule( 2, (Task13.Closure)(() => {
				GlobalFuncs.qdel( this );
				return;
			}));
			return;
		}

		// Function from file: disposal.dm
		public void expel( dynamic H = null, Ent_Static T = null, int? direction = null ) {
			dynamic target = null;
			Ent_Static F = null;
			Ent_Dynamic AM = null;
			Ent_Dynamic AM2 = null;

			
			if ( !( T != null ) || T == null ) {
				T = this.loc;
			}

			if ( T.density ) {
				H.active = 0;
				((Ent_Dynamic)H).forceMove( this );
				return;
			}

			if ( Lang13.Bool( ((dynamic)T).intact ) && T is Tile_Simulated_Floor ) {
				F = T;
				((dynamic)F).break_tile();
			}

			if ( Lang13.Bool( direction ) ) {
				
				if ( T is Tile_Space ) {
					target = GlobalFuncs.get_edge_target_turf( T, direction );
				} else {
					target = GlobalFuncs.get_ranged_target_turf( T, direction, 10 );
				}
				GlobalFuncs.playsound( this, "sound/machines/hiss.ogg", 50, 0, 0 );

				if ( Lang13.Bool( H ) ) {
					
					foreach (dynamic _a in Lang13.Enumerate( H, typeof(Ent_Dynamic) )) {
						AM = _a;
						
						AM.forceMove( T );
						AM.pipe_eject( direction );
						Task13.Schedule( 1, (Task13.Closure)(() => {
							
							if ( AM != null ) {
								AM.throw_at( target, 100, 1 );
							}
							return;
						}));
					}
					((Obj_Structure_Disposalholder)H).vent_gas( T );
					GlobalFuncs.qdel( H );
				}
			} else {
				GlobalFuncs.playsound( this, "sound/machines/hiss.ogg", 50, 0, 0 );

				if ( Lang13.Bool( H ) ) {
					
					foreach (dynamic _b in Lang13.Enumerate( H, typeof(Ent_Dynamic) )) {
						AM2 = _b;
						
						target = GlobalFuncs.get_offset_target_turf( T, Rand13.Int( 5 ) - Rand13.Int( 5 ), Rand13.Int( 5 ) - Rand13.Int( 5 ) );
						AM2.forceMove( T );
						AM2.pipe_eject( 0 );
						Task13.Schedule( 1, (Task13.Closure)(() => {
							
							if ( AM2 != null ) {
								AM2.throw_at( target, 5, 1 );
							}
							return;
						}));
					}
					((Obj_Structure_Disposalholder)H).vent_gas( T );
					GlobalFuncs.qdel( H );
				}
			}
			return;
		}

		// Function from file: disposal.dm
		public void updateicon(  ) {
			
			if ( this.invisibility != 0 ) {
				this.icon_state = "" + this.base_icon_state + "f";
			} else {
				this.icon_state = this.base_icon_state;
			}
			return;
		}

		// Function from file: disposal.dm
		public void update(  ) {
			Ent_Static T = null;

			T = this.loc;
			this.hide( Lang13.Bool( ((dynamic)T).intact ) && !( T is Tile_Space ) );
			return;
		}

		// Function from file: disposal.dm
		public virtual Obj_Structure_Disposalpipe transfer( Obj_Structure_Disposalholder H = null ) {
			double? nextdir = null;
			Tile T = null;
			Obj_Structure_Disposalpipe P = null;
			dynamic H2 = null;

			nextdir = this.nextdir( H.dir );
			H.dir = ((int)( nextdir ??0 ));
			T = H.nextloc();
			P = H.findpipe( T );

			if ( P != null ) {
				H2 = Lang13.FindIn( typeof(Obj_Structure_Disposalholder), P );

				if ( Lang13.Bool( H2 ) && !Lang13.Bool( H2.active ) ) {
					H.merge( H2 );
				}
				H.forceMove( P );
			} else {
				H.forceMove( T );
				return null;
			}
			return P;
		}

		// Function from file: disposal.dm
		public virtual double? nextdir( int fromdir = 0, dynamic sortTag = null ) {
			return this.dpdir & ~Num13.Rotate( fromdir, 180 );
		}

		// Function from file: disposal.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			dynamic H = null;
			Ent_Static T = null;
			Ent_Dynamic AM = null;

			H = Lang13.FindIn( typeof(Obj_Structure_Disposalholder), this );

			if ( Lang13.Bool( H ) ) {
				H.active = 0;
				T = this.loc;

				if ( T.density ) {
					
					foreach (dynamic _a in Lang13.Enumerate( H, typeof(Ent_Dynamic) )) {
						AM = _a;
						
						AM.forceMove( T );
						AM.pipe_eject( 0 );
					}
					GlobalFuncs.qdel( H );
					base.Destroy( (object)(brokenup) );
					return null;
				}

				if ( Lang13.Bool( H ) ) {
					this.expel( H, T, 0 );
				}
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}