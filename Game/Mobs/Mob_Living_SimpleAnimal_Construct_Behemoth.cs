// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Construct_Behemoth : Mob_Living_SimpleAnimal_Construct {

		public bool energy = false;
		public int max_energy = 1000;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.real_name = "Behemoth";
			this.icon_living = "behemoth";
			this.maxHealth = 750;
			this.health = 750;
			this.speak_emote = new ByTable(new object [] { "rumbles" });
			this.response_harm = "harmlessly punches";
			this.harm_intent_damage = 0;
			this.melee_damage_lower = 50;
			this.melee_damage_upper = 50;
			this.attacktext = "brutally crushes";
			this.speed = 5;
			this.environment_smash = 2;
			this.attack_sound = "sound/weapons/heavysmash.ogg";
			this.construct_spells = new ByTable(new object [] { typeof(Spell_AoeTurf_Conjure_Forcewall_Lesser) });
			this.icon = "icons/mob/mob.dmi";
			this.icon_state = "behemoth";
		}

		public Mob_Living_SimpleAnimal_Construct_Behemoth ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: constructs.dm
		public override bool Life(  ) {
			
			if ( this.timestopped ) {
				return false;
			}
			base.Life();

			if ( this.healths != null ) {
				
				dynamic _a = this.health; // Was a switch-case, sorry for the mess.
				if ( 750<=_a&&_a<=Double.PositiveInfinity ) {
					((dynamic)this.healths).icon_state = "juggernaut_health0";
				} else if ( 625<=_a&&_a<=749 ) {
					((dynamic)this.healths).icon_state = "juggernaut_health1";
				} else if ( 500<=_a&&_a<=624 ) {
					((dynamic)this.healths).icon_state = "juggernaut_health2";
				} else if ( 375<=_a&&_a<=499 ) {
					((dynamic)this.healths).icon_state = "juggernaut_health3";
				} else if ( 250<=_a&&_a<=374 ) {
					((dynamic)this.healths).icon_state = "juggernaut_health4";
				} else if ( 125<=_a&&_a<=249 ) {
					((dynamic)this.healths).icon_state = "juggernaut_health5";
				} else if ( 1<=_a&&_a<=124 ) {
					((dynamic)this.healths).icon_state = "juggernaut_health6";
				} else {
					((dynamic)this.healths).icon_state = "juggernaut_health7";
				}
			}
			return false;
		}

		// Function from file: constructs.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic damage = null;
			dynamic M = null;
			dynamic M2 = null;
			dynamic M3 = null;

			((Mob)b).delayNextAttack( 8 );

			if ( Lang13.Bool( a.force ) ) {
				
				if ( Convert.ToDouble( a.force ) >= 11 ) {
					damage = a.force;

					if ( a.damtype == "halloss" ) {
						damage = 0;
					}
					this.adjustBruteLoss( damage );

					foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
						M = _a;
						

						if ( Lang13.Bool( M.client ) && !Lang13.Bool( M.blinded ) ) {
							M.show_message( "<span class='danger'>" + this + " has been attacked with " + a + " by " + b + ". </span>" );
						}
					}
				} else {
					
					foreach (dynamic _b in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
						M2 = _b;
						

						if ( Lang13.Bool( M2.client ) && !Lang13.Bool( M2.blinded ) ) {
							M2.show_message( "<span class='danger'>" + a + " bounces harmlessly off of " + this + ". </span>" );
						}
					}
				}
			} else {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>This weapon is ineffective, it does no damage.</span>" );

				foreach (dynamic _c in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
					M3 = _c;
					

					if ( Lang13.Bool( M3.client ) && !Lang13.Bool( M3.blinded ) ) {
						M3.show_message( "<span class='warning'>" + b + " gently taps " + this + " with " + a + ". </span>" );
					}
				}
			}
			return null;
		}

	}

}