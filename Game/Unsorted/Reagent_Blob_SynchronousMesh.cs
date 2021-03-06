// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Blob_SynchronousMesh : Reagent_Blob {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Synchronous Mesh";
			this.id = "synchronous_mesh";
			this.description = "will do brute damage for each nearby blob and spread damage between nearby blobs.";
			this.shortdesc = "will do brute damage for each nearby blob.";
			this.color = "#65ADA2";
			this.blobbernaut_message = "synchronously strikes";
			this.message = "The blobs strike you";
		}

		// Function from file: blob_reagents.dm
		public override dynamic damage_reaction( Obj_Effect_Blob B = null, double original_health = 0, dynamic damage = null, dynamic damage_type = null, dynamic cause = null ) {
			double damagesplit = 0;
			Obj_Effect_Blob C = null;
			Obj_Effect_Blob C2 = null;

			
			if ( !( cause == null ) ) {
				damagesplit = 0.8;

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( B, 1 ), typeof(Obj_Effect_Blob) )) {
					C = _a;
					

					if ( C.overmind != null && C.overmind.blob_reagent_datum == B.overmind.blob_reagent_datum ) {
						damagesplit += 0.8;
					}
				}

				foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( B, 1 ), typeof(Obj_Effect_Blob) )) {
					C2 = _b;
					

					if ( C2.overmind != null && C2.overmind.blob_reagent_datum == B.overmind.blob_reagent_datum && !( C2 is Obj_Effect_Blob_Core ) ) {
						C2.take_damage( damage / damagesplit, "clone", B, false );
					}
				}
				return damage / damagesplit;
			} else {
				return damage * 1.25;
			}
		}

		// Function from file: blob_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			Obj_Effect_Blob B = null;

			reac_volume = base.reaction_mob( (object)(M), method, reac_volume, show_message, (object)(touch_protection), O );
			((Mob_Living)M).apply_damage( ( reac_volume ??0) * 0.1, "brute" );

			if ( Lang13.Bool( M ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( M, 1 ), typeof(Obj_Effect_Blob) )) {
					B = _a;
					

					if ( Lang13.Bool( M ) ) {
						B.blob_attack_animation( M );
						((Mob_Living)M).apply_damage( ( reac_volume ??0) * 0.3, "brute" );
					}
				}
			}
			return 0;
		}

	}

}