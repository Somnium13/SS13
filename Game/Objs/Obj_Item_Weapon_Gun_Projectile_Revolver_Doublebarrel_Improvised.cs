// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Revolver_Doublebarrel_Improvised : Obj_Item_Weapon_Gun_Projectile_Revolver_Doublebarrel {

		public bool slung = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mag_type = typeof(Obj_Item_AmmoBox_Magazine_Internal_Shot_Improvised);
			this.sawn_desc = "I'm just here for the gasoline.";
			this.icon_state = "ishotgun";
		}

		public Obj_Item_Weapon_Gun_Projectile_Revolver_Doublebarrel_Improvised ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: shotgun.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			base.update_icon( (object)(new_state), (object)(new_icon), new_px, new_py );

			if ( this.slung && Lang13.Bool( this.slot_flags & 512 ) ) {
				this.slung = false;
				this.icon_state = "ishotgun-sawn";
			}
			return false;
		}

		// Function from file: shotgun.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic C = null;

			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Stack_CableCoil && !( this.sawn_state != 0 ) ) {
				C = A;

				if ( ((Obj_Item_Stack)C).use( 10 ) != 0 ) {
					this.slot_flags = 1024;
					this.icon_state = "ishotgunsling";
					user.WriteMsg( "<span class='notice'>You tie the lengths of cable to the shotgun, making a sling.</span>" );
					this.slung = true;
					this.update_icon();
				} else {
					user.WriteMsg( "<span class='warning'>You need at least ten lengths of cable if you want to make a sling!</span>" );
					return null;
				}
			}
			return null;
		}

	}

}