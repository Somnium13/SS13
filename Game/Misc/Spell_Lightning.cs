// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Spell_Lightning : Spell {

		public dynamic chargedkey = null;
		public int basedamage = 50;
		public int? bounces = 0;
		public int bounce_range = 6;
		public Image chargeoverlay = null;
		public dynamic last_active_sound = null;
		public int multicast = 1;
		public int zapzap = 0;
		public Obj lastbumped = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Lightning";
			this.cooldown_min = 40;
			this.cooldown_reduc = 30;
			this.spell_levels = new ByTable().Set( "speed", 0 ).Set( "power", 0 );
			this.level_max = new ByTable().Set( "total", 3 ).Set( "speed", 3 ).Set( "power", 3 );
			this.invocation = "ZAP MUTHA FUH KA";
			this.invocation_type = "shout";
			this.hud_state = "wiz_zap";
		}

		// Function from file: lightning.dm
		public Spell_Lightning (  ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.chargeoverlay = new Image( "icons/mob/mob.dmi", null, "sithlord" );
			return;
		}

		// Function from file: lightning.dm
		public void zapmuthafucka( dynamic user = null, dynamic target = null, int? chained = null, ByTable zapped = null, dynamic oursound = null ) {
			chained = chained ?? this.bounces;
			zapped = zapped ?? new ByTable();

			dynamic otarget = null;
			dynamic T = null;
			dynamic U = null;
			Game_Data L = null;
			ByTable zappanic = null;
			Mob_Living Living = null;
			Game_Data B = null;
			Mob_Living next_target = null;
			int currdist = 0;
			Mob_Living M = null;
			int dist = 0;

			otarget = target;
			this.lastbumped = null;
			zapped.Add( target );
			T = GlobalFuncs.get_turf( user );
			U = GlobalFuncs.get_turf( target );
			L = GlobalFuncs.getFromPool( typeof(Obj_Item_Projectile_Beam_Lightning_Spell), T );

			if ( !Lang13.Bool( oursound ) ) {
				oursound = Rand13.PickFromTable( GlobalVars.lightning_sound );
			}
			((dynamic)L).our_spell = this;
			GlobalFuncs.playsound( GlobalFuncs.get_turf( user ), oursound, 100, 1 );
			((dynamic)L).tang = GlobalFuncs.adjustAngle( GlobalFuncs.get_angle( U, T ) );
			((dynamic)L).icon = GlobalVars.midicon;
			((dynamic)L).icon_state = "" + ((dynamic)L).tang;
			((dynamic)L).firer = user;
			((dynamic)L).def_zone = "chest";
			((dynamic)L).original = target;
			((dynamic)L).current = U;
			((dynamic)L).starting = U;
			((dynamic)L).yo = U.y - T.y;
			((dynamic)L).xo = U.x - T.x;
			((dynamic)L).process();

			while (!( this.lastbumped != null )) {
				Task13.Sleep( ((int)( Game13.tick_lag )) );
			}
			target = this.lastbumped;

			if ( !( target is Mob_Living ) ) {
				U = GlobalFuncs.get_turf( target );
				zappanic = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_turf( target ), typeof(Mob_Living) )) {
					Living = _a;
					

					if ( Living == user || Living == this.holder || zapped.Contains( Living ) ) {
						continue;
					}
					zappanic.Or( Living );
				}

				if ( zappanic.len != 0 ) {
					target = Rand13.PickFromTable( zappanic );
				} else if ( target is Tile ) {
					target = Map13.GetStepTowardsSimple( target, Map13.GetDistance( target, user ) );
				}
			}

			if ( target is Mob_Living ) {
				target.emp_act( 2 );
				((Mob_Living)target).apply_damage( ( target is Mob_Living_Silicon ? this.basedamage * 0.66 : this.basedamage ), "fire", "chest", 0 );
			} else if ( Lang13.Bool( target ) ) {
				B = GlobalFuncs.getFromPool( typeof(Obj_Item_Projectile_Beam_Lightning_Spell) );
				((dynamic)B).damage = this.basedamage;
				((Ent_Static)target).bullet_act( B );
				GlobalFuncs.returnToPool( B );
			}

			if ( Lang13.Bool( chained ) ) {
				next_target = null;
				currdist = -1;

				foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInView( this.bounce_range, target ), typeof(Mob_Living) )) {
					M = _b;
					

					if ( M != this.holder && M != Task13.User && M != user ) {
						
						if ( !zapped.Contains( M ) && target == otarget ) {
							continue;
						}
						dist = Map13.GetDistance( M, user );

						if ( currdist == -1 ) {
							currdist = dist;
							next_target = M;
						} else if ( dist < currdist ) {
							next_target = M;
							currdist = dist;
						}
					}
				}

				if ( !( next_target != null ) ) {
					return;
				}
				this.zapmuthafucka( target, next_target, ( chained ??0) - 1, zapped, oursound );
			}
			return;
		}

		// Function from file: lightning.dm
		public void charged_click( dynamic args = null ) {
			dynamic E = null;
			dynamic A = null;
			dynamic L = null;

			E = args["event"];

			if ( !Lang13.Bool( this.chargedkey ) ) {
				E.handlers.Remove( new Txt().Ref( this ).str( ":charged_click" ).ToString() );
				return;
			}
			A = args["atom"];

			if ( E.holder != this.holder ) {
				E.handlers.Remove( new Txt().Ref( this ).str( ":charged_click" ).ToString() );
				return;
			}
			((dynamic)this.holder).attack_delayer.delayNext( 0 );

			if ( A is Mob_Living ) {
				this.zapzap--;

				if ( this.zapzap != 0 ) {
					GlobalFuncs.to_chat( this.holder, new Txt( "<span class='info'>You can throw lightning " ).item( this.zapzap ).str( " more time" ).s().str( "</span>" ).ToString() );
				} else {
					Task13.User.overlays.Remove( this.chargeoverlay );
					this.take_charge( this.holder, false );
					E.handlers.Remove( this.chargedkey );
					this.chargedkey = null;
					((dynamic)this.connected_button).name = this.name;
				}
				L = A;
				this.f_invocation( this.holder );
				Task13.Schedule( 0, (Task13.Closure)(() => {
					this.zapmuthafucka( this.holder, L, this.bounces );
					return;
				}));
				this.process();
			}
			return;
		}

		// Function from file: lightning.dm
		public override void perform( Mob user = null, bool? skipcharge = null, Tile_Simulated T = null ) {
			user = user ?? Task13.User;
			skipcharge = skipcharge ?? false;

			_Event E = null;

			
			if ( !( this.holder != null ) ) {
				this.holder = user;
			}

			if ( !Lang13.Bool( this.chargedkey ) ) {
				
				if ( !this.cast_check( skipcharge, user ) ) {
					return;
				}
				this.chargedkey = user.on_uattack.Add( this, "charged_click" );
				((dynamic)this.connected_button).name = "(Ready) " + this.name;
				user.overlays.Add( this.chargeoverlay );

				if ( Game13.time >= Convert.ToDouble( this.last_active_sound + 50 ) ) {
					GlobalFuncs.playsound( GlobalFuncs.get_turf( user ), "sound/effects/lightning/chainlightning_activate.ogg", 100, 1 );
				}
				this.zapzap = this.multicast;
			} else {
				((dynamic)this.connected_button).name = this.name;
				E = user.on_uattack;
				E.handlers.Remove( this.chargedkey );
				this.chargedkey = null;
				this.charge_counter = this.charge_max;
				user.overlays.Remove( this.chargeoverlay );

				if ( this.zapzap != this.multicast ) {
					this.take_charge( this.holder, false );
				}
				this.zapzap = 0;
			}
			return;
		}

		// Function from file: lightning.dm
		public override void process(  ) {
			
			if ( Lang13.Bool( this.chargedkey ) ) {
				return;
			}
			base.process();
			return;
		}

		// Function from file: lightning.dm
		public override dynamic empower_spell(  ) {
			string temp = null;

			
			if ( !this.can_improve( "power" ) ) {
				return 0;
			}
			this.spell_levels["power"]++;
			temp = "";

			dynamic _a = this.level_max["power"] - this.spell_levels["power"]; // Was a switch-case, sorry for the mess.
			if ( _a==2 ) {
				temp = "You have improved " + this.name + " into Chain Lightning it will arc to one additional target.";
				this.name = "Chain Lightning";
				this.bounces++;
			} else if ( _a==1 ) {
				temp = "You have improved " + this.name + " into Powerful Chain Lightning it will arc to up to 3 targets.";
				this.name = "Powerful Chain Lightning";
				this.bounces += 2;
			} else if ( _a==0 ) {
				temp = "You have improved " + this.name + " into Zeus' Own Chain Lightning it will arc to up to 5 targets.";
				this.name = "Zeus' Own Chain Lightning";
				this.bounces += 2;
			}
			this.basedamage += 5;
			((dynamic)this.connected_button).name = this.name;
			return temp;
		}

		// Function from file: lightning.dm
		public override dynamic quicken_spell(  ) {
			string temp = null;

			
			if ( !this.can_improve( "speed" ) ) {
				return 0;
			}
			this.spell_levels["speed"]++;

			if ( this.delay_reduc && this.cast_delay != 0 ) {
				this.cast_delay = Num13.MaxInt( 0, this.cast_delay - ( this.delay_reduc ?1:0) );
			} else if ( this.cast_delay != 0 ) {
				this.cast_delay = Num13.Floor( Num13.MaxInt( 0, Convert.ToInt32( Lang13.Initial( this, "cast_delay" ) * ( ( this.level_max["speed"] - this.spell_levels["speed"] ) / this.level_max["speed"] ) ) ) );
			}

			if ( this.charge_type == "recharge" ) {
				
				if ( this.cooldown_reduc != 0 ) {
					this.charge_max = Num13.MaxInt( this.cooldown_min, this.charge_max - this.cooldown_reduc );
				} else {
					this.charge_max = Num13.Floor( Num13.MaxInt( this.cooldown_min, Convert.ToInt32( Lang13.Initial( this, "charge_max" ) * ( ( this.level_max["speed"] - this.spell_levels["speed"] ) / this.level_max["speed"] ) ) ) );
				}
			}

			if ( this.charge_max < this.charge_counter ) {
				this.charge_counter = this.charge_max;
			}
			temp = "You have improved " + this.name;

			if ( Convert.ToDouble( this.spell_levels["speed"] ) >= Convert.ToDouble( this.level_max["speed"] ) ) {
				this.multicast = 2;
				temp += " and gain the ability to multicast, each incantation allows you to fire off two bolts of lightning before having to re-cast.";
			} else {
				temp += " and can cast it more frequently.";
			}
			return temp;
		}

	}

}