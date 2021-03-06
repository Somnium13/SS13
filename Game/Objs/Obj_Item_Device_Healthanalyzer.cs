// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Healthanalyzer : Obj_Item_Device {

		public bool? mode = true;
		public bool scanchems = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "analyzer";
			this.flags = 64;
			this.slot_flags = 512;
			this.throwforce = 3;
			this.w_class = 1;
			this.throw_speed = 3;
			this.materials = new ByTable().Set( "$metal", 200 );
			this.origin_tech = "magnets=1;biotech=1";
			this.icon_state = "health";
		}

		public Obj_Item_Device_Healthanalyzer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: scanners.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			
			if ( ( Lang13.Bool( user.disabilities & 256 ) || ((Mob_Living)user).getBrainLoss() >= 60 ) && Rand13.PercentChance( 50 ) ) {
				user.WriteMsg( "<span class='notice'>You stupidly try to analyze the floor's vitals!</span>" );
				((Ent_Static)user).visible_message( "<span class='warning'>" + user + " has analyzed the floor's vitals!</span>" );
				user.WriteMsg( "<span class='info'>Analyzing results for The floor:\n	Overall status: <b>Healthy</b>" );
				user.WriteMsg( "<span class='info'>Key: <font color='blue'>Suffocation</font>/<font color='green'>Toxin</font>/<font color='#FF8000'>Burn</font>/<font color='red'>Brute</font></span>" );
				user.WriteMsg( "<span class='info'>	Damage specifics: <font color='blue'>0</font>-<font color='green'>0</font>-<font color='#FF8000'>0</font>-<font color='red'>0</font></span>" );
				user.WriteMsg( "<span class='info'>Body temperature: ???</span>" );
				return false;
			}
			((Ent_Static)user).visible_message( "<span class='notice'>" + user + " has analyzed " + M + "'s vitals.</span>" );

			if ( !this.scanchems ) {
				GlobalFuncs.healthscan( user, M, this.mode );
			} else {
				GlobalFuncs.chemscan( user, M );
			}
			this.add_fingerprint( user );
			return false;
		}

		// Function from file: scanners.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( !this.scanchems ) {
				user.WriteMsg( "<span class='notice'>You switch the health analyzer to scan chemical contents.</span>" );
				this.scanchems = true;
			} else {
				user.WriteMsg( "<span class='notice'>You switch the health analyzer to check physical health.</span>" );
				this.scanchems = false;
			}
			return null;
		}

		// Function from file: scanners.dm
		[Verb]
		[VerbInfo( name: "Switch Verbosity", group: "Object" )]
		public void toggle_mode(  ) {
			
			if ( Task13.User.stat != 0 || !Task13.User.canmove || Task13.User.restrained() ) {
				return;
			}
			this.mode = !( this.mode == true );

			switch ((bool?)( this.mode )) {
				case true:
					Task13.User.WriteMsg( "The scanner now shows specific limb damage." );
					break;
				case false:
					Task13.User.WriteMsg( "The scanner no longer shows limb damage." );
					break;
			}
			return;
		}

	}

}