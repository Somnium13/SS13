// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_SuspensionGen : Obj_Machinery {

		public dynamic cell = null;
		public dynamic auth_card = null;
		public bool locked = true;
		public bool open = false;
		public bool screwed = true;
		public string field_type = "";
		public int power_use = 25;
		public Obj_Effect_SuspensionField suspension_field = null;
		public ByTable secured_mobs = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 47 });
			this.icon = "icons/obj/xenoarchaeology.dmi";
			this.icon_state = "suspension2-b";
		}

		// Function from file: suspension_generator.dm
		public Obj_Machinery_SuspensionGen ( dynamic loc = null ) : base( (object)(loc) ) {
			this.cell = new Obj_Item_Weapon_Cell_High( this );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: suspension_generator.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			this.deactivate();
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: suspension_generator.dm
		public void deactivate(  ) {
			dynamic T = null;
			dynamic M = null;

			T = GlobalFuncs.get_turf( this.suspension_field );

			foreach (dynamic _a in Lang13.Enumerate( T )) {
				M = _a;
				
				GlobalFuncs.to_chat( M, "<span class='info'>You no longer feel like floating.</span>" );
				M.weakened = Num13.MinInt( ((int)( M.weakened )), 3 );
			}
			this.visible_message( new Txt( "<span class='notice'>" ).icon( this ).str( " " ).item( this ).str( " deactivates with a gentle shudder.</span>" ).ToString() );
			GlobalFuncs.qdel( this.suspension_field );
			this.suspension_field = null;
			this.icon_state = "suspension2";
			return;
		}

		// Function from file: suspension_generator.dm
		public void activate(  ) {
			dynamic T = null;
			bool success = false;
			int collected = 0;
			Mob_Living_Carbon C = null;
			Mob_Living_Silicon R = null;
			Mob_Living_SimpleAnimal C2 = null;
			Obj_Item I = null;

			T = GlobalFuncs.get_turf( Map13.GetStep( this, this.dir ) );
			success = false;
			collected = 0;

			switch ((string)( this.field_type )) {
				case "carbon":
					success = true;

					foreach (dynamic _a in Lang13.Enumerate( T, typeof(Mob_Living_Carbon) )) {
						C = _a;
						
						C.weakened += 5;
						C.visible_message( new Txt( "<span class='notice'>" ).icon( C ).str( " " ).item( C ).str( " begins to float in the air!</span>" ).ToString(), "You feel tingly and light, but it is difficult to move." );
					}
					break;
				case "nitrogen":
					success = true;
					break;
				case "mercury":
					success = true;
					break;
				case "chlorine":
					success = true;
					break;
				case "potassium":
					success = true;
					break;
				case "plasma":
					success = true;
					break;
				case "calcium":
					success = true;
					break;
				case "iron":
					success = true;

					foreach (dynamic _b in Lang13.Enumerate( T, typeof(Mob_Living_Silicon) )) {
						R = _b;
						
						R.weakened += 5;
						R.visible_message( new Txt( "<span class='notice'>" ).icon( R ).str( " " ).item( R ).str( " begins to float in the air!</span>" ).ToString(), "You feel tingly and light, but it is difficult to move." );
					}
					break;
			}

			if ( !success ) {
				return;
			}

			foreach (dynamic _d in Lang13.Enumerate( T, typeof(Mob_Living_SimpleAnimal) )) {
				C2 = _d;
				
				C2.visible_message( new Txt( "<span class='notice'>" ).icon( C2 ).str( " " ).item( C2 ).str( " begins to float in the air!</span>" ).ToString(), "You feel tingly and light, but it is difficult to move." );
				C2.weakened += 5;
			}
			this.suspension_field = new Obj_Effect_SuspensionField( T );
			this.suspension_field.field_type = this.field_type;
			this.visible_message( new Txt( "<span class='notice'>" ).icon( this ).str( " " ).item( this ).str( " activates with a low hum.</span>" ).ToString() );
			this.icon_state = "suspension3";

			foreach (dynamic _e in Lang13.Enumerate( T, typeof(Obj_Item) )) {
				I = _e;
				
				I.loc = this.suspension_field;
				collected++;
			}

			if ( collected != 0 ) {
				this.suspension_field.icon_state = "energynet";
				this.suspension_field.overlays.Add( "shield2" );
				this.visible_message( new Txt( "<span class='notice'>" ).icon( this.suspension_field ).str( " " ).item( this.suspension_field ).str( " gently absconds " ).item( ( collected > 1 ? "something" : "several things" ) ).str( ".</span>" ).ToString() );
			} else if ( T is Tile_Unsimulated_Mineral || T is Tile_Simulated_Wall ) {
				this.suspension_field.icon_state = "shieldsparkles";
			} else {
				this.suspension_field.icon_state = "shield2";
			}
			return;
		}

		// Function from file: suspension_generator.dm
		public bool attempt_unlock( dynamic C = null ) {
			
			if ( !this.open ) {
				
				if ( C is Obj_Item_Weapon_Card_Emag && Convert.ToDouble( this.cell.charge ) > 0 ) {
					
					if ( Rand13.PercentChance( 95 ) ) {
						this.locked = false;
					}
				} else if ( C is Obj_Item_Weapon_Card_Id && this.check_access( C ) ) {
					this.locked = false;
				}

				if ( !this.locked ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: suspension_generator.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic I = null;

			
			if ( a is Obj_Item_Weapon_Screwdriver ) {
				
				if ( !this.open ) {
					
					if ( this.screwed ) {
						this.screwed = false;
					} else {
						this.screwed = true;
					}
					GlobalFuncs.to_chat( b, "<span class='info'>You " + ( this.screwed ? "screw" : "unscrew" ) + " the battery panel.</span>" );
				}
			} else if ( a is Obj_Item_Weapon_Crowbar ) {
				
				if ( !this.locked ) {
					
					if ( !this.screwed ) {
						
						if ( !( this.suspension_field != null ) ) {
							
							if ( this.open ) {
								this.open = false;
							} else {
								this.open = true;
							}
							GlobalFuncs.to_chat( b, "<span class='info'>You crowbar the battery panel " + ( this.open ? "open" : "in place" ) + ".</span>" );
							this.icon_state = "suspension" + ( Lang13.Bool( this.anchored ) ? ( this.open ? ( Lang13.Bool( this.cell ) ? "1" : "0" ) : "2" ) : ( this.open ? ( Lang13.Bool( this.cell ) ? "1-b" : "0-b" ) : "2-b" ) );
						} else {
							GlobalFuncs.to_chat( b, "<span class='warning'>" + this + "'s safety locks are engaged, shut it down first.</span>" );
						}
					} else {
						GlobalFuncs.to_chat( b, "<span class='warning'>Unscrew " + this + "'s battery panel first.</span>" );
					}
				} else {
					GlobalFuncs.to_chat( b, "<span class='warning'>" + this + "'s security locks are engaged.</span>" );
				}
			} else if ( a is Obj_Item_Weapon_Wrench ) {
				
				if ( !( this.suspension_field != null ) ) {
					
					if ( Lang13.Bool( this.anchored ) ) {
						this.anchored = 0;
					} else {
						this.anchored = 1;
					}
					this.icon_state = "suspension" + ( Lang13.Bool( this.anchored ) ? ( this.open ? ( Lang13.Bool( this.cell ) ? "1" : "0" ) : "2" ) : ( this.open ? ( Lang13.Bool( this.cell ) ? "1-b" : "0-b" ) : "2-b" ) );
					GlobalFuncs.to_chat( b, "<span class='info'>You wrench the stabilising legs " + ( Lang13.Bool( this.anchored ) ? "into place" : "up against the body" ) + ".</span>" );

					if ( Lang13.Bool( this.anchored ) ) {
						this.desc = "It is resting securely on four stubby legs.";
					} else {
						this.desc = "It has stubby legs bolted up against it's body for stabilising.";
					}
				} else {
					GlobalFuncs.to_chat( b, "<span class='warning'>You are unable to secure " + this + " while it is active!</span>" );
				}
			} else if ( a is Obj_Item_Weapon_Cell ) {
				
				if ( this.open ) {
					
					if ( Lang13.Bool( this.cell ) ) {
						GlobalFuncs.to_chat( b, "<span class='warning'>There is a power cell already installed.</span>" );
					} else if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
						this.cell = a;
						GlobalFuncs.to_chat( b, "<span class='info'>You insert the power cell.</span>" );

						if ( Lang13.Bool( this.anchored ) ) {
							this.icon_state = "suspension1";
						} else {
							this.icon_state = "suspension1-b";
						}
					}
				}
			} else if ( a is Obj_Item_Weapon_Card ) {
				I = a;

				if ( !Lang13.Bool( this.auth_card ) ) {
					
					if ( this.attempt_unlock( I ) ) {
						GlobalFuncs.to_chat( b, "<span class='info'>You swipe " + I + ", the console flashes '<i>Access granted.</i>'</span>" );
					} else {
						GlobalFuncs.to_chat( b, "<span class='warning'>You swipe " + I + ", console flashes '<i>Access denied.</i>'</span>" );
					}
				} else {
					GlobalFuncs.to_chat( b, "<span class='warning'>Remove " + this.auth_card + " first.</span>" );
				}
			}
			return null;
		}

		// Function from file: suspension_generator.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( !this.open ) {
				this.interact( a );
			} else if ( Lang13.Bool( this.cell ) ) {
				
				if ( a is Mob_Dead_Observer ) {
					return 0;
				}
				this.cell.loc = this.loc;
				((Ent_Static)this.cell).add_fingerprint( a );
				this.cell.updateicon();

				if ( Lang13.Bool( this.anchored ) ) {
					this.icon_state = "suspension0";
				} else {
					this.icon_state = "suspension0-b";
				}
				this.cell = null;
				GlobalFuncs.to_chat( a, "<span class='info'>You remove the power cell</span>" );
			}
			return null;
		}

		// Function from file: suspension_generator.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic I = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}
			Task13.User.set_machine( this );

			if ( Lang13.Bool( href_list["toggle_field"] ) ) {
				
				if ( !( this.suspension_field != null ) ) {
					
					if ( Convert.ToDouble( this.cell.charge ) > 0 ) {
						
						if ( Lang13.Bool( this.anchored ) ) {
							this.activate();
						} else {
							GlobalFuncs.to_chat( Task13.User, "<span class='warning'>You are unable to activate " + this + " until it is properly secured on the ground.</span>" );
						}
					}
				} else {
					this.deactivate();
				}
			}

			if ( Lang13.Bool( href_list["select_field"] ) ) {
				this.field_type = href_list["select_field"];
			} else if ( Lang13.Bool( href_list["insertcard"] ) ) {
				I = Task13.User.get_active_hand();

				if ( I is Obj_Item_Weapon_Card ) {
					
					if ( Task13.User.drop_item( I, this ) ) {
						this.auth_card = I;

						if ( this.attempt_unlock( I ) ) {
							GlobalFuncs.to_chat( Task13.User, "<span class='info'>You insert " + I + ", the console flashes '<i>Access granted.</a>'</span>" );
						} else {
							GlobalFuncs.to_chat( Task13.User, "<span class='warning'>You insert " + I + ", the console flashes '<i>Access denied.</a>'</span>" );
						}
					}
				}
			} else if ( Lang13.Bool( href_list["ejectcard"] ) ) {
				
				if ( Lang13.Bool( this.auth_card ) ) {
					
					if ( Task13.User is Mob_Living_Carbon_Human ) {
						this.auth_card.loc = Task13.User.loc;

						if ( !Lang13.Bool( Task13.User.get_active_hand() ) ) {
							Task13.User.put_in_hands( this.auth_card );
						}
						this.auth_card = null;
					} else {
						this.auth_card.loc = this.loc;
						this.auth_card = null;
					}
				}
			} else if ( Lang13.Bool( href_list["lock"] ) ) {
				this.locked = true;
			} else if ( Lang13.Bool( href_list["close"] ) ) {
				Task13.User.unset_machine();
				Interface13.Browse( Task13.User, null, "window=suspension" );
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: suspension_generator.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			string dat = null;
			string colour = null;

			dat = "<b>Multi-phase mobile suspension field generator MK II \"Steadfast\"</b><br>";

			if ( Lang13.Bool( this.cell ) ) {
				colour = "red";

				if ( Convert.ToDouble( this.cell.charge / this.cell.maxcharge ) > 0.66 ) {
					colour = "green";
				} else if ( Convert.ToDouble( this.cell.charge / this.cell.maxcharge ) > 0.33 ) {
					colour = "orange";
				}
				dat += "<b>Energy cell</b>: <font color='" + colour + "'>" + this.cell.charge * 100 / this.cell.maxcharge + "%</font><br>";
			} else {
				dat += "<b>Energy cell</b>: None<br>";
			}

			if ( Lang13.Bool( this.auth_card ) ) {
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";ejectcard=1'>[" ).item( this.auth_card ).str( "]<a><br>" ).ToString();

				if ( !this.locked ) {
					dat += new Txt( "<b><A href='?src=" ).Ref( this ).str( ";toggle_field=1'>" ).item( ( this.suspension_field != null ? "Disable" : "Enable" ) ).str( " field</a></b><br>" ).ToString();
				} else {
					dat += "<br>";
				}
			} else {
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";insertcard=1'>[------]<a><br>" ).ToString();

				if ( !this.locked ) {
					dat += new Txt( "<b><A href='?src=" ).Ref( this ).str( ";toggle_field=1'>" ).item( ( this.suspension_field != null ? "Disable" : "Enable" ) ).str( " field</a></b><br>" ).ToString();
				} else {
					dat += "Enter your ID to begin.<br>";
				}
			}
			dat += "<hr>";

			if ( !this.locked ) {
				dat += "<b>Select field mode</b><br>";
				dat += new Txt().item( ( this.field_type == "carbon" ? "<b>" : "" ) ).str( "<A href='?src=" ).Ref( this ).str( ";select_field=carbon'>Diffracted carbon dioxide laser</A></b><br>" ).ToString();
				dat += new Txt().item( ( this.field_type == "nitrogen" ? "<b>" : "" ) ).str( "<A href='?src=" ).Ref( this ).str( ";select_field=nitrogen'>Nitrogen tracer field</A></b><br>" ).ToString();
				dat += new Txt().item( ( this.field_type == "potassium" ? "<b>" : "" ) ).str( "<A href='?src=" ).Ref( this ).str( ";select_field=potassium'>Potassium refrigerant cloud</A></b><br>" ).ToString();
				dat += new Txt().item( ( this.field_type == "mercury" ? "<b>" : "" ) ).str( "<A href='?src=" ).Ref( this ).str( ";select_field=mercury'>Mercury dispersion wave</A></b><br>" ).ToString();
				dat += new Txt().item( ( this.field_type == "iron" ? "<b>" : "" ) ).str( "<A href='?src=" ).Ref( this ).str( ";select_field=iron'>Iron wafer conduction field</A></b><br>" ).ToString();
				dat += new Txt().item( ( this.field_type == "calcium" ? "<b>" : "" ) ).str( "<A href='?src=" ).Ref( this ).str( ";select_field=calcium'>Calcium binary deoxidiser</A></b><br>" ).ToString();
				dat += new Txt().item( ( this.field_type == "chlorine" ? "<b>" : "" ) ).str( "<A href='?src=" ).Ref( this ).str( ";select_field=chlorine'>Chlorine diffusion emissions</A></b><br>" ).ToString();
				dat += new Txt().item( ( this.field_type == "plasma" ? "<b>" : "" ) ).str( "<A href='?src=" ).Ref( this ).str( ";select_field=plasma'>Plasma saturated field</A></b><br>" ).ToString();
			} else {
				dat += "<br>";
				dat += "<br>";
				dat += "<br>";
				dat += "<br>";
				dat += "<br>";
				dat += "<br>";
				dat += "<br>";
				dat += "<br>";
			}
			dat += "<hr>";
			dat += "<font color='blue'><b>Always wear safety gear and consult a field manual before operation.</b></font><br>";

			if ( !this.locked ) {
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";lock=1'>Lock console</A><br>" ).ToString();
			} else {
				dat += "<br>";
			}
			dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";refresh=1'>Refresh console</A><br>" ).ToString();
			dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";close=1'>Close console</A>" ).ToString();
			Interface13.Browse( user, dat, "window=suspension;size=500x400" );
			GlobalFuncs.onclose( user, "suspension" );
			return null;
		}

		// Function from file: suspension_generator.dm
		public override dynamic process(  ) {
			dynamic T = null;
			Mob_Living_Carbon M = null;
			Mob_Living_Silicon M2 = null;
			Obj_Item I = null;
			Mob_Living_SimpleAnimal M3 = null;

			
			if ( this.suspension_field != null ) {
				this.cell.charge -= this.power_use;
				T = GlobalFuncs.get_turf( this.suspension_field );

				if ( this.field_type == "carbon" ) {
					
					foreach (dynamic _a in Lang13.Enumerate( T, typeof(Mob_Living_Carbon) )) {
						M = _a;
						
						M.weakened = Num13.MaxInt( ((int)( M.weakened )), 3 );
						this.cell.charge -= this.power_use;

						if ( Rand13.PercentChance( 5 ) ) {
							GlobalFuncs.to_chat( M, "<span class='notice'>" + Rand13.Pick(new object [] { "You feel tingly.", "You feel like floating.", "It is hard to speak.", "You can barely move." }) + "</span>" );
						}
					}
				}

				if ( this.field_type == "iron" ) {
					
					foreach (dynamic _b in Lang13.Enumerate( T, typeof(Mob_Living_Silicon) )) {
						M2 = _b;
						
						M2.weakened = Num13.MaxInt( ((int)( M2.weakened )), 3 );
						this.cell.charge -= this.power_use;

						if ( Rand13.PercentChance( 5 ) ) {
							GlobalFuncs.to_chat( M2, "<span class='notice'>" + Rand13.Pick(new object [] { "You feel tingly.", "You feel like floating.", "It is hard to speak.", "You can barely move." }) + "</span>" );
						}
					}
				}

				foreach (dynamic _c in Lang13.Enumerate( T, typeof(Obj_Item) )) {
					I = _c;
					

					if ( !( this.suspension_field.contents.len != 0 ) ) {
						this.suspension_field.icon_state = "energynet";
						this.suspension_field.overlays.Add( "shield2" );
					}
					I.loc = this.suspension_field;
				}

				foreach (dynamic _d in Lang13.Enumerate( T, typeof(Mob_Living_SimpleAnimal) )) {
					M3 = _d;
					
					M3.weakened = Num13.MaxInt( ((int)( M3.weakened )), 3 );
					this.cell.charge -= this.power_use;

					if ( Rand13.PercentChance( 5 ) ) {
						GlobalFuncs.to_chat( M3, "<span class='notice'>" + Rand13.Pick(new object [] { "You feel tingly.", "You feel like floating.", "It is hard to speak.", "You can barely move." }) + "</span>" );
					}
				}

				if ( Convert.ToDouble( this.cell.charge ) <= 0 ) {
					this.deactivate();
				}
			}
			return null;
		}

		// Function from file: suspension_generator.dm
		public override dynamic power_change(  ) {
			return null;
		}

		// Function from file: suspension_generator.dm
		[Verb]
		[VerbInfo( name: "Rotate suspension gen (clockwise)", group: "Object", access: VerbAccess.InView, range: 1 )]
		public void toggle(  ) {
			
			if ( Lang13.Bool( this.anchored ) ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>You cannot rotate " + this + ", it has been firmly fixed to the floor.</span>" );
			} else {
				this.dir = Num13.Rotate( this.dir, 90 );
			}
			return;
		}

	}

}