// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_DockingPort_Stationary : Obj_DockingPort {

		public Type turf_type = typeof(Tile_Space);
		public Type area_type = typeof(Zone_Space);

		// Function from file: shuttle.dm
		public Obj_DockingPort_Stationary ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.SSshuttle.stationary.Add( this );

			if ( !Lang13.Bool( this.id ) ) {
				this.id = "" + GlobalVars.SSshuttle.stationary.len;
			}

			if ( this.name == "dock" ) {
				this.name = "dock" + GlobalVars.SSshuttle.stationary.len;
			}
			return;
		}

		// Function from file: shuttle.dm
		public override dynamic get_docked(  ) {
			return Lang13.FindIn( typeof(Obj_DockingPort_Mobile), this.loc );
		}

	}

}