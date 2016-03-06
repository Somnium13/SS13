// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_Targeted_Emplosion : Obj_Effect_ProcHolder_Spell_Targeted {

		public int emp_heavy = 2;
		public int emp_light = 3;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.action_icon_state = "emp";
			this.sound = "sound/weapons/ZapBang.ogg";
		}

		public Obj_Effect_ProcHolder_Spell_Targeted_Emplosion ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: tgstation.dme
		public override bool cast( dynamic targets = null, dynamic thearea = null, dynamic user = null ) {
			thearea = thearea ?? Task13.User;

			Mob_Living target = null;

			GlobalFuncs.playsound( GlobalFuncs.get_turf( thearea ), this.sound, 50, 1 );

			foreach (dynamic _a in Lang13.Enumerate( targets, typeof(Mob_Living) )) {
				target = _a;
				
				GlobalFuncs.empulse( target.loc, this.emp_heavy, this.emp_light );
			}
			return false;
		}

	}

}