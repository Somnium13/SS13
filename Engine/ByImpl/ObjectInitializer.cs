using System;

using Somnium.Engine.NewLib;

namespace Somnium.Engine.ByImpl {
	class ObjectInitializer {
		private Type type;

		public ObjectInitializer(Type t) {
			type = t;
		}

		public ObjectInitializer Set(string key, object value) {
			Logger.Debug("set var in initializer");
			return this;
		}
	}
}