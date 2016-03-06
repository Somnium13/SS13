// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_AoeTurf_Conjure : Obj_Effect_ProcHolder_Spell_AoeTurf {

		public ByTable summon_type = new ByTable();
		public int summon_lifespan = 0;
		public int? summon_amt = 1;
		public bool summon_ignore_density = false;
		public bool summon_ignore_prev_spawn_points = false;
		public ByTable newVars = new ByTable();
		public string cast_sound = "sound/items/welder.ogg";

		public Obj_Effect_ProcHolder_Spell_AoeTurf_Conjure ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: conjure.dm
		public override bool cast( dynamic targets = null, dynamic thearea = null, dynamic user = null ) {
			thearea = thearea ?? Task13.User;

			dynamic T = null;
			int? i = null;
			dynamic summoned_object_type = null;
			dynamic spawn_place = null;
			dynamic O = null;
			dynamic N = null;
			dynamic summoned_object = null;
			dynamic varName = null;

			GlobalFuncs.playsound( GlobalFuncs.get_turf( thearea ), this.cast_sound, 50, 1 );

			foreach (dynamic _a in Lang13.Enumerate( targets )) {
				T = _a;
				

				if ( T.density && !this.summon_ignore_density ) {
					targets -= T;
				}
			}
			i = null;
			i = 0;

			while (( i ??0) < ( this.summon_amt ??0)) {
				
				if ( !( targets.len != 0 ) ) {
					break;
				}
				summoned_object_type = Rand13.PickFromTable( this.summon_type );
				spawn_place = Rand13.PickFromTable( targets );

				if ( this.summon_ignore_prev_spawn_points ) {
					targets -= spawn_place;
				}

				if ( Lang13.Bool( summoned_object_type.IsSubclassOf( typeof(Tile) ) ) ) {
					O = spawn_place;
					N = summoned_object_type;
					((Tile)O).ChangeTurf( N );
				} else {
					summoned_object = Lang13.Call( summoned_object_type, spawn_place );

					foreach (dynamic _b in Lang13.Enumerate( this.newVars )) {
						varName = _b;
						

						if ( summoned_object.vars.Contains( varName ) ) {
							summoned_object.vars[varName] = this.newVars[varName];
						}
					}

					if ( this.summon_lifespan != 0 ) {
						Task13.Schedule( this.summon_lifespan, (Task13.Closure)(() => {
							
							if ( Lang13.Bool( summoned_object ) ) {
								GlobalFuncs.qdel( summoned_object );
							}
							return;
						}));
					}
				}
				i++;
			}
			return false;
		}

	}

}