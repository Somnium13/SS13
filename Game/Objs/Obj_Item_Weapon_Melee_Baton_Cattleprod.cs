// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Melee_Baton_Cattleprod : Obj_Item_Weapon_Melee_Baton {

		public dynamic sparkler = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "prod";
			this.force = 3;
			this.throwforce = 5;
			this.stunforce = 5;
			this.hitcost = 2500;
			this.icon_state = "stunprod_nocell";
		}

		// Function from file: stunbaton.dm
		public Obj_Item_Weapon_Melee_Baton_Cattleprod ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.sparkler = new Obj_Item_Device_Assembly_Igniter( this );
			return;
		}

		// Function from file: teleprod.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			Obj_Item_Weapon_Melee_Baton_Cattleprod_Teleprod S = null;

			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Weapon_Ore_BluespaceCrystal ) {
				
				if ( !Lang13.Bool( this.bcell ) ) {
					S = new Obj_Item_Weapon_Melee_Baton_Cattleprod_Teleprod();

					if ( !this.remove_item_from_storage( user ) ) {
						((Mob)user).unEquip( this );
					}
					((Mob)user).unEquip( A );
					((Mob)user).put_in_hands( S );
					user.WriteMsg( "<span class='notice'>You clamp the bluespace crystal securely with the wirecutters.</span>" );
					A.loc = S;
					GlobalFuncs.qdel( this );
				} else {
					((Ent_Static)user).visible_message( "<span class='warning'>You can't install the crystal onto the stunprod while it has a powercell installed!</span>" );
				}
			}
			return null;
		}

		// Function from file: stunbaton.dm
		public override bool baton_stun( dynamic L = null, dynamic user = null ) {
			
			if ( Lang13.Bool( this.sparkler.activate() ) ) {
				base.baton_stun( (object)(L), (object)(user) );
			}
			return false;
		}

	}

}