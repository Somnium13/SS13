// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpriteAccessory_Hair_Buzz : SpriteAccessory_Hair {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Buzzcut";
			this.icon_state = "hair_buzzcut";
			this.gender = "male";
			this.species_allowed = new ByTable(new object [] { "Human", "Unathi" });
		}

	}

}