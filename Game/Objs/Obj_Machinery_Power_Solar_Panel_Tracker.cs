// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Power_Solar_Panel_Tracker : Obj_Machinery_Power_Solar_Panel {

		public double? sun_angle = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.tracker = true;
			this.icon_state = "tracker";
		}

		public Obj_Machinery_Power_Solar_Panel_Tracker ( dynamic loc = null, Obj_Machinery_Power_SolarAssembly S = null ) : base( (object)(loc), S ) {
			
		}

		// Function from file: tracker.dm
		public override dynamic process(  ) {
			dynamic avail = null;

			avail = this.surplus();

			if ( Convert.ToDouble( avail ) > 500 ) {
				this.add_load( 500 );
				this.stat &= 65533;
			} else {
				this.stat |= 2;
			}
			return null;
		}

		// Function from file: tracker.dm
		public void set_angle( double? angle = null ) {
			Obj_Machinery_Power_Solar_Control C = null;

			this.sun_angle = angle;
			this.dir = Num13.Rotate( GlobalVars.NORTH, -( angle ??0) - 22.5 );

			if ( ( this.stat & 2 ) != 0 ) {
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.getPowernetNodes(), typeof(Obj_Machinery_Power_Solar_Control) )) {
				C = _a;
				

				if ( Map13.GetDistance( C, this ) < 40 ) {
					C.tracker_update( angle );
				}
			}
			return;
		}

	}

}