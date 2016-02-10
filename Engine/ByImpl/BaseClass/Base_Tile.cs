using System;
using System.Collections.Generic;
using System.Collections;

namespace Somnium.Engine.ByImpl {

	abstract class Base_Tile : Somnium.Game.Ent_Static {
		
		public static void PlaceInMap(Game.Tile t, int x, int y, int z) {
			if (Map13.__Map[x - 1, y - 1, z - 1] != null) {
				throw new Exception("CAN NOT PLACE NEW TILE IN MAP, TILE IN THE WAY!");
			}

			Map13.__Map[x - 1, y - 1, z - 1] = t;

			t._x = x;
			t._y = y;
			t._z = z;
		}
		
		public Base_Tile(dynamic loc) {
			if (loc != null) {
				if (loc is Base_Tile) {
					Base_Tile old_tile = (Base_Tile)loc;
					_x = old_tile._x;
					_y = old_tile._y;
					_z = old_tile._z;
					old_tile._x = -1;
					old_tile._y = -1;
					old_tile._z = -1;
					_contents = new EntContentsTable(this, (EntContentsTable)old_tile.contents);
					if (old_tile._loc != null) {
						old_tile._loc.contents.Add(this);
						old_tile._loc.contents.Remove(old_tile);
					}
					Map13.__Map[_x - 1, _y - 1, _z - 1] = (Game.Tile)this;
				}
				else {
					throw new Exception("BAD LOC FOR TILE!");
				}
			}
			else {
				_contents = new EntContentsTable(this);
			}
		}

		// NOTE: SHOULD RETURN NULL WHEN NOT IN THE MAP, BUT HOPEFULLY NOTHING ACTUALLY RELIES ON THIS!
		private int _x = -1;
		private int _y = -1;
		private int _z = -1;

		public override int x {
			get { return _x; }
			set { throw new Exception("CAN NOT SET LOC OF TILE!"); }
		}

		public override int y {
			get { return _y; }
			set { throw new Exception("CAN NOT SET LOC OF TILE!"); }
		}

		public override int z {
			get { return _z; }
			set { throw new Exception("CAN NOT SET LOC OF TILE!"); }
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
