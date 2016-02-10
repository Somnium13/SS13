using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somnium.Engine.ByImpl {
	[AttributeUsage(AttributeTargets.Method)]
	class Verb : Attribute {

	}
	
	[AttributeUsage(AttributeTargets.Method)]
	class VerbInfo : Attribute {
		public VerbInfo( string name = null, string desc = null, string group = null, VerbAccess access = VerbAccess.Default, int range = -1, bool hidden = false) {

		}
	}

	enum VerbAccess { // warning, default behavior depends on object type!
		Default, InView, InViewExcludeThis, InUserLocation, InRange, InUserContents, IsUser
	}

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	class VerbArg : Attribute {
		public VerbArg(int n, InputType type) {

		}

		public VerbArg(int n, InputType type, VerbArgFilter filter, params object[] _params) : this(n, type) {
			if (_params == null)
				_params = new object[] { null };

		}
	}

	enum VerbArgFilter {
		Any, InViewExcludeThis, FromGlobalVar, FromGlobalFunc, FromMemberVar, FromMemberFunc, TheseValues, FromGlobalVarMemberVar
	}

	[Flags]
	enum InputType {
		Null = 1,
		Num = 2,
		Str = 4,
		StrMultiline = 8,
		Color = 16,

		Zone = 32,
		Tile = 64,
		Mob = 128,
		Obj = 256,
		
		File = 512,
		Icon = 1024,
		Sound = 2048,
		
		Any = 4096
	}
}
