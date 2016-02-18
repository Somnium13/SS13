using System;
using System.Text.RegularExpressions;

using Somnium.Engine.NewLib;

namespace Somnium.Engine.ByImpl {

	static class String13 {
		
		// Not case sensitive.
		public static int GetOrder(params string[] args) { // this is hopefully good :/
			if (args.Length < 2) {
				throw new Exception("Need at least two strings to compare!");
			}

			// confirmed empty siring == null
			int order =  Math.Sign(String.Compare(args[0] ?? "", args[1] ?? "", true));
			
			for (int i = 1; i < args.Length-1; i++) {
				int next_order = Math.Sign(String.Compare(args[i] ?? "", args[i+1] ?? "", true));
				if (next_order != order) {
					if (order == 0) {
						order = next_order;
					}
					else if (next_order != 0) {
						return 0;
					}
				}
			}

			return -order;
		}

		// Not case sensitive.
		public static bool CompareIgnoreCase(string a, string b) {
			return a.ToLower()==b.ToLower();
		}

		// Not case sensitive.
		public static int FindIgnoreCase(string haystack, string needle, int start = 1, int end = 0) {
			if (haystack != null)
				haystack = haystack.ToLower();
			if (needle != null)
				needle = needle.ToLower();
			return Find( haystack, needle, start, end);
		}

		// Attempted to make more efficient, do not know if it still conforms!
		public static int Find(string haystack, string needle, int start = 1, int end = 0) {
			// Confirmed for all combinations of null.
			if (needle == null)
				return 1;
			if (haystack == null)
				return 0;

			if (start < 0)
				start = haystack.Length + 1 + start;
			else if (start == 0)
				return 0;

			if (end < 0)
				end = haystack.Length + 1 + end;

			int index;
			if (end == 0)
				index = haystack.IndexOf(needle, start-1);
			else
				index = haystack.IndexOf(needle, start-1, end - start); // I am not sure if this still conforms! TODO VERIFY!
			
			index++;

			return index;
		}


		public static string SubStr(string source, int start = 1, int end = 0) {
			if (source == null || start < 1 || start > source.Length || end < 0 || end > source.Length + 1)
				return ""; // verified that empty string is returned if args are invalid!
			else if (end == 0) {
				return source.Substring((int)start-1);
			}
			return source.Substring((int)start - 1, (int)end - (int)start);
		}

		public static string ToUpper(string a) {
			return a.ToUpper();
		}

		public static string ToLower(string a) {
			return a.ToLower();
		}

		public static string NumberToString(double a, int sf = 6) {
			Logger.Debug("->String13.numberToString");
			return "";
		}

		public static int GetCharCode(string a, int? i = null) {
			if (i == null) i = 1;
			i--;
			if (i < 0 || i >= a.Length) {
				return 0;
			}
			return (int)(a[(int)i]);
		}

		public static string GetCharFromCode(int n) { // TODO VERIFY BEHAVIOR!
			char c = (char)n;
			return c.ToString();
		}

		public static string ColorCode(int r, int g, int b, int a = 255) {
			Logger.Debug("->String13.color_code");
			return "#000";
		}


		

		public static string FormatTime(double time, string fmt) {
			DateTime date;

			if (time <= 864000) // R U FUCKING KIDDING ME? http://www.byond.com/forum/?post=72549
				date = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
			else
				date = new DateTime(2000, 1, 1);

			date = date.AddSeconds(time / 10);
			
			date = date.ToLocalTime(); // This takes a UTC time! Convert to local time!

			// This is a pretty stupid way to do this but I'm over it at this point.
			fmt = fmt.Replace("Month", "MMMM");
			fmt = fmt.Replace("Day", "dddd");
			fmt = fmt.Replace('Y', 'y');
			fmt = fmt.Replace('D', 'd');
			fmt = fmt.Replace('h', 'H');

			//Console13.debug("->String13.formatTime: " + time + " + " + fmt + " --> "+ date.ToString(fmt));
			return date.ToString(fmt);
		}

		// Thought about using a builtin parsing method but not sure how well it will conform. Also, https://facepunch.com/showthread.php?t=1478507
		// Also, some idiots were calling this with numbers...
		// THIS IS FAR FROM PERFECT!
		// MUST TEST MORE TO SEE HOW IT SHOULD BEHAVE!
		public static double? ParseNumber(dynamic n) { // TODO RE-WORK
			try {
				return Double.Parse(n);
			} catch (Exception) {
				return null;
			}
		}

		public static string MakeUrlParams(ByTable b) {
			Logger.Debug("->String13.conv_list2urlParams");
			return "";
		}

		public static ByTable ParseUrlParams(string t) {
			Logger.Debug("->String13.conv_urlParams2list");
			return new ByTable();
		}

		public static string HtmlEncode(dynamic a) { //usually passed strings, some fuckboy gave it a double tho
			Logger.Debug("->String13.html_encode");
			return "";
		}

		public static string HtmlDecode(string a) {
			Logger.Debug("->String13.html_decode");
			return "";
		}

		public static string UrlEncode(string a, bool format) {
			Logger.Debug("->String13.url_encode");
			return "";
		}

		public static string UrlDecode(string a) {
			Logger.Debug("->String13.url_decode");
			return "";
		}

		public static string CKey(string a) {

			return new Regex(@"[^0-9a-z@]").Replace(a.ToLower(), "");
		}

		public static string CKeyPreserveCase(string a) {

			return new Regex(@"[^0-9a-zA-Z@_-]").Replace(a, "");
		}

		// This is supposed to take varargs but the only generated code that uses it only uses two args.
		public static string Concat(string p1, string p2) {
			return p1 + p2;
		}
	}
}
