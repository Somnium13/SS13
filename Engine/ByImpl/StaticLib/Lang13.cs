using System;

using Somnium.Engine.NewLib;

namespace Somnium.Engine.ByImpl {
	static class Lang13 {
		public static bool Bool(object v) {	// This is used whenever the transcompiler needs to force a boolean value --
			if (v is bool) return (bool)v;		// The values it checks for are anything Byond considers 'false'
			return !(v == null || v.Equals("") || v.Equals(0) || v.Equals(0.0));
		}

		// The rest of these were added during the overhaul of the type inference system.
		// They generally make code more ugly, but should prevent errors.
		/*public static int Int(object v) {
			return Convert.ToInt32(v);
		}

		public static double Double(object v) {
			return Convert.ToDouble(v);
		}*/

		public static bool? BoolNullable(object v) {
			if (v == null)
				return null;

			return Bool(v);
		}

		public static int? IntNullable(object v) {
			if (v == null)
				return null;

			return Convert.ToInt32(v);
		}

		public static double? DoubleNullable(object v) {
			if (v == null)
				return null;

			return Convert.ToDouble(v);
		}

		public static bool IsNumber(object v) {
			return (v is int || v is double || v is bool); // No way this is a terrible idea /s
		} // (should probably cover more types, not sure if we should allow bool -- probably, since there's no difference in Byond)

		public static bool IsLocation(dynamic v) {
			return (v is Game.Zone || v is Game.Tile || v is Game.Obj || v is Game.Mob); // from the ref
		}

		public static bool IsInRange(double n, double low, double high) {
			return n >= low && n <= high;
		}

		// Length function -- we were just using the 'Length' params but sometimes this gets called with odd values.
		public static int Length(object o) {
			if (o == null)
				return 0;
			else if (o is ByTable)
				return ((ByTable)o).len;
			else if (o is string)
				return ((string)o).Length;
			return 0;
		}

		// Returns a table containing all of the subtypes of base_types, including base_types.
		public static ByTable GetTypes(params object[] base_types) {

			var type_table = new ByTable(base_types);
			
			foreach (object bt in base_types) {
				
				if (bt is Type) {
					// I feel disguested by this code, surely it can be optimized. (Cache results, and only do this loop once if multiple base_types are specified.)
					foreach (var asm in AppDomain.CurrentDomain.GetAssemblies()) {
						foreach (var t in asm.GetTypes()) {
							if (t.IsSubclassOf((Type)bt)) {
								type_table.Add(t);
							}
						}
					}
				}
				else {
					throw new Exception("get_all_types does not know how to deal with a "+bt.GetType());
				}
			
			}

			return type_table;
		}

		// STUB! Returns true if the object has a function of the specified name. QUESTION: How are verbs handled?
		public static bool HasCall(dynamic obj, string function_name) {
			Logger.Debug("@hascall");
			return false;
		}

		private static string fix_class_part(string part) {
			string[] split_part = part.Split('_');
			string fixed_part = "";

			foreach (string s in split_part) {
				fixed_part += s[0].ToString().ToUpper() + s.Substring(1);
			}

			return fixed_part;
		}

		// Attempts to find a class with the specified BYOND path. Just use a bunch of guesswork... Deprecate ASAP
		public static Type FindClass(string path) {
			//NewConsole.debug("@findClass "+path);
			
			string[] split_path = path.Split('/');
			string class_name = null;
			for (int i = 1; i < split_path.Length; i++) {
				string part = split_path[i];
				if (i == 1) {
					if (part == "datum")
					{
						continue;
					}
					else if (part == "area") {
						class_name = "Zone";
					}
					else if (part == "turf") {
						class_name = "Tile";
					}
					else {
						class_name = fix_class_part(part);
					}
				}
				else {
					if (class_name!=null)
						class_name += "_" + fix_class_part(part);
					else
						class_name = fix_class_part(part);
				}
			}

			Type t = Type.GetType("Somnium.Game." + class_name);
			if (t == null)
				Logger.Warning("Could not find type: " + path + "","Tried: "+class_name);
			return t;
		}
		
		public static dynamic FindIn(object type, object container) { // type is a string or type, container is a table or a Tile?

			Type real_type;
			ByTable real_container;

			if (type is Type) {
				real_type = (Type)type;
			}
			else {
				throw new Exception("Fixme");
			}

			if (container is ByTable) {
				real_container = (ByTable)container;
			}
			else if (container is Base_Static) {
				real_container = ((Base_Static)container).contents;
			}
			else {
				throw new Exception("Fixme");
			}

			for (int i = 1; i <= real_container.len; i++) { // TODO DO NON-NUMERIC KEY-VALUES MATTER?
				if (real_type.IsInstanceOfType(real_container[i])) {
					return real_container[i];
				}
			}

			return null;
		}

