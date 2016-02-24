using System;
using Somnium.Game;
using Somnium.Engine.ByImpl;

/*
 * This is based directly off of the DMMSuite maploader!
 * It has been optimized and is now allowed to fail to initialize objects!
 */

namespace Somnium.Engine.NewLib {


	class DMMLoader : Game_Data {

		public string quote = "\"";
		public ByTable letter_digits = new ByTable(new object[] { 
											"a", 
											"b", 
											"c", 
											"d", 
											"e", 
											"f", 
											"g", 
											"h", 
											"i", 
											"j", 
											"k", 
											"l", 
											"m", 
											"n", 
											"o", 
											"p", 
											"q", 
											"r", 
											"s", 
											"t", 
											"u", 
											"v", 
											"w", 
											"x", 
											"y", 
											"z", 
											"A", 
											"B", 
											"C", 
											"D", 
											"E", 
											"F", 
											"G", 
											"H", 
											"I", 
											"J", 
											"K", 
											"L", 
											"M", 
											"N", 
											"O", 
											"P", 
											"Q", 
											"R", 
											"S", 
											"T", 
											"U", 
											"V", 
											"W", 
											"X", 
											"Y", 
											"Z"
										 });

		// leaving this behind for now, just in case...
		public override dynamic Destroy() {
			base.Destroy();
			return 4;
		}

		public void LoadMap(string dmm_file, int x_offset, int y_offset, int z_offset) {
			string tfile = File13.Read(dmm_file);
			int tfile_len = tfile.Length;

			string[] tfile_lines = tfile.Split('\n');
			
			int key_len = Lang13.Length(String13.SubStr(tfile, 2, String13.Find(tfile, quote, 2, 0)));
			
			var grid_models = new ByTable();

			Logger.Announce("Parsing map file...");
			var timer = new System.Diagnostics.Stopwatch();
			timer.Start();

			int line_i = 0;

			string default_key = null;

			while (true) {
				string tline = tfile_lines[line_i];
				
				// Bail out if not a model.
				if (tline.Length == 0) break;

				string model_key = tline.Substring(1, key_len);
				string model_contents = tline.Substring(key_len + 6, tline.Length - (key_len + 7) );
				
				grid_models[model_key] = model_contents;

				if (default_key == null)
					default_key = model_key;

				line_i++;
			}
			Logger.Announce("Done parsing map file in " + timer.Elapsed + "s.");

			string zgrid = null;

			int x_depth = 0;
			int y_depth = 0;
			int z_depth = 0;

			double x_tilecount = 0;

			int? gpos = null;
			string grid_line = null;


			int xcrd = x_offset;
			int ycrd = y_offset;
			int zcrd = -1;

			int tpos = String13.Find(tfile, "\n(1,1,");
			while (tpos != 0) {
				zcrd++;
				Game13.map_size_z = Num13.MaxInt(Game13.map_size_z, zcrd + z_offset);
				zgrid = String13.SubStr(tfile, String13.Find(tfile, quote + "\n", tpos, 0) + 2, String13.Find(tfile, "\n" + quote, tpos, 0) + 1);
				z_depth = Lang13.Length(zgrid);
				x_depth = Lang13.Length(String13.SubStr(zgrid, 1, String13.Find(zgrid, "\n", 2, 0)));
				x_tilecount = x_depth / key_len;
				if (Game13.map_size_x < x_tilecount) {
					Game13.map_size_x = ((int)(x_tilecount));
				}
				y_depth = z_depth / (x_depth + 1);
				if (Game13.map_size_y < y_depth) {
					Game13.map_size_y = ((int)(y_depth));
				}
				ycrd = y_depth;
				gpos = null;
				gpos = 1;

				while (gpos != 0) {
					Logger.Announce("Starting map row #" + ycrd + "...");
					grid_line = String13.SubStr(zgrid, gpos ?? 0, String13.Find(zgrid, "\n", gpos ?? 0, 0));
					xcrd = 0;

					foreach (double mpos in Lang13.IterateRange(1, x_depth, key_len)) {
						xcrd++;
						string model_key = String13.SubStr(grid_line, (int)mpos, (int)mpos + key_len);
						if (model_key != default_key)
							this.parse_grid(grid_models[model_key], xcrd + x_offset, ycrd + y_offset, zcrd + z_offset);
					}
					if ((gpos ?? 0) + x_depth + 1 > z_depth) {
						break;
					}
					ycrd--;

					gpos = String13.Find(zgrid, "\n", gpos ?? 0, 0) + 1;
				}
				if (String13.Find(tfile, quote + "}", tpos, 0) + 2 == tfile_len) {
					break;
				}

				tpos = String13.Find(tfile, "\n(1,1,", tpos + 1, 0);
			}
			Logger.Announce("Done loading map in " + timer.Elapsed + "s.");
			return;
		}

