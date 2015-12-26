namespace SomEngine {
	class File {
		public File(string name) {

		}

		public void write(string data) {

		}
	}

	class Txt {
		public Txt(string s = "") {

		}

		static public implicit operator string(Txt t) {
			return "7";
		}

		public Txt str(string s) {
			return this;
		}

		public Txt item() {
			return this;
		}

		public Txt item(dynamic d) {
			return this;
		}

		public Txt st_nd_rd(dynamic d) {
			return this;
		}

		public Txt a(dynamic d) {
			return this;
		}

		public Txt A(dynamic d) {
			return this;
		}

		public Txt the(dynamic d) {
			return this;
		}

		public Txt The(dynamic d) {
			return this;
		}

		public Txt he_she_it_they() {
			return this;
		}

		public Txt He_She_It_They() {
			return this;
		}

		public Txt his_her_its_their() {
			return this;
		}

		public Txt His_Her_Its_Their() {
			return this;
		}

		public Txt his_hers_its_theirs() {
			return this;
		}

		public Txt His_Hers_Its_Theirs() {
			return this;
		}

		public Txt him_her_it_them() {
			return this;
		}

		public Txt himself_herself_itself_themself() {
			return this;
		}

		public Txt no_newline() {
			return this;
		}

		public Txt s() {
			return this;
		}

		public Txt proper() {
			return this;
		}

		public Txt improper() {
			return this;
		}

		public Txt red() {
			return this;
		}

		public Txt green() {
			return this;
		}

		public Txt blue() {
			return this;
		}

		public Txt black() {
			return this;
		}

		public Txt Ref(dynamic n) {
			return this;
		}

		public Txt icon(dynamic d) {
			return this;
		}

		public Txt roman(int n) {
			return this;
		}

		public Txt Roman(int n) {
			return this;
		}
	}

	class SaveFile {
		public SaveFile(string filename) {

		}

		public dynamic this[dynamic x] {
			get {
				return null;
			}
			set {

			}
		}

		public string cd;
		public bool eof;

		public string read() {
			return "";
		}

		public dynamic dir;
	}
}
