// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Asteroid_Goldgrub : Mob_Living_SimpleAnimal_Hostile_Asteroid {

		public ByTable ore_types_eaten = new ByTable();
		public bool alerted = false;
		public int ore_eaten = 1;
		public int chase_time = 100;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "Goldgrub";
			this.icon_aggro = "Goldgrub_alert";
			this.icon_dead = "Goldgrub_dead";
			this.icon_gib = "syndicate_gib";
			this.vision_range = 3;
			this.idle_vision_range = 3;
			this.move_to_delay = 3;
			this.friendly = "harmlessly rolls into";
			this.maxHealth = 60;
			this.health = 60;
			this.harm_intent_damage = 5;
			this.attacktext = "barrels into";
			this.throw_message = "sinks in slowly, before being pushed out of ";
			this.status_flags = 8;
			this.search_objects = 1;
			this.wanted_objects = new ByTable(new object [] { typeof(Obj_Item_Weapon_Ore_Diamond), typeof(Obj_Item_Weapon_Ore_Gold), typeof(Obj_Item_Weapon_Ore_Silver), typeof(Obj_Item_Weapon_Ore_Uranium) });
			this.icon_state = "Goldgrub";
		}

		public Mob_Living_SimpleAnimal_Hostile_Asteroid_Goldgrub ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mining_mobs.dm
		public override void Die( bool? gore = null ) {
			this.alerted = false;
			this.Reward();
			base.Die( gore );
			return;
		}

		// Function from file: mining_mobs.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			this.visible_message( "<span class='danger'>The " + Proj.name + " was repelled by " + this.name + "'s girth!</span>" );
			return null;
		}

		// Function from file: mining_mobs.dm
		public void Reward(  ) {
			int counter = 0;
			dynamic R = null;

			
			if ( !( this.ore_eaten != 0 ) || this.ore_types_eaten.len == 0 ) {
				return;
			}
			this.visible_message( "<span class='danger'>" + this + " spits up the contents of its stomach before dying!</span>" );

			foreach (dynamic _a in Lang13.Enumerate( this.ore_types_eaten )) {
				R = _a;
				
				counter = 0;

				while (counter < this.ore_eaten) {
					Lang13.Call( R, this.loc );
					counter++;
				}
			}
			this.ore_types_eaten.len = 0;
			this.ore_eaten = 0;
			return;
		}

		// Function from file: mining_mobs.dm
		public void Burrow(  ) {
			
			if ( !this.alerted ) {
				this.alerted = true;
				Task13.Schedule( this.chase_time, (Task13.Closure)(() => {
					
					if ( this.alerted ) {
						this.visible_message( "<span class='danger'>The " + this.name + " buries into the ground, vanishing from sight!</span>" );
						GlobalFuncs.qdel( this );
					}
					return;
				}));
			}
			return;
		}

		// Function from file: mining_mobs.dm
		public void EatOre( dynamic targeted_ore = null ) {
			Obj_Item_Weapon_Ore O = null;

			
			foreach (dynamic _a in Lang13.Enumerate( targeted_ore.loc, typeof(Obj_Item_Weapon_Ore) )) {
				O = _a;
				
				this.ore_eaten++;

				if ( !this.ore_types_eaten.Contains( O.type ) ) {
					this.ore_types_eaten.Add( O.type );
				}
				GlobalFuncs.qdel( O );
				O = null;
			}

			if ( this.ore_eaten > 5 ) {
				this.ore_eaten = 5;
			}
			this.visible_message( "<span class='notice'>The ore was swallowed whole!</span>" );
			return;
		}

		// Function from file: mining_mobs.dm
		public override dynamic AttackingTarget(  ) {
			
			if ( this.target is Obj_Item_Weapon_Ore ) {
				this.EatOre( this.target );
				return null;
			}
			base.AttackingTarget();
			return null;
		}

		// Function from file: mining_mobs.dm
		public override void GiveTarget( dynamic new_target = null ) {
			this.target = new_target;

			if ( this.target != null ) {
				
				if ( this.target is Obj_Item_Weapon_Ore ) {
					this.visible_message( "<span class='notice'>The " + this.name + " looks at " + this.target.name + " with hungry eyes.</span>" );
					this.stance = 3;
					return;
				}

				if ( this.target is Mob_Living ) {
					this.Aggro();
					this.stance = 3;
					this.visible_message( "<span class='danger'>The " + this.name + " tries to flee from " + this.target.name + "!</span>" );
					this.retreat_distance = 10;
					this.minimum_distance = 10;
					this.Burrow();
					return;
				}
			}
			return;
		}

	}

}