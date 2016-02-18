// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Illusion : Mob_Living_SimpleAnimal_Hostile {

		public double life_span = Double.PositiveInfinity;
		public dynamic parent_mob = null;
		public double? multiply_chance = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "static";
			this.icon_dead = "null";
			this.melee_damage_lower = 5;
			this.melee_damage_upper = 5;
			this.a_intent = "harm";
			this.attacktext = "gores";
			this.speed = 0;
			this.faction = new ByTable(new object [] { "illusion" });
			this.del_on_death = true;
			this.icon = "icons/effects/effects.dmi";
			this.icon_state = "static";
		}

		// Function from file: illusion.dm
		public Mob_Living_SimpleAnimal_Hostile_Illusion ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.deathmessage = "" + this + " vanishes into thin air! It was a fake!";
			return;
		}

		// Function from file: illusion.dm
		public override bool AttackingTarget(  ) {
			dynamic L = null;
			Mob_Living_SimpleAnimal_Hostile_Illusion M = null;

			base.AttackingTarget();

			if ( this.target is Mob_Living && Rand13.PercentChance( ((int)( this.multiply_chance ??0 )) ) ) {
				L = this.target;

				if ( Convert.ToInt32( L.stat ) == 2 ) {
					return false;
				}
				M = new Mob_Living_SimpleAnimal_Hostile_Illusion( this.loc );
				M.faction = this.faction.Copy();
				M.Copy_Parent( this.parent_mob, 80, this.health / 2, this.melee_damage_upper, ( this.multiply_chance ??0) / 2 );
				M.GiveTarget( L );
			}
			return false;
		}

		// Function from file: illusion.dm
		public override double examine( dynamic user = null ) {
			
			if ( Lang13.Bool( this.parent_mob ) ) {
				((Ent_Static)this.parent_mob).examine( user );
			} else {
				return base.examine( (object)(user) );
			}
			return 0;
		}

		// Function from file: illusion.dm
		public void Copy_Parent( dynamic original = null, int? life = null, dynamic health = null, dynamic damage = null, double? replicate = null ) {
			life = life ?? 50;
			health = health ?? 100;
			damage = damage ?? 0;
			replicate = replicate ?? 0;

			this.appearance = original.appearance;
			this.parent_mob = original;
			this.dir = Convert.ToInt32( original.dir );
			this.life_span = Game13.time + ( life ??0);
			this.melee_damage_lower = damage;
			this.melee_damage_upper = damage;
			this.multiply_chance = replicate;
			this.faction -= "neutral";
			this.transform = Lang13.Initial( this, "transform" );
			this.pixel_y = Convert.ToInt32( Lang13.Initial( this, "pixel_y" ) );
			this.pixel_x = Convert.ToInt32( Lang13.Initial( this, "pixel_x" ) );
			return;
		}

		// Function from file: illusion.dm
		public override bool Life(  ) {
			base.Life();

			if ( Game13.time > this.life_span ) {
				this.death();
			}
			return false;
		}

	}

}