// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_Targeted_ShadowlingExtendShuttle : Obj_Effect_ProcHolder_Spell_Targeted {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.panel = "Shadowling Abilities";
			this.range = 1;
			this.human_req = 1;
			this.clothes_req = 0;
			this.charge_max = 600;
			this.action_icon_state = "extend_shuttle";
		}

		public Obj_Effect_ProcHolder_Spell_Targeted_ShadowlingExtendShuttle ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: shadowling_abilities.dm
		public override bool cast( dynamic targets = null, dynamic thearea = null, dynamic user = null ) {
			thearea = thearea ?? Task13.User;

			Mob_Living_Carbon_Human target = null;
			Mob_Living_Carbon_Human M = null;
			int more_minutes = 0;
			double timer = 0;

			
			if ( !this.shadowling_check( thearea ) ) {
				this.revert_cast();
				return false;
			}

			foreach (dynamic _a in Lang13.Enumerate( targets, typeof(Mob_Living_Carbon_Human) )) {
				target = _a;
				

				if ( target.stat != 0 ) {
					this.revert_cast();
					return false;
				}

				if ( !GlobalFuncs.is_thrall( target ) ) {
					thearea.WriteMsg( "<span class='warning'>" + target + " must be a thrall.</span>" );
					this.revert_cast();
					return false;
				}

				if ( GlobalVars.SSshuttle.emergency.mode != 2 ) {
					thearea.WriteMsg( "<span class='warning'>The shuttle must be inbound only to the station.</span>" );
					this.revert_cast();
					return false;
				}
				M = target;
				((Ent_Static)thearea).visible_message( "<span class='warning'>" + thearea + "'s eyes flash a bright red!</span>", "<span class='notice'>You begin to draw " + M + "'s life force.</span>" );
				M.visible_message( "<span class='warning'>" + M + "'s face falls slack, their jaw slightly distending.</span>", "<span class='boldannounce'>You are suddenly transported... far, far away...</span>" );

				if ( !GlobalFuncs.do_after( thearea, 50, null, M ) ) {
					M.WriteMsg( "<span class='warning'>You are snapped back to reality, your haze dissipating!</span>" );
					thearea.WriteMsg( "<span class='warning'>You have been interrupted. The draw has failed.</span>" );
					return false;
				}
				thearea.WriteMsg( "<span class='notice'>You project " + M + "'s life force toward the approaching shuttle, extending its arrival duration!</span>" );
				M.visible_message( "<span class='warning'>" + M + "'s eyes suddenly flare red. They proceed to collapse on the floor, not breathing.</span>", "<span class='warning'><b>...speeding by... ...pretty blue glow... ...touch it... ...no glow now... ...no light... ...nothing at all...</span>" );
				M.death();

				if ( GlobalVars.SSshuttle.emergency.mode == 2 ) {
					more_minutes = 9000;
					timer = GlobalVars.SSshuttle.emergency.timeLeft();
					timer += more_minutes;
					GlobalFuncs.priority_announce( "Major system failure aboard the emergency shuttle. This will extend its arrival time by approximately 15 minutes..", "System Failure", "sound/misc/notice1.ogg" );
					GlobalVars.SSshuttle.emergency.setTimer( timer );
				}
				thearea.mind.spell_list.Remove( this );
				GlobalFuncs.qdel( this );
			}
			return false;
		}

	}

}