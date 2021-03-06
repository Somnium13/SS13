// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimegolem : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime Golem";
			this.id = "m_golem";
			this.required_reagents = new ByTable().Set( "plasma", 1 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Adamantine);
			this.required_other = true;
		}

		// Function from file: slime_extracts.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			Obj_Effect_Golemrune Z = null;

			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + this.type );
			Z = new Obj_Effect_Golemrune();
			Z.loc = GlobalFuncs.get_turf( holder.my_atom );
			GlobalFuncs.notify_ghosts( "Golem rune created in " + GlobalFuncs.get_area( Z ) + ".", "sound/effects/ghost2.ogg", null, Z );
			return;
		}

	}

}