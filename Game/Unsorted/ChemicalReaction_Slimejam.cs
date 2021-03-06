// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimejam : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime Jam";
			this.id = "m_jam";
			this.result = "slimejelly";
			this.required_reagents = new ByTable().Set( "sugar", 1 );
			this.result_amount = 10;
			this.required_container = typeof(Obj_Item_SlimeExtract_Purple);
			this.required_other = true;
		}

		// Function from file: slime_extracts.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + this.type );
			return;
		}

	}

}