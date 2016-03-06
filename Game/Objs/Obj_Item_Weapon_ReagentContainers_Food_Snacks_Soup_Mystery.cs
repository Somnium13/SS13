// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Mystery : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup {

		public dynamic extra_reagent = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "nutriment", 6 );
			this.icon_state = "mysterysoup";
		}

		// Function from file: snacks_soup.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Mystery ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.extra_reagent = Rand13.Pick(new object [] { "capsaicin", "frostoil", "omnizine", "banana", "blood", "slimejelly", "toxin", "banana", "carbon", "oculine" });
			this.reagents.add_reagent( "" + this.extra_reagent, 5 );
			this.bonus_reagents = new ByTable().Set( "" + this.extra_reagent, 5 ).Set( "nutriment", 6 );
			return;
		}

	}

}