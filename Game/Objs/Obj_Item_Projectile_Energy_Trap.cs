// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Energy_Trap : Obj_Item_Projectile_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.nodamage = true;
			this.weaken = 1;
			this.hitsound = "sound/weapons/taserhit.ogg";
			this.range = 4;
			this.icon_state = "e_snare";
		}

		public Obj_Item_Projectile_Energy_Trap ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: energy.dm
		public override void on_range(  ) {
			new Obj_Item_Weapon_Restraints_Legcuffs_Beartrap_Energy( this.loc );
			base.on_range();
			return;
		}

		// Function from file: energy.dm
		public override dynamic on_hit( Ent_Static target = null, double? blocked = null, dynamic hit_zone = null ) {
			blocked = blocked ?? 0;

			Obj_Item_Weapon_Restraints_Legcuffs_Beartrap_Energy B = null;

			
			if ( !( target is Mob ) || ( blocked ??0) >= 2 ) {
				new Obj_Item_Weapon_Restraints_Legcuffs_Beartrap_Energy( GlobalFuncs.get_turf( this.loc ) );
			} else if ( target is Mob_Living_Carbon ) {
				B = new Obj_Item_Weapon_Restraints_Legcuffs_Beartrap_Energy( GlobalFuncs.get_turf( target ) );
				B.Crossed( (Ent_Dynamic)(target) );
			}
			base.on_hit( target, blocked, (object)(hit_zone) );
			return null;
		}

	}

}