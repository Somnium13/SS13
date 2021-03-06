// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Alien_Whisper : Obj_Effect_ProcHolder_Alien {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.plasma_cost = 10;
			this.action_icon_state = "alien_whisper";
		}

		public Obj_Effect_ProcHolder_Alien_Whisper ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: alien_powers.dm
		public override bool fire( Mob user = null ) {
			ByTable options = null;
			Mob_Living Ms = null;
			dynamic M = null;
			string msg = null;

			options = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInViewExcludeThis( null, user ), typeof(Mob_Living) )) {
				Ms = _a;
				
				options.Add( Ms );
			}
			M = Interface13.Input( "Select who to whisper to:", "Whisper to?", null, null, options, InputType.Mob | InputType.Null );

			if ( !Lang13.Bool( M ) ) {
				return false;
			}
			msg = GlobalFuncs.sanitize( Interface13.Input( "Message:", "Alien Whisper", null, null, null, InputType.Str | InputType.Null ) );

			if ( Lang13.Bool( msg ) ) {
				GlobalFuncs.log_say( "AlienWhisper: " + GlobalFuncs.key_name( user ) + "->" + M.key + " : " + msg );
				M.WriteMsg( "<span class='noticealien'>You hear a strange, alien voice in your head...</span>" + msg );
				user.WriteMsg( "<span class='noticealien'>You said: \"" + msg + "\" to " + M + "</span>" );
			} else {
				return false;
			}
			return true;
		}

	}

}