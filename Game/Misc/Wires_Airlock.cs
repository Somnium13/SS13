// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Wires_Airlock : Wires {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.holder_type = typeof(Obj_Machinery_Door_Airlock);
			this.wire_count = 12;
			this.window_y = 570;
		}

		// Function from file: airlock.dm
		public Wires_Airlock ( Obj holder = null ) : base( holder ) {
			this.wire_names = new ByTable()
				.Set( "" + GlobalVars.AIRLOCK_WIRE_IDSCAN, "ID Scan" )
				.Set( "" + GlobalVars.AIRLOCK_WIRE_MAIN_POWER1, "Main Power 1" )
				.Set( "" + GlobalVars.AIRLOCK_WIRE_MAIN_POWER2, "Main Power 2" )
				.Set( "" + GlobalVars.AIRLOCK_WIRE_DOOR_BOLTS, "Bolts" )
				.Set( "" + GlobalVars.AIRLOCK_WIRE_BACKUP_POWER1, "Backup Power 1" )
				.Set( "" + GlobalVars.AIRLOCK_WIRE_BACKUP_POWER2, "Backup Power 2" )
				.Set( "" + GlobalVars.AIRLOCK_WIRE_OPEN_DOOR, "Open" )
				.Set( "" + GlobalVars.AIRLOCK_WIRE_AI_CONTROL, "AI Control" )
				.Set( "" + GlobalVars.AIRLOCK_WIRE_ELECTRIFY, "Electrify" )
				.Set( "" + GlobalVars.AIRLOCK_WIRE_SAFETY, "Safety" )
				.Set( "" + GlobalVars.AIRLOCK_WIRE_SPEED, "Speed" )
				.Set( "" + GlobalVars.AIRLOCK_WIRE_LIGHT, "Lights" )
			;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: airlock.dm
		public override void UpdatePulsed( double? index = null ) {
			Ent_Static A = null;
			dynamic M = null;
			dynamic M2 = null;

			A = this.holder;

			switch ((int?)( index )) {
				case 1:
					
					if ( Lang13.Bool( ((dynamic)A).arePowerSystemsOn() ) && !Lang13.Bool( ((dynamic)A).stat & 2 ) && A.density ) {
						((dynamic)A).door_animate( "deny" );
					}
					break;
				case 2:
				case 4:
					((dynamic)A).loseMainPower();
					break;
				case 8:
					
					if ( !Lang13.Bool( ((dynamic)A).locked ) ) {
						((dynamic)A).locked = 1;

						foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( A, 1 ) )) {
							M = _a;
							
							GlobalFuncs.to_chat( M, "You hear a click from the bottom of the door." );
						}
					} else if ( Lang13.Bool( ((dynamic)A).arePowerSystemsOn() ) ) {
						((dynamic)A).locked = 0;

						foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInRange( A, 1 ) )) {
							M2 = _b;
							
							GlobalFuncs.to_chat( M2, "You hear a click from the bottom of the door." );
						}
					}
					A.update_icon();
					break;
				case 16:
				case 32:
					((dynamic)A).loseBackupPower();
					break;
				case 128:
					
					if ( Lang13.Bool( ((dynamic)A).aiControlDisabled ) == false ) {
						((dynamic)A).aiControlDisabled = 1;
					} else if ( Convert.ToInt32( ((dynamic)A).aiControlDisabled ) == -1 ) {
						((dynamic)A).aiControlDisabled = 2;
					}
					Task13.Schedule( 10, (Task13.Closure)(() => {
						
						if ( A != null ) {
							
							if ( Lang13.Bool( ((dynamic)A).aiControlDisabled ) == true ) {
								((dynamic)A).aiControlDisabled = 0;
							} else if ( Convert.ToInt32( ((dynamic)A).aiControlDisabled ) == 2 ) {
								((dynamic)A).aiControlDisabled = -1;
							}
						}
						return;
					}));
					break;
				case 256:
					
					if ( Lang13.Bool( ((dynamic)A).secondsElectrified ) == false ) {
						((dynamic)A).shockedby += "[" + GlobalFuncs.time_stamp() + "]" + Task13.User + "(ckey:" + Task13.User.ckey + ")";
						GlobalFuncs.add_logs( Task13.User, A, "electrified", false, null, "at " + A.x + "," + A.y + "," + A.z );
						((dynamic)A).secondsElectrified = 30;
						Task13.Schedule( 10, (Task13.Closure)(() => {
							
							if ( A != null ) {
								
								while (Convert.ToDouble( ((dynamic)A).secondsElectrified ) > 0) {
									((dynamic)A).secondsElectrified -= 1;

									if ( Convert.ToDouble( ((dynamic)A).secondsElectrified ) < 0 ) {
										((dynamic)A).secondsElectrified = 0;
									}
									Task13.Sleep( 10 );
								}
							}
							return;
						}));
						return;
					}
					break;
				case 64:
					
					if ( !Lang13.Bool( ((dynamic)A).requiresID() ) || Lang13.Bool( ((dynamic)A).check_access( null ) ) ) {
						
						if ( A.density ) {
							((dynamic)A).open();
						} else {
							((Obj_Machinery_Door)A).close();
						}
					}
					break;
				case 512:
					((dynamic)A).safe = !Lang13.Bool( ((dynamic)A).safe );

					if ( !A.density ) {
						((Obj_Machinery_Door)A).close();
					}
					break;
				case 1024:
					((dynamic)A).normalspeed = !Lang13.Bool( ((dynamic)A).normalspeed );
					break;
				case 2048:
					((dynamic)A).lights = !Lang13.Bool( ((dynamic)A).lights );
					A.update_icon();
					break;
			}
			return;
		}

		// Function from file: airlock.dm
		public override void UpdateCut( double? index = null, bool mended = false ) {
			Ent_Static A = null;

			A = this.holder;

			switch ((int?)( index )) {
				case 2:
				case 4:
					
					if ( !mended ) {
						((dynamic)A).loseMainPower();
						((dynamic)A).shock( Task13.User, 50 );
					} else if ( !( this.IsIndexCut( GlobalVars.AIRLOCK_WIRE_MAIN_POWER1 ) != 0 ) && !( this.IsIndexCut( GlobalVars.AIRLOCK_WIRE_MAIN_POWER2 ) != 0 ) ) {
						((dynamic)A).regainMainPower();
						((dynamic)A).shock( Task13.User, 50 );
					}
					break;
				case 16:
				case 32:
					
					if ( !mended ) {
						((dynamic)A).loseBackupPower();
						((dynamic)A).shock( Task13.User, 50 );
					} else if ( !( this.IsIndexCut( GlobalVars.AIRLOCK_WIRE_BACKUP_POWER1 ) != 0 ) && !( this.IsIndexCut( GlobalVars.AIRLOCK_WIRE_BACKUP_POWER2 ) != 0 ) ) {
						((dynamic)A).regainBackupPower();
						((dynamic)A).shock( Task13.User, 50 );
					}
					break;
				case 8:
					
					if ( !mended ) {
						
						if ( Lang13.Bool( ((dynamic)A).locked ) != true ) {
							((dynamic)A).locked = 1;
						}
						A.update_icon();
					}
					break;
				case 128:
					
					if ( !mended ) {
						
						if ( Lang13.Bool( ((dynamic)A).aiControlDisabled ) == false ) {
							((dynamic)A).aiControlDisabled = 1;
						} else if ( Convert.ToInt32( ((dynamic)A).aiControlDisabled ) == -1 ) {
							((dynamic)A).aiControlDisabled = 2;
						}
					} else if ( Lang13.Bool( ((dynamic)A).aiControlDisabled ) == true ) {
						((dynamic)A).aiControlDisabled = 0;
					} else if ( Convert.ToInt32( ((dynamic)A).aiControlDisabled ) == 2 ) {
						((dynamic)A).aiControlDisabled = -1;
					}
					break;
				case 256:
					
					if ( !mended ) {
						
						if ( Convert.ToInt32( ((dynamic)A).secondsElectrified ) != -1 ) {
							((dynamic)A).shockedby += "[" + GlobalFuncs.time_stamp() + "]" + Task13.User + "(ckey:" + Task13.User.ckey + ")";
							GlobalFuncs.add_logs( Task13.User, A, "electrified", false, null, "at " + A.x + "," + A.y + "," + A.z );
							((dynamic)A).secondsElectrified = -1;
						}
					} else if ( Convert.ToInt32( ((dynamic)A).secondsElectrified ) == -1 ) {
						((dynamic)A).secondsElectrified = 0;
					}
					return;
					break;
				case 512:
					((dynamic)A).safe = mended;
					break;
				case 1024:
					((dynamic)A).autoclose = mended;

					if ( mended ) {
						
						if ( !A.density ) {
							((Obj_Machinery_Door)A).close();
						}
					}
					break;
				case 2048:
					((dynamic)A).lights = mended;
					A.update_icon();
					break;
			}
			return;
		}

		// Function from file: airlock.dm
		public override string GetInteractWindow(  ) {
			string _default = null;

			Ent_Static A = null;

			A = this.holder;
			_default += base.GetInteractWindow();
			_default += "<br>\n" + ( Lang13.Bool( ((dynamic)A).locked ) ? "The door bolts have fallen!" : "The door bolts look up." ) + "<br>\n" + ( Lang13.Bool( ((dynamic)A).lights ) ? "The door bolt lights are on." : "The door bolt lights are off!" ) + "<br>\n" + ( Lang13.Bool( ((dynamic)A).arePowerSystemsOn() ) && !Lang13.Bool( ((dynamic)A).stat & 2 ) ? "The test light is on." : "The test light is off!" ) + "<br>\n" + ( Lang13.Bool( ((dynamic)A).aiControlDisabled ) == false ? "The 'AI control allowed' light is on." : "The 'AI control allowed' light is off." ) + "<br>\n" + ( Lang13.Bool( ((dynamic)A).safe ) == false ? "The 'Check Wiring' light is on." : "The 'Check Wiring' light is off." ) + "<br>\n" + ( Lang13.Bool( ((dynamic)A).normalspeed ) == false ? "The 'Check Timing Mechanism' light is on." : "The 'Check Timing Mechanism' light is off." );
			return _default;
		}

		// Function from file: airlock.dm
		public override bool CanUse( dynamic L = null ) {
			Ent_Static A = null;

			A = this.holder;

			if ( !( L is Mob_Living_Silicon ) ) {
				
				if ( Lang13.Bool( ((dynamic)A).isElectrified() ) ) {
					
					if ( Lang13.Bool( ((dynamic)A).shock( L, 100 ) ) ) {
						return false;
					}
				}
			}

			if ( Lang13.Bool( ((dynamic)A).panel_open ) ) {
				return true;
			}
			return false;
		}

	}

}