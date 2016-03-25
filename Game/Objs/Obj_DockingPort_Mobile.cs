// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_DockingPort_Mobile : Obj_DockingPort {

		public dynamic areaInstance = null;
		public double timer = 0;
		public int mode = 0;
		public int callTime = 50;
		public string roundstart_move = null;
		public int travelDir = 0;
		public Obj_DockingPort_Stationary destination = null;
		public dynamic previous = null;
		public int launch_status = -1;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "pinonclose";
		}

		// Function from file: shuttle.dm
		public Obj_DockingPort_Mobile ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.SSshuttle.mobile.Add( this );
			return;
		}

		// Function from file: shuttle.dm
		public string getStatusText(  ) {
			string _default = null;

			dynamic dockedAt = null;
			dynamic dst = null;

			dockedAt = this.get_docked();
			_default = ( Lang13.Bool( dockedAt ) && Lang13.Bool( dockedAt.name ) ? dockedAt.name : "unknown" );

			if ( dockedAt is Obj_DockingPort_Stationary_Transit ) {
				
				if ( this.mode == 1 ) {
					dst = this.previous;
				} else {
					dst = this.destination;
				}
				_default += " towards " + ( Lang13.Bool( dst ) ? dst.name : "unknown location" ) + " (" + this.timeLeft( 600 ) + " minutes)";
			}
			return _default;
		}

		// Function from file: shuttle.dm
		public virtual double timeLeft( int? divisor = null ) {
			
			if ( ( divisor ??0) <= 0 ) {
				divisor = 10;
			}

			if ( !( this.timer != 0 ) ) {
				return Num13.Round( this.callTime / ( divisor ??0), 1 );
			}
			return Num13.MaxInt( ((int)( Num13.Round( ( this.timer + this.callTime - Game13.time ) / ( divisor ??0), 1 ) )), 0 );
		}

		// Function from file: shuttle.dm
		public void setTimer( dynamic wait = null ) {
			
			if ( this.timer <= 0 ) {
				this.timer = Game13.time;
			}
			this.timer += Convert.ToDouble( wait - this.timeLeft( 1 ) );
			return;
		}

		// Function from file: shuttle.dm
		public virtual void check(  ) {
			double timeLeft = 0;

			timeLeft = this.timeLeft( 1 );

			if ( timeLeft <= 0 ) {
				
				switch ((int)( this.mode )) {
					case 2:
						
						if ( this.dock( this.destination ) != 0 ) {
							this.setTimer( 20 );
							return;
						}
						break;
					case 1:
						
						if ( this.dock( this.previous ) != 0 ) {
							this.setTimer( 20 );
							return;
						}
						break;
				}
				this.mode = 0;
				this.timer = 0;
				this.destination = null;
			}
			return;
		}

		// Function from file: shuttle.dm
		public void roadkill( ByTable L = null, int dir = 0, dynamic x = null, dynamic y = null ) {
			dynamic T = null;
			Ent_Dynamic AM = null;
			Ent_Dynamic M = null;

			
			foreach (dynamic _b in Lang13.Enumerate( L )) {
				T = _b;
				

				foreach (dynamic _a in Lang13.Enumerate( T, typeof(Ent_Dynamic) )) {
					AM = _a;
					

					if ( AM is Mob ) {
						
						if ( AM is Mob_Living ) {
							M = AM;
							((Mob)M).Paralyse( 10 );
							((dynamic)M).take_organ_damage( 80 );
							M.anchored = 0;
						} else {
							continue;
						}
					}

					if ( !Lang13.Bool( AM.anchored ) ) {
						Map13.Step( AM, dir );
					} else {
						GlobalFuncs.qdel( AM );
					}
				}
			}
			return;
		}

		// Function from file: shuttle.dm
		public void closePortDoors(  ) {
			Tile T = null;
			dynamic Door = null;

			T = Map13.GetStep( this.loc, Num13.Rotate( this.dir, 180 ) );

			if ( T != null ) {
				Door = Lang13.FindIn( typeof(Obj_Machinery_Door), T );

				if ( Lang13.Bool( Door ) ) {
					Task13.Schedule( 0, (Task13.Closure)(() => {
						((Obj_Machinery_Door)Door).close();
						return;
					}));
				}
			}
			return;
		}

		// Function from file: shuttle.dm
		public Obj_DockingPort_Stationary findTransitDock(  ) {
			Obj_DockingPort_Stationary T = null;

			T = GlobalVars.SSshuttle.getDock( "" + this.id + "_transit" );

			if ( T != null && !( this.canDock( T ) != 0 ) ) {
				return T;
			}
			return null;
		}

		// Function from file: shuttle.dm
		public virtual int dock( dynamic S1 = null ) {
			int _default = 0;

			dynamic S0 = null;
			Type turf_type = null;
			Type area_type = null;
			ByTable L0 = null;
			ByTable L1 = null;
			double? rotation = null;
			dynamic A0 = null;
			dynamic T0 = null;
			int? i = null;
			Base_Data T02 = null;
			Ent_Static T1 = null;
			Ent_Static Ts1 = null;
			Ent_Dynamic AM = null;

			_default = this.canDock( S1 );

			if ( _default != 0 ) {
				//throw new Exception( "dock(): shuttle cannot dock" );
				return _default;
			}

			if ( this.canMove() ) {
				return -1;
			}
			this.closePortDoors();
			S0 = this.get_docked();
			turf_type = typeof(Tile_Space);
			area_type = typeof(Zone_Space);

			if ( Lang13.Bool( S0 ) ) {
				
				if ( Lang13.Bool( S0.turf_type ) ) {
					turf_type = S0.turf_type;
				}

				if ( Lang13.Bool( S0.area_type ) ) {
					area_type = S0.area_type;
				}
			}
			L0 = this.return_ordered_turfs( this.x, this.y, this.z, this.dir, this.areaInstance );
			L1 = this.return_ordered_turfs( Lang13.IntNullable( S1.x ), Lang13.IntNullable( S1.y ), Lang13.IntNullable( S1.z ), Lang13.IntNullable( S1.dir ) );
			rotation = ( GlobalFuncs.dir2angle( S1.dir ) ??0) - ( GlobalFuncs.dir2angle( this.dir ) ??0);

			if ( ( rotation ??0) % 90 != 0 ) {
				rotation += ( rotation ??0) % 90;
			}
			rotation = GlobalFuncs.SimplifyDegrees( rotation );

			if ( this.areaInstance.contents.len != 0 ) {
				A0 = Lang13.FindObj( "" + area_type );

				if ( !Lang13.Bool( A0 ) ) {
					A0 = Lang13.Call( area_type, null );
				}

				foreach (dynamic _a in Lang13.Enumerate( L0 )) {
					T0 = _a;
					
					A0.contents.Add( T0 );
				}
			}
			this.roadkill( L1, Convert.ToInt32( S1.dir ) );
			i = null;
			i = 1;

			while (( i ??0) <= L0.len) {
				T02 = L0[i];

				if ( !( T02 != null ) ) {
					
				} else {
					T1 = L1[i];

					if ( !( T1 != null ) ) {
						
					} else {
						
						if ( T02.type != ((dynamic)T02).baseturf ) {
							((dynamic)T02).copyTurf( T1 );
							this.areaInstance.contents.Add( T1 );

							if ( T1 is Tile_Simulated ) {
								Ts1 = T1;
								((dynamic)Ts1).copy_air_with_tile( T02 );
							}

							foreach (dynamic _b in Lang13.Enumerate( T02, typeof(Ent_Dynamic) )) {
								AM = _b;
								
								AM.onShuttleMove( T1, rotation );
							}
						}

						if ( Lang13.Bool( rotation ) ) {
							T1.shuttleRotate( rotation );
						}
						((dynamic)T1).redraw_lighting();
						GlobalVars.SSair.remove_from_active( T1 );
						((dynamic)T1).CalculateAdjacentTurfs();
						GlobalVars.SSair.add_to_active( T1, true );
						((dynamic)T02).ChangeTurf( turf_type );
						((dynamic)T02).redraw_lighting();
						GlobalVars.SSair.remove_from_active( T02 );
						((dynamic)T02).CalculateAdjacentTurfs();
						GlobalVars.SSair.add_to_active( T02, true );
					}
				}
				i++;
			}
			this.loc = S1.loc;
			this.dir = Convert.ToInt32( S1.dir );
			return _default;
		}

		// Function from file: shuttle.dm
		public void enterTransit(  ) {
			dynamic S0 = null;
			Obj_DockingPort_Stationary S1 = null;

			this.previous = null;
			S0 = this.get_docked();
			S1 = this.findTransitDock();

			if ( S1 != null ) {
				
				if ( this.dock( S1 ) != 0 ) {
					GlobalFuncs.warning( "" + ( "shuttle \"" + this.id + "\" could not enter transit space. Docked at " + ( Lang13.Bool( S0 ) ? S0.id : "null" ) + ". Transit dock " + ( S1 != null ? S1.id : "null" ) + "." ) + " in " + "code/modules/shuttle/shuttle.dm" + " at line " + 272 + " src: " + this + " usr: " + Task13.User + "." );
				} else {
					this.previous = S0;
				}
			} else {
				GlobalFuncs.warning( "" + ( "shuttle \"" + this.id + "\" could not enter transit space. S0=" + ( Lang13.Bool( S0 ) ? S0.id : "null" ) + " S1=" + ( S1 != null ? S1.id : "null" ) ) + " in " + "code/modules/shuttle/shuttle.dm" + " at line " + 276 + " src: " + this + " usr: " + Task13.User + "." );
			}
			return;
		}

		// Function from file: shuttle.dm
		public virtual void cancel( dynamic signalOrigin = null ) {
			
			if ( this.mode != 2 ) {
				return;
			}
			this.timer = Game13.time - this.timeLeft( 1 );
			this.mode = 1;
			return;
		}

		// Function from file: shuttle.dm
		public virtual int request( Obj_DockingPort_Stationary S = null, double? coefficient = null, dynamic signalOrigin = null, string reason = null, bool? redAlert = null ) {
			int _default = 0;

			
			if ( this.canDock( S ) != 0 ) {
				_default = 1;
				throw new Exception( "request(): shuttle cannot dock" );
				return 1;
			}

			switch ((int)( this.mode )) {
				case 2:
					
					if ( S == this.destination ) {
						
						if ( Game13.time <= this.timer ) {
							this.timer = Game13.time;
						}
					} else {
						this.destination = S;
						this.timer = Game13.time;
					}
					break;
				case 1:
					
					if ( S == this.destination ) {
						this.timer = Game13.time - this.timeLeft( 1 );
					} else {
						this.destination = S;
						this.timer = Game13.time;
					}
					this.mode = 2;
					break;
				default:
					this.destination = S;
					this.mode = 2;
					this.timer = Game13.time;
					this.enterTransit();
					break;
			}
			return _default;
		}

		// Function from file: shuttle.dm
		public int canDock( dynamic S = null ) {
			
			if ( !( S is Obj_DockingPort_Stationary ) ) {
				return 1;
			}

			if ( S is Obj_DockingPort_Stationary_Transit ) {
				return 0;
			}

			if ( this.dwidth > Convert.ToDouble( S.dwidth ) ) {
				return 2;
			}

			if ( ( this.width ??0) - this.dwidth > Convert.ToDouble( S.width - S.dwidth ) ) {
				return 3;
			}

			if ( this.dheight > Convert.ToDouble( S.dheight ) ) {
				return 4;
			}

			if ( ( this.height ??0) - this.dheight > Convert.ToDouble( S.height - S.dheight ) ) {
				return 5;
			}

			if ( Lang13.Bool( ((Obj_DockingPort)S).get_docked() ) ) {
				return 6;
			}
			return 0;
		}

		// Function from file: shuttle.dm
		public virtual bool canMove(  ) {
			return false;
		}

		// Function from file: shuttle.dm
		public override void initialize(  ) {
			dynamic A = null;

			A = GlobalFuncs.get_area( this );

			if ( A is Zone_Shuttle ) {
				this.areaInstance = A;
			}

			if ( !Lang13.Bool( this.id ) ) {
				this.id = "" + GlobalVars.SSshuttle.mobile.len;
			}

			if ( this.name == "shuttle" ) {
				this.name = "shuttle" + GlobalVars.SSshuttle.mobile.len;
			}

			if ( !Lang13.Bool( this.areaInstance ) ) {
				this.areaInstance = new Zone_Shuttle();
				this.areaInstance.name = this.name;
				this.areaInstance.contents.Add( this.return_ordered_turfs() );
			}
			return;
		}

	}

}