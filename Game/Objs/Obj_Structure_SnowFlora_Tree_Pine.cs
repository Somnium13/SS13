// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_SnowFlora_Tree_Pine : Obj_Structure_SnowFlora_Tree {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pixel_x = -16;
			this.pixel_y = 0;
			this.icon = "icons/obj/flora/pinetrees.dmi";
			this.icon_state = "pine_1";
		}

		// Function from file: snow.dm
		public Obj_Structure_SnowFlora_Tree_Pine ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.icon_state = Rand13.Pick(new object [] { "pine_1", "pine_2", "pine_3" });
			return;
		}

		// Function from file: snow.dm
		public override void idle(  ) {
			return;
		}

		// Function from file: snow.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			ByTable cutting = null;

			cutting = new ByTable(new object [] { typeof(Obj_Item_Weapon_Hatchet), typeof(Obj_Item_Weapon_Fireaxe) });

			if ( GlobalFuncs.is_type_in_list( a, cutting ) ) {
				this.axe_hits++;
				((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " hits " ).the( this ).item().str( " with " ).the( a ).item().str( ".</span>" ).ToString() );

				if ( this.axe_hits >= 5 ) {
					new Obj_Item_Weapon_Grown_Log( GlobalFuncs.get_turf( this ) );
					new Obj_Item_Weapon_Grown_Log( GlobalFuncs.get_turf( this ) );
					new Obj_Item_Weapon_Grown_Log( GlobalFuncs.get_turf( this ) );
					GlobalFuncs.qdel( this );
				}
			}
			return null;
		}

	}

}