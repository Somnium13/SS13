using System;

// The point of this monstrosity is to replace text macros.
// Som13 will attempt to convert most text macros to string concatenation.
// These are inserted when that fails.
// TODO: Discuss design/redesign of this, see if we can make some kind of custom string class...

namespace Somnium.Engine.ByImpl {
	class Txt {
		private string buffer;
		private object next_item;
		private object last_item;
		
		public Txt(string s = "") {
			buffer = s;
		}

		public override string ToString() {
			return buffer;
		}

		public Txt str(string s) {
			buffer += s;
			return this;
		}

		public Txt item() {
			buffer += next_item;
			return this;
		}

		public Txt item(dynamic d) {
			buffer += d;
			last_item = d;
			return this;
		}

		public Txt st_nd_rd(dynamic d) {
			throw new Exception("x");
			return this;
		}

		public Txt a(dynamic d) {
			buffer += "[a]";
			next_item = d;
			return this;
		}



		public Txt A(dynamic d) {
			throw new Exception("x");
			return this;
		}

		public Txt the(dynamic d) {
			throw new Exception("x");
			return this;
		}

		public Txt The(dynamic d) {
			throw new Exception("x");
			return this;
		}

		public Txt he_she_it_they() {
			throw new Exception("x");
			return this;
		}

		public Txt He_She_It_They() {
			throw new Exception("x");
			return this;
		}

		public Txt his_her_its_their() {
			throw new Exception("x");
			return this;
		}

		public Txt His_Her_Its_Their() {
			throw new Exception("x");
			return this;
		}

		public Txt his_hers_its_theirs() {
			throw new Exception("x");
			return this;
		}

		public Txt His_Hers_Its_Theirs() {
			throw new Exception("x");
			return this;
		}

		public Txt him_her_it_them() {
			throw new Exception("x");
			return this;
		}

		public Txt himself_herself_itself_themself() {
			throw new Exception("x");
			return this;
		}

		public Txt no_newline() {
			throw new Exception("x");
			return this;
		}

		public Txt s() {
			buffer += "[s]";
			return this;
		}

		public Txt proper() {
			throw new Exception("x");
			return this;
		}

		public Txt improper() {
			throw new Exception("x");
			return this;
		}

		public Txt red() {
			throw new Exception("x");
			return this;
		}

		public Txt green() {
			throw new Exception("x");
			return this;
		}

		public Txt blue() {
			throw new Exception("x");
			return this;
		}

		public Txt black() {
			throw new Exception("x");
			return this;
		}

		// Good 'nuff?
		public Txt Ref(object n) {
			
			int h = n.GetHashCode();
			string s = "[0x"+h.ToString("x8")+"]";
			buffer += s;

			return this;
		}

		public Txt icon(dynamic d) {
			throw new Exception("x");
			return this;
		}

		public Txt roman(int n) {
			throw new Exception("x");
			return this;
		}

		public Txt Roman(int n) {
			throw new Exception("x");
			return this;
		}
	}
}
