// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_HyperwaveFilter : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Hyperwave Filter";
			this.desc = "A tiny device capable of filtering and converting super-intense radiowaves.";
			this.id = "s-filter";
			this.req_tech = new ByTable().Set( "programming", 2 ).Set( "magnets", 2 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 40 ).Set( "$silver", 10 );
			this.build_path = typeof(Obj_Item_Weapon_StockParts_Subspace_Filter);
			this.category = new ByTable(new object [] { "Stock Parts" });
		}

	}

}