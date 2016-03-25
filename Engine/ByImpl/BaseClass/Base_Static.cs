using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somnium.Engine.ByImpl {

	class Appearance {

	}

	abstract class Base_Static : Somnium.Game.Data {
		public Base_Static(dynamic loc) {
			if (loc != null) {
				throw new Exception("BASE_STATIC CAN NOT HAVE A LOC!");
			}
		}

		public bool density;
		public int dir = 2; // this is the default pretty much everywhere.

		// Everything to do with appearance:
		public Appearance appearance;
		public int appearance_flags;
		public int alpha;
		public int blend_mode;
		public string color;
		public string desc;
		public string gender;
		public string icon;
		public string icon_state;
		public int invisibility;
		public double infra_luminosity;
		public double layer; // verified. must be double. fixme in translator!
		public double luminosity;
		public string maptext;
		public int maptext_width;
		public int maptext_height;
		public int maptext_x;
		public int maptext_y;
		public dynamic mouse_over_pointer;
		public dynamic mouse_drag_pointer;
		public dynamic mouse_drop_pointer;
		public bool mouse_drop_zone;
		public int mouse_opacity;
		public string name;
		public bool opacity;

		private ByTable _overlays = new ByTable();
		public dynamic overlays {
			get {
				return _overlays;
			}
			set {
				/*if (value is int) { GET RID OF THIS ASININE NONSENSE.
					_overlays.len = value;
				}
				else */
				if (value is ByTable)
					_overlays = value; // todo- redo if a special table!
				else {
					throw new Exception("Bad value for overlays: "+value);
				}
			}
		}

		public int pixel_x;
		public int pixel_y;
		public int pixel_z;
		public int plane;
		public string suffix;
		public string text;
		public Somnium.Game.Matrix transform;
		public ByTable underlays = new ByTable();
		
		
		public ByTable verbs = new ByTable(); // TODO

		// Location-related stuff
		protected ByTable _contents;
		protected Game.Ent_Static _loc;

		public ByTable contents {
			get { return _contents; }
			set { _contents.len = 0; _contents.Add(value); }
		}

		public Game.Ent_Static loc {
			get { return _loc; }
			set
            {
                if (this is Game.Ent_Dynamic)
                {
                    if (value != null)
                    {
                        Game.Ent_Static ent_loc = value;
                        ent_loc._contents.Add(this); // setting the actual loc is handled by this!
                    }
                }

                else {
                    throw new Exception("CAN NOT EDIT LOC OF STATIC ENTITIES!");
                }
                
            }
		}

		public void __SetLocInternal(Game.Ent_Static e) {
			_loc = e;
		}

		public virtual int x {
			get { throw new Exception("CAN NOT ACCESS LOC OF BASE_STATIC!"); }
			set { throw new Exception("CAN NOT ACCESS LOC OF BASE_STATIC!"); }
		}

		public virtual int y {
			get { throw new Exception("CAN NOT ACCESS LOC OF BASE_STATIC!"); }
			set { throw new Exception("CAN NOT ACCESS LOC OF BASE_STATIC!"); }
		}

		public virtual int z {
			get { throw new Exception("CAN NOT ACCESS LOC OF BASE_STATIC!"); }
			set { throw new Exception("CAN NOT ACCESS LOC OF BASE_STATIC!"); }
		}

		/*protected virtual void __BindChild(Game.Ent_Static child) {

		}*/

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

		public virtual bool Click(dynamic location, string control, string _params) {
			return false; // ?
		}

		public virtual bool DblClick(dynamic _object, string location, string control) {
			return false; // ?
		}

		public virtual bool Enter(Somnium.Game.Ent_Dynamic O, Game.Ent_Static old_loc) {
			return false;
		}

		public virtual bool Exit(Game.Ent_Dynamic O, Game.Ent_Static new_loc) {
			return false;
		}

		public virtual dynamic Entered(Somnium.Game.Ent_Dynamic O, Game.Ent_Static old_loc) {
			return null;
		}

		public virtual void Exited(Somnium.Game.Ent_Dynamic O, Game.Ent_Static new_loc) {

		}

		public void MouseDown(dynamic location, dynamic control, dynamic _params) {

		}

		public void MouseDrag(dynamic over_obj, dynamic src_loc, dynamic over_loc, dynamic src_control, dynamic over_control, dynamic _params) {

		}

		public void MouseDrop(dynamic over_obj, dynamic src_loc, dynamic over_loc, dynamic src_control, dynamic over_control, dynamic _params) {

		}

		public virtual bool MouseEntered(dynamic location, string control, string _params) {
			return false; //?
		}

		public virtual bool MouseExited(dynamic location, string control, string _params) {
			return false; //?
		}

		public void MouseMove(dynamic location, dynamic control, dynamic _params) {

		}

		public void MouseUp(dynamic location, dynamic control, dynamic _params) {

		}

		public void MouseWheel(double delta_x, double delta_y, dynamic location, dynamic control, dynamic _params) {

		}

		public virtual dynamic Stat() {
			return null;
		}
	}

}
