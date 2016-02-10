// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Map_Spawner_Space_Weapons : Obj_Map_Spawner_Space {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.chance = 20;
			this.toSpawn = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Kitchen_Utensil_Knife_Large_Butch_Meatcleaver), 
				typeof(Obj_Item_Weapon_Crossbow), 
				typeof(Obj_Item_Weapon_Grenade_Spawnergrenade_Manhacks), 
				typeof(Obj_Item_Weapon_Grenade_Spawnergrenade_Spesscarp), 
				typeof(Obj_Item_Weapon_Grenade_Flashbang_Clusterbang), 
				typeof(Obj_Item_Weapon_Grenade_Empgrenade), 
				typeof(Obj_Item_Weapon_Gun_Dartgun_Vox_Raider), 
				typeof(Obj_Item_Weapon_Gun_Energy_Decloner), 
				typeof(Obj_Item_Weapon_Gun_Energy_Laser_Retro), 
				typeof(Obj_Item_Weapon_Gun_Energy_Mindflayer), 
				typeof(Obj_Item_Weapon_Gun_Energy_Temperature), 
				typeof(Obj_Item_Weapon_Gun_Energy_Xray), 
				typeof(Obj_Item_Weapon_Gun_Projectile_Gyropistol), 
				typeof(Obj_Item_Weapon_Gun_Projectile_Pistol), 
				typeof(Obj_Item_Weapon_Gun_Projectile_Russian), 
				typeof(Obj_Item_Weapon_Gun_Projectile_Silenced), 
				typeof(Obj_Item_Weapon_Harpoon), 
				typeof(Obj_Item_Weapon_Melee_ClassicBaton), 
				typeof(Obj_Item_Weapon_Pickaxe_Plasmacutter), 
				typeof(Obj_Item_Weapon_Shield_Energy), 
				typeof(Obj_Item_Weapon_Organ_Head), 
				typeof(Obj_Item_Weapon_Organ_RLeg), 
				typeof(Obj_Item_Weapon_Organ_LArm), 
				typeof(Obj_Item_Weapon_Organ_LFoot)
			 });
			this.icon_state = "space_weapons";
		}

		public Obj_Map_Spawner_Space_Weapons ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}