// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Engineering_Engine_SupermatterShard : SupplyPack_Engineering_Engine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Supermatter Shard Crate";
			this.cost = 100;
			this.contains = new ByTable(new object [] { typeof(Obj_Machinery_Power_SupermatterShard) });
			this.crate_name = "supermatter shard crate";
			this.crate_type = typeof(Obj_Structure_Closet_Crate_Secure);
		}

	}

}