using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somnium.Engine.ByImpl
{
	abstract partial class Base_Image : Game.Data
	{ // many of these vars are the same as static, but this is supposed to inherit from data
		public Base_Image(params object[] v) { }

		public Game.Ent_Static loc;

		public bool v_override;

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
		public dynamic overlays
		{
			get
			{
				return _overlays;
			}
			set
			{
				if (value is int)
				{
					_overlays.len = value;
				}
				else if (value is ByTable)
					_overlays = value; // todo- redo if a special table!
				else {
					throw new Exception("WAT");
				}
			}
		}

		public int pixel_x;
		public int pixel_y;
		public int pixel_z;
		public int plane;
		public string suffix;
		public string text;
		public Game.Matrix transform;
		public ByTable underlays = new ByTable();
	}
}
