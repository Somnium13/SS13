// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Organ_Internal_Gland_Slime : Obj_Item_Organ_Internal_Gland {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "materials=4;biotech=6";
			this.cooldown_low = 600;
			this.cooldown_high = 1200;
			this.uses = -1;
			this.icon_state = "slime";
		}

		public Obj_Item_Organ_Internal_Gland_Slime ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: gland.dm
		public override void activate(  ) {
			Mob_Living_SimpleAnimal_Slime Slime = null;

			this.owner.WriteMsg( "<span class='warning'>You feel nauseous!</span>" );
			((Mob_Living_Carbon)this.owner).vomit( 20 );
			Slime = new Mob_Living_SimpleAnimal_Slime( GlobalFuncs.get_turf( this.owner ) );
			Slime.Friends = new ByTable(new object [] { this.owner });
			Slime.Leader = this.owner;
			return;
		}

	}

}