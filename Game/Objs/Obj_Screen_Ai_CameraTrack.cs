// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Ai_CameraTrack : Obj_Screen_Ai {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "track";
		}

		public Obj_Screen_Ai_CameraTrack ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: ai.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			Mob AI = null;
			dynamic target_name = null;

			AI = Task13.User;
			target_name = Interface13.Input( AI, "Choose who you want to track", "Tracking", null, ((Mob_Living_Silicon_Ai)AI).trackable_mobs(), InputType.Null | InputType.Any );
			((Mob_Living_Silicon_Ai)AI).ai_camera_track( target_name );
			return false;
		}

	}

}