// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Toggle : Obj_Item_Clothing_Suit {

		public Obj_Item_Clothing_Suit_Toggle ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: toggles.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );
			user.WriteMsg( "Alt-click on " + this + " to toggle the " + this.togglename + "." );
			return 0;
		}

		// Function from file: toggles.dm
		[VerbInfo( access: VerbAccess.InUserContents, range: 127 )]
		public bool suit_toggle(  ) {
			
			if ( !this.can_use( Task13.User ) ) {
				return false;
			}
			Task13.User.WriteMsg( "<span class='notice'>You toggle " + this + "'s " + this.togglename + ".</span>" );

			if ( this.suittoggled ) {
				this.icon_state = "" + Lang13.Initial( this, "icon_state" );
				this.suittoggled = false;
			} else if ( !this.suittoggled ) {
				this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + "_t";
				this.suittoggled = true;
			}
			Task13.User.update_inv_wear_suit();
			return false;
		}

		// Function from file: toggles.dm
		public override void ui_action_click(  ) {
			this.suit_toggle();
			return;
		}

		// Function from file: toggles.dm
		public override bool AltClick( Mob user = null ) {
			base.AltClick( user );

			if ( !user.canUseTopic( user ) ) {
				user.WriteMsg( "<span class='warning'>You can't do that right now!</span>" );
				return false;
			}

			if ( !( Map13.GetDistance( this, user ) <= 1 ) ) {
				return false;
			} else {
				this.suit_toggle(  );
			}
			return false;
		}

	}

}