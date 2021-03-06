// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Restraints_Legcuffs_Beartrap : Obj_Item_Weapon_Restraints_Legcuffs {

		public bool armed = false;
		public int trap_damage = 20;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.throw_speed = 1;
			this.throw_range = 1;
			this.icon_state = "beartrap";
		}

		// Function from file: handcuffs.dm
		public Obj_Item_Weapon_Restraints_Legcuffs_Beartrap ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + this.armed;
			return;
		}

		// Function from file: handcuffs.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			Ent_Dynamic L = null;
			bool snap = false;
			string def_zone = null;
			Ent_Dynamic C = null;
			Ent_Dynamic SA = null;

			
			if ( this.armed && this.loc is Tile ) {
				
				if ( O is Mob_Living ) {
					L = O;
					snap = false;
					def_zone = "chest";

					if ( L is Mob_Living_Carbon ) {
						C = L;
						snap = true;

						if ( !Lang13.Bool( ((dynamic)C).lying ) ) {
							def_zone = Rand13.Pick(new object [] { "l_leg", "r_leg" });

							if ( !Lang13.Bool( ((dynamic)C).legcuffed ) ) {
								((dynamic)C).legcuffed = this;
								this.loc = C;
								((dynamic)C).update_inv_legcuffed();
								GlobalFuncs.feedback_add_details( "handcuffs", "B" );
							}
						}
					} else if ( L is Mob_Living_SimpleAnimal ) {
						SA = L;

						if ( !Lang13.Bool( ((dynamic)SA).flying ) && Convert.ToDouble( ((dynamic)SA).mob_size ) > 0 ) {
							snap = true;
						}
					}

					if ( snap ) {
						this.armed = false;
						this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + this.armed;
						GlobalFuncs.playsound( this.loc, "sound/effects/snap.ogg", 50, 1 );
						L.visible_message( new Txt( "<span class='danger'>" ).item( L ).str( " triggers " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='userdanger'>You trigger " ).the( this ).item().str( "!</span>" ).ToString() );
						((dynamic)L).apply_damage( this.trap_damage, "brute", def_zone );
					}
				}
			}
			base.Crossed( O, (object)(X) );
			return null;
		}

		// Function from file: handcuffs.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			base.attack_self( (object)(user), (object)(flag), emp );

			if ( user is Mob_Living_Carbon_Human && !Lang13.Bool( user.stat ) && !((Mob)user).restrained() ) {
				this.armed = !this.armed;
				this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + this.armed;
				user.WriteMsg( "<span class='notice'>" + this + " is now " + ( this.armed ? "armed" : "disarmed" ) + "</span>" );
			}
			return null;
		}

		// Function from file: handcuffs.dm
		public override int suicide_act( Mob_Living_Carbon_Human user = null ) {
			user.visible_message( new Txt( "<span class='suicide'>" ).item( user ).str( " is sticking " ).his_her_its_their().str( " head in the " ).item( this.name ).str( "! It looks like " ).he_she_it_they().str( "'s trying to commit suicide.</span>" ).ToString() );
			GlobalFuncs.playsound( this.loc, "sound/weapons/bladeslice.ogg", 50, 1, -1 );
			return 1;
		}

	}

}