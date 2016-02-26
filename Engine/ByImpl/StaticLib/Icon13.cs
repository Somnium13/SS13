using System;

using Somnium.Engine.NewLib;

namespace Somnium.Engine.ByImpl {

	// I have not a whole lot of idea how most of this is supposed to work!
	// Just about everything is a stub!

	static class Icon13 {

		public static void Animate(ByTable args) {
			Logger.Debug2("icon->animate");
		}

		public static void Animate(Game.Ent_Static ent) {
			throw new NotImplementedException();
		}

		// SUPPORTS REVERSED ARGS!
		public static void Flick(dynamic o, dynamic name) {
			Logger.Debug2("icon->flick");
		}

		public static ByTable States(dynamic i, int mode) {
			Logger.Debug2("icon->states");
			return new ByTable();
		}

		// The following are internal functions that operate on CoreIcons...

		public static Base_Icon create(dynamic icon = null, dynamic icon_state = null, int dir = 0, int frame = 0, bool moving = false) {
			Logger.Debug2("icon->create");
			return new Base_Icon(icon, icon_state, dir, frame, moving);
		}

		public static void oper(int op, Base_Icon icon, dynamic param) {
			Logger.Debug2("icon->oper");
		}

		public static void oper_map_colors(Base_Icon icon, params object[] _) {
			Logger.Debug2("icon->oper_map_colors");
		}

		public static void oper_set_intensity(Base_Icon icon, int r, int g, int b) {
			Logger.Debug2("icon->oper_set_intensity");
		}

		public static void oper_swap_color(Base_Icon icon, string a, string b) {
			Logger.Debug2("icon->oper_swap_color");
		}

		public static void oper_shift(Base_Icon icon, dynamic dir = null, dynamic offset = null, dynamic wrap = null) {
			Logger.Debug2("icon->oper_shift");
		}

		public static void oper_draw_box(Base_Icon icon, string color, int? x1, int? y1, int? x2, int? y2) {
			Logger.Debug2("icon->oper_draw_box");
		}

		public static void oper_insert(Base_Icon icon, Somnium.Game.Icon new_icon, string icon_state, int dir, int frame, bool moving, dynamic delay) {
			Logger.Debug2("icon->oper_insert");
		}

		public static void oper_scale(Base_Icon icon, int x, int y) {
			Logger.Debug2("icon->oper_scale");
		}

		public static void oper_crop(Base_Icon icon, double x1, double y1, double x2, double y2) {
			Logger.Debug2("icon->oper_crop");
		}

		public static void oper_blend(Base_Icon icon, dynamic icon2, int? f, int? x, int? y) {
			Logger.Debug2("icon->oper_blend"); // Note: icon2 can be a color string!)
		}
		/*
		public static ByTable oper_states(CoreIcon icon, dynamic mode) {
			Console13.debug("icon->oper_states");
			return new ByTable();
		}
		*/
		public static string oper_getpixel(Base_Icon icon, int x, int y, string icon_state, int dir, int frame, bool moving) {
			Logger.Debug2("icon->oper_getpixel");
			return "#FFFFFFFF";
		}

		// Returns the dimension of the icon along one axis. 1->Width, 2->Height
		public static int oper_dim(Base_Icon icon, bool mode) {
			Logger.Debug2("icon->oper_dim");
			return 1;
		}
	}

	class Base_Icon {
		public Base_Icon(dynamic icon = null, dynamic icon_state = null, int dir = 0, int frame = 0, bool moving = false) {
			Logger.Debug2("NEW COREICON");
		}
	}
}
