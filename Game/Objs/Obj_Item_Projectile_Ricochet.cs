// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Ricochet : Obj_Item_Projectile {

		public double? pos_from = 4;
		public double? pos_to = 2;
		public bool bouncin = false;
		public ByTable ricochet_bump = new ByTable(new object [] { 
											typeof(Obj_Effect_Blob), 
											typeof(Obj_Machinery_Turret), 
											typeof(Obj_Machinery_Turretcover), 
											typeof(Obj_Mecha), 
											typeof(Obj_Structure_ReagentDispensers_Fueltank), 
											typeof(Obj_Structure_Bed_Chair_Vehicle)
										 });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage_type = "fire";
			this.flag = "laser";
			this.kill_count = 100;
			this.damage = 30;
			this.linear_movement = false;
			this.custom_impact = true;
			this.icon = "icons/obj/projectiles_experimental.dmi";
			this.icon_state = "ricochet_head";
			this.layer = 13;
		}

		public Obj_Item_Projectile_Ricochet ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: ricochet.dm
		public override void process_step(  ) {
			int? i = null;

			
			if ( this.loc != null ) {
				
				if ( ( this.kill_count ??0) < 1 ) {
					this.bulletdies();
				}
				this.kill_count--;
				i = null;
				i = 1;

				while (( i ??0) <= 2) {
					this.ricochet_movement();
					i++;
				}
				this.update_icon();
				Task13.Sleep( 1 );
			}
			return;
		}

		// Function from file: ricochet.dm
		public override dynamic Bump( Obj Obstacle = null, dynamic yes = null ) {
			Obj H = null;
			Tile T = null;

			
			if ( this.bumped ) {
				return 0;
			}
			this.bumped = true;

			if ( Obstacle != null ) {
				
				if ( Obstacle is Tile || Obstacle is Obj_Machinery_Door && Obstacle.opacity ) {
					this.bounce();
				} else if ( Obstacle is Mob_Living ) {
					
					if ( Obstacle is Mob_Living_Carbon_Human ) {
						H = Obstacle;

						if ( ((dynamic)H).wear_suit is Obj_Item_Clothing_Suit_Armor_Laserproof ) {
							this.visible_message( new Txt( "<span class='warning'>" ).the( this.name ).item().str( " bounces off " ).the( Obstacle.name ).item().str( "'s " ).item( ((dynamic)H).wear_suit ).str( "!</span>" ).ToString() );
							this.bounce();
						} else {
							this.visible_message( new Txt( "<span class='warning'>" ).the( Obstacle.name ).item().str( " is hit by " ).the( this.name ).item().str( " in the " ).item( GlobalFuncs.parse_zone( this.def_zone ) ).str( "!</span>" ).ToString() );
							Obstacle.bullet_act( this, this.def_zone );
							this.admin_warn( Obstacle );
							this.bulletdies( Obstacle );
						}
					} else {
						this.visible_message( new Txt( "<span class='warning'>" ).the( Obstacle.name ).item().str( " is hit by " ).the( this.name ).item().str( " in the " ).item( GlobalFuncs.parse_zone( this.def_zone ) ).str( "!</span>" ).ToString() );
						Obstacle.bullet_act( this, this.def_zone );
						this.admin_warn( Obstacle );
						this.bulletdies( Obstacle );
					}
				} else if ( GlobalFuncs.is_type_in_list( Obstacle, this.ricochet_bump ) ) {
					this.visible_message( new Txt( "<span class='warning'>" ).the( Obstacle.name ).item().str( " is hit by " ).the( this.name ).item().str( "!</span>" ).ToString() );
					Obstacle.bullet_act( this );
					this.bulletdies( Obstacle );
				} else if ( ( Obstacle is Obj_Structure_Window || Obstacle is Obj_Machinery_Door_Window || Obstacle is Obj_Machinery_Door_Firedoor_BorderOnly ) && Obstacle.loc == this.loc ) {
					T = Map13.GetStep( this, ((int)( this.pos_to ??0 )) );

					if ( T.density ) {
						this.bounce();
					} else {
						this.ricochet_jump();
					}
				} else {
					this.ricochet_jump();
				}
			}
			return null;
		}

		// Function from file: ricochet.dm
		public void ricochet_jump(  ) {
			
			if ( this.x == 1 || this.x == Game13.map_size_x || this.y == 1 || this.y == Game13.map_size_y ) {
				this.bulletdies();
				return;
			}
			this.ricochet_step( false );
			return;
		}

		// Function from file: ricochet.dm
		public void ricochet_movement(  ) {
			
			if ( this.x == 1 || this.x == Game13.map_size_x || this.y == 1 || this.y == Game13.map_size_y ) {
				this.bulletdies();
				return;
			}
			this.ricochet_step();
			this.bumped = false;
			this.bouncin = false;
			return;
		}

		// Function from file: ricochet.dm
		public void ricochet_step( bool? phase = null ) {
			phase = phase ?? true;

			Obj_Structure_RicochetTrail trail = null;
			Tile T = null;

			trail = new Obj_Structure_RicochetTrail( this.loc );

			switch ((int?)( this.pos_to )) {
				case 1:
					
					if ( this.pos_from == GlobalVars.WEST ) {
						trail.dir = ((int)( GlobalVars.NORTH ));
					} else {
						trail.dir = ((int)( GlobalVars.EAST ));
					}
					break;
				case 2:
					
					if ( this.pos_from == GlobalVars.WEST ) {
						trail.dir = ((int)( GlobalVars.WEST ));
					} else {
						trail.dir = ((int)( GlobalVars.SOUTH ));
					}
					break;
				case 4:
					
					if ( this.pos_from == GlobalVars.NORTH ) {
						trail.dir = ((int)( GlobalVars.EAST ));
					} else {
						trail.dir = ((int)( GlobalVars.SOUTH ));
					}
					break;
				case 8:
					
					if ( this.pos_from == GlobalVars.NORTH ) {
						trail.dir = ((int)( GlobalVars.NORTH ));
					} else {
						trail.dir = ((int)( GlobalVars.WEST ));
					}
					break;
			}

			if ( phase == true ) {
				this.current = Map13.GetStep( this, ((int)( this.pos_to ??0 )) );
				Map13.StepTowardsSimple( this, this.current );
			} else {
				T = Map13.GetStep( this, ((int)( this.pos_to ??0 )) );
				this.loc = T;
			}

			if ( this.bumped && !( phase == true ) || this.bouncin ) {
				return;
			}

			switch ((int?)( this.pos_to )) {
				case 1:
					
					if ( this.pos_from == GlobalVars.WEST ) {
						this.pos_to = GlobalVars.EAST;
					} else {
						this.pos_to = GlobalVars.WEST;
					}
					this.pos_from = GlobalVars.SOUTH;
					break;
				case 2:
					
					if ( this.pos_from == GlobalVars.WEST ) {
						this.pos_to = GlobalVars.EAST;
					} else {
						this.pos_to = GlobalVars.WEST;
					}
					this.pos_from = GlobalVars.NORTH;
					break;
				case 4:
					
					if ( this.pos_from == GlobalVars.NORTH ) {
						this.pos_to = GlobalVars.SOUTH;
					} else {
						this.pos_to = GlobalVars.NORTH;
					}
					this.pos_from = GlobalVars.WEST;
					break;
				case 8:
					
					if ( this.pos_from == GlobalVars.NORTH ) {
						this.pos_to = GlobalVars.SOUTH;
					} else {
						this.pos_to = GlobalVars.NORTH;
					}
					this.pos_from = GlobalVars.EAST;
					break;
			}
			return;
		}

		// Function from file: ricochet.dm
		public void bulletdies( Obj A = null ) {
			Game_Data impact = null;

			impact = GlobalFuncs.getFromPool( typeof(Obj_Effect_Overlay_Beam), GlobalFuncs.get_turf( this ), 10, 0, "icons/obj/projectiles_impacts.dmi" );

			if ( A != null ) {
				
				switch ((int)( Map13.GetDistance( this, A ) )) {
					case 1:
						((dynamic)impact).pixel_y = 16;
						break;
					case 2:
						((dynamic)impact).pixel_y = -16;
						break;
					case 4:
						((dynamic)impact).pixel_x = 16;
						break;
					case 8:
						((dynamic)impact).pixel_x = -16;
						break;
				}
			}
			((dynamic)impact).icon_state = "ricochet_hit";
			GlobalFuncs.playsound( impact, "sound/weapons/pierce.ogg", 30, 1 );
			Task13.Schedule( 0, (Task13.Closure)(() => {
				this.density = false;
				this.invisibility = 101;
				GlobalFuncs.returnToPool( this );
				this.OnDeath();
				return;
			}));
			return;
		}

		// Function from file: ricochet.dm
		public void bounce(  ) {
			Obj_Structure_RicochetBump bump = null;

			this.bouncin = true;
			bump = new Obj_Structure_RicochetBump( this.loc );
			bump.dir = ((int)( this.pos_to ??0 ));
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/metal_impact.ogg", 50, 1 );

			switch ((int?)( this.pos_to )) {
				case 1:
					
					if ( this.pos_from == GlobalVars.WEST ) {
						this.pos_to = GlobalVars.EAST;
					} else {
						this.pos_to = GlobalVars.WEST;
					}
					this.pos_from = GlobalVars.NORTH;
					break;
				case 2:
					
					if ( this.pos_from == GlobalVars.WEST ) {
						this.pos_to = GlobalVars.EAST;
					} else {
						this.pos_to = GlobalVars.WEST;
					}
					this.pos_from = GlobalVars.SOUTH;
					break;
				case 4:
					
					if ( this.pos_from == GlobalVars.NORTH ) {
						this.pos_to = GlobalVars.SOUTH;
					} else {
						this.pos_to = GlobalVars.NORTH;
					}
					this.pos_from = GlobalVars.EAST;
					break;
				case 8:
					
					if ( this.pos_from == GlobalVars.NORTH ) {
						this.pos_to = GlobalVars.SOUTH;
					} else {
						this.pos_to = GlobalVars.NORTH;
					}
					this.pos_from = GlobalVars.WEST;
					break;
			}
			return;
		}

		// Function from file: ricochet.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			switch ((int?)( this.pos_to )) {
				case 1:
					
					if ( this.pos_from == GlobalVars.WEST ) {
						this.dir = ((int)( GlobalVars.NORTHWEST ));
					} else {
						this.dir = ((int)( GlobalVars.EAST ));
					}
					break;
				case 2:
					
					if ( this.pos_from == GlobalVars.WEST ) {
						this.dir = ((int)( GlobalVars.WEST ));
					} else {
						this.dir = ((int)( GlobalVars.SOUTHEAST ));
					}
					break;
				case 4:
					
					if ( this.pos_from == GlobalVars.NORTH ) {
						this.dir = ((int)( GlobalVars.NORTHEAST ));
					} else {
						this.dir = ((int)( GlobalVars.SOUTH ));
					}
					break;
				case 8:
					
					if ( this.pos_from == GlobalVars.NORTH ) {
						this.dir = ((int)( GlobalVars.NORTH ));
					} else {
						this.dir = ((int)( GlobalVars.SOUTHWEST ));
					}
					break;
			}
			return null;
		}

		// Function from file: ricochet.dm
		public override bool OnFired(  ) {
			dynamic T1 = null;
			dynamic T2 = null;
			int X = 0;
			int Y = 0;
			int X_spawn = 0;
			int Y_spawn = 0;
			Tile newspawn = null;

			T1 = GlobalFuncs.get_turf( this.shot_from );
			T2 = GlobalFuncs.get_turf( this.original );
			this.shot_from.update_icon();
			X = Convert.ToInt32( T2.x - T1.x );
			Y = Convert.ToInt32( T2.y - T1.y );
			X_spawn = 0;
			Y_spawn = 0;

			if ( X > 0 ) {
				
				if ( Y > 0 ) {
					
					if ( X > Y ) {
						this.pos_from = GlobalVars.WEST;
						this.pos_to = GlobalVars.NORTH;
						X_spawn = 1;
					} else if ( X < Y ) {
						this.pos_from = GlobalVars.SOUTH;
						this.pos_to = GlobalVars.EAST;
						Y_spawn = 1;
					} else if ( Rand13.PercentChance( 50 ) ) {
						this.pos_from = GlobalVars.WEST;
						this.pos_to = GlobalVars.NORTH;
						X_spawn = 1;
					} else {
						this.pos_from = GlobalVars.SOUTH;
						this.pos_to = GlobalVars.EAST;
						Y_spawn = 1;
					}
				} else if ( Y < 0 ) {
					
					if ( X > Y * -1 ) {
						this.pos_from = GlobalVars.WEST;
						this.pos_to = GlobalVars.SOUTH;
						X_spawn = 1;
					} else if ( X < Y * -1 ) {
						this.pos_from = GlobalVars.NORTH;
						this.pos_to = GlobalVars.EAST;
						Y_spawn = -1;
					} else if ( Rand13.PercentChance( 50 ) ) {
						this.pos_from = GlobalVars.WEST;
						this.pos_to = GlobalVars.SOUTH;
						X_spawn = 1;
					} else {
						this.pos_from = GlobalVars.NORTH;
						this.pos_to = GlobalVars.EAST;
						Y_spawn = -1;
					}
				} else if ( Y == 0 ) {
					this.pos_from = GlobalVars.WEST;
					X_spawn = 1;

					if ( Rand13.PercentChance( 50 ) ) {
						this.pos_to = GlobalVars.NORTH;
					} else {
						this.pos_to = GlobalVars.SOUTH;
					}
				}
			} else if ( X < 0 ) {
				
				if ( Y > 0 ) {
					
					if ( X * -1 > Y ) {
						this.pos_from = GlobalVars.EAST;
						this.pos_to = GlobalVars.NORTH;
						X_spawn = -1;
					} else if ( X * -1 < Y ) {
						this.pos_from = GlobalVars.SOUTH;
						this.pos_to = GlobalVars.WEST;
						Y_spawn = 1;
					} else if ( Rand13.PercentChance( 50 ) ) {
						this.pos_from = GlobalVars.EAST;
						this.pos_to = GlobalVars.NORTH;
						X_spawn = -1;
					} else {
						this.pos_from = GlobalVars.SOUTH;
						this.pos_to = GlobalVars.WEST;
						Y_spawn = 1;
					}
				} else if ( Y < 0 ) {
					
					if ( X * -1 > Y * -1 ) {
						this.pos_from = GlobalVars.EAST;
						this.pos_to = GlobalVars.SOUTH;
						X_spawn = -1;
					} else if ( X * -1 < Y * -1 ) {
						this.pos_from = GlobalVars.NORTH;
						this.pos_to = GlobalVars.WEST;
						Y_spawn = -1;
					} else if ( Rand13.PercentChance( 50 ) ) {
						this.pos_from = GlobalVars.EAST;
						this.pos_to = GlobalVars.SOUTH;
						X_spawn = -1;
					} else {
						this.pos_from = GlobalVars.NORTH;
						this.pos_to = GlobalVars.WEST;
						Y_spawn = -1;
					}
				} else if ( Y == 0 ) {
					this.pos_from = GlobalVars.EAST;
					X_spawn = -1;

					if ( Rand13.PercentChance( 50 ) ) {
						this.pos_to = GlobalVars.NORTH;
					} else {
						this.pos_to = GlobalVars.SOUTH;
					}
				}
			} else if ( X == 0 ) {
				
				if ( Y > 0 ) {
					Y_spawn = 1;
					this.pos_from = GlobalVars.SOUTH;

					if ( Rand13.PercentChance( 50 ) ) {
						this.pos_to = GlobalVars.EAST;
					} else {
						this.pos_to = GlobalVars.WEST;
					}
				} else if ( Y < 0 ) {
					Y_spawn = -1;
					this.pos_from = GlobalVars.NORTH;

					if ( Rand13.PercentChance( 50 ) ) {
						this.pos_to = GlobalVars.EAST;
					} else {
						this.pos_to = GlobalVars.WEST;
					}
				}
			} else {
				this.OnDeath();
				this.loc = null;
				GlobalFuncs.returnToPool( this );
				return false;
			}
			newspawn = Map13.GetTile( Convert.ToInt32( T1.x + X_spawn ), Convert.ToInt32( T1.y + Y_spawn ), this.z );
			this.loc = newspawn;
			this.update_icon();
			base.OnFired();
			return false;
		}

	}

}