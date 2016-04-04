using System;

using Somnium.Engine.NewLib;

namespace Somnium.Engine.ByImpl {

	// quick and dirty, I do not know what most of this does. I do not know why there seems to be two systems that do the same thing.

	static class DB13 {
		public static dynamic op(Somnium.Game.Database d, int o, dynamic arg = null) {
			Logger.DebugMinor("db->opd");
			return null;
		}

		public static dynamic op(Somnium.Game.Database_Query q, int o, dynamic arg = null) {
			Logger.DebugMinor("db->opq");
			return null;
		}

		public static DB13_CONNECTION new_con() { // THIS IS ACTUALLY USED
			Logger.DebugMinor("DB->NEW CONNECTION!");
			return null;
		}

		public static DB13_QUERY new_query() {
			Logger.DebugMinor("db->new_query");
			return null;
		}

		public static bool connect(DB13_CONNECTION connection, string dbi, string user, string password, dynamic cursor, dynamic unknown_arg) {
			Logger.DebugMinor("db->connect");
			return false;
		}

		public static bool execute(DB13_QUERY q, string sql_query, DB13_CONNECTION c, dynamic cursor, dynamic unknown_arg) {
			Logger.DebugMinor("db->execute");
			return false;
		}

		public static bool next_row(DB13_QUERY q, ByTable item, ByTable conversions) {
			Logger.DebugMinor("db->next_row");
			return false;
		}

		public static string error_msg(DB13_CONNECTION connection) {
			Logger.DebugMinor("db->error_msg-c");
			return "";
		}

		public static string error_msg(DB13_QUERY connection) {
			Logger.DebugMinor("db->error_msg-q");
			return "";
		}

		public static bool close(DB13_CONNECTION connection) {
			Logger.DebugMinor("db->close-c");
			return false;
		}

		public static bool close(DB13_QUERY q) {
			Logger.DebugMinor("db->close-q");
			return false;
		}

		public static bool is_connected(DB13_CONNECTION connection) {
			Logger.DebugMinor("db->is_connected");
			return false;
		}

		public static int rows_affected(DB13_QUERY q) {
			Logger.DebugMinor("db->rows_affected");
			return 0;
		}

		public static int row_count(DB13_QUERY q) {
			Logger.DebugMinor("db->row_count");
			return 0;
		}

		public static string quote(DB13_CONNECTION c, string str) {
			Logger.DebugMinor("db->quote");
			return "";
		}

		// I have no idea why a type is being passed into this fucking thing.
		public static ByTable columns(DB13_QUERY q, Type t) {
			Logger.DebugMinor("db->columns");
			return null;
		}
	}

	class DB13_CONNECTION {

	}

	class DB13_QUERY {

	}
}
