using System;
using System.Net;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;

namespace Somnium.Engine.NewLib {
	static class ServiceDev {
		private static ConcurrentQueue<HttpListenerContext> map_reqs = new ConcurrentQueue<HttpListenerContext>();

		private static ConcurrentDictionary<string, ConcurrentBag<string>> warnings = new ConcurrentDictionary<string, ConcurrentBag<string>>();
		private static ConcurrentDictionary<string, ConcurrentBag<string>> errors = new ConcurrentDictionary<string, ConcurrentBag<string>>();

		public static void Setup() {
			if (!Config.DEVMODE) return;

			WebServer.RegisterService("dev-map", service_map);
			WebServer.RegisterService("dev-issues", service_issues);
		}

		public static void Process() {
			if (!Config.DEVMODE) return;

			HttpListenerContext context;
			if (map_reqs.TryDequeue(out context)) {
				var output_writer = new BinaryWriter(context.Response.OutputStream);

				context.Response.SendChunked = true;

				var map = ByImpl.Map13.__Map;
				var strtab = new StringTable();

				short size_x = (short)map.GetLength(0);
				short size_y = (short)map.GetLength(1);
				short size_z = (short)map.GetLength(2);

				// X Y Z size
				output_writer.Write(size_x);
				output_writer.Write(size_y);
				output_writer.Write(size_z);

				for (short iz = 0; iz < size_z; iz++) {
					for (short iy = 0; iy < size_y; iy++) {
						for (short ix = 0; ix < size_x; ix++) {
							// Write zone
							write_ent(output_writer, strtab, map[ix, iy, iz].loc);
							// Write tile
							write_ent(output_writer, strtab, map[ix, iy, iz]);
							

							// Write objs
							short obj_count = (short)map[ix, iy, iz].contents.len;
							output_writer.Write(obj_count);

							if (obj_count > 0) {
								foreach (ByImpl.Base_Static obj in map[ix, iy, iz].contents.__GetRawEnum()) {
									write_ent(output_writer, strtab, obj);
								}
							}
						}
					}
				}

				var str_list = strtab.GetStrings();
				short str_count = (short)str_list.Length;

				for (int i = str_count-1; i>=0; i--) {
					output_writer.Write((byte)0);
					output_writer.Write(str_list[i].ToCharArray());
				}

				output_writer.Write(str_count);
				Console.WriteLine(">>" + str_count);

				output_writer.Close();
			}
		}

		public static void NotifyIssue(bool is_error, string title, string misc)
		{
			if (!Config.DEVMODE) return;

			ConcurrentBag<string> miscs;
			if (is_error)
			{
				if (!errors.TryGetValue(title, out miscs))
				{
					miscs = new ConcurrentBag<string>();
					errors[title] = miscs;
				}
			} else
			{
				if (!warnings.TryGetValue(title, out miscs))
				{
					miscs = new ConcurrentBag<string>();
					warnings[title] = miscs;
				}
			}

			miscs.Add(misc);
		}

		private static void write_ent(BinaryWriter w, StringTable st, ByImpl.Base_Static ent)
		{
			short id_class = (short)st.GetId(ent.GetType().Name);
			short id_name = (short)st.GetId(ent.name);
			short id_desc = (short)st.GetId(ent.desc);
			short id_icon = (short)st.GetId(ent.icon);
			short id_state = (short)st.GetId(ent.icon_state);
			short dir = (short)ent.dir;

			w.Write(id_class);
			w.Write(id_name);
			w.Write(id_desc);
			w.Write(id_icon);
			w.Write(id_state);
			w.Write(dir);
		}

		private static void service_map(HttpListenerContext context) {
			if (ByImpl.Task13.__IsSchedulerRunning()) {
				map_reqs.Enqueue(context);
			}
			else {
				context.Response.StatusCode = 503;
				context.Response.Close();
			}
		}

		private static void service_issues(HttpListenerContext context)
		{
			var sr = new StreamWriter(context.Response.OutputStream);

			sr.Write(errors.Count);
			sr.Write(" Errors:\n\n");

			foreach (KeyValuePair<string, ConcurrentBag<string>> kv in errors)
			{
				sr.Write("\t"+kv.Key.Replace("\n","\n\t")+"\n");
				foreach (string misc in kv.Value)
				{
					sr.Write("\t\t> " + misc + "\n");
				}
			}

			sr.Write("\n\n");

			sr.Write(warnings.Count);
			sr.Write(" Warnings:\n\n");

			foreach (KeyValuePair<string, ConcurrentBag<string>> kv in warnings)
			{
				sr.Write("\t" + kv.Key.Replace("\n", "\n\t") + "\n");
				foreach (string misc in kv.Value)
				{
					sr.Write("\t\t> " + misc + "\n");
				}
			}

			sr.Close();
		}
	}

	class StringTable {
		Dictionary<string, int> ids = new Dictionary<string, int>();
		int next_id = 0;

		public int GetId(string str) {
			str = str ?? "";

			int id;
			if (ids.TryGetValue(str, out id)) {
				return id;
			}
			else {
				ids[str] = next_id;
				return next_id++;
			}
		}

		public string[] GetStrings() {
			string[] result = new string[next_id];
			foreach (var kv in ids) {
				result[kv.Value] = kv.Key;
			}
			return result;
		}

	}
}
