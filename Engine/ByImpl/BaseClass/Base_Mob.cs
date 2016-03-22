

namespace Somnium.Engine.ByImpl
{
	abstract partial class Base_Mob : Game.Obj
	{
		public Game.Client client;

		public string ckey;
		public string key;

		//public ByTable group;

		public int see_in_dark;
		public bool see_infrared;
		public int see_invisible;
		public int sight;

		public Base_Mob(object loc) : base(loc)
		{

		}

		public virtual dynamic Login()
		{
			return null;
		}

		public virtual bool Logout()
		{
			return false; //what should this return by default? what does the return value even DO?
		}

		public void WriteMsg(object o) { }
	}
}
