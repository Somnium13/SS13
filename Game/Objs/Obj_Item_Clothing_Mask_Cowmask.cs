// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Mask_Cowmask : Obj_Item_Clothing_Mask {

		public bool voicechange = true;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "cowmask";
			this.flags = 32768;
			this.flags_inv = 8;
			this.w_class = 2;
			this.icon = "icons/mob/mask.dmi";
			this.icon_state = "cowmask";
		}

		public Obj_Item_Clothing_Mask_Cowmask ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: miscellaneous.dm
		public override dynamic speechModification( dynamic message = null ) {
			
			if ( this.voicechange ) {
				message = Rand13.Pick(new object [] { "Moooooooo!", "Moo!", "Moooo!" });
			}
			return message;
		}

	}

}