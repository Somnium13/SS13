using System;

namespace Somnium.Engine.NewLib {
	static class Logger {

		public static void Announce(string s) {
			internal_print(s, ConsoleColor.Green);
		}

		public static void Debug(string s) {
			internal_print(s, ConsoleColor.DarkGreen);
		}

		public static void Debug2(string s)
		{
			internal_print(s, ConsoleColor.DarkGreen);
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

		public static void LogNet(string s)
		{
			internal_print(s, ConsoleColor.Yellow);
		}

		public static void Error(string info, Exception e) {
			while (e.InnerException != null)
				e = e.InnerException;
			
			string s = new String('=', Console.WindowWidth) + "\n" + info;
			s += "\n" + new String('-', Console.WindowWidth);
			s += "\n" + e.Message;
			s += "\n" + new String('-', Console.WindowWidth);
			s += "\n" + e.StackTrace;
			s += "\n" + new String('=', Console.WindowWidth);

			ServiceDev.NotifyIssue(true,e.Message+"\n"+e.StackTrace, info);

			internal_print(s, ConsoleColor.Red, false);
		}

		public static void Warning(string title, string misc)
		{
			ServiceDev.NotifyIssue(false, title, misc);
			internal_print(title + " " + misc, ConsoleColor.DarkYellow);
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
