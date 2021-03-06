// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj : Ent_Dynamic {

		public bool crit_fail = false;
		public dynamic req_access = null;
		public dynamic req_one_access = null;
		public string req_access_txt = "0";
		public string req_one_access_txt = "0";
		public bool unacidable = false;
		public dynamic throwforce = 0;
		public bool in_use = false;
		public dynamic damtype = "brute";
		public dynamic force = 0;
		public int burn_state = -1;
		public int burntime = 10;
		public int burn_world_time = 0;
		public bool being_shocked = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.languages = 1;

			__RegisterInitialTracked("name");
			__RegisterInitialTracked("icon_state");
		}

		public Obj ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: shuttle.dm
		public override bool onShuttleMove( Ent_Static T1 = null, double? rotation = null ) {
			bool _default = false;

			
			if ( this.invisibility >= 101 ) {
				return false;
			}
			_default = base.onShuttleMove( T1, rotation );
			return _default;
		}

		// Function from file: objs.dm
		public override bool fire_act( bool? air = null, dynamic exposed_temperature = null, double? exposed_volume = null ) {
			air = air ?? true;

			
			if ( !( this.burn_state != 0 ) ) {
				this.burn_state = 1;
				GlobalVars.SSobj.burning.Add( this );
				this.burn_world_time = Game13.time + this.burntime * Rand13.Int( 10, 20 );

				if ( air == true ) {
					this.overlays.Add( GlobalVars.fire_overlay );
				}
				return true;
			}
			return false;
		}

		// Function from file: objs.dm
		public override bool storage_contents_dump_act( Obj_Item_Weapon_Storage src_object = null, Mob user = null ) {
			dynamic T = null;

			T = GlobalFuncs.get_turf( this );
			return ((Ent_Static)T).storage_contents_dump_act( src_object, user );
		}

		// Function from file: objs.dm
		public override ByTable get_spans(  ) {
			return base.get_spans() | "robot";
		}

		// Function from file: objs.dm
		public override void singularity_pull( Obj_Singularity S = null, int? current_size = null ) {
			
			if ( !Lang13.Bool( this.anchored ) || ( current_size ??0) >= 9 ) {
				Map13.StepTowardsSimple( this, S );
			}
			return;
		}

		// Function from file: objs.dm
		public override double singularity_act( int? current_size = null, Obj_Singularity S = null ) {
			this.ex_act( 1 );

			if ( this != null && this.gc_destroyed == null ) {
				GlobalFuncs.qdel( this );
			}
			return 2;
		}

		// Function from file: objs.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			
			if ( severity == 1 || target == this ) {
				GlobalFuncs.qdel( this );
			} else if ( severity == 2 ) {
				
				if ( Rand13.PercentChance( 50 ) ) {
					GlobalFuncs.qdel( this );
				}
			}

			if ( !Lang13.Bool( this.gc_destroyed ) ) {
				base.ex_act( severity, (object)(target) );
			}
			return false;
		}

		// Function from file: objs.dm
		public override void attack_ghost( Mob user = null ) {
			
			if ( this.ui_interact( user ) != -1 ) {
				return;
			}
			base.attack_ghost( user );
			return;
		}

		// Function from file: objs.dm
		public override GasMixture return_air(  ) {
			
			if ( this.loc != null ) {
				return this.loc.return_air();
			} else {
				return null;
			}
		}

		// Function from file: objs.dm
		public override dynamic remove_air( double amount = 0 ) {
			
			if ( this.loc != null ) {
				return this.loc.remove_air( amount );
			} else {
				return null;
			}
		}

		// Function from file: objs.dm
		public override bool? assume_air( dynamic giver = null ) {
			
			if ( this.loc != null ) {
				return this.loc.assume_air( giver );
			} else {
				return null;
			}
		}

		// Function from file: objs.dm
		public override dynamic Destroy(  ) {
			
			if ( !( this is Obj_Machinery ) ) {
				GlobalVars.SSobj.processing.Remove( this );
			}
			GlobalVars.SStgui.close_uis( this );
			return base.Destroy();
		}

		// Function from file: buckling.dm
		public override bool buckle_mob( dynamic M = null, bool? force = null ) {
			force = force ?? false;

			bool _default = false;

			_default = base.buckle_mob( (object)(M), force );

			if ( _default ) {
				
				if ( this.burn_state == 1 ) {
					((Mob_Living)M).adjust_fire_stacks( 1 );
					M.IgniteMob();
				}
			}
			return _default;
		}

		// Function from file: atoms.dm
		public override bool add_blood( dynamic M = null ) {
			
			if ( !base.add_blood( (object)(M) ) ) {
				return false;
			}
			return this.add_blood_list( M );
		}

		// Function from file: telekinesis.dm
		public override void attack_tk( Mob_Living_Carbon_Human user = null ) {
			Obj_Item_TkGrab O = null;

			
			if ( user.stat != 0 ) {
				return;
			}

			if ( Lang13.Bool( this.anchored ) ) {
				base.attack_tk( user );
				return;
			}
			O = new Obj_Item_TkGrab( this );
			user.put_in_active_hand( O );
			O.host = user;
			O.focus_object( this );
			return;
		}

		// Function from file: access.dm
		public bool check_access_list( ByTable L = null ) {
			dynamic req = null;
			dynamic req2 = null;

			
			if ( !Lang13.Bool( this.req_access ) && !Lang13.Bool( this.req_one_access ) ) {
				return true;
			}

			if ( !( this.req_access is ByTable ) ) {
				return true;
			}

			if ( !( this.req_access.len != 0 ) && ( !Lang13.Bool( this.req_one_access ) || !( this.req_one_access.len != 0 ) ) ) {
				return true;
			}

			if ( !( L != null ) ) {
				return false;
			}

			if ( !( L is ByTable ) ) {
				return false;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.req_access )) {
				req = _a;
				

				if ( !L.Contains( req ) ) {
					return false;
				}
			}

			if ( Lang13.Bool( this.req_one_access ) && this.req_one_access.len != 0 ) {
				
				foreach (dynamic _b in Lang13.Enumerate( this.req_one_access )) {
					req2 = _b;
					

					if ( L.Contains( req2 ) ) {
						return true;
					}
				}
				return false;
			}
			return true;
		}

		// Function from file: access.dm
		public virtual bool check_access( dynamic I = null ) {
			ByTable req_access_str = null;
			dynamic x = null;
			double? n = null;
			ByTable req_one_access_str = null;
			dynamic x2 = null;
			double? n2 = null;
			dynamic L = null;
			dynamic req = null;
			dynamic req2 = null;

			
			if ( !Lang13.Bool( this.req_access ) ) {
				this.req_access = new ByTable();

				if ( Lang13.Bool( this.req_access_txt ) ) {
					req_access_str = GlobalFuncs.splittext( this.req_access_txt, ";" );

					foreach (dynamic _a in Lang13.Enumerate( req_access_str )) {
						x = _a;
						
						n = String13.ParseNumber( x );

						if ( Lang13.Bool( n ) ) {
							this.req_access += n;
						}
					}
				}
			}

			if ( !Lang13.Bool( this.req_one_access ) ) {
				this.req_one_access = new ByTable();

				if ( Lang13.Bool( this.req_one_access_txt ) ) {
					req_one_access_str = GlobalFuncs.splittext( this.req_one_access_txt, ";" );

					foreach (dynamic _b in Lang13.Enumerate( req_one_access_str )) {
						x2 = _b;
						
						n2 = String13.ParseNumber( x2 );

						if ( Lang13.Bool( n2 ) ) {
							this.req_one_access += n2;
						}
					}
				}
			}

			if ( !( this.req_access is ByTable ) ) {
				return true;
			}
			L = this.req_access;

			if ( !( L.len != 0 ) && ( !Lang13.Bool( this.req_one_access ) || !( this.req_one_access.len != 0 ) ) ) {
				return true;
			}

			if ( !Lang13.Bool( I ) ) {
				return false;
			}

			foreach (dynamic _c in Lang13.Enumerate( this.req_access )) {
				req = _c;
				

				if ( !Lang13.Bool( ((Obj_Item)I).GetAccess().Contains( req ) ) ) {
					return false;
				}
			}

			if ( Lang13.Bool( this.req_one_access ) && this.req_one_access.len != 0 ) {
				
				foreach (dynamic _d in Lang13.Enumerate( this.req_one_access )) {
					req2 = _d;
					

					if ( Lang13.Bool( ((Obj_Item)I).GetAccess().Contains( req2 ) ) ) {
						return true;
					}
				}
				return false;
			}
			return true;
		}

		// Function from file: access.dm
		public virtual bool allowed( dynamic M = null ) {
			dynamic H = null;
			dynamic george = null;
			dynamic A = null;

			
			if ( this.check_access( null ) ) {
				return true;
			}

			if ( M is Mob_Living_Silicon ) {
				return true;
			}

			if ( Lang13.Bool( GlobalFuncs.IsAdminGhost( M ) ) ) {
				return true;
			} else if ( M is Mob_Living_Carbon_Human ) {
				H = M;

				if ( this.check_access( ((Mob)H).get_active_hand() ) || this.check_access( H.wear_id ) ) {
					return true;
				}
			} else if ( M is Mob_Living_Carbon_Monkey || M is Mob_Living_Carbon_Alien_Humanoid ) {
				george = M;

				if ( this.check_access( ((Mob)george).get_active_hand() ) ) {
					return true;
				}
			} else if ( M is Mob_Living_SimpleAnimal ) {
				A = M;

				if ( this.check_access( A.access_card ) ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: tank.dm
		public virtual GasMixture portableConnectorReturnAir(  ) {
			return null;
		}

		// Function from file: helpers.dm
		public virtual bool IsAssemblyHolder(  ) {
			return false;
		}

		// Function from file: helpers.dm
		public bool IsSpecialAssembly(  ) {
			return false;
		}

		// Function from file: objs.dm
		public virtual bool CanAStarPass( dynamic ID = null, int dir = 0, dynamic caller = null ) {
			bool _default = false;

			_default = !this.density;
			return _default;
		}

		// Function from file: objs.dm
		public void reset_shocked(  ) {
			this.being_shocked = false;
			return;
		}

		// Function from file: objs.dm
		public virtual void tesla_act( double power = 0 ) {
			double power_bounced = 0;

			this.being_shocked = true;
			power_bounced = power / 2;
			GlobalFuncs.tesla_zap( this, 3, power_bounced );
			GlobalFuncs.addtimer( this, "reset_shocked", 10 );
			return;
		}

		// Function from file: objs.dm
		public virtual void empty_object_contents( bool? burn = null, dynamic new_loc = null ) {
			burn = burn ?? false;
			new_loc = new_loc ?? this.loc;

			Obj_Item Item = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Item) )) {
				Item = _a;
				
				Item.loc = new_loc;

				if ( burn == true ) {
					Item.fire_act();
				}
			}
			return;
		}

		// Function from file: objs.dm
		public virtual void extinguish(  ) {
			
			if ( this.burn_state == 1 ) {
				this.burn_state = 0;
				this.overlays.Remove( GlobalVars.fire_overlay );
				GlobalVars.SSobj.burning.Remove( this );
			}
			return;
		}

		// Function from file: objs.dm
		public virtual void burn(  ) {
			Obj_Effect_Decal_Cleanable_Ash A = null;

			this.empty_object_contents( true, this.loc );
			A = new Obj_Effect_Decal_Cleanable_Ash( this.loc );
			A.desc = "Looks like this used to be a " + this.name + " some time ago.";
			GlobalVars.SSobj.burning.Remove( this );
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: objs.dm
		public virtual void Deconstruct(  ) {
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: objs.dm
		public virtual void on_log(  ) {
			Ent_Static Loc = null;

			Lang13.SuperCall();

			if ( this.loc is Obj ) {
				Loc = this.loc;
				((Obj)Loc).on_log();
			}
			return;
		}

		// Function from file: objs.dm
		public virtual void hide( bool h = false ) {
			return;
		}

		// Function from file: objs.dm
		public virtual dynamic alter_health(  ) {
			return 1;
		}

		// Function from file: objs.dm
		public virtual bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			return false;
		}

		// Function from file: objs.dm
		public virtual void container_resist( Mob user = null ) {
			return;
		}

		// Function from file: objs.dm
		public void updateDialog(  ) {
			ByTable nearby = null;
			bool is_in_use = false;
			dynamic M = null;
			bool ai_in_use = false;

			
			if ( this.in_use ) {
				nearby = Map13.FetchViewers( this, 1 );
				is_in_use = false;

				foreach (dynamic _a in Lang13.Enumerate( nearby )) {
					M = _a;
					

					if ( Lang13.Bool( M.client ) && M.machine == this ) {
						is_in_use = true;
						this.interact( M );
					}
				}
				ai_in_use = GlobalFuncs.AutoUpdateAI( this );

				if ( !ai_in_use && !is_in_use ) {
					this.in_use = false;
				}
			}
			return;
		}

		// Function from file: objs.dm
		public void updateUsrDialog(  ) {
			bool is_in_use = false;
			ByTable nearby = null;
			dynamic M = null;
			Mob H = null;

			
			if ( this.in_use ) {
				is_in_use = false;
				nearby = Map13.FetchViewers( this, 1 );

				foreach (dynamic _a in Lang13.Enumerate( nearby )) {
					M = _a;
					

					if ( Lang13.Bool( M.client ) && M.machine == this ) {
						is_in_use = true;
						this.attack_hand( M );
					}
				}

				if ( Task13.User is Mob_Living_Silicon_Ai || Task13.User is Mob_Living_Silicon_Robot || Lang13.Bool( GlobalFuncs.IsAdminGhost( Task13.User ) ) ) {
					
					if ( !nearby.Contains( Task13.User ) ) {
						
						if ( Task13.User.client != null && Task13.User.machine == this ) {
							is_in_use = true;
							this.attack_ai( Task13.User );
						}
					}
				}

				if ( Task13.User is Mob_Living_Carbon_Human ) {
					H = Task13.User;

					if ( !nearby.Contains( Task13.User ) ) {
						
						if ( Task13.User.client != null && Task13.User.machine == this ) {
							
							if ( ((Dna)((dynamic)H).dna).check_mutation( "Telekinesis" ) != 0 ) {
								is_in_use = true;
								this.attack_hand( Task13.User );
							}
						}
					}
				}
				this.in_use = is_in_use;
			}
			return;
		}

		// Function from file: objs.dm
		public dynamic handle_internal_lifeform( dynamic lifeform_inside_me = null, bool breath_request = false ) {
			GasMixture environment = null;
			double breath_percentage = 0;

			
			if ( ( breath_request ?1:0) > 0 ) {
				environment = this.return_air();
				breath_percentage = 0.5 / environment.return_volume();
				return this.remove_air( environment.total_moles() * breath_percentage );
			} else {
				return null;
			}
		}

		// Function from file: machinery.dm
		public bool default_unfasten_wrench( dynamic user = null, dynamic W = null, int? time = null ) {
			time = time ?? 20;

			
			if ( W is Obj_Item_Weapon_Wrench && !Lang13.Bool( this.flags & 128 ) ) {
				user.WriteMsg( "<span class='notice'>You begin " + ( Lang13.Bool( this.anchored ) ? "un" : "" ) + "securing " + this.name + "...</span>" );
				GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 50, 1 );

				if ( GlobalFuncs.do_after( user, ( time ??0) / W.toolspeed, null, this ) ) {
					user.WriteMsg( "<span class='notice'>You " + ( Lang13.Bool( this.anchored ) ? "un" : "" ) + "secure " + this.name + ".</span>" );
					this.anchored = !Lang13.Bool( this.anchored );
					GlobalFuncs.playsound( this.loc, "sound/items/Deconstruct.ogg", 50, 1 );
				}
				return true;
			}
			return false;
		}

		// Function from file: skincmd.dm
		public void SkinCmd( Mob user = null, string data = null ) {
			return;
		}

		// Function from file: communications.dm
		public virtual bool receive_signal( Signal signal = null, bool? receive_method = null, dynamic receive_param = null ) {
			return false;
		}

		// Function from file: unsorted.dm
		public void atmosanalyzer_scan( GasMixture air_contents = null, dynamic user = null, dynamic target = null ) {
			target = target ?? this;

			dynamic icon = null;
			double pressure = 0;
			double total_moles = 0;
			ByTable cached_gases = null;
			dynamic id = null;
			double gas_concentration = 0;

			icon = target;
			((Ent_Static)user).visible_message( new Txt().item( user ).str( " has used the analyzer on " ).icon( icon ).str( " " ).item( target ).str( "." ).ToString(), new Txt( "<span class='notice'>You use the analyzer on " ).icon( icon ).str( " " ).item( target ).str( ".</span>" ).ToString() );
			pressure = air_contents.return_pressure();
			total_moles = air_contents.total_moles();
			user.WriteMsg( new Txt( "<span class='notice'>Results of analysis of " ).icon( icon ).str( " " ).item( target ).str( ".</span>" ).ToString() );

			if ( total_moles > 0 ) {
				user.WriteMsg( "<span class='notice'>Pressure: " + Num13.Round( pressure, 0.1 ) + " kPa</span>" );
				cached_gases = air_contents.gases;

				foreach (dynamic _a in Lang13.Enumerate( cached_gases )) {
					id = _a;
					
					gas_concentration = Convert.ToDouble( cached_gases[id][1] / total_moles );

					if ( Lang13.Bool( ((dynamic)( GlobalVars.hardcoded_gases != null || gas_concentration > 0.01 )).Contains( id ) ) ) {
						user.WriteMsg( "<span class='notice'>" + cached_gases[id][3][2] + ": " + Num13.Floor( gas_concentration * 100 ) + " %</span>" );
					}
				}
				user.WriteMsg( "<span class='notice'>Temperature: " + Num13.Floor( Convert.ToDouble( air_contents.temperature - 273.41 ) ) + " &deg;C</span>" );
			} else {
				user.WriteMsg( "<span class='notice'>" + target + " is empty!</span>" );
			}
			return;
		}

	}

}