// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Grille : Obj_Structure {

		public dynamic health = 20;
		public bool broken = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.siemens_coefficient = 1;
			this.pressure_resistance = 506.625;
			this.explosion_resistance = 5;
			this.icon_state = "grille";
			this.layer = 2.9;
		}

		public Obj_Structure_Grille ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: grille.dm
		public override bool fire_act( GasMixture air = null, double? exposed_temperature = null, int exposed_volume = 0 ) {
			
			if ( ( exposed_temperature ??0) > 1773.1500244140625 ) {
				this.health -= 1;
				this.healthcheck();
			}
			base.fire_act( air, exposed_temperature, exposed_volume );
			return false;
		}

		// Function from file: grille.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			int dir_to_set = 0;
			Obj_Structure_Window P = null;
			Obj_Structure_Window P2 = null;
			dynamic G = null;
			dynamic WD = null;
			dynamic ST = null;

			((Mob)b).delayNextAttack( 8 );

			if ( a is Obj_Item_Weapon_Wirecutters ) {
				
				if ( !this.shock( b, 100 ) ) {
					GlobalFuncs.playsound( this.loc, "sound/items/Wirecutter.ogg", 100, 1 );
					GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Rods), GlobalFuncs.get_turf( this ), ( this.broken ? 1 : 2 ) );
					GlobalFuncs.returnToPool( this );
					return null;
				}
				return null;
			} else if ( a is Obj_Item_Weapon_Screwdriver && ( this.loc is Tile_Simulated || Lang13.Bool( this.anchored ) ) ) {
				
				if ( !this.shock( b, 90 ) ) {
					GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 100, 1 );
					this.anchored = !Lang13.Bool( this.anchored );
					((Ent_Static)b).visible_message( "<span class='notice'>" + b + " " + ( Lang13.Bool( this.anchored ) ? "fastens" : "unfastens" ) + " the grille " + ( Lang13.Bool( this.anchored ) ? "to" : "from" ) + " the floor.</span>", "<span class='notice'>You " + ( Lang13.Bool( this.anchored ) ? "fasten" : "unfasten" ) + " the grille " + ( Lang13.Bool( this.anchored ) ? "to" : "from" ) + " the floor.</span>" );
					return null;
				}
			} else if ( a is Obj_Item_Stack_Sheet_Glass ) {
				
				if ( this.loc == b.loc ) {
					dir_to_set = Convert.ToInt32( b.dir );
				} else if ( this.x == Convert.ToInt32( b.x ) || this.y == Convert.ToInt32( b.y ) ) {
					
					if ( this.x == Convert.ToInt32( b.x ) ) {
						
						if ( this.y > Convert.ToDouble( b.y ) ) {
							dir_to_set = 2;
						} else {
							dir_to_set = 1;
						}
					} else if ( this.y == Convert.ToInt32( b.y ) ) {
						
						if ( this.x > Convert.ToDouble( b.x ) ) {
							dir_to_set = 8;
						} else {
							dir_to_set = 4;
						}
					}
				} else {
					GlobalFuncs.to_chat( b, "<span class='warning'>You can't reach far enough.</span>" );
					return null;
				}

				foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Obj_Structure_Window) )) {
					P = _a;
					

					if ( P.dir == dir_to_set ) {
						GlobalFuncs.to_chat( b, "<span class='warning'>There's already a window here.</span>" );
						return null;
					}
				}
				((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " starts placing a window on " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You start placing a window on " ).the( this ).item().str( ".</span>" ).ToString() );

				if ( GlobalFuncs.do_after( b, this, 20 ) ) {
					
					foreach (dynamic _b in Lang13.Enumerate( this.loc, typeof(Obj_Structure_Window) )) {
						P2 = _b;
						

						if ( P2.dir == dir_to_set ) {
							GlobalFuncs.to_chat( b, "<span class='warning'>There's already a window here.</span>" );
							return null;
						}
					}
					G = a;
					WD = Lang13.Call( G.created_window, this.loc, 0 );
					WD.dir = dir_to_set;
					WD.ini_dir = dir_to_set;
					WD.anchored = 0;
					WD.d_state = 0;
					ST = a;
					ST.use( 1 );
					((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " places " ).a( WD ).item().str( " on " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You place " ).a( WD ).item().str( " on " ).the( this ).item().str( ".</span>" ).ToString() );
				}
				return null;
			}

			dynamic _c = a.damtype; // Was a switch-case, sorry for the mess.
			if ( _c=="fire" ) {
				this.health -= a.force;
			} else if ( _c=="brute" ) {
				this.health -= a.force * 0.5;
			}
			this.shock( b, a.siemens_coefficient * 100 );
			this.healthcheck( true );
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: grille.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			
			if ( !Lang13.Bool( Proj ) ) {
				return null;
			}
			this.health -= Proj.damage;
			this.healthcheck( true );
			return 0;
		}

		// Function from file: grille.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 1.5;
			air_group = air_group ?? false;

			dynamic projectile = null;

			
			if ( air_group == true || height == 0 ) {
				return true;
			}

			if ( mover is Ent_Dynamic && ((Ent_Static)mover).checkpass( 4 ) != 0 ) {
				return true;
			} else if ( mover is Obj_Item_Projectile ) {
				projectile = mover;
				return Rand13.PercentChance( projectile.grillepasschance );
			} else {
				return !this.density;
			}
			return false;
		}

		// Function from file: grille.dm
		public override dynamic attack_animal( Mob_Living user = null ) {
			user.delayNextAttack( 8 );

			if ( Lang13.Bool( ((dynamic)user).melee_damage_upper ) == false ) {
				return null;
			}
			user.visible_message( new Txt( "<span class='warning'>" ).item( user ).str( " smashes against " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='warning'>You smash against " ).the( this ).item().str( ".</span>" ).ToString(), "You hear twisting metal." );
			this.health -= Rand13.Int( Convert.ToInt32( ((dynamic)user).melee_damage_lower ), Convert.ToInt32( ((dynamic)user).melee_damage_upper ) );
			this.healthcheck( true );
			this.shock( user, 100 );
			return null;
		}

		// Function from file: grille.dm
		public override void attack_slime( Mob_Living_Carbon_Slime user = null ) {
			
			if ( !( user is Mob_Living_Carbon_Slime_Adult ) ) {
				return;
			}
			user.delayNextAttack( 8 );
			user.visible_message( new Txt( "<span class='warning'>" ).item( user ).str( " smashes against " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='warning'>You smash against " ).the( this ).item().str( ".</span>" ).ToString(), "You hear twisting metal." );
			this.health -= 3;
			this.healthcheck( true );
			this.shock( user, 100 );
			return;
		}

		// Function from file: grille.dm
		public override dynamic attack_alien( Mob user = null ) {
			dynamic alienverb = null;

			
			if ( user is Mob_Living_Carbon_Alien_Larva ) {
				return null;
			}
			alienverb = Rand13.PickFromTable( new ByTable(new object [] { "slam", "rip", "claw" }) );
			user.delayNextAttack( 8 );
			user.visible_message( new Txt( "<span class='warning'>" ).item( user ).str( " " ).item( alienverb ).str( "s " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='warning'>You " ).item( alienverb ).str( " " ).the( this ).item().str( ".</span>" ).ToString(), "You hear twisting metal." );
			this.health -= 5;
			this.healthcheck( true );
			this.shock( user, 75 );
			return null;
		}

		// Function from file: grille.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic humanverb = null;

			humanverb = Rand13.PickFromTable( new ByTable(new object [] { "kick", "slam", "elbow" }) );
			((Mob)a).delayNextAttack( 8 );
			((Ent_Static)a).visible_message( new Txt( "<span class='warning'>" ).item( a ).str( " " ).item( humanverb ).str( "s " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='warning'>You " ).item( humanverb ).str( " " ).the( this ).item().str( ".</span>" ).ToString(), "<span class='warning'>You hear twisting metal.</span>" );

			if ( Lang13.Bool( a.mutations.Contains( 4 ) ) ) {
				this.health -= 5;
			} else {
				this.health -= 3;
			}
			this.healthcheck( true );
			this.shock( a, 100 );
			return null;
		}

		// Function from file: grille.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			this.attack_hand( a );
			return null;
		}

		// Function from file: grille.dm
		public override bool Bumped( Ent_Static AM = null, dynamic yes = null ) {
			
			if ( AM is Mob ) {
				this.shock( AM, 60 );
			}
			return false;
		}

		// Function from file: grille.dm
		public override bool blob_act( dynamic severity = null ) {
			this.health -= Rand13.Int( Convert.ToInt32( Lang13.Initial( this, "health" ) * 0.8 ), Convert.ToInt32( Lang13.Initial( this, "health" ) * 3 ) );
			this.healthcheck( true );
			return false;
		}

		// Function from file: grille.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((int?)( severity )) {
				case 1:
					this.health -= Rand13.Int( 30, 50 );
					break;
				case 2:
					this.health -= Rand13.Int( 15, 30 );
					break;
				case 3:
					this.health -= Rand13.Int( 5, 15 );
					break;
			}
			this.healthcheck( true );
			return false;
		}

		// Function from file: grille.dm
		public bool shock( dynamic user = null, dynamic prb = null ) {
			dynamic T = null;
			dynamic C = null;
			Effect_Effect_System_SparkSpread s = null;

			
			if ( !Lang13.Bool( this.anchored ) || this.broken ) {
				return false;
			}

			if ( !Rand13.PercentChance( Convert.ToInt32( prb ) ) ) {
				return false;
			}

			if ( !GlobalFuncs.in_range( this, user ) ) {
				return false;
			}
			T = GlobalFuncs.get_turf( this );
			C = ((Tile)T).get_cable_node();

			if ( Lang13.Bool( C ) ) {
				
				if ( Lang13.Bool( GlobalFuncs.electrocute_mob( user, C, this ) ) ) {
					s = new Effect_Effect_System_SparkSpread();
					s.set_up( 3, 1, this );
					s.start();
					return true;
				} else {
					return false;
				}
			}
			return false;
		}

		// Function from file: grille.dm
		public void healthcheck( bool? hitsound = null ) {
			hitsound = hitsound ?? false;

			
			if ( hitsound == true ) {
				GlobalFuncs.playsound( this.loc, "sound/effects/grillehit.ogg", 80, 1 );
			}

			if ( Convert.ToDouble( this.health ) <= Convert.ToDouble( Lang13.Initial( this, "health" ) * 0.25 ) && !this.broken ) {
				this.broken = true;
				this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + "-b";
				this.density = false;
				GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Rods), GlobalFuncs.get_turf( this ) );
			}

			if ( Convert.ToDouble( this.health ) <= 0 ) {
				GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Rods), GlobalFuncs.get_turf( this ) );
				GlobalFuncs.returnToPool( this );
			}
			return;
		}

		// Function from file: grille.dm
		public override dynamic cultify(  ) {
			new Obj_Structure_Grille_Cult( GlobalFuncs.get_turf( this ) );
			GlobalFuncs.returnToPool( this );
			base.cultify();
			return null;
		}

		// Function from file: grille.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( !Lang13.Bool( this.anchored ) ) {
				GlobalFuncs.to_chat( user, "Its screws are loose." );
			}

			if ( this.broken ) {
				GlobalFuncs.to_chat( user, "It has been completely smashed apart, only a few rods are still holding together" );
			}
			return null;
		}

	}

}