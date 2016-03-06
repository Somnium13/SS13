// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Briefcase_Sniperbundle : Obj_Item_Weapon_Storage_Briefcase {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 10;
			this.attack_verb = new ByTable(new object [] { "bashed", "battered", "bludgeoned", "thrashed", "whacked" });
		}

		// Function from file: briefcase.dm
		public Obj_Item_Weapon_Storage_Briefcase_Sniperbundle ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Weapon_Gun_Projectile_SniperRifle_Syndicate( this );
			new Obj_Item_Clothing_Tie_Red( this );
			new Obj_Item_Clothing_Under_Syndicate_Sniper( this );
			new Obj_Item_AmmoBox_Magazine_SniperRounds_Soporific( this );
			new Obj_Item_AmmoBox_Magazine_SniperRounds_Haemorrhage( this );
			new Obj_Item_Weapon_Suppressor_Specialoffer( this );
			return;
		}

	}

}