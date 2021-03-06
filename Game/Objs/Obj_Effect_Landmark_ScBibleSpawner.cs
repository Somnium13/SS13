// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_ScBibleSpawner : Obj_Effect_Landmark {

		// Function from file: stationCollision.dm
		public Obj_Effect_Landmark_ScBibleSpawner ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj_Item_Weapon_Storage_Book_Bible_Booze B = null;

			B = new Obj_Item_Weapon_Storage_Book_Bible_Booze( this.loc );
			B.name = "The Holy book of the Geometer";
			B.deity_name = "Narsie";
			B.icon_state = "melted";
			B.item_state = "melted";
			new Obj_Item_Weapon_Paper_ScSafehintPaperBible( B );
			new Obj_Item_Weapon_Pen( B );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}