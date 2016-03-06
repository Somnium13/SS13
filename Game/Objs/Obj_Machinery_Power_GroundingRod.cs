// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Power_GroundingRod : Obj_Machinery_Power {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/tesla_engine/tesla_coil.dmi";
			this.icon_state = "grounding_rod";
		}

		// Function from file: coil.dm
		public Obj_Machinery_Power_GroundingRod ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable();
			this.component_parts.Add( new Obj_Item_Weapon_Circuitboard_GroundingRod( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_Capacitor( null ) );
			this.RefreshParts();
			return;
		}

		// Function from file: coil.dm
		public override void tesla_act( double power = 0 ) {
			Icon13.Flick( "coil_shock_1", this );
			return;
		}

		// Function from file: coil.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( this.default_deconstruction_screwdriver( user, "grounding_rod", "grounding_rod", A ) ) {
				return null;
			}

			if ( this.exchange_parts( user, A ) ) {
				return null;
			}

			if ( this.default_pry_open( A ) ) {
				return null;
			}

			if ( this.default_unfasten_wrench( user, A ) ) {
				return null;
			}
			this.default_deconstruction_crowbar( A );
			return null;
		}

	}

}