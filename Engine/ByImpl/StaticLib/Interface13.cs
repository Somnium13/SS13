using System;

using Somnium.Engine.NewLib;

namespace Somnium.Engine.ByImpl {
	static class Interface13 {
		public static void SendFile(dynamic user, dynamic file, string name) {
			Logger.Debug("interface->sendFile");
		}

		public static void Stat(string a, dynamic b) {
			Logger.Debug("interface->stat");
		}

		public static bool IsStatPanelActive(string name) {
			Logger.Debug("interface->is_stat_panel_active");
			return false;
		}

		public static void SetStatPanel(dynamic a, dynamic b, dynamic c) {
			Logger.Debug("interface->set_stat_panel");			
		}

		public static void Browse(dynamic user, dynamic body, string options) {
			Logger.Debug("interface->browse");
		}

		public static void CacheBrowseResource(dynamic user, dynamic file, string filename) {
			Logger.Debug("interface->cache_browse_resource");
		}

		public static void WindowSet(dynamic user, string id, string _params) {
			Logger.Debug("interface->window_set");
		}

		public static string WindowGet(dynamic user, string id, string _params) {
			Logger.Debug("interface->window_get");
			return null;
		}

		public static void WindowClone(dynamic user, string window_name, string clone_name) {
			Logger.Debug("interface->window_clone");
		}

		public static void WindowShow(dynamic user, string window, dynamic show) {
			Logger.Debug("interface->window_show");
		}

		public static bool WindowExists(dynamic user, string id) {
			Logger.Debug("interface->window_exists");
			return false;
		}

		public static void Link(dynamic user, string url) {
			Logger.Debug("interface->link");
		}

		public static void Output(dynamic user, string msg, string ctrl_id) {
			Logger.Debug("interface->output");
		}

		// This can get wonky: User can be omitted, leaving msg as the first param!
		public static string Alert(dynamic user, string msg=null, string title=null, string btn1=null, string btn2=null, string btn3=null) {
			Logger.Debug("interface->alert");
			return "";
		}

		// Similar to above, first FOUR args can be shifted over by one if the user is omitted. The final two will always be in the correct spot.
		public static dynamic Input(dynamic user, string msg, dynamic title, dynamic _default, dynamic list, InputType types) {
			Logger.Debug("interface->input");
			return null;
		}

		public static void OpenFile(Game.Client c, File file) {
			Logger.Debug("interface->open");
		}
	}
}
