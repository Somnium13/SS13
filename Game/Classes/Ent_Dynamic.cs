// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Ent_Dynamic : Base_Dynamic {

		public dynamic orbiting = null;
		public double pressure_resistance = 5;
		public int? last_move = null;
		public dynamic anchored = 0;
		public bool throwing = false;
		public dynamic throw_speed = 2;
		public double? throw_range = 7;
		public Mob pulledby = null;
		public int languages = 0;
		public dynamic verb_say = "says";
		public string verb_ask = "asks";
		public string verb_exclaim = "exclaims";
		public string verb_yell = "yells";
		public int? inertia_dir = 0;
		public int pass_flags = 0;
		public bool can_buckle = false;
		public int buckle_lying = -1;
		public bool buckle_requires_restraints = false;
		public dynamic buckled_mob = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.glide_size = 8;
			this.layer = 3;
		}

		// Function from file: lighting_system.dm
		public Ent_Dynamic ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.opacity ) {
				this.UpdateAffectingLights();
			}

			if ( this.luminosity != 0 ) {
				this.light = new LightSource( this );
			}
			return;
		}

		// Function from file: lighting_system.dm
		public override int get_light_range( int radius = 0 ) {
			return Num13.MinInt( radius, 7 );
		}

		// Function from file: lighting_system.dm
		public override void UpdateAffectingLights(  ) {
			
			if ( this.loc is Tile ) {
				this.loc.UpdateAffectingLights();
			}
			return;
		}

		// Function from file: lighting_system.dm
		public virtual bool Moved( Ent_Static OldLoc = null, int? Dir = null ) {
			
			if ( this.loc is Tile ) {
				
				if ( this.opacity ) {
					OldLoc.UpdateAffectingLights();
				} else if ( this.light != null ) {
					this.light.f_changed();
				}
			}
			return this._internal_Moved( OldLoc, Dir );
		}

		// Function from file: atoms_movable.dm
		public override dynamic Destroy(  ) {
			dynamic _default = null;

			Ent_Dynamic AM = null;

			_default = base.Destroy();

			if ( this.loc != null ) {
				this.loc.handle_atom_del( this );
			}

			if ( this.reagents != null ) {
				GlobalFuncs.qdel( this.reagents );
			}

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Ent_Dynamic) )) {
				AM = _a;
				
				GlobalFuncs.qdel( AM );
			}
			this.loc = null;
			this.invisibility = 101;

			if ( this.pulledby != null ) {
				
				if ( this.pulledby.pulling == this ) {
					this.pulledby.pulling = null;
				}
				this.pulledby = null;
			}
			return _default;
		}

		// Function from file: pool.dm
		public override void ResetVars( params object[] _ ) {
			ByTable _args = new ByTable( new object[] {  } ).Extend(_);

			base.ResetVars();
			this.loc = null;
			this.contents = Lang13.Initial( this, "contents" );
			return;
		}

		// Function from file: buckling.dm
		public override bool MouseDrop_T( Ent_Static O = null, dynamic user = null, bool? needs_opened = null, bool? show_message = null, bool? move_them = null ) {
			bool _default = false;

			_default = base.MouseDrop_T( O, (object)(user), needs_opened, show_message, move_them );

			if ( this.can_buckle && O is Mob_Living && !Lang13.Bool( this.buckled_mob ) ) {
				
				if ( this.user_buckle_mob( O, user ) ) {
					return true;
				}
			}
			return _default;
		}

		// Function from file: buckling.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			dynamic _default = null;

			_default = base.attack_hand( (object)(a), b, c );

			if ( this.can_buckle && Lang13.Bool( this.buckled_mob ) ) {
				
				if ( Lang13.Bool( this.user_unbuckle_mob( a ) ) ) {
					return 1;
				}
			}
			return _default;
		}

		// Function from file: atoms_movable.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 1.5;

			
			if ( this.buckled_mob == mover ) {
				return true;
			}
			return base.CanPass( (object)(mover), (object)(target), height, air_group );
		}

		// Function from file: atoms_movable.dm
		public override bool hitby( Ent_Dynamic AM = null, bool? skipcatch = null, bool? hitpush = null, bool? blocked = null ) {
			hitpush = hitpush ?? true;

			
			if ( !Lang13.Bool( this.anchored ) && hitpush == true ) {
				Map13.Step( this, AM.dir );
			}
			base.hitby( AM, skipcatch, hitpush, blocked );
			return false;
		}

		// Function from file: atoms_movable.dm
		public override dynamic Bump( Ent_Dynamic A = null, dynamic yes = null ) {
			dynamic _default = null;

			
			if ( A != null && Lang13.Bool( yes ) ) {
				
				if ( this.throwing ) {
					this.throwing = false;
					this.throw_impact( A );
					_default = 1;

					if ( !( A != null ) || GlobalFuncs.qdeleted( A ) ) {
						return _default;
					}
				}
				A.Bumped( this );
			}
			return _default;
		}

		// Function from file: atoms_movable.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			return null;
		}

		// Function from file: atoms_movable.dm
		public override void Del(  ) {
			
			if ( this.gc_destroyed == null && this.loc != null ) {
				GlobalFuncs.testing( "GC: -- " + this.type + " was deleted via del() rather than qdel() --" );
			}
			base.Del();
			return;
		}

		// Function from file: atoms_movable.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			Dir = Dir ?? 0;

			bool _default = false;

			Ent_Static oldloc = null;

			
			if ( !( this.loc != null ) || !Lang13.Bool( NewLoc ) ) {
				return false;
			}
			oldloc = this.loc;

			if ( this.loc != NewLoc ) {
				
				if ( !( ( ( Dir ??0) & ( Dir ??0) - 1 ) != 0 ) ) {
					_default = base.Move( (object)(NewLoc), Dir, step_x, step_y );
				} else if ( ( ( Dir ??0) & 1 ) != 0 ) {
					
					if ( ( ( Dir ??0) & 4 ) != 0 ) {
						Map13.Step( this, ((int)( GlobalVars.NORTH )) );

						if ( false ) {
							Map13.Step( this, ((int)( GlobalVars.EAST )) );
							_default = false;
						} else {
							Map13.Step( this, ((int)( GlobalVars.EAST )) );

							if ( false ) {
								Map13.Step( this, ((int)( GlobalVars.NORTH )) );
								_default = false;
							}
						}
					} else if ( ( ( Dir ??0) & 8 ) != 0 ) {
						Map13.Step( this, ((int)( GlobalVars.NORTH )) );

						if ( false ) {
							Map13.Step( this, ((int)( GlobalVars.WEST )) );
							_default = false;
						} else {
							Map13.Step( this, ((int)( GlobalVars.WEST )) );

							if ( false ) {
								Map13.Step( this, ((int)( GlobalVars.NORTH )) );
								_default = false;
							}
						}
					}
				} else if ( ( ( Dir ??0) & 2 ) != 0 ) {
					
					if ( ( ( Dir ??0) & 4 ) != 0 ) {
						Map13.Step( this, ((int)( GlobalVars.SOUTH )) );

						if ( false ) {
							Map13.Step( this, ((int)( GlobalVars.EAST )) );
							_default = false;
						} else {
							Map13.Step( this, ((int)( GlobalVars.EAST )) );

							if ( false ) {
								Map13.Step( this, ((int)( GlobalVars.SOUTH )) );
								_default = false;
							}
						}
					} else if ( ( ( Dir ??0) & 8 ) != 0 ) {
						Map13.Step( this, ((int)( GlobalVars.SOUTH )) );

						if ( false ) {
							Map13.Step( this, ((int)( GlobalVars.WEST )) );
							_default = false;
						} else {
							Map13.Step( this, ((int)( GlobalVars.WEST )) );

							if ( false ) {
								Map13.Step( this, ((int)( GlobalVars.SOUTH )) );
								_default = false;
							}
						}
					}
				}
			}

			if ( !( this.loc != null ) || this.loc == oldloc && oldloc != NewLoc ) {
				this.last_move = 0;
				return _default;
			}

			if ( _default ) {
				this.Moved( oldloc, Dir );
			}
			this.last_move = Dir;
			Task13.Schedule( 5, (Task13.Closure)(() => {
				
				if ( this.loc != null && Lang13.Bool( Dir ) && this.last_move == Dir ) {
					
					if ( this.loc == NewLoc ) {
						this.newtonian_move( this.last_move );
					}
				}
				return;
			}));

			if ( _default && Lang13.Bool( this.buckled_mob ) && !this.handle_buckled_mob_movement( this.loc, Dir ) ) {
				_default = false;
			}
			return _default;
		}

		// Function from file: item_attack.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			((Ent_Dynamic)user).do_attack_animation( this );

			if ( Lang13.Bool( A ) && !Lang13.Bool( A.flags & 4 ) ) {
				this.visible_message( "<span class='danger'>" + user + " has hit " + this + " with " + A + "!</span>" );
			}
			return null;
		}

		// Function from file: click.dm
		public override void CtrlClick( Mob user = null ) {
			Mob ML = null;

			ML = user;

			if ( ML is Mob_Living ) {
				((Mob_Living)ML).pulled( this );
			}
			return;
		}

		// Function from file: adjacent.dm
		public override bool Adjacent( dynamic neighbor = null, dynamic recurse = null ) {
			
			if ( neighbor == this.loc ) {
				return true;
			}

			if ( !( this.loc is Tile ) ) {
				return false;
			}

			if ( this.loc.Adjacent( neighbor, this ) ) {
				return true;
			}
			return false;
		}

		// Function from file: disposal-unit.dm
		public virtual bool disposalEnterTry(  ) {
			return true;
		}

		// Function from file: disposal-structures.dm
		public virtual void pipe_eject( int? direction = null ) {
			return;
		}

		// Function from file: living.dm
		public virtual void do_attack_animation( dynamic A = null, dynamic end_pixel_y = null ) {
			int pixel_x_diff = 0;
			int pixel_y_diff = 0;
			dynamic final_pixel_y = null;
			int direction = 0;

			pixel_x_diff = 0;
			pixel_y_diff = 0;
			final_pixel_y = Lang13.Initial( this, "pixel_y" );

			if ( Lang13.Bool( end_pixel_y ) ) {
				final_pixel_y = end_pixel_y;
			}
			direction = Map13.GetDistance( this, A );

			if ( ( direction & 1 ) != 0 ) {
				pixel_y_diff = 8;
			} else if ( ( direction & 2 ) != 0 ) {
				pixel_y_diff = -8;
			}

			if ( ( direction & 4 ) != 0 ) {
				pixel_x_diff = 8;
			} else if ( ( direction & 8 ) != 0 ) {
				pixel_x_diff = -8;
			}
			Icon13.Animate( new ByTable().Set( 1, this ).Set( "pixel_x", this.pixel_x + pixel_x_diff ).Set( "pixel_y", this.pixel_y + pixel_y_diff ).Set( "time", 2 ) );
			Icon13.Animate( new ByTable().Set( "pixel_x", Lang13.Initial( this, "pixel_x" ) ).Set( "pixel_y", final_pixel_y ).Set( "time", 2 ) );
			return;
		}

		// Function from file: LINDA_turf_tile.dm
		public virtual bool experience_pressure_difference( dynamic pressure_difference = null, int direction = 0 ) {
			bool _default = false;

			_default = false;

			if ( !Lang13.Bool( this.anchored ) && !( this.pulledby != null ) ) {
				_default = true;

				if ( Convert.ToDouble( pressure_difference ) > this.pressure_resistance ) {
					Map13.Step( this, direction );
				}
			}
			return _default;
		}

		// Function from file: LINDA_system.dm
		public void atmos_spawn_air( int text = 0, double? amount = null ) {
			dynamic T = null;

			T = GlobalFuncs.get_turf( this );

			if ( !( T is Tile_Simulated ) ) {
				return;
			}
			((Tile_Simulated)T).atmos_spawn_air( text, amount );
			return;
		}

		// Function from file: LINDA_system.dm
		public void move_update_air( Ent_Static T = null ) {
			
			if ( T is Tile ) {
				((Tile)T).air_update_turf( true );
			}
			this.air_update_turf( true );
			return;
		}

		// Function from file: LINDA_system.dm
		public void air_update_turf( bool? command = null ) {
			command = command ?? false;

			dynamic T = null;

			
			if ( !( this.loc is Tile ) && command == true ) {
				return;
			}
			T = GlobalFuncs.get_turf( this.loc );
			((Tile)T).air_update_turf( command );
			return;
		}

		// Function from file: LINDA_system.dm
		public virtual bool BlockSuperconductivity(  ) {
			return false;
		}

		// Function from file: LINDA_system.dm
		public virtual bool CanAtmosPass( dynamic T = null ) {
			return true;
		}

		// Function from file: objs.dm
		public virtual void initialize(  ) {
			return;
		}

		// Function from file: buckling.dm
		public virtual dynamic user_unbuckle_mob( dynamic user = null ) {
			dynamic M = null;

			M = this.unbuckle_mob();

			if ( Lang13.Bool( M ) ) {
				
				if ( M != user ) {
					((Ent_Static)M).visible_message( "<span class='notice'>" + user + " unbuckles " + M + " from " + this + ".</span>", "<span class='notice'>" + user + " unbuckles you from " + this + ".</span>", "<span class='italics'>You hear metal clanking.</span>" );
				} else {
					((Ent_Static)M).visible_message( "<span class='notice'>" + M + " unbuckles themselves from " + this + ".</span>", "<span class='notice'>You unbuckle yourself from " + this + ".</span>", "<span class='italics'>You hear metal clanking.</span>" );
				}
				this.add_fingerprint( user );
			}
			return M;
		}

		// Function from file: buckling.dm
		public virtual bool user_buckle_mob( Ent_Static M = null, dynamic user = null ) {
			
			if ( !( Map13.GetDistance( user, this ) <= 1 ) || Lang13.Bool( user.stat ) || ((Mob)user).restrained() ) {
				return false;
			}
			this.add_fingerprint( user );

			if ( this.buckle_mob( M ) ) {
				
				if ( M == user ) {
					M.visible_message( "<span class='notice'>" + M + " buckles themself to " + this + ".</span>", "<span class='notice'>You buckle yourself to " + this + ".</span>", "<span class='italics'>You hear metal clanking.</span>" );
				} else {
					M.visible_message( "<span class='warning'>" + user + " buckles " + M + " to " + this + "!</span>", "<span class='warning'>" + user + " buckles you to " + this + "!</span>", "<span class='italics'>You hear metal clanking.</span>" );
				}
				return true;
			}
			return false;
		}

		// Function from file: buckling.dm
		public virtual void post_buckle_mob( dynamic M = null ) {
			return;
		}

		// Function from file: buckling.dm
		public virtual dynamic unbuckle_mob( bool? force = null ) {
			force = force ?? false;

			dynamic _default = null;

			
			if ( Lang13.Bool( this.buckled_mob ) && this.buckled_mob.buckled == this && ( ((Mob)this.buckled_mob).can_unbuckle() || force == true ) ) {
				_default = this.buckled_mob;
				this.buckled_mob.buckled = null;
				this.buckled_mob.anchored = Lang13.Initial( this.buckled_mob, "anchored" );
				((Mob)this.buckled_mob).update_canmove();
				((Mob)this.buckled_mob).clear_alert( "buckled" );
				this.buckled_mob = null;
				this.post_buckle_mob( _default );
			}
			return _default;
		}

		// Function from file: buckling.dm
		public virtual bool buckle_mob( dynamic M = null, bool? force = null ) {
			force = force ?? false;

			
			if ( !this.can_buckle && !( force == true ) || !( M is Mob_Living ) || M.loc != this.loc || M.buckled != null || Lang13.Bool( M.buckled_mob ) || this.buckle_requires_restraints && !((Mob)M).restrained() || M == this ) {
				return false;
			}

			if ( !((Mob)M).f_can_buckle() && !( force == true ) ) {
				
				if ( M == Task13.User ) {
					M.WriteMsg( "<span class='warning'>You are unable to buckle yourself to the " + this + "!</span>" );
				} else {
					Task13.User.WriteMsg( "<span class='warning'>You are unable to buckle " + M + " to the " + this + "!</span>" );
				}
				return false;
			}
			M.buckled = this;
			M.dir = this.dir;
			this.buckled_mob = M;
			((Mob)M).update_canmove();
			this.post_buckle_mob( M );
			((Mob)M).throw_alert( "buckled", typeof(Obj_Screen_Alert_Restrained_Buckled), null, this );
			return true;
		}

		// Function from file: say.dm
		public virtual dynamic GetRadio(  ) {
			return null;
		}

		// Function from file: say.dm
		public virtual dynamic GetSource(  ) {
			return null;
		}

		// Function from file: say.dm
		public virtual dynamic GetJob(  ) {
			return null;
		}

		// Function from file: say.dm
		public virtual string get_alt_name(  ) {
			return null;
		}

		// Function from file: say.dm
		public virtual bool IsVocal(  ) {
			return true;
		}

		// Function from file: say.dm
		public virtual dynamic GetVoice(  ) {
			return this.name;
		}

		// Function from file: say.dm
		public virtual string lang_treat( dynamic speaker = null, int message_langs = 0, dynamic raw_message = null, dynamic spans = null ) {
			Ent_Dynamic AM = null;
			Ent_Dynamic AM2 = null;

			
			if ( ( this.languages & message_langs ) != 0 ) {
				AM = ((Ent_Dynamic)speaker).GetSource();

				if ( AM != null ) {
					
					if ( AM.verb_say != speaker.verb_say || AM.verb_ask != speaker.verb_ask || AM.verb_exclaim != speaker.verb_exclaim || AM.verb_yell != speaker.verb_yell ) {
						return ((Ent_Dynamic)speaker).say_quote( raw_message, spans );
					}
					return AM.say_quote( raw_message, spans );
				} else {
					return ((Ent_Dynamic)speaker).say_quote( raw_message, spans );
				}
			} else if ( ( message_langs & 1 ) != 0 ) {
				AM2 = ((Ent_Dynamic)speaker).GetSource();

				if ( AM2 != null ) {
					return AM2.say_quote( GlobalFuncs.stars( raw_message ), spans );
				} else {
					return ((Ent_Dynamic)speaker).say_quote( GlobalFuncs.stars( raw_message ), spans );
				}
			} else if ( ( message_langs & 2 ) != 0 ) {
				return "chimpers.";
			} else if ( ( message_langs & 4 ) != 0 ) {
				return "hisses.";
			} else if ( ( message_langs & 8 ) != 0 ) {
				return "beeps rapidly.";
			} else if ( ( message_langs & 32 ) != 0 ) {
				return "chitters.";
			} else {
				return "makes a strange sound.";
			}
			return null;
		}

		// Function from file: say.dm
		public virtual string say_quote( dynamic input = null, dynamic spans = null ) {
			spans = spans ?? new ByTable();

			string ending = null;

			
			if ( !Lang13.Bool( input ) ) {
				return "says, \"...\"";
			}
			ending = String13.SubStr( input, Lang13.Length( input ), 0 );

			if ( String13.SubStr( input, Lang13.Length( input ) - 1, 0 ) == "!!" ) {
				spans |= "yell";
				return "" + this.verb_yell + ", \"" + GlobalFuncs.attach_spans( input, spans ) + "\"";
			}
			input = GlobalFuncs.attach_spans( input, spans );

			if ( ending == "?" ) {
				return "" + this.verb_ask + ", \"" + input + "\"";
			}

			if ( ending == "!" ) {
				return "" + this.verb_exclaim + ", \"" + input + "\"";
			}
			return "" + this.verb_say + ", \"" + input + "\"";
		}

		// Function from file: say.dm
		public virtual string compose_job( dynamic speaker = null, int message_langs = 0, dynamic raw_message = null, dynamic radio_freq = null ) {
			return "";
		}

		// Function from file: say.dm
		public virtual string compose_track_href( dynamic speaker = null, string message_langs = null, dynamic raw_message = null, dynamic radio_freq = null ) {
			return "";
		}

		// Function from file: say.dm
		public string compose_message( dynamic speaker = null, int message_langs = 0, dynamic raw_message = null, dynamic radio_freq = null, dynamic spans = null ) {
			string spanpart1 = null;
			string spanpart2 = null;
			string freqpart = null;
			string namepart = null;
			string endspanpart = null;
			string messagepart = null;

			spanpart1 = "<span class='" + ( Lang13.Bool( radio_freq ) ? GlobalFuncs.get_radio_span( radio_freq ) : "game say" ) + "'>";
			spanpart2 = "<span class='name'>";
			freqpart = ( Lang13.Bool( radio_freq ) ? "[" + GlobalFuncs.get_radio_name( radio_freq ) + "] " : "" );
			namepart = "" + ((Ent_Dynamic)speaker).GetVoice() + ((Ent_Dynamic)speaker).get_alt_name();
			endspanpart = "</span>";
			messagepart = " <span class='message'>" + this.lang_treat( speaker, message_langs, raw_message, spans ) + "</span></span>";
			return "" + spanpart1 + spanpart2 + freqpart + this.compose_track_href( speaker, namepart ) + namepart + this.compose_job( speaker, message_langs, raw_message, radio_freq ) + endspanpart + messagepart;
		}

		// Function from file: say.dm
		public virtual ByTable get_spans(  ) {
			return new ByTable();
		}

		// Function from file: say.dm
		public virtual void send_speech( dynamic message = null, double? range = null, dynamic source = null, string bubble_type = null, ByTable spans = null ) {
			range = range ?? 7;
			source = source ?? this;

			string rendered = null;
			Ent_Dynamic AM = null;

			rendered = this.compose_message( this, this.languages, message, null, spans );

			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_hearers_in_view( range, this ), typeof(Ent_Dynamic) )) {
				AM = _a;
				
				AM.Hear( rendered, this, this.languages, message, null, spans );
			}
			return;
		}

		// Function from file: say.dm
		public virtual bool can_speak( dynamic message = null ) {
			return true;
		}

		// Function from file: say.dm
		public virtual string Hear( string message = null, dynamic speaker = null, int message_langs = 0, dynamic raw_message = null, dynamic radio_freq = null, ByTable spans = null ) {
			return null;
		}

		// Function from file: say.dm
		public virtual bool say( dynamic message = null, string bubble_type = null ) {
			ByTable spans = null;

			
			if ( !this.can_speak() ) {
				return false;
			}

			if ( message == "" || !Lang13.Bool( message ) ) {
				return false;
			}
			spans = this.get_spans();
			this.send_speech( message, 7, this, null, spans );
			return false;
		}

		// Function from file: atoms_movable.dm
		public bool handle_buckled_mob_movement( Ent_Static newloc = null, int? direct = null ) {
			
			if ( !Lang13.Bool( this.buckled_mob.Move( newloc, direct ) ) ) {
				this.loc = this.buckled_mob.loc;
				this.last_move = this.buckled_mob.last_move;
				this.inertia_dir = this.last_move;
				this.buckled_mob.inertia_dir = this.last_move;
				return false;
			}
			return true;
		}

		// Function from file: atoms_movable.dm
		public bool hitcheck(  ) {
			Ent_Dynamic AM = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_turf( this ), typeof(Ent_Dynamic) )) {
				AM = _a;
				

				if ( AM == this ) {
					continue;
				}

				if ( AM.density && !( ( AM.pass_flags & 32 ) != 0 ) && !Lang13.Bool( AM.flags & 512 ) ) {
					this.throwing = false;
					this.throw_impact( AM );
					return true;
				}
			}
			return false;
		}

		// Function from file: atoms_movable.dm
		public virtual bool throw_at( dynamic target = null, double? range = null, dynamic speed = null, dynamic thrower = null, bool? spin = null, bool? diagonals_first = null ) {
			spin = spin ?? true;
			diagonals_first = diagonals_first ?? false;

			double? dist_travelled = null;
			int dist_since_sleep = 0;
			double dist_x = 0;
			double dist_y = 0;
			double? dx = null;
			double? dy = null;
			bool pure_diagonal = false;
			double olddist_x = 0;
			double? olddx = null;
			double error = 0;
			dynamic finalturf = null;
			bool hit = false;
			int init_dir = 0;
			Tile step = null;
			Ent_Static A = null;

			
			if ( !Lang13.Bool( target ) || !( this != null ) || Lang13.Bool( this.flags & 2 ) ) {
				return false;
			}
			this.throwing = true;

			if ( spin == true ) {
				this.SpinAnimation( 5, 1 );
			}
			dist_travelled = 0;
			dist_since_sleep = 0;
			dist_x = Math.Abs( Convert.ToDouble( target.x - this.x ) );
			dist_y = Math.Abs( Convert.ToDouble( target.y - this.y ) );
			dx = ( Convert.ToDouble( target.x ) > this.x ? GlobalVars.EAST : GlobalVars.WEST );
			dy = ( Convert.ToDouble( target.y ) > this.y ? GlobalVars.NORTH : GlobalVars.SOUTH );
			pure_diagonal = false;

			if ( dist_x == dist_y ) {
				pure_diagonal = true;
			}

			if ( dist_x <= dist_y ) {
				olddist_x = dist_x;
				olddx = dx;
				dist_x = dist_y;
				dist_y = olddist_x;
				dx = dy;
				dy = olddx;
			}
			error = dist_x / 2 - dist_y;
			finalturf = GlobalFuncs.get_turf( target );
			hit = false;
			init_dir = Map13.GetDistance( this, target );

			while (Lang13.Bool( target ) && ( ( dist_travelled ??0) < ( range ??0) && this.loc != finalturf || !GlobalFuncs.has_gravity( this ) )) {
				
				if ( !( this.loc is Tile ) ) {
					hit = true;
					break;
				}
				step = null;

				if ( ( dist_travelled ??0) < Num13.MaxInt( ((int)( dist_x )), ((int)( dist_y )) ) ) {
					step = Map13.GetStep( this, Map13.GetDistance( this, finalturf ) );
				} else {
					step = Map13.GetStep( this, init_dir );
				}

				if ( !pure_diagonal && !( diagonals_first == true ) ) {
					
					if ( error >= 0 && Num13.MaxInt( ((int)( dist_x )), ((int)( dist_y )) ) - ( dist_travelled ??0) != 1 ) {
						step = Map13.GetStep( this, ((int)( dx ??0 )) );
					}
					error += ( error < 0 ? dist_x / 2 : -dist_y );
				}

				if ( !( step != null ) ) {
					break;
				}
				this.Move( step, Map13.GetDistance( this.loc, step ) );

				if ( !this.throwing ) {
					hit = true;
					break;
				}
				dist_travelled++;
				dist_since_sleep++;

				if ( ( dist_travelled ??0) > 600 ) {
					break;
				}

				if ( dist_since_sleep >= Convert.ToDouble( speed ) ) {
					dist_since_sleep = 0;
					Task13.Sleep( 1 );
				}

				if ( !( dist_since_sleep != 0 ) && this.hitcheck() ) {
					hit = true;
					break;
				}
			}
			this.throwing = false;

			if ( !hit ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_turf( this ), typeof(Ent_Static) )) {
					A = _a;
					

					if ( A == target ) {
						hit = true;
						this.throw_impact( A );
						return true;
					}
				}
				this.throw_impact( GlobalFuncs.get_turf( this ) );
			}
			return true;
		}

		// Function from file: atoms_movable.dm
		public void throw_at_fast( dynamic target = null, double? range = null, double? speed = null, dynamic thrower = null, bool? spin = null, bool? diagonals_first = null ) {
			spin = spin ?? true;
			diagonals_first = diagonals_first ?? false;

			this.throw_at( target, range, speed, thrower, spin, diagonals_first );
			return;
		}

		// Function from file: atoms_movable.dm
		public virtual bool throw_impact( dynamic target = null, Mob_Living_Carbon thrower = null ) {
			return ((Ent_Static)target).hitby( this );
		}

		// Function from file: atoms_movable.dm
		public int checkpass( int passflag = 0 ) {
			return this.pass_flags & passflag;
		}

		// Function from file: atoms_movable.dm
		public bool newtonian_move( int? direction = null ) {
			bool _default = false;

			int old_dir = 0;

			
			if ( !( this.loc != null ) || this.Process_Spacemove( 0 ) != 0 ) {
				this.inertia_dir = 0;
				return false;
			}
			this.inertia_dir = direction;

			if ( !Lang13.Bool( direction ) ) {
				return true;
			}
			old_dir = this.dir;
			Map13.Step( this, direction ??0 );
			_default = !Lang13.Bool( direction );
			this.dir = old_dir;
			return _default;
		}

		// Function from file: atoms_movable.dm
		public virtual int Process_Spacemove( dynamic movement_dir = null ) {
			movement_dir = movement_dir ?? 0;

			
			if ( GlobalFuncs.has_gravity( this ) ) {
				return 1;
			}

			if ( this.pulledby != null ) {
				return 1;
			}

			if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Lattice), Map13.FetchInRange( GlobalFuncs.get_turf( this ), 1 ) ) ) ) {
				return 1;
			}
			return 0;
		}

		// Function from file: atoms_movable.dm
		public bool forceMove( dynamic destination = null ) {
			Ent_Static oldloc = null;
			Ent_Dynamic AM = null;

			
			if ( Lang13.Bool( destination ) ) {
				oldloc = this.loc;

				if ( oldloc != null ) {
					oldloc.Exited( this, destination );
				}
				this.loc = destination;
				((Base_Static)destination).Entered( this, oldloc );

				foreach (dynamic _a in Lang13.Enumerate( destination, typeof(Ent_Dynamic) )) {
					AM = _a;
					

					if ( AM == this ) {
						continue;
					}
					AM.Crossed( this );
				}
				this.Moved( oldloc, 0 );
				return true;
			}
			return false;
		}

		// Function from file: atoms_movable.dm
		[VerbInfo( name: "Moved" )]
		[VerbArg( 1, InputType.Mob | InputType.Obj | InputType.Tile | InputType.Zone )]
		public bool _internal_Moved( Ent_Static OldLoc = null, int? Dir = null ) {
			return true;
		}

		// Function from file: unsorted.dm
		public void stop_orbit(  ) {
			this.orbiting = null;
			return;
		}

		// Function from file: unsorted.dm
		public virtual void orbit( dynamic A = null, double? radius = null, bool? clockwise = null, double? rotation_speed = null, int? rotation_segments = null, bool? pre_rotation = null, bool? lockinorbit = null ) {
			radius = radius ?? 10;
			clockwise = clockwise ?? GlobalVars.FALSE;
			rotation_speed = rotation_speed ?? 20;
			rotation_segments = rotation_segments ?? 36;
			pre_rotation = pre_rotation ?? GlobalVars.TRUE;
			lockinorbit = lockinorbit ?? GlobalVars.FALSE;

			Matrix initial_transform = null;
			Ent_Static lastloc = null;
			Matrix M = null;
			double? pre_rot = null;
			Matrix shift = null;
			dynamic targetloc = null;

			
			if ( !( A is Ent_Static ) ) {
				return;
			}

			if ( Lang13.Bool( this.orbiting ) ) {
				this.stop_orbit();
			}
			this.orbiting = A;
			initial_transform = Num13.Matrix( this.transform );
			lastloc = this.loc;

			if ( pre_rotation == true ) {
				M = Num13.Matrix( this.transform );
				pre_rot = 90;

				if ( !( clockwise == true ) ) {
					pre_rot = -90;
				}
				M.Turn( pre_rot );
				this.transform = M;
			}
			shift = Num13.Matrix( this.transform );
			shift.Translate( false, radius );
			this.transform = shift;
			this.SpinAnimation( rotation_speed, -1, clockwise, rotation_segments );
			this.transform = initial_transform;

			while (Lang13.Bool( this.orbiting ) && this.orbiting == A && A.loc != null) {
				targetloc = GlobalFuncs.get_turf( A );

				if ( !( lockinorbit == true ) && this.loc != lastloc && this.loc != targetloc ) {
					break;
				}
				this.loc = targetloc;
				lastloc = this.loc;
				Task13.Sleep( ((int)( 0.6 )) );
			}

			if ( this.orbiting == A ) {
				this.orbiting = null;
				this.SpinAnimation( 0, 0 );
			}
			return;
		}

	}

}