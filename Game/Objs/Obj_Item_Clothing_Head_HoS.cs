// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_HoS : Obj_Item_Clothing_Head {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.armor = new ByTable().Set( "melee", 40 ).Set( "bullet", 30 ).Set( "laser", 25 ).Set( "energy", 10 ).Set( "bomb", 25 ).Set( "bio", 10 ).Set( "rad", 0 );
			this.strip_delay = 80;
			this.icon_state = "hoscap";
		}

		public Obj_Item_Clothing_Head_HoS ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}