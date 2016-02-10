// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Ore_Slag : Obj_Item_Weapon_Ore {

		public Materials mats = new Materials();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.melt_temperature = 453.41;
			this.icon_state = "slag";
		}

		public Obj_Item_Weapon_Ore_Slag ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: ores_coins.dm
		public override int recycle( Game_Data rec = null ) {
			
			if ( this.mats.getVolume() == 1 ) {
				return 0;
			}
			((dynamic)rec).addFrom( this.mats );
			return 1;
		}

	}

}