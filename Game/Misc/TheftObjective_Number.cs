// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TheftObjective_Number : TheftObjective {

		public int min = 0;
		public int max = 0;
		public int step = 1;
		public double required_amount = 0;

		// Function from file: steal_items.dm
		public TheftObjective_Number (  ) {
			double lower = 0;
			double upper = 0;

			
			if ( this.min == this.max ) {
				this.required_amount = this.min;
			} else {
				lower = this.min / this.step;
				upper = this.min / this.step;
				this.required_amount = Rand13.Int( ((int)( lower )), ((int)( upper )) ) * this.step;
			}
			this.name = "" + this.required_amount + " " + this.name;
			return;
		}

		// Function from file: steal_items.dm
		public virtual dynamic getAmountStolen( Obj I = null ) {
			return ((dynamic)I).amount;
		}

		// Function from file: steal_items.dm
		public override bool? check_completion( Game_Data owner = null ) {
			dynamic all_items = null;
			dynamic areatype = null;
			dynamic area = null;
			Obj O = null;
			double found_amount = 0;
			Obj I = null;
			Obj C = null;
			int is_at_least_one_alive = 0;
			Mob_Living_Silicon_Ai A = null;

			
			if ( !Lang13.Bool( ((dynamic)owner).current ) ) {
				return false;
			}
			all_items = new ByTable();

			if ( ((dynamic)owner).current is Mob_Living ) {
				all_items = ((dynamic)owner).current.get_contents();
			}

			if ( this.areas.len != 0 ) {
				
				foreach (dynamic _b in Lang13.Enumerate( this.areas )) {
					areatype = _b;
					
					area = Lang13.FindObj( areatype );

					foreach (dynamic _a in Lang13.Enumerate( area, typeof(Obj) )) {
						O = _a;
						
						all_items += O;
						all_items += this.get_contents( O );
					}
				}
			}

			if ( all_items.len != 0 ) {
				found_amount = 0;

				foreach (dynamic _d in Lang13.Enumerate( all_items, typeof(Obj) )) {
					I = _d;
					

					if ( Lang13.Bool( this.typepath.IsInstanceOfType( I ) ) ) {
						
						if ( I is Obj_Item_Weapon_ReagentContainers_Hypospray_Autoinjector ) {
							continue;
						}

						if ( I is Obj_Item_Device_Aicard ) {
							C = I;

							if ( !( C.contents.len != 0 ) ) {
								continue;
							}
							is_at_least_one_alive = 0;

							foreach (dynamic _c in Lang13.Enumerate( C, typeof(Mob_Living_Silicon_Ai) )) {
								A = _c;
								

								if ( A.stat != 2 ) {
									is_at_least_one_alive++;
								}
							}

							if ( !( is_at_least_one_alive != 0 ) ) {
								continue;
							}
						}

						if ( this.areas.len != 0 ) {
							
							if ( !GlobalFuncs.is_type_in_list( GlobalFuncs.get_area_master( I ), this.areas ) ) {
								continue;
							}
						}
						found_amount += Convert.ToDouble( this.getAmountStolen( I ) );
					}
				}
				return found_amount >= this.required_amount;
			}
			return GlobalVars.FALSE;
		}

	}

}