		private void parse_grid(string model = null, int xcrd = 0, double ycrd = 0, int zcrd = 0) {
			ByTable members = null;
			ByTable members_attributes = null;
			double index = 0;
			int old_position = 0;
			int dpos = 0;
			string full_def = null;
			Type atom_def = null;
			ByTable fields = null;
			int variables_start = 0;
			ByTable turfs_underlays = null;
			dynamic instance = null;
			Tile crds = null;
			int first_turf_index = 0;
			dynamic T = null;
			dynamic UT = null;
			members = new ByTable();
			members_attributes = new ByTable();
			index = 1;
			old_position = 1;
			while (true) { // Was a do-while, sorry for the mess.
				dpos = this.find_next_delimiter_position(model, old_position, ",", "{", "}");
				full_def = String13.SubStr(model, old_position, dpos);
				string path = String13.SubStr(full_def, 1, String13.Find(full_def, "{", 1, 0));
				atom_def = Lang13.FindClass(path);
				members.Add(atom_def);
				old_position = dpos + 1;
				fields = new ByTable();
				variables_start = String13.Find(full_def, "{", 1, 0);
				if (variables_start != 0) {
					full_def = String13.SubStr(full_def, variables_start + 1, Lang13.Length(full_def));
					fields = this.text2list(full_def, ";");
				}
				members_attributes.len++;
				members_attributes[index++] = fields;
				Task13.Sleep(-1);
				if (!(dpos != 0)) break;
			}

			turfs_underlays = new ByTable();
			index = members.len;

			// Setup zone...
			GlobalVars._preloader.setup(members_attributes[index]);
			instance = Lang13.FindObj(members[index]);

			crds = Map13.GetTile(xcrd, ((int)(ycrd)), zcrd);
			if (crds != null) {
				instance.contents.Add(crds);
			}

			if (Lang13.Bool(GlobalVars.use_preloader) && Lang13.Bool(instance))
			{
				GlobalVars._preloader.load(instance);
			}

			members.Remove(members[index]);

			// Load tile(s?!?)
			first_turf_index = 1;
			while (members[first_turf_index] == null || !members[first_turf_index].IsSubclassOf(typeof(Tile)) ) {
				first_turf_index++;
			}

			try {
				T = this.instance_atom(members[first_turf_index], members_attributes[first_turf_index], xcrd, ycrd, zcrd);
			}
			catch (Exception e)
			{
				Logger.Error("Failed to init tile [" + members[first_turf_index] + "] at ( " + xcrd + ", " + ycrd + ", " + zcrd + " )", e);
			}

			if (Lang13.Bool(T)) {
				index = first_turf_index + 1;
				while (index <= members.len) {
					turfs_underlays.Insert(1, new Image(T.icon, null, T.icon_state, T.layer, T.dir));
					UT = this.instance_atom(members[index], members_attributes[index], xcrd, ycrd, zcrd);
					this.add_underlying_turf(UT, T, turfs_underlays);
					T = UT;
					index++;
				}
			}

			foreach (dynamic _a in Lang13.IterateRange(1, first_turf_index - 1)) {
				index = _a;
				try {
					this.instance_atom(members[index], members_attributes[index], xcrd, ycrd, zcrd);
				}
				catch (Exception e) {
					Logger.Error("Failed to init object [" + members[index] + "] at ( " + xcrd + ", " + ycrd + ", " + zcrd + " )", e);
				}
			}
			return;
		}

