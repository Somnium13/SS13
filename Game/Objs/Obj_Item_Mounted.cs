// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Mounted : Obj_Item {

		public ByTable buildon_types = new ByTable(new object [] { typeof(Tile_Simulated_Wall), typeof(Tile_Simulated_Shuttle_Wall) });

		public Obj_Item_Mounted ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mountables.dm
		public virtual void do_build( dynamic on_wall = null, dynamic user = null ) {
			return;
		}

		// Function from file: mountables.dm
		public virtual bool try_build( dynamic on_wall = null, dynamic user = null, bool? proximity_flag = null ) {
			
			if ( !Lang13.Bool( on_wall ) || !Lang13.Bool( user ) ) {
				return false;
			}

			if ( proximity_flag != true ) {
				return false;
			}

			if ( !GlobalVars.cardinal.Contains( Map13.GetDistance( user, on_wall ) ) ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='rose'>You need to be standing next to a wall to place " ).the( this ).item().str( ".</span>" ).ToString() );
				return false;
			}

			if ( GlobalFuncs.gotwallitem( GlobalFuncs.get_turf( user ), Map13.GetDistance( user, on_wall ) ) ) {
				GlobalFuncs.to_chat( user, "<span class='rose'>There's already an item on this wall!</span>" );
				return false;
			}
			return true;
		}

		// Function from file: mountables.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			bool found_type = false;
			dynamic turf_type = null;

			found_type = false;

			foreach (dynamic _a in Lang13.Enumerate( this.buildon_types )) {
				turf_type = _a;
				

				if ( Lang13.Bool( turf_type.IsInstanceOfType( A ) ) ) {
					found_type = true;
					break;
				}
			}

			if ( found_type ) {
				
				if ( this.try_build( A, user, flag ) ) {
					this.do_build( A, user ); return false;
				}
			} else {
				base.afterattack( (object)(A), (object)(user), flag, (object)(_params), struggle );
			}
			return false;
		}

	}

}