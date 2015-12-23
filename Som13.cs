using System;

namespace Som13 {
	static class Main13 {
		static int Main() {
			

			return 0;
		}
	}

	/*static class Ext13 {
		public static object BTNew(this Type t,ByTable args) {
			return null;
		}

		public static object BTCall(this System.Reflection.MethodInfo t, ByTable args) {
			return null;
		}
	}*/

	static class Misc13 {
		public static dynamic thread_user;

		public static dynamic execute(string cmd) {
			return null;
		}

		public static void crash(string msg) {
		
		}

		public static void ftp(dynamic a, dynamic b, dynamic c) {

		}

		public static string ckey(dynamic d) {
			return null;
		}

		public static string ckey_preserve_case(dynamic d) {
			return null;
		}

		public static dynamic input(dynamic a, dynamic b, dynamic c, dynamic d, dynamic e, dynamic f) {
			return null;
		}

		public static dynamic alert(dynamic a, dynamic b, dynamic c, dynamic d, dynamic e, dynamic f) {
			return null;
		}

		public static bool isValid(dynamic v) {
			return !(v == null || v == "" || v == 0);
		}

		public static bool isNumber(dynamic v) {
			return (v is int || v is double);
		}

		public static void animate_listcall(ByTable args) {
			
		}

		public static string formatTime(double t, string fmt) {
			return "time";
		}

		// Thought about using a builtin parsing method but not sure how well it will conform. Also, https://facepunch.com/showthread.php?t=1478507
		public static double parseNumber(string n) {
			return 0;
		}

		public static object view(object a, object b) {
			return null;
		}

		public static ByTable viewers(object a, object b) {
			return null;
		}

		public static Type findType(string s) {
			return null;
		}

		public static ByTable types(Type t) {
			return null;
		}

		public static double max(params double[] nums) {
			return 0;
		}

		public static double min(params double[] nums) {
			return 0;
		}

		public static double round(double a, double b) {
			return 0;
		}

		public static int round(double a) {
			return 0;
		}

		public static bool str_cmp(params string[] strs) {
			return false;
		}

		public static string str_sub(string s, int a, int? b) {
			return "";
		}

		public static int str_find(string s, string t, int a, int? b) {
			return 0;
		}

		public static int str_find_exact_case(string s, string t, int a, int? b) {
			return 0;
		}

		public static int str_getCharCode(string a, int n) {
			return 0;
		}

		public static string str_getCharFromCode(int c) {
			return "a";
		}

		public static string str_upper(string a) {
			return a;
		}

		public static string str_lower(string a) {
			return a;
		}

		public static int string_order(string a, string b) {
			return 0;
		}

		public static dynamic turn(dynamic a, int b) {
			return null;
		}

		public static dynamic icon_states(dynamic a, dynamic b) {
			return null;
		}

		public static ByTable rect_contents(dynamic a, dynamic b) {
			return null;
		}

		public static String html_encode(string s) {
			return "";
		}

		public static String html_decode(string s) {
			return "";
		}

		public static void del(dynamic d) {
			
		}

		public static void browse(dynamic a, dynamic b, dynamic c) {
			
		}

		public static void browse_cache_rsc(dynamic a, dynamic b, dynamic c) {

		}

		public static void step(dynamic a, dynamic b) {

		}

		public static void step_towards(dynamic a, dynamic b) {
		
		}

		public static dynamic get_step_towards(dynamic a, dynamic b) {
			return null;
		}

		public static dynamic get_step(dynamic a, dynamic b) {
			return null;
		}

		public static void flick(object a, object b) {

		}

		public static int get_dist(object a, object b) {
			return 0;
		}

		public static System.Reflection.MethodInfo getf2(object a,object b) {
			return null;
		}

		public static string conv_num2text(double a, double b = 6) {
			return "";
		}

		public static ByTable conv_urlParams2list(string a) {
			return null;
		}

		public static string conv_list2urlParams(ByTable t) {
			return "";
		}

		public static object get_in(object a, object b) {
			return null;
		}

		public static object get_turf_at(int x, int y, int z) {
			return null;
		}

		public static object get_obj(string id) {
			return null;
		}

		public static object get_obj(Type zone_type) {
			return null;
		}

		public static void window_set(dynamic a, dynamic b, dynamic c) {

		}

		public static void window_get(dynamic a, dynamic b) {

		}

		public static ByTable range(object a, int range) {
			return null;
		}

		public static ByTable range_nocenter(object a, int range) {
			return null;
		}

		public static dynamic initial(dynamic d) {
			return null;
		}

		public static System.Collections.IEnumerable iter_range(int a, int b) {
			return null;
		}

		public static object call(string t, params object[] objs) { //oh hell
			return null;
		}

		public static object call(Type t, params object[] objs) {
			return null;
		}

		public static object call(System.Reflection.MethodInfo t, params object[] objs) {
			return null;
		}
	}

	static class Thread13 {
		public static void sleep(double t) {
			// oh christ this is going to be ugly
		}

		public delegate void Closure();

		public static void schedule(double t, Closure f) {
			// this will hopefully be less ugly
		}
	}

	static class File13 {
		public static void write(string filename, string data) {

		}

		public static string read(string filename) {
			return "";
		}

		public static bool exists(string filename) {
			return false;
		}

		public static dynamic cache(dynamic a) {
			return null;
		}
	}

	class File {
		public File(string name) {

		}

		public void write(string data) {

		}
	}

	class ByTable : System.Collections.IEnumerable {
		public ByTable(int len=0) {
			
		}
		
		public ByTable(object[] os) {

		}

		public int len = 0;
		public int Length = 0;

		public dynamic this[dynamic x] {
			get {
				return null;
			}
			set {

			}
		}

