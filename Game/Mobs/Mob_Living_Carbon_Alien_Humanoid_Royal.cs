// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_Carbon_Alien_Humanoid_Royal : Mob_Living_Carbon_Alien_Humanoid {

		public string alt_inhands_file = "icons/mob/alienqueen.dmi";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pixel_x = -16;
			this.status_flags = 0;
			this.bubble_icon = "alienroyal";
			this.mob_size = 3;
			this.pressure_resistance = 200;
			this.butcher_results = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Slab_Xeno), 20 ).Set( typeof(Obj_Item_Stack_Sheet_Animalhide_Xeno), 3 );
			this.icon = "icons/mob/alienqueen.dmi";
			this.layer = 4.5;
		}

		public Mob_Living_Carbon_Alien_Humanoid_Royal ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: update_icons.dm
		public override void update_inv_l_hand(  ) {
			dynamic itm_state = null;
			Image I = null;

			base.update_inv_l_hand();
			this.remove_overlay( 4 );

			if ( Lang13.Bool( this.l_hand ) ) {
				itm_state = this.l_hand.item_state;

				if ( !Lang13.Bool( itm_state ) ) {
					itm_state = this.l_hand.icon_state;
				}
				I = new Image( this.alt_inhands_file, null, "" + itm_state + this.caste + "_l", -4 );
				this.overlays_standing[4] = I;
				this.apply_overlay( 4 );
			}
			return;
		}

		// Function from file: update_icons.dm
		public override void update_inv_r_hand(  ) {
			dynamic itm_state = null;
			Image I = null;

			base.update_inv_r_hand();
			this.remove_overlay( 3 );

			if ( Lang13.Bool( this.r_hand ) ) {
				itm_state = this.r_hand.item_state;

				if ( !Lang13.Bool( itm_state ) ) {
					itm_state = this.r_hand.icon_state;
				}
				I = new Image( this.alt_inhands_file, null, "" + itm_state + this.caste + "_r", -3 );
				this.overlays_standing[3] = I;
				this.apply_overlay( 3 );
			}
			return;
		}

		// Function from file: queen.dm
		public override bool can_inject( dynamic user = null, bool error_msg = false, dynamic target_zone = null, bool? penetrate_thick = null ) {
			return false;
		}

	}

}