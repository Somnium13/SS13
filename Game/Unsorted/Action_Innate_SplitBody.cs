// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Action_Innate_SplitBody : Action_Innate {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Split Body";
			this.check_flags = 8;
			this.button_icon_state = "slimesplit";
			this.background_icon_state = "bg_alien";
		}

		public Action_Innate_SplitBody ( Obj_Item_Weapon_Tank Target = null ) : base( Target ) {
			
		}

		// Function from file: species_types.dm
		public override void Activate( int? forced_state = null ) {
			dynamic H = null;
			Reagent_Toxin_Slimejelly S = null;
			Mob_Living_Carbon_Human spare = null;
			Action_Innate_SwapBody callforward = null;
			Action_Innate_SwapBody callback = null;

			H = this.owner;
			H.WriteMsg( "<span class='notice'>You focus intently on moving your body while standing perfectly still...</span>" );
			H.notransform = 1;

			foreach (dynamic _a in Lang13.Enumerate( H.reagents.reagent_list, typeof(Reagent_Toxin_Slimejelly) )) {
				S = _a;
				

				if ( S.volume >= 200 ) {
					spare = new Mob_Living_Carbon_Human( H.loc );
					spare.underwear = "Nude";
					new ByTable().Set( 1, spare ).Set( "transfer_SE", 1 ).Apply( Lang13.BindFunc( H.dna, "transfer_identity" ) );
					H.dna.features["mcolor"] = Rand13.Pick(new object [] { "FFFFFF", "7F7F7F", "7FFF7F", "7F7FFF", "FF7F7F", "7FFFFF", "FF7FFF", "FFFF7F" });
					spare.real_name = spare.dna.real_name;
					spare.name = spare.dna.real_name;
					spare.updateappearance( null, true );
					spare.domutcheck();
					spare.Move( Map13.GetStep( H.loc, Convert.ToInt32( Rand13.Pick(new object [] { GlobalVars.NORTH, GlobalVars.SOUTH, GlobalVars.EAST, GlobalVars.WEST }) ) ) );
					S.volume = 80;
					H.notransform = 0;
					callforward = new Action_Innate_SwapBody();
					callback = new Action_Innate_SwapBody();
					callforward.body = spare;
					callforward.Grant( H );
					callback.body = H;
					callback.Grant( spare );
					((Mind)H.mind).transfer_to( spare );
					spare.WriteMsg( "<span class='notice'>...and after a moment of disorentation, you're besides yourself!</span>" );
					return;
				}
			}
			H.WriteMsg( "<span class='warning'>...but there is not enough of you to go around! You must attain more mass to split!</span>" );
			H.notransform = 0;
			return;
		}

		// Function from file: species_types.dm
		public override bool CheckRemoval( dynamic user = null ) {
			dynamic H = null;

			H = this.owner;

			if ( !( H is Mob_Living_Carbon_Human ) || !Lang13.Bool( H.dna ) || !Lang13.Bool( H.dna.species ) || H.dna.species.id != "slime" ) {
				return true;
			}
			return false;
		}

	}

}