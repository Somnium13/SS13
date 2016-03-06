// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Organ_Internal_Cyberimp_Eyes_Hud : Obj_Item_Organ_Internal_Cyberimp_Eyes {

		public int HUD_type = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.slot = "eye_hud";
		}

		public Obj_Item_Organ_Internal_Cyberimp_Eyes_Hud ( dynamic M = null ) : base( (object)(M) ) {
			
		}

		// Function from file: augments_eyes.dm
		public override void Remove( dynamic M = null, bool? special = null ) {
			special = special ?? false;

			AtomHud H = null;

			
			if ( this.HUD_type != 0 ) {
				H = GlobalVars.huds[this.HUD_type];
				M.permanent_huds.Xor( H );
				H.remove_hud_from( M );
			}
			base.Remove( (object)(M), special );
			return;
		}

		// Function from file: augments_eyes.dm
		public override void Insert( dynamic M = null, int? special = null ) {
			special = special ?? 0;

			AtomHud H = null;

			base.Insert( (object)(M), special );

			if ( this.HUD_type != 0 ) {
				H = GlobalVars.huds[this.HUD_type];
				H.add_hud_to( M );
				M.permanent_huds.Or( H );
			}
			return;
		}

	}

}