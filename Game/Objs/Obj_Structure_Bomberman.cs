// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Bomberman : Obj_Structure {

		public int? bombpower = 1;
		public bool? destroy_environnement = false;
		public bool? hurt_players = false;
		public Obj_Item_Weapon_Bomberman parent = null;
		public int countdown = 3;
		public bool kicked = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/bomberman.dmi";
			this.icon_state = "bomb";
		}

		// Function from file: bomberman.dm
		public Obj_Structure_Bomberman ( dynamic loc = null, int? Bpower = null, bool? destroy = null, bool? hurt = null, Obj_Item_Weapon_Bomberman dispenser = null, int? line_dir = null ) : base( (object)(loc) ) {
			Bpower = Bpower ?? 1;
			destroy = destroy ?? false;
			hurt = hurt ?? false;

			dynamic T1 = null;
			dynamic T2 = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.bombpower = Bpower;
			this.destroy_environnement = destroy;
			this.hurt_players = hurt;
			this.parent = dispenser;
			GlobalVars.bombermangear.Add( this );

			if ( ( !( this.parent != null ) || !( this.parent.arena != null ) ) && GlobalVars.bomberman_hurt ) {
				this.hurt_players = true;
			}

			if ( ( !( this.parent != null ) || !( this.parent.arena != null ) ) && GlobalVars.bomberman_destroy ) {
				this.destroy_environnement = true;
			}

			if ( Lang13.Bool( line_dir ) ) {
				T1 = GlobalFuncs.get_turf( this );
				Map13.Step( this, line_dir ??0 );
				T2 = GlobalFuncs.get_turf( this );

				if ( T1 == T2 ) {
					GlobalFuncs.qdel( this );
				} else if ( this.parent.bomblimit > 0 ) {
					this.parent.bomblimit--;
					new Obj_Structure_Bomberman( T2, this.bombpower, this.destroy_environnement, this.hurt_players, this.parent, line_dir );
				}
			}
			this.ticking();
			return;
		}

		// Function from file: bomberman.dm
		public override bool singuloCanEat(  ) {
			return false;
		}

		// Function from file: bomberman.dm
		public override dynamic cultify(  ) {
			return null;
		}

		// Function from file: bomberman.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			this.detonate();
			return false;
		}

		// Function from file: bomberman.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			this.visible_message( new Txt( "<span class='warning'>" ).The( Proj ).item().str( " hits " ).the( this ).item().str( ".</span>" ).ToString() );
			this.detonate();
			return null;
		}

		// Function from file: bomberman.dm
		public override dynamic emp_act( int severity = 0 ) {
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: bomberman.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( this.parent != null ) {
				this.parent.bomblimit++;
			}
			GlobalVars.bombermangear.Remove( this );
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: bomberman.dm
		[VerbInfo( name: "kicked" )]
		public void f_kicked( int kick_dir = 0 ) {
			dynamic T1 = null;
			dynamic T2 = null;

			T1 = GlobalFuncs.get_turf( this );
			Map13.Step( this, kick_dir );
			T2 = GlobalFuncs.get_turf( this );

			if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Bomberflame), T2 ) ) ) {
				this.detonate();
			}

			if ( T1 != T2 ) {
				Task13.Sleep( 2 );
				this.f_kicked( kick_dir );
			} else {
				this.kicked = false;
			}
			return;
		}

		// Function from file: bomberman.dm
		public virtual void detonate(  ) {
			dynamic T = null;

			T = GlobalFuncs.get_turf( this );

			if ( !Lang13.Bool( T ) ) {
				GlobalFuncs.qdel( this );
				return;
			}
			GlobalFuncs.playsound( T, "sound/bomberman/bombexplode.ogg", 100, 1 );
			Task13.Schedule( 0, (Task13.Closure)(() => {
				new Obj_Structure_Bomberflame( T, true, this.bombpower, GlobalVars.SOUTH, this.destroy_environnement, this.hurt_players );
				return;
			}));
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: bomberman.dm
		public void ticking(  ) {
			this.countdown--;
			Task13.Sleep( 10 );

			if ( this.countdown <= 0 ) {
				this.detonate();
			} else {
				this.ticking();
			}
			return;
		}

		// Function from file: bomberman.dm
		public override bool Bumped( Ent_Static AM = null, dynamic yes = null ) {
			Obj_Item_Weapon_Bomberman dispenser = null;

			
			foreach (dynamic _a in Lang13.Enumerate( AM, typeof(Obj_Item_Weapon_Bomberman) )) {
				dispenser = _a;
				

				if ( dispenser.can_kick && !this.kicked ) {
					this.kicked = true;
					this.f_kicked( Map13.GetDistance( AM, this ) );
				}
			}
			base.Bumped( AM, (object)(yes) );
			return false;
		}

		// Function from file: bomberman.dm
		public override dynamic Bump( Obj Obstacle = null, dynamic yes = null ) {
			this.kicked = false;
			base.Bump( Obstacle );
			return null;
		}

	}

}