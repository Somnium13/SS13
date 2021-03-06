// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Falsewall_Plasma : Obj_Structure_Falsewall {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mineral = "plasma";
			this.walltype = "plasma";
			this.canSmoothWith = new ByTable(new object [] { typeof(Obj_Structure_Falsewall_Plasma), typeof(Tile_Simulated_Wall_Mineral_Plasma) });
			this.icon = "icons/turf/walls/plasma_wall.dmi";
			this.icon_state = "plasma";
		}

		public Obj_Structure_Falsewall_Plasma ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: false_walls.dm
		public override dynamic temperature_expose( GasMixture air = null, dynamic exposed_temperature = null, int? exposed_volume = null ) {
			
			if ( Convert.ToDouble( exposed_temperature ) > 300 ) {
				this.burnbabyburn();
			}
			return null;
		}

		// Function from file: false_walls.dm
		public void burnbabyburn( dynamic user = null ) {
			GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );
			this.atmos_spawn_air( 5, 400 );
			new Obj_Structure_Girder_Displaced( this.loc );
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: false_walls.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( ((Obj_Item)A).is_hot() > 300 ) {
				GlobalFuncs.message_admins( new Txt( "Plasma falsewall ignited by " ).item( GlobalFuncs.key_name_admin( user ) ).str( "(<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( user ).str( "'>?</A>) (<A HREF='?_src_=holder;adminplayerobservefollow=" ).Ref( user ).str( "'>FLW</A>) in (" ).item( this.x ).str( "," ).item( this.y ).str( "," ).item( this.z ).str( " - <A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" ).item( this.x ).str( ";Y=" ).item( this.y ).str( ";Z=" ).item( this.z ).str( "'>JMP</a>)" ).ToString() );
				GlobalFuncs.log_game( "Plasma falsewall ignited by " + GlobalFuncs.key_name( user ) + " in (" + this.x + "," + this.y + "," + this.z + ")" );
				this.burnbabyburn();
				return null;
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

	}

}