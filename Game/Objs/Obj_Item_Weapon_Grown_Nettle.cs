// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Grown_Nettle : Obj_Item_Weapon_Grown {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damtype = "fire";
			this.force = 15;
			this.hitsound = "sound/weapons/bladeslice.ogg";
			this.throwforce = 5;
			this.w_class = 1;
			this.throw_speed = 1;
			this.throw_range = 3;
			this.plant_type = 1;
			this.origin_tech = "combat=1";
			this.attack_verb = new ByTable(new object [] { "stung" });
			this.icon_state = "nettle";
		}

		public Obj_Item_Weapon_Grown_Nettle ( dynamic newloc = null, int? new_potency = null ) : base( (object)(newloc), new_potency ) {
			
		}

		// Function from file: growninedible.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			
			if ( !( proximity_flag == true ) ) {
				return false;
			}

			if ( Convert.ToDouble( this.force ) > 0 ) {
				this.force -= Rand13.Int( 1, Convert.ToInt32( this.force / 3 + 1 ) );
			} else {
				Task13.User.WriteMsg( "All the leaves have fallen off the nettle from violent whacking." );
				Task13.User.unEquip( this );
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: growninedible.dm
		public override bool pickup( dynamic user = null ) {
			dynamic C = null;
			dynamic H = null;
			string organ = null;
			Obj_Item_Organ_Limb affecting = null;

			
			if ( !( user is Mob_Living_Carbon ) ) {
				return false;
			}
			C = user;

			if ( user is Mob_Living_Carbon_Human ) {
				H = C;

				if ( Lang13.Bool( H.gloves ) ) {
					return false;
				}
				organ = ( H.hand ? "l_" : "r_" ) + "arm";
				affecting = ((Mob_Living_Carbon_Human)H).get_organ( organ );

				if ( affecting.take_damage( 0, this.force ) ) {
					((Mob_Living)H).update_damage_overlays(  );
				}
			} else {
				((Mob_Living)C).take_organ_damage( 0, this.force );
			}
			C.WriteMsg( "<span class='userdanger'>The nettle burns your bare hand!</span>" );
			return true;
		}

		// Function from file: growninedible.dm
		public override int suicide_act( Mob_Living_Carbon_Human user = null ) {
			user.visible_message( new Txt( "<span class='suicide'>" ).item( user ).str( " is eating some of the " ).item( this.name ).str( "! It looks like " ).he_she_it_they().str( "'s trying to commit suicide.</span>" ).ToString() );
			return 5;
		}

	}

}