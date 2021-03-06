// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Subsystem_Mobs : Subsystem {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Mobs";
			this.priority = 4;
			this.display = 4;
		}

		// Function from file: mobs.dm
		public Subsystem_Mobs (  ) {
			
			if ( GlobalVars.SSmob != this ) {
				
				if ( GlobalVars.SSmob is Subsystem_Mobs ) {
					this.Recover();
					GlobalFuncs.qdel( GlobalVars.SSmob );
				}
				GlobalVars.SSmob = this;
			}
			return;
		}

		// Function from file: mobs.dm
		public override void fire(  ) {
			double seconds = 0;
			dynamic thing = null;

			seconds = this.wait * 0.1;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.mob_list )) {
				thing = _a;
				

				if ( Lang13.Bool( thing ) ) {
					thing.Life( seconds );
					continue;
				}
				GlobalVars.mob_list.Remove( thing );
			}
			return;
		}

		// Function from file: mobs.dm
		public override void stat_entry( string msg = null ) {
			base.stat_entry( "P:" + GlobalVars.mob_list.len );
			return;
		}

	}

}