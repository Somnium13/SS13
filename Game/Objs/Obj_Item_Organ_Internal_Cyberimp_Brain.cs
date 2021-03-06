// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Organ_Internal_Cyberimp_Brain : Obj_Item_Organ_Internal_Cyberimp {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.implant_overlay = "brain_implant_overlay";
			this.zone = "head";
			this.icon_state = "brain_implant";
		}

		public Obj_Item_Organ_Internal_Cyberimp_Brain ( dynamic M = null ) : base( (object)(M) ) {
			
		}

		// Function from file: augments_internal.dm
		public override double emp_act( int severity = 0 ) {
			double stun_amount = 0;

			
			if ( !Lang13.Bool( this.owner ) ) {
				return 0;
			}
			stun_amount = ( severity - 1 != 0 ? 0 : 5 ) + 5;
			((Mob)this.owner).Stun( stun_amount );
			this.owner.WriteMsg( "<span class='warning'>Your body seizes up!</span>" );
			return stun_amount;
		}

	}

}