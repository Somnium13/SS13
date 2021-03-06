// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Changeling_Weapon : Obj_Effect_ProcHolder_Changeling {

		public Type weapon_type = null;
		public string weapon_name_simple = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.helptext = "Yell at Miauw and/or Perakp";
			this.chemical_cost = 1000;
			this.genetic_damage = 1000;
		}

		public Obj_Effect_ProcHolder_Changeling_Weapon ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mutations.dm
		public override void on_refund( Mob user = null ) {
			this.check_weapon( user, user.r_hand, true );
			this.check_weapon( user, user.l_hand, false );
			return;
		}

		// Function from file: mutations.dm
		public override dynamic sting_action( Mob user = null, Ent_Static target = null ) {
			dynamic W = null;

			
			if ( !user.drop_item() ) {
				user.WriteMsg( "<span class='warning'>The " + user.get_active_hand() + " is stuck to your hand, you cannot grow a " + this.weapon_name_simple + " over it!</span>" );
				return null;
			}
			W = Lang13.Call( this.weapon_type, user );
			user.put_in_hands( W );
			GlobalFuncs.playsound( user, "sound/effects/blobattack.ogg", 30, 1 );
			return W;
		}

		// Function from file: mutations.dm
		public bool check_weapon( Mob user = null, dynamic hand_item = null, bool? right_hand = null ) {
			right_hand = right_hand ?? true;

			
			if ( Lang13.Bool( ((dynamic)this.weapon_type).IsInstanceOfType( hand_item ) ) ) {
				GlobalFuncs.playsound( user, "sound/effects/blobattack.ogg", 30, 1 );
				GlobalFuncs.qdel( hand_item );
				user.visible_message( "<span class='warning'>With a sickening crunch, " + user + " reforms their " + this.weapon_name_simple + " into an arm!</span>", "<span class='notice'>We assimilate the " + this.weapon_name_simple + " back into our body.</span>", "<span class='italics>You hear organic matter ripping and tearing!</span>" );

				if ( right_hand == true ) {
					user.update_inv_r_hand();
				} else {
					user.update_inv_l_hand();
				}
				return true;
			}
			return false;
		}

		// Function from file: mutations.dm
		public override void try_to_sting( Mob user = null, Ent_Static target = null ) {
			
			if ( this.check_weapon( user, user.r_hand, true ) ) {
				return;
			}

			if ( this.check_weapon( user, user.l_hand, false ) ) {
				return;
			}
			base.try_to_sting( user, target );
			return;
		}

	}

}