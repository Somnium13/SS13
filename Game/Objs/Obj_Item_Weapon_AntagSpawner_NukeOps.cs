// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_AntagSpawner_NukeOps : Obj_Item_Weapon_AntagSpawner {

		public dynamic borg_to_spawn = null;
		public ByTable possible_types = new ByTable(new object [] { "Assault", "Medical" });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/device.dmi";
			this.icon_state = "locator";
		}

		public Obj_Item_Weapon_AntagSpawner_NukeOps ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: antag_spawner.dm
		public override void spawn_antag( dynamic C = null, dynamic T = null, string type = null ) {
			dynamic new_op_code = null;
			Mob_Living_Carbon_Human M = null;
			dynamic nuke = null;
			dynamic newname = null;

			new_op_code = "Ask your leader!";
			M = new Mob_Living_Carbon_Human( T );
			C.prefs.copy_to( M );
			M.key = C.key;
			nuke = Lang13.FindIn( "syndienuke", GlobalVars.nuke_list );

			if ( Lang13.Bool( nuke ) ) {
				new_op_code = nuke.r_code;
			}
			M.mind.make_Nuke( T, new_op_code, false, GlobalVars.FALSE );
			newname = ((Species)M.dna.species).random_name( M.gender, false, GlobalVars.ticker.mode.nukeops_lastname );
			M.mind.name = newname;
			M.real_name = newname;
			M.name = newname;
			return;
		}

		// Function from file: antag_spawner.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			ByTable nuke_candidates = null;
			dynamic C = null;
			EffectSystem_SparkSpread S = null;

			
			if ( !this.check_usability( user ) ) {
				return null;
			}
			nuke_candidates = GlobalFuncs.get_candidates( "operative", 3000, "operative" );

			if ( nuke_candidates.len > 0 ) {
				this.used = true;
				C = Rand13.PickFromTable( nuke_candidates );
				this.spawn_antag( C, GlobalFuncs.get_turf( this.loc ), "syndieborg" );
				S = new EffectSystem_SparkSpread();
				S.set_up( 4, 1, this );
				S.start();
				GlobalFuncs.qdel( this );
			} else {
				user.WriteMsg( "<span class='warning'>Unable to connect to Syndicate command. Please wait and try again later or use the teleporter on your uplink to get your points refunded.</span>" );
			}
			return null;
		}

		// Function from file: antag_spawner.dm
		public bool check_usability( dynamic user = null ) {
			
			if ( this.used ) {
				user.WriteMsg( "<span class='warning'>" + this + " is out of power!</span>" );
				return false;
			}

			if ( !GlobalVars.ticker.mode.syndicates.Contains( user.mind ) ) {
				user.WriteMsg( "<span class='danger'>AUTHENTICATION FAILURE. ACCESS DENIED.</span>" );
				return false;
			}

			if ( Convert.ToInt32( user.z ) != 2 ) {
				user.WriteMsg( "<span class='warning'>" + this + " is out of range! It can only be used at your base!</span>" );
				return false;
			}
			return true;
		}

	}

}