using System;

using Somnium.Engine.NewLib;

using SysFile = System.IO.File;

namespace Somnium.Engine.ByImpl {

	static class File13 {

		// TODO! ALL OPS SHOULD BE RESTRICTED TO CONTENT DIR!

		public static bool Exists(string filename) {
			return SysFile.Exists(Config.DIR_CONTENT + filename);
		}

		public static bool Delete(dynamic a) {
			Logger.Debug("file->delete "+a);
			return false;
		}

		public static void Copy(dynamic source, string dest_path) {
			Logger.Debug("file->copy");
		}

		public static ByTable List(string path) {
			Logger.Debug("file->list");
			return new ByTable();
		}

		public static string Read(string filename) {
			try { // This appears to strip all carriage returns from the string!
				return SysFile.ReadAllText(Config.DIR_CONTENT + filename).Replace("\r", "");
			}
			catch {
				return null;
			}
		}

		public static void Write(string filename, string data) {
			Logger.Debug("file->write");
		}

		public static dynamic Cache(dynamic a) {
			Logger.Debug("file->cache");
			return null;
		}

	}
}
