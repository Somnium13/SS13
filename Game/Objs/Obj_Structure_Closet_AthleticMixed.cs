// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_AthleticMixed : Obj_Structure_Closet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_door = "mixed";
		}

		// Function from file: fitness.dm
		public Obj_Structure_Closet_AthleticMixed ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Clothing_Under_Shorts_Purple( this );
			new Obj_Item_Clothing_Under_Shorts_Grey( this );
			new Obj_Item_Clothing_Under_Shorts_Black( this );
			new Obj_Item_Clothing_Under_Shorts_Red( this );
			new Obj_Item_Clothing_Under_Shorts_Blue( this );
			new Obj_Item_Clothing_Under_Shorts_Green( this );
			return;
		}

	}

}