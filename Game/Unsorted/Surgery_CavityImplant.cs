// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Surgery_CavityImplant : Surgery {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "cavity implant";
			this.steps = new ByTable(new object [] { 
				typeof(SurgeryStep_Incise), 
				typeof(SurgeryStep_ClampBleeders), 
				typeof(SurgeryStep_RetractSkin), 
				typeof(SurgeryStep_Incise), 
				typeof(SurgeryStep_HandleCavity), 
				typeof(SurgeryStep_Close)
			 });
			this.species = new ByTable(new object [] { typeof(Mob_Living_Carbon_Human), typeof(Mob_Living_Carbon_Monkey) });
			this.possible_locs = new ByTable(new object [] { "chest" });
		}

	}

}