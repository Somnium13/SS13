// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Lizard : Mob_Living_SimpleAnimal_Hostile {

		public ByTable edibles = new ByTable(new object [] { typeof(Mob_Living_SimpleAnimal_Butterfly), typeof(Mob_Living_SimpleAnimal_Cockroach) });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "lizard";
			this.icon_dead = "lizard_dead";
			this.speak_emote = new ByTable(new object [] { "hisses" });
			this.health = 5;
			this.maxHealth = 5;
			this.faction = new ByTable(new object [] { "Lizard" });
			this.attacktext = "bites";
			this.melee_damage_lower = 1;
			this.melee_damage_upper = 2;
			this.response_help = "pets";
			this.response_disarm = "shoos";
			this.response_harm = "stomps on";
			this.ventcrawler = 2;
			this.pass_flags = 17;
			this.mob_size = 1;
			this.gold_core_spawnable = 2;
			this.icon_state = "lizard";
		}

		public Mob_Living_SimpleAnimal_Hostile_Lizard ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: lizard.dm
		public override bool AttackingTarget(  ) {
			
			if ( GlobalFuncs.is_type_in_list( this.target, this.edibles ) ) {
				this.visible_message( "" + this.name + " consumes " + this.target + " in a single gulp", "<span class='notice'>You consume " + this.target + " in a single gulp</span>" );
				GlobalFuncs.qdel( this.target );
				this.target = null;
				this.adjustBruteLoss( -2 );
			} else {
				base.AttackingTarget();
			}
			return false;
		}

		// Function from file: lizard.dm
		public override bool CanAttack( dynamic the_target = null ) {
			
			if ( this.see_invisible < Convert.ToDouble( the_target.invisibility ) ) {
				return false;
			}

			if ( GlobalFuncs.is_type_in_list( the_target, this.edibles ) ) {
				return true;
			}
			return false;
		}

	}

}