using System;
using Game13;

namespace Som13 {
	partial class BaseData {

		public double gc_destroyed = 0;

		public virtual void ResetVars(  ) {
			ByTable excluded = null;
			dynamic V = null;
			excluded = new ByTable(new object [] { "animate_movement", "contents", "loc", "locs", "parent_type", "vars", "verbs", "type" });
			V = null;
			foreach (dynamic _a in this.vars ) {
				V = _a;
				if ( excluded.contains( V ) ) {
					continue;
				}
				this.vars[V] = Misc13.initial( this.vars[V] );
			};
			return;
		}

		public virtual int process(  ) {
			GlobalVars.SSobj.processing.Remove( this );
			return 0;
		}

		public virtual int Destroy(  ) {
			this.tag = null;
			return 0;
		}

	}

	partial class BaseDynamic : BaseStatic {

		public dynamic glide_size = 8;

		public BaseStatic orbiting = null;
		public int orbitid = 0;
		public int pressure_resistance = 5;
		public int last_move = 0;
		public dynamic anchored = 0;
		public int throwing = 0;
		public int throw_speed = 2;
		public int throw_range = 7;
		public Mob pulledby = null;
		public int languages = 0;
		public string verb_say = "says";
		public string verb_ask = "asks";
		public string verb_exclaim = "exclaims";
		public string verb_yell = "yells";
		public int inertia_dir = 0;
		public int pass_flags = 0;
		public int can_buckle = 0;
		public int buckle_lying = -1;
		public int buckle_requires_restraints = 0;
		public dynamic buckled_mob = null;

		public BaseDynamic ( BaseStatic _loc = null ) : base( _loc ) {
			if ( Misc13.isValid( this.opacity ) ) {
				this.UpdateAffectingLights();
			}
			if ( Misc13.isValid( this.luminosity ) ) {
				this.light = new LightSource( this );
			}
			return;
		}

		public override dynamic get_light_range( dynamic radius = null ) {
			return Misc13.min( radius, 5 );
		}

		public override void UpdateAffectingLights(  ) {
			if ( this.loc is Tile ) {
				this.loc.UpdateAffectingLights();
			}
			return;
		}

		public virtual dynamic Moved( dynamic OldLoc = null, dynamic Dir = null ) {
			if ( this.loc is Tile ) {
				if ( Misc13.isValid( this.opacity ) ) {
					OldLoc.UpdateAffectingLights();
				} else if ( this.light != null ) {
					this.light.f_changed();
				}
			}
			return base.Moved();
		}

		public override int Destroy(  ) {
			int _default = 0;
			BaseDynamic AM = null;
			_default = base.Destroy();
			if ( Misc13.isValid( this.loc ) ) {
				this.loc.handle_atom_del( this );
			}
			if ( this.reagents != null ) {
				GlobalFuncs.qdel( this.reagents );
			}
			AM = null;
			foreach (dynamic _a in this.contents ) {
				AM = _a;
				if ( !( AM is BaseDynamic ) ) {
					continue;
				}
				GlobalFuncs.qdel( AM );
			};
			this.loc = null;
			this.invisibility = 101;
			if ( this.pulledby != null ) {
				if ( this.pulledby.pulling == this ) {
					this.pulledby.pulling = null;
				}
				this.pulledby = null;
			}
			return 0;
			return _default;
		}

		public override void ResetVars(  ) {
			base.ResetVars();
			this.loc = null;
			this.contents = Misc13.initial( this.contents );
			return;
		}

		public override int MouseDrop_T( Mob_Living M = null, dynamic user = null ) {
			int _default = 0;
			_default = base.MouseDrop_T();
			if ( ( this.can_buckle != 0 ) && M is Mob_Living ) {
				if ( Misc13.isValid( this.user_buckle_mob( M, user ) ) ) {
					return 1;
				}
			}
			return 0;
			return _default;
		}

		public override int attack_hand( dynamic user = null ) {
			int _default = 0;
			_default = base.attack_hand();
			if ( ( this.can_buckle != 0 ) && Misc13.isValid( this.buckled_mob ) ) {
				if ( Misc13.isValid( this.user_unbuckle_mob( user ) ) ) {
					return 1;
				}
			}
			return 0;
			return _default;
		}

		public override dynamic CanPass( dynamic mover = null, dynamic target = null, double height = 0 ) {
			if ( height == null ) {
				height = 1.5;
			}
			if ( this.buckled_mob == mover ) {
				return 1;
			}
			return base.CanPass();
		}

		public override int hitby( dynamic AM = null, dynamic skipcatch = null, int hitpush = 0, dynamic blocked = null ) {
			if ( hitpush == null ) {
				hitpush = 1;
			}
			if ( !Misc13.isValid( this.anchored ) && ( hitpush != 0 ) ) {
				Misc13.step( this, AM.dir );
			}
			base.hitby();
			return 0;
		}

		public virtual int Bump( dynamic A = null, dynamic yes = null ) {
			int _default = 0;
			if ( Misc13.isValid( A ) && Misc13.isValid( yes ) ) {
				if ( this.throwing != 0 ) {
					this.throwing = 0;
					this.throw_impact( A );
					_default = 1;
					if ( !Misc13.isValid( A ) || Misc13.isValid( GlobalFuncs.qdeleted( A ) ) ) {
						return 0;
					}
				}
				A.Bumped( this );
			}
			return 0;
			return _default;
		}

		public virtual int Crossed( BaseDynamic AM = null ) {
			return 0;
		}

		public void Del(  ) {
			if ( this.gc_destroyed == null && Misc13.isValid( this.loc ) ) {
				GlobalFuncs.testing( "GC: -- " + this.type + " was deleted via del() rather than qdel() --" );
			}
			base.Del();
			return;
		}

		public virtual int Move( dynamic newloc = null, int direct = 0 ) {
			int _default = 0;
			dynamic oldloc = null;
			if ( direct == null ) {
				direct = 0;
			}
			if ( !Misc13.isValid( this.loc ) || !Misc13.isValid( newloc ) ) {
				return 0;
			}
			oldloc = this.loc;
			if ( this.loc != newloc ) {
				if ( ( direct & direct - 1 ) == 0 ) {
					_default = base.Move();
				} else if ( ( direct & 1 ) != 0 ) {
					if ( ( direct & 4 ) != 0 ) {
						Misc13.step( this, GlobalVars.NORTH );
						if ( Misc13.isValid( null ) ) {
							Misc13.step( this, GlobalVars.EAST );
							_default = 0;
						} else {
							Misc13.step( this, GlobalVars.EAST );
							if ( Misc13.isValid( null ) ) {
								Misc13.step( this, GlobalVars.NORTH );
								_default = 0;
							}
						}
					} else if ( ( direct & 8 ) != 0 ) {
						Misc13.step( this, GlobalVars.NORTH );
						if ( Misc13.isValid( null ) ) {
							Misc13.step( this, GlobalVars.WEST );
							_default = 0;
						} else {
							Misc13.step( this, GlobalVars.WEST );
							if ( Misc13.isValid( null ) ) {
								Misc13.step( this, GlobalVars.NORTH );
								_default = 0;
							}
						}
					}
				} else if ( ( direct & 2 ) != 0 ) {
					if ( ( direct & 4 ) != 0 ) {
						Misc13.step( this, GlobalVars.SOUTH );
						if ( Misc13.isValid( null ) ) {
							Misc13.step( this, GlobalVars.EAST );
							_default = 0;
						} else {
							Misc13.step( this, GlobalVars.EAST );
							if ( Misc13.isValid( null ) ) {
								Misc13.step( this, GlobalVars.SOUTH );
								_default = 0;
							}
						}
					} else if ( ( direct & 8 ) != 0 ) {
						Misc13.step( this, GlobalVars.SOUTH );
						if ( Misc13.isValid( null ) ) {
							Misc13.step( this, GlobalVars.WEST );
							_default = 0;
						} else {
							Misc13.step( this, GlobalVars.WEST );
							if ( Misc13.isValid( null ) ) {
								Misc13.step( this, GlobalVars.SOUTH );
								_default = 0;
							}
						}
					}
				}
			}
			if ( !Misc13.isValid( this.loc ) || this.loc == oldloc && oldloc != newloc ) {
				this.last_move = 0;
				return 0;
			}
			if ( _default != 0 ) {
				this.f_Moved( oldloc, direct );
			}
			this.last_move = direct;
			Thread13.schedule( 5, (Thread13.Closure)(() => {
				if ( Misc13.isValid( this.loc ) && ( direct != 0 ) && this.last_move == direct ) {
					if ( this.loc == newloc ) {
						this.newtonian_move( this.last_move );
					}
				}
				return;
			}));
			if ( ( _default != 0 ) && Misc13.isValid( this.buckled_mob ) && !Misc13.isValid( this.handle_buckled_mob_movement( this.loc, direct ) ) ) {
				_default = 0;
			}
			return 0;
			return _default;
		}

		public override int attackby( dynamic W = null, dynamic user = null, dynamic _params = null ) {
			user.do_attack_animation( this );
			if ( Misc13.isValid( W ) && !Misc13.isValid( W.flags & 4 ) ) {
				this.visible_message( "<span class='danger'>" + user + " has hit " + this + " with " + W + "!</span>" );
			}
			return 0;
		}

		public override void CtrlClick( dynamic user = null ) {
			if ( Misc13.isValid( this.Adjacent( user ) ) ) {
				user.start_pulling( this );
			}
			return;
		}

		public override dynamic Adjacent( dynamic neighbor = null ) {
			if ( neighbor == this.loc ) {
				return 1;
			}
			if ( !( this.loc is Tile ) ) {
				return 0;
			}
			if ( Misc13.isValid( this.loc.Adjacent( neighbor, this ) ) ) {
				return 1;
			}
			return 0;
		}

		public virtual int disposalEnterTry(  ) {
			return 1;
		}

		public virtual void pipe_eject( int direction = 0 ) {
			return;
		}

		public virtual ByTable get_ui_data( dynamic user = null ) {
			return new ByTable();
		}

		public virtual void ui_interact( dynamic user = null, string ui_key = "", dynamic ui = null ) {
			if ( ui_key == null ) {
				ui_key = "main";
			}
			if ( ui == null ) {
				ui = null;
			}
			return;
		}

		public virtual void do_attack_animation( BaseStatic A = null, dynamic end_pixel_y = null ) {
			int pixel_x_diff = 0;
			int pixel_y_diff = 0;
			dynamic final_pixel_y = null;
			dynamic direction = null;
			pixel_x_diff = 0;
			pixel_y_diff = 0;
			final_pixel_y = Misc13.initial( this.pixel_y );
			if ( Misc13.isValid( end_pixel_y ) ) {
				final_pixel_y = end_pixel_y;
			}
			direction = Misc13.get_dist( this, A );
			dynamic _a = direction; // Was a switch-case, sorry for the mess.
			if ( _a==1 ) {
				pixel_y_diff = 8;
			} else if ( _a==2 ) {
				pixel_y_diff = -8;
			} else if ( _a==4 ) {
				pixel_x_diff = 8;
			} else if ( _a==8 ) {
				pixel_x_diff = -8;
			} else if ( _a==5 ) {
				pixel_x_diff = 8;
				pixel_y_diff = 8;
			} else if ( _a==9 ) {
				pixel_x_diff = -8;
				pixel_y_diff = 8;
			} else if ( _a==6 ) {
				pixel_x_diff = 8;
				pixel_y_diff = -8;
			} else if ( _a==10 ) {
				pixel_x_diff = -8;
				pixel_y_diff = -8;
			};
			Misc13.animate_listcall( new ByTable().set( "time", 2 ).set( "pixel_y", this.pixel_y + pixel_y_diff ).set( "pixel_x", this.pixel_x + pixel_x_diff ).set( 1, this ) );
			Misc13.animate_listcall( new ByTable().set( "time", 2 ).set( "pixel_y", final_pixel_y ).set( "pixel_x", Misc13.initial( this.pixel_x ) ) );
			return;
		}

		public virtual int experience_pressure_difference( int pressure_difference = 0, int direction = 0 ) {
			if ( !Misc13.isValid( this.anchored ) && ( this.pulledby == null ) ) {
				if ( pressure_difference > this.pressure_resistance ) {
					Thread13.schedule( 0, (Thread13.Closure)(() => {
						Misc13.step( this, direction );
						return;
					}));
				}
				return 1;
			}
			return 0;
		}

		public void atmos_spawn_air( int text = 0, dynamic amount = null ) {
			Tile_Simulated T = null;
			T = GlobalFuncs.get_turf( this );
			if ( !( T is Tile_Simulated ) ) {
				return;
			}
			T.atmos_spawn_air( text, amount );
			return;
		}

		public void move_update_air( Tile T = null ) {
			if ( T is Tile ) {
				T.air_update_turf( 1 );
			}
			this.air_update_turf( 1 );
			return;
		}

		public void air_update_turf( int command = 0 ) {
			dynamic T = null;
			if ( command == null ) {
				command = 0;
			}
			if ( !( this.loc is Tile ) && ( command != 0 ) ) {
				return;
			}
			T = GlobalFuncs.get_turf( this.loc );
			T.air_update_turf( command );
			return;
		}

		public virtual int BlockSuperconductivity(  ) {
			return 0;
		}

		public virtual dynamic CanAtmosPass(  ) {
			return 1;
		}

		public virtual void initialize(  ) {
			return;
		}

		public virtual dynamic user_unbuckle_mob( dynamic user = null ) {
			dynamic M = null;
			M = this.unbuckle_mob();
			if ( Misc13.isValid( M ) ) {
				if ( M != user ) {
					M.visible_message( "<span class='notice'>" + user + " unbuckles " + M + " from " + this + ".</span>", "<span class='notice'>" + user + " unbuckles you from " + this + ".</span>", "<span class='italics'>You hear metal clanking.</span>" );
				} else {
					M.visible_message( "<span class='notice'>" + M + " unbuckles themselves from " + this + ".</span>", "<span class='notice'>You unbuckle yourself from " + this + ".</span>", "<span class='italics'>You hear metal clanking.</span>" );
				}
				this.add_fingerprint( user );
			}
			return M;
		}

		public virtual int user_buckle_mob( Mob_Living M = null, dynamic user = null ) {
			if ( !( Misc13.get_dist( user, this ) <= 1 ) || Misc13.isValid( user.stat ) || Misc13.isValid( user.restrained() ) ) {
				return 0;
			}
			this.add_fingerprint( user );
			if ( Misc13.isValid( this.buckle_mob( M ) ) ) {
				if ( M == user ) {
					M.visible_message( "<span class='notice'>" + M + " buckles themself to " + this + ".</span>", "<span class='notice'>You buckle yourself to " + this + ".</span>", "<span class='italics'>You hear metal clanking.</span>" );
				} else {
					M.visible_message( "<span class='warning'>" + user + " buckles " + M + " to " + this + "!</span>", "<span class='warning'>" + user + " buckles you to " + this + "!</span>", "<span class='italics'>You hear metal clanking.</span>" );
				}
				return 1;
			}
			return 0;
		}

		public virtual void post_buckle_mob( dynamic M = null ) {
			return;
		}

		public virtual dynamic unbuckle_mob( int force = 0 ) {
			dynamic _default = null;
			if ( force == null ) {
				force = 0;
			}
			if ( Misc13.isValid( this.buckled_mob ) && this.buckled_mob.buckled == this && ( Misc13.isValid( this.buckled_mob.can_unbuckle() ) || ( force != 0 ) ) ) {
				_default = this.buckled_mob;
				this.buckled_mob.buckled = null;
				this.buckled_mob.anchored = Misc13.initial( this.buckled_mob.anchored );
				this.buckled_mob.update_canmove();
				this.buckled_mob.clear_alert( "buckled" );
				this.buckled_mob = null;
				this.post_buckle_mob( _default );
			}
			return null;
			return _default;
		}

		public virtual int buckle_mob( dynamic M = null, int force = 0 ) {
			if ( force == null ) {
				force = 0;
			}
			if ( ( this.can_buckle == 0 ) && ( force == 0 ) || !( M is Mob_Living ) || M.loc != this.loc || Misc13.isValid( M.buckled ) || Misc13.isValid( M.buckled_mob ) || ( this.buckle_requires_restraints != 0 ) && !Misc13.isValid( M.restrained() ) || M == this ) {
				return 0;
			}
			if ( !Misc13.isValid( M.can_buckle() ) && ( force == 0 ) ) {
				if ( M == Misc13.thread_user ) {
					M.write( "<span class='warning'>You are unable to buckle yourself to the " + this + "!</span>" );
				} else {
					Misc13.thread_user.write( "<span class='warning'>You are unable to buckle " + M + " to the " + this + "!</span>" );
				}
				return 0;
			}
			M.buckled = this;
			M.dir = this.dir;
			this.buckled_mob = M;
			M.update_canmove();
			this.post_buckle_mob( M );
			new ByTable().set( "new_master", this ).set( 2, typeof(Ent_Screen_Alert_Buckled) ).set( 1, "buckled" ).apply( M.GetType().GetMethod( "throw_alert" ) );
			return 1;
		}

		public virtual dynamic GetRadio(  ) {
			return null;
		}

		public virtual dynamic GetSource(  ) {
			return null;
		}

		public virtual dynamic GetJob(  ) {
			return null;
		}

		public virtual string get_alt_name(  ) {
			return null;
		}

		public virtual dynamic IsVocal(  ) {
			return 1;
		}

		public virtual dynamic GetVoice(  ) {
			return this.name;
		}

