using System;
using Som13;

namespace Game13 {
	static class Game {
		public const int fps = 10;
		public const int icon_size = 32;
		public static string name;
		public static double time;
		public static double realtime;
		public static System.Collections.IEnumerable _all_ents_() {return null;}
		public static dynamic view;
		public static void write(string s) {}
		public static File log;
		public static int maxx; // note that Som13 should be able to insert the correct values here! todo!
		public static int maxy;
		public static int maxz;
		public static dynamic GetConfig(string s,string k=null) {return null;}
	}
}