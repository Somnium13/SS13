using System;

namespace Somnium.Engine.NewLib {
	static class Logger {

		public static void Announce(string s) {
			internal_print(s, ConsoleColor.Green);
		}

		public static void Debug(string s) {
			internal_print(s, ConsoleColor.DarkYellow);
		}

		public static void Log(string s) {
			internal_print(s, ConsoleColor.Gray);
		}

		public static void LogFile(string s) {
			internal_print(s, ConsoleColor.Cyan);
		}

		public static void LogScheduler(string s) {
			internal_print(s, ConsoleColor.Magenta);
		}

		public static void Error(string s, Exception e) {
			while (e.InnerException != null)
				e = e.InnerException;
			
			s = new String('=', Console.WindowWidth) + "\n" + s;
			s += "\n" + new String('-', Console.WindowWidth);
			s += "\n" + e.Message;
			s += "\n" + new String('-', Console.WindowWidth);
			s += "\n" + e.StackTrace;
			s += "\n" + new String('=', Console.WindowWidth);

			internal_print(s, ConsoleColor.Red, false);
		}

		private static void internal_print(string s, ConsoleColor color, bool strip_newlines = true) {
			ConsoleColor oldcolor = Console.ForegroundColor;
			
			Console.ForegroundColor = color;

			if (strip_newlines)
				s = s.Replace("\n", "").Replace("\r", "");

			Console.WriteLine( s ); // yes i know this is ugly
			
			Console.ForegroundColor = oldcolor;
		}
	}
}
