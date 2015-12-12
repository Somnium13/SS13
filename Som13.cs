using System;

namespace Som13 {
	static class Main13 {
		static int Main() {
			

			return 0;
		}
	}

	static class Ext13 {
		public static object BTNew(this Type t,ByTable args) {
			return null;
		}
	}

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

		public static String str_sub(string s, int a, int b) {
			return "";
		}

		public static String str_find(string s, string t, int a, int? b) {
			return "";
		}

		public static String html_encode(string s) {
			return "";
		}

		public static String html_decode(string s) {
			return "";
		}
	}

	class ByTable : System.Collections.IEnumerable {
		public ByTable(int len=0) {
			
		}
		
		public ByTable(object[] os) {

		}

		public int len = 0;

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

		public int Find(object o) {
			return 5;
		}

		public ByTable set(object k, object v);
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

	partial class Image {
		public Image(params object[] v) { }

		public int pixel_x;
		public int pixel_y;
	}

	class Client {
		
	}

	class Txt {
		public Txt(string s="") {

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
}