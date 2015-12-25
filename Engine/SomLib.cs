using System;

namespace Som13 {
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

		public static String html_encode(dynamic d) { // damn commies passing numbers and shit to this...
			string s = d as string;
			if (s == null)
				return null;
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

		public static System.Reflection.MethodInfo getf2(object a, object b) {
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
}
