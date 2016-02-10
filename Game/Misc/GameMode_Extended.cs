// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GameMode_Extended : GameMode {

		public int waittime_l = 600;
		public int waittime_h = 1800;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "extended";
			this.config_tag = "extended";
		}

		// Function from file: extended.dm
		public override bool post_setup(  ) {
			Task13.Schedule( Rand13.Int( GlobalVars.waittime_l, GlobalVars.waittime_h ), (Task13.Closure)(() => {
				
				if ( !this.mixed ) {
					this.send_intercept();
				}
				return;
			}));
			base.post_setup();
			return false;
		}

		// Function from file: extended.dm
		public override bool pre_setup(  ) {
			GlobalFuncs.log_admin( "Starting a round of extended." );
			GlobalFuncs.message_admins( "Starting a round of extended." );
			return true;
		}

	}

}