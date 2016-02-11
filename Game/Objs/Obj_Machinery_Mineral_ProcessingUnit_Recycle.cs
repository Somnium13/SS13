// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Mineral_ProcessingUnit_Recycle : Obj_Machinery_Mineral_ProcessingUnit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.credits = -1;
		}

		// Function from file: machine_processing.dm
		public Obj_Machinery_Mineral_ProcessingUnit_Recycle ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable(new object [] { 
				new Obj_Item_Weapon_Circuitboard_ProcessingUnit_Recycling(), 
				new Obj_Item_Weapon_StockParts_MatterBin(), 
				new Obj_Item_Weapon_StockParts_MatterBin(), 
				new Obj_Item_Weapon_StockParts_MicroLaser(), 
				new Obj_Item_Weapon_StockParts_MicroLaser()
			 });
			this.RefreshParts();
			return;
		}

		// Function from file: machine_processing.dm
		public override void grab_ores(  ) {
			Tile in_T = null;
			Tile out_T = null;
			Ent_Dynamic A = null;

			in_T = Map13.GetStep( this, this.in_dir );
			out_T = Map13.GetStep( this, this.out_dir );

			if ( in_T.density || out_T.density ) {
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( in_T.contents, typeof(Ent_Dynamic) )) {
				A = _a;
				

				if ( Lang13.Bool( A.anchored ) ) {
					continue;
				}

				if ( !new ByTable(new object [] { 0, 3 }).Contains( A.w_type ) ) {
					
					if ( A.recycle( this.ore ) != 0 ) {
						GlobalFuncs.qdel( A );
						continue;
					}
				}
				A.forceMove( out_T );
			}
			return;
		}

	}

}