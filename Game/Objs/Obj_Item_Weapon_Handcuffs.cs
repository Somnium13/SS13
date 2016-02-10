// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Handcuffs : Obj_Item_Weapon {

		public bool dispenser = false;
		public int breakouttime = 1200;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.slot_flags = 512;
			this.throwforce = 5;
			this.w_class = 2;
			this.throw_range = 5;
			this.starting_materials = new ByTable().Set( "$iron", 500 );
			this.w_type = 4;
			this.melt_temperature = 1783.1500244140625;
			this.origin_tech = "materials=1";
			this.icon_state = "handcuff";
		}

		public Obj_Item_Weapon_Handcuffs ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: handcuffs.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			Ent_Static p_loc = null;
			Ent_Static p_loc_m = null;
			dynamic O = null;
			Obj_Effect_EquipE_Human O2 = null;
			Obj_Effect_EquipE_Human O3 = null;
			Obj_Effect_EquipE_Monkey O4 = null;

			
			if ( !( M is Mob_Living_Carbon ) ) {
				return null;
			}

			if ( this is Obj_Item_Weapon_Handcuffs_Cyborg && user is Mob_Living_Silicon_Robot ) {
				
				if ( !Lang13.Bool( M.handcuffed ) ) {
					p_loc = user.loc;
					p_loc_m = M.loc;
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/weapons/handcuffs.ogg", 30, 1, -2 );

					foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, user ) )) {
						O = _a;
						
						O.show_message( "<span class='danger'>" + user + " is trying to put handcuffs on " + M + "!</span>", 1 );
					}
					Task13.Schedule( 30, (Task13.Closure)(() => {
						
						if ( !Lang13.Bool( M ) ) {
							return;
						}

						if ( p_loc == user.loc && p_loc_m == M.loc ) {
							M.handcuffed = new Obj_Item_Weapon_Handcuffs( M );
							((Mob)M).update_inv_handcuffed();
						}
						return;
					}));
				}
			} else {
				Interface13.Stat( null, Task13.User.mutations.Contains( 5 ) );

				if ( this is Obj_Item_Weapon_Handcuffs_Cyborg && user is Mob_Living_Silicon_Robot && Rand13.PercentChance( 50 ) ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='warning'>Uh ... how do those things work?!</span>" );

					if ( M is Mob_Living_Carbon_Human ) {
						
						if ( !Lang13.Bool( M.handcuffed ) ) {
							O2 = new Obj_Effect_EquipE_Human();
							O2.source = user;
							O2.target = user;
							O2.item = ((Mob)user).get_active_hand();
							O2.s_loc = user.loc;
							O2.t_loc = user.loc;
							O2.place = "handcuff";
							M.requests.Add( O2 );
							Task13.Schedule( 0, (Task13.Closure)(() => {
								O2.process();
								return;
							}));
						}
						return null;
					}
					return null;
				}

				if ( !Lang13.Bool( Task13.User.dexterity_check() ) ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='warning'>You don't have the dexterity to do this!</span>" );
					return null;
				}

				if ( M is Mob_Living_Carbon_Human ) {
					
					if ( !Lang13.Bool( M.handcuffed ) ) {
						M.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been handcuffed (attempt) by " + user.name + " (" + user.ckey + ")</font>" );
						user.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Attempted to handcuff " + M.name + " (" + M.ckey + ")</font>" );

						if ( !( user is Mob_Living_Carbon ) ) {
							M.LAssailant = null;
						} else {
							M.LAssailant = user;
						}
						GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<font color='red'>" + user.name + " (" + user.ckey + ") Attempted to handcuff " + M.name + " (" + M.ckey + ")</font>" ) ) );
						O3 = new Obj_Effect_EquipE_Human();
						O3.source = user;
						O3.target = M;
						O3.item = ((Mob)user).get_active_hand();
						O3.s_loc = user.loc;
						O3.t_loc = M.loc;
						O3.place = "handcuff";
						M.requests.Add( O3 );
						Task13.Schedule( 0, (Task13.Closure)(() => {
							
							if ( this is Obj_Item_Weapon_Handcuffs_Cable ) {
								GlobalFuncs.feedback_add_details( "handcuffs", "C" );
								GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/weapons/cablecuff.ogg", 30, 1, -2 );
							} else {
								GlobalFuncs.feedback_add_details( "handcuffs", "H" );
								GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/weapons/handcuffs.ogg", 30, 1, -2 );
							}
							O3.process();
							return;
						}));
					}
					return null;
				} else {
					
					if ( !Lang13.Bool( M.handcuffed ) ) {
						O4 = new Obj_Effect_EquipE_Monkey();
						O4.source = user;
						O4.target = M;
						O4.item = ((Mob)user).get_active_hand();
						O4.s_loc = user.loc;
						O4.t_loc = M.loc;
						O4.place = "handcuff";
						M.requests.Add( O4 );
						Task13.Schedule( 0, (Task13.Closure)(() => {
							
							if ( this is Obj_Item_Weapon_Handcuffs_Cable ) {
								GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/weapons/cablecuff.ogg", 30, 1, -2 );
							} else {
								GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/weapons/handcuffs.ogg", 30, 1, -2 );
							}
							O4.process();
							return;
						}));
					}
					return null;
				}
			}
			return null;
		}

		// Function from file: handcuffs.dm
		public override void setGender( string gend = null ) {
			return;
		}

	}

}