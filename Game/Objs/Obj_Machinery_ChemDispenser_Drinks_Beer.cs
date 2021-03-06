// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_ChemDispenser_Drinks_Beer : Obj_Machinery_ChemDispenser_Drinks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.dispensable_reagents = new ByTable(new object [] { 
				"lemon_lime", 
				"sugar", 
				"orangejuice", 
				"limejuice", 
				"sodawater", 
				"tonic", 
				"beer", 
				"kahlua", 
				"whiskey", 
				"wine", 
				"vodka", 
				"gin", 
				"rum", 
				"tequila", 
				"vermouth", 
				"cognac", 
				"ale"
			 });
			this.icon_state = "booze_dispenser";
		}

		public Obj_Machinery_ChemDispenser_Drinks_Beer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}