// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Restraints_Handcuffs_Cable : Obj_Item_Weapon_Restraints_Handcuffs {

		public dynamic wirestorage = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "coil_red";
			this.breakouttime = 300;
			this.cuffsound = "sound/weapons/cablecuff.ogg";
			this.icon_state = "cuff_red";
		}

		public Obj_Item_Weapon_Restraints_Handcuffs_Cable ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: handcuffs.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic R = null;
			Obj_Item_Weapon_Wirerod W = null;

			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Stack_Rods ) {
				R = A;

				if ( ((Obj_Item_Stack)R).use( 1 ) != 0 ) {
					W = new Obj_Item_Weapon_Wirerod();

					if ( !this.remove_item_from_storage( user ) ) {
						((Mob)user).unEquip( this );
					}
					((Mob)user).put_in_hands( W );
					user.WriteMsg( "<span class='notice'>You wrap the cable restraint around the top of the rod.</span>" );
					GlobalFuncs.qdel( this );
				} else {
					user.WriteMsg( "<span class='warning'>You need one rod to make a wired rod!</span>" );
					return null;
				}
			}
			return null;
		}

		// Function from file: handcuffs.dm
		public override void apply_cuffs( dynamic target = null, dynamic user = null, bool? dispense = null ) {
			dispense = dispense ?? false;

			
			if ( Lang13.Bool( this.wirestorage ) ) {
				
				if ( !( ((RobotEnergyStorage)this.wirestorage).use_charge( 15 ) != 0 ) ) {
					user.WriteMsg( "<span class='warning'>You need at least 15 wire to restrain " + target + "!</span>" );
					return;
				}
				base.apply_cuffs( (object)(target), (object)(user), true ); return;
			}
			base.apply_cuffs( (object)(target), (object)(user), dispense ); return;
		}

		// Function from file: handcuffs.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			
			if ( !( M is Mob_Living_Carbon ) ) {
				return false;
			}

			if ( Lang13.Bool( this.wirestorage ) && Convert.ToDouble( this.wirestorage.energy ) < 15 ) {
				user.WriteMsg( "<span class='warning'>You need at least 15 wire to restrain " + M + "!</span>" );
				return false;
			}
			return base.attack( (object)(M), (object)(user), def_zone );
		}

	}

}