using System;

using Somnium.Engine.NewLib;

using SysFile = System.IO.File;
using SysDir = System.IO.Directory;

namespace Somnium.Engine.ByImpl {

	static class File13 {

		// TODO! ALL OPS SHOULD BE RESTRICTED TO CONTENT DIR!

		public static bool Exists(string filename) {
			return SysFile.Exists(Config.DIR_CONTENT + filename);
		}

		public static bool Delete(dynamic a) {
			if (!(a is string))
				throw new Exception("File13.Delete: Attempt to delete "+a);

			if (!Exists(a))
				return false;

			SysFile.Delete(Config.DIR_CONTENT + a);

			return true;
		}

		public static bool Copy(dynamic source, string dest_path) {
			if (!(source is string))
				throw new Exception("File13.Copy: Attempt to copy " + source);



			Logger.DebugMajor("file->copy");
			return false; // returns success
		}

		public static ByTable List(string path) {
			var dir = new System.IO.DirectoryInfo(Config.DIR_CONTENT + path);

			var result_tab = new ByTable();

			foreach (var fi in dir.GetFiles())
			{
				result_tab.Add(fi.Name);
			}

			foreach (var di in dir.GetDirectories())
			{
				result_tab.Add(dir.Name);
			}

			return result_tab;
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
			Logger.DebugMajor("file->write");
		}

		public static dynamic Cache(dynamic a) {
			Logger.DebugMajor("file->cache");
			return null;
		}

	}
}
