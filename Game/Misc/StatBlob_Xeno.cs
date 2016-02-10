// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class StatBlob_Xeno : StatBlob {

		public int eggs_laid = 0;
		public int faces_hugged = 0;
		public int proper_head_protection = 0;

		// Function from file: stat_blob.dm
		public override void writeStats( File file = null ) {
			file.WriteMsg( "XENOSTATS|" + this.eggs_laid + "|" + this.faces_hugged + "|" + this.proper_head_protection );
			return;
		}

	}

}