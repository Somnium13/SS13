// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Grab : Obj_Item_Weapon {

		public Game_Data hud = null;
		public Mob_Living_SimpleAnimal affecting = null;
		public dynamic assailant = null;
		public int state = 1;
		public bool allow_upgrade = true;
		public int last_upgrade = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 4;
			this.v_abstract = true;
			this.item_state = "nothing";
			this.w_class = 5;
			this.layer = 21;
		}

		// Function from file: mob_grab.dm
		public Obj_Item_Weapon_Grab ( dynamic loc = null, dynamic victim = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.assailant = loc;
			this.affecting = victim;

			if ( this.affecting != null && Lang13.Bool( this.affecting.anchored ) ) {
				GlobalFuncs.returnToPool( this );
				return;
			}
			this.hud = GlobalFuncs.getFromPool( typeof(Obj_Screen_Grab) );
			((dynamic)this.hud).icon_state = "reinforce";
			((dynamic)this.hud).name = "reinforce grab";
			((dynamic)this.hud).master = this;
			return;
		}

		// Function from file: mob_grab.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( this.affecting != null ) {
				this.affecting.grabbed_by.Remove( this );
				this.affecting = null;
			}

			if ( Lang13.Bool( this.assailant ) ) {
				
				if ( Lang13.Bool( this.assailant.client ) ) {
					this.assailant.client.screen -= this.hud;
				}
				this.assailant = null;
			}

			if ( this.hud != null ) {
				GlobalFuncs.returnToPool( this.hud );
			}
			this.hud = null;
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: mob_grab.dm
		public override dynamic dropped( dynamic user = null ) {
			GlobalFuncs.returnToPool( this );
			return null;
		}

		// Function from file: mob_grab.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			dynamic attacker = null;

			
			if ( !( this.affecting != null ) ) {
				return null;
			}

			if ( M == this.affecting ) {
				this.s_click( this.hud );
				return null;
			}

			if ( M == this.assailant && this.state >= 2 ) {
				
				if ( user is Mob_Living_Carbon_Human && Lang13.Bool( user.mutations.Contains( 6 ) ) && this.affecting is Mob_Living_Carbon_Monkey || user is Mob_Living_Carbon_Alien && this.affecting is Mob_Living_Carbon ) {
					attacker = user;
					((Ent_Static)user).visible_message( "<span class='danger'>" + user + " is attempting to devour " + this.affecting + "!</span>", null, null, "<span class='danger'>" + user + " is attempting to kiss " + this.affecting + "! Ew!</span>" );

					if ( user is Mob_Living_Carbon_Alien_Humanoid_Hunter ) {
						
						if ( !GlobalFuncs.do_mob( user, this.affecting ) ) {
							return null;
						}
					} else if ( !GlobalFuncs.do_mob( user, this.affecting, 100 ) ) {
						return null;
					}
					((Ent_Static)user).visible_message( "<span class='danger'>" + user + " devours " + this.affecting + "!</span>", null, null, "<span class='danger'>" + this.affecting + " vanishes in disgust.</span>" );
					this.affecting.loc = user;
					attacker.stomach_contents.Add( this.affecting );
					GlobalFuncs.returnToPool( this );
				}
			}
			return null;
		}

		// Function from file: mob_grab.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic _default = null;

			_default = base.attack_self( (object)(user), (object)(flag), emp );

			if ( Lang13.Bool( _default ) ) {
				return _default;
			} else if ( this.hud != null ) {
				this.s_click( this.hud ); return null;
			}
			return _default;
		}

		// Function from file: mob_grab.dm
		public override dynamic process(  ) {
			dynamic G = null;
			dynamic G2 = null;
			bool? h = null;
			Obj_Item_Weapon_Grab G3 = null;
			Mob_Living_SimpleAnimal L = null;

			this.confirm();

			if ( !Lang13.Bool( this.assailant ) ) {
				this.affecting = null;
				GlobalFuncs.returnToPool( this );
				return null;
			}

			if ( Lang13.Bool( this.assailant.client ) ) {
				this.assailant.client.screen -= this.hud;
				this.assailant.client.screen += this.hud;
			}

			if ( this.assailant.pulling == this.affecting ) {
				this.assailant.__CallVerb("Stop Pulling" );
			}

			if ( this.state <= 2 ) {
				this.allow_upgrade = true;

				if ( Lang13.Bool( this.assailant.l_hand ) && this.assailant.l_hand != this && this.assailant.l_hand is Obj_Item_Weapon_Grab ) {
					G = this.assailant.l_hand;

					if ( G.affecting != this.affecting ) {
						this.allow_upgrade = false;
					}
				}

				if ( Lang13.Bool( this.assailant.r_hand ) && this.assailant.r_hand != this && this.assailant.r_hand is Obj_Item_Weapon_Grab ) {
					G2 = this.assailant.r_hand;

					if ( G2.affecting != this.affecting ) {
						this.allow_upgrade = false;
					}
				}

				if ( this.state == 2 ) {
					h = this.affecting.hand;
					this.affecting.drop_hands();
					this.affecting.hand = h;

					foreach (dynamic _a in Lang13.Enumerate( this.affecting.grabbed_by, typeof(Obj_Item_Weapon_Grab) )) {
						G3 = _a;
						

						if ( G3 == this ) {
							continue;
						}

						if ( G3.state == 2 ) {
							this.allow_upgrade = false;
						}
					}
				}

				if ( this.allow_upgrade ) {
					((dynamic)this.hud).icon_state = "reinforce";
				} else {
					((dynamic)this.hud).icon_state = "!reinforce";
				}
			} else if ( !Lang13.Bool( this.affecting.locked_to ) ) {
				this.affecting.loc = this.assailant.loc;
			}

			if ( this.state >= 3 ) {
				
				if ( this.affecting is Mob_Living ) {
					L = this.affecting;
					L.adjustOxyLoss( 1 );
				}
			}

			if ( this.state >= 5 ) {
				this.affecting.Weaken( 5 );
				this.affecting.losebreath = Num13.MinInt( this.affecting.losebreath + 2, 3 );
			}
			return null;
		}

		// Function from file: mob_grab.dm
		public bool confirm(  ) {
			
			if ( !Lang13.Bool( this.assailant ) || !( this.affecting != null ) ) {
				GlobalFuncs.returnToPool( this );
				return false;
			}

			if ( this.affecting != null ) {
				
				if ( !( this.assailant.loc is Tile ) || !( this.affecting.loc is Tile ) || this.assailant.loc != this.affecting.loc && Map13.GetDistance( this.assailant, this.affecting ) > 1 ) {
					GlobalFuncs.returnToPool( this );
					return false;
				}
			}
			return true;
		}

		// Function from file: mob_grab.dm
		public void s_click( Game_Data S = null ) {
			
			if ( !( this.affecting != null ) || !Lang13.Bool( this.assailant ) || Lang13.Bool( this.timeDestroyed ) ) {
				return;
			}

			if ( this.assailant.attack_delayer.blocked() ) {
				return;
			}

			if ( this.state == 4 ) {
				return;
			}

			if ( !this.assailant.canmove || this.assailant.lying == true ) {
				GlobalFuncs.returnToPool( this );
				return;
			}
			this.last_upgrade = Game13.time;

			if ( this.state < 2 ) {
				
				if ( !this.allow_upgrade ) {
					return;
				}
				((Ent_Static)this.assailant).visible_message( "<span class='warning'>" + this.assailant + " has grabbed " + this.affecting + " aggressively (now hands)!</span>", null, null, "<span class='warning'>" + this.assailant + " has hugged " + this.affecting + " passionately!</span>" );
				this.state = 2;
				this.icon_state = "grabbed1";
			} else if ( this.state < 3 ) {
				
				if ( this.affecting is Mob_Living_Carbon_Slime ) {
					GlobalFuncs.to_chat( this.assailant, "<span class='notice'>You squeeze " + this.affecting + ", but nothing interesting happens.</span>" );
					return;
				}
				((Ent_Static)this.assailant).visible_message( new Txt( "<span class='warning'>" ).item( this.assailant ).str( " has reinforced " ).his_her_its_their().str( " grip on " ).item( this.affecting ).str( " (now neck)!</span>" ).ToString(), null, null, new Txt( "<span class='warning'>" ).item( this.assailant ).str( " has reinforced " ).his_her_its_their().str( " hug on " ).item( this.affecting ).str( "!</span>" ).ToString() );
				this.state = 3;
				this.icon_state = "grabbed+1";

				if ( !Lang13.Bool( this.affecting.locked_to ) ) {
					this.affecting.loc = this.assailant.loc;
				}
				this.affecting.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has had their neck grabbed by " + this.assailant.name + " (" + this.assailant.ckey + ")</font>" );
				this.assailant.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Grabbed the neck of " + this.affecting.name + " (" + this.affecting.ckey + ")</font>" );
				GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<font color='red'>" + this.assailant.name + " (" + this.assailant.ckey + ") grabbed the neck of " + this.affecting.name + " (" + this.affecting.ckey + ")</font>" ) ) );
				((dynamic)this.hud).icon_state = "disarm/kill";
				((dynamic)this.hud).name = "disarm/kill";
			} else if ( this.state < 4 ) {
				((Ent_Static)this.assailant).visible_message( new Txt( "<span class='danger'>" ).item( this.assailant ).str( " starts to tighten " ).his_her_its_their().str( " grip on " ).item( this.affecting ).str( "'s neck!</span>" ).ToString(), null, null, new Txt( "<span class='danger'>" ).item( this.assailant ).str( " starts to tighten " ).his_her_its_their().str( " hug on " ).item( this.affecting ).str( "!</span>" ).ToString() );
				((dynamic)this.hud).icon_state = "disarm/kill1";
				this.state = 4;

				if ( GlobalFuncs.do_after( this.assailant, this.affecting, 100 ) ) {
					
					if ( this.state == 5 ) {
						return;
					}

					if ( !Lang13.Bool( this.assailant ) || !( this.affecting != null ) ) {
						GlobalFuncs.returnToPool( this );
						return;
					}

					if ( !this.assailant.canmove || this.assailant.lying == true ) {
						GlobalFuncs.returnToPool( this );
						return;
					}
					this.state = 5;
					((Ent_Static)this.assailant).visible_message( new Txt( "<span class='danger'>" ).item( this.assailant ).str( " has tightened " ).his_her_its_their().str( " grip on " ).item( this.affecting ).str( "'s neck!</span>" ).ToString(), null, null, new Txt( "<span class='danger'>" ).item( this.assailant ).str( " has tightened " ).his_her_its_their().str( " hug on " ).item( this.affecting ).str( "!</span>" ).ToString() );
					this.affecting.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been strangled (kill intent) by " + this.assailant.name + " (" + this.assailant.ckey + ")</font>" );
					this.assailant.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Strangled (kill intent) " + this.affecting.name + " (" + this.affecting.ckey + ")</font>" );
					GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<font color='red'>" + this.assailant.name + " (" + this.assailant.ckey + ") Strangled (kill intent) " + this.affecting.name + " (" + this.affecting.ckey + ")</font>" ) ) );
					this.assailant.delayNextMove( 10 );
					((Mob)this.assailant).delayNextAttack( 10 );
					this.affecting.losebreath += 1;
				} else {
					
					if ( !Lang13.Bool( this.assailant ) || !( this.affecting != null ) ) {
						GlobalFuncs.returnToPool( this );
						return;
					}
					((Ent_Static)this.assailant).visible_message( new Txt( "<span class='warning'>" ).item( this.assailant ).str( " was unable to tighten " ).his_her_its_their().str( " grip on " ).item( this.affecting ).str( "'s neck!</span>" ).ToString(), null, null, "<span class='warning'>" + this.affecting + " refused " + this.assailant + "'s hug!</span>" );
					((dynamic)this.hud).icon_state = "disarm/kill";
					this.state = 3;
				}
			}
			return;
		}

		// Function from file: mob_grab.dm
		public void synch(  ) {
			
			if ( this.affecting != null ) {
				
				if ( this.assailant.r_hand == this ) {
					((dynamic)this.hud).screen_loc = "CENTER-1:16,SOUTH:5";
				} else {
					((dynamic)this.hud).screen_loc = "CENTER:16,SOUTH:5";
				}
			}
			return;
		}

		// Function from file: mob_grab.dm
		public Mob_Living_SimpleAnimal toss(  ) {
			
			if ( this.affecting != null ) {
				
				if ( Lang13.Bool( this.affecting.locked_to ) || !this.loc.Adjacent( this.affecting ) ) {
					return null;
				}

				if ( this.state >= 2 ) {
					return this.affecting;
				}
			}
			return null;
		}

	}

}