		public virtual string lang_treat( BaseDynamic speaker = null, int message_langs = 0, dynamic raw_message = null, dynamic spans = null ) {
			dynamic AM = null;
			if ( ( this.languages & message_langs ) != 0 ) {
				AM = speaker.GetSource();
				if ( Misc13.isValid( AM ) ) {
					if ( AM.verb_say != speaker.verb_say || AM.verb_ask != speaker.verb_ask || AM.verb_exclaim != speaker.verb_exclaim || AM.verb_yell != speaker.verb_yell ) {
						return speaker.say_quote( raw_message, spans );
					}
					return AM.say_quote( raw_message, spans );
				} else {
					return speaker.say_quote( raw_message, spans );
				}
			} else if ( ( message_langs & 1 ) != 0 ) {
				AM = speaker.GetSource();
				if ( Misc13.isValid( AM ) ) {
					return AM.say_quote( GlobalFuncs.stars( raw_message ), spans );
				} else {
					return speaker.say_quote( GlobalFuncs.stars( raw_message ), spans );
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

		public virtual string say_quote( dynamic input = null, dynamic spans = null ) {
			dynamic ending = null;
			if ( spans == null ) {
				spans = new ByTable();
			}
			if ( !Misc13.isValid( input ) ) {
				return "says, \"...\"";
			}
			ending = Misc13.str_sub( input, input.Length, null );
			if ( Misc13.str_sub( input, input.Length - 1, null ) == "!!" ) {
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

		public virtual string compose_job( BaseDynamic speaker = null, int message_langs = 0, dynamic raw_message = null, dynamic radio_freq = null ) {
			return "";
		}

		public virtual string compose_track_href( BaseDynamic speaker = null, string message_langs = "", dynamic raw_message = null, dynamic radio_freq = null ) {
			return "";
		}

		public string compose_message( BaseDynamic speaker = null, int message_langs = 0, dynamic raw_message = null, dynamic radio_freq = null, dynamic spans = null ) {
			string spanpart1 = "";
			string spanpart2 = "";
			string freqpart = "";
			string namepart = "";
			string endspanpart = "";
			string messagepart = "";
			spanpart1 = "<span class='" + ( Misc13.isValid( radio_freq ) ? GlobalFuncs.get_radio_span( radio_freq ) : "game say" ) + "'>";
			spanpart2 = "<span class='name'>";
			freqpart = Misc13.isValid( radio_freq ) ? "[" + GlobalFuncs.get_radio_name( radio_freq ) + "] " : "";
			namepart = "" + speaker.GetVoice() + speaker.get_alt_name();
			endspanpart = "</span>";
			messagepart = " <span class='message'>" + this.lang_treat( speaker, message_langs, raw_message, spans ) + "</span></span>";
			return "" + spanpart1 + spanpart2 + freqpart + this.compose_track_href( speaker, namepart ) + namepart + this.compose_job( speaker, message_langs, raw_message, radio_freq ) + endspanpart + messagepart;
		}

		public virtual ByTable get_spans(  ) {
			return new ByTable();
		}

		public virtual void send_speech( string message = "", int range = 0, BaseDynamic source = null, dynamic bubble_type = null, dynamic spans = null ) {
			dynamic rendered = null;
			BaseDynamic AM = null;
			if ( range == null ) {
				range = 7;
			}
			if ( source == null ) {
				source = this;
			}
			rendered = this.compose_message( this, this.languages, message, null, spans );
			AM = null;
			foreach (dynamic _a in GlobalFuncs.get_hearers_in_view( range, this ) ) {
				AM = _a;
				if ( !( AM is BaseDynamic ) ) {
					continue;
				}
				AM.Hear( rendered, this, this.languages, message, null, spans );
			};
			return;
		}

		public virtual int can_speak(  ) {
			return 1;
		}

		public virtual dynamic Hear( dynamic message = null, dynamic speaker = null, int message_langs = 0, dynamic raw_message = null, dynamic radio_freq = null, dynamic spans = null ) {
			return null;
		}

		public virtual int say( string message = "" ) {
			dynamic spans = null;
			if ( !Misc13.isValid( this.can_speak() ) ) {
				return 0;
			}
			if ( message == "" || !Misc13.isValid( message ) ) {
				return 0;
			}
			spans = this.get_spans();
			this.send_speech( message, 7, this, null, spans );
			return 0;
		}

		public int handle_buckled_mob_movement( dynamic newloc = null, int direct = 0 ) {
			if ( !Misc13.isValid( this.buckled_mob.Move( newloc, direct ) ) ) {
				this.loc = this.buckled_mob.loc;
				this.last_move = this.buckled_mob.last_move;
				this.inertia_dir = this.last_move;
				this.buckled_mob.inertia_dir = this.last_move;
				return 0;
			}
			return 1;
		}

		public int hitcheck(  ) {
			BaseDynamic AM = null;
			AM = null;
			foreach (dynamic _a in GlobalFuncs.get_turf( this ) ) {
				AM = _a;
				if ( !( AM is BaseDynamic ) ) {
					continue;
				}
				if ( AM == this ) {
					continue;
				}
				if ( Misc13.isValid( AM.density ) && ( ( AM.pass_flags & 32 ) == 0 ) && !Misc13.isValid( AM.flags & 512 ) ) {
					this.throwing = 0;
					this.throw_impact( AM );
					return 1;
				}
			};
			return 0;
		}

		public virtual int throw_at( dynamic target = null, int range = 0, double speed = 0, dynamic thrower = null, int spin = 0, int diagonals_first = 0 ) {
			int dist_travelled = 0;
			int dist_since_sleep = 0;
			dynamic dist_x = null;
			dynamic dist_y = null;
			int dx = 0;
			int dy = 0;
			int pure_diagonal = 0;
			dynamic olddist_x = null;
			int olddx = 0;
			dynamic error = null;
			dynamic finalturf = null;
			int hit = 0;
			dynamic init_dir = null;
			dynamic step = null;
			BaseStatic A = null;
			if ( spin == null ) {
				spin = 1;
			}
			if ( diagonals_first == null ) {
				diagonals_first = 0;
			}
			if ( !Misc13.isValid( target ) || ( this == null ) || Misc13.isValid( ( this.flags & 2 ) ) ) {
				return 0;
			}
			this.throwing = 1;
			if ( spin != 0 ) {
				this.SpinAnimation( 5, 1 );
			}
			dist_travelled = 0;
			dist_since_sleep = 0;
			dist_x = Math.Abs( target.x - this.x );
			dist_y = Math.Abs( target.y - this.y );
			dx = target.x > this.x ? GlobalVars.EAST : GlobalVars.WEST;
			dy = target.y > this.y ? GlobalVars.NORTH : GlobalVars.SOUTH;
			pure_diagonal = 0;
			if ( dist_x == dist_y ) {
				pure_diagonal = 1;
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
			hit = 0;
			init_dir = Misc13.get_dist( this, target );
			while (Misc13.isValid( target ) && ( dist_travelled < range && this.loc != finalturf || !Misc13.isValid( GlobalFuncs.has_gravity( this ) ) )) {
				if ( !( this.loc is Tile ) ) {
					hit = 1;
					break;
				}
				step = null;
				if ( dist_travelled < Misc13.max( dist_x, dist_y ) ) {
					step = Misc13.get_step( this, Misc13.get_dist( this, finalturf ) );
				} else {
					step = Misc13.get_step( this, init_dir );
				}
				if ( ( pure_diagonal == 0 ) && ( diagonals_first == 0 ) ) {
					if ( error >= 0 && Misc13.max( dist_x, dist_y ) - dist_travelled != 1 ) {
						step = Misc13.get_step( this, dx );
					}
					error += error < 0 ? dist_x / 2 : -dist_y;
				}
				if ( !Misc13.isValid( step ) ) {
					break;
				}
				this.Move( step, Misc13.get_dist( this.loc, step ) );
				if ( this.throwing == 0 ) {
					hit = 1;
					break;
				}
				dist_travelled++;
				dist_since_sleep++;
				if ( dist_travelled > 600 ) {
					break;
				}
				if ( dist_since_sleep >= speed ) {
					dist_since_sleep = 0;
					Thread13.sleep( 1 );
				}
				if ( ( dist_since_sleep == 0 ) && Misc13.isValid( this.hitcheck() ) ) {
					hit = 1;
					break;
				}
			}
			this.throwing = 0;
			if ( hit == 0 ) {
				A = null;
				foreach (dynamic _a in GlobalFuncs.get_turf( this ) ) {
					A = _a;
					if ( !( A is BaseStatic ) ) {
						continue;
					}
					if ( A == target ) {
						hit = 1;
						this.throw_impact( A );
						return 1;
					}
				};
				this.throw_impact( GlobalFuncs.get_turf( this ) );
			}
			return 1;
		}

		public virtual dynamic throw_impact( dynamic hit_atom = null ) {
			return hit_atom.hitby( this );
		}

		public int checkpass( int passflag = 0 ) {
			return this.pass_flags & passflag;
		}

		public dynamic newtonian_move( int direction = 0 ) {
			dynamic _default = null;
			int old_dir = 0;
			if ( !Misc13.isValid( this.loc ) || Misc13.isValid( this.Process_Spacemove( 0 ) ) ) {
				this.inertia_dir = 0;
				return 0;
			}
			this.inertia_dir = direction;
			if ( direction == 0 ) {
				return 1;
			}
			old_dir = this.dir;
			Misc13.step( this, direction );
			_default = ( direction == 0 );
			this.dir = old_dir;
			return null;
			return _default;
		}

		public virtual int Process_Spacemove( int movement_dir = 0 ) {
			if ( movement_dir == null ) {
				movement_dir = 0;
			}
			if ( Misc13.isValid( GlobalFuncs.has_gravity( this ) ) ) {
				return 1;
			}
			if ( this.pulledby != null ) {
				return 1;
			}
			if ( Misc13.isValid( Misc13.get_in( typeof(Ent_Structure_Lattice), Misc13.range( GlobalFuncs.get_turf( this ), 1 ) ) ) ) {
				return 1;
			}
			return 0;
		}

		public int forceMove( dynamic destination = null ) {
			dynamic oldloc = null;
			BaseDynamic AM = null;
			if ( Misc13.isValid( destination ) ) {
				oldloc = this.loc;
				if ( Misc13.isValid( oldloc ) ) {
					oldloc.Exited( this, destination );
				}
				this.loc = destination;
				destination.Entered( this, oldloc );
				AM = null;
				foreach (dynamic _a in destination ) {
					AM = _a;
					if ( !( AM is BaseDynamic ) ) {
						continue;
					}
					if ( AM == this ) {
						continue;
					}
					AM.Crossed( this );
				};
				this.f_Moved( oldloc, 0 );
				return 1;
			}
			return 0;
		}

		public virtual int f_Moved( dynamic OldLoc = null, int Dir = 0 ) {
			return 1;
		}

		public void stop_orbit(  ) {
			if ( this.orbiting != null ) {
				this.loc = GlobalFuncs.get_turf( this.orbiting );
				this.orbiting = null;
			}
			return;
		}

		public virtual void orbit( BaseStatic A = null, int radius = 0, int clockwise = 0, int angle_increment = 0, int lockinorbit = 0 ) {
			int myid = 0;
			dynamic lastloc = null;
			int angle = 0;
			Matrix initial_transform = null;
			dynamic targetloc = null;
			Matrix shift = null;
			if ( radius == null ) {
				radius = 10;
			}
			if ( clockwise == null ) {
				clockwise = 1;
			}
			if ( angle_increment == null ) {
				angle_increment = 15;
			}
			if ( lockinorbit == null ) {
				lockinorbit = 0;
			}
			if ( !( A is BaseStatic ) ) {
				return;
			}
			this.orbitid++;
			myid = this.orbitid;
			if ( this.orbiting != null ) {
				this.stop_orbit();
				Thread13.sleep( Game.tick_lag + 2.5999999046325684 );
				if ( ( this.orbiting != null ) || !( A is BaseStatic ) || this.orbitid != myid ) {
					return;
				}
			}
			this.orbiting = A;
			lastloc = this.loc;
			angle = 0;
			initial_transform = new Matrix( this.transform );
			while (( this.orbiting != null ) && Misc13.isValid( this.orbiting.loc ) && this.orbitid == myid) {
				targetloc = GlobalFuncs.get_turf( this.orbiting );
				if ( ( lockinorbit == 0 ) && this.loc != lastloc && this.loc != targetloc ) {
					break;
				}
				this.loc = targetloc;
				lastloc = this.loc;
				angle += angle_increment;
				shift = new Matrix( initial_transform );
				shift.Translate( radius, 0 );
				if ( clockwise != 0 ) {
					shift.Turn( angle );
				} else {
					shift.Turn( -angle );
				}
				Misc13.animate_listcall( new ByTable().set( 3, 2 ).set( "transform", shift ).set( 1, this ) );
				Thread13.sleep( 0.6000000238418579 );
			}
			Misc13.animate_listcall( new ByTable().set( 3, 2 ).set( "transform", initial_transform ).set( 1, this ) );
			this.orbiting = null;
			return;
		}

	}

	partial class BaseStatic : BaseData {

		public int smooth = 0;
		public dynamic top_left_corner = null;
		public dynamic top_right_corner = null;
		public dynamic bottom_left_corner = null;
		public dynamic bottom_right_corner = null;
		public int can_be_unanchored = 0;
		public ByTable canSmoothWith = new ByTable(new object [] { typeof(Tile_Simulated_Wall), typeof(Tile_Simulated_Wall_RWall), typeof(Ent_Structure_Falsewall), typeof(Ent_Structure_Falsewall_Reinforced), typeof(Tile_Simulated_Wall_Rust), typeof(Tile_Simulated_Wall_RWall_Rust) });
		public dynamic suit_fibers = null;
		public int level = 2;
		public dynamic flags = 0;
		public ByTable fingerprints = null;
		public dynamic fingerprintshidden = null;
		public string fingerprintslast = "";
		public ByTable blood_DNA = new ByTable();
		public Reagents reagents = new Reagents();
		public dynamic hud_list = null;
		public ByTable hud_possible = new ByTable(new object [] { "12" });
		public int explosion_block = 0;
		public LightSource light = null;

		public BaseStatic ( BaseStatic _loc = null ) {
			this.loc = _loc;
			if ( ( GlobalVars._preloader != null ) && this.type == GlobalVars._preloader.target_path ) {
				GlobalVars._preloader.load( this );
			}
			throw "Ctor fault.";
			return;
		}

		public void Read( dynamic S = null ) {
			dynamic l = null;
			string ic = "";
			if ( Misc13.isValid( this.contents.len ) ) {
				l = this.contents;
			}
			base.Read();
			if ( !Misc13.isValid( this.icon ) && S.dir.contains( "icon" ) ) {
				ic = S["icon"].read();
				if ( ic is string ) {
					this.icon = GlobalVars.swapmaps_iconcache[ic];
				}
			}
			if ( Misc13.isValid( l ) && this.contents != l ) {
				this.contents += l;
				GlobalFuncs.qdel( l );
			}
			return;
		}

		public void Write( dynamic S = null ) {
			dynamic V = null;
			dynamic M = null;
			dynamic l = null;
			V = null;
			foreach (dynamic _a in this.vars - "x" - "y" - "z" - "contents" - "icon" - "overlays" - "underlays" ) {
				V = _a;
				if ( Misc13.isValid( Misc13.call( GlobalVars.undefined, this.vars[V] ) ) ) {
					if ( this.vars[V] != Misc13.initial( this.vars[V] ) ) {
						S[V].write( this.vars[V] );
					} else {
						S.dir.Remove( V );
					}
				}
			};
			if ( this.icon != Misc13.initial( this.icon ) ) {
				if ( Misc13.isValid( GlobalVars.swapmaps_iconcache ) && Misc13.isValid( GlobalVars.swapmaps_iconcache[this.icon] ) ) {
					S["icon"].write( GlobalVars.swapmaps_iconcache[this.icon] );
				} else {
					S["icon"].write( this.icon );
				}
			}
			M = null;
			foreach (dynamic _b in this ) {
				M = _b;
				if ( Misc13.isValid( M.key ) ) {
					break;
				}
			};
			if ( Misc13.isValid( this.overlays.len ) ) {
				S["overlays"].write( this.overlays );
			}
			if ( Misc13.isValid( this.underlays.len ) ) {
				S["underlays"].write( this.underlays );
			}
			if ( Misc13.isValid( this.contents.len ) && !( this is Zone ) ) {
				l = this.contents;
				if ( Misc13.isValid( M ) ) {
					l = l.Copy();
					foreach (dynamic _c in this ) {
						M = _c;
						if ( Misc13.isValid( M.key ) ) {
							l -= M;
						}
					};
				}
				if ( Misc13.isValid( l.len ) ) {
					S["contents"].write( l );
				}
				if ( l != this.contents ) {
					GlobalFuncs.qdel( l );
				}
			}
			return;
		}

		public virtual dynamic Stat(  ) {
			dynamic _default = null;
			_default = base.Stat();
			Thread13.sleep( 1 );
			return null;
			return _default;
		}

		public virtual int MouseDrop( dynamic over = null, dynamic src_location = null, dynamic over_location = null, dynamic src_control = null, dynamic over_control = null, dynamic _params = null ) {
			if ( !Misc13.isValid( Misc13.thread_user ) || !Misc13.isValid( over ) ) {
				return 0;
			}
			if ( over == this ) {
				return Misc13.thread_user.client.Click( this, src_location, src_control, _params );
			}
			if ( !Misc13.isValid( this.Adjacent( Misc13.thread_user ) ) || !Misc13.isValid( over.Adjacent( Misc13.thread_user ) ) ) {
				return 0;
			}
			over.MouseDrop_T( this, Misc13.thread_user );
			return 0;
		}

		public void DblClick( dynamic location = null, dynamic control = null, dynamic _params = null ) {
			Misc13.thread_user.DblClickOn( this, _params );
			return;
		}

		public virtual int Click( dynamic location = null, dynamic control = null, dynamic _params = null ) {
			Misc13.thread_user.ClickOn( this, _params );
			return 0;
		}

		public virtual void shuttleRotate( dynamic rotation = null ) {
			dynamic turntimes = null;
			dynamic oldPX = null;
			dynamic oldPY = null;
			this.dir = GlobalFuncs.angle2dir( rotation + GlobalFuncs.dir2angle( this.dir ) );
			if ( this.smooth != 0 ) {
				GlobalFuncs.smooth_icon( this );
			}
			if ( Misc13.isValid( this.pixel_x ) || Misc13.isValid( this.pixel_y ) ) {
				if ( rotation < 0 ) {
					rotation += 360;
				}
				turntimes = null;
				turntimes = rotation / 90;
				while (turntimes > 0) {
					oldPX = this.pixel_x;
					oldPY = this.pixel_y;
					this.pixel_x = oldPY;
					this.pixel_y = oldPX * -1;
					turntimes--;
				}
			}
			return;
		}

		public void create_reagents( int max_vol = 0 ) {
			if ( this.reagents != null ) {
				GlobalFuncs.qdel( this.reagents );
			}
			this.reagents = new Reagents( max_vol );
			this.reagents.my_atom = this;
			return;
		}

		public virtual dynamic ninjadrain_act(  ) {
			return "INVALID";
		}

		public virtual void swarmer_act( dynamic S = null ) {
			S.DisIntegrate( this );
			return;
		}

		public void move_camera_by_click(  ) {
			dynamic AI = null;
			if ( Misc13.thread_user is Mob_Living_Silicon_Ai ) {
				AI = Misc13.thread_user;
				if ( Misc13.isValid( AI.eyeobj ) && AI.client.eye == AI.eyeobj ) {
					AI.cameraFollow = null;
					if ( this.loc is Tile || this is Tile ) {
						AI.eyeobj.setLoc( this );
					}
				}
			}
			return;
		}

		public virtual dynamic update_pipe_vision( dynamic new_loc = null ) {
			if ( new_loc == null ) {
				new_loc = null;
			}
			return null;
		}

		public virtual void audible_message( string message = "", string deaf_message = "", dynamic hearing_distance = null ) {
			int range = 0;
			dynamic M = null;
			range = 7;
			if ( Misc13.isValid( hearing_distance ) ) {
				range = hearing_distance;
			}
			M = null;
			foreach (dynamic _a in GlobalFuncs.get_hearers_in_view( range, this ) ) {
				M = _a;
				M.show_message( message, 2, deaf_message, 1 );
			};
			return;
		}

		public virtual void visible_message( string message = "", string blind_message = "" ) {
			ByTable mob_viewers = null;
			ByTable possible_viewers = null;
			dynamic heard = null;
			BaseDynamic A = null;
			dynamic B = null;
			dynamic T = null;
			dynamic M = null;
			ByTable mob_hearers = null;
			dynamic C = null;
			dynamic MOB = null;
			mob_viewers = new ByTable();
			possible_viewers = new ByTable();
			mob_viewers |= Misc13.viewers( this, null );
			heard = GlobalFuncs.get_hear( 7, this );
			A = null;
			foreach (dynamic _a in heard ) {
				A = _a;
				if ( !( A is BaseDynamic ) ) {
					continue;
				}
				possible_viewers |= GlobalFuncs.recursive_hear_check( A );
			};
			B = null;
			foreach (dynamic _b in possible_viewers ) {
				B = _b;
				if ( mob_viewers.contains( B ) ) {
					continue;
				}
				if ( B.loc is Tile ) {
					continue;
				}
				T = GlobalFuncs.get_turf( B );
				if ( Misc13.view( T, null ).contains( this ) ) {
					mob_viewers |= B;
				}
			};
			M = null;
			foreach (dynamic _c in mob_viewers ) {
				M = _c;
				M.show_message( message, 1 );
			};
			if ( Misc13.isValid( blind_message ) ) {
				mob_hearers = new ByTable();
				C = null;
				foreach (dynamic _d in GlobalFuncs.get_hearers_in_view( 7, this ) ) {
					C = _d;
					if ( mob_viewers.contains( C ) ) {
						continue;
					}
					mob_hearers |= C;
				};
				MOB = null;
				foreach (dynamic _e in mob_hearers ) {
					MOB = _e;
					MOB.show_message( blind_message, 2 );
				};
			}
			return;
		}

		public virtual void prepare_huds(  ) {
			dynamic hud = null;
			hud = null;
			foreach (dynamic _a in this.hud_possible ) {
				hud = _a;
				this.hud_list[hud] = new Image( new ByRsc(229), this, "" );
			};
			return;
		}

		public virtual dynamic get_light_range( int radius = 0 ) {
			return Misc13.min( radius, 8 );
		}

		public virtual void UpdateAffectingLights(  ) {
			return;
		}

		public int SetOpacity( dynamic new_opacity = null ) {
			if ( new_opacity == null ) {
				new_opacity = !Misc13.isValid( this.opacity );
			} else if ( this.opacity == new_opacity ) {
				return 0;
			}
			this.opacity = new_opacity;
			this.UpdateAffectingLights();
			return 1;
		}

		public void AddLuminosity( int delta_luminosity = 0 ) {
			if ( this.light != null ) {
				this.SetLuminosity( this.light.radius + delta_luminosity );
			} else {
				this.SetLuminosity( delta_luminosity );
			}
			return;
		}

		public virtual void SetLuminosity( int new_luminosity = 0 ) {
			if ( new_luminosity < 0 ) {
				new_luminosity = 0;
			}
			if ( this.light == null ) {
				if ( new_luminosity == 0 ) {
					return;
				}
				this.light = new LightSource( this );
			} else if ( this.light.radius == new_luminosity ) {
				return;
			}
			this.light.radius = new_luminosity;
			this.luminosity = new_luminosity;
			this.light.f_changed();
			return;
		}

		public void transfer_fingerprints_to( Ent_Item_Stack_Rods A = null ) {
			if ( !( A.fingerprints is ByTable ) ) {
				A.fingerprints = new ByTable();
			}
			if ( !( A.fingerprintshidden is ByTable ) ) {
				A.fingerprintshidden = new ByTable();
			}
			if ( !( this.fingerprints is ByTable ) ) {
				this.fingerprints = new ByTable();
			}
			if ( !( this.fingerprintshidden is ByTable ) ) {
				this.fingerprintshidden = new ByTable();
			}
			if ( this.fingerprints != null ) {
				A.fingerprints |= this.fingerprints.Copy();
			}
			if ( Misc13.isValid( this.fingerprintshidden ) ) {
				A.fingerprintshidden |= this.fingerprintshidden.Copy();
			}
			A.fingerprintslast = this.fingerprintslast;
			return;
		}

		public int add_fingerprint( dynamic M = null, int ignoregloves = 0 ) {
			dynamic H = null;
			dynamic G = null;
			dynamic full_print = null;
			if ( ignoregloves == null ) {
				ignoregloves = 0;
			}
			if ( M == null ) {
				return 0;
			}
			if ( M.key == null ) {
				return 0;
			}
			if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				if ( !Misc13.isValid( this.fingerprintshidden ) ) {
					this.fingerprintshidden = new ByTable();
				}
				this.add_fibers( H );
				if ( Misc13.isValid( H.gloves ) ) {
					G = H.gloves;
					if ( Misc13.isValid( G.transfer_prints ) ) {
						ignoregloves = 1;
					}
				}
				if ( ignoregloves == 0 ) {
					if ( Misc13.isValid( H.gloves ) && H.gloves != this ) {
						if ( this.fingerprintslast != H.ckey ) {
							this.fingerprintshidden += "[" + GlobalFuncs.time_stamp() + "](Wearing gloves). Real name: " + H.real_name + ", Key: " + H.key;
							this.fingerprintslast = H.ckey;
						}
						H.gloves.add_fingerprint( M );
						return 0;
					}
				}
				if ( this.fingerprintslast != H.ckey ) {
					this.fingerprintshidden += "[" + GlobalFuncs.time_stamp() + "]Real name: " + H.real_name + ", Key: " + H.key;
					this.fingerprintslast = H.ckey;
				}
				if ( this.fingerprints == null ) {
					this.fingerprints = new ByTable();
				}
				full_print = Misc13.call( GlobalVars.undefined, H.dna.uni_identity );
				this.fingerprints[full_print] = full_print;
				return 1;
			} else if ( this.fingerprintslast != M.ckey ) {
				this.fingerprintshidden += "[" + GlobalFuncs.time_stamp() + "]Real name: " + M.real_name + ", Key: " + M.key;
				this.fingerprintslast = M.ckey;
			}
			return 0;
		}

		public int add_hiddenprint( dynamic M = null ) {
			dynamic H = null;
			if ( M == null ) {
				return 0;
			}
			if ( M.key == null ) {
				return 0;
			}
			if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				if ( Misc13.isValid( H.gloves ) ) {
					if ( this.fingerprintslast != H.ckey ) {
						this.fingerprintshidden += "[" + GlobalFuncs.time_stamp() + "] (Wearing gloves). Real name: " + H.real_name + ", Key: " + H.key;
						this.fingerprintslast = H.ckey;
					}
					return 0;
				}
				if ( this.fingerprints == null ) {
					if ( this.fingerprintslast != H.ckey ) {
						this.fingerprintshidden += "[" + GlobalFuncs.time_stamp() + "] Real name: " + H.real_name + ", Key: " + H.key;
						this.fingerprintslast = H.ckey;
					}
					return 1;
				}
			} else if ( this.fingerprintslast != M.ckey ) {
				this.fingerprintshidden += "[" + GlobalFuncs.time_stamp() + "] Real name: " + M.real_name + ", Key: " + M.key;
				this.fingerprintslast = M.ckey;
			}
			return 0;
		}

		public void add_fibers( dynamic M = null ) {
			dynamic G = null;
			string fibertext = "";
			double item_multiplier = 0;
			if ( Misc13.isValid( M.gloves ) && M.gloves is Ent_Item_Clothing ) {
				G = M.gloves;
				if ( G.transfer_blood > 1 ) {
					if ( Misc13.isValid( this.add_blood( G.bloody_hands_mob ) ) ) {
						G.transfer_blood--;
					}
				}
			} else if ( M.bloody_hands > 1 ) {
				if ( Misc13.isValid( this.add_blood( M.bloody_hands_mob ) ) ) {
					M.bloody_hands--;
				}
			}
			if ( !Misc13.isValid( this.suit_fibers ) ) {
				this.suit_fibers = new ByTable();
			}
			item_multiplier = this is Ent_Item ? 1.2000000476837158 : 1;
			if ( Misc13.isValid( M.wear_suit ) ) {
				fibertext = new Txt( "Material from " ).a( M.wear_suit ).item().str( "." );
				if ( Misc13.isValid( Rand13.chance( item_multiplier * 10 ) ) && !this.suit_fibers.contains( fibertext ) ) {
					this.suit_fibers += fibertext;
				}
				if ( !Misc13.isValid( M.wear_suit.body_parts_covered & 2 ) ) {
					if ( Misc13.isValid( M.w_uniform ) ) {
						fibertext = new Txt( "Fibers from " ).a( M.w_uniform ).item().str( "." );
						if ( Misc13.isValid( Rand13.chance( item_multiplier * 12 ) ) && !this.suit_fibers.contains( fibertext ) ) {
							this.suit_fibers += fibertext;
						}
					}
				}
				if ( !Misc13.isValid( M.wear_suit.body_parts_covered & 1536 ) ) {
					if ( Misc13.isValid( M.gloves ) ) {
						fibertext = "Material from a pair of " + M.gloves.name + ".";
						if ( Misc13.isValid( Rand13.chance( item_multiplier * 20 ) ) && !this.suit_fibers.contains( fibertext ) ) {
							this.suit_fibers += fibertext;
						}
					}
				}
			} else if ( Misc13.isValid( M.w_uniform ) ) {
				fibertext = new Txt( "Fibers from " ).a( M.w_uniform ).item().str( "." );
				if ( Misc13.isValid( Rand13.chance( item_multiplier * 15 ) ) && !this.suit_fibers.contains( fibertext ) ) {
					this.suit_fibers += fibertext;
				}
				if ( Misc13.isValid( M.gloves ) ) {
					fibertext = "Material from a pair of " + M.gloves.name + ".";
					if ( Misc13.isValid( Rand13.chance( item_multiplier * 20 ) ) && !this.suit_fibers.contains( fibertext ) ) {
						this.suit_fibers += "Material from a pair of " + M.gloves.name + ".";
					}
				}
			} else if ( Misc13.isValid( M.gloves ) ) {
				fibertext = "Material from a pair of " + M.gloves.name + ".";
				if ( Misc13.isValid( Rand13.chance( item_multiplier * 20 ) ) && !this.suit_fibers.contains( fibertext ) ) {
					this.suit_fibers += "Material from a pair of " + M.gloves.name + ".";
				}
			}
			return;
		}

		public void investigate_log( string message = "", string subject = "" ) {
			dynamic F = null;
			if ( !Misc13.isValid( message ) ) {
				return;
			}
			F = GlobalFuncs.investigate_subject2file( subject );
			if ( !Misc13.isValid( F ) ) {
				return;
			}
			F.write( new Txt( "<small>" ).item( GlobalFuncs.time_stamp() ).str( " " ).Ref( this ).str( " (" ).item( this.x ).str( "," ).item( this.y ).str( "," ).item( this.z ).str( ")</small> || " ).item( this ).str( " " ).item( message ).str( "<br>" ) );
			return;
		}

		public virtual dynamic CanPass( dynamic mover = null, dynamic target = null, double height = 0 ) {
			if ( height == null ) {
				height = 1.5;
			}
			return !Misc13.isValid( this.density ) || ( height == 0 );
		}

		public virtual void temperature_expose( dynamic air = null, dynamic exposed_temperature = null, dynamic exposed_volume = null ) {
			return;
		}

		public virtual int transfer_ai( dynamic interaction = null, dynamic user = null, dynamic AI = null, Ent_Item_Device_Aicard card = null ) {
			if ( card is Ent_Item_Device_Aicard ) {
				if ( card.flush != 0 ) {
					user.write( "<span class='boldannounce'>ERROR</span>: AI flush is in progress, cannot execute transfer protocol." );
					return 0;
				}
			}
			return 1;
		}

		public virtual int rad_act( double severity = 0 ) {
			return 1;
		}

		public virtual int mech_melee_attack( Ent_Mecha M = null ) {
			return 0;
		}

		public Signal telecomms_process(  ) {
			Signal signal = null;
			dynamic pos = null;
			Ent_Machinery_Telecomms_Receiver R = null;
			signal = new Signal();
			signal.transmission_method = 2;
			pos = GlobalFuncs.get_turf( this );
			signal.data = new ByTable().set( "level", pos.z ).set( "done", 0 ).set( "reject", 0 ).set( "type", 4 ).set( "traffic", 0 ).set( "compression", Rand13.Int( 45, 50 ) ).set( "message", "TEST" ).set( "slow", 0 );
			signal.frequency = 1459;
			R = null;
			foreach (dynamic _a in GlobalVars.telecomms_list ) {
				R = _a;
				if ( !( R is Ent_Machinery_Telecomms_Receiver ) ) {
					continue;
				}
				R.receive_signal( signal );
			};
			Thread13.sleep( Rand13.Int( 10, 25 ) );
			return signal;
		}

		public bool test_telecomms(  ) {
			dynamic signal = null;
			dynamic position = null;
			signal = this.telecomms_process();
			position = GlobalFuncs.get_turf( this );
			return Misc13.isValid( signal.data["level"] ) && Misc13.isValid( signal.data["done"] ).contains( position.z );
		}

		public void auto_turn(  ) {
			Tile_Simulated_Wall T = null;
			int i = 0;
			T = null;
			i = 0;
			i = 1;
			while (i <= 8) {
				T = GlobalFuncs.get_ranged_target_turf( this, i, 1 );
				if ( T is Tile_Simulated_Wall ) {
					dynamic _a = i; // Was a switch-case, sorry for the mess.
					if ( _a==1 ) {
						this.dir = GlobalVars.SOUTH;
					} else if ( _a==2 ) {
						this.dir = GlobalVars.NORTH;
					} else if ( _a==8 ) {
						this.dir = GlobalVars.EAST;
					} else if ( _a==4 ) {
						this.dir = GlobalVars.WEST;
					};
					break;
				}
				i += i;
			}
			return;
		}

		public virtual void playsound_local( Tile turf_source = null, dynamic soundin = null, int vol = 0, int vary = 0, dynamic frequency = null, dynamic falloff = null, int surround = 0 ) {
			Sound S = null;
			dynamic T = null;
			int pressure_factor = 0;
			dynamic hearer_env = null;
			dynamic source_env = null;
			dynamic pressure = null;
			dynamic distance = null;
			dynamic dx = null;
			dynamic dz = null;
			if ( surround == null ) {
				surround = 1;
			}
			soundin = GlobalFuncs.get_sfx( soundin );
			S = new Sound( soundin );
			S.wait = 0;
			S.channel = 0;
			S.volume = vol;
			if ( vary != 0 ) {
				if ( Misc13.isValid( frequency ) ) {
					S.frequency = frequency;
				} else {
					S.frequency = GlobalFuncs.get_rand_frequency();
				}
			}
			if ( turf_source is Tile ) {
				T = GlobalFuncs.get_turf( this );
				pressure_factor = 1;
				hearer_env = T.return_air();
				source_env = turf_source.return_air();
				if ( Misc13.isValid( hearer_env ) && Misc13.isValid( source_env ) ) {
					pressure = Misc13.min( hearer_env.return_pressure(), source_env.return_pressure() );
					if ( pressure < 101.32499694824219 ) {
						pressure_factor = Misc13.max( ( pressure - 10 ) / 91.32499694824219, 0 );
					}
				} else {
					pressure_factor = 0;
				}
				distance = Misc13.get_dist( T, turf_source );
				if ( distance <= 1 ) {
					pressure_factor = Misc13.max( pressure_factor, 0.15000000596046448 );
				}
				S.volume *= pressure_factor;
				if ( S.volume <= 0 ) {
					return;
				}
				if ( surround != 0 ) {
					dx = turf_source.x - T.x;
					S.x = Misc13.round( Misc13.max( -7, Misc13.min( 7, dx ) ), 1 );
					dz = turf_source.y - T.y;
					S.z = Misc13.round( Misc13.max( -7, Misc13.min( 7, dz ) ), 1 );
				}
				S.y = 1;
				S.falloff = Misc13.isValid( falloff ) ? falloff : 1;
			}
			this.write( S );
			return;
		}

		public void remove_from_all_data_huds(  ) {
			AtomHud_Data hud = null;
			hud = null;
			foreach (dynamic _a in GlobalVars.huds ) {
				hud = _a;
				if ( !( hud is AtomHud_Data ) ) {
					continue;
				}
				hud.remove_from_hud( this );
			};
			return;
		}

		public void add_to_all_human_data_huds(  ) {
			AtomHud_Data_Human hud = null;
			hud = null;
			foreach (dynamic _a in GlobalVars.huds ) {
				hud = _a;
				if ( !( hud is AtomHud_Data_Human ) ) {
					continue;
				}
				hud.add_to_hud( this );
			};
			return;
		}

		public virtual void handle_atom_del( dynamic A = null ) {
			return;
		}

		public virtual int storage_contents_dump_act( dynamic src_object = null, dynamic user = null ) {
			return 0;
		}

		public virtual void narsie_act(  ) {
			return;
		}

		public virtual int emag_act(  ) {
			return 0;
		}

		public virtual int acid_act( dynamic acidpwr = null, dynamic toxpwr = null, dynamic acid_volume = null ) {
			return 0;
		}

		public virtual void singularity_pull(  ) {
			return;
		}

		public virtual int singularity_act(  ) {
			return 0;
		}

		public virtual int handle_slip(  ) {
			return 0;
		}

		public virtual void handle_fall(  ) {
			return;
		}

		public int isinspace(  ) {
			if ( GlobalFuncs.get_turf( this ) is Tile_Space ) {
				return 1;
			} else {
				return 0;
			}
			return 0;
		}

		public dynamic get_global_map_pos(  ) {
			int cur_x = 0;
			dynamic cur_y = null;
			dynamic y_arr = null;
			if ( !( GlobalVars.global_map is ByTable ) || Misc13.isValid( GlobalFuncs.isemptylist( GlobalVars.global_map ) ) ) {
				return null;
			}
			cur_x = 0;
			cur_y = null;
			y_arr = null;
			cur_x = 1;
			while (cur_x <= GlobalVars.global_map.len) {
				y_arr = GlobalVars.global_map[cur_x];
				cur_y = y_arr.Find( this.z );
				if ( Misc13.isValid( cur_y ) ) {
					break;
				}
				cur_x++;
			}
			if ( ( cur_x != 0 ) && Misc13.isValid( cur_y ) ) {
				return new ByTable().set( "y", cur_y ).set( "x", cur_x );
			} else {
				return 0;
			}
			return null;
		}

		public virtual int clean_blood(  ) {
			if ( this.blood_DNA is ByTable ) {
				this.blood_DNA = null;
				return 1;
			}
			return 0;
		}

		public void add_blood_floor( dynamic M = null ) {
			dynamic B = null;
			if ( this is Tile_Simulated ) {
				if ( Misc13.isValid( M.has_dna() ) ) {
					B = Misc13.get_in( typeof(Ent_Effect_Decal_Cleanable_Blood), this.contents );
					if ( !Misc13.isValid( B ) ) {
						GlobalFuncs.blood_splatter( this, M, 1 );
						B = Misc13.get_in( typeof(Ent_Effect_Decal_Cleanable_Blood), this.contents );
					}
					B.blood_DNA[M.dna.unique_enzymes] = M.dna.blood_type;
				} else if ( M is Mob_Living_Carbon_Alien ) {
					B = Misc13.get_in( typeof(Ent_Effect_Decal_Cleanable_Xenoblood), this.contents );
					if ( B == null ) {
						B = new Ent_Effect_Decal_Cleanable_Xenoblood( this );
					}
					B.blood_DNA["UNKNOWN BLOOD"] = "X*";
				} else if ( M is Mob_Living_Silicon_Robot ) {
					B = Misc13.get_in( typeof(Ent_Effect_Decal_Cleanable_Oil), this.contents );
					if ( B == null ) {
						B = new Ent_Effect_Decal_Cleanable_Oil( this );
					}
				}
			}
			return;
		}

		public void add_vomit_floor( dynamic M = null, int toxvomit = 0 ) {
			Ent_Effect_Decal_Cleanable_Vomit _this = null;
			if ( toxvomit == null ) {
				toxvomit = 0;
			}
			if ( this is Tile_Simulated ) {
				_this = new Ent_Effect_Decal_Cleanable_Vomit( this );
				if ( Misc13.isValid( M.reagents ) ) {
					M.reagents.trans_to( _this, M.reagents.total_volume / 10 );
				}
				if ( toxvomit != 0 ) {
					_this.icon_state = "vomittox_" + Rand13.pick(new object [] { 1, 4 });
				}
			}
			return;
		}

		public virtual int rejects_blood(  ) {
			return 0;
		}

		public virtual int add_blood( Mob_Living_Carbon_Human M = null ) {
			Mob_Living_Carbon_Human H = null;
			if ( ( M == null ) || !Misc13.isValid( M.has_dna() ) || Misc13.isValid( this.rejects_blood() ) ) {
				return 0;
			}
			if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				if ( H.dna.species.specflags.contains( 1024 ) ) {
					return 0;
				}
			}
			return 1;
		}

		public int add_blood_list( dynamic M = null ) {
			if ( !( this.blood_DNA is ByTable ) ) {
				this.blood_DNA = new ByTable();
			}
			if ( Misc13.isValid( this.blood_DNA[M.dna.unique_enzymes] ) ) {
				return 0;
			}
			this.blood_DNA[M.dna.unique_enzymes] = M.dna.blood_type;
			return 1;
		}

		public dynamic blood_splatter_index(  ) {
			return new Txt().Ref( Misc13.initial( this.icon ) ).str( "-" ).item( Misc13.initial( this.icon_state ) );
		}

		public virtual int hitby( dynamic AM = null, dynamic skipcatch = null, dynamic hitpush = null, dynamic blocked = null ) {
			if ( Misc13.isValid( this.density ) && !Misc13.isValid( GlobalFuncs.has_gravity( AM ) ) ) {
				Thread13.schedule( 2, (Thread13.Closure)(() => {
					Misc13.step( AM, Misc13.turn( AM.dir, 180 ) );
					return;
				}));
			}
			return 0;
		}

		public virtual int fire_act(  ) {
			return 0;
		}

		public virtual int blob_act(  ) {
			return 0;
		}

		public virtual int ex_act( int severity = 0, dynamic target = null ) {
			this.contents_explosion( severity, target );
			return 0;
		}

		public virtual void contents_explosion( int severity = 0, dynamic target = null ) {
			BaseStatic A = null;
			A = null;
			foreach (dynamic _a in this.contents ) {
				A = _a;
				if ( !( A is BaseStatic ) ) {
					continue;
				}
				A.ex_act( severity, target );
			};
			return;
		}

		public virtual int relaymove(  ) {
			return 0;
		}

		public virtual dynamic examine( Mob user = null ) {
			string f_name = "";
			Reagent R = null;
			f_name = new Txt().a( this ).item().str( "." );
			if ( ( this.blood_DNA != null ) && !( this is Ent_Effect_Decal ) ) {
				if ( this.gender == GlobalVars.PLURAL ) {
					f_name = "some ";
				} else {
					f_name = "a ";
				}
				f_name += "<span class='danger'>blood-stained</span> " + this.name + "!";
			}
			user.write( new Txt().icon( this ).str( " That's " ).item( f_name ) );
			if ( Misc13.isValid( this.desc ) ) {
				user.write( this.desc );
			}
			if ( ( this.reagents != null ) && Misc13.isValid( this.is_open_container() ) ) {
				user.write( "It contains:" );
				if ( Misc13.isValid( this.reagents.reagent_list.len ) ) {
					R = null;
					foreach (dynamic _a in this.reagents.reagent_list ) {
						R = _a;
						if ( !( R is Reagent ) ) {
							continue;
						}
						user.write( "" + R.volume + " units of " + R.name );
					};
				} else {
					user.write( "Nothing." );
				}
			}
			return null;
		}

		public Beam Beam( dynamic BeamTarget = null, string icon_state = "", ByRsc icon = null, int time = 0, int maxdistance = 0, Type beam_type = null ) {
			Beam newbeam = null;
			if ( icon_state == null ) {
				icon_state = "b_beam";
			}
			if ( icon == null ) {
				icon = new ByRsc(98);
			}
			if ( time == null ) {
				time = 50;
			}
			if ( maxdistance == null ) {
				maxdistance = 10;
			}
			if ( beam_type == null ) {
				beam_type = typeof(Ent_Effect_Ebeam);
			}
			newbeam = new Beam( this, BeamTarget, icon, icon_state, time, maxdistance, beam_type );
			Thread13.schedule( 0, (Thread13.Closure)(() => {
				newbeam.Start();
				return;
			}));
			return newbeam;
		}

		public ByTable search_contents_for( Type path = null, dynamic filter_path = null ) {
			ByTable found = null;
			BaseStatic A = null;
			int pass = 0;
			dynamic type = null;
			if ( filter_path == null ) {
				filter_path = null;
			}
			found = new ByTable();
			A = null;
			foreach (dynamic _b in this ) {
				A = _b;
				if ( !( A is BaseStatic ) ) {
					continue;
				}
				if ( Misc13.isValid( path.IsInstanceOfType( A ) ) ) {
					found += A;
				}
				if ( Misc13.isValid( filter_path ) ) {
					pass = 0;
					type = null;
					foreach (dynamic _a in filter_path ) {
						type = _a;
						pass |= type.IsInstanceOfType( A );
					};
					if ( pass == 0 ) {
						continue;
					}
				}
				if ( Misc13.isValid( A.contents.len ) ) {
					found += A.search_contents_for( path, filter_path );
				}
			};
			return found;
		}

		public int in_contents_of( dynamic container = null ) {
			if ( container is Type ) {
				if ( Misc13.isValid( container.IsInstanceOfType( this.loc ) ) ) {
					return 1;
				}
			} else if ( container.contains( this ) ) {
				return 1;
			}
			return 0;
		}

		public virtual int bullet_act( dynamic P = null, dynamic def_zone = null ) {
			int _default = 0;
			_default = P.on_hit( this, 0, def_zone );
			return 0;
			return _default;
		}

		public virtual int emp_act( int severity = 0 ) {
			return 0;
		}

		public virtual int HasProximity( dynamic AM = null ) {
			return 0;
		}

		public virtual dynamic CheckExit(  ) {
			return 1;
		}

		public virtual int allow_drop(  ) {
			return 1;
		}

		public dynamic is_open_container(  ) {
			return this.flags & 4096;
		}

		public virtual int Bumped( dynamic AM = null ) {
			return 0;
		}

		public virtual void on_reagent_change(  ) {
			return;
		}

		public virtual dynamic check_eye( Mob_Living_Silicon_Ai user = null ) {
			if ( user is Mob_Living_Silicon_Ai ) {
				return 1;
			}
			return null;
		}

		public virtual GasMixture return_air(  ) {
			if ( Misc13.isValid( this.loc ) ) {
				return this.loc.return_air();
			} else {
				return null;
			}
			return null;
		}

		public virtual GasMixture remove_air( dynamic amount = null ) {
			return null;
		}

		public virtual int assume_air( dynamic giver = null ) {
			GlobalFuncs.qdel( giver );
			return 0;
		}

		public virtual void CheckParts(  ) {
			return;
		}

		public virtual int attack_hulk( dynamic hulk = null, int do_attack_animation = 0 ) {
			if ( do_attack_animation == null ) {
				do_attack_animation = 0;
			}
			if ( do_attack_animation != 0 ) {
				hulk.changeNext_move( 8 );
				GlobalFuncs.add_logs( hulk, this, "punched", "hulk powers" );
				hulk.do_attack_animation( this );
			}
			return 0;
		}

		public int onSyndieBase(  ) {
			dynamic T = null;
			T = GlobalFuncs.get_turf( this );
			if ( !Misc13.isValid( T ) ) {
				return 0;
			}
			if ( T.z != 2 ) {
				return 0;
			}
			if ( T.loc is Zone_Shuttle_Syndicate || T.loc is Zone_SyndicateMothership ) {
				return 1;
			}
			return 0;
		}

		public dynamic onCentcom(  ) {
			dynamic T = null;
			dynamic centcom_shuttle = null;
			dynamic M = null;
			T = GlobalFuncs.get_turf( this );
			if ( !Misc13.isValid( T ) ) {
				return 0;
			}
			if ( T.z != 2 ) {
				return 0;
			}
			centcom_shuttle = null;
			foreach (dynamic _a in new ByTable(new object [] { "emergency", "pod1", "pod2", "pod3", "pod4", "ferry" }) ) {
				centcom_shuttle = _a;
				M = GlobalVars.SSshuttle.getShuttle( centcom_shuttle );
				if ( M.areaInstance.contains( T ) ) {
					return 1;
				}
			};
			return T.loc is Zone_Centcom;
		}

		public virtual dynamic attack_self_tk( dynamic user = null ) {
			return null;
		}

		public virtual dynamic attack_tk( dynamic user = null ) {
			if ( Misc13.isValid( user.stat ) ) {
				return null;
			}
			user.UnarmedAttack( this, 0 );
			return null;
		}

		public virtual int attack_slime( dynamic user = null ) {
			return 0;
		}

		public virtual int attack_larva( dynamic user = null ) {
			return 0;
		}

		public virtual int attack_alien( dynamic user = null ) {
			this.attack_paw( user );
			return 0;
		}

		public virtual int attack_paw( dynamic user = null ) {
			return 0;
		}

		public virtual int attack_animal( dynamic user = null ) {
			return 0;
		}

		public virtual int attack_hand( dynamic user = null ) {
			return 0;
		}

		public virtual void attack_ghost( Mob_Dead_Observer user = null ) {
			if ( Misc13.isValid( user.client ) && Misc13.isValid( user.client.inquisitive_ghost ) ) {
				user.examinate( this );
			}
			return;
		}

		public virtual int attackby( dynamic W = null, dynamic user = null, dynamic _params = null ) {
			return 0;
		}

		public virtual int MouseDrop_T( dynamic dropping = null, dynamic user = null ) {
			return 0;
		}

		public virtual dynamic attack_robot( dynamic user = null ) {
			this.attack_ai( user );
			return null;
		}

		public virtual void BorgAltClick( dynamic user = null ) {
			this.AltClick( user );
			return;
		}

		public virtual void BorgCtrlClick( dynamic user = null ) {
			this.CtrlClick( user );
			return;
		}

		public virtual void BorgShiftClick( dynamic user = null ) {
			this.ShiftClick( user );
			return;
		}

		public virtual void BorgCtrlShiftClick( dynamic user = null ) {
			this.CtrlShiftClick( user );
			return;
		}

		public void CtrlShiftClick( Mob user = null ) {
			return;
		}

		public virtual int AltClick( Mob user = null ) {
			dynamic T = null;
			T = GlobalFuncs.get_turf( this );
			if ( Misc13.isValid( T ) && Misc13.isValid( user.TurfAdjacent( T ) ) ) {
				if ( user.listed_turf == T ) {
					user.listed_turf = null;
				} else {
					user.listed_turf = T;
					user.client.statpanel = T.name;
				}
			}
			return 0;
		}

		public virtual void CtrlClick( Mob user = null ) {
			return;
		}

		public void ShiftClick( Mob user = null ) {
			if ( Misc13.isValid( user.client ) && user.client.eye == user || user.client.eye == user.loc ) {
				user.examinate( this );
			}
			return;
		}

		public virtual void AICtrlShiftClick(  ) {
			return;
		}

		public virtual void AIShiftClick(  ) {
			return;
		}

		public virtual void AIAltClick( dynamic user = null ) {
			this.AltClick( user );
			return;
		}

		public virtual void AICtrlClick(  ) {
			return;
		}

		public virtual int attack_ai( dynamic user = null ) {
			return 0;
		}

		public virtual dynamic Adjacent( dynamic neighbor = null ) {
			return 0;
		}

		public dynamic GetTypeInAllContents( dynamic typepath = null ) {
			ByTable processing_list = null;
			ByTable processed = null;
			dynamic found = null;
			dynamic A = null;
			BaseStatic a = null;
			processing_list = new ByTable(new object [] { this });
			processed = new ByTable();
			found = null;
			while (Misc13.isValid( processing_list.len ) && found == null) {
				A = processing_list[1];
				if ( Misc13.isValid( typepath.IsInstanceOfType( A ) ) ) {
					found = A;
				}
				processing_list -= A;
				a = null;
				foreach (dynamic _a in A ) {
					a = _a;
					if ( !( a is BaseStatic ) ) {
						continue;
					}
					if ( !processed.contains( a ) ) {
						processing_list |= a;
					}
				};
				processed |= A;
			}
			return found;
		}

		public ByTable GetAllContents(  ) {
			ByTable processing_list = null;
			ByTable assembled = null;
			dynamic A = null;
			BaseStatic a = null;
			processing_list = new ByTable(new object [] { this });
			assembled = new ByTable();
			while (Misc13.isValid( processing_list.len )) {
				A = processing_list[1];
				processing_list -= A;
				a = null;
				foreach (dynamic _a in A ) {
					a = _a;
					if ( !( a is BaseStatic ) ) {
						continue;
					}
					if ( !assembled.contains( a ) ) {
						processing_list |= a;
					}
				};
				assembled |= A;
			}
			return assembled;
		}

		public void SpinAnimation( int speed = 0, int loops = 0 ) {
			Matrix m120 = null;
			Matrix m240 = null;
			Matrix m360 = null;
			if ( speed == null ) {
				speed = 10;
			}
			if ( loops == null ) {
				loops = -1;
			}
			m120 = new Matrix( this.transform );
			m120.Turn( 120 );
			m240 = new Matrix( this.transform );
			m240.Turn( 240 );
			m360 = new Matrix( this.transform );
			speed /= 3;
			Misc13.animate_listcall( new ByTable().set( 4, loops ).set( "time", speed ).set( "transform", m120 ).set( 1, this ) );
			Misc13.animate_listcall( new ByTable().set( "time", speed ).set( "transform", m240 ) );
			Misc13.animate_listcall( new ByTable().set( "time", speed ).set( "transform", m360 ) );
			return;
		}

		public int DrawPixelOn( dynamic colour = null, dynamic drawX = null, dynamic drawY = null ) {
			Icon I = null;
			dynamic J = null;
			I = new Icon( this.icon );
			J = GlobalFuncs.DrawPixel( I, colour, drawX, drawY );
			if ( Misc13.isValid( J ) ) {
				this.icon = J;
				return J;
			}
			return 0;
		}

		public void clear_smooth_overlays(  ) {
			this.overlays -= this.top_left_corner;
			this.overlays -= this.top_right_corner;
			this.overlays -= this.bottom_right_corner;
			this.overlays -= this.bottom_left_corner;
			return;
		}

	}

	partial class Image : BaseData {

		public override void ResetVars(  ) {
			base.ResetVars();
			this.loc = null;
			return;
		}

	}

	partial class Mob : BaseDynamic {

		public dynamic glide_size = 8;
		public dynamic mouse_drag_pointer = 1;

		public double next_click = 0;
		public int next_move_adjust = 0;
		public int next_move_modifier = 1;
		public dynamic skincmds = null;
		public int suiciding = 0;
		public ByTable open_uis = null;
		public dynamic alerts = null;
		public HSB sandbox = null;
		public int bloody_hands = 0;
		public dynamic bloody_hands_mob = null;
		public Mind mind = null;
		public int stat = 0;
		public Ent_Screen flash = null;
		public Ent_Screen blind = null;
		public Ent_Screen_Robot_Module hands = null;
		public Ent_Screen_Pull pullin = null;
		public Ent_Screen_Internals internals = null;
		public dynamic i_select = null;
		public dynamic m_select = null;
		public Ent_Screen healths = null;
		public dynamic throw_icon = null;
		public Ent_Screen damageoverlay = null;
		public Ent_Screen_ZoneSel zone_sel = null;
		public dynamic leap_icon = null;
		public Ent_Screen healthdoll = null;
		public int damageoverlaytemp = 0;
		public dynamic computer_id = null;
		public dynamic lastattacker = null;
		public dynamic lastattacked = null;
		public string attack_log = "";
		public dynamic machine = null;
		public dynamic other_mobs = null;
		public string memory = "";
		public dynamic disabilities = 0;
		public dynamic pulling = null;
		public double next_move = 0;
		public int notransform = 0;
		public dynamic hand = null;
		public int eye_blind = 0;
		public int eye_blurry = 0;
		public int ear_deaf = 0;
		public int ear_damage = 0;
		public int stuttering = 0;
		public int slurring = 0;
		public dynamic real_name = null;
		public int druggy = 0;
		public int confused = 0;
		public int sleeping = 0;
		public dynamic resting = 0;
		public dynamic lying = 0;
		public dynamic lying_prev = 0;
		public dynamic canmove = 1;
		public int eye_stat = 0;
		public int lastpuke = 0;
		public dynamic name_archive = null;
		public double timeofdeath = 0;
		public int cpr_time = 1;
		public double bodytemperature = 310.05499267578125;
		public int drowsyness = 0;
		public int dizziness = 0;
		public int jitteriness = 0;
		public int nutrition = 400;
		public int satiety = 0;
		public int overeatduration = 0;
		public int paralysis = 0;
		public int stunned = 0;
		public int weakened = 0;
		public int losebreath = 0;
		public int shakecamera = 0;
		public string a_intent = "help";
		public string m_intent = "run";
		public dynamic lastKnownIP = null;
		public dynamic buckled = null;
		public dynamic l_hand = null;
		public dynamic r_hand = null;
		public Ent_Item_Weapon_Storage s_active = null;
		public int seer = 0;
		public int see_override = 0;
		public Hud hud_used = null;
		public int research_scanner = 0;
		public dynamic scanner = null;
		public dynamic grabbed_by = null;
		public dynamic requests = null;
		public dynamic mapobjs = null;
		public int in_throw_mode = 0;
		public string music_lastplayed = "null";
		public string job = "";
		public int radiation = 0;
		public string voice_name = "unidentifiable voice";
		public ByTable faction = new ByTable(new object [] { "slime" });
		public int move_on_shuttle = 1;
		public dynamic LAssailant = null;
		public ByTable mob_spell_list = null;
		public ByTable viruses = null;
		public ByTable resistances = null;
		public dynamic virus = null;
		public int status_flags = 15;
		public dynamic lastarea = null;
		public int digitalcamo = 0;
		public int digitalinvis = 0;
		public dynamic digitaldisguise = null;
		public int weakeyes = 0;
		public int has_unlimited_silicon_privilege = 0;
		public int force_compose = 0;
		public dynamic control_object = null;
		public dynamic remote_control = null;
		public dynamic listed_turf = null;
		public dynamic permanent_huds = null;
		public int permanent_sight_flags = 0;
		public int resize = 1;

		public dynamic flags = 16;
		public ByTable hud_possible = null;
		public int pressure_resistance = 8;

		public Mob ( BaseStatic _loc = null ) : base( _loc ) {
			this.tag = "mob_" + GlobalVars.next_mob_id++;
			GlobalVars.mob_list += this;
			if ( this.stat == 2 ) {
				GlobalVars.dead_mob_list += this;
			} else {
				GlobalVars.living_mob_list += this;
			}
			this.prepare_huds();
			return;
		}

		public override void pipe_eject( dynamic direction = null ) {
			if ( Misc13.isValid( this.client ) ) {
				this.client.perspective = GlobalVars.MOB_PERSPECTIVE;
				this.client.eye = this;
			}
			return;
		}

		public override int Process_Spacemove( int movement_dir = 0 ) {
			dynamic dense_object_backup = null;
			dynamic A = null;
			dynamic turf = null;
			dynamic AM = null;
			if ( movement_dir == null ) {
				movement_dir = 0;
			}
			if ( Misc13.isValid( base.Process_Spacemove() ) ) {
				return 1;
			}
			A = null;
			foreach (dynamic _a in Misc13.range_nocenter( GlobalFuncs.get_turf( this ), 1 ) ) {
				A = _a;
				if ( !( A is BaseStatic ) ) {
					continue;
				}
				if ( A is Zone ) {
					continue;
				} else if ( A is Tile ) {
					turf = A;
					if ( turf is Tile_Space ) {
						continue;
					}
					if ( !Misc13.isValid( turf.density ) && !Misc13.isValid( this.mob_negates_gravity() ) ) {
						continue;
					}
					return 1;
				} else {
					AM = A;
					if ( AM == this.buckled ) {
						continue;
					}
					if ( Misc13.isValid( AM.density ) ) {
						if ( Misc13.isValid( AM.anchored ) ) {
							return 1;
						}
						if ( this.pulling == AM ) {
							continue;
						}
						dense_object_backup = AM;
					}
				}
			};
			if ( ( movement_dir != 0 ) && Misc13.isValid( dense_object_backup ) ) {
				if ( Misc13.isValid( dense_object_backup.newtonian_move( Misc13.turn( movement_dir, 180 ) ) ) ) {
					this.write( "<span class='info'>You push off of " + dense_object_backup + " to propel yourself.</span>" );
				}
				return 1;
			}
			return 0;
		}

		public override dynamic CanPass( dynamic mover = null, dynamic target = null, int height = 0 ) {
			dynamic moving_mob = null;
			if ( height == null ) {
				height = 0;
			}
			if ( height == 0 ) {
				return 1;
			}
			if ( mover is Ent_Item_Projectile || Misc13.isValid( mover.throwing ) ) {
				return !Misc13.isValid( this.density ) || Misc13.isValid( this.lying );
			}
			if ( Misc13.isValid( mover.checkpass( 16 ) ) ) {
				return 1;
			}
			if ( this.buckled == mover ) {
				return 1;
			}
			if ( mover is Mob ) {
				moving_mob = mover;
				if ( Misc13.isValid( this.other_mobs ) && Misc13.isValid( moving_mob.other_mobs ) ) {
					return 1;
				}
				if ( mover == this.buckled_mob ) {
					return 1;
				}
			}
			return !Misc13.isValid( mover.density ) || !Misc13.isValid( this.density ) || Misc13.isValid( this.lying );
		}

		public override void post_buckle_mob( dynamic M = null ) {
			dynamic height = null;
			if ( M == this.buckled_mob ) {
				height = M.get_mob_buckling_height( this );
				M.pixel_y = Misc13.initial( M.pixel_y ) + height;
				if ( M.layer < this.layer ) {
					M.layer = this.layer + 0.10000000149011612;
				}
			} else {
				M.layer = Misc13.initial( M.layer );
				M.pixel_y = Misc13.initial( M.pixel_y );
			}
			return;
		}

		public override int buckle_mob( dynamic M = null, int force = 0 ) {
			dynamic T = null;
			dynamic old_density = null;
			dynamic can_step = null;
			if ( force == null ) {
				force = 0;
			}
			if ( Misc13.isValid( M.buckled ) ) {
				return 0;
			}
			T = GlobalFuncs.get_turf( this );
			if ( M.loc != T ) {
				old_density = this.density;
				this.density = 0;
				Misc13.step_towards( M, T );
				can_step = null;
				this.density = old_density;
				if ( !Misc13.isValid( can_step ) ) {
					return 0;
				}
			}
			return base.buckle_mob();
		}

		public override void shuttleRotate( dynamic rotation = null ) {
			this.dir = GlobalFuncs.angle2dir( rotation + GlobalFuncs.dir2angle( this.dir ) );
			return;
		}


//FAILURE

		public override int MouseDrop( Mob_Living_Silicon_Ai M = null ) {
			base.MouseDrop();
			if ( M != Misc13.thread_user ) {
				return 0;
			}
			if ( Misc13.thread_user == this ) {
				return 0;
			}
			if ( !Misc13.isValid( this.Adjacent( Misc13.thread_user ) ) ) {
				return 0;
			}
			if ( M is Mob_Living_Silicon_Ai ) {
				return 0;
			}
			this.show_inv( Misc13.thread_user );
			return 0;
		}

		public virtual int Topic( dynamic href = null, dynamic href_list = null ) {
			string t1 = "";
			dynamic slot = null;
			dynamic what = null;
			if ( Misc13.isValid( href_list["mach_close"] ) ) {
				t1 = "window=" + href_list["mach_close"];
				this.unset_machine();
				Misc13.browse( this, null, t1 );
			}
			if ( Misc13.isValid( href_list["refresh"] ) ) {
				if ( Misc13.isValid( this.machine ) && Misc13.get_dist( this, Misc13.thread_user ) <= 1 ) {
					this.show_inv( this.machine );
				}
			}
			if ( Misc13.isValid( Misc13.thread_user.canUseTopic( this, 1, 1 ) ) ) {
				if ( Misc13.isValid( href_list["item"] ) ) {
					slot = Misc13.parseNumber( href_list["item"] );
					what = this.get_item_by_slot( slot );
					if ( Misc13.isValid( what ) ) {
						Misc13.thread_user.stripPanelUnequip( what, this, slot );
					} else {
						Misc13.thread_user.stripPanelEquip( what, this, slot );
					}
				}
			}
			if ( Misc13.thread_user.machine == this ) {
				if ( Misc13.isValid( this.Adjacent( Misc13.thread_user ) ) ) {
					this.show_inv( Misc13.thread_user );
				} else {
					Misc13.browse( Misc13.thread_user, null, new Txt( "window=mob" ).Ref( this ) );
				}
			}
			return 0;
		}

		public override void audible_message( dynamic message = null, dynamic deaf_message = null, dynamic hearing_distance = null, dynamic self_message = null ) {
			int range = 0;
			dynamic M = null;
			dynamic msg = null;
			range = 7;
			if ( Misc13.isValid( hearing_distance ) ) {
				range = hearing_distance;
			}
			M = null;
			foreach (dynamic _a in GlobalFuncs.get_hearers_in_view( range, this ) ) {
				M = _a;
				msg = message;
				if ( Misc13.isValid( self_message ) && M == this ) {
					msg = self_message;
				}
				M.show_message( msg, 2, deaf_message, 1 );
			};
			return;
		}

		public override void visible_message( dynamic message = null, dynamic self_message = null, dynamic blind_message = null ) {
			ByTable mob_viewers = null;
			ByTable possible_viewers = null;
			dynamic heard = null;
			BaseDynamic A = null;
			dynamic B = null;
			dynamic T = null;
			dynamic M = null;
			dynamic msg = null;
			ByTable mob_hearers = null;
			dynamic C = null;
			dynamic MOB = null;
			mob_viewers = new ByTable();
			possible_viewers = new ByTable();
			mob_viewers |= this;
			mob_viewers |= Misc13.viewers( this, null );
			heard = GlobalFuncs.get_hear( 7, this );
			A = null;
			foreach (dynamic _a in heard ) {
				A = _a;
				if ( !( A is BaseDynamic ) ) {
					continue;
				}
				possible_viewers |= GlobalFuncs.recursive_hear_check( A );
			};
			B = null;
			foreach (dynamic _b in possible_viewers ) {
				B = _b;
				if ( mob_viewers.contains( B ) ) {
					continue;
				}
				if ( B.loc is Tile ) {
					continue;
				}
				T = GlobalFuncs.get_turf( B );
				if ( Misc13.view( T, null ).contains( this ) ) {
					mob_viewers |= B;
				}
			};
			M = null;
			foreach (dynamic _c in mob_viewers ) {
				M = _c;
				if ( M.see_invisible < this.invisibility ) {
					continue;
				}
				msg = message;
				if ( Misc13.isValid( self_message ) && M == this ) {
					msg = self_message;
				}
				M.show_message( msg, 1 );
			};
			if ( Misc13.isValid( blind_message ) ) {
				mob_hearers = new ByTable();
				C = null;
				foreach (dynamic _d in GlobalFuncs.get_hearers_in_view( 7, this ) ) {
					C = _d;
					if ( mob_viewers.contains( C ) ) {
						continue;
					}
					mob_hearers |= C;
				};
				MOB = null;
				foreach (dynamic _e in mob_hearers ) {
					MOB = _e;
					MOB.show_message( blind_message, 2 );
				};
			}
			return;
		}

		public override int Destroy(  ) {
			dynamic infection = null;
			GlobalVars.mob_list -= this;
			GlobalVars.dead_mob_list -= this;
			GlobalVars.living_mob_list -= this;
			GlobalFuncs.qdel( this.hud_used );
			if ( ( this.mind != null ) && this.mind.current == this ) {
				this.spellremove( this );
			}
			infection = null;
			foreach (dynamic _a in this.viruses ) {
				infection = _a;
				GlobalFuncs.qdel( infection );
			};
			this.ghostize();
			return base.Destroy();
		}

		public virtual int Logout(  ) {
			dynamic admins_number = null;
			string cheesy_message = "";
			dynamic Loc = null;
			GlobalVars.SSnano.user_logout( this );
			GlobalVars.player_list -= this;
			GlobalFuncs.log_access( "Logout: " + GlobalFuncs.key_name( this ) );
			if ( Misc13.isValid( GlobalVars.admin_datums[this.ckey] ) ) {
				if ( ( GlobalVars.ticker != null ) && GlobalVars.ticker.current_state == 3 ) {
					admins_number = GlobalVars.admins.len;
					if ( admins_number == 0 ) {
						cheesy_message = Rand13.pick( new ByTable(new object [] { "I have no admins online!", "I'm all alone :(", "I'm feeling lonely :(", "I'm so lonely :(", "Why does nobody love me? :(", "I want a man :(", "Where has everyone gone?", "I need a hug :(", "Someone come hold me :(", "I need someone on me :(", "What happened? Where has everyone gone?", "Forever alone :(" }) );
						if ( Misc13.isValid( cheesy_message ) ) {
							cheesy_message += " (No admins online)";
						}
						GlobalFuncs.send2irc( "Server", "" + cheesy_message );
					}
				}
			}
			base.Logout();
			if ( this.loc is Entity ) {
				Loc = this.loc;
				Loc.on_log();
			}
			return 1;
		}

		public virtual dynamic Login(  ) {
			dynamic Loc = null;
			GlobalVars.player_list |= this;
			this.update_Login_details();
			Game.update_status();
			this.client.images = null;
			this.client.screen = new ByTable();
			if ( this.hud_used != null ) {
				GlobalFuncs.qdel( this.hud_used );
			}
			this.hud_used = new Hud( this );
			this.next_move = 1;
			this.sight |= GlobalVars.SEE_SELF;
			base.Login();
			if ( Misc13.isValid( this.loc ) && !( this.loc is Tile ) ) {
				this.client.eye = this.loc;
				this.client.perspective = GlobalVars.EYE_PERSPECTIVE;
			} else {
				this.client.eye = this;
				this.client.perspective = GlobalVars.MOB_PERSPECTIVE;
			}
			if ( this.loc is Entity ) {
				Loc = this.loc;
				Loc.on_log();
			}
			this.reload_huds();
			if ( GlobalVars.deadmins.contains( this.ckey ) ) {
				this.verbs += typeof(Client).GetMethod( "readmin" );
			}
			this.client.screen += GlobalVars._void;
			return null;
		}

		public override dynamic get_light_range( dynamic radius = null ) {
			return Misc13.min( radius, 5 );
		}

		public override void playsound_local( dynamic turf_source = null, dynamic soundin = null, dynamic vol = null, dynamic vary = null, dynamic frequency = null, dynamic falloff = null, int surround = 0 ) {
			if ( surround == null ) {
				surround = 1;
			}
			if ( !Misc13.isValid( this.client ) || this.ear_deaf > 0 ) {
				return;
			}
			base.playsound_local();
			return;
		}

		public override dynamic attack_tk( dynamic user = null ) {
			return null;
		}

		public virtual void hotkey_help(  ) {
			string hotkey_mode = "";
			string other = "";
			hotkey_mode = "<font color='purple'>\nHotkey-Mode: (hotkey-mode must be on)\n	TAB = toggle hotkey-mode\n	a = left\n	s = down\n	d = right\n	w = up\n	q = drop\n	e = equip\n	r = throw\n	m = me\n	t = say\n	o = OOC\n	b = resist\n	x = swap-hand\n	z = activate held object (or y)\n	f = cycle-intents-left\n	g = cycle-intents-right\n	1 = help-intent\n	2 = disarm-intent\n	3 = grab-intent\n	4 = harm-intent\n</font>";
			other = "<font color='purple'>\nAny-Mode: (hotkey doesn't need to be on)\n	Ctrl+a = left\n	Ctrl+s = down\n	Ctrl+d = right\n	Ctrl+w = up\n	Ctrl+q = drop\n	Ctrl+e = equip\n	Ctrl+r = throw\n	Ctrl+b = resist\n	Ctrl+O = OOC\n	Ctrl+x = swap-hand\n	Ctrl+z = activate held object (or Ctrl+y)\n	Ctrl+f = cycle-intents-left\n	Ctrl+g = cycle-intents-right\n	Ctrl+1 = help-intent\n	Ctrl+2 = disarm-intent\n	Ctrl+3 = grab-intent\n	Ctrl+4 = harm-intent\n	DEL = pull\n	INS = cycle-intents-right\n	HOME = drop\n	PGUP = swap-hand\n	PGDN = activate held object\n	END = throw\n</font>";
			this.write( hotkey_mode );
			this.write( other );
			return;
		}

		public virtual dynamic getlimb(  ) {
			return null;
		}

		public virtual Ent_Item_Organ_Internal getorganslot( dynamic slot = null ) {
			return null;
		}

		public virtual ByTable getorganszone( dynamic zone = null ) {
			return null;
		}

		public virtual dynamic getorgan( Type typepath = null ) {
			return null;
		}

		public virtual void throw_item( dynamic target = null ) {
			return;
		}

		public virtual int binarycheck(  ) {
			return 0;
		}

		public virtual ByTable get_contents(  ) {
			return null;
		}

		public Mob_Dead_Observer ghostize( int can_reenter_corpse = 0 ) {
			Mob_Dead_Observer ghost = null;
			if ( can_reenter_corpse == null ) {
				can_reenter_corpse = 1;
			}
			if ( Misc13.isValid( this.key ) ) {
				if ( !Misc13.isValid( Misc13.str_cmp( "@", Misc13.str_sub( this.key, 1, 2 ) ) ) ) {
					ghost = new Mob_Dead_Observer( this );
					ghost.can_reenter_corpse = can_reenter_corpse;
					ghost.key = this.key;
					return ghost;
				}
			}
			return null;
		}

		public virtual void update_inv_ears(  ) {
			return;
		}

		public virtual void update_inv_pockets(  ) {
			return;
		}

		public virtual void update_inv_s_store(  ) {
			return;
		}

		public virtual void update_inv_glasses(  ) {
			return;
		}

		public virtual void update_inv_shoes(  ) {
			return;
		}

		public virtual void update_inv_wear_id(  ) {
			return;
		}

		public virtual void update_inv_gloves(  ) {
			return;
		}

		public virtual void update_hair(  ) {
			return;
		}

		public virtual dynamic update_inv_head(  ) {
			return null;
		}

		public virtual void update_inv_belt(  ) {
			return;
		}

		public virtual void update_inv_w_uniform(  ) {
			return;
		}

		public virtual void update_inv_wear_suit(  ) {
			return;
		}

		public virtual dynamic update_inv_wear_mask(  ) {
			return null;
		}

		public virtual void update_inv_r_hand(  ) {
			return;
		}

		public virtual void update_inv_l_hand(  ) {
			return;
		}

		public virtual dynamic update_inv_back(  ) {
			return null;
		}

		public virtual void update_inv_legcuffed(  ) {
			return;
		}

		public virtual int update_inv_handcuffed(  ) {
			return 0;
		}

		public virtual dynamic update_transform(  ) {
			return null;
		}

		public virtual int update_hud(  ) {
			return 0;
		}

		public virtual void update_icons(  ) {
			return;
		}

		public virtual int regenerate_icons(  ) {
			return 0;
		}

		public int safe_animal( dynamic MP = null ) {
			if ( !Misc13.isValid( MP ) ) {
				return 0;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Construct) ) ) ) {
				return 0;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Pet_Cat) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Pet_Dog_Corgi) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Crab) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Hostile_Carp) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Hostile_Mushroom) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Shade) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Hostile_Killertomato) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Mouse) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Hostile_Bear) ) ) ) {
				return 1;
			}
			if ( Misc13.isValid( MP.IsSubclassOf( typeof(Mob_Living_SimpleAnimal_Parrot) ) ) ) {
				return 1;
			}
			return 0;
		}

		public virtual dynamic Animalize(  ) {
			dynamic _default = null;
			dynamic mobtypes = null;
			dynamic mobpath = null;
			dynamic new_mob = null;
			mobtypes = Misc13.types( typeof(Mob_Living_SimpleAnimal) );
			mobpath = Misc13.input( "Which type of mob should " + this + " turn into?", "Choose a type", null, null, mobtypes, 0 );
			if ( !Misc13.isValid( this.safe_animal( mobpath ) ) ) {
				Misc13.thread_user.write( "<span class='danger'>Sorry but this mob type is currently unavailable.</span>" );
				return null;
			}
			new_mob = Misc13.call( mobpath, this.loc );
			new_mob.key = this.key;
			new_mob.a_intent = "harm";
			new_mob.write( "You feel more... animalistic" );
			new_mob.update_pipe_vision();
			_default = new_mob;
			GlobalFuncs.qdel( this );
			return null;
			return _default;
		}

		public virtual Mob_Living_Silicon_Ai AIize(  ) {
			Mob_Living_Silicon_Ai _default = null;
			Mob_Living_Silicon_Ai O = null;
			dynamic loc_landmark = null;
			Ent_Effect_Landmark_Start sloc = null;
			Ent_Effect_Landmark tripai = null;
			Ent_Item_Device_Radio_Intercom comm = null;
			if ( Misc13.isValid( this.client ) ) {
				this.stopLobbySound();
			}
			O = new Mob_Living_Silicon_Ai( this.loc, null, null, 1 );
			O.invisibility = 0;
			O.aiRestorePowerRoutine = 0;
			if ( this.mind != null ) {
				this.mind.transfer_to( O );
			} else {
				O.key = this.key;
			}
			O.update_pipe_vision();
			sloc = null;
			foreach (dynamic _a in GlobalVars.landmarks_list ) {
				sloc = _a;
				if ( !( sloc is Ent_Effect_Landmark_Start ) ) {
					continue;
				}
				if ( sloc.name != "AI" ) {
					continue;
				}
				if ( Misc13.isValid( Misc13.get_in( typeof(Mob_Living), sloc.loc ) ) ) {
					continue;
				}
				loc_landmark = sloc;
			};
			if ( !Misc13.isValid( loc_landmark ) ) {
				tripai = null;
				foreach (dynamic _b in GlobalVars.landmarks_list ) {
					tripai = _b;
					if ( !( tripai is Ent_Effect_Landmark ) ) {
						continue;
					}
					if ( tripai.name == "tripai" ) {
						if ( Misc13.isValid( Misc13.get_in( typeof(Mob_Living), tripai.loc ) ) ) {
							continue;
						}
						loc_landmark = tripai;
					}
				};
			}
			if ( !Misc13.isValid( loc_landmark ) ) {
				O.write( "Oh god sorry we can't find an unoccupied AI spawn location, so we're spawning you on top of someone." );
				sloc = null;
				foreach (dynamic _c in GlobalVars.landmarks_list ) {
					sloc = _c;
					if ( !( sloc is Ent_Effect_Landmark_Start ) ) {
						continue;
					}
					if ( sloc.name == "AI" ) {
						loc_landmark = sloc;
					}
				};
			}
			O.loc = loc_landmark.loc;
			comm = null;
			foreach (dynamic _d in O.loc ) {
				comm = _d;
				if ( !( comm is Ent_Item_Device_Radio_Intercom ) ) {
					continue;
				}
				comm.ai += O;
			};
			O.write( "<B>You are playing the station's AI. The AI cannot move, but can interact with many objects while viewing them (through cameras).</B>" );
			O.write( "<B>To look at other parts of the station, click on yourself to get a camera menu.</B>" );
			O.write( "<B>While observing through a camera, you can use most (networked) devices which you can see, such as computers, APCs, intercoms, doors, etc.</B>" );
			O.write( "To use something, simply click on it." );
			O.write( "Use say \":b to speak to your cyborgs through binary." );
			O.write( "For department channels, use the following say commands:" );
			O.write( ":o - AI Private, :c - Command, :s - Security, :e - Engineering, :u - Supply, :v - Service, :m - Medical, :n - Science." );
			if ( !( ( GlobalVars.ticker != null ) && Misc13.isValid( GlobalVars.ticker.mode ) && GlobalVars.ticker.mode.malf_ai.contains( O.mind ) ) ) {
				O.show_laws();
				O.write( "<b>These laws may be changed by other players, or by you being the traitor.</b>" );
			}
			O.verbs += typeof(Mob_Living_Silicon_Ai).GetMethod( "show_laws_verb" );
			O.verbs += typeof(Mob_Living_Silicon_Ai).GetMethod( "ai_statuschange" );
			O.job = "AI";
			O.rename_self( "ai", 1 );
			_default = O;
			GlobalFuncs.qdel( this );
			return null;
			return _default;
		}

		public virtual int lingcheck(  ) {
			return 0;
		}

		public virtual int hivecheck(  ) {
			return 0;
		}

		public virtual void emote( dynamic act = null ) {
			return;
		}

		public void say_dead( dynamic message = null ) {
			dynamic name = null;
			string alt_name = "";
			string rendered = "";
			Mob_NewPlayer M = null;
			name = this.real_name;
			alt_name = "";
			if ( Misc13.isValid( GlobalVars.say_disabled ) ) {
				Misc13.thread_user.write( "<span class='danger'>Speech is currently admin-disabled.</span>" );
				return;
			}
			if ( ( this.mind != null ) && Misc13.isValid( this.mind.name ) ) {
				name = "" + this.mind.name;
			} else {
				name = this.real_name;
			}
			if ( name != this.real_name ) {
				alt_name = " (died as " + this.real_name + ")";
			}
			message = this.say_quote( message, this.get_spans() );
			rendered = "<span class='game deadsay'><span class='prefix'>DEAD:</span> <span class='name'>" + name + "</span>" + alt_name + " <span class='message'>" + message + "</span></span>";
			M = null;
			foreach (dynamic _a in GlobalVars.player_list ) {
				M = _a;
				if ( M is Mob_NewPlayer ) {
					continue;
				}
				if ( Misc13.isValid( M.client ) && Misc13.isValid( M.client.holder ) && Misc13.isValid( ( M.client.prefs.chat_toggles & 2 ) ) ) {
					M.write( rendered );
				} else if ( M.stat == 2 ) {
					M.write( rendered );
				}
			};
			return;
		}

		public dynamic change_mob_type( dynamic new_type = null, Tile location = null, string new_name = "", int delete_old_mob = 0 ) {
			dynamic M = null;
			Mob C = null;
			dynamic D = null;
			dynamic H = null;
			if ( new_type == null ) {
				new_type = null;
			}
			if ( location == null ) {
				location = null;
			}
			if ( new_name == null ) {
				new_name = null;
			}
			if ( delete_old_mob == null ) {
				delete_old_mob = 0;
			}
			if ( this is Mob_NewPlayer ) {
				Misc13.thread_user.write( "<span class='danger'>cannot convert players who have not entered yet.</span>" );
				return null;
			}
			if ( !Misc13.isValid( new_type ) ) {
				new_type = Misc13.input( "Mob type path:", "Mob type", null, null, null, 132 );
			}
			if ( new_type is string ) {
				new_type = Misc13.findType( new_type );
			}
			if ( !( new_type is Type ) ) {
				Misc13.thread_user.write( "Invalid type path (new_type = " + new_type + ") in change_mob_type(). Contact a coder." );
				return null;
			}
			if ( new_type == typeof(Mob_NewPlayer) ) {
				Misc13.thread_user.write( "<span class='danger'>cannot convert into a new_player mob type.</span>" );
				return null;
			}
			if ( location is Tile ) {
				M = Misc13.call( new_type, location );
			} else {
				M = Misc13.call( new_type, this.loc );
			}
			if ( !Misc13.isValid( M ) || !( M is Mob ) ) {
				Misc13.thread_user.write( "Type path is not a mob (new_type = " + new_type + ") in change_mob_type(). Contact a coder." );
				GlobalFuncs.qdel( M );
				return null;
			}
			if ( new_name is string ) {
				M.name = new_name;
				M.real_name = new_name;
			} else {
				M.name = this.name;
				M.real_name = this.real_name;
			}
			if ( Misc13.isValid( this.has_dna() ) && Misc13.isValid( M.has_dna() ) ) {
				C = this;
				D = M;
				C.dna.transfer_identity( D );
				new ByTable().set( "mutations_overlay_update", 1 ).set( "mutcolor_update", 1 ).apply( D.GetType().GetMethod( "updateappearance" ) );
			} else if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				this.client.prefs.copy_to( H );
				H.dna.update_dna_identity();
			}
			if ( ( this.mind != null ) && M is Mob_Living ) {
				this.mind.transfer_to( M );
			} else {
				M.key = this.key;
			}
			if ( delete_old_mob != 0 ) {
				Thread13.schedule( 1, (Thread13.Closure)(() => {
					GlobalFuncs.qdel( this );
					return;
				}));
			}
			return M;
		}

		public virtual void update_gravity(  ) {
			return;
		}

		public virtual int slip( dynamic s_amount = null, dynamic w_amount = null, dynamic O = null, dynamic lube = null ) {
			return 0;
		}

		public void Move_Pulled( dynamic A = null ) {
			dynamic M = null;
			dynamic t = null;
			if ( !Misc13.isValid( this.canmove ) || Misc13.isValid( this.restrained() ) || !Misc13.isValid( this.pulling ) ) {
				return;
			}
			if ( Misc13.isValid( this.pulling.anchored ) ) {
				return;
			}
			if ( !Misc13.isValid( this.pulling.Adjacent( this ) ) ) {
				return;
			}
			if ( A == this.loc && Misc13.isValid( this.pulling.density ) ) {
				return;
			}
			if ( !Misc13.isValid( this.Process_Spacemove( Misc13.get_dist( this.pulling.loc, A ) ) ) ) {
				return;
			}
			if ( this.pulling is Mob ) {
				M = this.pulling;
				t = M.pulling;
				M.stop_pulling();
				Misc13.step( this.pulling, Misc13.get_dist( this.pulling.loc, A ) );
				if ( Misc13.isValid( M ) ) {
					M.start_pulling( t );
				}
			} else {
				Misc13.step( this.pulling, Misc13.get_dist( this.pulling.loc, A ) );
			}
			return;
		}

		public virtual dynamic mob_negates_gravity(  ) {
			return 0;
		}

		public virtual dynamic mob_has_gravity( dynamic T = null ) {
			return GlobalFuncs.has_gravity( this, T );
		}

		public virtual int reagent_check( dynamic R = null ) {
			return 1;
		}

		public virtual int abiotic( int full_body = 0 ) {
			if ( full_body == null ) {
				full_body = 0;
			}
			if ( Misc13.isValid( this.l_hand ) && !Misc13.isValid( this.l_hand.flags ) & 128 || Misc13.isValid( this.r_hand ) && !Misc13.isValid( this.r_hand.flags ) & 128 ) {
				return 1;
			}
			return 0;
		}

		public virtual int can_unbuckle(  ) {
			return 1;
		}

		public virtual int f_can_buckle(  ) {
			return 1;
		}

		public virtual int get_mob_buckling_height( Mob_Living seat = null ) {
			Mob_Living L = null;
			if ( seat is Mob_Living ) {
				L = seat;
				if ( L.mob_size <= 1 ) {
					return 0;
				}
			}
			return 9;
		}

		public void AddSpell( dynamic spell = null ) {
			this.mob_spell_list += spell;
			if ( !Misc13.isValid( spell.action ) ) {
				spell.action = new Action_SpellAction();
				spell.action.target = spell;
				spell.action.name = spell.name;
				spell.action.button_icon = spell.action_icon;
				spell.action.button_icon_state = spell.action_icon_state;
				spell.action.background_icon_state = spell.action_background_icon_state;
			}
			if ( this is Mob_Living ) {
				spell.action.Grant( this );
			}
			return;
		}

		public virtual void setEarDamage(  ) {
			return;
		}

		public virtual void adjustEarDamage(  ) {
			return;
		}

		public dynamic notify_ghost_cloning( string message = "", ByRsc sound = null, dynamic source = null ) {
			dynamic ghost = null;
			if ( message == null ) {
				message = "Someone is trying to revive you. Re-enter your corpse if you want to be revived!";
			}
			if ( sound == null ) {
				sound = new ByRsc(231);
			}
			if ( source == null ) {
				source = null;
			}
			ghost = this.get_ghost();
			if ( Misc13.isValid( ghost ) ) {
				ghost.notify_cloning( message, sound, source );
				return ghost;
			}
			return null;
		}

		public Mob_Dead_Observer get_ghost( int even_if_they_cant_reenter = 0 ) {
			Mob_Dead_Observer G = null;
			if ( even_if_they_cant_reenter == null ) {
				even_if_they_cant_reenter = 0;
			}
			if ( this.mind != null ) {
				G = null;
				foreach (dynamic _a in GlobalVars.dead_mob_list ) {
					G = _a;
					if ( !( G is Mob_Dead_Observer ) ) {
						continue;
					}
					if ( G.mind == this.mind ) {
						if ( ( G.can_reenter_corpse != 0 ) || ( even_if_they_cant_reenter != 0 ) ) {
							return G;
						}
						break;
					}
				};
			}
			return null;
		}

		public virtual int assess_threat(  ) {
			return 0;
		}

		public void AdjustResting( dynamic amount = null ) {
			this.resting = Misc13.max( this.resting + amount, 0 );
			this.update_canmove();
			return;
		}

		public void SetResting( dynamic amount = null ) {
			this.resting = Misc13.max( amount, 0 );
			this.update_canmove();
			return;
		}

		public void Resting( dynamic amount = null ) {
			this.resting = Misc13.max( Misc13.max( this.resting, amount ), 0 );
			this.update_canmove();
			return;
		}

		public void AdjustSleeping( dynamic amount = null ) {
			this.sleeping = Misc13.max( this.sleeping + amount, 0 );
			this.update_canmove();
			return;
		}

		public void SetSleeping( dynamic amount = null ) {
			this.sleeping = Misc13.max( amount, 0 );
			this.update_canmove();
			return;
		}

		public void Sleeping( dynamic amount = null ) {
			this.sleeping = Misc13.max( Misc13.max( this.sleeping, amount ), 0 );
			this.update_canmove();
			return;
		}

		public void AdjustParalysis( int amount = 0 ) {
			if ( ( this.status_flags & 4 ) != 0 ) {
				this.paralysis = Misc13.max( this.paralysis + amount, 0 );
				this.update_canmove();
			}
			return;
		}

		public void SetParalysis( int amount = 0 ) {
			if ( ( this.status_flags & 4 ) != 0 ) {
				this.paralysis = Misc13.max( amount, 0 );
				this.update_canmove();
			}
			return;
		}

		public void Paralyse( int amount = 0 ) {
			if ( ( this.status_flags & 4 ) != 0 ) {
				this.paralysis = Misc13.max( Misc13.max( this.paralysis, amount ), 0 );
				this.update_canmove();
			}
			return;
		}

		public void AdjustWeakened( int amount = 0 ) {
			if ( ( this.status_flags & 2 ) != 0 ) {
				this.weakened = Misc13.max( this.weakened + amount, 0 );
				this.update_canmove();
			}
			return;
		}

		public void SetWeakened( int amount = 0 ) {
			if ( ( this.status_flags & 2 ) != 0 ) {
				this.weakened = Misc13.max( amount, 0 );
				this.update_canmove();
			}
			return;
		}

		public void Weaken( int amount = 0, int ignore_canweaken = 0 ) {
			if ( ignore_canweaken == null ) {
				ignore_canweaken = 0;
			}
			if ( ( ( this.status_flags & 2 ) != 0 ) || ( ignore_canweaken != 0 ) ) {
				this.weakened = Misc13.max( Misc13.max( this.weakened, amount ), 0 );
				this.update_canmove();
			}
			return;
		}

		public void AdjustStunned( int amount = 0 ) {
			if ( ( this.status_flags & 1 ) != 0 ) {
				this.stunned = Misc13.max( this.stunned + amount, 0 );
				this.update_canmove();
			}
			return;
		}

		public void SetStunned( int amount = 0 ) {
			if ( ( this.status_flags & 1 ) != 0 ) {
				this.stunned = Misc13.max( amount, 0 );
				this.update_canmove();
			}
			return;
		}

		public virtual void Stun( int amount = 0 ) {
			if ( ( this.status_flags & 1 ) != 0 ) {
				this.stunned = Misc13.max( Misc13.max( this.stunned, amount ), 0 );
				this.update_canmove();
			}
			return;
		}

		public void Dizzy( int amount = 0 ) {
			this.dizziness = Misc13.max( this.dizziness, amount, 0 );
			return;
		}

		public void Jitter( int amount = 0 ) {
			this.jitteriness = Misc13.max( this.jitteriness, amount, 0 );
			return;
		}

		public virtual void activate_hand( dynamic selhand = null ) {
			return;
		}

		public virtual void swap_hand(  ) {
			return;
		}

		public virtual int IsAdvancedToolUser(  ) {
			return 0;
		}

		public virtual void fall( bool forced = false ) {
			this.drop_l_hand();
			this.drop_r_hand();
			return;
		}

		public virtual dynamic update_canmove(  ) {
			bool ko = false;
			bool buckle_lying = false;
			ko = ( this.weakened != 0 ) || ( this.paralysis != 0 ) || ( this.stat != 0 ) || ( ( this.status_flags & 8192 ) != 0 );
			buckle_lying = !( Misc13.isValid( this.buckled ) && !Misc13.isValid( this.buckled.buckle_lying ) );
			if ( ko || Misc13.isValid( this.resting ) || ( this.stunned != 0 ) ) {
				this.drop_r_hand();
				this.drop_l_hand();
			} else {
				this.lying = 0;
				this.canmove = 1;
			}
			if ( Misc13.isValid( this.buckled ) ) {
				this.lying = buckle_lying * 90;
			} else if ( ( ko || Misc13.isValid( this.resting ) ) && !Misc13.isValid( this.lying ) ) {
				this.fall( ko );
			}
			this.canmove = !( ko || Misc13.isValid( this.resting ) || ( this.stunned != 0 ) || Misc13.isValid( this.buckled ) );
			this.density = !Misc13.isValid( this.lying );
			if ( Misc13.isValid( this.lying ) ) {
				if ( this.layer == Misc13.initial( this.layer ) ) {
					this.layer = 3.799999952316284;
				}
			} else if ( this.layer == 3.799999952316284 ) {
				this.layer = Misc13.initial( this.layer );
			}
			this.update_transform();
			this.lying_prev = this.lying;
			return this.canmove;
		}

		public int canface(  ) {
			if ( !Misc13.isValid( this.canmove ) ) {
				return 0;
			}
			if ( Misc13.isValid( this.client.moving ) ) {
				return 0;
			}
			if ( Game.time < this.client.move_delay ) {
				return 0;
			}
			if ( this.stat == 2 ) {
				return 0;
			}
			if ( Misc13.isValid( this.anchored ) ) {
				return 0;
			}
			if ( this.notransform != 0 ) {
				return 0;
			}
			if ( Misc13.isValid( this.restrained() ) ) {
				return 0;
			}
			return 1;
		}

		public void add_stings_to_statpanel( dynamic stings = null ) {
			Ent_Effect_ProcHolder_Changeling S = null;
			S = null;
			foreach (dynamic _a in stings ) {
				S = _a;
				if ( !( S is Ent_Effect_ProcHolder_Changeling ) ) {
					continue;
				}
				if ( S.chemical_cost >= 0 && Misc13.isValid( S.can_be_used_by( this ) ) ) {
					Misc13.call( GlobalVars.undefined, "" + S.panel, S.chemical_cost > 0 ? "" + S.chemical_cost : "", S );
				}
			};
			return;
		}

		public void add_spells_to_statpanel( dynamic spells = null ) {
			Ent_Effect_ProcHolder_Spell S = null;
			S = null;
			foreach (dynamic _b in spells ) {
				S = _b;
				if ( !( S is Ent_Effect_ProcHolder_Spell ) ) {
					continue;
				}
				if ( Misc13.isValid( S.can_be_cast_by( this ) ) ) {
					dynamic _a = S.charge_type; // Was a switch-case, sorry for the mess.
					if ( _a=="recharge" ) {
						Misc13.call( GlobalVars.undefined, "" + S.panel, "" + S.charge_counter / 10 + "/" + S.charge_max / 10, S );
					} else if ( _a=="charges" ) {
						Misc13.call( GlobalVars.undefined, "" + S.panel, "" + S.charge_counter + "/" + S.charge_max, S );
					} else if ( _a=="holdervar" ) {
						Misc13.call( GlobalVars.undefined, "" + S.panel, "" + S.holder_var_type + " " + S.holder_var_amount, S );
					};
				}
			};
			return;
		}

		public void show_viewers( dynamic message = null ) {
			dynamic M = null;
			M = null;
			foreach (dynamic _a in Misc13.viewers( null, null ) ) {
				M = _a;
				M.see( message );
			};
			return;
		}

		public int see( dynamic message = null ) {
			if ( !Misc13.isValid( this.is_active() ) ) {
				return 0;
			}
			this.write( message );
			return 1;
		}

		public virtual dynamic is_muzzled(  ) {
			return 0;
		}

		public virtual dynamic is_active(  ) {
			return 0 >= Misc13.thread_user.stat;
		}

		public virtual int can_use_hands(  ) {
			return 0;
		}

		public virtual int stripPanelEquip( dynamic what = null, dynamic who = null ) {
			return 0;
		}

		public virtual void stripPanelUnequip( dynamic what = null, dynamic who = null ) {
			return;
		}

		public void store_memory( dynamic msg = null, dynamic popup = null, int sane = 0 ) {
			if ( sane == null ) {
				sane = 1;
			}
			msg = Misc13.str_sub( msg, 1, 1024 );
			if ( sane != 0 ) {
				msg = GlobalFuncs.sanitize( msg );
			}
			if ( this.memory.Length == 0 ) {
				this.memory += msg;
			} else {
				this.memory += "<BR>" + msg;
			}
			if ( Misc13.isValid( popup ) ) {
				this.f_memory();
			}
			return;
		}

		public virtual void start_pulling( dynamic AM = null ) {
			dynamic M = null;
			if ( !Misc13.isValid( AM ) || ( this == null ) || this == AM || !( AM.loc is Tile ) ) {
				return;
			}
			if ( !Misc13.isValid( AM.anchored ) ) {
				AM.add_fingerprint( this );
				if ( Misc13.isValid( this.pulling ) ) {
					if ( AM == this.pulling ) {
						return;
					}
					this.stop_pulling();
				}
				this.pulling = AM;
				AM.pulledby = this;
				if ( this.pullin != null ) {
					this.pullin.update_icon( this );
				}
				if ( AM is Mob ) {
					M = AM;
					if ( !( this is Mob_Living_Carbon ) ) {
						M.LAssailant = null;
					} else {
						M.LAssailant = Misc13.thread_user;
					}
				}
			}
			return;
		}

		public virtual void show_inv( dynamic user = null ) {
			return;
		}

		public virtual void reset_view( BaseDynamic A = null ) {
			if ( Misc13.isValid( this.client ) ) {
				if ( A is BaseDynamic ) {
					this.client.perspective = GlobalVars.EYE_PERSPECTIVE;
					this.client.eye = A;
				} else if ( this.loc is Tile ) {
					this.client.eye = this.client.mob;
					this.client.perspective = GlobalVars.MOB_PERSPECTIVE;
				} else {
					this.client.perspective = GlobalVars.EYE_PERSPECTIVE;
					this.client.eye = this.loc;
				}
			}
			return;
		}

		public int equip_to_appropriate_slot( Ent_Item W = null ) {
			dynamic slot = null;
			if ( !( W is Ent_Item ) ) {
				return 0;
			}
			slot = null;
			foreach (dynamic _a in GlobalVars.slot_equipment_priority ) {
				slot = _a;
				if ( Misc13.isValid( this.equip_to_slot_if_possible( W, slot, 0, 1, 1 ) ) ) {
					return 1;
				}
			};
			return 0;
		}

		public void equip_to_slot_or_del( dynamic W = null, dynamic slot = null ) {
			this.equip_to_slot_if_possible( W, slot, 1, 1, 0 );
			return;
		}

		public virtual int equip_to_slot( dynamic W = null, dynamic slot = null ) {
			return 0;
		}

		public int equip_to_slot_if_possible( dynamic W = null, dynamic slot = null, int qdel_on_fail = 0, int disable_warning = 0, int redraw_mob = 0 ) {
			if ( qdel_on_fail == null ) {
				qdel_on_fail = 0;
			}
			if ( disable_warning == null ) {
				disable_warning = 0;
			}
			if ( redraw_mob == null ) {
				redraw_mob = 1;
			}
			if ( !( W is Ent_Item ) ) {
				return 0;
			}
			if ( !Misc13.isValid( W.mob_can_equip( this, slot, disable_warning ) ) ) {
				if ( qdel_on_fail != 0 ) {
					GlobalFuncs.qdel( W );
				} else if ( disable_warning == 0 ) {
					this.write( "<span class='warning'>You are unable to equip that!</span>" );
				}
				return 0;
			}
			this.equip_to_slot( W, slot, redraw_mob );
			return 1;
		}

		public int put_in_any_hand_if_possible( dynamic W = null, int qdel_on_fail = 0, int disable_warning = 0, int redraw_mob = 0 ) {
			if ( qdel_on_fail == null ) {
				qdel_on_fail = 0;
			}
			if ( disable_warning == null ) {
				disable_warning = 1;
			}
			if ( redraw_mob == null ) {
				redraw_mob = 1;
			}
			if ( Misc13.isValid( this.equip_to_slot_if_possible( W, 4, qdel_on_fail, disable_warning, redraw_mob ) ) ) {
				return 1;
			} else if ( Misc13.isValid( this.equip_to_slot_if_possible( W, 5, qdel_on_fail, disable_warning, redraw_mob ) ) ) {
				return 1;
			}
			return 0;
		}

		public virtual int attack_ui( dynamic slot = null ) {
			Ent_Item W = null;
			Ent_Item I = null;
			W = this.get_active_hand();
			if ( W is Ent_Item ) {
				if ( Misc13.isValid( this.equip_to_slot_if_possible( W, slot, 0, 0, 0 ) ) ) {
					return 1;
				}
			}
			if ( W == null ) {
				I = this.get_item_by_slot( slot );
				if ( I is Ent_Item ) {
					I.attack_hand( this );
				}
			}
			return 0;
		}

		public virtual int incapacitated(  ) {
			return 0;
		}

		public virtual int restrained(  ) {
			return 0;
		}

		public ByTable ret_grab( Ent_Effect_ListContainer_Mobl L = null, int flag = 0 ) {
			dynamic G = null;
			ByTable temp = null;
			if ( !( this.l_hand is Ent_Item_Weapon_Grab ) && !( this.r_hand is Ent_Item_Weapon_Grab ) ) {
				if ( L == null ) {
					return null;
				} else {
					return L.container;
				}
			} else {
				if ( L == null ) {
					L = new Ent_Effect_ListContainer_Mobl( null );
					L.container += this;
					L.master = this;
				}
				if ( this.l_hand is Ent_Item_Weapon_Grab ) {
					G = this.l_hand;
					if ( !Misc13.isValid( L.container.Find( G.affecting ) ) ) {
						L.container += G.affecting;
						if ( Misc13.isValid( G.affecting ) ) {
							G.affecting.ret_grab( L, 1 );
						}
					}
				}
				if ( this.r_hand is Ent_Item_Weapon_Grab ) {
					G = this.r_hand;
					if ( !Misc13.isValid( L.container.Find( G.affecting ) ) ) {
						L.container += G.affecting;
						if ( Misc13.isValid( G.affecting ) ) {
							G.affecting.ret_grab( L, 1 );
						}
					}
				}
				if ( flag == 0 ) {
					if ( L.master == this ) {
						temp = new ByTable();
						temp += L.container;
						GlobalFuncs.qdel( L );
						return temp;
					} else {
						return L.container;
					}
				}
			}
			return null;
		}

		public virtual dynamic get_item_by_slot( int slot_id = 0 ) {
			dynamic _a = slot_id; // Was a switch-case, sorry for the mess.
			if ( _a==4 ) {
				return this.l_hand;
			} else if ( _a==5 ) {
				return this.r_hand;
			};
			return null;
		}

		public virtual int Life(  ) {
			return 0;
		}

		public virtual int movement_delay(  ) {
			return 0;
		}

		public void show_message( string msg = "", int type = 0, string alt = "", int alt_type = 0 ) {
			if ( !Misc13.isValid( this.client ) ) {
				return;
			}
			msg = Misc13.str_sub( msg, 1, 1024 );
			if ( type != 0 ) {
				if ( ( ( type & 1 ) != 0 ) && ( Misc13.isValid( ( this.disabilities & 1 ) ) || ( this.paralysis != 0 ) ) ) {
					if ( !Misc13.isValid( alt ) ) {
						return;
					} else {
						msg = alt;
						type = alt_type;
					}
				}
				if ( ( ( type & 2 ) != 0 ) && ( this.ear_deaf != 0 ) ) {
					if ( !Misc13.isValid( alt ) ) {
						return;
					} else {
						msg = alt;
						type = alt_type;
						if ( ( ( type & 1 ) != 0 ) && Misc13.isValid( ( this.disabilities & 1 ) ) ) {
							return;
						}
					}
				}
			}
			if ( this.stat == 1 || this.sleeping > 0 ) {
				this.write( "<I>... You can almost hear someone talking ...</I>" );
			} else {
				this.write( msg );
			}
			return;
		}

		public int Cell(  ) {
			dynamic environment = null;
			string t = "";
			Gas trace_gas = null;
			if ( !Misc13.isValid( this.loc ) ) {
				return 0;
			}
			environment = this.loc.return_air();
			t = "<span class='notice'>Coordinates: " + this.x + "," + this.y + " \n</span>";
			t += "<span class='danger'>Temperature: " + environment.temperature + " \n</span>";
			t += "<span class='notice'>Nitrogen: " + environment.nitrogen + " \n</span>";
			t += "<span class='notice'>Oxygen: " + environment.oxygen + " \n</span>";
			t += "<span class='notice'>Plasma : " + environment.toxins + " \n</span>";
			t += "<span class='notice'>Carbon Dioxide: " + environment.carbon_dioxide + " \n</span>";
			trace_gas = null;
			foreach (dynamic _a in environment.trace_gases ) {
				trace_gas = _a;
				if ( !( trace_gas is Gas ) ) {
					continue;
				}
				t += "<span class='notice'>" + trace_gas.type + ": " + trace_gas.moles + " \n</span>";
			};
			Misc13.thread_user.show_message( t, 1 );
			return 0;
		}

		public void sac_act( dynamic R = null, dynamic victim = null ) {
			return;
		}

		public virtual void update_normal_mode(  ) {
			Misc13.window_set( this, null, "mainwindow.macro=macro hotkey_toggle.is-checked=false input.focus=true input.background-color=#D3B5B5" );
			return;
		}

		public virtual void update_hotkey_mode(  ) {
			Misc13.window_set( this, null, "mainwindow.macro=hotkeymode hotkey_toggle.is-checked=true mapwindow.map.focus=true input.background-color=#F0F0F0" );
			return;
		}

		public void update_interface(  ) {
			if ( Misc13.isValid( this.client ) ) {
				if ( Misc13.window_get( this, "mainwindow.hotkey_toggle", "is-checked" ) == "true" ) {
					this.update_hotkey_mode();
				} else {
					this.update_normal_mode();
				}
			}
			return;
		}

		public void update_Login_details(  ) {
			dynamic M = null;
			string matches = "";
			this.lastKnownIP = this.client.address;
			this.computer_id = this.client.computer_id;
			GlobalFuncs.log_access( "Login: " + GlobalFuncs.key_name( this ) + " from " + ( Misc13.isValid( this.lastKnownIP ) ? this.lastKnownIP : "localhost" ) + "-" + this.computer_id + " || BYOND v" + this.client.byond_version );
			if ( Misc13.isValid( GlobalVars.config.log_access ) ) {
				M = null;
				foreach (dynamic _a in GlobalVars.player_list ) {
					M = _a;
					if ( M == this ) {
						continue;
					}
					if ( Misc13.isValid( M.key ) && M.key != this.key ) {
						matches = null;
						if ( M.lastKnownIP == this.client.address ) {
							matches += "IP (" + this.client.address + ")";
						}
						if ( M.computer_id == this.client.computer_id ) {
							if ( Misc13.isValid( matches ) ) {
								matches += " and ";
							}
							matches += "ID (" + this.client.computer_id + ")";
							Thread13.schedule( 0, (Thread13.Closure)(() => {
								Misc13.alert( "You have logged in already with another key this round, please log out of this one NOW or risk being banned!", null, null, null, null, null );
								return;
							}));
						}
						if ( Misc13.isValid( matches ) ) {
							if ( Misc13.isValid( M.client ) ) {
								GlobalFuncs.message_admins( "<font color='red'><B>Notice: </B><font color='blue'>" + GlobalFuncs.key_name_admin( this ) + " has the same " + matches + " as " + GlobalFuncs.key_name_admin( M ) + ".</font>" );
								GlobalFuncs.log_access( "Notice: " + GlobalFuncs.key_name( this ) + " has the same " + matches + " as " + GlobalFuncs.key_name( M ) + "." );
							} else {
								GlobalFuncs.message_admins( "<font color='red'><B>Notice: </B><font color='blue'>" + GlobalFuncs.key_name_admin( this ) + " has the same " + matches + " as " + GlobalFuncs.key_name_admin( M ) + " (no longer logged in). </font>" );
								GlobalFuncs.log_access( "Notice: " + GlobalFuncs.key_name( this ) + " has the same " + matches + " as " + GlobalFuncs.key_name( M ) + " (no longer logged in)." );
							}
						}
					}
				};
			}
			return;
		}

		public ByTable get_equipped_items(  ) {
			ByTable items = null;
			items = new ByTable();
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "back" ) ) ) {
				if ( Misc13.isValid( this.back ) ) {
					items += this.back;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "belt" ) ) ) {
				if ( Misc13.isValid( this.belt ) ) {
					items += this.belt;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "ears" ) ) ) {
				if ( Misc13.isValid( this.ears ) ) {
					items += this.ears;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "glasses" ) ) ) {
				if ( Misc13.isValid( this.glasses ) ) {
					items += this.glasses;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "gloves" ) ) ) {
				if ( Misc13.isValid( this.gloves ) ) {
					items += this.gloves;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "head" ) ) ) {
				if ( Misc13.isValid( this.head ) ) {
					items += this.head;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "shoes" ) ) ) {
				if ( Misc13.isValid( this.shoes ) ) {
					items += this.shoes;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "wear_id" ) ) ) {
				if ( Misc13.isValid( this.wear_id ) ) {
					items += this.wear_id;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "wear_mask" ) ) ) {
				if ( Misc13.isValid( this.wear_mask ) ) {
					items += this.wear_mask;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "wear_suit" ) ) ) {
				if ( Misc13.isValid( this.wear_suit ) ) {
					items += this.wear_suit;
				}
			}
			if ( Misc13.isValid( GlobalFuncs.hasvar( this, "w_uniform" ) ) ) {
				if ( Misc13.isValid( this.w_uniform ) ) {
					items += this.w_uniform;
				}
			}
			return items;
		}

		public int remove_from_mob( dynamic O = null ) {
			this.unEquip( O );
			O.screen_loc = null;
			return 1;
		}

		public virtual int unEquip( dynamic I = null, int force = 0 ) {
			if ( !Misc13.isValid( I ) ) {
				return 1;
			}
			if ( Misc13.isValid( ( I.flags & 2 ) ) && ( force == 0 ) ) {
				return 0;
			}
			if ( I == this.r_hand ) {
				this.r_hand = null;
				this.update_inv_r_hand();
			} else if ( I == this.l_hand ) {
				this.l_hand = null;
				this.update_inv_l_hand();
			}
			if ( Misc13.isValid( I ) ) {
				if ( Misc13.isValid( this.client ) ) {
					this.client.screen -= I;
				}
				I.loc = this.loc;
				I.dropped( this );
				if ( Misc13.isValid( I ) ) {
					I.layer = Misc13.initial( I.layer );
				}
			}
			return 1;
		}

		public int canUnEquip( dynamic I = null, dynamic force = null ) {
			if ( !Misc13.isValid( I ) ) {
				return 1;
			}
			if ( Misc13.isValid( ( I.flags & 2 ) ) && !Misc13.isValid( force ) ) {
				return 0;
			}
			return 1;
		}

		public virtual dynamic drop_item(  ) {
			if ( Misc13.isValid( this.hand ) ) {
				return this.drop_l_hand();
			} else {
				return this.drop_r_hand();
			}
			return null;
		}

		public dynamic drop_r_hand(  ) {
			if ( !Misc13.isValid( this.loc.allow_drop() ) ) {
				return null;
			}
			return this.unEquip( this.r_hand );
		}

		public dynamic drop_l_hand(  ) {
			if ( !Misc13.isValid( this.loc.allow_drop() ) ) {
				return null;
			}
			return this.unEquip( this.l_hand );
		}

		public int drop_item_v(  ) {
			if ( this.stat == 0 && this.loc is Tile ) {
				return this.drop_item();
			}
			return 0;
		}

		public int put_in_hands( dynamic W = null ) {
			if ( !Misc13.isValid( W ) ) {
				return 0;
			}
			if ( Misc13.isValid( this.put_in_active_hand( W ) ) ) {
				return 1;
			} else if ( Misc13.isValid( this.put_in_inactive_hand( W ) ) ) {
				return 1;
			} else {
				W.loc = GlobalFuncs.get_turf( this );
				W.layer = Misc13.initial( W.layer );
				W.dropped( this );
				return 0;
			}
			return 0;
		}

		public dynamic put_in_inactive_hand( dynamic W = null ) {
			if ( Misc13.isValid( this.hand ) ) {
				return this.put_in_r_hand( W );
			} else {
				return this.put_in_l_hand( W );
			}
			return null;
		}

		public dynamic put_in_active_hand( dynamic W = null ) {
			if ( Misc13.isValid( this.hand ) ) {
				return this.put_in_l_hand( W );
			} else {
				return this.put_in_r_hand( W );
			}
			return null;
		}

		public virtual int put_in_hand_check( dynamic W = null ) {
			if ( Misc13.isValid( this.lying ) && !Misc13.isValid( W.flags & 128 ) ) {
				return 0;
			}
			if ( !( W is Ent_Item ) ) {
				return 0;
			}
			return 1;
		}

		public int put_in_r_hand( dynamic W = null ) {
			if ( !Misc13.isValid( this.put_in_hand_check( W ) ) ) {
				return 0;
			}
			if ( !Misc13.isValid( this.r_hand ) ) {
				W.loc = this;
				this.r_hand = W;
				W.layer = 20;
				W.equipped( this, 5 );
				if ( Misc13.isValid( this.client ) ) {
					this.client.screen |= W;
				}
				if ( this.pulling == W ) {
					this.stop_pulling();
				}
				this.update_inv_r_hand();
				W.pixel_x = Misc13.initial( W.pixel_x );
				W.pixel_y = Misc13.initial( W.pixel_y );
				return 1;
			}
			return 0;
		}

		public int put_in_l_hand( dynamic W = null ) {
			if ( !Misc13.isValid( this.put_in_hand_check( W ) ) ) {
				return 0;
			}
			if ( !Misc13.isValid( this.l_hand ) ) {
				W.loc = this;
				this.l_hand = W;
				W.layer = 20;
				W.equipped( this, 4 );
				if ( Misc13.isValid( this.client ) ) {
					this.client.screen |= W;
				}
				if ( this.pulling == W ) {
					this.stop_pulling();
				}
				this.update_inv_l_hand();
				W.pixel_x = Misc13.initial( W.pixel_x );
				W.pixel_y = Misc13.initial( W.pixel_y );
				return 1;
			}
			return 0;
		}

		public virtual int can_equip( Ent_Item I = null, dynamic slot = null, int disable_warning = 0 ) {
			if ( disable_warning == null ) {
				disable_warning = 0;
			}
			return 0;
		}

		public dynamic get_inactive_hand(  ) {
			if ( Misc13.isValid( this.hand ) ) {
				return this.r_hand;
			} else {
				return this.l_hand;
			}
			return null;
		}

		public virtual dynamic get_active_hand(  ) {
			if ( Misc13.isValid( this.hand ) ) {
				return this.l_hand;
			} else {
				return this.r_hand;
			}
			return null;
		}

		public virtual int death( int gibbed = 0 ) {
			return 0;
		}

		public virtual void dust(  ) {
			return;
		}

		public virtual dynamic gib(  ) {
			return null;
		}

		public virtual void on_forcemove( dynamic newloc = null ) {
			return;
		}

		public void set_machine( dynamic O = null ) {
			if ( Misc13.isValid( this.machine ) ) {
				this.unset_machine();
			}
			this.machine = O;
			if ( O is Entity ) {
				O.in_use = 1;
			}
			return;
		}

		public void unset_machine(  ) {
			this.machine = null;
			return;
		}

		public void clearmap(  ) {
			Ent_Screen O = null;
			this.client.screen -= this.mapobjs;
			O = null;
			foreach (dynamic _a in this.mapobjs ) {
				O = _a;
				if ( !( O is Ent_Screen ) ) {
					continue;
				}
				GlobalFuncs.qdel( O );
			};
			this.mapobjs = null;
			this.unset_machine();
			return;
		}

		public virtual int canUseTopic(  ) {
			return 0;
		}

		public int casting(  ) {
			if ( !( Misc13.thread_user.wear_suit is Ent_Item_Clothing_Suit_Wizrobe ) ) {
				Misc13.thread_user.write( "I don't feel strong enough without my robe." );
				return 0;
			}
			if ( !( Misc13.thread_user.shoes is Ent_Item_Clothing_Shoes_Sandal ) ) {
				Misc13.thread_user.write( "I don't feel strong enough without my sandals." );
				return 0;
			}
			if ( !( Misc13.thread_user.head is Ent_Item_Clothing_Head_Wizard ) ) {
				Misc13.thread_user.write( "I don't feel strong enough without my hat." );
				return 0;
			} else {
				return 1;
			}
			return 0;
		}

		public void spellremove( dynamic M = null ) {
			Ent_Effect_ProcHolder_Spell spell_to_remove = null;
			if ( this.mind == null ) {
				return;
			}
			spell_to_remove = null;
			foreach (dynamic _a in this.mind.spell_list ) {
				spell_to_remove = _a;
				if ( !( spell_to_remove is Ent_Effect_ProcHolder_Spell ) ) {
					continue;
				}
				GlobalFuncs.qdel( spell_to_remove );
				this.mind.spell_list -= spell_to_remove;
			};
			return;
		}

		public void sandbox_panel(  ) {
			if ( this.sandbox != null ) {
				this.sandbox.update();
			}
			return;
		}

		public void CanBuild(  ) {
			if ( GlobalVars.master_mode == "sandbox" ) {
				this.sandbox = new HSB();
				this.sandbox.owner = this.ckey;
				if ( Misc13.isValid( this.client.holder ) ) {
					this.sandbox.admin = 1;
				}
				this.verbs += typeof(Mob).GetMethod( "sandbox_panel" );
			}
			return;
		}

		public int null_rod_check(  ) {
			dynamic N = null;
			N = Misc13.get_in( typeof(Ent_Item_Weapon_Nullrod), this );
			if ( Misc13.isValid( N ) ) {
				return 1;
			}
			return 0;
		}

		public void cult_add_comm(  ) {
			this.verbs += typeof(Mob_Living).GetMethod( "cult_innate_comm" );
			return;
		}

		public void remove_changeling_powers( int keep_free_powers = 0 ) {
			Ent_Effect_ProcHolder_Changeling p = null;
			if ( keep_free_powers == null ) {
				keep_free_powers = 0;
			}
			if ( this is Mob_Living_Carbon_Human || this is Mob_Living_Carbon_Monkey ) {
				if ( ( this.mind != null ) && ( this.mind.changeling != null ) ) {
					this.mind.changeling.changeling_speak = 0;
					this.mind.changeling.reset();
					p = null;
					foreach (dynamic _a in this.mind.changeling.purchasedpowers ) {
						p = _a;
						if ( !( p is Ent_Effect_ProcHolder_Changeling ) ) {
							continue;
						}
						if ( p.dna_cost == 0 && ( keep_free_powers != 0 ) ) {
							continue;
						}
						this.mind.changeling.purchasedpowers -= p;
						p.on_refund( this );
					};
				}
				if ( this.hud_used != null ) {
					this.hud_used.lingstingdisplay.icon_state = null;
					this.hud_used.lingstingdisplay.invisibility = 101;
				}
			}
			return;
		}

		public int make_changeling(  ) {
			dynamic path = null;
			dynamic S = null;
			dynamic C = null;
			dynamic prof = null;
			if ( this.mind == null ) {
				return 0;
			}
			if ( !( this is Mob_Living_Carbon_Human ) && !( this is Mob_Living_Carbon_Monkey ) ) {
				return 0;
			}
			if ( this.mind.changeling == null ) {
				this.mind.changeling = new Changeling( this.gender );
			}
			if ( !Misc13.isValid( GlobalVars.sting_paths ) ) {
				GlobalVars.sting_paths = GlobalFuncs.init_paths( typeof(Ent_Effect_ProcHolder_Changeling) );
			}
			if ( Misc13.isValid( this.mind.changeling.purchasedpowers ) ) {
				this.remove_changeling_powers( 1 );
			}
			path = null;
			foreach (dynamic _a in GlobalVars.sting_paths ) {
				path = _a;
				S = Misc13.call( path );
				if ( !Misc13.isValid( S.dna_cost ) ) {
					if ( !Misc13.isValid( this.mind.changeling.has_sting( S ) ) ) {
						this.mind.changeling.purchasedpowers += S;
					}
					S.on_purchase( this );
				}
			};
			C = this;
			if ( C is Mob_Living_Carbon_Human ) {
				prof = this.mind.changeling.add_profile( C );
				this.mind.changeling.first_prof = prof;
			}
			return 1;
		}

		public void stopLobbySound(  ) {
			this.write( new ByTable().set( "channel", 1 ).set( "volume", 85 ).set( "wait", 0 ).set( "repeat", 0 ).set( 1, null ).applyCtor( typeof(Sound) ) );
			return;
		}

		public virtual void domutcheck(  ) {
			return;
		}

		public virtual Dna has_dna(  ) {
			return null;
		}

		public virtual void set_species( dynamic mrace = null, int icon_update = 0 ) {
			if ( icon_update == null ) {
				icon_update = 1;
			}
			return;
		}

		public int ForceContractDisease( dynamic D = null ) {
			if ( !Misc13.isValid( this.CanContractDisease( D ) ) ) {
				return 0;
			}
			this.AddDisease( D );
			return 0;
		}

		public void AddDisease( dynamic D = null ) {
			dynamic DD = null;
			ByTable skipped = null;
			dynamic V = null;
			dynamic L = null;
			DD = D.type( 1, D, 0 );
			this.viruses += DD;
			DD.affected_mob = this;
			DD.holder = this;
			skipped = new ByTable(new object [] { "affected_mob", "holder", "carrier", "stage", "type", "parent_type", "vars", "transformed" });
			V = null;
			foreach (dynamic _a in DD.vars ) {
				V = _a;
				if ( skipped.contains( V ) ) {
					continue;
				}
				if ( DD.vars[V] is ByTable ) {
					L = D.vars[V];
					DD.vars[V] = L.Copy();
				} else {
					DD.vars[V] = D.vars[V];
				}
			};
			DD.affected_mob.med_hud_set_status();
			return;
		}

		public virtual int ContractDisease( dynamic D = null ) {
			if ( !Misc13.isValid( this.CanContractDisease( D ) ) ) {
				return 0;
			}
			this.AddDisease( D );
			return 0;
		}

		public virtual int CanContractDisease( dynamic D = null ) {
			if ( this.stat == 2 ) {
				return 0;
			}
			if ( this.resistances.contains( D.GetDiseaseID() ) ) {
				return 0;
			}
			if ( Misc13.isValid( this.HasDisease( D ) ) ) {
				return 0;
			}
			if ( !D.viable_mobtypes.contains( this.type ) ) {
				return 0;
			}
			if ( GlobalFuncs.count_by_type( this.viruses, typeof(Disease_Advance) ) >= 3 ) {
				return 0;
			}
			return 1;
		}

		public int HasDisease( dynamic D = null ) {
			Disease DD = null;
			DD = null;
			foreach (dynamic _a in this.viruses ) {
				DD = _a;
				if ( !( DD is Disease ) ) {
					continue;
				}
				if ( Misc13.isValid( D.IsSame( DD ) ) ) {
					return 1;
				}
			};
			return 0;
		}

		public virtual void mind_initialize(  ) {
			if ( this.mind != null ) {
				this.mind.key = this.key;
			} else {
				this.mind = new Mind( this.key );
				if ( GlobalVars.ticker != null ) {
					GlobalVars.ticker.minds += this.mind;
				} else {
					Thread13.schedule( 0, (Thread13.Closure)(() => {
						throw new Exception( "mind_initialize(): No ticker ready", "code/datums/mind.dm", 1496 );
						return;
					}));
				}
			}
			if ( !Misc13.isValid( this.mind.name ) ) {
				this.mind.name = this.real_name;
			}
			this.mind.current = this;
			return;
		}

		public void sync_mind(  ) {
			this.mind_initialize();
			this.mind.active = 1;
			return;
		}

		public void reload_huds(  ) {
			ByTable gang_huds = null;
			Gang G = null;
			AtomHud hud = null;
			gang_huds = new ByTable();
			if ( Misc13.isValid( GlobalVars.ticker.mode ) ) {
				G = null;
				foreach (dynamic _a in GlobalVars.ticker.mode.gangs ) {
					G = _a;
					if ( !( G is Gang ) ) {
						continue;
					}
					gang_huds += G.ganghud;
				};
			}
			hud = null;
			foreach (dynamic _b in GlobalVars.huds | gang_huds ) {
				hud = _b;
				if ( !( hud is AtomHud ) ) {
					continue;
				}
				if ( hud.hudusers.contains( this ) ) {
					hud.add_hud_to( this );
				}
			};
			return;
		}

		public void browse_rsc_icon( dynamic icon = null, dynamic icon_state = null, int dir = 0 ) {
			if ( dir == null ) {
				dir = -1;
			}
			return;
		}

		public int clear_alert( string category = "" ) {
			dynamic alert = null;
			alert = this.alerts[category];
			if ( !Misc13.isValid( alert ) ) {
				return 0;
			}
			this.alerts -= category;
			if ( Misc13.isValid( this.client ) && ( this.hud_used != null ) ) {
				this.hud_used.reorganize_alerts();
				this.client.screen -= alert;
			}
			GlobalFuncs.qdel( alert );
			return 0;
		}

		public dynamic throw_alert( string category = "", Type type = null, int severity = 0, dynamic new_master = null ) {
			dynamic alert = null;
			dynamic old_layer = null;
			if ( !Misc13.isValid( category ) ) {
				return null;
			}
			if ( Misc13.isValid( this.alerts[category] ) ) {
				alert = this.alerts[category];
				if ( Misc13.isValid( new_master ) && new_master != alert.master ) {
					GlobalFuncs.warning( "" + ( "" + this + " threw alert " + category + " with new_master " + new_master + " while already having that alert with master " + alert.master ) + " in " + "code/_onclick/hud/alert.dm" + " at line " + 27 + " src: " + this + " usr: " + Misc13.thread_user + "." );
					this.clear_alert( category );
					return undefined._BROKEN_INDEX_();
				} else if ( alert.type == type && ( ( severity == 0 ) || severity == alert.severity ) ) {
					if ( Misc13.isValid( alert.timeout ) ) {
						this.clear_alert( category );
						return undefined._BROKEN_INDEX_();
					} else {
						return 0;
					}
				}
			} else {
				alert = GlobalFuncs.PoolOrNew( type );
			}
			if ( Misc13.isValid( new_master ) ) {
				old_layer = new_master.layer;
				new_master.layer = GlobalVars.FLOAT_LAYER;
				alert.overlays += new_master;
				new_master.layer = old_layer;
				alert.icon_state = "template";
				alert.master = new_master;
			} else {
				alert.icon_state = "" + Misc13.initial( alert.icon_state ) + severity;
				alert.severity = severity;
			}
			this.alerts[category] = alert;
			if ( Misc13.isValid( this.client ) && ( this.hud_used != null ) ) {
				this.hud_used.reorganize_alerts();
			}
			alert.transform = new Matrix( 32, 6, 7 );
			Misc13.animate_listcall( new ByTable().set( "easing", 3 ).set( "time", 2.5 ).set( "transform", new Matrix() ).set( 1, alert ) );
			if ( Misc13.isValid( alert.timeout ) ) {
				Thread13.schedule( alert.timeout, (Thread13.Closure)(() => {
					if ( Misc13.isValid( alert.timeout ) && this.alerts[category] == alert && Game.time >= alert.timeout ) {
						this.clear_alert( category );
					}
					return;
				}));
				alert.timeout = Game.time + alert.timeout - Game.tick_lag;
			}
			return alert;
		}

		public virtual void update_action_buttons(  ) {
			return;
		}

		public virtual void face_atom( dynamic A = null ) {
			dynamic dx = null;
			dynamic dy = null;
			if ( Misc13.isValid( this.buckled ) || this.stat != 0 || !Misc13.isValid( A ) || !Misc13.isValid( this.x ) || !Misc13.isValid( this.y ) || !Misc13.isValid( A.x ) || !Misc13.isValid( A.y ) ) {
				return;
			}
			dx = A.x - this.x;
			dy = A.y - this.y;
			if ( !Misc13.isValid( dx ) && !Misc13.isValid( dy ) ) {
				if ( A.pixel_y > 16 ) {
					this.dir = GlobalVars.NORTH;
				} else if ( A.pixel_y < -16 ) {
					this.dir = GlobalVars.SOUTH;
				} else if ( A.pixel_x > 16 ) {
					this.dir = GlobalVars.EAST;
				} else if ( A.pixel_x < -16 ) {
					this.dir = GlobalVars.WEST;
				}
				return;
			}
			if ( Math.Abs( dx ) < Math.Abs( dy ) ) {
				if ( dy > 0 ) {
					this.dir = GlobalVars.NORTH;
				} else {
					this.dir = GlobalVars.SOUTH;
				}
			} else if ( dx > 0 ) {
				this.dir = GlobalVars.EAST;
			} else {
				this.dir = GlobalVars.WEST;
			}
			return;
		}

		public virtual void LaserEyes( dynamic A = null ) {
			return;
		}

		public virtual void CtrlShiftClickOn( dynamic A = null ) {
			A.CtrlShiftClick( this );
			return;
		}

		public virtual bool TurfAdjacent( dynamic T = null ) {
			return T.Adjacent( this );
		}

		public virtual void AltClickOn( dynamic A = null ) {
			A.AltClick( this );
			return;
		}

		public virtual void CtrlClickOn( dynamic A = null ) {
			A.CtrlClick( this );
			return;
		}

		public virtual void ShiftClickOn( dynamic A = null ) {
			A.ShiftClick( this );
			return;
		}

		public virtual void MiddleClickOn( dynamic A = null ) {
			return;
		}

		public virtual int RestrainedClickOn( dynamic A = null ) {
			return 0;
		}

		public virtual void RangedAttack( dynamic A = null, dynamic _params = null ) {
			return;
		}

		public virtual void UnarmedAttack( dynamic A = null, int proximity_flag = 0 ) {
			if ( A is Mob ) {
				this.changeNext_move( 8 );
			}
			return;
		}

		public virtual void DblClickOn( dynamic A = null, dynamic _params = null ) {
			return;
		}

		public virtual dynamic ClickOn( dynamic A = null, dynamic _params = null ) {
			dynamic modifiers = null;
			dynamic M = null;
			dynamic W = null;
			dynamic resolved = null;
			if ( Game.time <= this.next_click ) {
				return null;
			}
			this.next_click = Game.time + 1;
			if ( Misc13.isValid( this.client.buildmode ) ) {
				GlobalFuncs.build_click( this, this.client.buildmode, _params, A );
				return null;
			}
			modifiers = Misc13.conv_urlParams2list( _params );
			if ( Misc13.isValid( modifiers["shift"] ) && Misc13.isValid( modifiers["ctrl"] ) ) {
				this.CtrlShiftClickOn( A );
				return null;
			}
			if ( Misc13.isValid( modifiers["middle"] ) ) {
				this.MiddleClickOn( A );
				return null;
			}
			if ( Misc13.isValid( modifiers["shift"] ) ) {
				this.ShiftClickOn( A );
				return null;
			}
			if ( Misc13.isValid( modifiers["alt"] ) ) {
				this.AltClickOn( A );
				return null;
			}
			if ( Misc13.isValid( modifiers["ctrl"] ) ) {
				this.CtrlClickOn( A );
				return null;
			}
			if ( ( this.stat != 0 ) || ( this.paralysis != 0 ) || ( this.stunned != 0 ) || ( this.weakened != 0 ) ) {
				return null;
			}
			this.face_atom( A );
			if ( this.next_move > Game.time ) {
				return null;
			}
			if ( this.loc is Ent_Mecha ) {
				M = this.loc;
				return M.click_action( A, this );
			}
			if ( Misc13.isValid( this.restrained() ) ) {
				this.changeNext_move( 10 );
				this.RestrainedClickOn( A );
				return null;
			}
			if ( this.in_throw_mode != 0 ) {
				this.throw_item( A );
				return null;
			}
			W = this.get_active_hand();
			if ( W == A ) {
				W.attack_self( this );
				if ( Misc13.isValid( this.hand ) ) {
					this.update_inv_l_hand( 0 );
				} else {
					this.update_inv_r_hand( 0 );
				}
				return null;
			}
			if ( !( A is Tile ) && A == this.loc || this.contents.contains( A ) || this.contents.contains( A.loc ) || Misc13.isValid( A.loc ) && this.contents.contains( A.loc.loc ) ) {
				if ( Misc13.isValid( W ) ) {
					resolved = A.attackby( W, this );
					if ( !Misc13.isValid( resolved ) && Misc13.isValid( A ) && Misc13.isValid( W ) ) {
						W.afterattack( A, this, 1, _params );
					}
				} else {
					if ( A is Mob ) {
						this.changeNext_move( 8 );
					}
					this.UnarmedAttack( A );
				}
				return null;
			}
			if ( !( this.loc is Tile ) ) {
				return null;
			}
			if ( A is Tile || A.loc is Tile || Misc13.isValid( A.loc ) && A.loc.loc is Tile ) {
				if ( Misc13.isValid( A.Adjacent( this ) ) ) {
					if ( Misc13.isValid( W ) ) {
						resolved = A.attackby( W, this, _params );
						if ( !Misc13.isValid( resolved ) && Misc13.isValid( A ) && Misc13.isValid( W ) ) {
							W.afterattack( A, this, 1, _params );
						}
					} else {
						if ( A is Mob ) {
							this.changeNext_move( 8 );
						}
						this.UnarmedAttack( A, 1 );
					}
					return null;
				} else if ( Misc13.isValid( W ) ) {
					W.afterattack( A, this, 0, _params );
				} else {
					this.RangedAttack( A, _params );
				}
			}
			return null;
		}

		public void changeNext_move( int num = 0 ) {
			this.next_move = Game.time + ( num + this.next_move_adjust ) * this.next_move_modifier;
			return;
		}

		public void rename_self( string role = "", int allow_numbers = 0 ) {
			dynamic oldname = null;
			dynamic newname = null;
			int loop = 0;
			int safety = 0;
			Mob_Living M = null;
			Mob A = null;
			if ( allow_numbers == null ) {
				allow_numbers = 0;
			}
			oldname = this.real_name;
			loop = 1;
			safety = 0;
			while (( loop != 0 ) && safety < 5) {
				if ( Misc13.isValid( this.client ) && Misc13.isValid( this.client.prefs.custom_names[role] ) && ( safety == 0 ) ) {
					newname = this.client.prefs.custom_names[role];
				} else {
					dynamic _a = role; // Was a switch-case, sorry for the mess.
					if ( _a=="clown" ) {
						newname = Rand13.pick( GlobalVars.clown_names );
					} else if ( _a=="mime" ) {
						newname = Rand13.pick( GlobalVars.mime_names );
					} else if ( _a=="ai" ) {
						newname = Rand13.pick( GlobalVars.ai_names );
					} else {
						return;
					};
				}
				M = null;
				foreach (dynamic _b in GlobalVars.player_list ) {
					M = _b;
					if ( !( M is Mob_Living ) ) {
						continue;
					}
					if ( M == this ) {
						continue;
					}
					if ( !Misc13.isValid( newname ) || M.real_name == newname ) {
						newname = null;
						loop++;
						break;
					}
				};
				loop--;
				safety++;
			}
			if ( this is Mob_Living_Silicon_Ai ) {
				oldname = null;
			}
			if ( Misc13.isValid( newname ) ) {
				this.fully_replace_character_name( oldname, newname );
				if ( this is Mob_Living_Silicon_Robot ) {
					A = this;
					A.custom_name = newname;
				}
			}
			return;
		}

		public int fully_replace_character_name( dynamic oldname = null, dynamic newname = null ) {
			Mob C = null;
			Mob AI = null;
			Mob_Living_Silicon_Robot Slave = null;
			Mob R = null;
			ByTable L = null;
			dynamic searching = null;
			int search_id = 0;
			int search_pda = 0;
			dynamic A = null;
			dynamic ID = null;
			dynamic PDA = null;
			Mind T = null;
			Objective obj = null;
			if ( !Misc13.isValid( newname ) ) {
				return 0;
			}
			this.real_name = newname;
			this.name = newname;
			if ( this.mind != null ) {
				this.mind.name = newname;
			}
			if ( this is Mob_Living_Carbon ) {
				C = this;
				if ( Misc13.isValid( C.dna ) ) {
					C.dna.real_name = this.real_name;
				}
			}
			if ( this is Mob_Living_Silicon_Ai ) {
				AI = this;
				if ( oldname != this.real_name ) {
					if ( Misc13.isValid( AI.eyeobj ) ) {
						AI.eyeobj.name = "" + newname + " (AI Eye)";
					}
					if ( Misc13.isValid( AI.aiPDA ) ) {
						AI.aiPDA.owner = newname;
						AI.aiPDA.name = newname + " (" + AI.aiPDA.ownjob + ")";
					}
					Slave = null;
					foreach (dynamic _a in AI.connected_robots ) {
						Slave = _a;
						if ( !( Slave is Mob_Living_Silicon_Robot ) ) {
							continue;
						}
						Slave.show_laws();
					};
				}
			}
			if ( this is Mob_Living_Silicon_Robot ) {
				R = this;
				if ( oldname != this.real_name ) {
					R.notify_ai( 3, oldname, newname );
				}
				if ( Misc13.isValid( R.camera ) ) {
					R.camera.c_tag = this.real_name;
				}
			}
			if ( Misc13.isValid( oldname ) ) {
				L = null;
				foreach (dynamic _b in new ByTable(new object [] { GlobalVars.data_core.general, GlobalVars.data_core.medical, GlobalVars.data_core.security, GlobalVars.data_core.locked }) ) {
					L = _b;
					if ( !( L is ByTable ) ) {
						continue;
					}
					R = GlobalFuncs.find_record( "name", oldname, L );
					if ( Misc13.isValid( R ) ) {
						R.fields["name"] = newname;
					}
				};
				searching = this.GetAllContents();
				search_id = 1;
				search_pda = 1;
				A = null;
				foreach (dynamic _c in searching ) {
					A = _c;
					if ( ( search_id != 0 ) && A is Ent_Item_Weapon_Card_Id ) {
						ID = A;
						if ( ID.registered_name == oldname ) {
							ID.registered_name = newname;
							ID.update_label();
							if ( search_pda == 0 ) {
								break;
							}
							search_id = 0;
						}
					} else if ( ( search_pda != 0 ) && A is Ent_Item_Device_Pda ) {
						PDA = A;
						if ( PDA.owner == oldname ) {
							PDA.owner = newname;
							PDA.update_label();
							if ( search_id == 0 ) {
								break;
							}
							search_pda = 0;
						}
					}
				};
				T = null;
				foreach (dynamic _e in GlobalVars.ticker.minds ) {
					T = _e;
					if ( !( T is Mind ) ) {
						continue;
					}
					obj = null;
					foreach (dynamic _d in T.objectives ) {
						obj = _d;
						if ( !( obj is Objective ) ) {
							continue;
						}
						if ( Misc13.isValid( obj.target ) && Misc13.isValid( obj.target.current ) && obj.target.current.real_name == this.name ) {
							obj.update_explanation_text();
						}
					};
				};
			}
			return 1;
		}

		public void AddCamoOverlay( dynamic A = null ) {
			Icon opacity_icon = null;
			dynamic alpha_mask = null;
			int i = 0;
			dynamic I = null;
			opacity_icon = new Icon( A.icon, A.icon_state );
			alpha_mask = GlobalFuncs.getIconMask( this );
			opacity_icon.AddAlphaMask( alpha_mask );
			opacity_icon.ChangeOpacity( 0.4000000059604645 );
			i = 0;
			i = 0;
			while (i < 5) {
				I = new ByTable().set( "layer", this.layer + 0.800000011920929 ).set( "icon_state", A.icon_state ).set( "icon", opacity_icon ).applyCtor( typeof(Image) );
				dynamic _a = i; // Was a switch-case, sorry for the mess.
				if ( _a==1 ) {
					I.pixel_x--;
				} else if ( _a==2 ) {
					I.pixel_x++;
				} else if ( _a==3 ) {
					I.pixel_y--;
				} else if ( _a==4 ) {
					I.pixel_y++;
				};
				this.overlays += I;
				i++;
			}
			return;
		}

		public void me_verb( dynamic message = null ) {
			if ( Misc13.isValid( GlobalVars.say_disabled ) ) {
				Misc13.thread_user.write( "<span class='danger'>Speech is currently admin-disabled.</span>" );
				return;
			}
			message = GlobalFuncs.trim( Misc13.str_sub( GlobalFuncs.sanitize( message ), 1, 1024 ) );
			Misc13.thread_user.emote( "me", 1, message );
			return;
		}

		public virtual void whisper( dynamic message = null ) {
			return;
		}

		public void say_verb( dynamic message = null ) {
			if ( Misc13.isValid( GlobalVars.say_disabled ) ) {
				Misc13.thread_user.write( "<span class='danger'>Speech is currently admin-disabled.</span>" );
				return;
			}
			Misc13.thread_user.say( message );
			return;
		}

		public void a_intent_change( string input = "" ) {
			if ( this is Mob_Living_Carbon_Human || this is Mob_Living_Carbon_Alien_Humanoid || this is Mob_Living_Carbon_Brain ) {
				dynamic _a = input; // Was a switch-case, sorry for the mess.
				if ( _a=="help" || _a=="disarm" || _a=="grab" || _a=="harm" ) {
					this.a_intent = input;
				} else if ( _a=="right" ) {
					this.a_intent = GlobalFuncs.intent_numeric( ( GlobalFuncs.intent_numeric( this.a_intent ) + 1 ) % 4 );
				} else if ( _a=="left" ) {
					this.a_intent = GlobalFuncs.intent_numeric( ( GlobalFuncs.intent_numeric( this.a_intent ) + 3 ) % 4 );
				};
				if ( ( this.hud_used != null ) && Misc13.isValid( this.hud_used.action_intent ) ) {
					this.hud_used.action_intent.icon_state = "" + this.a_intent;
				}
			} else if ( this is Mob_Living_Silicon_Robot || this is Mob_Living_Carbon_Monkey || this is Mob_Living_Carbon_Alien_Larva ) {
				dynamic _b = input; // Was a switch-case, sorry for the mess.
				if ( _b=="help" ) {
					this.a_intent = "help";
				} else if ( _b=="harm" ) {
					this.a_intent = "harm";
				} else if ( _b=="right" || _b=="left" ) {
					this.a_intent = GlobalFuncs.intent_numeric( GlobalFuncs.intent_numeric( this.a_intent ) - 3 );
				};
				if ( ( this.hud_used != null ) && Misc13.isValid( this.hud_used.action_intent ) ) {
					if ( this.a_intent == "harm" ) {
						this.hud_used.action_intent.icon_state = "harm";
					} else {
						this.hud_used.action_intent.icon_state = "help";
					}
				}
			}
			return;
		}

		public int southface(  ) {
			if ( !Misc13.isValid( this.canface() ) ) {
				return 0;
			}
			this.dir = GlobalVars.SOUTH;
			this.client.move_delay += this.movement_delay();
			return 1;
		}

		public int northface(  ) {
			if ( !Misc13.isValid( this.canface() ) ) {
				return 0;
			}
			this.dir = GlobalVars.NORTH;
			this.client.move_delay += this.movement_delay();
			return 1;
		}

		public int westface(  ) {
			if ( !Misc13.isValid( this.canface() ) ) {
				return 0;
			}
			this.dir = GlobalVars.WEST;
			this.client.move_delay += this.movement_delay();
			return 1;
		}

		public int eastface(  ) {
			if ( !Misc13.isValid( this.canface() ) ) {
				return 0;
			}
			this.dir = GlobalVars.EAST;
			this.client.move_delay += this.movement_delay();
			return 1;
		}

		public virtual void cancel_camera(  ) {
			this.reset_view( null );
			this.unset_machine();
			return;
		}

		public void observe(  ) {
			int is_admin = 0;
			ByTable names = null;
			ByTable namecounts = null;
			ByTable creatures = null;
			dynamic O = null;
			string name = "";
			dynamic M = null;
			dynamic eye_name = null;
			string ok = "";
			dynamic mob_eye = null;
			is_admin = 0;
			if ( Misc13.isValid( GlobalFuncs.check_rights_for( this.client, 2 ) ) ) {
				is_admin = 1;
			} else if ( this.stat != 2 || this is Mob_NewPlayer ) {
				Misc13.thread_user.write( "<span class='notice'>You must be observing to use this!</span>" );
				return;
			}
			if ( ( is_admin != 0 ) && this.stat == 2 ) {
				is_admin = 0;
			}
			names = new ByTable();
			namecounts = new ByTable();
			creatures = new ByTable();
			O = null;
			foreach (dynamic _a in Game.contents ) {
				O = _a;
				if ( !( O is Entity ) ) {
					continue;
				}
				if ( !Misc13.isValid( O.loc ) ) {
					continue;
				}
				if ( O is Ent_Item_Weapon_Disk_Nuclear ) {
					name = "Nuclear Disk";
					if ( Misc13.isValid( names.Find( name ) ) ) {
						namecounts[name]++;
						name = "" + name + " (" + namecounts[name] + ")";
					} else {
						names.Add( name );
						namecounts[name] = 1;
					}
					creatures[name] = O;
				}
				if ( O is Ent_Singularity ) {
					name = "Singularity";
					if ( Misc13.isValid( names.Find( name ) ) ) {
						namecounts[name]++;
						name = "" + name + " (" + namecounts[name] + ")";
					} else {
						names.Add( name );
						namecounts[name] = 1;
					}
					creatures[name] = O;
				}
				if ( O is Ent_Machinery_Bot ) {
					name = "BOT: " + O.name;
					if ( Misc13.isValid( names.Find( name ) ) ) {
						namecounts[name]++;
						name = "" + name + " (" + namecounts[name] + ")";
					} else {
						names.Add( name );
						namecounts[name] = 1;
					}
					creatures[name] = O;
				}
			};
			M = null;
			foreach (dynamic _b in GlobalFuncs.sortNames( GlobalVars.mob_list ) ) {
				M = _b;
				name = M.name;
				if ( Misc13.isValid( names.Find( name ) ) ) {
					namecounts[name]++;
					name = "" + name + " (" + namecounts[name] + ")";
				} else {
					names.Add( name );
					namecounts[name] = 1;
				}
				creatures[name] = M;
			};
			this.client.perspective = GlobalVars.EYE_PERSPECTIVE;
			eye_name = null;
			ok = "" + ( is_admin != 0 ? "Admin Observe" : "Observe" );
			eye_name = Misc13.input( "Please, select a player!", ok, null, null, creatures, 4224 );
			if ( !Misc13.isValid( eye_name ) ) {
				return;
			}
			mob_eye = creatures[eye_name];
			if ( Misc13.isValid( this.client ) && Misc13.isValid( mob_eye ) ) {
				this.client.eye = mob_eye;
				if ( is_admin != 0 ) {
					this.client.adminobs = 1;
					if ( mob_eye == this.client.mob || this.client.eye == this.client.mob ) {
						this.client.adminobs = 0;
					}
				}
			}
			return;
		}

		public void abandon_mob(  ) {
			Mob_NewPlayer M = null;
			if ( !Misc13.isValid( GlobalVars.abandon_allowed ) ) {
				return;
			}
			if ( this.stat != 2 || ( GlobalVars.ticker == null ) ) {
				Misc13.thread_user.write( "<span class='boldnotice'>You must be dead to use this!</span>" );
				return;
			}
			GlobalFuncs.log_game( "" + Misc13.thread_user.name + "/" + Misc13.thread_user.key + " used abandon mob." );
			Misc13.thread_user.write( "<span class='boldnotice'>Please roleplay correctly!</span>" );
			if ( !Misc13.isValid( this.client ) ) {
				GlobalFuncs.log_game( "" + Misc13.thread_user.key + " AM failed due to disconnect." );
				return;
			}
			this.client.screen.Cut();
			this.client.screen += GlobalVars._void;
			if ( !Misc13.isValid( this.client ) ) {
				GlobalFuncs.log_game( "" + Misc13.thread_user.key + " AM failed due to disconnect." );
				return;
			}
			M = new Mob_NewPlayer();
			if ( !Misc13.isValid( this.client ) ) {
				GlobalFuncs.log_game( "" + Misc13.thread_user.key + " AM failed due to disconnect." );
				GlobalFuncs.qdel( M );
				return;
			}
			M.key = this.key;
			return;
		}

		public virtual void add_memory( dynamic msg = null ) {
			msg = Misc13.str_sub( msg, 1, 1024 );
			msg = GlobalFuncs.sanitize( msg );
			if ( this.mind != null ) {
				this.mind.store_memory( msg );
			} else {
				this.write( "The game appears to have misplaced your mind datum, so we can't show you your notes." );
			}
			return;
		}

		public virtual void f_memory(  ) {
			if ( this.mind != null ) {
				this.mind.show_memory( this );
			} else {
				this.write( "The game appears to have misplaced your mind datum, so we can't show you your notes." );
			}
			return;
		}

		public virtual void mode(  ) {
			dynamic W = null;
			if ( this.loc is Ent_Mecha ) {
				return;
			}
			if ( Misc13.isValid( this.hand ) ) {
				W = this.l_hand;
				if ( Misc13.isValid( W ) ) {
					W.attack_self( this );
					this.update_inv_l_hand();
				}
			} else {
				W = this.r_hand;
				if ( Misc13.isValid( W ) ) {
					W.attack_self( this );
					this.update_inv_r_hand();
				}
			}
			return;
		}

		public void stop_pulling(  ) {
			if ( Misc13.isValid( this.pulling ) ) {
				this.pulling.pulledby = null;
				this.pulling = null;
				if ( this.pullin != null ) {
					this.pullin.update_icon( this );
				}
			}
			return;
		}

		public virtual int pointed( Ent_Effect_Decal_Point A = null ) {
			dynamic tile = null;
			Ent_Effect_Decal_Point P = null;
			if ( ( this == null ) || !( this.loc is Tile ) || !Misc13.view( this.loc, null ).contains( A ) ) {
				return 0;
			}
			if ( A is Ent_Effect_Decal_Point ) {
				return 0;
			}
			tile = GlobalFuncs.get_turf( A );
			if ( !Misc13.isValid( tile ) ) {
				return 0;
			}
			P = new Ent_Effect_Decal_Point( tile );
			P.invisibility = this.invisibility;
			Thread13.schedule( 20, (Thread13.Closure)(() => {
				if ( P != null ) {
					GlobalFuncs.qdel( P );
				}
				return;
			}));
			return 1;
		}

		public void examinate( BaseStatic A = null ) {
			if ( Misc13.isValid( GlobalFuncs.is_blind( this ) ) ) {
				this.write( "<span class='notice'>Something is there but you can't see it.</span>" );
				return;
			}
			this.face_atom( A );
			A.examine( this );
			return;
		}

		public void pray( dynamic msg = null ) {
			Image cross = null;
			dynamic C = null;
			if ( Misc13.isValid( GlobalVars.say_disabled ) ) {
				Misc13.thread_user.write( "<span class='danger'>Speech is currently admin-disabled.</span>" );
				return;
			}
			msg = Misc13.str_sub( GlobalFuncs.sanitize( msg ), 1, 1024 );
			if ( !Misc13.isValid( msg ) ) {
				return;
			}
			GlobalFuncs.log_prayer( "" + this.key + "/(" + this.name + "): " + msg );
			if ( Misc13.isValid( Misc13.thread_user.client ) ) {
				if ( Misc13.isValid( ( Misc13.thread_user.client.prefs.muted & 4 ) ) ) {
					Misc13.thread_user.write( "<span class='danger'>You cannot pray (muted).</span>" );
					return;
				}
				if ( Misc13.isValid( this.client.handle_spam_prevention( msg, 4 ) ) ) {
					return;
				}
			}
			cross = new Image( new ByRsc(331), "bible" );
			if ( Misc13.thread_user.job == "Chaplain" ) {
				cross = new Image( new ByRsc(331), "kingyellow" );
				msg = new Txt( "<span class='adminnotice'>" ).icon( cross ).str( " <b><font color=blue>CHAPLAIN PRAYER: </font>" ).item( GlobalFuncs.key_name_admin( this ) ).str( " (<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( this ).str( "'>?</A>) (<A HREF='?_src_=holder;adminplayeropts=" ).Ref( this ).str( "'>PP</A>) (<A HREF='?_src_=vars;Vars=" ).Ref( this ).str( "'>VV</A>) (<A HREF='?_src_=holder;subtlemessage=" ).Ref( this ).str( "'>SM</A>) (<A HREF='?_src_=holder;adminplayerobservefollow=" ).Ref( this ).str( "'>FLW</A>) (<A HREF='?_src_=holder;traitor=" ).Ref( this ).str( "'>TP</A>) (<A HREF='?_src_=holder;adminspawncookie=" ).Ref( this ).str( "'>SC</a>):</b> " ).item( msg ).str( "</span>" );
			} else if ( Misc13.isValid( GlobalFuncs.iscultist( Misc13.thread_user ) ) ) {
				cross = new Image( new ByRsc(331), "tome" );
				msg = new Txt( "<span class='adminnotice'>" ).icon( cross ).str( " <b><font color=red>CULTIST PRAYER: </font>" ).item( GlobalFuncs.key_name_admin( this ) ).str( " (<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( this ).str( "'>?</A>) (<A HREF='?_src_=holder;adminplayeropts=" ).Ref( this ).str( "'>PP</A>) (<A HREF='?_src_=vars;Vars=" ).Ref( this ).str( "'>VV</A>) (<A HREF='?_src_=holder;subtlemessage=" ).Ref( this ).str( "'>SM</A>) (<A HREF='?_src_=holder;adminplayerobservefollow=" ).Ref( this ).str( "'>FLW</A>) (<A HREF='?_src_=holder;traitor=" ).Ref( this ).str( "'>TP</A>) (<A HREF='?_src_=holder;adminspawncookie=" ).Ref( this ).str( "'>SC</a>):</b> " ).item( msg ).str( "</span>" );
			} else {
				cross = new Image( new ByRsc(331), "bible" );
				msg = new Txt( "<span class='adminnotice'>" ).icon( cross ).str( " <b><font color=purple>PRAYER: </font>" ).item( GlobalFuncs.key_name_admin( this ) ).str( " (<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( this ).str( "'>?</A>) (<A HREF='?_src_=holder;adminplayeropts=" ).Ref( this ).str( "'>PP</A>) (<A HREF='?_src_=vars;Vars=" ).Ref( this ).str( "'>VV</A>) (<A HREF='?_src_=holder;subtlemessage=" ).Ref( this ).str( "'>SM</A>) (<A HREF='?_src_=holder;adminplayerobservefollow=" ).Ref( this ).str( "'>FLW</A>) (<A HREF='?_src_=holder;traitor=" ).Ref( this ).str( "'>TP</A>) (<A HREF='?_src_=holder;adminspawncookie=" ).Ref( this ).str( "'>SC</a>):</b> " ).item( msg ).str( "</span>" );
			}
			C = null;
			foreach (dynamic _a in GlobalVars.admins ) {
				C = _a;
				if ( !Misc13.isValid( typeof(Client).IsInstanceOfType( C ) ) ) {
					continue;
				}
				if ( Misc13.isValid( ( C.prefs.chat_toggles & 16 ) ) ) {
					C.write( msg );
					if ( Misc13.isValid( ( C.prefs.toggles & 512 ) ) ) {
						if ( Misc13.thread_user.job == "Chaplain" ) {
							C.write( new ByRsc(332) );
						}
					}
				}
			};
			Misc13.thread_user.write( "Your prayers have been received by the gods." );
			GlobalFuncs.feedback_add_details( "admin_verb", "PR" );
			return;
		}

		public void skincmd( dynamic data = null ) {
			dynamic _ref = null;
			dynamic a = null;
			_ref = Misc13.str_sub( data, 1, Misc13.str_find( data, ";", 1, null ) );
			if ( this.skincmds[_ref] != null ) {
				a = this.skincmds[_ref];
				a.SkinCmd( this, Misc13.str_sub( data, Misc13.str_find( data, ";", 1, null ) + 1, null ) );
			}
			return;
		}

		public void vote(  ) {
			Browser popup = null;
			popup = new Browser( this, "vote", "Voting Panel" );
			popup.set_window_options( "can_close=0" );
			popup.set_content( GlobalVars.SSvote.f_interface( this.client ) );
			popup.open( 0 );
			return;
		}

		public void button_pressed_F12(  ) {
			if ( ( this.hud_used != null ) && Misc13.isValid( this.client ) ) {
				if ( this is Mob_Living_Carbon_Human ) {
					this.hud_used.show_hud();
					Misc13.thread_user.write( "<span class ='info'>Switched HUD mode. Press F12 to toggle.</span>" );
				} else {
					Misc13.thread_user.write( "<span class ='warning'>Inventory hiding is currently only supported for human mobs, sorry.</span>" );
				}
			} else {
				Misc13.thread_user.write( "<span class ='warning'>This mob type does not use a HUD.</span>" );
			}
			return;
		}

	}

}