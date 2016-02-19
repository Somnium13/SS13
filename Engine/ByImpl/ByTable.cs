using System;
using System.Collections;

using Somnium.Engine.NewLib;

/*
 * 
 * This is by far, the most broken data structure I have ever encountered.
 * At first I thought it was like a Lua table. It isn't.
 * I honestly have a hard time believing a real person designed it.
 * You should never actually use this for new code.
 * 
 * It works as follows:
 *
 * Note that numeric values should always be converted using some goofy logic.
 * 
 * Note that it is perfectly fine for null to be a key!
 * 
 * When indexed with a number, n:
 *		- n = floor(n)
 *		- The new number must be within [1..len], or an exception is thrown.
 *		- If writing, and the VALUE at the index n is in the hash, delete it from the hash.
 * 
 * When indexed with a non-number, k:
 *		- If reading, return null if k is not in the hash. Never throw an exception.
 *		- If writing, and k is not in the LIST, append k to the end of the list.
 *		- If writing, set hash[k] = v.
 * 
 * 
 * 
 * Room for optimizations:
 *		- Fold type checking into Enumerate function.
 *		- Don't create the hash unless we have to -- it is rarely used! [DONE!]
 */

namespace Somnium.Engine.ByImpl {
	class ByTable { // : IEnumerable {
		// Stupid hack for null keys
		private class NullKey {
			public override string ToString() {
				return "null";
			}
		}
		private static NullKey NULL_KEY = new NullKey();
		
		// Ctors -- They generally don't directly edit stuff and don't appear to have problems!
		public ByTable(double? length = null) {
			if (length == null)
				length = 0;
			list_init();
			len = (int)length;
		}

		public ByTable(double? dim1, params double?[] dims) { // This could probably be implemented better!
			list_init();

			if (dim1 == null)
				throw new Exception("A dimension on this already idiotic ByTable CTOR is null. Wut."); // TODO VERIFY WHAT ACTUALLY HAPPENS WHEN THIS GETS BORKD

			len = (int)dim1;

			// A stack to hold unfinished tables.
			var parents = new [] { this };
			int parent_dim = (int)dim1;

			foreach (double? d in dims) {
				if (d == null)
					throw new Exception("A dimension on this already idiotic ByTable CTOR is null. Wut."); // TODO VERIFY WHAT ACTUALLY HAPPENS WHEN THIS GETS BORKD

				var parents_temp = new ByTable[parents.Length*parent_dim];

				for (int pi = 0; pi < parents.Length; pi++) {
					for (int ii = 0; ii < parent_dim; ii++) {
						var new_tbl = new ByTable((int)d);
						parents[pi][ii + 1] = new_tbl;
						parents_temp[pi * parent_dim + ii] = new_tbl;
					}
				}

				parents = parents_temp;
				parent_dim = (int)d;
			}
		}

		public ByTable(ByTable src) { // We better be wanting a shallow copy here... TODO VERIFY
			list_init_clone(src);
			if (src.hash != null && src.hash.Count>0)
				hash = (Hashtable)src.hash.Clone();
		}

		public ByTable(object[] os) {
			list_init();
			this.Extend(os); // This will automatically convert bools for us.
		}

		// Change list length, deleting elements or adding nulls at the end.
		public int len {
			get { return list_len(); }
			set {
				int current_len = list_len();
				if (value < 0) {
					throw new Exception("Cannot set ByTable length less than 0.");
				}
				else if (current_len == value) {
					return;
				}
				// We need to shorten the list.
				else if (current_len > value) {
					// Delete values for all the keys we delete. I have verified that it works like this.
					for (int i = value + 1; i <= current_len; i++) {
						object k = list_get(i);
						if (hash != null)
							hash.Remove(k ?? NULL_KEY);
					}
					list_remove_range(value + 1, current_len - value);
				}
				// We need to lengthen it!
				else {
					for (int i = 0; i < value - current_len; i++) {
						list_add(null);
					}
				}
			}
		}

		// See the block comment at the top for an explanation of this mess.
		public dynamic this[object k] {
			get { // Getter doesn't need to do any dumb value conversions, or call any notification crap.
				if (Lang13.IsNumber(k)) {
					int k_int = Convert.ToInt32(k);
					if (k_int < 1 || k_int > list_len())
						throw new Exception("ByTable index out of range.");
					return list_get(k_int);
				}
				else {
					return hash_get(k);
				}
			}
			set {
				if (Lang13.IsNumber(value)) { // all numeric values to doubles
					value = convert_number(value);
				}
				if (Lang13.IsNumber(k)) {
					int k_int = Convert.ToInt32(k);
					if (k_int < 1 || k_int > list_len())
						throw new Exception("ByTable index out of range.");

					// Remove the old hash value!
					object removal_key = list_get(k_int);
					hash_remove(removal_key);

					list_set(k_int, value);
				}
				else {
					if (!list_has(k)) {
						list_add(k);
					}
					hash_set(k, value);
				}
			}
		}

