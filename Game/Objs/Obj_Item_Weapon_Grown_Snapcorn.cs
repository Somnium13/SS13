// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Grown_Snapcorn : Obj_Item_Weapon_Grown {

		public int snap_pops = 1;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.seed = typeof(Obj_Item_Seeds_Snapcornseed);
			this.item_state = "corncob";
			this.w_class = 1;
			this.throw_speed = 3;
			this.icon_state = "snapcorn";
		}

		public Obj_Item_Weapon_Grown_Snapcorn ( dynamic newloc = null, int? new_potency = null ) : base( (object)(newloc), new_potency ) {
			
		}

		// Function from file: growninedible.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			Obj_Item_Toy_Snappop S = null;

			base.attack_self( (object)(user), (object)(flag), emp );
			user.WriteMsg( "<span class='notice'>You pick up a snap pops from the cob.</span>" );
			S = new Obj_Item_Toy_Snappop( user.loc );

			if ( user is Mob_Living_Carbon_Human ) {
				((Mob)user).put_in_hands( S );
			}
			this.snap_pops -= 1;

			if ( !( this.snap_pops != 0 ) ) {
				new Obj_Item_Weapon_Grown_Corncob( user.loc );
				GlobalFuncs.qdel( this );
			}
			return null;
		}

		// Function from file: growninedible.dm
		public override bool add_juice(  ) {
			base.add_juice();
			this.snap_pops = Num13.MaxInt( Num13.Floor( ( this.potency ??0) / 8 ), 1 );
			return false;
		}

	}

}