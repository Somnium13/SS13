// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_FiringPin : Obj_Item_Device {

		public bool emagged = false;
		public string fail_message = "<span class='warning'>INVALID USER.</span>";
		public bool selfdestruct = false;
		public bool force_replace = false;
		public bool pin_removeable = false;
		public dynamic gun = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "pen";
			this.flags = 64;
			this.w_class = 1;
			this.attack_verb = new ByTable(new object [] { "poked" });
			this.icon_state = "firing_pin";
		}

		// Function from file: pins.dm
		public Obj_Item_Device_FiringPin ( dynamic newloc = null ) : base( (object)(newloc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( newloc is Obj_Item_Weapon_Gun ) {
				this.gun = newloc;
			}
			return;
		}

		// Function from file: pins.dm
		public override dynamic Destroy(  ) {
			
			if ( Lang13.Bool( this.gun ) ) {
				this.gun.pin = null;
			}
			return base.Destroy();
		}

		// Function from file: pins.dm
		public virtual void auth_fail( dynamic user = null ) {
			((Mob)user).show_message( this.fail_message, 1 );

			if ( this.selfdestruct ) {
				((Mob)user).show_message( "<span class='danger'>SELF-DESTRUCTING...</span><br>", 1 );
				user.WriteMsg( "<span class='userdanger'>" + this.gun + " explodes!</span>" );
				GlobalFuncs.explosion( GlobalFuncs.get_turf( this.gun ), -1, 0, 2, 3 );

				if ( Lang13.Bool( this.gun ) ) {
					GlobalFuncs.qdel( this.gun );
				}
			}
			return;
		}

		// Function from file: pins.dm
		public virtual bool pin_auth( dynamic user = null ) {
			return true;
		}

		// Function from file: pins.dm
		public virtual void gun_remove( dynamic user = null ) {
			this.gun.pin = null;
			this.gun = null;
			return;
		}

		// Function from file: pins.dm
		public virtual void gun_insert( dynamic user = null, dynamic G = null ) {
			this.gun = G;
			this.loc = this.gun;
			this.gun.pin = this;
			return;
		}

		// Function from file: pins.dm
		public override bool emag_act( dynamic user = null ) {
			
			if ( !this.emagged ) {
				this.emagged = true;
				user.WriteMsg( "<span class='notice'>You override the authentication mechanism.</span>" );
			}
			return false;
		}

		// Function from file: pins.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic G = null;

			
			if ( proximity_flag == true ) {
				
				if ( target is Obj_Item_Weapon_Gun ) {
					G = target;

					if ( Lang13.Bool( G.pin ) && ( this.force_replace || G.pin.pin_removeable ) ) {
						G.pin.loc = GlobalFuncs.get_turf( G );
						((Obj_Item_Device_FiringPin)G.pin).gun_remove( user );
						user.WriteMsg( "<span class ='notice'>You remove " + G + "'s old pin.</span>" );
					}

					if ( !Lang13.Bool( G.pin ) ) {
						
						if ( !((Mob)user).unEquip( this ) ) {
							return false;
						}
						this.gun_insert( user, G );
						user.WriteMsg( "<span class ='notice'>You insert " + this + " into " + G + ".</span>" );
					} else {
						user.WriteMsg( "<span class ='notice'>This firearm already has a firing pin installed.</span>" );
					}
				}
			}
			return false;
		}

	}

}