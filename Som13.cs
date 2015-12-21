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

		public static dynamic ckey(dynamic d) {
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

		public static double round(double a) {
			return 0;
		}

		public static string str_sub(string s, int a, int? b) {
			return "";
		}

		public static string str_find(string s, string t, int a, int? b) {
			return "";
		}

		public static string str_find_exact_case(string s, string t, int a, int? b) {
			return "";
		}

		public static int str_getCharCode(string a, int n) {
			return 0;
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

		public static dynamic get_step_towards(dynamic a, dynamic b) {
			return null;
		}

		public static dynamic get_step(dynamic a, dynamic b) {
			return null;
		}

		public static void flick(object a, object b) {

		}

		public static System.Reflection.MethodInfo getf2(object a,object b) {
			return null;
		}

		public static string conv_num2text(double a, double b = 6) {
			return "";
		}

		public static ByTable conv_params2list(dynamic a) {
			return null;
		}

		public static object locate_in(object a, object b) {
			return null;
		}

		public static object get_turf_at(int x, int y, int z) {
			return null;
		}

		public static ByTable range(object a, object b) {
			return null;
		}

		public static dynamic initial(dynamic d) {
			return null;
		}

		public static System.Collections.IEnumerable iter_range(int a, int b) {
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

		public void write(string s) {

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

		public bool HasValue(object v) {
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
		public Game13.BaseDynamic statobj;
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

		public dynamic item(dynamic d) {
			return null;
		}

		public dynamic icon(dynamic d) {
			return null;
		}

		public dynamic Ref(dynamic n) {
			return null;
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

		public static bool chance(int n) {
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

	partial class BaseData {
		public string tag;
		public static Type type;
		public ByTable vars;

		public void Del() { }
		public void Read(SaveFile f) { }
		public void Write(SaveFile f) { }
		public void Topic(dynamic a, dynamic b) { }
	}

	partial class BaseStatic : BaseData , System.Collections.IEnumerable {
		public System.Collections.IEnumerator GetEnumerator() {
			return new ByEnum();
		}

		public bool density;
		public int dir;
		
		public Game13.Icon icon;
		public string icon_state;
		
		public int layer;
		public dynamic loc;

		public string name;

		public ByTable overlays;

		public Game13.Matrix transform;

		public int x;
		public int y;
		public int z;
	}

	partial class Image {
		public Image(params object[] v) { }

		public dynamic loc;
		public int pixel_x;
		public int pixel_y;
	}

	partial class Mob : Game13.BaseDynamic {
		public string ckey;
		public Client client;
		
		public void write(string s) {

		}
	}
}