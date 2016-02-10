// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Validsalad : Recipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.items = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Ambrosiavulgaris), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Ambrosiavulgaris), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Ambrosiavulgaris), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Potato), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Faggot)
			 });
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Validsalad);
		}

		// Function from file: recipes_microwave.dm
		public override dynamic make_food( Obj_Machinery_Microwave container = null ) {
			dynamic being_cooked = null;

			being_cooked = base.make_food( container );
			((Reagents)being_cooked.reagents).del_reagent( "toxin" );
			return being_cooked;
		}

	}

}