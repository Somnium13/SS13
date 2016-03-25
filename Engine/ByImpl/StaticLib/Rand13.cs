using System;

using Somnium.Engine.NewLib;

namespace Somnium.Engine.ByImpl {
	static class Rand13 {
		static private Random internal_random = new Random();

		public static dynamic Pick(object[] a) {
			object picked = a[internal_random.Next(a.Length)];
			return picked;
		}

		public static dynamic PickFromTable(ByTable a) {
			if (a.len < 1)
				return null;

			object picked = a[internal_random.Next(a.len)+1];
			return picked;
		}

		public static dynamic PickFromTable(dynamic a) { // some dumb pubbie tried to call this with some random value, wtf?
			Logger.Debug("rand->pick-wtf");
			return a;
		}

		public static dynamic PickWeighted(object[] a) { // this is very ugly because it is a direct analog to the way things work internally. I didn't bother to make it pretty (yet), and possibly won't.
			if (a.Length % 2 != 0) {
				throw new Exception("WEIGHTED PICK MUST HAVE AN EVEN NUMBER OF ITEMS!");
			}
			
			int n = internal_random.Next(65535);

			for (int i = 0; i < a.Length; i += 2) {
				int prob = Convert.ToInt32(a[i]);
				if (n < prob)
					return a[i + 1];
			}

			throw new Exception("This should never happen!");
		}

		// STUB
		public static dynamic PickWeightedDynamic(object[] a, object _default) {
			return null;
		}

		public static bool PercentChance(int n) {
			return internal_random.NextDouble() < n / 100;
		}

		public static int Int(int a) {
			return internal_random.Next((int)a+1);
		}

		public static int Int(int a, int b) {
			return internal_random.Next((int)a,(int)b+1);
		}

		public static double Float() {
			return internal_random.NextDouble();
		}
	}
}
