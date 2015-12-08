namespace Core13 {
	static class Main13 {
		static int Main() {
			System.Reflection.MethodInfo t = typeof(ByTable).GetMethod("gert");

			ByTable bt = new ByTable();

			System.Console.WriteLine(t.Invoke(bt,new object[] {}));

			while (true);

			return 0;
		}
	}

	class ByTable {
		public ByTable() {
			
		}
		
		public ByTable(object[] os) {

		}

		public int Find(object o) {
			return 5;
		}

		public ByTable set(object k, object v);
	}

	class Client {
		
	}

	class UNKNOWN { }

	static class Rand {
		public static object pick(object[] a) {
			return null;
		}

		public static bool chance(int n) {
			return true;
		}
	}
}