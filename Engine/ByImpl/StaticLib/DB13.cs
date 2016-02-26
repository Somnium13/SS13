using System;

using Somnium.Engine.NewLib;

namespace Somnium.Engine.ByImpl {

	// quick and dirty, I do not know what most of this does. I do not know why there seems to be two systems that do the same thing.

	static class DB13 {
		public static dynamic op(Somnium.Game.Database d, int o, dynamic arg = null) {
			Logger.Debug2("db->opd");
			return null;
		}

		public static dynamic op(Somnium.Game.Database_Query q, int o, dynamic arg = null) {
			Logger.Debug2("db->opq");
			return null;
		}

		public static DB13_CONNECTION new_con() { // THIS IS ACTUALLY USED
			Logger.Debug2("DB->NEW CONNECTION!");
			return null;
		}

		public static DB13_QUERY new_query() {
			Logger.Debug2("db->new_query");
			return null;
		}

		public static bool connect(DB13_CONNECTION connection, string dbi, string user, string password, dynamic cursor, dynamic unknown_arg) {
			Logger.Debug2("db->connect");
			return false;
		}

		public static bool execute(DB13_QUERY q, string sql_query, DB13_CONNECTION c, dynamic cursor, dynamic unknown_arg) {
			Logger.Debug2("db->execute");
			return false;
		}

		public static bool next_row(DB13_QUERY q, ByTable item, ByTable conversions) {
			Logger.Debug2("db->next_row");
			return false;
		}

		public static string error_msg(DB13_CONNECTION connection) {
			Logger.Debug2("db->error_msg-c");
			return "";
		}

		public static string error_msg(DB13_QUERY connection) {
			Logger.Debug2("db->error_msg-q");
			return "";
		}

		public static bool close(DB13_CONNECTION connection) {
			Logger.Debug2("db->close-c");
			return false;
		}

		public static bool close(DB13_QUERY q) {
			Logger.Debug2("db->close-q");
			return false;
		}

		public static bool is_connected(DB13_CONNECTION connection) {
			Logger.Debug2("db->is_connected");
			return false;
		}

		public static int rows_affected(DB13_QUERY q) {
			Logger.Debug2("db->rows_affected");
			return 0;
		}

		public static int row_count(DB13_QUERY q) {
			Logger.Debug2("db->row_count");
			return 0;
		}

		public static string quote(DB13_CONNECTION c, string str) {
			Logger.Debug2("db->quote");
			return "";
		}

		// I have no idea why a type is being passed into this fucking thing.
		public static ByTable columns(DB13_QUERY q, Type t) {
			Logger.Debug2("db->columns");
			return null;
		}
	}

	class DB13_CONNECTION {

	}

	class DB13_QUERY {

	}
}
