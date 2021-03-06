// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Toy_Crayon_Mime : Obj_Item_Toy_Crayon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.paint_color = "#FFFFFF";
			this.colourName = "mime";
			this.uses = -1;
			this.icon_state = "crayonmime";
		}

		public Obj_Item_Toy_Crayon_Mime ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: crayons.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			
			if ( Task13.User.restrained() || Task13.User.stat != 0 || Task13.User.get_active_hand() != this ) {
				return null;
			}

			if ( Lang13.Bool( href_list["color"] ) ) {
				
				if ( this.paint_color != "#FFFFFF" ) {
					this.paint_color = "#FFFFFF";
				} else {
					this.paint_color = "#000000";
				}
				this.update_window( Task13.User );
			} else {
				base.Topic( href, href_list, (object)(hsrc) );
			}
			return null;
		}

		// Function from file: crayons.dm
		public override void update_window( dynamic user = null ) {
			this.dat += new Txt( "<center><span style='border:1px solid #161616; background-color: " ).item( this.paint_color ).str( ";'>&nbsp;&nbsp;&nbsp;</span><a href='?src=" ).Ref( this ).str( ";color=1'>Change color</a></center>" ).ToString();
			base.update_window( (object)(user) );
			return;
		}

		// Function from file: crayons.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.update_window( user );
			return null;
		}

	}

}