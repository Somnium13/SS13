// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mutation_Human_XRay : Mutation_Human {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "X Ray Vision";
			this.quality = 1;
			this.get_chance = 25;
			this.lowest_value = 3072;
			this.text_gain_indication = "<span class='notice'>The walls suddenly disappear!</span>";
			this.time_coeff = 2;
		}

		// Function from file: mutations.dm
		public override dynamic on_losing( dynamic owner = null ) {
			
			if ( Lang13.Bool( base.on_losing( (object)(owner) ) ) ) {
				return null;
			}

			if ( ( ( owner.permanent_sight_flags ?1:0) & 4 ) != 0 && ( ( owner.permanent_sight_flags ?1:0) & 8 ) != 0 && ( ( owner.permanent_sight_flags ?1:0) & 16 ) != 0 ) {
				return null;
			}
			owner.see_in_dark = Convert.ToInt32( Lang13.Initial( owner, "see_in_dark" ) );
			owner.sight = Convert.ToInt32( Lang13.Initial( owner, "sight" ) );
			return null;
		}

		// Function from file: mutations.dm
		public override void on_life( dynamic owner = null ) {
			owner.sight |= 28;
			owner.see_in_dark = 8;
			return;
		}

		// Function from file: mutations.dm
		public override dynamic on_acquiring( dynamic owner = null ) {
			
			if ( Lang13.Bool( base.on_acquiring( (object)(owner) ) ) ) {
				return null;
			}
			this.on_life( owner );
			return null;
		}

	}

}