// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SurgeryStep_Dethrall : SurgeryStep {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "cleanse contamination";
			this.implements = new ByTable().Set( typeof(Obj_Item_Device_Assembly_Flash), 100 ).Set( typeof(Obj_Item_Device_Flashlight_Pen), 80 ).Set( typeof(Obj_Item_Device_Flashlight), 40 );
			this.time = 30;
		}

		// Function from file: dethralling.dm
		public override bool success( dynamic user = null, Mob target = null, string target_zone = null, dynamic tool = null, Surgery surgery = null ) {
			dynamic C = null;
			dynamic S = null;

			
			if ( ((dynamic)target).dna.species.id == "l_shadowling" ) {
				target.WriteMsg( "<span class='shadowling'><b><i>NOT LIKE THIS!</i></b></span>" );
				((Ent_Static)user).visible_message( "<span class='warning'><b>" + target + " suddenly slams upward and knocks down " + user + "!</span>", "<span class='userdanger'>" + target + " suddenly bolts up and slams you with tremendous force!</span>" );
				user.resting = 0;
				((Mob)user).SetSleeping( 0 );
				((Mob)user).SetStunned( 0 );
				((Mob)user).SetWeakened( 0 );
				((Mob)user).SetParalysis( 0 );

				if ( user is Mob_Living_Carbon ) {
					C = user;
					((Mob)C).Weaken( 6 );
					C.apply_damage( 20, "brute", "chest" );
				} else if ( user is Mob_Living_Silicon ) {
					S = user;
					((Mob)S).Weaken( 8 );
					S.apply_damage( 20, "brute" );
					GlobalFuncs.playsound( S, "sound/effects/bang.ogg", 50, 1 );
				}
				return false;
			}
			((Ent_Static)user).visible_message( "" + user + " shines light onto the tumor in " + target + "'s head!", "<span class='notice'>You cleanse the contamination from " + target + "'s brain!</span>" );
			((GameMode)GlobalVars.ticker.mode).remove_thrall( target.mind, false );
			target.visible_message( "<span class='warning'>A strange black mass falls from " + target + "'s head!</span>" );
			new Obj_Item_Organ_Internal_Shadowtumor( GlobalFuncs.get_turf( target ) );
			return true;
		}

		// Function from file: dethralling.dm
		public override int preop( dynamic user = null, Mob target = null, string target_zone = null, dynamic tool = null, Surgery surgery = null ) {
			((Ent_Static)user).visible_message( "" + user + " reaches into " + target + "'s head with " + tool + ".", "<span class='notice'>You begin aligning " + tool + "'s light to the tumor on " + target + "'s brain...</span>" );
			return 0;
		}

	}

}