// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class MapGenerator_Asteroid_Hollow_Random_Monsters : MapGenerator_Asteroid_Hollow_Random {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.modules = new ByTable(new object [] { 
				typeof(MapGeneratorModule_BottomLayer_AsteroidTurfs), 
				typeof(MapGeneratorModule_Border_AsteroidWalls), 
				typeof(MapGeneratorModule_SplatterLayer_AsteroidWalls), 
				typeof(MapGeneratorModule_SplatterLayer_AsteroidMonsters)
			 });
		}

	}

}