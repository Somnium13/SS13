// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Syndicate_MechaPilot_NoMech : Mob_Living_SimpleAnimal_Hostile_Syndicate_MechaPilot {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.spawn_mecha_type = null;
			this.search_objects = 2;
		}

		// Function from file: mecha_pilot.dm
		public Mob_Living_SimpleAnimal_Hostile_Syndicate_MechaPilot_NoMech ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.wanted_objects = Lang13.GetTypes( typeof(Obj_Mecha_Combat) ) - typeof(Obj_Mecha_Combat);
			return;
		}

	}

}