// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Meteor_Dust : Obj_Effect_Meteor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pass_flags = 5;
			this.hits = 1;
			this.hitpwr = 3;
			this.meteorsound = "sound/weapons/throwtap.ogg";
			this.meteordrop = typeof(Obj_Item_Weapon_Ore_Glass);
			this.icon_state = "dust";
		}

		public Obj_Effect_Meteor_Dust ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}