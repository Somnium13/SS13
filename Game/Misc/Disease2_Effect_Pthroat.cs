// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease2_Effect_Pthroat : Disease2_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Pierrot's Throat";
			this.stage = 3;
		}

		// Function from file: effect.dm
		public override bool activate( Mob_Living mob = null, bool multiplier = false ) {
			Obj_Item_Clothing_Mask_Gas_VirusclownHat virusclown_hat = null;

			virusclown_hat = new Obj_Item_Clothing_Mask_Gas_VirusclownHat();

			if ( Lang13.Bool( mob.wear_mask ) && !( mob.wear_mask is Obj_Item_Clothing_Mask_Gas_VirusclownHat ) ) {
				mob.u_equip( mob.wear_mask, true );
				mob.equip_to_slot( virusclown_hat, 2 );
			}

			if ( !Lang13.Bool( mob.wear_mask ) ) {
				mob.equip_to_slot( virusclown_hat, 2 );
			}
			((Reagents)mob.reagents).add_reagent( "psilocybin", 20 );
			mob.say( Rand13.Pick(new object [] { "HONK!", "Honk!", "Honk.", "Honk?", "Honk!!", "Honk?!", "Honk..." }) );
			return false;
		}

	}

}