// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_MixVirus : ChemicalReaction {

		public int level_min = 0;
		public int level_max = 2;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Mix Virus";
			this.id = "mixvirus";
			this.result = "blood";
			this.required_reagents = new ByTable().Set( "virusfood", 1 );
			this.required_catalysts = new ByTable().Set( "blood", 1 );
		}

		// Function from file: others.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			dynamic B = null;
			dynamic D = null;

			B = Lang13.FindIn( typeof(Reagent_Blood), holder.reagent_list );

			if ( Lang13.Bool( B ) && Lang13.Bool( B.data ) ) {
				D = Lang13.FindIn( typeof(Disease_Advance), B.data["viruses"] );

				if ( Lang13.Bool( D ) ) {
					((Disease_Advance)D).Evolve( this.level_min, this.level_max );
				}
			}
			return;
		}

	}

}