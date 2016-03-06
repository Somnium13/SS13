// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Extinguisher : Obj_Item_Weapon {

		public double max_water = 50;
		public int last_use = 1;
		public bool safety = true;
		public string sprite_name = "fire_extinguisher";
		public int? power = 5;
		public bool precision = false;
		public int cooling_power = 2;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "fire_extinguisher";
			this.hitsound = "sound/weapons/smash.ogg";
			this.flags = 64;
			this.throwforce = 10;
			this.force = 10;
			this.materials = new ByTable().Set( "$metal", 90 );
			this.attack_verb = new ByTable(new object [] { "slammed", "whacked", "bashed", "thunked", "battered", "bludgeoned", "thrashed" });
			this.icon_state = "fire_extinguisher0";
		}

		// Function from file: extinguisher.dm
		public Obj_Item_Weapon_Extinguisher ( dynamic loc = null ) : base( (object)(loc) ) {
			this.create_reagents( this.max_water );
			this.reagents.add_reagent( "water", this.max_water );
			return;
		}

		// Function from file: extinguisher.dm
		public override bool AltClick( Mob user = null ) {
			this.EmptyExtinguisher( user );
			return false;
		}

		// Function from file: extinguisher.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			bool Refill = false;
			int direction = 0;
			Ent_Dynamic B = null;
			int movementdirection = 0;
			dynamic T = null;
			Tile T1 = null;
			Tile T2 = null;
			ByTable the_targets = null;
			Tile T3 = null;
			Tile T4 = null;
			int? a = null;
			dynamic W = null;
			dynamic my_target = null;
			Reagents R = null;
			int? b = null;
			dynamic A = null;

			
			if ( target.loc == user || !this.check_allowed_items( target ) ) {
				return false;
			}
			Refill = this.AttemptRefill( target, user );

			if ( Refill ) {
				return false;
			}

			if ( !this.safety ) {
				
				if ( ( this.reagents.total_volume ??0) < 1 ) {
					Task13.User.WriteMsg( new Txt( "<span class='warning'>" ).The( this ).item().str( " is empty!</span>" ).ToString() );
					return false;
				}

				if ( Game13.time < this.last_use + 20 ) {
					return false;
				}
				this.last_use = Game13.time;
				GlobalFuncs.playsound( this.loc, "sound/effects/extinguish.ogg", 75, 1, -3 );
				direction = Map13.GetDistance( this, target );

				if ( Task13.User.buckled != null && Task13.User.buckled is Obj && !Lang13.Bool( Task13.User.buckled.anchored ) ) {
					Task13.Schedule( 0, (Task13.Closure)(() => {
						B = Task13.User.buckled;
						movementdirection = Num13.Rotate( direction, 180 );
						Map13.Step( B, movementdirection );
						Task13.Sleep( 1 );
						Map13.Step( B, movementdirection );
						Task13.Sleep( 1 );
						Map13.Step( B, movementdirection );
						Task13.Sleep( 1 );
						Map13.Step( B, movementdirection );
						Task13.Sleep( 2 );
						Map13.Step( B, movementdirection );
						Task13.Sleep( 2 );
						Map13.Step( B, movementdirection );
						Task13.Sleep( 3 );
						Map13.Step( B, movementdirection );
						Task13.Sleep( 3 );
						Map13.Step( B, movementdirection );
						Task13.Sleep( 3 );
						Map13.Step( B, movementdirection );
						return;
					}));
				} else {
					((Ent_Dynamic)user).newtonian_move( Num13.Rotate( direction, 180 ) );
				}
				T = GlobalFuncs.get_turf( target );
				T1 = Map13.GetStep( T, Num13.Rotate( direction, 90 ) );
				T2 = Map13.GetStep( T, Num13.Rotate( direction, -90 ) );
				the_targets = new ByTable(new object [] { T, T1, T2 });

				if ( this.precision ) {
					T3 = Map13.GetStep( T1, Num13.Rotate( direction, 90 ) );
					T4 = Map13.GetStep( T2, Num13.Rotate( direction, -90 ) );
					the_targets = new ByTable(new object [] { T, T1, T2, T3, T4 });
				}
				a = null;
				a = 0;

				while (( a ??0) < 5) {
					Task13.Schedule( 0, (Task13.Closure)(() => {
						W = GlobalFuncs.PoolOrNew( typeof(Obj_Effect_ParticleEffect_Water), GlobalFuncs.get_turf( this ) );
						my_target = Rand13.PickFromTable( the_targets );

						if ( this.precision ) {
							the_targets.Remove( my_target );
						}
						R = new Reagents( 5 );

						if ( !Lang13.Bool( W ) ) {
							return;
						}
						W.reagents = R;
						R.my_atom = W;

						if ( !Lang13.Bool( W ) || !( this != null ) ) {
							return;
						}
						this.reagents.trans_to( W, 1 );
						b = null;
						b = 0;

						while (( b ??0) < ( this.power ??0)) {
							Map13.StepTowardsSimple( W, my_target );

							if ( !Lang13.Bool( W ) || !Lang13.Bool( W.reagents ) ) {
								return;
							}
							((Reagents)W.reagents).reaction( GlobalFuncs.get_turf( W ) );

							foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_turf( W ) )) {
								A = _a;
								

								if ( !Lang13.Bool( W ) ) {
									return;
								}
								((Reagents)W.reagents).reaction( A );
							}

							if ( W.loc == my_target ) {
								break;
							}
							Task13.Sleep( 2 );
							b++;
						}
						return;
					}));
					a++;
				}
			} else {
				return base.afterattack( (object)(target), (object)(user), proximity_flag, click_parameters );
			}
			return false;
		}

		// Function from file: extinguisher.dm
		public void EmptyExtinguisher( Mob user = null ) {
			
			if ( this.loc == user && Lang13.Bool( this.reagents.total_volume ) ) {
				this.reagents.clear_reagents();
				user.visible_message( new Txt().item( user ).str( " empties out " ).the( this ).item().str( " onto the floor using the release valve." ).ToString(), new Txt( "<span class='info'>You quietly empty out " ).the( this ).item().str( " using its release valve.</span>" ).ToString() );
			}
			return;
		}

		// Function from file: extinguisher.dm
		public bool AttemptRefill( dynamic target = null, dynamic user = null ) {
			bool safety_save = false;
			dynamic W = null;
			dynamic transferred = null;
			Reagent_Water R = null;

			
			if ( target is Obj_Structure_ReagentDispensers_Watertank && ((Ent_Static)target).Adjacent( user ) ) {
				safety_save = this.safety;
				this.safety = true;

				if ( this.reagents.total_volume == this.reagents.maximum_volume ) {
					user.WriteMsg( new Txt( "<span class='warning'>" ).The( this ).item().str( " is already full!</span>" ).ToString() );
					this.safety = safety_save;
					return true;
				}
				W = target;
				transferred = ((Reagents)W.reagents).trans_to( this, this.max_water );

				if ( Convert.ToDouble( transferred ) > 0 ) {
					user.WriteMsg( new Txt( "<span class='notice'>" ).The( this ).item().str( " has been refilled by " ).item( transferred ).str( " units.</span>" ).ToString() );
					GlobalFuncs.playsound( this.loc, "sound/effects/refill.ogg", 50, 1, -6 );

					foreach (dynamic _a in Lang13.Enumerate( this.reagents.reagent_list, typeof(Reagent_Water) )) {
						R = _a;
						
						R.cooling_temperature = this.cooling_power;
					}
				} else {
					user.WriteMsg( new Txt( "<span class='warning'>" ).The( W ).item().str( " is empty!</span>" ).ToString() );
				}
				this.safety = safety_save;
				return true;
			} else {
				return false;
			}
		}

		// Function from file: extinguisher.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );

			if ( Lang13.Bool( this.reagents.total_volume ) ) {
				user.WriteMsg( "It contains " + Num13.Floor( this.reagents.total_volume ??0 ) + " units." );
			} else {
				user.WriteMsg( "It is empty." );
			}
			return 0;
		}

		// Function from file: extinguisher.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.safety = !this.safety;
			this.icon_state = "" + this.sprite_name + !this.safety;
			this.desc = "The safety is " + ( this.safety ? "on" : "off" ) + ".";
			user.WriteMsg( "The safety is " + ( this.safety ? "on" : "off" ) + "." );
			return null;
		}

	}

}