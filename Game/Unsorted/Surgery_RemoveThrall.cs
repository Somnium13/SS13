// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Surgery_RemoveThrall : Surgery {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "dethralling";
			this.steps = new ByTable(new object [] { typeof(SurgeryStep_Incise), typeof(SurgeryStep_ClampBleeders), typeof(SurgeryStep_RetractSkin), typeof(SurgeryStep_Saw), typeof(SurgeryStep_Dethrall) });
			this.possible_locs = new ByTable(new object [] { "head" });
		}

		// Function from file: dethralling.dm
		public override bool can_start( dynamic user = null, dynamic target = null ) {
			return GlobalFuncs.is_thrall( target );
		}

	}

}