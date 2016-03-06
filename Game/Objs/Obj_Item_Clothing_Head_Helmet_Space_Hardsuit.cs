// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space_Hardsuit : Obj_Item_Clothing_Head_Helmet_Space {

		public string basestate = "hardsuit";
		public double brightness_on = 4;
		public bool on = false;
		public Obj_Item_Clothing_Suit_Space_Hardsuit suit = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "eng_helm";
			this.armor = new ByTable().Set( "melee", 10 ).Set( "bullet", 5 ).Set( "laser", 10 ).Set( "energy", 5 ).Set( "bomb", 10 ).Set( "bio", 100 ).Set( "rad", 75 );
			this.item_color = "engineering";
			this.action_button_name = "Toggle Helmet Light";
			this.icon_state = "hardsuit0-engineering";
		}

		public Obj_Item_Clothing_Head_Helmet_Space_Hardsuit ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: toggles.dm
		public override dynamic Destroy(  ) {
			
			if ( this.suit != null ) {
				this.suit.helmet = null;
			}
			return base.Destroy();
		}

		// Function from file: hardsuit.dm
		public override double emp_act( int severity = 0 ) {
			base.emp_act( severity );
			this.display_visor_message( "" + ( severity > 1 ? "Light" : "Strong" ) + " electromagnetic pulse detected!" );
			return 0;
		}

		// Function from file: hardsuit.dm
		public override bool rad_act( double severity = 0 ) {
			base.rad_act( severity );
			this.display_visor_message( "Radiation pulse detected! Magnitude: <span class='green'>" + severity + "</span> RADs." );
			return false;
		}

		// Function from file: hardsuit.dm
		public void display_visor_message( string msg = null ) {
			Ent_Static wearer = null;

			wearer = this.loc;

			if ( Lang13.Bool( msg ) && wearer is Mob_Living_Carbon_Human ) {
				((dynamic)wearer).show_message( new Txt().icon( this ).str( "<b><span class='robot'>" ).item( msg ).str( "</span></b>" ).ToString(), 1 );
			}
			return;
		}

		// Function from file: hardsuit.dm
		public override void equipped( Mob user = null, dynamic slot = null ) {
			
			if ( slot != 11 ) {
				
				if ( this.suit != null ) {
					this.suit.RemoveHelmet();
				} else {
					GlobalFuncs.qdel( this );
				}
			}
			return;
		}

		// Function from file: hardsuit.dm
		public override bool dropped( dynamic user = null ) {
			
			if ( this.on ) {
				((Ent_Static)user).AddLuminosity( -this.brightness_on );
				this.SetLuminosity( this.brightness_on );
			}

			if ( this.suit != null ) {
				this.suit.RemoveHelmet();
			}
			return false;
		}

		// Function from file: hardsuit.dm
		public override bool pickup( dynamic user = null ) {
			
			if ( this.on ) {
				((Ent_Static)user).AddLuminosity( this.brightness_on );
				this.SetLuminosity( 0 );
			}
			return false;
		}

		// Function from file: hardsuit.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( !( user.loc is Tile ) ) {
				user.WriteMsg( "<span class='warning'>You cannot turn the light on while in this " + user.loc + "!</span>" );
				return null;
			}
			this.on = !this.on;
			this.icon_state = "" + this.basestate + this.on + "-" + this.item_color;
			((Mob)user).update_inv_head();

			if ( this.on ) {
				((Ent_Static)user).AddLuminosity( this.brightness_on );
			} else {
				((Ent_Static)user).AddLuminosity( -this.brightness_on );
			}
			return null;
		}

	}

}