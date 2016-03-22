using System;

namespace Somnium.Engine.ByImpl {

	abstract class Base_Client {
		public string address;
		public bool authenticate;
		public int byond_version = 509;
		public string ckey;
		public dynamic color;
		public string command_text;
		public string computer_id;
		public string connection;
		public int control_freak;
		public string default_verb_category;
		public int dir = 2; // From Client's broken initializer
		public string edge_limit;
		public dynamic eye;
		public string gender;
		public ByTable images;
		public int inactivity;
		public string key;
		public int lazy_eye;
		public Somnium.Game.Mob mob;
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
		public Somnium.Game.Ent_Dynamic statobj;
		public ByTable verbs;
		public int view;
		public Somnium.Game.Ent_Static virtual_eye;

		public void write(dynamic o) { }

		public dynamic call_verb(string n, params object[] o) {
			return null;
		}

		public void Click(Game.Ent_Static ent_Static, dynamic src_location, string src_control, string _params)
		{
			throw new NotImplementedException();
		}

		public virtual bool Move(dynamic loc, int dir) {
			return false;
		}

		public virtual dynamic Stat() {
			return null;
		}

		public virtual void Topic(string href, ByTable href_list, dynamic hsrc) {

		}

		public virtual void Del() {}

		public void WriteMsg(object o) { }

		public dynamic __CallVerb(string n, params object[] o) {
			return null;
		}
	}
}