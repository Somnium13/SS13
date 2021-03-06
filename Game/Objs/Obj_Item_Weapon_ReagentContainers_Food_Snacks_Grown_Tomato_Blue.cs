// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato_Blue : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.seed = typeof(Obj_Item_Seeds_Bluetomatoseed);
			this.splat = typeof(Obj_Effect_Decal_Cleanable_Oil);
			this.filling_color = "#0000FF";
			this.icon_state = "bluetomato";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato_Blue ( dynamic newloc = null, int? new_potency = null ) : base( (object)(newloc), new_potency ) {
			
		}

		// Function from file: grown.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			Ent_Dynamic M = null;
			int stun = 0;
			int weaken = 0;

			
			if ( O is Mob_Living_Carbon ) {
				M = O;
				stun = Num13.MaxInt( 1, Num13.MinInt( ((int)( ( this.potency ??0) / 10 )), 10 ) );
				weaken = Num13.MaxInt( ((int)( 0.5 )), Num13.MinInt( ((int)( ( this.potency ??0) / 20 )), 5 ) );
				((dynamic)M).slip( stun, weaken, this );
			}
			return null;
		}

		// Function from file: grown.dm
		public override bool add_juice( dynamic loc = null, int? potency = null ) {
			base.add_juice( (object)(loc), potency );
			this.reagents.add_reagent( "lube", Num13.Round( ( this.potency ??0) / 5, 1 ) + 1 );
			return false;
		}

	}

}