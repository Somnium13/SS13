using System;
using System.Collections.Generic;

using Somnium.Engine.NewLib;

namespace Somnium.Engine.ByImpl {
	class ObjectInitializer {
		private Type type;

		private Dictionary<string, object> vars = new Dictionary<string, object>();

		public ObjectInitializer(Type t) {
			type = t;
		}

		public ObjectInitializer Set(string key, object value) {
			vars[key] = value;
			return this;
		}

		public object Call(object[] args)
		{
			Base_Data result = Lang13.Call(type, args);
			foreach (var kv in vars)
			{
				result.vars[kv.Key] = kv.Value;
			}
			return result;
		}
	}
}