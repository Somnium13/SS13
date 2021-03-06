// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Grenade_ChemGrenade_Colorful : Obj_Item_Weapon_Grenade_ChemGrenade {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.stage = 3;
		}

		// Function from file: chem_grenade.dm
		public Obj_Item_Weapon_Grenade_ChemGrenade_Colorful ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj_Item_Weapon_ReagentContainers_Glass_Beaker B1 = null;
			Obj_Item_Weapon_ReagentContainers_Glass_Beaker B2 = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			B1 = new Obj_Item_Weapon_ReagentContainers_Glass_Beaker( this );
			B2 = new Obj_Item_Weapon_ReagentContainers_Glass_Beaker( this );
			B1.reagents.add_reagent( "colorful_reagent", 25 );
			B1.reagents.add_reagent( "potassium", 25 );
			B2.reagents.add_reagent( "phosphorus", 25 );
			B2.reagents.add_reagent( "sugar", 25 );
			this.beakers.Add( B1 );
			this.beakers.Add( B2 );
			return;
		}

	}

}