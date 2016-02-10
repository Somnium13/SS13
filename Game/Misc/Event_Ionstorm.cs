// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Event_Ionstorm : Event {

		public double botEmagChance = 0.5;
		public ByTable players = new ByTable();
		public bool active = false;
		public ByTable bots = new ByTable();

		public Event_Ionstorm ( Obj_Item_MechaParts_MechaEquipment_Tool_CableLayer tlistener = null, string tprocname = null ) : base( tlistener, tprocname ) {
			
		}

		// Function from file: ion_storm.dm
		public override void end(  ) {
			this.active = false;
			Task13.Schedule( Rand13.Int( 5000, 8000 ), (Task13.Closure)(() => {
				
				if ( Rand13.PercentChance( 50 ) ) {
					GlobalFuncs.command_alert( "It has come to our attention that the station passed through an ion storm.  Please monitor all electronic equipment for malfunctions.", "Anomaly Alert" );
				}
				return;
			}));
			return;
		}

		// Function from file: ion_storm.dm
		public override void tick(  ) {
			Obj_Machinery_Bot bot = null;

			
			if ( this.botEmagChance != 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.bots, typeof(Obj_Machinery_Bot) )) {
					bot = _a;
					

					if ( !( bot.loc != null ) ) {
						this.bots.Remove( bot );
						continue;
					}

					if ( Rand13.PercentChance( ((int)( this.botEmagChance )) ) ) {
						bot.Emag();
					}
				}
			}
			return;
		}

		// Function from file: ion_storm.dm
		public override void announce(  ) {
			this.endWhen = Rand13.Int( 500, 1500 );
			GlobalFuncs.generate_ion_law();
			return;
		}

		// Function from file: ion_storm.dm
		public override bool start(  ) {
			Obj_Machinery_Bot bot = null;

			this.active = true;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Bot) )) {
				bot = _a;
				
				this.bots.Add( bot );
			}
			return false;
		}

	}

}