// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Rcd : Obj_Item_Weapon {

		public EffectSystem_SparkSpread spark_system = null;
		public double matter = 0;
		public double max_matter = 160;
		public bool working = false;
		public int mode = 1;
		public bool canRturf = false;
		public Type airlock_type = typeof(Obj_Machinery_Door_Airlock);
		public bool advanced_airlock_setting = true;
		public int sheetmultiplier = 4;
		public int plasteelmultiplier = 3;
		public ByTable conf_access = null;
		public bool use_one_access = false;
		public double wallcost = 16;
		public double floorcost = 2;
		public double grillecost = 4;
		public double windowcost = 8;
		public double airlockcost = 16;
		public double deconwallcost = 26;
		public double deconfloorcost = 33;
		public double decongrillecost = 4;
		public double deconwindowcost = 8;
		public double deconairlockcost = 32;
		public double walldelay = 20;
		public dynamic floordelay = null;
		public double grilledelay = 40;
		public double windowdelay = 40;
		public double airlockdelay = 50;
		public double deconwalldelay = 40;
		public double deconfloordelay = 50;
		public dynamic decongrilledelay = null;
		public double deconwindowdelay = 50;
		public double deconairlockdelay = 50;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 64;
			this.force = 10;
			this.throwforce = 10;
			this.throw_speed = 3;
			this.throw_range = 5;
			this.materials = new ByTable().Set( "$metal", 100000 );
			this.origin_tech = "engineering=4;materials=2";
			this.req_access_txt = "11";
			this.icon_state = "rcd";
		}

		// Function from file: RCD.dm
		public Obj_Item_Weapon_Rcd ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.desc = "An RCD. It currently holds " + this.matter + "/" + this.max_matter + " matter-units.";
			this.spark_system = new EffectSystem_SparkSpread();
			this.spark_system.set_up( 5, 0, this );
			this.spark_system.attach( this );
			GlobalVars.rcd_list.Add( this );
			return;
		}

		// Function from file: RCD.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic S = null;
			dynamic F = null;
			bool door_check = false;
			Obj_Machinery_Door D = null;
			dynamic T = null;
			dynamic W = null;
			dynamic F2 = null;
			dynamic G = null;
			Obj_Structure_Grille GRILLE = null;
			Obj_Structure_Grille G2 = null;
			Obj_Structure_Window_Fulltile WD = null;

			
			if ( !( proximity_flag == true ) ) {
				return false;
			}

			if ( target is Zone_Shuttle || target is Tile_Space_Transit ) {
				return false;
			}

			if ( !( target is Tile || target is Obj_Machinery_Door_Airlock || target is Obj_Structure_Grille || target is Obj_Structure_Window ) ) {
				return false;
			}

			switch ((int)( this.mode )) {
				case 1:
					
					if ( target is Tile_Space ) {
						S = target;

						if ( this.useResource( this.floorcost, user ) ) {
							user.WriteMsg( "<span class='notice'>You start building floor...</span>" );
							this.activate();
							((Tile)S).ChangeTurf( typeof(Tile_Simulated_Floor_Plating) );
							return true;
						}
						return false;
					}

					if ( target is Tile_Simulated_Floor ) {
						F = target;

						if ( this.checkResource( this.wallcost, user ) ) {
							user.WriteMsg( "<span class='notice'>You start building wall...</span>" );
							GlobalFuncs.playsound( this.loc, "sound/machines/click.ogg", 50, 1 );

							if ( GlobalFuncs.do_after( user, this.walldelay, null, target ) ) {
								
								if ( !this.useResource( this.wallcost, user ) ) {
									return false;
								}
								this.activate();
								((Tile)F).ChangeTurf( typeof(Tile_Simulated_Wall) );
								return true;
							}
						}
						return false;
					}
					break;
				case 2:
					
					if ( target is Tile_Simulated_Floor ) {
						
						if ( this.checkResource( this.airlockcost, user ) ) {
							door_check = true;

							foreach (dynamic _a in Lang13.Enumerate( target, typeof(Obj_Machinery_Door) )) {
								D = _a;
								

								if ( !D.sub_door ) {
									door_check = false;
									break;
								}
							}

							if ( door_check ) {
								user.WriteMsg( "<span class='notice'>You start building airlock...</span>" );
								GlobalFuncs.playsound( this.loc, "sound/machines/click.ogg", 50, 1 );

								if ( GlobalFuncs.do_after( user, this.airlockdelay, null, target ) ) {
									
									if ( !this.useResource( this.airlockcost, user ) ) {
										return false;
									}
									this.activate();
									T = Lang13.Call( this.airlock_type, target );
									T.electronics = new Obj_Item_Weapon_Electronics_Airlock( this.loc );

									if ( this.conf_access != null ) {
										T.electronics.accesses = this.conf_access.Copy();
									}
									T.electronics.one_access = this.use_one_access;

									if ( T.electronics.one_access ) {
										T.req_one_access = T.electronics.accesses;
									} else {
										T.req_access = T.electronics.accesses;
									}

									if ( !((Obj_Machinery_Door)T).checkForMultipleDoors() ) {
										GlobalFuncs.qdel( T );
										this.useResource( -this.airlockcost, user );
										return false;
									}
									T.autoclose = true;
									return true;
								}
								return false;
							} else {
								user.WriteMsg( "<span class='warning'>There is another door here!</span>" );
								return false;
							}
						}
						return false;
					}
					break;
				case 3:
					
					if ( target is Tile_Simulated_Wall ) {
						W = target;

						if ( W is Tile_Simulated_Wall_RWall && !this.canRturf ) {
							return false;
						}

						if ( this.checkResource( this.deconwallcost, user ) ) {
							user.WriteMsg( "<span class='notice'>You start deconstructing wall...</span>" );
							GlobalFuncs.playsound( this.loc, "sound/machines/click.ogg", 50, 1 );

							if ( GlobalFuncs.do_after( user, this.deconwalldelay, null, target ) ) {
								
								if ( !this.useResource( this.deconwallcost, user ) ) {
									return false;
								}
								this.activate();
								((Tile)W).ChangeTurf( typeof(Tile_Simulated_Floor_Plating) );
								return true;
							}
						}
						return false;
					}

					if ( target is Tile_Simulated_Floor ) {
						F2 = target;

						if ( F2 is Tile_Simulated_Floor_Engine && !this.canRturf ) {
							return false;
						}

						if ( Lang13.Bool( ((dynamic)F2.baseturf).IsInstanceOfType( F2 ) ) ) {
							user.WriteMsg( "<span class='notice'>You can't dig any deeper!</span>" );
							return false;
						} else if ( this.checkResource( this.deconfloorcost, user ) ) {
							user.WriteMsg( "<span class='notice'>You start deconstructing floor...</span>" );
							GlobalFuncs.playsound( this.loc, "sound/machines/click.ogg", 50, 1 );

							if ( GlobalFuncs.do_after( user, this.deconfloordelay, null, target ) ) {
								
								if ( !this.useResource( this.deconfloorcost, user ) ) {
									return false;
								}
								this.activate();
								((Tile)F2).ChangeTurf( F2.baseturf );
								return true;
							}
						}
						return false;
					}

					if ( target is Obj_Machinery_Door_Airlock ) {
						
						if ( this.checkResource( this.deconairlockcost, user ) ) {
							user.WriteMsg( "<span class='notice'>You start deconstructing airlock...</span>" );
							GlobalFuncs.playsound( this.loc, "sound/machines/click.ogg", 50, 1 );

							if ( GlobalFuncs.do_after( user, this.deconairlockdelay, null, target ) ) {
								
								if ( !this.useResource( this.deconairlockcost, user ) ) {
									return false;
								}
								this.activate();
								GlobalFuncs.qdel( target );
								return true;
							}
						}
						return false;
					}

					if ( target is Obj_Structure_Window ) {
						
						if ( this.checkResource( this.deconwindowcost, user ) ) {
							user.WriteMsg( "<span class='notice'>You start deconstructing the window...</span>" );
							GlobalFuncs.playsound( this.loc, "sound/machines/click.ogg", 50, 1 );

							if ( GlobalFuncs.do_after( user, this.deconwindowdelay, null, target ) ) {
								
								if ( !this.useResource( this.deconwindowcost, user ) ) {
									return false;
								}
								this.activate();
								GlobalFuncs.qdel( target );
								return true;
							}
						}
						return false;
					}

					if ( target is Obj_Structure_Grille ) {
						G = target;

						if ( !((Obj_Structure_Grille)G).shock( user, 90 ) ) {
							
							if ( this.useResource( this.decongrillecost, user ) ) {
								user.WriteMsg( "<span class='notice'>You start deconstructing the grille...</span>" );
								this.activate();
								GlobalFuncs.playsound( this.loc, "sound/machines/click.ogg", 50, 1 );
								GlobalFuncs.qdel( target );
								return true;
							}
							return false;
						}
					}
					break;
				case 4:
					
					if ( target is Tile_Simulated_Floor ) {
						
						if ( this.checkResource( this.grillecost, user ) ) {
							
							foreach (dynamic _b in Lang13.Enumerate( target, typeof(Obj_Structure_Grille) )) {
								GRILLE = _b;
								
								user.WriteMsg( "<span class='warning'>There is already a grille there!</span>" );
								return false;
							}
							user.WriteMsg( "<span class='notice'>You start building a grille...</span>" );
							GlobalFuncs.playsound( this.loc, "sound/machines/click.ogg", 50, 1 );

							if ( GlobalFuncs.do_after( user, this.grilledelay, null, target ) ) {
								
								if ( !this.useResource( this.grillecost, user ) ) {
									return false;
								}
								this.activate();
								G2 = new Obj_Structure_Grille( target );
								G2.anchored = 1;
								return true;
							}
							return false;
						}
						return false;
					}

					if ( target is Obj_Structure_Grille ) {
						
						if ( this.checkResource( this.windowcost, user ) ) {
							user.WriteMsg( "<span class='notice'>You start building a window...</span>" );
							GlobalFuncs.playsound( this.loc, "sound/machines/click.ogg", 50, 1 );

							if ( GlobalFuncs.do_after( user, this.windowdelay, null, target ) ) {
								
								if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Window), target.loc ) ) ) {
									return false;
								}

								if ( !this.useResource( this.windowcost, user ) ) {
									return false;
								}
								this.activate();
								WD = new Obj_Structure_Window_Fulltile( target.loc );
								WD.anchored = 1;
								return true;
							}
							return false;
						}
						return false;
					}
					break;
				default:
					user.WriteMsg( "ERROR: RCD in MODE: " + this.mode + " attempted use by " + user + ". Send this text #coderbus or an admin." );
					return false;
					break;
			}
			return false;
		}

		// Function from file: RCD.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			GlobalFuncs.playsound( this.loc, "sound/effects/pop.ogg", 50, 0 );

			switch ((int)( this.mode )) {
				case 1:
					this.mode = 2;
					user.WriteMsg( "<span class='notice'>You change RCD's mode to 'Airlock'.</span>" );
					break;
				case 2:
					this.mode = 3;
					user.WriteMsg( "<span class='notice'>You change RCD's mode to 'Deconstruct'.</span>" );
					break;
				case 3:
					this.mode = 4;
					user.WriteMsg( "<span class='notice'>You change RCD's mode to 'Grilles & Windows'.</span>" );
					break;
				case 4:
					this.mode = 1;
					user.WriteMsg( "<span class='notice'>You change RCD's mode to 'Floor & Walls'.</span>" );
					break;
			}

			if ( Rand13.PercentChance( 20 ) ) {
				this.spark_system.start();
			}
			return null;
		}

		// Function from file: RCD.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			bool loaded = false;
			dynamic R = null;

			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( user is Mob_Living_Silicon_Robot ) {
				return null;
			}
			loaded = false;

			if ( A is Obj_Item_Weapon_RcdAmmo ) {
				R = A;

				if ( this.matter + R.ammoamt > this.max_matter ) {
					user.WriteMsg( "<span class='warning'>The RCD can't hold any more matter-units!</span>" );
					return null;
				}

				if ( !((Mob)user).unEquip( A ) ) {
					return null;
				}
				GlobalFuncs.qdel( A );
				this.matter += R.ammoamt;
				GlobalFuncs.playsound( this.loc, "sound/machines/click.ogg", 50, 1 );
				loaded = true;
			} else if ( A is Obj_Item_Stack_Sheet_Metal || A is Obj_Item_Stack_Sheet_Glass ) {
				loaded = this.loadwithsheets( A, this.sheetmultiplier, user );
			} else if ( A is Obj_Item_Stack_Sheet_Plasteel ) {
				loaded = this.loadwithsheets( A, this.plasteelmultiplier * this.sheetmultiplier, user );
			}

			if ( loaded ) {
				user.WriteMsg( "<span class='notice'>The RCD now holds " + this.matter + "/" + this.max_matter + " matter-units.</span>" );
				this.desc = "A RCD. It currently holds " + this.matter + "/" + this.max_matter + " matter-units.";
			}
			return null;
		}

		// Function from file: RCD.dm
		public override dynamic Destroy(  ) {
			GlobalFuncs.qdel( this.spark_system );
			this.spark_system = null;
			GlobalVars.rcd_list.Remove( this );
			return base.Destroy();
		}

		// Function from file: RCD.dm
		public virtual bool checkResource( double amount = 0, dynamic user = null ) {
			return this.matter >= amount;
		}

		// Function from file: RCD.dm
		public virtual bool useResource( double amount = 0, dynamic user = null ) {
			
			if ( this.matter < amount ) {
				return false;
			}
			this.matter -= amount;
			this.desc = "An RCD. It currently holds " + this.matter + "/" + this.max_matter + " matter-units.";
			return true;
		}

		// Function from file: RCD.dm
		public void activate(  ) {
			GlobalFuncs.playsound( this.loc, "sound/items/Deconstruct.ogg", 50, 1 );
			return;
		}

		// Function from file: RCD.dm
		public bool loadwithsheets( dynamic S = null, int value = 0, dynamic user = null ) {
			double? maxsheets = null;

			maxsheets = Num13.Floor( ( this.max_matter - this.matter ) / value );

			if ( ( maxsheets ??0) > 0 ) {
				
				if ( Convert.ToDouble( S.amount ) > ( maxsheets ??0) ) {
					((Obj_Item_Stack)S).use( maxsheets );
					this.matter += value * ( maxsheets ??0);
					GlobalFuncs.playsound( this.loc, "sound/machines/click.ogg", 50, 1 );
					user.WriteMsg( "<span class='notice'>You insert " + maxsheets + " " + S.name + " sheets into the RCD. </span>" );
				} else {
					this.matter += value * Convert.ToDouble( S.amount );
					((Mob)user).unEquip();
					((Obj_Item_Stack)S).use( Lang13.DoubleNullable( S.amount ) );
					GlobalFuncs.playsound( this.loc, "sound/machines/click.ogg", 50, 1 );
					user.WriteMsg( "<span class='notice'>You insert " + S.amount + " " + S.name + " sheets into the RCD. </span>" );
				}
				return true;
			}
			user.WriteMsg( "<span class='warning'>You can't insert any more " + S.name + " sheets into the RCD!" );
			return false;
		}

		// Function from file: RCD.dm
		public void toggle_access( string acc = null ) {
			double? req = null;

			
			if ( acc == "all" ) {
				this.conf_access = null;
			} else if ( acc == "one" ) {
				this.use_one_access = !this.use_one_access;
			} else {
				req = String13.ParseNumber( acc );

				if ( this.conf_access == null ) {
					this.conf_access = new ByTable();
				}

				if ( !this.conf_access.Contains( req ) ) {
					this.conf_access.Add( req );
				} else {
					this.conf_access.Remove( req );

					if ( !( this.conf_access.len != 0 ) ) {
						this.conf_access = null;
					}
				}
			}
			return;
		}

		// Function from file: RCD.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			base.Topic( href, href_list, (object)(hsrc) );

			if ( Task13.User.stat != 0 || Task13.User.restrained() ) {
				return null;
			}

			if ( Lang13.Bool( href_list["close"] ) ) {
				Interface13.Browse( Task13.User, null, "window=airlock" );
				return null;
			}

			if ( Lang13.Bool( href_list["access"] ) ) {
				this.toggle_access( href_list["access"] );
			}
			this.__CallVerb("Change Airlock Access" );
			return null;
		}

		// Function from file: RCD.dm
		public override int suicide_act( Mob_Living_Carbon_Human user = null ) {
			user.visible_message( new Txt( "<span class='suicide'>" ).item( user ).str( " sets the RCD to 'Wall' and points it down " ).his_her_its_their().str( " throat! It looks like " ).he_she_it_they().str( "'s trying to commit suicide..</span>" ).ToString() );
			return 1;
		}

		// Function from file: RCD.dm
		[Verb]
		[VerbInfo( name: "Change Airlock Setting", group: "Object", access: VerbAccess.InUserContents, range: 127 )]
		public void change_airlock_setting(  ) {
			dynamic airlockcat = null;
			dynamic airlockpaint = null;
			dynamic airlockpaint2 = null;

			airlockcat = Interface13.Input( Task13.User, "Select whether the airlock is solid or glass.", null, null, new ByTable(new object [] { "Solid", "Glass" }), InputType.Any );

			dynamic _c = airlockcat; // Was a switch-case, sorry for the mess.
			if ( _c=="Solid" ) {
				
				if ( this.advanced_airlock_setting ) {
					airlockpaint = Interface13.Input( Task13.User, "Select the paintjob of the airlock.", null, null, new ByTable(new object [] { "Default", "Engineering", "Atmospherics", "Security", "Command", "Medical", "Research", "Mining", "Maintenance", "External", "High Security" }), InputType.Any );

					dynamic _a = airlockpaint; // Was a switch-case, sorry for the mess.
					if ( _a=="Default" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock);
					} else if ( _a=="Engineering" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_Engineering);
					} else if ( _a=="Atmospherics" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_Atmos);
					} else if ( _a=="Security" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_Security);
					} else if ( _a=="Command" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_Command);
					} else if ( _a=="Medical" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_Medical);
					} else if ( _a=="Research" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_Research);
					} else if ( _a=="Mining" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_Mining);
					} else if ( _a=="Maintenance" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_Maintenance);
					} else if ( _a=="External" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_External);
					} else if ( _a=="High Security" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_Highsecurity);
					}
				} else {
					this.airlock_type = typeof(Obj_Machinery_Door_Airlock);
				}
			} else if ( _c=="Glass" ) {
				
				if ( this.advanced_airlock_setting ) {
					airlockpaint2 = Interface13.Input( Task13.User, "Select the paintjob of the airlock.", null, null, new ByTable(new object [] { "Default", "Engineering", "Atmospherics", "Security", "Command", "Medical", "Research", "Mining" }), InputType.Any );

					dynamic _b = airlockpaint2; // Was a switch-case, sorry for the mess.
					if ( _b=="Default" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_Glass);
					} else if ( _b=="Engineering" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_GlassEngineering);
					} else if ( _b=="Atmospherics" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_GlassAtmos);
					} else if ( _b=="Security" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_GlassSecurity);
					} else if ( _b=="Command" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_GlassCommand);
					} else if ( _b=="Medical" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_GlassMedical);
					} else if ( _b=="Research" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_GlassResearch);
					} else if ( _b=="Mining" ) {
						this.airlock_type = typeof(Obj_Machinery_Door_Airlock_GlassMining);
					}
				} else {
					this.airlock_type = typeof(Obj_Machinery_Door_Airlock_Glass);
				}
			} else {
				this.airlock_type = typeof(Obj_Machinery_Door_Airlock);
			}
			return;
		}

		// Function from file: RCD.dm
		[Verb]
		[VerbInfo( name: "Change Airlock Access", group: "Object", access: VerbAccess.InUserContents, range: 127 )]
		public dynamic change_airlock_access(  ) {
			Mob H = null;
			string t1 = null;
			string accesses = null;
			double? i = null;
			double? i2 = null;
			dynamic A = null;
			Browser popup = null;

			
			if ( !( Task13.User is Mob_Living_Carbon_Human ) && !Task13.User.has_unlimited_silicon_privilege ) {
				return Lang13.SuperCall( Task13.User );
			}
			H = Task13.User;

			if ( Convert.ToDouble( ((dynamic)H).getBrainLoss() ) >= 60 ) {
				return null;
			}
			t1 = "";

			if ( this.use_one_access ) {
				t1 += new Txt( "Restriction Type: <a href='?src=" ).Ref( this ).str( ";access=one'>At least one access required</a><br>" ).ToString();
			} else {
				t1 += new Txt( "Restriction Type: <a href='?src=" ).Ref( this ).str( ";access=one'>All accesses required</a><br>" ).ToString();
			}
			t1 += new Txt( "<a href='?src=" ).Ref( this ).str( ";access=all'>Remove All</a><br>" ).ToString();
			accesses = "";
			accesses += "<div align='center'><b>Access</b></div>";
			accesses += "<table style='width:100%'>";
			accesses += "<tr>";
			i = null;
			i = 1;

			while (( i ??0) <= 7) {
				accesses += "<td style='width:14%'><b>" + GlobalFuncs.get_region_accesses_name( i ) + ":</b></td>";
				i++;
			}
			accesses += "</tr><tr>";
			i2 = null;
			i2 = 1;

			while (( i2 ??0) <= 7) {
				accesses += "<td style='width:14%' valign='top'>";

				foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_region_accesses( i2 ) )) {
					A = _a;
					

					if ( this.conf_access.Contains( A ) ) {
						accesses += new Txt( "<a href='?src=" ).Ref( this ).str( ";access=" ).item( A ).str( "'><font color=\"red\">" ).item( GlobalFuncs.replacetext( GlobalFuncs.get_access_desc( A ), " ", "&nbsp" ) ).str( "</font></a> " ).ToString();
					} else {
						accesses += new Txt( "<a href='?src=" ).Ref( this ).str( ";access=" ).item( A ).str( "'>" ).item( GlobalFuncs.replacetext( GlobalFuncs.get_access_desc( A ), " ", "&nbsp" ) ).str( "</a> " ).ToString();
					}
					accesses += "<br>";
				}
				accesses += "</td>";
				i2++;
			}
			accesses += "</tr></table>";
			t1 += "<tt>" + accesses + "</tt>";
			t1 += new Txt( "<p><a href='?src=" ).Ref( this ).str( ";close=1'>Close</a></p>\n" ).ToString();
			popup = new Browser( Task13.User, "airlock_electronics", "Access Control", 900, 500 );
			popup.set_content( t1 );
			popup.set_title_image( Task13.User.browse_rsc_icon( this.icon, this.icon_state ) );
			popup.open();
			GlobalFuncs.onclose( Task13.User, "airlock" );
			return null;
		}

	}

}