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

		public static string formatTime(double t, string fmt) {
			return "time";
		}

		// Thought about using a builtin parsing method but not sure how well it will conform. Also, https://facepunch.com/showthread.php?t=1478507
		public static double parseNumber(string n) {
			return 0;
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

		public static String str_sub(string s, int a, int? b) {
			return "";
		}

		public static String str_find(string s, string t, int a, int? b) {
			return "";
		}

		public static int str_getCharCode(string a, int n) {
			return 0;
		}

		public static int string_order(string a, string b) {
			return 0;
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

		public static dynamic initial(dynamic d) {
			return null;
		}

		public static System.Collections.IEnumerator iter_range(int a, int b) {
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

		public void Add(params object[] items) {

		}

		public ByTable Copy(int start = 1, int end = 0) {
			return null;
		}

		public int Find(object o) {
			return 0;
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
	}

	class UNKNOWN { }

	static class Rand {
		public static object pick(object[] a) {
			return null;
		}

		public static object pick(ByTable a) {
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
	}

	partial class Image {
		public Image(params object[] v) { }

		public int pixel_x;
		public int pixel_y;
	}

	partial class BaseStatic : Game13.Base13 {
		public int dir;
		public Game13.Icon icon;
		public string icon_state;
		public int layer;
	}
}