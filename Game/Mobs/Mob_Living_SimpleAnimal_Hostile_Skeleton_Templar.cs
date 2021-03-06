// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Skeleton_Templar : Mob_Living_SimpleAnimal_Hostile_Skeleton {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "templar";
			this.icon_dead = "templar_dead";
			this.maxHealth = 150;
			this.health = 150;
			this.speed = 2;
			this.speak_chance = 1;
			this.speak = new ByTable(new object [] { "THE GODS WILL IT!", "DEUS VULT!", "REMOVE KABAB!" });
			this.force_threshold = 10;
			this.melee_damage_lower = 25;
			this.melee_damage_upper = 30;
			this.deathmessage = "The templar knight collaspes into a pile of bones, its gear clanging as it hits the ground!";
			this.loot = new ByTable(new object [] { 
				typeof(Obj_Effect_Decal_Remains_Human), 
				typeof(Obj_Item_Clothing_Suit_Armor_Riot_Knight_Templar), 
				typeof(Obj_Item_Clothing_Head_Helmet_Knight_Templar), 
				new ObjectInitializer(typeof(Obj_Item_Weapon_Claymore_Hog)).Set( "name", "holy sword" )
			 });
			this.icon_state = "templar";
		}

		public Mob_Living_SimpleAnimal_Hostile_Skeleton_Templar ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}