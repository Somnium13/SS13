// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Holiday_UFO : Holiday {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "UFO Day";
			this.begin_day = 2;
			this.begin_month = 7;
		}

		// Function from file: holidays.dm
		public override string getStationPrefix(  ) {
			return Rand13.Pick(new object [] { "Ayy", "Truth", "Tsoukalos", "Mulder" });
		}

	}

}