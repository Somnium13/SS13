// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile : Obj_Item {

		public dynamic def_zone = "";
		public dynamic firer = null;
		public bool suppressed = false;
		public double yo = 0;
		public double xo = 0;
		public dynamic current = null;
		public dynamic original = null;
		public dynamic starting = null;
		public ByTable permutated = new ByTable();
		public int? paused = 0;
		public double? p_x = 16;
		public double? p_y = 16;
		public int damage = 10;
		public string damage_type = "brute";
		public bool nodamage = false;
		public string flag = "bullet";
		public string projectile_type = "/obj/item/projectile";
		public int range = 50;
		public int stun = 0;
		public int weaken = 0;
		public bool paralyze = false;
		public int irradiate = 0;
		public int stutter = 0;
		public bool slur = false;
		public int eyeblur = 0;
		public bool drowsy = false;
		public int stamina = 0;
		public int jitter = 0;
		public bool forcedodge = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.unacidable = true;
			this.hitsound = "sound/weapons/pierce.ogg";
			this.pressure_resistance = Double.PositiveInfinity;
			this.icon = "icons/obj/projectiles.dmi";
			this.icon_state = "bullet";
		}

		// Function from file: projectile.dm
		public Obj_Item_Projectile ( dynamic loc = null ) : base( (object)(loc) ) {
			this.permutated = new ByTable();
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: disposal-unit.dm
		public override bool disposalEnterTry(  ) {
			return false;
		}

		// Function from file: projectile.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			base.Crossed( O, (object)(X) );

			if ( O is Mob_Living && O.density && !( this.checkpass( 16 ) != 0 ) ) {
				this.Bump( O, 1 );
			}
			return null;
		}

		// Function from file: projectile.dm
		public override int Process_Spacemove( dynamic movement_dir = null ) {
			movement_dir = movement_dir ?? 0;

			return 1;
		}

		// Function from file: projectile.dm
		public override dynamic Bump( Ent_Static Obstacle = null, dynamic yes = null ) {
			int distance = 0;
			dynamic target_turf = null;
			dynamic permutation = null;
			ByTable mobs_list = null;
			Mob_Living L = null;
			dynamic picked_mob = null;

			
			if ( !Lang13.Bool( yes ) ) {
				return null;
			}

			if ( Lang13.Bool( this.firer ) ) {
				
				if ( Obstacle == this.firer || Obstacle == this.firer.loc && Obstacle is Obj_Mecha ) {
					this.loc = Obstacle.loc;
					return 0;
				}
			}
			distance = Map13.GetDistance( GlobalFuncs.get_turf( Obstacle ), this.starting );
			this.def_zone = GlobalFuncs.ran_zone( this.def_zone, Num13.MaxInt( 100 - distance * 7, 5 ) );
			target_turf = GlobalFuncs.get_turf( Obstacle );
			permutation = Obstacle.bullet_act( this, this.def_zone );

			if ( permutation == -1 || this.forcedodge ) {
				this.loc = target_turf;

				if ( Obstacle != null ) {
					this.permutated.Add( Obstacle );
				}
				return 0;
			} else if ( Obstacle != null && Obstacle.density && !( Obstacle is Mob ) && !Lang13.Bool( Obstacle.flags & 512 ) ) {
				mobs_list = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( target_turf, typeof(Mob_Living) )) {
					L = _a;
					
					mobs_list.Add( L );
				}

				if ( mobs_list.len != 0 ) {
					picked_mob = Rand13.PickFromTable( mobs_list );
					((Ent_Static)picked_mob).bullet_act( this, this.def_zone );
				}
			}
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: projectile.dm
		public virtual bool fire(  ) {
			
			while (this.loc != null) {
				
				if ( !Lang13.Bool( this.paused ) ) {
					
					if ( !Lang13.Bool( this.current ) || this.loc == this.current ) {
						this.current = Map13.GetTile( Num13.MaxInt( 1, Num13.MinInt( ((int)( this.x + this.xo )), Game13.map_size_x ) ), Num13.MaxInt( 1, Num13.MinInt( ((int)( this.y + this.yo )), Game13.map_size_y ) ), this.z );
					}
					Map13.StepTowardsSimple( this, this.current );

					if ( Lang13.Bool( this.original ) && Convert.ToDouble( this.original.layer ) >= 2.75 || this.original is Mob ) {
						
						if ( this.loc == GlobalFuncs.get_turf( this.original ) ) {
							
							if ( !this.permutated.Contains( this.original ) ) {
								this.Bump( this.original, 1 );
							}
						}
					}
					this.Range();
				}
				Task13.Sleep( 1 );
			}
			return false;
		}

		// Function from file: projectile.dm
		public int vol_by_damage(  ) {
			
			if ( this.damage != 0 ) {
				return Num13.MaxInt( 30, Num13.MinInt( ((int)( this.damage * 0.67 )), 100 ) );
			} else {
				return 50;
			}
		}

		// Function from file: projectile.dm
		public virtual dynamic on_hit( Ent_Static target = null, double? blocked = null, dynamic hit_zone = null ) {
			blocked = blocked ?? 0;

			Ent_Static L = null;
			string organ_hit_text = null;
			int? volume = null;
			string reagent_note = null;
			Reagent R = null;

			
			if ( !( target is Mob_Living ) ) {
				return 0;
			}
			L = target;

			if ( blocked != 100 ) {
				organ_hit_text = "";

				if ( Lang13.Bool( ((dynamic)L).has_limbs ) ) {
					organ_hit_text = new Txt( " in " ).the( GlobalFuncs.parse_zone( this.def_zone ) ).item().ToString();
				}

				if ( this.suppressed ) {
					GlobalFuncs.playsound( this.loc, this.hitsound, 5, 1, -1 );
					((dynamic)L).WriteMsg( new Txt( "<span class='userdanger'>You're shot by " ).a( this ).item().item( organ_hit_text ).str( "!</span>" ).ToString() );
				} else {
					
					if ( Lang13.Bool( this.hitsound ) ) {
						volume = this.vol_by_damage();
						GlobalFuncs.playsound( this.loc, this.hitsound, volume, 1, -1 );
					}
					L.visible_message( new Txt( "<span class='danger'>" ).item( L ).str( " is hit by " ).a( this ).item().item( organ_hit_text ).str( "!</span>" ).ToString(), new Txt( "<span class='userdanger'>" ).item( L ).str( " is hit by " ).a( this ).item().item( organ_hit_text ).str( "!</span>" ).ToString() );
				}
				((dynamic)L).on_hit( this.type );
			}

			if ( this.reagents != null && this.reagents.reagent_list != null ) {
				reagent_note = " REAGENTS:";

				foreach (dynamic _a in Lang13.Enumerate( this.reagents.reagent_list, typeof(Reagent) )) {
					R = _a;
					
					reagent_note += R.id + " (";
					reagent_note += String13.NumberToString( R.volume ) + ") ";
				}
			}
			GlobalFuncs.add_logs( this.firer, L, "shot", this, reagent_note );
			return ((dynamic)L).apply_effects( this.stun, this.weaken, this.paralyze, this.irradiate, this.slur, this.stutter, this.eyeblur, this.drowsy, blocked, this.stamina, this.jitter );
		}

		// Function from file: projectile.dm
		public virtual void on_range(  ) {
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: projectile.dm
		public virtual void Range(  ) {
			this.range--;

			if ( this.range <= 0 && this.loc != null ) {
				this.on_range();
			}
			return;
		}

	}

}