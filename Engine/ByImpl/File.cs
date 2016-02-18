using System;

using Somnium.Engine.NewLib;

namespace Somnium.Engine.ByImpl {
	class File {
		private string _name;

		public File(string name) {
			_name = name;
		}

		public void WriteMsg(object data) {
			if (this == Game13.log)
				Logger.Log(data.ToString());
			else
				Logger.LogFile("[" + _name + "] << " + data);
		}
	}
}
