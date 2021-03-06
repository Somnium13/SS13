// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Action_ItemAction_Tank_Internals : Action_ItemAction_Tank {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Set Internals";
		}

		public Action_ItemAction_Tank_Internals ( Obj_Item_Weapon_Tank Target = null ) : base( Target ) {
			
		}

		// Function from file: tanks.dm
		public override dynamic IsAvailable(  ) {
			dynamic C = null;

			C = this.owner;

			if ( !Lang13.Bool( C.wear_mask ) || !Lang13.Bool( C.wear_mask.flags & 8 ) ) {
				return null;
			}
			return base.IsAvailable();
		}

		// Function from file: tanks.dm
		public override bool Trigger(  ) {
			dynamic C = null;

			
			if ( !this.Checks() ) {
				return false;
			}
			C = this.owner;

			if ( !( C is Mob_Living_Carbon_Human ) ) {
				return false;
			}

			if ( C.v_internal == this.target ) {
				C.v_internal = null;
				C.WriteMsg( new Txt( "<span class='notice'>You close " ).the( this.target ).item().str( " valve.</span>" ).ToString() );
				((Mob_Living_Carbon)C).update_internals_hud_icon( false );
			} else if ( Lang13.Bool( C.wear_mask ) && Lang13.Bool( C.wear_mask.flags & 8 ) ) {
				C.v_internal = this.target;
				C.WriteMsg( new Txt( "<span class='notice'>You open " ).the( this.target ).item().str( " valve.</span>" ).ToString() );
				((Mob_Living_Carbon)C).update_internals_hud_icon( true );
			}
			return true;
		}

	}

}