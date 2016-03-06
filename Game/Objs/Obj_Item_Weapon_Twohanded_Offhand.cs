// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Twohanded_Offhand : Obj_Item_Weapon_Twohanded {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 5;
			this.flags = 128;
			this.icon_state = "offhand";
		}

		public Obj_Item_Weapon_Twohanded_Offhand ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: twohanded.dm
		public override bool hit_reaction( Mob_Living_Carbon owner = null, string attack_text = null, int? final_block_chance = null, dynamic damage = null, int? attack_type = null ) {
			Ent_Static user = null;
			dynamic I = null;

			user = this.loc;

			if ( !( user is Mob ) ) {
				return false;
			}
			I = ((Mob)user).get_active_hand();

			if ( I == this ) {
				I = ((Mob)user).get_inactive_hand();
			}

			if ( !Lang13.Bool( I ) ) {
				return false;
			}
			return ((Obj_Item)I).hit_reaction();
		}

		// Function from file: twohanded.dm
		public override void wield( dynamic user = null ) {
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: twohanded.dm
		public override void unwield( dynamic user = null ) {
			GlobalFuncs.qdel( this );
			return;
		}

	}

}