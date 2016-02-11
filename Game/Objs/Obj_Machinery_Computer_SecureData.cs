// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_SecureData : Obj_Machinery_Computer {

		public dynamic scan = null;
		public bool? authenticated = null;
		public dynamic rank = null;
		public int? screen = null;
		public dynamic active1 = null;
		public dynamic active2 = null;
		public dynamic a_id = null;
		public string temp = null;
		public bool? printing = null;
		public bool can_change_id = false;
		public ByTable Perp = null;
		public dynamic tempname = null;
		public string sortBy = "name";
		public dynamic order = 1;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_one_access = new ByTable(new object [] { 1, 4 });
			this.circuit = "/obj/item/weapon/circuitboard/secure_data";
			this.light_color = "#FA8282";
			this.icon_state = "security";
		}

		public Obj_Machinery_Computer_SecureData ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: security.dm
		public override dynamic emp_act( int severity = 0 ) {
			Data_Record R = null;

			
			if ( ( this.stat & 3 ) != 0 ) {
				base.emp_act( severity );
				return null;
			}

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.data_core.security, typeof(Data_Record) )) {
				R = _b;
				

				if ( Rand13.PercentChance( ((int)( 10 / severity )) ) ) {
					
					switch ((int)( Rand13.Int( 1, 6 ) )) {
						case 1:
							R.fields["name"] = "" + Rand13.Pick(new object [] { Rand13.PickFromTable( GlobalVars.first_names_male ), Rand13.PickFromTable( GlobalVars.first_names_female ) }) + " " + Rand13.PickFromTable( GlobalVars.last_names );
							break;
						case 2:
							R.fields["sex"] = Rand13.Pick(new object [] { "Male", "Female" });
							break;
						case 3:
							R.fields["age"] = Rand13.Int( 5, 85 );
							break;
						case 4:
							R.fields["criminal"] = Rand13.Pick(new object [] { "None", "*Arrest*", "Incarcerated", "Parolled", "Released" });
							break;
						case 5:
							R.fields["p_stat"] = Rand13.Pick(new object [] { "*Unconcious*", "Active", "Physically Unfit" });
							break;
						case 6:
							R.fields["m_stat"] = Rand13.Pick(new object [] { "*Insane*", "*Unstable*", "*Watch*", "Stable" });
							break;
					}
					continue;
				} else if ( Rand13.PercentChance( 1 ) ) {
					GlobalFuncs.qdel( R );
					R = null;
					continue;
				}
			}
			base.emp_act( severity );
			return null;
		}

		// Function from file: security.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic I = null;
			dynamic t1 = null;
			ByTable components = null;
			Data_Record R = null;
			string temptext = null;
			int? i = null;
			ByTable prelist = null;
			int? i2 = null;
			Data_Record E = null;
			dynamic R2 = null;
			dynamic R3 = null;
			dynamic S = null;
			Data_Record E2 = null;
			Obj_Item_Weapon_Paper P = null;
			int counter = 0;
			Data_Record R4 = null;
			dynamic a2 = null;
			string t12 = null;
			int counter2 = 0;
			Data_Record R5 = null;
			Data_Record G = null;
			dynamic a1 = null;
			dynamic a22 = null;
			string t13 = null;
			string t14 = null;
			string t15 = null;
			dynamic t16 = null;
			string t17 = null;
			string t18 = null;
			string t19 = null;
			string t110 = null;
			string t111 = null;
			ByTable L = null;
			dynamic rank = null;
			bool norange = false;
			string t112 = null;
			Data_Record R6 = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}

			if ( !( GlobalVars.data_core.general.Find( this.active1 ) != 0 ) ) {
				this.active1 = null;
			}

			if ( !( GlobalVars.data_core.security.Find( this.active2 ) != 0 ) ) {
				this.active2 = null;
			}

			if ( Task13.User.contents.Find( this ) != 0 || GlobalFuncs.in_range( this, Task13.User ) && this.loc is Tile || Task13.User is Mob_Living_Silicon ) {
				Task13.User.set_machine( this );

				dynamic _j = href_list["choice"]; // Was a switch-case, sorry for the mess.
				if ( _j=="Sorting" ) {
					
					if ( this.sortBy == href_list["sort"] ) {
						
						if ( this.order == 1 ) {
							this.order = -1;
						} else {
							this.order = 1;
						}
					} else {
						this.sortBy = href_list["sort"];
						this.order = Lang13.Initial( this, "order" );
					}
				} else if ( _j=="Clear Screen" ) {
					this.temp = null;
				} else if ( _j=="Return" ) {
					this.screen = 1;
					this.active1 = null;
					this.active2 = null;
				} else if ( _j=="Confirm Identity" ) {
					
					if ( Lang13.Bool( this.scan ) ) {
						
						if ( Task13.User is Mob_Living_Carbon_Human && !Lang13.Bool( Task13.User.get_active_hand() ) ) {
							Task13.User.put_in_hands( this.scan );
						} else {
							this.scan.loc = GlobalFuncs.get_turf( this );
						}
						this.scan = null;
					} else {
						I = Task13.User.get_active_hand();

						if ( I is Obj_Item_Weapon_Card_Id ) {
							
							if ( Task13.User.drop_item( I, this ) ) {
								this.scan = I;
							}
						}
					}
				} else if ( _j=="Log Out" ) {
					this.authenticated = null;
					this.screen = null;
					this.active1 = null;
					this.active2 = null;
				} else if ( _j=="Log In" ) {
					
					if ( Task13.User is Mob_Living_Silicon ) {
						this.active1 = null;
						this.active2 = null;
						this.authenticated = true;
						this.rank = "AI";
						this.screen = 1;
					} else if ( this.scan is Obj_Item_Weapon_Card_Id ) {
						this.active1 = null;
						this.active2 = null;

						if ( this.check_access( this.scan ) ) {
							this.authenticated = Lang13.BoolNullable( this.scan.registered_name );
							this.rank = this.scan.assignment;
							this.screen = 1;
						}
					}
				} else if ( _j=="Search Records" ) {
					t1 = Interface13.Input( "Search String: (Partial Name or ID or Fingerprints or Rank)", "Secure. records", null, null, null, InputType.Str );

					if ( !Lang13.Bool( t1 ) || Lang13.Bool( Task13.User.stat ) || !( this.authenticated == true ) || Task13.User.restrained() || !GlobalFuncs.in_range( this, Task13.User ) ) {
						return null;
					}
					this.Perp = new ByTable();
					t1 = String13.ToLower( t1 );
					components = GlobalFuncs.text2list( t1, " " );

					if ( components.len > 5 ) {
						return null;
					}

					foreach (dynamic _a in Lang13.Enumerate( GlobalVars.data_core.general, typeof(Data_Record) )) {
						R = _a;
						
						temptext = R.fields["name"] + " " + R.fields["id"] + " " + R.fields["fingerprint"] + " " + R.fields["rank"];
						i = null;
						i = 1;

						while (( i ??0) <= components.len) {
							
							if ( String13.FindIgnoreCase( temptext, components[i], 1, 0 ) != 0 ) {
								prelist = new ByTable( 2 );
								prelist[1] = R;
								this.Perp.Add( prelist );
							}
							i++;
						}
					}
					i2 = null;
					i2 = 1;

					while (( i2 ??0) <= this.Perp.len) {
						
						foreach (dynamic _b in Lang13.Enumerate( GlobalVars.data_core.security, typeof(Data_Record) )) {
							E = _b;
							
							R2 = this.Perp[i2];

							if ( E.fields["name"] == R2.fields["name"] && E.fields["id"] == R2.fields["id"] ) {
								this.Perp[( i2 ??0) + 1] = E;
							}
						}
						i2 += 2;
					}
					this.tempname = t1;
					this.screen = 4;
				} else if ( _j=="Record Maintenance" ) {
					this.screen = 2;
					this.active1 = null;
					this.active2 = null;
				} else if ( _j=="Browse Record" ) {
					R3 = Lang13.FindObj( href_list["d_rec"] );
					S = Lang13.FindObj( href_list["d_rec"] );

					if ( !( GlobalVars.data_core.general.Find( R3 ) != 0 ) ) {
						this.temp = "Record Not Found!";
					} else {
						
						foreach (dynamic _c in Lang13.Enumerate( GlobalVars.data_core.security, typeof(Data_Record) )) {
							E2 = _c;
							

							if ( E2.fields["name"] == R3.fields["name"] || E2.fields["id"] == R3.fields["id"] ) {
								S = E2;
							}
						}
						this.active1 = R3;
						this.active2 = S;
						this.screen = 3;
					}
				} else if ( _j=="Print Record" ) {
					
					if ( !( this.printing == true ) ) {
						this.printing = true;
						Task13.Sleep( 50 );
						P = new Obj_Item_Weapon_Paper( this.loc );
						P.info = "<CENTER><B>Security Record</B></CENTER><BR>";

						if ( this.active1 is Data_Record && GlobalVars.data_core.general.Find( this.active1 ) != 0 ) {
							P.info += "Name: " + this.active1.fields["name"] + " ID: " + this.active1.fields["id"] + "<BR>\nSex: " + this.active1.fields["sex"] + "<BR>\nAge: " + this.active1.fields["age"] + "<BR>\nFingerprint: " + this.active1.fields["fingerprint"] + "<BR>\nPhysical Status: " + this.active1.fields["p_stat"] + "<BR>\nMental Status: " + this.active1.fields["m_stat"] + "<BR>";
						} else {
							P.info += "<B>General Record Lost!</B><BR>";
						}

						if ( this.active2 is Data_Record && GlobalVars.data_core.security.Find( this.active2 ) != 0 ) {
							P.info += "<BR>\n<CENTER><B>Security Data</B></CENTER><BR>\nCriminal Status: " + this.active2.fields["criminal"] + "<BR>\n<BR>\nMinor Crimes: " + this.active2.fields["mi_crim"] + "<BR>\nDetails: " + this.active2.fields["mi_crim_d"] + "<BR>\n<BR>\nMajor Crimes: " + this.active2.fields["ma_crim"] + "<BR>\nDetails: " + this.active2.fields["ma_crim_d"] + "<BR>\n<BR>\nImportant Notes:<BR>\n	" + this.active2.fields["notes"] + "<BR>\n<BR>\n<CENTER><B>Comments/Log</B></CENTER><BR>";
							counter = 1;

							while (Lang13.Bool( this.active2.fields["com_" + counter] )) {
								P.info += "" + this.active2.fields["com_" + counter] + "<BR>";
								counter++;
							}
						} else {
							P.info += "<B>Security Record Lost!</B><BR>";
						}
						P.info += "</TT>";
						P.name = "paper - 'Security Record'";
						this.printing = null;
					}
				} else if ( _j=="Delete All Records" ) {
					this.temp = new Txt( "\n					Are you sure you wish to delete all Security records?<br>\n					<a href='?src=" ).Ref( this ).str( ";choice=Purge All Records'>Yes</a><br>\n					<a href='?src=" ).Ref( this ).str( ";choice=Clear Screen'>No</a>" ).ToString();
				} else if ( _j=="Purge All Records" ) {
					
					foreach (dynamic _d in Lang13.Enumerate( GlobalVars.data_core.security, typeof(Data_Record) )) {
						R4 = _d;
						
						GlobalFuncs.qdel( R4 );
						R4 = null;
					}
					this.temp = "All Security records deleted.";
				} else if ( _j=="Add Entry" ) {
					
					if ( !( this.active2 is Data_Record ) ) {
						return null;
					}
					a2 = this.active2;
					t12 = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Add Comment:", "Secure. records", null, null, null, InputType.StrMultiline ) ), 1, 1024 );

					if ( !Lang13.Bool( t12 ) || !( this.authenticated == true ) || Lang13.Bool( Task13.User.stat ) || Task13.User.restrained() || !GlobalFuncs.in_range( this, Task13.User ) && !( Task13.User is Mob_Living_Silicon ) || this.active2 != a2 ) {
						return null;
					}
					counter2 = 1;

					while (Lang13.Bool( this.active2.fields["com_" + counter2] )) {
						counter2++;
					}
					this.active2.fields["com_" + counter2] = "Made by " + this.authenticated + " (" + this.rank + ") on " + String13.FormatTime( Game13.realtime, "DDD MMM DD hh:mm:ss" ) + ", 2053<BR>" + t12;
				} else if ( _j=="Delete Record (ALL)" ) {
					
					if ( Lang13.Bool( this.active1 ) ) {
						this.temp = new Txt( "<h5>Are you sure you wish to delete the record (ALL)?</h5>\n						<a href='?src=" ).Ref( this ).str( ";choice=Delete Record (ALL) Execute'>Yes</a><br>\n						<a href='?src=" ).Ref( this ).str( ";choice=Clear Screen'>No</a>" ).ToString();
					}
				} else if ( _j=="Delete Record (Security)" ) {
					
					if ( Lang13.Bool( this.active2 ) ) {
						this.temp = new Txt( "<h5>Are you sure you wish to delete the record (Security Portion Only)?</h5>\n						<a href='?src=" ).Ref( this ).str( ";choice=Delete Record (Security) Execute'>Yes</a><br>\n						<a href='?src=" ).Ref( this ).str( ";choice=Clear Screen'>No</a>" ).ToString();
					}
				} else if ( _j=="Delete Entry" ) {
					
					if ( this.active2 is Data_Record && Lang13.Bool( this.active2.fields["com_" + href_list["del_c"]] ) ) {
						this.active2.fields["com_" + href_list["del_c"]] = "<B>Deleted</B>";
					}
				} else if ( _j=="New Record (Security)" ) {
					
					if ( this.active1 is Data_Record && !( this.active2 is Data_Record ) ) {
						R5 = new Data_Record();
						R5.fields["name"] = this.active1.fields["name"];
						R5.fields["id"] = this.active1.fields["id"];
						R5.name = "Security Record #" + R5.fields["id"];
						R5.fields["criminal"] = "None";
						R5.fields["mi_crim"] = "None";
						R5.fields["mi_crim_d"] = "No minor crime convictions.";
						R5.fields["ma_crim"] = "None";
						R5.fields["ma_crim_d"] = "No major crime convictions.";
						R5.fields["notes"] = "No notes.";
						GlobalVars.data_core.security.Add( R5 );
						this.active2 = R5;
						this.screen = 3;
					}
				} else if ( _j=="New Record (General)" ) {
					G = new Data_Record();
					G.fields["name"] = "New Record";
					G.fields["id"] = "" + GlobalFuncs.add_zero( GlobalFuncs.num2hex( Rand13.Int( 1, 16777215 ) ), 6 );
					G.fields["rank"] = "Unassigned";
					G.fields["real_rank"] = "Unassigned";
					G.fields["sex"] = "Male";
					G.fields["age"] = "Unknown";
					G.fields["fingerprint"] = "Unknown";
					G.fields["p_stat"] = "Active";
					G.fields["m_stat"] = "Stable";
					G.fields["species"] = "Human";
					GlobalVars.data_core.general.Add( G );
					this.active1 = G;
					this.active2 = null;
				} else if ( _j=="Edit Field" ) {
					a1 = this.active1;
					a22 = this.active2;

					dynamic _f = href_list["field"]; // Was a switch-case, sorry for the mess.
					if ( _f=="name" ) {
						
						if ( this.active1 is Data_Record ) {
							t13 = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Please input name:", "Secure. records", this.active1.fields["name"], null, null, InputType.Str ) ), 1, 1024 );

							if ( !Lang13.Bool( t13 ) || !( Lang13.Length( GlobalFuncs.trim( t13 ) ) != 0 ) || !( this.authenticated == true ) || Lang13.Bool( Task13.User.stat ) || Task13.User.restrained() || !GlobalFuncs.in_range( this, Task13.User ) && !( Task13.User is Mob_Living_Silicon ) || this.active1 != a1 ) {
								return null;
							}
							this.active1.fields["name"] = t13;
						}
					} else if ( _f=="id" ) {
						
						if ( this.active2 is Data_Record ) {
							t14 = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Please input id:", "Secure. records", this.active1.fields["id"], null, null, InputType.Str ) ), 1, 1024 );

							if ( !Lang13.Bool( t14 ) || !( this.authenticated == true ) || Lang13.Bool( Task13.User.stat ) || Task13.User.restrained() || !GlobalFuncs.in_range( this, Task13.User ) && !( Task13.User is Mob_Living_Silicon ) || this.active1 != a1 ) {
								return null;
							}
							this.active1.fields["id"] = t14;
						}
					} else if ( _f=="fingerprint" ) {
						
						if ( this.active1 is Data_Record ) {
							t15 = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Please input fingerprint hash:", "Secure. records", this.active1.fields["fingerprint"], null, null, InputType.Str ) ), 1, 1024 );

							if ( !Lang13.Bool( t15 ) || !( this.authenticated == true ) || Lang13.Bool( Task13.User.stat ) || Task13.User.restrained() || !GlobalFuncs.in_range( this, Task13.User ) && !( Task13.User is Mob_Living_Silicon ) || this.active1 != a1 ) {
								return null;
							}
							this.active1.fields["fingerprint"] = t15;
						}
					} else if ( _f=="sex" ) {
						
						if ( this.active1 is Data_Record ) {
							
							if ( this.active1.fields["sex"] == "Male" ) {
								this.active1.fields["sex"] = "Female";
							} else {
								this.active1.fields["sex"] = "Male";
							}
						}
					} else if ( _f=="age" ) {
						
						if ( this.active1 is Data_Record ) {
							t16 = Interface13.Input( "Please input age:", "Secure. records", this.active1.fields["age"], null, null, InputType.Num );

							if ( !Lang13.Bool( t16 ) || !( this.authenticated == true ) || Lang13.Bool( Task13.User.stat ) || Task13.User.restrained() || !GlobalFuncs.in_range( this, Task13.User ) && !( Task13.User is Mob_Living_Silicon ) || this.active1 != a1 ) {
								return null;
							}
							this.active1.fields["age"] = t16;
						}
					} else if ( _f=="mi_crim" ) {
						
						if ( this.active2 is Data_Record ) {
							t17 = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Please input minor crimes list:", "Secure. records", this.active2.fields["mi_crim"], null, null, InputType.Str ) ), 1, 1024 );

							if ( !Lang13.Bool( t17 ) || !( this.authenticated == true ) || Lang13.Bool( Task13.User.stat ) || Task13.User.restrained() || !GlobalFuncs.in_range( this, Task13.User ) && !( Task13.User is Mob_Living_Silicon ) || this.active2 != a22 ) {
								return null;
							}
							this.active2.fields["mi_crim"] = t17;
						}
					} else if ( _f=="mi_crim_d" ) {
						
						if ( this.active2 is Data_Record ) {
							t18 = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Please summarize minor crimes:", "Secure. records", this.active2.fields["mi_crim_d"], null, null, InputType.StrMultiline ) ), 1, 1024 );

							if ( !Lang13.Bool( t18 ) || !( this.authenticated == true ) || Lang13.Bool( Task13.User.stat ) || Task13.User.restrained() || !GlobalFuncs.in_range( this, Task13.User ) && !( Task13.User is Mob_Living_Silicon ) || this.active2 != a22 ) {
								return null;
							}
							this.active2.fields["mi_crim_d"] = t18;
						}
					} else if ( _f=="ma_crim" ) {
						
						if ( this.active2 is Data_Record ) {
							t19 = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Please input major crimes list:", "Secure. records", this.active2.fields["ma_crim"], null, null, InputType.Str ) ), 1, 1024 );

							if ( !Lang13.Bool( t19 ) || !( this.authenticated == true ) || Lang13.Bool( Task13.User.stat ) || Task13.User.restrained() || !GlobalFuncs.in_range( this, Task13.User ) && !( Task13.User is Mob_Living_Silicon ) || this.active2 != a22 ) {
								return null;
							}
							this.active2.fields["ma_crim"] = t19;
						}
					} else if ( _f=="ma_crim_d" ) {
						
						if ( this.active2 is Data_Record ) {
							t110 = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Please summarize major crimes:", "Secure. records", this.active2.fields["ma_crim_d"], null, null, InputType.StrMultiline ) ), 1, 1024 );

							if ( !Lang13.Bool( t110 ) || !( this.authenticated == true ) || Lang13.Bool( Task13.User.stat ) || Task13.User.restrained() || !GlobalFuncs.in_range( this, Task13.User ) && !( Task13.User is Mob_Living_Silicon ) || this.active2 != a22 ) {
								return null;
							}
							this.active2.fields["ma_crim_d"] = t110;
						}
					} else if ( _f=="notes" ) {
						
						if ( this.active2 is Data_Record ) {
							t111 = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Please summarize notes:", "Secure. records", this.active2.fields["notes"], null, null, InputType.StrMultiline ) ), 1, 1024 );

							if ( !Lang13.Bool( t111 ) || !( this.authenticated == true ) || Lang13.Bool( Task13.User.stat ) || Task13.User.restrained() || !GlobalFuncs.in_range( this, Task13.User ) && !( Task13.User is Mob_Living_Silicon ) || this.active2 != a22 ) {
								return null;
							}
							this.active2.fields["notes"] = t111;
						}
					} else if ( _f=="criminal" ) {
						
						if ( this.active2 is Data_Record ) {
							this.temp = new Txt( "<h5>Criminal Status:</h5>\n								<ul>\n								<li><a href='?src=" ).Ref( this ).str( ";choice=Change Criminal Status;criminal2=none'>None</a></li>\n								<li><a href='?src=" ).Ref( this ).str( ";choice=Change Criminal Status;criminal2=arrest'>*Arrest*</a></li>\n								<li><a href='?src=" ).Ref( this ).str( ";choice=Change Criminal Status;criminal2=incarcerated'>Incarcerated</a></li>\n								<li><a href='?src=" ).Ref( this ).str( ";choice=Change Criminal Status;criminal2=parolled'>Parolled</a></li>\n								<li><a href='?src=" ).Ref( this ).str( ";choice=Change Criminal Status;criminal2=released'>Released</a></li>\n								</ul>" ).ToString();
						}
					} else if ( _f=="rank" ) {
						L = new ByTable(new object [] { "Head of Personnel", "Captain", "AI" });

						if ( this.active1 is Data_Record && L.Find( this.rank ) != 0 ) {
							this.temp = "<h5>Rank:</h5>\n								<ul>";

							foreach (dynamic _e in Lang13.Enumerate( GlobalFuncs.get_all_jobs() )) {
								rank = _e;
								
								this.temp += new Txt( "<li><a href='?src=" ).Ref( this ).str( ";choice=Change Rank;rank=" ).item( rank ).str( "'>" ).item( rank ).str( "</a></li>" ).ToString();
							}
							this.temp += "</ul>";
						} else {
							Interface13.Alert( Task13.User, "You do not have the required rank to do this!" );
						}
					} else if ( _f=="species" ) {
						
						if ( this.active1 is Data_Record ) {
							norange = Task13.User.mutations != null && Task13.User.mutations.len != 0 && Task13.User.mutations.Contains( 1 );
							t112 = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Please enter race:", "General records", this.active1.fields["species"], null, null, InputType.StrMultiline ) ), 1, 1024 );

							if ( !Lang13.Bool( t112 ) || !( this.authenticated == true ) || Lang13.Bool( Task13.User.stat ) || Task13.User.restrained() || !GlobalFuncs.in_range( this, Task13.User ) && !( Task13.User is Mob_Living_Silicon ) && !norange || this.active1 != a1 ) {
								return null;
							}
							this.active1.fields["species"] = t112;
						}
					}
				} else {
					this.temp = null;

					dynamic _i = href_list["choice"]; // Was a switch-case, sorry for the mess.
					if ( _i=="Change Rank" ) {
						
						if ( Lang13.Bool( this.active1 ) ) {
							this.active1.fields["rank"] = href_list["rank"];

							if ( GlobalFuncs.get_all_jobs().Contains( href_list["rank"] ) ) {
								this.active1.fields["real_rank"] = href_list["real_rank"];
							}
						}
					} else if ( _i=="Change Criminal Status" ) {
						
						if ( Lang13.Bool( this.active2 ) ) {
							
							dynamic _g = href_list["criminal2"]; // Was a switch-case, sorry for the mess.
							if ( _g=="none" ) {
								this.active2.fields["criminal"] = "None";
							} else if ( _g=="arrest" ) {
								this.active2.fields["criminal"] = "*Arrest*";
							} else if ( _g=="incarcerated" ) {
								this.active2.fields["criminal"] = "Incarcerated";
							} else if ( _g=="parolled" ) {
								this.active2.fields["criminal"] = "Parolled";
							} else if ( _g=="released" ) {
								this.active2.fields["criminal"] = "Released";
							}
						}
					} else if ( _i=="Delete Record (Security) Execute" ) {
						
						if ( Lang13.Bool( this.active2 ) ) {
							GlobalFuncs.qdel( this.active2 );
							this.active2 = null;
						}
					} else if ( _i=="Delete Record (ALL) Execute" ) {
						
						if ( Lang13.Bool( this.active1 ) ) {
							
							foreach (dynamic _h in Lang13.Enumerate( GlobalVars.data_core.medical, typeof(Data_Record) )) {
								R6 = _h;
								

								if ( R6.fields["name"] == this.active1.fields["name"] || R6.fields["id"] == this.active1.fields["id"] ) {
									GlobalFuncs.qdel( R6 );
									R6 = null;
								}
							}
							GlobalFuncs.qdel( this.active1 );
							this.active1 = null;
						}

						if ( Lang13.Bool( this.active2 ) ) {
							GlobalFuncs.qdel( this.active2 );
							this.active2 = null;
						}
					} else {
						this.temp = "This function does not appear to be working at the moment. Our apologies.";
					}
				}
			}
			this.add_fingerprint( Task13.User );
			this.updateUsrDialog();
			return null;
		}

		// Function from file: security.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string dat = null;
			Data_Record R = null;
			string crimstat = null;
			Data_Record E = null;
			string background = null;
			Icon front = null;
			Icon side = null;
			int counter = 0;
			int? i = null;
			string crimstat2 = null;
			dynamic R2 = null;
			dynamic E2 = null;
			string background2 = null;

			
			if ( Lang13.Bool( base.attack_hand( (object)(a), (object)(b), (object)(c) ) ) ) {
				return null;
			}

			if ( this.z > 6 ) {
				GlobalFuncs.to_chat( a, "<span class='danger'>Unable to establish a connection: </span>You're too far away from the station!" );
				return null;
			}

			if ( Lang13.Bool( this.temp ) ) {
				dat = new Txt( "<TT>" ).item( this.temp ).str( "</TT><BR><BR><A href='?src=" ).Ref( this ).str( ";choice=Clear Screen'>Clear Screen</A>" ).ToString();
			} else {
				dat = new Txt( "Confirm Identity: <A href='?src=" ).Ref( this ).str( ";choice=Confirm Identity'>" ).item( ( Lang13.Bool( this.scan ) ? "" + this.scan.name : "----------" ) ).str( "</A><HR>" ).ToString();

				if ( this.authenticated == true ) {
					
					switch ((int?)( this.screen )) {
						case 1:
							dat += "\n<p style='text-align:center;'>";
							dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";choice=Search Records'>Search Records</A><BR>" ).ToString();
							dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";choice=New Record (General)'>New Record</A><BR>" ).ToString();
							dat += new Txt( @"
</p>
<table style=""text-align:center;"" cellspacing=""0"" width=""100%"">
<tr>
<th>Records:</th>
</tr>
</table>
<table style=""text-align:center;"" border=""1"" cellspacing=""0"" width=""100%"">
<tr>
<th><A href='?src=" ).Ref( this ).str( ";choice=Sorting;sort=name'>Name</A></th>\n<th><A href='?src=" ).Ref( this ).str( ";choice=Sorting;sort=id'>ID</A></th>\n<th><A href='?src=" ).Ref( this ).str( ";choice=Sorting;sort=rank'>Rank</A></th>\n<th><A href='?src=" ).Ref( this ).str( ";choice=Sorting;sort=fingerprint'>Fingerprints</A></th>\n<th>Criminal Status</th>\n</tr>" ).ToString();

							if ( !( GlobalVars.data_core.general == null ) ) {
								
								foreach (dynamic _c in Lang13.Enumerate( GlobalFuncs.sortRecord( GlobalVars.data_core.general, this.sortBy, this.order ), typeof(Data_Record) )) {
									R = _c;
									
									crimstat = "";

									foreach (dynamic _a in Lang13.Enumerate( GlobalVars.data_core.security, typeof(Data_Record) )) {
										E = _a;
										

										if ( E.fields["name"] == R.fields["name"] && E.fields["id"] == R.fields["id"] ) {
											crimstat = E.fields["criminal"];
										}
									}
									background = null;

									switch ((string)( crimstat )) {
										case "*Arrest*":
											background = "'background-color:#DC143C;'";
											break;
										case "Incarcerated":
											background = "'background-color:#CD853F;'";
											break;
										case "Parolled":
											background = "'background-color:#CD853F;'";
											break;
										case "Released":
											background = "'background-color:#3BB9FF;'";
											break;
										case "None":
											background = "'background-color:#00FF7F;'";
											break;
										case "":
											background = "'background-color:#FFFFFF;'";
											crimstat = "No Record.";
											break;
									}
									dat += new Txt( "<tr style=" ).item( background ).str( "><td><A href='?src=" ).Ref( this ).str( ";choice=Browse Record;d_rec=" ).Ref( R ).str( "'>" ).item( R.fields["name"] ).str( "</a></td>" ).ToString();
									dat += "<td>" + R.fields["id"] + "</td>";
									dat += "<td>" + R.fields["rank"] + "</td>";
									dat += "<td>" + R.fields["fingerprint"] + "</td>";
									dat += "<td>" + crimstat + "</td></tr>";
								}
								dat += "</table><hr width='75%' />";
							}
							dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";choice=Record Maintenance'>Record Maintenance</A><br><br>" ).ToString();
							dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";choice=Log Out'>{Log Out}</A>" ).ToString();
							break;
						case 2:
							dat += new Txt( "<B>Records Maintenance</B><HR>\n						<BR><A href='?src=" ).Ref( this ).str( ";choice=Delete All Records'>Delete All Records</A><BR><BR><A href='?src=" ).Ref( this ).str( ";choice=Return'>Back</A>" ).ToString();
							break;
						case 3:
							dat += "<CENTER><B>Security Record</B></CENTER><BR>";

							if ( this.active1 is Data_Record && GlobalVars.data_core.general.Find( this.active1 ) != 0 ) {
								front = new Icon( this.active1.fields["photo"], null, GlobalVars.SOUTH );
								side = new Icon( this.active1.fields["photo"], null, GlobalVars.WEST );
								Interface13.CacheBrowseResource( a, front, "front.png" );
								Interface13.CacheBrowseResource( a, side, "side.png" );
								dat += new Txt( "<table><tr><td>	Name: <A href='?src=" ).Ref( this ).str( ";choice=Edit Field;field=name'>" ).item( this.active1.fields["name"] ).str( "</A><BR> ID: <A href='?src=" ).Ref( this ).str( ";choice=Edit Field;field=id'>" ).item( this.active1.fields["id"] ).str( "</A><BR>\n	Sex: <A href='?src=" ).Ref( this ).str( ";choice=Edit Field;field=sex'>" ).item( this.active1.fields["sex"] ).str( "</A><BR>\n	Age: <A href='?src=" ).Ref( this ).str( ";choice=Edit Field;field=age'>" ).item( this.active1.fields["age"] ).str( "</A><BR>\n	Rank: <A href='?src=" ).Ref( this ).str( ";choice=Edit Field;field=rank'>" ).item( this.active1.fields["rank"] ).str( "</A><BR>\n	Fingerprint: <A href='?src=" ).Ref( this ).str( ";choice=Edit Field;field=fingerprint'>" ).item( this.active1.fields["fingerprint"] ).str( "</A><BR>\n	Physical Status: " ).item( this.active1.fields["p_stat"] ).str( "<BR>\n	Mental Status: " ).item( this.active1.fields["m_stat"] ).str( "<BR></td>	<td align = center valign = top>Photo:<br><img src=front.png height=80 width=80 border=4>	<img src=side.png height=80 width=80 border=4></td></tr></table>" ).ToString();
							} else {
								dat += "<B>General Record Lost!</B><BR>";
							}

							if ( this.active2 is Data_Record && GlobalVars.data_core.security.Find( this.active2 ) != 0 ) {
								dat += new Txt( "<BR>\n<CENTER><B>Security Data</B></CENTER><BR>\nCriminal Status: <A href='?src=" ).Ref( this ).str( ";choice=Edit Field;field=criminal'>" ).item( this.active2.fields["criminal"] ).str( "</A><BR>\n<BR>\nMinor Crimes: <A href='?src=" ).Ref( this ).str( ";choice=Edit Field;field=mi_crim'>" ).item( this.active2.fields["mi_crim"] ).str( "</A><BR>\nDetails: <A href='?src=" ).Ref( this ).str( ";choice=Edit Field;field=mi_crim_d'>" ).item( this.active2.fields["mi_crim_d"] ).str( "</A><BR>\n<BR>\nMajor Crimes: <A href='?src=" ).Ref( this ).str( ";choice=Edit Field;field=ma_crim'>" ).item( this.active2.fields["ma_crim"] ).str( "</A><BR>\nDetails: <A href='?src=" ).Ref( this ).str( ";choice=Edit Field;field=ma_crim_d'>" ).item( this.active2.fields["ma_crim_d"] ).str( "</A><BR>\n<BR>\nImportant Notes:<BR>\n	<A href='?src=" ).Ref( this ).str( ";choice=Edit Field;field=notes'>" ).item( this.active2.fields["notes"] ).str( "</A><BR>\n<BR>\n<CENTER><B>Comments/Log</B></CENTER><BR>" ).ToString();
								counter = 1;

								while (Lang13.Bool( this.active2.fields["com_" + counter] )) {
									dat += new Txt().item( this.active2.fields["com_" + counter] ).str( "<BR><A href='?src=" ).Ref( this ).str( ";choice=Delete Entry;del_c=" ).item( counter ).str( "'>Delete Entry</A><BR><BR>" ).ToString();
									counter++;
								}
								dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";choice=Add Entry'>Add Entry</A><BR><BR>" ).ToString();
								dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";choice=Delete Record (Security)'>Delete Record (Security Only)</A><BR><BR>" ).ToString();
							} else {
								dat += "<B>Security Record Lost!</B><BR>";
								dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";choice=New Record (Security)'>New Security Record</A><BR><BR>" ).ToString();
							}
							dat += new Txt( "\n<A href='?src=" ).Ref( this ).str( ";choice=Delete Record (ALL)'>Delete Record (ALL)</A><BR><BR>\n<A href='?src=" ).Ref( this ).str( ";choice=Print Record'>Print Record</A><BR>\n<A href='?src=" ).Ref( this ).str( ";choice=Return'>Back</A><BR>" ).ToString();
							break;
						case 4:
							
							if ( !( this.Perp.len != 0 ) ) {
								dat += new Txt( "ERROR.  String could not be located.<br><br><A href='?src=" ).Ref( this ).str( ";choice=Return'>Back</A>" ).ToString();
							} else {
								dat += "\n<table style=\"text-align:center;\" cellspacing=\"0\" width=\"100%\">\n<tr>					";
								dat += "<th>Search Results for '" + this.tempname + "':</th>";
								dat += @"
</tr>
</table>
<table style=""text-align:center;"" border=""1"" cellspacing=""0"" width=""100%"">
<tr>
<th>Name</th>
<th>ID</th>
<th>Rank</th>
<th>Fingerprints</th>
<th>Criminal Status</th>
</tr>					";
								i = null;
								i = 1;

								while (( i ??0) <= this.Perp.len) {
									crimstat2 = "";
									R2 = this.Perp[i];

									if ( this.Perp[( i ??0) + 1] is Data_Record ) {
										E2 = this.Perp[( i ??0) + 1];
										crimstat2 = E2.fields["criminal"];
									}
									background2 = null;

									switch ((string)( crimstat2 )) {
										case "*Arrest*":
											background2 = "'background-color:#DC143C;'";
											break;
										case "Incarcerated":
											background2 = "'background-color:#CD853F;'";
											break;
										case "Parolled":
											background2 = "'background-color:#CD853F;'";
											break;
										case "Released":
											background2 = "'background-color:#3BB9FF;'";
											break;
										case "None":
											background2 = "'background-color:#00FF7F;'";
											break;
										case "":
											background2 = "'background-color:#FFFFFF;'";
											crimstat2 = "No Record.";
											break;
									}
									dat += new Txt( "<tr style=" ).item( background2 ).str( "><td><A href='?src=" ).Ref( this ).str( ";choice=Browse Record;d_rec=" ).Ref( R2 ).str( "'>" ).item( R2.fields["name"] ).str( "</a></td>" ).ToString();
									dat += "<td>" + R2.fields["id"] + "</td>";
									dat += "<td>" + R2.fields["rank"] + "</td>";
									dat += "<td>" + R2.fields["fingerprint"] + "</td>";
									dat += "<td>" + crimstat2 + "</td></tr>";
									i += 2;
								}
								dat += "</table><hr width='75%' />";
								dat += new Txt( "<br><A href='?src=" ).Ref( this ).str( ";choice=Return'>Return to index.</A>" ).ToString();
							}
							break;
					}
				} else {
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";choice=Log In'>{Log In}</A>" ).ToString();
				}
			}
			Interface13.Browse( a, "<HEAD><TITLE>Security Records</TITLE></HEAD><TT>" + dat + "</TT>", "window=secure_rec;size=600x400" );
			GlobalFuncs.onclose( a, "secure_rec" );
			return null;
		}

		// Function from file: security.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: security.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.add_hiddenprint( user );
			return this.attack_hand( user );
		}

		// Function from file: security.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Card_Id && !Lang13.Bool( this.scan ) ) {
				
				if ( Task13.User.drop_item( a, this ) ) {
					this.scan = a;
					GlobalFuncs.to_chat( b, new Txt( "You insert " ).the( a ).item().str( "." ).ToString() );
				}
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

	}

}