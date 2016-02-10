using System;
using System.Collections.Generic;

using Somnium.Engine.NewLib;

namespace Somnium.Engine.ByImpl {
	static class Map13 {
		public static Game.Tile GetTile(int x, int y, int z) {
			if (x < 1 || x > Game13.map_size_x || y < 1 || y > Game13.map_size_y || z < 1 || z > Game13.map_size_z) {
				return null;
			}

			return __Map[x - 1, y - 1, z - 1];
		}

		// TODO WHAT DOES THIS RETURN IF NOT GIVEN AN ENT?
		public static int GetDistance(dynamic a, dynamic b) {
			var a_ent = (Base_Static)a;
			var b_ent = (Base_Static)b;

			// Confirmed z is disregarded!
			var a_x = a_ent.x;
			var a_y = a_ent.y;

			var b_x = b_ent.x;
			var b_y = b_ent.y;

			return Math.Max(Math.Abs(a_x-b_x),Math.Abs(a_y-b_y));
		}

		public static void Step(Game.Ent_Dynamic ent, int dir) {
			Logger.Debug("map->step");
		}

		public static void StepTowards(Game.Ent_Dynamic ent, Game.Ent_Static target, int stop_dist = 0) {
			Logger.Debug("map->step_towards");
		}

		public static void StepAway(Game.Ent_Dynamic ent, Game.Ent_Static target, int? stop_dist) {
			if (stop_dist == null)
				stop_dist = 5;
			Logger.Debug("map->step_away");
		}

		public static void StepTowardsSimple(Game.Ent_Dynamic ent, Game.Ent_Static target) {
			Logger.Debug("map->step_twoards_stupid");
		}

		public static void StepRandom(Game.Ent_Dynamic ent) {
			Logger.Debug("map->step_rand");
		}

		/////
		// 1 2 4 8 -> N S E W
		public static Game.Tile GetStep(Game.Ent_Static ent, int dir) {
			int base_x = ent.x;
			int base_y = ent.y;
			int base_z = ent.z;

			switch (dir) {
				case 1: base_y++; break;
				case 5: base_y++; base_x++; break;
				case 4: base_x++; break;
				case 6: base_y--; base_x++; break;
				case 2: base_y--; break;
				case 10: base_y--; base_x--; break;
				case 8: base_x--; break;
				case 9: base_y++; base_x--; break;
				default: throw new Exception("Bad Dir!"); 
			}

			return GetTile(base_x, base_y, base_z);
		}

		public static Game.Tile GetStepTowards(Game.Ent_Static ent, Game.Ent_Static target, int stop_dist = 0) {
			Logger.Debug("map->get_step_towards");
			return null;
		}

		public static Game.Tile GetStepAway(Game.Ent_Static ent, Game.Ent_Static target, int? stop_dist) {
			if (stop_dist == null)
				stop_dist = 5;
			Logger.Debug("map->get_step_away");
			return null;
		}

		public static Game.Tile GetStepTowardsSimple(Game.Ent_Static ent, Game.Ent_Static target) {
			Logger.Debug("map->get_step_towards_stupid");
			return null;
		}

		/////

		public static void Walk(Game.Ent_Dynamic ent, int dir, int lag = 0) {
			Logger.Debug("map->walk");
		}

		// target can be a number -- in that case it will halt!
		public static void WalkTowards(Game.Ent_Dynamic ent, dynamic target, int stop_dist = 0, int lag = 0) {
			Logger.Debug("map->walk_towards");
		}

		public static void WalkAway(Game.Ent_Dynamic ent, Game.Ent_Static target, int? stop_dist = null, int lag = 0) {
			if (stop_dist == null)
				stop_dist = 5;
			Logger.Debug("map->walk_away");
		}

		public static void WalkTowardsSimple(Game.Ent_Dynamic ent, Game.Ent_Static target, int lag = 0) {
			Logger.Debug("map->walk_towards_stupid");
		}

		/////

