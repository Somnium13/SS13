// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Bot_Secbot_Beepsky : Mob_Living_SimpleAnimal_Bot_Secbot {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.auto_patrol = true;
		}

		public Mob_Living_SimpleAnimal_Bot_Secbot_Beepsky ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: secbot.dm
		public override void explode(  ) {
			dynamic Tsec = null;
			Obj_Item_Weapon_ReagentContainers_Food_Drinks_Drinkingglass_Shotglass S = null;

			Tsec = GlobalFuncs.get_turf( this );
			new Obj_Item_Weapon_StockParts_Cell_Potato( Tsec );
			S = new Obj_Item_Weapon_ReagentContainers_Food_Drinks_Drinkingglass_Shotglass( Tsec );
			S.reagents.add_reagent( "whiskey", 15 );
			S.on_reagent_change();
			base.explode();
			return;
		}

	}

}