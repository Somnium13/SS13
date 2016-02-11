// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_GravityGenerator : Obj_Machinery {

		public bool on = true;
		public ByTable localareas = new ByTable();
		public int effectiverange = 25;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 200;
			this.active_power_usage = 1000;
			this.icon = "icons/obj/singularity.dmi";
			this.icon_state = "TheSingGen";
		}

		// Function from file: gravitygenerator.dm
		public Obj_Machinery_GravityGenerator ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 5, (Task13.Closure)(() => {
				this.locatelocalareas();
				return;
				return;
			}));
			return;
		}

		// Function from file: gravitygenerator.dm
		public void locatelocalareas(  ) {
			dynamic A = null;

			
			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( this.effectiverange, this ) )) {
				A = _a;
				

				if ( A.type == typeof(Zone) ) {
					continue;
				}

				if ( !this.localareas.Contains( A ) ) {
					this.localareas.Add( A );
				}
			}
			return;
		}

	}

}