		private int find_next_delimiter_position(string text = null, int initial_position = 0, string delimiter = null, string opening_escape = null, string closing_escape = null) {
			int position = 0;
			int next_delimiter = 0;
			int next_opening = 0;
			if (delimiter == null) {
				delimiter = ",";
			}
			if (opening_escape == null) {
				opening_escape = this.quote;
			}
			if (closing_escape == null) {
				closing_escape = this.quote;
			}
			position = initial_position;
			next_delimiter = String13.Find(text, delimiter, position, 0);
			next_opening = String13.Find(text, opening_escape, position, 0);
			while (next_opening != 0 && next_opening < next_delimiter) {
				position = String13.Find(text, closing_escape, next_opening + 1, 0) + 1;
				next_delimiter = String13.Find(text, delimiter, position, 0);
				next_opening = String13.Find(text, opening_escape, position, 0);
			}
			return next_delimiter;
		}

		private dynamic instance_atom(Type type = null, dynamic attributes = null, int x = 0, double y = 0, int z = 0) {
			dynamic instance = null;
			Tile T = null;

			GlobalVars._preloader.setup(attributes, type);
			T = Map13.GetTile(x, ((int)(y)), z);

			if (T != null) {
				instance = Lang13.Call(type, T);
			}

			if (Lang13.Bool(GlobalVars.use_preloader) && Lang13.Bool(instance))
			{
				GlobalVars._preloader.load(instance);
			}
			return instance;
		}

		private void add_underlying_turf(dynamic placed = null, dynamic underturf = null, ByTable turfs_underlays = null) {
			if (Lang13.Bool(underturf.density)) {
				placed.density = 1;
			}
			if (Lang13.Bool(underturf.opacity)) {
				placed.opacity = 1;
			}
			placed.underlays += turfs_underlays;
			return;
		}

		private ByTable text2list(string text = null, string delimiter = null) {
			ByTable to_return = null;
			int position = 0;
			int old_position = 0;
			int equal_position = 0;
			string trim_left = null;
			dynamic trim_right = null;
			if (delimiter == null) {
				delimiter = ",";
			}
			to_return = new ByTable();
			old_position = 1;
			while (true) { // Was a do-while, sorry for the mess.
				position = this.find_next_delimiter_position(text, old_position, delimiter);
				equal_position = String13.Find(text, "=", old_position, position);
				trim_left = this.trim_text(String13.SubStr(text, old_position, (equal_position != 0 ? equal_position : position)), true);
				old_position = position + 1;
				if (equal_position != 0) {
					trim_right = this.trim_text(String13.SubStr(text, equal_position + 1, position));
					if (String13.Find(trim_right, this.quote, 1, 2) != 0) {
						trim_right = String13.SubStr(trim_right, 2, String13.Find(trim_right, this.quote, 3, 0));
					}
					else if (Lang13.Bool(Lang13.IsNumber(String13.ParseNumber(trim_right)))) {
						trim_right = String13.ParseNumber(trim_right);
					}
					else if (trim_right == "null") {
						trim_right = null;
					}
					else if (String13.SubStr(trim_right, 1, 5) == "list") {
						trim_right = this.text2list(String13.SubStr(trim_right, 6, Lang13.Length(trim_right)));
					}
					else if (String13.SubStr(trim_right, 1, 2) == "'") {
						trim_right = new File(String13.SubStr(trim_right, 2, Lang13.Length(trim_right)));
					}
					to_return[trim_left] = trim_right;
				}
				else {
					to_return[trim_left] = null;
				}
				if (!(position != 0)) break;
			}
			return to_return;
		}

		private string trim_text(string what = null, bool? trim_quotes = null) {
			if (trim_quotes == null) {
				trim_quotes = false;
			}
			while (Lang13.Length(what) != 0 && String13.Find(what, " ", 1, 2) != 0) {
				what = String13.SubStr(what, 2, 0);
			}
			while (Lang13.Length(what) != 0 && String13.Find(what, " ", Lang13.Length(what), 0) != 0) {
				what = String13.SubStr(what, 1, Lang13.Length(what));
			}
			if (trim_quotes == true) {
				while (Lang13.Length(what) != 0 && String13.Find(what, this.quote, 1, 2) != 0) {
					what = String13.SubStr(what, 2, 0);
				}
				while (Lang13.Length(what) != 0 && String13.Find(what, this.quote, Lang13.Length(what), 0) != 0) {
					what = String13.SubStr(what, 1, Lang13.Length(what));
				}
			}
			return what;
		}
	}
}
