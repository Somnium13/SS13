// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_AiModule_Supplied_Freeform : Obj_Item_Weapon_AiModule_Supplied {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.lawpos = 15;
			this.origin_tech = "programming=4;materials=4";
			this.laws = new ByTable(new object [] { "" });
		}

		public Obj_Item_Weapon_AiModule_Supplied_Freeform ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: AI_modules.dm
		public override bool install( Game_Data law_datum = null, dynamic user = null ) {
			
			if ( this.laws[1] == "" ) {
				user.WriteMsg( "No law detected on module, please create one." );
				return false;
			}
			base.install( law_datum, (object)(user) );
			return false;
		}

		// Function from file: AI_modules.dm
		public override dynamic transmitInstructions( Game_Data law_datum = null, dynamic sender = null ) {
			base.transmitInstructions( law_datum, (object)(sender) );
			return this.laws[1];
		}

		// Function from file: AI_modules.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic newpos = null;
			string response = null;
			string targName = null;

			newpos = Interface13.Input( "Please enter the priority for your new law. Can only write to law sectors 15 and above.", "Law Priority (15+)", this.lawpos, null, null, InputType.Num | InputType.Null );

			if ( newpos == null ) {
				return null;
			}

			if ( Convert.ToDouble( newpos ) < 15 ) {
				response = Interface13.Alert( "Error: The law priority of " + newpos + " is invalid,  Law priorities below 14 are reserved for core laws,  Would you like to change that that to 15?", "Invalid law priority", "Change to 15", "Cancel" );

				if ( !Lang13.Bool( response ) || response == "Cancel" ) {
					return null;
				}
				newpos = 15;
			}
			this.lawpos = Num13.MinInt( Convert.ToInt32( newpos ), 50 );
			targName = GlobalFuncs.stripped_input( user, "Please enter a new law for the AI.", "Freeform Law Entry", this.laws[1], 1024 );

			if ( !Lang13.Bool( targName ) ) {
				return null;
			}
			this.laws[1] = targName;
			base.attack_self( (object)(user), (object)(flag), emp );
			return null;
		}

	}

}