		public System.Collections.IEnumerator GetEnumerator() {
			return new ByEnum();
		}

		public static ByTable operator -(ByTable a, dynamic b) {
			return new ByTable();
		}

		public static ByTable operator +(ByTable a, dynamic b) {
			return new ByTable();
		}

		public static ByTable operator |(ByTable a, dynamic b) {
			return new ByTable();
		}

		public void write(dynamic o) {

		}

		public void Add(params object[] items) {

		}

		public ByTable Copy(int start = 1, int end = 0) {
			return null;
		}

		public void Cut(int start = 1, int end = 0) {

		}

		public int Find(object o) {
			return 0;
		}

		public int Insert(int i, params object[] items) {
			return 33;
		}

		public bool Remove(params object[] items) {
			return false;
		}

		public void Swap(object k1, object k2) {

		}

		public ByTable set(object k, object v) {
			return this;
		}

		public bool contains(object v) {
			return false;
		}

		public object apply(System.Reflection.MethodInfo f) {
			return null;
		}

		public object applyCtor(Type t) {
			return null;
		}
	}

	class ByEnum : System.Collections.IEnumerator {
		public object Current;
		
		public bool MoveNext() {
			return false;
		}

		public void Reset() {

		}
	}

	class ByRsc {
		public ByRsc(int n) { }
	}

	class ByArea {
		public ByArea(int n) { }
	}

	class Client {
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
		public Mob mob;
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
		public BaseDynamic statobj;
		public ByTable verbs;
		public int view;
		public BaseStatic virtual_eye;


	}

	class Color {
		public Color(int r, int g, int b, int a = 255) {

		}
	}

	class Txt {
		public Txt(string s="") {

		}

		static public implicit operator string(Txt t) {
			return "7";
		}

		public Txt str(string s) {
			return this;
		}

		public Txt item() {
			return this;
		}

		public Txt item(dynamic d) {
			return this;
		}

		public Txt st_nd_rd(dynamic d) {
			return this;
		}

		public Txt a(dynamic d) {
			return this;
		}

		public Txt A(dynamic d) {
			return this;
		}

		public Txt the(dynamic d) {
			return this;
		}

		public Txt The(dynamic d) {
			return this;
		}

		public Txt he_she_it_they() {
			return this;
		}

		public Txt He_She_It_They() {
			return this;
		}

		public Txt his_her_its_their() {
			return this;
		}

		public Txt His_Her_Its_Their() {
			return this;
		}

		public Txt his_hers_its_theirs() {
			return this;
		}

		public Txt His_Hers_Its_Theirs() {
			return this;
		}

		public Txt him_her_it_them() {
			return this;
		}

		public Txt himself_herself_itself_themself() {
			return this;
		}

		public Txt no_newline() {
			return this;
		}

		public Txt s() {
			return this;
		}

		public Txt proper() {
			return this;
		}

		public Txt improper() {
			return this;
		}

		public Txt red() {
			return this;
		}

		public Txt green() {
			return this;
		}

		public Txt blue() {
			return this;
		}

		public Txt black() {
			return this;
		}

		public Txt Ref(dynamic n) {
			return this;
		}

		public Txt icon(dynamic d) {
			return this;
		}

		public Txt roman(int n) {
			return this;
		}

		public Txt Roman(int n) {
			return this;
		}
	}

	class UNKNOWN { }

	static class Rand13 {
		public static dynamic pick(object[] a) {
			return null;
		}

		public static dynamic pick(ByTable a) {
			return null;
		}

		public static dynamic pickWeighted(object[] a) {
			return null;
		}

		public static bool chance(double n) { // should really be an int param, but sometimes was used with a double.
			return true;
		}

		public static int Int(int a, int b) {
			return 0;
		}
	}

	class SaveFile {
		public SaveFile(string filename) {

		}

		public dynamic this[dynamic x] {
			get {
				return null;
			}
			set {

			}
		}

		public string cd;
		public bool eof;
		
		public string read() {
			return "";
		}

		public dynamic dir;
	}

	class BaseGame : System.Collections.IEnumerable {
		public System.Collections.IEnumerator GetEnumerator() {return new ByEnum();}

		public static double time;

		public static double realtime;

		public static int tick_lag;

		public static dynamic view;

		public static ByTable contents;

		public static void write(dynamic o) {}

		public static File log;

		public static int maxx; // note that Som13 should be able to insert the correct values here! todo! (OR NOT, WE WANT DYNAMIC MAP LOADING BUILTIN!)
		public static int maxy;
		public static int maxz;

		public static dynamic GetConfig(string s,string k=null) {return null;}
	}

	partial class BaseData {
		public string tag;
		public Type type;
		public ByTable vars;

		public void Del() { }
		public void Read(SaveFile f) { }
		public void Write(SaveFile f) { }
		public void Topic(dynamic a = null, dynamic b = null) { }
	}

	partial class BaseStatic : BaseData , System.Collections.IEnumerable {
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

		public bool Enter(BaseDynamic O, dynamic old_loc) {
			return false;
		}

		public void Entered(BaseDynamic O, dynamic old_loc) {
			
		}

		public bool Exit(BaseDynamic O, dynamic old_loc) {
			return false;
		}

		public void Exited(BaseDynamic O, dynamic old_loc) {

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

		public void MouseWheel(double delta_x, double delta_y ,dynamic location, dynamic control, dynamic _params) {

		}

		public void Stat() {

		}
	}

	partial class BaseDynamic : BaseStatic {

	}

	partial class Image {
		public Image(params object[] v) { }

		public dynamic loc;
		public int pixel_x;
		public int pixel_y;
	}

	partial class Mob : BaseDynamic {
		public string key;
		public string ckey;
		public Client client;
		
		public void write(dynamic o) {
			string s = "asdasfasfasd";
		}
	}
}