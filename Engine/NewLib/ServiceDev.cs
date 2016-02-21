using System;
using System.Net;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;

namespace Somnium.Engine.NewLib {
	static class ServiceDev {
		private static ConcurrentQueue<HttpListenerContext> map_reqs = new ConcurrentQueue<HttpListenerContext>();

		public static void Setup() {
			if (!Config.DEVMODE) return;

			WebServer.RegisterService("dev-map", service_map);
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
							// Write tile
							write_ent(output_writer, strtab, map[ix, iy, iz]);
							// Write zone
							write_ent(output_writer, strtab, map[ix, iy, iz].loc);

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

				output_writer.Write(str_count);

				foreach (var str in str_list) {
					output_writer.Write(str.ToCharArray());
					output_writer.Write((byte)0);
				}

				output_writer.Close();
			}
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
	}

	class StringTable {
		Dictionary<string, int> ids = new Dictionary<string, int>();
		int next_id = 0;

		public int GetId(string str) {
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
