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

	abstract class Base_Dynamic : Somnium.Game.Ent_Static {
		public Base_Dynamic(object loc) {
			this.loc = loc;
			this._contents = new EntContentsTable(this);
		}

		public override int x {
			get { return _loc.x; }
			set { throw new Exception("TODO"); }
		}

		public override int y {
			get { return _loc.y; }
			set { throw new Exception("TODO"); }
		}

		public override int z {
			get { return _loc.z; }
			set { throw new Exception("TODO"); }
		}

		public int glide_size;

		public int bound_width;
		public int bound_height;

		public string screen_loc;

		public virtual bool Move(dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0) {
			return false;
		}

		public virtual dynamic Bump(Game.Ent_Static Obstacle = null, dynamic yes = null) {
			return null;
		}

		public virtual dynamic Crossed(Game.Ent_Dynamic O = null, dynamic X = null) {
			return null;
		}

		public virtual dynamic Uncrossed(Game.Ent_Dynamic O = null) {
			return null;
		}
	}

	abstract partial class Base_Image : Somnium.Game.Data { // many of these vars are the same as static, but this is supposed to inherit from data
		public Base_Image(params object[] v) { }

		public Somnium.Game.Ent_Static loc;

		public bool v_override;

		// Everything to do with appearance:
		public Appearance appearance;
		public int appearance_flags;
		public int alpha;
		public int blend_mode;
		public string color;
		public string desc;
		public string gender;
		public string icon;
		public string icon_state;
		public int invisibility;
		public double infra_luminosity;
		public double layer; // verified. must be double. fixme in translator!
		public double luminosity;
		public string maptext;
		public int maptext_width;
		public int maptext_height;
		public int maptext_x;
		public int maptext_y;
		public dynamic mouse_over_pointer;
		public dynamic mouse_drag_pointer;
		public dynamic mouse_drop_pointer;
		public bool mouse_drop_zone;
		public int mouse_opacity;
		public string name;
		public bool opacity;

		private ByTable _overlays = new ByTable();
		public dynamic overlays {
			get {
				return _overlays;
			}
			set {
				if (value is int) {
					_overlays.len = value;
				}
				else if (value is ByTable)
					_overlays = value; // todo- redo if a special table!
				else {
					throw new Exception("WAT");
				}
			}
		}

		public int pixel_x;
		public int pixel_y;
		public int pixel_z;
		public int plane;
		public string suffix;
		public string text;
		public Somnium.Game.Matrix transform;
		public ByTable underlays = new ByTable();
	}

	abstract partial class Base_Mob : Somnium.Game.Obj {
		public Game.Client client;
		
		public string ckey;
		public string key;

		//public ByTable group;

		public int see_in_dark;
		public bool see_infrared;
		public int see_invisible;
		public int sight;

		public Base_Mob(object loc) : base(loc) {

		}

		public virtual dynamic Login() {
			return null;
		}

		public virtual bool Logout() {
			return false; //what should this return by default? what does the return value even DO?
		}

		public void WriteMsg(object o) {}
	}
}