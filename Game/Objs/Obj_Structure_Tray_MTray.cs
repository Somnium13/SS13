// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Tray_MTray : Obj_Structure_Tray {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "morguet";
		}

		public Obj_Structure_Tray_MTray ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: morgue.dm
		public override bool CanAStarPass( dynamic ID = null, int dir = 0, dynamic caller = null ) {
			bool _default = false;

			Ent_Dynamic mover = null;

			_default = !this.density;

			if ( caller is Ent_Dynamic ) {
				mover = caller;
				_default = _default || mover.checkpass( 1 ) != 0;
			}
			return _default;
		}

		// Function from file: morgue.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 0;

			
			if ( height == 0 ) {
				return true;
			}

			if ( mover is Ent_Dynamic && ((Ent_Dynamic)mover).checkpass( 1 ) != 0 ) {
				return true;
			}

			if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Table), GlobalFuncs.get_turf( mover ) ) ) ) {
				return true;
			} else {
				return false;
			}
		}

	}

}