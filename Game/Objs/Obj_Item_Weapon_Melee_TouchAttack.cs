// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Melee_TouchAttack : Obj_Item_Weapon_Melee {

		public string catchphrase = "High Five!";
		public string on_use_sound = null;
		public dynamic attached_spell = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 130;
			this.w_class = 5;
			this.throw_range = 0;
			this.throw_speed = 0;
			this.icon_state = "syndballoon";
		}

		// Function from file: godhand.dm
		public Obj_Item_Weapon_Melee_TouchAttack ( dynamic spell = null ) : base( (object)(spell) ) {
			this.attached_spell = spell;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: godhand.dm
		public override bool dropped( dynamic user = null ) {
			
			if ( Lang13.Bool( this.attached_spell ) ) {
				this.attached_spell.attached_hand = null;
			}
			GlobalFuncs.qdel( this );
			return false;
		}

		// Function from file: godhand.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			((Ent_Dynamic)user).say( this.catchphrase );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( user ), this.on_use_sound, 50, 1 );

			if ( Lang13.Bool( this.attached_spell ) ) {
				this.attached_spell.attached_hand = null;
			}
			GlobalFuncs.qdel( this );
			return false;
		}

		// Function from file: godhand.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			
			if ( !( user is Mob_Living_Carbon ) ) {
				return false;
			}

			if ( Lang13.Bool( user.lying ) || Lang13.Bool( user.handcuffed ) ) {
				user.WriteMsg( "<span class='warning'>You can't reach out!</span>" );
				return false;
			}
			base.attack( (object)(M), (object)(user), def_zone );
			return false;
		}

	}

}