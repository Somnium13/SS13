// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_Hydro : Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Botanist";
			this.flag = 4;
			this.department_flag = 4;
			this.faction = "Station";
			this.total_positions = 3;
			this.spawn_positions = 2;
			this.supervisors = "the head of personnel";
			this.selection_color = "#dddddd";
			this.access = new ByTable(new object [] { 35, 25, 28, 6 });
			this.minimal_access = new ByTable(new object [] { 35, 6 });
			this.alt_titles = new ByTable(new object [] { "Hydroponicist", "Beekeeper", "Gardener" });
			this.pdatype = typeof(Obj_Item_Device_Pda_Botanist);
			this.department = "Civilian";
		}

		// Function from file: civilian.dm
		public override bool equip( dynamic H = null ) {
			
			if ( !Lang13.Bool( H ) ) {
				return false;
			}
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Device_Radio_Headset_HeadsetService(  ), 8 );

			dynamic _a = H.backbag; // Was a switch-case, sorry for the mess.
			if ( _a==2 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack( H ), 1 );
			} else if ( _a==3 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack_SatchelHyd( H ), 1 );
			} else if ( _a==4 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack_Satchel( H ), 1 );
			}

			switch ((string)( H.mind.role_alt_title )) {
				case "Hydroponicist":
					((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Under_Rank_Hydroponics( H ), 14 );
					break;
				case "Botanist":
					((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Under_Rank_Botany( H ), 14 );
					break;
				case "Beekeeper":
					((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Under_Rank_Beekeeper( H ), 14 );
					break;
				case "Gardener":
					((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Under_Rank_Gardener( H ), 14 );
					break;
			}
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Shoes_Black( H ), 12 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Gloves_BotanicLeather( H ), 10 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Suit_Apron( H ), 13 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Device_Analyzer_PlantAnalyzer( H ), 17 );

			if ( Lang13.Bool( H.backbag ) == true ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( Lang13.Call( H.species.survival_gear, H ), 5 );
			} else {
				((Mob_Living_Carbon_Human)H).equip_or_collect( Lang13.Call( H.species.survival_gear, H.back ), 18 );
			}
			return true;
		}

	}

}