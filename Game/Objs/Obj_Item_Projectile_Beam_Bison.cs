// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Beam_Bison : Obj_Item_Projectile_Beam {

		public bool drawn = false;
		public bool tang = false;
		public dynamic last = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.kill_count = 100;
			this.damage = 15;
			this.linear_movement = false;
			this.icon = "icons/obj/lightning.dmi";
			this.icon_state = "heatray";
		}

		public Obj_Item_Projectile_Beam_Bison ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: beams.dm
		public override dynamic Bump( Obj Obstacle = null, dynamic yes = null ) {
			Obj M = null;

			
			if ( Obstacle == this.firer ) {
				this.loc = Obstacle.loc;
				return 0;
			}

			if ( Lang13.Bool( this.firer ) && Obstacle is Mob_Living ) {
				M = Obstacle;
				Obstacle.bullet_act( this, this.def_zone );
				this.loc = Obstacle.loc;
				this.permutated.Add( Obstacle );
				this.visible_message( "<span class='warning'>" + Obstacle.name + " is hit by the " + this.name + " in the " + GlobalFuncs.parse_zone( this.def_zone ) + "!</span>" );

				if ( this.firer is Mob ) {
					GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<font color='red'>" + GlobalFuncs.key_name( this.firer ) + " shot " + GlobalFuncs.key_name( M ) + " with a " + this.type + "</font>" ) ) );
					((dynamic)M).attack_log += "[" + GlobalFuncs.time_stamp() + "] <b>" + GlobalFuncs.key_name( this.firer ) + "</b> shot <b>" + GlobalFuncs.key_name( M ) + "</b> with a <b>" + this.type + "</b>";
					this.firer.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <b>" + GlobalFuncs.key_name( this.firer ) + "</b> shot <b>" + GlobalFuncs.key_name( M ) + "</b> with a <b>" + this.type + "</b>" );
					GlobalFuncs.msg_admin_attack( "" + GlobalFuncs.key_name( this.firer ) + " shot " + GlobalFuncs.key_name( M ) + " with a " + this.type + " (<A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" + this.firer.x + ";Y=" + this.firer.y + ";Z=" + this.firer.z + "'>JMP</a>)" );

					if ( !( this.firer is Mob_Living_Carbon ) ) {
						((dynamic)M).LAssailant = null;
					} else {
						((dynamic)M).LAssailant = this.firer;
					}
				} else {
					((dynamic)M).attack_log += "[" + GlobalFuncs.time_stamp() + "] <b>UNKNOWN/(no longer exists)</b> shot <b>" + GlobalFuncs.key_name( M ) + "</b> with a <b>" + this.type + "</b>";
					GlobalFuncs.msg_admin_attack( "UNKNOWN/(no longer exists) shot " + GlobalFuncs.key_name( M ) + " with a " + this.type + " (<A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" + this.firer.x + ";Y=" + this.firer.y + ";Z=" + this.firer.z + "'>JMP</a>)" );
					GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<font color='red'>UNKNOWN/(no longer exists) shot " + GlobalFuncs.key_name( M ) + " with a " + this.type + "</font>" ) ) );
				}
				return 1;
			} else {
				return base.Bump( Obstacle );
			}
		}

		// Function from file: beams.dm
		public override void bullet_die(  ) {
			this.draw_ray( this.loc );
			base.bullet_die();
			return;
		}

		// Function from file: beams.dm
		public override dynamic process(  ) {
			Ent_Static lastposition = null;
			Tile step = null;
			Tile step2 = null;
			Tile step3 = null;
			Tile step4 = null;

			lastposition = this.loc;
			this.target = GlobalFuncs.get_turf( this.original );
			this.dist_x = Math.Abs( Convert.ToDouble( this.target.x - this.x ) );
			this.dist_y = Math.Abs( Convert.ToDouble( this.target.y - this.y ) );

			if ( Convert.ToDouble( this.target.x ) > this.x ) {
				this.dx = GlobalVars.EAST;
			} else {
				this.dx = GlobalVars.WEST;
			}

			if ( Convert.ToDouble( this.target.y ) > this.y ) {
				this.dy = GlobalVars.NORTH;
			} else {
				this.dy = GlobalVars.SOUTH;
			}

			if ( this.dist_x > this.dist_y ) {
				this.error = this.dist_x / 2 - this.dist_y;
				Task13.Schedule( 0, (Task13.Closure)(() => {
					
					while (this != null && this.loc != null) {
						
						if ( this.error < 0 ) {
							step = Map13.GetStep( this, ((int)( this.dy ??0 )) );

							if ( !( step != null ) ) {
								break;
							}
							this.Move( step );
							this.error += this.dist_x;
						} else {
							step2 = Map13.GetStep( this, ((int)( this.dx ??0 )) );

							if ( !( step2 != null ) ) {
								break;
							}
							this.Move( step2 );
							this.error -= this.dist_y;
						}

						if ( this.loc == null ) {
							this.draw_ray( lastposition );
							return;
						}

						if ( lastposition == this.loc ) {
							this.kill_count = 0;
						}
						lastposition = this.loc;

						if ( ( this.kill_count ??0) < 1 ) {
							this.draw_ray( lastposition );
							GlobalFuncs.returnToPool( this );
							return;
						}
						this.kill_count--;

						if ( !this.bumped && !( this.original is Tile ) ) {
							
							if ( this.loc == this.target ) {
								
								if ( !this.permutated.Contains( this.original ) ) {
									this.draw_ray( this.target );
									this.Bump( this.original );
								}
							}
						}
					}
					return;
				}));
			} else {
				this.error = this.dist_y / 2 - this.dist_x;
				Task13.Schedule( 0, (Task13.Closure)(() => {
					
					while (this != null && this.loc != null) {
						
						if ( this.error < 0 ) {
							step3 = Map13.GetStep( this, ((int)( this.dx ??0 )) );

							if ( !( step3 != null ) ) {
								break;
							}
							this.Move( step3 );
							this.error += this.dist_y;
						} else {
							step4 = Map13.GetStep( this, ((int)( this.dy ??0 )) );

							if ( !( step4 != null ) ) {
								break;
							}
							this.Move( step4 );
							this.error -= this.dist_x;
						}

						if ( this.loc == null ) {
							this.draw_ray( lastposition );
							return;
						}

						if ( lastposition == this.loc ) {
							this.kill_count = 0;
						}
						lastposition = this.loc;

						if ( ( this.kill_count ??0) < 1 ) {
							this.draw_ray( lastposition );
							GlobalFuncs.returnToPool( this );
							return;
						}
						this.kill_count--;

						if ( !this.bumped && !( this.original is Tile ) ) {
							
							if ( this.loc == GlobalFuncs.get_turf( this.original ) ) {
								
								if ( !this.permutated.Contains( this.original ) ) {
									this.draw_ray( this.target );
									this.Bump( this.original );
								}
							}
						}
					}
					return;
				}));
			}
			return null;
		}

		// Function from file: beams.dm
		public void draw_ray( dynamic lastloc = null ) {
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
			int timer_total = 0;
			double increment = 0;
			double current_timer = 0;
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

			
			if ( this.drawn ) {
				return;
			}
			this.drawn = true;
			curr = lastloc;

			if ( !Lang13.Bool( this.firer ) ) {
				this.firer = this.starting;
			}
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
			T = GlobalFuncs.get_turf( this.firer );
			timer_total = 16;
			increment = timer_total / Num13.MaxInt( 1, Num13.Floor( length / 32 ) );
			current_timer = 5;

			while (N < length + 16) {
				
				if ( ( count ??0) >= ( this.kill_count ??0) ) {
					break;
				}
				count++;
				X = GlobalFuncs.getFromPool( typeof(Obj_Effect_Overlay_Beam), T, current_timer, 1 );
				((dynamic)X).BeamSource = this;
				current_timer += increment;

				if ( N + 64 > length + 16 && N + 32 <= length + 16 ) {
					((dynamic)X).icon = Iend;
				} else if ( N == 0 ) {
					((dynamic)X).icon = Istart;
				} else if ( N + 32 > length + 16 ) {
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

				if ( TT == this.firer.loc ) {
					
				}
				N += 32;
			}
			return;
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