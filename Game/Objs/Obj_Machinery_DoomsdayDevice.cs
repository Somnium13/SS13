// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_DoomsdayDevice : Obj_Machinery {

		public bool timing = true;
		public int timer = 450;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.verb_exclaim = "blares";
			this.icon = "icons/obj/machines/nuke_terminal.dmi";
			this.icon_state = "nuclearbomb_base";
		}

		public Obj_Machinery_DoomsdayDevice ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: Malf_Modules.dm
		public void detonate( int? z_level = null ) {
			z_level = z_level ?? 1;

			dynamic M = null;
			Mob_Living L = null;
			dynamic T = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list )) {
				M = _a;
				
				M.WriteMsg( "sound/machines/Alarm.ogg" );
			}
			Task13.Sleep( 100 );

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.mob_list, typeof(Mob_Living) )) {
				L = _b;
				
				T = GlobalFuncs.get_turf( L );

				if ( Lang13.IntNullable( T.z ) != z_level ) {
					continue;
				}

				if ( L is Mob_Living_Silicon ) {
					continue;
				}
				L.WriteMsg( "<span class='danger'><B>The blast wave from the " + this + " tears you atom from atom!</B></span>" );
				L.dust();
			}
			Game13.WriteMsg( "<B>The AI cleansed the station of life with the doomsday device!</B>" );
			GlobalVars.ticker.force_ending = 1;
			return;
		}

		// Function from file: Malf_Modules.dm
		public override int? process( dynamic seconds = null ) {
			dynamic T = null;
			string message = null;

			T = GlobalFuncs.get_turf( this );

			if ( !Lang13.Bool( T ) || Lang13.Bool( T.z ) != true ) {
				GlobalFuncs.minor_announce( "DOOMSDAY DEVICE OUT OF STATION RANGE, ABORTING", "ERROR ER0RR $R0RRO$!R41.%%!!(%$^^__+ @#F0E4", true );
				GlobalVars.SSshuttle.emergencyNoEscape = false;

				if ( GlobalVars.SSshuttle.emergency.mode == 4 ) {
					GlobalVars.SSshuttle.emergency.mode = 3;
					GlobalVars.SSshuttle.emergency.timer = Game13.time;
					GlobalFuncs.priority_announce( "Hostile environment resolved. You have 3 minutes to board the Emergency Shuttle.", null, "sound/AI/shuttledock.ogg", "Priority" );
				}
				GlobalFuncs.qdel( this );
			}

			if ( !this.timing ) {
				return null;
			}

			if ( this.timer <= 0 ) {
				this.timing = false;
				this.detonate( Lang13.IntNullable( T.z ) );
				GlobalFuncs.qdel( this );
			} else {
				this.timer--;

				if ( !( this.timer % 60 != 0 ) ) {
					message = "" + this.timer + " SECONDS UNTIL DOOMSDAY DEVICE ACTIVATION!";
					GlobalFuncs.minor_announce( message, "ERROR ER0RR $R0RRO$!R41.%%!!(%$^^__+ @#F0E4", true );
				}
			}
			return null;
		}

	}

}