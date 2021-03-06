// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms_Receiver_PresetRight : Obj_Machinery_Telecomms_Receiver {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "Receiver B";
			this.network = "tcommsat";
			this.autolinkers = new ByTable(new object [] { "receiverB" });
			this.freq_listening = new ByTable(new object [] { 1353, 1357, 1359 });
		}

		// Function from file: receiver.dm
		public Obj_Machinery_Telecomms_Receiver_PresetRight ( dynamic loc = null ) : base( (object)(loc) ) {
			int? i = null;

			i = null;
			i = 1441;

			while (( i ??0) < 1489) {
				this.freq_listening.Or( i );
				i += 2;
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}