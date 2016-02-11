// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Beam_Lightning : Obj_Item_Projectile_Beam {

		public double tang = 0;
		public dynamic last = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 0;
			this.stun = 10;
			this.weaken = 10;
			this.stutter = 50;
			this.eyeblur = 50;
			this.kill_count = 12;
			this.icon = "icons/obj/lightning.dmi";
			this.icon_state = "lightning";
		}

		public Obj_Item_Projectile_Beam_Lightning ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: beams.dm
		public override bool on_hit( dynamic atarget = null, int? blocked = null ) {
			blocked = blocked ?? 0;

			dynamic M = null;

			
			if ( atarget is Mob_Living ) {
				M = atarget;
				((Mob)M).playsound_local( this, "explosion", 50, 1 );
			}
			base.on_hit( (object)(atarget), blocked );
			return false;
		}

		// Function from file: beams.dm
		public override dynamic process(  ) {
			bool first = false;
			bool broke = false;
			bool broken = false;
			dynamic curr = null;
			double Angle = 0;
			Icon I = null;
			Icon Istart = null;
			Icon Iend = null;
			double DX = 0;
			double DY = 0;
			int N = 0;
			int length = 0;
			int? count = null;
			dynamic T = null;
			ByTable ouroverlays = null;
			Game_Data X = null;
			int? Pixel_x = null;
			int? Pixel_y = null;
			int? a = null;
			int? a2 = null;
			int? a3 = null;
			int? a4 = null;
			int x_increm = 0;
			int y_increm = 0;
			dynamic TT = null;
			Ent_Static O = null;
			Mob_Living O2 = null;
			Ent_Static thing = null;
			bool tS = false;
			dynamic f = null;
			Ent_Static thing2 = null;

			this.icon_state = "lightning";
			first = true;
			broke = false;
			curr = this.current;
			Angle = Num13.Floor( GlobalFuncs.Get_Angle( this.firer, curr ) );
			I = new Icon( "icons/obj/lightning.dmi", this.icon_state );
			Istart = new Icon( "icons/obj/lightning.dmi", "" + this.icon_state + "start" );
			Iend = new Icon( "icons/obj/lightning.dmi", "" + this.icon_state + "end" );
			I.Turn( Angle + 45 );
			Istart.Turn( Angle + 45 );
			Iend.Turn( Angle + 45 );
			DX = Convert.ToDouble( curr.x * 32 + curr.pixel_x - ( this.firer.x * 32 + this.firer.pixel_x ) );
			DY = Convert.ToDouble( curr.y * 32 + curr.pixel_y - ( this.firer.y * 32 + this.firer.pixel_y ) );
			N = 0;
			length = Num13.Floor( Math.Sqrt( Math.Pow( DX, 2 ) + Math.Pow( DY, 2 ) ) );
			count = 0;
			T = GlobalFuncs.get_turf( this );
			ouroverlays = new ByTable();
			Task13.Schedule( 0, (Task13.Closure)(() => {
				
				while (N < length) {
					
					if ( ( count ??0) >= ( this.kill_count ??0) ) {
						break;
					}
					count++;
					X = GlobalFuncs.getFromPool( typeof(Obj_Effect_Overlay_Beam_Persist), T );
					((dynamic)X).BeamSource = this;
					ouroverlays.Add( X );

					if ( N + 64 > length && N + 32 <= length ) {
						((dynamic)X).icon = Iend;
					} else if ( N == 0 ) {
						((dynamic)X).icon = Istart;
					} else if ( N + 32 > length ) {
						((dynamic)X).icon = null;
					} else {
						((dynamic)X).icon = I;
					}
					Pixel_x = Num13.Floor( Math.Sin( Angle ) + Math.Sin( Angle ) * ( N + 16 ) * 32 / 32 );
					Pixel_y = Num13.Floor( Math.Cos( Angle ) + Math.Cos( Angle ) * ( N + 16 ) * 32 / 32 );

					if ( DX == 0 ) {
						Pixel_x = 0;
					}

					if ( DY == 0 ) {
						Pixel_y = 0;
					}

					if ( ( Pixel_x ??0) > 32 ) {
						a = null;
						a = 0;

						while (( a ??0) <= ( Pixel_x ??0)) {
							((dynamic)X).x++;
							Pixel_x -= 32;
							a += 32;
						}
					}

					if ( ( Pixel_x ??0) < -32 ) {
						a2 = null;
						a2 = 0;

						while (( a2 ??0) >= ( Pixel_x ??0)) {
							((dynamic)X).x--;
							Pixel_x += 32;
							a2 -= 32;
						}
					}

					if ( ( Pixel_y ??0) > 32 ) {
						a3 = null;
						a3 = 0;

						while (( a3 ??0) <= ( Pixel_y ??0)) {
							((dynamic)X).y++;
							Pixel_y -= 32;
							a3 += 32;
						}
					}

					if ( ( Pixel_y ??0) < -32 ) {
						a4 = null;
						a4 = 0;

						while (( a4 ??0) >= ( Pixel_y ??0)) {
							((dynamic)X).y--;
							Pixel_y += 32;
							a4 -= 32;
						}
					}
					x_increm = 0;
					y_increm = 0;

					while (( Pixel_x ??0) >= 32 || ( Pixel_x ??0) <= -32) {
						
						if ( ( Pixel_x ??0) > 0 ) {
							Pixel_x -= 32;
							x_increm++;
						} else {
							Pixel_x += 32;
							x_increm--;
						}
					}

					while (( Pixel_y ??0) >= 32 || ( Pixel_y ??0) <= -32) {
						
						if ( ( Pixel_y ??0) > 0 ) {
							Pixel_y -= 32;
							y_increm++;
						} else {
							Pixel_y += 32;
							y_increm--;
						}
					}
					((dynamic)X).x += x_increm;
					((dynamic)X).y += y_increm;
					((dynamic)X).pixel_x = Pixel_x;
					((dynamic)X).pixel_y = Pixel_y;
					TT = GlobalFuncs.get_turf( ((dynamic)X).loc );

					while (( TT.timestopped || this.timestopped || Lang13.Bool( ((dynamic)X).timestopped ) ) && Lang13.Bool( count )) {
						Task13.Sleep( 2 );
					}

					if ( TT == this.firer.loc ) {
						
					} else {
						
						if ( TT.density ) {
							GlobalFuncs.qdel( X );
							X = null;
							break;
						}

						foreach (dynamic _a in Lang13.Enumerate( TT, typeof(Ent_Static) )) {
							O = _a;
							

							if ( !O.CanPass( this ) ) {
								GlobalFuncs.qdel( X );
								broke = true;
								break;
							}
						}

						foreach (dynamic _b in Lang13.Enumerate( TT.contents, typeof(Mob_Living) )) {
							O2 = _b;
							

							if ( O2 is Mob_Living ) {
								
								if ( O2.density ) {
									GlobalFuncs.qdel( X );
									X = null;
									broke = true;
									break;
								}
							}
						}

						if ( broke ) {
							
							if ( X != null ) {
								GlobalFuncs.qdel( X );
								X = null;
							}
							break;
						}
					}
					N += 32;
				}
				return;
			}));
			Task13.Schedule( 10, (Task13.Closure)(() => {
				
				foreach (dynamic _c in Lang13.Enumerate( ouroverlays, typeof(Ent_Static) )) {
					thing = _c;
					

					if ( !thing.timestopped && !thing.loc.timestopped ) {
						ouroverlays.Remove( thing );
						GlobalFuncs.returnToPool( thing );
					}
				}
				return;
			}));
			Task13.Schedule( 0, (Task13.Closure)(() => {
				tS = false;

				while (this.loc != null) {
					
					if ( tS ) {
						tS = false;
						this.timestopped = this.loc.timestopped;
					}

					while (( this.loc.timestopped || this.timestopped ) && !first) {
						tS = true;
						Task13.Sleep( 3 );
					}

					if ( first ) {
						this.icon = GlobalVars.midicon;

						if ( this.timestopped || this.loc.timestopped ) {
							tS = true;
							this.timestopped = false;
						}
					}

					if ( !Lang13.Bool( this.current ) || this.loc == this.current ) {
						broken = true;
						this.icon = GlobalVars.endicon;
						this.tang = this.adjustAngle( GlobalFuncs.get_angle( this.original, this.current ) );

						if ( this.tang > 180 ) {
							this.tang -= 180;
						} else {
							this.tang += 180;
						}
						this.icon_state = "" + this.tang;
						f = this.current;

						if ( Lang13.Bool( f ) && f is Tile_Simulated_Floor ) {
							((Tile_Simulated_Floor)f).break_tile();
							((Tile)f).hotspot_expose( 1000, 2500, null, true );
						}
					}

					if ( this.x == 1 || this.x == Game13.map_size_x || this.y == 1 || this.y == Game13.map_size_y ) {
						broken = true;
						return;
					}

					if ( ( this.kill_count ??0) < 1 ) {
						broken = true;
					}
					this.kill_count--;

					if ( !this.bumped && !( this.original is Tile ) ) {
						
						if ( this.loc == GlobalFuncs.get_turf( this.original ) ) {
							
							if ( !this.permutated.Contains( this.original ) ) {
								this.icon = GlobalVars.endicon;
							}

							if ( !broken ) {
								this.tang = this.adjustAngle( GlobalFuncs.get_angle( this.original, this.current ) );

								if ( this.tang > 180 ) {
									this.tang -= 180;
								} else {
									this.tang += 180;
								}
								this.icon_state = "" + this.tang;
							}
							this.Bump( this.original );
						}
					}
					first = false;

					if ( broken ) {
						break;
					} else {
						this.last = GlobalFuncs.get_turf( this.loc );
						Map13.StepTowardsSimple( this, this.current );

						if ( this.loc != this.current ) {
							this.tang = this.adjustAngle( GlobalFuncs.get_angle( this.loc, this.current ) );
						}
						this.icon_state = "" + this.tang;
					}
				}

				if ( ouroverlays.len != 0 ) {
					Task13.Sleep( 10 );

					foreach (dynamic _d in Lang13.Enumerate( ouroverlays, typeof(Ent_Static) )) {
						thing2 = _d;
						
						ouroverlays.Remove( thing2 );
						GlobalFuncs.returnToPool( thing2 );
					}
				}
				GlobalFuncs.returnToPool( this );
				return;
			}));
			return null;
		}

		// Function from file: beams.dm
		public double adjustAngle( double angle = 0 ) {
			angle = Num13.Floor( angle ) + 45;

			if ( angle > 180 ) {
				angle -= 180;
			} else {
				angle += 180;
			}

			if ( !( angle != 0 ) ) {
				angle = 1;
			}
			return angle;
		}

	}

}