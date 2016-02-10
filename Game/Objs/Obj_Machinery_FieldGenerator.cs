// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_FieldGenerator : Obj_Machinery {

		public int num_power_levels = 6;
		public bool Varedit_start = false;
		public bool Varpower = false;
		public int active = 0;
		public double? power = 20;
		public int warming_up = 0;
		public ByTable fields = null;
		public ByTable connected_gens = null;
		public bool clean_up = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.use_power = 0;
			this.machine_flags = 88;
			this.icon = "icons/obj/machines/field_generator.dmi";
			this.icon_state = "Field_Gen";
		}

		// Function from file: field_generator.dm
		public Obj_Machinery_FieldGenerator ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.fields = new ByTable();
			this.connected_gens = new ByTable();
			GlobalVars.field_gen_list.Add( this );
			return;
		}

		// Function from file: field_generator.dm
		public void cleanup(  ) {
			Obj_Effect_Beam B = null;
			Obj_Machinery_ContainmentField F = null;
			Obj_Machinery_FieldGenerator FG = null;
			bool temp = false;
			Obj_Machinery_Singularity O = null;

			this.clean_up = true;

			foreach (dynamic _a in Lang13.Enumerate( this.beams, typeof(Obj_Effect_Beam) )) {
				B = _a;
				

				if ( !( B != null ) ) {
					continue;
				}

				if ( B.target == this ) {
					B.target = null;
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( this.fields, typeof(Obj_Machinery_ContainmentField) )) {
				F = _b;
				

				if ( F == null ) {
					continue;
				}
				GlobalFuncs.qdel( F );
				F = null;
			}
			this.fields = new ByTable();

			foreach (dynamic _c in Lang13.Enumerate( this.connected_gens, typeof(Obj_Machinery_FieldGenerator) )) {
				FG = _c;
				

				if ( FG == null ) {
					continue;
				}
				FG.connected_gens.Remove( this );

				if ( !FG.clean_up ) {
					FG.cleanup();
				}
				this.connected_gens.Remove( FG );
			}
			this.connected_gens = new ByTable();
			this.clean_up = false;
			this.update_icon();
			Task13.Schedule( 1, (Task13.Closure)(() => {
				temp = true;

				foreach (dynamic _d in Lang13.Enumerate( GlobalVars.power_machines, typeof(Obj_Machinery_Singularity) )) {
					O = _d;
					

					if ( O.last_warning != 0 && temp ) {
						
						if ( Game13.time - O.last_warning > 50 ) {
							temp = false;
							GlobalFuncs.message_admins( "A singulo exists and a containment field has failed." );
							this.investigation_log( "singulo", "has <font color='red'>failed</font> whilst a singulo exists." );
						}
					}
					O.last_warning = Game13.time;
				}
				return;
			}));
			return;
		}

		// Function from file: field_generator.dm
		public bool setup_field( int NSEW = 0 ) {
			Ent_Static T = null;
			dynamic G = null;
			int? steps = null;
			int? dist = null;
			Ent_Static A = null;
			int? dist2 = null;
			int field_dir = 0;
			Obj_Machinery_ContainmentField CF = null;
			bool listcheck = false;
			Obj_Machinery_FieldGenerator FG = null;
			Obj_Machinery_FieldGenerator FG2 = null;

			T = this.loc;
			steps = 0;

			if ( !( NSEW != 0 ) ) {
				return false;
			}
			dist = null;
			dist = 0;

			while (( dist ??0) <= 9) {
				T = Map13.GetStep( T, NSEW );

				if ( T.density ) {
					return false;
				}

				foreach (dynamic _a in Lang13.Enumerate( T.contents, typeof(Ent_Static) )) {
					A = _a;
					

					if ( A is Mob ) {
						continue;
					}

					if ( !( A is Obj_Machinery_FieldGenerator ) ) {
						
						if ( ( A is Obj_Machinery_Door || A is Obj_Machinery_TheSingularitygen ) && A.density ) {
							return false;
						}
					}
				}
				steps += 1;
				G = Lang13.FindIn( typeof(Obj_Machinery_FieldGenerator), T );

				if ( !( G == null ) ) {
					steps -= 1;

					if ( !Lang13.Bool( G.active ) ) {
						return false;
					}
					break;
				}
				dist += 1;
			}

			if ( G == null ) {
				return false;
			}
			T = this.loc;
			dist2 = null;
			dist2 = 0;

			while (( dist2 ??0) < ( steps ??0)) {
				field_dir = Map13.GetDistance( T, Map13.GetStep( G.loc, NSEW ) );
				T = Map13.GetStep( T, NSEW );

				if ( !Lang13.Bool( Lang13.FindIn( typeof(Obj_Machinery_ContainmentField), T ) ) ) {
					CF = new Obj_Machinery_ContainmentField();
					CF.set_master( this, G );
					this.fields.Add( CF );
					G.fields += CF;
					CF.loc = T;
					CF.dir = field_dir;
				}
				dist2 += 1;
			}
			listcheck = false;

			foreach (dynamic _b in Lang13.Enumerate( this.connected_gens, typeof(Obj_Machinery_FieldGenerator) )) {
				FG = _b;
				

				if ( FG == null ) {
					continue;
				}

				if ( FG == G ) {
					listcheck = true;
					break;
				}
			}

			if ( !listcheck ) {
				this.connected_gens.Add( G );
			}
			listcheck = false;

			foreach (dynamic _c in Lang13.Enumerate( G.connected_gens, typeof(Obj_Machinery_FieldGenerator) )) {
				FG2 = _c;
				

				if ( FG2 == null ) {
					continue;
				}

				if ( FG2 == this ) {
					listcheck = true;
					break;
				}
			}

			if ( !listcheck ) {
				G.connected_gens.Add( this );
			}
			return false;
		}

		// Function from file: field_generator.dm
		public void start_fields(  ) {
			
			if ( ( !Lang13.Bool( this.state ) ?1:0) == 2 || !Lang13.Bool( this.anchored ) ) {
				this.turn_off();
				return;
			}
			Task13.Schedule( 1, (Task13.Closure)(() => {
				this.setup_field( 1 );
				return;
			}));
			Task13.Schedule( 2, (Task13.Closure)(() => {
				this.setup_field( 2 );
				return;
			}));
			Task13.Schedule( 3, (Task13.Closure)(() => {
				this.setup_field( 4 );
				return;
			}));
			Task13.Schedule( 4, (Task13.Closure)(() => {
				this.setup_field( 8 );
				return;
			}));
			this.active = 2;
			return;
		}

		// Function from file: field_generator.dm
		public bool draw_power( double? draw = null, int? failsafe = null, Obj_Machinery_FieldGenerator G = null, Obj_Machinery_FieldGenerator last = null ) {
			draw = draw ?? 0;
			failsafe = failsafe ?? 0;

			Obj_Machinery_FieldGenerator FG = null;

			
			if ( this.Varpower ) {
				return true;
			}

			if ( G != null && G == this || ( failsafe ??0) >= 8 ) {
				return false;
			} else {
				failsafe++;
			}

			if ( ( this.power ??0) >= ( draw ??0) ) {
				this.power -= draw ??0;
				return true;
			} else {
				draw -= this.power ??0;
				this.power = 0;

				foreach (dynamic _a in Lang13.Enumerate( this.connected_gens, typeof(Obj_Machinery_FieldGenerator) )) {
					FG = _a;
					

					if ( FG == null ) {
						continue;
					}

					if ( FG == last ) {
						continue;
					}

					if ( G != null ) {
						
						if ( FG.draw_power( draw, failsafe, G, this ) ) {
							return true;
						} else {
							return false;
						}
					} else if ( FG.draw_power( draw, failsafe, this, this ) ) {
						return true;
					} else {
						return false;
					}
				}
			}
			return false;
		}

		// Function from file: field_generator.dm
		public bool calc_power(  ) {
			int power_draw = 0;
			Obj_Machinery_ContainmentField F = null;
			dynamic M = null;

			
			if ( this.Varpower ) {
				return true;
			}
			this.update_icon();

			if ( ( this.power ??0) > 250 ) {
				this.power = 250;
			}
			power_draw = 2;

			foreach (dynamic _a in Lang13.Enumerate( this.fields, typeof(Obj_Machinery_ContainmentField) )) {
				F = _a;
				

				if ( F == null ) {
					continue;
				}
				power_draw++;
			}

			if ( this.draw_power( Num13.Round( power_draw / 2, 1 ) ) ) {
				return true;
			} else {
				
				foreach (dynamic _b in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
					M = _b;
					
					M.show_message( "<span class='warning'>The " + this.name + " shuts down!</span>" );
				}
				this.turn_off();
				this.investigation_log( "singulo", "ran out of power and <font color='red'>deactivated</font>" );
				this.power = 0;
				return false;
			}
		}

		// Function from file: field_generator.dm
		public void turn_on(  ) {
			this.active = 1;
			this.warming_up = 1;
			Task13.Schedule( 1, (Task13.Closure)(() => {
				
				while (this.warming_up < 3 && this.active != 0) {
					Task13.Sleep( 50 );
					this.warming_up++;
					this.update_icon();

					if ( this.warming_up >= 3 ) {
						this.start_fields();
					}
				}
				return;
			}));
			this.update_icon();
			return;
		}

		// Function from file: field_generator.dm
		public void turn_off(  ) {
			this.active = 0;
			Task13.Schedule( 1, (Task13.Closure)(() => {
				this.cleanup();
				return;
			}));
			this.update_icon();
			return;
		}

		// Function from file: field_generator.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			this.cleanup();
			GlobalVars.field_gen_list.Remove( this );
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: field_generator.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			
			if ( Proj.flag != "bullet" ) {
				this.power += Convert.ToDouble( Proj.damage );
				this.update_icon();
			}
			return 0;
		}

		// Function from file: field_generator.dm
		public override bool blob_act( dynamic severity = null ) {
			
			if ( this.active != 0 ) {
				return false;
			} else {
				base.blob_act( (object)(severity) );
			}
			return false;
		}

		// Function from file: field_generator.dm
		public override dynamic emp_act( int severity = 0 ) {
			return 0;
		}

		// Function from file: field_generator.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( this.active != 0 ) {
				GlobalFuncs.to_chat( b, "The " + this + " needs to be off." );
				return null;
			} else if ( Lang13.Bool( base.attackby( (object)(a), (object)(b), (object)(c) ) ) ) {
				return 1;
			}
			return null;
		}

		// Function from file: field_generator.dm
		public override int wrenchAnchor( dynamic user = null ) {
			
			if ( this.active != 0 ) {
				GlobalFuncs.to_chat( user, "Turn off the " + this + " first." );
				return -1;
			}
			return base.wrenchAnchor( (object)(user) );
		}

		// Function from file: field_generator.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Mob_Dead_Observer && !GlobalFuncs.isAdminGhost( a ) ) {
				return 0;
			}

			if ( this.state == 2 ) {
				
				if ( Map13.GetDistance( this, a ) <= 1 ) {
					
					if ( this.active >= 1 ) {
						GlobalFuncs.to_chat( a, "You are unable to turn off the " + this.name + " once it is online." );
						return 1;
					} else {
						((Ent_Static)a).visible_message( "" + a.name + " turns on the " + this.name, "You turn on the " + this.name + ".", "You hear heavy droning" );
						this.turn_on();
						this.investigation_log( "singulo", "<font color='green'>activated</font> by " + a.key + "." );
						this.add_fingerprint( a );
					}
				}
			} else {
				GlobalFuncs.to_chat( a, "The " + this + " needs to be firmly secured to the floor first." );
				return 0;
			}
			return null;
		}

		// Function from file: field_generator.dm
		public override dynamic process(  ) {
			Obj_Effect_Beam B = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.beams, typeof(Obj_Effect_Beam) )) {
				B = _a;
				
				this.power += B.get_damage();
			}

			if ( this.Varedit_start ) {
				
				if ( this.active == 0 ) {
					this.active = 1;
					this.state = 2;
					this.power = 250;
					this.anchored = 1;
					this.warming_up = 3;
					this.start_fields();
					this.update_icon();
				}
				this.Varedit_start = false;
			}

			if ( this.active == 2 ) {
				this.calc_power();
				this.update_icon();
			}
			return null;
		}

		// Function from file: field_generator.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			int level = 0;

			this.overlays.len = 0;

			if ( !( this.active != 0 ) ) {
				
				if ( this.warming_up != 0 ) {
					this.overlays.Add( "+a" + this.warming_up );
				}
			}

			if ( this.fields.len != 0 ) {
				this.overlays.Add( "+on" );
			}
			level = Num13.Floor( ( this.power ??0) * 6 / 250 );
			level = ( level <= 0 ? 0 : ( level >= GlobalVars.num_power_levels ? GlobalVars.num_power_levels : level ) );

			if ( level != 0 ) {
				this.overlays.Add( "+p" + level );
			}
			return null;
		}

	}

}