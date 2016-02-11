// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Turret_GunTurret : Obj_Structure_Turret {

		public int cooldown = 20;
		public int projectiles = 100;
		public int projectiles_per_shot = 2;
		public double deviation = 0.3;
		public ByTable exclude = new ByTable();
		public dynamic cur_target = null;
		public double scan_range = 7;
		public int health = 40;
		public ByTable scan_for = new ByTable().Set( "human", 0 ).Set( "cyborg", 0 ).Set( "mecha", 0 ).Set( "alien", 1 );
		public bool on = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/turrets.dmi";
			this.icon_state = "gun_turret";
		}

		public Obj_Structure_Turret_GunTurret ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: turrets.dm
		public override dynamic process(  ) {
			Task13.Schedule( 0, (Task13.Closure)(() => {
				
				while (this.on) {
					
					if ( this.projectiles <= 0 ) {
						this.on = false;
						return;
					}

					if ( Lang13.Bool( this.cur_target ) && !this.validate_target( this.cur_target ) ) {
						this.cur_target = null;
					}

					if ( !Lang13.Bool( this.cur_target ) ) {
						this.cur_target = this.get_target();
					}
					this.fire( this.cur_target );
					Task13.Sleep( this.cooldown );
				}
				return;
			}));
			return null;
		}

		// Function from file: turrets.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			
			if ( Lang13.Bool( href_list["power"] ) ) {
				this.on = !this.on;

				if ( this.on ) {
					Task13.Schedule( 50, (Task13.Closure)(() => {
						
						if ( this != null ) {
							this.process();
						}
						return;
					}));
				}
			}

			if ( Lang13.Bool( href_list["scan_range"] ) ) {
				this.scan_range = ( this.scan_range + ( String13.ParseNumber( href_list["scan_range"] ) ??0) <= 1 ? 1 : ( this.scan_range + ( String13.ParseNumber( href_list["scan_range"] ) ??0) >= 8 ? 8 : this.scan_range + ( String13.ParseNumber( href_list["scan_range"] ) ??0) ) );
			}

			if ( Lang13.Bool( href_list["scan_for"] ) ) {
				
				if ( this.scan_for.Contains( href_list["scan_for"] ) ) {
					this.scan_for[href_list["scan_for"]] = !Lang13.Bool( this.scan_for[href_list["scan_for"]] );
				}
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: turrets.dm
		public override dynamic attack_alien( Mob user = null ) {
			user.visible_message( "" + user + " slashes at " + this, "You slash at " + this );
			this.take_damage( 15 );
			return null;
		}

		// Function from file: turrets.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.add_hiddenprint( user );
			return this.attack_hand( user );
		}

		// Function from file: turrets.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string dat = null;
			dynamic scan = null;

			((Mob)a).set_machine( this );
			dat = new Txt( "<html>\n						<head><title>" ).item( this ).str( " Control</title></head>\n						<body>\n						<b>Power: </b><a href='?src=" ).Ref( this ).str( ";power=1'>" ).item( ( this.on ? "on" : "off" ) ).str( "</a><br>\n						<b>Scan Range: </b><a href='?src=" ).Ref( this ).str( ";scan_range=-1'>-</a> " ).item( this.scan_range ).str( " <a href='?src=" ).Ref( this ).str( ";scan_range=1'>+</a><br>\n						<b>Scan for: </b>" ).ToString();

			foreach (dynamic _a in Lang13.Enumerate( this.scan_for )) {
				scan = _a;
				
				dat += new Txt( "<div style=\"margin-left: 15px;\">" ).item( scan ).str( " (<a href='?src=" ).Ref( this ).str( ";scan_for=" ).item( scan ).str( "'>" ).item( ( Lang13.Bool( this.scan_for[scan] ) ? "Yes" : "No" ) ).str( "</a>)</div>" ).ToString();
			}
			dat += "<b>Ammo: </b>" + Num13.MaxInt( 0, this.projectiles ) + "<br>\n					</body>\n					</html>";
			Interface13.Browse( a, dat, "window=turret" );
			GlobalFuncs.onclose( a, "turret" );
			return null;
		}

		// Function from file: turrets.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			this.take_damage( Convert.ToInt32( Proj.damage ) );
			base.bullet_act( (object)(Proj), (object)(def_zone) );
			return null;
		}

		// Function from file: turrets.dm
		public void fire( dynamic target = null ) {
			double i = 0;
			dynamic curloc = null;
			dynamic targloc = null;
			Obj_Item_Projectile A = null;

			
			if ( !Lang13.Bool( target ) ) {
				this.cur_target = null;
				return;
			}
			this.dir = Map13.GetDistance( this, target );
			Task13.Schedule( 0, (Task13.Closure)(() => {
				
				foreach (dynamic _a in Lang13.IterateRange( 1, Num13.MinInt( this.projectiles, this.projectiles_per_shot ) )) {
					i = _a;
					

					if ( !( this != null ) || !Lang13.Bool( target ) ) {
						break;
					}
					curloc = GlobalFuncs.get_turf( this );
					targloc = GlobalFuncs.get_turf( target );

					if ( !Lang13.Bool( targloc ) || !Lang13.Bool( curloc ) ) {
						continue;
					}

					if ( targloc == curloc ) {
						continue;
					}
					GlobalFuncs.playsound( this, "sound/weapons/Gunshot.ogg", 50, 1 );
					A = new Obj_Item_Projectile( curloc );
					this.projectiles--;
					A.original = target;
					A.current = curloc;
					A.target = targloc;
					A.starting = curloc;
					A.yo = Convert.ToDouble( targloc.y - curloc.y );
					A.xo = Convert.ToDouble( targloc.x - curloc.x );
					A.OnFired();
					A.process();
					Task13.Sleep( 2 );
				}
				return;
			}));
			return;
		}

		// Function from file: turrets.dm
		public dynamic get_target(  ) {
			ByTable pos_targets = null;
			dynamic target = null;
			Mob_Living_Carbon_Human M = null;
			Mob_Living_Silicon M2 = null;
			Obj_Mecha M3 = null;
			Mob_Living_Carbon_Alien M4 = null;

			pos_targets = new ByTable();
			target = null;

			if ( Lang13.Bool( this.scan_for["human"] ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInViewExcludeThis( this, this.scan_range ), typeof(Mob_Living_Carbon_Human) )) {
					M = _a;
					

					if ( this.exclude.Contains( Lang13.Bool( M.stat ) || M.lying == true || M != null ) ) {
						continue;
					}
					pos_targets.Add( M );
				}
			}

			if ( Lang13.Bool( this.scan_for["cyborg"] ) ) {
				
				foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInViewExcludeThis( this, this.scan_range ), typeof(Mob_Living_Silicon) )) {
					M2 = _b;
					

					if ( this.exclude.Contains( Lang13.Bool( M2.stat ) || M2.lying == true || M2 != null ) ) {
						continue;
					}
					pos_targets.Add( M2 );
				}
			}

			if ( Lang13.Bool( this.scan_for["mecha"] ) ) {
				
				foreach (dynamic _c in Lang13.Enumerate( Map13.FetchInViewExcludeThis( this, this.scan_range ), typeof(Obj_Mecha) )) {
					M3 = _c;
					

					if ( this.exclude.Contains( M3 ) ) {
						continue;
					}
					pos_targets.Add( M3 );
				}
			}

			if ( Lang13.Bool( this.scan_for["alien"] ) ) {
				
				foreach (dynamic _d in Lang13.Enumerate( Map13.FetchInViewExcludeThis( this, this.scan_range ), typeof(Mob_Living_Carbon_Alien) )) {
					M4 = _d;
					

					if ( this.exclude.Contains( Lang13.Bool( M4.stat ) || M4.lying == true || M4 != null ) ) {
						continue;
					}
					pos_targets.Add( M4 );
				}
			}

			if ( pos_targets.len != 0 ) {
				target = Rand13.PickFromTable( pos_targets );
			}
			return target;
		}

		// Function from file: turrets.dm
		public bool validate_target( dynamic target = null ) {
			dynamic M = null;

			
			if ( Map13.GetDistance( target, this ) > this.scan_range ) {
				return false;
			}

			if ( target is Mob ) {
				M = target;

				if ( !Lang13.Bool( M.stat ) && !( M.lying == true ) ) {
					return true;
				}
			} else if ( target is Obj_Mecha ) {
				return true;
			}
			return false;
		}

		// Function from file: turrets.dm
		public void take_damage( int damage = 0 ) {
			this.health -= damage;

			if ( this.health <= 0 ) {
				GlobalFuncs.qdel( this );
			}
			return;
		}

		// Function from file: turrets.dm
		public void update_health(  ) {
			
			if ( this.health <= 0 ) {
				GlobalFuncs.qdel( this );
			}
			return;
		}

		// Function from file: turrets.dm
		public override dynamic emp_act( int severity = 0 ) {
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: turrets.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			GlobalFuncs.qdel( this );
			return false;
		}

	}

}