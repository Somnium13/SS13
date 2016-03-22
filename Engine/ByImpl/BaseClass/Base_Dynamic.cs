using System;

namespace Somnium.Engine.ByImpl
{
	abstract class Base_Dynamic : Game.Ent_Static
	{
		public Base_Dynamic(Game.Ent_Static loc)
		{
			this.loc = loc;
			this._contents = new EntContentsTable(this);
		}

		public override int x
		{
			get { if (_loc == null) return -1; return _loc.x; }
			set { throw new Exception("TODO"); }
		}

		public override int y
		{
			get { if (_loc == null) return -1; return _loc.y; }
			set { throw new Exception("TODO"); }
		}

		public override int z
		{
			get { if (_loc == null) return -1; return _loc.z; }
			set { throw new Exception("TODO"); }
		}

		public int glide_size;

		public int bound_width;
		public int bound_height;

		public string screen_loc;

		public virtual bool Move(dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0)
		{
			return false;
		}

		public virtual dynamic Bump(Game.Ent_Static Obstacle = null, dynamic yes = null)
		{
			return null;
		}

		public virtual dynamic Crossed(Game.Ent_Dynamic O = null, dynamic X = null)
		{
			return null;
		}

		public virtual void Uncrossed(Game.Ent_Dynamic O = null)
		{
			return;
		}
	}
}
