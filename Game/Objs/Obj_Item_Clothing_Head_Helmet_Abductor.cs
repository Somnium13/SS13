// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Abductor : Obj_Item_Clothing_Head_Helmet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "alienhelmet";
			this.blockTracking = true;
			this.origin_tech = "materials=6;magnets=5";
			this.icon_state = "alienhelmet";
		}

		public Obj_Item_Clothing_Head_Helmet_Abductor ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}