// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Radio_Headset_Ai : Obj_Item_Device_Radio_Headset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.keyslot2 = new Obj_Item_Device_Encryptionkey_Ai();
		}

		public Obj_Item_Device_Radio_Headset_Ai ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: headset.dm
		public override double? receive_range( dynamic freq = null, dynamic level = null, bool? AIuser = null ) {
			return base.receive_range( (object)(freq), (object)(level), true );
		}

	}

}