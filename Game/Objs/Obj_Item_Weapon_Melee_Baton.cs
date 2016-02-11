// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Melee_Baton : Obj_Item_Weapon_Melee {

		public int stunforce = 10;
		public bool status = false;
		public dynamic bcell = null;
		public double hitcost = 100;
		public dynamic foundmob = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "baton";
			this.slot_flags = 512;
			this.force = 10;
			this.throwforce = 7;
			this.origin_tech = "combat=2";
			this.attack_verb = new ByTable(new object [] { "beaten" });
			this.icon_state = "stun baton";
		}

		// Function from file: stunbaton.dm
		public Obj_Item_Weapon_Melee_Baton ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.update_icon();
			return;
		}

		// Function from file: stunbaton.dm
		public override dynamic emp_act( int severity = 0 ) {
			
			if ( Lang13.Bool( this.bcell ) ) {
				this.deductcharge( 1000 / severity );

				if ( Convert.ToInt32( this.bcell.reliability ) != 100 && Rand13.PercentChance( ((int)( 50 / severity )) ) ) {
					this.bcell.reliability -= 10 / severity;
				}
			}
			base.emp_act( severity );
			return null;
		}

		// Function from file: stunbaton.dm
		public override dynamic throw_impact( dynamic hit_atom = null, dynamic speed = null, Mob user = null ) {
			dynamic L = null;
			Ent_Static R = null;
			dynamic H = null;

			this.foundmob = GlobalVars.directory[String13.CKey( this.fingerprintslast )];

			if ( Rand13.PercentChance( 50 ) ) {
				
				if ( hit_atom is Mob_Living ) {
					L = hit_atom;

					if ( this.status ) {
						
						if ( Lang13.Bool( this.foundmob ) ) {
							this.foundmob.lastattacked = L;
							L.lastattacker = this.foundmob;
						}
						((Mob)L).Stun( this.stunforce );
						((Mob)L).Weaken( this.stunforce );
						((Mob_Living)L).apply_effect( "stutter", this.stunforce );
						((Ent_Static)L).visible_message( "<span class='danger'>" + L + " has been stunned with " + this + " by " + ( Lang13.Bool( this.foundmob ) ? this.foundmob : ((dynamic)( "Unknown" )) ) + "!</span>" );
						GlobalFuncs.playsound( this.loc, "sound/weapons/Egloves.ogg", 50, 1, -1 );

						if ( this.loc is Mob_Living_Silicon_Robot ) {
							R = this.loc;

							if ( R != null && Lang13.Bool( ((dynamic)R).cell ) ) {
								((Obj_Item_Weapon_Cell)((dynamic)R).cell).use( this.hitcost );
							}
						} else {
							this.deductcharge( this.hitcost );
						}

						if ( L is Mob_Living_Carbon_Human ) {
							H = L;
							((Mob_Living_Carbon_Human)H).forcesay( GlobalVars.hit_appends );
						}
						this.foundmob.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "]<font color='red'> Stunned " + L.name + " (" + L.ckey + ") with " + this.name + "</font>" );
						L.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "]<font color='orange'> Stunned by thrown " + this + " by " + ( this.foundmob is Mob ? this.foundmob.name : "" ) + " (" + ( this.foundmob is Mob ? this.foundmob.ckey : "" ) + ")</font>" );
						GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<font color='red'>Flying " + this.name + ", thrown by " + ( this.foundmob is Mob ? this.foundmob.name : "" ) + " (" + ( this.foundmob is Mob ? this.foundmob.ckey : "" ) + ") stunned " + L.name + " (" + L.ckey + ")</font>" ) ) );

						if ( !( this.foundmob is Mob_Living_Carbon ) ) {
							L.LAssailant = null;
						} else {
							L.LAssailant = this.foundmob;
						}
						return null;
					}
				}
			}
			return base.throw_impact( (object)(hit_atom), (object)(speed), user );
		}

		// Function from file: stunbaton.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			dynamic L = null;
			int? hit = null;
			dynamic target_zone = null;
			Ent_Static R = null;
			dynamic H = null;

			
			if ( this.status && Lang13.Bool( user.mutations.Contains( 5 ) ) && Rand13.PercentChance( 50 ) ) {
				((Mob)user).simple_message( "<span class='danger'>You accidentally hit yourself with " + this + "!</span>", "<span class='danger'>The " + this.name + " goes mad!</span>" );
				((Mob)user).Weaken( this.stunforce * 3 );
				this.deductcharge( this.hitcost );
				return null;
			}

			if ( M is Mob_Living_Silicon_Robot ) {
				base.attack( (object)(M), (object)(user), def_zone, eat_override );
				return null;
			}

			if ( !( M is Mob_Living ) ) {
				return null;
			}
			L = M;
			hit = 1;

			if ( user.a_intent == "hurt" ) {
				hit = Lang13.IntNullable( base.attack( (object)(M), (object)(user), def_zone, eat_override ) );

				if ( Lang13.Bool( hit ) ) {
					GlobalFuncs.playsound( this.loc, "swing_hit", 50, 1, -1 );
				}
			} else {
				hit = -1;

				if ( !this.status ) {
					((Ent_Static)L).visible_message( "<span class='attack'>" + L + " has been prodded with the " + this + " by " + user + ". Luckily it was off.</span>", null, null, null, "<span class='warning'>The " + this.name + " decides to spare this one.</span>" );
					return null;
				}
			}

			if ( this.status && Lang13.Bool( hit ) ) {
				
				if ( hit == -1 ) {
					target_zone = GlobalFuncs.get_zone_with_miss_chance( ((dynamic)user.zone_sel).selecting, L );

					if ( user == L ) {
						target_zone = ((dynamic)user.zone_sel).selecting;
					}

					if ( !Lang13.Bool( target_zone ) && !Lang13.Bool( L.stat ) ) {
						this.visible_message( new Txt( "<span class='danger'>" ).item( user ).str( " misses " ).item( L ).str( " with " ).the( this ).item().str( "!</span>" ).ToString() );
						return null;
					}
				}
				user.lastattacked = L;
				L.lastattacker = user;
				((Mob)L).Stun( this.stunforce );
				((Mob)L).Weaken( this.stunforce );
				((Mob_Living)L).apply_effect( "stutter", this.stunforce );
				((Ent_Static)L).visible_message( "<span class='danger'>" + L + " has been stunned with " + this + " by " + user + "!</span>", "<span class='userdanger'>You have been stunned with " + this + " by " + user + "!</span>", null, null, "<span class='userdanger'>" + user + "'s " + this.name + " sucks the life right out of you!</span>" );
				GlobalFuncs.playsound( this.loc, "sound/weapons/Egloves.ogg", 50, 1, -1 );

				if ( this.loc is Mob_Living_Silicon_Robot ) {
					R = this.loc;

					if ( R != null && Lang13.Bool( ((dynamic)R).cell ) ) {
						((Obj_Item_Weapon_Cell)((dynamic)R).cell).use( this.hitcost );
					}
				} else {
					this.deductcharge( this.hitcost );
				}

				if ( L is Mob_Living_Carbon_Human ) {
					H = L;
					((Mob_Living_Carbon_Human)H).forcesay( GlobalVars.hit_appends );
				}
				user.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "]<font color='red'> Stunned " + L.name + " (" + L.ckey + ") with " + this.name + "</font>" );
				L.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "]<font color='orange'> Stunned by " + user.name + " (" + user.ckey + ") with " + this.name + "</font>" );
				GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<font color='red'>" + user.name + " (" + user.ckey + ") stunned " + L.name + " (" + L.ckey + ") with " + this.name + "</font>" ) ) );

				if ( !( user is Mob_Living_Carbon ) ) {
					M.LAssailant = null;
				} else {
					M.LAssailant = user;
				}
			}
			return null;
		}

		// Function from file: stunbaton.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.status && Lang13.Bool( user.mutations.Contains( 5 ) ) && Rand13.PercentChance( 50 ) ) {
				((Mob)user).simple_message( "<span class='warning'>You grab the " + this + " on the wrong side.</span>", "<span class='danger'>The " + this.name + " blasts you with its power!</span>" );
				((Mob)user).Weaken( this.stunforce * 3 );
				this.deductcharge( this.hitcost );
				return null;
			}

			if ( Lang13.Bool( this.bcell ) && Convert.ToDouble( this.bcell.charge ) >= this.hitcost ) {
				this.status = !this.status;
				((Mob)user).simple_message( "<span class='notice'>" + this + " is now " + ( this.status ? "on" : "off" ) + ".</span>", "<span class='notice'>" + this + " is now " + Rand13.Pick(new object [] { "drowsy", "hungry", "thirsty", "bored", "unhappy" }) + ".</span>" );
				GlobalFuncs.playsound( this.loc, "sparks", 75, 1, -1 );
				this.update_icon();
			} else {
				this.status = false;

				if ( !Lang13.Bool( this.bcell ) ) {
					((Mob)user).simple_message( "<span class='warning'>" + this + " does not have a power source!</span>", "<span class='warning'>" + this + " has no pulse and its soul has departed...</span>" );
				} else {
					((Mob)user).simple_message( "<span class='warning'>" + this + " is out of charge.</span>", "<span class='warning'>" + this + " refuses to obey you.</span>" );
				}
			}
			this.add_fingerprint( user );
			return null;
		}

		// Function from file: stunbaton.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Cell ) {
				
				if ( !Lang13.Bool( this.bcell ) ) {
					
					if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
						this.bcell = a;
						GlobalFuncs.to_chat( b, "<span class='notice'>You install a cell in " + this + ".</span>" );
						this.update_icon();
					}
				} else {
					GlobalFuncs.to_chat( b, "<span class='notice'>" + this + " already has a cell.</span>" );
				}
			} else if ( a is Obj_Item_Weapon_Screwdriver ) {
				
				if ( Lang13.Bool( this.bcell ) ) {
					this.bcell.updateicon();
					this.bcell.loc = GlobalFuncs.get_turf( this.loc );
					this.bcell = null;
					GlobalFuncs.to_chat( b, "<span class='notice'>You remove the cell from the " + this + ".</span>" );
					this.status = false;
					this.update_icon();
					return null;
				}
				base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: stunbaton.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( Lang13.Bool( this.bcell ) ) {
				GlobalFuncs.to_chat( user, "<span class='info'>The baton is " + Num13.Floor( ((Obj_Item_Weapon_Cell)this.bcell).percent() ) + "% charged.</span>" );
			}

			if ( !Lang13.Bool( this.bcell ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>The baton does not have a power source installed.</span>" );
			}
			return null;
		}

		// Function from file: stunbaton.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( this.status ) {
				this.icon_state = "" + Lang13.Initial( this, "name" ) + "_active";
			} else if ( !Lang13.Bool( this.bcell ) ) {
				this.icon_state = "" + Lang13.Initial( this, "name" ) + "_nocell";
			} else {
				this.icon_state = "" + Lang13.Initial( this, "name" );
			}
			return null;
		}

		// Function from file: stunbaton.dm
		public bool deductcharge( double chrgdeductamt = 0 ) {
			
			if ( Lang13.Bool( this.bcell ) ) {
				
				if ( ((Obj_Item_Weapon_Cell)this.bcell).use( chrgdeductamt ) ) {
					
					if ( Convert.ToDouble( this.bcell.charge ) < this.hitcost ) {
						this.status = false;
						this.update_icon();
					}
					return true;
				} else {
					this.status = false;
					this.update_icon();
					return false;
				}
			}
			return false;
		}

		// Function from file: stunbaton.dm
		public override dynamic suicide_act( Mob_Living_Carbon_Human user = null ) {
			GlobalFuncs.to_chat( Map13.FetchViewers( null, user ), new Txt( "<span class='danger'>" ).item( user ).str( " is putting the live " ).item( this.name ).str( " in " ).his_her_its_their().str( " mouth! It looks like " ).he_she_it_they().str( "'s trying to commit suicide.</span>" ).ToString() );
			return 2;
		}

	}

}