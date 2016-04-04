using System;

/*
 * 
 * I have not implemented these yet. The transcompiler output should be good enough now, though!
 * 
 * Anyway, here are some notes:
 *		- dir can not be indexed with non-numeric keys.
 *		- When values in dir are deleted, those directories are deleted from the save.
 *		- F[key] << value is translated to: F[key] = value
 *		- F[key] >> value is translated to: value = F.ReadItem(key,value)
 *			- This is so that existing objects can be loaded to. I could have used a ref parameter, but that would have caused issues with properties!
 *			- Note that 'value = F[key]' is still a valid way to load a totally new object from a save!
 *		- I do not know extactly how eof works or what it is for.
 *		- Paths probably have some fuckery, needs further investigation!
 *		- WE SHOULD PROBABLY ADDRESS NULLS AND BOOLS THE SAME WAY WE DO IN ByTable!
 *		- The doc claims that sometimes references are saved to deal with circular structures. I don't even want to think about this!
 * 
 */

using Somnium.Engine.NewLib;

namespace Somnium.Engine.ByImpl {
	class SaveFile {
		public SaveFile(string filename) {
			Logger.DebugMinor("SAVE-OPEN: " + filename);
		}

		public SaveFile() {
			Logger.DebugMinor("SAVE-OPEN: NULL");
		}

		public dynamic this[string key] {
			get {
				Logger.DebugMinor("SAVE-GET");
				return null;
			}
			set {
				Logger.DebugMinor("SAVE-SET");
			}
		}

		public string cd;
		public bool eof;

		public ByTable dir = new ByTable(); // this needs to be a special table tied to us

		public dynamic ReadItem(string key, object current_value) {
			Logger.DebugMinor("SAVE-READ");
			return null;
		}

		public void ExportText(string a, string b) {

		}
	}
}
