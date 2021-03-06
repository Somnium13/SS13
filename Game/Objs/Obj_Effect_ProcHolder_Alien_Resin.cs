// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Alien_Resin : Obj_Effect_ProcHolder_Alien {

		public ByTable structures = new ByTable().Set( "resin wall", typeof(Obj_Structure_Alien_Resin_Wall) ).Set( "resin membrane", typeof(Obj_Structure_Alien_Resin_Membrane) ).Set( "resin nest", typeof(Obj_Structure_Bed_Nest) );

		protected override void __FieldInit() {
			base.__FieldInit();

			this.plasma_cost = 55;
			this.check_turf = true;
			this.action_icon_state = "alien_resin";
		}

		public Obj_Effect_ProcHolder_Alien_Resin ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: alien_powers.dm
		public override bool fire( Mob user = null ) {
			dynamic choice = null;

			
			if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Alien_Resin), user.loc ) ) ) {
				user.WriteMsg( "<span class='danger'>There is already a resin structure there.</span>" );
				return false;
			}
			choice = Interface13.Input( "Choose what you wish to shape.", "Resin building", null, null, this.structures, InputType.Null | InputType.Any );

			if ( !Lang13.Bool( choice ) ) {
				return false;
			}

			if ( !this.cost_check( this.check_turf, user ) ) {
				return false;
			}
			user.WriteMsg( "<span class='notice'>You shape a " + choice + ".</span>" );
			user.visible_message( "<span class='notice'>" + user + " vomits up a thick purple substance and begins to shape it.</span>" );
			choice = this.structures[choice];
			Lang13.Call( choice, user.loc );
			return true;
		}

	}

}