		// All of these operators are horribly inefficient. They are replaced wherever possible!
		public static ByTable operator +(ByTable a, object b) {
			var new_table = new ByTable(a);
			new_table.Add(b);
			return new_table;
		}

		public static ByTable operator -(ByTable a, object b) {
			var new_table = new ByTable(a);
			new_table.Remove(b);
			return new_table;
		}

		public static ByTable operator |(ByTable a, object b) {
			var new_table = new ByTable(a);
			new_table.Or(b);
			return new_table;
		}

		public static ByTable operator &(ByTable a, object b) {
			var new_table = new ByTable(a);
			new_table.And(b);
			return new_table;
		}

		public static ByTable operator ^(ByTable a, object b) {
			var new_table = new ByTable(a);
			new_table.Xor(b);
			return new_table;
		}

		// The transpiler will attempt to use these (as well as Add/Remove) where possible, since they don't create garbage and won't break references.
		public void Or(object item) {
			if (item is ByTable) {
				var tab = (ByTable)item;
				foreach (var k in tab.list) {
					if (!list_has(k)) {
						list_add(k);
						var v = tab.hash_get(k);
						if (tab.hash_haskey(k))
							this.hash_set(k, tab.hash_get(k));
					}
				}
			}
			else {
				if (Lang13.IsNumber(item))
					item = convert_number(item);

				if (!list_has(item)) {
					list_add(item);
				}
			}
		}

		public void And(object item)
		{
			if (item is ByTable)
			{
				var other_list = ((ByTable)item).__GetEnumerationList(null);

				for (int i= len; i>=1; i--)
				{
					object v = this[i];

					int i2 = other_list.IndexOf(v);

					if (i2!=-1) // Keep it!
					{
						other_list.RemoveAt(i2);
					} else // Ditch it!
					{
						hash_remove(v);
						list_remove_range(i,1);
					}
				}
			}
			else { // I have no idea why this would ever be used, but let's roll with it. (confirmed behavior)
				if (Lang13.IsNumber(item))
					item = convert_number(item);

				bool has_item = list_has(item);

				len = 0;

				if (has_item)
					list_add(item);
			}
		}

		// TODO -- REMEMBER BOOL, NULL
		public void Xor(object item) {
			throw new Exception("TODO LIST XOR");
		}

		public void WriteMsg(dynamic o) { // TODO
			Logger.Debug("WRITE to table.");
		}

		public void Add(params object[] items) {
			if (items == null)
				items = new object[] { null };

			foreach (var item in items) {
				if (Lang13.IsNumber(item)) {
					object item2 = convert_number(item);
					list_add(item2);
				}
				else if (item is ByTable) { // we need to add the items from the other list...
					ByTable tab = (ByTable)item;

					foreach (var k in tab.__GetRawEnum()) {
						list_add(k);
						if (tab.hash_haskey(k))
							this.hash_set(k, tab.hash_get(k));
					}
				}
				else {
					list_add(item);
				}
			}
		}

		public bool Remove(params object[] items) {
			if (items == null)
				items = new object[] { null };
			
			bool modified = false;
			
			foreach (var item in items) {
				if (item is ByTable) {
					foreach (var item2 in ((ByTable)item).list) {
						if (internal_remove(item2)) modified = true;
					}
				}
				else {
					if (internal_remove(item)) modified = true;
				}
			}
			return modified;
		}

		private bool internal_remove(object item) {
			if (Lang13.IsNumber(item))
				item = convert_number(item);

			if (list_has(item)) {
				list_remove(item);
				hash_remove(item);

				return true;
			}
			return false;
		}

		public ByTable Copy(int? start = null, int end = 0) {
			if (start == null || start == 0) // confirmed that setting start to zero basically has this effect
				start = 1;

			if (start < 0 || end < 0) { // Confirmed negative args not ok here.
				throw new Exception("Bad Cut args: " + start + ", " + end);
			}

			if (end == 0)
				end = list.Count + 1;

			ByTable copied = new ByTable();
			for (int i = (int)(start); i < end; i++) {
				object item = list_get(i);
				copied.list_add(item);
				if (hash_haskey(item)) {
					copied.hash_set(item, hash_get(item));
				}
			}

			return copied;
		}

