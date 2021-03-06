// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_AntagSpawner_NukeOps_BorgTele : Obj_Item_Weapon_AntagSpawner_NukeOps {

		public Obj_Item_Weapon_AntagSpawner_NukeOps_BorgTele ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: antag_spawner.dm
		public override void spawn_antag( dynamic C = null, dynamic T = null, string type = null ) {
			Mob_Living_Silicon_Robot_Syndicate R = null;
			dynamic brainfirstname = null;
			dynamic brainopslastname = null;
			string brainopsname = null;

			
			dynamic _a = this.borg_to_spawn; // Was a switch-case, sorry for the mess.
			if ( _a=="Medical" ) {
				R = new Mob_Living_Silicon_Robot_Syndicate_Medical( T );
			} else {
				R = new Mob_Living_Silicon_Robot_Syndicate( T );
			}
			brainfirstname = Rand13.PickFromTable( GlobalVars.first_names_male );

			if ( Rand13.PercentChance( 50 ) ) {
				brainfirstname = Rand13.PickFromTable( GlobalVars.first_names_female );
			}
			brainopslastname = Rand13.PickFromTable( GlobalVars.last_names );

			if ( Lang13.Bool( GlobalVars.ticker.mode.nukeops_lastname ) ) {
				brainopslastname = GlobalVars.ticker.mode.nukeops_lastname;
			}
			brainopsname = "" + brainfirstname + " " + brainopslastname;
			R.mmi.name = "Man-Machine Interface: " + brainopsname;
			R.mmi.brain.name = "" + brainopsname + "'s brain";
			R.mmi.brainmob.real_name = brainopsname;
			R.mmi.brainmob.name = brainopsname;
			R.key = C.key;
			GlobalVars.ticker.mode.syndicates.Add( R.mind );
			((GameMode)GlobalVars.ticker.mode).update_synd_icons_added( R.mind );
			R.mind.special_role = "syndicate";
			R.faction = new ByTable(new object [] { "syndicate" });
			return;
		}

		// Function from file: antag_spawner.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.borg_to_spawn = Interface13.Input( "What type?", "Cyborg Type", this.type, null, this.possible_types, InputType.Null | InputType.Any );

			if ( !Lang13.Bool( this.borg_to_spawn ) ) {
				return null;
			}
			base.attack_self( (object)(user), (object)(flag), emp );
			return null;
		}

	}

}