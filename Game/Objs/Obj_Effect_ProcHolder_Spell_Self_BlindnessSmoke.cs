// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_Self_BlindnessSmoke : Obj_Effect_ProcHolder_Spell_Self {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.panel = "Shadowling Abilities";
			this.charge_max = 600;
			this.human_req = 1;
			this.clothes_req = 0;
			this.action_icon_state = "black_smoke";
			this.sound = "sound/effects/bamf.ogg";
		}

		public Obj_Effect_ProcHolder_Spell_Self_BlindnessSmoke ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: shadowling_abilities.dm
		public override bool cast( dynamic targets = null, dynamic thearea = null, dynamic user = null ) {
			Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Large B = null;
			EffectSystem_SmokeSpread_Chem S = null;

			
			if ( !this.shadowling_check( targets ) ) {
				this.revert_cast();
				return false;
			}
			((Ent_Static)targets).visible_message( "<span class='warning'>" + targets + " bends over and coughs out a cloud of black smoke!</span>" );
			targets.WriteMsg( "<span class='shadowling'>You regurgitate a vast cloud of blinding smoke.</span>" );
			B = new Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Large( targets.loc );
			B.reagents.clear_reagents();
			B.invisibility = Int32.MaxValue;
			B.reagents.add_reagent( "blindness_smoke", 10 );
			S = new EffectSystem_SmokeSpread_Chem();
			S.attach( B );

			if ( S != null ) {
				S.set_up( B.reagents, 4, 0, B.loc );
				S.start();
			}
			GlobalFuncs.qdel( B );
			return false;
		}

	}

}