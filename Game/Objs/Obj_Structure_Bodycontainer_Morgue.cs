// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Bodycontainer_Morgue : Obj_Structure_Bodycontainer {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.opendir = 4;
		}

		// Function from file: morgue.dm
		public Obj_Structure_Bodycontainer_Morgue ( dynamic loc = null ) : base( (object)(loc) ) {
			this.connected = new Obj_Structure_Tray_MTray( this );
			this.connected.connected = this;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: morgue.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			ByTable compiled = null;
			Mob_Living M = null;

			
			if ( !( this.connected != null ) || this.connected.loc != this ) {
				this.icon_state = "morgue0";
			} else if ( this.contents.len == 1 ) {
				this.icon_state = "morgue1";
			} else {
				this.icon_state = "morgue2";
				compiled = GlobalFuncs.recursive_mob_check( this, false, false );

				if ( !( Lang13.Length( compiled ) != 0 ) ) {
					this.icon_state = "morgue3";
					return false;
				}

				foreach (dynamic _a in Lang13.Enumerate( compiled, typeof(Mob_Living) )) {
					M = _a;
					

					if ( M.client != null ) {
						this.icon_state = "morgue4";
						break;
					}
				}
			}
			return false;
		}

	}

}