		// not much that can go wrong here, as far as bool/null fuckery goes
		public void Cut(int? start = null, int end = 0) {
			if (start == null || start==0) // confirmed that setting start to zero basically has this effect
				start = 1;
			
			if (start < 0 || end < 0) { // Confirmed negative args not ok here.
				throw new Exception("Bad Cut args: "+start+", "+end);
			}
			
			if (end == 0)
				end = list.Count+1;

			for (int i = (int)(start); i < end; i++) {
				object k = list_get(i);
				hash_remove(k);
			}
			list_remove_range((int)(start), end - (int)start);
		}

		public int Find(object o = null, int? start = null, int end = 0) { // this is once called with no parameter. wat. TODO INVESTIGATE -- other than that, should be good!
			if (start == null || start == 0) // confirmed.
				start = 1;
			if (start < 0 || start > len) // confirmed, first arg invalid -> return 0
				return 0;
			if (end < 0 || end > len + 1) // confirmed, second arg invalid -> crash
				throw new Exception("Bad Find args: " + start + ", " + end);

			if (Lang13.IsNumber(o))
				o = convert_number(o);

			// confirmed that hash values are ignored
			int index = list_indexof(o, (int)start);

			if (end == 0 || index < end)
				return index;

			return 0;
		}

		// LIKE ADD, IF YOU PASS A WHOLE TABLE, IT SHOULD ADD EVERY ITEM IN THE TABLE
		// UNLIKE ADD, ASSOCIATIVE VALUES SHOULD ONLY BE COPIED IF THE KEYS DO NOT EXIST YET!
		// THAT'S RIGHT, FUCK YOU.
		public int Insert(int i, params object[] items) {
			if (items == null)
				items = new object[] { null };


			foreach (var item in items) {
				if (Lang13.IsNumber(item)) {
					object item2 = convert_number(item);
					list_insert(i, item2);
					i++;
				}
				else if (item is ByTable) { // we need to add the items from the other list...
					ByTable tab = (ByTable)item;
					
					// We need an actual arraylist to insert.
					var e = tab.__GetRawEnum();
					ArrayList to_insert;
					if (e is ArrayList)
						to_insert = (ArrayList)e;
					else {
						to_insert = new ArrayList();
						foreach (var tmp in e) {
							to_insert.Add(tmp);
						}
					}
					
					list_insert_range(i, to_insert);
					i += tab.list_len();

					foreach (var k in to_insert) {
						if (tab.hash_haskey(k) && !this.hash_haskey(k))
							this.hash_set(k, tab.hash_get(k));
					}
				}
				else {
					list_insert(i, item);
					i++;
				}
			}

			return i; // <- I think this is correct?
		}

		// We have to be more careful here than in globals due to massive fuckery
		public int Insert(double? i, params object[] items) {
			return Insert(Convert.ToInt32(i), items);
		}

		public void Swap(object k1, object k2) { // TODO
			if (Lang13.IsNumber(k1) && Lang13.IsNumber(k2)) {
				int i1 = Convert.ToInt32(k1);
				int i2 = Convert.ToInt32(k2);

				object tmp = list_get(i1);
				list_set(i1,list_get(i2));
				list_set(i2, tmp);

				return;
			}
			throw new Exception("HOW DO I SWAP THESE?");
		}

		// These next two methods are used to help build lists in generated code.
		public ByTable Set(object k, object v) {
			
			if (Lang13.IsNumber(k)) {
				k = Convert.ToInt32(k);

				// We may need to increase the size of the list!
				if (len < (int)k) {
					len = (int)k;
				}
			}

			this[k] = v;
			return this;
		}

		public ByTable Extend(object[] os) {
			if (os == null)
			{
				list_add(null);
				return this;
			}
			foreach (var o in os) {
				if (Lang13.IsNumber(o))
					list_add(convert_number(o));
				else
					list_add(o);
			}
			return this;
		}

		// Confirmed only needs to check values in list!
		public bool Contains(object v) {
			if (Lang13.IsNumber(v))
				v = convert_number(v);
			return list_has(v);
		}

		public dynamic Apply(System.Reflection.MethodInfo f) { // TODO
			if (f == null)
				throw new Exception("THAT SHIT IS NULL NIGGA");
			Logger.Debug("TABLE APPLY " + f.Name);
			this.__Debug();
			throw new Exception("STOP");
			return null;
		}

		public dynamic Apply(BoundFunc b) {
			Logger.Debug("TABLE APPLY BOUND");
			throw new Exception("STOP");
			return null;
		}

