// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms_Server_Presets_Security : Obj_Machinery_Telecomms_Server_Presets {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "Security Server";
			this.freq_listening = new ByTable(new object [] { 1359 });
			this.autolinkers = new ByTable(new object [] { "security" });
		}

		public Obj_Machinery_Telecomms_Server_Presets_Security ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}