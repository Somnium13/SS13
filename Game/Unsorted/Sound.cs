// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Sound : Game_Data {

		public dynamic file = null;
		public bool? repeat = null;
		public bool? wait = null;
		public int? channel = null;
		public double? frequency = 0;
		public bool pan = false;
		public int? volume = 100;
		public int priority = 0;
		public int status = 0;
		public int environment = -1;
		public dynamic echo = null;
		public double x = 0;
		public bool y = false;
		public double z = 0;
		public int? falloff = 1;

		public Sound ( dynamic file = null, bool? repeat = null, bool? wait = null, int? channel = null, int? volume = null ) {
			volume = volume ?? 100;

			this.file = File13.Cache( file );
			this.repeat = repeat;
			this.wait = wait;
			this.channel = channel;
			this.volume = volume;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		public dynamic RscFile(  ) {
			return this.file;
		}

	}

}