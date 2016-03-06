// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Changeling_Adrenaline : Obj_Effect_ProcHolder_Changeling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.helptext = "Removes all stuns instantly and adds a short-term reduction in further stuns. Can be used while unconscious. Continued use poisons the body.";
			this.chemical_cost = 30;
			this.dna_cost = 2;
			this.req_human = true;
			this.req_stat = 1;
		}

		public Obj_Effect_ProcHolder_Changeling_Adrenaline ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: adrenaline.dm
		public override dynamic sting_action( Mob user = null, Ent_Static target = null ) {
			user.WriteMsg( "<span class='notice'>Energy rushes through us." + ( Lang13.Bool( user.lying ) ? " We arise." : "" ) + "</span>" );
			user.SetSleeping( 0 );
			user.SetParalysis( 0 );
			user.SetStunned( 0 );
			user.SetWeakened( 0 );
			user.reagents.add_reagent( "changelingAdrenaline", 10 );
			user.reagents.add_reagent( "changelingAdrenaline2", 2 );
			((dynamic)user).adjustStaminaLoss( -75 );
			GlobalFuncs.feedback_add_details( "changeling_powers", "UNS" );
			return 1;
		}

	}

}