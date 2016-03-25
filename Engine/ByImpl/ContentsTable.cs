using System;
using System.Collections;
using System.Collections.Generic;

namespace Somnium.Engine.ByImpl {

	// Global contents table. It just prevents direct modification!
	class GlobalContentsTable : ByTable {

		private static void add_contents_r(ArrayList list, ByTable c, Type t) {
			foreach (Base_Static ent in c.__GetRawEnum()) {
				if (t == null || t.IsInstanceOfType(ent))
					list.Add(ent);
				add_contents_r(list,ent.contents,t);
			}
		}

		public override ArrayList __GetEnumerationList(Type t) {
			var a = new ArrayList();

			var zone_set = new HashSet<Game.Zone>();

			foreach (Game.Tile tile in Map13.__Map) {
				// Add Tiles
				if (t == null || t.IsInstanceOfType(tile))
					a.Add(tile);
				
				// Add Zones
				if (tile.loc != null && !zone_set.Contains((Game.Zone)tile.loc) && (t == null || t.IsInstanceOfType(tile.loc))) {
					zone_set.Add((Game.Zone)tile.loc);
					a.Add(tile.loc);
				}

				// Add all other objects
				add_contents_r(a, tile.contents, t);
			}

			return a;
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
			throw new Exception("NO.");
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
			throw new Exception("NO.");
		}

		protected override void hash_remove(object key) {
			throw new Exception("NO.");
		}

		protected override bool hash_haskey(object key) {
			return false;
		}
	}

	class EntContentsTable : ByTable {

		private Base_Static owner;

		private HashSet<Game.Ent_Dynamic> contents;

		public EntContentsTable(Base_Static owner) {
			this.owner = owner;
		}

		public EntContentsTable(Base_Static owner, EntContentsTable copy_from) {
			this.owner = owner;

			var tmp = this.contents;
			this.contents = copy_from.contents;
			copy_from.contents = tmp;
		}

		public override ArrayList __GetEnumerationList(Type t) {
			var list = new ArrayList(contents.Count);

			foreach (var e in contents) {
				if (t == null || t.IsInstanceOfType(e))
					list.Add(e);
			}

			return list;
		}

		public override IEnumerable __GetRawEnum() {
			return contents;
		}

		protected override void list_init() {
			contents = new HashSet<Game.Ent_Dynamic>();
		}

		protected override void list_init_clone(ByTable src) {
			throw new Exception("NO.");
		}

		protected override int list_len() {
			return contents.Count;
		}

		protected override bool list_has(object item) {
			throw new Exception("NO.");
		}

		protected override int list_indexof(object item, int start) {
			throw new Exception("NO.");
		}

		protected override object list_get(int i) {
			var e = contents.GetEnumerator();
			while (i > 0) {
				e.MoveNext();
				i--;
			}
			return e.Current;
		}

		protected override void list_set(int i, object item) {
			throw new Exception("NO.");
		}

		protected override void list_add(object item) {
			if (!(item is Game.Ent_Dynamic))
				throw new Exception("CAN NOT ADD STATIC ENT TO CONTENTS!");

			Game.Ent_Dynamic item_ent = (Game.Ent_Dynamic)item;

			contents.Add(item_ent);
			item_ent.__SetLocInternal((Game.Ent_Static)owner);
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
			if (i==1 && count == contents.Count)
			{
				contents.Clear();
				return;
			}

			throw new Exception("BAD RANGE REMOVAL ON CONTENTS TABLE!");
		}

		/////////

		protected override object hash_get(object key) {
			throw new Exception("NO.");
		}

		protected override void hash_set(object key, object item) {
			throw new Exception("NO.");
		}

		protected override void hash_remove(object key) {
			// meh
		}

		protected override bool hash_haskey(object key) {
			return false;
		}
	}
}
