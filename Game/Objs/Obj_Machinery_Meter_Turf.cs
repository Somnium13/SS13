// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Meter_Turf : Obj_Machinery_Meter {

		// Function from file: meter.dm
		public Obj_Machinery_Meter_Turf ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.target = this.loc;
			return; // Warning! Attempt to return some other value!
		}

		// Function from file: meter.dm
		public override void initialize(  ) {
			
			if ( !Lang13.Bool( this.target ) ) {
				this.target = this.loc;
			}
			return;
		}

	}

}