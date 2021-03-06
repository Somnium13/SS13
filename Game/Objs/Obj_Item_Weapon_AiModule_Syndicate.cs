// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_AiModule_Syndicate : Obj_Item_Weapon_AiModule {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "programming=3;materials=6;syndicate=7";
			this.laws = new ByTable(new object [] { "" });
		}

		public Obj_Item_Weapon_AiModule_Syndicate ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: AI_modules.dm
		public override dynamic transmitInstructions( Game_Data law_datum = null, dynamic sender = null ) {
			
			if ( Lang13.Bool( ((dynamic)law_datum).owner ) ) {
				((dynamic)law_datum).owner.WriteMsg( "<span class='warning'>BZZZZT</span>" );
				((Mob_Living_Silicon)((dynamic)law_datum).owner).add_ion_law( this.laws[1] );
			} else {
				((AiLaws)law_datum).add_ion_law( this.laws[1] );
			}
			return this.laws[1];
		}

		// Function from file: AI_modules.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			string targName = null;

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