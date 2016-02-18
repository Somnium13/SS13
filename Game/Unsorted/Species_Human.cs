// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Species_Human : Species {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Human";
			this.id = "human";
			this.default_color = "FFFFFF";
			this.roundstart = true;
			this.specflags = new ByTable(new object [] { 8, 2, 4, 16 });
			this.mutant_bodyparts = new ByTable(new object [] { "tail_human", "ears" });
			this.default_features = new ByTable().Set( "mcolor", "FFF" ).Set( "tail_human", "None" ).Set( "ears", "None" );
			this.use_skintones = true;
			this.skinned_type = typeof(Obj_Item_Stack_Sheet_Animalhide_Human);
		}

		// Function from file: species_types.dm
		public override void spec_death( bool? gibbed = null, Mob_Living_Carbon_Human H = null ) {
			
			if ( H != null ) {
				H.endTailWag();
			}
			return;
		}

		// Function from file: species_types.dm
		public override bool handle_chemicals( dynamic chem = null, Mob_Living H = null ) {
			
			if ( chem.id == "mutationtoxin" ) {
				H.WriteMsg( "<span class='danger'>Your flesh rapidly mutates!</span>" );
				H.set_species( typeof(Species_Jelly_Slime) );
				H.reagents.del_reagent( chem.type );
				H.faction |= "slime";
				return true;
			}
			return false;
		}

		// Function from file: species_types.dm
		public override bool qualifies_for_rank( string rank = null, ByTable features = null ) {
			
			if ( ( !Lang13.Bool( features["tail_human"] ) || features["tail_human"] == "None" ) && ( !Lang13.Bool( features["ears"] ) || features["ears"] == "None" ) ) {
				return true;
			}

			if ( GlobalVars.security_positions.Contains( rank ) ) {
				return false;
			}

			if ( GlobalVars.science_positions.Contains( rank ) ) {
				return false;
			}

			if ( GlobalVars.medical_positions.Contains( rank ) ) {
				return false;
			}

			if ( GlobalVars.engineering_positions.Contains( rank ) ) {
				return false;
			}

			if ( rank == "Quartermaster" ) {
				return false;
			}
			return base.qualifies_for_rank( rank, features );
		}

	}

}