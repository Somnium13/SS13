// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_Targeted_EtherealJaunt_Shift : Obj_Effect_ProcHolder_Spell_Targeted_EtherealJaunt {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.charge_max = 200;
			this.clothes_req = 0;
			this.action_icon_state = "phaseshift";
			this.action_background_icon_state = "bg_demon";
		}

		public Obj_Effect_ProcHolder_Spell_Targeted_EtherealJaunt_Shift ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: construct_spells.dm
		public override void jaunt_steam( dynamic mobloc = null ) {
			return;
		}

		// Function from file: construct_spells.dm
		public override void jaunt_reappear( Dynamic_Overlay animation = null, Mob_Living target = null ) {
			animation.icon_state = "phase_shift2";
			animation.dir = target.dir;
			Icon13.Flick( "phase_shift2", animation );
			return;
		}

		// Function from file: construct_spells.dm
		public override void jaunt_disappear( Dynamic_Overlay animation = null, Mob_Living target = null ) {
			animation.icon_state = "phase_shift";
			animation.dir = target.dir;
			Icon13.Flick( "phase_shift", animation );
			return;
		}

	}

}