// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Folder_Syndicate_Red : Obj_Item_Weapon_Folder_Syndicate {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "folder_sred";
		}

		// Function from file: folders.dm
		public Obj_Item_Weapon_Folder_Syndicate_Red ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Documents_Syndicate_Red( this );
			this.update_icon();
			return;
		}

	}

}