// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SurgeryStep_ExtractOrgan : SurgeryStep {

		public Obj_Item IC = null;
		public ByTable organ_types = new ByTable(new object [] { typeof(Obj_Item_Organ_Internal_Heart) });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "remove heart";
			this.accept_hand = true;
			this.time = 32;
		}

		// Function from file: abduction_surgery.dm
		public override bool success( dynamic user = null, Mob target = null, string target_zone = null, dynamic tool = null, Surgery surgery = null ) {
			
			if ( this.IC != null ) {
				((Ent_Static)user).visible_message( "" + user + " pulls " + this.IC + " out of " + target + "'s " + target_zone + "!", "<span class='notice'>You pull " + this.IC + " out of " + target + "'s " + target_zone + ".</span>" );
				((Mob)user).put_in_hands( this.IC );
				new ByTable().Set( 1, target ).Set( "special", 1 ).Apply( Lang13.BindFunc( this.IC, "Remove" ) );
				return true;
			} else {
				user.WriteMsg( "<span class='warning'>You don't find anything in " + target + "'s " + target_zone + "!</span>" );
				return false;
			}
		}

		// Function from file: abduction_surgery.dm
		public override int preop( dynamic user = null, Mob target = null, string target_zone = null, dynamic tool = null, Surgery surgery = null ) {
			Obj_Item I = null;

			
			foreach (dynamic _a in Lang13.Enumerate( ((dynamic)target).internal_organs, typeof(Obj_Item) )) {
				I = _a;
				

				if ( this.organ_types.Contains( I.type ) ) {
					this.IC = I;
					break;
				}
			}
			((Ent_Static)user).visible_message( "" + user + " starts to remove " + target + "'s organs.", "<span class='notice'>You start to remove " + target + "'s organs...</span>" );
			return 0;
		}

	}

}