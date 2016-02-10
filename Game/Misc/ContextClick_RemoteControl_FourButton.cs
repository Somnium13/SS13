// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ContextClick_RemoteControl_FourButton : ContextClick_RemoteControl {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.buttons = new ByTable().Set( "4B1", null ).Set( "4B2", null ).Set( "4B3", null ).Set( "4B4", null );
			this.removable_buttons = new ByTable(new object [] { "4B1", "4B2", "4B3", "4B4" });
		}

		public ContextClick_RemoteControl_FourButton ( Obj_Item to_hold = null ) : base( to_hold ) {
			
		}

		// Function from file: remote_4b.dm
		public override ByTable get_pixel_displacement( dynamic button_id = null ) {
			int x_dis = 0;
			int y_dis = 0;

			x_dis = 0;
			y_dis = 0;

			dynamic _a = button_id; // Was a switch-case, sorry for the mess.
			if ( _a=="4B1" || _a=="4B4" ) {
				x_dis = -5;
			} else if ( _a=="4B2" || _a=="4B3" ) {
				x_dis = 4;
			}

			dynamic _b = button_id; // Was a switch-case, sorry for the mess.
			if ( _b=="4B1" || _b=="4B2" ) {
				y_dis = -9;
			}
			return new ByTable().Set( "pixel_x", x_dis ).Set( "pixel_y", y_dis );
		}

		// Function from file: remote_4b.dm
		public override string get_icon_type( dynamic button_id = null ) {
			return "4bq";
		}

		// Function from file: remote_4b.dm
		public override dynamic return_clicked_id( double? x_pos = null, double? y_pos = null ) {
			
			dynamic _c = y_pos; // Was a switch-case, sorry for the mess.
			if ( 4<=_c&&_c<=12 ) {
				
				dynamic _a = x_pos; // Was a switch-case, sorry for the mess.
				if ( 8<=_a&&_a<=16 ) {
					return "4B1";
				} else if ( 17<=_a&&_a<=25 ) {
					return "4B2";
				}
			} else if ( 13<=_c&&_c<=21 ) {
				
				dynamic _b = x_pos; // Was a switch-case, sorry for the mess.
				if ( 8<=_b&&_b<=16 ) {
					return "4B4";
				} else if ( 17<=_b&&_b<=25 ) {
					return "4B3";
				}
			}
			return null;
		}

	}

}