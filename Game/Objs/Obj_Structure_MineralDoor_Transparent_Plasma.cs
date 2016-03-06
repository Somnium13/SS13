// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_MineralDoor_Transparent_Plasma : Obj_Structure_MineralDoor_Transparent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mineralType = "plasma";
		}

		public Obj_Structure_MineralDoor_Transparent_Plasma ( dynamic location = null ) : base( (object)(location) ) {
			
		}

		// Function from file: mineral_doors.dm
		public void TemperatureAct( dynamic temperature = null ) {
			this.atmos_spawn_air( 5, 500 );
			this.hardness = 0;
			this.CheckHardness();
			return;
		}

		// Function from file: mineral_doors.dm
		public override dynamic temperature_expose( GasMixture air = null, dynamic exposed_temperature = null, int? exposed_volume = null ) {
			
			if ( Convert.ToDouble( exposed_temperature ) > 300 ) {
				this.TemperatureAct( exposed_temperature );
			}
			return null;
		}

		// Function from file: mineral_doors.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( ((Obj_Item)A).is_hot() != 0 ) {
				GlobalFuncs.message_admins( new Txt( "Plasma mineral door ignited by " ).item( GlobalFuncs.key_name_admin( user ) ).str( "(<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( user ).str( "'>?</A>) (<A HREF='?_src_=holder;adminplayerobservefollow=" ).Ref( user ).str( "'>FLW</A>) in (" ).item( this.x ).str( "," ).item( this.y ).str( "," ).item( this.z ).str( " - <A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" ).item( this.x ).str( ";Y=" ).item( this.y ).str( ";Z=" ).item( this.z ).str( "'>JMP</a>)" ).ToString() );
				GlobalFuncs.log_game( "Plasma mineral door ignited by " + GlobalFuncs.key_name( user ) + " in (" + this.x + "," + this.y + "," + this.z + ")" );
				this.TemperatureAct( 100 );
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

	}

}