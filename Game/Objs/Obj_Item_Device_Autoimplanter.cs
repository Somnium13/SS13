// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Autoimplanter : Obj_Item_Device {

		public dynamic storedorgan = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "walkietalkie";
			this.w_class = 2;
			this.icon_state = "autoimplanter";
		}

		public Obj_Item_Device_Autoimplanter ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: autoimplanter.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic floorloc = null;

			
			if ( A is Obj_Item_Organ_Internal_Cyberimp ) {
				
				if ( Lang13.Bool( this.storedorgan ) ) {
					user.WriteMsg( "<span class='notice'>" + this + " already has an implant stored.</span>" );
					return null;
				}

				if ( !Lang13.Bool( user.drop_item() ) ) {
					return null;
				}
				A.loc = this;
				this.storedorgan = A;
				user.WriteMsg( "<span class='notice'>You insert the " + A + " into " + this + ".</span>" );
			} else if ( A is Obj_Item_Weapon_Screwdriver ) {
				
				if ( !Lang13.Bool( this.storedorgan ) ) {
					user.WriteMsg( "<span class='notice'>There's no implant in " + this + " for you to remove.</span>" );
				} else {
					floorloc = GlobalFuncs.get_turf( user );
					floorloc.contents.Add( this.contents );
					user.WriteMsg( "<span class='notice'>You remove the " + this.storedorgan + " from " + this + ".</span>" );
					GlobalFuncs.playsound( GlobalFuncs.get_turf( user ), "sound/items/Screwdriver.ogg", 50, 1 );
					this.storedorgan = null;
				}
			}
			return null;
		}

		// Function from file: autoimplanter.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( !Lang13.Bool( this.storedorgan ) ) {
				user.WriteMsg( "<span class='notice'>" + this + " currently has no implant stored.</span>" );
				return null;
			}
			this.storedorgan.Insert( user );
			((Ent_Static)user).visible_message( "<span class='notice'>" + user + " presses a button on " + this + ", and you hear a short mechanical noise.</span>", "<span class='notice'>You feel a sharp sting as " + this + " plunges into your body.</span>" );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( user ), "sound/weapons/circsawhit.ogg", 50, 1 );
			this.storedorgan = null;
			return null;
		}

	}

}