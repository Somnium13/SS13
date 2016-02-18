using System;
using System.Collections;
using System.Collections.Generic;

namespace Somnium.Engine.ByImpl {

	abstract class Base_Zone : Somnium.Game.Ent_Static {
		public Base_Zone(dynamic loc) {
			if (loc != null) {
				throw new Exception("ZONE CAN NOT HAVE A LOC!");
			}

			_contents = new ZoneContentsTable(this);
		}

		public override int x {
			get { return ((ZoneContentsTable)_contents).__GetPos('x'); }
			set { throw new Exception("CAN NOT SET LOC OF ZONE!"); }
		}

		public override int y {
			get { return ((ZoneContentsTable)_contents).__GetPos('y'); }
			set { throw new Exception("CAN NOT SET LOC OF ZONE!"); }
		}

		public override int z {
			get { return ((ZoneContentsTable)_contents).__GetPos('z'); }
			set { throw new Exception("CAN NOT SET LOC OF ZONE!"); }
		}

		class ZoneContentsTable : ByTable {

			private Base_Zone owner;

			private HashSet<Game.Tile> direct_contents;

			public ZoneContentsTable(Base_Zone owner) {
				this.owner = owner;
			}

            public int __GetPos(char d)
            {
                int x= -1;
                int y= -1;
                int z= -1;

                foreach (Game.Tile t in direct_contents) {
                    if (x == -1 || t.z < z || ( t.z == z && t.y < y ) || (t.z == z && t.y == y && t.x < x ) )
					{
						x = t.x;
						y = t.y;
						z = t.z;
                    }
                }

				switch (d)
				{
					case 'x':
						return x;
					case 'y':
						return y;
					case 'z':
						return z;
					default:
						throw new Exception("Bad dimension.");
				}
            }

			public override ArrayList __GetEnumerationList(Type t) {

				ArrayList l = new ArrayList();
				foreach (var tile in direct_contents) {
					if (t==null || t.IsInstanceOfType(tile))
						l.Add(tile);
					foreach (var obj in tile.contents.__GetRawEnum()) {
						if (t == null || t.IsInstanceOfType(obj))
							l.Add(obj);
					}
				}
				return l;
			}

			public override IEnumerable __GetRawEnum() {
				return __GetEnumerationList(null);
			}

			protected override void list_init() {
				direct_contents = new HashSet<Game.Tile>();
			}

			protected override void list_init_clone(ByTable src) {
				throw new Exception("NO.");
			}

			protected override int list_len() {
				int length = 0;
				foreach (var tile in direct_contents) {
					length += 1 + tile.contents.len;
				}
				return length;
			}

			protected override bool list_has(object item) {
				if (direct_contents.Contains((Game.Tile)item))
					return true;

				return false; // TODO NON-DIRECT CONTENTS!
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
				Base_Static ent = (Base_Static)item;
				if (ent is Game.Tile) {
					direct_contents.Add((Game.Tile)ent);
					ent.__SetLocInternal(owner);
				}
				else {
					throw new Exception("BAD ITEM FOR ZONE CONTENTS!");
				}
			}

			protected override void list_insert(int i, object item) {
				throw new Exception("NO.");
			}

			protected override void list_insert_range(int i, ICollection collection) {
				throw new Exception("NO.");
			}

			protected override void list_remove(object item) {
				Base_Static ent = (Base_Static)item;
				direct_contents.Remove((Game.Tile)ent);
				ent.__SetLocInternal(null);
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
				// meh
			}

			protected override bool hash_haskey(object key) {
				throw new Exception("NO.");
			}
		}

				//loc = Map13.get_tile_at(x, y, value);

		// Sets the parent. You should have updated the parent's contents already.
		// Area contents will still need to be updated by this... GAH!
		/*public void __SetParent(Game.Ent_Static new_parent) {
			
			// Zones work a little different... a lot different...
			if (this is Game.Tile) {
				if (!(new_parent is Game.Zone))
					throw new Exception("CAN NOT SET PARENT OF TILE TO " + new_parent.GetType());
				
				var old_parent = this._parent;
				this._parent = new_parent;

				if (old_parent != null) {
					// Check if the old parent zone should still be allowed to stay in Game13.contents
					if (old_parent._is_in_map) {
						old_parent._is_in_map = false;
						foreach (Game.Ent_Static c in Lang13.Enumerate(old_parent.contents)) { // todo don't use the damn enumerate function in engine code, it is trash
							if (c is Game.Tile && c._is_in_map) {
								old_parent._is_in_map = true;
								break;
							}
						}
						if (!old_parent._is_in_map) {
							Game13.contents.__QuietRemove(old_parent);
						}
					}

					// Check if we need to update the old parent's position
					if (old_parent._pos == this._pos) {
						foreach (Game.Ent_Static c in Lang13.Enumerate(old_parent.contents)) { // todo don't use the damn enumerate function in engine code, it is trash
							if (c is Game.Tile && (old_parent._pos == null || old_parent._pos.IsLower(c._pos)))
								old_parent._pos = c._pos;
						}
					}
				}

				// ALRIGHT, NOW FOR THE NEW PARENT! PUT IT IN THE MAP IF IT AINT!
				if (!new_parent._is_in_map && this._is_in_map) {
					Game13.contents.__QuietAdd(new_parent);
					new_parent._is_in_map = true;
				}

				// SET THE POS IF OURS IS LOWER!
				if (new_parent._pos == null || new_parent._pos.IsLower(this._pos)) {
					new_parent._pos = this._pos;
				}

				// MOVE ALL OUR SUB-ENTS TO THE NEW ZONE'S CONTENTS!
				foreach (Game.Ent_Static c in Lang13.Enumerate(this.contents)) {
					if (old_parent != null)
						old_parent.contents.Remove(c);
					new_parent.contents.Add(c);
				}
			}
			else {
				throw new Exception("!!");
			}
		}*/
	}

}
