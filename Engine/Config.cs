using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somnium.Engine {
	
	// We should probably be loading this from a config file.
	static class Config {
		public const bool DEVMODE = true;

		public const string DIR_CONTENT = "../../content/";
		public const string DIR_WWW = "../../www/";

		public const string HOMEPAGE = "http://somnium13.github.io";

		public const string HOST_ADDR = "localhost";
		public const int HOST_PORT = 80;
		
	}
}
