// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_BarbersAid : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Barber's Aid";
			this.id = "barbers_aid";
			this.description = "A solution to hair loss across the world.";
			this.color = "#C8A5DC";
		}

		// Function from file: other_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			dynamic H = null;
			dynamic picked_hair = null;
			dynamic picked_beard = null;

			
			if ( method == GlobalVars.TOUCH || method == GlobalVars.VAPOR ) {
				
				if ( Lang13.Bool( M ) && M is Mob_Living_Carbon_Human ) {
					H = M;
					picked_hair = Rand13.PickFromTable( GlobalVars.hair_styles_list );
					picked_beard = Rand13.PickFromTable( GlobalVars.facial_hair_styles_list );
					H.hair_style = picked_hair;
					H.facial_hair_style = picked_beard;
					((Mob)H).update_hair();
				}
			}
			return 0;
		}

	}

}