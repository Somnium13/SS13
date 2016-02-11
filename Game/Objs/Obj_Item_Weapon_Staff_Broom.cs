// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Staff_Broom : Obj_Item_Weapon_Staff {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "broom0";
			this.flags = 288;
			this.icon_state = "broom";
		}

		public Obj_Item_Weapon_Staff_Broom ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: weapon.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Clothing_Mask_Horsehead ) {
				new Obj_Item_Weapon_Staff_Broom_Horsebroom( GlobalFuncs.get_turf( this ) );
				((Mob)b).u_equip( a );
				GlobalFuncs.qdel( a );
				GlobalFuncs.qdel( this );
				return null;
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: weapon.dm
		public override void update_wield( dynamic user = null ) {
			base.update_wield( (object)(user) );
			this.item_state = "broom" + ( Lang13.Bool( this.wielded ) ? true : false );
			this.force = ( Lang13.Bool( this.wielded ) ? 5 : 3 );
			this.attack_verb = ( Lang13.Bool( this.wielded ) ? new ByTable(new object [] { "rammed into", "charged at" }) : new ByTable(new object [] { "bludgeoned", "whacked", "cleaned" }) );

			if ( Lang13.Bool( user ) ) {
				((Mob)user).update_inv_l_hand();
				((Mob)user).update_inv_r_hand();

				if ( GlobalVars.ticker.mode.wizards.Contains( user.mind ) ) {
					user.flying = ( Lang13.Bool( this.wielded ) ? true : false );

					if ( Lang13.Bool( this.wielded ) ) {
						GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>You hold " ).the( this ).item().str( " between your legs.</span>" ).ToString() );
						((Ent_Dynamic)user).say( "QUID 'ITCH" );
						Icon13.Animate( new ByTable().Set( 1, user ).Set( "pixel_y", this.pixel_y + 10 ).Set( "time", 10 ).Set( "loop", 1 ).Set( "easing", 1 ) );
					} else {
						Icon13.Animate( new ByTable().Set( 1, user ).Set( "pixel_y", this.pixel_y + 10 ).Set( "time", 1 ).Set( "loop", 1 ) );
						Icon13.Animate( new ByTable().Set( 1, user ).Set( "pixel_y", this.pixel_y ).Set( "time", 10 ).Set( "loop", 1 ).Set( "easing", 1 ) );
						Icon13.Animate( user );

						if ( user.lying == true ) {
							user.pixel_y -= 6;
						}
					}
				} else if ( Lang13.Bool( this.wielded ) ) {
					GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>You hold " ).the( this ).item().str( " between your legs.</span>" ).ToString() );
				}
			}
			return;
		}

	}

}