// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Window : Obj_Machinery_Door {

		public string base_state = "left";
		public int health = 100;
		public dynamic electronics = null;
		public bool dismantled = false;
		public bool secure = false;
		public Type shard = typeof(Obj_Item_Weapon_Shard);

		protected override void __FieldInit() {
			base.__FieldInit();

			this.visible = false;
			this.use_power = 0;
			this.flags = 512;
			this.explosion_resistance = 5;
			this.air_properties_vary_with_direction = true;
			this.ghost_read = false;
			this.machine_flags = 1;
			this.soundeffect = "sound/machines/windowdoor.ogg";
			this.penetration_dampening = 2;
			this.icon = "icons/obj/doors/windoor.dmi";
			this.icon_state = "left";
		}

		// Function from file: windowdoor.dm
		public Obj_Machinery_Door_Window ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.req_access is ByTable && this.req_access.len != 0 || this.req_access is string ) {
				this.icon_state = "" + this.icon_state;
				this.base_state = this.icon_state;
			}
			return;
		}

		// Function from file: windowdoor.dm
		public override int emag( dynamic user = null ) {
			dynamic used_emag = null;

			used_emag = user.contents.Contains( typeof(Obj_Item_Weapon_Card_Emag) );
			return this.hackOpen( used_emag, user ) ?1:0;
		}

		// Function from file: windowdoor.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic aforce = null;

			
			if ( !this.density && this.operating != 1 && a is Obj_Item_Weapon_Crowbar ) {
				((Ent_Static)b).visible_message( "" + b + " removes the electronics from the windoor assembly.", "You start to remove the electronics from the windoor assembly." );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Crowbar.ogg", 100, 1 );

				if ( GlobalFuncs.do_after( b, this, 40 ) && this != null && !this.density && this.operating != 1 ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You removed the windoor electronics!</span>" );
					this.make_assembly( b );
					this.dismantled = true;
					GlobalFuncs.qdel( this );
				}
				return null;
			}

			if ( this.operating != 0 ) {
				return null;
			}

			if ( this.density && a is Obj_Item_Weapon && !( a is Obj_Item_Weapon_Card ) ) {
				aforce = a.force;
				((Mob)b).delayNextAttack( 8 );

				if ( a.damtype == "brute" || a.damtype == "fire" ) {
					this.health = Num13.MaxInt( 0, ((int)( this.health - Convert.ToDouble( aforce ) )) );
				}
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/Glasshit.ogg", 75, 1 );
				this.visible_message( "<span class='danger'>" + this + " was hit by " + a + ".</span>" );

				if ( this.health <= 0 ) {
					GlobalFuncs.getFromPool( this.shard, this.loc );
					GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_CableCoil), this.loc, 2 );
					GlobalFuncs.qdel( this );
				}
				return null;
			}
			this.add_fingerprint( b );

			if ( !this.requiresID() ) {
				b = null;
			}

			if ( b is Mob_Living_Silicon_Robot ) {
				
				if ( this.density ) {
					return this.open();
				} else {
					return this.close();
				}
			}

			if ( !this.allowed( b ) && this.density ) {
				Icon13.Flick( "" + this.base_state + "deny", this );
			}
			return base.attackby( (object)(a), (object)(b), (object)(c) );
		}

		// Function from file: windowdoor.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return this.attackby( a, a );
		}

		// Function from file: windowdoor.dm
		public override dynamic attack_animal( Mob_Living user = null ) {
			Mob_Living M = null;

			
			if ( this.operating != 0 ) {
				return null;
			}
			M = user;

			if ( Convert.ToDouble( ((dynamic)M).melee_damage_upper ) <= 0 ) {
				return null;
			}
			user.delayNextAttack( 8 );
			this.health = Num13.MaxInt( 0, ((int)( this.health - Convert.ToDouble( ((dynamic)M).melee_damage_upper ) )) );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/Glasshit.ogg", 75, 1 );
			this.visible_message( new Txt( "<span class='warning'>" ).The( M ).item().str( " " ).item( ((dynamic)M).attacktext ).str( " against " ).the( this.name ).item().str( ".</span>" ).ToString(), 1 );

			if ( this.health <= 0 ) {
				GlobalFuncs.getFromPool( this.shard, this.loc );
				GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_CableCoil), this.loc, 2 );
				GlobalFuncs.qdel( this );
			}
			return null;
		}

		// Function from file: windowdoor.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Mob_Living_Carbon_Alien_Humanoid || a is Mob_Living_Carbon_Slime_Adult ) {
				
				if ( this.operating != 0 ) {
					return null;
				}
				a.delayNextAttack( 8 );
				this.health = Num13.MaxInt( 0, this.health - 25 );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/Glasshit.ogg", 75, 1 );
				this.visible_message( new Txt( "<span class='warning'>" ).The( a ).item().str( " smashes against " ).the( this.name ).item().str( ".</span>" ).ToString(), 1 );

				if ( this.health <= 0 ) {
					GlobalFuncs.getFromPool( this.shard, this.loc );
					GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_CableCoil), this.loc, 2 );
					GlobalFuncs.qdel( this );
				}
			} else {
				return this.attack_hand( a );
			}
			return null;
		}

		// Function from file: windowdoor.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.add_hiddenprint( user );
			return this.attack_hand( user );
		}

		// Function from file: windowdoor.dm
		public override void hitby( Ent_Static AM = null, dynamic speed = null, int? dir = null ) {
			int tforce = 0;

			base.hitby( AM, (object)(speed), dir );
			this.visible_message( "<span class='warning'>The glass door was hit by " + AM + ".</span>", 1 );
			tforce = 0;

			if ( AM is Mob ) {
				tforce = 40;
			} else {
				tforce = Convert.ToInt32( ((dynamic)AM).throwforce );
			}
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/Glasshit.ogg", 100, 1 );
			this.take_damage( tforce );
			return;
		}

		// Function from file: windowdoor.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			
			if ( Lang13.Bool( Proj.damage ) ) {
				this.take_damage( Num13.Floor( Convert.ToDouble( Proj.damage / 2 ) ) );
			}
			base.bullet_act( (object)(Proj), (object)(def_zone) );
			return null;
		}

		// Function from file: windowdoor.dm
		public void eject_electronics(  ) {
			dynamic AE = null;

			AE = ( Lang13.Bool( this.electronics ) ? this.electronics : ((dynamic)( new Obj_Item_Weapon_Circuitboard_Airlock( this.loc ) )) );

			if ( Lang13.Bool( this.electronics ) ) {
				this.electronics = null;
				AE.installed = 0;
			} else {
				
				if ( this.operating == -1 ) {
					AE.icon_state = "door_electronics_smoked";
				}

				if ( Lang13.Bool( this.req_access ) && this.req_access.len > 0 ) {
					AE.conf_access = this.req_access;
				} else if ( Lang13.Bool( this.req_one_access ) && this.req_one_access.len > 0 ) {
					AE.conf_access = this.req_one_access;
					AE.one_access = 1;
				}
			}
			AE.loc = this.loc;
			return;
		}

		// Function from file: windowdoor.dm
		public void set_assembly( dynamic user = null, Obj_Structure_WindoorAssembly WA = null ) {
			WA.name = "Near finished Windoor Assembly";
			WA.dir = this.dir;
			WA.anchored = 1;
			WA.facing = ( this.is_left_opening() ? "l" : "r" );
			WA.secure = "";
			WA.state = "02";
			WA.update_icon();
			WA.fingerprints.Add( this.fingerprints );
			WA.fingerprintshidden.Add( this.fingerprints );
			WA.fingerprintslast = user.ckey;
			this.eject_electronics();
			return;
		}

		// Function from file: windowdoor.dm
		public virtual Obj_Structure_WindoorAssembly make_assembly( dynamic user = null ) {
			Obj_Structure_WindoorAssembly WA = null;

			WA = new Obj_Structure_WindoorAssembly( this.loc );
			this.set_assembly( user, WA );
			return WA;
		}

		// Function from file: windowdoor.dm
		public bool is_left_opening(  ) {
			return this.base_state == "left" || this.base_state == "leftsecure";
		}

		// Function from file: windowdoor.dm
		public bool hackOpen( dynamic I = null, dynamic user = null ) {
			this.operating = -1;

			if ( Lang13.Bool( this.electronics ) ) {
				this.electronics.icon_state = "door_electronics_smoked";
			}
			Icon13.Flick( "" + this.base_state + "spark", this );
			Task13.Sleep( 6 );
			this.open();
			return true;
		}

		// Function from file: windowdoor.dm
		public void take_damage( int damage = 0 ) {
			this.health = Num13.MaxInt( 0, this.health - damage );

			if ( this.health <= 0 ) {
				GlobalFuncs.getFromPool( this.shard, this.loc );
				GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_CableCoil), this.loc, 2 );
				this.eject_electronics();
				GlobalFuncs.qdel( this );
				return;
			}
			return;
		}

		// Function from file: windowdoor.dm
		public override bool close( bool? surpress_send = null ) {
			
			if ( this.operating != 0 ) {
				return false;
			}
			this.operating = 1;
			Icon13.Flick( "" + this.base_state + "closing", this );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), this.soundeffect, 100, 1 );
			this.icon_state = this.base_state;
			this.density = true;
			this.explosion_resistance = Lang13.Initial( this, "explosion_resistance" );
			this.update_nearby_tiles();
			Task13.Sleep( 10 );
			this.operating = 0;
			return true;
		}

		// Function from file: windowdoor.dm
		public override bool open( int? surpress_send = null ) {
			
			if ( this.operating == 1 ) {
				return false;
			}

			if ( !( GlobalVars.ticker != null ) ) {
				return false;
			}

			if ( !( this.operating != 0 ) ) {
				this.operating = 1;
			}
			Icon13.Flick( "" + this.base_state + "opening", this );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), this.soundeffect, 100, 1 );
			this.icon_state = "" + this.base_state + "open";
			Task13.Sleep( 10 );
			this.explosion_resistance = 0;
			this.density = false;
			this.update_nearby_tiles();

			if ( this.operating == 1 ) {
				this.operating = 0;
			}
			return true;
		}

		// Function from file: windowdoor.dm
		public override bool CheckExit( Ent_Dynamic mover = null, Ent_Static target = null ) {
			
			if ( mover is Ent_Dynamic && mover.checkpass( 2 ) != 0 ) {
				return true;
			}

			if ( Map13.GetDistance( this.loc, target ) == this.dir ) {
				return !this.density;
			} else {
				return true;
			}
		}

		// Function from file: windowdoor.dm
		public override bool CanAStarPass( Ent_Dynamic ID = null, int to_dir = 0 ) {
			return !this.density || this.dir != to_dir || this.check_access( ID );
		}

		// Function from file: windowdoor.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 1.5;
			air_group = air_group ?? false;

			
			if ( mover is Ent_Dynamic && ((Ent_Static)mover).checkpass( 2 ) != 0 ) {
				return true;
			}

			if ( Map13.GetDistance( this.loc, target ) == this.dir ) {
				
				if ( air_group == true ) {
					return false;
				}
				return !this.density;
			} else {
				return true;
			}
		}

		// Function from file: windowdoor.dm
		public override bool Bumped( Ent_Static AM = null, dynamic yes = null ) {
			Ent_Static bot = null;
			Ent_Static mecha = null;

			
			if ( !( AM is Mob ) ) {
				bot = AM;

				if ( bot is Obj_Machinery_Bot ) {
					
					if ( this.density && this.check_access( ((dynamic)bot).botcard ) ) {
						this.open();
						Task13.Sleep( 50 );
						this.close();
					}
				} else if ( AM is Obj_Mecha ) {
					mecha = AM;

					if ( this.density ) {
						
						if ( Lang13.Bool( ((dynamic)mecha).occupant ) && this.allowed( ((dynamic)mecha).occupant ) ) {
							this.open();
							Task13.Sleep( 50 );
							this.close();
						}
					}
				}
				return false;
			}

			if ( !( GlobalVars.ticker != null ) ) {
				return false;
			}

			if ( this.operating != 0 ) {
				return false;
			}

			if ( this.density && this.allowed( AM ) ) {
				this.open();

				if ( this.check_access( null ) ) {
					Task13.Sleep( 50 );
				} else {
					Task13.Sleep( 20 );
				}
				this.close();
			}
			return false;
		}

		// Function from file: windowdoor.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( this.secure ) {
				GlobalFuncs.to_chat( user, "It is a secure windoor, it is stronger and closes more quickly." );
			}
			return null;
		}

		// Function from file: windowdoor.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			this.density = false;

			if ( !this.dismantled ) {
				GlobalFuncs.playsound( this, "shatter", 70, 1 );
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}