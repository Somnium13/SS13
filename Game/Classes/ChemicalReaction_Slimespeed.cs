// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimespeed : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime Speed";
			this.id = "m_speed";
			this.required_reagents = new ByTable().Set( "water", 1 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Red);
			this.required_other = true;
		}

		// Function from file: slime_extracts.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			Obj_Item_Slimepotion_Speed P = null;

			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + this.type );
			P = new Obj_Item_Slimepotion_Speed();
			P.loc = GlobalFuncs.get_turf( holder.my_atom );
			return;
		}

	}

}