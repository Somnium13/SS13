// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Bmode_Buildholder : Obj_Effect_Bmode {

		public Client cl = null;
		public dynamic builddir = null;
		public dynamic buildhelp = null;
		public Obj_Effect_Bmode_Buildmode buildmode = null;
		public dynamic buildquit = null;
		public Ent_Static throw_atom = null;
		public dynamic fill_left = null;
		public dynamic fill_right = null;

		// Function from file: buildmode.dm
		public Obj_Effect_Bmode_Buildholder ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.buildmodeholders.Or( this );
			return;
		}

		// Function from file: buildmode.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );
			this.cl.screen.Remove( new ByTable(new object [] { this.builddir, this.buildhelp, this.buildmode, this.buildquit }) );
			//this.cl.buildmode_objs.And( ~new ByTable(new object [] { this.builddir, this.buildhelp, this.buildmode, this.buildquit, this }) );
			// FUCKING EXCUSE ME??? (FIXME)
			GlobalVars.buildmodeholders.Remove( this );
			return null;
		}

	}

}