// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_HolodeckEffect_Sparks : Obj_Effect_HolodeckEffect {

		public Obj_Effect_HolodeckEffect_Sparks ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: holo_effect.dm
		public override dynamic activate( Obj_Machinery_Computer_Holodeck HC = null ) {
			dynamic T = null;
			EffectSystem_SparkSpread s = null;

			T = GlobalFuncs.get_turf( this );

			if ( Lang13.Bool( T ) ) {
				s = new EffectSystem_SparkSpread();
				s.set_up( 3, 1, T );
				s.start();
				T.temperature = 5000;
				((Tile)T).hotspot_expose( 50000, 50000, true );
			}
			return null;
		}

	}

}