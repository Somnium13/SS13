// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_TableParts_Wood_Poker : Obj_Item_Weapon_TableParts_Wood {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "gambling_tableparts";
		}

		public Obj_Item_Weapon_TableParts_Wood_Poker ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: table_rack_parts.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			new Obj_Structure_Table_Woodentable_Poker( user.loc );
			user.drop_item( this, null, 1 );
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: table_rack_parts.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Wrench ) {
				new Obj_Item_Stack_Sheet_Wood( b.loc );
				new Obj_Item_Stack_Tile_Grass( b.loc );
				GlobalFuncs.qdel( this );
			}
			return null;
		}

	}

}