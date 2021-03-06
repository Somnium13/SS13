// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Alien : Obj_Effect_ProcHolder {

		public int plasma_cost = 0;
		public bool? check_turf = false;
		public bool has_action = true;
		public Action_SpellAction_Alien action = null;
		public string action_icon = "icons/mob/actions.dmi";
		public string action_icon_state = "spell_default";
		public string action_background_icon_state = "bg_alien";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.panel = "Alien";
		}

		public Obj_Effect_ProcHolder_Alien ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: alien_powers.dm
		public bool cost_check( bool? check_turf = null, dynamic user = null, bool? silent = null ) {
			check_turf = check_turf ?? false;
			silent = silent ?? false;

			
			if ( Lang13.Bool( user.stat ) ) {
				
				if ( !( silent == true ) ) {
					user.WriteMsg( "<span class='noticealien'>You must be conscious to do this.</span>" );
				}
				return false;
			}

			if ( ((Mob_Living_Carbon)user).getPlasma() < this.plasma_cost ) {
				
				if ( !( silent == true ) ) {
					user.WriteMsg( "<span class='noticealien'>Not enough plasma stored.</span>" );
				}
				return false;
			}

			if ( check_turf == true && ( !( user.loc is Tile ) || user.loc is Tile_Space ) ) {
				
				if ( !( silent == true ) ) {
					user.WriteMsg( "<span class='noticealien'>Bad place for a garden!</span>" );
				}
				return false;
			}
			return true;
		}

		// Function from file: alien_powers.dm
		public virtual bool fire( Mob user = null ) {
			return true;
		}

		// Function from file: alien_powers.dm
		public virtual void on_lose( Mob_Living_Carbon user = null ) {
			return;
		}

		// Function from file: alien_powers.dm
		public virtual void on_gain( Mob_Living_Carbon user = null ) {
			return;
		}

		// Function from file: alien_powers.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			Mob user = null;

			
			if ( !( Task13.User is Mob_Living_Carbon ) ) {
				return true;
			}
			user = Task13.User;

			if ( this.cost_check( this.check_turf, user ) ) {
				
				if ( this.fire( user ) && user != null ) {
					((dynamic)user).adjustPlasma( -this.plasma_cost );
				}
			}
			return true;
		}

	}

}