// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Cartridge : Obj_Item_Weapon {

		public Obj_Item_Radio_Integrated radio = null;
		public bool access_security = false;
		public bool access_engine = false;
		public bool access_atmos = false;
		public bool access_mechanic = false;
		public bool access_medical = false;
		public bool access_manifest = true;
		public bool access_clown = false;
		public bool access_mime = false;
		public bool access_janitor = false;
		public bool access_reagent_scanner = false;
		public bool access_remote_door = false;
		public string remote_door_id = "";
		public bool access_status_display = false;
		public bool access_quartermaster = false;
		public bool access_hydroponics = false;
		public int mode = 0;
		public string menu = null;
		public dynamic active1 = null;
		public dynamic active2 = null;
		public dynamic active3 = null;
		public dynamic powmonitor = null;
		public ByTable powermonitors = new ByTable();
		public dynamic alertmonitor = null;
		public ByTable alertmonitors = new ByTable();
		public dynamic message1 = null;
		public dynamic message2 = null;
		public ByTable stored_data = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "electronic";
			this.origin_tech = "programming=2";
			this.w_class = 1;
			this.icon = "icons/obj/pda.dmi";
			this.icon_state = "cart";
		}

		public Obj_Item_Weapon_Cartridge ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: cart.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic R = null;
			dynamic M = null;
			Data_Record E = null;
			dynamic R2 = null;
			dynamic S = null;
			Data_Record E2 = null;
			dynamic new_frequency = null;
			double? pnum = null;
			double? pnum2 = null;

			base.Topic( href, href_list, (object)(hclient) );

			if ( !Task13.User.canmove || Lang13.Bool( Task13.User.stat ) || Task13.User.restrained() || !GlobalFuncs.in_range( this.loc, Task13.User ) ) {
				Task13.User.unset_machine();
				Interface13.Browse( Task13.User, null, "window=pda" );
				return null;
			}

			dynamic _d = href_list["choice"]; // Was a switch-case, sorry for the mess.
			if ( _d=="Medical Records" ) {
				R = Lang13.FindObj( href_list["target"] );
				M = Lang13.FindObj( href_list["target"] );
				((dynamic)this.loc).mode = 441;
				this.mode = 441;

				if ( GlobalVars.data_core.general.Contains( R ) ) {
					
					foreach (dynamic _a in Lang13.Enumerate( GlobalVars.data_core.medical, typeof(Data_Record) )) {
						E = _a;
						

						if ( E.fields["name"] == R.fields["name"] || E.fields["id"] == R.fields["id"] ) {
							M = E;
							break;
						}
					}
					this.active1 = R;
					this.active2 = M;
				}
			} else if ( _d=="Security Records" ) {
				R2 = Lang13.FindObj( href_list["target"] );
				S = Lang13.FindObj( href_list["target"] );
				((dynamic)this.loc).mode = 451;
				this.mode = 451;

				if ( GlobalVars.data_core.general.Contains( R2 ) ) {
					
					foreach (dynamic _b in Lang13.Enumerate( GlobalVars.data_core.security, typeof(Data_Record) )) {
						E2 = _b;
						

						if ( E2.fields["name"] == R2.fields["name"] || E2.fields["id"] == R2.fields["id"] ) {
							S = E2;
							break;
						}
					}
					this.active1 = R2;
					this.active3 = S;
				}
			} else if ( _d=="Send Signal" ) {
				Task13.Schedule( 0, (Task13.Closure)(() => {
					((Obj_Item_Radio_Integrated_Signal)this.radio).send_signal( "ACTIVATE" );
					return;
					return;
				}));
			} else if ( _d=="Signal Frequency" ) {
				new_frequency = GlobalFuncs.sanitize_frequency( ((dynamic)this.radio).frequency + String13.ParseNumber( href_list["sfreq"] ) );
				((Obj_Item_Radio_Integrated_Signal)this.radio).set_frequency( new_frequency );
			} else if ( _d=="Signal Code" ) {
				((dynamic)this.radio).code += String13.ParseNumber( href_list["scode"] );
				((dynamic)this.radio).code = Num13.Floor( Convert.ToDouble( ((dynamic)this.radio).code ) );
				((dynamic)this.radio).code = Num13.MinInt( 100, Convert.ToInt32( ((dynamic)this.radio).code ) );
				((dynamic)this.radio).code = Num13.MaxInt( 1, Convert.ToInt32( ((dynamic)this.radio).code ) );
			} else if ( _d=="Status" ) {
				
				dynamic _c = href_list["statdisp"]; // Was a switch-case, sorry for the mess.
				if ( _c=="message" ) {
					this.post_status( "message", this.message1, this.message2 );
				} else if ( _c=="alert" ) {
					this.post_status( "alert", href_list["alert"] );
				} else if ( _c=="setmsg1" ) {
					this.message1 = GlobalFuncs.reject_bad_text( GlobalFuncs.trim( String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Line 1", "Enter Message Text", this.message1, null, null, InputType.Str | InputType.Null ) ), 1, 40 ) ), 40 );
					this.updateSelfDialog();
				} else if ( _c=="setmsg2" ) {
					this.message2 = GlobalFuncs.reject_bad_text( GlobalFuncs.trim( String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Line 2", "Enter Message Text", this.message2, null, null, InputType.Str | InputType.Null ) ), 1, 40 ) ), 40 );
					this.updateSelfDialog();
				} else {
					this.post_status( href_list["statdisp"] );
				}
			} else if ( _d=="Power Select" ) {
				pnum = String13.ParseNumber( href_list["target"] );
				this.powmonitor = Lang13.FindObj( this.powermonitors[pnum] );

				if ( this.powmonitor is Obj_Machinery_Power_Monitor ) {
					((dynamic)this.loc).mode = 433;
					this.mode = 433;
				}
			} else if ( _d=="Alert Select" ) {
				pnum2 = String13.ParseNumber( href_list["target"] );
				this.alertmonitor = Lang13.FindObj( this.alertmonitors[pnum2] );

				if ( this.alertmonitor is Obj_Machinery_Computer_StationAlert ) {
					((dynamic)this.loc).mode = 533;
					this.mode = 533;
				}
			}
			this.generate_menu();
			this.print_to_host( this.menu );
			return null;
		}

		// Function from file: cart.dm
		public void generate_menu(  ) {
			int powercount = 0;
			bool found = false;
			Obj_Machinery_Power_Monitor pMon = null;
			dynamic T = null;
			ByTable L = null;
			Obj_Machinery_Power_Terminal term = null;
			Ent_Static A = null;
			ByTable S = null;
			ByTable chg = null;
			Obj_Machinery_Power_Apc A2 = null;
			int alertcount = 0;
			bool found2 = false;
			Obj_Machinery_Computer_StationAlert aMon = null;
			dynamic T2 = null;
			dynamic cat = null;
			ByTable L2 = null;
			dynamic alarm = null;
			dynamic alm = null;
			dynamic A3 = null;
			ByTable sources = null;
			Data_Record R = null;
			Data_Record R2 = null;
			Obj_Item_Radio_Integrated SC = null;
			Obj_Machinery_Bot B = null;
			dynamic S2 = null;
			dynamic SO = null;
			dynamic S3 = null;
			dynamic SO2 = null;
			Obj_Item_Radio_Integrated QC = null;
			Obj_Machinery_Bot_Mulebot B2 = null;
			dynamic C = null;
			dynamic cl = null;
			dynamic ldat = null;
			Obj_Item_Weapon_Mop M = null;
			dynamic ml = null;
			int direction = 0;
			Obj_Structure_Mopbucket B3 = null;
			dynamic bl = null;
			int direction2 = 0;
			Obj_Machinery_Bot_Cleanbot B4 = null;
			dynamic bl2 = null;
			int direction3 = 0;

			
			switch ((int)( this.mode )) {
				case 40:
					this.menu = "<h4><img src=pda_signaler.png> Remote Signaling System</h4>";
					this.menu += new Txt( "\n<a href='byond://?src=" ).Ref( this ).str( ";choice=Send Signal'>Send Signal</A><BR>\nFrequency:\n<a href='byond://?src=" ).Ref( this ).str( ";choice=Signal Frequency;sfreq=-10'>-</a>\n<a href='byond://?src=" ).Ref( this ).str( ";choice=Signal Frequency;sfreq=-2'>-</a>\n" ).item( GlobalFuncs.format_frequency( ((dynamic)this.radio).frequency ) ).str( "\n<a href='byond://?src=" ).Ref( this ).str( ";choice=Signal Frequency;sfreq=2'>+</a>\n<a href='byond://?src=" ).Ref( this ).str( ";choice=Signal Frequency;sfreq=10'>+</a><br>\n<br>\nCode:\n<a href='byond://?src=" ).Ref( this ).str( ";choice=Signal Code;scode=-5'>-</a>\n<a href='byond://?src=" ).Ref( this ).str( ";choice=Signal Code;scode=-1'>-</a>\n" ).item( ((dynamic)this.radio).code ).str( "\n<a href='byond://?src=" ).Ref( this ).str( ";choice=Signal Code;scode=1'>+</a>\n<a href='byond://?src=" ).Ref( this ).str( ";choice=Signal Code;scode=5'>+</a><br>" ).ToString();
					break;
				case 42:
					this.menu = new Txt( "<h4><img src=pda_status.png> Station Status Display Interlink</h4>\n				[ <A HREF='?src=" ).Ref( this ).str( ";choice=Status;statdisp=blank'>Clear</A> ]<BR>\n				[ <A HREF='?src=" ).Ref( this ).str( ";choice=Status;statdisp=shuttle'>Shuttle ETA</A> ]<BR>\n				[ <A HREF='?src=" ).Ref( this ).str( ";choice=Status;statdisp=message'>Message</A> ]\n				<ul><li> Line 1: <A HREF='?src=" ).Ref( this ).str( ";choice=Status;statdisp=setmsg1'>" ).item( ( Lang13.Bool( this.message1 ) ? this.message1 : ((dynamic)( "(none)" )) ) ).str( "</A>\n				<li> Line 2: <A HREF='?src=" ).Ref( this ).str( ";choice=Status;statdisp=setmsg2'>" ).item( ( Lang13.Bool( this.message2 ) ? this.message2 : ((dynamic)( "(none)" )) ) ).str( "</A></ul><br>\n				[ Alert: <A HREF='?src=" ).Ref( this ).str( ";choice=Status;statdisp=alert;alert=default'>None</A> |\n				<A HREF='?src=" ).Ref( this ).str( ";choice=Status;statdisp=alert;alert=redalert'>Red Alert</A> |\n				<A HREF='?src=" ).Ref( this ).str( ";choice=Status;statdisp=alert;alert=lockdown'>Lockdown</A> |\n				<A HREF='?src=" ).Ref( this ).str( ";choice=Status;statdisp=alert;alert=biohazard'>Biohazard</A> ]<BR>" ).ToString();
					break;
				case 43:
					this.menu = "<h4><img src=pda_power.png> Please select a Power Monitoring Computer</h4><BR>No Power Monitoring Computer detected in the vicinity.<BR>";
					powercount = 0;
					found = false;

					foreach (dynamic _a in Lang13.Enumerate( GlobalVars.power_machines, typeof(Obj_Machinery_Power_Monitor) )) {
						pMon = _a;
						

						if ( !( ( pMon.stat & 3 ) != 0 ) ) {
							T = GlobalFuncs.get_turf( this );

							if ( Convert.ToInt32( T.z ) == pMon.z ) {
								
								if ( !found ) {
									this.menu = "<h4><img src=pda_power.png> Please select a Power Monitoring Computer</h4><BR>";
									found = true;
									this.menu += "<FONT SIZE=-1>";
								}
								powercount++;
								this.menu += new Txt( "<a href='byond://?src=" ).Ref( this ).str( ";choice=Power Select;target=" ).item( powercount ).str( "'> " ).item( pMon ).str( " </a><BR>" ).ToString();
								this.powermonitors.Add( new Txt().Ref( pMon ).ToString() );
							}
						}
					}

					if ( found ) {
						this.menu += "</FONT>";
					}
					break;
				case 433:
					
					if ( !Lang13.Bool( this.powmonitor ) ) {
						this.menu = "<h4><img src=pda_power.png> Power Monitor </h4><BR>";
						this.menu += "No connection<BR>";
					} else {
						this.menu = "<h4><img src=pda_power.png> " + this.powmonitor + " </h4><BR>";
						L = new ByTable();

						foreach (dynamic _b in Lang13.Enumerate( this.powmonitor.powernet.nodes, typeof(Obj_Machinery_Power_Terminal) )) {
							term = _b;
							

							if ( term.master is Obj_Machinery_Power_Apc ) {
								A = term.master;
								L.Add( A );
							}
						}
						this.menu += "<PRE>Total power: " + this.powmonitor.powernet.avail + " W<BR>Total load:  " + String13.NumberToString( this.powmonitor.powernet.viewload, 10 ) + " W<BR>\n					<FONT SIZE=-1>";

						if ( L.len > 0 ) {
							this.menu += "Area                           Eqp./Lgt./Env.  Load   Cell<HR>";
							S = new ByTable(new object [] { " Off", "AOff", "  On", " AOn" });
							chg = new ByTable(new object [] { "N", "C", "F" });

							foreach (dynamic _c in Lang13.Enumerate( L, typeof(Obj_Machinery_Power_Apc) )) {
								A2 = _c;
								
								this.menu += String13.SubStr( GlobalFuncs.add_tspace( A2.areaMaster.name, 30 ), 1, 30 );
								this.menu += " " + S[( A2.equipment ??0) + 1] + " " + S[( A2.lighting ??0) + 1] + " " + S[( A2.environ ??0) + 1] + " " + GlobalFuncs.add_lspace( A2.lastused_total, 6 ) + "  " + ( Lang13.Bool( A2.cell ) ? "" + GlobalFuncs.add_lspace( Num13.Floor( ((Obj_Item_Weapon_Cell)A2.cell).percent() ), 3 ) + "% " + chg[A2.charging + 1] : "  N/C" ) + "<BR>";
							}
						}
						this.menu += "</FONT></PRE>";
					}
					break;
				case 53:
					this.menu = "<h4><img src=pda_alert.png> Please select an Alert Computer</h4><BR>No Alert Computer detected in the vicinity.<BR>";
					this.alertmonitor = null;
					this.alertmonitors = new ByTable();
					alertcount = 0;
					found2 = false;

					foreach (dynamic _d in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Computer_StationAlert) )) {
						aMon = _d;
						

						if ( !( ( aMon.stat & 3 ) != 0 ) ) {
							T2 = GlobalFuncs.get_turf( this );

							if ( Convert.ToInt32( T2.z ) == aMon.z ) {
								
								if ( !found2 ) {
									this.menu = "<h4><img src=pda_alert.png> Please select an Alert Computer</h4><BR>";
									found2 = true;
									this.menu += "<FONT SIZE=-1>";
								}
								alertcount++;
								this.menu += new Txt( "<a href='byond://?src=" ).Ref( this ).str( ";choice=Alert Select;target=" ).item( alertcount ).str( "'> " ).item( aMon ).str( " </a><BR>" ).ToString();
								this.alertmonitors.Add( new Txt().Ref( aMon ).ToString() );
							}
						}
					}

					if ( found2 ) {
						this.menu += "</FONT>";
					}
					break;
				case 533:
					
					if ( !Lang13.Bool( this.alertmonitor ) ) {
						this.menu = "<h4><img src=pda_alert.png> Alert Monitor </h4><BR>";
						this.menu += "No connection<BR>";
					} else {
						this.menu = "<h4><img src=pda_alert.png> " + this.alertmonitor + " </h4><BR>";

						foreach (dynamic _f in Lang13.Enumerate( this.alertmonitor.alarms )) {
							cat = _f;
							
							this.menu += "<B>" + cat + "</B><BR>\n";
							L2 = this.alertmonitor.alarms[cat];

							if ( L2.len != 0 ) {
								
								foreach (dynamic _e in Lang13.Enumerate( L2 )) {
									alarm = _e;
									
									alm = L2[alarm];
									A3 = alm[1];
									sources = alm[3];
									this.menu += "<NOBR>\n								&bull;\n								" + A3.name;

									if ( sources.len > 1 ) {
										this.menu += " - " + sources.len + " sources";
									}
									this.menu += "</NOBR><BR>\n";
								}
							} else {
								this.menu += "-- All Systems Nominal<BR>\n";
							}
							this.menu += "<BR>\n";
						}
						this.menu += "</FONT></PRE>";
					}
					break;
				case 44:
					this.menu = "<h4><img src=pda_medical.png> Medical Record List</h4>";

					if ( !( GlobalVars.data_core.general == null ) ) {
						
						foreach (dynamic _g in Lang13.Enumerate( GlobalFuncs.sortRecord( GlobalVars.data_core.general ), typeof(Data_Record) )) {
							R = _g;
							
							this.menu += new Txt( "<a href='byond://?src=" ).Ref( this ).str( ";choice=Medical Records;target=" ).Ref( R ).str( "'>" ).item( R.fields["id"] ).str( ": " ).item( R.fields["name"] ).str( "<br>" ).ToString();
						}
					}
					this.menu += "<br>";
					break;
				case 441:
					this.menu = "<h4><img src=pda_medical.png> Medical Record</h4>";

					if ( this.active1 is Data_Record && GlobalVars.data_core.general.Contains( this.active1 ) ) {
						this.menu += "Name: " + this.active1.fields["name"] + " ID: " + this.active1.fields["id"] + "<br>\n					Sex: " + this.active1.fields["sex"] + "<br>\n					Age: " + this.active1.fields["age"] + "<br>\n					Rank: " + this.active1.fields["rank"] + "<br>\n					Fingerprint: " + this.active1.fields["fingerprint"] + "<br>\n					Physical Status: " + this.active1.fields["p_stat"] + "<br>\n					Mental Status: " + this.active1.fields["m_stat"] + "<br>";
					} else {
						this.menu += "<b>Record Lost!</b><br>";
					}
					this.menu += "<br>\n				<h4><img src=pda_medical.png> Medical Data</h4>";

					if ( this.active2 is Data_Record && GlobalVars.data_core.medical.Contains( this.active2 ) ) {
						this.menu += "Blood Type: " + this.active2.fields["b_type"] + "<br><br>\n					Minor Disabilities: " + this.active2.fields["mi_dis"] + "<br>\n					Details: " + this.active2.fields["mi_dis_d"] + "<br><br>\n					Major Disabilities: " + this.active2.fields["ma_dis"] + "<br>\n					Details: " + this.active2.fields["ma_dis_d"] + "<br><br>\n					Allergies: " + this.active2.fields["alg"] + "<br>\n					Details: " + this.active2.fields["alg_d"] + "<br><br>\n					Current Diseases: " + this.active2.fields["cdi"] + "<br>\n					Details: " + this.active2.fields["cdi_d"] + "<br><br>\n					Important Notes: " + this.active2.fields["notes"] + "<br>";
					} else {
						this.menu += "<b>Record Lost!</b><br>";
					}
					this.menu += "<br>";
					break;
				case 45:
					this.menu = "<h4><img src=pda_cuffs.png> Security Record List</h4>";

					if ( !( GlobalVars.data_core.general == null ) ) {
						
						foreach (dynamic _h in Lang13.Enumerate( GlobalFuncs.sortRecord( GlobalVars.data_core.general ), typeof(Data_Record) )) {
							R2 = _h;
							
							this.menu += new Txt( "<a href='byond://?src=" ).Ref( this ).str( ";choice=Security Records;target=" ).Ref( R2 ).str( "'>" ).item( R2.fields["id"] ).str( ": " ).item( R2.fields["name"] ).str( "<br>" ).ToString();
						}
					}
					this.menu += "<br>";
					break;
				case 451:
					this.menu = "<h4><img src=pda_cuffs.png> Security Record</h4>";

					if ( this.active1 is Data_Record && GlobalVars.data_core.general.Contains( this.active1 ) ) {
						this.menu += "Name: " + this.active1.fields["name"] + " ID: " + this.active1.fields["id"] + "<br>\n					Sex: " + this.active1.fields["sex"] + "<br>\n					Age: " + this.active1.fields["age"] + "<br>\n					Rank: " + this.active1.fields["rank"] + "<br>\n					Fingerprint: " + this.active1.fields["fingerprint"] + "<br>\n					Physical Status: " + this.active1.fields["p_stat"] + "<br>\n					Mental Status: " + this.active1.fields["m_stat"] + "<br>";
					} else {
						this.menu += "<b>Record Lost!</b><br>";
					}
					this.menu += "<br>\n				<h4><img src=pda_cuffs.png> Security Data</h4>";

					if ( this.active3 is Data_Record && GlobalVars.data_core.security.Contains( this.active3 ) ) {
						this.menu += "Criminal Status: " + this.active3.fields["criminal"] + "<br>\n					Minor Crimes: " + this.active3.fields["mi_crim"] + "<br>\n					Details: " + this.active3.fields["mi_crim"] + "<br><br>\n					Major Crimes: " + this.active3.fields["ma_crim"] + "<br>\n					Details: " + this.active3.fields["ma_crim_d"] + "<br><br>\n					Important Notes:<br>\n					" + this.active3.fields["notes"];
					} else {
						this.menu += "<b>Record Lost!</b><br>";
					}
					this.menu += "<br>";
					break;
				case 46:
					SC = this.radio;

					if ( !( SC != null ) ) {
						this.menu = "Interlink Error - Please reinsert cartridge.";
						return;
					}
					this.menu = "<h4><img src=pda_cuffs.png> Securitron Interlink</h4>";

					if ( !Lang13.Bool( ((dynamic)SC).active ) ) {
						
						if ( !Lang13.Bool( ((dynamic)SC).botlist ) || Lang13.Bool( ((dynamic)SC).botlist ) && ((dynamic)SC).botlist.len == 0 ) {
							this.menu += "No bots found.<BR>";
						} else {
							
							foreach (dynamic _i in Lang13.Enumerate( ((dynamic)SC).botlist, typeof(Obj_Machinery_Bot) )) {
								B = _i;
								

								if ( B != null ) {
									this.menu += new Txt( "<A href='byond://?src=" ).Ref( SC ).str( ";op=control;bot=" ).Ref( B ).str( "'>" ).item( B ).str( " at " ).item( B.loc.loc ).str( "</A><BR>" ).ToString();
								}
							}
						}
						this.menu += new Txt( "<BR><A href='byond://?src=" ).Ref( SC ).str( ";op=scanbots'><img src=pda_scanner.png> Scan for active bots</A><BR>" ).ToString();
					} else {
						this.menu += new Txt( "<B>" ).item( ((dynamic)SC).active ).str( "</B><BR> Status: (<A href='byond://?src=" ).Ref( SC ).str( ";op=control;bot=" ).Ref( ((dynamic)SC).active ).str( "'><img src=pda_refresh.png><i>refresh</i></A>)<BR>" ).ToString();

						if ( !Lang13.Bool( ((dynamic)SC).botstatus ) ) {
							this.menu += "Waiting for response...<BR>";
						} else {
							this.menu += "Location: " + ((dynamic)SC).botstatus["loca"] + "<BR>\n						Mode: ";

							dynamic _j = ((dynamic)SC).botstatus["mode"]; // Was a switch-case, sorry for the mess.
							if ( _j==0 ) {
								this.menu += "Ready";
							} else if ( _j==1 ) {
								this.menu += "Apprehending target";
							} else if ( _j==2 || _j==3 ) {
								this.menu += "Arresting target";
							} else if ( _j==4 ) {
								this.menu += "Starting patrol";
							} else if ( _j==5 ) {
								this.menu += "On patrol";
							} else if ( _j==6 ) {
								this.menu += "Responding to summons";
							}
							this.menu += new Txt( "<BR>[<A href='byond://?src=" ).Ref( SC ).str( ";op=stop'>Stop Patrol</A>]\n						[<A href='byond://?src=" ).Ref( SC ).str( ";op=go'>Start Patrol</A>]\n						[<A href='byond://?src=" ).Ref( SC ).str( ";op=summon'>Summon Bot</A>]<BR>\n						<HR><A href='byond://?src=" ).Ref( SC ).str( ";op=botlist'><img src=pda_back.png>Return to bot list</A>" ).ToString();
						}
					}
					break;
				case 47:
					this.menu = "<h4><img src=pda_crate.png> Supply Record Interlink</h4>\n				<BR><B>Supply shuttle</B><BR>\n				Location: " + ( GlobalVars.supply_shuttle.moving != 0 ? "Moving to station (" + GlobalVars.supply_shuttle.eta + " Mins.)" : ( GlobalVars.supply_shuttle.at_station ? "Station" : "Dock" ) ) + "<BR>\n				Current approved orders: <BR><ol>";

					foreach (dynamic _k in Lang13.Enumerate( GlobalVars.supply_shuttle.shoppinglist )) {
						S2 = _k;
						
						SO = S2;
						this.menu += "<li>#" + SO.ordernum + " - " + SO.v_object.name + " approved by " + SO.orderedby + " " + ( Lang13.Bool( SO.comment ) ? "(" + SO.comment + ")" : "" ) + "</li>";
					}
					this.menu += "</ol>\n				Current requests: <BR><ol>";

					foreach (dynamic _l in Lang13.Enumerate( GlobalVars.supply_shuttle.requestlist )) {
						S3 = _l;
						
						SO2 = S3;
						this.menu += "<li>#" + SO2.ordernum + " - " + SO2.v_object.name + " requested by " + SO2.orderedby + "</li>";
					}
					this.menu += "</ol><font size=\"-3\">Upgrade NOW to Space Parts & Space Vendors PLUS for full remote order control and inventory management.";
					break;
				case 48:
					QC = this.radio;

					if ( !( QC != null ) ) {
						this.menu = "Interlink Error - Please reinsert cartridge.";
						return;
					}
					this.menu = "<h4><img src=pda_mule.png> M.U.L.E. bot Interlink V0.8</h4>";

					if ( !Lang13.Bool( ((dynamic)QC).active ) ) {
						
						if ( !Lang13.Bool( ((dynamic)QC).botlist ) || Lang13.Bool( ((dynamic)QC).botlist ) && ((dynamic)QC).botlist.len == 0 ) {
							this.menu += "No bots found.<BR>";
						} else {
							
							foreach (dynamic _m in Lang13.Enumerate( ((dynamic)QC).botlist, typeof(Obj_Machinery_Bot_Mulebot) )) {
								B2 = _m;
								
								this.menu += new Txt( "<A href='byond://?src=" ).Ref( QC ).str( ";op=control;bot=" ).Ref( B2 ).str( "'>" ).item( B2 ).str( " at " ).item( GlobalFuncs.get_area( B2 ) ).str( "</A><BR>" ).ToString();
							}
						}
						this.menu += new Txt( "<BR><A href='byond://?src=" ).Ref( QC ).str( ";op=scanbots'><img src=pda_scanner.png> Scan for active bots</A><BR>" ).ToString();
					} else {
						this.menu += new Txt( "<B>" ).item( ((dynamic)QC).active ).str( "</B><BR> Status: (<A href='byond://?src=" ).Ref( QC ).str( ";op=control;bot=" ).Ref( ((dynamic)QC).active ).str( "'><img src=pda_refresh.png><i>refresh</i></A>)<BR>" ).ToString();

						if ( !Lang13.Bool( ((dynamic)QC).botstatus ) ) {
							this.menu += "Waiting for response...<BR>";
						} else {
							this.menu += "Location: " + ((dynamic)QC).botstatus["loca"] + "<BR>\n						Mode: ";

							dynamic _n = ((dynamic)QC).botstatus["mode"]; // Was a switch-case, sorry for the mess.
							if ( _n==0 ) {
								this.menu += "Ready";
							} else if ( _n==1 ) {
								this.menu += "Loading/Unloading";
							} else if ( _n==2 ) {
								this.menu += "Navigating to Delivery Location";
							} else if ( _n==3 ) {
								this.menu += "Navigating to Home";
							} else if ( _n==4 ) {
								this.menu += "Waiting for clear path";
							} else if ( _n==5 || _n==6 ) {
								this.menu += "Calculating navigation path";
							} else if ( _n==7 ) {
								this.menu += "Unable to locate destination";
							}
							C = ((dynamic)QC).botstatus["load"];
							this.menu += new Txt( "<BR>Current Load: " ).item( ( !Lang13.Bool( C ) ? "<i>none</i>" : new Txt().item( C.name ).str( " (<A href='byond://?src=" ).Ref( QC ).str( ";op=unload'><i>unload</i></A>)" ).ToString() ) ).str( "<BR>\n						Destination: " ).item( ( !Lang13.Bool( ((dynamic)QC).botstatus["dest"] ) ? "<i>none</i>" : ((dynamic)QC).botstatus["dest"] ) ).str( " (<A href='byond://?src=" ).Ref( QC ).str( ";op=setdest'><i>set</i></A>)<BR>\n						Power: " ).item( ((dynamic)QC).botstatus["powr"] ).str( "%<BR>\n						Home: " ).item( ( !Lang13.Bool( ((dynamic)QC).botstatus["home"] ) ? "<i>none</i>" : ((dynamic)QC).botstatus["home"] ) ).str( "<BR>\n						Auto Return Home: " ).item( ( Lang13.Bool( ((dynamic)QC).botstatus["retn"] ) ? new Txt( "<B>On</B> <A href='byond://?src=" ).Ref( QC ).str( ";op=retoff'>Off</A>" ).ToString() : new Txt( "(<A href='byond://?src=" ).Ref( QC ).str( ";op=reton'><i>On</i></A>) <B>Off</B>" ).ToString() ) ).str( "<BR>\n						Auto Pickup Crate: " ).item( ( Lang13.Bool( ((dynamic)QC).botstatus["pick"] ) ? new Txt( "<B>On</B> <A href='byond://?src=" ).Ref( QC ).str( ";op=pickoff'>Off</A>" ).ToString() : new Txt( "(<A href='byond://?src=" ).Ref( QC ).str( ";op=pickon'><i>On</i></A>) <B>Off</B>" ).ToString() ) ).str( "<BR><BR>\n						[<A href='byond://?src=" ).Ref( QC ).str( ";op=stop'>Stop</A>]\n						[<A href='byond://?src=" ).Ref( QC ).str( ";op=go'>Proceed</A>]\n						[<A href='byond://?src=" ).Ref( QC ).str( ";op=home'>Return Home</A>]<BR>\n						<HR><A href='byond://?src=" ).Ref( QC ).str( ";op=botlist'><img src=pda_back.png>Return to bot list</A>" ).ToString();
						}
					}
					break;
				case 49:
					this.menu = "<h4><img src=pda_bucket.png> Persistent Custodial Object Locator</h4>";
					cl = GlobalFuncs.get_turf( this );

					if ( Lang13.Bool( cl ) ) {
						this.menu += "Current Orbital Location: <b>[" + ( cl.x - GlobalVars.WORLD_X_OFFSET[cl.z] ) + "," + ( cl.y - GlobalVars.WORLD_Y_OFFSET[cl.z] ) + "]</b>\n					<h4>Located Mops:</h4>";
						ldat = null;

						foreach (dynamic _o in Lang13.Enumerate( typeof(Game13), typeof(Obj_Item_Weapon_Mop) )) {
							M = _o;
							
							ml = GlobalFuncs.get_turf( M );

							if ( Lang13.Bool( ml ) ) {
								
								if ( ml.z != cl.z ) {
									continue;
								}
								direction = Map13.GetDistance( this, M );
								ldat += "Mop - <b>[" + ( ml.x - GlobalVars.WORLD_X_OFFSET[ml.z] ) + "," + ( ml.y - GlobalVars.WORLD_Y_OFFSET[ml.z] ) + " (" + String13.ToUpper( GlobalFuncs.dir2text( direction ) ) + ")]</b> - " + ( Lang13.Bool( M.reagents.total_volume ) ? "Wet" : "Dry" ) + "<br>";
							}
						}

						if ( !Lang13.Bool( ldat ) ) {
							this.menu += "None";
						} else {
							this.menu += "" + ldat;
						}
						this.menu += "<h4>Located Mop Buckets:</h4>";
						ldat = null;

						foreach (dynamic _p in Lang13.Enumerate( typeof(Game13), typeof(Obj_Structure_Mopbucket) )) {
							B3 = _p;
							
							bl = GlobalFuncs.get_turf( B3 );

							if ( Lang13.Bool( bl ) ) {
								
								if ( bl.z != cl.z ) {
									continue;
								}
								direction2 = Map13.GetDistance( this, B3 );
								ldat += "Bucket - <b>[" + ( bl.x - GlobalVars.WORLD_X_OFFSET[bl.z] ) + "," + ( bl.y - GlobalVars.WORLD_Y_OFFSET[bl.z] ) + " (" + String13.ToUpper( GlobalFuncs.dir2text( direction2 ) ) + ")]</b> - Water level: " + B3.reagents.total_volume + "/100<br>";
							}
						}

						if ( !Lang13.Bool( ldat ) ) {
							this.menu += "None";
						} else {
							this.menu += "" + ldat;
						}
						this.menu += "<h4>Located Cleanbots:</h4>";
						ldat = null;

						foreach (dynamic _q in Lang13.Enumerate( typeof(Game13), typeof(Obj_Machinery_Bot_Cleanbot) )) {
							B4 = _q;
							
							bl2 = GlobalFuncs.get_turf( B4 );

							if ( Lang13.Bool( bl2 ) ) {
								
								if ( bl2.z != cl.z ) {
									continue;
								}
								direction3 = Map13.GetDistance( this, B4 );
								ldat += "Cleanbot - <b>[" + ( bl2.x - GlobalVars.WORLD_X_OFFSET[bl2.z] ) + "," + ( bl2.y - GlobalVars.WORLD_Y_OFFSET[bl2.z] ) + " (" + String13.ToUpper( GlobalFuncs.dir2text( direction3 ) ) + ")]</b> - " + ( B4.on ? "Online" : "Offline" ) + "<br>";
							}
						}

						if ( !Lang13.Bool( ldat ) ) {
							this.menu += "None";
						} else {
							this.menu += "" + ldat;
						}
					} else {
						this.menu += "ERROR: Unable to determine current location.";
					}
					this.menu += new Txt( "<br><br><A href='byond://?src=" ).Ref( this ).str( ";choice=49'>Refresh GPS Locator</a>" ).ToString();
					break;
			}
			return;
		}

		// Function from file: cart.dm
		public void post_status( string command = null, dynamic data1 = null, dynamic data2 = null ) {
			dynamic frequency = null;
			Game_Data status_signal = null;
			Ent_Static PDA = null;
			string user = null;

			frequency = GlobalVars.radio_controller.return_frequency( 1435 );

			if ( !Lang13.Bool( frequency ) ) {
				return;
			}
			status_signal = GlobalFuncs.getFromPool( typeof(Signal) );
			((dynamic)status_signal).source = this;
			((dynamic)status_signal).transmission_method = 1;
			((dynamic)status_signal).data["command"] = command;

			switch ((string)( command )) {
				case "message":
					((dynamic)status_signal).data["msg1"] = data1;
					((dynamic)status_signal).data["msg2"] = data2;

					if ( this.loc != null ) {
						PDA = this.loc;
						user = PDA.fingerprintslast;

						if ( PDA.loc is Mob_Living ) {
							this.name = PDA.loc;
						}
						GlobalFuncs.log_admin( "STATUS: " + user + " set status screen with " + PDA + ". Message: " + data1 + " " + data2 );
						GlobalFuncs.message_admins( "STATUS: " + user + " set status screen with " + PDA + ". Message: " + data1 + " " + data2 );
					}
					break;
				case "alert":
					((dynamic)status_signal).data["picture_state"] = data1;
					break;
			}
			frequency.post_signal( this, status_signal );
			return;
		}

		// Function from file: cart.dm
		public void print_to_host( string text = null ) {
			Ent_Static pda_device = null;
			dynamic M = null;

			
			if ( !( this.loc is Obj_Item_Device_Pda ) ) {
				return;
			}
			pda_device = this.loc;
			((dynamic)pda_device).cart = text;

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( pda_device.loc, 1 ) )) {
				M = _a;
				

				if ( Lang13.Bool( M.client ) && M.machine == pda_device ) {
					((Obj_Item)pda_device).attack_self( M );
				}
			}
			return;
		}

		// Function from file: cart.dm
		public void unlock(  ) {
			
			if ( !( this.loc is Obj_Item_Device_Pda ) ) {
				return;
			}
			this.generate_menu();
			this.print_to_host( this.menu );
			return;
		}

	}

}