namespace Som13 {
	class Som13 {
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
		
		public ByTable(dynamic[] o) {

		}

		public int gert() {
			return 5;
		}

		public ByTable set(object k, object v);
	}

	class Client {
		
	}

	class UNKNOWN { }
}