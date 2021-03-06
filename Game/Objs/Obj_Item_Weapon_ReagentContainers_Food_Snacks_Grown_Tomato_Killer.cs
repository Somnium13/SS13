// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato_Killer : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato {

		public bool awakening = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.seed = typeof(Obj_Item_Seeds_Killertomatoseed);
			this.filling_color = "#FF0000";
			this.icon_state = "killertomato";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato_Killer ( dynamic newloc = null, int? new_potency = null ) : base( (object)(newloc), new_potency ) {
			
		}

		// Function from file: grown.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			Mob_Living_SimpleAnimal_Hostile_Killertomato K = null;

			
			if ( this.awakening || user.loc is Tile_Space ) {
				return null;
			}
			user.WriteMsg( "<span class='notice'>You begin to awaken the Killer Tomato...</span>" );
			this.awakening = true;
			Task13.Schedule( 30, (Task13.Closure)(() => {
				
				if ( !Lang13.Bool( this.gc_destroyed ) ) {
					K = new Mob_Living_SimpleAnimal_Hostile_Killertomato( GlobalFuncs.get_turf( this.loc ) );
					K.maxHealth += Num13.Floor( this.endurance / 3 );
					K.melee_damage_lower += Num13.Floor( ( this.potency ??0) / 10 );
					K.melee_damage_upper += Num13.Floor( ( this.potency ??0) / 10 );
					K.move_to_delay -= Num13.Floor( ( this.production ?1:0) / 50 );
					K.health = K.maxHealth;
					K.visible_message( "<span class='notice'>The Killer Tomato growls as it suddenly awakens.</span>" );

					if ( Lang13.Bool( user ) ) {
						((Mob)user).unEquip( this );
					}
					GlobalFuncs.qdel( this );
				}
				return;
			}));
			return null;
		}

		// Function from file: grown.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			
			if ( this.awakening ) {
				user.WriteMsg( "<span class='warning'>The tomato is twitching and shaking, preventing you from eating it.</span>" );
				return false;
			}
			base.attack( (object)(M), (object)(user), def_zone );
			return false;
		}

	}

}