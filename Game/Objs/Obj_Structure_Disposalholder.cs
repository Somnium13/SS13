// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Disposalholder : Obj_Structure {

		public GasMixture gas = null;
		public bool active = false;
		public int count = 1000;
		public double? destinationTag = 0;
		public double? tomail = 0;
		public bool hasmob = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.invisibility = 101;
		}

		public Obj_Structure_Disposalholder ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: disposal-structures.dm
		public override bool allow_drop(  ) {
			return true;
		}

		// Function from file: disposal-structures.dm
		public override bool relaymove( Mob user = null, int? direction = null ) {
			dynamic M = null;

			
			if ( user.stat != 0 ) {
				return false;
			}

			if ( this.loc != null ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_hearers_in_view( this.loc.loc ) )) {
					M = _a;
					
					M.show_message( "<FONT size=" + Num13.MaxInt( 0, 5 - Map13.GetDistance( this, M ) ) + ">CLONG, clong!</FONT>", 2 );
				}
			}
			GlobalFuncs.playsound( this.loc, "sound/effects/clang.ogg", 50, 0, 0 );
			return false;
		}

		// Function from file: disposal-structures.dm
		public void vent_gas( dynamic T = null ) {
			((Ent_Static)T).assume_air( this.gas );
			((Tile)T).air_update_turf();
			return;
		}

		// Function from file: disposal-structures.dm
		public void merge( dynamic other = null ) {
			Ent_Dynamic AM = null;
			Ent_Dynamic M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( other, typeof(Ent_Dynamic) )) {
				AM = _a;
				
				AM.loc = this;

				if ( AM is Mob ) {
					M = AM;
					((dynamic)M).reset_perspective( this );
				}
			}
			GlobalFuncs.qdel( other );
			return;
		}

		// Function from file: disposal-structures.dm
		public Obj_Structure_Disposalpipe findpipe( Tile T = null ) {
			int fdir = 0;
			Obj_Structure_Disposalpipe P = null;

			
			if ( !( T != null ) ) {
				return null;
			}
			fdir = Num13.Rotate( this.dir, 180 );

			foreach (dynamic _a in Lang13.Enumerate( T, typeof(Obj_Structure_Disposalpipe) )) {
				P = _a;
				

				if ( ( fdir & P.dpdir ) != 0 ) {
					return P;
				}
			}
			return null;
		}

		// Function from file: disposal-structures.dm
		public Tile nextloc(  ) {
			return Map13.GetStep( this.loc, this.dir );
		}

		// Function from file: disposal-structures.dm
		public void move(  ) {
			dynamic last = null;
			dynamic curr = null;

			
			while (this.active) {
				curr = this.loc;
				last = curr;
				curr = ((Obj_Structure_Disposalpipe)curr).transfer( this );

				if ( !Lang13.Bool( curr ) && this.active ) {
					last.expel( this, this.loc, this.dir );
				}
				Task13.Sleep( 1 );

				if ( !( this.count-- != 0 ) ) {
					this.active = false;
				}
			}
			return;
		}

		// Function from file: disposal-structures.dm
		public void start( Obj_Machinery_Disposal D = null ) {
			
			if ( !Lang13.Bool( D.trunk ) ) {
				D.expel( this );
				return;
			}
			this.loc = D.trunk;
			this.active = true;
			this.dir = GlobalVars.DOWN;
			this.move();
			return;
		}

		// Function from file: disposal-structures.dm
		public void init( Obj_Machinery_Disposal D = null ) {
			Mob_Living M = null;
			Obj O = null;
			Mob_Living M2 = null;
			Ent_Dynamic AM = null;
			Ent_Dynamic T = null;
			Ent_Dynamic T2 = null;

			this.gas = D.air_contents;

			foreach (dynamic _a in Lang13.Enumerate( D, typeof(Mob_Living) )) {
				M = _a;
				

				if ( M.client != null ) {
					M.reset_perspective( this );
				}
				this.hasmob = true;
			}

			foreach (dynamic _c in Lang13.Enumerate( D, typeof(Obj) )) {
				O = _c;
				

				if ( O.contents != null ) {
					
					foreach (dynamic _b in Lang13.Enumerate( O.contents, typeof(Mob_Living) )) {
						M2 = _b;
						
						this.hasmob = true;
					}
				}
			}

			foreach (dynamic _d in Lang13.Enumerate( D, typeof(Ent_Dynamic) )) {
				AM = _d;
				
				AM.loc = this;

				if ( AM is Obj_Structure_BigDelivery && !this.hasmob ) {
					T = AM;
					this.destinationTag = Lang13.DoubleNullable( ((dynamic)T).sortTag );
				}

				if ( AM is Obj_Item_SmallDelivery && !this.hasmob ) {
					T2 = AM;
					this.destinationTag = Lang13.DoubleNullable( ((dynamic)T2).sortTag );
				}
			}
			return;
		}

		// Function from file: disposal-structures.dm
		public override dynamic Destroy(  ) {
			GlobalFuncs.qdel( this.gas );
			this.active = false;
			return base.Destroy();
		}

	}

}