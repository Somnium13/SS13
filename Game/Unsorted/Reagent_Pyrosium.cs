// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Pyrosium : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Pyrosium";
			this.id = "pyrosium";
			this.description = "Comes into existence at 20K. As long as there is sufficient oxygen for it to react with, Pyrosium slowly cools all other reagents in the mob down to 0K.";
			this.color = "#B20000";
			this.metabolization_rate = 0.2;
		}

		// Function from file: pyrotechnic_reagents.dm
		public override void on_tick( dynamic data = null ) {
			
			if ( Lang13.Bool( ((Reagents)this.holder).has_reagent( "oxygen" ) ) ) {
				((Reagents)this.holder).remove_reagent( "oxygen", 1 );
				((dynamic)this.holder).chem_temp += 10;
				((Reagents)this.holder).handle_reactions();
			}
			base.on_tick( (object)(data) );
			return;
		}

		// Function from file: pyrotechnic_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			
			if ( Lang13.Bool( ((Reagents)M.reagents).has_reagent( "oxygen" ) ) ) {
				((Reagents)M.reagents).remove_reagent( "oxygen", 0.5 );
				M.bodytemperature += 15;
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}