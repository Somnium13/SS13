// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Spell_Targeted : Spell {

		public int? max_targets = 1;
		public bool target_ignore_prev = true;
		public int amt_weakened = 0;
		public int amt_paralysis = 0;
		public int amt_stunned = 0;
		public int amt_dizziness = 0;
		public int amt_confused = 0;
		public int amt_stuttering = 0;
		public int amt_dam_fire = 0;
		public int amt_dam_brute = 0;
		public bool amt_dam_oxy = false;
		public bool amt_dam_tox = false;
		public int amt_eye_blind = 0;
		public int amt_eye_blurry = 0;
		public bool mind_affecting = false;
		public ByTable compatible_mobs = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.spell_flags = 128;
		}

		// Function from file: targeted.dm
		public bool tinfoil_check( Mob user = null ) {
			
			if ( !( user is Mob_Living_Carbon_Human ) ) {
				return false;
			}

			if ( Lang13.Bool( ((dynamic)user).head ) && ((dynamic)user).head is Obj_Item_Clothing_Head_Tinfoil ) {
				return true;
			}
			return false;
		}

		// Function from file: targeted.dm
		public void apply_spell_damage( Mob_Living target = null ) {
			target.adjustBruteLoss( this.amt_dam_brute );
			target.adjustFireLoss( this.amt_dam_fire );
			target.adjustToxLoss( this.amt_dam_tox );
			target.adjustOxyLoss( this.amt_dam_oxy );
			target.Weaken( this.amt_weakened );
			target.Paralyse( this.amt_paralysis );
			target.Stun( this.amt_stunned );

			if ( this.amt_weakened != 0 || this.amt_paralysis != 0 || this.amt_stunned != 0 ) {
				
				if ( Lang13.Bool( target.locked_to ) ) {
					((Ent_Dynamic)target.locked_to).unlock_atom( target );
				}
			}
			target.eye_blind += this.amt_eye_blind;
			target.eye_blurry += this.amt_eye_blurry;
			target.dizziness += this.amt_dizziness;
			target.confused += this.amt_confused;
			target.stuttering += this.amt_stuttering;
			return;
		}

		// Function from file: targeted.dm
		public override bool cast( ByTable targets = null, Mob user = null ) {
			Mob_Living target = null;

			
			foreach (dynamic _a in Lang13.Enumerate( targets, typeof(Mob_Living) )) {
				target = _a;
				

				if ( ( this.range ??0) >= 0 ) {
					
					if ( !GlobalFuncs.view_or_range( this.range, this.holder, this.selection_type ).Contains( target ) ) {
						targets.Remove( target );
						continue;
					}
				}
				this.apply_spell_damage( target );
			}
			return false;
		}

		// Function from file: targeted.dm
		public override ByTable choose_targets( Mob user = null ) {
			user = user ?? Task13.User;

			ByTable targets = null;
			Mob_Living target = null;
			ByTable possible_targets = null;
			ByTable starting_targets = null;
			Mob_Living M = null;
			Mob H = null;
			dynamic temp_target = null;
			ByTable possible_targets2 = null;
			ByTable starting_targets2 = null;
			Mob_Living target2 = null;
			int? i = null;
			dynamic M2 = null;
			int? i2 = null;
			dynamic target3 = null;
			Mob_Living target4 = null;

			
			if ( this.mind_affecting && this.tinfoil_check( user ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>Something is interfering with your ability to target minds.</span>" );
				return null;
			}
			targets = new ByTable();

			if ( this.max_targets == 0 ) {
				
				if ( this.range == -2 ) {
					targets = GlobalVars.living_mob_list;
				} else {
					
					foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.view_or_range( this.range, this.holder, this.selection_type ), typeof(Mob_Living) )) {
						target = _a;
						
						targets.Add( target );
					}
				}
			} else if ( this.max_targets == 1 ) {
				
				if ( ( this.range == 0 || this.range == -1 ) && ( this.spell_flags & 64 ) != 0 ) {
					targets.Add( user );
				} else {
					possible_targets = new ByTable();
					starting_targets = null;

					if ( this.range == -2 ) {
						starting_targets = GlobalVars.living_mob_list;
					} else {
						starting_targets = GlobalFuncs.view_or_range( this.range, this.holder, this.selection_type );
					}

					foreach (dynamic _b in Lang13.Enumerate( starting_targets, typeof(Mob_Living) )) {
						M = _b;
						

						if ( !( ( this.spell_flags & 64 ) != 0 ) && M == user ) {
							continue;
						}

						if ( this.compatible_mobs != null && this.compatible_mobs.len != 0 ) {
							
							if ( !GlobalFuncs.is_type_in_list( M, this.compatible_mobs ) ) {
								continue;
							}
						}

						if ( this.compatible_mobs != null && this.compatible_mobs.len != 0 && !GlobalFuncs.is_type_in_list( M, this.compatible_mobs ) ) {
							continue;
						}

						if ( this.mind_affecting ) {
							H = user;

							if ( !((Mob_Living_Carbon_Human)H).can_mind_interact( M ) ) {
								continue;
							}
						}
						possible_targets.Add( M );
					}

					if ( possible_targets.len != 0 ) {
						
						if ( ( this.spell_flags & 128 ) != 0 ) {
							temp_target = Interface13.Input( user, "Choose the target for the spell.", "Targeting", null, possible_targets, InputType.Mob | InputType.Null );

							if ( Lang13.Bool( temp_target ) ) {
								targets.Add( temp_target );
							}
						} else {
							targets.Add( Rand13.PickFromTable( possible_targets ) );
						}
					}
				}
			} else {
				possible_targets2 = new ByTable();
				starting_targets2 = null;

				if ( this.range == -2 ) {
					starting_targets2 = GlobalVars.living_mob_list;
				} else {
					starting_targets2 = GlobalFuncs.view_or_range( this.range, this.holder, this.selection_type );
				}

				foreach (dynamic _c in Lang13.Enumerate( starting_targets2, typeof(Mob_Living) )) {
					target2 = _c;
					

					if ( !( ( this.spell_flags & 64 ) != 0 ) && target2 == user ) {
						continue;
					}

					if ( this.compatible_mobs != null && !GlobalFuncs.is_type_in_list( target2, this.compatible_mobs ) ) {
						continue;
					}
					possible_targets2.Add( target2 );
				}

				if ( ( this.spell_flags & 128 ) != 0 ) {
					i = null;
					i = 1;

					while (( i ??0) <= ( this.max_targets ??0)) {
						
						if ( !( possible_targets2.len != 0 ) ) {
							break;
						}
						M2 = Interface13.Input( user, "Choose the target for the spell.", "Targeting", null, possible_targets2, InputType.Mob | InputType.Null );

						if ( !Lang13.Bool( M2 ) ) {
							break;
						}

						if ( this.range != -2 ) {
							
							if ( !GlobalFuncs.view_or_range( this.range, this.holder, this.selection_type ).Contains( M2 ) ) {
								i++;
								continue;
							}
						}
						targets.Add( M2 );
						possible_targets2.Remove( M2 );
						i++;
					}
				} else {
					i2 = null;
					i2 = 1;

					while (( i2 ??0) <= ( this.max_targets ??0)) {
						
						if ( !( possible_targets2.len != 0 ) ) {
							break;
						}

						if ( this.target_ignore_prev ) {
							target3 = Rand13.PickFromTable( possible_targets2 );
							possible_targets2.Remove( target3 );
							targets.Add( target3 );
						} else {
							targets.Add( Rand13.PickFromTable( possible_targets2 ) );
						}
						i2++;
					}
				}
			}

			if ( !( ( this.spell_flags & 64 ) != 0 ) && targets.Contains( user ) ) {
				targets.Remove( user );
			}

			if ( this.compatible_mobs != null && this.compatible_mobs.len != 0 ) {
				
				foreach (dynamic _d in Lang13.Enumerate( targets, typeof(Mob_Living) )) {
					target4 = _d;
					

					if ( !GlobalFuncs.is_type_in_list( target4, this.compatible_mobs ) ) {
						targets.Remove( target4 );
					}
				}
			}
			return targets;
		}

	}

}