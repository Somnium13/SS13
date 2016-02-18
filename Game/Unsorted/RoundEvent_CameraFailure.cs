// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_CameraFailure : RoundEvent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.startWhen = 1;
			this.endWhen = 2;
		}

		// Function from file: camerafailure.dm
		public override void tick(  ) {
			double iterations = 0;
			dynamic C = null;

			iterations = 1;
			C = Rand13.PickFromTable( GlobalVars.cameranet.cameras );

			while (Rand13.PercentChance( Num13.Floor( 100 / iterations ) )) {
				
				while (!Lang13.Bool( C.network.Contains( "SS13" ) )) {
					C = Rand13.PickFromTable( GlobalVars.cameranet.cameras );
				}

				if ( Lang13.Bool( C.status ) ) {
					((Obj_Machinery_Camera)C).toggle_cam( null, false );
				}
				iterations *= 2.5;
			}
			return;
		}

	}

}