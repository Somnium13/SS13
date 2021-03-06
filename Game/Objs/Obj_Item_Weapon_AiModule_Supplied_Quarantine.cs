// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_AiModule_Supplied_Quarantine : Obj_Item_Weapon_AiModule_Supplied {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "programming=3;biotech=2;materials=4";
			this.laws = new ByTable(new object [] { 
				"The station is under a quarantine. Do not permit anyone to leave. Prevent, by any means necessary, humans from leaving. It is impossible to harm a human while preventing them from leaving."
			 });
			this.lawpos = 8;
		}

		public Obj_Item_Weapon_AiModule_Supplied_Quarantine ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}