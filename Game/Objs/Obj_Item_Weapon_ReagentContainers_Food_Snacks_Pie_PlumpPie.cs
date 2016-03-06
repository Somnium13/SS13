// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_PlumpPie : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "vitamin", 4 );
			this.icon_state = "plump_pie";
		}

		// Function from file: snacks_pie.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_PlumpPie ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Rand13.PercentChance( 10 ) ) {
				this.name = "exceptional plump pie";
				this.desc = "Microwave is taken by a fey mood! It has cooked an exceptional plump pie!";
				this.reagents.add_reagent( "omnizine", 5 );
				this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "omnizine", 5 ).Set( "vitamin", 4 );
			}
			return;
		}

	}

}