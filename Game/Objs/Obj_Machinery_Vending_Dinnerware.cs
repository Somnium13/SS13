// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Vending_Dinnerware : Obj_Machinery_Vending {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.product_ads = "Mm, food stuffs!;Food and food accessories.;Get your plates!;You like forks?;I like forks.;Woo, utensils.;You don't really need these...";
			this.products = new ByTable()
				.Set( typeof(Obj_Item_Weapon_Storage_Bag_Tray), 8 )
				.Set( typeof(Obj_Item_Weapon_Kitchen_Fork), 6 )
				.Set( typeof(Obj_Item_Weapon_Kitchen_Knife), 3 )
				.Set( typeof(Obj_Item_Weapon_Kitchen_Rollingpin), 2 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Drinkingglass), 8 )
				.Set( typeof(Obj_Item_Clothing_Suit_Apron_Chef), 2 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Condiment_Pack_Ketchup), 5 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Condiment_Pack_Hotsauce), 5 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Condiment_Saltshaker), 5 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Condiment_Peppermill), 5 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bowl), 20 )
			;
			this.contraband = new ByTable().Set( typeof(Obj_Item_Weapon_Kitchen_Rollingpin), 2 ).Set( typeof(Obj_Item_Weapon_Kitchen_Knife_Butcher), 2 );
			this.icon_state = "dinnerware";
		}

		public Obj_Machinery_Vending_Dinnerware ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}