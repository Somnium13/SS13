// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_Treevenge : RoundEvent {

		// Function from file: xmas.dm
		public override bool start(  ) {
			Obj_Structure_Flora_Tree_Pine xmas = null;
			Mob_Living_SimpleAnimal_Hostile_Tree evil_tree = null;

			
			foreach (dynamic _a in Lang13.Enumerate( typeof(Game13), typeof(Obj_Structure_Flora_Tree_Pine) )) {
				xmas = _a;
				
				evil_tree = new Mob_Living_SimpleAnimal_Hostile_Tree( xmas.loc );
				evil_tree.icon_state = xmas.icon_state;
				evil_tree.icon_living = evil_tree.icon_state;
				evil_tree.icon_dead = evil_tree.icon_state;
				evil_tree.icon_gib = evil_tree.icon_state;
				GlobalFuncs.qdel( xmas );
			}
			return false;
		}

	}

}