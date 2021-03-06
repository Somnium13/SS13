// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpaceLevel : Game_Data {

		public dynamic name = "Your config settings failed, you need to fix this for the datum space levels to work";
		public ByTable neigbours = new ByTable();
		public int z_value = 1;
		public int linked = 1;
		public int? xi = null;
		public int? yi = null;

		// Function from file: space_transition.dm
		public SpaceLevel ( dynamic transition_type = null ) {
			ByTable L = null;
			dynamic A = null;

			this.linked = Convert.ToInt32( transition_type );

			if ( this.linked == 1 ) {
				this.neigbours = new ByTable();
				L = new ByTable(new object [] { "1", "2", "4", "8" });

				foreach (dynamic _a in Lang13.Enumerate( L )) {
					A = _a;
					
					this.neigbours[A] = this;
				}
			}
			return;
		}

		// Function from file: space_transition.dm
		public void set_neigbours( ByTable L = null ) {
			Point P = null;

			
			foreach (dynamic _a in Lang13.Enumerate( L, typeof(Point) )) {
				P = _a;
				

				if ( P.x == this.xi ) {
					
					if ( P.y == ( this.yi ??0) + 1 ) {
						this.neigbours["1"] = P.spl;
						P.spl.neigbours["2"] = this;
					} else if ( P.y == ( this.yi ??0) - 1 ) {
						this.neigbours["2"] = P.spl;
						P.spl.neigbours["1"] = this;
					}
				} else if ( P.y == this.yi ) {
					
					if ( P.x == ( this.xi ??0) + 1 ) {
						this.neigbours["4"] = P.spl;
						P.spl.neigbours["8"] = this;
					} else if ( P.x == ( this.xi ??0) - 1 ) {
						this.neigbours["8"] = P.spl;
						P.spl.neigbours["4"] = this;
					}
				}
			}
			return;
		}

	}

}