		public static ByTable FetchInBlock(Game.Ent_Static a, Game.Ent_Static b) {
			if (a == null || b==null) // confirmed returns empty table if either arg is null
				return new ByTable();
			
			// Determine real upper and lower bounds
			int low_x, low_y, low_z;
			int high_x, high_y, high_z;

			if (a.x < b.x) {
				low_x = a.x;
				high_x = b.x;
			}
			else {
				low_x = b.x;
				high_x = a.x;
			}

			if (a.y < b.y) {
				low_y = a.y;
				high_y = b.y;
			}
			else {
				low_y = b.y;
				high_y = a.y;
			}

			if (a.z < b.z) {
				low_z = a.z;
				high_z = b.z;
			}
			else {
				low_z = b.z;
				high_z = a.z;
			}

			// Clamp min/max within bounds of the map.
			// If we can't, return an empty table.
			if (low_x < 1) low_x = 1;
			else if (low_x > Game13.map_size_x) return new ByTable();

			if (low_y < 1) low_y = 1;
			else if (low_y > Game13.map_size_y) return new ByTable();

			if (low_z < 1) low_z = 1;
			else if (low_z > Game13.map_size_z) return new ByTable();

			if (high_x > Game13.map_size_x) high_x = Game13.map_size_x;
			else if (high_x < 1) return new ByTable();

			if (high_y > Game13.map_size_y) high_y = Game13.map_size_y;
			else if (high_y < 1) return new ByTable();

			if (high_z > Game13.map_size_z) high_z = Game13.map_size_z;
			else if (high_z < 1) return new ByTable();

			// Build result table.
			var result_table = new ByTable();

			for (int x = low_x; x <= high_x; x++) {
				for (int y = low_y; y <= high_y; y++) {
					for (int z = low_z; z <= high_z; z++) {
						result_table.Add(__Map[x-1,y-1,z-1]);
					}
				}
			}

			return result_table;
		}

		// _FOR THE FOLLOWING FUNCTIONS_
		// if first argument is null, use second arg as first and set range to default. This is necessary due to some stupid crap that i dont want to explain and will hopefully fix
		// I DON'T KNOW IF THE PREVIOUS STATEMENT STILL APPLIES, BUT:
		// It is perfectly fine to put the args in reverse order!
		public static ByTable FetchInRange(dynamic a, dynamic b) {
			Logger.Debug("map->fetch_in_range");
			return new ByTable();
		}

		public static ByTable FetchInRangeExcludeThis(dynamic a, dynamic b) {
			Logger.Debug("map->fetch_in_range_nocenter");
			return new ByTable();
		}

		public static ByTable FetchInView(dynamic a, dynamic b) {
			Logger.Debug("map->fetch_in_view");
			return new ByTable();
		}

		public static ByTable FetchInViewExcludeThis(dynamic a, dynamic b) {
			Logger.Debug("map->fetch_in_view_nocenter");
			return new ByTable();
		}

		public static ByTable FetchViewers(dynamic a, dynamic b) {
			Logger.Debug("map->fetch_viewers");
			return new ByTable();
		}

		public static ByTable FetchViewersExcludeThis(dynamic a, dynamic b) {
			Logger.Debug("map->fetch_viewers_nocenter");
			return new ByTable();
		}

		public static ByTable FetchHearers(dynamic a, dynamic b) {
			Logger.Debug("map->fetch_hearers");
			return new ByTable();
		}

		public static ByTable FetchHearersExcludeThis(dynamic a, dynamic b) {
			Logger.Debug("map->fetch_hearers_nocenter");
			return new ByTable();
		}

		////////////////////////////////

		private static Dictionary<Type, Game.Zone> zone_insts = new Dictionary<Type, Game.Zone>();

		// This is public because we want Game13 to notice us (senpai). In a perfect world, everything dealing with the map would be in this class!
		// In a perfect world, this entire shitshow of a project would never have been created.
		public static Game.Tile[, ,] __Map = new Game.Tile[0, 0, 0];

		public static void __Resize(int x, int y, int z) {
			var old_map = __Map;

			__Map = new Game.Tile[x, y, z];
			
			// LOOKS LIKE THE WHOLE ZONE SINGLETON THING ISNT HANDLED IN A FUCKY WAY -- HOORAY! (still need to investigate!)
			Game.Zone zone_instance = __GetZoneInstance(Game13.default_zone);

			for (int ix = 0; ix < x; ix++) {
				for (int iy = 0; iy < y; iy++) {
					for (int iz = 0; iz < z; iz++) {
						if (ix < old_map.GetLength(0) && iy < old_map.GetLength(1) && iz < old_map.GetLength(2)) {
							__Map[ix, iy, iz] = old_map[ix, iy, iz];
						}
						else {
							Game.Tile tile_instance = Lang13.Call(Game13.default_tile, null);
							Base_Tile.PlaceInMap(tile_instance, ix+1, iy+1, iz+1);
							zone_instance.contents.Add(tile_instance);
						}
					}
				}
			}
		}

		public static Game.Zone __GetZoneInstance(Type t) {
			Game.Zone z;
			if (!zone_insts.TryGetValue(t, out z)) {
				z = Lang13.Call(t, null);
				zone_insts[t] = z;
			}
			return z;
		}

	}

		/*public bool IsLower(MapPos other) {
			return other.z < this.z ||
				(other.z == this.z && other.y < this.y) ||
				(other.z == this.z && other.y == this.y && other.z < this.z);
		}*/
}
