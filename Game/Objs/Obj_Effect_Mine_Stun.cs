// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Mine_Stun : Obj_Effect_Mine {

		public int stun_time = 8;

		public Obj_Effect_Mine_Stun ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mines.dm
		public override void mineEffect( Ent_Dynamic victim = null ) {
			
			if ( victim is Mob_Living ) {
				((Mob)victim).Weaken( this.stun_time );
			}
			return;
		}

	}

}