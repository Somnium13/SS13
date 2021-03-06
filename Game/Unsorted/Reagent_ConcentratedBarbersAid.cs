// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_ConcentratedBarbersAid : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Concentrated Barber's Aid";
			this.id = "concentrated_barbers_aid";
			this.description = "A concentrated solution to hair loss across the world.";
			this.color = "#C8A5DC";
		}

		// Function from file: other_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			dynamic H = null;

			
			if ( method == GlobalVars.TOUCH || method == GlobalVars.VAPOR ) {
				
				if ( Lang13.Bool( M ) && M is Mob_Living_Carbon_Human ) {
					H = M;
					H.hair_style = "Very Long Hair";
					H.facial_hair_style = "Very Long Beard";
					((Mob)H).update_hair();
				}
			}
			return 0;
		}

	}

}