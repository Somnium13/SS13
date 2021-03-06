// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Mineral_Random : Tile_Simulated_Mineral {

		public ByTable mineralSpawnChanceList = new ByTable().Set( "Uranium", 5 ).Set( "Diamond", 1 ).Set( "Gold", 10 ).Set( "Silver", 12 ).Set( "Plasma", 20 ).Set( "Iron", 40 ).Set( "Gibtonite", 4 ).Set( "Cave", 2 ).Set( "BScrystal", 1 );
		public int mineralChance = 13;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "rock";
		}

		// Function from file: mine_turfs.dm
		public Tile_Simulated_Mineral_Random ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic mName = null;
			Tile_Simulated_Mineral M = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Rand13.PercentChance( this.mineralChance ) ) {
				mName = GlobalFuncs.pickweight( this.mineralSpawnChanceList );

				if ( Lang13.Bool( mName ) ) {
					
					dynamic _a = mName; // Was a switch-case, sorry for the mess.
					if ( _a=="Uranium" ) {
						M = new Tile_Simulated_Mineral_Uranium( this );
					} else if ( _a=="Iron" ) {
						M = new Tile_Simulated_Mineral_Iron( this );
					} else if ( _a=="Diamond" ) {
						M = new Tile_Simulated_Mineral_Diamond( this );
					} else if ( _a=="Gold" ) {
						M = new Tile_Simulated_Mineral_Gold( this );
					} else if ( _a=="Silver" ) {
						M = new Tile_Simulated_Mineral_Silver( this );
					} else if ( _a=="Plasma" ) {
						M = new Tile_Simulated_Mineral_Plasma( this );
					} else if ( _a=="Cave" ) {
						new Tile_Simulated_Floor_Plating_Asteroid_Airless_Cave( this );
					} else if ( _a=="Gibtonite" ) {
						M = new Tile_Simulated_Mineral_Gibtonite( this );
					} else if ( _a=="Bananium" ) {
						M = new Tile_Simulated_Mineral_Clown( this );
					} else if ( _a=="BScrystal" ) {
						M = new Tile_Simulated_Mineral_Bscrystal( this );
					}

					if ( M != null ) {
						M.mineralAmt = Rand13.Int( 1, 5 );
						M.environment_type = this.environment_type;
						M.turf_type = this.turf_type;
						M.baseturf = this.baseturf;
						Task13.Source = M;
						M.levelupdate();
					}
				}
			}
			return;
		}

	}

}