// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class MapGeneratorModule_DenseLayer : MapGeneratorModule {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.clusterCheckFlags = 0;
			this.spawnableAtoms = new ByTable().Set( typeof(Ent_Static), 75 );
			this.spawnableTurfs = new ByTable().Set( typeof(Tile), 75 );
		}

	}

}