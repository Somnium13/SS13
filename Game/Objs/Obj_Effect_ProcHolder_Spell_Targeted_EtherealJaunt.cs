// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_Targeted_EtherealJaunt : Obj_Effect_ProcHolder_Spell_Targeted {

		public int jaunt_duration = 50;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.school = "transmutation";
			this.charge_max = 300;
			this.invocation = "none";
			this.range = -1;
			this.cooldown_min = 100;
			this.include_user = true;
			this.centcom_cancast = false;
			this.nonabstract_req = true;
			this.action_icon_state = "jaunt";
		}

		public Obj_Effect_ProcHolder_Spell_Targeted_EtherealJaunt ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: ethereal_jaunt.dm
		public virtual void jaunt_steam( dynamic mobloc = null ) {
			EffectSystem_SteamSpread steam = null;

			steam = new EffectSystem_SteamSpread();
			steam.set_up( 10, 0, mobloc );
			steam.start();
			return;
		}

		// Function from file: ethereal_jaunt.dm
		public virtual void jaunt_reappear( Dynamic_Overlay animation = null, Mob_Living target = null ) {
			Icon13.Flick( "reappear", animation );
			return;
		}

		// Function from file: ethereal_jaunt.dm
		public virtual void jaunt_disappear( Dynamic_Overlay animation = null, Mob_Living target = null ) {
			animation.icon_state = "liquify";
			Icon13.Flick( "liquify", animation );
			return;
		}

		// Function from file: ethereal_jaunt.dm
		public override bool cast( dynamic targets = null, dynamic thearea = null, dynamic user = null ) {
			thearea = thearea ?? Task13.User;

			Mob_Living target = null;
			dynamic mobloc = null;
			Obj_Effect_Dummy_SpellJaunt holder = null;
			Dynamic_Overlay animation = null;
			dynamic direction = null;
			Tile T = null;

			GlobalFuncs.playsound( GlobalFuncs.get_turf( thearea ), "sound/magic/Ethereal_Enter.ogg", 50, 1, -1 );

			foreach (dynamic _b in Lang13.Enumerate( targets, typeof(Mob_Living) )) {
				target = _b;
				
				target.notransform = 1;
				Task13.Schedule( 0, (Task13.Closure)(() => {
					mobloc = GlobalFuncs.get_turf( target.loc );
					holder = new Obj_Effect_Dummy_SpellJaunt( mobloc );
					animation = new Dynamic_Overlay( mobloc );
					animation.name = "water";
					animation.density = false;
					animation.anchored = 1;
					animation.icon = "icons/mob/mob.dmi";
					animation.layer = 5;
					animation.master = holder;
					target.ExtinguishMob();

					if ( target.buckled != null ) {
						target.buckled.unbuckle_mob();
					}

					if ( target.pulledby != null ) {
						target.pulledby.__CallVerb("Stop Pulling" );
					}
					target.__CallVerb("Stop Pulling" );

					if ( Lang13.Bool( target.buckled_mob ) ) {
						target.unbuckle_mob( true );
					}
					this.jaunt_disappear( animation, target );
					target.loc = holder;
					target.reset_perspective( holder );
					target.notransform = 0;
					this.jaunt_steam( mobloc );
					Task13.Sleep( this.jaunt_duration );

					if ( target.loc != holder ) {
						GlobalFuncs.qdel( holder );
						return;
					}
					mobloc = GlobalFuncs.get_turf( target.loc );
					animation.loc = mobloc;
					this.jaunt_steam( mobloc );
					target.canmove = false;
					holder.reappearing = true;
					GlobalFuncs.playsound( GlobalFuncs.get_turf( thearea ), "sound/magic/Ethereal_Exit.ogg", 50, 1, -1 );
					Task13.Sleep( 20 );

					if ( !Lang13.Bool( GlobalFuncs.qdeleted( target ) ) ) {
						this.jaunt_reappear( animation, target );
					}
					Task13.Sleep( 5 );
					GlobalFuncs.qdel( animation );
					GlobalFuncs.qdel( holder );

					if ( !Lang13.Bool( GlobalFuncs.qdeleted( target ) ) ) {
						
						if ( mobloc.density ) {
							
							foreach (dynamic _a in Lang13.Enumerate( new ByTable(new object [] { 1, 2, 4, 8, 5, 6, 9, 10 }) )) {
								direction = _a;
								
								T = Map13.GetStep( mobloc, Convert.ToInt32( direction ) );

								if ( T != null ) {
									
									if ( target.Move( T ) ) {
										break;
									}
								}
							}
						}
						target.canmove = true;
					}
					return;
				}));
			}
			return false;
		}

	}

}