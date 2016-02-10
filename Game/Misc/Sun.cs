// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Sun : Game_Data {

		public double? angle = null;
		public double dx = 0;
		public double dy = 0;
		public ByTable solars = null;
		public int updatePer = 600;
		public int nextTime = 0;
		public double? lastAngle = 0;
		public double rotationRate = 1;

		// Function from file: sun.dm
		public Sun (  ) {
			this.solars = GlobalVars.solars_list;
			this.nextTime = this.updatePer;
			this.rotationRate = Rand13.Int( 850, 1150 ) / 1000;

			if ( Rand13.PercentChance( 50 ) ) {
				this.rotationRate = -this.rotationRate;
			}
			return;
		}

		// Function from file: sun.dm
		public void occlusion( Obj_Machinery_Power_Solar_Panel S = null ) {
			double ax = 0;
			double ay = 0;
			double i = 0;
			Tile T = null;

			ax = S.x;
			ay = S.y;

			foreach (dynamic _a in Lang13.IterateRange( 1, 256 )) {
				i = _a;
				
				ax += this.dx;
				ay += this.dy;
				T = Map13.GetTile( ((int)( Num13.Round( ax, 0.5 ) )), ((int)( Num13.Round( ay, 0.5 ) )), S.z );

				if ( T.x == 1 || T.x == Game13.map_size_x || T.y == 1 || T.y == Game13.map_size_y ) {
					break;
				}

				if ( T.opacity ) {
					S.obscured = true;
					return;
				}
			}
			S.obscured = false;
			S.update_solar_exposure();
			return;
		}

		// Function from file: sun.dm
		public void calc_position(  ) {
			int time = 0;
			Obj_Machinery_Power_Solar_Panel_Tracker T = null;
			double si = 0;
			double co = 0;
			Obj_Machinery_Power_Solar_Panel S = null;

			time = Game13.time;
			this.angle = ( this.rotationRate * time / 100 % 360 + 360 ) % 360;

			if ( this.angle != this.lastAngle ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.solars_list, typeof(Obj_Machinery_Power_Solar_Panel_Tracker) )) {
					T = _a;
					

					if ( !Lang13.Bool( T.powernet ) ) {
						GlobalVars.solars_list.Remove( T );
						continue;
					}
					T.set_angle( this.angle );
				}
				this.lastAngle = this.angle;
			}

			if ( Game13.time < this.nextTime ) {
				return;
			}
			this.nextTime += this.updatePer;
			si = Math.Sin( this.angle ??0 );
			co = Math.Cos( this.angle ??0 );

			if ( !( co != 0 ) ) {
				this.dx = 0;
				this.dy = si;
			} else if ( Math.Abs( si ) < Math.Abs( co ) ) {
				this.dx = si / Math.Abs( co );
				this.dy = co / Math.Abs( co );
			} else {
				this.dx = si / Math.Abs( si );
				this.dy = co / Math.Abs( si );
			}

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.solars_list, typeof(Obj_Machinery_Power_Solar_Panel) )) {
				S = _b;
				

				if ( !Lang13.Bool( S.powernet ) ) {
					GlobalVars.solars_list.Remove( S );
				}

				if ( S.control != null ) {
					this.occlusion( S );
				}
			}
			return;
		}

	}

}