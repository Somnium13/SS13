// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Blob_ZombifyingFeelers : Reagent_Blob {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Zombifying Feelers";
			this.id = "zombifying_feelers";
			this.description = "will cause medium toxin damage and turn sleeping targets into blob zombies.";
			this.color = "#828264";
			this.message_living = ", and you feel tired";
		}

		// Function from file: blob_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			Mob_Living_SimpleAnimal_Hostile_Blob_Blobspore_Weak BS = null;

			reac_volume = base.reaction_mob( (object)(M), method, reac_volume, show_message, (object)(touch_protection), O );
			M.apply_damage( ( reac_volume ??0) * 0.6, "tox" );

			if ( O != null && M is Mob_Living_Carbon_Human && Lang13.Bool( M.stat ) == true ) {
				((Mob)M).death();
				BS = new Mob_Living_SimpleAnimal_Hostile_Blob_Blobspore_Weak( GlobalFuncs.get_turf( M ) );
				BS.overmind = O;
				BS.update_icons();
				O.blob_mobs.Add( BS );
				BS.Zombify( M );
			}
			return 0;
		}

	}

}