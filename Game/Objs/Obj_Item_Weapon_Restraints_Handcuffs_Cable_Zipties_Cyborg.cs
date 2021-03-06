// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Restraints_Handcuffs_Cable_Zipties_Cyborg : Obj_Item_Weapon_Restraints_Handcuffs_Cable_Zipties {

		public Obj_Item_Weapon_Restraints_Handcuffs_Cable_Zipties_Cyborg ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: handcuffs.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			
			if ( user is Mob_Living_Silicon_Robot ) {
				
				if ( !Lang13.Bool( M.handcuffed ) ) {
					GlobalFuncs.playsound( this.loc, "sound/weapons/cablecuff.ogg", 30, 1, -2 );
					((Ent_Static)M).visible_message( "<span class='danger'>" + user + " is trying to put zipties on " + M + "!</span>", "<span class='userdanger'>" + user + " is trying to put zipties on " + M + "!</span>" );

					if ( GlobalFuncs.do_mob( user, M, 30 ) ) {
						
						if ( !Lang13.Bool( M.handcuffed ) ) {
							M.handcuffed = new Obj_Item_Weapon_Restraints_Handcuffs_Cable_Zipties_Used( M );
							((Mob_Living_Carbon)M).update_handcuffed();
							user.WriteMsg( "<span class='notice'>You handcuff " + M + ".</span>" );
							GlobalFuncs.add_logs( user, M, "handcuffed" );
						}
					} else {
						user.WriteMsg( "<span class='warning'>You fail to handcuff " + M + "!</span>" );
					}
				}
			}
			return false;
		}

	}

}