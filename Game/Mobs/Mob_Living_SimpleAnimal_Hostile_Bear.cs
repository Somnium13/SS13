// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Bear : Mob_Living_SimpleAnimal_Hostile {

		public string default_icon_space = "bear";
		public string default_icon_floor = "bearfloor";
		public int stance_step = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "bear";
			this.icon_dead = "bear_dead";
			this.icon_gib = "bear_gib";
			this.speak = new ByTable(new object [] { "RAWR!", "Rawr!", "GRR!", "Growl!" });
			this.speak_emote = new ByTable(new object [] { "growls", "roars" });
			this.emote_hear = new ByTable(new object [] { "rawrs", "grumbles", "grawls" });
			this.emote_see = new ByTable(new object [] { "stares ferociously", "stomps" });
			this.speak_chance = 1;
			this.turns_per_move = 5;
			this.meat_type = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Bearmeat);
			this.response_help = "pets";
			this.response_disarm = "gently pushes aside";
			this.maxHealth = 60;
			this.health = 60;
			this.attacktext = "mauls";
			this.melee_damage_lower = 20;
			this.melee_damage_upper = 30;
			this.size = 4;
			this.min_oxy = 0;
			this.max_tox = false;
			this.max_co2 = 0;
			this.minbodytemp = 0;
			this.faction = "russian";
			this.icon_state = "bear";
			this.see_in_dark = 6;
		}

		public Mob_Living_SimpleAnimal_Hostile_Bear ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: bear.dm
		public override void LoseTarget(  ) {
			base.LoseTarget(  );
			return;
		}

		// Function from file: bear.dm
		public override dynamic FindTarget(  ) {
			dynamic _default = null;

			_default = base.FindTarget();

			if ( Lang13.Bool( _default ) ) {
				this.emote( "stares alertly at " + _default );
				this.stance = 2;
			}
			return _default;
		}

		// Function from file: bear.dm
		public override bool CanAttack( dynamic target = null ) {
			bool _default = false;

			Obj_Effect_Decal_Cleanable_Crayon C = null;

			_default = base.CanAttack( (object)(target) );

			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_turf( target ), typeof(Obj_Effect_Decal_Cleanable_Crayon) )) {
				C = _a;
				

				if ( !Lang13.Bool( C.on_wall ) && C.name == "o" ) {
					return false;
				}
			}
			return _default;
		}

		// Function from file: bear.dm
		public override int Process_Spacemove( bool? check_drift = null, bool? ignore_slip = null ) {
			check_drift = check_drift ?? false;

			return 1;
		}

		// Function from file: bear.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( this.stance != 3 && this.stance != 4 ) {
				this.stance = 2;
				this.stance_step = 6;
				this.target = a;
			}
			base.attack_hand( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: bear.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( this.stance != 3 && this.stance != 4 ) {
				this.stance = 2;
				this.stance_step = 6;
				this.target = b;
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: bear.dm
		public override bool Life(  ) {
			bool _default = false;

			bool found_mob = false;
			dynamic action = null;

			
			if ( this.timestopped ) {
				return false;
			}
			_default = base.Life();

			if ( !_default ) {
				return _default;
			}

			switch ((int)( this.stance )) {
				case 5:
					this.stop_automated_movement = true;
					this.stance_step++;

					if ( this.stance_step >= 10 ) {
						
						if ( this.ListTargets().Contains( Lang13.Bool( this.target ) && Lang13.Bool( this.target ) ) ) {
							this.stance = 3;
						} else {
							this.stance = 1;
						}
					}
					break;
				case 2:
					this.stop_automated_movement = true;
					found_mob = false;

					if ( this.ListTargets().Contains( Lang13.Bool( this.target ) && Lang13.Bool( this.target ) ) ) {
						
						if ( this.CanAttack( this.target ) ) {
							this.stance_step = Num13.MaxInt( 0, this.stance_step );
							this.stance_step++;
							found_mob = true;
							this.dir = Map13.GetDistance( this, this.target );

							if ( new ByTable(new object [] { 1, 4, 7 }).Contains( this.stance_step ) ) {
								action = Rand13.PickFromTable( new ByTable(new object [] { "growls at " + this.target, "stares angrily at " + this.target, "prepares to attack " + this.target, "closely watches " + this.target }) );

								if ( Lang13.Bool( action ) ) {
									this.emote( action );
								}
							}
						}
					}

					if ( !found_mob ) {
						this.stance_step--;
					}

					if ( this.stance_step <= -20 ) {
						this.stance = 1;
					}

					if ( this.stance_step >= 7 ) {
						this.stance = 3;
					}
					break;
				case 4:
					
					if ( this.stance_step >= 20 ) {
						this.emote( "is worn out and needs to rest" );
						this.stance = 5;
						this.stance_step = 0;
						Map13.Walk( this, 0, 0 );
						return _default;
					}
					break;
			}
			return _default;
		}

		// Function from file: bear.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			base.Move( (object)(NewLoc), Dir, step_x, step_y );

			if ( this.stat != 2 ) {
				
				if ( this.loc != null && this.loc is Tile_Space ) {
					this.icon_state = this.default_icon_space;
				} else {
					this.icon_state = this.default_icon_floor;
				}
			}
			return false;
		}

	}

}