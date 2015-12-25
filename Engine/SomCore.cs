using System;

namespace Som13 {




	class CoreGame {
		//public System.Collections.IEnumerator GetEnumerator() {return new ByEnum();}

		public static double time;

		public static double realtime;

		public static int tick_lag;

		public static dynamic view;

		public static ByTable contents;

		public static void write(dynamic o) { }

		public static File log;

		public static int maxx; // note that Som13 should be able to insert the correct values here! todo! (OR NOT, WE WANT DYNAMIC MAP LOADING BUILTIN!)
		public static int maxy;
		public static int maxz;

		public static dynamic GetConfig(string s, string k = null) { return null; }
	}

	class CoreClient {
		public string address;
		public bool authenticate;
		public int byond_version = 666;
		public string ckey;
		public dynamic color;
		public string command_text;
		public string computer_id;
		public string connection;
		public int control_freak;
		public string default_verb_category;
		public int dir;
		public string edge_limit;
		public dynamic eye;
		public string gender;
		public ByTable images;
		public int inactivity;
		public string key;
		public int lazy_eye;
		public Game13.Mob mob;
		public dynamic mouse_pointer_icon;
		public int perspective;
		public int pixel_x;
		public int pixel_y;
		public int pixel_z;
		public int pixel_step_size; //dep?
		public dynamic preload_rsc;
		public ByTable screen;
		public string script;
		public bool show_map;
		public bool show_popup_menus;
		public bool show_verb_panel;
		public Game13.BaseDynamic statobj;
		public ByTable verbs;
		public int view;
		public Game13.BaseStatic virtual_eye;
	}

	class CoreData {
		public string tag;
		public Type type;
		public ByTable vars;

		public void Del() { }
		public void Read(SaveFile f) { }
		public void Write(SaveFile f) { }
		public void Topic(dynamic a = null, dynamic b = null) { }
	}

	class CoreStatic : Game13.BaseData, System.Collections.IEnumerable {
		public System.Collections.IEnumerator GetEnumerator() {
			return new ByEnum();
		}

		public int alpha;
		public dynamic appearance;
		public int appearance_flags;
		public int blend_mode;
		public dynamic color;
		public ByTable contents;
		public bool density;
		public string desc;
		public int dir;
		public string gender;
		public Game13.Icon icon;
		public string icon_state;
		public int infra_luminosity;
		public int invisibility;
		public int layer;
		public dynamic loc;
		public int luminosity;
		public string maptext;
		public int maptext_width;
		public int maptext_height;
		public int maptext_x;
		public int maptext_y;
		public int mouse_drag_pointer;
		public int mouse_drop_pointer;
		public int mouse_drop_zone;
		public int mouse_opacity;
		public int mouse_over_pointer;
		public string name;
		public bool opacity;
		public ByTable overlays;
		//override wat?
		public int pixel_x;
		public int pixel_y;
		public int pixel_z;
		public int plane;
		public string suffix;
		public string text;
		public Game13.Matrix transform;
		public ByTable underlays;
		public ByTable verbs;
		public int x;
		public int y;
		public int z;

		public void Click(dynamic location, dynamic control, dynamic _params) {

		}

		public void DblClick(dynamic location, dynamic control, dynamic _params) {

		}

		public bool Enter(Game13.BaseDynamic O, dynamic old_loc) {
			return false;
		}

		public void Entered(Game13.BaseDynamic O, dynamic old_loc) {

		}

		public bool Exit(Game13.BaseDynamic O, dynamic old_loc) {
			return false;
		}

		public void Exited(Game13.BaseDynamic O, dynamic old_loc) {

		}

		public void MouseDown(dynamic location, dynamic control, dynamic _params) {

		}

		public void MouseDrag(dynamic over_obj, dynamic src_loc, dynamic over_loc, dynamic src_control, dynamic over_control, dynamic _params) {

		}

		public void MouseDrop(dynamic over_obj, dynamic src_loc, dynamic over_loc, dynamic src_control, dynamic over_control, dynamic _params) {

		}

		public void MouseEntered(dynamic location, dynamic control, dynamic _params) {

		}

		public void MouseExited(dynamic location, dynamic control, dynamic _params) {

		}

		public void MouseMove(dynamic location, dynamic control, dynamic _params) {

		}

		public void MouseUp(dynamic location, dynamic control, dynamic _params) {

		}

		public void MouseWheel(double delta_x, double delta_y, dynamic location, dynamic control, dynamic _params) {

		}

		public void Stat() {

		}
	}

	class CoreDynamic : Game13.BaseStatic {

	}

	partial class CoreImage {
		public CoreImage(params object[] v) { }

		public Game13.BaseStatic loc;
		public int pixel_x;
		public int pixel_y;
	}

	partial class CoreMob : Game13.Entity {
		public string key;
		public string ckey;
		public Game13.Client client;

		public void write(dynamic o) {
			string s = "asdasfasfasd";
		}
	}
}