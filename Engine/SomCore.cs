using System;

namespace SomEngine {


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
		public SomGame.Mob mob;
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
		public SomGame.BaseDynamic statobj;
		public ByTable verbs;
		public int view;
		public SomGame.BaseStatic virtual_eye;

		public void write(dynamic o) { }

		public dynamic call_verb(string n, params object[] o) {
			return null;
		}
	}

	class CoreData {
		public string tag;
		public Type type;
		public ByTable vars;

		public void Del() { }
		public void Read(SaveFile f) { }
		public void Write(SaveFile f) { }
		public void Topic(dynamic a = null, dynamic b = null) { }

		public dynamic call_verb(string n, params object[] o) {
			return null;
		}
	}

	class CoreStatic : SomGame.BaseData, System.Collections.IEnumerable {
		public CoreStatic(dynamic loc) {
			this.loc = loc;
		}
		
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
		public string icon;
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
		public SomGame.Matrix transform;
		public ByTable underlays;
		public ByTable verbs;
		public int x;
		public int y;
		public int z;

		public void Click(dynamic location, dynamic control, dynamic _params) {

		}

		public void DblClick(dynamic location, dynamic control, dynamic _params) {

		}

		public bool Enter(SomGame.BaseDynamic O, dynamic old_loc) {
			return false;
		}

		public void Entered(SomGame.BaseDynamic O, dynamic old_loc) {

		}

		public bool Exit(SomGame.BaseDynamic O, dynamic old_loc) {
			return false;
		}

		public void Exited(SomGame.BaseDynamic O, dynamic old_loc) {

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

	class CoreDynamic : SomGame.BaseStatic {
		public CoreDynamic(object loc) : base(loc) { }
	}

	partial class CoreImage {
		public CoreImage(params object[] v) { }

		public SomGame.BaseStatic loc;
		public int pixel_x;
		public int pixel_y;
	}

	partial class CoreMob : SomGame.Entity {
		public string key;
		public string ckey;
		public SomGame.Client client;

		public void write(dynamic o) {}
	}
}