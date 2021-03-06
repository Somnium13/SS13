// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Assembly_Control : Obj_Item_Device_Assembly {

		public string id = null;
		public bool can_change_id = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "magnets=1;programming=2";
			this.attachable = true;
			this.icon_state = "control";
		}

		public Obj_Item_Device_Assembly_Control ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: doorcontrol.dm
		public override bool activate(  ) {
			bool? openclose = null;
			Obj_Machinery_Door_Poddoor M = null;

			this.cooldown = 1;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Door_Poddoor) )) {
				M = _a;
				

				if ( M.id == this.id ) {
					
					if ( openclose == null ) {
						openclose = M.density;
					}
					Task13.Schedule( 0, (Task13.Closure)(() => {
						
						if ( M != null ) {
							
							if ( openclose == true ) {
								M.open();
							} else {
								M.close();
							}
						}
						return;
						return;
					}));
				}
			}
			Task13.Sleep( 10 );
			this.cooldown = 0;
			return false;
		}

		// Function from file: doorcontrol.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );

			if ( Lang13.Bool( this.id ) ) {
				user.WriteMsg( "It's channel ID is '" + this.id + "'." );
			}
			return 0;
		}

	}

}