// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GlobalIterator_MechaGenerator_Nuclear : GlobalIterator_MechaGenerator {

		public GlobalIterator_MechaGenerator_Nuclear ( ByTable arguments = null, bool? autostart = null ) : base( arguments, autostart ) {
			
		}

		// Function from file: tools.dm
		public override bool process( Obj port = null, dynamic mecha = null ) {
			Mob_Living_Carbon M = null;

			
			if ( base.process( port, (object)(mecha) ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( null, ((dynamic)port).chassis ), typeof(Mob_Living_Carbon) )) {
					M = _a;
					

					if ( M is Mob_Living_Carbon_Human ) {
						M.apply_effect( ((dynamic)port).rad_per_cycle * 3, "irradiate", 0 );
					} else {
						M.radiation += Convert.ToDouble( ((dynamic)port).rad_per_cycle );
					}
				}
			}
			return true;
		}

	}

}