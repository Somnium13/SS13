// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Charcoal : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Activated Charcoal";
			this.id = "charcoal";
			this.reagent_state = 2;
			this.color = "#333333";
		}

		// Function from file: vgstation13.dme
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			Mob_Living H = null;
			Reagent reagent = null;

			
			if ( !( M != null ) ) {
				M = ((dynamic)this.holder).my_atom;
			}

			if ( M is Mob_Living_Carbon_Human && Rand13.PercentChance( 5 ) ) {
				H = M;
				((dynamic)H).vomit();
				((dynamic)this.holder).remove_reagent( "charcoal", this.volume );
				return false;
			}

			foreach (dynamic _a in Lang13.Enumerate( ((dynamic)this.holder).reagent_list, typeof(Reagent) )) {
				reagent = _a;
				
				Interface13.Stat( null, GlobalVars.charcoal_doesnt_remove.Contains( reagent.id ) );

				if ( reagent is Reagent ) {
					continue;
				}
				((dynamic)this.holder).remove_reagent( reagent.id, 1.5 );
			}
			M.adjustToxLoss( -1 );
			base.on_mob_life( M, alien );
			return false;
		}

	}

}