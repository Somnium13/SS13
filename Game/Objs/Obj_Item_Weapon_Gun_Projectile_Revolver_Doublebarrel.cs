// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Revolver_Doublebarrel : Obj_Item_Weapon_Gun_Projectile_Revolver {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "shotgun";
			this.w_class = 4;
			this.force = 10;
			this.slot_flags = 1024;
			this.origin_tech = "combat=3;materials=1";
			this.mag_type = typeof(Obj_Item_AmmoBox_Magazine_Internal_Shot_Dual);
			this.sawn_desc = "Omar's coming!";
			this.unique_rename = true;
			this.unique_reskin = true;
			this.icon_state = "dshotgun";
		}

		// Function from file: shotgun.dm
		public Obj_Item_Weapon_Gun_Projectile_Revolver_Doublebarrel ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.options["Default"] = "dshotgun";
			this.options["Dark Red Finish"] = "dshotgun-d";
			this.options["Ash"] = "dshotgun-f";
			this.options["Faded Grey"] = "dshotgun-g";
			this.options["Maple"] = "dshotgun-l";
			this.options["Rosewood"] = "dshotgun-p";
			this.options["Cancel"] = null;
			return;
		}

		// Function from file: shotgun.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			int num_unloaded = 0;
			dynamic CB = null;

			num_unloaded = 0;

			while (this.get_ammo() > 0) {
				CB = null;
				CB = ((Obj_Item_AmmoBox)this.magazine).get_round( false );
				this.chambered = null;
				CB.loc = GlobalFuncs.get_turf( this.loc );
				CB.update_icon();
				num_unloaded++;
			}

			if ( num_unloaded != 0 ) {
				user.WriteMsg( new Txt( "<span class='notice'>You break open " ).the( this ).item().str( " and unload " ).item( num_unloaded ).str( " shell" ).s().str( ".</span>" ).ToString() );
			} else {
				user.WriteMsg( "<span class='warning'>" + this + " is empty!</span>" );
			}
			return null;
		}

		// Function from file: shotgun.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic W = null;

			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_AmmoBox || A is Obj_Item_AmmoCasing ) {
				this.chamber_round();
			}

			if ( A is Obj_Item_Weapon_Melee_Energy ) {
				W = A;

				if ( Lang13.Bool( W.active ) ) {
					this.sawoff( user );
				}
			}

			if ( A is Obj_Item_Weapon_CircularSaw || A is Obj_Item_Weapon_Gun_Energy_Plasmacutter ) {
				this.sawoff( user );
			}
			return null;
		}

	}

}