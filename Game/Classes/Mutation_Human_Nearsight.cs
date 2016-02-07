// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mutation_Human_Nearsight : Mutation_Human {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Near Sightness";
			this.quality = 3;
			this.text_gain_indication = "<span class='danger'>You can't see very well.</span>";
		}

		// Function from file: mutations.dm
		public override dynamic on_losing( dynamic owner = null ) {
			
			if ( Lang13.Bool( base.on_losing( (object)(owner) ) ) ) {
				return null;
			}
			owner.disabilities &= 65527;
			return null;
		}

		// Function from file: mutations.dm
		public override dynamic on_acquiring( dynamic owner = null ) {
			
			if ( Lang13.Bool( base.on_acquiring( (object)(owner) ) ) ) {
				return null;
			}
			owner.disabilities |= 8;
			return null;
		}

	}

}