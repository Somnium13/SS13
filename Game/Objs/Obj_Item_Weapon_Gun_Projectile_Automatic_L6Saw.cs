// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Automatic_L6Saw : Obj_Item_Weapon_Gun_Projectile_Automatic {

		public bool cover_open = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "l6closedmag";
			this.w_class = 5;
			this.origin_tech = "combat=5;materials=1;syndicate=2";
			this.mag_type = typeof(Obj_Item_AmmoBox_Magazine_Mm556x45);
			this.heavy_weapon = true;
			this.fire_sound = "sound/weapons/gunshot_smg.ogg";
			this.fire_delay = 1;
			this.pin = typeof(Obj_Item_Device_FiringPin_Implant_Pindicate);
			this.icon_state = "l6closed100";
		}

		public Obj_Item_Weapon_Gun_Projectile_Automatic_L6Saw ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: saw.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic _default = null;

			_default = base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( Lang13.Bool( _default ) ) {
				return _default;
			}

			if ( !this.cover_open ) {
				user.WriteMsg( "<span class='warning'>" + this + "'s cover is closed! You can't insert a new mag.</span>" );
				return _default;
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return _default;
		}

		// Function from file: saw.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( this.loc != a ) {
				base.attack_hand( (object)(a), b, c );
				return null;
			}

			if ( !this.cover_open || this.cover_open && !Lang13.Bool( this.magazine ) ) {
				base.attack_hand( (object)(a), b, c );
			} else if ( this.cover_open && Lang13.Bool( this.magazine ) ) {
				this.magazine.update_icon();
				this.magazine.loc = GlobalFuncs.get_turf( this.loc );
				((Mob)a).put_in_hands( this.magazine );
				this.magazine = null;
				this.update_icon();
				a.WriteMsg( "<span class='notice'>You remove the magazine from " + this + ".</span>" );
			}
			return null;
		}

		// Function from file: saw.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			
			if ( this.cover_open ) {
				user.WriteMsg( "<span class='warning'>" + this + "'s cover is open! Close it before firing!</span>" );
			} else {
				base.afterattack( (object)(target), (object)(user), proximity_flag, click_parameters );
				this.update_icon();
			}
			return false;
		}

		// Function from file: saw.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.icon_state = "l6" + ( this.cover_open ? "open" : "closed" ) + ( Lang13.Bool( this.magazine ) ? ((dynamic)( GlobalFuncs.Ceiling( this.get_ammo( false ) / 12.5 ) * 25 )) : ((dynamic)( "-empty" )) ) + ( Lang13.Bool( this.suppressed ) ? "-suppressed" : "" );
			this.item_state = "l6" + ( this.cover_open ? "openmag" : "closedmag" );
			return false;
		}

		// Function from file: saw.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.cover_open = !this.cover_open;
			user.WriteMsg( "<span class='notice'>You " + ( this.cover_open ? "open" : "close" ) + " " + this + "'s cover.</span>" );
			this.update_icon();
			return null;
		}

	}

}