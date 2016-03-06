// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Alien_Resin_FlowerBudEnemy : Obj_Structure_Alien_Resin {

		public int growth_time = 1200;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.canSmoothWith = new ByTable();
			this.icon = "icons/effects/spacevines.dmi";
			this.icon_state = "flower_bud";
			this.layer = 4;
		}

		// Function from file: venus_human_trap.dm
		public Obj_Structure_Alien_Resin_FlowerBudEnemy ( dynamic location = null ) : base( (object)(location) ) {
			ByTable anchors = null;
			dynamic T = null;
			Beam B = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			anchors = new ByTable();
			anchors.Add( Map13.GetTile( this.x - 2, this.y + 2, this.z ) );
			anchors.Add( Map13.GetTile( this.x + 2, this.y + 2, this.z ) );
			anchors.Add( Map13.GetTile( this.x - 2, this.y - 2, this.z ) );
			anchors.Add( Map13.GetTile( this.x + 2, this.y - 2, this.z ) );

			foreach (dynamic _a in Lang13.Enumerate( anchors )) {
				T = _a;
				
				B = this.Beam( T, "vine", "icons/effects/spacevines.dmi", Double.PositiveInfinity, 5, typeof(Obj_Effect_Ebeam_Vine) );
				B.sleep_time = 10;
			}
			Task13.Schedule( this.growth_time, (Task13.Closure)(() => {
				this.visible_message( "<span class='danger'>the plant has borne fruit!</span>" );
				new Mob_Living_SimpleAnimal_Hostile_VenusHumanTrap( GlobalFuncs.get_turf( this ) );
				GlobalFuncs.qdel( this );
				return;
			}));
			return;
		}

	}

}