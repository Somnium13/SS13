// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Culthood : Obj_Item_Clothing_Head {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.armor = new ByTable().Set( "melee", 30 ).Set( "bullet", 10 ).Set( "laser", 5 ).Set( "energy", 5 ).Set( "bomb", 0 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.body_parts_covered = 8193;
			this.heat_conductivity = 0;
			this.icon_state = "culthood";
		}

		public Obj_Item_Clothing_Head_Culthood ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: cult_items.dm
		public override dynamic cultify(  ) {
			return null;
		}

	}

}