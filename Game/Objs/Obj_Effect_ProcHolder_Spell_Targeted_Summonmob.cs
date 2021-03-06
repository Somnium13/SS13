// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_Targeted_Summonmob : Obj_Effect_ProcHolder_Spell_Targeted {

		public Mob_Living_Carbon_Human target_mob = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.clothes_req = 0;
			this.invocation = "JE VES";
			this.invocation_type = "whisper";
			this.range = -1;
			this.level_max = 0;
			this.cooldown_min = 100;
			this.include_user = true;
			this.action_icon_state = "summons";
		}

		public Obj_Effect_ProcHolder_Spell_Targeted_Summonmob ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: Academy.dm
		public override bool cast( dynamic targets = null, dynamic thearea = null, dynamic user = null ) {
			thearea = thearea ?? Task13.User;

			dynamic Start = null;
			dynamic direction = null;
			Tile T = null;

			
			if ( !( this.target_mob != null ) ) {
				return false;
			}
			Start = GlobalFuncs.get_turf( thearea );

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.alldirs )) {
				direction = _a;
				
				T = Map13.GetStep( Start, Convert.ToInt32( direction ) );

				if ( !T.density ) {
					this.target_mob.Move( T );
				}
			}
			return false;
		}

	}

}