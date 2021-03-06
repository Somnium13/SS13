// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Card_Id_Prisoner : Obj_Item_Weapon_Card_Id {

		public bool goal = false;
		public bool points = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "orange-id";
			this.assignment = "Prisoner";
			this.registered_name = "Scum";
			this.icon_state = "orange";
		}

		public Obj_Item_Weapon_Card_Id_Prisoner ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: cards_ids.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			Task13.User.WriteMsg( "<span class='notice'>You have accumulated " + this.points + " out of the " + this.goal + " points you need for freedom.</span>" );
			return null;
		}

	}

}