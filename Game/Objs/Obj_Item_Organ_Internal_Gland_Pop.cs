// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Organ_Internal_Gland_Pop : Obj_Item_Organ_Internal_Gland {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "materials=4;biotech=6";
			this.cooldown_low = 900;
			this.cooldown_high = 1800;
			this.uses = 6;
			this.human_only = true;
			this.icon_state = "species";
		}

		public Obj_Item_Organ_Internal_Gland_Pop ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: gland.dm
		public override void activate(  ) {
			dynamic species = null;

			this.owner.WriteMsg( "<span class='notice'>You feel unlike yourself.</span>" );
			species = Rand13.PickFromTable( new ByTable(new object [] { typeof(Species_Lizard), typeof(Species_Jelly_Slime), typeof(Species_Pod), typeof(Species_Fly) }) );
			((Mob)this.owner).set_species( species );
			return;
		}

	}

}