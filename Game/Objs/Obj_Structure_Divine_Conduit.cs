// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Divine_Conduit : Obj_Structure_Divine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.health = 150;
			this.maxhealth = 150;
			this.metal_cost = 20;
			this.glass_cost = 5;
			this.icon_state = "conduit";
		}

		public Obj_Structure_Divine_Conduit ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: structures.dm
		public override bool assign_deity( Mob_Camera_God new_deity = null, int? alert_old_deity = null ) {
			alert_old_deity = alert_old_deity ?? GlobalVars.TRUE;

			
			if ( this.deity != null ) {
				this.deity.conduits.Remove( this );
			}
			base.assign_deity( new_deity, alert_old_deity );

			if ( this.deity != null ) {
				this.deity.conduits.Add( this );
			}
			return false;
		}

	}

}