// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class AiLaws_Default_Paladin : AiLaws_Default {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Personality Test";
			this.inherent = new ByTable(new object [] { "Never willingly commit an evil act.", "Respect legitimate authority.", "Act with honor.", "Help those in need.", "Punish those who harm or threaten innocents." });
		}

	}

}