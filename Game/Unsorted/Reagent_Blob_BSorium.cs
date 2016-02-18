// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Blob_BSorium : Reagent_Blob {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Sorium";
			this.id = "b_sorium";
			this.description = "will do medium brute damage and throw nearby objects and enemies away from the target.";
			this.color = "#808000";
			this.message = "The blob slams into you and sends you flying";
		}

		// Function from file: blob_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			reac_volume = base.reaction_mob( (object)(M), method, reac_volume, show_message, (object)(touch_protection), O );
			this.reagent_vortex( M, 1, reac_volume );
			((Mob_Living)M).apply_damage( ( reac_volume ??0) * 0.4, "brute" );
			return 0;
		}

	}

}