// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Glowshroom : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom {

		public Type effect_path = typeof(Obj_Effect_Glowshroom);

		protected override void __FieldInit() {
			base.__FieldInit();

			this.seed = typeof(Obj_Item_Seeds_Glowshroom);
			this.filling_color = "#00FA9A";
			this.icon_state = "glowshroom";
		}

		// Function from file: grown.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Glowshroom ( dynamic loc = null, int? new_potency = null ) : base( (object)(loc), new_potency ) {
			new_potency = new_potency ?? 10;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.lifespan == 0 ) {
				this.lifespan = 120;
				this.endurance = 30;
				this.maturation = 15;
				this.production = true;
				this.yield = 3;
				this.potency = 30;
				this.plant_type = 2;
			}

			if ( this.loc is Mob ) {
				this.pickup( this.loc );
			} else {
				this.SetLuminosity( Num13.Round( ( this.potency ??0) / 10, 1 ) );
			}
			return;
		}

		// Function from file: grown.dm
		public override bool dropped( dynamic user = null ) {
			((Ent_Static)user).AddLuminosity( Num13.Round( -( this.potency ??0) / 10, 1 ) );
			this.SetLuminosity( Num13.Round( ( this.potency ??0) / 10, 1 ) );
			return false;
		}

		// Function from file: grown.dm
		public override bool pickup( dynamic user = null ) {
			this.SetLuminosity( 0 );
			((Ent_Static)user).AddLuminosity( Num13.Round( ( this.potency ??0) / 10, 1 ) );
			return false;
		}

		// Function from file: grown.dm
		public override dynamic Destroy(  ) {
			
			if ( this.loc is Mob ) {
				this.loc.AddLuminosity( Num13.Round( -( this.potency ??0) / 10, 1 ) );
			}
			return base.Destroy();
		}

		// Function from file: grown.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic planted = null;

			
			if ( user.loc is Tile_Space ) {
				return null;
			}
			planted = Lang13.Call( this.effect_path, user.loc );
			planted.delay = planted.delay - ( this.production ?1:0) * 100;
			planted.endurance = this.endurance;
			planted.yield = this.yield;
			planted.potency = this.potency;
			user.WriteMsg( "<span class='notice'>You plant " + this + ".</span>" );
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: grown.dm
		public override bool add_juice( dynamic loc = null, int? potency = null ) {
			base.add_juice( (object)(loc), potency );
			this.reagents.add_reagent( "nutriment", Num13.Round( ( this.potency ??0) / 25, 1 ) + 1 );
			this.reagents.add_reagent( "radium", Num13.Round( ( this.potency ??0) / 20, 1 ) + 1 );
			this.bitesize = Num13.Round( ( this.reagents.total_volume ??0) / 2, 1 ) + 1;
			return false;
		}

	}

}