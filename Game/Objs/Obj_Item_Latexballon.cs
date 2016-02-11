// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Latexballon : Obj_Item {

		public dynamic state = null;
		public dynamic air_contents = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "lgloves";
			this.throwforce = 0;
			this.w_class = 1;
			this.throw_speed = 1;
			this.throw_range = 15;
			this.icon_state = "latexballon";
		}

		public Obj_Item_Latexballon ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: latexballoon.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( Lang13.Bool( this.is_sharp(  ) ) ) {
				this.burst();
			}
			return null;
		}

		// Function from file: latexballoon.dm
		public override bool fire_act( GasMixture air = null, double? exposed_temperature = null, int exposed_volume = 0 ) {
			
			if ( ( exposed_temperature ??0) > 373.41 ) {
				this.burst();
			}
			return false;
		}

		// Function from file: latexballoon.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			this.burst();
			return null;
		}

		// Function from file: latexballoon.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			this.burst();

			switch ((int?)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
			}
			return false;
		}

		// Function from file: latexballoon.dm
		public void burst(  ) {
			
			if ( !Lang13.Bool( this.air_contents ) ) {
				return;
			}
			GlobalFuncs.playsound( this, "sound/weapons/Gunshot.ogg", 100, 1 );
			this.icon_state = "latexballon_bursted";
			this.item_state = "lgloves";
			this.loc.assume_air( this.air_contents );
			return;
		}

		// Function from file: latexballoon.dm
		public void blow( Obj_Item_Weapon_Tank tank = null ) {
			
			if ( this.icon_state == "latexballon_bursted" ) {
				return;
			}
			this.air_contents = tank.remove_air_volume( 3 );
			this.icon_state = "latexballon_blow";
			this.item_state = "latexballon";
			return;
		}

	}

}