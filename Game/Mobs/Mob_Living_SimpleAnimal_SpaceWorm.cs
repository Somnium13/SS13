// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_SpaceWorm : Mob_Living_SimpleAnimal {

		public Mob_Living_SimpleAnimal_SpaceWorm previous = null;
		public Mob_Living_SimpleAnimal_SpaceWorm next = null;
		public int stomachProcessProbability = 50;
		public int digestionProbability = 20;
		public int? flatPlasmaValue = 5;
		public Obj currentlyEating = null;
		public int eatingDuration = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "spaceworm";
			this.icon_dead = "spacewormdead";
			this.status_flags = 0;
			this.speak_emote = new ByTable(new object [] { "transmits" });
			this.emote_hear = new ByTable(new object [] { "transmits" });
			this.response_help = "touches";
			this.response_disarm = "flails at";
			this.response_harm = "punches the";
			this.harm_intent_damage = 2;
			this.maxHealth = 30;
			this.health = 30;
			this.stop_automated_movement = true;
			this.minbodytemp = 0;
			this.min_oxy = 0;
			this.max_co2 = 0;
			this.max_tox = false;
			this.a_intent = "hurt";
			this.environment_smash = 2;
			this.speed = -1;
			this.icon_state = "spaceworm";
		}

		public Mob_Living_SimpleAnimal_SpaceWorm ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: worm.dm
		public void ProcessStomach(  ) {
			Ent_Dynamic stomachContent = null;
			Ent_Dynamic oldStack = null;
			Ent_Dynamic oldItem = null;
			Ent_Dynamic stomachContent2 = null;
			Ent_Dynamic stomachContent3 = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Ent_Dynamic) )) {
				stomachContent = _a;
				

				if ( Rand13.PercentChance( this.digestionProbability ) ) {
					
					if ( stomachContent is Obj_Item_Stack ) {
						
						if ( !( stomachContent is Obj_Item_Stack_Sheet_Mineral_Plasma ) ) {
							oldStack = stomachContent;
							new Obj_Item_Stack_Sheet_Mineral_Plasma( this, Lang13.IntNullable( ((dynamic)oldStack).amount ) );
							GlobalFuncs.qdel( oldStack );
							oldStack = null;
							continue;
						}
					} else if ( stomachContent is Obj_Item ) {
						oldItem = stomachContent;
						new Obj_Item_Stack_Sheet_Mineral_Plasma( this, Lang13.IntNullable( ((dynamic)oldItem).w_class ) );
						GlobalFuncs.qdel( oldItem );
						oldItem = null;
						continue;
					} else {
						new Obj_Item_Stack_Sheet_Mineral_Plasma( this, this.flatPlasmaValue );
						GlobalFuncs.qdel( stomachContent );
						stomachContent = null;
						continue;
					}
				}
			}

			if ( this.previous != null ) {
				
				foreach (dynamic _b in Lang13.Enumerate( this.contents, typeof(Ent_Dynamic) )) {
					stomachContent2 = _b;
					
					this.previous.contents.Add( stomachContent2 );
				}
			} else {
				
				foreach (dynamic _c in Lang13.Enumerate( this.contents, typeof(Ent_Dynamic) )) {
					stomachContent3 = _c;
					
					this.loc.contents.Add( stomachContent3 );
				}
			}
			return;
		}

		// Function from file: worm.dm
		public void Detach( bool? die = null ) {
			die = die ?? false;

			Mob_Living_SimpleAnimal_SpaceWorm_Head newHead = null;
			Mob_Living_SimpleAnimal_SpaceWorm newHeadPrevious = null;

			newHead = new Mob_Living_SimpleAnimal_SpaceWorm_Head( this.loc, 0 );
			newHeadPrevious = this.previous;
			this.previous = null;
			newHead.Attach( newHeadPrevious );

			if ( die == true ) {
				newHead.Die();
			}
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: worm.dm
		public void Attach( Mob_Living_SimpleAnimal_SpaceWorm attachement = null ) {
			
			if ( !( attachement != null ) ) {
				return;
			}
			this.previous = attachement;
			attachement.next = this;
			return;
		}

		// Function from file: worm.dm
		public bool AttemptToEat( Ent_Static target = null ) {
			Ent_Static wall = null;
			Game_Data M = null;
			
			if ( target is Tile_Simulated_Wall ) {
				
				if ( !( target is Tile_Simulated_Wall_RWall ) && this.eatingDuration >= 100 || this.eatingDuration >= 200 ) {
					wall = target;
					((Tile)wall).ChangeTurf( typeof(Tile_Simulated_Floor) );
					M = GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Metal), this );
					((dynamic)M).amount = this.flatPlasmaValue;
					return true;
				}
			} else if ( target is Ent_Dynamic ) {
				
				if ( target is Mob || this.eatingDuration >= 50 ) {
					this.contents.Add(target);
					return true;
				}
			}
			return false;
		}

		// Function from file: worm.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( this.stat == 0 || this.stat == 1 ) {
				
				if ( this.previous != null ) {
					this.icon_state = "spaceworm" + ( Map13.GetDistance( this, this.previous ) | Map13.GetDistance( this, this.next ) );
				} else {
					this.icon_state = "spacewormtail";
					this.dir = Map13.GetDistance( this, this.next );
				}
			} else {
				this.icon_state = "spacewormdead";
			}
			return null;
		}

		// Function from file: worm.dm
		public override dynamic Bump(Ent_Static Obstacle = null, dynamic yes = null) {
			
			if ( this.currentlyEating != Obstacle ) {
				this.currentlyEating = Obstacle;
				this.eatingDuration = 0;
			}

			if ( !this.AttemptToEat( Obstacle ) ) {
				this.eatingDuration++;
			} else {
				this.currentlyEating = null;
				this.eatingDuration = 0;
			}
			return null;
		}

		// Function from file: worm.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			Ent_Static attachementNextPosition = null;

			attachementNextPosition = this.loc;

			if ( base.Move( (object)(NewLoc), Dir, step_x, step_y ) ) {
				
				if ( this.previous != null ) {
					this.previous.Move( attachementNextPosition );
				}
				this.update_icon();
			}
			return false;
		}

		// Function from file: worm.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( this.previous != null ) {
				this.previous.Detach();
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: worm.dm
		public override bool Life(  ) {
			base.Life();

			if ( this.next != null && !Map13.FetchInView( 1, this ).Contains( this.next ) ) {
				this.Detach();
			}

			if ( this.stat == 2 ) {
				
				if ( this.previous != null ) {
					this.previous.Detach();
				}

				if ( this.next != null ) {
					this.Detach( true );
				}
			}

			if ( Rand13.PercentChance( this.stomachProcessProbability ) ) {
				this.ProcessStomach();
			}
			this.update_icon();
			return false;
		}

	}

}