// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Mask_Gas_Welding : Obj_Item_Clothing_Mask_Gas {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.materials = new ByTable().Set( "$metal", 4000 ).Set( "$glass", 2000 );
			this.flash_protect = 2;
			this.tint = 2;
			this.armor = new ByTable().Set( "melee", 10 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.origin_tech = "materials=2;engineering=2";
			this.action_button_name = "Toggle Welding Mask";
			this.flags_cover = 2;
			this.visor_flags_inv = 4;
			this.icon_state = "weldingmask";
		}

		public Obj_Item_Clothing_Mask_Gas_Welding ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: gasmask.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.toggle();
			return null;
		}

		// Function from file: gasmask.dm
		[Verb]
		[VerbInfo( name: "Adjust welding mask", group: "Object", access: VerbAccess.InUserContents, range: 127 )]
		public void toggle(  ) {
			this.weldingvisortoggle();
			return;
		}

	}

}