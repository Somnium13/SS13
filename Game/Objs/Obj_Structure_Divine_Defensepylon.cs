// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Divine_Defensepylon : Obj_Structure_Divine {

		public Obj_Machinery_PortaTurret_DefensepylonInternalTurret pylon_gun = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.health = 150;
			this.maxhealth = 150;
			this.metal_cost = 25;
			this.glass_cost = 30;
			this.icon_state = "defensepylon";
		}

		// Function from file: structures.dm
		public Obj_Structure_Divine_Defensepylon ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.pylon_gun = new Obj_Machinery_PortaTurret_DefensepylonInternalTurret( this );
			this.pylon_gun.v_base = this;
			this.pylon_gun.faction = new ByTable(new object [] { "" + this.side + " god" });
			return;
		}

		// Function from file: structures.dm
		public override void attack_god( Mob_Camera_God user = null ) {
			
			if ( user.side == this.side ) {
				this.pylon_gun.on = !this.pylon_gun.on;
				this.icon_state = ( this.pylon_gun.on ? "defensepylon-" + this.side : "defensepylon" );
			}
			return;
		}

		// Function from file: structures.dm
		public override bool assign_deity( Mob_Camera_God new_deity = null, int? alert_old_deity = null ) {
			alert_old_deity = alert_old_deity ?? GlobalVars.TRUE;

			
			if ( base.assign_deity( new_deity, alert_old_deity ) && this.pylon_gun != null ) {
				this.pylon_gun.faction = new ByTable(new object [] { "" + this.side + " god" });
				this.pylon_gun.side = this.side;
			}
			return false;
		}

		// Function from file: structures.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );
			user.WriteMsg( new Txt( "<span class='notice'>" ).The( this ).item().str( " looks " ).item( ( this.pylon_gun.on ? "on" : "off" ) ).str( ".</span>" ).ToString() );
			return 0;
		}

		// Function from file: structures.dm
		public override dynamic Destroy(  ) {
			GlobalFuncs.qdel( this.pylon_gun );
			return base.Destroy();
		}

	}

}