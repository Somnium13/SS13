// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Medicine_SilverSulfadiazine : Reagent_Medicine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Silver Sulfadiazine";
			this.id = "silver_sulfadiazine";
			this.description = "If used in touch-based applications, immediately restores burn wounds as well as restoring more over time. If ingested through other means, deals minor toxin damage.";
			this.color = "#C8A5DC";
		}

		// Function from file: medicine_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			((Mob_Living)M).adjustFireLoss( -2 );
			base.on_mob_life( (object)(M) );
			return false;
		}

		// Function from file: medicine_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;
			show_message = show_message ?? true;

			
			if ( M is Mob_Living_Carbon && Convert.ToInt32( M.stat ) != 2 ) {
				
				if ( new ByTable(new object [] { GlobalVars.INGEST, GlobalVars.VAPOR, GlobalVars.INJECT }).Contains( method ) ) {
					((Mob_Living)M).adjustToxLoss( ( reac_volume ??0) * 0.5 );

					if ( show_message == true ) {
						M.WriteMsg( "<span class='warning'>You don't feel so good...</span>" );
					}
				} else if ( ((Mob_Living)M).getFireLoss() != 0 ) {
					((Mob_Living)M).adjustFireLoss( -( reac_volume ??0) );

					if ( show_message == true ) {
						M.WriteMsg( "<span class='danger'>You feel your burns healing! It stings like hell!</span>" );
					}
					((Mob)M).emote( "scream" );
				}
			}
			base.reaction_mob( (object)(M), method, reac_volume, show_message, (object)(touch_protection), O );
			return 0;
		}

	}

}