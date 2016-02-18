// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SurgeryStep_Incise : SurgeryStep {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "make incision";
			this.implements = new ByTable()
				.Set( typeof(Obj_Item_Weapon_Scalpel), 100 )
				.Set( typeof(Obj_Item_Weapon_Melee_Energy_Sword), 75 )
				.Set( typeof(Obj_Item_Weapon_Kitchen_Knife), 65 )
				.Set( typeof(Obj_Item_Weapon_Shard), 45 )
			;
			this.time = 16;
		}

		// Function from file: generic_steps.dm
		public override int preop( dynamic user = null, Mob target = null, string target_zone = null, dynamic tool = null, Surgery surgery = null ) {
			((Ent_Static)user).visible_message( "" + user + " begins to make an incision in " + target + "'s " + GlobalFuncs.parse_zone( target_zone ) + ".", "<span class='notice'>You begin to make an incision in " + target + "'s " + GlobalFuncs.parse_zone( target_zone ) + "...</span>" );
			return 0;
		}

	}

}