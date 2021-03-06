// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Toy_AI : Obj_Item_Toy {

		public bool cooldown = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 2;
			this.icon = "icons/obj/toy.dmi";
			this.icon_state = "AI";
		}

		public Obj_Item_Toy_AI ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: toys.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic message = null;

			
			if ( !this.cooldown ) {
				message = GlobalFuncs.generate_ion_law();
				user.WriteMsg( "<span class='notice'>You press the button on " + this + ".</span>" );
				GlobalFuncs.playsound( user, "sound/machines/click.ogg", 20, 1 );
				this.loc.visible_message( new Txt( "<span class='danger'>" ).icon( this ).str( " " ).item( message ).str( "</span>" ).ToString() );
				this.cooldown = true;
				Task13.Schedule( 30, (Task13.Closure)(() => {
					this.cooldown = false;
					return;
				}));
				return null;
			}
			base.attack_self( (object)(user), (object)(flag), emp );
			return null;
		}

	}

}