// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing : Obj_Item {

		public string fire_sound = null;
		public string caliber = null;
		public dynamic projectile_type = null;
		public dynamic BB = null;
		public int pellets = 0;
		public double variance = 0;
		public int delay = 0;

		private string default_icon_state;
		private string default_desc;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 64;
			this.slot_flags = 512;
			this.w_class = 1;
			this.icon = "icons/obj/ammo.dmi";
			this.icon_state = "s-casing";
		}

		// Function from file: ammunition.dm
		public Obj_Item_AmmoCasing ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Lang13.Bool( this.projectile_type ) ) {
				this.BB = Lang13.Call( this.projectile_type, this );
			}
			this.pixel_x = Rand13.Int( -10, 10 );
			this.pixel_y = Rand13.Int( -10, 10 );
			this.dir = Convert.ToInt32( Rand13.PickFromTable( GlobalVars.alldirs ) );

			// We save defaults so we don't need initial!
			default_icon_state = icon_state;
			default_desc = desc;

			this.update_icon();
			return;
		}

		// Function from file: ammunition.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic box = null;
			int boolets = 0;
			Obj_Item_AmmoCasing bullet = null;

			
			if ( A is Obj_Item_AmmoBox ) {
				box = A;

				if ( this.loc is Tile ) {
					boolets = 0;

					foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Obj_Item_AmmoCasing) )) {
						bullet = _a;
						

						if ( box.stored_ammo.len >= ( box.max_ammo ??0) ) {
							break;
						}

						if ( Lang13.Bool( bullet.BB ) ) {
							
							if ( ((Obj_Item_AmmoBox)box).give_round( bullet, false ) ) {
								boolets++;
							}
						} else {
							continue;
						}
					}

					if ( boolets > 0 ) {
						box.update_icon();
						user.WriteMsg( new Txt( "<span class='notice'>You collect " ).item( boolets ).str( " shell" ).s().str( ". " ).item( box ).str( " now contains " ).item( box.stored_ammo.len ).str( " shell" ).s().str( ".</span>" ).ToString() );
					} else {
						user.WriteMsg( "<span class='warning'>You fail to collect anything!</span>" );
					}
				}
			} else {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: firing.dm
		public Tile spread( dynamic target = null, Ent_Static current = null, double? distro = null ) {
			double dx = 0;
			double dy = 0;

			dx = Math.Abs( Convert.ToDouble( target.x - current.x ) );
			dy = Math.Abs( Convert.ToDouble( target.y - current.y ) );
			return Map13.GetTile( Convert.ToInt32( target.x + Num13.Round( GlobalFuncs.gaussian( false, distro ) * ( dy + 2 ) / 8, 1 ) ), Convert.ToInt32( target.y + Num13.Round( GlobalFuncs.gaussian( false, distro ) * ( dx + 2 ) / 8, 1 ) ), Convert.ToInt32( target.z ) );
		}

		// Function from file: firing.dm
		public bool throw_proj( dynamic target = null, dynamic targloc = null, dynamic user = null, string _params = null ) {
			Ent_Static curloc = null;
			ByTable mouse_control = null;

			curloc = user.loc;

			if ( !( targloc is Tile ) || !( curloc is Tile ) || !Lang13.Bool( this.BB ) ) {
				return false;
			}

			if ( targloc == curloc ) {
				
				if ( Lang13.Bool( target ) ) {
					((Ent_Static)target).bullet_act( this.BB, this.BB.def_zone );
				}
				GlobalFuncs.qdel( this.BB );
				this.BB = null;
				return true;
			}
			this.BB.loc = GlobalFuncs.get_turf( user );
			this.BB.starting = GlobalFuncs.get_turf( user );
			this.BB.current = curloc;
			this.BB.yo = Convert.ToDouble( targloc.y - curloc.y );
			this.BB.xo = Convert.ToDouble( targloc.x - curloc.x );

			if ( Lang13.Bool( _params ) ) {
				mouse_control = String13.ParseUrlParams( _params );

				if ( Lang13.Bool( mouse_control["icon-x"] ) ) {
					this.BB.p_x = String13.ParseNumber( mouse_control["icon-x"] );
				}

				if ( Lang13.Bool( mouse_control["icon-y"] ) ) {
					this.BB.p_y = String13.ParseNumber( mouse_control["icon-y"] );
				}
			}

			if ( Lang13.Bool( this.BB ) ) {
				((Obj_Item_Projectile)this.BB).fire();
			}
			this.BB = null;
			return true;
		}

		// Function from file: firing.dm
		public void ready_proj( dynamic target = null, dynamic user = null, dynamic quiet = null, dynamic zone_override = null ) {
			zone_override = zone_override ?? "";

			
			if ( !Lang13.Bool( this.BB ) ) {
				return;
			}
			this.BB.original = target;
			this.BB.firer = user;

			if ( Lang13.Bool( zone_override ) ) {
				this.BB.def_zone = zone_override;
			} else {
				this.BB.def_zone = user.zone_selected;
			}
			this.BB.suppressed = quiet;

			if ( this.reagents != null && Lang13.Bool( this.BB.reagents ) ) {
				this.reagents.trans_to( this.BB, this.reagents.total_volume );
				GlobalFuncs.qdel( this.reagents );
			}
			return;
		}

		// Function from file: firing.dm
		public virtual bool fire( dynamic target = null, dynamic user = null, string _params = null, double? distro = null, dynamic quiet = null, dynamic zone_override = null ) {
			zone_override = zone_override ?? "";

			int? i = null;
			Ent_Static curloc = null;
			dynamic targloc = null;

			distro += this.variance;
			i = null;
			i = Num13.MaxInt( 1, this.pellets );

			while (( i ??0) > 0) {
				curloc = user.loc;
				targloc = GlobalFuncs.get_turf( target );
				this.ready_proj( target, user, quiet, zone_override );

				if ( Lang13.Bool( distro ) ) {
					targloc = this.spread( targloc, curloc, distro );
				}

				if ( !this.throw_proj( target, targloc, user, _params ) ) {
					return false;
				}

				if ( ( i ??0) > 1 ) {
					this.newshot();
				}
				i--;
			}
			((Mob)user).changeNext_move( 4 );
			((Ent_Dynamic)user).newtonian_move( Map13.GetDistance( target, user ) );
			this.update_icon();
			return true;
		}

		// Function from file: ammunition.dm
		public virtual void newshot(  ) {
			
			if ( !Lang13.Bool( this.BB ) ) {
				this.BB = Lang13.Call( this.projectile_type, this );
			}
			return;
		}

		// Function from file: ammunition.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			base.update_icon( (object)(new_state), (object)(new_icon), new_px, new_py );
			this.icon_state = default_icon_state + ( Lang13.Bool( this.BB ) ? "-live" : "" );
			this.desc = default_desc + ( Lang13.Bool( this.BB ) ? "" : " This one is spent" );
			return false;
		}

	}

}