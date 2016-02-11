// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_SleepConsole : Obj_Machinery {

		public dynamic connected = null;
		public string orient = "LEFT";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/Cryogenic2.dmi";
			this.icon_state = "sleeperconsole";
		}

		// Function from file: Sleeper.dm
		public Obj_Machinery_SleepConsole ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 5, (Task13.Closure)(() => {
				this.update_icon();

				if ( this.orient == "RIGHT" ) {
					this.connected = Lang13.FindIn( typeof(Obj_Machinery_Sleeper), Map13.GetStep( this, ((int)( GlobalVars.EAST )) ) );
				} else {
					this.connected = Lang13.FindIn( typeof(Obj_Machinery_Sleeper), Map13.GetStep( this, ((int)( GlobalVars.WEST )) ) );
				}
				return;
			}));
			return;
		}

		// Function from file: Sleeper.dm
		public override dynamic power_change(  ) {
			return null;
		}

		// Function from file: Sleeper.dm
		public override dynamic process(  ) {
			
			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: Sleeper.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return 1;
			} else {
				Task13.User.set_machine( this );

				if ( Lang13.Bool( href_list["chemical"] ) ) {
					
					if ( Lang13.Bool( this.connected ) ) {
						
						if ( Lang13.Bool( this.connected.occupant ) ) {
							
							if ( Convert.ToInt32( this.connected.occupant.stat ) == 2 ) {
								GlobalFuncs.to_chat( Task13.User, "<span class='danger'>This person has no life for to preserve anymore. Take them to a department capable of reanimating them.</span>" );
							} else if ( href_list["chemical"] == "stoxin" && this.connected.sedativeblock != 0 ) {
								
								if ( this.connected.sedativeblock < 3 ) {
									GlobalFuncs.to_chat( Task13.User, "<span class='warning'>Sedative injections not yet ready. Please try again in a few seconds.</span>" );
								} else {
									GlobalFuncs.to_chat( Task13.User, "" + Rand13.Pick(new object [] { "<span class='warning'>This guy just got jammed into the machine, give them a breath before trying to pump them full of drugs.</span>", "<span class='warning'>Give it a rest.</span>", "<span class='warning'>Aren't you going to tuck them in before putting them to sleep?</span>", "<span class='warning'>Slow down just a second, they aren't going anywhere... right?</span>", "<span class='warning'>Just got to make sure you're not tripping the fuck out of an innocent bystander, stay tight.</span>", "<span class='warning'>The occupant is still moving around!</span>", "<span class='warning'>Sorry pal, safety procedures.</span>", "<span class='warning'>But it's not bedtime yet!</span>" }) );
								}
								this.connected.sedativeblock++;
							} else if ( Convert.ToDouble( this.connected.occupant.health ) < 0 && href_list["chemical"] != "inaprovaline" ) {
								GlobalFuncs.to_chat( Task13.User, "<span class='danger'>This person is not in good enough condition for sleepers to be effective! Use another means of treatment, such as cryogenics!</span>" );
							} else {
								((Obj_Machinery_Sleeper)this.connected).inject_chemical( Task13.User, href_list["chemical"], String13.ParseNumber( href_list["amount"] ) );
							}
						}
					}
				}

				if ( Lang13.Bool( href_list["refresh"] ) ) {
					this.updateUsrDialog();
				}
				this.add_fingerprint( Task13.User );
			}
			return null;
		}

		// Function from file: Sleeper.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Mob_Living occupant = null;
			string dat = null;
			string t1 = null;
			Mob_Living C = null;
			dynamic chemical = null;
			dynamic chemical2 = null;
			dynamic amount = null;

			
			if ( Lang13.Bool( base.attack_hand( (object)(a), (object)(b), (object)(c) ) ) ) {
				return null;
			}

			if ( Lang13.Bool( this.connected ) ) {
				occupant = this.connected.occupant;
				dat = "<font color='blue'><B>Occupant Statistics:</B></FONT><BR>";

				if ( occupant != null ) {
					
					switch ((int?)( occupant.stat )) {
						case 0:
							t1 = "Conscious";
							break;
						case 1:
							t1 = "<font color='blue'>Unconscious</font>";
							break;
						case 2:
							t1 = "<font color='red'>*dead*</font>";
							break;
					}
					dat += "" + ( Convert.ToDouble( occupant.health ) > 50 ? "<font color='blue'>" : "<font color='red'>" ) + "	Health %: " + occupant.health + " (" + t1 + ")</FONT><BR>";

					if ( occupant is Mob_Living_Carbon ) {
						C = occupant;
						dat += "" + ( Lang13.Bool( ((dynamic)C).pulse ) == false || Convert.ToInt32( ((dynamic)C).pulse ) == 6 ? "<font color='red'>" : "<font color='blue'>" ) + "	-Pulse, bpm: " + ((dynamic)C).get_pulse( 1 ) + "</FONT><BR>";
					}
					dat += "" + ( occupant.getBruteLoss() < 60 ? "<font color='blue'>" : "<font color='red'>" ) + "	-Brute Damage %: " + occupant.getBruteLoss() + "</FONT><BR>";
					dat += "" + ( Convert.ToDouble( occupant.getOxyLoss() ) < 60 ? "<font color='blue'>" : "<font color='red'>" ) + "	-Respiratory Damage %: " + occupant.getOxyLoss() + "</FONT><BR>";
					dat += "" + ( Convert.ToDouble( occupant.getToxLoss() ) < 60 ? "<font color='blue'>" : "<font color='red'>" ) + "	-Toxin Content %: " + occupant.getToxLoss() + "</FONT><BR>";
					dat += "" + ( occupant.getFireLoss() < 60 ? "<font color='blue'>" : "<font color='red'>" ) + "	-Burn Severity %: " + occupant.getFireLoss() + "</FONT><BR>";
					dat += "<HR>Paralysis Summary %: " + occupant.paralysis + " (" + Num13.Floor( occupant.paralysis / 4 ) + " seconds left!)<BR>";

					if ( Lang13.Bool( occupant.reagents ) ) {
						
						foreach (dynamic _b in Lang13.Enumerate( this.connected.available_options )) {
							chemical = _b;
							
							dat += "" + this.connected.available_options[chemical] + ": " + ((Reagents)occupant.reagents).get_reagent_amount( chemical ) + " units<br>";
						}
					}
					dat += new Txt( "<HR><A href='?src=" ).Ref( this ).str( ";refresh=1'>Refresh meter readings each second</A><BR>" ).ToString();

					foreach (dynamic _d in Lang13.Enumerate( this.connected.available_options )) {
						chemical2 = _d;
						
						dat += "Inject " + this.connected.available_options[chemical2] + ": ";

						foreach (dynamic _c in Lang13.Enumerate( this.connected.amounts )) {
							amount = _c;
							
							dat += new Txt( "<a href ='?src=" ).Ref( this ).str( ";chemical=" ).item( chemical2 ).str( ";amount=" ).item( amount ).str( "'>" ).item( amount ).str( " units</a> " ).ToString();
						}
						dat += "<br>";
					}
				} else {
					dat += "The sleeper is empty.";
				}
				dat += new Txt( "<BR><BR><A href='?src=" ).Ref( a ).str( ";mach_close=sleeper'>Close</A>" ).ToString();
				Interface13.Browse( a, dat, "window=sleeper;size=400x500" );
				GlobalFuncs.onclose( a, "sleeper" );
			}
			return null;
		}

		// Function from file: Sleeper.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: Sleeper.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.add_hiddenprint( user );
			return this.attack_hand( user );
		}

		// Function from file: Sleeper.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			this.icon_state = "sleeperconsole" + ( ( this.stat & 2 ) != 0 ? "-p" : null ) + ( this.orient == "LEFT" ? null : "-r" );
			return null;
		}

		// Function from file: Sleeper.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((int?)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					return false;
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.qdel( this );
						return false;
					}
					break;
			}
			return false;
		}

	}

}