using System;
using System.Collections;

namespace Somnium.Engine.ByImpl {
	abstract class Base_Data {
		public Base_Data() {
			__FieldInit();

			vars = new VarTable(this);
		}

		protected virtual void __FieldInit() {

		}

		public string tag;
		public Type type {
			get {
				return this.GetType();
			}
		}
		public readonly ByTable vars;

		public virtual void Del() { }
		public virtual void Read(SaveFile F, dynamic __id = null, dynamic locorner = null) { }
		public virtual void Write(SaveFile F) { }
		public virtual dynamic Topic(string href = "", ByTable href_list = null, dynamic hsrc = null, Game.HtmlInterface currui = null) { return null; }


		public dynamic __CallVerb(string n, params object[] o) {
			return null;
		}



		class VarTable : ByTable {

			private Base_Data owner;

			public VarTable(Base_Data owner) {
				this.owner = owner;
			}

			public override ArrayList __GetEnumerationList(Type t) {
				throw new Exception("NO.");
			}

			public override IEnumerable __GetRawEnum() {
				return __GetEnumerationList(null);
			}

			protected override void list_init() {

			}

			protected override void list_init_clone(ByTable src) {
				throw new Exception("NO.");
			}

			protected override int list_len() {
				return 0;
			}

			protected override bool list_has(object item) {
				return hash_haskey(item);
			}

			protected override int list_indexof(object item, int start) {
				throw new Exception("NO.");
			}

			protected override object list_get(int i) {
				throw new Exception("NO.");
			}

			protected override void list_set(int i, object item) {
				throw new Exception("NO.");
			}

			protected override void list_add(object item) {
				throw new Exception("NO.");
			}

			protected override void list_insert(int i, object item) {
				throw new Exception("NO.");
			}

			protected override void list_insert_range(int i, ICollection collection) {
				throw new Exception("NO.");
			}

			protected override void list_remove(object item) {
				throw new Exception("NO.");
			}

			protected override void list_remove_range(int i, int count) {
				throw new Exception("NO.");
			}

			/////////

			protected override object hash_get(object key) {
				throw new Exception("NO.");
			}

			protected override void hash_set(object key, object item) {
				var f = get_field(key);
				try {
					f.SetValue(owner, item);
				}
				catch (Exception e) {
					NewLib.Logger.Debug("WARN! COULD NOT SET VALUE VIA VARS: "+owner.GetType()+"."+key+" to "+item);
				}
			}

			protected override void hash_remove(object key) {
				throw new Exception("NO.");
			}

			protected override bool hash_haskey(object key) {
				return get_field(key) != null;
			}

			private System.Reflection.FieldInfo get_field(object key) {
				var skey = key as string;
				if (skey == null)
					throw new Exception("INVALID KEY!");
				var t = owner.GetType();
				return t.GetField(skey);
			}
		}
	}
}
