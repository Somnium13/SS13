// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset_Injection : Obj_Structure_Closet_SecureCloset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 58 });
		}

		// Function from file: security.dm
		public Obj_Structure_Closet_SecureCloset_Injection ( dynamic loc = null ) : base( (object)(loc) ) {
			double i = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.IterateRange( 1, 5 )) {
				i = _a;
				
				new Obj_Item_Weapon_ReagentContainers_Syringe_Lethal_Choral( this );
			}
			return;
		}

	}

}