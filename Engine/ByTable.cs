using System;

namespace Som13 {
	class ByTable : System.Collections.IEnumerable {
		public ByTable(int len = 0) {

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

		public static ByTable operator +(ByTable a, dynamic b) {
			return new ByTable();
		}

		public static ByTable operator -(ByTable a, dynamic b) {
			return new ByTable();
		}

		public static ByTable operator |(ByTable a, dynamic b) {
			return new ByTable();
		}

		public static ByTable operator &(ByTable a, dynamic b) {
			return new ByTable();
		}

		public void write(dynamic o) {

		}

		public void Add(params object[] items) {

		}

		public ByTable Copy(int start = 1, int end = 0) {
			return null;
		}

		public void Cut(int start = 1, int end = 0) {

		}

		public int Find(object o) {
			return 0;
		}

		public int Insert(int i, params object[] items) {
			return 33;
		}

		public bool Remove(params object[] items) {
			return false;
		}

		public void Swap(object k1, object k2) {

		}

		public ByTable set(object k, object v) {
			return this;
		}

		public bool contains(object v) {
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
}
