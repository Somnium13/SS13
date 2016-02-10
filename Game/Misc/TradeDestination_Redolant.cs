// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TradeDestination_Redolant : TradeDestination {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "OAV Redolant";
			this.description = "Osiris Atmospherics station in orbit around the only gas giant insystem. They retain tight control over shipping rights, and Osiris warships protecting their prize are not an uncommon sight in Tau Ceti.";
			this.distance = 0.6;
			this.willing_to_buy = new ByTable();
			this.willing_to_sell = new ByTable();
			this.viable_random_events = new ByTable(new object [] { 3, 6, 7 });
			this.viable_mundane_events = new ByTable(new object [] { 15, 15 });
		}

		// Function from file: Economy_TradeDestinations.dm
		public override string get_custom_eventstring( int? event_type = null ) {
			
			if ( event_type == 15 ) {
				return "Thanks to research conducted on the OAV Redolant, Osiris Atmospherics wishes to announce a major breakthough in the field of " + Rand13.Pick(new object [] { "plasma research", "high energy flux capacitance", "super-compressed materials", "theoretical particle physics" }) + ". Nanotrasen is expected to announce a co-exploitation deal within the fortnight.";
			}
			return null;
		}

	}

}