// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Costume_Maid : Obj_Effect_Landmark_Costume {

		// Function from file: landmarks.dm
		public Obj_Effect_Landmark_Costume_Maid ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic CHOICE = null;

			new Obj_Item_Clothing_Under_Blackskirt( this.loc );
			CHOICE = Rand13.Pick(new object [] { typeof(Obj_Item_Clothing_Head_Beret), typeof(Obj_Item_Clothing_Head_Rabbitears) });
			Lang13.Call( CHOICE, this.loc );
			new Obj_Item_Clothing_Glasses_Sunglasses_Blindfold( this.loc );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}