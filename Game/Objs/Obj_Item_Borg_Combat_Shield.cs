// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Borg_Combat_Shield : Obj_Item_Borg_Combat {

		public double shield_level = 0.5;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/decals.dmi";
			this.icon_state = "shock";
		}

		public Obj_Item_Borg_Combat_Shield ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: robot_items.dm
		[Verb]
		[VerbInfo( name: "Set shield level", group: "Object", access: VerbAccess.InRange, range: 0 )]
		public void set_shield_level(  ) {
			dynamic N = null;

			N = Interface13.Input( "How much damage should the shield absorb?", null, null, null, new ByTable(new object [] { "5", "10", "25", "50", "75", "100" }), InputType.Any );

			if ( Lang13.Bool( N ) ) {
				this.shield_level = ( String13.ParseNumber( N ) ??0) / 100;
			}
			return;
		}

	}

}