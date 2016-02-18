// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimepsteroid : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime Steroid";
			this.id = "m_steroid";
			this.required_reagents = new ByTable().Set( "plasma", 1 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Purple);
			this.required_other = true;
		}

		// Function from file: slime_extracts.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			Obj_Item_Slimepotion_Steroid P = null;

			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + this.type );
			P = new Obj_Item_Slimepotion_Steroid();
			P.loc = GlobalFuncs.get_turf( holder.my_atom );
			return;
		}

	}

}