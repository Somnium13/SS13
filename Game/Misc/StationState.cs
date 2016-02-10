// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class StationState : Game_Data {

		public int floor = 0;
		public int wall = 0;
		public int r_wall = 0;
		public int window = 0;
		public int door = 0;
		public int grille = 0;
		public int mach = 0;

		// Function from file: blob_report.dm
		public double score( StationState result = null ) {
			double output = 0;

			
			if ( !( result != null ) ) {
				return 0;
			}
			output = 0;
			output += result.floor / Num13.MaxInt( this.floor, 1 );
			output += result.r_wall / Num13.MaxInt( this.r_wall, 1 );
			output += result.wall / Num13.MaxInt( this.wall, 1 );
			output += result.window / Num13.MaxInt( this.window, 1 );
			output += result.door / Num13.MaxInt( this.door, 1 );
			output += result.grille / Num13.MaxInt( this.grille, 1 );
			output += result.mach / Num13.MaxInt( this.mach, 1 );
			return output / 7;
		}

		// Function from file: blob_report.dm
		public void count(  ) {
			dynamic T = null;
			Obj O = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.turfs )) {
				T = _a;
				

				if ( Lang13.Bool( T.z ) != true ) {
					continue;
				}

				if ( T is Tile_Simulated_Floor ) {
					
					if ( !T.burnt ) {
						this.floor += 12;
					} else {
						this.floor += 1;
					}
				}

				if ( T is Tile_Simulated_Wall ) {
					
					if ( T.intact == true ) {
						this.wall += 2;
					} else {
						this.wall += 1;
					}
				}

				if ( T is Tile_Simulated_Wall_RWall ) {
					
					if ( T.intact == true ) {
						this.r_wall += 2;
					} else {
						this.r_wall += 1;
					}
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( typeof(Game13), typeof(Obj) )) {
				O = _b;
				

				if ( O.z != 1 ) {
					continue;
				}

				if ( O is Obj_Structure_Window ) {
					this.window += 1;
				} else if ( O is Obj_Structure_Grille && !Lang13.Bool( ((dynamic)O).destroyed ) ) {
					this.grille += 1;
				} else if ( O is Obj_Machinery_Door ) {
					this.door += 1;
				} else if ( O is Obj_Machinery ) {
					this.mach += 1;
				}
			}
			return;
		}

	}

}