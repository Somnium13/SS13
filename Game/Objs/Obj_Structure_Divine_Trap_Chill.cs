// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Divine_Trap_Chill : Obj_Structure_Divine_Trap {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "trap-frost";
		}

		public Obj_Structure_Divine_Trap_Chill ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: traps.dm
		public override void trap_effect( Ent_Dynamic L = null ) {
			((dynamic)L).WriteMsg( "<span class='danger'><B>You're frozen solid!</B></span>" );
			((Mob)L).Weaken( 1 );
			((dynamic)L).bodytemperature -= 300;
			new Obj_Effect_ParticleEffect_Sparks( GlobalFuncs.get_turf( L ) );
			return;
		}

	}

}