		public static dynamic FindObj(dynamic id) {
			if (id is Type) {
				Type t = id;
				if (t == typeof(Game.Zone) || t.IsSubclassOf(typeof(Game.Zone))) {
					return Map13.__GetZoneInstance(t);
				}
			}
			Logger.Debug2("@find_obj "+id);
			return null;
		}

		// We're going to have fun with this one.
		public static void Delete(dynamic obj) {
			Logger.Debug2("@delete");
		}

		private static object[] resize_arg_list(object[] args, int required_count) {
			if (args == null) {
				args = new object[] { null };
			}
			if (args.Length < required_count) {
				object[] new_args = new object[required_count];
				args.CopyTo(new_args, 0);
				for (int i = args.Length; i < required_count; i++) {
					new_args[i] = Type.Missing;
				}
				return new_args;
			}
			else if (args.Length > required_count) {
				var new_args = new object[required_count];
				for (int i = 0; i < required_count; i++) {
					new_args[i] = args[i];
				}
				return new_args;
			}
			return args;
		}

		public static dynamic Call(string t, params object[] objs) { //oh hell - seems to be only for ctors, at least
			Type real_type = FindClass(t);
			if (real_type == null)
				throw new Exception("Call-typename: Could not find \""+t+"\"");
			return Call(real_type, objs);
		}

		public static dynamic Call(Type t, params object[] args) { // call ctor -- TODO, IM SURE THIS COULD USE WORK!
			var ctor_canidates = t.GetConstructors();
			if (ctor_canidates.Length != 1)
				throw new Exception("Incorrent number of canidate ctors for " + t + " ( " + ctor_canidates.Length + " )");
			var the_ctor = ctor_canidates[0];

			args = resize_arg_list(args, the_ctor.GetParameters().Length);

			object result = the_ctor.Invoke(args);
			return result;
		}

		public static dynamic Call(System.Reflection.MethodInfo f, params object[] args) { // call a global function
			args = resize_arg_list(args, f.GetParameters().Length);
			
			var result = f.Invoke(null, args);
			return result;
		}

		public static dynamic Call(BoundFunc f, params object[] objs) { // call a bound method
			Logger.Debug("@call bound");
			return null;
		}

		public static dynamic Call(ObjectInitializer f, params object[] objs)
		{
			Logger.Debug("@call initializer");
			return null;
		}

		//This is probably good now. This binds a MethodInfo to an object, or fetches the methodinfo and binds it based on the name.
		public static BoundFunc BindFunc(dynamic _this, dynamic f) {
			Logger.Debug("@bindf");
			return null;
		}

		public static System.Reflection.MethodInfo GetLibFunc(string lib, string name) {
			Logger.Debug2("@getf_dll: "+lib+" ~ "+name);
			return null;
		}

		public static System.Collections.IEnumerable IterateRange(double? start, double? end, double step=1) {
            //if(start== null || end==null) -- Rolled back Pdan's change. We really want to know when this fucks up.
            //{ yield return null; }		-- We also don't know how Byond behaves when one of these is null.

			for (double i = (double)start; i <= (double)end; i += step) {
				yield return i;
			}
		}

		public static System.Collections.IEnumerable Enumerate(object o, Type t = null) {
			if (o == null)
				return new System.Collections.ArrayList(); // bigstupid
			else if (o is ByTable)
				return ((ByTable)o).__GetEnumerationList(t);
			else if (o is Base_Static)
				return ((Base_Static)o).contents.__GetEnumerationList(t);
			else if (o == typeof(Game13))
				return Game13.contents.__GetEnumerationList(t);
			else
				throw new Exception("Don't know how to enumarate: "+o);
		}

		public static dynamic Initial(object o, string key) {
			if (o is Game.Ent_Static)
			{
				dynamic result;
				if (((Game.Ent_Static)o).__TryGetInitial(key, out result))
				{
					return result;
				}
			}
			if (o is Type)
				throw new Exception("Attempt to get initial field of TYPE!");
			else
				Logger.Warning("Initial " + key, "in " + o);
			return null;
		}

		public static dynamic InitialBroken(object o) {
			Logger.Debug("!!Initial-Broken");
			return null;
		}

		public static bool IsSaved(object o, string key) {
			Logger.Debug("!!Saved");
			return false;
		}

		public static bool IsSavedBroken(object o) {
			Logger.Debug("!!Saved-Broken");
			return false;
		}

		public static dynamic SuperCall(params object[] args) {
			// This is generated when a function attempts to call a super function, but one doesn't exist.
			Logger.Debug("!!Super Function");
			return null;
		}
	}

	class BoundFunc {

	}
}