		public dynamic Apply(Type t) {
			var ctor = t.GetConstructors()[0];

			var arg_info = ctor.GetParameters();

			var args = new object[arg_info.Length];

			for (int i = 0; i<args.Length; i++)
			{
				args[i] = Type.Missing;
			}

			for (int i = 1; i<=len; i++)
			{
				object lv = list_get(i);
				object hv = hash_get(lv);
				if (lv is string && hv != null)
				{
					// lv = param name
					// hv = value
					for (int j = 0; j<arg_info.Length; j++)
					{
						if ( (string)lv == arg_info[j].Name )
						{
							args[j] = hv;
							goto end;
						}
					}

					throw new Exception("Bad apply! " + lv + " -> " + ctor.Name);

				} else
				{
					// i = param #
					// lv = value
					if ((i-1)<args.Length)
					{
						args[i-1] = lv;
					} else
					{
						throw new Exception("Bad apply! " + i + " -> " + ctor.Name);
					}
				}

				end: { }
			}

			return ctor.Invoke(args);
		}

		/*public object applyCtor(Type t) { // TODO
			Logger.Debug("TABLE APPLY-CTOR " + t);
			throw new Exception("STOP");
			return null;
		}*/

		public override string ToString() {
			return "[ByTable]";
		}

		private object convert_number(object o) { // stop judging me!
			if (o is bool)
				return (bool)o ? 0 : 1;
			if (o is double) {
				if ((double)o % 1 == 0)
					return (int)(double)o;
				return o;
			}
			if (o is int) {
				return o;
			}
			throw new Exception("This should not be reachable!");
		}

		public void __Debug() {
			Logger.Debug("ByTable Debug: "+list.Count+" / "+((hash != null)?hash.Count:0));
			for (int i = 1; i <= this.len; i++) {
				object k = list[i-1];
				if (k == null) k = NULL_KEY;
				object v = (hash != null)?hash[k]:null;
				if (v == null) v = NULL_KEY;
				Logger.Debug(" > " + i + ": " + k + " -- " + v);
			}
		}

		////////////////////////////
		////////////////////////////
		////////////////////////////

		// THIS IS ALL PRETTY TERRIBLE, BUT WAY BETTER THAN WHAT WE HAD! NOW WE CAN IMPLEMENT CUSTOM LISTS WITHOUT WANTING TO AN HERO!

		private Hashtable hash; // We don't init this unless we have to, as many of these structures are just lists.
		private ArrayList list;

		// TODO, this will need to filter types
		public virtual ArrayList __GetEnumerationList(Type t) {
			if (t == null) {
				return (ArrayList)list.Clone();
			} else
			{
				ArrayList result = new ArrayList();
				foreach (var item in list)
				{
					
					if (t.IsInstanceOfType(item))
					{
						result.Add(item);
					}
				}
				return result;
			}
		}

		public virtual IEnumerable __GetRawEnum() {
			return list;
		}

		protected virtual void list_init() {
			list = new ArrayList();
		}

		protected virtual void list_init_clone(ByTable src) {
			list = src.__GetEnumerationList(null);
		}

		protected virtual int list_len() {
			return list.Count;
		}

		protected virtual bool list_has(object item) {
			return list.Contains(item);
		}

		protected virtual int list_indexof(object item, int start) {
			return list.IndexOf(item, (int)start - 1) + 1;
		}

		protected virtual object list_get(int i) {
			return list[i - 1];
		}

		protected virtual void list_set(int i, object item) {
			list[i - 1] = item;
		}

		protected virtual void list_add(object item) {
			list.Add(item);
		}

		protected virtual void list_insert(int i, object item) {
			list.Insert(i - 1, item);
		}

		protected virtual void list_insert_range(int i, ICollection collection) {
			list.InsertRange(i - 1, collection);
		}

		protected virtual void list_remove(object item) {
			list.Remove(item);
		}

		protected virtual void list_remove_range(int i, int count) {
			list.RemoveRange(i - 1, count);
		}

		/////////

		protected virtual object hash_get(object key) {
			if (hash == null)
				return null;
			return hash[key ?? NULL_KEY];
		}

		protected virtual void hash_set(object key, object item) {
			if (hash == null)
				hash = new Hashtable();
			hash[key ?? NULL_KEY] = item;
		}

		protected virtual void hash_remove(object key) {
			if (hash != null)
				hash.Remove(key ?? NULL_KEY);
		}

		protected virtual bool hash_haskey(object key) {
			if (hash == null)
				return false;
			return hash.ContainsKey(key ?? NULL_KEY);
		}
	}
}
