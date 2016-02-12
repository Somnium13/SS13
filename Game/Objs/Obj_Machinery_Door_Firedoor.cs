// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Firedoor : Obj_Machinery_Door {

		public dynamic alert_overlays_local = null;
		public bool blocked = false;
		public bool lockdown = false;
		public bool pdiff_alert = false;
		public double pdiff = 0;
		public int? nextstate = null;
		public dynamic net_id = null;
		public ByTable areas_added = null;
		public ByTable users_to_open = null;
		public ByTable tile_info = new ByTable( 4 );
		public ByTable dir_alerts = new ByTable( 4 );
		public ByTable ALERT_STATES = new ByTable(new object [] { "hot", "cold" });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_one_access = new ByTable(new object [] { 24, 11 });
			this.base_layer = 2.5;
			this.icon = "icons/obj/doors/DoorHazard.dmi";
			this.icon_state = "door_open";
			this.layer = 2.5;
		}

		// Function from file: firedoor.dm
		public Obj_Machinery_Door_Firedoor ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic type_states = null;
			dynamic alert_state = null;
			ByTable starting = null;
			dynamic cdir = null;
			Obj_Machinery_Door_Firedoor F = null;
			dynamic A = null;
			dynamic direction = null;
			Tile T = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( !GlobalVars.alert_overlays_global.Contains( "" + this.type ) ) {
				GlobalVars.alert_overlays_global.Add( new ByTable().Set( "" + this.type, new ByTable().Set( "alert_hot", new ByTable() ).Set( "alert_cold", new ByTable() ) ) );
				type_states = GlobalVars.alert_overlays_global["" + this.type];

				foreach (dynamic _b in Lang13.Enumerate( type_states )) {
					alert_state = _b;
					
					starting = new ByTable();

					foreach (dynamic _a in Lang13.Enumerate( GlobalVars.cardinal )) {
						cdir = _a;
						
						starting["" + cdir] = new Icon( this.icon, alert_state, cdir );
					}
					type_states[alert_state] = starting;
				}
				GlobalVars.alert_overlays_global["" + this.type] = type_states;
				this.alert_overlays_local = type_states;
			} else {
				this.alert_overlays_local = GlobalVars.alert_overlays_global["" + this.type];
			}

			foreach (dynamic _c in Lang13.Enumerate( this.loc, typeof(Obj_Machinery_Door_Firedoor) )) {
				F = _c;
				

				if ( F != this ) {
					
					if ( Lang13.Bool( F.flags & 512 ) && Lang13.Bool( this.flags & 512 ) && F.dir != this.dir ) {
						continue;
					}
					Task13.Schedule( 1, (Task13.Closure)(() => {
						GlobalFuncs.qdel( this );
						return;
					}));
					//_default; return;
					return;
				}
			}
			A = GlobalFuncs.get_area( this );

			if ( !( A is Zone ) ) {
				Task13.Crash( "" + "code/game/machinery/doors/firedoor.dm" + ":" + 118 + ":Assertion Failed: " + "istype(A)" );
			}
			A.all_doors.Add( this );
			this.areas_added = new ByTable(new object [] { A });

			foreach (dynamic _d in Lang13.Enumerate( GlobalVars.cardinal )) {
				direction = _d;
				
				T = Map13.GetStep( this, Convert.ToInt32( direction ) );

				if ( T is Tile_Simulated_Floor ) {
					A = GlobalFuncs.get_area( Map13.GetStep( this, Convert.ToInt32( direction ) ) );

					if ( Lang13.Bool( A ) ) {
						A.all_doors.Or( this );
						this.areas_added.Or( A );
					}
				}
			}
			return;
		}

		// Function from file: firedoor.dm
		public override bool CanAStarPass( Ent_Dynamic ID = null, int to_dir = 0 ) {
			return !this.density;
		}

		// Function from file: firedoor.dm
		public override dynamic process(  ) {
			bool changed = false;
			ByTable old_alerts = null;
			int? index = null;
			dynamic tileinfo = null;
			int celsius = 0;
			int alerts = 0;

			base.process();

			if ( this.density ) {
				changed = false;
				this.lockdown = false;
				this.pdiff = GlobalFuncs.getOPressureDifferential( this.loc );

				if ( this.pdiff >= 25 ) {
					this.lockdown = true;

					if ( !this.pdiff_alert ) {
						this.pdiff_alert = true;
						changed = true;
					}
				} else if ( this.pdiff_alert ) {
					this.pdiff_alert = false;
					changed = true;
				}
				this.tile_info = GlobalFuncs.getCardinalAirInfo( this, this.loc, new ByTable(new object [] { "temperature", "pressure" }) );
				old_alerts = this.dir_alerts;
				index = null;
				index = 1;

				while (( index ??0) <= 4) {
					tileinfo = this.tile_info[index];

					if ( tileinfo == null ) {
						
					} else {
						celsius = Convert.ToInt32( GlobalFuncs.convert_k2c( tileinfo[1] ) );
						alerts = 0;

						if ( celsius >= 50 ) {
							alerts |= 1;
							this.lockdown = true;
						} else if ( celsius <= 0 ) {
							alerts |= 2;
							this.lockdown = true;
						}
						this.dir_alerts[index] = alerts;
					}
					index++;
				}

				if ( this.dir_alerts != old_alerts ) {
					changed = true;
				}

				if ( changed ) {
					this.update_icon();
				}
			}
			return null;
		}

		// Function from file: firedoor.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			int? d = null;
			dynamic cdir = null;
			int? i = null;
			dynamic state_list = null;

			this.overlays.len = 0;

			if ( this.density ) {
				this.icon_state = "door_closed";

				if ( this.blocked ) {
					this.overlays.Add( "welded" );
				}

				if ( this.pdiff_alert ) {
					this.overlays.Add( "palert" );
				}

				if ( this.dir_alerts != null ) {
					d = null;
					d = 1;

					while (( d ??0) <= 4) {
						cdir = GlobalVars.cardinal[d];
						i = null;
						i = 1;

						while (( i ??0) <= this.ALERT_STATES.len) {
							
							if ( Lang13.Bool( this.dir_alerts[d] & 1 << ( i ??0) - 1 ) ) {
								state_list = this.alert_overlays_local["alert_" + this.ALERT_STATES[i]];

								if ( Lang13.Bool( this.flags & 512 ) ) {
									this.overlays.Add( Num13.Rotate( state_list["" + Num13.Rotate( cdir, GlobalFuncs.dir2angle( this.dir ) ??0 )], GlobalFuncs.dir2angle( this.dir ) ??0 ) );
								} else {
									this.overlays.Add( state_list["" + cdir] );
								}
							}
							i++;
						}
						d++;
					}
				}
			} else {
				this.icon_state = "door_open";

				if ( this.blocked ) {
					this.overlays.Add( "welded_open" );
				}
			}
			return null;
		}

		// Function from file: firedoor.dm
		public override void door_animate( string animation = null ) {
			
			switch ((string)( animation )) {
				case "opening":
					Icon13.Flick( "door_opening", this );
					break;
				case "closing":
					Icon13.Flick( "door_closing", this );
					break;
			}
			return;
		}

		// Function from file: firedoor.dm
		public override bool close( bool? surpress_send = null ) {
			
			if ( this.blocked || !( this.loc != null ) ) {
				return false;
			}
			base.close( surpress_send );
			this.latetoggle();
			this.layer = this.base_layer + 0.8;
			return false;
		}

		// Function from file: firedoor.dm
		public void latetoggle(  ) {
			
			if ( this.operating != 0 || ( this.stat & 2 ) != 0 || !Lang13.Bool( this.nextstate ) ) {
				return;
			}

			switch ((int?)( this.nextstate )) {
				case 1:
					this.nextstate = null;
					this.open();
					break;
				case 2:
					this.nextstate = null;
					this.close();
					break;
			}
			return;
		}

		// Function from file: firedoor.dm
		public void force_open( dynamic user = null, dynamic C = null ) {
			dynamic A = null;
			bool alarmed = false;

			A = GlobalFuncs.get_area_master( this );

			if ( !( A is Zone ) ) {
				Task13.Crash( "" + "code/game/machinery/doors/firedoor.dm" + ":" + 330 + ":Assertion Failed: " + "istype(A)" );
			}
			alarmed = A.doors_down || Lang13.Bool( A.fire );

			if ( this.blocked ) {
				((Ent_Static)user).visible_message( new Txt( "<span class='attack'>" ).The( ( user.loc is Obj_Mecha ? "" + user.loc.name : "" + user ) ).item().str( " pries at " ).the( this ).item().str( " with " ).a( C ).item().str( ", but " ).the( this ).item().str( " is welded in place!</span>" ).ToString(), new Txt( "You try to pry " ).the( this ).item().str( " " ).item( ( this.density ? "open" : "closed" ) ).str( ", but it is welded in place!" ).ToString(), "You hear someone struggle and metal straining." );
				return;
			}
			((Ent_Static)user).visible_message( new Txt( "<span class='attack'>" ).The( ( user.loc is Obj_Mecha ? "" + user.loc.name : "" + user ) ).item().str( " forces " ).the( this ).item().str( " " ).item( ( this.density ? "open" : "closed" ) ).str( " with " ).a( C ).item().str( "!</span>" ).ToString(), new Txt( "You force " ).the( this ).item().str( " " ).item( ( this.density ? "open" : "closed" ) ).str( " with " ).the( C ).item().str( "!" ).ToString(), "You hear metal strain, and a door " + ( this.density ? "open" : "close" ) + "." );

			if ( this.density ) {
				Task13.Schedule( 0, (Task13.Closure)(() => {
					this.open();
					return;
				}));
			} else {
				Task13.Schedule( 0, (Task13.Closure)(() => {
					this.close();
					return;
				}));
			}
			GlobalVars.admin_diary.WriteMsg( "" + user + "/(" + user.ckey + ") " + ( this.density ? "closed the open" : "opened the closed" ) + " " + ( alarmed ? "and alarming" : "" ) + " firelock at " + GlobalFuncs.formatJumpTo( GlobalFuncs.get_turf( this ) ) );
			return;
		}

		// Function from file: firedoor.dm
		public override bool open( int? surpress_send = null ) {
			dynamic A = null;
			bool alarmed = false;

			
			if ( !( this.loc != null ) || this.blocked ) {
				return false;
			}
			base.open( surpress_send );
			this.latetoggle();
			this.layer = this.base_layer;
			A = GlobalFuncs.get_area_master( this );

			if ( !( A is Zone ) ) {
				Task13.Crash( "" + "code/game/machinery/doors/firedoor.dm" + ":" + 323 + ":Assertion Failed: " + "istype(A)" );
			}
			alarmed = A.doors_down || Lang13.Bool( A.fire );

			if ( alarmed ) {
				Task13.Schedule( 50, (Task13.Closure)(() => {
					this.close();
					return;
				}));
			}
			return false;
		}

		// Function from file: firedoor.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic W = null;
			dynamic A = null;
			bool alarmed = false;
			bool access_granted = false;
			string users_name = null;
			dynamic ID = null;
			dynamic pda = null;
			string answer = null;
			bool needs_to_close = false;

			this.add_fingerprint( b );

			if ( this.operating != 0 ) {
				return null;
			}

			if ( a is Obj_Item_Weapon_Weldingtool ) {
				W = a;

				if ( Lang13.Bool( W.remove_fuel( 0, b ) ) ) {
					this.blocked = !this.blocked;
					((Ent_Static)b).visible_message( new Txt( "<span class='attack'>" ).The( b ).item().str( " " ).item( ( this.blocked ? "welds" : "unwelds" ) ).str( " " ).the( this ).item().str( " with " ).a( W ).item().str( ".</span>" ).ToString(), new Txt( "You " ).item( ( this.blocked ? "weld" : "unweld" ) ).str( " " ).the( this ).item().str( " with " ).the( W ).item().str( "." ).ToString(), "You hear something being welded." );
					this.update_icon();
					return null;
				}
			}

			if ( a is Obj_Item_Weapon_Crowbar || a is Obj_Item_Weapon_Fireaxe && Lang13.Bool( a.wielded ) ) {
				this.force_open( b, a );
				return null;
			}

			if ( this.blocked ) {
				GlobalFuncs.to_chat( b, new Txt( "<span class='warning'>" ).The( this ).item().str( " is welded solid!</span>" ).ToString() );
				return null;
			}
			A = GlobalFuncs.get_area_master( this );

			if ( !( A is Zone ) ) {
				Task13.Crash( "" + "code/game/machinery/doors/firedoor.dm" + ":" + 244 + ":Assertion Failed: " + "istype(A)" );
			}
			alarmed = A.doors_down || Lang13.Bool( A.fire );
			access_granted = false;

			if ( !( a is Obj ) ) {
				
				if ( this.allowed( b ) ) {
					access_granted = true;
				}

				if ( b is Mob_Living_Carbon_Human ) {
					users_name = GlobalFuncs.FindNameFromID( b );
				} else {
					users_name = "Unknown";
				}
			}

			if ( b is Mob_Living_Carbon_Human && !( this.stat != 0 ) && ( a is Obj_Item_Weapon_Card_Id || a is Obj_Item_Device_Pda ) ) {
				ID = a;

				if ( a is Obj_Item_Device_Pda ) {
					pda = a;
					ID = pda.id;
				}

				if ( !( ID is Obj_Item_Weapon_Card_Id ) ) {
					ID = null;
				}

				if ( Lang13.Bool( ID ) ) {
					users_name = ID.registered_name;
				}

				if ( this.check_access( ID ) ) {
					access_granted = true;
				}
			}
			answer = "Yes";

			if ( answer == "No" ) {
				return null;
			}

			if ( Lang13.Bool( b.locked_to ) ) {
				
				if ( !( b.locked_to is Obj_Structure_Bed_Chair_Vehicle ) ) {
					GlobalFuncs.to_chat( b, new Txt( "Sorry, you must remain able bodied and close to " ).the( this ).item().str( " in order to use it." ).ToString() );
					return null;
				}
			}

			if ( Lang13.Bool( b.stat ) || Lang13.Bool( b.stunned ) || b.weakened != 0 || b.paralysis != 0 || Map13.GetDistance( this, b ) > 1 ) {
				GlobalFuncs.to_chat( b, new Txt( "Sorry, you must remain able bodied and close to " ).the( this ).item().str( " in order to use it." ).ToString() );
				return null;
			}

			if ( alarmed && this.density && this.lockdown && !access_granted ) {
				GlobalFuncs.to_chat( b, "<span class='warning'>Access denied. Please wait for authorities to arrive, or for the alert to clear.</span>" );
				return null;
			} else {
				((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).The( this ).item().str( " " ).item( ( this.density ? "open" : "close" ) ).str( "s for " ).the( b ).item().str( ".</span>" ).ToString(), new Txt().The( this ).item().str( " " ).item( ( this.density ? "open" : "close" ) ).str( "s." ).ToString(), "You hear a beep, and a door opening." );

				if ( !( this.users_to_open != null ) ) {
					this.users_to_open = new ByTable();
				}
				this.users_to_open.Add( users_name );
			}
			needs_to_close = false;

			if ( this.density ) {
				
				if ( alarmed ) {
					needs_to_close = true;
				}
				Task13.Schedule( 0, (Task13.Closure)(() => {
					this.open();
					return;
				}));
			} else {
				Task13.Schedule( 0, (Task13.Closure)(() => {
					this.close();
					return;
				}));
			}
			GlobalVars.admin_diary.WriteMsg( "" + b + "/(" + b.ckey + ") " + ( this.density ? "closed the open" : "opened the closed" ) + " " + ( alarmed ? "and alarming" : "" ) + " firelock at " + GlobalFuncs.formatJumpTo( GlobalFuncs.get_turf( this ) ) );

			if ( needs_to_close ) {
				Task13.Schedule( 50, (Task13.Closure)(() => {
					
					if ( alarmed && !this.density ) {
						this.close();
					}
					return;
				}));
			}
			return null;
		}

		// Function from file: firedoor.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return this.attackby( null, a );
		}

		// Function from file: firedoor.dm
		public override dynamic attack_ai( dynamic user = null ) {
			dynamic A = null;
			bool alarmed = false;
			bool old_density = false;

			
			if ( user is Mob_Dead_Observer || Lang13.Bool( user.stat ) ) {
				return null;
			}
			Task13.Schedule( 0, (Task13.Closure)(() => {
				A = GlobalFuncs.get_area_master( this );

				if ( !( A is Zone ) ) {
					Task13.Crash( "" + "code/game/machinery/doors/firedoor.dm" + ":" + 206 + ":Assertion Failed: " + "istype(A)" );
				}
				alarmed = A.doors_down || Lang13.Bool( A.fire );
				old_density = this.density;

				if ( old_density && Interface13.Alert( new Txt( "Override the " ).item( ( alarmed ? "alarming " : "" ) ).str( "firelock safeties and open " ).the( this ).item().str( "?" ).ToString(), null, "Yes", "No" ) == "Yes" ) {
					this.open();
				} else if ( !old_density ) {
					this.close();
				} else {
					return;
				}
				GlobalVars.admin_diary.WriteMsg( "" + user + "/(" + user.ckey + ") " + ( this.density ? "closed the open" : "opened the closed" ) + " " + ( alarmed ? "and alarming" : "" ) + " firelock at " + GlobalFuncs.formatJumpTo( GlobalFuncs.get_turf( this ) ) );
				GlobalFuncs.message_admins( "" + user + "/(" + user.ckey + ") " + ( this.density ? "closed the open" : "opened the closed" ) + " " + ( alarmed ? "and alarming" : "" ) + " firelock at " + GlobalFuncs.formatJumpTo( GlobalFuncs.get_turf( this ) ) );
				return;
			}));
			return null;
		}

		// Function from file: firedoor.dm
		public override dynamic power_change(  ) {
			
			if ( Lang13.Bool( this.powered( 3 ) ) ) {
				this.stat &= 65533;
				this.latetoggle();
			} else {
				this.stat |= 2;
			}
			return null;
		}

		// Function from file: firedoor.dm
		public override bool Bumped( Ent_Static AM = null, dynamic yes = null ) {
			Ent_Static mecha = null;
			Ent_Static M = null;

			
			if ( this.panel_open || this.operating != 0 ) {
				return false;
			}

			if ( !this.density ) {
				return base.Bumped( AM, (object)(yes) );
			}

			if ( AM is Obj_Mecha ) {
				mecha = AM;

				if ( Lang13.Bool( ((dynamic)mecha).occupant ) ) {
					M = ((dynamic)mecha).occupant;

					if ( Game13.time - M.last_bumped <= 10 ) {
						return false;
					}
					M.last_bumped = Game13.time;
					this.attack_hand( M );
				}
			}
			return false;
		}

		// Function from file: firedoor.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			dynamic _default = null;

			int? index = null;
			string o = null;
			dynamic celsius = null;
			dynamic pressure = null;
			dynamic users_to_open_string = null;
			double i = 0;

			_default = base.examine( (object)(user), size );

			if ( this.pdiff >= 25 ) {
				GlobalFuncs.to_chat( user, "<span class='danger'>WARNING: Current pressure differential is " + this.pdiff + "kPa! Opening door may result in injury!</span>" );
			}
			GlobalFuncs.to_chat( user, "<b>Sensor readings:</b>" );
			index = null;
			index = 1;

			while (( index ??0) <= this.tile_info.len) {
				o = "&nbsp;&nbsp;";

				switch ((int?)( index )) {
					case 1:
						o += "NORTH: ";
						break;
					case 2:
						o += "SOUTH: ";
						break;
					case 3:
						o += "EAST: ";
						break;
					case 4:
						o += "WEST: ";
						break;
				}

				if ( this.tile_info[index] == null ) {
					o += "<span class='warning'>DATA UNAVAILABLE</span>";
					GlobalFuncs.to_chat( Task13.User, o );
				} else {
					celsius = GlobalFuncs.convert_k2c( this.tile_info[index][1] );
					pressure = this.tile_info[index][2];

					if ( Lang13.Bool( this.dir_alerts[index] & 3 ) ) {
						o += "<span class='warning'>";
					} else {
						o += "<span style='color:blue'>";
					}
					o += "" + celsius + "ï¿½C</span> ";
					o += "<span style='color:blue'>";
					o += "" + pressure + "kPa</span></li>";
					GlobalFuncs.to_chat( user, o );
				}
				index++;
			}

			if ( GlobalFuncs.islist( this.users_to_open ) && this.users_to_open.len != 0 ) {
				users_to_open_string = this.users_to_open[1];

				if ( this.users_to_open.len >= 2 ) {
					
					foreach (dynamic _b in Lang13.IterateRange( 2, this.users_to_open.len )) {
						i = _b;
						
						users_to_open_string += ", " + this.users_to_open[i];
					}
				}
				GlobalFuncs.to_chat( user, new Txt( "These people have opened " ).the( this ).item().str( " during an alert: " ).item( users_to_open_string ).str( "." ).ToString() );
			}
			return _default;
		}

		// Function from file: firedoor.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			dynamic _default = null;

			dynamic A = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.areas_added )) {
				A = _a;
				
				A.all_doors.Remove( this );
			}
			_default = base.Destroy( (object)(brokenup) );
			return _default;
		}

	}

}