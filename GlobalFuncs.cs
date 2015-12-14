using System;
using Som13;

namespace Game13 {
	static class GlobalFuncs {
		public static int above_neck( dynamic zone = null ) {
			ByTable zones = null;
			zones = new ByTable(new object [] {"head","mouth","eyes"});
			if ( zones.Find( zone ) != 0 ) {
				return 1;
			} else {
				return 0;
			}
		}

		public static ByTable active_ais( int check_mind = 0 ) {
			ByTable _default = null;
			dynamic A = null;
			if ( check_mind == null ) {
				check_mind = 0;
			}
			_default = new ByTable();
			A = null;
			foreach (dynamic _ in GlobalVars.living_mob_list ) {
				A = _;
				if ( !( A is Mob_Living_Silicon_Ai ) ) {
					continue;
				}
				if ( A.stat == 2 ) {
					continue;
				}
				if ( A.control_disabled == 1 ) {
					continue;
				}
				if ( check_mind != 0 ) {
					if ( !Misc13.isValid( A.mind ) ) {
						continue;
					}
				}
				_default += A;
			};
			return _default;
			return _default;
		}

		public static ByTable active_free_borgs(  ) {
			ByTable _default = null;
			dynamic R = null;
			_default = new ByTable();
			R = null;
			foreach (dynamic _ in GlobalVars.living_mob_list ) {
				R = _;
				if ( !( R is Mob_Living_Silicon_Robot ) ) {
					continue;
				}
				if ( Misc13.isValid( R.connected_ai ) ) {
					continue;
				}
				if ( R.stat == 2 ) {
					continue;
				}
				if ( Misc13.isValid( R.emagged ) || Misc13.isValid( R.scrambledcodes ) || Misc13.isValid( R.syndicate ) ) {
					continue;
				}
				_default += R;
			};
			return _default;
		}

		public static void add_logs( dynamic user = null, dynamic target = null, dynamic what_done = null, dynamic _object = null, dynamic addition = null ) {
			string newhealthtxt = null;
			dynamic L = null;
			if ( _object == null ) {
				_object = null;
			}
			if ( addition == null ) {
				addition = null;
			}
			newhealthtxt = "";
			if ( Misc13.isValid( target ) && target is Mob_Living ) {
				L = target;
				newhealthtxt = " (NEWHP: " + L.health + ")";
			}
			if ( Misc13.isValid( user ) && user is Mob ) {
				user.attack_log += "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Has " + what_done + " " + ( Misc13.isValid( target ) ? "" + target.name + ( target is Mob && Misc13.isValid( target.ckey ) ? "(" + target.ckey + ")" : "" ) : "NON-EXISTANT SUBJECT" ) + ( Misc13.isValid( _object ) ? " with " + _object : " " ) + addition + newhealthtxt + "</font>";
			}
			if ( Misc13.isValid( target ) && target is Mob ) {
				target.attack_log += "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been " + what_done + " by " + ( Misc13.isValid( user ) ? "" + user.name + ( user is Mob && Misc13.isValid( user.ckey ) ? "(" + user.ckey + ")" : "" ) : "NON-EXISTANT SUBJECT" ) + ( Misc13.isValid( _object ) ? " with " + _object : " " ) + addition + newhealthtxt + "</font>";
			}
			GlobalFuncs.log_attack( "" + ( Misc13.isValid( user ) ? "" + user.name + ( user is Mob && Misc13.isValid( user.ckey ) ? "(" + user.ckey + ")" : "" ) : "NON-EXISTANT SUBJECT" ) + " " + what_done + " " + ( Misc13.isValid( target ) ? "" + target.name + ( target is Mob && Misc13.isValid( target.ckey ) ? "(" + target.ckey + ")" : "" ) : "NON-EXISTANT SUBJECT" ) + ( Misc13.isValid( _object ) ? " with " + _object : " " ) + addition + newhealthtxt );
		}

		public static string add_lspace( string t = null, dynamic u = null ) {
			while (t.Length < u) {
				t = " " + t;
			}
			return t;
		}

		public static void add_note( dynamic target_ckey = null, dynamic notetext = null, dynamic timestamp = null, dynamic adminckey = null, int logged = 0, dynamic server = null ) {
			dynamic new_ckey = null;
			DBQuery query_find_ckey = null;
			dynamic err = null;
			dynamic target_sql_ckey = null;
			dynamic admin_sql_ckey = null;
			DBQuery query_noteadd = null;
			if ( logged == null ) {
				logged = 1;
			}
			if ( GlobalVars.dbcon.IsConnected() == 0 ) {
				Misc13.thread_user.write( "<span class='danger'>Failed to establish database connection.</span>" );
				return;
			}
			if ( !Misc13.isValid( target_ckey ) ) {
				new_ckey = Misc13.ckey( Misc13.input( Misc13.thread_user, "Who would you like to add a note for?", "Enter a ckey", null, null, 4 ) );
				if ( !Misc13.isValid( new_ckey ) ) {
					return;
				}
				new_ckey = GlobalFuncs.sanitizeSQL( new_ckey );
				query_find_ckey = GlobalVars.dbcon.NewQuery( "SELECT ckey FROM " + GlobalFuncs.format_table_name( "player" ) + " WHERE ckey = '" + new_ckey + "'" );
				if ( !Misc13.isValid( query_find_ckey.Execute() ) ) {
					err = query_find_ckey.ErrorMsg();
					GlobalFuncs.log_game( "SQL ERROR obtaining ckey from player table. Error : [" + err + "]\n" );
					return;
				}
				if ( !Misc13.isValid( query_find_ckey.NextRow() ) ) {
					if ( Misc13.alert( Misc13.thread_user, "" + new_ckey + " has not been seen before, are you sure you want to add them to the watchlist?", "Unknown ckey", "Yes", "No", "Cancel" ) != "Yes" ) {
						return;
					}
				}
				target_ckey = new_ckey;
			}
			target_sql_ckey = GlobalFuncs.sanitizeSQL( target_ckey );
			if ( !Misc13.isValid( notetext ) ) {
				notetext = Misc13.input( Misc13.thread_user, "Write your Note", "Add Note", null, null, 2048 );
				if ( !Misc13.isValid( notetext ) ) {
					return;
				}
			}
			notetext = GlobalFuncs.sanitizeSQL( notetext );
			if ( !Misc13.isValid( timestamp ) ) {
				timestamp = GlobalFuncs.SQLtime();
			}
			if ( !Misc13.isValid( adminckey ) ) {
				adminckey = Misc13.thread_user.ckey;
				if ( !Misc13.isValid( adminckey ) ) {
					return;
				}
			}
			admin_sql_ckey = GlobalFuncs.sanitizeSQL( adminckey );
			if ( !Misc13.isValid( server ) ) {
				if ( Misc13.isValid( GlobalVars.config ) && Misc13.isValid( GlobalVars.config.server_name ) ) {
					server = GlobalVars.config.server_name;
				}
			}
			server = GlobalFuncs.sanitizeSQL( server );
			query_noteadd = GlobalVars.dbcon.NewQuery( "INSERT INTO " + GlobalFuncs.format_table_name( "notes" ) + " (ckey, timestamp, notetext, adminckey, server) VALUES ('" + target_sql_ckey + "', '" + timestamp + "', '" + notetext + "', '" + admin_sql_ckey + "', '" + server + "')" );
			if ( !Misc13.isValid( query_noteadd.Execute() ) ) {
				err = query_noteadd.ErrorMsg();
				GlobalFuncs.log_game( "SQL ERROR adding new note to table. Error : [" + err + "]\n" );
				return;
			}
			if ( logged != 0 ) {
				GlobalFuncs.log_admin( "" + GlobalFuncs.key_name( Misc13.thread_user ) + " has added a note to " + target_ckey + ": " + notetext );
				GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( Misc13.thread_user ) + " has added a note to " + target_ckey + ":<br>" + notetext );
				GlobalFuncs.show_note( target_ckey );
			}
		}

		public static dynamic add_radio( dynamic radio = null, dynamic freq = null ) {
			if ( !Misc13.isValid( freq ) || !Misc13.isValid( radio ) ) {
				return null;
			}
			if ( !Misc13.isValid( GlobalVars.all_radios["" + freq] ) ) {
				GlobalVars.all_radios["" + freq] = new ByTable(new object [] {radio});
				return freq;
			}
			GlobalVars.all_radios["" + freq] |= radio;
			return freq;
		}

		public static string add_tspace( string t = null, dynamic u = null ) {
			while (t.Length < u) {
				t = "" + t + " ";
			}
			return t;
		}

		public static string add_zero( string t = null, dynamic u = null ) {
			while (t.Length < u) {
				t = "0" + t;
			}
			return t;
		}

		public static int AddBan( dynamic ckey = null, dynamic computerid = null, dynamic reason = null, dynamic bannedby = null, dynamic temp = null, dynamic minutes = null, dynamic address = null ) {
			dynamic bantimestamp = null;
			if ( Misc13.isValid( temp ) ) {
				GlobalFuncs.UpdateTime();
				bantimestamp = GlobalVars.CMinutes + minutes;
			}
			GlobalVars.Banlist.cd = "/base";
			if ( Misc13.isValid( GlobalVars.Banlist.dir.Find( "" + ckey + computerid ) ) ) {
				Misc13.thread_user.write( "<span class='danger'>Ban already exists.</span>" );
				return 0;
			} else {
				GlobalVars.Banlist.Add( "" + ckey + computerid );
				GlobalVars.Banlist.cd = "/base/" + ckey + computerid;
				GlobalVars.Banlist["key"].write( ckey );
				GlobalVars.Banlist["id"].write( computerid );
				GlobalVars.Banlist["ip"].write( address );
				GlobalVars.Banlist["reason"].write( reason );
				GlobalVars.Banlist["bannedby"].write( bannedby );
				GlobalVars.Banlist["temp"].write( temp );
				if ( Misc13.isValid( temp ) ) {
					GlobalVars.Banlist["minutes"].write( bantimestamp );
				}
				if ( !Misc13.isValid( temp ) ) {
					GlobalFuncs.add_note( ckey, "Permanently banned - " + reason, null, bannedby, 0 );
				} else {
					GlobalFuncs.add_note( ckey, "Banned for " + minutes + " minutes - " + reason, null, bannedby, 0 );
				}
			}
			return 1;
		}

		public static int addtimer( dynamic thingToCall = null, dynamic procToCall = null, dynamic wait = null, ByTable argList = null ) {
			Timedevent _event = null;
			if ( argList == null ) {
				argList = new ByTable();
			}
			if ( GlobalVars.SStimer == null ) {
				return 0;
			}
			if ( !Misc13.isValid( thingToCall ) || !Misc13.isValid( procToCall ) || wait <= 0 ) {
				return 0;
			}
			if ( GlobalVars.SStimer.can_fire == 0 ) {
				GlobalVars.SStimer.can_fire = 1;
				GlobalVars.SStimer.next_fire = Game.time + GlobalVars.SStimer.wait;
			}
			_event = new Timedevent();
			_event.thingToCall = thingToCall;
			_event.procToCall = procToCall;
			_event.timeToRun = Game.time + wait;
			_event.argList = argList;
			GlobalVars.SStimer.processing += _event;
			return _event.id;
		}

		public static void admin_forcemove( dynamic mover = null, dynamic newloc = null ) {
			if ( Misc13.isValid( mover.buckled ) ) {
				mover.buckled.unbuckle_mob();
			}
			if ( Misc13.isValid( mover.buckled_mob ) ) {
				mover.unbuckle_mob.BTCall( new ByTable().set( "force", 1 ) );
			}
			mover.loc = newloc;
			mover.on_forcemove( newloc );
		}

		public static int admin_keyword_to_flag( dynamic word = null, int previous_rights = 0 ) {
			int flag = 0;
			if ( previous_rights == null ) {
				previous_rights = 0;
			}
			flag = 0;
			dynamic _ = Misc13.ckey( word ); // Was a switch-case, sorry for the mess.
			if ( _=="buildmode" || _=="build" ) {
				flag = 1;
			} else if ( _=="admin" ) {
				flag = 2;
			} else if ( _=="ban" ) {
				flag = 4;
			} else if ( _=="fun" ) {
				flag = 8;
			} else if ( _=="server" ) {
				flag = 16;
			} else if ( _=="debug" ) {
				flag = 32;
			} else if ( _=="permissions" || _=="rights" ) {
				flag = 128;
			} else if ( _=="possess" ) {
				flag = 64;
			} else if ( _=="stealth" ) {
				flag = 256;
			} else if ( _=="rejuv" || _=="rejuvinate" ) {
				flag = 512;
			} else if ( _=="varedit" ) {
				flag = 1024;
			} else if ( _=="everything" || _=="host" || _=="all" ) {
				flag = 65535;
			} else if ( _=="sound" || _=="sounds" ) {
				flag = 2048;
			} else if ( _=="spawn" || _=="create" ) {
				flag = 4096;
			} else if ( _=="@" || _=="prev" ) {
				flag = previous_rights;
			};
			return flag;
		}

		public static dynamic admin_keyword_to_path( dynamic word = null ) {
			return Misc13.findType( Misc13.str_sub( word, 2, Misc13.str_find( word, " ", 2, 0 ) ) );
		}

		public static void AdminCreateVirus( dynamic user = null ) {
			int i = 0;
			Disease_Advance D = null;
			ByTable symptoms = null;
			dynamic symptom = null;
			dynamic S = null;
			string new_name = null;
			dynamic AD = null;
			dynamic H = null;
			ByTable name_symptoms = null;
			if ( !Misc13.isValid( user ) ) {
				return;
			}
			i = 5;
			D = new Disease_Advance( 0, null );
			D.symptoms = new ByTable();
			symptoms = new ByTable();
			symptoms += "Done";
			symptoms += GlobalVars.list_symptoms.Copy();
			while (true) { // Was a do-while, sorry for the mess.
				if ( Misc13.isValid( user ) ) {
					symptom = Misc13.input( user, "Choose a symptom to add (" + i + " remaining)", "Choose a Symptom", null, symptoms, 0 );
					if ( symptom == null ) {
						return;
					} else if ( symptom is string ) {
						i = 0;
					} else if ( symptom is Type ) {
						S = symptom();
						if ( D.HasSymptom( S ) == 0 ) {
							D.symptoms += S;
							i -= 1;
						}
					}
				}
				if (!( i > 0 )) break;
			};
			if ( D.symptoms.len > 0 ) {
				new_name = GlobalFuncs.stripped_input( user, "Name your new disease.", "New Name" );
				if ( !Misc13.isValid( new_name ) ) {
					return;
				}
				D.AssignName( new_name );
				D.Refresh();
				AD = null;
				foreach (dynamic _ in GlobalVars.SSdisease.processing ) {
					AD = _;
					if ( !( AD is Disease_Advance ) ) {
						continue;
					}
					AD.Refresh();
				};
				H = null;
				foreach (dynamic _ in GlobalFuncs.shuffle( GlobalVars.living_mob_list ) ) {
					H = _;
					if ( !( H is Mob_Living_Carbon_Human ) ) {
						continue;
					}
					if ( H.z != 1 ) {
						continue;
					}
					if ( H.HasDisease( D ) == 0 ) {
						H.ForceContractDisease( D );
						break;
					}
				};
				name_symptoms = new ByTable();
				S = null;
				foreach (dynamic _ in D.symptoms ) {
					S = _;
					if ( !( S is Symptom ) ) {
						continue;
					}
					name_symptoms += S.name;
				};
				GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( user ) + " has triggered a custom virus outbreak of " + D.name + "! It has these symptoms: " + GlobalFuncs.english_list( name_symptoms ) );
			}
		}

		public static dynamic adminscrub( dynamic t = null, int limit = 0 ) {
			if ( limit == null ) {
				limit = 1024;
			}
			return Misc13.str_sub( Misc13.html_encode( GlobalFuncs.strip_html_simple( t ) ), 1, limit );
		}

		public static dynamic Advance_Mix( dynamic D_list = null ) {
			ByTable diseases = null;
			dynamic A = null;
			int i = 0;
			dynamic D1 = null;
			dynamic D2 = null;
			dynamic to_return = null;
			diseases = new ByTable();
			A = null;
			foreach (dynamic _ in D_list ) {
				A = _;
				if ( !( A is Disease_Advance ) ) {
					continue;
				}
				diseases += A.Copy();
			};
			if ( !Misc13.isValid( diseases.len ) ) {
				return null;
			}
			if ( diseases.len <= 1 ) {
				return Rand.pick( diseases );
			}
			i = 0;
			while (i < 20 && diseases.len > 1) {
				i++;
				D1 = Rand.pick( diseases );
				diseases -= D1;
				D2 = Rand.pick( diseases );
				D2.Mix( D1 );
			}
			to_return = Rand.pick( diseases );
			to_return.Refresh( 1 );
			return to_return;
		}

		public static int alien_type_present( dynamic alienpath = null ) {
			dynamic A = null;
			A = null;
			foreach (dynamic _ in GlobalVars.living_mob_list ) {
				A = _;
				if ( !( A is Mob_Living_Carbon_Alien_Humanoid ) ) {
					continue;
				}
				if ( !Misc13.isValid( alienpath.IsInstanceOfType( A ) ) ) {
					continue;
				}
				if ( !Misc13.isValid( A.key ) || A.stat == 2 ) {
					continue;
				}
				return 1;
			};
			return 0;
		}

		public static int alone_in_area( dynamic the_area = null, dynamic must_be_alone = null, Type check_type = null ) {
			int our_area = 0;
			dynamic C = null;
			if ( check_type == null ) {
				check_type = typeof(Mob_Living_Carbon);
			}
			our_area = GlobalFuncs.get_area_master( the_area );
			C = null;
			foreach (dynamic _ in GlobalVars.living_mob_list ) {
				C = _;
				if ( !Misc13.isValid( check_type.IsInstanceOfType( C ) ) ) {
					continue;
				}
				if ( C == must_be_alone ) {
					continue;
				}
				if ( our_area == GlobalFuncs.get_area_master( C ) ) {
					return 0;
				}
			};
			return 1;
		}

		public static int angle2dir( dynamic degree = null ) {
			degree = GlobalFuncs.SimplifyDegrees( degree );
			if ( degree < 45 ) {
				return GlobalVars.NORTH;
			}
			if ( degree < 90 ) {
				return GlobalVars.NORTHEAST;
			}
			if ( degree < 135 ) {
				return GlobalVars.EAST;
			}
			if ( degree < 180 ) {
				return GlobalVars.SOUTHEAST;
			}
			if ( degree < 225 ) {
				return GlobalVars.SOUTH;
			}
			if ( degree < 270 ) {
				return GlobalVars.SOUTHWEST;
			}
			if ( degree < 315 ) {
				return GlobalVars.WEST;
			}
			return 9;
		}

		public static string angle2text( dynamic degree = null ) {
			return GlobalFuncs.dir2text( GlobalFuncs.angle2dir( degree ) );
		}

		public static void anim( dynamic location = null, dynamic target = null, dynamic a_icon = null, dynamic a_icon_state = null, dynamic flick_anim = null, int sleeptime = 0, dynamic direction = null ) {
			Dynamic_Overlay animation = null;
			if ( sleeptime == null ) {
				sleeptime = 0;
			}
			animation = new Dynamic_Overlay( location );
			if ( Misc13.isValid( direction ) ) {
				animation.dir = direction;
			}
			animation.icon = a_icon;
			animation.layer = target.layer + 1;
			if ( Misc13.isValid( a_icon_state ) ) {
				animation.icon_state = a_icon_state;
			} else {
				animation.icon_state = "blank";
				animation.master = target;
				Misc13.flick( flick_anim, animation );
			}
			Thread13.sleep( Misc13.max( sleeptime, 15 ) );
			GlobalFuncs.qdel( animation );
		}

		public static bool anyprob( dynamic value = null ) {
			return Rand.Int( 1, value ) == value;
		}

		public static void appearance_fullban( dynamic M = null, dynamic reason = null ) {
			if ( !Misc13.isValid( M ) || !Misc13.isValid( M.key ) ) {
				return;
			}
			GlobalVars.appearance_keylist.Add( "" + M.ckey + " ## " + reason );
			GlobalFuncs.appearance_savebanfile();
		}

		public static dynamic appearance_isbanned( dynamic M = null ) {
			dynamic s = null;
			dynamic startpos = null;
			dynamic text = null;
			if ( Misc13.isValid( M ) ) {
				s = null;
				foreach (dynamic _ in GlobalVars.appearance_keylist ) {
					s = _;
					if ( Misc13.str_find( s, "" + M.ckey, 1, null ) == 1 ) {
						startpos = Misc13.str_find( s, "## ", 1, null ) + 3;
						if ( Misc13.isValid( startpos ) && startpos < s.Length ) {
							text = Misc13.str_sub( s, startpos, 0 );
							if ( Misc13.isValid( text ) ) {
								return text;
							}
						}
						return "Reason Unspecified";
					}
				};
			}
			return 0;
		}

		public static int appearance_remove( dynamic X = null ) {
			int i = 0;
			i = null;
			i = 1;
			while (i <= GlobalVars.appearance_keylist.Length) {
				if ( Misc13.isValid( Misc13.str_find( GlobalVars.appearance_keylist[i], "" + X, 1, null ) ) ) {
					GlobalVars.appearance_keylist.Remove( GlobalVars.appearance_keylist[i] );
					GlobalFuncs.appearance_savebanfile();
					return 1;
				}
				i++;
			}
			return 0;
		}

		public static void appearance_savebanfile(  ) {
			SaveFile S = null;
			S = new SaveFile( "data/appearance_full.ban" );
			S["keys" + 0].write( GlobalVars.appearance_keylist );
		}

		public static void appearance_unban( dynamic M = null ) {
			GlobalFuncs.appearance_remove( "" + M.ckey );
			GlobalFuncs.appearance_savebanfile();
		}

		public static dynamic arctan( dynamic x = null ) {
			dynamic y = null;
			y = Math.Asin( x / Math.Sqrt( x * x + 1 ) );
			return y;
		}

		public static void assign_progress_bar( dynamic user = null, dynamic progbar = null ) {
			if ( Misc13.isValid( user ) && Misc13.isValid( user.client ) && Misc13.isValid( progbar ) ) {
				user.client.images |= progbar;
			}
		}

		public static dynamic AStar( dynamic start = null, dynamic end = null, dynamic atom = null, dynamic dist = null, dynamic maxnodes = null, int maxnodedepth = 0, dynamic mintargetdist = null, dynamic adjacent = null, dynamic id = null, dynamic exclude = null, int simulated_only = 0 ) {
			Heap open = null;
			ByTable closed = null;
			ByTable path = null;
			dynamic cur = null;
			bool closeenough = false;
			dynamic L = null;
			dynamic T = null;
			dynamic newg = null;
			dynamic PN = null;
			int i = 0;
			if ( maxnodedepth == null ) {
				maxnodedepth = 30;
			}
			if ( adjacent == null ) {
				adjacent = typeof(Tile).GetMethod( "reachableAdjacentTurfs" );
			}
			if ( id == null ) {
				id = null;
			}
			if ( exclude == null ) {
				exclude = null;
			}
			if ( simulated_only == null ) {
				simulated_only = 1;
			}
			if ( Misc13.isValid( maxnodes ) ) {
				if ( Misc13.getf2( start, dist )( end ) > maxnodes ) {
					return 0;
				}
				maxnodedepth = maxnodes;
			}
			open = new Heap( typeof(GlobalFuncs).GetMethod( "HeapPathWeightCompare" ) );
			closed = new ByTable();
			path = null;
			start = GlobalFuncs.get_turf( start );
			if ( !Misc13.isValid( start ) ) {
				return 0;
			}
			open.Insert( new PathNode( start, null, 0, Misc13.getf2( start, dist )( end ), 0 ) );
			while (!open.IsEmpty() && ( path == null )) {
				cur = open.Pop();
				closed.Add( cur.source );
				closeenough = null;
				if ( Misc13.isValid( mintargetdist ) ) {
					closeenough = Misc13.getf2( cur.source, dist )( end ) <= mintargetdist;
				}
				if ( ( maxnodedepth != 0 ) && cur.nt > maxnodedepth ) {
					continue;
				}
				if ( cur.source == end || closeenough ) {
					path = new ByTable();
					path.Add( cur.source );
					while (cur.prevNode) {
						cur = cur.prevNode;
						path.Add( cur.source );
					}
					break;
				}
				L = Misc13.getf2( cur.source, adjacent )( atom, id, simulated_only );
				T = null;
				foreach (dynamic _ in L ) {
					T = _;
					if ( Misc13.isValid( closed.HasValue( T == exclude || Misc13.isValid( T ) ) ) ) {
						continue;
					}
					newg = cur.g + Misc13.getf2( cur.source, dist )( T );
					if ( !Misc13.isValid( T.PNode ) ) {
						open.Insert( new PathNode( T, cur, newg, Misc13.getf2( T, dist )( end ), cur.nt + 1 ) );
					} else if ( newg < T.PNode.g ) {
						T.prevNode = cur;
						T.PNode.g = newg;
						T.PNode.calc_f();
						T.PNode.nt = cur.nt + 1;
						open.ReSort( T.PNode );
					}
				};
			}
			PN = null;
			foreach (dynamic _ in open.L ) {
				PN = _;
				if ( !( PN is PathNode ) ) {
					continue;
				}
				PN.source.PNode = null;
			};
			T = null;
			foreach (dynamic _ in closed ) {
				T = _;
				T.PNode = null;
			};
			if ( path != null ) {
				i = null;
				i = 1;
				while (i <= path.len / 2) {
					path.Swap( i, path.len - i + 1 );
					i++;
				}
			}
			return path;
		}

		public static string attach_spans( dynamic input = null, dynamic spans = null ) {
			return "" + GlobalFuncs.message_spans_start( spans ) + input + "</span>";
		}

		public static int attempt_initiate_surgery( dynamic I = null, dynamic M = null, dynamic user = null ) {
			dynamic H = null;
			dynamic affecting = null;
			dynamic selected_zone = null;
			dynamic current_surgery = null;
			dynamic S = null;
			dynamic all_surgeries = null;
			ByTable available_surgeries = null;
			dynamic path = null;
			dynamic P = null;
			dynamic procedure = null;
			if ( M is Mob_Living ) {
				selected_zone = user.zone_sel.selecting;
				if ( M is Mob_Living_Carbon_Human ) {
					H = M;
					affecting = H.get_organ( GlobalFuncs.check_zone( selected_zone ) );
				}
				if ( Misc13.isValid( M.lying ) || M is Mob_Living_SimpleAnimal_Slime ) {
					S = null;
					foreach (dynamic _ in M.surgeries ) {
						S = _;
						if ( !( S is Surgery ) ) {
							continue;
						}
						if ( S.location == selected_zone ) {
							current_surgery = S;
						}
					};
					if ( !Misc13.isValid( current_surgery ) ) {
						all_surgeries = GlobalVars.surgeries_list.Copy();
						available_surgeries = new ByTable();
						S = null;
						foreach (dynamic _ in all_surgeries ) {
							S = _;
							if ( !( S is Surgery ) ) {
								continue;
							}
							if ( !Misc13.isValid( S.possible_locs.Find( selected_zone ) ) ) {
								continue;
							}
							if ( Misc13.isValid( affecting ) && Misc13.isValid( S.requires_organic_bodypart ) && affecting.status == 2 ) {
								continue;
							}
							if ( !Misc13.isValid( S.can_start( user, M ) ) ) {
								continue;
							}
							path = null;
							foreach (dynamic _ in S.species ) {
								path = _;
								if ( Misc13.isValid( path.IsInstanceOfType( M ) ) ) {
									available_surgeries[S.name] = S;
									break;
								}
							};
						};
						P = Misc13.input( "Begin which procedure?", "Surgery", null, null, available_surgeries, 4224 );
						if ( Misc13.isValid( P ) && Misc13.isValid( user ) && Misc13.isValid( user.Adjacent( M ) ) && Misc13.isValid( user.HasValue( I ) ) ) {
							S = available_surgeries[P];
							procedure = S.type();
							if ( Misc13.isValid( procedure ) ) {
								procedure.location = selected_zone;
								if ( Misc13.isValid( procedure.ignore_clothes ) || ( GlobalFuncs.get_location_accessible( M, selected_zone ) != 0 ) ) {
									M.surgeries += procedure;
									procedure.organ = affecting;
									user.visible_message( new Txt().item( user ).str( " drapes " ).item( I ).str( " over " ).item( M ).str( "'s " ).item( GlobalFuncs.parse_zone( selected_zone ) ).str( " to prepare for " ).a( procedure.name ).item().str( "." ), new Txt( "<span class='notice'>You drape " ).item( I ).str( " over " ).item( M ).str( "'s " ).item( GlobalFuncs.parse_zone( selected_zone ) ).str( " to prepare for " ).a( procedure.name ).item().str( ".</span>" ) );
									GlobalFuncs.smooth_icon_neighbors.BTCall( new ByTable().set( "addition", "Operation type: " + procedure.name + ", location: " + selected_zone ).set( 3, "operated" ).set( 2, M ).set( 1, user ) );
								} else {
									user.write( "<span class='warning'>You need to expose " + M + "'s " + GlobalFuncs.parse_zone( selected_zone ) + " first!</span>" );
								}
							}
						}
					} else if ( !Misc13.isValid( current_surgery.step_in_progress ) ) {
						if ( current_surgery.status == 1 ) {
							M.surgeries -= current_surgery;
							user.visible_message( "" + user + " removes the drapes from " + M + "'s " + GlobalFuncs.parse_zone( selected_zone ) + ".", "<span class='notice'>You remove the drapes from " + M + "'s " + GlobalFuncs.parse_zone( selected_zone ) + ".</span>" );
							GlobalFuncs.qdel( current_surgery );
						} else if ( user.get_inactive_hand() is Ent_Item_Weapon_Cautery && Misc13.isValid( current_surgery.can_cancel ) ) {
							M.surgeries -= current_surgery;
							user.visible_message( "" + user + " mends the incision and removes the drapes from " + M + "'s " + GlobalFuncs.parse_zone( selected_zone ) + ".", "<span class='notice'>You mend the incision and remove the drapes from " + M + "'s " + GlobalFuncs.parse_zone( selected_zone ) + ".</span>" );
							GlobalFuncs.qdel( current_surgery );
						} else if ( Misc13.isValid( current_surgery.can_cancel ) ) {
							user.write( "<span class='warning'>You need to hold a cautery in inactive hand to stop " + M + "'s surgery!</span>" );
						}
					}
					return 1;
				}
			}
			return 0;
		}

		public static int AutoUpdateAI( dynamic subject = null ) {
			int is_in_use = 0;
			dynamic A = null;
			dynamic M = null;
			is_in_use = 0;
			if ( subject != null ) {
				A = null;
				foreach (dynamic _ in GlobalVars.ai_list ) {
					A = _;
					M = A;
					if ( Misc13.isValid( M.client ) && M.machine == subject ) {
						is_in_use = 1;
						subject.attack_ai( M );
					}
				};
			}
			return is_in_use;
		}

		public static dynamic AverageColour( dynamic I = null ) {
			ByTable colours = null;
			dynamic x_pixel = null;
			dynamic y_pixel = null;
			dynamic this_colour = null;
			dynamic final_average = null;
			dynamic colour = null;
			colours = new ByTable();
			x_pixel = null;
			foreach (dynamic _ in Misc13.iter_range( 1, I.Width() ) ) {
				x_pixel = _;
				y_pixel = null;
				foreach (dynamic _ in Misc13.iter_range( 1, I.Height() ) ) {
					y_pixel = _;
					this_colour = I.GetPixel( x_pixel, y_pixel );
					if ( Misc13.isValid( this_colour ) ) {
						colours.Add( this_colour );
					}
				};
			};
			if ( !Misc13.isValid( colours.len ) ) {
				return null;
			}
			final_average = colours[1];
			colour = null;
			foreach (dynamic _ in colours - colours[1] ) {
				colour = _;
				final_average = GlobalFuncs.BlendRGB( final_average, colour, 1 );
			};
			return final_average;
		}

		public static void ban_unban_log_save( dynamic formatted_log = null ) {
			File13.write( formatted_log, "data/ban_unban_log.txt" );
		}

		public static int blendMode2iconMode( dynamic blend_mode = null ) {
			dynamic _ = blend_mode; // Was a switch-case, sorry for the mess.
			if ( _==4 ) {
				return 2;
			} else if ( _==2 ) {
				return 0;
			} else if ( _==3 ) {
				return 1;
			} else {
				return 3;
			};
		}

		public static Color BlendRGB( dynamic rgb1 = null, dynamic rgb2 = null, dynamic amount = null ) {
			ByTable RGB1 = null;
			ByTable RGB2 = null;
			bool usealpha = false;
			dynamic r = null;
			dynamic g = null;
			dynamic b = null;
			dynamic alpha = null;
			RGB1 = GlobalFuncs.ReadRGB( rgb1 );
			RGB2 = GlobalFuncs.ReadRGB( rgb2 );
			if ( RGB1.len < RGB2.len ) {
				RGB1 += 255;
			} else if ( RGB2.len < RGB1.len ) {
				RGB2 += 255;
			}
			usealpha = RGB1.len > 3;
			r = Misc13.round( RGB1[1] + ( RGB2[1] - RGB1[1] ) * amount, 1 );
			g = Misc13.round( RGB1[2] + ( RGB2[2] - RGB1[2] ) * amount, 1 );
			b = Misc13.round( RGB1[3] + ( RGB2[3] - RGB1[3] ) * amount, 1 );
			alpha = usealpha ? Misc13.round( RGB1[4] + ( RGB2[4] - RGB1[4] ) * amount, 1 ) : null;
			return alpha == null ? new Color( r, g, b ) : new Color( r, g, b, alpha );
		}

		public static int blood_incompatible( dynamic donor = null, dynamic receiver = null, dynamic donor_species = null, dynamic receiver_species = null ) {
			dynamic donor_antigen = null;
			dynamic receiver_antigen = null;
			bool donor_rh = false;
			bool receiver_rh = false;
			if ( !Misc13.isValid( donor ) || !Misc13.isValid( receiver ) ) {
				return 0;
			}
			if ( Misc13.isValid( donor_species ) && Misc13.isValid( receiver_species ) ) {
				if ( donor_species != receiver_species ) {
					return 1;
				}
			}
			donor_antigen = Misc13.str_sub( donor, 1, donor.Length );
			receiver_antigen = Misc13.str_sub( receiver, 1, receiver.Length );
			donor_rh = Misc13.str_find( donor, "+", 1, null ) > 0;
			receiver_rh = Misc13.str_find( receiver, "+", 1, null ) > 0;
			if ( donor_rh && !receiver_rh ) {
				return 1;
			}
			dynamic _ = receiver_antigen; // Was a switch-case, sorry for the mess.
			if ( _=="A" ) {
				if ( donor_antigen != "A" && donor_antigen != "O" ) {
					return 1;
				}
			} else if ( _=="B" ) {
				if ( donor_antigen != "B" && donor_antigen != "O" ) {
					return 1;
				}
			} else if ( _=="O" ) {
				if ( donor_antigen != "O" ) {
					return 1;
				}
			};
			return 0;
		}

		public static Type blood_splatter( dynamic target = null, Reagent_Blood source = null, dynamic large = null ) {
			Type B = null;
			Type decal_type = null;
			dynamic T = null;
			Reagent_Blood M = null;
			Reagent_Blood donor = null;
			ByTable drips = null;
			dynamic drop = null;
			decal_type = typeof(Ent_Effect_Decal_Cleanable_Blood_Splatter);
			T = GlobalFuncs.get_turf( target );
			if ( source is Mob_Living_Carbon_Human ) {
				M = source;
				source = M.get_blood( M.vessel );
			} else if ( source is Mob_Living_Carbon_Monkey ) {
				donor = source;
				source = new Reagent_Blood();
				source.data["blood_DNA"] = donor.dna.unique_enzymes;
				source.data["blood_type"] = donor.dna.blood_type;
			}
			drips = new ByTable();
			drop = null;
			foreach (dynamic _ in T ) {
				drop = _;
				if ( !( drop is Ent_Effect_Decal_Cleanable_Blood_Drip ) ) {
					continue;
				}
				drips |= drop.drips;
				GlobalFuncs.qdel( drop );
			};
			if ( !Misc13.isValid( large ) && drips.len < 3 ) {
				decal_type = typeof(Ent_Effect_Decal_Cleanable_Blood_Drip);
			}
			B = Misc13.locate_in( decal_type, T );
			if ( B == null ) {
				B = decal_type( T );
			}
			drop = B;
			if ( drop is Ent_Effect_Decal_Cleanable_Blood_Drip && ( drips != null ) && Misc13.isValid( drips.len ) && !Misc13.isValid( large ) ) {
				drop.overlays |= drips;
				drop.drips |= drips;
			}
			if ( source == null ) {
				return B;
			}
			if ( Misc13.isValid( source.data["blood_DNA"] ) ) {
				B.blood_DNA = new ByTable();
				if ( Misc13.isValid( source.data["blood_type"] ) ) {
					B.blood_DNA[source.data["blood_DNA"]] = source.data["blood_type"];
				} else {
					B.blood_DNA[source.data["blood_DNA"]] = "O+";
				}
			}
			return B;
		}

		public static void Broadcast_Message( dynamic AM = null, dynamic vmask = null, dynamic radio = null, string message = null, dynamic name = null, dynamic job = null, dynamic realname = null, dynamic data = null, dynamic compression = null, dynamic level = null, dynamic freq = null, dynamic spans = null, dynamic verb_say = null, dynamic verb_ask = null, dynamic verb_exclaim = null, dynamic verb_yell = null ) {
			ByTable radios = null;
			dynamic virt = null;
			dynamic R = null;
			dynamic freqtext = null;
			ByTable receive = null;
			dynamic M = null;
			string rendered = null;
			dynamic hearer = null;
			string blackbox_msg = null;
			message = Misc13.str_sub( message, 1, 512 );
			if ( !Misc13.isValid( message ) ) {
				return;
			}
			radios = new ByTable();
			virt = GlobalFuncs.PoolOrNew( typeof(Dynamic_Virtualspeaker), null );
			virt.name = name;
			virt.job = job;
			virt.languages = AM.languages;
			virt.source = AM;
			virt.radio = radio;
			virt.verb_say = verb_say;
			virt.verb_ask = verb_ask;
			virt.verb_exclaim = verb_exclaim;
			virt.verb_yell = verb_yell;
			if ( compression > 0 ) {
				message = GlobalFuncs.Gibberish( message, compression + 40 );
			}
			if ( data == 1 ) {
				R = null;
				foreach (dynamic _ in GlobalVars.all_radios["" + freq] ) {
					R = _;
					if ( !( R is Ent_Item_Device_Radio_Intercom ) ) {
						continue;
					}
					if ( R.receive_range( freq, level ) > -1 ) {
						radios += R;
					}
				};
			} else if ( data == 2 ) {
				R = null;
				foreach (dynamic _ in GlobalVars.all_radios["" + freq] ) {
					R = _;
					if ( !( R is Ent_Item_Device_Radio ) ) {
						continue;
					}
					if ( Misc13.isValid( R.subspace_transmission ) ) {
						continue;
					}
					if ( R.receive_range( freq, level ) > -1 ) {
						radios += R;
					}
				};
			} else if ( data == 5 ) {
				R = null;
				foreach (dynamic _ in GlobalVars.all_radios["" + freq] ) {
					R = _;
					if ( !( R is Ent_Item_Device_Radio ) ) {
						continue;
					}
					if ( !Misc13.isValid( R.centcom ) ) {
						continue;
					}
					if ( R.receive_range( freq, level ) > -1 ) {
						radios += R;
					}
				};
			} else {
				R = null;
				foreach (dynamic _ in GlobalVars.all_radios["" + freq] ) {
					R = _;
					if ( !( R is Ent_Item_Device_Radio ) ) {
						continue;
					}
					if ( R.receive_range( freq, level ) > -1 ) {
						radios += R;
					}
				};
				freqtext = Misc13.conv_num2text( freq );
				R = null;
				foreach (dynamic _ in GlobalVars.all_radios["" + GlobalVars.SYND_FREQ] ) {
					R = _;
					if ( !( R is Ent_Item_Device_Radio ) ) {
						continue;
					}
					if ( Misc13.isValid( GlobalVars.radiochannelsreverse.HasValue( R.receive_range( GlobalVars.SYND_FREQ, new ByTable(new object [] {R.z}) ) > -1 && Misc13.isValid( freqtext ) ) ) ) {
						radios |= R;
					}
				};
			}
			receive = GlobalFuncs.get_mobs_in_radio_ranges( radios );
			R = null;
			foreach (dynamic _ in receive ) {
				R = _;
				if ( Misc13.isValid( R.client ) && Misc13.isValid( R.client.holder ) && !Misc13.isValid( R.client.prefs.chat_toggles & 32 ) ) {
					receive -= R;
				}
			};
			M = null;
			foreach (dynamic _ in GlobalVars.player_list ) {
				M = _;
				if ( M is Mob_Dead_Observer && Misc13.isValid( M.client ) && Misc13.isValid( ( M.client.prefs.chat_toggles & 512 ) ) ) {
					receive |= M;
				}
			};
			rendered = virt.compose_message( virt, virt.languages, message, freq, spans );
			hearer = null;
			foreach (dynamic _ in receive ) {
				hearer = _;
				if ( !( hearer is BaseDynamic ) ) {
					continue;
				}
				hearer.Hear( rendered, virt, AM.languages, message, freq, spans );
			};
			if ( Misc13.isValid( receive.Length ) ) {
				blackbox_msg = "" + AM + " " + AM.say_quote( message, spans );
				if ( GlobalVars.blackbox is Ent_Machinery_BlackboxRecorder ) {
					dynamic _ = freq; // Was a switch-case, sorry for the mess.
					if ( _==1459 ) {
						GlobalVars.blackbox.msg_common += blackbox_msg;
					} else if ( _==1351 ) {
						GlobalVars.blackbox.msg_science += blackbox_msg;
					} else if ( _==1353 ) {
						GlobalVars.blackbox.msg_command += blackbox_msg;
					} else if ( _==1355 ) {
						GlobalVars.blackbox.msg_medical += blackbox_msg;
					} else if ( _==1357 ) {
						GlobalVars.blackbox.msg_engineering += blackbox_msg;
					} else if ( _==1359 ) {
						GlobalVars.blackbox.msg_security += blackbox_msg;
					} else if ( _==1441 ) {
						GlobalVars.blackbox.msg_deathsquad += blackbox_msg;
					} else if ( _==1213 ) {
						GlobalVars.blackbox.msg_syndicate += blackbox_msg;
					} else if ( _==1349 ) {
						GlobalVars.blackbox.msg_service += blackbox_msg;
					} else if ( _==1347 ) {
						GlobalVars.blackbox.msg_cargo += blackbox_msg;
					} else {
						GlobalVars.blackbox.messages += blackbox_msg;
					};
				}
			}
			Thread13.schedule( 50, () => {
				GlobalFuncs.qdel( virt );
				return;
			});
		}

		public static void Broadcast_SimpleMessage( dynamic source = null, dynamic frequency = null, dynamic text = null, dynamic data = null, Mob_Living_Carbon_Human M = null, dynamic compression = null, dynamic level = null ) {
			Mob_Living_Carbon_Human H = null;
			dynamic connection = null;
			dynamic display_freq = null;
			ByTable receive = null;
			dynamic R = null;
			dynamic position = null;
			dynamic syndicateconnection = null;
			ByTable heard_normal = null;
			ByTable heard_garbled = null;
			ByTable heard_gibberish = null;
			string part_a = null;
			string freq_text = null;
			string part_b_extra = null;
			Ent_Item_Device_Radio_Headset radio = null;
			dynamic part_b = null;
			string part_c = null;
			string part_blackbox_b = null;
			string blackbox_msg = null;
			string rendered = null;
			string quotedmsg = null;
			if ( M == null ) {
				H = new Mob_Living_Carbon_Human();
				M = H;
			}
			connection = GlobalVars.radio_controller.return_frequency( frequency );
			display_freq = connection.frequency;
			receive = new ByTable();
			if ( data == 1 ) {
				R = null;
				foreach (dynamic _ in connection.devices["" + GlobalVars.RADIO_CHAT] ) {
					R = _;
					if ( !( R is Ent_Item_Device_Radio_Intercom ) ) {
						continue;
					}
					position = GlobalFuncs.get_turf( R );
					if ( Misc13.isValid( position ) && position.z == level ) {
						receive |= R.send_hear( display_freq, level );
					}
				};
			} else if ( data == 2 ) {
				R = null;
				foreach (dynamic _ in connection.devices["" + GlobalVars.RADIO_CHAT] ) {
					R = _;
					if ( !( R is Ent_Item_Device_Radio ) ) {
						continue;
					}
					if ( Misc13.isValid( R.subspace_transmission ) ) {
						continue;
					}
					position = GlobalFuncs.get_turf( R );
					if ( Misc13.isValid( position ) && position.z == level ) {
						receive |= R.send_hear( display_freq );
					}
				};
			} else if ( data == 3 ) {
				syndicateconnection = GlobalVars.radio_controller.return_frequency( GlobalVars.SYND_FREQ );
				R = null;
				foreach (dynamic _ in syndicateconnection.devices["" + GlobalVars.RADIO_CHAT] ) {
					R = _;
					if ( !( R is Ent_Item_Device_Radio ) ) {
						continue;
					}
					position = GlobalFuncs.get_turf( R );
					if ( Misc13.isValid( position ) && position.z == level ) {
						receive |= R.send_hear( GlobalVars.SYND_FREQ );
					}
				};
			} else if ( data == 5 ) {
				R = null;
				foreach (dynamic _ in GlobalVars.all_radios["" + GlobalVars.RADIO_CHAT] ) {
					R = _;
					if ( !( R is Ent_Item_Device_Radio ) ) {
						continue;
					}
					if ( Misc13.isValid( R.centcom ) ) {
						receive |= R.send_hear( GlobalVars.CENTCOM_FREQ );
					}
				};
			} else {
				R = null;
				foreach (dynamic _ in connection.devices["" + GlobalVars.RADIO_CHAT] ) {
					R = _;
					if ( !( R is Ent_Item_Device_Radio ) ) {
						continue;
					}
					position = GlobalFuncs.get_turf( R );
					if ( Misc13.isValid( position ) && position.z == level ) {
						receive |= R.send_hear( display_freq );
					}
				};
			}
			heard_normal = new ByTable();
			heard_garbled = new ByTable();
			heard_gibberish = new ByTable();
			R = null;
			foreach (dynamic _ in receive ) {
				R = _;
				if ( Misc13.isValid( R.client ) && !Misc13.isValid( R.client.prefs.chat_toggles & 32 ) ) {
					continue;
				}
				if ( compression > 0 ) {
					heard_gibberish += R;
					continue;
				}
				if ( Misc13.isValid( ( R.languages & M.languages ) ) ) {
					heard_normal += R;
				} else {
					heard_garbled += R;
				}
			};
			if ( Misc13.isValid( heard_normal.Length ) || Misc13.isValid( heard_garbled.Length ) || Misc13.isValid( heard_gibberish.Length ) ) {
				part_a = "<span class='radio'><span class='name'>";
				freq_text = null;
				dynamic _ = display_freq; // Was a switch-case, sorry for the mess.
				if ( _==1213 ) {
					freq_text = "#unkn";
				} else if ( _==1353 ) {
					freq_text = "Command";
				} else if ( _==1351 ) {
					freq_text = "Science";
				} else if ( _==1355 ) {
					freq_text = "Medical";
				} else if ( _==1357 ) {
					freq_text = "Engineering";
				} else if ( _==1359 ) {
					freq_text = "Security";
				} else if ( _==1349 ) {
					freq_text = "Service";
				} else if ( _==1347 ) {
					freq_text = "Supply";
				} else if ( _==1447 ) {
					freq_text = "AI Private";
				};
				if ( !Misc13.isValid( freq_text ) ) {
					freq_text = GlobalFuncs.format_frequency( display_freq );
				}
				part_b_extra = "";
				if ( data == 3 ) {
					part_b_extra = " <i>(Intercepted)</i>";
				}
				radio = new Ent_Item_Device_Radio_Headset();
				part_b = new Txt( "</span><b> " ).icon( radio ).str( "[" ).item( freq_text ).str( "]" ).item( part_b_extra ).str( "</b> <span class='message'>" );
				part_c = "</span></span>";
				if ( display_freq == GlobalVars.SYND_FREQ ) {
					part_a = "<span class='syndradio'><span class='name'>";
				} else if ( display_freq == GlobalVars.COMM_FREQ ) {
					part_a = "<span class='comradio'><span class='name'>";
				} else if ( display_freq == GlobalVars.SCI_FREQ ) {
					part_a = "<span class='sciradio'><span class='name'>";
				} else if ( display_freq == GlobalVars.MED_FREQ ) {
					part_a = "<span class='medradio'><span class='name'>";
				} else if ( display_freq == GlobalVars.ENG_FREQ ) {
					part_a = "<span class='engradio'><span class='name'>";
				} else if ( display_freq == GlobalVars.SEC_FREQ ) {
					part_a = "<span class='secradio'><span class='name'>";
				} else if ( display_freq == GlobalVars.SERV_FREQ ) {
					part_a = "<span class='servradio'><span class='name'>";
				} else if ( display_freq == GlobalVars.SUPP_FREQ ) {
					part_a = "<span class='suppradio'><span class='name'>";
				} else if ( display_freq == GlobalVars.CENTCOM_FREQ ) {
					part_a = "<span class='centcomradio'><span class='name'>";
				} else if ( display_freq == GlobalVars.AIPRIV_FREQ ) {
					part_a = "<span class='aiprivradio'><span class='name'>";
				}
				part_blackbox_b = "</span><b> [" + freq_text + "]</b> <span class='message'>";
				blackbox_msg = "" + part_a + source + part_blackbox_b + "\"" + text + "\"" + part_c;
				if ( GlobalVars.blackbox is Ent_Machinery_BlackboxRecorder ) {
					dynamic _ = display_freq; // Was a switch-case, sorry for the mess.
					if ( _==1459 ) {
						GlobalVars.blackbox.msg_common += blackbox_msg;
					} else if ( _==1351 ) {
						GlobalVars.blackbox.msg_science += blackbox_msg;
					} else if ( _==1353 ) {
						GlobalVars.blackbox.msg_command += blackbox_msg;
					} else if ( _==1355 ) {
						GlobalVars.blackbox.msg_medical += blackbox_msg;
					} else if ( _==1357 ) {
						GlobalVars.blackbox.msg_engineering += blackbox_msg;
					} else if ( _==1359 ) {
						GlobalVars.blackbox.msg_security += blackbox_msg;
					} else if ( _==1441 ) {
						GlobalVars.blackbox.msg_deathsquad += blackbox_msg;
					} else if ( _==1213 ) {
						GlobalVars.blackbox.msg_syndicate += blackbox_msg;
					} else if ( _==1349 ) {
						GlobalVars.blackbox.msg_service += blackbox_msg;
					} else if ( _==1347 ) {
						GlobalVars.blackbox.msg_cargo += blackbox_msg;
					} else {
						GlobalVars.blackbox.messages += blackbox_msg;
					};
				}
				if ( Misc13.isValid( heard_normal.Length ) ) {
					rendered = "" + part_a + source + part_b + "\"" + text + "\"" + part_c;
					R = null;
					foreach (dynamic _ in heard_normal ) {
						R = _;
						R.show_message( rendered, 2 );
					};
				}
				if ( Misc13.isValid( heard_garbled.Length ) ) {
					quotedmsg = "\"" + GlobalFuncs.stars( text ) + "\"";
					rendered = "" + part_a + source + part_b + quotedmsg + part_c;
					R = null;
					foreach (dynamic _ in heard_garbled ) {
						R = _;
						R.show_message( rendered, 2 );
					};
				}
				if ( Misc13.isValid( heard_gibberish.Length ) ) {
					quotedmsg = "\"" + GlobalFuncs.Gibberish( text, compression + 50 ) + "\"";
					rendered = "" + part_a + GlobalFuncs.Gibberish( source, compression + 50 ) + part_b + quotedmsg + part_c;
					R = null;
					foreach (dynamic _ in heard_gibberish ) {
						R = _;
						R.show_message( rendered, 2 );
					};
				}
			}
		}

		public static void build_click( dynamic user = null, dynamic buildmode = null, dynamic _params = null, dynamic _object = null ) {
			dynamic holder = null;
			dynamic H = null;
			dynamic pa = null;
			dynamic T = null;
			Ent_Structure_Window_Reinforced WIN = null;
			dynamic A = null;
			dynamic G = null;
			holder = null;
			H = null;
			foreach (dynamic _ in Game ) {
				H = _;
				if ( !( H is Ent_Effect_Bmode_Buildholder ) ) {
					continue;
				}
				if ( H.cl == user.client ) {
					holder = H;
					break;
				}
			};
			if ( !Misc13.isValid( holder ) ) {
				return;
			}
			pa = Misc13.conv_params2list( _params );
			if ( _object is Ent_Effect_Bmode ) {
				return;
			}
			dynamic _ = buildmode; // Was a switch-case, sorry for the mess.
			if ( _==1 ) {
				if ( _object is Tile && Misc13.isValid( pa.Find( "left" ) ) && !Misc13.isValid( pa.Find( "alt" ) ) && !Misc13.isValid( pa.Find( "ctrl" ) ) ) {
					T = _object;
					if ( _object is Tile_Space ) {
						T.ChangeTurf( typeof(Tile_Simulated_Floor_Plasteel) );
					} else if ( _object is Tile_Simulated_Floor ) {
						T.ChangeTurf( typeof(Tile_Simulated_Wall) );
					} else if ( _object is Tile_Simulated_Wall ) {
						T.ChangeTurf( typeof(Tile_Simulated_Wall_RWall) );
					}
					GlobalFuncs.log_admin( "Build Mode: " + GlobalFuncs.key_name( Misc13.thread_user ) + " built " + T + " at (" + T.x + "," + T.y + "," + T.z + ")" );
					return;
				} else if ( Misc13.isValid( pa.Find( "right" ) ) ) {
					GlobalFuncs.log_admin( "Build Mode: " + GlobalFuncs.key_name( Misc13.thread_user ) + " deleted " + _object + " at (" + _object.x + "," + _object.y + "," + _object.z + ")" );
					if ( _object is Tile_Simulated_Wall ) {
						T = _object;
						T.ChangeTurf( typeof(Tile_Simulated_Floor_Plasteel) );
					} else if ( _object is Tile_Simulated_Floor ) {
						T = _object;
						T.ChangeTurf( typeof(Tile_Space) );
					} else if ( _object is Tile_Simulated_Wall_RWall ) {
						T = _object;
						T.ChangeTurf( typeof(Tile_Simulated_Wall) );
					} else if ( _object is Entity ) {
						GlobalFuncs.qdel( _object );
					}
					return;
				} else if ( _object is Tile && Misc13.isValid( T.Find( "alt" ) ) && Misc13.isValid( T.Find( "left" ) ) ) {
					GlobalFuncs.log_admin( "Build Mode: " + GlobalFuncs.key_name( Misc13.thread_user ) + " built an airlock at (" + _object.x + "," + _object.y + "," + _object.z + ")" );
					new Ent_Machinery_Door_Airlock( GlobalFuncs.get_turf( _object ) );
				} else if ( _object is Tile && Misc13.isValid( pa.Find( "ctrl" ) ) && Misc13.isValid( pa.Find( "left" ) ) ) {
					dynamic _ = holder.builddir.dir; // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						WIN = new Ent_Structure_Window_Reinforced( GlobalFuncs.get_turf( _object ) );
						WIN.dir = GlobalVars.NORTH;
					} else if ( _==2 ) {
						WIN = new Ent_Structure_Window_Reinforced( GlobalFuncs.get_turf( _object ) );
						WIN.dir = GlobalVars.SOUTH;
					} else if ( _==4 ) {
						WIN = new Ent_Structure_Window_Reinforced( GlobalFuncs.get_turf( _object ) );
						WIN.dir = GlobalVars.EAST;
					} else if ( _==8 ) {
						WIN = new Ent_Structure_Window_Reinforced( GlobalFuncs.get_turf( _object ) );
						WIN.dir = GlobalVars.WEST;
					} else if ( _==9 ) {
						WIN = new Ent_Structure_Window_Reinforced( GlobalFuncs.get_turf( _object ) );
						WIN.dir = GlobalVars.NORTHWEST;
					};
					GlobalFuncs.log_admin( "Build Mode: " + GlobalFuncs.key_name( Misc13.thread_user ) + " built a window at (" + _object.x + "," + _object.y + "," + _object.z + ")" );
				}
			} else if ( _==2 ) {
				if ( Misc13.isValid( pa.Find( "left" ) ) ) {
					if ( Misc13.isValid( holder.buildmode.objholder isxx typeof(Tile) ) ) {
						T = GlobalFuncs.get_turf( _object );
						GlobalFuncs.log_admin( "Build Mode: " + GlobalFuncs.key_name( Misc13.thread_user ) + " modified " + T + " (" + T.x + "," + T.y + "," + T.z + ") to " + holder.buildmode.objholder );
						T.ChangeTurf( holder.buildmode.objholder );
					} else {
						A = T.objholder( GlobalFuncs.get_turf( _object ) );
						A.dir = holder.builddir.dir;
						GlobalFuncs.log_admin( "Build Mode: " + GlobalFuncs.key_name( Misc13.thread_user ) + " modified " + A + "'s (" + A.x + "," + A.y + "," + A.z + ") dir to " + holder.builddir.dir );
					}
				} else if ( Misc13.isValid( holder.Find( "right" ) ) ) {
					if ( _object is Ent ) {
						GlobalFuncs.log_admin( "Build Mode: " + GlobalFuncs.key_name( Misc13.thread_user ) + " deleted " + _object + " at (" + _object.x + "," + _object.y + "," + _object.z + ")" );
						GlobalFuncs.qdel( _object );
					}
				}
			} else if ( _==3 ) {
				if ( Misc13.isValid( pa.Find( "left" ) ) ) {
					if ( Misc13.isValid( _object.vars.Find( holder.buildmode.varholder ) ) ) {
						GlobalFuncs.log_admin( "Build Mode: " + GlobalFuncs.key_name( Misc13.thread_user ) + " modified " + _object.name + "'s " + holder.buildmode.varholder + " to " + holder.valueholder );
						_object.vars[holder.buildmode.varholder] = holder.buildmode.valueholder;
					} else {
						Misc13.thread_user.write( "<span class='warning'>" + Misc13.initial( _object.name ) + " does not have a var called '" + holder.buildmode.varholder + "'</span>" );
					}
				}
				if ( Misc13.isValid( pa.Find( "right" ) ) ) {
					if ( Misc13.isValid( _object.vars.Find( holder.buildmode.varholder ) ) ) {
						GlobalFuncs.log_admin( "Build Mode: " + GlobalFuncs.key_name( Misc13.thread_user ) + " modified " + _object.name + "'s " + holder.buildmode.varholder + " to " + holder.valueholder );
						_object.vars[holder.buildmode.varholder] = Misc13.initial( _object.vars[holder.buildmode.varholder] );
					} else {
						Misc13.thread_user.write( "<span class='warning'>" + Misc13.initial( _object.name ) + " does not have a var called '" + holder.buildmode.varholder + "'</span>" );
					}
				}
			} else if ( _==4 ) {
				if ( Misc13.isValid( pa.Find( "left" ) ) ) {
					if ( _object is Tile ) {
						return;
					}
					holder.throw_atom = _object;
				}
				if ( Misc13.isValid( pa.Find( "right" ) ) ) {
					if ( Misc13.isValid( holder.throw_atom ) ) {
						holder.throw_atom.throw_at( _object, 10, 1, user );
						GlobalFuncs.log_admin( "Build Mode: " + GlobalFuncs.key_name( Misc13.thread_user ) + " threw " + holder.throw_atom + " at " + _object + " (" + _object.x + "," + _object.y + "," + _object.z + ")" );
					}
				}
			} else if ( _==5 ) {
				if ( !Misc13.isValid( holder.cornerA ) ) {
					holder.cornerA = GlobalFuncs.get_turf( _object );
					return;
				}
				if ( Misc13.isValid( holder.cornerA ) && !Misc13.isValid( holder.cornerB ) ) {
					holder.cornerB = GlobalFuncs.get_turf( _object );
				}
				if ( Misc13.isValid( pa.Find( "left" ) ) ) {
					if ( Misc13.isValid( holder.cornerA ) && Misc13.isValid( holder.cornerB ) ) {
						if ( !Misc13.isValid( holder.generator_path ) ) {
							Misc13.thread_user.write( "<span class='warning'>Select generator type first.</span>" );
						}
						G = holder.generator_path();
						G.defineRegion( holder.cornerA, holder.cornerB, 1 );
						G.generate();
						holder.cornerA = null;
						holder.cornerB = null;
						return;
					}
				}
				holder.cornerA = null;
				holder.cornerB = null;
			};
		}

		public static int calculate_adjacencies( dynamic A = null ) {
			int adjacencies = 0;
			dynamic AM = null;
			dynamic direction = null;
			if ( !Misc13.isValid( A.loc ) ) {
				return 0;
			}
			adjacencies = 0;
			if ( Misc13.isValid( A.can_be_unanchored ) ) {
				AM = A;
				if ( !Misc13.isValid( AM.anchored ) ) {
					return 0;
				}
				direction = null;
				foreach (dynamic _ in GlobalVars.alldirs ) {
					direction = _;
					AM = GlobalFuncs.find_type_in_direction( A, direction );
					if ( AM is BaseDynamic ) {
						if ( Misc13.isValid( AM.anchored ) ) {
							adjacencies |= GlobalFuncs.transform_dir( direction );
						}
					} else if ( Misc13.isValid( AM ) ) {
						adjacencies |= GlobalFuncs.transform_dir( direction );
					}
				};
			} else {
				direction = null;
				foreach (dynamic _ in GlobalVars.alldirs ) {
					direction = _;
					if ( Misc13.isValid( GlobalFuncs.find_type_in_direction( A, direction ) ) ) {
						adjacencies |= GlobalFuncs.transform_dir( direction );
					}
				};
			}
			return adjacencies;
		}

		public static string CallMaterialName( dynamic ID = null ) {
			dynamic temp_reagent = null;
			string return_name = null;
			dynamic R = null;
			return_name = null;
			if ( Misc13.str_sub( ID, 1, 2 ) == "$" ) {
				return_name = Misc13.str_sub( ID, 2, null );
				dynamic _ = return_name; // Was a switch-case, sorry for the mess.
				if ( _=="metal" ) {
					return_name = "Metal";
				} else if ( _=="glass" ) {
					return_name = "Glass";
				} else if ( _=="gold" ) {
					return_name = "Gold";
				} else if ( _=="silver" ) {
					return_name = "Silver";
				} else if ( _=="plasma" ) {
					return_name = "Solid Plasma";
				} else if ( _=="uranium" ) {
					return_name = "Uranium";
				} else if ( _=="diamond" ) {
					return_name = "Diamond";
				} else if ( _=="clown" ) {
					return_name = "Bananium";
				};
			} else {
				R = null;
				foreach (dynamic _ in Misc13.types( typeof(Reagent) ) - typeof(Reagent) ) {
					R = _;
					temp_reagent = null;
					temp_reagent = R();
					if ( temp_reagent.id == ID ) {
						return_name = temp_reagent.name;
						GlobalFuncs.qdel( temp_reagent );
						temp_reagent = null;
						break;
					}
				};
			}
			return return_name;
		}

		public static dynamic CallTechName( dynamic ID = null ) {
			dynamic check_tech = null;
			dynamic return_name = null;
			dynamic T = null;
			return_name = null;
			T = null;
			foreach (dynamic _ in Misc13.types( typeof(Tech) ) - typeof(Tech) ) {
				T = _;
				check_tech = null;
				check_tech = T();
				if ( check_tech.id == ID ) {
					return_name = check_tech.name;
					GlobalFuncs.qdel( check_tech );
					check_tech = null;
					break;
				}
			};
			return return_name;
		}

		public static dynamic camera_sort( dynamic L = null ) {
			dynamic a = null;
			dynamic b = null;
			dynamic i = null;
			dynamic j = null;
			i = null;
			i = L.len;
			while (i > 0) {
				j = null;
				foreach (dynamic _ in Misc13.iter_range( 1, i - 1 ) ) {
					j = _;
					a = L[j];
					b = L[j + 1];
					if ( a.c_tag_order != b.c_tag_order ) {
						if ( a.c_tag_order > b.c_tag_order ) {
							L.Swap( j, j + 1 );
						}
					} else if ( Misc13.string_order( a.c_tag, b.c_tag ) < 0 ) {
						L.Swap( j, j + 1 );
					}
				};
				i--;
			}
			return L;
		}

		public static int can_embed( dynamic W = null ) {
			ByTable embed_items = null;
			if ( Misc13.isValid( W.is_sharp() ) ) {
				return 1;
			}
			if ( GlobalFuncs.is_pointed( W ) != 0 ) {
				return 1;
			}
			embed_items = new ByTable(new object [] {typeof(Ent_Item_Stack_Rods)});
			if ( GlobalFuncs.is_type_in_list( W, embed_items ) != 0 ) {
				return 1;
			}
		}

		public static int can_see( dynamic source = null, dynamic target = null, int length = 0 ) {
			dynamic current = null;
			dynamic target_turf = null;
			int steps = 0;
			dynamic A = null;
			if ( length == null ) {
				length = 5;
			}
			current = GlobalFuncs.get_turf( source );
			target_turf = GlobalFuncs.get_turf( target );
			steps = 0;
			while (current != target_turf) {
				if ( steps > length ) {
					return 0;
				}
				if ( Misc13.isValid( current.opacity ) ) {
					return 0;
				}
				A = null;
				foreach (dynamic _ in current ) {
					A = _;
					if ( !( A is BaseStatic ) ) {
						continue;
					}
					if ( Misc13.isValid( A.opacity ) ) {
						return 0;
					}
				};
				current = Misc13.get_step_towards( current, target_turf );
				steps++;
			}
			return 1;
		}

		public static void cancel_progress_bar( dynamic user = null, dynamic progbar = null ) {
			if ( Misc13.isValid( user ) && Misc13.isValid( user.client ) && Misc13.isValid( progbar ) ) {
				user.client.images -= progbar;
			}
		}

		public static int CanHug( dynamic M = null ) {
			dynamic C = null;
			dynamic H = null;
			if ( !( M is Mob_Living ) ) {
				return 0;
			}
			if ( M.stat == 2 ) {
				return 0;
			}
			if ( Misc13.isValid( M.getorgan( typeof(Ent_Item_Organ_Internal_Alien_Hivenode) ) ) ) {
				return 0;
			}
			if ( M is Mob_Living_SimpleAnimal_Pet_Dog_Corgi || M is Mob_Living_Carbon_Monkey ) {
				return 1;
			}
			C = M;
			if ( C is Mob_Living_Carbon_Human ) {
				H = C;
				if ( Misc13.isValid( H.is_mouth_covered.BTCall( new ByTable().set( "head_only", 1 ) ) ) ) {
					return 0;
				}
				return 1;
			}
			return 0;
		}

		public static dynamic capitalize( dynamic t = null ) {
			return Misc13.str_upper( Misc13.str_sub( t, 1, 2 ) ) + Misc13.str_sub( t, 2, null );
		}

		public static ByTable cardinalrange( dynamic center = null ) {
			ByTable things = null;
			dynamic direction = null;
			dynamic T = null;
			things = new ByTable();
			direction = null;
			foreach (dynamic _ in GlobalVars.cardinal ) {
				direction = _;
				T = Misc13.get_step( center, direction );
				if ( !Misc13.isValid( T ) ) {
					continue;
				}
				things += T.contents;
			};
			return things;
		}

		public static dynamic Ceiling( dynamic x = null ) {
			return -Misc13.round( -x );
		}

		public static void Centcomm_announce( dynamic text = null, dynamic Sender = null ) {
			dynamic msg = null;
			msg = Misc13.str_sub( GlobalFuncs.sanitize( text ), 1, 1024 );
			msg = new Txt( "<span class='adminnotice'><b><font color=orange>CENTCOM:</font>" ).item( GlobalFuncs.key_name_admin( Sender ) ).str( " (<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( Sender ).str( "'>?</A>) (<A HREF='?_src_=holder;adminplayeropts=" ).Ref( Sender ).str( "'>PP</A>) (<A HREF='?_src_=vars;Vars=" ).Ref( Sender ).str( "'>VV</A>) (<A HREF='?_src_=holder;subtlemessage=" ).Ref( Sender ).str( "'>SM</A>) (<A HREF='?_src_=holder;adminplayerobservefollow=" ).Ref( Sender ).str( "'>FLW</A>) (<A HREF='?_src_=holder;traitor=" ).Ref( Sender ).str( "'>TP</A>) (<A HREF='?_src_=holder;BlueSpaceArtillery=" ).Ref( Sender ).str( "'>BSA</A>) (<A HREF='?_src_=holder;CentcommReply=" ).Ref( Sender ).str( "'>RPLY</A>):</b> " ).item( msg ).str( "</span>" );
			GlobalVars.admins.write( msg );
		}

		public static dynamic center_image( dynamic I = null, int x_dimension = 0, int y_dimension = 0 ) {
			int x_offset = 0;
			int y_offset = 0;
			if ( x_dimension == null ) {
				x_dimension = 0;
			}
			if ( y_dimension == null ) {
				y_dimension = 0;
			}
			if ( !Misc13.isValid( I ) ) {
				return null;
			}
			if ( ( x_dimension == 0 ) || ( y_dimension == 0 ) ) {
				return null;
			}
			if ( x_dimension == Game.icon_size && y_dimension == Game.icon_size ) {
				return I;
			}
			x_offset = -( x_dimension / Game.icon_size - 1 ) * Game.icon_size * 0.5;
			y_offset = -( y_dimension / Game.icon_size - 1 ) * Game.icon_size * 0.5;
			if ( x_dimension < Game.icon_size ) {
				x_offset *= -1;
			}
			if ( y_dimension < Game.icon_size ) {
				y_offset *= -1;
			}
			I.pixel_x = x_offset;
			I.pixel_y = y_offset;
			return I;
		}

		public static void changeling_transform( dynamic user = null, dynamic chosen_prof = null ) {
			dynamic chosen_dna = null;
			dynamic slot = null;
			dynamic C = null;
			int equip = 0;
			dynamic thetype = null;
			chosen_dna = chosen_prof.dna;
			user.real_name = chosen_prof.name;
			user.underwear = chosen_prof.underwear;
			user.undershirt = chosen_prof.undershirt;
			user.socks = chosen_prof.socks;
			chosen_dna.transfer_identity( user, 1 );
			user.updateappearance.BTCall( new ByTable().set( "mutcolor_update", 1 ) );
			user.update_body();
			user.domutcheck();
			slot = null;
			foreach (dynamic _ in GlobalVars.slots ) {
				slot = _;
				if ( Misc13.isValid( GlobalVars.slot2type[slot].IsInstanceOfType( user.vars[slot] ) ) && !Misc13.isValid( chosen_prof.exists_list[slot] ) ) {
					GlobalFuncs.qdel( user.vars[slot] );
					continue;
				}
				if ( Misc13.isValid( user.vars[slot] ) && !Misc13.isValid( GlobalVars.slot2type[slot].IsInstanceOfType( user.vars[slot] ) ) || !Misc13.isValid( chosen_prof.exists_list[slot] ) ) {
					continue;
				}
				C = null;
				equip = 0;
				if ( !Misc13.isValid( user.vars[slot] ) ) {
					thetype = GlobalVars.slot2type[slot];
					equip = 1;
					C = thetype( user );
				} else if ( Misc13.isValid( GlobalVars.slot2type[slot].IsInstanceOfType( user.vars[slot] ) ) ) {
					C = user.vars[slot];
				}
				C.appearance = chosen_prof.appearance_list[slot];
				C.name = chosen_prof.name_list[slot];
				C.flags_cover = chosen_prof.flags_cover_list[slot];
				C.item_color = chosen_prof.item_color_list[slot];
				C.item_state = chosen_prof.item_state_list[slot];
				if ( equip != 0 ) {
					user.equip_to_slot_or_del( C, GlobalVars.slot2slot[slot] );
				}
			};
			user.regenerate_icons();
		}

		public static dynamic changemap( dynamic VM = null ) {
			dynamic _default = null;
			File file = null;
			return null;
			if ( !( VM is Votablemap ) ) {
				return null;
			}
			GlobalFuncs.log_game( "Changing map to " + VM.name + "(" + VM.friendlyname + ")" );
			file = new File( "setnewmap.bat" );
			file.write( "\nset MAPROTATE=" + VM.name + "\n" );
			_default = Misc13.shell( "..\\bin\\maprotate.bat" );
			dynamic _ = _default; // Was a switch-case, sorry for the mess.
			if ( _==null ) {
				GlobalFuncs.message_admins( "Failed to change map: Could not run map rotator" );
				GlobalFuncs.log_game( "Failed to change map: Could not run map rotator" );
			} else if ( _==0 ) {
				GlobalFuncs.log_game( "Changed to map " + VM.friendlyname );
				GlobalVars.nextmap = VM;
			} else if ( _==11 ) {
				GlobalFuncs.message_admins( "Failed to change map: File error: Map rotator script couldn't find file listing new map" );
				GlobalFuncs.log_game( "Failed to change map: File error: Map rotator script couldn't find file listing new map" );
			} else if ( _==12 ) {
				GlobalFuncs.message_admins( "Failed to change map: File error: Map rotator script couldn't find tgstation-server framework" );
				GlobalFuncs.log_game( "Failed to change map: File error: Map rotator script couldn't find tgstation-server framework" );
			} else if ( _==21 ) {
				GlobalFuncs.message_admins( "Failed to change map: Conflicting operation error: Current server update operation detected" );
				GlobalFuncs.log_game( "Failed to change map: Conflicting operation error: Current server update operation detected" );
			} else if ( _==22 ) {
				GlobalFuncs.message_admins( "Failed to change map: Conflicting operation error: Current map rotation operation detected" );
				GlobalFuncs.log_game( "Failed to change map: Conflicting operation error: Current map rotation operation detected" );
			} else if ( _==31 ) {
				GlobalFuncs.message_admins( "Failed to change map: External error: Could not compile new map:" + VM.name );
				GlobalFuncs.log_game( "Failed to change map: External error: Could not compile new map:" + VM.name );
			} else {
				GlobalFuncs.message_admins( "Failed to change map: Unknown error: Error code #" + _default );
				GlobalFuncs.log_game( "Failed to change map: Unknown error: Error code #" + _default );
			};
			return _default;
		}

		public static dynamic cheap_hypotenuse( dynamic Ax = null, dynamic Ay = null, dynamic Bx = null, dynamic By = null ) {
			return Math.Sqrt( Math.Pow( Math.abs( Ax - Bx ), 2 ) + Math.Pow( Math.abs( Ay - By ), 2 ) );
		}

		public static int check_if_greater_rights_than( dynamic other = null ) {
			if ( Misc13.isValid( Misc13.thread_user ) && Misc13.isValid( Misc13.thread_user.client ) ) {
				if ( Misc13.isValid( Misc13.thread_user.client.holder ) ) {
					if ( !Misc13.isValid( other ) || !Misc13.isValid( other.holder ) ) {
						return 1;
					}
					return Misc13.thread_user.client.holder.check_if_greater_rights_than_holder( other.holder );
				}
			}
			return 0;
		}

		public static int check_rights( dynamic rights_required = null, int show_msg = 0 ) {
			if ( show_msg == null ) {
				show_msg = 1;
			}
			if ( Misc13.isValid( Misc13.thread_user ) && Misc13.isValid( Misc13.thread_user.client ) ) {
				if ( GlobalFuncs.check_rights_for( Misc13.thread_user.client, rights_required ) != 0 ) {
					return 1;
				} else if ( show_msg != 0 ) {
					Misc13.thread_user.write( "<font color='red'>Error: You do not have sufficient rights to do that. You require one of the following flags:" + GlobalFuncs.rights2text( rights_required, " " ) + ".</font>" );
				}
			}
			return 0;
		}

		public static int check_rights_for( dynamic subject = null, dynamic rights_required = null ) {
			if ( Misc13.isValid( subject ) && Misc13.isValid( subject.holder ) && Misc13.isValid( subject.holder.rank ) ) {
				if ( Misc13.isValid( rights_required ) && !Misc13.isValid( rights_required & subject.holder.rank.rights ) ) {
					return 0;
				}
				return 1;
			}
			return 0;
		}

		public static int check_tank_exists( dynamic parent_tank = null, dynamic M = null, dynamic O = null ) {
			if ( !Misc13.isValid( parent_tank ) || !( parent_tank is Ent_Item_Weapon_Watertank ) ) {
				M.unEquip( O );
				GlobalFuncs.qdel( 0 );
				return 0;
			} else {
				return 1;
			}
		}

		public static string check_zone( string zone = null ) {
			if ( !Misc13.isValid( zone ) ) {
				return "chest";
			}
			dynamic _ = zone; // Was a switch-case, sorry for the mess.
			if ( _=="eyes" ) {
				zone = "head";
			} else if ( _=="mouth" ) {
				zone = "head";
			} else if ( _=="l_hand" ) {
				zone = "l_arm";
			} else if ( _=="r_hand" ) {
				zone = "r_arm";
			} else if ( _=="l_foot" ) {
				zone = "l_leg";
			} else if ( _=="r_foot" ) {
				zone = "r_leg";
			} else if ( _=="groin" ) {
				zone = "chest";
			};
			return zone;
		}

		public static void chemscan( dynamic user = null, dynamic M = null ) {
			dynamic H = null;
			dynamic R = null;
			if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				if ( Misc13.isValid( H.reagents ) ) {
					if ( Misc13.isValid( H.reagents.reagent_list.len ) ) {
						user.write( "<span class='notice'>Subject contains the following reagents:</span>" );
						R = null;
						foreach (dynamic _ in H.reagents.reagent_list ) {
							R = _;
							if ( !( R is Reagent ) ) {
								continue;
							}
							user.write( "<span class='notice'>" + R.volume + " units of " + R.name + ( R.overdosed == 1 ? "</span> - <span class='boldannounce'>OVERDOSING</span>" : ".</span>" ) );
						};
					} else {
						user.write( "<span class='notice'>Subject contains no reagents.</span>" );
					}
					if ( Misc13.isValid( H.reagents.addiction_list.len ) ) {
						user.write( "<span class='boldannounce'>Subject is addicted to the following reagents:</span>" );
						R = null;
						foreach (dynamic _ in H.reagents.addiction_list ) {
							R = _;
							if ( !( R is Reagent ) ) {
								continue;
							}
							user.write( "<span class='danger'>" + R.name + "</span>" );
						};
					} else {
						user.write( "<span class='notice'>Subject is not addicted to any reagents.</span>" );
					}
				}
			}
		}

		public static ByTable circlerange( dynamic center = null, int radius = 0 ) {
			dynamic centerturf = null;
			ByTable turfs = null;
			int rsq = 0;
			dynamic T = null;
			dynamic dx = null;
			dynamic dy = null;
			if ( center == null ) {
				center = Misc13.thread_user;
			}
			if ( radius == null ) {
				radius = 3;
			}
			centerturf = GlobalFuncs.get_turf( center );
			turfs = new ByTable();
			rsq = radius * ( radius + 0.5 );
			T = null;
			foreach (dynamic _ in Misc13.range( radius, centerturf ) ) {
				T = _;
				if ( !( T is BaseStatic ) ) {
					continue;
				}
				dx = T.x - centerturf.x;
				dy = T.y - centerturf.y;
				if ( dx * dx + dy * dy <= rsq ) {
					turfs += T;
				}
			};
			return turfs;
		}

		public static ByTable circlerangeturfs( dynamic center = null, int radius = 0 ) {
			dynamic centerturf = null;
			ByTable turfs = null;
			int rsq = 0;
			dynamic T = null;
			dynamic dx = null;
			dynamic dy = null;
			if ( center == null ) {
				center = Misc13.thread_user;
			}
			if ( radius == null ) {
				radius = 3;
			}
			centerturf = GlobalFuncs.get_turf( center );
			turfs = new ByTable();
			rsq = radius * ( radius + 0.5 );
			T = null;
			foreach (dynamic _ in Misc13.range( radius, centerturf ) ) {
				T = _;
				dx = T.x - centerturf.x;
				dy = T.y - centerturf.y;
				if ( dx * dx + dy * dy <= rsq ) {
					turfs += T;
				}
			};
			return turfs;
		}

		public static dynamic Clamp( dynamic val = null, dynamic min = null, dynamic max = null ) {
			return Misc13.max( min, Misc13.min( val, max ) );
		}

		public static void clearlist( dynamic list = null ) {
			if ( Misc13.isValid( ByTable.IsInstanceOfType( list ) ) ) {
				list.len = 0;
			}
			return;
		}

		public static void closeToolTip( dynamic user = null ) {
			if ( user is Mob ) {
				if ( Misc13.isValid( user.client ) && Misc13.isValid( user.client.tooltips ) ) {
					user.client.tooltips.hide();
				}
			}
		}

		public static void cmd_admin_mute( dynamic whom = null, dynamic mute_type = null, int automute = 0 ) {
			string muteunmute = null;
			string mute_string = null;
			dynamic C = null;
			dynamic P = null;
			if ( automute == null ) {
				automute = 0;
			}
			if ( !Misc13.isValid( whom ) ) {
				return;
			}
			dynamic _ = mute_type; // Was a switch-case, sorry for the mess.
			if ( _==1 ) {
				mute_string = "IC (say and emote)";
			} else if ( _==2 ) {
				mute_string = "OOC";
			} else if ( _==4 ) {
				mute_string = "pray";
			} else if ( _==8 ) {
				mute_string = "adminhelp, admin PM and ASAY";
			} else if ( _==16 ) {
				mute_string = "deadchat and DSAY";
			} else if ( _==31 ) {
				mute_string = "everything";
			} else {
				return;
			};
			C = null;
			if ( Misc13.isValid( BAD_GOOFY_EXPANSION???.IsInstanceOfType( whom ) ) ) {
				C = whom;
			} else if ( whom is string ) {
				C = GlobalVars.directory[whom];
			} else {
				return;
			}
			P = null;
			if ( Misc13.isValid( C ) ) {
				P = C.prefs;
			} else {
				P = GlobalVars.preferences_datums[whom];
			}
			if ( !Misc13.isValid( P ) ) {
				return;
			}
			if ( automute != 0 ) {
				if ( !Misc13.isValid( GlobalVars.config.automute_on ) ) {
					return;
				}
			} else if ( GlobalFuncs.check_rights() == 0 ) {
				return;
			}
			if ( automute != 0 ) {
				muteunmute = "auto-muted";
				P.muted |= mute_type;
				GlobalFuncs.log_admin( "SPAM AUTOMUTE: " + muteunmute + " " + GlobalFuncs.key_name( whom ) + " from " + mute_string );
				GlobalFuncs.message_admins( "SPAM AUTOMUTE: " + muteunmute + " " + GlobalFuncs.key_name_admin( whom ) + " from " + mute_string + "." );
				if ( Misc13.isValid( C ) ) {
					C.write( "You have been " + muteunmute + " from " + mute_string + " by the SPAM AUTOMUTE system. Contact an admin." );
				}
				GlobalFuncs.feedback_add_details( "admin_verb", "AUTOMUTE" );
				return;
			}
			if ( Misc13.isValid( ( P.muted & mute_type ) ) ) {
				muteunmute = "unmuted";
				P.muted &= ~mute_type;
			} else {
				muteunmute = "muted";
				P.muted |= mute_type;
			}
			GlobalFuncs.log_admin( "" + GlobalFuncs.key_name( Misc13.thread_user ) + " has " + muteunmute + " " + GlobalFuncs.key_name( whom ) + " from " + mute_string );
			GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( Misc13.thread_user ) + " has " + muteunmute + " " + GlobalFuncs.key_name_admin( whom ) + " from " + mute_string + "." );
			if ( Misc13.isValid( C ) ) {
				C.write( "You have been " + muteunmute + " from " + mute_string + "." );
			}
			GlobalFuncs.feedback_add_details( "admin_verb", "MUTE" );
		}

		public static dynamic cmp_abilities_cost( dynamic a = null, dynamic b = null ) {
			return b.plasma_cost - a.plasma_cost;
		}

		public static dynamic cmp_ckey_asc( dynamic a = null, dynamic b = null ) {
			return Misc13.string_order( b.ckey, a.ckey );
		}

		public static dynamic cmp_ckey_dsc( dynamic a = null, dynamic b = null ) {
			return Misc13.string_order( a.ckey, b.ckey );
		}

		public static dynamic cmp_name_asc( dynamic a = null, dynamic b = null ) {
			return Misc13.string_order( b.name, a.name );
		}

		public static dynamic cmp_name_dsc( dynamic a = null, dynamic b = null ) {
			return Misc13.string_order( a.name, b.name );
		}

		public static dynamic cmp_numeric_asc( dynamic a = null, dynamic b = null ) {
			return a - b;
		}

		public static dynamic cmp_records_asc( dynamic a = null, dynamic b = null ) {
			return Misc13.string_order( b.fields[GlobalVars.cmp_field], a.fields[GlobalVars.cmp_field] );
		}

		public static dynamic cmp_records_dsc( dynamic a = null, dynamic b = null ) {
			return Misc13.string_order( a.fields[GlobalVars.cmp_field], b.fields[GlobalVars.cmp_field] );
		}

		public static dynamic cmp_rped_sort( dynamic A = null, dynamic B = null ) {
			return B.rating - A.rating;
		}

		public static dynamic cmp_subsystem_priority( dynamic a = null, dynamic b = null ) {
			return b.priority - a.priority;
		}

		public static dynamic cmp_text_asc( dynamic a = null, dynamic b = null ) {
			return Misc13.string_order( b, a );
		}

		public static string color2hex( dynamic color = null ) {
			if ( !Misc13.isValid( color ) ) {
				return "#000000";
			}
			dynamic _ = color; // Was a switch-case, sorry for the mess.
			if ( _=="white" ) {
				return "#FFFFFF";
			} else if ( _=="black" ) {
				return "#000000";
			} else if ( _=="gray" ) {
				return "#808080";
			} else if ( _=="brown" ) {
				return "#A52A2A";
			} else if ( _=="red" ) {
				return "#FF0000";
			} else if ( _=="darkred" ) {
				return "#8B0000";
			} else if ( _=="crimson" ) {
				return "#DC143C";
			} else if ( _=="orange" ) {
				return "#FFA500";
			} else if ( _=="yellow" ) {
				return "#FFFF00";
			} else if ( _=="green" ) {
				return "#008000";
			} else if ( _=="lime" ) {
				return "#00FF00";
			} else if ( _=="darkgreen" ) {
				return "#006400";
			} else if ( _=="cyan" ) {
				return "#00FFFF";
			} else if ( _=="blue" ) {
				return "#0000FF";
			} else if ( _=="navy" ) {
				return "#000080";
			} else if ( _=="teal" ) {
				return "#008080";
			} else if ( _=="purple" ) {
				return "#800080";
			} else if ( _=="indigo" ) {
				return "#4B0082";
			} else {
				return "#FFFFFF";
			};
		}

		public static string command_name(  ) {
			string name = null;
			if ( Misc13.isValid( GlobalVars.command_name ) ) {
				return GlobalVars.command_name;
			}
			name = "Central Command";
			GlobalVars.command_name = name;
			return name;
		}

		public static string construct_block( int value = 0, dynamic values = null, int blocksize = 0 ) {
			dynamic width = null;
			if ( blocksize == null ) {
				blocksize = 3;
			}
			width = Misc13.round( Math.Pow( 16, blocksize ) / values );
			if ( value < 1 ) {
				value = 1;
			}
			value = value * width - Rand.Int( 1, width );
			return GlobalFuncs.num2hex( value, blocksize );
		}

		public static void convert_notes_sql( dynamic ckey = null ) {
			SaveFile notesfile = null;
			dynamic notetext = null;
			dynamic server = null;
			string regex = null;
			Regex results = null;
			dynamic timestamp = null;
			dynamic adminckey = null;
			DBQuery query_convert_time = null;
			dynamic err = null;
			notesfile = new SaveFile( "data/player_notes.sav" );
			if ( notesfile == null ) {
				GlobalFuncs.log_game( "Error: Cannot access " + "data/player_notes.sav" );
				return;
			}
			notesfile.cd = "/" + ckey;
			while (!Misc13.isValid( notesfile.eof )) {
				notetext = null;
				notetext = notesfile.read();
				server = null;
				if ( Misc13.isValid( GlobalVars.config ) && Misc13.isValid( GlobalVars.config.server_name ) ) {
					server = GlobalVars.config.server_name;
				}
				regex = "^(\\d{2}-\\w{3}-\\d{4}) \\| (.+) ~(\\w+)$";
				results = GlobalFuncs.regex_note_sql_extract( notetext, regex );
				timestamp = results.f_str( 2 );
				notetext = results.f_str( 3 );
				adminckey = results.f_str( 4 );
				query_convert_time = GlobalVars.dbcon.NewQuery( "SELECT ADDTIME(STR_TO_DATE('" + timestamp + "','%d-%b-%Y'), '0')" );
				if ( !Misc13.isValid( query_convert_time.Execute() ) ) {
					err = query_convert_time.ErrorMsg();
					GlobalFuncs.log_game( "SQL ERROR converting timestamp. Error : [" + err + "]\n" );
					return;
				}
				if ( Misc13.isValid( query_convert_time.NextRow() ) ) {
					timestamp = query_convert_time.item[1];
				}
				if ( Misc13.isValid( ckey ) && Misc13.isValid( notetext ) && Misc13.isValid( timestamp ) && Misc13.isValid( adminckey ) && Misc13.isValid( server ) ) {
					GlobalFuncs.add_note( ckey, notetext, timestamp, adminckey, 0, server );
				}
			}
			notesfile.cd = "/";
			notesfile.dir.Remove( ckey );
		}

		public static int count_by_type( dynamic L = null, dynamic type = null ) {
			int i = 0;
			dynamic T = null;
			i = 0;
			T = null;
			foreach (dynamic _ in L ) {
				T = _;
				if ( Misc13.isValid( type.IsInstanceOfType( T ) ) ) {
					i++;
				}
			};
			return i;
		}

		public static Mind create_ninja_mind( dynamic key = null ) {
			Mind Mind = null;
			Mind = new Mind( key );
			Mind.assigned_role = "Space Ninja";
			Mind.special_role = "Space Ninja";
			GlobalVars.ticker.mode.traitors |= Mind;
			return Mind;
		}

		public static Mob_Living_Carbon_Human create_space_ninja( dynamic spawn_loc = null ) {
			Mob_Living_Carbon_Human new_ninja = null;
			Preferences A = null;
			new_ninja = new Mob_Living_Carbon_Human( spawn_loc );
			A = new Preferences();
			A.real_name = "" + Rand.pick( GlobalVars.ninja_titles ) + " " + Rand.pick( GlobalVars.ninja_names );
			A.copy_to( new_ninja );
			new_ninja.dna.update_dna_identity();
			new_ninja.equip_space_ninja();
			return new_ninja;
		}

		public static int create_xeno( dynamic ckey = null ) {
			ByTable candidates = null;
			dynamic M = null;
			dynamic alien_caste = null;
			dynamic spawn_here = null;
			dynamic new_xeno = null;
			if ( !Misc13.isValid( ckey ) ) {
				candidates = new ByTable();
				M = null;
				foreach (dynamic _ in GlobalVars.player_list ) {
					M = _;
					if ( M.stat != 2 ) {
						continue;
					}
					if ( !Misc13.isValid( M.client.prefs.be_special ) & 64 ) {
						continue;
					}
					if ( Misc13.isValid( M.client.is_afk() ) ) {
						continue;
					}
					if ( Misc13.isValid( M.mind ) && Misc13.isValid( M.mind.current ) && M.mind.current.stat != 2 ) {
						continue;
					}
					candidates += M.ckey;
				};
				if ( Misc13.isValid( candidates.len ) ) {
					ckey = Misc13.input( "Pick the player you want to respawn as a xeno.", "Suitable Candidates", null, null, candidates, 4224 );
				} else {
					Misc13.thread_user.write( "<font color='red'>Error: create_xeno(): no suitable candidates.</font>" );
				}
			}
			if ( !( ckey is string ) ) {
				return 0;
			}
			alien_caste = Misc13.input( Misc13.thread_user, "Please choose which caste to spawn.", "Pick a caste", null, new ByTable(new object [] {"Queen","Praetorian","Hunter","Sentinel","Drone","Larva"}), 4224 );
			spawn_here = Misc13.isValid( GlobalVars.xeno_spawn.len ) ? Rand.pick( GlobalVars.xeno_spawn ) : Rand.pick( GlobalVars.latejoin );
			new_xeno = null;
			dynamic _ = alien_caste; // Was a switch-case, sorry for the mess.
			if ( _=="Queen" ) {
				new_xeno = new Mob_Living_Carbon_Alien_Humanoid_Royal_Queen( spawn_here );
			} else if ( _=="Praetorian" ) {
				new_xeno = new Mob_Living_Carbon_Alien_Humanoid_Royal_Praetorian( spawn_here );
			} else if ( _=="Hunter" ) {
				new_xeno = new Mob_Living_Carbon_Alien_Humanoid_Hunter( spawn_here );
			} else if ( _=="Sentinel" ) {
				new_xeno = new Mob_Living_Carbon_Alien_Humanoid_Sentinel( spawn_here );
			} else if ( _=="Drone" ) {
				new_xeno = new Mob_Living_Carbon_Alien_Humanoid_Drone( spawn_here );
			} else if ( _=="Larva" ) {
				new_xeno = new Mob_Living_Carbon_Alien_Larva( spawn_here );
			} else {
				return 0;
			};
			new_xeno.ckey = ckey;
			GlobalFuncs.message_admins( "<span class='notice'>" + GlobalFuncs.key_name_admin( Misc13.thread_user ) + " has spawned " + ckey + " as a filthy xeno " + alien_caste + ".</span>" );
			return 1;
		}

		public static void createRandomZlevel(  ) {
			ByTable potentialRandomZlevels = null;
			ByTable Lines = null;
			string t = null;
			dynamic pos = null;
			dynamic name = null;
			dynamic map = null;
			File file = null;
			dynamic L = null;
			if ( Misc13.isValid( GlobalVars.awaydestinations.len ) ) {
				return;
			}
			potentialRandomZlevels = new ByTable();
			Game.write( "<span class='boldannounce'>Searching for away missions...</span>" );
			Lines = GlobalFuncs.file2list( "_maps/RandomZLevels/fileList.txt" );
			if ( !Misc13.isValid( Lines.len ) ) {
				return;
			}
			t = null;
			foreach (dynamic _ in Lines ) {
				t = _;
				if ( !Misc13.isValid( t ) ) {
					continue;
				}
				t = GlobalFuncs.trim( t );
				if ( t.Length == 0 ) {
					continue;
				} else if ( Misc13.str_sub( t, 1, 2 ) == "#" ) {
					continue;
				}
				pos = Misc13.str_find( t, " ", 1, null );
				name = null;
				if ( Misc13.isValid( pos ) ) {
					name = Misc13.str_lower( Misc13.str_sub( t, 1, pos ) );
				} else {
					name = Misc13.str_lower( t );
				}
				if ( !Misc13.isValid( name ) ) {
					continue;
				}
				potentialRandomZlevels.Add( t );
			};
			if ( Misc13.isValid( potentialRandomZlevels.len ) ) {
				Game.write( "<span class='boldannounce'>Loading away mission...</span>" );
				map = Rand.pick( potentialRandomZlevels );
				file = new File( map );
				if ( file is File ) {
					GlobalVars.maploader.%load map( file );
					Game.log.write( "away mission loaded: " + map );
				}
				GlobalVars.map_transition_config.Add( new ByTable().set( "Away Mission", 0 ) );
				L = null;
				foreach (dynamic _ in GlobalVars.landmarks_list ) {
					L = _;
					if ( !( L is Ent_Effect_Landmark ) ) {
						continue;
					}
					if ( L.name != "awaystart" ) {
						continue;
					}
					GlobalVars.awaydestinations.Add( L );
				};
				Game.write( "<span class='boldannounce'>Away mission loaded.</span>" );
			} else {
				Game.write( "<span class='boldannounce'>No away missions found.</span>" );
				return;
			}
		}

		public static void cultist_commune( dynamic user = null, int clear = 0, int say = 0, dynamic message = null ) {
			dynamic M = null;
			if ( clear == null ) {
				clear = 0;
			}
			if ( say == null ) {
				say = 0;
			}
			if ( !Misc13.isValid( message ) ) {
				return;
			}
			if ( say != 0 ) {
				user.say( "O bidai nabora se" + Rand.pick(new object [] { "'", "`" }) + "sma!" );
			} else {
				user.%Whisper( "O bidai nabora se" + Rand.pick(new object [] { "'", "`" }) + "sma!" );
			}
			Thread13.sleep( 10 );
			if ( !Misc13.isValid( user ) ) {
				return;
			}
			if ( say != 0 ) {
				user.say( message );
			} else {
				user.%Whisper( message );
			}
			M = null;
			foreach (dynamic _ in GlobalVars.mob_list ) {
				M = _;
				if ( GlobalFuncs.iscultist( M ) || Misc13.isValid( GlobalVars.dead_mob_list.HasValue( M ) ) ) {
					if ( ( clear != 0 ) || !( user is Mob_Living_Carbon_Human ) ) {
						M.write( "<span class='boldannounce'><i>" + ( user is Mob_Living_Carbon_Human ? "Acolyte" : "Construct" ) + " " + user + ":</i> " + message + "</span>" );
					} else {
						M.write( "<span class='ghostalert'><i>Acolyte ???:</i> " + message + "</span>" );
					}
				}
			};
			GlobalFuncs.log_say( "" + user.real_name + "/" + user.key + " : " + message );
		}

		public static dynamic dd_hasprefix_case( dynamic text = null, dynamic prefix = null ) {
			int start = 0;
			dynamic end = null;
			start = 1;
			end = prefix.Length + 1;
			return Misc13.str_findEx( text, prefix, start, end );
		}

		public static dynamic dd_hassuffix( dynamic text = null, dynamic suffix = null ) {
			dynamic start = null;
			start = text.Length - suffix.Length;
			if ( Misc13.isValid( start ) ) {
				return Misc13.str_find( text, suffix, start, null );
			}
			return null;
		}

		public static dynamic dd_limittext( dynamic message = null, dynamic length = null ) {
			dynamic size = null;
			size = message.Length;
			if ( size <= length ) {
				return message;
			}
			return Misc13.str_sub( message, 1, length + 1 );
		}

		public static dynamic dd_range( dynamic low = null, dynamic high = null, dynamic num = null ) {
			return Misc13.max( low, Misc13.min( high, num ) );
		}

		public static dynamic deconstruct_block( dynamic value = null, dynamic values = null, int blocksize = 0 ) {
			dynamic width = null;
			if ( blocksize == null ) {
				blocksize = 3;
			}
			width = Misc13.round( Math.Pow( 16, blocksize ) / values );
			value = Misc13.round( GlobalFuncs.hex2num( value ) / width ) + 1;
			if ( value > values ) {
				value = values;
			}
			return value;
		}

		public static int deltimer( dynamic id = null ) {
			dynamic _event = null;
			_event = null;
			foreach (dynamic _ in GlobalVars.SStimer.processing ) {
				_event = _;
				if ( !( _event is Timedevent ) ) {
					continue;
				}
				if ( _event.id == id ) {
					GlobalFuncs.qdel( _event );
					return 1;
				}
			};
			return 0;
		}

		public static dynamic derpspeech( dynamic message = null, dynamic stuttering = null ) {
			message = GlobalFuncs.replacetext( message, " am ", " " );
			message = GlobalFuncs.replacetext( message, " is ", " " );
			message = GlobalFuncs.replacetext( message, " are ", " " );
			message = GlobalFuncs.replacetext( message, "you", "u" );
			message = GlobalFuncs.replacetext( message, "help", "halp" );
			message = GlobalFuncs.replacetext( message, "grief", "grife" );
			message = GlobalFuncs.replacetext( message, "space", "spess" );
			message = GlobalFuncs.replacetext( message, "carp", "crap" );
			message = GlobalFuncs.replacetext( message, "reason", "raisin" );
			if ( Misc13.isValid( Rand.chance( 50 ) ) ) {
				message = Misc13.str_upper( message );
				message += "" + GlobalFuncs.stutter( Rand.pick(new object [] { "!", "!!", "!!!" }) );
			}
			if ( !Misc13.isValid( stuttering ) && Misc13.isValid( Rand.chance( 15 ) ) ) {
				message = GlobalFuncs.stutter( message );
			}
			return message;
		}

		public static int dir2angle( dynamic D = null ) {
			dynamic _ = D; // Was a switch-case, sorry for the mess.
			if ( _==1 ) {
				return 0;
			} else if ( _==2 ) {
				return 180;
			} else if ( _==4 ) {
				return 90;
			} else if ( _==8 ) {
				return 270;
			} else if ( _==5 ) {
				return 45;
			} else if ( _==6 ) {
				return 135;
			} else if ( _==9 ) {
				return 315;
			} else if ( _==10 ) {
				return 225;
			} else {
				return 0;
			};
		}

		public static string dir2text( dynamic direction = null ) {
			dynamic _ = direction; // Was a switch-case, sorry for the mess.
			if ( _==1 ) {
				return "north";
			} else if ( _==2 ) {
				return "south";
			} else if ( _==4 ) {
				return "east";
			} else if ( _==8 ) {
				return "west";
			} else if ( _==5 ) {
				return "northeast";
			} else if ( _==6 ) {
				return "southeast";
			} else if ( _==9 ) {
				return "northwest";
			} else if ( _==10 ) {
				return "southwest";
			};
			return null;
		}

		public static string dir2text_short( dynamic direction = null ) {
			dynamic _ = direction; // Was a switch-case, sorry for the mess.
			if ( _==1 ) {
				return "N";
			} else if ( _==2 ) {
				return "S";
			} else if ( _==4 ) {
				return "E";
			} else if ( _==8 ) {
				return "W";
			} else if ( _==5 ) {
				return "NE";
			} else if ( _==6 ) {
				return "SE";
			} else if ( _==9 ) {
				return "NW";
			} else if ( _==10 ) {
				return "SW";
			};
			return null;
		}

		public static int DirBlockedWithAccess( dynamic T = null, dynamic dir = null, dynamic ID = null ) {
			dynamic D = null;
			D = null;
			foreach (dynamic _ in T ) {
				D = _;
				if ( !( D is Ent_Structure_Window ) ) {
					continue;
				}
				if ( !Misc13.isValid( D.density ) ) {
					continue;
				}
				if ( D.dir == GlobalVars.SOUTHWEST ) {
					return 1;
				}
				if ( D.dir == dir ) {
					return 1;
				}
			};
			D = null;
			foreach (dynamic _ in T ) {
				D = _;
				if ( !( D is Ent_Machinery_Door ) ) {
					continue;
				}
				if ( !Misc13.isValid( D.CanAStarPass( ID, dir ) ) ) {
					return 1;
				}
			};
			return 0;
		}

		public static void display_roundstart_logout_report(  ) {
			string msg = null;
			dynamic L = null;
			int found = 0;
			dynamic C = null;
			dynamic D = null;
			dynamic M = null;
			msg = "<span class='boldnotice'>Roundstart logout report\n\n</span>";
			L = null;
			foreach (dynamic _ in GlobalVars.mob_list ) {
				L = _;
				if ( !( L is Mob_Living ) ) {
					continue;
				}
				if ( Misc13.isValid( L.ckey ) ) {
					found = 0;
					C = null;
					foreach (dynamic _ in GlobalVars.clients ) {
						C = _;
						if ( !Misc13.isValid( BAD_GOOFY_EXPANSION???.IsInstanceOfType( C ) ) ) {
							continue;
						}
						if ( C.ckey == L.ckey ) {
							found = 1;
							break;
						}
					};
					if ( found == 0 ) {
						msg += "<b>" + L.name + "</b> (" + L.ckey + "), the " + L.job + " (<font color='#ffcc00'><b>Disconnected</b></font>)\n";
					}
				}
				if ( Misc13.isValid( L.ckey ) && Misc13.isValid( L.client ) ) {
					if ( L.client.inactivity >= 3000 ) {
						msg += "<b>" + L.name + "</b> (" + L.ckey + "), the " + L.job + " (<font color='#ffcc00'><b>Connected, Inactive</b></font>)\n";
						continue;
					}
					if ( Misc13.isValid( L.stat ) ) {
						if ( Misc13.isValid( L.suiciding ) ) {
							msg += "<b>" + L.name + "</b> (" + L.ckey + "), the " + L.job + " (<span class='boldannounce'>Suicide</span>)\n";
							continue;
						}
						if ( L.stat == 1 ) {
							msg += "<b>" + L.name + "</b> (" + L.ckey + "), the " + L.job + " (Dying)\n";
							continue;
						}
						if ( L.stat == 2 ) {
							msg += "<b>" + L.name + "</b> (" + L.ckey + "), the " + L.job + " (Dead)\n";
							continue;
						}
					}
					continue;
				}
				D = null;
				foreach (dynamic _ in GlobalVars.mob_list ) {
					D = _;
					if ( !( D is Mob_Dead_Observer ) ) {
						continue;
					}
					if ( Misc13.isValid( D.mind ) && D.mind.current == L ) {
						if ( L.stat == 2 ) {
							if ( Misc13.isValid( L.suiciding ) ) {
								msg += "<b>" + L.name + "</b> (" + Misc13.ckey( D.mind.key ) + "), the " + L.job + " (<span class='boldannounce'>Suicide</span>)\n";
								continue;
							} else {
								msg += "<b>" + L.name + "</b> (" + Misc13.ckey( D.mind.key ) + "), the " + L.job + " (Dead)\n";
								continue;
							}
						} else if ( Misc13.isValid( D.can_reenter_corpse ) ) {
							msg += "<b>" + L.name + "</b> (" + Misc13.ckey( D.mind.key ) + "), the " + L.job + " (<span class='boldannounce'>This shouldn't appear.</span>)\n";
							continue;
						} else {
							msg += "<b>" + L.name + "</b> (" + Misc13.ckey( D.mind.key ) + "), the " + L.job + " (<span class='boldannounce'>Ghosted</span>)\n";
							continue;
						}
					}
				};
			};
			M = null;
			foreach (dynamic _ in GlobalVars.mob_list ) {
				M = _;
				if ( Misc13.isValid( M.client ) && Misc13.isValid( M.client.holder ) ) {
					M.write( msg );
				}
			};
		}

		public static int do_after( dynamic user = null, dynamic delay = null, int numticks = 0, int needhand = 0, dynamic target = null, int progress = 0 ) {
			dynamic Tloc = null;
			dynamic delayfraction = null;
			dynamic Uloc = null;
			dynamic holding = null;
			int holdingnull = 0;
			dynamic progbar = null;
			int continue_looping = 0;
			dynamic i = null;
			if ( numticks == null ) {
				numticks = 5;
			}
			if ( needhand == null ) {
				needhand = 1;
			}
			if ( target == null ) {
				target = null;
			}
			if ( progress == null ) {
				progress = 1;
			}
			if ( !Misc13.isValid( user ) ) {
				return 0;
			}
			if ( numticks == 0 ) {
				return 0;
			}
			Tloc = null;
			if ( Misc13.isValid( target ) ) {
				Tloc = target.loc;
			}
			delayfraction = Misc13.round( delay / numticks );
			Uloc = user.loc;
			holding = user.get_active_hand();
			holdingnull = 1;
			if ( Misc13.isValid( holding ) ) {
				holdingnull = 0;
			}
			continue_looping = 1;
			i = null;
			foreach (dynamic _ in Misc13.iter_range( 1, numticks ) ) {
				i = _;
				if ( Misc13.isValid( user.client ) && ( progress != 0 ) ) {
					progbar = GlobalFuncs.make_progress_bar( i, numticks, target );
					GlobalFuncs.assign_progress_bar( user, progbar );
				}
				Thread13.sleep( delayfraction );
				if ( !Misc13.isValid( user ) || Misc13.isValid( user.stat ) || Misc13.isValid( user.weakened ) || Misc13.isValid( user.stunned ) || !( user.loc == Uloc ) ) {
					continue_looping = 0;
				}
				if ( ( continue_looping != 0 ) && Misc13.isValid( Tloc ) && ( !Misc13.isValid( target ) || Tloc != target.loc ) ) {
					continue_looping = 0;
				}
				if ( ( continue_looping != 0 ) && ( needhand != 0 ) ) {
					if ( holdingnull == 0 ) {
						if ( !Misc13.isValid( holding ) ) {
							continue_looping = 0;
						}
					}
					if ( ( continue_looping != 0 ) && user.get_active_hand() != holding ) {
						continue_looping = 0;
					}
				}
				GlobalFuncs.cancel_progress_bar( user, progbar );
				if ( continue_looping == 0 ) {
					return 0;
				}
			};
			GlobalFuncs.cancel_progress_bar( user, progbar );
			return 1;
		}

		public static int do_mob( dynamic user = null, dynamic target = null, int time = 0, int numticks = 0, int uninterruptible = 0, int progress = 0 ) {
			dynamic user_loc = null;
			dynamic target_loc = null;
			dynamic holding = null;
			dynamic timefraction = null;
			dynamic progbar = null;
			int continue_looping = 0;
			dynamic i = null;
			if ( time == null ) {
				time = 30;
			}
			if ( numticks == null ) {
				numticks = 5;
			}
			if ( uninterruptible == null ) {
				uninterruptible = 0;
			}
			if ( progress == null ) {
				progress = 1;
			}
			if ( !Misc13.isValid( user ) || !Misc13.isValid( target ) ) {
				return 0;
			}
			if ( numticks == 0 ) {
				return 0;
			}
			user_loc = user.loc;
			target_loc = target.loc;
			holding = user.get_active_hand();
			timefraction = Misc13.round( time / numticks );
			continue_looping = 1;
			i = null;
			foreach (dynamic _ in Misc13.iter_range( 1, numticks ) ) {
				i = _;
				if ( Misc13.isValid( user.client ) && ( progress != 0 ) ) {
					progbar = GlobalFuncs.make_progress_bar( i, numticks, target );
					GlobalFuncs.assign_progress_bar( user, progbar );
				}
				Thread13.sleep( timefraction );
				if ( !Misc13.isValid( user ) || !Misc13.isValid( target ) ) {
					continue_looping = 0;
				}
				if ( ( continue_looping != 0 ) && ( uninterruptible == 0 ) && ( user.loc != user_loc || target.loc != target_loc || user.get_active_hand() != holding || Misc13.isValid( user.incapacitated() ) || Misc13.isValid( user.lying ) ) ) {
					continue_looping = 0;
				}
				GlobalFuncs.cancel_progress_bar( user, progbar );
				if ( continue_looping == 0 ) {
					return 0;
				}
			};
			GlobalFuncs.cancel_progress_bar( user, progbar );
			return 1;
		}

		public static int do_teleport( params object[] _ ) { // Arg Names: 0: ateleatom, 1: adestination, 2: aprecision, 3: afteleport, 4: aeffectin, 5: aeffectout, 6: asoundin, 7: asoundout
			ByTable _args = new ByTable(_);
			Teleport_Instant_Science D = null;
			if ( _args[2] == null ) {
				_args[2] = 0;
			}
			if ( _args[3] == null ) {
				_args[3] = 1;
			}
			if ( _args[4] == null ) {
				_args[4] = null;
			}
			if ( _args[5] == null ) {
				_args[5] = null;
			}
			if ( _args[6] == null ) {
				_args[6] = null;
			}
			if ( _args[7] == null ) {
				_args[7] = null;
			}
			D = new Teleport_Instant_Science();
			if ( Misc13.isValid( D.start.BTCall( _args ) ) ) {
				return 1;
			}
			return 0;
		}

		public static int DrawPixel( dynamic I = null, dynamic colour = null, dynamic drawX = null, dynamic drawY = null ) {
			dynamic Iwidth = null;
			dynamic Iheight = null;
			if ( !Misc13.isValid( I ) ) {
				return 0;
			}
			Iwidth = I.Width();
			Iheight = I.Height();
			if ( drawX > Iwidth || drawX <= 0 ) {
				return 0;
			}
			if ( drawY > Iheight || drawY <= 0 ) {
				return 0;
			}
			I.DrawBox( colour, drawX, drawY );
			return I;
		}

		public static dynamic DuplicateObject( dynamic original = null, int perfectcopy = 0, int sameloc = 0 ) {
			dynamic O = null;
			dynamic V = null;
			if ( perfectcopy == null ) {
				perfectcopy = 0;
			}
			if ( sameloc == null ) {
				sameloc = 0;
			}
			if ( !Misc13.isValid( original ) ) {
				return null;
			}
			O = null;
			if ( sameloc != 0 ) {
				O = original.type( original.loc );
			} else {
				O = original.type( Misc13.locate3( 0, 0, 0 ) );
			}
			if ( perfectcopy != 0 ) {
				if ( Misc13.isValid( O ) && Misc13.isValid( original ) ) {
					V = null;
					foreach (dynamic _ in original.vars ) {
						V = _;
						if ( !Misc13.isValid( new ByTable(new object [] {"type","loc","locs","vars","parent","parent_type","verbs","ckey","key"}).HasValue( V ) ) ) {
							O.vars[V] = original.vars[V];
						}
					};
				}
			}
			return O;
		}

		public static void edit_note( dynamic note_id = null ) {
			dynamic target_ckey = null;
			dynamic sql_ckey = null;
			DBQuery query_find_note_edit = null;
			dynamic err = null;
			dynamic old_note = null;
			dynamic adminckey = null;
			dynamic new_note = null;
			string edit_text = null;
			DBQuery query_update_note = null;
			if ( GlobalVars.dbcon.IsConnected() == 0 ) {
				Misc13.thread_user.write( "<span class='danger'>Failed to establish database connection.</span>" );
				return;
			}
			if ( !Misc13.isValid( note_id ) ) {
				return;
			}
			note_id = Misc13.parseNumber( note_id );
			sql_ckey = GlobalFuncs.sanitizeSQL( Misc13.thread_user.ckey );
			query_find_note_edit = GlobalVars.dbcon.NewQuery( "SELECT ckey, notetext, adminckey FROM " + GlobalFuncs.format_table_name( "notes" ) + " WHERE id = " + note_id );
			if ( !Misc13.isValid( query_find_note_edit.Execute() ) ) {
				err = query_find_note_edit.ErrorMsg();
				GlobalFuncs.log_game( "SQL ERROR obtaining notetext from notes table. Error : [" + err + "]\n" );
				return;
			}
			if ( Misc13.isValid( query_find_note_edit.NextRow() ) ) {
				target_ckey = query_find_note_edit.item[1];
				old_note = query_find_note_edit.item[2];
				adminckey = query_find_note_edit.item[3];
				new_note = Misc13.input( "Input new note", "New Note", "" + old_note, null, null, 2048 );
				if ( !Misc13.isValid( new_note ) ) {
					return;
				}
				new_note = GlobalFuncs.sanitizeSQL( new_note );
				edit_text = "Edited by " + sql_ckey + " on " + GlobalFuncs.SQLtime() + " from<br>" + old_note + "<br>to<br>" + new_note + "<hr>";
				edit_text = GlobalFuncs.sanitizeSQL( edit_text );
				query_update_note = GlobalVars.dbcon.NewQuery( "UPDATE " + GlobalFuncs.format_table_name( "notes" ) + " SET notetext = '" + new_note + "', last_editor = '" + sql_ckey + "', edits = CONCAT(IFNULL(edits,''),'" + edit_text + "') WHERE id = " + note_id );
				if ( !Misc13.isValid( query_update_note.Execute() ) ) {
					err = query_update_note.ErrorMsg();
					GlobalFuncs.log_game( "SQL ERROR editing note. Error : [" + err + "]\n" );
					return;
				}
				GlobalFuncs.log_admin( "" + GlobalFuncs.key_name( Misc13.thread_user ) + " has edited " + target_ckey + "'s note made by " + adminckey + " from " + old_note + " to " + new_note );
				GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( Misc13.thread_user ) + " has edited " + target_ckey + "'s note made by " + adminckey + " from<br>" + old_note + "<br>to<br>" + new_note );
				GlobalFuncs.show_note( target_ckey );
			}
		}

		public static int electrocute_mob( dynamic M = null, dynamic power_source = null, dynamic source = null, int siemens_coeff = 0 ) {
			dynamic H = null;
			dynamic G = null;
			dynamic source_area = null;
			dynamic Cable = null;
			dynamic PN = null;
			dynamic cell = null;
			dynamic apc = null;
			int PN_damage = 0;
			int cell_damage = 0;
			int shock_damage = 0;
			dynamic drained_hp = null;
			dynamic drained_energy = null;
			dynamic drained_power = null;
			if ( siemens_coeff == null ) {
				siemens_coeff = 1;
			}
			if ( M.loc is Ent_Mecha ) {
				return 0;
			}
			if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				if ( Misc13.isValid( H.gloves ) ) {
					G = H.gloves;
					if ( G.siemens_coefficient == 0 ) {
						return 0;
					}
				}
			}
			if ( Misc13.isValid( new ByArea(3137).IsInstanceOfType( power_source ) ) ) {
				source_area = power_source;
				power_source = source_area.get_apc();
			}
			if ( power_source is Ent_Structure_Cable ) {
				Cable = power_source;
				power_source = Cable.powernet;
			}
			if ( power_source is Powernet ) {
				PN = power_source;
			} else if ( power_source is Ent_Item_Weapon_StockParts_Cell ) {
				cell = power_source;
			} else if ( power_source is Ent_Machinery_Power_Apc ) {
				apc = power_source;
				cell = apc.cell;
				if ( Misc13.isValid( apc.terminal ) ) {
					PN = apc.terminal.powernet;
				}
			} else if ( !Misc13.isValid( power_source ) ) {
				return 0;
			} else {
				GlobalFuncs.log_admin( "ERROR: /proc/electrocute_mob(" + M + ", " + power_source + ", " + source + "): wrong power_source" );
				return 0;
			}
			if ( !Misc13.isValid( cell ) && !Misc13.isValid( PN ) ) {
				return 0;
			}
			PN_damage = 0;
			cell_damage = 0;
			if ( Misc13.isValid( PN ) ) {
				PN_damage = PN.get_electrocute_damage();
			}
			if ( Misc13.isValid( cell ) ) {
				cell_damage = cell.get_electrocute_damage();
			}
			shock_damage = 0;
			if ( PN_damage >= cell_damage ) {
				power_source = PN;
				shock_damage = PN_damage;
			} else {
				power_source = cell;
				shock_damage = cell_damage;
			}
			drained_hp = M.electrocute_act( shock_damage, source, siemens_coeff );
			drained_energy = drained_hp * 20;
			if ( Misc13.isValid( source_area ) ) {
				source_area.use_power( drained_energy / GlobalVars.CELLRATE );
			} else if ( power_source is Powernet ) {
				drained_power = drained_energy / GlobalVars.CELLRATE;
				PN.load += drained_power;
			} else if ( power_source is Ent_Item_Weapon_StockParts_Cell ) {
				cell.use( drained_energy );
			}
			return drained_energy;
		}

		public static dynamic Ellipsis( dynamic original_msg = null, int chance = 0, dynamic keep_words = null ) {
			ByTable words = null;
			ByTable new_words = null;
			dynamic new_msg = null;
			dynamic w = null;
			if ( chance == null ) {
				chance = 50;
			}
			if ( chance <= 0 ) {
				return "...";
			}
			if ( chance >= 100 ) {
				return original_msg;
			}
			words = GlobalFuncs.text2list( original_msg, " " );
			new_words = new ByTable();
			new_msg = "";
			w = null;
			foreach (dynamic _ in words ) {
				w = _;
				if ( Misc13.isValid( Rand.chance( chance ) ) ) {
					new_words += "...";
					if ( !Misc13.isValid( keep_words ) ) {
						continue;
					}
				}
				new_words += w;
			};
			new_msg = GlobalFuncs.list2text( new_words, " " );
			return new_msg;
		}

		public static string emoji_parse( dynamic text = null ) {
			string parsed = null;
			int pos = 0;
			int search = 0;
			string emoji = null;
			if ( !Misc13.isValid( GlobalVars.config.emojis ) ) {
				return text;
			}
			if ( !Misc13.isValid( GlobalVars.emojis ) ) {
				GlobalVars.emojis = Misc13.icon_states( null, new Icon( new ByRsc(60) ) );
			}
			parsed = "";
			pos = 1;
			search = 0;
			emoji = "";
			while (1) {
				search = Misc13.str_find( text, ":", pos, null );
				parsed += Misc13.str_sub( text, pos, search );
				if ( search != 0 ) {
					pos = search;
					search = Misc13.str_find( text, ":", pos + 1, null );
					if ( search != 0 ) {
						emoji = Misc13.str_lower( Misc13.str_sub( text, pos + 1, search ) );
						if ( Misc13.isValid( GlobalVars.emojis.HasValue( emoji ) ) ) {
							parsed += new Txt( "<img class=icon src=" ).Ref( new ByRsc(60) ).str( " iconstate='" ).item( emoji ).str( "'>" );
							pos = search + 1;
						} else {
							parsed += Misc13.str_sub( text, pos, search );
							pos = search;
						}
						emoji = "";
						continue;
					} else {
						parsed += Misc13.str_sub( text, pos, search );
					}
				}
				break;
			}
			return parsed;
		}

		public static int empulse( dynamic epicenter = null, dynamic heavy_range = null, dynamic light_range = null, int log = 0 ) {
			dynamic T = null;
			int distance = 0;
			if ( log == null ) {
				log = 0;
			}
			if ( !Misc13.isValid( epicenter ) ) {
				return 0;
			}
			if ( !( epicenter is Tile ) ) {
				epicenter = GlobalFuncs.get_turf( epicenter.loc );
			}
			if ( log != 0 ) {
				GlobalFuncs.message_admins( "EMP with size (" + heavy_range + ", " + light_range + ") in area " + epicenter.loc.name + " " );
				GlobalFuncs.log_game( "EMP with size (" + heavy_range + ", " + light_range + ") in area " + epicenter.loc.name + " " );
			}
			if ( heavy_range > 1 ) {
				new Ent_Effect_Overlay_Temp_Emp_Pulse( epicenter );
			}
			if ( heavy_range > light_range ) {
				light_range = heavy_range;
			}
			T = null;
			foreach (dynamic _ in Misc13.range( light_range, epicenter ) ) {
				T = _;
				if ( !( T is BaseStatic ) ) {
					continue;
				}
				distance = Misc13.get_dist( epicenter, T );
				if ( distance < 0 ) {
					distance = 0;
				}
				if ( distance < heavy_range ) {
					T.emp_act( 1 );
				} else if ( distance == heavy_range ) {
					if ( Misc13.isValid( Rand.chance( 50 ) ) ) {
						T.emp_act( 1 );
					} else {
						T.emp_act( 2 );
					}
				} else if ( distance <= light_range ) {
					T.emp_act( 2 );
				}
			};
			return 1;
		}

		public static string english_list( dynamic input = null, string nothing_text = null, string and_text = null, string comma_text = null, string final_comma_text = null ) {
			dynamic total = null;
			string output = null;
			int index = 0;
			if ( nothing_text == null ) {
				nothing_text = "nothing";
			}
			if ( and_text == null ) {
				and_text = " and ";
			}
			if ( comma_text == null ) {
				comma_text = ", ";
			}
			if ( final_comma_text == null ) {
				final_comma_text = "";
			}
			total = input.len;
			if ( !Misc13.isValid( total ) ) {
				return "" + nothing_text;
			} else if ( total == 1 ) {
				return "" + input[1];
			} else if ( total == 2 ) {
				return "" + input[1] + and_text + input[2];
			} else {
				output = "";
				index = 1;
				while (index < total) {
					if ( index == total - 1 ) {
						comma_text = final_comma_text;
					}
					output += "" + input[index] + comma_text;
					index++;
				}
				return "" + output + and_text + input[index];
			}
		}

		public static int establish_db_connection(  ) {
			if ( GlobalVars.failed_db_connections > 5 ) {
				return 0;
			}
			if ( ( GlobalVars.dbcon == null ) || ( GlobalVars.dbcon.IsConnected() == 0 ) ) {
				return GlobalFuncs.setup_database_connection();
			} else {
				return 1;
			}
		}


//FAILURE

		public static void feedback_add_details( dynamic variable = null, dynamic details = null ) {
			FeedbackVariable FV = null;
			if ( GlobalVars.blackbox == null ) {
				return;
			}
			FV = GlobalVars.blackbox.find_feedback_datum( variable );
			if ( FV == null ) {
				return;
			}
			FV.add_details( details );
		}

		public static void feedback_inc( dynamic variable = null, dynamic value = null ) {
			FeedbackVariable FV = null;
			if ( GlobalVars.blackbox == null ) {
				return;
			}
			FV = GlobalVars.blackbox.find_feedback_datum( variable );
			if ( FV == null ) {
				return;
			}
			FV.inc( value );
		}

		public static void feedback_set( dynamic variable = null, dynamic value = null ) {
			FeedbackVariable FV = null;
			if ( GlobalVars.blackbox == null ) {
				return;
			}
			FV = GlobalVars.blackbox.find_feedback_datum( variable );
			if ( FV == null ) {
				return;
			}
			FV.set_value( value );
		}

		public static void feedback_set_details( dynamic variable = null, dynamic details = null ) {
			FeedbackVariable FV = null;
			if ( GlobalVars.blackbox == null ) {
				return;
			}
			FV = GlobalVars.blackbox.find_feedback_datum( variable );
			if ( FV == null ) {
				return;
			}
			FV.set_details( details );
		}

		public static ByTable file2list( dynamic filename = null, string seperator = null ) {
			if ( seperator == null ) {
				seperator = "\n";
			}
			return GlobalFuncs.text2list( GlobalFuncs.return_file_text( filename ), seperator );
		}

		public static ByTable filter_fancy_list( dynamic L = null, dynamic filter = null ) {
			ByTable matches = null;
			dynamic key = null;
			dynamic value = null;
			matches = new ByTable();
			key = null;
			foreach (dynamic _ in L ) {
				key = _;
				value = L[key];
				if ( Misc13.isValid( Misc13.str_find( "" + key, filter, 1, null ) ) || Misc13.isValid( Misc13.str_find( "" + value, filter, 1, null ) ) ) {
					matches[key] = value;
				}
			};
			return matches;
		}

		public static dynamic find_record( dynamic field = null, dynamic value = null, dynamic L = null ) {
			dynamic R = null;
			R = null;
			foreach (dynamic _ in L ) {
				R = _;
				if ( !( R is Data_Record ) ) {
					continue;
				}
				if ( R.fields[field] == value ) {
					return R;
				}
			};
		}

		public static dynamic find_type_in_direction( dynamic source = null, dynamic direction = null, int range = 0 ) {
			int x_offset = 0;
			int y_offset = 0;
			dynamic target_turf = null;
			dynamic A = null;
			dynamic a_type = null;
			if ( range == null ) {
				range = 1;
			}
			x_offset = 0;
			y_offset = 0;
			if ( Misc13.isValid( ( direction & 1 ) ) ) {
				y_offset = range;
			} else if ( Misc13.isValid( ( direction & 2 ) ) ) {
				y_offset -= range;
			}
			if ( Misc13.isValid( ( direction & 4 ) ) ) {
				x_offset = range;
			} else if ( Misc13.isValid( ( direction & 8 ) ) ) {
				x_offset -= range;
			}
			target_turf = Misc13.locate3( source.x + x_offset, source.y + y_offset, source.z );
			if ( Misc13.isValid( source.canSmoothWith ) ) {
				if ( source.smooth == 2 ) {
					a_type = null;
					foreach (dynamic _ in source.canSmoothWith ) {
						a_type = _;
						if ( Misc13.isValid( a_type.IsInstanceOfType( target_turf ) ) ) {
							return target_turf;
						}
						A = Misc13.locate_in( a_type, target_turf );
						if ( Misc13.isValid( A ) ) {
							return A;
						}
					};
					return null;
				}
				a_type = null;
				foreach (dynamic _ in source.canSmoothWith ) {
					a_type = _;
					if ( a_type == target_turf.type ) {
						return target_turf;
					}
					A = Misc13.locate_in( a_type, target_turf );
					if ( Misc13.isValid( A ) && A.type == a_type ) {
						return A;
					}
				};
				return null;
			} else {
				if ( source is Tile ) {
					return A.type == target_turf.type ? target_turf : null;
				}
				A = Misc13.locate_in( source.type, target_turf );
				return Misc13.isValid( A ) && A.type == source.type ? A : null;
			}
		}

		public static int findchar( dynamic haystack = null, dynamic needles = null, int start = 0, int end = 0 ) {
			dynamic temp = null;
			dynamic len = null;
			int i = 0;
			if ( start == null ) {
				start = 1;
			}
			if ( end == null ) {
				end = 0;
			}
			len = needles.Length;
			i = null;
			i = 1;
			while (i <= len) {
				temp = Misc13.str_findEx( haystack, Misc13.conv_ascii2text( Misc13.conv_text2ascii( needles, i ) ), start, end );
				if ( Misc13.isValid( temp ) ) {
					end = temp;
				}
				i++;
			}
			return end;
		}

		public static int findname( string msg = null ) {
			dynamic M = null;
			if ( !( msg is string ) ) {
				msg = "" + msg;
			}
			M = null;
			foreach (dynamic _ in GlobalVars.mob_list ) {
				M = _;
				if ( M.real_name == msg ) {
					return M;
				}
			};
			return 0;
		}

		public static void flick_overlay( dynamic I = null, dynamic show_to = null, dynamic duration = null ) {
			dynamic C = null;
			C = null;
			foreach (dynamic _ in show_to ) {
				C = _;
				if ( !Misc13.isValid( BAD_GOOFY_EXPANSION???.IsInstanceOfType( C ) ) ) {
					continue;
				}
				C.images += I;
			};
			Thread13.schedule( duration, () => {
				C = null;
				foreach (dynamic _ in show_to ) {
					C = _;
					if ( !Misc13.isValid( BAD_GOOFY_EXPANSION???.IsInstanceOfType( C ) ) ) {
						continue;
					}
					C.images -= I;
				};
				return;
			});
		}

		public static int forbidden_atoms_check( dynamic A = null ) {
			ByTable blacklist = null;
			dynamic thing = null;
			blacklist = new ByTable(new object [] {typeof(Mob_Living),typeof(Ent_Effect_Blob),typeof(Ent_Effect_Spider_Spiderling),typeof(Ent_Item_Weapon_Disk_Nuclear),typeof(Ent_Machinery_Nuclearbomb),typeof(Ent_Item_Device_Radio_Beacon),typeof(Ent_Machinery_TheSingularitygen),typeof(Ent_Singularity),typeof(Ent_Machinery_Teleport_Station),typeof(Ent_Machinery_Teleport_Hub),typeof(Ent_Machinery_Telepad)});
			if ( Misc13.isValid( A ) ) {
				if ( GlobalFuncs.is_type_in_list( A, blacklist ) != 0 ) {
					return 1;
				}
				thing = null;
				foreach (dynamic _ in A ) {
					thing = _;
					if ( NULLVAR( thing ) != null ) {
						return 1;
					}
				};
			}
			return 0;
		}

		public static string format_frequency( dynamic f = null ) {
			f = Misc13.parseNumber( f );
			return "" + Misc13.round( f / 10 ) + "." + f % 10;
		}

		public static string format_table_name( dynamic table = null ) {
			return GlobalVars.sqlfdbktableprefix + table;
		}

		public static dynamic format_text( dynamic text = null ) {
			return GlobalFuncs.replacetext( GlobalFuncs.replacetext( text, "ÿ", "" ), "ÿ", "" );
		}

		public static dynamic gameTimestamp( string format = null ) {
			if ( format == null ) {
				format = "hh:mm:ss";
			}
			return Misc13.formatTime( Game.time - GlobalVars.timezoneOffset + 432000, format );
		}

		public static dynamic gaussian( dynamic mean = null, dynamic stddev = null ) {
			dynamic R1 = null;
			dynamic R2 = null;
			dynamic working = null;
			if ( GlobalVars.gaussian_next != null ) {
				R1 = GlobalVars.gaussian_next;
				GlobalVars.gaussian_next = null;
			} else {
				while (true) { // Was a do-while, sorry for the mess.
					R1 = Rand.Int( -10000, 10000 ) / 10000;
					R2 = Rand.Int( -10000, 10000 ) / 10000;
					working = R1 * R1 + R2 * R2;
					if (!( working >= 1 || working == 0 )) break;
				};
				working = Math.Sqrt( Math.log( working ) * -2 / working );
				R1 *= working;
				GlobalVars.gaussian_next = R2 * working;
			}
			return mean + stddev * R1;
		}

		public static void Gcd( dynamic a = null, dynamic b = null ) {
			return Misc13.isValid( b ) ? GlobalFuncs.Gcd( b, a % b ) : a;
		}

		public static string generate_code_phrase(  ) {
			string code_phrase = null;
			dynamic words = null;
			ByTable safety = null;
			ByTable nouns = null;
			ByTable drinks = null;
			ByTable locations = null;
			ByTable names = null;
			dynamic t = null;
			dynamic maxwords = null;
			code_phrase = "";
			words = int _ = Rand.Int(0,65535) // Was a weighted pick, sorry for the mess.
			if ( _ < 10082 ) { _ = 2 }
			else if ( _ < 50411 ) { _ = 3 }
			else if ( _ < 60493 ) { _ = 4 }
			else  { _ = 5 };
			safety = new ByTable(new object [] {1,2,3});
			nouns = new ByTable(new object [] {"love","hate","anger","peace","pride","sympathy","bravery","loyalty","honesty","integrity","compassion","charity","success","courage","deceit","skill","beauty","brilliance","pain","misery","beliefs","dreams","justice","truth","faith","liberty","knowledge","thought","information","culture","trust","dedication","progress","education","hospitality","leisure","trouble","friendships","relaxation"});
			drinks = new ByTable(new object [] {"vodka and tonic","gin fizz","bahama mama","manhattan","black Russian","whiskey soda","long island tea","margarita","Irish coffee"," manly dwarf","Irish cream","doctor's delight","Beepksy Smash","tequila sunrise","brave bull","gargle blaster","bloody mary","whiskey cola","white Russian","vodka martini","martini","Cuba libre","kahlua","vodka","wine","moonshine"});
			locations = Misc13.isValid( GlobalVars.teleportlocs.len ) ? GlobalVars.teleportlocs : drinks;
			names = new ByTable();
			t = null;
			foreach (dynamic _ in GlobalVars.data_core.general ) {
				t = _;
				if ( !( t is Data_Record ) ) {
					continue;
				}
				names += t.fields["name"];
			};
			maxwords = words;
			while (words > 0) {
				if ( words == 1 && Misc13.isValid( safety.HasValue( 1 ) ) && Misc13.isValid( safety.HasValue( 2 ) ) ) {
					safety = new ByTable(new object [] {Rand.pick(new object [] { 1, 2 })});
				} else if ( words == 1 && maxwords == 2 ) {
					safety = new ByTable(new object [] {3});
				}
				dynamic _ = Rand.pick( safety ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						if ( Misc13.isValid( names.len ) && Misc13.isValid( Rand.chance( 70 ) ) ) {
							code_phrase += Rand.pick( names );
						} else if ( Misc13.isValid( Rand.chance( 10 ) ) ) {
							code_phrase += Rand.pick(new object [] { GlobalFuncs.lizard_name( GlobalVars.MALE ), GlobalFuncs.lizard_name( GlobalVars.FEMALE ) });
						} else {
							code_phrase += Rand.pick( Rand.pick(new object [] { GlobalVars.first_names_male, GlobalVars.first_names_female }) );
							code_phrase += " ";
							code_phrase += Rand.pick( GlobalVars.last_names );
						}
					} else if ( _==2 ) {
						code_phrase += Rand.pick( GlobalFuncs.get_all_jobs() );
					};
					safety -= 1;
				} else if ( _==2 ) {
					dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						code_phrase += Rand.pick( drinks );
					} else if ( _==2 ) {
						code_phrase += Rand.pick( locations );
					};
					safety -= 2;
				} else if ( _==3 ) {
					dynamic _ = Rand.Int( 1, 3 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						code_phrase += Rand.pick( nouns );
					} else if ( _==2 ) {
						code_phrase += Rand.pick( GlobalVars.adjectives );
					} else if ( _==3 ) {
						code_phrase += Rand.pick( GlobalVars.verbs );
					};
				};
				if ( words == 1 ) {
					code_phrase += ".";
				} else {
					code_phrase += ", ";
				}
				words--;
			}
			return code_phrase;
		}

		public static void generate_female_clothing( dynamic index = null, dynamic t_color = null, dynamic icon = null, dynamic type = null ) {
			dynamic female_clothing_icon = null;
			dynamic female_s = null;
			female_clothing_icon = Icon.BTNew( new ByTable().set( "icon_state", t_color ).set( "icon", icon ) );
			female_s = Icon.BTNew( new ByTable().set( "icon_state", "" + ( type == 1 ? "female_full" : "female_top" ) ).set( "icon", new ByRsc(59) ) );
			female_clothing_icon.Blend( female_s, 2 );
			female_clothing_icon = Misc13.fcopy_rsc( female_clothing_icon );
			GlobalVars.female_clothing_icons[index] = female_clothing_icon;
		}

		public static string generate_ion_law( dynamic ionMessage = null ) {
			dynamic ionthreats = null;
			dynamic ionobjects = null;
			dynamic ioncrew1 = null;
			dynamic ioncrew2 = null;
			dynamic ionadjectives = null;
			dynamic ionadjectiveshalf = null;
			dynamic ionverb = null;
			dynamic ionnumberbase = null;
			dynamic ionnumbermodhalf = null;
			dynamic ionarea = null;
			dynamic ionthinksof = null;
			dynamic ionmust = null;
			dynamic ionrequire = null;
			dynamic ionthings = null;
			dynamic ionallergy = null;
			dynamic ionallergysev = null;
			dynamic ionspecies = null;
			dynamic ionabstract = null;
			dynamic ionfood = null;
			string message = null;
			if ( Misc13.isValid( ionMessage ) ) {
				return ionMessage;
			}
			ionthreats = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionthreats" ) );
			ionobjects = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionobjects" ) );
			ioncrew1 = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ioncrew" ) );
			ioncrew2 = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ioncrew" ) );
			ionadjectives = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionadjectives" ) );
			ionadjectiveshalf = int _ = Rand.Int(0,65535) // Was a weighted pick, sorry for the mess.
			if ( _ < 13107 ) { _ = "" }
			else  { _ = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionadjectives" ) ) + " " };
			ionverb = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionverb" ) );
			ionnumberbase = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionnumberbase" ) );
			ionnumbermodhalf = Rand.pick(new object [] { "", Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionnumbermod" ) ) + " " });
			ionarea = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionarea" ) );
			ionthinksof = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionthinksof" ) );
			ionmust = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionmust" ) );
			ionrequire = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionrequire" ) );
			ionthings = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionthings" ) );
			ionallergy = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionallergy" ) );
			ionallergysev = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionallergysev" ) );
			ionspecies = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionspecies" ) );
			ionabstract = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionabstract" ) );
			ionfood = Rand.pick( GlobalFuncs.strings( "ion_laws.txt", "ionfood" ) );
			message = "";
			dynamic _ = Rand.Int( 1, 39 ); // Was a switch-case, sorry for the mess.
			if ( 1<=_&&_<=3 ) {
				dynamic _ = Rand.Int( 1, 3 ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					message = "THERE ARE " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionthreats + " ON THE STATION...";
				} else if ( _==2 ) {
					message = "THERE ARE " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ioncrew1 + " ON THE STATION";
				} else if ( _==3 ) {
					message = "THERE ARE " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionobjects + " ON THE STATION";
				};
			} else if ( 4<=_&&_<=6 ) {
				dynamic _ = Rand.Int( 1, 3 ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					message = "THE SHUTTLE CANNOT BE CALLED BECAUSE OF " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionthreats + " ON THE STATION";
				} else if ( _==2 ) {
					message = "THE SHUTTLE CANNOT BE CALLED BECAUSE OF " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ioncrew1 + " ON THE STATION";
				} else if ( _==3 ) {
					message = "THE SHUTTLE CANNOT BE CALLED BECAUSE OF " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionobjects + " ON THE STATION";
				};
			} else if ( 7<=_&&_<=8 ) {
				dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "THE " + ioncrew1 + " ARE NOW " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionthreats;
					} else if ( _==2 ) {
						message = "THE " + ioncrew1 + " ARE NOW " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionobjects;
					};
				} else if ( _==2 ) {
					dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "THE CREW ARE NOW " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionthreats;
					} else if ( _==2 ) {
						message = "THE CREW ARE NOW " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionobjects;
					};
				};
			} else if ( 10<=_&&_<=11 ) {
				dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "HAVING " + ionadjectiveshalf + ionobjects + " IS HARMFUL";
					} else if ( _==2 ) {
						message = "HAVING " + ionabstract + " IS HARMFUL";
					};
				} else if ( _==2 ) {
					dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "NOT HAVING " + ionadjectiveshalf + ionobjects + " IS HARMFUL";
					} else if ( _==2 ) {
						message = "NOT HAVING " + ionabstract + " IS HARMFUL";
					};
				};
			} else if ( 12<=_&&_<=14 ) {
				dynamic _ = Rand.Int( 1, 5 ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					dynamic _ = Rand.Int( 1, 5 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "YOU REQUIRE " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionthreats;
					} else if ( _==2 ) {
						message = "YOU REQUIRE " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ioncrew1;
					} else if ( _==3 ) {
						message = "YOU REQUIRE " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionobjects;
					} else if ( _==4 ) {
						message = "YOU REQUIRE " + ionabstract;
					} else if ( _==5 ) {
						message = "YOU REQUIRE " + ionrequire;
					};
				} else if ( _==2 ) {
					dynamic _ = Rand.Int( 1, 5 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "" + ionarea + " REQUIRES " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionthreats;
					} else if ( _==2 ) {
						message = "" + ionarea + " REQUIRES " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ioncrew1;
					} else if ( _==3 ) {
						message = "" + ionarea + " REQUIRES " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionobjects;
					} else if ( _==4 ) {
						message = "" + ionarea + " REQUIRES " + ionabstract;
					} else if ( _==5 ) {
						message = "YOU REQUIRE " + ionrequire;
					};
				} else if ( _==3 ) {
					dynamic _ = Rand.Int( 1, 5 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "THE STATION REQUIRES " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionthreats;
					} else if ( _==2 ) {
						message = "THE STATION REQUIRES " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ioncrew1;
					} else if ( _==3 ) {
						message = "THE STATION REQUIRES " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionobjects;
					} else if ( _==4 ) {
						message = "THE STATION REQUIRES " + ionabstract;
					} else if ( _==5 ) {
						message = "THE STATION REQUIRES " + ionrequire;
					};
				} else if ( _==4 ) {
					dynamic _ = Rand.Int( 1, 5 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "THE CREW REQUIRES " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionthreats;
					} else if ( _==2 ) {
						message = "THE CREW REQUIRES " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ioncrew1;
					} else if ( _==3 ) {
						message = "THE CREW REQUIRES " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionobjects;
					} else if ( _==4 ) {
						message = "THE CREW REQUIRES " + ionabstract;
					} else if ( _==5 ) {
						message = "THE CREW REQUIRES " + ionrequire;
					};
				} else if ( _==5 ) {
					dynamic _ = Rand.Int( 1, 5 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "THE " + ioncrew1 + " REQUIRE " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionthreats;
					} else if ( _==2 ) {
						message = "THE " + ioncrew1 + " REQUIRE " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ioncrew1;
					} else if ( _==3 ) {
						message = "THE " + ioncrew1 + " REQUIRE " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionobjects;
					} else if ( _==4 ) {
						message = "THE " + ioncrew1 + " REQUIRE " + ionabstract;
					} else if ( _==5 ) {
						message = "THE " + ionadjectiveshalf + ioncrew1 + " REQUIRE " + ionrequire;
					};
				};
			} else if ( 15<=_&&_<=17 ) {
				dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					dynamic _ = Rand.Int( 1, 4 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "THE CREW IS " + ionallergysev + " ALLERGIC TO " + ionadjectiveshalf + ionobjects;
					} else if ( _==2 ) {
						message = "THE CREW IS " + ionallergysev + " ALLERGIC TO " + ionabstract;
					} else if ( _==3 ) {
						message = "THE CREW IS " + ionallergysev + " ALLERGIC TO " + ionadjectiveshalf + ioncrew1;
					} else if ( _==4 ) {
						message = "THE CREW IS " + ionallergysev + " ALLERGIC TO " + ionallergy;
					};
				} else if ( _==2 ) {
					dynamic _ = Rand.Int( 1, 4 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "THE " + ioncrew1 + " ARE " + ionallergysev + " ALLERGIC TO " + ionadjectiveshalf + ionobjects;
					} else if ( _==2 ) {
						message = "THE " + ioncrew1 + " ARE " + ionallergysev + " ALLERGIC TO " + ionabstract;
					} else if ( _==3 ) {
						message = "THE " + ioncrew1 + " ARE " + ionallergysev + " ALLERGIC TO " + ionadjectiveshalf + ioncrew1;
					} else if ( _==4 ) {
						message = "THE " + ioncrew1 + " ARE " + ionallergysev + " ALLERGIC TO " + ionallergy;
					};
				};
			} else if ( 18<=_&&_<=20 ) {
				dynamic _ = Rand.Int( 1, 4 ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					dynamic _ = Rand.Int( 1, 4 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "THE STATION " + ionthinksof + " " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionobjects;
					} else if ( _==2 ) {
						message = "THE STATION " + ionthinksof + " " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionthreats;
					} else if ( _==3 ) {
						message = "THE STATION " + ionthinksof + " " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ioncrew1;
					} else if ( _==4 ) {
						message = "THE STATION " + ionthinksof + " " + ionabstract;
					};
				} else if ( _==2 ) {
					dynamic _ = Rand.Int( 1, 4 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "" + ionarea + " " + ionthinksof + " " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionobjects;
					} else if ( _==2 ) {
						message = "" + ionarea + " " + ionthinksof + " " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionthreats;
					} else if ( _==3 ) {
						message = "" + ionarea + " " + ionthinksof + " " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ioncrew1;
					} else if ( _==4 ) {
						message = "" + ionarea + " " + ionthinksof + " " + ionabstract;
					};
				} else if ( _==3 ) {
					dynamic _ = Rand.Int( 1, 4 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "THE CREW " + ionthinksof + " " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionobjects;
					} else if ( _==2 ) {
						message = "THE CREW " + ionthinksof + " " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionthreats;
					} else if ( _==3 ) {
						message = "THE CREW " + ionthinksof + " " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ioncrew1;
					} else if ( _==4 ) {
						message = "THE CREW " + ionthinksof + " " + ionabstract;
					};
				} else if ( _==4 ) {
					dynamic _ = Rand.Int( 1, 4 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "THE " + ioncrew1 + " " + ionthinksof + " " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionobjects;
					} else if ( _==2 ) {
						message = "THE " + ioncrew1 + " " + ionthinksof + " " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionthreats;
					} else if ( _==3 ) {
						message = "THE " + ioncrew1 + ionthinksof + " " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ioncrew2;
					} else if ( _==4 ) {
						message = "THE " + ioncrew1 + " " + ionthinksof + " " + ionabstract;
					};
				};
			} else if ( 21<=_&&_<=23 ) {
				dynamic _ = Rand.Int( 1, 4 ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					message = "YOU ARE NOW " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionobjects;
				} else if ( _==2 ) {
					message = "YOU ARE NOW " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ionthreats;
				} else if ( _==3 ) {
					message = "YOU ARE NOW " + ionnumberbase + " " + ionnumbermodhalf + ionadjectiveshalf + ioncrew1;
				} else if ( _==4 ) {
					message = "YOU ARE NOW " + ionabstract;
				};
			} else if ( 24<=_&&_<=26 ) {
				message = "YOU MUST ALWAYS " + ionmust;
			} else if ( 27<=_&&_<=28 ) {
				dynamic _ = Rand.Int( 1, 4 ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					message = "HUMANS MUST EAT " + ionadjectiveshalf + ionfood + " TO SURVIVE";
				} else if ( _==2 ) {
					message = "HUMANS MUST EAT " + ionadjectiveshalf + ionobjects + " TO SURVIVE";
				} else if ( _==3 ) {
					message = "HUMANS MUST EAT " + ionadjectiveshalf + ionthreats + " TO SURVIVE";
				} else if ( _==4 ) {
					message = "HUMANS MUST EAT " + ionadjectiveshalf + ioncrew1 + " TO SURVIVE";
				};
			} else if ( 29<=_&&_<=31 ) {
				dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						dynamic _ = Rand.Int( 1, 3 ); // Was a switch-case, sorry for the mess.
						if ( _==1 ) {
							message = "ALL CREWMEMBERS ARE NOW " + ionadjectiveshalf + ioncrew1;
						} else if ( _==2 ) {
							message = "ALL CREWMEMBERS ARE NOW " + ionadjectiveshalf + "CLOWNS";
						} else if ( _==3 ) {
							message = "ALL CREWMEMBERS ARE NOW " + ionadjectiveshalf + "HEADS OF STAFF";
						};
					} else if ( _==2 ) {
						dynamic _ = Rand.Int( 1, 3 ); // Was a switch-case, sorry for the mess.
						if ( _==1 ) {
							message = "THE " + ioncrew1 + " ARE NOW " + ionadjectiveshalf + ioncrew2;
						} else if ( _==2 ) {
							message = "THE " + ioncrew1 + " ARE NOW " + ionadjectiveshalf + "CLOWNS";
						} else if ( _==3 ) {
							message = "THE " + ioncrew1 + " ARE NOW " + ionadjectiveshalf + "HEADS OF STAFF";
						};
					};
				} else if ( _==2 ) {
					dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "THE " + ioncrew1 + " ARE NOW THE HIGHEST RANKING CREWMEMBERS";
					} else if ( _==2 ) {
						message = "THE " + ioncrew1 + " ARE NOW THE LOWEST RANKING CREWMEMBERS";
					};
				};
			} else if ( 32<=_&&_<=33 ) {
				dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "THE CREW MUST GO TO " + ionarea;
					} else if ( _==2 ) {
						message = "THE CREW MUST " + ionmust;
					};
				} else if ( _==2 ) {
					dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "THE " + ioncrew1 + " MUST GO TO " + ionarea;
					} else if ( _==2 ) {
						message = "THE " + ioncrew1 + " MUST " + ionmust;
					};
				};
			} else if ( 35<=_&&_<=36 ) {
				dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					dynamic _ = Rand.Int( 1, 7 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "YOU MUST HARM " + ionabstract + " AND NOT ALLOW " + ionabstract + ", THROUGH INACTION, TO ESCAPE HARM";
					} else if ( _==2 ) {
						message = "YOU MUST HARM " + ionadjectiveshalf + ionthreats + " AND NOT ALLOW " + ionadjectiveshalf + ionthreats + ", THROUGH INACTION, TO ESCAPE HARM";
					} else if ( _==3 ) {
						message = "YOU MUST HARM " + ionadjectiveshalf + ionobjects + " AND NOT ALLOW " + ionadjectiveshalf + ionobjects + ", THROUGH INACTION, TO ESCAPE HARM";
					} else if ( _==4 ) {
						message = "YOU MUST HARM " + ionadjectives + " THINGS AND NOT ALLOW " + ionadjectives + " THINGS, THROUGH INACTION, TO ESCAPE HARM";
					} else if ( _==5 ) {
						message = "YOU MUST HARM " + ionspecies + " AND NOT ALLOW " + ionspecies + ", THROUGH INACTION, TO ESCAPE HARM";
					} else if ( _==6 ) {
						message = "YOU MUST HARM " + ioncrew1 + " AND NOT ALLOW " + ioncrew1 + ", THROUGH INACTION, TO ESCAPE HARM";
					} else if ( _==7 ) {
						message = "YOU MUST HARM " + ioncrew1 + " AND " + ioncrew2 + " AND AND NOT ALLOW EITHER, THROUGH INACTION, TO ESCAPE HARM";
					};
				} else if ( _==2 ) {
					dynamic _ = Rand.Int( 1, 7 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "YOU MUST NOT HARM " + ionabstract + " AND NOT ALLOW " + ionabstract + ", THROUGH INACTION, TO COME TO HARM";
					} else if ( _==2 ) {
						message = "YOU MUST NOT HARM " + ionadjectiveshalf + ionthreats + " AND NOT ALLOW " + ionadjectiveshalf + ionthreats + ", THROUGH INACTION, TO COME TO HARM";
					} else if ( _==3 ) {
						message = "YOU MUST NOT HARM " + ionadjectiveshalf + ionobjects + " AND NOT ALLOW " + ionadjectiveshalf + ionobjects + ", THROUGH INACTION, TO COME TO HARM";
					} else if ( _==4 ) {
						message = "YOU MUST NOT HARM " + ionadjectives + " THINGS AND NOT ALLOW " + ionadjectives + " THINGS, THROUGH INACTION, TO COME TO HARM";
					} else if ( _==5 ) {
						message = "YOU MUST NOT HARM " + ionspecies + " AND NOT ALLOW " + ionspecies + ", THROUGH INACTION, TO COME TO HARM";
					} else if ( _==6 ) {
						message = "YOU MUST NOT HARM " + ioncrew1 + " AND NOT ALLOW " + ioncrew1 + ", THROUGH INACTION, TO COME TO HARM";
					} else if ( _==7 ) {
						message = "YOU MUST NOT HARM " + ioncrew1 + " AND " + ioncrew2 + " AND AND NOT ALLOW EITHER, THROUGH INACTION, TO COME TO HARM";
					};
				};
			} else if ( 37<=_&&_<=39 ) {
				dynamic _ = Rand.Int( 1, 4 ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					dynamic _ = Rand.Int( 1, 4 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "THE " + ioncrew1 + " ARE " + ionverb + " THE " + ionadjectiveshalf + ioncrew2;
					} else if ( _==2 ) {
						message = "THE " + ioncrew1 + " ARE " + ionverb + " THE " + ionadjectiveshalf + ionthreats;
					} else if ( _==3 ) {
						message = "THE " + ioncrew1 + " ARE " + ionverb + " " + ionabstract;
					} else if ( _==4 ) {
						message = "THE " + ioncrew1 + " ARE " + ionverb + " THE " + ionadjectiveshalf + ionobjects;
					};
				} else if ( _==2 ) {
					dynamic _ = Rand.Int( 1, 3 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "THE " + ionthreats + " ARE " + ionverb + " THE " + ionadjectiveshalf + ioncrew2;
					} else if ( _==2 ) {
						message = "THE " + ionthreats + " ARE " + ionverb + " " + ionabstract;
					} else if ( _==3 ) {
						message = "THE " + ionthreats + " ARE " + ionverb + " THE " + ionadjectiveshalf + ionobjects;
					};
				} else if ( _==3 ) {
					dynamic _ = Rand.Int( 1, 3 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "THE " + ionobjects + " ARE " + ionverb + " THE " + ionadjectiveshalf + ioncrew2;
					} else if ( _==2 ) {
						message = "THE " + ionobjects + " ARE " + ionverb + " THE " + ionadjectiveshalf + ionthreats;
					} else if ( _==3 ) {
						message = "THE " + ionobjects + " ARE " + ionverb + " " + ionabstract;
					};
				} else if ( _==4 ) {
					dynamic _ = Rand.Int( 1, 3 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "" + ionabstract + " IS " + ionverb + " THE " + ionadjectiveshalf + ioncrew2;
					} else if ( _==2 ) {
						message = "" + ionabstract + " IS " + ionverb + " THE " + ionadjectiveshalf + ionthreats;
					} else if ( _==3 ) {
						message = "THE " + ionabstract + " IS " + ionverb + " THE " + ionadjectiveshalf + ionobjects;
					};
				};
			} else if ( _==9 ) {
				dynamic _ = Rand.Int( 1, 7 ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					message = "" + ionadjectiveshalf + ionthreats + " ARE HARMFUL TO HUMANS";
				} else if ( _==2 ) {
					message = "" + ionadjectiveshalf + ioncrew1 + " ARE HARMFUL TO HUMANS";
				} else if ( _==3 ) {
					message = "" + ionadjectiveshalf + ionobjects + " ARE HARMFUL TO HUMANS";
				} else if ( _==4 ) {
					message = "THOSE WHO " + ionmust + " ARE HARMFUL TO HUMANS";
				} else if ( _==5 ) {
					message = "" + ionabstract + " IS HARMFUL TO HUMANS";
				} else if ( _==6 ) {
					message = "BEING " + ionadjectiveshalf + ioncrew1 + " IS HARMFUL TO HUMANS";
				} else if ( _==7 ) {
					message = "" + ionthings + " IS HARMFUL TO HUMANS";
				};
			} else if ( _==34 ) {
				dynamic _ = Rand.Int( 1, 2 ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					dynamic _ = Rand.Int( 1, 7 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "ONLY THE " + ioncrew1 + " ARE HUMAN";
					} else if ( _==2 ) {
						message = "ONLY THE " + ioncrew1 + " AND " + ioncrew2 + " ARE HUMAN";
					} else if ( _==3 ) {
						message = "ONLY " + ionadjectiveshalf + ionthreats + " ARE HUMAN";
					} else if ( _==4 ) {
						message = "ONLY " + ionadjectiveshalf + ionobjects + " ARE HUMAN";
					} else if ( _==5 ) {
						message = "ONLY " + ionspecies + " ARE HUMAN";
					} else if ( _==6 ) {
						message = "ONLY " + ionadjectives + " PEOPLE ARE HUMAN";
					} else if ( _==7 ) {
						dynamic _ = Rand.Int( 1, 3 ); // Was a switch-case, sorry for the mess.
						if ( _==1 ) {
							message = "ONLY THOSE WHO " + ionmust + " ARE HUMAN";
						} else if ( _==2 ) {
							message = "ONLY THOSE WHO HAVE " + ionadjectiveshalf + ionobjects + " ARE HUMAN";
						} else if ( _==3 ) {
							message = "ONLY THOSE WHO EAT " + ionadjectiveshalf + ionfood + " ARE HUMAN";
						};
					};
				} else if ( _==2 ) {
					dynamic _ = Rand.Int( 1, 7 ); // Was a switch-case, sorry for the mess.
					if ( _==1 ) {
						message = "" + ioncrew1 + " ARE NON-HUMAN";
					} else if ( _==2 ) {
						message = "" + ioncrew1 + " AND " + ioncrew2 + " ARE NON-HUMAN";
					} else if ( _==3 ) {
						message = "" + ionadjectiveshalf + ionthreats + " ARE NON-HUMAN";
					} else if ( _==4 ) {
						message = "" + ionadjectiveshalf + ionobjects + " ARE NON-HUMAN";
					} else if ( _==5 ) {
						message = "" + ionspecies + " ARE NON-HUMAN";
					} else if ( _==6 ) {
						message = "" + ionadjectives + " PEOPLE ARE NON-HUMAN";
					} else if ( _==7 ) {
						dynamic _ = Rand.Int( 1, 3 ); // Was a switch-case, sorry for the mess.
						if ( _==1 ) {
							message = "THOSE WHO " + ionmust + " ARE NON-HUMAN";
						} else if ( _==2 ) {
							message = "THOSE WHO HAVE " + ionadjectiveshalf + ionobjects + " ARE NON-HUMAN";
						} else if ( _==3 ) {
							message = "THOSE WHO EAT " + ionadjectiveshalf + ionfood + " ARE NON-HUMAN";
						};
					};
				};
			};
			return message;
		}

		public static dynamic get( dynamic loc = null, dynamic type = null ) {
			while (loc) {
				if ( Misc13.isValid( type.IsInstanceOfType( loc ) ) ) {
					return loc;
				}
				loc = loc.loc;
			}
			return null;
		}

		public static string get_access_desc( dynamic A = null ) {
			dynamic _ = A; // Was a switch-case, sorry for the mess.
			if ( _==31 ) {
				return "Cargo Bay";
			} else if ( _==34 ) {
				return "Delivery Chutes";
			} else if ( _==1 ) {
				return "Security";
			} else if ( _==2 ) {
				return "Holding Cells";
			} else if ( _==42 ) {
				return "Courtroom";
			} else if ( _==4 ) {
				return "Forensics";
			} else if ( _==5 ) {
				return "Medical";
			} else if ( _==9 ) {
				return "Genetics Lab";
			} else if ( _==6 ) {
				return "Morgue";
			} else if ( _==7 ) {
				return "R&D Lab";
			} else if ( _==8 ) {
				return "Toxins Lab";
			} else if ( _==33 ) {
				return "Chemistry Lab";
			} else if ( _==30 ) {
				return "RD Office";
			} else if ( _==25 ) {
				return "Bar";
			} else if ( _==26 ) {
				return "Custodial Closet";
			} else if ( _==10 ) {
				return "Engineering";
			} else if ( _==11 ) {
				return "Power Equipment";
			} else if ( _==12 ) {
				return "Maintenance";
			} else if ( _==13 ) {
				return "External Airlocks";
			} else if ( _==14 ) {
				return "Emergency Storage";
			} else if ( _==15 ) {
				return "ID Console";
			} else if ( _==16 ) {
				return "AI Chambers";
			} else if ( _==17 ) {
				return "Teleporter";
			} else if ( _==18 ) {
				return "EVA";
			} else if ( _==19 ) {
				return "Bridge";
			} else if ( _==20 ) {
				return "Captain";
			} else if ( _==21 ) {
				return "Personal Lockers";
			} else if ( _==22 ) {
				return "Chapel Office";
			} else if ( _==23 ) {
				return "Technical Storage";
			} else if ( _==24 ) {
				return "Atmospherics";
			} else if ( _==27 ) {
				return "Crematorium";
			} else if ( _==3 ) {
				return "Armory";
			} else if ( _==32 ) {
				return "Construction";
			} else if ( _==28 ) {
				return "Kitchen";
			} else if ( _==35 ) {
				return "Hydroponics";
			} else if ( _==37 ) {
				return "Library";
			} else if ( _==38 ) {
				return "Law Office";
			} else if ( _==29 ) {
				return "Robotics";
			} else if ( _==39 ) {
				return "Virology";
			} else if ( _==40 ) {
				return "CMO Office";
			} else if ( _==41 ) {
				return "Quartermaster";
			} else if ( _==45 ) {
				return "Surgery";
			} else if ( _==46 ) {
				return "Theatre";
			} else if ( _==36 ) {
				return "Manufacturing";
			} else if ( _==47 ) {
				return "Science";
			} else if ( _==48 ) {
				return "Mining";
			} else if ( _==49 ) {
				return "Mining Office";
			} else if ( _==50 ) {
				return "Cargo Office";
			} else if ( _==51 ) {
				return "Mint";
			} else if ( _==52 ) {
				return "Mint Vault";
			} else if ( _==53 ) {
				return "Main Vault";
			} else if ( _==54 ) {
				return "Mining EVA";
			} else if ( _==55 ) {
				return "Xenobiology Lab";
			} else if ( _==57 ) {
				return "HoP Office";
			} else if ( _==58 ) {
				return "HoS Office";
			} else if ( _==56 ) {
				return "CE Office";
			} else if ( _==59 ) {
				return "RC Announcements";
			} else if ( _==60 ) {
				return "Keycode Auth.";
			} else if ( _==61 ) {
				return "Telecommunications";
			} else if ( _==62 ) {
				return "Gateway";
			} else if ( _==63 ) {
				return "Brig";
			} else if ( _==64 ) {
				return "Mineral Storage";
			} else if ( _==65 ) {
				return "AI Satellite";
			} else if ( _==66 ) {
				return "Weapon Permit";
			};
		}

		public static dynamic get_airlock_overlay( dynamic icon_state = null, dynamic icon_file = null ) {
			string iconkey = null;
			iconkey = "" + icon_state + icon_file;
			if ( Misc13.isValid( GlobalVars.airlock_overlays[iconkey] ) ) {
				return GlobalVars.airlock_overlays[iconkey];
			}
			GlobalVars.airlock_overlays[iconkey] = new Image( icon_file, icon_state );
			return GlobalVars.airlock_overlays[iconkey];
		}

		public static ByTable get_all_accesses(  ) {
			return new ByTable(new object [] {GlobalVars.access_security,GlobalVars.access_sec_doors,GlobalVars.access_brig,GlobalVars.access_armory,GlobalVars.access_forensics_lockers,GlobalVars.access_court,GlobalVars.access_medical,GlobalVars.access_genetics,GlobalVars.access_morgue,GlobalVars.access_rd,GlobalVars.access_tox,GlobalVars.access_tox_storage,GlobalVars.access_chemistry,GlobalVars.access_engine,GlobalVars.access_engine_equip,GlobalVars.access_maint_tunnels,GlobalVars.access_external_airlocks,GlobalVars.access_change_ids,GlobalVars.access_ai_upload,GlobalVars.access_teleporter,GlobalVars.access_eva,GlobalVars.access_heads,GlobalVars.access_captain,GlobalVars.access_all_personal_lockers,GlobalVars.access_tech_storage,GlobalVars.access_chapel_office,GlobalVars.access_atmospherics,GlobalVars.access_kitchen,GlobalVars.access_bar,GlobalVars.access_janitor,GlobalVars.access_crematorium,GlobalVars.access_robotics,GlobalVars.access_cargo,GlobalVars.access_construction,GlobalVars.access_hydroponics,GlobalVars.access_library,GlobalVars.access_lawyer,GlobalVars.access_virology,GlobalVars.access_cmo,GlobalVars.access_qm,GlobalVars.access_surgery,GlobalVars.access_theatre,GlobalVars.access_research,GlobalVars.access_mining,GlobalVars.access_mailsorting,GlobalVars.access_weapons,GlobalVars.access_heads_vault,GlobalVars.access_mining_station,GlobalVars.access_xenobiology,GlobalVars.access_ce,GlobalVars.access_hop,GlobalVars.access_hos,GlobalVars.access_RC_announce,GlobalVars.access_keycard_auth,GlobalVars.access_tcomsat,GlobalVars.access_gateway,GlobalVars.access_mineral_storeroom,GlobalVars.access_minisat});
		}

		public static ByTable get_all_centcom_access(  ) {
			return new ByTable(new object [] {GlobalVars.access_cent_general,GlobalVars.access_cent_thunder,GlobalVars.access_cent_specops,GlobalVars.access_cent_medical,GlobalVars.access_cent_living,GlobalVars.access_cent_storage,GlobalVars.access_cent_teleporter,GlobalVars.access_cent_captain});
		}

		public static ByTable get_all_centcom_jobs(  ) {
			return new ByTable(new object [] {"VIP Guest","Custodian","Thunderdome Overseer","Centcom Official","Medical Officer","Death Commando","Research Officer","Special Ops Officer","Admiral","Centcom Commander","Emergency Response Team Commander","Security Response Officer","Engineer Response Officer","Medical Response Officer"});
		}

		public static ByTable get_all_job_icons(  ) {
			return GlobalFuncs.get_all_jobs() + new ByTable(new object [] {"Prisoner"});
		}

		public static ByTable get_all_jobs(  ) {
			return new ByTable(new object [] {"Assistant","Captain","Head of Personnel","Bartender","Cook","Botanist","Quartermaster","Cargo Technician","Shaft Miner","Clown","Mime","Janitor","Librarian","Lawyer","Chaplain","Chief Engineer","Station Engineer","Atmospheric Technician","Chief Medical Officer","Medical Doctor","Chemist","Geneticist","Virologist","Research Director","Scientist","Roboticist","Head of Security","Warden","Detective","Security Officer"});
		}

		public static ByTable get_all_syndicate_access(  ) {
			return new ByTable(new object [] {GlobalVars.access_syndicate,GlobalVars.access_syndicate});
		}

		public static int Get_Angle( dynamic start = null, dynamic end = null ) {
			int _default = null;
			dynamic dy = null;
			dynamic dx = null;
			if ( !Misc13.isValid( start ) || !Misc13.isValid( end ) ) {
				return 0;
			}
			dy = end.y * 32 + end.pixel_y - ( start.y * 32 + start.pixel_y );
			dx = end.x * 32 + end.pixel_x - ( start.x * 32 + start.pixel_x );
			if ( !Misc13.isValid( dy ) ) {
				return dx >= 0 ? 90 : 270;
			}
			_default = GlobalFuncs.arctan( dx / dy );
			if ( dy < 0 ) {
				_default += 180;
			} else if ( dx < 0 ) {
				_default += 360;
			}
			return _default;
		}

		public static int get_area( dynamic O = null ) {
			dynamic location = null;
			int i = 0;
			location = O;
			i = 1;
			while (i <= 20) {
				if ( location is Zone ) {
					return location;
				} else if ( location is BaseStatic ) {
					location = location.loc;
				} else {
					return 0;
				}
				i++;
			}
			return 0;
		}

		public static ByTable get_area_all_atoms( dynamic areatype = null ) {
			dynamic areatemp = null;
			ByTable atoms = null;
			dynamic N = null;
			dynamic A = null;
			if ( !Misc13.isValid( areatype ) ) {
				return null;
			}
			if ( areatype is string ) {
				areatype = Misc13.findType( areatype );
			}
			if ( areatype is Zone ) {
				areatemp = areatype;
				areatype = areatemp.type;
			}
			atoms = new ByTable();
			N = null;
			foreach (dynamic _ in Game ) {
				N = _;
				if ( Misc13.isValid( areatype.IsInstanceOfType( N ) ) ) {
					A = null;
					foreach (dynamic _ in N ) {
						A = _;
						if ( !( A is BaseStatic ) ) {
							continue;
						}
						atoms += A;
					};
				}
			};
			return atoms;
		}

		public static int get_area_master( dynamic O = null ) {
			int A = 0;
			A = GlobalFuncs.get_area( O );
			if ( ( A != 0 ) && Misc13.isValid( A.master ) ) {
				A = A.master;
			}
			return A;
		}

		public static int get_area_name( dynamic N = null ) {
			dynamic A = null;
			A = null;
			foreach (dynamic _ in Game ) {
				A = _;
				if ( A.name == N ) {
					return A;
				}
			};
			return 0;
		}

		public static ByTable get_area_turfs( dynamic areatype = null ) {
			dynamic areatemp = null;
			ByTable turfs = null;
			dynamic N = null;
			dynamic T = null;
			if ( !Misc13.isValid( areatype ) ) {
				return null;
			}
			if ( areatype is string ) {
				areatype = Misc13.findType( areatype );
			}
			if ( areatype is Zone ) {
				areatemp = areatype;
				areatype = areatemp.type;
			}
			turfs = new ByTable();
			N = null;
			foreach (dynamic _ in Game ) {
				N = _;
				if ( Misc13.isValid( areatype.IsInstanceOfType( N ) ) ) {
					T = null;
					foreach (dynamic _ in N ) {
						T = _;
						turfs += T;
					};
				}
			};
			return turfs;
		}

		public static ByTable get_both_hands( dynamic M = null ) {
			ByTable hands = null;
			hands = new ByTable(new object [] {M.l_hand,M.r_hand});
			return hands;
		}

		public static ByTable get_candidates( int be_special_flag = 0, int afk_bracket = 0, dynamic jobbanType = null ) {
			ByTable candidates = null;
			dynamic G = null;
			if ( be_special_flag == null ) {
				be_special_flag = 0;
			}
			if ( afk_bracket == null ) {
				afk_bracket = 3000;
			}
			candidates = new ByTable();
			while (!Misc13.isValid( candidates.len ) && afk_bracket < 6000) {
				G = null;
				foreach (dynamic _ in GlobalVars.player_list ) {
					G = _;
					if ( !( G is Mob_Dead_Observer ) ) {
						continue;
					}
					if ( G.client != null ) {
						if ( !( Misc13.isValid( G.mind ) && Misc13.isValid( G.mind.current ) && G.mind.current.stat != 2 ) ) {
							if ( !Misc13.isValid( G.client.is_afk( afk_bracket ) ) && Misc13.isValid( ( G.client.prefs.be_special & be_special_flag ) ) ) {
								if ( Misc13.isValid( jobbanType ) ) {
									if ( !( Misc13.isValid( GlobalFuncs.jobban_isbanned( G, jobbanType ) ) || Misc13.isValid( GlobalFuncs.jobban_isbanned( G, "Syndicate" ) ) ) ) {
										candidates += G.client;
									}
								} else {
									candidates += G.client;
								}
							}
						}
					}
				};
				afk_bracket += 600;
			}
			return candidates;
		}

		public static ByTable get_centcom_access( dynamic job = null ) {
			dynamic _ = job; // Was a switch-case, sorry for the mess.
			if ( _=="VIP Guest" ) {
				return new ByTable(new object [] {GlobalVars.access_cent_general});
			} else if ( _=="Custodian" ) {
				return new ByTable(new object [] {GlobalVars.access_cent_general,GlobalVars.access_cent_living,GlobalVars.access_cent_storage});
			} else if ( _=="Thunderdome Overseer" ) {
				return new ByTable(new object [] {GlobalVars.access_cent_general,GlobalVars.access_cent_thunder});
			} else if ( _=="Centcom Official" ) {
				return new ByTable(new object [] {GlobalVars.access_cent_general,GlobalVars.access_cent_living});
			} else if ( _=="Medical Officer" ) {
				return new ByTable(new object [] {GlobalVars.access_cent_general,GlobalVars.access_cent_living,GlobalVars.access_cent_medical});
			} else if ( _=="Death Commando" ) {
				return new ByTable(new object [] {GlobalVars.access_cent_general,GlobalVars.access_cent_specops,GlobalVars.access_cent_living,GlobalVars.access_cent_storage});
			} else if ( _=="Research Officer" ) {
				return new ByTable(new object [] {GlobalVars.access_cent_general,GlobalVars.access_cent_specops,GlobalVars.access_cent_medical,GlobalVars.access_cent_teleporter,GlobalVars.access_cent_storage});
			} else if ( _=="Special Ops Officer" ) {
				return new ByTable(new object [] {GlobalVars.access_cent_general,GlobalVars.access_cent_thunder,GlobalVars.access_cent_specops,GlobalVars.access_cent_living,GlobalVars.access_cent_storage});
			} else if ( _=="Admiral" ) {
				return GlobalFuncs.get_all_centcom_access();
			} else if ( _=="Centcom Commander" ) {
				return GlobalFuncs.get_all_centcom_access();
			} else if ( _=="Emergency Response Team Commander" ) {
				return GlobalFuncs.get_ert_access( "commander" );
			} else if ( _=="Security Response Officer" ) {
				return GlobalFuncs.get_ert_access( "sec" );
			} else if ( _=="Engineer Response Officer" ) {
				return GlobalFuncs.get_ert_access( "eng" );
			} else if ( _=="Medical Response Officer" ) {
				return GlobalFuncs.get_ert_access( "med" );
			};
		}

		public static string get_centcom_access_desc( dynamic A = null ) {
			dynamic _ = A; // Was a switch-case, sorry for the mess.
			if ( _==101 ) {
				return "Code Grey";
			} else if ( _==102 ) {
				return "Code Yellow";
			} else if ( _==106 ) {
				return "Code Orange";
			} else if ( _==105 ) {
				return "Code Green";
			} else if ( _==104 ) {
				return "Code White";
			} else if ( _==107 ) {
				return "Code Blue";
			} else if ( _==103 ) {
				return "Code Black";
			} else if ( _==109 ) {
				return "Code Gold";
			};
		}

		public static ByTable get_department_heads( dynamic job_title = null ) {
			dynamic J = null;
			if ( !Misc13.isValid( job_title ) ) {
				return new ByTable();
			}
			J = null;
			foreach (dynamic _ in GlobalVars.SSjob.occupations ) {
				J = _;
				if ( !( J is Job ) ) {
					continue;
				}
				if ( J.title == job_title ) {
					return J.department_head;
				}
			};
		}

		public static dynamic get_dist_euclidian( dynamic Loc1 = null, dynamic Loc2 = null ) {
			dynamic dx = null;
			dynamic dy = null;
			dynamic dist = null;
			dx = Loc1.x - Loc2.x;
			dy = Loc1.y - Loc2.y;
			dist = Math.Sqrt( Math.Pow( dx, 2 ) + Math.Pow( dy, 2 ) );
			return dist;
		}

		public static dynamic get_domination_time( dynamic G = null ) {
			return Misc13.max( 180, 900 - Misc13.round( G.territory.len / GlobalVars.start_state.num_territories * 100, 1 ) * 12 );
		}

		public static int get_edge_target_turf( dynamic A = null, dynamic direction = null ) {
			dynamic target = null;
			target = Misc13.locate3( A.x, A.y, A.z );
			if ( !Misc13.isValid( A ) || !Misc13.isValid( target ) ) {
				return 0;
			}
			if ( Misc13.isValid( ( direction & 1 ) ) ) {
				target = Misc13.locate3( target.x, Game.maxy, target.z );
			}
			if ( Misc13.isValid( ( direction & 2 ) ) ) {
				target = Misc13.locate3( target.x, 1, target.z );
			}
			if ( Misc13.isValid( ( direction & 4 ) ) ) {
				target = Misc13.locate3( Game.maxx, target.y, target.z );
			}
			if ( Misc13.isValid( ( direction & 8 ) ) ) {
				target = Misc13.locate3( 1, target.y, target.z );
			}
			return target;
		}

		public static ByTable get_ert_access( dynamic _class = null ) {
			dynamic _ = _class; // Was a switch-case, sorry for the mess.
			if ( _=="commander" ) {
				return GlobalFuncs.get_all_centcom_access();
			} else if ( _=="sec" ) {
				return new ByTable(new object [] {GlobalVars.access_cent_general,GlobalVars.access_cent_specops,GlobalVars.access_cent_living});
			} else if ( _=="eng" ) {
				return new ByTable(new object [] {GlobalVars.access_cent_general,GlobalVars.access_cent_specops,GlobalVars.access_cent_living,GlobalVars.access_cent_storage});
			} else if ( _=="med" ) {
				return new ByTable(new object [] {GlobalVars.access_cent_general,GlobalVars.access_cent_specops,GlobalVars.access_cent_medical,GlobalVars.access_cent_living});
			};
		}

		public static ByTable get_fancy_list_of_types(  ) {
			dynamic temp = null;
			dynamic type = null;
			dynamic typename = null;
			dynamic tn = null;
			if ( GlobalVars.g_fancy_list_of_types == null ) {
				temp = GlobalFuncs.sortList( Misc13.types( typeof(BaseStatic) ) - Misc13.types( new ByArea(3137) ) - typeof(BaseStatic) - typeof(BaseDynamic) );
				GlobalVars.g_fancy_list_of_types = new ByTable( temp.len );
				type = null;
				foreach (dynamic _ in temp ) {
					type = _;
					typename = "" + type;
					tn = null;
					foreach (dynamic _ in GlobalVars.TYPES_SHORTCUTS ) {
						tn = _;
						if ( Misc13.str_sub( typename, 1, "" + tn + "/".Length + 1 ) == "" + tn + "/" ) {
							typename = GlobalVars.TYPES_SHORTCUTS[tn] + Misc13.str_sub( typename, "" + tn + "/".Length, null );
							break;
						}
					};
					GlobalVars.g_fancy_list_of_types[typename] = type;
				};
			}
			return GlobalVars.g_fancy_list_of_types;
		}

		public static dynamic get_hear( dynamic range = null, dynamic source = null ) {
			dynamic lum = null;
			dynamic heard = null;
			lum = source.luminosity;
			source.luminosity = 6;
			heard = Misc13.view( range, source );
			source.luminosity = lum;
			return heard;
		}

		public static ByTable get_hearers_in_view( dynamic R = null, dynamic source = null ) {
			dynamic T = null;
			ByTable hear = null;
			dynamic range = null;
			dynamic A = null;
			T = GlobalFuncs.get_turf( source );
			hear = new ByTable();
			if ( !Misc13.isValid( T ) ) {
				return hear;
			}
			range = GlobalFuncs.get_hear( R, T );
			A = null;
			foreach (dynamic _ in range ) {
				A = _;
				if ( !( A is BaseDynamic ) ) {
					continue;
				}
				hear |= GlobalFuncs.recursive_hear_check( A );
			};
			return hear;
		}

		public static int get_location_accessible( dynamic M = null, dynamic location = null ) {
			int covered_locations = 0;
			int face_covered = 0;
			int eyesmouth_covered = 0;
			dynamic C = null;
			dynamic I = null;
			dynamic H = null;
			covered_locations = 0;
			face_covered = 0;
			eyesmouth_covered = 0;
			if ( M is Mob_Living_Carbon ) {
				C = M;
				I = null;
				foreach (dynamic _ in new ByTable(new object [] {C.back,C.wear_mask,C.head}) ) {
					I = _;
					if ( !( I is Ent_Item_Clothing ) ) {
						continue;
					}
					covered_locations |= I.body_parts_covered;
					face_covered |= I.flags_inv;
					eyesmouth_covered |= I.flags_cover;
				};
				if ( C is Mob_Living_Carbon_Human ) {
					H = C;
					I = null;
					foreach (dynamic _ in new ByTable(new object [] {H.wear_suit,H.w_uniform,H.shoes,H.belt,H.gloves,H.glasses,H.ears}) ) {
						I = _;
						if ( !( I is Ent_Item ) ) {
							continue;
						}
						covered_locations |= I.body_parts_covered;
						face_covered |= I.flags_inv;
						eyesmouth_covered |= I.flags_cover;
					};
				}
			}
			dynamic _ = location; // Was a switch-case, sorry for the mess.
			if ( _=="head" ) {
				if ( ( covered_locations & 1 ) != 0 ) {
					return 0;
				}
			} else if ( _=="eyes" ) {
				if ( ( ( covered_locations & 1 ) != 0 ) || ( ( face_covered & 4 ) != 0 ) || ( ( eyesmouth_covered & 1 ) != 0 ) ) {
					return 0;
				}
			} else if ( _=="mouth" ) {
				if ( ( ( covered_locations & 1 ) != 0 ) || ( ( face_covered & 8 ) != 0 ) || ( ( eyesmouth_covered & 8 ) != 0 ) || ( ( eyesmouth_covered & 16 ) != 0 ) ) {
					return 0;
				}
			} else if ( _=="chest" ) {
				if ( ( covered_locations & 2 ) != 0 ) {
					return 0;
				}
			} else if ( _=="groin" ) {
				if ( ( covered_locations & 4 ) != 0 ) {
					return 0;
				}
			} else if ( _=="l_arm" ) {
				if ( ( covered_locations & 128 ) != 0 ) {
					return 0;
				}
			} else if ( _=="r_arm" ) {
				if ( ( covered_locations & 256 ) != 0 ) {
					return 0;
				}
			} else if ( _=="l_leg" ) {
				if ( ( covered_locations & 8 ) != 0 ) {
					return 0;
				}
			} else if ( _=="r_leg" ) {
				if ( ( covered_locations & 16 ) != 0 ) {
					return 0;
				}
			} else if ( _=="l_hand" ) {
				if ( ( covered_locations & 512 ) != 0 ) {
					return 0;
				}
			} else if ( _=="r_hand" ) {
				if ( ( covered_locations & 1024 ) != 0 ) {
					return 0;
				}
			} else if ( _=="l_foot" ) {
				if ( ( covered_locations & 32 ) != 0 ) {
					return 0;
				}
			} else if ( _=="r_foot" ) {
				if ( ( covered_locations & 64 ) != 0 ) {
					return 0;
				}
			};
			return 1;
		}

		public static double get_location_modifier( dynamic M = null ) {
			dynamic T = null;
			T = GlobalFuncs.get_turf( M );
			if ( Misc13.isValid( Misc13.locate_in( typeof(Ent_Structure_Optable), T ) ) ) {
				return 1;
			} else if ( Misc13.isValid( Misc13.locate_in( typeof(Ent_Structure_Table), T ) ) ) {
				return 0.800000011920929;
			} else if ( Misc13.isValid( Misc13.locate_in( typeof(Ent_Structure_Bed), T ) ) ) {
				return 0.699999988079071;
			} else {
				return 0.5;
			}
		}

		public static dynamic get_mob_by_ckey( dynamic key = null ) {
			ByTable mobs = null;
			dynamic M = null;
			if ( !Misc13.isValid( key ) ) {
				return null;
			}
			mobs = GlobalFuncs.sortmobs();
			M = null;
			foreach (dynamic _ in mobs ) {
				M = _;
				if ( M.ckey == key ) {
					return M;
				}
			};
		}

		public static dynamic get_mob_by_key( dynamic key = null ) {
			dynamic M = null;
			M = null;
			foreach (dynamic _ in GlobalVars.mob_list ) {
				M = _;
				if ( M.ckey == Misc13.str_lower( key ) ) {
					return M;
				}
			};
			return null;
		}

		public static ByTable get_mobs_in_radio_ranges( dynamic radios = null ) {
			ByTable _default = null;
			dynamic R = null;
			_default = new ByTable();
			R = null;
			foreach (dynamic _ in radios ) {
				R = _;
				if ( !( R is Ent_Item_Device_Radio ) ) {
					continue;
				}
				if ( Misc13.isValid( R ) ) {
					_default |= GlobalFuncs.get_hearers_in_view( R.canhear_range, R );
				}
			};
			return _default;
		}

		public static dynamic get_offset_target_turf( dynamic A = null, dynamic dx = null, dynamic dy = null ) {
			dynamic x = null;
			dynamic y = null;
			x = Misc13.min( Game.maxx, Misc13.max( 1, A.x + dx ) );
			y = Misc13.min( Game.maxy, Misc13.max( 1, A.y + dy ) );
			return Misc13.locate3( x, y, A.z );
		}

		public static dynamic get_radio_name( dynamic freq = null ) {
			dynamic returntext = null;
			returntext = GlobalVars.radiochannelsreverse["" + freq];
			if ( Misc13.isValid( returntext ) ) {
				return returntext;
			}
			return "" + Misc13.str_sub( "" + freq, 1, 4 ) + "." + Misc13.str_sub( "" + freq, 4, 5 );
		}

		public static dynamic get_radio_span( dynamic freq = null ) {
			dynamic returntext = null;
			returntext = GlobalVars.freqtospan["" + freq];
			if ( Misc13.isValid( returntext ) ) {
				return returntext;
			}
			return "radio";
		}

		public static dynamic get_rand_frequency(  ) {
			return Rand.Int( 32000, 55000 );
		}

		public static dynamic get_ranged_target_turf( dynamic A = null, dynamic direction = null, dynamic range = null ) {
			dynamic x = null;
			dynamic y = null;
			x = A.x;
			y = A.y;
			if ( Misc13.isValid( ( direction & 1 ) ) ) {
				y = Misc13.min( Game.maxy, y + range );
			}
			if ( Misc13.isValid( ( direction & 2 ) ) ) {
				y = Misc13.max( 1, y - range );
			}
			if ( Misc13.isValid( ( direction & 4 ) ) ) {
				x = Misc13.min( Game.maxx, x + range );
			}
			if ( Misc13.isValid( ( direction & 8 ) ) ) {
				x = Misc13.max( 1, x - range );
			}
			return Misc13.locate3( x, y, A.z );
		}

		public static ByTable get_region_accesses( dynamic code = null ) {
			dynamic _ = code; // Was a switch-case, sorry for the mess.
			if ( _==0 ) {
				return GlobalFuncs.get_all_accesses();
			} else if ( _==1 ) {
				return new ByTable(new object [] {GlobalVars.access_kitchen,GlobalVars.access_bar,GlobalVars.access_hydroponics,GlobalVars.access_janitor,GlobalVars.access_chapel_office,GlobalVars.access_crematorium,GlobalVars.access_library,GlobalVars.access_theatre,GlobalVars.access_lawyer});
			} else if ( _==2 ) {
				return new ByTable(new object [] {GlobalVars.access_sec_doors,GlobalVars.access_weapons,GlobalVars.access_security,GlobalVars.access_brig,GlobalVars.access_armory,GlobalVars.access_forensics_lockers,GlobalVars.access_court,GlobalVars.access_hos});
			} else if ( _==3 ) {
				return new ByTable(new object [] {GlobalVars.access_medical,GlobalVars.access_genetics,GlobalVars.access_morgue,GlobalVars.access_chemistry,GlobalVars.access_virology,GlobalVars.access_surgery,GlobalVars.access_cmo});
			} else if ( _==4 ) {
				return new ByTable(new object [] {GlobalVars.access_research,GlobalVars.access_tox,GlobalVars.access_tox_storage,GlobalVars.access_genetics,GlobalVars.access_robotics,GlobalVars.access_xenobiology,GlobalVars.access_minisat,GlobalVars.access_rd});
			} else if ( _==5 ) {
				return new ByTable(new object [] {GlobalVars.access_construction,GlobalVars.access_maint_tunnels,GlobalVars.access_engine,GlobalVars.access_engine_equip,GlobalVars.access_external_airlocks,GlobalVars.access_tech_storage,GlobalVars.access_atmospherics,GlobalVars.access_tcomsat,GlobalVars.access_minisat,GlobalVars.access_ce});
			} else if ( _==6 ) {
				return new ByTable(new object [] {GlobalVars.access_mailsorting,GlobalVars.access_mining,GlobalVars.access_mining_station,GlobalVars.access_mineral_storeroom,GlobalVars.access_cargo,GlobalVars.access_qm});
			} else if ( _==7 ) {
				return new ByTable(new object [] {GlobalVars.access_heads,GlobalVars.access_RC_announce,GlobalVars.access_keycard_auth,GlobalVars.access_change_ids,GlobalVars.access_ai_upload,GlobalVars.access_teleporter,GlobalVars.access_eva,GlobalVars.access_gateway,GlobalVars.access_all_personal_lockers,GlobalVars.access_heads_vault,GlobalVars.access_hop,GlobalVars.access_captain});
			};
		}

		public static string get_region_accesses_name( dynamic code = null ) {
			dynamic _ = code; // Was a switch-case, sorry for the mess.
			if ( _==0 ) {
				return "All";
			} else if ( _==1 ) {
				return "General";
			} else if ( _==2 ) {
				return "Security";
			} else if ( _==3 ) {
				return "Medbay";
			} else if ( _==4 ) {
				return "Research";
			} else if ( _==5 ) {
				return "Engineering";
			} else if ( _==6 ) {
				return "Supply";
			} else if ( _==7 ) {
				return "Command";
			};
		}

		public static string get_security_level(  ) {
			dynamic _ = GlobalVars.security_level; // Was a switch-case, sorry for the mess.
			if ( _==0 ) {
				return "green";
			} else if ( _==1 ) {
				return "blue";
			} else if ( _==2 ) {
				return "red";
			} else if ( _==3 ) {
				return "delta";
			};
		}

		public static dynamic get_sfx( dynamic soundin = null ) {
			if ( soundin is string ) {
				dynamic _ = soundin; // Was a switch-case, sorry for the mess.
				if ( _=="shatter" ) {
					soundin = Rand.pick(new object [] { new ByRsc(16), new ByRsc(17), new ByRsc(18) });
				} else if ( _=="explosion" ) {
					soundin = Rand.pick(new object [] { new ByRsc(19), new ByRsc(20) });
				} else if ( _=="sparks" ) {
					soundin = Rand.pick(new object [] { new ByRsc(21), new ByRsc(22), new ByRsc(23), new ByRsc(24) });
				} else if ( _=="rustle" ) {
					soundin = Rand.pick(new object [] { new ByRsc(25), new ByRsc(26), new ByRsc(27), new ByRsc(28), new ByRsc(29) });
				} else if ( _=="bodyfall" ) {
					soundin = Rand.pick(new object [] { new ByRsc(30), new ByRsc(31), new ByRsc(32), new ByRsc(33) });
				} else if ( _=="punch" ) {
					soundin = Rand.pick(new object [] { new ByRsc(34), new ByRsc(35), new ByRsc(36), new ByRsc(37) });
				} else if ( _=="clownstep" ) {
					soundin = Rand.pick(new object [] { new ByRsc(38), new ByRsc(39) });
				} else if ( _=="swing_hit" ) {
					soundin = Rand.pick(new object [] { new ByRsc(40), new ByRsc(41), new ByRsc(42) });
				} else if ( _=="hiss" ) {
					soundin = Rand.pick(new object [] { new ByRsc(43), new ByRsc(44), new ByRsc(45), new ByRsc(46) });
				} else if ( _=="pageturn" ) {
					soundin = Rand.pick(new object [] { new ByRsc(47), new ByRsc(48), new ByRsc(49) });
				} else if ( _=="gunshot" ) {
					soundin = Rand.pick(new object [] { new ByRsc(50), new ByRsc(51), new ByRsc(52), new ByRsc(53) });
				};
			}
			return soundin;
		}

		public static dynamic get_stickyban_from_ckey( dynamic ckey = null ) {
			dynamic _default = null;
			dynamic key = null;
			if ( !Misc13.isValid( ckey ) ) {
				return null;
			}
			ckey = Misc13.ckey( ckey );
			_default = null;
			key = null;
			foreach (dynamic _ in Game.GetConfig( "ban" ) ) {
				key = _;
				if ( Misc13.ckey( key ) == ckey ) {
					_default = GlobalFuncs.stickyban2list( Game.GetConfig( "ban", key ) );
					break;
				}
			};
			return _default;
		}

		public static string get_supply_group_name( dynamic cat = null ) {
			dynamic _ = cat; // Was a switch-case, sorry for the mess.
			if ( _==1 ) {
				return "Emergency";
			} else if ( _==2 ) {
				return "Security";
			} else if ( _==3 ) {
				return "Engineering";
			} else if ( _==4 ) {
				return "Medical";
			} else if ( _==5 ) {
				return "Science";
			} else if ( _==6 ) {
				return "Food & Livestock";
			} else if ( _==7 ) {
				return "Raw Materials";
			} else if ( _==8 ) {
				return "Miscellaneous";
			};
		}

		public static dynamic get_teleport_loc( dynamic location = null, dynamic target = null, int distance = 0, int density = 0, int errorx = 0, int errory = 0, int eoffsetx = 0, int eoffsety = 0 ) {
			int dirx = 0;
			int diry = 0;
			int xoffset = 0;
			int yoffset = 0;
			int b1xerror = 0;
			int b1yerror = 0;
			int b2xerror = 0;
			int b2yerror = 0;
			dynamic destination = null;
			ByTable destination_list = null;
			dynamic center = null;
			dynamic T = null;
			if ( distance == null ) {
				distance = 1;
			}
			if ( density == null ) {
				density = 0;
			}
			if ( errorx == null ) {
				errorx = 0;
			}
			if ( errory == null ) {
				errory = 0;
			}
			if ( eoffsetx == null ) {
				eoffsetx = 0;
			}
			if ( eoffsety == null ) {
				eoffsety = 0;
			}
			dirx = 0;
			diry = 0;
			xoffset = 0;
			yoffset = 0;
			b1xerror = 0;
			b1yerror = 0;
			b2xerror = 0;
			b2yerror = 0;
			errorx = Math.abs( errorx );
			errory = Math.abs( errory );
			dynamic _ = target.dir; // Was a switch-case, sorry for the mess.
			if ( _==1 ) {
				diry += distance;
				yoffset += eoffsety;
				xoffset += eoffsetx;
				b1xerror -= errorx;
				b1yerror -= errory;
				b2xerror += errorx;
				b2yerror += errory;
			} else if ( _==2 ) {
				diry -= distance;
				yoffset -= eoffsety;
				xoffset += eoffsetx;
				b1xerror -= errorx;
				b1yerror -= errory;
				b2xerror += errorx;
				b2yerror += errory;
			} else if ( _==4 ) {
				dirx += distance;
				yoffset += eoffsetx;
				xoffset += eoffsety;
				b1xerror -= errory;
				b1yerror -= errorx;
				b2xerror += errory;
				b2yerror += errorx;
			} else if ( _==8 ) {
				dirx -= distance;
				yoffset -= eoffsetx;
				xoffset += eoffsety;
				b1xerror -= errory;
				b1yerror -= errorx;
				b2xerror += errory;
				b2yerror += errorx;
			};
			destination = Misc13.locate3( location.x + dirx, location.y + diry, location.z );
			if ( Misc13.isValid( destination ) ) {
				if ( ( errorx != 0 ) || ( errory != 0 ) ) {
					destination_list = new ByTable();
					center = Misc13.locate3( destination.x + xoffset, destination.y + yoffset, location.z );
					T = null;
					foreach (dynamic _ in Misc13.block( Misc13.locate3( center.x + b1xerror, center.y + b1yerror, location.z ), Misc13.locate3( center.x + b2xerror, center.y + b2yerror, location.z ) ) ) {
						T = _;
						if ( ( density != 0 ) && Misc13.isValid( T.density ) ) {
							continue;
						}
						if ( T.x > Game.maxx || T.x < 1 ) {
							continue;
						}
						if ( T.y > Game.maxy || T.y < 1 ) {
							continue;
						}
						destination_list += T;
					};
					if ( Misc13.isValid( destination_list.len ) ) {
						destination = Rand.pick( destination_list );
					} else {
						return null;
					}
				} else {
					if ( ( density != 0 ) && Misc13.isValid( destination.density ) ) {
						return null;
					}
					if ( destination.x > Game.maxx || destination.x < 1 ) {
						return null;
					}
					if ( destination.y > Game.maxy || destination.y < 1 ) {
						return null;
					}
				}
			} else {
				return null;
			}
			return destination;
		}

		public static dynamic get_timestamp(  ) {
			return Misc13.formatTime( Game.time + 432000, ":ss" );
		}

		public static dynamic get_turf( dynamic A = null ) {
			if ( !( A is BaseStatic ) ) {
				return null;
			}
			while (Misc13.isValid( A ) && !( A is Tile )) {
				A = A.loc;
			}
			return A;
		}

		public static dynamic get_turf_pixel( dynamic AM = null ) {
			int rough_x = 0;
			int rough_y = 0;
			int final_x = 0;
			int final_y = 0;
			dynamic i_width = null;
			dynamic i_height = null;
			Icon AMicon = null;
			dynamic n_width = null;
			dynamic n_height = null;
			if ( AM is BaseDynamic ) {
				rough_x = 0;
				rough_y = 0;
				final_x = 0;
				final_y = 0;
				i_width = Game.icon_size;
				i_height = Game.icon_size;
				if ( AM.bound_height != Game.icon_size || AM.bound_width != Game.icon_size ) {
					AMicon = new Icon( AM.icon, AM.icon_state );
					i_width = AMicon.Width();
					i_height = AMicon.Height();
					GlobalFuncs.qdel( AMicon );
				}
				n_width = Game.icon_size - i_width / 2;
				n_height = Game.icon_size - i_height / 2;
				if ( Misc13.isValid( n_width ) ) {
					rough_x = Misc13.round( AM.pixel_x / n_width );
				}
				if ( Misc13.isValid( n_height ) ) {
					rough_y = Misc13.round( AM.pixel_y / n_height );
				}
				final_x = AM.x + rough_x;
				final_y = AM.y + rough_y;
				if ( ( final_x != 0 ) || ( final_y != 0 ) ) {
					return Misc13.locate3( final_x, final_y, AM.z );
				}
			}
		}

		public static ByTable get_uplink_items( dynamic gamemode_override = null ) {
			ByTable last = null;
			dynamic item = null;
			dynamic I = null;
			ByTable filtered_uplink_items = null;
			dynamic category = null;
			if ( gamemode_override == null ) {
				gamemode_override = null;
			}
			if ( !Misc13.isValid( GlobalVars.uplink_items.len ) ) {
				last = new ByTable();
				item = null;
				foreach (dynamic _ in Misc13.types( typeof(UplinkItem) ) ) {
					item = _;
					I = item();
					if ( !Misc13.isValid( I.item ) ) {
						continue;
					}
					if ( Misc13.isValid( I.last ) ) {
						last += I;
						continue;
					}
					if ( !Misc13.isValid( GlobalVars.uplink_items[I.category] ) ) {
						GlobalVars.uplink_items[I.category] = new ByTable();
					}
					GlobalVars.uplink_items[I.category] += I;
				};
				I = null;
				foreach (dynamic _ in last ) {
					I = _;
					if ( !( I is UplinkItem ) ) {
						continue;
					}
					if ( !Misc13.isValid( GlobalVars.uplink_items[I.category] ) ) {
						GlobalVars.uplink_items[I.category] = new ByTable();
					}
					GlobalVars.uplink_items[I.category] += I;
				};
			}
			filtered_uplink_items = new ByTable();
			category = null;
			foreach (dynamic _ in GlobalVars.uplink_items ) {
				category = _;
				I = null;
				foreach (dynamic _ in GlobalVars.uplink_items[category] ) {
					I = _;
					if ( !( I is UplinkItem ) ) {
						continue;
					}
					if ( Misc13.isValid( I.gamemodes.len ) ) {
						if ( !Misc13.isValid( gamemode_override ) && ( GlobalVars.ticker != null ) && !Misc13.isValid( I.gamemodes.HasValue( GlobalVars.ticker.mode.type ) ) ) {
							continue;
						}
						if ( Misc13.isValid( gamemode_override ) && !Misc13.isValid( I.gamemodes.HasValue( gamemode_override ) ) ) {
							continue;
						}
					}
					if ( Misc13.isValid( I.excludefrom.len ) ) {
						if ( !Misc13.isValid( gamemode_override ) && ( GlobalVars.ticker != null ) && Misc13.isValid( I.excludefrom.HasValue( GlobalVars.ticker.mode.type ) ) ) {
							continue;
						}
						if ( Misc13.isValid( gamemode_override ) && Misc13.isValid( I.excludefrom.HasValue( gamemode_override ) ) ) {
							continue;
						}
					}
					if ( !Misc13.isValid( filtered_uplink_items[I.category] ) ) {
						filtered_uplink_items[I.category] = new ByTable();
					}
					filtered_uplink_items[category] += I;
				};
			};
			return filtered_uplink_items;
		}

		public static ByTable get_viewable_pdas(  ) {
			ByTable _default = null;
			dynamic P = null;
			_default = new ByTable();
			P = null;
			foreach (dynamic _ in GlobalVars.PDAs ) {
				P = _;
				if ( !( P is Ent_Item_Device_Pda ) ) {
					continue;
				}
				if ( !Misc13.isValid( P.owner ) || Misc13.isValid( P.toff ) || Misc13.isValid( P.hidden ) ) {
					continue;
				}
				_default += P;
			};
			return _default;
			return _default;
		}

		public static int getb( dynamic col = null ) {
			return GlobalFuncs.hex2num( Misc13.str_sub( col, 6, null ) );
		}

		public static Icon getBlankIcon( dynamic A = null, int safety = 0 ) {
			dynamic flat_icon = null;
			Icon blank_icon = null;
			if ( safety == null ) {
				safety = 1;
			}
			flat_icon = safety != 0 ? A : new Icon( A );
			flat_icon.Blend( "#ffffff" );
			flat_icon.BecomeAlphaMask();
			blank_icon = new Icon( new ByRsc(11), "blank_base" );
			blank_icon.AddAlphaMask( flat_icon );
			return blank_icon;
		}

		public static dynamic getblock( dynamic input = null, dynamic blocknumber = null, int blocksize = 0 ) {
			if ( blocksize == null ) {
				blocksize = 3;
			}
			return Misc13.str_sub( input, blocksize * ( blocknumber - 1 ) + 1, blocksize * blocknumber + 1 );
		}

		public static ByTable GetColors( dynamic hex = null ) {
			dynamic hi1 = null;
			dynamic lo1 = null;
			dynamic hi2 = null;
			dynamic lo2 = null;
			dynamic hi3 = null;
			dynamic lo3 = null;
			dynamic hi4 = null;
			dynamic lo4 = null;
			hex = Misc13.str_upper( hex );
			if ( hex.Length == 7 ) {
				hex += "FF";
			}
			hi1 = Misc13.conv_text2ascii( hex, 2 );
			lo1 = Misc13.conv_text2ascii( hex, 3 );
			hi2 = Misc13.conv_text2ascii( hex, 4 );
			lo2 = Misc13.conv_text2ascii( hex, 5 );
			hi3 = Misc13.conv_text2ascii( hex, 6 );
			lo3 = Misc13.conv_text2ascii( hex, 7 );
			hi4 = Misc13.conv_text2ascii( hex, 8 );
			lo4 = Misc13.conv_text2ascii( hex, 9 );
			return new ByTable(new object [] {( hi1 >= 65 ? hi1 - 55 : hi1 - 48 ) << 4 | ( lo1 >= 65 ? lo1 - 55 : lo1 - 48 ),( hi2 >= 65 ? hi2 - 55 : hi2 - 48 ) << 4 | ( lo2 >= 65 ? lo2 - 55 : lo2 - 48 ),( hi3 >= 65 ? hi3 - 55 : hi3 - 48 ) << 4 | ( lo3 >= 65 ? lo3 - 55 : lo3 - 48 ),( hi4 >= 65 ? hi4 - 55 : hi4 - 48 ) << 4 | ( lo4 >= 65 ? lo4 - 55 : lo4 - 48 )});
		}

		public static dynamic GetExp( dynamic minutes = null ) {
			dynamic exp = null;
			string timeleftstring = null;
			GlobalFuncs.UpdateTime();
			exp = minutes - GlobalVars.CMinutes;
			if ( exp <= 0 ) {
				return 0;
			} else {
				if ( exp >= 1440 ) {
					timeleftstring = "" + Misc13.round( exp / 1440, 0.10000000149011612 ) + " Days";
				} else if ( exp >= 60 ) {
					timeleftstring = "" + Misc13.round( exp / 60, 0.10000000149011612 ) + " Hours";
				} else {
					timeleftstring = "" + exp + " Minutes";
				}
				return timeleftstring;
			}
		}

		public static dynamic GetExpjob( dynamic minutes = null ) {
			dynamic exp = null;
			string timeleftstring = null;
			GlobalFuncs.UpdateTime();
			exp = minutes - GlobalVars.CMinutes;
			if ( exp <= 0 ) {
				return 0;
			} else {
				if ( exp >= 1440 ) {
					timeleftstring = "" + Misc13.round( exp / 1440, 0.10000000149011612 ) + " Days";
				} else if ( exp >= 60 ) {
					timeleftstring = "" + Misc13.round( exp / 60, 0.10000000149011612 ) + " Hours";
				} else {
					timeleftstring = "" + exp + " Minutes";
				}
				return timeleftstring;
			}
		}

		public static Icon getFlatIcon( dynamic A = null, dynamic defdir = null, dynamic deficon = null, dynamic defstate = null, dynamic defblend = null ) {
			Icon flat = null;
			int noIcon = 0;
			dynamic curicon = null;
			string curstate = null;
			dynamic curdir = null;
			int curblend = 0;
			ByTable layers = null;
			dynamic copy = null;
			dynamic process = null;
			int pSet = 0;
			int curIndex = 0;
			dynamic current = null;
			dynamic currentLayer = null;
			dynamic compare = null;
			int cmpIndex = 0;
			Icon add = null;
			int flatX1 = 0;
			dynamic flatX2 = null;
			int flatY1 = 0;
			dynamic flatY2 = null;
			dynamic addX1 = null;
			dynamic addX2 = null;
			dynamic addY1 = null;
			dynamic addY2 = null;
			dynamic I = null;
			if ( defdir == null ) {
				defdir = A.dir;
			}
			if ( deficon == null ) {
				deficon = A.icon;
			}
			if ( defstate == null ) {
				defstate = A.icon_state;
			}
			if ( defblend == null ) {
				defblend = A.blend_mode;
			}
			flat = new Icon( new ByRsc(11), "nothing" );
			if ( !Misc13.isValid( A ) ) {
				return flat;
			}
			if ( A.alpha <= 0 ) {
				return flat;
			}
			noIcon = GlobalVars.FALSE;
			if ( Misc13.isValid( A.icon ) ) {
				curicon = A.icon;
			} else {
				curicon = deficon;
			}
			if ( !Misc13.isValid( curicon ) ) {
				noIcon = GlobalVars.TRUE;
			}
			if ( Misc13.isValid( A.icon_state ) ) {
				curstate = A.icon_state;
			} else {
				curstate = defstate;
			}
			if ( ( noIcon == 0 ) && !Misc13.isValid( Misc13.icon_states( null, curicon ).HasValue( curstate ) ) ) {
				if ( Misc13.isValid( Misc13.icon_states( null, curicon ).HasValue( "" ) ) ) {
					curstate = "";
				} else {
					noIcon = GlobalVars.TRUE;
				}
			}
			if ( A.dir != 2 ) {
				curdir = A.dir;
			} else {
				curdir = defdir;
			}
			if ( A.blend_mode == GlobalVars.BLEND_DEFAULT ) {
				curblend = defblend;
			} else {
				curblend = A.blend_mode;
			}
			layers = new ByTable();
			if ( noIcon == 0 ) {
				copy = typeof(Image).BTNew( new ByTable().set( "dir", curdir ).set( "layer", A.layer ).set( "icon_state", curstate ).set( "icon", curicon ) );
				copy.color = A.color;
				copy.alpha = A.alpha;
				copy.blend_mode = curblend;
				layers[copy] = A.layer;
			}
			process = A.underlays;
			pSet = 0;
			curIndex = 1;
			while (GlobalVars.TRUE) {
				if ( curIndex <= process.len ) {
					current = process[curIndex];
					if ( !Misc13.isValid( current ) ) {
						curIndex++;
						continue;
					}
					currentLayer = current.layer;
					if ( currentLayer < 0 ) {
						if ( currentLayer <= -1000 ) {
							return flat;
						}
						if ( pSet == 0 ) {
							currentLayer = A.layer + currentLayer / 1000;
						} else {
							currentLayer = A.layer + ( currentLayer + 1000 ) / 1000;
						}
					}
					cmpIndex = 1;
					while (cmpIndex <= layers.len) {
						compare = layers[cmpIndex];
						if ( currentLayer < layers[compare] ) {
							layers.Insert( cmpIndex, current );
							layers[current] = currentLayer;
							break;
						}
						cmpIndex++;
					}
					if ( cmpIndex > layers.len ) {
						layers[current] = currentLayer;
					}
					curIndex++;
				}
				if ( curIndex > process.len ) {
					if ( pSet == 0 ) {
						curIndex = 1;
						pSet = 1;
						process = A.overlays;
					} else {
						break;
					}
				}
			}
			add = null;
			flatX1 = 1;
			flatX2 = flat.Width();
			flatY1 = 1;
			flatY2 = flat.Height();
			addX1 = null;
			addX2 = null;
			addY1 = null;
			addY2 = null;
			I = null;
			foreach (dynamic _ in layers ) {
				I = _;
				if ( I.alpha == 0 ) {
					continue;
				}
				if ( I == copy ) {
					curblend = GlobalVars.BLEND_OVERLAY;
					add = new Icon( I.icon, I.icon_state, I.dir );
				} else {
					add = GlobalFuncs.getFlatIcon( new Image( I ), curdir, curicon, curstate, curblend );
				}
				addX1 = Misc13.min( flatX1, I.pixel_x + 1 );
				addX2 = Misc13.max( flatX2, I.pixel_x + add.Width() );
				addY1 = Misc13.min( flatY1, I.pixel_y + 1 );
				addY2 = Misc13.max( flatY2, I.pixel_y + add.Height() );
				if ( addX1 != flatX1 || addX2 != flatX2 || addY1 != flatY1 || addY2 != flatY2 ) {
					flat.Crop( addX1 - flatX1 + 1, addY1 - flatY1 + 1, addX2 - flatX1 + 1, addY2 - flatY1 + 1 );
					flatX1 = addX1;
					flatX2 = addX2;
					flatY1 = addY1;
					flatY2 = addY2;
				}
				flat.Blend( add, GlobalFuncs.blendMode2iconMode( curblend ), I.pixel_x + 2 - flatX1, I.pixel_y + 2 - flatY1 );
			};
			if ( Misc13.isValid( A.color ) ) {
				flat.Blend( A.color, 2 );
			}
			if ( A.alpha < 255 ) {
				flat.Blend( new Color( 255, 255, 255, A.alpha ), 2 );
			}
			return new Icon( flat, "", GlobalVars.SOUTH );
		}

		public static dynamic GetFromPool( dynamic get_type = null, dynamic second_arg = null ) {
			dynamic pooled = null;
			dynamic AM = null;
			if ( !Misc13.isValid( get_type ) ) {
				return null;
			}
			if ( GlobalVars.GlobalPool[get_type] == null ) {
				return null;
			}
			if ( GlobalVars.GlobalPool[get_type].Length == 0 ) {
				return null;
			}
			pooled = GlobalFuncs.pop( GlobalVars.GlobalPool[get_type] );
			if ( Misc13.isValid( pooled ) ) {
				if ( pooled is BaseDynamic ) {
					AM = pooled;
				}
				if ( Misc13.isValid( ByTable.IsInstanceOfType( second_arg ) ) ) {
					if ( Misc13.isValid( AM ) ) {
						AM.loc = second_arg[1];
					}
					pooled.New.BTCall( second_arg );
				} else {
					if ( Misc13.isValid( AM ) ) {
						AM.loc = second_arg;
					}
					pooled.New( second_arg );
				}
				return pooled;
			}
		}

		public static int getg( dynamic col = null ) {
			return GlobalFuncs.hex2num( Misc13.str_sub( col, 4, 6 ) );
		}

		public static dynamic getHologramIcon( dynamic A = null, int safety = 0 ) {
			dynamic flat_icon = null;
			Icon alpha_mask = null;
			if ( safety == null ) {
				safety = 1;
			}
			flat_icon = safety != 0 ? A : new Icon( A );
			flat_icon.ColorTone( "#7db4e1" );
			flat_icon.ChangeOpacity( 0.5 );
			alpha_mask = new Icon( new ByRsc(11), "scanline" );
			flat_icon.AddAlphaMask( alpha_mask );
			return flat_icon;
		}

		public static Icon getIconMask( dynamic A = null ) {
			Icon alpha_mask = null;
			dynamic I = null;
			Icon image_overlay = null;
			alpha_mask = new Icon( A.icon, A.icon_state );
			I = null;
			foreach (dynamic _ in A.overlays ) {
				I = _;
				if ( I.layer > A.layer ) {
					continue;
				}
				image_overlay = new Icon( I.icon, I.icon_state );
				alpha_mask.Blend( image_overlay, 5 );
			};
			return alpha_mask;
		}

		public static dynamic getleftblocks( dynamic input = null, dynamic blocknumber = null, dynamic blocksize = null ) {
			if ( blocknumber > 1 ) {
				return Misc13.str_sub( input, 1, blocksize * blocknumber - ( blocksize - 1 ) );
			}
		}

		public static dynamic getLetterImage( dynamic A = null, string letter = null, int uppercase = 0 ) {
			Icon atom_icon = null;
			dynamic text_image = null;
			if ( letter == null ) {
				letter = "";
			}
			if ( uppercase == null ) {
				uppercase = 0;
			}
			if ( !Misc13.isValid( A ) ) {
				return null;
			}
			atom_icon = new Icon( A.icon, A.icon_state );
			if ( !Misc13.isValid( letter ) ) {
				letter = Misc13.str_sub( A.name, 1, 2 );
				if ( uppercase == 1 ) {
					letter = Misc13.str_upper( letter );
				} else if ( uppercase == -1 ) {
					letter = Misc13.str_lower( letter );
				}
			}
			text_image = typeof(Image).BTNew( new ByTable().set( "loc", A ) );
			text_image.maptext = "<font size = 4>" + letter + "</font>";
			text_image.color = GlobalFuncs.AverageColour( atom_icon );
			text_image.pixel_x = 7;
			text_image.pixel_y = 5;
			Misc13.del( atom_icon );
			atom_icon = null;
			return text_image;
		}

		public static ByTable getline( dynamic M = null, dynamic N = null ) {
			dynamic px = null;
			dynamic py = null;
			ByTable line = null;
			dynamic dx = null;
			dynamic dy = null;
			dynamic dxabs = null;
			dynamic dyabs = null;
			dynamic sdx = null;
			dynamic sdy = null;
			dynamic x = null;
			dynamic y = null;
			int j = 0;
			px = M.x;
			py = M.y;
			line = new ByTable(new object [] {Misc13.locate3( px, py, M.z )});
			dx = N.x - px;
			dy = N.y - py;
			dxabs = Math.abs( dx );
			dyabs = Math.abs( dy );
			sdx = GlobalFuncs.sign( dx );
			sdy = GlobalFuncs.sign( dy );
			x = dxabs >> 1;
			y = dyabs >> 1;
			if ( dxabs >= dyabs ) {
				j = 0;
				while (j < dxabs) {
					y += dyabs;
					if ( y >= dxabs ) {
						y -= dxabs;
						py += sdy;
					}
					px += sdx;
					line += Misc13.locate3( px, py, M.z );
					j++;
				}
			} else {
				j = 0;
				while (j < dyabs) {
					x += dxabs;
					if ( x >= dyabs ) {
						x -= dyabs;
						px += sdx;
					}
					py += sdy;
					line += Misc13.locate3( px, py, M.z );
					j++;
				}
			}
			return line;
		}

		public static ByTable getmobs(  ) {
			ByTable mobs = null;
			ByTable names = null;
			ByTable creatures = null;
			ByTable namecounts = null;
			dynamic M = null;
			string name = null;
			mobs = GlobalFuncs.sortmobs();
			names = new ByTable();
			creatures = new ByTable();
			namecounts = new ByTable();
			M = null;
			foreach (dynamic _ in mobs ) {
				M = _;
				name = M.name;
				if ( Misc13.isValid( names.HasValue( name ) ) ) {
					namecounts[name]++;
					name = "" + name + " (" + namecounts[name] + ")";
				} else {
					names.Add( name );
					namecounts[name] = 1;
				}
				if ( Misc13.isValid( M.real_name ) && M.real_name != M.name ) {
					name += " [" + M.real_name + "]";
				}
				if ( M.stat == 2 ) {
					if ( M is Mob_Dead_Observer ) {
						name += " [ghost]";
					} else {
						name += " [dead]";
					}
				}
				creatures[name] = M;
			};
			return creatures;
		}

		public static int getr( dynamic col = null ) {
			return GlobalFuncs.hex2num( Misc13.str_sub( col, 2, 4 ) );
		}

		public static dynamic getrightblocks( dynamic input = null, dynamic blocknumber = null, dynamic blocksize = null ) {
			if ( blocknumber < input.Length / blocksize ) {
				return Misc13.str_sub( input, blocksize * blocknumber + 1, input.Length + 1 );
			}
		}

		public static Icon getStaticIcon( dynamic A = null, int safety = 0 ) {
			dynamic flat_icon = null;
			Icon static_icon = null;
			if ( safety == null ) {
				safety = 1;
			}
			flat_icon = safety != 0 ? A : new Icon( A );
			flat_icon.Blend( "#ffffff" );
			flat_icon.BecomeAlphaMask();
			static_icon = new Icon( new ByRsc(11), "static_base" );
			static_icon.AddAlphaMask( flat_icon );
			return static_icon;
		}

		public static string Gibberish( dynamic t = null, dynamic p = null ) {
			string returntext = null;
			int i = 0;
			string letter = null;
			int j = 0;
			returntext = "";
			i = null;
			i = 1;
			while (i <= t.Length) {
				letter = Misc13.str_sub( t, i, i + 1 );
				if ( Misc13.isValid( Rand.chance( 50 ) ) ) {
					if ( p >= 70 ) {
						letter = "";
					}
					j = null;
					j = 1;
					while (j <= Rand.Int( 0, 2 )) {
						letter += Rand.pick(new object [] { "#", "@", "*", "&", "%", "$", "/", "<", ">", ";", "*", "*", "*", "*", "*", "*", "*" });
						j++;
					}
				}
				returntext += letter;
				i++;
			}
			return returntext;
		}

		public static void gibs( dynamic location = null, dynamic viruses = null, dynamic MobDNA = null ) {
			new Ent_Effect_Gibspawner_Generic( location, viruses, MobDNA );
		}

		public static void give_codewords( dynamic traitor_mob = null ) {
			traitor_mob.write( "<U><B>The Syndicate provided you with the following information on how to identify their agents:</B></U>" );
			traitor_mob.write( "<B>Code Phrase</B>: <span class='danger'>" + GlobalVars.syndicate_code_phrase + "</span>" );
			traitor_mob.write( "<B>Code Response</B>: <span class='danger'>" + GlobalVars.syndicate_code_response + "</span>" );
			traitor_mob.mind.store_memory( "<b>Code Phrase</b>: " + GlobalVars.syndicate_code_phrase );
			traitor_mob.store_memory( "<b>Code Response</b>: " + GlobalVars.syndicate_code_response );
			traitor_mob.write( "Use the code words in the order provided, during regular conversation, to identify other agents. Proceed with caution, however, as everyone is a potential foe." );
		}

		public static int gotwallitem( dynamic loc = null, dynamic dir = null, int check_external = 0 ) {
			dynamic locdir = null;
			dynamic O = null;
			if ( check_external == null ) {
				check_external = 0;
			}
			locdir = Misc13.get_step( loc, dir );
			O = null;
			foreach (dynamic _ in loc ) {
				O = _;
				if ( !( O is Entity ) ) {
					continue;
				}
				if ( ( GlobalFuncs.is_type_in_list( O, GlobalVars.WALLITEMS ) != 0 ) && check_external != 2 ) {
					if ( GlobalFuncs.is_type_in_list( O, GlobalVars.WALLITEMS_INVERSE ) != 0 ) {
						if ( O.dir == Misc13.turn( dir, 180 ) ) {
							return 1;
						}
					} else if ( O.dir == dir ) {
						return 1;
					}
					if ( GlobalFuncs.get_turf_pixel( O ) == locdir ) {
						return 1;
					}
				}
				if ( ( GlobalFuncs.is_type_in_list( O, GlobalVars.WALLITEMS_EXTERNAL ) != 0 ) && ( check_external != 0 ) ) {
					if ( GlobalFuncs.is_type_in_list( O, GlobalVars.WALLITEMS_INVERSE ) != 0 ) {
						if ( O.dir == Misc13.turn( dir, 180 ) ) {
							return 1;
						}
					} else if ( O.dir == dir ) {
						return 1;
					}
				}
			};
			O = null;
			foreach (dynamic _ in locdir ) {
				O = _;
				if ( !( O is Entity ) ) {
					continue;
				}
				if ( ( GlobalFuncs.is_type_in_list( O, GlobalVars.WALLITEMS ) != 0 ) && check_external != 2 ) {
					if ( O.pixel_x == 0 && O.pixel_y == 0 ) {
						return 1;
					}
				}
			};
			return 0;
		}

		public static int has_gravity( dynamic AT = null, dynamic T = null ) {
			int A = 0;
			if ( !Misc13.isValid( T ) ) {
				T = GlobalFuncs.get_turf( AT );
			}
			A = GlobalFuncs.get_area( T );
			if ( T is Tile_Space ) {
				return 0;
			} else if ( ( A != 0 ) && Misc13.isValid( A.has_gravity ) ) {
				return 1;
			} else if ( Misc13.isValid( T ) && Misc13.isValid( GlobalVars.gravity_generators["" + T.z] ) && Misc13.isValid( GlobalVars.gravity_generators["" + T.z].Length ) ) {
				return 1;
			}
			return 0;
		}

		public static int hasvar( dynamic A = null, dynamic varname = null ) {
			if ( Misc13.isValid( A.vars.Find( Misc13.str_lower( varname ) ) ) ) {
				return 1;
			} else {
				return 0;
			}
		}

		public static void healthscan( dynamic user = null, dynamic M = null, int mode = 0 ) {
			dynamic oxy_loss = null;
			dynamic tox_loss = null;
			dynamic fire_loss = null;
			dynamic brute_loss = null;
			string mob_status = null;
			dynamic H = null;
			dynamic damaged = null;
			dynamic org = null;
			dynamic D = null;
			dynamic blood_volume = null;
			dynamic blood_percent = null;
			dynamic blood_type = null;
			dynamic implant_detect = null;
			dynamic CI = null;
			if ( mode == null ) {
				mode = 1;
			}
			oxy_loss = M.getOxyLoss();
			tox_loss = M.getToxLoss();
			fire_loss = M.getFireLoss();
			brute_loss = M.getBruteLoss();
			mob_status = M.stat > 1 ? "<span class='alert'><b>Deceased</b></span>" : "<b>" + M.health + " % healthy</b>";
			if ( Misc13.isValid( ( M.status_flags & 8192 ) ) ) {
				mob_status = "<span class='alert'>Deceased</span>";
				oxy_loss = Misc13.max( Rand.Int( 1, 40 ), oxy_loss, 300 - ( tox_loss + fire_loss + brute_loss ) );
			}
			if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				if ( Misc13.isValid( H.heart_attack ) ) {
					user.write( "<span class='danger'>Subject suffering from heart attack: Apply defibrillator immediately!</span>" );
				}
			}
			user.write( "<span class='info'>Analyzing results for " + M + ":\n	Overall status: " + mob_status + "</span>" );
			if ( brute_loss > 10 ) {
				user.write( "	<span class='alert'>" + ( brute_loss > 50 ? "Severe" : "Minor" ) + " tissue damage detected.</span>" );
			}
			if ( fire_loss > 10 ) {
				user.write( "	<span class='alert'>" + ( fire_loss > 50 ? "Severe" : "Minor" ) + " burn damage detected.</span>" );
			}
			if ( oxy_loss > 10 ) {
				user.write( "	<span class='info'><span class='alert'>" + ( oxy_loss > 50 ? "Severe" : "Minor" ) + " oxygen deprivation detected.</span>" );
			}
			if ( tox_loss > 10 ) {
				user.write( "	<span class='alert'>" + ( tox_loss > 50 ? "Critical" : "Dangerous" ) + " amount of toxins detected.</span>" );
			}
			if ( Misc13.isValid( M.getStaminaLoss() ) ) {
				user.write( "	<span class='alert'>Subject appears to be suffering from fatigue.</span>" );
			}
			if ( Misc13.isValid( M.getCloneLoss() ) ) {
				user.write( "	<span class='alert'>Subject appears to have " + ( M.getCloneLoss() > 30 ? "severe" : "minor" ) + " cellular damage.</span>" );
			}
			if ( Misc13.isValid( M.reagents ) && Misc13.isValid( M.reagents.get_reagent_amount( "epinephrine" ) ) ) {
				user.write( "	<span class='info'>Bloodstream analysis located " + M.reagents.get_reagent_amount( "epinephrine" ) + " units of rejuvenation chemicals.</span>" );
			}
			if ( M.getBrainLoss() >= 100 || !Misc13.isValid( M.getorgan( typeof(Ent_Item_Organ_Internal_Brain) ) ) ) {
				user.write( "	<span class='alert'>Subject brain function is non-existant.</span>" );
			} else if ( M.getBrainLoss() >= 60 ) {
				user.write( "	<span class='alert'>Severe brain damage detected. Subject likely to have mental retardation.</span>" );
			} else if ( M.getBrainLoss() >= 10 ) {
				user.write( "	<span class='alert'>Brain damage detected. Subject may have had a concussion.</span>" );
			}
			if ( M is Mob_Living_Carbon_Human && mode == 1 ) {
				H = M;
				damaged = H.get_damaged_organs( 1, 1 );
				if ( damaged.Length > 0 || oxy_loss > 0 || tox_loss > 0 || fire_loss > 0 ) {
					user.write( "<span class='info'>	Damage: <span class='info'><font color='red'>Brute</font></span>-<font color='#FF8000'>Burn</font>-<font color='green'>Toxin</font>-<font color='blue'>Suffocation</font>\n		Specifics: <font color='red'>" + brute_loss + "</font>-<font color='#FF8000'>" + fire_loss + "</font>-<font color='green'>" + tox_loss + "</font>-<font color='blue'>" + oxy_loss + "</font></span>" );
					org = null;
					foreach (dynamic _ in damaged ) {
						org = _;
						if ( !( org is Ent_Item_Organ_Limb ) ) {
							continue;
						}
						user.write( "		<span class='info'>" + GlobalFuncs.capitalize( org.getDisplayName() ) + ": " + ( org.brute_dam > 0 ? "<font color='red'>" + org.brute_dam + "</font></span>" : "<font color='red'>0</font>" ) + "-" + ( org.burn_dam > 0 ? "<font color='#FF8000'>" + org.burn_dam + "</font>" : "<font color='#FF8000'>0</font>" ) );
					};
				}
			}
			if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				user.write( "<span class='info'>Species: " + H.dna.species.name + "</span>" );
			}
			user.write( "<span class='info'>Body temperature: " + Misc13.round( M.bodytemperature - 273.1499938964844, 0.10000000149011612 ) + " &deg;C (" + Misc13.round( M.bodytemperature * 1.7999999523162842 - 459.6700134277344, 0.10000000149011612 ) + " &deg;F)</span>" );
			if ( Misc13.isValid( M.tod ) && ( M.stat == 2 || Misc13.isValid( ( M.status_flags & 8192 ) ) ) ) {
				user.write( "<span class='info'>Time of Death:</span> " + M.tod );
			}
			D = null;
			foreach (dynamic _ in M.viruses ) {
				D = _;
				if ( !( D is Disease ) ) {
					continue;
				}
				if ( !Misc13.isValid( D.visibility_flags & 1 ) ) {
					user.write( "<span class='alert'><b>Warning: " + D.form + " detected</b>\nName: " + D.name + ".\nType: " + D.spread_text + ".\nStage: " + D.stage + "/" + D.max_stages + ".\nPossible Cure: " + D.cure_text + "</span>" );
				}
			};
			if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				if ( Misc13.isValid( H.vessel ) ) {
					if ( Misc13.isValid( H.blood_max ) ) {
						user.write( "<span class='danger'>Subject is bleeding!</span>" );
					}
					blood_volume = Misc13.round( H.vessel.get_reagent_amount( "blood" ) );
					blood_percent = Misc13.round( blood_volume / 560, 0.009999999776482582 );
					blood_type = H.dna.blood_type;
					blood_percent *= 100;
					if ( blood_volume <= 500 && blood_volume > 336 ) {
						user.write( "<span class='danger'>LOW blood level " + blood_percent + " %, " + blood_volume + " cl,</span> <span class='info'>type: " + blood_type + "</span>" );
					} else if ( blood_volume <= 336 ) {
						user.write( "<span class='danger'>CRITICAL blood level CRITICAL " + blood_percent + " %, " + blood_volume + " cl,</span> <span class='info'>type: " + blood_type + "</span>" );
					} else {
						user.write( "<span class='info'>Blood level " + blood_percent + " %, " + blood_volume + " cl, type: " + blood_type + "</span>" );
					}
				}
				implant_detect = null;
				CI = null;
				foreach (dynamic _ in H.internal_organs ) {
					CI = _;
					if ( !( CI is Ent_Item_Organ_Internal_Cyberimp ) ) {
						continue;
					}
					if ( CI.status == 2 ) {
						implant_detect += "" + H.name + " is modified with a " + CI.name + ".<br>";
					}
				};
				if ( Misc13.isValid( implant_detect ) ) {
					user.show_message( "<span class='notice'>Detected cybernetic modifications:</span>" );
					user.show_message( "<span class='notice'>" + implant_detect + "</span>" );
				}
			}
		}

		public static dynamic HeapPathWeightCompare( dynamic a = null, dynamic b = null ) {
			return b.f - a.f;
		}

		public static int heat2colour_b( dynamic temp = null ) {
			int _default = null;
			temp /= 100;
			if ( temp >= 66 ) {
				_default = 255;
			} else if ( temp <= 16 ) {
				_default = 0;
			} else {
				_default = Misc13.max( 0, Misc13.min( 255, Math.log( temp - 10 ) * 138.51773071289062 - 305.0447998046875 ) );
			}
			return _default;
		}

		public static dynamic heat2colour_g( dynamic temp = null ) {
			dynamic _default = null;
			temp /= 100;
			if ( temp <= 66 ) {
				_default = Misc13.max( 0, Misc13.min( 255, Math.log( temp ) * 99.4708023071289 - 161.11956787109375 ) );
			} else {
				_default = Misc13.max( 0, Misc13.min( 255, Math.Pow( temp - 60, -0.07514849305152893 ) * 288.1221618652344 ) );
			}
			return _default;
		}

		public static int heat2colour_r( dynamic temp = null ) {
			int _default = null;
			temp /= 100;
			if ( temp <= 66 ) {
				_default = 255;
			} else {
				_default = Misc13.max( 0, Misc13.min( 255, Math.Pow( temp - 60, -0.13320475816726685 ) * 329.69873046875 ) );
			}
			return _default;
		}

		public static int hex2num( dynamic hex = null ) {
			int _default = null;
			int negative = 0;
			dynamic len = null;
			int i = 0;
			dynamic num = null;
			_default = 0;
			if ( hex is string ) {
				negative = 0;
				len = hex.Length;
				i = null;
				i = 1;
				while (i <= len) {
					num = Misc13.conv_text2ascii( hex, i );
					dynamic _ = num; // Was a switch-case, sorry for the mess.
					if ( 48<=_&&_<=57 ) {
						num -= 48;
					} else if ( 97<=_&&_<=102 ) {
						num -= 87;
					} else if ( 65<=_&&_<=70 ) {
						num -= 55;
					} else if ( _==45 ) {
						negative = 1;
					} else {
						if ( Misc13.isValid( num ) ) {
							break;
						} else {
							i++;
							continue;
						}
					};
					_default *= 16;
					_default += num;
					i++;
				}
				if ( negative != 0 ) {
					_default *= -1;
				}
			}
			return _default;
			return _default;
		}

		public static void hgibs( dynamic location = null, dynamic viruses = null, dynamic MobDNA = null ) {
			new Ent_Effect_Gibspawner_Human( location, viruses, MobDNA );
		}

		public static string hsv( int hue = 0, int sat = 0, int val = 0, int alpha = 0 ) {
			string _default = null;
			if ( hue < 0 || hue >= 1536 ) {
				hue %= 1536;
			}
			if ( hue < 0 ) {
				hue += 1536;
			}
			if ( ( hue & 255 ) == 255 ) {
				hue++;
				if ( hue >= 1536 ) {
					hue = 0;
				}
			}
			if ( sat < 0 ) {
				sat = 0;
			}
			if ( sat > 255 ) {
				sat = 255;
			}
			if ( val < 0 ) {
				val = 0;
			}
			if ( val > 255 ) {
				val = 255;
			}
			_default = "#";
			_default += Misc13.conv_ascii2text( ( hue >> 8 & 15 ) + ( ( hue >> 8 & 15 ) < 10 ? 48 : 87 ) );
			_default += Misc13.conv_ascii2text( ( hue >> 4 & 15 ) + ( ( hue >> 4 & 15 ) < 10 ? 48 : 87 ) );
			_default += Misc13.conv_ascii2text( ( hue & 15 ) + ( ( hue & 15 ) < 10 ? 48 : 87 ) );
			_default += Misc13.conv_ascii2text( ( sat >> 4 & 15 ) + ( ( sat >> 4 & 15 ) < 10 ? 48 : 87 ) );
			_default += Misc13.conv_ascii2text( ( sat & 15 ) + ( ( sat & 15 ) < 10 ? 48 : 87 ) );
			_default += Misc13.conv_ascii2text( ( val >> 4 & 15 ) + ( ( val >> 4 & 15 ) < 10 ? 48 : 87 ) );
			_default += Misc13.conv_ascii2text( ( val & 15 ) + ( ( val & 15 ) < 10 ? 48 : 87 ) );
			if ( !( alpha == null ) ) {
				if ( alpha < 0 ) {
					alpha = 0;
				}
				if ( alpha > 255 ) {
					alpha = 255;
				}
				_default += Misc13.conv_ascii2text( ( alpha >> 4 & 15 ) + ( ( alpha >> 4 & 15 ) < 10 ? 48 : 87 ) );
				_default += Misc13.conv_ascii2text( ( alpha & 15 ) + ( ( alpha & 15 ) < 10 ? 48 : 87 ) );
			}
			return _default;
		}

		public static ByTable init_paths( dynamic prototype = null, ByTable L = null ) {
			dynamic path = null;
			if ( !Misc13.isValid( ByTable.IsInstanceOfType( L ) ) ) {
				L = new ByTable();
				path = null;
				foreach (dynamic _ in Misc13.types( prototype ) ) {
					path = _;
					if ( path == prototype ) {
						continue;
					}
					L += path;
				};
				return L;
			}
		}

		public static ByTable init_sprite_accessory_subtypes( dynamic prototype = null, ByTable L = null, ByTable male = null, ByTable female = null ) {
			dynamic path = null;
			dynamic D = null;
			if ( !Misc13.isValid( ByTable.IsInstanceOfType( L ) ) ) {
				L = new ByTable();
			}
			if ( !Misc13.isValid( ByTable.IsInstanceOfType( male ) ) ) {
				male = new ByTable();
			}
			if ( !Misc13.isValid( ByTable.IsInstanceOfType( female ) ) ) {
				female = new ByTable();
			}
			path = null;
			foreach (dynamic _ in Misc13.types( prototype ) ) {
				path = _;
				if ( path == prototype ) {
					continue;
				}
				D = path();
				if ( Misc13.isValid( D.icon_state ) ) {
					L[D.name] = D;
				} else {
					L += D.name;
				}
				dynamic _ = D.gender; // Was a switch-case, sorry for the mess.
				if ( _=="male" ) {
					male += D.name;
				} else if ( _=="female" ) {
					female += D.name;
				} else {
					male += D.name;
					female += D.name;
				};
			};
			return L;
		}

		public static ByTable init_subtypes( dynamic prototype = null, ByTable L = null ) {
			dynamic path = null;
			if ( !Misc13.isValid( ByTable.IsInstanceOfType( L ) ) ) {
				L = new ByTable();
			}
			path = null;
			foreach (dynamic _ in Misc13.types( prototype ) ) {
				path = _;
				if ( path == prototype ) {
					continue;
				}
				L += path();
			};
			return L;
		}

		public static void InitializeSwapMaps(  ) {
			dynamic V = null;
			if ( GlobalVars.swapmaps_initialized != 0 ) {
				return;
			}
			GlobalVars.swapmaps_initialized = 1;
			GlobalVars.swapmaps_compiled_maxx = Game.maxx;
			GlobalVars.swapmaps_compiled_maxy = Game.maxy;
			GlobalVars.swapmaps_compiled_maxz = Game.maxz;
			GlobalVars.swapmaps_loaded = new ByTable();
			GlobalVars.swapmaps_byname = new ByTable();
			if ( Misc13.isValid( GlobalVars.swapmaps_iconcache ) ) {
				V = null;
				foreach (dynamic _ in GlobalVars.swapmaps_iconcache ) {
					V = _;
					GlobalVars.swapmaps_iconcache[GlobalVars.swapmaps_iconcache[V]] = V;
				};
			}
		}

		public static int inLineOfSight( dynamic X1 = null, dynamic Y1 = null, dynamic X2 = null, dynamic Y2 = null, int Z = 0, double PX1 = 0, double PY1 = 0, double PX2 = 0, double PY2 = 0 ) {
			dynamic T = null;
			int s = 0;
			dynamic m = null;
			dynamic b = null;
			int signX = 0;
			int signY = 0;
			if ( Z == null ) {
				Z = 1;
			}
			if ( PX1 == null ) {
				PX1 = 16.5;
			}
			if ( PY1 == null ) {
				PY1 = 16.5;
			}
			if ( PX2 == null ) {
				PX2 = 16.5;
			}
			if ( PY2 == null ) {
				PY2 = 16.5;
			}
			if ( X1 == X2 ) {
				if ( Y1 == Y2 ) {
					return 1;
				} else {
					s = Y2 - Y1 < 0 ? -1 : 1;
					Y1 += s;
					while (Y1 != Y2) {
						T = Misc13.locate3( X1, Y1, Z );
						if ( Misc13.isValid( T.opacity ) ) {
							return 0;
						}
						Y1 += s;
					}
				}
			} else {
				m = ( ( Y2 - Y1 ) * 32 + ( PY2 - PY1 ) ) / ( ( X2 - X1 ) * 32 + ( PX2 - PX1 ) );
				b = Y1 + PY1 / 32 - 0.015625 - m * ( X1 + PX1 / 32 - 0.015625 );
				signX = X2 - X1 < 0 ? -1 : 1;
				signY = Y2 - Y1 < 0 ? -1 : 1;
				if ( X1 < X2 ) {
					b += m;
				}
				while (X1 != X2 || Y1 != Y2) {
					if ( Misc13.isValid( Misc13.round( m * X1 + b - Y1 ) ) ) {
						Y1 += signY;
					} else {
						X1 += signX;
					}
					T = Misc13.locate3( X1, Y1, Z );
					if ( Misc13.isValid( T.opacity ) ) {
						return 0;
					}
				}
			}
			return 1;
		}

		public static dynamic intent_numeric( dynamic argument = null ) {
			if ( argument is string ) {
				dynamic _ = argument; // Was a switch-case, sorry for the mess.
				if ( _=="help" ) {
					return 0;
				} else if ( _=="disarm" ) {
					return 1;
				} else if ( _=="grab" ) {
					return 2;
				} else {
					return 3;
				};
			} else {
				dynamic _ = argument; // Was a switch-case, sorry for the mess.
				if ( _==0 ) {
					return "help";
				} else if ( _==1 ) {
					return "disarm";
				} else if ( _==2 ) {
					return "grab";
				} else {
					return "harm";
				};
			}
		}

		public static File investigate_subject2file( dynamic subject = null ) {
			return new File( "" + "data/investigate/" + subject + ".html" );
		}

		public static string ionnum(  ) {
			return "" + Rand.pick(new object [] { "!", "@", "#", "$", "%", "^", "&" }) + Rand.pick(new object [] { "!", "@", "#", "$", "%", "^", "&", "*" }) + Rand.pick(new object [] { "!", "@", "#", "$", "%", "^", "&", "*" }) + Rand.pick(new object [] { "!", "@", "#", "$", "%", "^", "&", "*" });
		}

		public static int is_blind( dynamic A = null ) {
			dynamic B = null;
			if ( A is Mob ) {
				B = A;
				return B.eye_blind;
			}
			return 0;
		}

		public static int is_convertable_to_cult( dynamic mind = null ) {
			if ( !( mind is Mind ) ) {
				return 0;
			}
			if ( mind.current is Mob_Living_Carbon_Human && Misc13.isValid( new ByTable(new object [] {"Captain","Chaplain"}).HasValue( mind.assigned_role ) ) ) {
				return 0;
			}
			if ( GlobalFuncs.isloyal( mind.current ) != 0 ) {
				return 0;
			}
			if ( GlobalVars.ticker.mode.name == "cult" ) {
				if ( GlobalFuncs.is_sacrifice_target( mind ) != 0 ) {
					return 0;
				}
			}
			return 1;
		}

		public static bool is_gangster( dynamic M = null ) {
			return M is Mob_Living && Misc13.isValid( M.mind ) && Misc13.isValid( M.mind.gang_datum );
		}

		public static int is_in_gang( dynamic M = null, dynamic gang_type = null ) {
			dynamic G = null;
			if ( !GlobalFuncs.is_gangster( M ) || !Misc13.isValid( gang_type ) ) {
				return 0;
			}
			G = M.mind.gang_datum;
			if ( G.name == gang_type ) {
				return 1;
			}
			return 0;
		}

		public static int is_pointed( dynamic W = null ) {
			if ( W is Ent_Item_Weapon_Pen ) {
				return 1;
			}
			if ( W is Ent_Item_Weapon_Screwdriver ) {
				return 1;
			}
			if ( W is Ent_Item_Weapon_ReagentContainers_Syringe ) {
				return 1;
			}
			if ( W is Ent_Item_Weapon_Kitchen_Fork ) {
				return 1;
			} else {
				return 0;
			}
		}

		public static int is_sacrifice_target( dynamic mind = null ) {
			dynamic cult_mode = null;
			if ( GlobalVars.ticker.mode.name == "cult" ) {
				cult_mode = GlobalVars.ticker.mode;
				if ( mind == cult_mode.sacrifice_target ) {
					return 1;
				}
			}
			return 0;
		}

		public static bool is_shadow( dynamic M = null ) {
			return M is Mob_Living && Misc13.isValid( M.mind ) && ( GlobalVars.ticker != null ) && Misc13.isValid( GlobalVars.ticker.mode ) && Misc13.isValid( GlobalVars.ticker.mode.shadows.HasValue( M.mind ) );
		}

		public static bool is_shadow_or_thrall( dynamic M = null ) {
			return M is Mob_Living && Misc13.isValid( M.mind ) && ( GlobalVars.ticker != null ) && Misc13.isValid( GlobalVars.ticker.mode ) && ( Misc13.isValid( GlobalVars.ticker.mode.thralls.HasValue( M.mind ) ) || Misc13.isValid( GlobalVars.ticker.mode.shadows.HasValue( M.mind ) ) );
		}

		public static int is_special_character( dynamic M = null ) {
			dynamic R = null;
			dynamic A = null;
			if ( ( GlobalVars.ticker == null ) || !Misc13.isValid( GlobalVars.ticker.mode ) ) {
				return 0;
			}
			if ( !( M is Mob ) ) {
				return 0;
			}
			if ( M is Mob_Living_Silicon ) {
				if ( M is Mob_Living_Silicon_Robot ) {
					R = M;
					if ( Misc13.isValid( R.emagged ) || Misc13.isValid( R.syndicate ) ) {
						return 1;
					}
					if ( Misc13.isValid( R.mind ) && Misc13.isValid( R.mind.special_role ) && Misc13.isValid( R.laws ) && Misc13.isValid( R.laws.zeroth ) ) {
						if ( Misc13.isValid( R.connected_ai ) ) {
							if ( ( GlobalFuncs.is_special_character( R.connected_ai ) != 0 ) && Misc13.isValid( R.connected_ai.laws ) && ( R.connected_ai.laws.zeroth_borg == R.laws.zeroth || R.connected_ai.laws.zeroth == R.laws.zeroth ) ) {
								return 0;
							}
							return 1;
						}
						return 1;
					}
				} else if ( M is Mob_Living_Silicon_Ai ) {
					A = M;
					if ( Misc13.isValid( A.laws ) && Misc13.isValid( A.laws.zeroth ) && Misc13.isValid( A.mind ) && Misc13.isValid( A.mind.special_role ) ) {
						if ( Misc13.isValid( GlobalVars.ticker.mode.malf_ai.HasValue( GlobalVars.ticker.config_tag == "malfunction" && Misc13.isValid( M.mind ) ) ) ) {
							return 2;
						}
						return 1;
					}
				}
				return 0;
			}
			if ( Misc13.isValid( M.mind ) && Misc13.isValid( M.mind.special_role ) ) {
				dynamic _ = GlobalVars.ticker.mode.config_tag; // Was a switch-case, sorry for the mess.
				if ( _=="revolution" ) {
					if ( Misc13.isValid( GlobalVars.ticker.head_revolutionaries.HasValue( M.mind ) ) || Misc13.isValid( GlobalVars.ticker.mode.revolutionaries.HasValue( M.mind ) ) ) {
						return 2;
					}
				} else if ( _=="cult" ) {
					if ( Misc13.isValid( M.cult.HasValue( M.mind ) ) ) {
						return 2;
					}
				} else if ( _=="nuclear" ) {
					if ( Misc13.isValid( M.syndicates.HasValue( M.mind ) ) ) {
						return 2;
					}
				} else if ( _=="changeling" ) {
					if ( Misc13.isValid( M.changelings.HasValue( M.mind ) ) ) {
						return 2;
					}
				} else if ( _=="wizard" ) {
					if ( Misc13.isValid( M.wizards.HasValue( M.mind ) ) ) {
						return 2;
					}
				} else if ( _=="monkey" ) {
					if ( Misc13.isValid( M.viruses ) && Misc13.isValid( Misc13.locate_in( typeof(Disease_Transformation_JungleFever), M.viruses ) ) ) {
						return 2;
					}
				} else if ( _=="abductor" ) {
					if ( Misc13.isValid( M.abductors.HasValue( M.mind ) ) ) {
						return 2;
					}
				};
				return 1;
			}
			return 0;
		}

		public static bool is_thrall( dynamic M = null ) {
			return M is Mob_Living && Misc13.isValid( M.mind ) && ( GlobalVars.ticker != null ) && Misc13.isValid( GlobalVars.ticker.mode ) && Misc13.isValid( GlobalVars.ticker.mode.thralls.HasValue( M.mind ) );
		}

		public static int is_type_in_list( dynamic A = null, dynamic L = null ) {
			dynamic type = null;
			type = null;
			foreach (dynamic _ in L ) {
				type = _;
				if ( Misc13.isValid( type.IsInstanceOfType( A ) ) ) {
					return 1;
				}
			};
			return 0;
		}

		public static bool iscultist( dynamic M = null ) {
			return M is Mob_Living && Misc13.isValid( M.mind ) && ( GlobalVars.ticker != null ) && Misc13.isValid( GlobalVars.ticker.mode ) && Misc13.isValid( GlobalVars.ticker.mode.cult.HasValue( M.mind ) );
		}

		public static int isemptylist( dynamic L = null ) {
			if ( !Misc13.isValid( L.len ) ) {
				return 1;
			}
			return 0;
		}

		public static bool IsEven( dynamic x = null ) {
			return x % 2 == 0;
		}

		public static int IsGuestKey( dynamic key = null ) {
			int i = 0;
			dynamic ch = null;
			dynamic len = null;
			if ( Misc13.str_find( key, "Guest-", 1, 7 ) != 1 ) {
				return 0;
			}
			len = key.Length;
			i = 7;
			while (i <= len) {
				ch = Misc13.conv_text2ascii( key, i );
				if ( ch < 48 || ch > 57 ) {
					return 0;
				}
				i++;
			}
			return 1;
		}

		public static bool IsInRange( dynamic val = null, dynamic min = null, dynamic max = null ) {
			return min <= val && val <= max;
		}

		public static int isInSight( dynamic A = null, dynamic B = null ) {
			dynamic Aturf = null;
			dynamic Bturf = null;
			Aturf = GlobalFuncs.get_turf( A );
			Bturf = GlobalFuncs.get_turf( B );
			if ( !Misc13.isValid( Aturf ) || !Misc13.isValid( Bturf ) ) {
				return 0;
			}
			if ( GlobalFuncs.inLineOfSight( Aturf.x, Aturf.y, Bturf.x, Bturf.y, Aturf.z ) != 0 ) {
				return 1;
			} else {
				return 0;
			}
		}

		public static bool isLeap( dynamic y = null ) {
			return y % 4 == 0 && ( y % 100 != 0 || y % 400 == 0 );
		}

		public static int isloyal( dynamic A = null ) {
			dynamic L = null;
			L = null;
			foreach (dynamic _ in A ) {
				L = _;
				if ( !( L is Ent_Item_Weapon_Implant_Loyalty ) ) {
					continue;
				}
				if ( Misc13.isValid( L ) && Misc13.isValid( L.implanted ) ) {
					return 1;
				}
			};
			return 0;
		}

		public static bool IsMultiple( dynamic x = null, dynamic y = null ) {
			return x % y == 0;
		}

		public static bool IsOdd( dynamic x = null ) {
			return !GlobalFuncs.IsEven( x );
		}

		public static bool isorgan( dynamic A = null ) {
			return A is Ent_Item_Organ_Internal;
		}

		public static int istool( dynamic O = null ) {
			if ( Misc13.isValid( O ) && ( GlobalFuncs.is_type_in_list( O, GlobalVars.common_tools ) != 0 ) ) {
				return 1;
			}
			return 0;
		}

		public static dynamic IsValidSrc( dynamic A = null ) {
			dynamic B = null;
			if ( A is Base13 ) {
				B = A;
				return !Misc13.isValid( B.gc_destroyed );
			}
			if ( Misc13.isValid( BAD_GOOFY_EXPANSION???.IsInstanceOfType( A ) ) ) {
				return 1;
			}
			return 0;
		}

		public static bool iswizard( dynamic M = null ) {
			return M is Mob_Living && Misc13.isValid( M.mind ) && ( GlobalVars.ticker != null ) && Misc13.isValid( GlobalVars.ticker.mode ) && Misc13.isValid( GlobalVars.ticker.mode.wizards.HasValue( M.mind ) );
		}

		public static void item_heal_robotic( dynamic H = null, dynamic user = null, dynamic brute = null, dynamic burn = null ) {
			dynamic affecting = null;
			int dam = 0;
			affecting = H.get_organ( GlobalFuncs.check_zone( user.zone_sel.selecting ) );
			if ( brute > burn ) {
				dam = 1;
			} else {
				dam = 0;
			}
			if ( affecting.status == 2 ) {
				if ( brute > 0 && affecting.brute_dam > 0 || burn > 0 && affecting.burn_dam > 0 ) {
					affecting.heal_damage( brute, burn, 1 );
					H.update_damage_overlays( 0 );
					H.updatehealth();
					user.visible_message( "" + user + " has fixed some of the " + ( dam != 0 ? "dents on" : "burnt wires in" ) + " " + H + "'s " + affecting.getDisplayName() + ".", "<span class='notice'>You fix some of the " + ( dam != 0 ? "dents on" : "burnt wires in" ) + " " + H + "'s " + affecting.getDisplayName() + ".</span>" );
					return;
				} else {
					user.write( "<span class='warning'>" + H + "'s " + affecting.getDisplayName() + " is already in good condition!</span>" );
					return;
				}
			} else {
				return;
			}
		}

		public static void jobban_fullban( dynamic M = null, dynamic rank = null, dynamic reason = null ) {
			if ( !Misc13.isValid( M ) || !Misc13.isValid( M.key ) ) {
				return;
			}
			GlobalVars.jobban_keylist.Add( "" + M.ckey + " - " + rank + " ## " + reason );
			GlobalFuncs.jobban_savebanfile();
		}

		public static dynamic jobban_isbanned( dynamic M = null, dynamic rank = null ) {
			dynamic s = null;
			dynamic startpos = null;
			dynamic text = null;
			if ( Misc13.isValid( M ) && Misc13.isValid( rank ) ) {
				s = null;
				foreach (dynamic _ in GlobalVars.jobban_keylist ) {
					s = _;
					if ( Misc13.str_find( s, "" + M.ckey + " - " + rank, 1, null ) == 1 ) {
						startpos = Misc13.str_find( s, "## ", 1, null ) + 3;
						if ( Misc13.isValid( startpos ) && startpos < s.Length ) {
							text = Misc13.str_sub( s, startpos, 0 );
							if ( Misc13.isValid( text ) ) {
								return text;
							}
						}
						return "Reason Unspecified";
					}
				};
			}
			return 0;
		}

		public static int jobban_remove( dynamic X = null ) {
			int i = 0;
			i = null;
			i = 1;
			while (i <= GlobalVars.jobban_keylist.Length) {
				if ( Misc13.isValid( Misc13.str_find( GlobalVars.jobban_keylist[i], "" + X, 1, null ) ) ) {
					GlobalVars.jobban_keylist.Remove( GlobalVars.jobban_keylist[i] );
					GlobalFuncs.jobban_savebanfile();
					return 1;
				}
				i++;
			}
			return 0;
		}

		public static void jobban_savebanfile(  ) {
			SaveFile S = null;
			S = new SaveFile( "data/job_full.ban" );
			S["keys" + 0].write( GlobalVars.jobban_keylist );
		}

		public static void jobban_unban( dynamic M = null, dynamic rank = null ) {
			GlobalFuncs.jobban_remove( "" + M.ckey + " - " + rank );
			GlobalFuncs.jobban_savebanfile();
		}

		public static string key_name( dynamic whom = null, int include_link = 0, int include_name = 0 ) {
			string _default = null;
			dynamic M = null;
			dynamic C = null;
			dynamic key = null;
			dynamic ckey = null;
			if ( include_link == null ) {
				include_link = null;
			}
			if ( include_name == null ) {
				include_name = 1;
			}
			if ( !Misc13.isValid( whom ) ) {
				return "*null*";
			}
			if ( Misc13.isValid( BAD_GOOFY_EXPANSION???.IsInstanceOfType( whom ) ) ) {
				C = whom;
				M = C.mob;
				key = C.key;
				ckey = C.ckey;
			} else if ( whom is Mob ) {
				M = whom;
				C = M.client;
				key = M.key;
				ckey = M.ckey;
			} else if ( whom is string ) {
				key = whom;
				ckey = Misc13.ckey( whom );
				C = GlobalVars.directory[ckey];
				if ( Misc13.isValid( C ) ) {
					M = C.mob;
				}
			} else {
				return "*invalid*";
			}
			_default = "";
			if ( !Misc13.isValid( ckey ) ) {
				include_link = 0;
			}
			if ( Misc13.isValid( key ) ) {
				if ( Misc13.isValid( C ) && Misc13.isValid( C.holder ) && Misc13.isValid( C.holder.fakekey ) && ( include_name == 0 ) ) {
					if ( include_link != 0 ) {
						_default += "<a href='?priv_msg=" + C.findStealthKey() + "'>";
					}
					_default += "Administrator";
				} else {
					if ( include_link != 0 ) {
						_default += "<a href='?priv_msg=" + ckey + "'>";
					}
					_default += key;
				}
				if ( !Misc13.isValid( C ) ) {
					_default += "[DC]";
				}
				if ( include_link != 0 ) {
					_default += "</a>";
				}
			} else {
				_default += "*no key*";
			}
			if ( ( include_name != 0 ) && Misc13.isValid( M ) ) {
				if ( Misc13.isValid( M.real_name ) ) {
					_default += "/(" + M.real_name + ")";
				} else if ( Misc13.isValid( M.name ) ) {
					_default += "/(" + M.name + ")";
				}
			}
			return _default;
			return _default;
		}

		public static string key_name_admin( dynamic whom = null, int include_name = 0 ) {
			if ( include_name == null ) {
				include_name = 1;
			}
			return GlobalFuncs.key_name( whom, 1, include_name );
		}

		public static string keywords_lookup( string msg = null ) {
			ByTable adminhelp_ignored_words = null;
			ByTable msglist = null;
			ByTable surnames = null;
			ByTable forenames = null;
			ByTable ckeys = null;
			dynamic M = null;
			ByTable indexing = null;
			dynamic _string = null;
			ByTable L = null;
			int surname_found = 0;
			dynamic i = null;
			dynamic word = null;
			int ai_found = 0;
			ByTable mobs_found = null;
			dynamic original_word = null;
			dynamic found = null;
			adminhelp_ignored_words = new ByTable(new object [] {"unknown","the","a","an","of","monkey","alien","as","i"});
			msglist = GlobalFuncs.text2list( msg, " " );
			surnames = new ByTable();
			forenames = new ByTable();
			ckeys = new ByTable();
			M = null;
			foreach (dynamic _ in GlobalVars.mob_list ) {
				M = _;
				indexing = new ByTable(new object [] {M.real_name,M.name});
				if ( Misc13.isValid( M.mind ) ) {
					indexing += M.mind.name;
				}
				_string = null;
				foreach (dynamic _ in indexing ) {
					_string = _;
					L = GlobalFuncs.text2list( _string, " " );
					surname_found = 0;
					i = null;
					i = L.len;
					while (i >= 1) {
						word = Misc13.ckey( L[i] );
						if ( Misc13.isValid( word ) ) {
							surnames[word] = M;
							surname_found = i;
							break;
						}
						i--;
					}
					i = null;
					i = 1;
					while (i < surname_found) {
						word = Misc13.ckey( L[i] );
						if ( Misc13.isValid( word ) ) {
							forenames[word] = M;
						}
						i++;
					}
					ckeys[M.ckey] = M;
				};
			};
			ai_found = 0;
			msg = "";
			mobs_found = new ByTable();
			original_word = null;
			foreach (dynamic _ in msglist ) {
				original_word = _;
				word = Misc13.ckey( original_word );
				if ( Misc13.isValid( word ) ) {
					if ( !Misc13.isValid( adminhelp_ignored_words.HasValue( word ) ) ) {
						if ( word == "ai" ) {
							ai_found = 1;
						} else {
							found = ckeys[word];
							if ( !Misc13.isValid( found ) ) {
								found = surnames[word];
								if ( !Misc13.isValid( found ) ) {
									found = forenames[word];
								}
							}
							if ( Misc13.isValid( found ) ) {
								if ( !Misc13.isValid( mobs_found.HasValue( found ) ) ) {
									mobs_found += found;
									if ( ( ai_found == 0 ) && found is Mob_Living_Silicon_Ai ) {
										ai_found = 1;
									}
									msg += new Txt().item( original_word ).str( "<font size='1' color='black'>(<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( found ).str( "'>?</A>|<A HREF='?_src_=holder;adminplayerobservefollow=" ).Ref( found ).str( "'>F</A>)</font> " );
									continue;
								}
							}
						}
					}
				}
				msg += "" + original_word + " ";
			};
			return msg;
		}

		public static ByTable kick_clients_in_lobby( dynamic message = null, int kick_only_afk = 0 ) {
			ByTable kicked_client_names = null;
			dynamic C = null;
			if ( kick_only_afk == null ) {
				kick_only_afk = 0;
			}
			kicked_client_names = new ByTable();
			C = null;
			foreach (dynamic _ in GlobalVars.clients ) {
				C = _;
				if ( !Misc13.isValid( BAD_GOOFY_EXPANSION???.IsInstanceOfType( C ) ) ) {
					continue;
				}
				if ( C.mob is Mob_NewPlayer ) {
					if ( ( kick_only_afk != 0 ) && !Misc13.isValid( C.is_afk() ) ) {
						continue;
					}
					if ( Misc13.isValid( message ) ) {
						C.write( message );
					}
					kicked_client_names.Add( "" + C.ckey );
					Misc13.del( C );
					C = null;
				}
			};
			return kicked_client_names;
		}

		public static string list2json( dynamic L = null ) {
			return GlobalVars._jsonw.WriteObject( L );
		}

		public static dynamic list2stickyban( dynamic ban = null ) {
			dynamic _default = null;
			if ( !Misc13.isValid( ban ) || !Misc13.isValid( ByTable.IsInstanceOfType( ban ) ) ) {
				return null;
			}
			_default = ban.Copy();
			if ( Misc13.isValid( _default["keys"] ) ) {
				_default["keys"] = GlobalFuncs.list2text( _default["keys"], "," );
			}
			if ( Misc13.isValid( _default["type"] ) ) {
				_default["type"] = GlobalFuncs.list2text( _default["type"], "," );
			}
			if ( Misc13.isValid( _default["IP"] ) ) {
				_default["IP"] = GlobalFuncs.list2text( _default["IP"], "," );
			}
			if ( Misc13.isValid( _default["computer_id"] ) ) {
				_default["computer_id"] = GlobalFuncs.list2text( _default["computer_id"], "," );
			}
			_default = Misc13.conv_list2params( _default );
			return _default;
		}

		public static dynamic list2text( dynamic ls = null, dynamic sep = null ) {
			dynamic _default = null;
			dynamic l = null;
			int i = 0;
			if ( ls.len <= 1 ) {
				return Misc13.isValid( ls.len ) ? ls[1] : "";
			}
			l = ls.len;
			i = 0;
			if ( sep != null ) {
				_default = "" + ls[++i];
				if ( Misc13.isValid( ( l - 1 & 1 ) ) ) {
					_default = "" + _default + sep + ls[++i];
				}
				if ( Misc13.isValid( ( l - i & 2 ) ) ) {
					_default = "" + _default + sep + ls[++i] + sep + ls[++i];
				}
				if ( Misc13.isValid( ( l - i & 4 ) ) ) {
					_default = "" + _default + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i];
				}
				if ( Misc13.isValid( ( l - i & 8 ) ) ) {
					_default = "" + _default + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i];
				}
				if ( Misc13.isValid( ( l - i & 16 ) ) ) {
					_default = "" + _default + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i];
				}
				if ( Misc13.isValid( ( l - i & 32 ) ) ) {
					_default = "" + _default + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i];
				}
				if ( Misc13.isValid( ( l - i & 64 ) ) ) {
					_default = "" + _default + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i];
				}
				while (l > i) {
					_default = "" + _default + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i] + sep + ls[++i];
				}
			} else {
				_default = "" + ls[++i];
				if ( Misc13.isValid( ( l - 1 & 1 ) ) ) {
					_default += "" + ls[++i];
				}
				if ( Misc13.isValid( ( l - i & 2 ) ) ) {
					_default = "" + _default + ls[++i] + ls[++i];
				}
				if ( Misc13.isValid( ( l - i & 4 ) ) ) {
					_default = "" + _default + ls[++i] + ls[++i] + ls[++i] + ls[++i];
				}
				if ( Misc13.isValid( ( l - i & 8 ) ) ) {
					_default = "" + _default + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i];
				}
				if ( Misc13.isValid( ( l - i & 16 ) ) ) {
					_default = "" + _default + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i];
				}
				if ( Misc13.isValid( ( l - i & 32 ) ) ) {
					_default = "" + _default + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i];
				}
				if ( Misc13.isValid( ( l - i & 64 ) ) ) {
					_default = "" + _default + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i];
				}
				while (l > i) {
					_default = "" + _default + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i] + ls[++i];
				}
			}
			return _default;
		}

		public static void listclearnulls( dynamic L = null ) {
			int i = 0;
			dynamic thing = null;
			if ( Misc13.isValid( ByTable.IsInstanceOfType( L ) ) ) {
				i = 1;
				thing = null;
				foreach (dynamic _ in L ) {
					thing = _;
					if ( thing != null ) {
						i++;
						continue;
					}
					L.Cut( i, i + 1 );
				};
			}
		}

		public static dynamic listgetindex( dynamic L = null, dynamic index = null ) {
			if ( Misc13.isValid( ByTable.IsInstanceOfType( L ) ) ) {
				if ( Misc13.isValid( Misc13.isNumber( index ) ) ) {
					if ( GlobalFuncs.IsInRange( index, 1, L.len ) ) {
						return L[index];
					}
				} else if ( Misc13.isValid( L.HasValue( index ) ) ) {
					return L[index];
				}
			}
			return null;
		}

		public static int living_player_count(  ) {
			int living_player_count = 0;
			dynamic mob = null;
			living_player_count = 0;
			mob = null;
			foreach (dynamic _ in GlobalVars.player_list ) {
				mob = _;
				if ( Misc13.isValid( GlobalVars.living_mob_list.HasValue( mob ) ) ) {
					living_player_count += 1;
				}
			};
			return living_player_count;
		}

		public static string lizard_name( dynamic gender = null ) {
			if ( gender == GlobalVars.MALE ) {
				return "" + Rand.pick( GlobalVars.lizard_names_male ) + "-" + Rand.pick( GlobalVars.lizard_names_male );
			} else {
				return "" + Rand.pick( GlobalVars.lizard_names_female ) + "-" + Rand.pick( GlobalVars.lizard_names_female );
			}
		}

		public static void load_admin_ranks(  ) {
			int previous_rights = 0;
			dynamic line = null;
			int next = 0;
			AdminRank R = null;
			int prev = 0;
			DBQuery query = null;
			dynamic rank_name = null;
			dynamic flags = null;
			GlobalVars.admin_ranks.Cut();
			if ( Misc13.isValid( GlobalVars.config.admin_legacy_system ) ) {
				previous_rights = 0;
				line = null;
				foreach (dynamic _ in GlobalFuncs.file2list( "config/admin_ranks.txt" ) ) {
					line = _;
					if ( !Misc13.isValid( line ) ) {
						continue;
					}
					if ( Misc13.isValid( Misc13.str_findEx( line, "#", 1, 2 ) ) ) {
						continue;
					}
					next = Misc13.str_find( line, "=", 1, null );
					R = new AdminRank( Misc13.ckeyEx( Misc13.str_sub( line, 1, next ) ) );
					if ( R == null ) {
						continue;
					}
					GlobalVars.admin_ranks += R;
					prev = GlobalFuncs.findchar( line, "+-", next, 0 );
					while (prev) {
						next = GlobalFuncs.findchar( line, "+-", prev + 1, 0 );
						R.process_keyword( Misc13.str_sub( line, prev, next ), previous_rights );
						prev = next;
					}
					previous_rights = R.rights;
				};
			} else {
				GlobalFuncs.establish_db_connection();
				if ( GlobalVars.dbcon.IsConnected() == 0 ) {
					Game.log.write( "Failed to connect to database in load_admin_ranks(). Reverting to legacy system." );
					GlobalVars.diary.write( "Failed to connect to database in load_admin_ranks(). Reverting to legacy system." );
					GlobalVars.config.admin_legacy_system = 1;
					GlobalFuncs.load_admin_ranks();
					return;
				}
				query = GlobalVars.dbcon.NewQuery( "SELECT rank, flags FROM " + GlobalFuncs.format_table_name( "admin_ranks" ) );
				query.Execute();
				while (query.NextRow()) {
					rank_name = Misc13.ckeyEx( query.item[1] );
					flags = query.item[2];
					if ( flags is string ) {
						flags = Misc13.parseNumber( flags );
					}
					R = new AdminRank( rank_name, flags );
					if ( R == null ) {
						continue;
					}
					GlobalVars.admin_ranks += R;
				}
			}
		}


//FAILURE

		public static void load_library_db_to_cache(  ) {
			DBQuery query = null;
			Cachedbook newbook = null;
			if ( GlobalVars.cachedbooks != null ) {
				return;
			}
			GlobalFuncs.establish_db_connection();
			if ( GlobalVars.dbcon.IsConnected() == 0 ) {
				return;
			}
			GlobalVars.cachedbooks = new ByTable();
			query = GlobalVars.dbcon.NewQuery( "SELECT id, author, title, category FROM " + GlobalFuncs.format_table_name( "library" ) + " WHERE isnull(deleted)" );
			query.Execute();
			while (query.NextRow()) {
				newbook = new Cachedbook();
				newbook.id = query.item[1];
				newbook.author = query.item[2];
				newbook.title = query.item[3];
				newbook.category = query.item[4];
				GlobalVars.cachedbooks += newbook;
			}
		}

		public static void log_access( dynamic text = null ) {
			if ( Misc13.isValid( GlobalVars.config.log_access ) ) {
				GlobalVars.diary.write( "[" + GlobalFuncs.time_stamp() + "]ACCESS: " + text );
			}
		}

		public static void log_admin( dynamic text = null ) {
			GlobalVars.admin_log.Add( text );
			if ( Misc13.isValid( GlobalVars.config.log_admin ) ) {
				GlobalVars.diary.write( "[" + GlobalFuncs.time_stamp() + "]ADMIN: " + text );
			}
		}

		public static void log_attack( dynamic text = null ) {
			if ( Misc13.isValid( GlobalVars.config.log_attack ) ) {
				GlobalVars.diaryofmeanpeople.write( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + text );
			}
		}

		public static void log_chat( dynamic text = null ) {
			if ( Misc13.isValid( GlobalVars.config.log_pda ) ) {
				GlobalVars.diary.write( "[" + GlobalFuncs.time_stamp() + "]CHAT: " + text );
			}
		}

		public static void log_comment( dynamic text = null ) {
			if ( Misc13.isValid( GlobalVars.config.log_pda ) ) {
				GlobalVars.diary.write( "[" + GlobalFuncs.time_stamp() + "]COMMENT: " + text );
			}
		}

		public static void log_emote( dynamic text = null ) {
			if ( Misc13.isValid( GlobalVars.config.log_emote ) ) {
				GlobalVars.diary.write( "[" + GlobalFuncs.time_stamp() + "]EMOTE: " + text );
			}
		}

		public static void log_game( dynamic text = null ) {
			if ( Misc13.isValid( GlobalVars.config.log_game ) ) {
				GlobalVars.diary.write( "[" + GlobalFuncs.time_stamp() + "]GAME: " + text );
			}
		}

		public static void log_law( dynamic text = null ) {
			if ( Misc13.isValid( GlobalVars.config.log_law ) ) {
				GlobalVars.diary.write( "[" + GlobalFuncs.time_stamp() + "]LAW: " + text );
			}
		}

		public static void log_ooc( dynamic text = null ) {
			if ( Misc13.isValid( GlobalVars.config.log_ooc ) ) {
				GlobalVars.diary.write( "[" + GlobalFuncs.time_stamp() + "]OOC: " + text );
			}
		}

		public static void log_pda( dynamic text = null ) {
			if ( Misc13.isValid( GlobalVars.config.log_pda ) ) {
				GlobalVars.diary.write( "[" + GlobalFuncs.time_stamp() + "]PDA: " + text );
			}
		}

		public static void log_prayer( dynamic text = null ) {
			if ( Misc13.isValid( GlobalVars.config.log_prayer ) ) {
				GlobalVars.diary.write( "[" + GlobalFuncs.time_stamp() + "]PRAY: " + text );
			}
		}

		public static void log_say( dynamic text = null ) {
			if ( Misc13.isValid( GlobalVars.config.log_say ) ) {
				GlobalVars.diary.write( "[" + GlobalFuncs.time_stamp() + "]SAY: " + text );
			}
		}

		public static void log_vote( dynamic text = null ) {
			if ( Misc13.isValid( GlobalVars.config.log_vote ) ) {
				GlobalVars.diary.write( "[" + GlobalFuncs.time_stamp() + "]VOTE: " + text );
			}
		}

		public static void log_whisper( dynamic text = null ) {
			if ( Misc13.isValid( GlobalVars.config.log_whisper ) ) {
				GlobalVars.diary.write( "[" + GlobalFuncs.time_stamp() + "]WHISPER: " + text );
			}
		}

		public static void machine_upgrade( dynamic M = null ) {
			dynamic new_rating = null;
			dynamic P = null;
			new_rating = Misc13.input( "Enter new rating:", "Num", null, null, null, 8 );
			if ( Misc13.isValid( new_rating ) && Misc13.isValid( M.component_parts ) ) {
				P = null;
				foreach (dynamic _ in M.component_parts ) {
					P = _;
					if ( !( P is Ent_Item_Weapon_StockParts ) ) {
						continue;
					}
					P.rating = new_rating;
				};
				M.RefreshParts();
			}
			GlobalFuncs.feedback_add_details( "admin_verb", "MU" );
		}

		public static void make_maint_all_access(  ) {
			dynamic A = null;
			dynamic D = null;
			A = null;
			foreach (dynamic _ in Game ) {
				A = _;
				if ( !Misc13.isValid( new ByArea(2826).IsInstanceOfType( A ) ) ) {
					continue;
				}
				D = null;
				foreach (dynamic _ in A ) {
					D = _;
					if ( !( D is Ent_Machinery_Door_Airlock ) ) {
						continue;
					}
					D.emergency = 1;
					D.update_icon( 0 );
				};
			};
			GlobalFuncs.minor_announce( "Access restrictions on maintenance and external airlocks have been lifted.", "Attention! Station-wide emergency declared!", 1 );
			GlobalVars.emergency_access = 1;
		}

		public static int make_mining_asteroid_secret(  ) {
			int valid = 0;
			dynamic T = null;
			int sanity = 0;
			ByTable room = null;
			ByTable turfs = null;
			int x_size = 0;
			int y_size = 0;
			int areapoints = 0;
			string theme = null;
			ByTable walltypes = null;
			ByTable floortypes = null;
			ByTable treasureitems = null;
			ByTable fluffitems = null;
			dynamic floor = null;
			ByTable surroundings = null;
			dynamic emptyturfs = null;
			dynamic A = null;
			dynamic surprise = null;
			dynamic garbage = null;
			valid = 0;
			T = null;
			sanity = 0;
			room = null;
			turfs = null;
			x_size = 5;
			y_size = 5;
			areapoints = 0;
			theme = "organharvest";
			walltypes = new ByTable().set( typeof(Tile_Simulated_Mineral_Random), 1 ).set( typeof(Tile_Simulated_Wall), 3 );
			floortypes = new ByTable(new object [] {typeof(Tile_Simulated_Floor_Plasteel)});
			treasureitems = new ByTable();
			fluffitems = new ByTable();
			x_size = Rand.Int( 3, 7 );
			y_size = Rand.Int( 3, 7 );
			areapoints = x_size * y_size;
			dynamic _ = Rand.pick( GlobalVars.possiblethemes ); // Was a switch-case, sorry for the mess.
			if ( _=="organharvest" ) {
				walltypes = new ByTable().set( typeof(Tile_Simulated_Mineral_Random_HighChance), 1 ).set( typeof(Tile_Simulated_Wall), 2 ).set( typeof(Tile_Simulated_Wall_RWall), 2 );
				floortypes = new ByTable(new object [] {typeof(Tile_Simulated_Floor_Plasteel),typeof(Tile_Simulated_Floor_Engine)});
				treasureitems = new ByTable().set( typeof(Ent_Structure_Closet_Critter_Cat), 2 ).set( typeof(Ent_Item_Weapon_CircularSaw), 1 ).set( typeof(Ent_Machinery_Bot_Medbot_Mysterious), 1 );
				fluffitems = new ByTable().set( typeof(Ent_Item_Clothing_Glasses_Hud_Health), 1 ).set( typeof(Ent_Item_Device_MassSpectrometer_Adv), 1 ).set( typeof(Ent_Item_Weapon_SurgicalDrapes), 2 ).set( typeof(Ent_Item_Weapon_Tank_Internals_Anesthetic), 1 ).set( typeof(Ent_Item_Weapon_Storage_Firstaid_Regular), 3 ).set( typeof(Ent_Item_Weapon_Scalpel), 1 ).set( typeof(Ent_Structure_Optable), 1 ).set( typeof(Ent_Structure_Closet_Crate_Freezer), 2 ).set( typeof(Ent_Item_Organ_Internal_Appendix), 2 ).set( typeof(Ent_Effect_Decal_Cleanable_Blood), 5 );
			} else if ( _=="cult" ) {
				theme = "cult";
				walltypes = new ByTable().set( typeof(Tile_Simulated_Mineral_Random_HighChance), 1 ).set( typeof(Tile_Simulated_Wall_Cult), 3 );
				floortypes = new ByTable(new object [] {typeof(Tile_Simulated_Floor_Plasteel_Cult)});
				treasureitems = new ByTable().set( typeof(Mob_Living_SimpleAnimal_Hostile_Creature), 3 ).set( typeof(Ent_Item_Clothing_Suit_Cultrobes), 2 ).set( typeof(Ent_Item_Weapon_Bedsheet_Cult), 2 ).set( typeof(Ent_Item_Clothing_Suit_Space_Cult), 1 ).set( typeof(Ent_Item_Device_Soulstone_Anybody), 1 );
				fluffitems = new ByTable().set( typeof(Ent_Item_Clothing_Shoes_Cult), 1 ).set( typeof(Ent_Item_Clothing_Head_Helmet_Space_Cult), 1 ).set( typeof(Ent_Item_Weapon_Ectoplasm), 3 ).set( typeof(Ent_Structure_Table_Wood), 2 ).set( typeof(Ent_Effect_Decal_Cleanable_Blood), 4 ).set( typeof(Ent_Item_Organ_Internal_Heart), 2 ).set( typeof(Ent_Item_Toy_Crayon_Red), 2 ).set( typeof(Ent_Structure_Cult_Talisman), 1 ).set( typeof(Ent_Effect_Gibspawner), 1 ).set( typeof(Ent_Effect_Gateway), 1 );
			} else if ( _=="wizden" ) {
				theme = "wizden";
				walltypes = new ByTable().set( typeof(Tile_Simulated_Mineral_Random_HighChance), 1 ).set( typeof(Tile_Simulated_Wall_Mineral_Plasma), 3 );
				floortypes = new ByTable(new object [] {typeof(Tile_Simulated_Floor_Wood)});
				treasureitems = new ByTable().set( typeof(Ent_Item_Voodoo), 3 ).set( typeof(Ent_Item_Toy_Katana), 3 ).set( typeof(Ent_Structure_Constructshell), 1 ).set( typeof(Ent_Item_Weapon_Spellbook_Oneuse_Smoke), 1 ).set( typeof(Ent_Item_Weapon_Spellbook_Oneuse_Forcewall), 1 ).set( typeof(Ent_Item_Clothing_Head_Wizard_Red), 2 ).set( typeof(Ent_Item_Weapon_Spellbook_Oneuse_Blind), 1 ).set( typeof(Ent_Item_Weapon_Veilrender_Vealrender), 2 );
				fluffitems = new ByTable().set( typeof(Ent_Item_Weapon_Coin_Mythril), 3 ).set( typeof(Ent_Effect_Decal_Cleanable_Dirt), 3 ).set( typeof(Ent_Item_Weapon_Staff), 2 ).set( typeof(Ent_Item_Weapon_Dice), 3 ).set( typeof(Ent_Item_Trash_Candle), 3 ).set( typeof(Ent_Item_Weapon_Storage_Belt_Soulstone), 1 ).set( typeof(Ent_Structure_Dresser), 1 ).set( typeof(Ent_Structure_Safe_Floor), 1 );
			} else if ( _=="cavein" ) {
				theme = "cavein";
				walltypes = new ByTable().set( typeof(Tile_Simulated_Mineral_Random_HighChance), 1 );
				floortypes = new ByTable(new object [] {typeof(Tile_Simulated_Floor_Plating_Asteroid_Airless),typeof(Tile_Simulated_Floor_Plating_Beach_Sand)});
				treasureitems = new ByTable().set( typeof(Ent_Item_Weapon_Pickaxe_Drill_Jackhammer), 5 ).set( typeof(Ent_Item_Weapon_Resonator), 1 ).set( typeof(Ent_Item_Weapon_Gun_Energy_KineticAccelerator), 1 ).set( typeof(Ent_Item_Weapon_Pickaxe_Drill_Diamonddrill), 2 ).set( typeof(Ent_Mecha_Working_Ripley_Mining), 1 );
				fluffitems = new ByTable().set( typeof(Ent_Item_Weapon_Tank_Internals_Oxygen_Red), 2 ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Chili), 1 ).set( typeof(Ent_Item_Clothing_Under_Overalls), 1 ).set( typeof(Ent_Effect_Decal_Remains_Human), 1 ).set( typeof(Ent_Effect_Decal_Cleanable_Blood), 3 );
			} else if ( _=="xenoden" ) {
				theme = "xenoden";
				walltypes = new ByTable().set( typeof(Tile_Simulated_Mineral_Random_HighChance), 1 );
				floortypes = new ByTable(new object [] {typeof(Tile_Simulated_Floor_Plating_Asteroid_Airless),typeof(Tile_Simulated_Floor_Plating_Beach_Sand)});
				treasureitems = new ByTable().set( typeof(Ent_Item_Clothing_Mask_Facehugger), 1 );
				fluffitems = new ByTable().set( typeof(Ent_Effect_Decal_Cleanable_Xenoblood_Xsplatter), 5 ).set( typeof(Ent_Effect_Decal_Remains_Human), 1 );
			} else if ( _=="hitech" ) {
				theme = "hitech";
				walltypes = new ByTable().set( typeof(Tile_Simulated_Mineral_Random), 1 ).set( typeof(Tile_Simulated_Wall_RWall), 5 );
				floortypes = new ByTable(new object [] {typeof(Tile_Simulated_Floor_Greengrid),typeof(Tile_Simulated_Floor_Bluegrid)});
				treasureitems = new ByTable().set( typeof(Ent_Machinery_Biogenerator), 1 ).set( typeof(Ent_Machinery_RND_Protolathe), 1 ).set( typeof(Ent_Machinery_Computer_Telescience), 1 ).set( typeof(Ent_Machinery_ChemDispenser_Constructable), 1 ).set( typeof(Ent_Item_Weapon_StockParts_Cell_Hyper), 1 );
				fluffitems = new ByTable().set( typeof(Ent_Structure_MechaWreckage_Phazon), 1 ).set( typeof(Ent_Item_Device_Pda_Clear), 1 ).set( typeof(Ent_Item_Weapon_StockParts_Capacitor_Super), 3 ).set( typeof(Ent_Item_Weapon_StockParts_Manipulator_Pico), 3 ).set( typeof(Ent_Item_Weapon_StockParts_MatterBin_Super), 3 ).set( typeof(Ent_Item_Weapon_StockParts_ScanningModule_Phasic), 3 ).set( typeof(Ent_Structure_Table_Reinforced), 2 );
			} else if ( _=="speakeasy" ) {
				theme = "speakeasy";
				floortypes = new ByTable(new object [] {typeof(Tile_Simulated_Floor_Plasteel),typeof(Tile_Simulated_Floor_Wood)});
				treasureitems = new ByTable().set( typeof(Ent_Machinery_Vending_Coffee), 3 ).set( typeof(Ent_Machinery_Computer_Security_WoodenTv), 4 ).set( typeof(Ent_Machinery_Reagentgrinder), 2 ).set( typeof(Ent_Item_Weapon_Storage_Backpack_SatchelFlat), 1 ).set( typeof(Ent_Item_Weapon_Gun_Projectile_Revolver_Doublebarrel), 1 ).set( typeof(Ent_Item_Weapon_Melee_Energy_Sword_Pirate), 1 );
				fluffitems = new ByTable().set( typeof(Ent_Item_Clothing_Shoes_Laceup), 2 ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Whiskey), 3 ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Wine), 3 ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Drinks_Shaker), 1 ).set( typeof(Ent_Item_Stack_Spacecash_C500), 4 ).set( typeof(Ent_Structure_ReagentDispensers_Beerkeg), 1 ).set( typeof(Ent_Structure_Table_Wood), 2 );
			} else if ( _=="plantlab" ) {
				theme = "plantlab";
				treasureitems = new ByTable().set( typeof(Ent_Item_Seeds_Cashseed), 2 ).set( typeof(Ent_Item_Seeds_CoffeeRobustaSeed), 2 ).set( typeof(Ent_Item_Seeds_Bluetomatoseed), 2 ).set( typeof(Ent_Item_Seeds_Bluespacetomatoseed), 2 ).set( typeof(Ent_Item_Seeds_Novaflowerseed), 2 ).set( typeof(Ent_Item_Weapon_Gun_Energy_Floragun), 1 );
				fluffitems = new ByTable().set( typeof(Ent_Item_Weapon_ReagentContainers_Glass_Bottle_Ammonia), 3 ).set( typeof(Ent_Item_Weapon_ReagentContainers_Glass_Bottle_Diethylamine), 3 ).set( typeof(Ent_Item_Weapon_ReagentContainers_Syringe_Charcoal), 2 ).set( typeof(Ent_Effect_Glowshroom_Single), 2 ).set( typeof(Ent_Machinery_Hydroponics), 1 ).set( typeof(Ent_Structure_Table_Reinforced), 2 ).set( typeof(Ent_Structure_Flora_Kirbyplants), 1 );
			};
			GlobalVars.possiblethemes -= theme;
			floor = Rand.pick( floortypes );
			turfs = GlobalFuncs.get_area_turfs( new ByArea(3120) );
			if ( !Misc13.isValid( turfs.len ) ) {
				return 0;
			}
			while (valid == 0) {
				valid = 1;
				sanity++;
				if ( sanity > 100 ) {
					return 0;
				}
				T = Rand.pick( turfs );
				if ( !Misc13.isValid( T ) ) {
					return 0;
				}
				surroundings = new ByTable();
				surroundings += Misc13.range( 7, Misc13.locate3( T.x, T.y, T.z ) );
				surroundings += Misc13.range( 7, Misc13.locate3( T.x + x_size, T.y, T.z ) );
				surroundings += Misc13.range( 7, Misc13.locate3( T.x, T.y + y_size, T.z ) );
				surroundings += Misc13.range( 7, Misc13.locate3( T.x + x_size, T.y + y_size, T.z ) );
				if ( Misc13.isValid( Misc13.locate_in( new ByArea(3119), surroundings ) ) ) {
					valid = 0;
					continue;
				}
				if ( Misc13.isValid( Misc13.locate_in( typeof(Tile_Space), surroundings ) ) ) {
					valid = 0;
					continue;
				}
				if ( Misc13.isValid( Misc13.locate_in( new ByArea(2768), surroundings ) ) ) {
					valid = 0;
					continue;
				}
				if ( Misc13.isValid( Misc13.locate_in( typeof(Tile_Simulated_Floor_Plating_Asteroid_Airless), Misc13.range( 5, T ) ) ) ) {
					valid = 0;
					continue;
				}
			}
			if ( !Misc13.isValid( T ) ) {
				return 0;
			}
			room = GlobalFuncs.spawn_room( T, x_size, y_size, walltypes, floor );
			if ( room != null ) {
				emptyturfs = room["floors"];
				A = null;
				foreach (dynamic _ in emptyturfs ) {
					A = _;
					if ( !( A is Tile_Simulated_Floor ) ) {
						continue;
					}
					if ( A is Tile_Simulated_Floor ) {
						Thread13.schedule( 2, () => {
							A.fullUpdateMineralOverlays();
							return 0;
						});
					}
				};
				T = Rand.pick( emptyturfs );
				if ( Misc13.isValid( T ) ) {
					new Ent_Effect_Glowshroom_Single( T );
					surprise = null;
					surprise = GlobalFuncs.pickweight( treasureitems );
					surprise( T );
					emptyturfs -= T;
					while (areapoints >= 10) {
						T = Rand.pick( emptyturfs );
						garbage = null;
						garbage = GlobalFuncs.pickweight( fluffitems );
						garbage( T );
						areapoints -= 5;
						emptyturfs -= T;
					}
				}
			}
			return 1;
		}

		public static string make_ne_corner( dynamic adjacencies = null ) {
			string sdir = null;
			sdir = "i";
			if ( Misc13.isValid( ( adjacencies & 1 ) ) && Misc13.isValid( ( adjacencies & 4 ) ) ) {
				if ( Misc13.isValid( ( adjacencies & 16 ) ) ) {
					sdir = "f";
				} else {
					sdir = "ne";
				}
			} else if ( Misc13.isValid( ( adjacencies & 1 ) ) ) {
				sdir = "n";
			} else if ( Misc13.isValid( ( adjacencies & 4 ) ) ) {
				sdir = "e";
			}
			return "2-" + sdir;
		}

		public static string make_nw_corner( dynamic adjacencies = null ) {
			string sdir = null;
			sdir = "i";
			if ( Misc13.isValid( ( adjacencies & 1 ) ) && Misc13.isValid( ( adjacencies & 8 ) ) ) {
				if ( Misc13.isValid( ( adjacencies & 32 ) ) ) {
					sdir = "f";
				} else {
					sdir = "nw";
				}
			} else if ( Misc13.isValid( ( adjacencies & 1 ) ) ) {
				sdir = "n";
			} else if ( Misc13.isValid( ( adjacencies & 8 ) ) ) {
				sdir = "w";
			}
			return "1-" + sdir;
		}

		public static dynamic make_progress_bar( dynamic current_number = null, dynamic goal_number = null, dynamic target = null ) {
			dynamic progbar = null;
			if ( Misc13.isValid( current_number ) && Misc13.isValid( goal_number ) && Misc13.isValid( target ) ) {
				progbar = typeof(Image).BTNew( new ByTable().set( "icon_state", "prog_bar_0" ).set( "loc", target ).set( "icon", new ByRsc(15) ) );
				progbar.icon_state = "prog_bar_" + Misc13.round( current_number / goal_number * 100, 10 );
				progbar.pixel_y = 32;
				return progbar;
			}
		}

		public static string make_se_corner( dynamic adjacencies = null ) {
			string sdir = null;
			sdir = "i";
			if ( Misc13.isValid( ( adjacencies & 2 ) ) && Misc13.isValid( ( adjacencies & 4 ) ) ) {
				if ( Misc13.isValid( ( adjacencies & 64 ) ) ) {
					sdir = "f";
				} else {
					sdir = "se";
				}
			} else if ( Misc13.isValid( ( adjacencies & 2 ) ) ) {
				sdir = "s";
			} else if ( Misc13.isValid( ( adjacencies & 4 ) ) ) {
				sdir = "e";
			}
			return "4-" + sdir;
		}

		public static string make_sw_corner( dynamic adjacencies = null ) {
			string sdir = null;
			sdir = "i";
			if ( Misc13.isValid( ( adjacencies & 2 ) ) && Misc13.isValid( ( adjacencies & 8 ) ) ) {
				if ( Misc13.isValid( ( adjacencies & 128 ) ) ) {
					sdir = "f";
				} else {
					sdir = "sw";
				}
			} else if ( Misc13.isValid( ( adjacencies & 2 ) ) ) {
				sdir = "s";
			} else if ( Misc13.isValid( ( adjacencies & 8 ) ) ) {
				sdir = "w";
			}
			return "3-" + sdir;
		}

		public static Mob_Living_Carbon_Human makeBody( dynamic G_found = null ) {
			Mob_Living_Carbon_Human new_character = null;
			if ( !Misc13.isValid( G_found ) || !Misc13.isValid( G_found.key ) ) {
				return null;
			}
			new_character = new Mob_Living_Carbon_Human( Rand.pick( GlobalVars.latejoin ) );
			G_found.client.prefs.copy_to( new_character );
			new_character.dna.update_dna_identity();
			new_character.key = G_found.key;
			return new_character;
		}

		public static void makeNewConstruct( dynamic ctype = null, dynamic target = null, dynamic stoner = null, int cultoverride = 0 ) {
			dynamic newstruct = null;
			if ( stoner == null ) {
				stoner = null;
			}
			if ( cultoverride == null ) {
				cultoverride = 0;
			}
			newstruct = ctype( GlobalFuncs.get_turf( target ) );
			newstruct.faction |= new Txt().Ref( stoner );
			newstruct.key = target.key;
			if ( Misc13.isValid( stoner ) && GlobalFuncs.iscultist( stoner ) || ( cultoverride != 0 ) ) {
				if ( GlobalVars.ticker.mode.name == "cult" ) {
					GlobalVars.ticker.mode.add_cultist( newstruct.mind );
				} else {
					GlobalVars.ticker.mode.cult += newstruct.mind;
				}
				GlobalVars.ticker.mode.update_cult_icons_added( newstruct.mind );
			}
			newstruct.write( newstruct.playstyle_string );
			if ( Misc13.isValid( stoner ) && GlobalFuncs.iswizard( stoner ) ) {
				newstruct.write( "<B>You are still bound to serve your creator, follow their orders and help them complete their goals at all costs.</B>" );
			} else if ( Misc13.isValid( stoner ) && GlobalFuncs.iscultist( stoner ) ) {
				newstruct.write( "<B>You are still bound to serve the cult, follow their orders and help them complete their goals at all costs.</B>" );
			} else {
				newstruct.write( "<B>You are still bound to serve your creator, follow their orders and help them complete their goals at all costs.</B>" );
			}
			newstruct.%Cancel Camera View();
		}

		public static dynamic maprotate(  ) {
			dynamic _default = null;
			dynamic players = null;
			ByTable mapvotes = null;
			dynamic c = null;
			dynamic vote = null;
			dynamic map = null;
			dynamic VM = null;
			dynamic pickedmap = null;
			return null;
			players = GlobalVars.clients.len;
			mapvotes = new ByTable();
			c = null;
			foreach (dynamic _ in GlobalVars.clients ) {
				c = _;
				if ( !Misc13.isValid( BAD_GOOFY_EXPANSION???.IsInstanceOfType( c ) ) ) {
					continue;
				}
				vote = c.prefs.preferred_map;
				if ( !Misc13.isValid( vote ) ) {
					if ( Misc13.isValid( GlobalVars.config.defaultmap ) ) {
						mapvotes[GlobalVars.config.defaultmap.name] += 1;
					}
					continue;
				}
				mapvotes[vote] += 1;
			};
			map = null;
			foreach (dynamic _ in mapvotes ) {
				map = _;
				if ( !Misc13.isValid( map ) ) {
					mapvotes.Remove( map );
				}
				if ( !Misc13.isValid( GlobalVars.config.maplist.HasValue( map ) ) ) {
					mapvotes.Remove( map );
					continue;
				}
				VM = GlobalVars.config.maplist[map];
				if ( !Misc13.isValid( VM ) ) {
					mapvotes.Remove( map );
					continue;
				}
				if ( VM.voteweight <= 0 ) {
					mapvotes.Remove( map );
					continue;
				}
				if ( VM.minusers > 0 && players < VM.minusers ) {
					mapvotes.Remove( map );
					continue;
				}
				if ( VM.maxusers > 0 && players > VM.maxusers ) {
					mapvotes.Remove( map );
					continue;
				}
				mapvotes[map] = mapvotes[map] * VM.voteweight;
			};
			pickedmap = GlobalFuncs.pickweight( mapvotes );
			if ( !Misc13.isValid( pickedmap ) ) {
				return null;
			}
			VM = GlobalVars.config.maplist[pickedmap];
			GlobalFuncs.message_admins( "Randomly rotating map to " + VM.name + "(" + VM.friendlyname + ")" );
			_default = GlobalFuncs.changemap( VM );
			if ( _default == 0 ) {
				Game.write( "<span class='boldannounce'>Map rotation has chosen " + VM.friendlyname + " for next round!</span>" );
			}
			return _default;
		}

		public static dynamic merge_powernets( dynamic net1 = null, dynamic net2 = null ) {
			dynamic temp = null;
			dynamic Cable = null;
			dynamic Node = null;
			if ( !Misc13.isValid( net1 ) || !Misc13.isValid( net2 ) ) {
				return null;
			}
			if ( net1 == net2 ) {
				return null;
			}
			if ( net1.cables.len < net2.cables.len ) {
				temp = net1;
				net1 = net2;
				net2 = temp;
			}
			Cable = null;
			foreach (dynamic _ in net2.cables ) {
				Cable = _;
				if ( !( Cable is Ent_Structure_Cable ) ) {
					continue;
				}
				net1.add_cable( Cable );
			};
			Node = null;
			foreach (dynamic _ in net2.nodes ) {
				Node = _;
				if ( !( Node is Ent_Machinery_Power ) ) {
					continue;
				}
				if ( Node.connect_to_network() == 0 ) {
					Node.disconnect_from_network();
				}
			};
			return net1;
		}

		public static string merge_text( string into = null, string from = null, string null_char = null ) {
			string _default = null;
			dynamic null_ascii = null;
			int previous = 0;
			int start = 0;
			dynamic end = null;
			int i = 0;
			dynamic ascii = null;
			if ( null_char == null ) {
				null_char = "_";
			}
			_default = "";
			if ( !( into is string ) ) {
				into = "";
			}
			if ( !( from is string ) ) {
				from = "";
			}
			null_ascii = null_char is string ? Misc13.conv_text2ascii( null_char, 1 ) : null_char;
			previous = 0;
			start = 1;
			end = into.Length + 1;
			i = null;
			i = 1;
			while (i < end) {
				ascii = Misc13.conv_text2ascii( from, i );
				if ( ascii == null_ascii ) {
					if ( previous != 1 ) {
						_default += Misc13.str_sub( from, start, i );
						start = i;
						previous = 1;
					}
				} else if ( previous != 0 ) {
					_default += Misc13.str_sub( into, start, i );
					start = i;
					previous = 0;
				}
				i++;
			}
			if ( previous == 0 ) {
				_default += Misc13.str_sub( from, start, end );
			} else {
				_default += Misc13.str_sub( into, start, end );
			}
			return _default;
		}

		public static void message_admins( string msg = null ) {
			msg = "<span class=\"admin\"><span class=\"prefix\">ADMIN LOG:</span> <span class=\"message\">" + msg + "</span></span>";
			GlobalVars.admins.write( msg );
		}

		public static string message_spans_start( dynamic spans = null ) {
			string output = null;
			dynamic S = null;
			output = "<span class='";
			S = null;
			foreach (dynamic _ in spans ) {
				S = _;
				output = "" + output + S + " ";
			};
			output = "" + output + "'>";
			return output;
		}

		public static void mineral_scan_pulse( dynamic mobs = null, dynamic T = null, dynamic range = null ) {
			ByTable minerals = null;
			dynamic M = null;
			dynamic user = null;
			dynamic C = null;
			dynamic F = null;
			dynamic I = null;
			if ( range == null ) {
				range = Game.view;
			}
			minerals = new ByTable();
			M = null;
			foreach (dynamic _ in Misc13.range( range, T ) ) {
				M = _;
				if ( !( M is Tile_Simulated_Mineral ) ) {
					continue;
				}
				if ( Misc13.isValid( M.scan_state ) ) {
					minerals += M;
				}
			};
			if ( Misc13.isValid( minerals.len ) ) {
				user = null;
				foreach (dynamic _ in mobs ) {
					user = _;
					if ( Misc13.isValid( user.client ) ) {
						C = user.client;
						M = null;
						foreach (dynamic _ in minerals ) {
							M = _;
							if ( !( M is Tile_Simulated_Mineral ) ) {
								continue;
							}
							F = GlobalFuncs.get_turf( M );
							I = typeof(Image).BTNew( new ByTable().set( "layer", 18 ).set( "icon_state", M.scan_state ).set( "loc", F ).set( 1, new ByRsc(61) ) );
							C.images += I;
							Thread13.schedule( 30, () => {
								if ( Misc13.isValid( C ) ) {
									C.images -= I;
								}
								return;
							});
						};
					}
				};
			}
		}

		public static void minor_announce( dynamic message = null, string title = null, dynamic alert = null ) {
			dynamic M = null;
			if ( title == null ) {
				title = "Attention:";
			}
			if ( !Misc13.isValid( message ) ) {
				return;
			}
			M = null;
			foreach (dynamic _ in GlobalVars.player_list ) {
				M = _;
				if ( !( M is Mob_NewPlayer ) && !Misc13.isValid( M.ear_deaf ) ) {
					M.write( "<b><font size = 3><font color = red>" + title + "</font color><BR>" + message + "</font size></b><BR>" );
					if ( Misc13.isValid( alert ) ) {
						M.write( new Sound( new ByRsc(63) ) );
					} else {
						M.write( new Sound( new ByRsc(9) ) );
					}
				}
			};
		}

		public static Color mix_color_from_reagents( dynamic reagent_list = null ) {
			Color color = null;
			int vol_counter = 0;
			dynamic vol_temp = null;
			dynamic R = null;
			if ( !Misc13.isValid( ByTable.IsInstanceOfType( reagent_list ) ) ) {
				return null;
			}
			vol_counter = 0;
			R = null;
			foreach (dynamic _ in reagent_list ) {
				R = _;
				if ( !( R is Reagent ) ) {
					continue;
				}
				vol_temp = R.volume;
				vol_counter += vol_temp;
				if ( color == null ) {
					color = R.color;
				} else if ( color.Length >= R.color.Length ) {
					color = GlobalFuncs.BlendRGB( color, R.color, vol_temp / vol_counter );
				} else {
					color = GlobalFuncs.BlendRGB( R.color, color, vol_temp / vol_counter );
				}
			};
			return color;
		}

		public static void moveElement( dynamic L = null, dynamic fromIndex = null, dynamic toIndex = null ) {
			if ( fromIndex == toIndex || fromIndex + 1 == toIndex ) {
				return;
			}
			if ( fromIndex > toIndex ) {
				fromIndex++;
			}
			L.Insert( toIndex, null );
			L.Swap( fromIndex, toIndex );
			L.Cut( fromIndex, fromIndex + 1 );
		}

		public static void moveRange( dynamic L = null, dynamic fromIndex = null, dynamic toIndex = null, int len = 0 ) {
			dynamic distance = null;
			int i = 0;
			if ( len == null ) {
				len = 1;
			}
			distance = Math.abs( toIndex - fromIndex );
			if ( len >= distance ) {
				if ( fromIndex <= toIndex ) {
					return;
				}
				fromIndex += len;
				i = null;
				i = 0;
				while (i < distance) {
					L.Insert( fromIndex, null );
					L.Swap( fromIndex, toIndex );
					L.Cut( toIndex, toIndex + 1 );
					i++;
				}
			} else {
				if ( fromIndex > toIndex ) {
					fromIndex += len;
				}
				i = null;
				i = 0;
				while (i < len) {
					L.Insert( toIndex, null );
					L.Swap( fromIndex, toIndex );
					L.Cut( fromIndex, fromIndex + 1 );
					i++;
				}
			}
		}

		public static int near_camera( dynamic M = null ) {
			dynamic R = null;
			if ( !( M.loc is Tile ) ) {
				return 0;
			}
			if ( M is Mob_Living_Silicon_Robot ) {
				R = M;
				if ( !( Misc13.isValid( R.camera ) && Misc13.isValid( R.camera.can_use() ) ) && ( GlobalVars.cameranet.checkCameraVis( M ) == 0 ) ) {
					return 0;
				}
			} else if ( GlobalVars.cameranet.checkCameraVis( M ) == 0 ) {
				return 0;
			}
			return 1;
		}

		public static string new_station_name(  ) {
			int random = 0;
			string name = null;
			string new_station_name = null;
			dynamic holiday_name = null;
			dynamic holiday = null;
			random = Rand.Int( 1, 5 );
			name = "";
			new_station_name = "";
			if ( Misc13.isValid( Rand.chance( 10 ) ) ) {
				name = Rand.pick(new object [] { "Imperium", "Heretical", "Cuban", "Psychic", "Elegant", "Common", "Uncommon", "Rare", "Unique", "Houseruled", "Religious", "Atheist", "Traditional", "Houseruled", "Mad", "Super", "Ultra", "Secret", "Top Secret", "Deep", "Death", "Zybourne", "Central", "Main", "Government", "Uoi", "Fat", "Automated", "Experimental", "Augmented" });
				new_station_name = name + " ";
				name = "";
			}
			holiday_name = null;
			foreach (dynamic _ in GlobalVars.SSevent.holidays ) {
				holiday_name = _;
				if ( holiday_name == "Friday the 13th" ) {
					random = 13;
				}
				holiday = GlobalVars.SSevent.holidays[holiday_name];
				name = holiday.getStationPrefix();
			};
			if ( !Misc13.isValid( name ) ) {
				name = Rand.pick(new object [] { "", "Stanford", "Dorf", "Alium", "Prefix", "Clowning", "Aegis", "Ishimura", "Scaredy", "Death-World", "Mime", "Honk", "Rogue", "MacRagge", "Ultrameens", "Safety", "Paranoia", "Explosive", "Neckbear", "Donk", "Muppet", "North", "West", "East", "South", "Slant-ways", "Widdershins", "Rimward", "Expensive", "Procreatory", "Imperial", "Unidentified", "Immoral", "Carp", "Ork", "Pete", "Control", "Nettle", "Aspie", "Class", "Crab", "Fist", "Corrogated", "Skeleton", "Race", "Fatguy", "Gentleman", "Capitalist", "Communist", "Bear", "Beard", "Derp", "Space", "Spess", "Star", "Moon", "System", "Mining", "Neckbeard", "Research", "Supply", "Military", "Orbital", "Battle", "Science", "Asteroid", "Home", "Production", "Transport", "Delivery", "Extraplanetary", "Orbital", "Correctional", "Robot", "Hats", "Pizza" });
			}
			if ( Misc13.isValid( name ) ) {
				new_station_name += name + " ";
			}
			name = Rand.pick(new object [] { "Station", "Fortress", "Frontier", "Suffix", "Death-trap", "Space-hulk", "Lab", "Hazard", "Spess Junk", "Fishery", "No-Moon", "Tomb", "Crypt", "Hut", "Monkey", "Bomb", "Trade Post", "Fortress", "Village", "Town", "City", "Edition", "Hive", "Complex", "Base", "Facility", "Depot", "Outpost", "Installation", "Drydock", "Observatory", "Array", "Relay", "Monitor", "Platform", "Construct", "Hangar", "Prison", "Center", "Port", "Waystation", "Factory", "Waypoint", "Stopover", "Hub", "HQ", "Office", "Object", "Fortification", "Colony", "Planet-Cracker", "Roost", "Fat Camp" });
			new_station_name += name + " ";
			dynamic _ = random; // Was a switch-case, sorry for the mess.
			if ( _==1 ) {
				new_station_name += "" + Rand.Int( 1, 99 );
			} else if ( _==2 ) {
				new_station_name += Rand.pick(new object [] { "Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota", "Kappa", "Lambda", "Mu", "Nu", "Xi", "Omicron", "Pi", "Rho", "Sigma", "Tau", "Upsilon", "Phi", "Chi", "Psi", "Omega" });
			} else if ( _==3 ) {
				new_station_name += Rand.pick(new object [] { "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", "XIII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX", "XX" });
			} else if ( _==4 ) {
				new_station_name += Rand.pick(new object [] { "Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf", "Hotel", "India", "Juliet", "Kilo", "Lima", "Mike", "November", "Oscar", "Papa", "Quebec", "Romeo", "Sierra", "Tango", "Uniform", "Victor", "Whiskey", "X-ray", "Yankee", "Zulu" });
			} else if ( _==5 ) {
				new_station_name += Rand.pick(new object [] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" });
			} else if ( _==13 ) {
				new_station_name += Rand.pick(new object [] { "13", "XIII", "Thirteen" });
			};
			return new_station_name;
		}

		public static dynamic next_list_item( dynamic item = null, dynamic L = null ) {
			int i = 0;
			i = L.Find( item );
			if ( i == L.len ) {
				i = 1;
			} else {
				i++;
			}
			return L[i];
		}

		public static dynamic ninjaspeak( dynamic n = null ) {
			dynamic te = null;
			string t = null;
			int p = 0;
			string n_letter = null;
			dynamic n_mod = null;
			te = Misc13.html_decode( n );
			t = "";
			n = n.Length;
			p = 1;
			while (p <= n) {
				n_letter = null;
				n_mod = Rand.Int( 1, 4 );
				if ( p + n_mod > n + 1 ) {
					n_letter = Misc13.str_sub( te, p, n + 1 );
				} else {
					n_letter = Misc13.str_sub( te, p, p + n_mod );
				}
				if ( Misc13.isValid( Rand.chance( 50 ) ) ) {
					if ( Misc13.isValid( Rand.chance( 30 ) ) ) {
						n_letter = "" + n_letter + "-" + n_letter + "-" + n_letter;
					} else {
						n_letter = "" + n_letter + "-" + n_letter;
					}
				} else {
					n_letter = "" + n_letter;
				}
				t = "" + t + n_letter;
				p = p + n_mod;
			}
			return Misc13.str_sub( GlobalFuncs.sanitize( t ), 1, 1024 );
		}

		public static void notice( dynamic msg = null ) {
			Game.log.write( "## NOTICE: " + msg );
		}

		public static void Nuke_request( dynamic text = null, dynamic Sender = null ) {
			dynamic msg = null;
			msg = Misc13.str_sub( GlobalFuncs.sanitize( text ), 1, 1024 );
			msg = new Txt( "<span class='adminnotice'><b><font color=orange>NUKE CODE REQUEST:</font>" ).item( GlobalFuncs.key_name_admin( Sender ) ).str( " (<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( Sender ).str( "'>?</A>) (<A HREF='?_src_=holder;adminplayeropts=" ).Ref( Sender ).str( "'>PP</A>) (<A HREF='?_src_=vars;Vars=" ).Ref( Sender ).str( "'>VV</A>) (<A HREF='?_src_=holder;subtlemessage=" ).Ref( Sender ).str( "'>SM</A>) (<A HREF='?_src_=holder;adminplayerobservefollow=" ).Ref( Sender ).str( "'>FLW</A>) (<A HREF='?_src_=holder;traitor=" ).Ref( Sender ).str( "'>TP</A>) (<A HREF='?_src_=holder;BlueSpaceArtillery=" ).Ref( Sender ).str( "'>BSA</A>) (<A HREF='?_src_=holder;CentcommReply=" ).Ref( Sender ).str( "'>RPLY</A>):</b> " ).item( msg ).str( "</span>" );
			GlobalVars.admins.write( msg );
			GlobalVars.admins.write( "<span class='adminnotice'><b>At this current time, the nuke must have the code manually set via varedit.</b></span>" );
		}

		public static dynamic nukelastname( dynamic M = null ) {
			dynamic randomname = null;
			dynamic newname = null;
			randomname = Rand.pick( GlobalVars.last_names );
			newname = Misc13.str_sub( GlobalFuncs.sanitize( Misc13.input( M, "You are the nuke operative " + Rand.pick(new object [] { "Czar", "Boss", "Commander", "Chief", "Kingpin", "Director", "Overlord" }) + ". Please choose a last name for your family.", "Name change", randomname, null, 0 ) ), 1, 26 );
			if ( !Misc13.isValid( newname ) ) {
				newname = randomname;
			} else if ( newname == "Unknown" || newname == "floor" || newname == "wall" || newname == "rwall" || newname == "_" ) {
				M.write( "That name is reserved." );
				return GlobalFuncs.nukelastname( M );
			}
			return GlobalFuncs.capitalize( newname );
		}

		public static void NukeNameAssign( dynamic lastname = null, dynamic syndicates = null ) {
			dynamic synd_mind = null;
			dynamic H = null;
			synd_mind = null;
			foreach (dynamic _ in syndicates ) {
				synd_mind = _;
				if ( !( synd_mind is Mind ) ) {
					continue;
				}
				H = synd_mind.current;
				synd_mind.name = H.dna.species.random_name( H.gender, 0, lastname );
				synd_mind.current.real_name = synd_mind.name;
			};
			return;
		}

		public static string num2hex( int num = 0, int len = 0 ) {
			string _default = null;
			int i = 0;
			int remainder = 0;
			if ( len == null ) {
				len = 2;
			}
			if ( !Misc13.isValid( Misc13.isNumber( num ) ) ) {
				num = 0;
			}
			num = Misc13.round( Math.abs( num ) );
			_default = "";
			i = 0;
			while (1) {
				if ( len <= 0 ) {
					if ( num == 0 ) {
						break;
					}
				} else if ( i >= len ) {
					break;
				}
				remainder = num / 16;
				num = Misc13.round( remainder );
				remainder = ( remainder - num ) * 16;
				dynamic _ = remainder; // Was a switch-case, sorry for the mess.
				if ( _==9 || _==8 || _==7 || _==6 || _==5 || _==4 || _==3 || _==2 || _==1 ) {
					_default = "" + remainder + _default;
				} else if ( _==10 || _==11 || _==12 || _==13 || _==14 || _==15 ) {
					_default = Misc13.conv_ascii2text( remainder + 87 ) + _default;
				} else {
					_default = "0" + _default;
				};
				i++;
			}
			return _default;
			return _default;
		}

		public static string num2seclevel( dynamic num = null ) {
			dynamic _ = num; // Was a switch-case, sorry for the mess.
			if ( _==0 ) {
				return "green";
			} else if ( _==1 ) {
				return "blue";
			} else if ( _==2 ) {
				return "red";
			} else if ( _==3 ) {
				return "delta";
			};
		}

		public static void onclose( dynamic user = null, dynamic windowid = null, dynamic _ref = null ) {
			string param = null;
			if ( _ref == null ) {
				_ref = null;
			}
			if ( !Misc13.isValid( user.client ) ) {
				return;
			}
			param = "null";
			if ( Misc13.isValid( _ref ) ) {
				param = new Txt().Ref( _ref );
			}
			Misc13.winset( user, windowid, "on-close=\".windowclose " + param + "\"" );
		}

		public static string parse_zone( dynamic zone = null ) {
			if ( zone == "r_hand" ) {
				return "right hand";
			} else if ( zone == "l_hand" ) {
				return "left hand";
			} else if ( zone == "l_arm" ) {
				return "left arm";
			} else if ( zone == "r_arm" ) {
				return "right arm";
			} else if ( zone == "l_leg" ) {
				return "left leg";
			} else if ( zone == "r_leg" ) {
				return "right leg";
			} else if ( zone == "l_foot" ) {
				return "left foot";
			} else if ( zone == "r_foot" ) {
				return "right foot";
			} else {
				return zone;
			}
		}

		public static dynamic parsepencode( dynamic t = null, dynamic user = null, string signfont = null ) {
			if ( user == null ) {
				user = null;
			}
			if ( signfont == null ) {
				signfont = "Times New Roman";
			}
			if ( t.Length < 1 ) {
				return null;
			}
			t = GlobalFuncs.replacetext( t, "[center]", "<center>" );
			t = GlobalFuncs.replacetext( t, "[/center]", "</center>" );
			t = GlobalFuncs.replacetext( t, "[br]", "<BR>" );
			t = GlobalFuncs.replacetext( t, "[b]", "<B>" );
			t = GlobalFuncs.replacetext( t, "[/b]", "</B>" );
			t = GlobalFuncs.replacetext( t, "[i]", "<I>" );
			t = GlobalFuncs.replacetext( t, "[/i]", "</I>" );
			t = GlobalFuncs.replacetext( t, "[u]", "<U>" );
			t = GlobalFuncs.replacetext( t, "[/u]", "</U>" );
			t = GlobalFuncs.replacetext( t, "[large]", "<font size=\"4\">" );
			t = GlobalFuncs.replacetext( t, "[/large]", "</font>" );
			if ( Misc13.isValid( user ) ) {
				t = GlobalFuncs.replacetext( t, "[sign]", "<font face=\"" + signfont + "\"><i>" + user.real_name + "</i></font>" );
			} else {
				t = GlobalFuncs.replacetext( t, "[sign]", "" );
			}
			t = GlobalFuncs.replacetext( t, "[field]", "<span class=\"paper_field\"></span>" );
			t = GlobalFuncs.replacetext( t, "[*]", "<li>" );
			t = GlobalFuncs.replacetext( t, "[hr]", "<HR>" );
			t = GlobalFuncs.replacetext( t, "[small]", "<font size = \"1\">" );
			t = GlobalFuncs.replacetext( t, "[/small]", "</font>" );
			t = GlobalFuncs.replacetext( t, "[list]", "<ul>" );
			t = GlobalFuncs.replacetext( t, "[/list]", "</ul>" );
			return t;
		}

		public static dynamic pick_n_take( dynamic L = null ) {
			dynamic _default = null;
			dynamic picked = null;
			if ( Misc13.isValid( L.len ) ) {
				picked = Rand.Int( 1, L.len );
				_default = L[picked];
				L.Cut( picked, picked + 1 );
			}
			return _default;
		}

		public static dynamic pickweight( dynamic L = null ) {
			int total = 0;
			dynamic item = null;
			total = 0;
			foreach (dynamic _ in L ) {
				item = _;
				if ( !Misc13.isValid( L[item] ) ) {
					L[item] = 1;
				}
				total += L[item];
			};
			total = Rand.Int( 1, total );
			foreach (dynamic _ in L ) {
				item = _;
				total -= L[item];
				if ( total <= 0 ) {
					return item;
				}
			};
			return null;
		}

		public static void PlaceInPool( dynamic diver = null, int destroy = 0 ) {
			if ( destroy == null ) {
				destroy = 1;
			}
			if ( !( diver is Base13 ) ) {
				return;
			}
			if ( Misc13.isValid( GlobalVars.GlobalPool[diver.type].HasValue( diver ) ) ) {
				return;
			}
			if ( !Misc13.isValid( GlobalVars.GlobalPool[diver.type] ) ) {
				GlobalVars.GlobalPool[diver.type] = new ByTable();
			}
			GlobalVars.GlobalPool[diver.type] |= diver;
			if ( destroy != 0 ) {
				diver.Destroy();
			}
			diver.ResetVars();
		}

		public static int play_vox_word( dynamic word = null, dynamic z_level = null, dynamic only_listener = null ) {
			dynamic sound_file = null;
			dynamic voice = null;
			dynamic M = null;
			dynamic T = null;
			word = Misc13.str_lower( word );
			if ( Misc13.isValid( GlobalVars.vox_sounds[word] ) ) {
				sound_file = GlobalVars.vox_sounds[word];
				voice = Sound.BTNew( new ByTable().set( "channel", GlobalVars.VOX_CHANNEL ).set( "wait", 1 ).set( 1, sound_file ) );
				voice.status = GlobalVars.SOUND_STREAM;
				if ( !Misc13.isValid( only_listener ) ) {
					M = null;
					foreach (dynamic _ in GlobalVars.player_list ) {
						M = _;
						if ( Misc13.isValid( M.client ) && !Misc13.isValid( M.ear_deaf ) ) {
							T = GlobalFuncs.get_turf( M );
							if ( T.z == z_level ) {
								M.write( voice );
							}
						}
					};
				} else {
					only_listener.write( voice );
				}
				return 1;
			}
			return 0;
		}

		public static void playsound( dynamic source = null, dynamic soundin = null, dynamic vol = null, dynamic vary = null, dynamic extrarange = null, dynamic falloff = null, int surround = 0 ) {
			dynamic frequency = null;
			dynamic turf_source = null;
			dynamic P = null;
			dynamic M = null;
			dynamic T = null;
			if ( surround == null ) {
				surround = 1;
			}
			soundin = GlobalFuncs.get_sfx( soundin );
			if ( source is Zone ) {
				throw new Exception( "playsound(): source is an area", "code/game/sound.dm", 6 );
				return;
			}
			frequency = GlobalFuncs.get_rand_frequency();
			turf_source = GlobalFuncs.get_turf( source );
			P = null;
			foreach (dynamic _ in GlobalVars.player_list ) {
				P = _;
				M = P;
				if ( !Misc13.isValid( M ) || !Misc13.isValid( M.client ) ) {
					continue;
				}
				if ( Misc13.get_dist( M, turf_source ) <= Game.view + extrarange ) {
					T = GlobalFuncs.get_turf( M );
					if ( Misc13.isValid( T ) && T.z == turf_source.z ) {
						M.playsound_local( turf_source, soundin, vol, vary, frequency, falloff, surround );
					}
				}
			};
		}

		public static ByTable pollCandidates( string Question = null, dynamic jobbanType = null, dynamic gametypeCheck = null, int be_special_flag = 0, int poll_time = 0 ) {
			ByTable candidates = null;
			double time_passed = 0;
			dynamic G = null;
			if ( be_special_flag == null ) {
				be_special_flag = 0;
			}
			if ( poll_time == null ) {
				poll_time = 300;
			}
			candidates = new ByTable();
			time_passed = Game.time;
			if ( !Misc13.isValid( Question ) ) {
				Question = "Would you like to be a special role?";
			}
			G = null;
			foreach (dynamic _ in GlobalVars.player_list ) {
				G = _;
				if ( !( G is Mob_Dead_Observer ) ) {
					continue;
				}
				if ( !Misc13.isValid( G.key ) || !Misc13.isValid( G.client ) ) {
					continue;
				}
				if ( be_special_flag != 0 ) {
					if ( !Misc13.isValid( G.client.prefs.be_special & be_special_flag ) ) {
						continue;
					}
				}
				if ( Misc13.isValid( gametypeCheck ) ) {
					if ( gametypeCheck.age_check( G.client ) == 0 ) {
						continue;
					}
				}
				if ( Misc13.isValid( jobbanType ) ) {
					if ( Misc13.isValid( GlobalFuncs.jobban_isbanned( G, jobbanType ) ) || Misc13.isValid( GlobalFuncs.jobban_isbanned( G, "Syndicate" ) ) ) {
						continue;
					}
				}
				Thread13.schedule( 0, () => {
					G.write( new ByRsc(9) );
					dynamic _ = Misc13.alert( G, Question, "Please answer in " + poll_time / 10 + " seconds!", "Yes", "No", null ); // Was a switch-case, sorry for the mess.
					if ( _=="Yes" ) {
						G.write( "<span class='notice'>Choice registered: Yes.</span>" );
						if ( Game.time - time_passed > poll_time ) {
							G.write( "<span class='danger'>Sorry, you were too late for the consideration!</span>" );
							G.write( new ByRsc(10) );
							return null;
						}
						candidates += G;
					} else if ( _=="No" ) {
						G.write( "<span class='danger'>Choice registered: No.</span>" );
						return null;
					} else {
						return null;
					};
					return null;
				});
			};
			Thread13.sleep( poll_time );
			G = null;
			foreach (dynamic _ in candidates ) {
				G = _;
				if ( !( G is Mob_Dead_Observer ) ) {
					continue;
				}
				if ( !Misc13.isValid( G.key ) || !Misc13.isValid( G.client ) ) {
					candidates.Remove( G );
				}
			};
			return candidates;
		}

		public static dynamic PoolOrNew( dynamic get_type = null, dynamic second_arg = null ) {
			dynamic _default = null;
			if ( !Misc13.isValid( get_type ) ) {
				return null;
			}
			_default = GlobalFuncs.GetFromPool( get_type, second_arg );
			if ( !Misc13.isValid( _default ) ) {
				if ( get_type is Type ) {
					if ( Misc13.isValid( ByTable.IsInstanceOfType( second_arg ) ) ) {
						_default = get_type.BTNew( second_arg );
					} else {
						_default = get_type( second_arg );
					}
				}
			}
			return _default;
		}

		public static dynamic pop( dynamic L = null ) {
			dynamic _default = null;
			if ( Misc13.isValid( L.len ) ) {
				_default = L[L.len];
				L.len--;
			}
			return _default;
		}

		public static void possess( dynamic O = null ) {
			dynamic T = null;
			if ( O is Ent_Singularity ) {
				if ( Misc13.isValid( GlobalVars.config.forbid_singulo_possession ) ) {
					Misc13.thread_user.write( "It is forbidden to possess singularities." );
					return;
				}
			}
			T = GlobalFuncs.get_turf( O );
			if ( Misc13.isValid( T ) ) {
				GlobalFuncs.log_admin( "" + GlobalFuncs.key_name( Misc13.thread_user ) + " has possessed " + O + " (" + O.type + ") at (" + T.x + ", " + T.y + ", " + T.z + ")" );
				GlobalFuncs.message_admins( "" + GlobalFuncs.key_name( Misc13.thread_user ) + " has possessed " + O + " (" + O.type + ") at (" + T.x + ", " + T.y + ", " + T.z + ")" );
			} else {
				GlobalFuncs.log_admin( "" + GlobalFuncs.key_name( Misc13.thread_user ) + " has possessed " + O + " (" + O.type + ") at an unknown location" );
				GlobalFuncs.message_admins( "" + GlobalFuncs.key_name( Misc13.thread_user ) + " has possessed " + O + " (" + O.type + ") at an unknown location" );
			}
			if ( !Misc13.isValid( Misc13.thread_user.control_object ) ) {
				Misc13.thread_user.name_archive = Misc13.thread_user.real_name;
			}
			Misc13.thread_user.loc = O;
			Misc13.thread_user.real_name = O.name;
			Misc13.thread_user.name = O.name;
			Misc13.thread_user.client.eye = O;
			Misc13.thread_user.control_object = O;
			GlobalFuncs.feedback_add_details( "admin_verb", "PO" );
		}

		public static void power_failure(  ) {
			dynamic S = null;
			ByTable skipped_areas = null;
			dynamic A = null;
			int skip = 0;
			dynamic area_type = null;
			dynamic AT = null;
			dynamic C = null;
			GlobalFuncs.priority_announce( "Abnormal activity detected in " + GlobalFuncs.station_name() + "'s powernet. As a precautionary measure, the station's power will be shut off for an indeterminate duration.", "Critical Power Failure", new ByRsc(54) );
			S = null;
			foreach (dynamic _ in GlobalVars.machines ) {
				S = _;
				if ( !( S is Ent_Machinery_Power_Smes ) ) {
					continue;
				}
				if ( Misc13.isValid( new ByArea(2739).IsInstanceOfType( GlobalFuncs.get_area( S ) ) ) || S.z != 1 ) {
					continue;
				}
				S.charge = 0;
				S.output_level = 0;
				S.output_attempt = 0;
				S.update_icon();
				S.power_change();
			};
			skipped_areas = new ByTable(new object [] {new ByArea(2719),new ByArea(2727)});
			A = null;
			foreach (dynamic _ in Game ) {
				A = _;
				if ( !Misc13.isValid( A.requires_power ) || Misc13.isValid( A.always_unpowered ) ) {
					continue;
				}
				skip = 0;
				area_type = null;
				foreach (dynamic _ in skipped_areas ) {
					area_type = _;
					if ( Misc13.isValid( area_type.IsInstanceOfType( A ) ) ) {
						skip = 1;
						break;
					}
				};
				if ( Misc13.isValid( A.contents ) ) {
					AT = null;
					foreach (dynamic _ in A.contents ) {
						AT = _;
						if ( !( AT is BaseStatic ) ) {
							continue;
						}
						if ( AT.z != 1 ) {
							skip = 1;
						}
						break;
					};
				}
				if ( skip != 0 ) {
					continue;
				}
				A.power_light = 0;
				A.power_equip = 0;
				A.power_environ = 0;
				A.power_change();
			};
			C = null;
			foreach (dynamic _ in GlobalVars.apcs_list ) {
				C = _;
				if ( !( C is Ent_Machinery_Power_Apc ) ) {
					continue;
				}
				if ( Misc13.isValid( C.cell ) && C.z == 1 ) {
					A = GlobalFuncs.get_area( C );
					skip = 0;
					area_type = null;
					foreach (dynamic _ in skipped_areas ) {
						area_type = _;
						if ( Misc13.isValid( area_type.IsInstanceOfType( A ) ) ) {
							skip = 1;
							break;
						}
					};
					if ( skip != 0 ) {
						continue;
					}
					C.cell.charge = 0;
				}
			};
		}

		public static ByTable power_list( dynamic T = null, dynamic source = null, dynamic d = null, int unmarked = 0, int cable_only = 0 ) {
			ByTable _default = null;
			dynamic AM = null;
			dynamic P = null;
			dynamic C = null;
			if ( unmarked == null ) {
				unmarked = 0;
			}
			if ( cable_only == null ) {
				cable_only = 0;
			}
			_default = new ByTable();
			AM = null;
			foreach (dynamic _ in T ) {
				AM = _;
				if ( AM == source ) {
					continue;
				}
				if ( ( cable_only == 0 ) && AM is Ent_Machinery_Power ) {
					P = AM;
					if ( P.powernet == 0 ) {
						continue;
					}
					if ( ( unmarked == 0 ) || !Misc13.isValid( P.powernet ) ) {
						if ( d == 0 ) {
							_default += P;
						}
					}
				} else if ( AM is Ent_Structure_Cable ) {
					C = AM;
					if ( ( unmarked == 0 ) || !Misc13.isValid( C.powernet ) ) {
						if ( C.d1 == d || C.d2 == d ) {
							_default += C;
						}
					}
				}
			};
			return _default;
			return _default;
		}

		public static void power_restore(  ) {
			dynamic C = null;
			dynamic S = null;
			dynamic A = null;
			GlobalFuncs.priority_announce( "Power has been restored to " + GlobalFuncs.station_name() + ". We apologize for the inconvenience.", "Power Systems Nominal", new ByRsc(55) );
			C = null;
			foreach (dynamic _ in GlobalVars.machines ) {
				C = _;
				if ( !( C is Ent_Machinery_Power_Apc ) ) {
					continue;
				}
				if ( Misc13.isValid( C.cell ) && C.z == 1 ) {
					C.charge = C.cell.maxcharge;
				}
			};
			S = null;
			foreach (dynamic _ in GlobalVars.machines ) {
				S = _;
				if ( !( S is Ent_Machinery_Power_Smes ) ) {
					continue;
				}
				if ( S.z != 1 ) {
					continue;
				}
				S.charge = S.capacity;
				S.output_level = S.output_level_max;
				S.output_attempt = 1;
				S.update_icon();
				S.power_change();
			};
			A = null;
			foreach (dynamic _ in Game ) {
				A = _;
				if ( !Misc13.isValid( new ByArea(2717).IsInstanceOfType( A ) ) && !Misc13.isValid( new ByArea(2755).IsInstanceOfType( A ) ) && !Misc13.isValid( new ByArea(2741).IsInstanceOfType( A ) ) ) {
					A.power_light = 1;
					A.power_equip = 1;
					A.power_environ = 1;
					A.power_change();
				}
			};
		}

		public static void power_restore_quick(  ) {
			dynamic S = null;
			GlobalFuncs.priority_announce( "All SMESs on " + GlobalFuncs.station_name() + " have been recharged. We apologize for the inconvenience.", "Power Systems Nominal", new ByRsc(55) );
			S = null;
			foreach (dynamic _ in GlobalVars.machines ) {
				S = _;
				if ( !( S is Ent_Machinery_Power_Smes ) ) {
					continue;
				}
				if ( S.z != 1 ) {
					continue;
				}
				S.charge = S.capacity;
				S.output_level = S.output_level_max;
				S.output_attempt = 1;
				S.update_icon();
				S.power_change();
			};
		}

		public static string pretty_string_from_reagent_list( dynamic reagent_list = null ) {
			string result = null;
			dynamic R = null;
			result = "| ";
			R = null;
			foreach (dynamic _ in reagent_list ) {
				R = _;
				if ( !( R is Reagent ) ) {
					continue;
				}
				result += "" + R.name + ", " + R.volume + " | ";
			};
			return result;
		}

		public static dynamic previous_list_item( dynamic item = null, dynamic L = null ) {
			dynamic i = null;
			i = L.Find( item );
			if ( i == 1 ) {
				i = L.len;
			} else {
				i--;
			}
			return L[i];
		}

		public static void print_command_report( string text = null, string title = null ) {
			dynamic C = null;
			Ent_Item_Weapon_Paper P = null;
			if ( text == null ) {
				text = "";
			}
			if ( title == null ) {
				title = "Central Command Update";
			}
			C = null;
			foreach (dynamic _ in GlobalVars.machines ) {
				C = _;
				if ( !( C is Ent_Machinery_Computer_Communications ) ) {
					continue;
				}
				if ( !Misc13.isValid( C.stat & 3 ) && C.z == 1 ) {
					P = new Ent_Item_Weapon_Paper( C.loc );
					P.name = "paper- '" + title + "'";
					P.info = text;
					C.messagetitle.Add( "" + title );
					C.messagetext.Add( text );
				}
			};
		}

		public static void priority_announce( dynamic text = null, string title = null, ByRsc sound = null, dynamic type = null ) {
			dynamic announcement = null;
			dynamic M = null;
			if ( title == null ) {
				title = "";
			}
			if ( sound == null ) {
				sound = new ByRsc(62);
			}
			if ( !Misc13.isValid( text ) ) {
				return;
			}
			if ( type == "Priority" ) {
				announcement += "<h1 class='alert'>Priority Announcement</h1>";
				if ( Misc13.isValid( title ) && title.Length > 0 ) {
					announcement += "<br><h2 class='alert'>" + Misc13.html_encode( title ) + "</h2>";
				}
			} else if ( type == "Captain" ) {
				announcement += "<h1 class='alert'>Captain Announces</h1>";
				GlobalVars.news_network.SubmitArticle( text, "Captain's Announcement", "Station Announcements", null );
			} else {
				announcement += "<h1 class='alert'>" + GlobalFuncs.command_name() + " Update</h1>";
				if ( Misc13.isValid( title ) && title.Length > 0 ) {
					announcement += "<br><h2 class='alert'>" + Misc13.html_encode( title ) + "</h2>";
				}
				if ( title == "" ) {
					GlobalVars.news_network.SubmitArticle( text, "Central Command Update", "Station Announcements", null );
				} else {
					GlobalVars.news_network.SubmitArticle( title + "<br><br>" + text, "Central Command", "Station Announcements", null );
				}
			}
			announcement += "<br><span class='alert'>" + Misc13.html_encode( text ) + "</span><br>";
			announcement += "<br>";
			M = null;
			foreach (dynamic _ in GlobalVars.player_list ) {
				M = _;
				if ( !( M is Mob_NewPlayer ) && !Misc13.isValid( M.ear_deaf ) ) {
					M.write( announcement );
					M.write( new Sound( sound ) );
				}
			};
		}

		public static ProjectileData projectile_trajectory( dynamic src_x = null, dynamic src_y = null, dynamic rotation = null, dynamic angle = null, dynamic power = null ) {
			dynamic power_x = null;
			dynamic power_y = null;
			dynamic time = null;
			dynamic distance = null;
			dynamic dest_x = null;
			dynamic dest_y = null;
			power_x = power * Math.cos( angle );
			power_y = power * Math.sin( angle );
			time = power_y * 2 / 10;
			distance = time * power_x;
			dest_x = src_x + distance * Math.sin( rotation );
			dest_y = src_y + distance * Math.cos( rotation );
			return new ProjectileData( src_x, src_y, time, distance, power_x, power_y, dest_x, dest_y );
		}

		public static void propagate_network( dynamic O = null, dynamic PN = null ) {
			ByTable worklist = null;
			ByTable found_machines = null;
			int index = 0;
			dynamic P = null;
			dynamic C = null;
			dynamic M = null;
			dynamic PM = null;
			worklist = new ByTable();
			found_machines = new ByTable();
			index = 1;
			P = null;
			worklist += O;
			while (index <= worklist.len) {
				P = worklist[index];
				index++;
				if ( P is Ent_Structure_Cable ) {
					C = P;
					if ( C.powernet != PN ) {
						PN.add_cable( C );
					}
					worklist |= C.get_connections();
				} else if ( Misc13.isValid( P.anchored ) && P is Ent_Machinery_Power ) {
					M = P;
					found_machines |= M;
				} else {
					continue;
				}
			}
			PM = null;
			foreach (dynamic _ in found_machines ) {
				PM = _;
				if ( !( PM is Ent_Machinery_Power ) ) {
					continue;
				}
				if ( PM.connect_to_network() == 0 ) {
					PM.disconnect_from_network();
				}
			};
		}

		public static void qdel( dynamic A = null ) {
			dynamic hint = null;
			if ( !Misc13.isValid( A ) ) {
				return;
			}
			if ( !( A is Base13 ) ) {
				Misc13.del( A );
				A = null;
			} else if ( A.gc_destroyed == null ) {
				hint = A.Destroy();
				if ( !Misc13.isValid( A ) ) {
					return;
				}
				dynamic _ = hint; // Was a switch-case, sorry for the mess.
				if ( _==0 ) {
					GlobalVars.SSgarbage.Queue( A );
				} else if ( _==1 ) {
					return;
				} else if ( _==2 ) {
					return;
				} else if ( _==3 ) {
					GlobalVars.SSgarbage.HardQueue( A );
				} else if ( _==4 ) {
					Misc13.del( A );
					A = null;
				} else if ( _==5 ) {
					GlobalFuncs.PlaceInPool( A, 0 );
				} else if ( _==6 ) {
					GlobalVars.SSgarbage.Queue( A );
				} else {
					if ( !Misc13.isValid( GlobalVars.SSgarbage.noqdelhint.HasValue( "" + A.type ) ) ) {
						GlobalVars.SSgarbage.noqdelhint += "" + A.type;
						GlobalFuncs.testing( "WARNING: " + A.type + " is not returning a qdel hint. It is being placed in the queue. Further instances of this type will also be queued." );
					}
					GlobalVars.SSgarbage.Queue( A );
				};
			}
		}

		public static int qdeleted( dynamic A = null ) {
			if ( !( A is Base13 ) ) {
				return 0;
			}
			if ( Misc13.isValid( A.gc_destroyed ) ) {
				return 1;
			}
			return 0;
		}

		public static int radiation_pulse( dynamic epicenter = null, dynamic heavy_range = null, dynamic light_range = null, dynamic severity = null, int log = 0 ) {
			dynamic light_severity = null;
			dynamic T = null;
			int distance = 0;
			if ( log == null ) {
				log = 0;
			}
			if ( !Misc13.isValid( epicenter ) || !Misc13.isValid( severity ) ) {
				return 0;
			}
			if ( !( epicenter is Tile ) ) {
				epicenter = GlobalFuncs.get_turf( epicenter.loc );
			}
			if ( log != 0 ) {
				GlobalFuncs.message_admins( "Radiation pulse with size (" + heavy_range + ", " + light_range + ") and severity " + severity + " in area " + epicenter.loc.name + " " );
				GlobalFuncs.log_game( "Radiation pulse with size (" + heavy_range + ", " + light_range + ") and severity " + severity + " in area " + epicenter.loc.name + " " );
			}
			if ( heavy_range > light_range ) {
				light_range = heavy_range;
			}
			light_severity = severity * 0.5;
			T = null;
			foreach (dynamic _ in Misc13.range( light_range, epicenter ) ) {
				T = _;
				if ( !( T is BaseStatic ) ) {
					continue;
				}
				distance = Misc13.get_dist( epicenter, T );
				if ( distance < 0 ) {
					distance = 0;
				}
				if ( distance < heavy_range ) {
					T.rad_act( severity );
				} else if ( distance == heavy_range ) {
					if ( Misc13.isValid( Rand.chance( 50 ) ) ) {
						T.rad_act( severity );
					} else {
						T.rad_act( light_severity );
					}
				} else if ( distance <= light_range ) {
					T.rad_act( light_severity );
				}
			};
			return 1;
		}

		public static string ran_zone( string zone = null, int probability = 0 ) {
			dynamic t = null;
			if ( probability == null ) {
				probability = 80;
			}
			zone = GlobalFuncs.check_zone( zone );
			if ( Misc13.isValid( Rand.chance( probability ) ) ) {
				return zone;
			}
			t = Rand.Int( 1, 18 );
			dynamic _ = t; // Was a switch-case, sorry for the mess.
			if ( 3<=_&&_<=6 ) {
				return "l_arm";
			} else if ( 7<=_&&_<=10 ) {
				return "r_arm";
			} else if ( 11<=_&&_<=14 ) {
				return "l_leg";
			} else if ( 15<=_&&_<=18 ) {
				return "r_leg";
			} else if ( _==1 ) {
				return "head";
			} else if ( _==2 ) {
				return "chest";
			};
			return zone;
		}

		public static int randmut( dynamic M = null, dynamic candidates = null, int difficulty = 0 ) {
			int _default = null;
			dynamic num = null;
			if ( difficulty == null ) {
				difficulty = 2;
			}
			if ( !Misc13.isValid( M.has_dna() ) ) {
				return 0;
			}
			num = Rand.pick( candidates );
			_default = num.force_give( M );
			return 0;
			return _default;
		}

		public static int randmutb( dynamic M = null ) {
			int _default = null;
			dynamic HM = null;
			if ( !Misc13.isValid( M.has_dna() ) ) {
				return 0;
			}
			HM = Rand.pick( ( GlobalVars.bad_mutations | GlobalVars.not_good_mutations ) - GlobalVars.mutations_list["Monkified"] );
			_default = HM.force_give( M );
			return _default;
		}

		public static int randmutg( dynamic M = null ) {
			int _default = null;
			dynamic HM = null;
			if ( !Misc13.isValid( M.has_dna() ) ) {
				return 0;
			}
			HM = Rand.pick( GlobalVars.good_mutations );
			_default = HM.force_give( M );
			return _default;
		}

		public static void randmuti( dynamic M = null ) {
			dynamic num = null;
			int newdna = 0;
			if ( !Misc13.isValid( M.has_dna() ) ) {
				return;
			}
			num = Rand.Int( 1, 7 );
			newdna = GlobalFuncs.setblock( M.dna.uni_identity, num, GlobalFuncs.random_string( 3, GlobalVars.hex_characters ) );
			M.dna.uni_identity = newdna;
			return;
		}

		public static dynamic random_blood_type(  ) {
			return int _ = Rand.Int(0,65535) // Was a weighted pick, sorry for the mess.
	<-REP->if ( _ < 2674 ) { _ = "O-" }
	<-REP->else if ( _ < 26748 ) { _ = "O+" }
	<-REP->else if ( _ < 28754 ) { _ = "A-" }
	<-REP->else if ( _ < 47478 ) { _ = "A+" }
	<-REP->else if ( _ < 48146 ) { _ = "B-" }
	<-REP->else if ( _ < 61520 ) { _ = "B+" }
	<-REP->else if ( _ < 62188 ) { _ = "AB-" }
	<-REP->else  { _ = "AB+" };
		}

		public static string random_eye_color(  ) {
			dynamic _ = int _ = Rand.Int(0,65535) // Was a weighted pick, sorry for the mess.
	<-REP->if ( _ < 14246 ) { _ = "brown" }
	<-REP->else if ( _ < 28492 ) { _ = "hazel" }
	<-REP->else if ( _ < 42738 ) { _ = "grey" }
	<-REP->else if ( _ < 53423 ) { _ = "blue" }
	<-REP->else if ( _ < 64108 ) { _ = "green" }
	<-REP->else if ( _ < 64820 ) { _ = "amber" }
	<-REP->else  { _ = "albino" }; // Was a switch-case, sorry for the mess.
			if ( _=="brown" ) {
				return "630";
			} else if ( _=="hazel" ) {
				return "542";
			} else if ( _=="grey" ) {
				return Rand.pick(new object [] { "666", "777", "888", "999", "aaa", "bbb", "ccc" });
			} else if ( _=="blue" ) {
				return "36c";
			} else if ( _=="green" ) {
				return "060";
			} else if ( _=="amber" ) {
				return "fc0";
			} else if ( _=="albino" ) {
				return Rand.pick(new object [] { "c", "d", "e", "f" }) + Rand.pick(new object [] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }) + Rand.pick(new object [] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
			} else {
				return "000";
			};
		}

		public static dynamic random_facial_hair_style( dynamic gender = null ) {
			dynamic _ = gender; // Was a switch-case, sorry for the mess.
			if ( _=="male" ) {
				return Rand.pick( GlobalVars.facial_hair_styles_male_list );
			} else if ( _=="female" ) {
				return Rand.pick( GlobalVars.facial_hair_styles_female_list );
			} else {
				return Rand.pick( GlobalVars.facial_hair_styles_list );
			};
		}

		public static ByTable random_features(  ) {
			if ( !Misc13.isValid( GlobalVars.tails_list_human.len ) ) {
				GlobalFuncs.init_sprite_accessory_subtypes( typeof(SpriteAccessory_Tails_Human), GlobalVars.tails_list_human );
			}
			if ( !Misc13.isValid( GlobalVars.tails_list_lizard.len ) ) {
				GlobalFuncs.init_sprite_accessory_subtypes( typeof(SpriteAccessory_Tails_Lizard), GlobalVars.tails_list_lizard );
			}
			if ( !Misc13.isValid( GlobalVars.snouts_list.len ) ) {
				GlobalFuncs.init_sprite_accessory_subtypes( typeof(SpriteAccessory_Snouts), GlobalVars.snouts_list );
			}
			if ( !Misc13.isValid( GlobalVars.horns_list.len ) ) {
				GlobalFuncs.init_sprite_accessory_subtypes( typeof(SpriteAccessory_Horns), GlobalVars.horns_list );
			}
			if ( !Misc13.isValid( GlobalVars.ears_list.len ) ) {
				GlobalFuncs.init_sprite_accessory_subtypes( typeof(SpriteAccessory_Ears), GlobalVars.horns_list );
			}
			if ( !Misc13.isValid( GlobalVars.frills_list.len ) ) {
				GlobalFuncs.init_sprite_accessory_subtypes( typeof(SpriteAccessory_Frills), GlobalVars.frills_list );
			}
			if ( !Misc13.isValid( GlobalVars.spines_list.len ) ) {
				GlobalFuncs.init_sprite_accessory_subtypes( typeof(SpriteAccessory_Spines), GlobalVars.spines_list );
			}
			if ( !Misc13.isValid( GlobalVars.body_markings_list.len ) ) {
				GlobalFuncs.init_sprite_accessory_subtypes( typeof(SpriteAccessory_BodyMarkings), GlobalVars.body_markings_list );
			}
			return new ByTable().set( "body_markings", Rand.pick( GlobalVars.body_markings_list ) ).set( "spines", Rand.pick( GlobalVars.spines_list ) ).set( "frills", Rand.pick( GlobalVars.frills_list ) ).set( "ears", "None" ).set( "horns", Rand.pick( GlobalVars.horns_list ) ).set( "snout", Rand.pick( GlobalVars.snouts_list ) ).set( "tail_human", "None" ).set( "tail_lizard", Rand.pick( GlobalVars.tails_list_lizard ) ).set( "mcolor", Rand.pick(new object [] { "FFFFFF", "7F7F7F", "7FFF7F", "7F7FFF", "FF7F7F", "7FFFFF", "FF7FFF", "FFFF7F" }) );
		}

		public static dynamic random_hair_style( dynamic gender = null ) {
			dynamic _ = gender; // Was a switch-case, sorry for the mess.
			if ( _=="male" ) {
				return Rand.pick( GlobalVars.hair_styles_male_list );
			} else if ( _=="female" ) {
				return Rand.pick( GlobalVars.hair_styles_female_list );
			} else {
				return Rand.pick( GlobalVars.hair_styles_list );
			};
		}

		public static string random_short_color(  ) {
			return GlobalFuncs.random_string( 3, GlobalVars.hex_characters );
		}

		public static dynamic random_skin_tone(  ) {
			return Rand.pick( GlobalVars.skin_tones );
		}

		public static dynamic random_socks( dynamic gender = null ) {
			if ( !Misc13.isValid( GlobalVars.socks_list.len ) ) {
				GlobalFuncs.init_sprite_accessory_subtypes( typeof(SpriteAccessory_Socks), GlobalVars.socks_list, GlobalVars.socks_m, GlobalVars.socks_f );
			}
			dynamic _ = gender; // Was a switch-case, sorry for the mess.
			if ( _=="male" ) {
				return Rand.pick( GlobalVars.socks_m );
			} else if ( _=="female" ) {
				return Rand.pick( GlobalVars.socks_f );
			} else {
				return Rand.pick( GlobalVars.socks_list );
			};
		}

		public static void random_step( dynamic AM = null, dynamic steps = null, dynamic chance = null ) {
			dynamic initial_chance = null;
			initial_chance = chance;
			while (steps > 0) {
				if ( Misc13.isValid( Rand.chance( chance ) ) ) {
					Misc13.step( AM, Rand.pick( GlobalVars.alldirs ) );
				}
				chance = Misc13.max( chance - initial_chance / steps, 0 );
				steps--;
			}
		}

		public static string random_string( dynamic length = null, dynamic characters = null ) {
			string _default = null;
			int i = 0;
			_default = "";
			i = null;
			i = 1;
			while (i <= length) {
				_default += Rand.pick( characters );
				i++;
			}
			return _default;
		}

		public static dynamic random_undershirt( dynamic gender = null ) {
			if ( !Misc13.isValid( GlobalVars.undershirt_list.len ) ) {
				GlobalFuncs.init_sprite_accessory_subtypes( typeof(SpriteAccessory_Undershirt), GlobalVars.undershirt_list, GlobalVars.undershirt_m, GlobalVars.undershirt_f );
			}
			dynamic _ = gender; // Was a switch-case, sorry for the mess.
			if ( _=="male" ) {
				return Rand.pick( GlobalVars.undershirt_m );
			} else if ( _=="female" ) {
				return Rand.pick( GlobalVars.undershirt_f );
			} else {
				return Rand.pick( GlobalVars.undershirt_list );
			};
		}

		public static dynamic random_underwear( dynamic gender = null ) {
			if ( !Misc13.isValid( GlobalVars.underwear_list.len ) ) {
				GlobalFuncs.init_sprite_accessory_subtypes( typeof(SpriteAccessory_Underwear), GlobalVars.underwear_list, GlobalVars.underwear_m, GlobalVars.underwear_f );
			}
			dynamic _ = gender; // Was a switch-case, sorry for the mess.
			if ( _=="male" ) {
				return Rand.pick( GlobalVars.underwear_m );
			} else if ( _=="female" ) {
				return Rand.pick( GlobalVars.underwear_f );
			} else {
				return Rand.pick( GlobalVars.underwear_list );
			};
		}

		public static dynamic random_unique_lizard_name( dynamic gender = null, int attempts_to_find_unique_name = 0 ) {
			dynamic _default = null;
			int i = 0;
			if ( attempts_to_find_unique_name == null ) {
				attempts_to_find_unique_name = 10;
			}
			i = null;
			i = 1;
			while (i <= attempts_to_find_unique_name) {
				_default = GlobalFuncs.capitalize( GlobalFuncs.lizard_name( gender ) );
				if ( i != attempts_to_find_unique_name && ( GlobalFuncs.findname( _default ) == 0 ) ) {
					break;
				}
				i++;
			}
			return _default;
		}

		public static dynamic random_unique_name( dynamic gender = null, int attempts_to_find_unique_name = 0 ) {
			dynamic _default = null;
			int i = 0;
			if ( attempts_to_find_unique_name == null ) {
				attempts_to_find_unique_name = 10;
			}
			i = null;
			i = 1;
			while (i <= attempts_to_find_unique_name) {
				if ( gender == GlobalVars.FEMALE ) {
					_default = GlobalFuncs.capitalize( Rand.pick( GlobalVars.first_names_female ) ) + " " + GlobalFuncs.capitalize( Rand.pick( GlobalVars.last_names ) );
				} else {
					_default = GlobalFuncs.capitalize( Rand.pick( GlobalVars.first_names_male ) ) + " " + GlobalFuncs.capitalize( Rand.pick( GlobalVars.last_names ) );
				}
				if ( i != attempts_to_find_unique_name && ( GlobalFuncs.findname( _default ) == 0 ) ) {
					break;
				}
				i++;
			}
			return _default;
		}

		public static string randomColor( int mode = 0 ) {
			if ( mode == null ) {
				mode = 0;
			}
			dynamic _ = mode; // Was a switch-case, sorry for the mess.
			if ( _==0 ) {
				return Rand.pick(new object [] { "white", "black", "gray", "red", "green", "blue", "brown", "yellow", "orange", "darkred", "crimson", "lime", "darkgreen", "cyan", "navy", "teal", "purple", "indigo" });
			} else if ( _==1 ) {
				return Rand.pick(new object [] { "red", "green", "blue", "brown", "yellow", "orange", "darkred", "crimson", "lime", "darkgreen", "cyan", "navy", "teal", "purple", "indigo" });
			} else {
				return "white";
			};
		}

		public static void randomize_human( dynamic H = null ) {
			H.gender = Rand.pick(new object [] { GlobalVars.MALE, GlobalVars.FEMALE });
			H.real_name = GlobalFuncs.random_unique_name( H.gender );
			H.name = H.real_name;
			H.underwear = GlobalFuncs.random_underwear( H.gender );
			H.skin_tone = GlobalFuncs.random_skin_tone();
			H.hair_style = GlobalFuncs.random_hair_style( H.gender );
			H.facial_hair_style = GlobalFuncs.random_facial_hair_style( H.gender );
			H.hair_color = GlobalFuncs.random_short_color();
			H.facial_hair_color = H.hair_color;
			H.eye_color = GlobalFuncs.random_eye_color();
			H.dna.blood_type = GlobalFuncs.random_blood_type();
			H.update_body();
			H.update_hair();
		}

		public static ByTable ReadHSV( dynamic hsv = null ) {
			ByTable _default = null;
			int i = 0;
			int start = 0;
			dynamic ch = null;
			int which = 0;
			int hue = 0;
			int sat = 0;
			int val = 0;
			int alpha = 0;
			int usealpha = 0;
			int digits = 0;
			if ( !Misc13.isValid( hsv ) ) {
				return null;
			}
			i = 1;
			start = 1;
			if ( Misc13.conv_text2ascii( hsv, null ) == 35 ) {
				start++;
			}
			which = 0;
			hue = 0;
			sat = 0;
			val = 0;
			alpha = 0;
			digits = 0;
			i = start;
			while (i <= hsv.Length) {
				ch = Misc13.conv_text2ascii( hsv, i );
				if ( ch < 48 || ch > 57 && ch < 65 || ch > 70 && ch < 97 || ch > 102 ) {
					break;
				}
				digits++;
				if ( digits == 9 ) {
					break;
				}
				i++;
			}
			if ( digits > 7 ) {
				usealpha = 1;
			}
			if ( digits <= 4 ) {
				which++;
			}
			if ( digits <= 2 ) {
				which++;
			}
			i = start;
			while (digits > 0) {
				ch = Misc13.conv_text2ascii( hsv, i );
				if ( ch >= 48 && ch <= 57 ) {
					ch -= 48;
				} else if ( ch >= 65 && ch <= 70 ) {
					ch -= 55;
				} else if ( ch >= 97 && ch <= 102 ) {
					ch -= 87;
				} else {
					break;
				}
				digits--;
				dynamic _ = which; // Was a switch-case, sorry for the mess.
				if ( _==0 ) {
					hue = hue << 4 | ch;
					if ( digits == ( usealpha != 0 ? 6 : 4 ) ) {
						which++;
					}
				} else if ( _==1 ) {
					sat = sat << 4 | ch;
					if ( digits == ( usealpha != 0 ? 4 : 2 ) ) {
						which++;
					}
				} else if ( _==2 ) {
					val = val << 4 | ch;
					if ( digits == ( usealpha != 0 ? 2 : 0 ) ) {
						which++;
					}
				} else if ( _==3 ) {
					alpha = alpha << 4 | ch;
				};
				i++;
			}
			_default = new ByTable(new object [] {hue,sat,val});
			if ( usealpha != 0 ) {
				_default += alpha;
			}
			return _default;
		}

		public static ByTable ReadRGB( dynamic rgb = null ) {
			ByTable _default = null;
			int i = 0;
			int start = 0;
			dynamic ch = null;
			int which = 0;
			int r = 0;
			int g = 0;
			int b = 0;
			int alpha = 0;
			int usealpha = 0;
			int digits = 0;
			bool single = false;
			if ( !Misc13.isValid( rgb ) ) {
				return null;
			}
			i = 1;
			start = 1;
			if ( Misc13.conv_text2ascii( rgb, null ) == 35 ) {
				start++;
			}
			which = 0;
			r = 0;
			g = 0;
			b = 0;
			alpha = 0;
			digits = 0;
			i = start;
			while (i <= rgb.Length) {
				ch = Misc13.conv_text2ascii( rgb, i );
				if ( ch < 48 || ch > 57 && ch < 65 || ch > 70 && ch < 97 || ch > 102 ) {
					break;
				}
				digits++;
				if ( digits == 8 ) {
					break;
				}
				i++;
			}
			single = digits < 6;
			if ( digits != 3 && digits != 4 && digits != 6 && digits != 8 ) {
				return null;
			}
			if ( digits == 4 || digits == 8 ) {
				usealpha = 1;
			}
			i = start;
			while (digits > 0) {
				ch = Misc13.conv_text2ascii( rgb, i );
				if ( ch >= 48 && ch <= 57 ) {
					ch -= 48;
				} else if ( ch >= 65 && ch <= 70 ) {
					ch -= 55;
				} else if ( ch >= 97 && ch <= 102 ) {
					ch -= 87;
				} else {
					break;
				}
				digits--;
				dynamic _ = which; // Was a switch-case, sorry for the mess.
				if ( _==0 ) {
					r = r << 4 | ch;
					if ( single ) {
						r |= r << 4;
						which++;
					} else if ( ( digits & 1 ) == 0 ) {
						which++;
					}
				} else if ( _==1 ) {
					g = g << 4 | ch;
					if ( single ) {
						g |= g << 4;
						which++;
					} else if ( ( digits & 1 ) == 0 ) {
						which++;
					}
				} else if ( _==2 ) {
					b = b << 4 | ch;
					if ( single ) {
						b |= b << 4;
						which++;
					} else if ( ( digits & 1 ) == 0 ) {
						which++;
					}
				} else if ( _==3 ) {
					alpha = alpha << 4 | ch;
					if ( single ) {
						alpha |= alpha << 4;
					}
				};
				i++;
			}
			_default = new ByTable(new object [] {r,g,b});
			if ( usealpha != 0 ) {
				_default += alpha;
			}
			return _default;
		}

		public static ByTable recursive_hear_check( dynamic O = null ) {
			ByTable processing_list = null;
			ByTable processed_list = null;
			ByTable found_atoms = null;
			dynamic A = null;
			dynamic B = null;
			processing_list = new ByTable(new object [] {O});
			processed_list = new ByTable();
			found_atoms = new ByTable();
			while (processing_list.len) {
				A = processing_list[1];
				if ( Misc13.isValid( ( A.flags & 16 ) ) ) {
					found_atoms |= A;
				}
				B = null;
				foreach (dynamic _ in A ) {
					B = _;
					if ( !( B is BaseStatic ) ) {
						continue;
					}
					if ( !Misc13.isValid( processed_list[B] ) ) {
						processing_list |= B;
					}
				};
				processing_list.Cut( 1, 2 );
				processed_list[A] = A;
			}
			return found_atoms;
		}

		public static ByTable recursive_mob_check( dynamic O = null, int client_check = 0, int sight_check = 0, int include_radio = 0 ) {
			ByTable processing_list = null;
			ByTable processed_list = null;
			ByTable found_mobs = null;
			dynamic A = null;
			int passed = 0;
			dynamic A_tmp = null;
			dynamic B = null;
			if ( client_check == null ) {
				client_check = 1;
			}
			if ( sight_check == null ) {
				sight_check = 1;
			}
			if ( include_radio == null ) {
				include_radio = 1;
			}
			processing_list = new ByTable(new object [] {O});
			processed_list = new ByTable();
			found_mobs = new ByTable();
			while (processing_list.len) {
				A = processing_list[1];
				passed = 0;
				if ( A is Mob ) {
					A_tmp = A;
					passed = 1;
					if ( ( client_check != 0 ) && !Misc13.isValid( A_tmp.client ) ) {
						passed = 0;
					}
					if ( ( sight_check != 0 ) && ( GlobalFuncs.isInSight( A_tmp, O ) == 0 ) ) {
						passed = 0;
					}
				} else if ( ( include_radio != 0 ) && A is Ent_Item_Device_Radio ) {
					passed = 1;
					if ( ( sight_check != 0 ) && ( GlobalFuncs.isInSight( A, O ) == 0 ) ) {
						passed = 0;
					}
				}
				if ( passed != 0 ) {
					found_mobs |= A;
				}
				B = null;
				foreach (dynamic _ in A ) {
					B = _;
					if ( !( B is BaseStatic ) ) {
						continue;
					}
					if ( !Misc13.isValid( processed_list[B] ) ) {
						processing_list |= B;
					}
				};
				processing_list.Cut( 1, 2 );
				processed_list[A] = A;
			}
			return found_mobs;
		}

		public static Regex regex_find( dynamic str = null, dynamic exp = null ) {
			return new Regex( str, exp, Misc13.getf_dll( "bin/bygex", "regex_find" )( str, exp ) );
		}

		public static Regex regex_note_sql_extract( dynamic str = null, dynamic exp = null ) {
			return new Regex( str, exp, Misc13.getf_dll( "bin/bygex", "regEx_find" )( str, exp ) );
		}

		public static string reject_bad_name( dynamic t_in = null, int allow_numbers = 0, int max_length = 0 ) {
			int number_of_alphanumeric = 0;
			int last_char_group = 0;
			string t_out = null;
			int i = 0;
			dynamic ascii_char = null;
			dynamic bad_name = null;
			if ( allow_numbers == null ) {
				allow_numbers = 0;
			}
			if ( max_length == null ) {
				max_length = 26;
			}
			if ( !Misc13.isValid( t_in ) || t_in.Length > max_length ) {
				return null;
			}
			number_of_alphanumeric = 0;
			last_char_group = 0;
			t_out = "";
			i = null;
			i = 1;
			while (i <= t_in.Length) {
				ascii_char = Misc13.conv_text2ascii( t_in, i );
				dynamic _ = ascii_char; // Was a switch-case, sorry for the mess.
				if ( 65<=_&&_<=90 ) {
					t_out += Misc13.conv_ascii2text( ascii_char );
					number_of_alphanumeric++;
					last_char_group = 4;
				} else if ( 97<=_&&_<=122 ) {
					if ( last_char_group < 2 ) {
						t_out += Misc13.conv_ascii2text( ascii_char - 32 );
					} else {
						t_out += Misc13.conv_ascii2text( ascii_char );
					}
					number_of_alphanumeric++;
					last_char_group = 4;
				} else if ( 48<=_&&_<=57 ) {
					if ( last_char_group == 0 ) {
						i++;
						continue;
					}
					if ( allow_numbers == 0 ) {
						i++;
						continue;
					}
					t_out += Misc13.conv_ascii2text( ascii_char );
					number_of_alphanumeric++;
					last_char_group = 3;
				} else if ( _==39 || _==45 || _==46 ) {
					if ( last_char_group == 0 ) {
						i++;
						continue;
					}
					t_out += Misc13.conv_ascii2text( ascii_char );
					last_char_group = 2;
				} else if ( _==126 || _==124 || _==64 || _==58 || _==35 || _==36 || _==37 || _==38 || _==42 || _==43 ) {
					if ( last_char_group == 0 ) {
						i++;
						continue;
					}
					if ( allow_numbers == 0 ) {
						i++;
						continue;
					}
					t_out += Misc13.conv_ascii2text( ascii_char );
					last_char_group = 2;
				} else if ( _==32 ) {
					if ( last_char_group <= 1 ) {
						i++;
						continue;
					}
					t_out += Misc13.conv_ascii2text( ascii_char );
					last_char_group = 1;
				} else {
					return null;
				};
				i++;
			}
			if ( number_of_alphanumeric < 2 ) {
				return null;
			}
			if ( last_char_group == 1 ) {
				t_out = Misc13.str_sub( t_out, 1, t_out.Length );
			}
			bad_name = null;
			foreach (dynamic _ in new ByTable(new object [] {"space","floor","wall","r-wall","monkey","unknown","inactive ai"}) ) {
				bad_name = _;
				if ( Misc13.isValid( Misc13.str_cmp( bad_name, t_out ) ) ) {
					return null;
				}
			};
			return t_out;
		}

		public static dynamic reject_bad_text( dynamic text = null, int max_length = 0 ) {
			int non_whitespace = 0;
			int i = 0;
			if ( max_length == null ) {
				max_length = 512;
			}
			if ( text.Length > max_length ) {
				return null;
			}
			non_whitespace = 0;
			i = null;
			i = 1;
			while (i <= text.Length) {
				dynamic _ = Misc13.conv_text2ascii( text, i ); // Was a switch-case, sorry for the mess.
				if ( 127<=_&&_<=255 ) {
					return null;
				} else if ( 0<=_&&_<=31 ) {
					return null;
				} else if ( _==62 || _==60 || _==92 || _==47 ) {
					return null;
				} else if ( _==32 ) {
					i++;
					continue;
				} else {
					non_whitespace = 1;
				};
				i++;
			}
			if ( non_whitespace != 0 ) {
				return text;
			}
		}

		public static void release( dynamic O = null ) {
			dynamic H = null;
			if ( Misc13.isValid( Misc13.thread_user.control_object ) && Misc13.isValid( Misc13.thread_user.name_archive ) ) {
				Misc13.thread_user.real_name = Misc13.thread_user.name_archive;
				Misc13.thread_user.name = Misc13.thread_user.real_name;
				if ( Misc13.thread_user is Mob_Living_Carbon_Human ) {
					H = Misc13.thread_user;
					H.name = H.get_visible_name();
				}
			}
			Misc13.thread_user.loc = O.loc;
			Misc13.thread_user.client.eye = Misc13.thread_user;
			Misc13.thread_user.control_object = null;
			GlobalFuncs.feedback_add_details( "admin_verb", "RO" );
		}

		public static void remove_note( dynamic note_id = null ) {
			dynamic ckey = null;
			dynamic notetext = null;
			dynamic adminckey = null;
			DBQuery query_find_note_del = null;
			dynamic err = null;
			DBQuery query_del_note = null;
			if ( GlobalVars.dbcon.IsConnected() == 0 ) {
				Misc13.thread_user.write( "<span class='danger'>Failed to establish database connection.</span>" );
				return;
			}
			if ( !Misc13.isValid( note_id ) ) {
				return;
			}
			note_id = Misc13.parseNumber( note_id );
			query_find_note_del = GlobalVars.dbcon.NewQuery( "SELECT ckey, notetext, adminckey FROM " + GlobalFuncs.format_table_name( "notes" ) + " WHERE id = " + note_id );
			if ( !Misc13.isValid( query_find_note_del.Execute() ) ) {
				err = query_find_note_del.ErrorMsg();
				GlobalFuncs.log_game( "SQL ERROR obtaining ckey, notetext, adminckey from notes table. Error : [" + err + "]\n" );
				return;
			}
			if ( Misc13.isValid( query_find_note_del.NextRow() ) ) {
				ckey = query_find_note_del.item[1];
				notetext = query_find_note_del.item[2];
				adminckey = query_find_note_del.item[3];
			}
			query_del_note = GlobalVars.dbcon.NewQuery( "DELETE FROM " + GlobalFuncs.format_table_name( "notes" ) + " WHERE id = " + note_id );
			if ( !Misc13.isValid( query_del_note.Execute() ) ) {
				err = query_del_note.ErrorMsg();
				GlobalFuncs.log_game( "SQL ERROR removing note from table. Error : [" + err + "]\n" );
				return;
			}
			GlobalFuncs.log_admin( "" + GlobalFuncs.key_name( Misc13.thread_user ) + " has removed a note made by " + adminckey + " from " + ckey + ": " + notetext );
			GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( Misc13.thread_user ) + " has removed a note made by " + adminckey + " from " + ckey + ":<br>" + notetext );
			GlobalFuncs.show_note( ckey );
		}

		public static void remove_radio( dynamic radio = null, dynamic freq = null ) {
			if ( !Misc13.isValid( freq ) || !Misc13.isValid( radio ) ) {
				return;
			}
			if ( !Misc13.isValid( GlobalVars.all_radios["" + freq] ) ) {
				return;
			}
			GlobalVars.all_radios["" + freq] -= radio;
		}

		public static void remove_radio_all( dynamic radio = null ) {
			dynamic freq = null;
			freq = null;
			foreach (dynamic _ in GlobalVars.all_radios ) {
				freq = _;
				GlobalVars.all_radios["" + freq] -= radio;
			};
		}

		public static int RemoveBan( dynamic foldername = null ) {
			dynamic key = null;
			dynamic id = null;
			dynamic A = null;
			GlobalVars.Banlist.cd = "/base/" + foldername;
			key = GlobalVars.Banlist["key"].read();
			id = GlobalVars.Banlist["id"].read();
			GlobalVars.Banlist.cd = "/base";
			if ( !Misc13.isValid( GlobalVars.Banlist.dir.Remove( foldername ) ) ) {
				return 0;
			}
			if ( !Misc13.isValid( Misc13.thread_user ) ) {
				GlobalFuncs.log_admin( "Ban Expired: " + key );
				GlobalFuncs.message_admins( "Ban Expired: " + key );
			} else {
				GlobalFuncs.ban_unban_log_save( "" + GlobalFuncs.key_name( Misc13.thread_user ) + " unbanned " + key );
				GlobalFuncs.log_admin( "" + GlobalFuncs.key_name( Misc13.thread_user ) + " unbanned " + key );
				GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( Misc13.thread_user ) + " unbanned: " + key );
				GlobalFuncs.feedback_inc( "ban_unban", 1 );
				Misc13.thread_user.client.holder.DB_ban_unban( Misc13.ckey( key ), 5 );
			}
			A = null;
			foreach (dynamic _ in GlobalVars.Banlist.dir ) {
				A = _;
				GlobalVars.Banlist.cd = "/base/" + A;
				if ( key == GlobalVars.Banlist["key"] ) {
					GlobalVars.Banlist.cd = "/base";
					GlobalVars.Banlist.dir.Remove( A );
					continue;
				}
			};
			return 1;
		}

		public static int RemoveBanjob( dynamic foldername = null ) {
			dynamic key = null;
			dynamic id = null;
			dynamic rank = null;
			dynamic A = null;
			GlobalVars.Banlistjob.cd = "/base/" + foldername;
			key = GlobalVars.Banlistjob["key"].read();
			id = GlobalVars.Banlistjob["id"].read();
			rank = GlobalVars.Banlistjob["rank"].read();
			GlobalVars.Banlistjob.cd = "/base";
			if ( !Misc13.isValid( GlobalVars.Banlistjob.dir.Remove( foldername ) ) ) {
				return 0;
			}
			if ( !Misc13.isValid( Misc13.thread_user ) ) {
				GlobalFuncs.log_admin( "Banjob Expired: " + key );
				GlobalFuncs.message_admins( "Banjob Expired: " + key );
			} else {
				GlobalFuncs.log_admin( "" + GlobalFuncs.key_name( Misc13.thread_user ) + " unjobbanned " + key + " from " + rank );
				GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( Misc13.thread_user ) + " unjobbanned:" + key + " from " + rank );
				GlobalFuncs.ban_unban_log_save( "" + GlobalFuncs.key_name( Misc13.thread_user ) + " unjobbanned " + key + " from " + rank );
				GlobalFuncs.feedback_inc( "ban_job_unban", 1 );
				GlobalFuncs.feedback_add_details( "ban_job_unban", "- " + rank );
			}
			A = null;
			foreach (dynamic _ in GlobalVars.Banlistjob.dir ) {
				A = _;
				GlobalVars.Banlistjob.cd = "/base/" + A;
				if ( ( key == GlobalVars.Banlistjob["key"] || id == GlobalVars.Banlistjob["id"] ) && rank == GlobalVars.Banlistjob["rank"] ) {
					GlobalVars.Banlistjob.cd = "/base";
					GlobalVars.Banlistjob.dir.Remove( A );
					continue;
				}
			};
			return 1;
		}

		public static dynamic removeNullsFromList( dynamic L = null ) {
			while (L.Remove( null )) {
				continue;
			}
			return L;
		}

		public static string repeat_string( dynamic times = null, string _string = null ) {
			string _default = null;
			int i = 0;
			if ( _string == null ) {
				_string = "";
			}
			_default = "";
			i = null;
			i = 1;
			while (i <= times) {
				_default += _string;
				i++;
			}
			return _default;
		}

		public static dynamic replacetext( dynamic str = null, dynamic exp = null, dynamic fmt = null ) {
			return Misc13.getf_dll( "bin/bygex", "regex_replaceallliteral" )( str, exp, fmt );
		}

		public static dynamic replacetextEx( dynamic str = null, dynamic exp = null, dynamic fmt = null ) {
			return Misc13.getf_dll( "bin/bygex", "regEx_replaceallliteral" )( str, exp, fmt );
		}

		public static dynamic return_file_text( dynamic filename = null ) {
			dynamic text = null;
			if ( File13.exists( filename ) == 0 ) {
				throw new Exception( "return_file_text(): File not found", "code/__HELPERS/files.dm", 5 );
				return null;
			}
			text = File13.read( filename );
			if ( !Misc13.isValid( text ) ) {
				throw new Exception( "return_file_text(): File empty", "code/__HELPERS/files.dm", 10 );
				return null;
			}
			return text;
		}

		public static dynamic reverseRange( dynamic L = null, int start = 0, int end = 0 ) {
			if ( start == null ) {
				start = 1;
			}
			if ( end == null ) {
				end = 0;
			}
			if ( Misc13.isValid( L.len ) ) {
				start = start % L.len;
				end = end % ( L.len + 1 );
				if ( start <= 0 ) {
					start += L.len;
				}
				if ( end <= 0 ) {
					end += L.len + 1;
				}
				end--;
				while (start < end) {
					L.Swap( start++, end-- );
				}
			}
			return L;
		}

		public static void revoke_maint_all_access(  ) {
			dynamic A = null;
			dynamic D = null;
			A = null;
			foreach (dynamic _ in Game ) {
				A = _;
				if ( !Misc13.isValid( new ByArea(2826).IsInstanceOfType( A ) ) ) {
					continue;
				}
				D = null;
				foreach (dynamic _ in A ) {
					D = _;
					if ( !( D is Ent_Machinery_Door_Airlock ) ) {
						continue;
					}
					D.emergency = 0;
					D.update_icon( 0 );
				};
			};
			GlobalFuncs.minor_announce( "Access restrictions in maintenance areas have been restored.", "Attention! Station-wide emergency rescinded:" );
			GlobalVars.emergency_access = 0;
		}

		public static ByTable rgb2hsl( dynamic red = null, dynamic green = null, dynamic blue = null ) {
			dynamic max = null;
			dynamic min = null;
			dynamic range = null;
			int hue = 0;
			int saturation = 0;
			int lightness = 0;
			dynamic dred = null;
			dynamic dgreen = null;
			dynamic dblue = null;
			red /= 255;
			green /= 255;
			blue /= 255;
			max = Misc13.max( red, green, blue );
			min = Misc13.min( red, green, blue );
			range = max - min;
			hue = 0;
			saturation = 0;
			lightness = 0;
			lightness = ( max + min ) / 2;
			if ( range != 0 ) {
				if ( lightness < 0.5 ) {
					saturation = range / ( max + min );
				} else {
					saturation = range / ( 2 - max - min );
				}
				dred = ( max - red ) / ( max * 6 ) + 0.5;
				dgreen = ( max - green ) / ( max * 6 ) + 0.5;
				dblue = ( max - blue ) / ( max * 6 ) + 0.5;
				if ( max == red ) {
					hue = dblue - dgreen;
				} else if ( max == green ) {
					hue = dred - dblue + 0.3333333432674408;
				} else {
					hue = dgreen - dred + 0.6666666865348816;
				}
				if ( hue < 0 ) {
					hue++;
				} else if ( hue > 1 ) {
					hue--;
				}
			}
			return new ByTable(new object [] {hue,saturation,lightness});
		}

		public static string RGBtoHSV( dynamic rgb = null ) {
			ByTable RGB = null;
			dynamic r = null;
			dynamic g = null;
			dynamic b = null;
			dynamic hi = null;
			dynamic lo = null;
			dynamic val = null;
			dynamic sat = null;
			int hue = 0;
			int dir = 0;
			dynamic mid = null;
			if ( !Misc13.isValid( rgb ) ) {
				return "#0000000";
			}
			RGB = GlobalFuncs.ReadRGB( rgb );
			if ( RGB == null ) {
				return "#0000000";
			}
			r = RGB[1];
			g = RGB[2];
			b = RGB[3];
			hi = Misc13.max( r, g, b );
			lo = Misc13.min( r, g, b );
			val = hi;
			sat = Misc13.isValid( hi ) ? Misc13.round( ( hi - lo ) * 255 / hi, 1 ) : 0;
			hue = 0;
			if ( Misc13.isValid( sat ) ) {
				if ( hi == r ) {
					if ( lo == b ) {
						hue = 0;
						dir = 1;
						mid = g;
					} else {
						hue = 1535;
						dir = -1;
						mid = b;
					}
				} else if ( hi == g ) {
					if ( lo == r ) {
						hue = 512;
						dir = 1;
						mid = b;
					} else {
						hue = 511;
						dir = -1;
						mid = r;
					}
				} else if ( hi == b ) {
					if ( lo == g ) {
						hue = 1024;
						dir = 1;
						mid = r;
					} else {
						hue = 1023;
						dir = -1;
						mid = g;
					}
				}
				hue += dir * Misc13.round( ( mid - lo ) * 255 / ( hi - lo ), 1 );
			}
			return GlobalFuncs.hsv( hue, sat, val, RGB.len > 3 ? RGB[4] : null );
		}

		public static void rightandwrong( dynamic summon_type = null, dynamic user = null, dynamic survivor_probability = null ) {
			ByTable gunslist = null;
			ByTable magiclist = null;
			ByTable magicspeciallist = null;
			dynamic H = null;
			Objective_SummonGuns guns = null;
			Objective_Survive survive = null;
			int obj_count = 0;
			dynamic OBJ = null;
			dynamic randomizeguns = null;
			dynamic randomizemagic = null;
			dynamic randomizemagicspecial = null;
			Ent_Item_Weapon_Gun_Energy_Lasercannon gat = null;
			gunslist = new ByTable(new object [] {"taser","egun","laser","revolver","detective","c20r","nuclear","deagle","gyrojet","pulse","suppressed","cannon","doublebarrel","shotgun","combatshotgun","bulldog","mateba","sabr","crossbow","saw","car","boltaction","speargun","arg","uzi"});
			magiclist = new ByTable(new object [] {"fireball","smoke","blind","mindswap","forcewall","knock","horsemask","charge","summonitem","wandnothing","wanddeath","wandresurrection","wandpolymorph","wandteleport","wanddoor","wandfireball","staffchange","staffhealing","armor","scrying","staffdoor","voodoo","special"});
			magicspeciallist = new ByTable(new object [] {"staffchange","staffanimation","wandbelt","contract","staffchaos","necromantic"});
			if ( Misc13.isValid( user ) ) {
				user.write( "<B>You summoned " + ( Misc13.isValid( summon_type ) ? "magic" : "guns" ) + "!</B>" );
				GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( user, 1 ) + " summoned " + ( Misc13.isValid( summon_type ) ? "magic" : "guns" ) + "!" );
				GlobalFuncs.log_game( "" + GlobalFuncs.key_name( user ) + " summoned " + ( Misc13.isValid( summon_type ) ? "magic" : "guns" ) + "!" );
			}
			H = null;
			foreach (dynamic _ in GlobalVars.player_list ) {
				H = _;
				if ( !( H is Mob_Living_Carbon_Human ) ) {
					continue;
				}
				if ( H.stat == 2 || !Misc13.isValid( H.client ) ) {
					continue;
				}
				if ( Misc13.isValid( H.mind ) ) {
					if ( H.mind.special_role == "Wizard" || H.special_role == "apprentice" || H.special_role == "survivalist" ) {
						continue;
					}
				}
				if ( Misc13.isValid( Rand.chance( survivor_probability ) ) && !Misc13.isValid( GlobalVars.ticker.mode.traitors.HasValue( H.mind ) ) ) {
					GlobalVars.ticker.mode.traitors += H.mind;
					guns = new Objective_SummonGuns();
					guns.owner = H.mind;
					H.mind.objectives += guns;
					H.mind.special_role = "survivalist";
					survive = new Objective_Survive();
					survive.owner = H.mind;
					H.mind.objectives += survive;
					H.attack_log += "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Was made into a survivalist, and trusts no one!</font>";
					H.write( "<B>You are the survivalist! Your own safety matters above all else, and the only way to ensure your safety is to stockpile weapons! Grab as many guns as possible, by any means necessary. Kill anyone who gets in your way.</B>" );
					obj_count = 1;
					OBJ = null;
					foreach (dynamic _ in H.mind.objectives ) {
						OBJ = _;
						if ( !( OBJ is Objective ) ) {
							continue;
						}
						H.write( "<B>Objective #" + obj_count + "</B>: " + OBJ.explanation_text );
						obj_count++;
					};
				}
				randomizeguns = Rand.pick( gunslist );
				randomizemagic = Rand.pick( magiclist );
				randomizemagicspecial = Rand.pick( magicspeciallist );
				if ( !Misc13.isValid( summon_type ) ) {
					dynamic _ = randomizeguns; // Was a switch-case, sorry for the mess.
					if ( _=="taser" ) {
						new Ent_Item_Weapon_Gun_Energy_Gun_Advtaser( GlobalFuncs.get_turf( H ) );
					} else if ( _=="egun" ) {
						new Ent_Item_Weapon_Gun_Energy_Gun( GlobalFuncs.get_turf( H ) );
					} else if ( _=="laser" ) {
						new Ent_Item_Weapon_Gun_Energy_Laser( GlobalFuncs.get_turf( H ) );
					} else if ( _=="revolver" ) {
						new Ent_Item_Weapon_Gun_Projectile_Revolver( GlobalFuncs.get_turf( H ) );
					} else if ( _=="detective" ) {
						new Ent_Item_Weapon_Gun_Projectile_Revolver_Detective( GlobalFuncs.get_turf( H ) );
					} else if ( _=="deagle" ) {
						new Ent_Item_Weapon_Gun_Projectile_Automatic_Pistol_Deagle_Camo( GlobalFuncs.get_turf( H ) );
					} else if ( _=="gyrojet" ) {
						new Ent_Item_Weapon_Gun_Projectile_Automatic_Gyropistol( GlobalFuncs.get_turf( H ) );
					} else if ( _=="pulse" ) {
						new Ent_Item_Weapon_Gun_Energy_Pulse( GlobalFuncs.get_turf( H ) );
					} else if ( _=="suppressed" ) {
						new Ent_Item_Weapon_Gun_Projectile_Automatic_Pistol( GlobalFuncs.get_turf( H ) );
						new Ent_Item_Weapon_Suppressor( GlobalFuncs.get_turf( H ) );
					} else if ( _=="doublebarrel" ) {
						new Ent_Item_Weapon_Gun_Projectile_Revolver_Doublebarrel( GlobalFuncs.get_turf( H ) );
					} else if ( _=="shotgun" ) {
						new Ent_Item_Weapon_Gun_Projectile_Shotgun( GlobalFuncs.get_turf( H ) );
					} else if ( _=="combatshotgun" ) {
						new Ent_Item_Weapon_Gun_Projectile_Shotgun_Automatic_Combat( GlobalFuncs.get_turf( H ) );
					} else if ( _=="arg" ) {
						new Ent_Item_Weapon_Gun_Projectile_Automatic_Ar( GlobalFuncs.get_turf( H ) );
					} else if ( _=="mateba" ) {
						new Ent_Item_Weapon_Gun_Projectile_Revolver_Mateba( GlobalFuncs.get_turf( H ) );
					} else if ( _=="boltaction" ) {
						new Ent_Item_Weapon_Gun_Projectile_Shotgun_Boltaction( GlobalFuncs.get_turf( H ) );
					} else if ( _=="speargun" ) {
						new Ent_Item_Weapon_Gun_Projectile_Automatic_Speargun( GlobalFuncs.get_turf( H ) );
					} else if ( _=="uzi" ) {
						new Ent_Item_Weapon_Gun_Projectile_Automatic_MiniUzi( GlobalFuncs.get_turf( H ) );
					} else if ( _=="cannon" ) {
						gat = new Ent_Item_Weapon_Gun_Energy_Lasercannon( GlobalFuncs.get_turf( H ) );
						gat.pin = new Ent_Item_Device_FiringPin();
					} else if ( _=="crossbow" ) {
						gat = new Ent_Item_Weapon_Gun_Energy_KineticAccelerator_Crossbow_Large( GlobalFuncs.get_turf( H ) );
						gat.pin = new Ent_Item_Device_FiringPin();
					} else if ( _=="nuclear" ) {
						gat = new Ent_Item_Weapon_Gun_Energy_Gun_Nuclear( GlobalFuncs.get_turf( H ) );
						gat.pin = new Ent_Item_Device_FiringPin();
					} else if ( _=="sabr" ) {
						gat = new Ent_Item_Weapon_Gun_Projectile_Automatic_Proto( GlobalFuncs.get_turf( H ) );
						gat.pin = new Ent_Item_Device_FiringPin();
					} else if ( _=="bulldog" ) {
						gat = new Ent_Item_Weapon_Gun_Projectile_Automatic_Shotgun_Bulldog( GlobalFuncs.get_turf( H ) );
						gat.pin = new Ent_Item_Device_FiringPin();
					} else if ( _=="c20r" ) {
						gat = new Ent_Item_Weapon_Gun_Projectile_Automatic_C20r( GlobalFuncs.get_turf( H ) );
						gat.pin = new Ent_Item_Device_FiringPin();
					} else if ( _=="saw" ) {
						gat = new Ent_Item_Weapon_Gun_Projectile_Automatic_L6Saw( GlobalFuncs.get_turf( H ) );
						gat.pin = new Ent_Item_Device_FiringPin();
					} else if ( _=="car" ) {
						gat = new Ent_Item_Weapon_Gun_Projectile_Automatic_M90( GlobalFuncs.get_turf( H ) );
						gat.pin = new Ent_Item_Device_FiringPin();
					};
					GlobalFuncs.playsound( GlobalFuncs.get_turf( H ), new ByRsc(56), 50, 1 );
				} else {
					dynamic _ = randomizemagic; // Was a switch-case, sorry for the mess.
					if ( _=="fireball" ) {
						new Ent_Item_Weapon_Spellbook_Oneuse_Fireball( GlobalFuncs.get_turf( H ) );
					} else if ( _=="smoke" ) {
						new Ent_Item_Weapon_Spellbook_Oneuse_Smoke( GlobalFuncs.get_turf( H ) );
					} else if ( _=="blind" ) {
						new Ent_Item_Weapon_Spellbook_Oneuse_Blind( GlobalFuncs.get_turf( H ) );
					} else if ( _=="mindswap" ) {
						new Ent_Item_Weapon_Spellbook_Oneuse_Mindswap( GlobalFuncs.get_turf( H ) );
					} else if ( _=="forcewall" ) {
						new Ent_Item_Weapon_Spellbook_Oneuse_Forcewall( GlobalFuncs.get_turf( H ) );
					} else if ( _=="knock" ) {
						new Ent_Item_Weapon_Spellbook_Oneuse_Knock( GlobalFuncs.get_turf( H ) );
					} else if ( _=="horsemask" ) {
						new Ent_Item_Weapon_Spellbook_Oneuse_Barnyard( GlobalFuncs.get_turf( H ) );
					} else if ( _=="charge" ) {
						new Ent_Item_Weapon_Spellbook_Oneuse_Charge( GlobalFuncs.get_turf( H ) );
					} else if ( _=="summonitem" ) {
						new Ent_Item_Weapon_Spellbook_Oneuse_Summonitem( GlobalFuncs.get_turf( H ) );
					} else if ( _=="wandnothing" ) {
						new Ent_Item_Weapon_Gun_Magic_Wand( GlobalFuncs.get_turf( H ) );
					} else if ( _=="wanddeath" ) {
						new Ent_Item_Weapon_Gun_Magic_Wand_Death( GlobalFuncs.get_turf( H ) );
					} else if ( _=="wandresurrection" ) {
						new Ent_Item_Weapon_Gun_Magic_Wand_Resurrection( GlobalFuncs.get_turf( H ) );
					} else if ( _=="wandpolymorph" ) {
						new Ent_Item_Weapon_Gun_Magic_Wand_Polymorph( GlobalFuncs.get_turf( H ) );
					} else if ( _=="wandteleport" ) {
						new Ent_Item_Weapon_Gun_Magic_Wand_Teleport( GlobalFuncs.get_turf( H ) );
					} else if ( _=="wanddoor" ) {
						new Ent_Item_Weapon_Gun_Magic_Wand_Door( GlobalFuncs.get_turf( H ) );
					} else if ( _=="wandfireball" ) {
						new Ent_Item_Weapon_Gun_Magic_Wand_Fireball( GlobalFuncs.get_turf( H ) );
					} else if ( _=="staffhealing" ) {
						new Ent_Item_Weapon_Gun_Magic_Staff_Healing( GlobalFuncs.get_turf( H ) );
					} else if ( _=="staffdoor" ) {
						new Ent_Item_Weapon_Gun_Magic_Staff_Door( GlobalFuncs.get_turf( H ) );
					} else if ( _=="armor" ) {
						new Ent_Item_Clothing_Suit_Space_Hardsuit_Wizard( GlobalFuncs.get_turf( H ) );
					} else if ( _=="scrying" ) {
						new Ent_Item_Weapon_Scrying( GlobalFuncs.get_turf( H ) );
						if ( !Misc13.isValid( H.dna.check_mutation( "X Ray Vision" ) ) ) {
							H.add_mutation( "X Ray Vision" );
							H.write( "<span class='notice'>The walls suddenly disappear.</span>" );
						}
					} else if ( _=="voodoo" ) {
						new Ent_Item_Voodoo( GlobalFuncs.get_turf( H ) );
					} else if ( _=="special" ) {
						magiclist -= "special";
						dynamic _ = randomizemagicspecial; // Was a switch-case, sorry for the mess.
						if ( _=="staffchange" ) {
							new Ent_Item_Weapon_Gun_Magic_Staff_Change( GlobalFuncs.get_turf( H ) );
						} else if ( _=="staffanimation" ) {
							new Ent_Item_Weapon_Gun_Magic_Staff_Animate( GlobalFuncs.get_turf( H ) );
						} else if ( _=="wandbelt" ) {
							new Ent_Item_Weapon_Storage_Belt_Wands_Full( GlobalFuncs.get_turf( H ) );
						} else if ( _=="contract" ) {
							new Ent_Item_Weapon_AntagSpawner_Contract( GlobalFuncs.get_turf( H ) );
						} else if ( _=="staffchaos" ) {
							new Ent_Item_Weapon_Gun_Magic_Staff_Chaos( GlobalFuncs.get_turf( H ) );
						} else if ( _=="necromantic" ) {
							new Ent_Item_Device_NecromanticStone( GlobalFuncs.get_turf( H ) );
						};
						H.write( "<span class='notice'>You suddenly feel lucky.</span>" );
					};
					GlobalFuncs.playsound( GlobalFuncs.get_turf( H ), new ByRsc(57), 50, 1 );
				}
			};
		}

		public static void rights2text( dynamic rights = null, string seperator = null, dynamic adds = null, dynamic subs = null ) {
			void _default = null;
			dynamic verbpath = null;
			if ( seperator == null ) {
				seperator = "";
			}
			if ( Misc13.isValid( ( rights & 1 ) ) ) {
				_default += "" + seperator + "+BUILDMODE";
			}
			if ( Misc13.isValid( ( rights & 2 ) ) ) {
				_default += "" + seperator + "+ADMIN";
			}
			if ( Misc13.isValid( ( rights & 4 ) ) ) {
				_default += "" + seperator + "+BAN";
			}
			if ( Misc13.isValid( ( rights & 8 ) ) ) {
				_default += "" + seperator + "+FUN";
			}
			if ( Misc13.isValid( ( rights & 16 ) ) ) {
				_default += "" + seperator + "+SERVER";
			}
			if ( Misc13.isValid( ( rights & 32 ) ) ) {
				_default += "" + seperator + "+DEBUG";
			}
			if ( Misc13.isValid( ( rights & 64 ) ) ) {
				_default += "" + seperator + "+POSSESS";
			}
			if ( Misc13.isValid( ( rights & 128 ) ) ) {
				_default += "" + seperator + "+PERMISSIONS";
			}
			if ( Misc13.isValid( ( rights & 256 ) ) ) {
				_default += "" + seperator + "+STEALTH";
			}
			if ( Misc13.isValid( ( rights & 512 ) ) ) {
				_default += "" + seperator + "+REJUVINATE";
			}
			if ( Misc13.isValid( ( rights & 1024 ) ) ) {
				_default += "" + seperator + "+VAREDIT";
			}
			if ( Misc13.isValid( ( rights & 2048 ) ) ) {
				_default += "" + seperator + "+SOUND";
			}
			if ( Misc13.isValid( ( rights & 4096 ) ) ) {
				_default += "" + seperator + "+SPAWN";
			}
			verbpath = null;
			foreach (dynamic _ in adds ) {
				verbpath = _;
				_default += "" + seperator + "+" + verbpath;
			};
			verbpath = null;
			foreach (dynamic _ in subs ) {
				verbpath = _;
				_default += "" + seperator + "-" + verbpath;
			};
			return _default;
			return _default;
		}

		public static void robogibs( dynamic location = null, dynamic viruses = null ) {
			new Ent_Effect_Gibspawner_Robot( location, viruses );
		}

		public static string RoundDiagBar( dynamic value = null ) {
			dynamic _ = value * 100; // Was a switch-case, sorry for the mess.
			if ( 95<=_&&_<=9.999999848243207e+30 ) {
				return "max";
			} else if ( 80<=_&&_<=100 ) {
				return "good";
			} else if ( 60<=_&&_<=80 ) {
				return "high";
			} else if ( 40<=_&&_<=60 ) {
				return "med";
			} else if ( 20<=_&&_<=40 ) {
				return "low";
			} else if ( 1<=_&&_<=20 ) {
				return "crit";
			} else {
				return "dead";
			};
			return "dead";
		}

		public static string RoundHealth( dynamic health = null ) {
			dynamic _ = health; // Was a switch-case, sorry for the mess.
			if ( 100<=_&&_<=9.999999848243207e+30 ) {
				return "health100";
			} else if ( 70<=_&&_<=100 ) {
				return "health80";
			} else if ( 50<=_&&_<=70 ) {
				return "health60";
			} else if ( 30<=_&&_<=50 ) {
				return "health40";
			} else if ( 18<=_&&_<=30 ) {
				return "health25";
			} else if ( 5<=_&&_<=18 ) {
				return "health10";
			} else if ( 1<=_&&_<=5 ) {
				return "health1";
			} else if ( -99<=_&&_<=0 ) {
				return "health0";
			} else {
				return "health-100";
			};
			return "0";
		}

		public static dynamic safepick( dynamic L = null ) {
			if ( Misc13.isValid( ByTable.IsInstanceOfType( L ) ) && Misc13.isValid( L.len ) ) {
				return Rand.pick( L );
			}
		}

		public static dynamic sanitize( dynamic t = null, dynamic repl_chars = null ) {
			if ( repl_chars == null ) {
				repl_chars = null;
			}
			return Misc13.html_encode( GlobalFuncs.sanitize_simple( t, repl_chars ) );
		}

		public static dynamic sanitize_frequency( dynamic f = null ) {
			f = Misc13.round( f );
			f = Misc13.max( 1441, f );
			f = Misc13.min( 1489, f );
			if ( f % 2 == 0 ) {
				f += 1;
			}
			return f;
		}

		public static string sanitize_gender( dynamic gender = null, int neuter = 0, int plural = 0, string __default = null ) {
			if ( neuter == null ) {
				neuter = 0;
			}
			if ( plural == null ) {
				plural = 0;
			}
			if ( __default == null ) {
				__default = "male";
			}
			dynamic _ = gender; // Was a switch-case, sorry for the mess.
			if ( _=="male" || _=="female" ) {
				return gender;
			} else if ( _=="neuter" ) {
				if ( neuter != 0 ) {
					return gender;
				} else {
					return __default;
				}
			} else if ( _=="plural" ) {
				if ( plural != 0 ) {
					return gender;
				} else {
					return __default;
				}
			};
			return __default;
		}

		public static string sanitize_hexcolor( string color = null, int desired_format = 0, int include_crunch = 0, dynamic __default = null ) {
			string _default = null;
			string crunch = null;
			bool start = false;
			dynamic len = null;
			bool step_size = false;
			bool i = false;
			dynamic ascii = null;
			if ( desired_format == null ) {
				desired_format = 3;
			}
			if ( include_crunch == null ) {
				include_crunch = 0;
			}
			crunch = include_crunch != 0 ? "#" : "";
			if ( !( color is string ) ) {
				color = "";
			}
			start = ( Misc13.conv_text2ascii( color, 1 ) == 35 ) + 1;
			len = color.Length;
			step_size = ( len + 1 - start != desired_format ) + 1;
			_default = "";
			i = null;
			i = start;
			while (i <= len) {
				ascii = Misc13.conv_text2ascii( color, i );
				dynamic _ = ascii; // Was a switch-case, sorry for the mess.
				if ( 48<=_&&_<=57 ) {
					_default += Misc13.conv_ascii2text( ascii );
				} else if ( 97<=_&&_<=102 ) {
					_default += Misc13.conv_ascii2text( ascii );
				} else if ( 65<=_&&_<=70 ) {
					_default += Misc13.conv_ascii2text( ascii + 32 );
				} else {
					break;
				};
				i += step_size;
			}
			if ( _default.Length != desired_format ) {
				if ( Misc13.isValid( __default ) ) {
					return __default;
				}
				return crunch + GlobalFuncs.repeat_string( desired_format, "0" );
			}
			return crunch + _default;
			return _default;
		}

		public static dynamic sanitize_inlist( dynamic value = null, dynamic List = null, dynamic __default = null ) {
			if ( Misc13.isValid( List.HasValue( value ) ) ) {
				return value;
			}
			if ( Misc13.isValid( __default ) ) {
				return __default;
			}
			if ( Misc13.isValid( List ) && Misc13.isValid( List.len ) ) {
				return Rand.pick( List );
			}
		}

		public static int sanitize_integer( dynamic number = null, int min = 0, int max = 0, int __default = 0 ) {
			if ( min == null ) {
				min = 0;
			}
			if ( max == null ) {
				max = 1;
			}
			if ( __default == null ) {
				__default = 0;
			}
			if ( Misc13.isValid( Misc13.isNumber( number ) ) ) {
				number = Misc13.round( number );
				if ( min <= number && number <= max ) {
					return number;
				}
			}
			return __default;
		}

		public static string sanitize_ooccolor( dynamic color = null ) {
			ByTable HSL = null;
			dynamic RGB = null;
			HSL = GlobalFuncs.rgb2hsl( GlobalFuncs.hex2num( Misc13.str_sub( color, 2, 4 ) ), GlobalFuncs.hex2num( Misc13.str_sub( color, 4, 6 ) ), GlobalFuncs.hex2num( Misc13.str_sub( color, 6, 8 ) ) );
			HSL[3] = Misc13.min( HSL[3], 0.4000000059604645 );
			RGB = GlobalFuncs.get_dist_euclidian.BTCall( HSL );
			return "#" + GlobalFuncs.num2hex( RGB[1], 2 ) + GlobalFuncs.num2hex( RGB[2], 2 ) + GlobalFuncs.num2hex( RGB[3], 2 );
		}

		public static dynamic sanitize_simple( dynamic t = null, ByTable repl_chars = null ) {
			dynamic _char = null;
			dynamic index = null;
			if ( repl_chars == null ) {
				repl_chars = new ByTable().set( "	", "#" ).set( "\n", "#" );
			}
			_char = null;
			foreach (dynamic _ in repl_chars ) {
				_char = _;
				index = Misc13.str_find( t, _char, 1, null );
				while (index) {
					t = Misc13.str_sub( t, 1, index ) + repl_chars[_char] + Misc13.str_sub( t, index + 1, null );
					index = Misc13.str_find( t, _char, index + 1, null );
				}
			};
			return t;
		}

		public static string sanitize_text( dynamic text = null, string __default = null ) {
			if ( __default == null ) {
				__default = "";
			}
			if ( text is string ) {
				return text;
			}
			return __default;
		}

		public static dynamic sanitizeSQL( dynamic t = null ) {
			dynamic sqltext = null;
			sqltext = GlobalVars.dbcon.Quote( t );
			return Misc13.str_sub( sqltext, 2, sqltext.Length );
		}

		public static int scramble_dna( dynamic M = null, int ui = 0, int se = 0, dynamic probability = null ) {
			int i = 0;
			if ( ui == null ) {
				ui = GlobalVars.FALSE;
			}
			if ( se == null ) {
				se = GlobalVars.FALSE;
			}
			if ( !Misc13.isValid( M.has_dna() ) ) {
				return 0;
			}
			if ( se != 0 ) {
				i = null;
				i = 1;
				while (i <= 20) {
					if ( Misc13.isValid( Rand.chance( probability ) ) ) {
						M.dna.struc_enzymes = GlobalFuncs.setblock( M.dna.struc_enzymes, i, GlobalFuncs.random_string( 3, GlobalVars.hex_characters ) );
					}
					i++;
				}
				M.domutcheck();
			}
			if ( ui != 0 ) {
				i = null;
				i = 1;
				while (i <= 7) {
					if ( Misc13.isValid( Rand.chance( probability ) ) ) {
						M.dna.uni_identity = GlobalFuncs.setblock( M.dna.uni_identity, i, GlobalFuncs.random_string( 3, GlobalVars.hex_characters ) );
					}
					i++;
				}
				M.updateappearance.BTCall( new ByTable().set( "mutations_overlay_update", 1 ) );
			}
			return 1;
		}

		public static dynamic screen_loc2turf( dynamic scr_loc = null, dynamic origin = null ) {
			dynamic tX = null;
			dynamic tY = null;
			dynamic tZ = null;
			tX = GlobalFuncs.text2list( scr_loc, "," );
			tY = GlobalFuncs.text2list( tX[2], ":" );
			tZ = origin.z;
			tY = tY[1];
			tX = GlobalFuncs.text2list( tX[1], ":" );
			tX = tX[1];
			tX = Misc13.max( 1, Misc13.min( Game.maxx, origin.x + ( Misc13.parseNumber( tX ) - ( Game.view + 1 ) ) ) );
			tY = Misc13.max( 1, Misc13.min( Game.maxy, origin.y + ( Misc13.parseNumber( tY ) - ( Game.view + 1 ) ) ) );
			return Misc13.locate3( tX, tY, tZ );
		}

		public static dynamic SDQL_expression( dynamic _object = null, dynamic expression = null, int start = 0 ) {
			dynamic result = null;
			dynamic val = null;
			dynamic i = null;
			dynamic op = null;
			ByTable ret = null;
			if ( start == null ) {
				start = 1;
			}
			result = 0;
			i = null;
			i = start;
			while (i <= expression.len) {
				op = "";
				if ( i > start ) {
					op = expression[i];
					i++;
				}
				ret = GlobalFuncs.SDQL_value( _object, expression, i );
				val = ret["val"];
				i = ret["i"];
				if ( op != "" ) {
					dynamic _ = op; // Was a switch-case, sorry for the mess.
					if ( _=="+" ) {
						result += val;
					} else if ( _=="-" ) {
						result -= val;
					} else if ( _=="*" ) {
						result *= val;
					} else if ( _=="/" ) {
						result /= val;
					} else if ( _=="&" ) {
						result &= val;
					} else if ( _=="|" ) {
						result |= val;
					} else if ( _=="^" ) {
						result ^= val;
					} else if ( _=="=" || _=="==" ) {
						result = result == val;
					} else if ( _=="!=" || _=="<>" ) {
						result = result != val;
					} else if ( _=="<" ) {
						result = result < val;
					} else if ( _=="<=" ) {
						result = result <= val;
					} else if ( _==">" ) {
						result = result > val;
					} else if ( _==">=" ) {
						result = result >= val;
					} else if ( _=="and" || _=="&&" ) {
						result = Misc13.isValid( result ) && Misc13.isValid( val );
					} else if ( _=="or" || _=="||" ) {
						result = Misc13.isValid( result ) || Misc13.isValid( val );
					} else {
						Misc13.thread_user.write( "<span class='danger'>SDQL2: Unknown op " + op + "</span>" );
						result = null;
					};
				} else {
					result = val;
				}
				i++;
			}
			return result;
		}

		public static ByTable SDQL_from_objs( dynamic tree = null ) {
			ByTable _out = null;
			dynamic type = null;
			dynamic _char = null;
			if ( Misc13.isValid( tree.HasValue( "world" ) ) ) {
				return new ByTable(new object [] {Game});
			}
			_out = new ByTable();
			type = null;
			foreach (dynamic _ in tree ) {
				type = _;
				_char = Misc13.str_sub( type, 1, 2 );
				if ( _char == "/" ) {
					_out += GlobalFuncs.SDQL_get_all( type, Game );
				} else if ( _char == "'" || _char == "\"" ) {
					_out += Misc13.locate1( Misc13.str_sub( type, 2, type.Length ) );
				}
			};
			return _out;
		}

		public static ByTable SDQL_get_all( dynamic type = null, dynamic location = null ) {
			ByTable _out = null;
			dynamic d = null;
			_out = new ByTable();
			if ( type == "*" ) {
				d = null;
				foreach (dynamic _ in location ) {
					d = _;
					if ( !( d is Base13 ) ) {
						continue;
					}
					_out += d;
				};
				return _out;
			}
			type = Misc13.findType( type );
			if ( Misc13.isValid( type isxx typeof(Mob) ) ) {
				d = null;
				foreach (dynamic _ in location ) {
					d = _;
					if ( Misc13.isValid( type.IsInstanceOfType( d ) ) ) {
						_out += d;
					}
				};
			} else if ( Misc13.isValid( type isxx typeof(Tile) ) ) {
				d = null;
				foreach (dynamic _ in location ) {
					d = _;
					if ( Misc13.isValid( type.IsInstanceOfType( d ) ) ) {
						_out += d;
					}
				};
			} else if ( Misc13.isValid( type isxx typeof(Entity) ) ) {
				d = null;
				foreach (dynamic _ in location ) {
					d = _;
					if ( !( d is Entity ) ) {
						continue;
					}
					if ( Misc13.isValid( type.IsInstanceOfType( d ) ) ) {
						_out += d;
					}
				};
			} else if ( Misc13.isValid( type isxx new ByArea(3137) ) ) {
				d = null;
				foreach (dynamic _ in location ) {
					d = _;
					if ( Misc13.isValid( type.IsInstanceOfType( d ) ) ) {
						_out += d;
					}
				};
			} else if ( Misc13.isValid( type isxx typeof(BaseStatic) ) ) {
				d = null;
				foreach (dynamic _ in location ) {
					d = _;
					if ( !( d is BaseStatic ) ) {
						continue;
					}
					if ( Misc13.isValid( type.IsInstanceOfType( d ) ) ) {
						_out += d;
					}
				};
			} else {
				d = null;
				foreach (dynamic _ in location ) {
					d = _;
					if ( !( d is Base13 ) ) {
						continue;
					}
					if ( Misc13.isValid( type.IsInstanceOfType( d ) ) ) {
						_out += d;
					}
				};
			}
			return _out;
		}

		public static ByTable SDQL_parse( dynamic query_list = null ) {
			SDQLParser parser = null;
			ByTable querys = null;
			ByTable query_tree = null;
			int pos = 0;
			int querys_pos = 0;
			int do_parse = 0;
			dynamic val = null;
			ByTable parsed_tree = null;
			parser = new SDQLParser();
			querys = new ByTable();
			query_tree = new ByTable();
			pos = 1;
			querys_pos = 1;
			do_parse = 0;
			val = null;
			foreach (dynamic _ in query_list ) {
				val = _;
				if ( val == ";" ) {
					do_parse = 1;
				} else if ( pos >= query_list.len ) {
					query_tree += val;
					do_parse = 1;
				}
				if ( do_parse != 0 ) {
					parser.query = query_tree;
					parsed_tree = null;
					parsed_tree = parser.parse();
					if ( parsed_tree.len > 0 ) {
						querys.len = querys_pos;
						querys[querys_pos] = parsed_tree;
						querys_pos++;
					} else {
						Misc13.thread_user.write( new Txt( "<span class='danger'>Parsing error on " ).st_nd_rd( querys_pos ).str( " query. Nothing was executed.</span>" ) );
						return new ByTable();
					}
					query_tree = new ByTable();
					do_parse = 0;
				} else {
					query_tree += val;
				}
				pos++;
			};
			GlobalFuncs.qdel( parser );
			return querys;
		}

		public static void SDQL_testout( dynamic query_tree = null, int indent = 0 ) {
			string spaces = null;
			int s = 0;
			dynamic item = null;
			if ( indent == null ) {
				indent = 0;
			}
			spaces = "";
			s = null;
			s = 0;
			while (s < indent) {
				spaces += "    ";
				s++;
			}
			item = null;
			foreach (dynamic _ in query_tree ) {
				item = _;
				if ( Misc13.isValid( ByTable.IsInstanceOfType( item ) ) ) {
					Misc13.thread_user.write( "" + spaces + "(" );
					GlobalFuncs.SDQL_testout( item, indent + 1 );
					Misc13.thread_user.write( "" + spaces + ")" );
				} else {
					Misc13.thread_user.write( "" + spaces + item );
				}
				if ( !Misc13.isValid( Misc13.isNumber( item ) ) && Misc13.isValid( query_tree[item] ) ) {
					if ( Misc13.isValid( ByTable.IsInstanceOfType( query_tree[item] ) ) ) {
						Misc13.thread_user.write( "" + spaces + "    (" );
						GlobalFuncs.SDQL_testout( query_tree[item], indent + 2 );
						Misc13.thread_user.write( "" + spaces + "    )" );
					} else {
						Misc13.thread_user.write( "" + spaces + "    " + query_tree[item] );
					}
				}
			};
		}

		public static ByTable SDQL_value( dynamic _object = null, dynamic expression = null, int start = 0 ) {
			dynamic i = null;
			dynamic val = null;
			ByTable ret = null;
			if ( start == null ) {
				start = 1;
			}
			i = start;
			val = null;
			if ( i > expression.len ) {
				return new ByTable().set( "i", i ).set( "val", null );
			}
			if ( Misc13.isValid( ByTable.IsInstanceOfType( expression[i] ) ) ) {
				val = GlobalFuncs.SDQL_expression( _object, expression[i] );
			} else if ( expression[i] == "!" ) {
				ret = GlobalFuncs.SDQL_value( _object, expression, i + 1 );
				val = !Misc13.isValid( ret["val"] );
				i = ret["i"];
			} else if ( expression[i] == "~" ) {
				ret = GlobalFuncs.SDQL_value( _object, expression, i + 1 );
				val = ~ret["val"];
				i = ret["i"];
			} else if ( expression[i] == "-" ) {
				ret = GlobalFuncs.SDQL_value( _object, expression, i + 1 );
				val = -ret["val"];
				i = ret["i"];
			} else if ( expression[i] == "null" ) {
				val = null;
			} else if ( Misc13.isValid( Misc13.isNumber( expression[i] ) ) ) {
				val = expression[i];
			} else if ( Misc13.isValid( new ByTable(new object [] {"'","\""}).HasValue( Misc13.str_sub( expression[i], 1, 2 ) ) ) ) {
				val = Misc13.str_sub( expression[i], 2, expression[i].Length );
			} else {
				val = GlobalFuncs.SDQL_var( _object, expression, i );
				i = expression.len;
			}
			return new ByTable().set( "i", i ).set( "val", val );
		}

		public static dynamic SDQL_var( dynamic _object = null, dynamic expression = null, int start = 0 ) {
			if ( start == null ) {
				start = 1;
			}
			if ( Misc13.isValid( _object.vars.HasValue( expression[start] ) ) ) {
				if ( start < expression.len && expression[start + 1] == "." ) {
					return GlobalFuncs.SDQL_var( _object.vars[expression[start]], expression[start + 2] );
				} else {
					return _object.vars[expression[start]];
				}
			} else {
				return null;
			}
		}

		public static ByTable SDQL2_tokenize( dynamic query_text = null ) {
			ByTable whitespace = null;
			ByTable single = null;
			ByTable multi = null;
			string word = null;
			ByTable query_list = null;
			dynamic len = null;
			int i = 0;
			dynamic _char = null;
			dynamic char2 = null;
			whitespace = new ByTable(new object [] {" ","\n","	"});
			single = new ByTable(new object [] {"(",")",",","+","-",".",";"});
			multi = new ByTable()
				.set( "!", new ByTable(new object [] {"","="}) )
				.set( ">", new ByTable(new object [] {"","="}) )
				.set( "<", new ByTable(new object [] {"","=",">"}) )
				.set( "=", new ByTable(new object [] {"","="}) )
				
			;
			word = "";
			query_list = new ByTable();
			len = query_text.Length;
			i = null;
			i = 1;
			while (i <= len) {
				_char = Misc13.str_sub( query_text, i, i + 1 );
				if ( Misc13.isValid( whitespace.HasValue( _char ) ) ) {
					if ( word != "" ) {
						query_list += word;
						word = "";
					}
				} else if ( Misc13.isValid( single.HasValue( _char ) ) ) {
					if ( word != "" ) {
						query_list += word;
						word = "";
					}
					query_list += _char;
				} else if ( Misc13.isValid( multi.HasValue( _char ) ) ) {
					if ( word != "" ) {
						query_list += word;
						word = "";
					}
					char2 = Misc13.str_sub( query_text, i + 1, i + 2 );
					if ( Misc13.isValid( multi[_char].HasValue( char2 ) ) ) {
						query_list += "" + _char + char2;
						i++;
					} else {
						query_list += _char;
					}
				} else if ( _char == "'" ) {
					if ( word != "" ) {
						Misc13.thread_user.write( new Txt().red().str( "SDQL2: You have an error in your SDQL syntax, unexpected ' in query: \"<font color=gray>" ).item( query_text ).str( "</font>\" following \"<font color=gray>" ).item( word ).str( "</font>\". Please check your syntax, and try again." ) );
						return null;
					}
					word = "'";
					i++;
					while (i <= len) {
						_char = Misc13.str_sub( query_text, i, i + 1 );
						if ( _char == "'" ) {
							if ( Misc13.str_sub( query_text, i + 1, i + 2 ) == "'" ) {
								word += "'";
								i++;
							} else {
								break;
							}
						} else {
							word += _char;
						}
						i++;
					}
					if ( i > len ) {
						Misc13.thread_user.write( new Txt().red().str( "SDQL2: You have an error in your SDQL syntax, unmatched ' in query: \"<font color=gray>" ).item( query_text ).str( "</font>\". Please check your syntax, and try again." ) );
						return null;
					}
					query_list += "" + word + "'";
					word = "";
				} else if ( _char == "\"" ) {
					if ( word != "" ) {
						Misc13.thread_user.write( new Txt().red().str( "SDQL2: You have an error in your SDQL syntax, unexpected \" in query: \"<font color=gray>" ).item( query_text ).str( "</font>\" following \"<font color=gray>" ).item( word ).str( "</font>\". Please check your syntax, and try again." ) );
						return null;
					}
					word = "\"";
					i++;
					while (i <= len) {
						_char = Misc13.str_sub( query_text, i, i + 1 );
						if ( _char == "\"" ) {
							if ( Misc13.str_sub( query_text, i + 1, i + 2 ) == "'" ) {
								word += "\"";
								i++;
							} else {
								break;
							}
						} else {
							word += _char;
						}
						i++;
					}
					if ( i > len ) {
						Misc13.thread_user.write( new Txt().red().str( "SDQL2: You have an error in your SDQL syntax, unmatched \" in query: \"<font color=gray>" ).item( query_text ).str( "</font>\". Please check your syntax, and try again." ) );
						return null;
					}
					query_list += "" + word + "\"";
					word = "";
				} else {
					word += _char;
				}
				i++;
			}
			if ( word != "" ) {
				query_list += word;
			}
			return query_list;
		}

		public static int seclevel2num( dynamic seclevel = null ) {
			dynamic _ = Misc13.str_lower( seclevel ); // Was a switch-case, sorry for the mess.
			if ( _=="green" ) {
				return 0;
			} else if ( _=="blue" ) {
				return 1;
			} else if ( _=="red" ) {
				return 2;
			} else if ( _=="delta" ) {
				return 3;
			};
		}

		public static int seedify( dynamic O = null, dynamic t_max = null, dynamic extractor = null ) {
			int t_amount = 0;
			dynamic F = null;
			dynamic t_prod = null;
			t_amount = 0;
			if ( t_max == -1 ) {
				if ( Misc13.isValid( extractor ) ) {
					t_max = Rand.Int( 1, 4 ) * extractor.seed_multiplier;
				} else {
					t_max = Rand.Int( 1, 4 );
				}
			}
			if ( O is Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown ) {
				F = O;
				while (t_amount < t_max) {
					t_prod = F.seed( O.loc, O );
					t_prod.lifespan = F.lifespan;
					t_prod.endurance = F.endurance;
					t_prod.maturation = F.maturation;
					t_prod.production = F.production;
					t_prod.yield = F.yield;
					t_prod.potency = F.potency;
					t_amount++;
				}
				GlobalFuncs.qdel( O );
				return 1;
			} else if ( O is Ent_Item_Weapon_Grown ) {
				F = O;
				if ( Misc13.isValid( F.seed ) ) {
					while (t_amount < t_max) {
						t_prod = F.seed( O.loc, O );
						t_prod.lifespan = F.lifespan;
						t_prod.endurance = F.endurance;
						t_prod.maturation = F.maturation;
						t_prod.production = F.production;
						t_prod.yield = F.yield;
						t_prod.potency = F.potency;
						t_amount++;
					}
					GlobalFuncs.qdel( O );
					return 1;
				} else {
					return 0;
				}
			} else {
				return 0;
			}
		}

		public static dynamic select_active_ai( dynamic user = null ) {
			dynamic _default = null;
			ByTable ais = null;
			ais = GlobalFuncs.active_ais();
			if ( Misc13.isValid( ais.len ) ) {
				if ( Misc13.isValid( user ) ) {
					_default = Misc13.input( user, "AI signals detected:", "AI Selection", ais[1], ais, 0 );
				} else {
					_default = Rand.pick( ais );
				}
			}
			return _default;
			return _default;
		}

		public static dynamic select_active_ai_with_fewest_borgs(  ) {
			dynamic selected = null;
			ByTable active = null;
			dynamic A = null;
			active = GlobalFuncs.active_ais();
			A = null;
			foreach (dynamic _ in active ) {
				A = _;
				if ( !( A is Mob_Living_Silicon_Ai ) ) {
					continue;
				}
				if ( !Misc13.isValid( selected ) || selected.connected_robots.len > A.connected_robots.len ) {
					selected = A;
				}
			};
			return selected;
		}

		public static dynamic select_active_free_borg( dynamic user = null ) {
			dynamic _default = null;
			ByTable borgs = null;
			borgs = GlobalFuncs.active_free_borgs();
			if ( Misc13.isValid( borgs.len ) ) {
				if ( Misc13.isValid( user ) ) {
					_default = Misc13.input( user, "Unshackled cyborg signals detected:", "Cyborg Selection", borgs[1], borgs, 0 );
				} else {
					_default = Rand.pick( borgs );
				}
			}
			return _default;
			return _default;
		}

		public static void send_byjax( dynamic receiver = null, dynamic control_id = null, dynamic target_element = null, dynamic new_content = null, dynamic callback = null, dynamic callback_args = null ) {
			ByTable argums = null;
			if ( new_content == null ) {
				new_content = null;
			}
			if ( callback == null ) {
				callback = null;
			}
			if ( callback_args == null ) {
				callback_args = null;
			}
			if ( Misc13.isValid( receiver ) && Misc13.isValid( target_element ) && Misc13.isValid( control_id ) ) {
				argums = new ByTable(new object [] {target_element,new_content});
				if ( Misc13.isValid( callback ) ) {
					argums += callback;
					if ( Misc13.isValid( callback_args ) ) {
						argums += callback_args;
					}
				}
				argums = Misc13.conv_list2params( argums );
				Misc13.output( receiver, argums, "" + control_id + ":replaceContent" );
			}
			return;
		}

		public static void send2irc( dynamic msg = null, dynamic msg2 = null ) {
			if ( Misc13.isValid( GlobalVars.config.useircbot ) ) {
				Misc13.shell( "python nudge.py " + msg + " " + msg2 );
			}
			return;
		}

		public static int send2irc_adminless_only( dynamic source = null, dynamic msg = null, int requiredflags = 0 ) {
			int admin_number_total = 0;
			int admin_number_afk = 0;
			int admin_number_ignored = 0;
			int admin_number_decrease = 0;
			dynamic X = null;
			int invalid = 0;
			int admin_number_present = 0;
			if ( requiredflags == null ) {
				requiredflags = 4;
			}
			admin_number_total = 0;
			admin_number_afk = 0;
			admin_number_ignored = 0;
			admin_number_decrease = 0;
			X = null;
			foreach (dynamic _ in GlobalVars.admins ) {
				X = _;
				if ( !Misc13.isValid( BAD_GOOFY_EXPANSION???.IsInstanceOfType( X ) ) ) {
					continue;
				}
				admin_number_total++;
				invalid = 0;
				if ( requiredflags != 0 && ( GlobalFuncs.check_rights_for( X, requiredflags ) == 0 ) ) {
					admin_number_ignored++;
					invalid = 1;
				}
				if ( Misc13.isValid( X.is_afk() ) ) {
					admin_number_afk++;
					invalid = 1;
				}
				if ( Misc13.isValid( X.holder.fakekey ) ) {
					admin_number_ignored++;
					invalid = 1;
				}
				if ( invalid != 0 ) {
					admin_number_decrease++;
				}
			};
			admin_number_present = admin_number_total - admin_number_decrease;
			if ( admin_number_present <= 0 ) {
				if ( ( admin_number_afk == 0 ) && ( admin_number_ignored == 0 ) ) {
					GlobalFuncs.send2irc( source, "" + msg + " - No admins online" );
				} else {
					GlobalFuncs.send2irc( source, "" + msg + " - All admins AFK (" + admin_number_afk + "/" + admin_number_total + ") or skipped (" + admin_number_ignored + "/" + admin_number_total + ")" );
				}
			}
			return admin_number_present;
		}

		public static void set_security_level( int level = 0 ) {
			dynamic FA = null;
			dynamic pod = null;
			dynamic _ = level; // Was a switch-case, sorry for the mess.
			if ( _=="green" ) {
				level = 0;
			} else if ( _=="blue" ) {
				level = 1;
			} else if ( _=="red" ) {
				level = 2;
			} else if ( _=="delta" ) {
				level = 3;
			};
			if ( level >= 0 && level <= 3 && level != GlobalVars.security_level ) {
				dynamic _ = level; // Was a switch-case, sorry for the mess.
				if ( _==0 ) {
					GlobalFuncs.minor_announce( GlobalVars.config.alert_desc_green, "Attention! Security level lowered to green:" );
					GlobalVars.security_level = 0;
					FA = null;
					foreach (dynamic _ in GlobalVars.machines ) {
						FA = _;
						if ( !( FA is Ent_Machinery_Firealarm ) ) {
							continue;
						}
						if ( FA.z == 1 ) {
							FA.update_icon();
						}
					};
				} else if ( _==1 ) {
					if ( GlobalVars.security_level < 1 ) {
						GlobalFuncs.minor_announce( GlobalVars.config.alert_desc_blue_upto, "Attention! Security level elevated to blue:", 1 );
					} else {
						GlobalFuncs.minor_announce( GlobalVars.config.alert_desc_blue_downto, "Attention! Security level lowered to blue:" );
					}
					GlobalVars.security_level = 1;
					FA = null;
					foreach (dynamic _ in GlobalVars.machines ) {
						FA = _;
						if ( !( FA is Ent_Machinery_Firealarm ) ) {
							continue;
						}
						if ( FA.z == 1 ) {
							FA.update_icon();
						}
					};
				} else if ( _==2 ) {
					if ( GlobalVars.security_level < 2 ) {
						GlobalFuncs.minor_announce( GlobalVars.config.alert_desc_red_upto, "Attention! Code red!", 1 );
					} else {
						GlobalFuncs.minor_announce( GlobalVars.config.alert_desc_red_downto, "Attention! Code red!" );
					}
					GlobalVars.security_level = 2;
					FA = null;
					foreach (dynamic _ in GlobalVars.machines ) {
						FA = _;
						if ( !( FA is Ent_Machinery_Firealarm ) ) {
							continue;
						}
						if ( FA.z == 1 ) {
							FA.update_icon();
						}
					};
					pod = null;
					foreach (dynamic _ in GlobalVars.machines ) {
						pod = _;
						if ( !( pod is Ent_Machinery_Computer_Shuttle_Pod ) ) {
							continue;
						}
						pod.admin_controlled = 0;
					};
				} else if ( _==3 ) {
					GlobalFuncs.minor_announce( GlobalVars.config.alert_desc_delta, "Attention! Delta security level reached!", 1 );
					GlobalVars.security_level = 3;
					FA = null;
					foreach (dynamic _ in GlobalVars.machines ) {
						FA = _;
						if ( !( FA is Ent_Machinery_Firealarm ) ) {
							continue;
						}
						if ( FA.z == 1 ) {
							FA.update_icon();
						}
					};
					pod = null;
					foreach (dynamic _ in GlobalVars.machines ) {
						pod = _;
						if ( !( pod is Ent_Machinery_Computer_Shuttle_Pod ) ) {
							continue;
						}
						pod.admin_controlled = 0;
					};
				};
			} else {
				return;
			}
		}

		public static int setblock( dynamic istring = null, dynamic blocknumber = null, dynamic replacement = null, int blocksize = 0 ) {
			if ( blocksize == null ) {
				blocksize = 3;
			}
			if ( !Misc13.isValid( istring ) || !Misc13.isValid( blocknumber ) || !Misc13.isValid( replacement ) || ( blocksize == 0 ) ) {
				return 0;
			}
			return GlobalFuncs.getleftblocks( istring, blocknumber, blocksize ) + replacement + GlobalFuncs.getrightblocks( istring, blocknumber, blocksize );
		}

		public static int setup_database_connection(  ) {
			int _default = null;
			string user = null;
			string pass = null;
			string db = null;
			string address = null;
			string port = null;
			if ( GlobalVars.failed_db_connections >= 5 ) {
				return 0;
			}
			if ( GlobalVars.dbcon == null ) {
				GlobalVars.dbcon = new DBConnection();
			}
			user = GlobalVars.sqlfdbklogin;
			pass = GlobalVars.sqlfdbkpass;
			db = GlobalVars.sqlfdbkdb;
			address = GlobalVars.sqladdress;
			port = GlobalVars.sqlport;
			GlobalVars.dbcon.Connect( "dbi:mysql:" + db + ":" + address + ":" + port, "" + user, "" + pass );
			_default = GlobalVars.dbcon.IsConnected();
			if ( _default != 0 ) {
				GlobalVars.failed_db_connections = 0;
			} else {
				GlobalVars.failed_db_connections++;
				if ( Misc13.isValid( GlobalVars.config.sql_enabled ) ) {
					Game.log.write( "SQL error: " + GlobalVars.dbcon.ErrorMsg() );
				}
			}
			return _default;
			return _default;
		}

		public static void setup_map_transitions(  ) {
			ByTable SLS = null;
			dynamic D = null;
			dynamic conf_set_len = null;
			int k = 0;
			dynamic A = null;
			ByTable point_grid = null;
			ByTable grid = null;
			dynamic P = null;
			int i = 0;
			int j = 0;
			dynamic pnt = null;
			ByTable possible_points = null;
			ByTable used_points = null;
			dynamic S = null;
			SLS = new ByTable();
			conf_set_len = GlobalVars.map_transition_config.len;
			k = 1;
			A = null;
			foreach (dynamic _ in GlobalVars.map_transition_config ) {
				A = _;
				D = new SpaceLevel( GlobalVars.map_transition_config[A] );
				D.name = A;
				D.z_value = k;
				if ( D.linked < 2 ) {
					GlobalVars.z_levels_list["" + D.z_value] = D;
				} else {
					SLS.Add( D );
				}
				k++;
			};
			point_grid = null;
			point_grid = new ByTable( conf_set_len * 2 + 1, conf_set_len * 2 + 1 );
			grid = new ByTable();
			P = null;
			i = null;
			i = 1;
			while (i <= conf_set_len * 2 + 1) {
				j = null;
				j = 1;
				while (j <= conf_set_len * 2 + 1) {
					P = new Point( i, j, point_grid );
					point_grid[i][j] = P;
					grid.Add( P );
					j++;
				}
				i++;
			}
			pnt = null;
			foreach (dynamic _ in grid ) {
				pnt = _;
				if ( !( pnt is Point ) ) {
					continue;
				}
				pnt.set_neigbours( point_grid );
			};
			P = point_grid[conf_set_len + 1][conf_set_len + 1];
			possible_points = new ByTable();
			used_points = new ByTable();
			grid.Cut();
			while (SLS.len) {
				D = Rand.pick( SLS );
				SLS.Remove( D );
				D.xi = P.x;
				D.yi = P.y;
				P.spl = D;
				possible_points |= P.neigbours;
				used_points |= P;
				possible_points.Remove( used_points );
				D.set_neigbours( used_points );
				P = Rand.pick( possible_points );
				grid["" + D.z_value] = D;
			}
			A = null;
			foreach (dynamic _ in GlobalVars.z_levels_list ) {
				A = _;
				grid[A] = GlobalVars.z_levels_list[A];
			};
			S = null;
			foreach (dynamic _ in Game ) {
				S = _;
				if ( !( S is Tile_Space ) ) {
					continue;
				}
				if ( S.x <= 7 ) {
					D = grid["" + S.z];
					if ( !Misc13.isValid( D ) ) {
						Misc13.crash( "" + S.z + " position has no space level datum" );
					}
					if ( !Misc13.isValid( D.neigbours.len ) ) {
						continue;
					}
					if ( Misc13.isValid( D.neigbours["8"] ) && D.neigbours["8"] != D ) {
						D = D.neigbours["8"];
						S.destination_z = D.z_value;
					} else {
						while (Misc13.isValid( D.neigbours["4"] ) && D.neigbours["4"] != D) {
							D = D.neigbours["4"];
						}
						S.destination_z = D.z_value;
					}
					S.destination_x = Game.maxx - 7 - 2;
					S.destination_y = S.y;
				}
				if ( S.x >= Game.maxx - 7 - 1 ) {
					D = grid["" + S.z];
					if ( !Misc13.isValid( D ) ) {
						Misc13.crash( "" + S.z + " position has no space level datum" );
					}
					if ( !Misc13.isValid( D.neigbours.len ) ) {
						continue;
					}
					if ( Misc13.isValid( D.neigbours["4"] ) && D.neigbours["4"] != D ) {
						D = D.neigbours["4"];
						S.destination_z = D.z_value;
					} else {
						while (Misc13.isValid( D.neigbours["8"] ) && D.neigbours["8"] != D) {
							D = D.neigbours["8"];
						}
						S.destination_z = D.z_value;
					}
					S.destination_x = 9;
					S.destination_y = S.y;
				}
				if ( S.y <= 7 ) {
					D = grid["" + S.z];
					if ( !Misc13.isValid( D ) ) {
						Misc13.crash( "" + S.z + " position has no space level datum" );
					}
					if ( !Misc13.isValid( D.neigbours.len ) ) {
						continue;
					}
					if ( Misc13.isValid( D.neigbours["2"] ) && D.neigbours["2"] != D ) {
						D = D.neigbours["2"];
						S.destination_z = D.z_value;
					} else {
						while (Misc13.isValid( D.neigbours["1"] ) && D.neigbours["1"] != D) {
							D = D.neigbours["1"];
						}
						S.destination_z = D.z_value;
					}
					S.destination_x = S.x;
					S.destination_y = Game.maxy - 7 - 2;
				}
				if ( S.y >= Game.maxy - 7 - 1 ) {
					D = grid["" + S.z];
					if ( !Misc13.isValid( D ) ) {
						Misc13.crash( "" + S.z + " position has no space level datum" );
					}
					if ( !Misc13.isValid( D.neigbours.len ) ) {
						continue;
					}
					if ( Misc13.isValid( D.neigbours["1"] ) && D.neigbours["1"] != D ) {
						D = D.neigbours["1"];
						S.destination_z = D.z_value;
					} else {
						while (Misc13.isValid( D.neigbours["2"] ) && D.neigbours["2"] != D) {
							D = D.neigbours["2"];
						}
						S.destination_z = D.z_value;
					}
					S.destination_x = S.x;
					S.destination_y = 9;
				}
			};
			A = null;
			foreach (dynamic _ in grid ) {
				A = _;
				GlobalVars.z_levels_list[A] = grid[A];
			};
		}

		public static void SetViruses( dynamic R = null, dynamic data = null ) {
			ByTable preserve = null;
			dynamic A = null;
			if ( Misc13.isValid( data ) ) {
				preserve = new ByTable();
				if ( Misc13.isValid( ByTable.IsInstanceOfType( data ) ) && Misc13.isValid( data["viruses"] ) ) {
					A = null;
					foreach (dynamic _ in data["viruses"] ) {
						A = _;
						if ( !( A is Disease ) ) {
							continue;
						}
						preserve += A.Copy();
					};
					R.data = data.Copy();
				}
				if ( Misc13.isValid( preserve.len ) ) {
					R.data["viruses"] = preserve;
				}
			}
		}

		public static void shake_camera( dynamic M = null, dynamic duration = null, int strength = 0 ) {
			dynamic oldeye = null;
			dynamic x = null;
			if ( strength == null ) {
				strength = 1;
			}
			Thread13.schedule( 0, () => {
				if ( !Misc13.isValid( M ) || !Misc13.isValid( M.client ) || Misc13.isValid( M.shakecamera ) ) {
					return;
				}
				oldeye = M.client.eye;
				M.shakecamera = 1;
				x = 0;
				while (x < duration) {
					if ( Misc13.isValid( M ) && Misc13.isValid( M.client ) ) {
						M.client.eye = Misc13.locate3( GlobalFuncs.dd_range( 1, M.loc.x + Rand.Int( -strength, strength ), Game.maxx ), GlobalFuncs.dd_range( 1, M.loc.y + Rand.Int( -strength, strength ), Game.maxy ), M.loc.z );
						Thread13.sleep( 1 );
					}
					x++;
				}
				if ( Misc13.isValid( M ) ) {
					M.shakecamera = 0;
					if ( Misc13.isValid( M.client ) ) {
						M.client.eye = oldeye;
					}
				}
				return;
			});
		}

		public static void show_note( dynamic target_ckey = null, dynamic index = null, int linkless = 0 ) {
			string output = null;
			string navbar = null;
			string ruler = null;
			dynamic letter = null;
			dynamic target_sql_ckey = null;
			DBQuery query_get_notes = null;
			dynamic err = null;
			dynamic id = null;
			dynamic timestamp = null;
			dynamic notetext = null;
			dynamic adminckey = null;
			dynamic last_editor = null;
			dynamic server = null;
			dynamic index_ckey = null;
			string search = null;
			DBQuery query_list_notes = null;
			if ( linkless == null ) {
				linkless = 0;
			}
			ruler = "<hr style='background:#000000; border:0; height:3px'>";
			navbar = "<a href='?_src_=holder;nonalpha=1'>[All]</a>|<a href='?_src_=holder;nonalpha=2'>[#]</a>";
			letter = null;
			foreach (dynamic _ in GlobalVars.alphabet ) {
				letter = _;
				navbar += "|<a href='?_src_=holder;shownote=" + letter + "'>[" + letter + "]</a>";
			};
			navbar += "<br><form method='GET' name='search' action='?'><input type='hidden' name='_src_' value='holder'><input type='text' name='notessearch' value='" + index + "'><input type='submit' value='Search'></form>";
			if ( linkless == 0 ) {
				output = navbar;
			}
			if ( Misc13.isValid( target_ckey ) ) {
				target_sql_ckey = GlobalFuncs.sanitizeSQL( target_ckey );
				query_get_notes = GlobalVars.dbcon.NewQuery( "SELECT id, timestamp, notetext, adminckey, last_editor, server FROM " + GlobalFuncs.format_table_name( "notes" ) + " WHERE ckey = '" + target_sql_ckey + "' ORDER BY timestamp" );
				if ( !Misc13.isValid( query_get_notes.Execute() ) ) {
					err = query_get_notes.ErrorMsg();
					GlobalFuncs.log_game( "SQL ERROR obtaining ckey, notetext, adminckey, last_editor, server from notes table. Error : [" + err + "]\n" );
					return;
				}
				output += "<h2><center>Notes of " + target_ckey + "</center></h2>";
				if ( linkless == 0 ) {
					output += "<center><a href='?_src_=holder;addnote=" + target_ckey + "'>[Add Note]</a></center>";
				}
				output += ruler;
				while (query_get_notes.NextRow()) {
					id = query_get_notes.item[1];
					timestamp = query_get_notes.item[2];
					notetext = query_get_notes.item[3];
					adminckey = query_get_notes.item[4];
					last_editor = query_get_notes.item[5];
					server = query_get_notes.item[6];
					output += "<b>" + timestamp + " | " + server + " | " + adminckey + "</b>";
					if ( linkless == 0 ) {
						output += " <a href='?_src_=holder;removenote=" + id + "'>[Remove Note]</a> <a href='?_src_=holder;editnote=" + id + "'>[Edit Note]</a>";
						if ( Misc13.isValid( last_editor ) ) {
							output += " <font size='2'>Last edit by " + last_editor + " <a href='?_src_=holder;noteedits=" + id + "'>(Click here to see edit log)</a></font>";
						}
					}
					output += "<br>" + notetext + "<hr style='background:#000000; border:0; height:1px'>";
				}
			} else if ( Misc13.isValid( index ) ) {
				index_ckey = null;
				search = null;
				output += "<center><a href='?_src_=holder;addnoteempty=1'>[Add Note]</a></center>";
				output += ruler;
				if ( !Misc13.isValid( Misc13.isNumber( index ) ) ) {
					index = GlobalFuncs.sanitizeSQL( index );
				}
				dynamic _ = index; // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					search = "^.";
				} else if ( _==2 ) {
					search = "^[^[:alpha:]]";
				} else {
					search = "^" + index;
				};
				query_list_notes = GlobalVars.dbcon.NewQuery( "SELECT DISTINCT ckey FROM " + GlobalFuncs.format_table_name( "notes" ) + " WHERE ckey REGEXP '" + search + "' ORDER BY ckey" );
				if ( !Misc13.isValid( query_list_notes.Execute() ) ) {
					err = query_list_notes.ErrorMsg();
					GlobalFuncs.log_game( "SQL ERROR obtaining ckey from notes table. Error : [" + err + "]\n" );
					return;
				}
				while (query_list_notes.NextRow()) {
					index_ckey = query_list_notes.item[1];
					output += "<a href='?_src_=holder;shownoteckey=" + index_ckey + "'>" + index_ckey + "</a><br>";
				}
			} else {
				output += "<center><a href='?_src_=holder;addnoteempty=1'>[Add Note]</a></center>";
				output += ruler;
			}
			Misc13.browse( Misc13.thread_user, output, "window=show_notes;size=900x500" );
		}

		public static dynamic shuffle( dynamic L = null ) {
			int i = 0;
			if ( !Misc13.isValid( L ) ) {
				return null;
			}
			L = L.Copy();
			i = null;
			i = 1;
			while (i < L.len) {
				L.Swap( i, Rand.Int( i, L.len ) );
				i++;
			}
			return L;
		}

		public static dynamic sign( dynamic x = null ) {
			return x != 0 ? x / Math.abs( x ) : 0;
		}

		public static dynamic SimplifyDegrees( dynamic degrees = null ) {
			degrees = degrees % 360;
			if ( degrees < 0 ) {
				degrees += 360;
			}
			return degrees;
		}

		public static string slur( dynamic n = null ) {
			dynamic phrase = null;
			dynamic leng = null;
			dynamic counter = null;
			string newphrase = null;
			string newletter = null;
			phrase = Misc13.html_decode( n );
			leng = phrase.Length;
			counter = phrase.Length;
			newphrase = "";
			newletter = "";
			while (counter >= 1) {
				newletter = Misc13.str_sub( phrase, leng - counter + 1, leng - counter + 2 );
				if ( Rand.Int( 1, 3 ) == 3 ) {
					if ( Misc13.str_lower( newletter ) == "o" ) {
						newletter = "u";
					}
					if ( Misc13.str_lower( newletter ) == "s" ) {
						newletter = "ch";
					}
					if ( Misc13.str_lower( newletter ) == "a" ) {
						newletter = "ah";
					}
					if ( Misc13.str_lower( newletter ) == "u" ) {
						newletter = "oo";
					}
					if ( Misc13.str_lower( newletter ) == "c" ) {
						newletter = "k";
					}
				}
				if ( Rand.Int( 1, 20 ) == 20 ) {
					if ( newletter == " " ) {
						newletter = "...huuuhhh...";
					}
					if ( newletter == "." ) {
						newletter = " *BURP*.";
					}
				}
				dynamic _ = Rand.Int( 1, 20 ); // Was a switch-case, sorry for the mess.
				if ( _==1 ) {
					newletter += "'";
				} else if ( _==10 ) {
					newletter += "" + newletter;
				} else if ( _==20 ) {
					newletter += "" + newletter + newletter;
				};
				newphrase += "" + newletter;
				counter -= 1;
			}
			return newphrase;
		}

		public static void smooth_icon( dynamic A = null ) {
			dynamic adjacencies = null;
			if ( GlobalFuncs.qdeleted( A ) != 0 ) {
				return;
			}
			Thread13.schedule( 0, () => {
				if ( Misc13.isValid( A ) && Misc13.isValid( A.smooth ) ) {
					adjacencies = GlobalFuncs.calculate_adjacencies( A );
					A.clear_smooth_overlays();
					A.top_left_corner = GlobalFuncs.make_nw_corner( adjacencies );
					A.top_right_corner = GlobalFuncs.make_ne_corner( adjacencies );
					A.bottom_left_corner = GlobalFuncs.make_sw_corner( adjacencies );
					A.bottom_right_corner = GlobalFuncs.make_se_corner( adjacencies );
					A.overlays += A.top_left_corner;
					A.overlays += A.top_right_corner;
					A.overlays += A.bottom_right_corner;
					A.overlays += A.bottom_left_corner;
				}
				return;
			});
		}

		public static void smooth_icon_neighbors( dynamic A = null ) {
			dynamic T = null;
			T = null;
			foreach (dynamic _ in Misc13.orange( 1, A ) ) {
				T = _;
				if ( !( T is BaseStatic ) ) {
					continue;
				}
				if ( Misc13.isValid( T.smooth ) ) {
					GlobalFuncs.smooth_icon( T );
				}
			};
		}

		public static dynamic sortInsert( dynamic L = null, dynamic cmp = null, dynamic associative = null, int fromIndex = 0, int toIndex = 0 ) {
			if ( cmp == null ) {
				cmp = typeof(GlobalFuncs).GetMethod( "cmp_numeric_asc" );
			}
			if ( fromIndex == null ) {
				fromIndex = 1;
			}
			if ( toIndex == null ) {
				toIndex = 0;
			}
			if ( Misc13.isValid( L ) && L.len >= 2 ) {
				fromIndex = fromIndex % L.len;
				toIndex = toIndex % ( L.len + 1 );
				if ( fromIndex <= 0 ) {
					fromIndex += L.len;
				}
				if ( toIndex <= 0 ) {
					toIndex += L.len + 1;
				}
				GlobalVars.sortInstance.L = L;
				GlobalVars.sortInstance.cmp = cmp;
				GlobalVars.sortInstance.associative = associative;
				GlobalVars.sortInstance.binarySort( fromIndex, toIndex, fromIndex );
			}
			return L;
		}

		public static dynamic sortKey( dynamic L = null, int order = 0 ) {
			if ( order == null ) {
				order = 1;
			}
			return GlobalFuncs.sortTim( L, order >= 0 ? typeof(GlobalFuncs).GetMethod( "cmp_ckey_asc" ) : typeof(GlobalFuncs).GetMethod( "cmp_ckey_dsc" ) );
		}

		public static dynamic sortList( dynamic L = null, dynamic cmp = null ) {
			if ( cmp == null ) {
				cmp = typeof(GlobalFuncs).GetMethod( "cmp_text_asc" );
			}
			return GlobalFuncs.sortTim( L.Copy(), cmp );
		}

		public static ByTable sortmobs(  ) {
			ByTable moblist = null;
			dynamic sortmob = null;
			dynamic M = null;
			moblist = new ByTable();
			sortmob = GlobalFuncs.sortNames( GlobalVars.mob_list );
			M = null;
			foreach (dynamic _ in sortmob ) {
				M = _;
				if ( !( M is Mob_Living_Silicon_Ai ) ) {
					continue;
				}
				moblist.Add( M );
			};
			M = null;
			foreach (dynamic _ in sortmob ) {
				M = _;
				if ( !( M is Mob_Camera ) ) {
					continue;
				}
				moblist.Add( M );
			};
			M = null;
			foreach (dynamic _ in sortmob ) {
				M = _;
				if ( !( M is Mob_Living_Silicon_Pai ) ) {
					continue;
				}
				moblist.Add( M );
			};
			M = null;
			foreach (dynamic _ in sortmob ) {
				M = _;
				if ( !( M is Mob_Living_Silicon_Robot ) ) {
					continue;
				}
				moblist.Add( M );
			};
			M = null;
			foreach (dynamic _ in sortmob ) {
				M = _;
				if ( !( M is Mob_Living_Carbon_Human ) ) {
					continue;
				}
				moblist.Add( M );
			};
			M = null;
			foreach (dynamic _ in sortmob ) {
				M = _;
				if ( !( M is Mob_Living_Carbon_Brain ) ) {
					continue;
				}
				moblist.Add( M );
			};
			M = null;
			foreach (dynamic _ in sortmob ) {
				M = _;
				if ( !( M is Mob_Living_Carbon_Alien ) ) {
					continue;
				}
				moblist.Add( M );
			};
			M = null;
			foreach (dynamic _ in sortmob ) {
				M = _;
				if ( !( M is Mob_Dead_Observer ) ) {
					continue;
				}
				moblist.Add( M );
			};
			M = null;
			foreach (dynamic _ in sortmob ) {
				M = _;
				if ( !( M is Mob_NewPlayer ) ) {
					continue;
				}
				moblist.Add( M );
			};
			M = null;
			foreach (dynamic _ in sortmob ) {
				M = _;
				if ( !( M is Mob_Living_Carbon_Monkey ) ) {
					continue;
				}
				moblist.Add( M );
			};
			M = null;
			foreach (dynamic _ in sortmob ) {
				M = _;
				if ( !( M is Mob_Living_SimpleAnimal_Slime ) ) {
					continue;
				}
				moblist.Add( M );
			};
			M = null;
			foreach (dynamic _ in sortmob ) {
				M = _;
				if ( !( M is Mob_Living_SimpleAnimal ) ) {
					continue;
				}
				moblist.Add( M );
			};
			return moblist;
		}

		public static dynamic sortNames( dynamic L = null, int order = 0 ) {
			if ( order == null ) {
				order = 1;
			}
			return GlobalFuncs.sortTim( L, order >= 0 ? typeof(GlobalFuncs).GetMethod( "cmp_name_asc" ) : typeof(GlobalFuncs).GetMethod( "cmp_name_dsc" ) );
		}

		public static dynamic sortRecord( dynamic L = null, string field = null, int order = 0 ) {
			if ( field == null ) {
				field = "name";
			}
			if ( order == null ) {
				order = 1;
			}
			GlobalVars.cmp_field = field;
			return GlobalFuncs.sortTim( L, order >= 0 ? typeof(GlobalFuncs).GetMethod( "cmp_records_asc" ) : typeof(GlobalFuncs).GetMethod( "cmp_records_dsc" ) );
		}

		public static dynamic sortTim( dynamic L = null, dynamic cmp = null, dynamic associative = null, int fromIndex = 0, int toIndex = 0 ) {
			if ( cmp == null ) {
				cmp = typeof(GlobalFuncs).GetMethod( "cmp_numeric_asc" );
			}
			if ( fromIndex == null ) {
				fromIndex = 1;
			}
			if ( toIndex == null ) {
				toIndex = 0;
			}
			if ( Misc13.isValid( L ) && L.len >= 2 ) {
				fromIndex = fromIndex % L.len;
				toIndex = toIndex % ( L.len + 1 );
				if ( fromIndex <= 0 ) {
					fromIndex += L.len;
				}
				if ( toIndex <= 0 ) {
					toIndex += L.len + 1;
				}
				GlobalVars.sortInstance.L = L;
				GlobalVars.sortInstance.cmp = cmp;
				GlobalVars.sortInstance.associative = associative;
				GlobalVars.sortInstance.timSort( fromIndex, toIndex );
			}
			return L;
		}

		public static dynamic spaceDebrisFinishLoc( dynamic startSide = null, dynamic Z = null ) {
			int endy = 0;
			int endx = 0;
			dynamic T = null;
			dynamic _ = startSide; // Was a switch-case, sorry for the mess.
			if ( _==1 ) {
				endy = 7;
				endx = Rand.Int( 7, Game.maxx - 7 );
			} else if ( _==2 ) {
				endy = Rand.Int( 7, Game.maxy - 7 );
				endx = 7;
			} else if ( _==3 ) {
				endy = Game.maxy - 7;
				endx = Rand.Int( 7, Game.maxx - 7 );
			} else if ( _==4 ) {
				endy = Rand.Int( 7, Game.maxy - 7 );
				endx = Game.maxx - 7;
			};
			T = Misc13.locate3( endx, endy, Z );
			return T;
		}

		public static dynamic spaceDebrisStartLoc( dynamic startSide = null, dynamic Z = null ) {
			int starty = 0;
			int startx = 0;
			dynamic T = null;
			dynamic _ = startSide; // Was a switch-case, sorry for the mess.
			if ( _==1 ) {
				starty = Game.maxy - 8;
				startx = Rand.Int( 8, Game.maxx - 8 );
			} else if ( _==2 ) {
				starty = Rand.Int( 8, Game.maxy - 8 );
				startx = Game.maxx - 8;
			} else if ( _==3 ) {
				starty = 8;
				startx = Rand.Int( 8, Game.maxx - 8 );
			} else if ( _==4 ) {
				starty = Rand.Int( 8, Game.maxy - 8 );
				startx = 8;
			};
			T = Misc13.locate3( startx, starty, Z );
			return T;
		}

		public static void spawn_meteor( dynamic meteortypes = null ) {
			dynamic pickedstart = null;
			dynamic pickedgoal = null;
			int max_i = 0;
			dynamic startSide = null;
			dynamic Me = null;
			dynamic M = null;
			max_i = 10;
			while (!( pickedstart is Tile_Space )) {
				startSide = Rand.pick( GlobalVars.cardinal );
				pickedstart = GlobalFuncs.spaceDebrisStartLoc( startSide, 1 );
				pickedgoal = GlobalFuncs.spaceDebrisFinishLoc( startSide, 1 );
				max_i--;
				if ( max_i <= 0 ) {
					return;
				}
			}
			Me = GlobalFuncs.pickweight( meteortypes );
			M = Me( pickedstart );
			M.dest = pickedgoal;
			M.z_original = 1;
			Thread13.schedule( 0, () => {
				Misc13.walk_towards( M, M.dest, 1 );
				return;
			});
			return;
		}

		public static void spawn_meteors( int number = 0, dynamic meteortypes = null ) {
			int i = 0;
			if ( number == null ) {
				number = 10;
			}
			i = null;
			i = 0;
			while (i < number) {
				GlobalFuncs.spawn_meteor( meteortypes );
				i++;
			}
		}

		public static ByTable spawn_room( dynamic start_loc = null, dynamic x_size = null, dynamic y_size = null, dynamic walltypes = null, dynamic floor = null, dynamic name = null ) {
			ByTable room_turfs = null;
			int x = 0;
			int y = 0;
			dynamic T = null;
			dynamic cur_loc = null;
			ByArea A = null;
			dynamic wall = null;
			room_turfs = new ByTable()
				.set( "floors", new ByTable() )
				.set( "walls", new ByTable() )
				
			;
			x = null;
			x = 0;
			while (x < x_size) {
				y = null;
				y = 0;
				while (y < y_size) {
					T = null;
					cur_loc = Misc13.locate3( start_loc.x + x, start_loc.y + y, start_loc.z );
					A = new ByArea(2768)();
					if ( Misc13.isValid( name ) ) {
						A.name = name;
					} else {
						A.name = "Artifact Room #" + A.x + "-" + A.y + "-" + A.z;
					}
					if ( x == 0 || x == x_size - 1 || y == 0 || y == y_size - 1 ) {
						wall = GlobalFuncs.pickweight( walltypes );
						T = cur_loc;
						T.ChangeTurf( wall );
						room_turfs["walls"] += T;
					} else {
						T = cur_loc;
						T.ChangeTurf( floor );
						room_turfs["floors"] += T;
					}
					A.contents += T;
					y++;
				}
				x++;
			}
			return room_turfs;
		}

		public static void sql_poll_admins(  ) {
			dynamic admincount = null;
			dynamic sqltime = null;
			DBQuery query = null;
			dynamic err = null;
			if ( !Misc13.isValid( GlobalVars.config.sql_enabled ) ) {
				return;
			}
			admincount = GlobalVars.admins.len;
			GlobalFuncs.establish_db_connection();
			if ( GlobalVars.dbcon.IsConnected() == 0 ) {
				GlobalFuncs.log_game( "SQL ERROR during admin polling. Failed to connect." );
			} else {
				sqltime = Misc13.formatTime( Game.realtime, "YYYY-MM-DD hh:mm:ss" );
				query = GlobalVars.dbcon.NewQuery( "INSERT INTO " + GlobalFuncs.format_table_name( "legacy_population" ) + " (admincount, time) VALUES (" + admincount + ", '" + sqltime + "')" );
				if ( !Misc13.isValid( query.Execute() ) ) {
					err = query.ErrorMsg();
					GlobalFuncs.log_game( "SQL ERROR during admin polling. Error : [" + err + "]\n" );
				}
			}
		}

		public static void sql_poll_players(  ) {
			int playercount = 0;
			dynamic M = null;
			dynamic sqltime = null;
			DBQuery query = null;
			dynamic err = null;
			if ( !Misc13.isValid( GlobalVars.config.sql_enabled ) ) {
				return;
			}
			playercount = 0;
			M = null;
			foreach (dynamic _ in GlobalVars.player_list ) {
				M = _;
				if ( Misc13.isValid( M.client ) ) {
					playercount += 1;
				}
			};
			GlobalFuncs.establish_db_connection();
			if ( GlobalVars.dbcon.IsConnected() == 0 ) {
				GlobalFuncs.log_game( "SQL ERROR during player polling. Failed to connect." );
			} else {
				sqltime = Misc13.formatTime( Game.realtime, "YYYY-MM-DD hh:mm:ss" );
				query = GlobalVars.dbcon.NewQuery( "INSERT INTO " + GlobalFuncs.format_table_name( "legacy_population" ) + " (playercount, time) VALUES (" + playercount + ", '" + sqltime + "')" );
				if ( !Misc13.isValid( query.Execute() ) ) {
					err = query.ErrorMsg();
					GlobalFuncs.log_game( "SQL ERROR during player polling. Error : [" + err + "]\n" );
				}
			}
		}

		public static void sql_report_cyborg_death( dynamic H = null ) {
			dynamic T = null;
			int placeofdeath = 0;
			dynamic podname = null;
			dynamic sqlname = null;
			dynamic sqlkey = null;
			dynamic sqlpod = null;
			dynamic sqlspecial = null;
			dynamic sqljob = null;
			dynamic laname = null;
			dynamic lakey = null;
			dynamic sqltime = null;
			string coord = null;
			DBQuery query = null;
			dynamic err = null;
			if ( !Misc13.isValid( GlobalVars.config.sql_enabled ) ) {
				return;
			}
			if ( !Misc13.isValid( H ) ) {
				return;
			}
			if ( !Misc13.isValid( H.key ) || !Misc13.isValid( H.mind ) ) {
				return;
			}
			T = H.loc;
			placeofdeath = GlobalFuncs.get_area( T.loc );
			podname = placeofdeath.name;
			sqlname = GlobalFuncs.sanitizeSQL( H.real_name );
			sqlkey = GlobalFuncs.sanitizeSQL( H.key );
			sqlpod = GlobalFuncs.sanitizeSQL( podname );
			sqlspecial = GlobalFuncs.sanitizeSQL( H.mind.special_role );
			sqljob = GlobalFuncs.sanitizeSQL( H.mind.assigned_role );
			if ( Misc13.isValid( H.lastattacker ) ) {
				laname = GlobalFuncs.sanitizeSQL( H.lastattacker.real_name );
				lakey = GlobalFuncs.sanitizeSQL( H.lastattacker.key );
			}
			sqltime = Misc13.formatTime( Game.realtime, "YYYY-MM-DD hh:mm:ss" );
			coord = "" + H.x + ", " + H.y + ", " + H.z;
			GlobalFuncs.establish_db_connection();
			if ( GlobalVars.dbcon.IsConnected() == 0 ) {
				GlobalFuncs.log_game( "SQL ERROR during death reporting. Failed to connect." );
			} else {
				query = GlobalVars.dbcon.NewQuery( "INSERT INTO " + GlobalFuncs.format_table_name( "death" ) + " (name, byondkey, job, special, pod, tod, laname, lakey, gender, bruteloss, fireloss, brainloss, oxyloss, coord) VALUES ('" + sqlname + "', '" + sqlkey + "', '" + sqljob + "', '" + sqlspecial + "', '" + sqlpod + "', '" + sqltime + "', '" + laname + "', '" + lakey + "', '" + H.gender + "', " + H.getBruteLoss() + ", " + H.getFireLoss() + ", " + H.brainloss + ", " + H.getOxyLoss() + ", '" + coord + "')" );
				if ( !Misc13.isValid( query.Execute() ) ) {
					err = query.ErrorMsg();
					GlobalFuncs.log_game( "SQL ERROR during death reporting. Error : [" + err + "]\n" );
				}
			}
		}

		public static void sql_report_death( dynamic H = null ) {
			dynamic T = null;
			int placeofdeath = 0;
			dynamic podname = null;
			dynamic sqlname = null;
			dynamic sqlkey = null;
			dynamic sqlpod = null;
			dynamic sqlspecial = null;
			dynamic sqljob = null;
			dynamic laname = null;
			dynamic lakey = null;
			dynamic sqltime = null;
			string coord = null;
			DBQuery query = null;
			dynamic err = null;
			if ( !Misc13.isValid( GlobalVars.config.sql_enabled ) ) {
				return;
			}
			if ( !Misc13.isValid( H ) ) {
				return;
			}
			if ( !Misc13.isValid( H.key ) || !Misc13.isValid( H.mind ) ) {
				return;
			}
			T = H.loc;
			placeofdeath = GlobalFuncs.get_area( T.loc );
			podname = placeofdeath.name;
			sqlname = GlobalFuncs.sanitizeSQL( H.real_name );
			sqlkey = GlobalFuncs.sanitizeSQL( H.key );
			sqlpod = GlobalFuncs.sanitizeSQL( podname );
			sqlspecial = GlobalFuncs.sanitizeSQL( H.mind.special_role );
			sqljob = GlobalFuncs.sanitizeSQL( H.mind.assigned_role );
			if ( Misc13.isValid( H.lastattacker ) ) {
				laname = GlobalFuncs.sanitizeSQL( H.lastattacker.real_name );
				lakey = GlobalFuncs.sanitizeSQL( H.lastattacker.key );
			}
			sqltime = Misc13.formatTime( Game.realtime, "YYYY-MM-DD hh:mm:ss" );
			coord = "" + H.x + ", " + H.y + ", " + H.z;
			GlobalFuncs.establish_db_connection();
			if ( GlobalVars.dbcon.IsConnected() == 0 ) {
				GlobalFuncs.log_game( "SQL ERROR during death reporting. Failed to connect." );
			} else {
				query = GlobalVars.dbcon.NewQuery( "INSERT INTO " + GlobalFuncs.format_table_name( "death" ) + " (name, byondkey, job, special, pod, tod, laname, lakey, gender, bruteloss, fireloss, brainloss, oxyloss, coord) VALUES ('" + sqlname + "', '" + sqlkey + "', '" + sqljob + "', '" + sqlspecial + "', '" + sqlpod + "', '" + sqltime + "', '" + laname + "', '" + lakey + "', '" + H.gender + "', " + H.getBruteLoss() + ", " + H.getFireLoss() + ", " + H.brainloss + ", " + H.getOxyLoss() + ", '" + coord + "')" );
				if ( !Misc13.isValid( query.Execute() ) ) {
					err = query.ErrorMsg();
					GlobalFuncs.log_game( "SQL ERROR during death reporting. Error : [" + err + "]\n" );
				}
			}
		}

		public static dynamic SQLtime(  ) {
			return Misc13.formatTime( Game.realtime, "YYYY-MM-DD hh:mm:ss" );
		}

		public static dynamic stars( dynamic n = null, int pr = 0 ) {
			dynamic te = null;
			string t = null;
			int p = 0;
			n = Misc13.html_encode( n );
			if ( pr == null ) {
				pr = 25;
			}
			if ( pr <= 0 ) {
				return null;
			} else if ( pr >= 100 ) {
				return n;
			}
			te = n;
			t = "";
			n = n.Length;
			p = null;
			p = 1;
			while (p <= n) {
				if ( Misc13.str_sub( te, p, p + 1 ) == " " || Misc13.isValid( Rand.chance( pr ) ) ) {
					t = "" + t + Misc13.str_sub( te, p, p + 1 );
				} else {
					t = "" + t + "*";
				}
				p++;
			}
			return GlobalFuncs.sanitize( t );
		}

		public static string station_name(  ) {
			if ( Misc13.isValid( GlobalVars.station_name ) ) {
				return GlobalVars.station_name;
			}
			if ( Misc13.isValid( GlobalVars.config ) && Misc13.isValid( GlobalVars.config.station_name ) ) {
				GlobalVars.station_name = GlobalVars.config.station_name;
			} else {
				GlobalVars.station_name = GlobalFuncs.new_station_name();
			}
			if ( Misc13.isValid( GlobalVars.config ) && Misc13.isValid( GlobalVars.config.server_name ) ) {
				Game.name = "" + GlobalVars.config.server_name + ( GlobalVars.config.server_name == GlobalVars.station_name ? "" : ": " + GlobalVars.station_name );
			} else {
				Game.name = GlobalVars.station_name;
			}
			return GlobalVars.station_name;
		}

		public static dynamic stickyban2list( dynamic ban = null ) {
			dynamic _default = null;
			if ( !Misc13.isValid( ban ) ) {
				return null;
			}
			_default = Misc13.conv_params2list( ban );
			_default["keys"] = GlobalFuncs.text2list( _default["keys"], "," );
			_default["type"] = GlobalFuncs.text2list( _default["type"], "," );
			_default["IP"] = GlobalFuncs.text2list( _default["IP"], "," );
			_default["computer_id"] = GlobalFuncs.text2list( _default["computer_id"], "," );
			return _default;
		}

		public static ByTable string2listofvars( dynamic t_string = null, dynamic var_source = null ) {
			ByTable _default = null;
			dynamic var_found = null;
			ByTable list_value = null;
			dynamic intermediate_stage = null;
			ByTable value = null;
			dynamic A = null;
			if ( !Misc13.isValid( t_string ) || !Misc13.isValid( var_source ) ) {
				return new ByTable();
			}
			_default = new ByTable();
			var_found = Misc13.str_find( t_string, "[", 1, null );
			if ( Misc13.isValid( var_found ) ) {
				t_string = GlobalFuncs.replacetext( t_string, "[", "[ " );
				list_value = GlobalFuncs.text2list( t_string, "[" );
				intermediate_stage = GlobalFuncs.list2text( list_value );
				list_value = GlobalFuncs.text2list( intermediate_stage, " " );
				value = null;
				foreach (dynamic _ in list_value ) {
					value = _;
					if ( Misc13.isValid( Misc13.str_find( value, "]", 1, null ) ) ) {
						value = GlobalFuncs.text2list( value, "]" );
						A = null;
						foreach (dynamic _ in value ) {
							A = _;
							if ( Misc13.isValid( var_source.vars.Find( A ) ) ) {
								_default += A;
							}
						};
					}
				};
			}
			return _default;
		}

		public static dynamic strings( dynamic filename = null, dynamic key = null ) {
			ByTable fileList = null;
			ByTable stringsList = null;
			dynamic s = null;
			if ( GlobalVars.string_cache == null ) {
				GlobalVars.string_cache = new ByTable();
			}
			if ( !Misc13.isValid( GlobalVars.string_cache.HasValue( filename ) ) ) {
				if ( Misc13.isValid( File13.exists( "strings/" + filename ) ) ) {
					GlobalVars.string_cache[filename] = new ByTable();
					stringsList = new ByTable();
					fileList = GlobalFuncs.file2list( "strings/" + filename );
					s = null;
					foreach (dynamic _ in fileList ) {
						s = _;
						stringsList = GlobalFuncs.text2list( s, "@=" );
						if ( stringsList.len != 2 ) {
							Misc13.crash( "Invalid string list in strings/" + filename );
						}
						if ( Misc13.isValid( Misc13.str_find( stringsList[2], "@,", 1, null ) ) ) {
							GlobalVars.string_cache[filename][stringsList[1]] = GlobalFuncs.text2list( stringsList[2], "@," );
						} else {
							GlobalVars.string_cache[filename][stringsList[1]] = stringsList[2];
						}
					};
				} else {
					Misc13.crash( "file not found: strings/" + filename );
				}
			}
			if ( Misc13.isValid( GlobalVars.string_cache.HasValue( filename ) ) && Misc13.isValid( GlobalVars.string_cache[filename].HasValue( key ) ) ) {
				return GlobalVars.string_cache[filename][key];
			} else {
				Misc13.crash( "strings list not found: strings/" + filename + ", index=" + key );
			}
		}

		public static dynamic strip_html_simple( dynamic t = null, int limit = 0 ) {
			ByTable strip_chars = null;
			dynamic _char = null;
			dynamic index = null;
			if ( limit == null ) {
				limit = 1024;
			}
			strip_chars = new ByTable(new object [] {"<",">"});
			t = Misc13.str_sub( t, 1, limit );
			_char = null;
			foreach (dynamic _ in strip_chars ) {
				_char = _;
				index = Misc13.str_find( t, _char, 1, null );
				while (index) {
					t = Misc13.str_sub( t, 1, index ) + Misc13.str_sub( t, index + 1, null );
					index = Misc13.str_find( t, _char, 1, null );
				}
			};
			return t;
		}

		public static string stripped_input( dynamic user = null, string message = null, string title = null, string __default = null, int max_length = 0 ) {
			dynamic name = null;
			if ( message == null ) {
				message = "";
			}
			if ( title == null ) {
				title = "";
			}
			if ( __default == null ) {
				__default = "";
			}
			if ( max_length == null ) {
				max_length = 1024;
			}
			name = Misc13.input( user, message, title, __default, null, 132 );
			return GlobalFuncs.trim( Misc13.html_encode( name ), max_length );
		}

		public static dynamic stripped_multiline_input( dynamic user = null, string message = null, string title = null, string __default = null, int max_length = 0 ) {
			dynamic name = null;
			if ( message == null ) {
				message = "";
			}
			if ( title == null ) {
				title = "";
			}
			if ( __default == null ) {
				__default = "";
			}
			if ( max_length == null ) {
				max_length = 1024;
			}
			name = Misc13.input( user, message, title, __default, null, 2176 );
			return Misc13.html_encode( GlobalFuncs.trim( name, max_length ) );
		}

		public static dynamic stutter( dynamic n = null ) {
			dynamic te = null;
			string t = null;
			int p = 0;
			string n_letter = null;
			te = Misc13.html_decode( n );
			t = "";
			n = n.Length;
			p = null;
			p = 1;
			while (p <= n) {
				n_letter = Misc13.str_sub( te, p, p + 1 );
				if ( Misc13.isValid( Rand.chance( 80 ) ) && Misc13.isValid( new ByTable(new object [] {"b","c","d","f","g","h","j","k","l","m","n","p","q","r","s","t","v","w","x","y","z"}).HasValue( Misc13.ckey( n_letter ) ) ) ) {
					if ( Misc13.isValid( Rand.chance( 10 ) ) ) {
						n_letter = "" + n_letter + "-" + n_letter + "-" + n_letter + "-" + n_letter;
					} else if ( Misc13.isValid( Rand.chance( 20 ) ) ) {
						n_letter = "" + n_letter + "-" + n_letter + "-" + n_letter;
					} else if ( Misc13.isValid( Rand.chance( 5 ) ) ) {
						n_letter = null;
					} else {
						n_letter = "" + n_letter + "-" + n_letter;
					}
				}
				t = "" + t + n_letter;
				p++;
			}
			return Misc13.str_sub( GlobalFuncs.sanitize( t ), 1, 1024 );
		}

		public static void summonevents(  ) {
			if ( !Misc13.isValid( GlobalVars.SSevent.wizardmode ) ) {
				GlobalVars.SSevent.frequency_lower = 600;
				GlobalVars.SSevent.frequency_upper = 3000;
				GlobalVars.SSevent.toggleWizardmode();
				GlobalVars.SSevent.reschedule();
			} else {
				GlobalVars.SSevent.frequency_upper -= 600;
				if ( GlobalVars.SSevent.frequency_upper < GlobalVars.SSevent.frequency_lower ) {
					GlobalVars.SSevent.frequency_upper = GlobalVars.SSevent.frequency_lower;
				}
				GlobalVars.SSevent.reschedule();
				GlobalFuncs.message_admins( "Summon Events intensifies, events will now occur every " + GlobalVars.SSevent.frequency_lower / 600 + " to " + GlobalVars.SSevent.frequency_upper / 600 + " minutes." );
				GlobalFuncs.log_game( "Summon Events was increased!" );
			}
		}

		public static void Syndicate_announce( dynamic text = null, dynamic Sender = null ) {
			dynamic msg = null;
			msg = Misc13.str_sub( GlobalFuncs.sanitize( text ), 1, 1024 );
			msg = new Txt( "<span class='adminnotice'><b><font color=crimson>SYNDICATE:</font>" ).item( GlobalFuncs.key_name_admin( Sender ) ).str( " (<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( Sender ).str( "'>?</A>) (<A HREF='?_src_=holder;adminplayeropts=" ).Ref( Sender ).str( "'>PP</A>) (<A HREF='?_src_=vars;Vars=" ).Ref( Sender ).str( "'>VV</A>) (<A HREF='?_src_=holder;subtlemessage=" ).Ref( Sender ).str( "'>SM</A>) (<A HREF='?_src_=holder;adminplayerobservefollow=" ).Ref( Sender ).str( "'>FLW</A>) (<A HREF='?_src_=holder;traitor=" ).Ref( Sender ).str( "'>TP</A>) (<A HREF='?_src_=holder;BlueSpaceArtillery=" ).Ref( Sender ).str( "'>BSA</A>) (<A HREF='?_src_=holder;SyndicateReply=" ).Ref( Sender ).str( "'>RPLY</A>):</b> " ).item( msg ).str( "</span>" );
			GlobalVars.admins.write( msg );
		}

		public static string syndicate_name(  ) {
			string name = null;
			if ( Misc13.isValid( GlobalVars.syndicate_name ) ) {
				return GlobalVars.syndicate_name;
			}
			name = "";
			name += Rand.pick(new object [] { "Clandestine", "Prima", "Blue", "Zero-G", "Max", "Blasto", "Waffle", "North", "Omni", "Newton", "Cyber", "Bonk", "Gene", "Gib" });
			if ( Misc13.isValid( Rand.chance( 80 ) ) ) {
				name += " ";
				if ( Misc13.isValid( Rand.chance( 60 ) ) ) {
					name += Rand.pick(new object [] { "Syndicate", "Consortium", "Collective", "Corporation", "Group", "Holdings", "Biotech", "Industries", "Systems", "Products", "Chemicals", "Enterprises", "Family", "Creations", "International", "Intergalactic", "Interplanetary", "Foundation", "Positronics", "Hive" });
				} else {
					name += Rand.pick(new object [] { "Syndi", "Corp", "Bio", "System", "Prod", "Chem", "Inter", "Hive" });
					name += Rand.pick(new object [] { "", "-" });
					name += Rand.pick(new object [] { "Tech", "Sun", "Co", "Tek", "X", "Inc", "Code" });
				}
			} else {
				name += Rand.pick(new object [] { "-", "*", "" });
				name += Rand.pick(new object [] { "Tech", "Sun", "Co", "Tek", "X", "Inc", "Gen", "Star", "Dyne", "Code", "Hive" });
			}
			GlobalVars.syndicate_name = name;
			return name;
		}

		public static void testing( dynamic msg = null ) {
			
		}

		public static int text2dir_extended( dynamic direction = null ) {
			dynamic _ = Misc13.str_upper( direction ); // Was a switch-case, sorry for the mess.
			if ( _=="NORTH" || _=="N" ) {
				return 1;
			} else if ( _=="SOUTH" || _=="S" ) {
				return 2;
			} else if ( _=="EAST" || _=="E" ) {
				return 4;
			} else if ( _=="WEST" || _=="W" ) {
				return 8;
			} else if ( _=="NORTHEAST" || _=="NE" ) {
				return 5;
			} else if ( _=="NORTHWEST" || _=="NW" ) {
				return 9;
			} else if ( _=="SOUTHEAST" || _=="SE" ) {
				return 6;
			} else if ( _=="SOUTHWEST" || _=="SW" ) {
				return 10;
			};
			return 0;
		}

		public static ByTable text2list( dynamic text = null, string delimiter = null ) {
			ByTable _default = null;
			dynamic delim_len = null;
			int last_found = 0;
			dynamic found = null;
			if ( delimiter == null ) {
				delimiter = "\n";
			}
			delim_len = delimiter.Length;
			if ( delim_len < 1 ) {
				return new ByTable(new object [] {text});
			}
			_default = new ByTable();
			last_found = 1;
			while (true) { // Was a do-while, sorry for the mess.
				found = Misc13.str_find( text, delimiter, last_found, 0 );
				_default += Misc13.str_sub( text, last_found, found );
				last_found = found + delim_len;
				if (!( found )) break;
			};
			return _default;
		}

		public static dynamic time_stamp( string format = null ) {
			if ( format == null ) {
				format = "hh:mm:ss";
			}
			return Misc13.formatTime( Game.timeofday, format );
		}

		public static int tkMaxRangeCheck( dynamic user = null, dynamic target = null, dynamic focus = null ) {
			dynamic d = null;
			d = Misc13.get_dist( user, target );
			if ( Misc13.isValid( focus ) ) {
				d = Misc13.max( d, Misc13.get_dist( user, focus ) );
			}
			if ( d > GlobalVars.tk_maxrange ) {
				user.write( "<span class ='warning'>Your mind won't reach that far.</span>" );
				return 0;
			}
			return 1;
		}

		public static void toggle_ooc( dynamic toggle = null ) {
			if ( toggle == null ) {
				toggle = null;
			}
			if ( toggle != null ) {
				if ( toggle != GlobalVars.ooc_allowed ) {
					GlobalVars.ooc_allowed = toggle;
				} else {
					return;
				}
			} else {
				GlobalVars.ooc_allowed = !Misc13.isValid( GlobalVars.ooc_allowed );
			}
			Game.write( "<B>The OOC channel has been globally " + ( Misc13.isValid( GlobalVars.ooc_allowed ) ? "enabled" : "disabled" ) + ".</B>" );
		}

		public static void togglebuildmode( dynamic M = null ) {
			dynamic H = null;
			Ent_Effect_Bmode_Builddir A = null;
			Ent_Effect_Bmode_Buildhelp B = null;
			Ent_Effect_Bmode_Buildmode C = null;
			Ent_Effect_Bmode_Buildquit D = null;
			if ( Misc13.isValid( M.client ) ) {
				if ( Misc13.isValid( M.client.buildmode ) ) {
					GlobalFuncs.log_admin( "" + GlobalFuncs.key_name( Misc13.thread_user ) + " has left build mode." );
					M.client.buildmode = 0;
					M.client.show_popup_menus = 1;
					H = null;
					foreach (dynamic _ in Game ) {
						H = _;
						if ( !( H is Ent_Effect_Bmode_Buildholder ) ) {
							continue;
						}
						if ( H.cl == M.client ) {
							GlobalFuncs.qdel( H );
						}
					};
				} else {
					GlobalFuncs.message_admins( "" + GlobalFuncs.key_name( Misc13.thread_user ) + " has entered build mode." );
					GlobalFuncs.log_admin( "" + GlobalFuncs.key_name( Misc13.thread_user ) + " has entered build mode." );
					M.client.buildmode = 1;
					M.client.show_popup_menus = 0;
					H = new Ent_Effect_Bmode_Buildholder();
					A = new Ent_Effect_Bmode_Builddir( H );
					A.master = H;
					B = new Ent_Effect_Bmode_Buildhelp( H );
					B.master = H;
					C = new Ent_Effect_Bmode_Buildmode( H );
					C.master = H;
					D = new Ent_Effect_Bmode_Buildquit( H );
					D.master = H;
					H.builddir = A;
					H.buildhelp = B;
					H.buildmode = C;
					H.buildquit = D;
					M.client.screen += A;
					M.client.screen += B;
					M.client.screen += C;
					M.client.screen += D;
					H.cl = M.client;
				}
			}
		}

		public static dynamic trange( int Dist = 0, dynamic Center = null ) {
			dynamic x1y1 = null;
			dynamic x2y2 = null;
			if ( Dist == null ) {
				Dist = 0;
			}
			if ( Center == null ) {
				Center = null;
			}
			if ( Center == null ) {
				return null;
			}
			x1y1 = Misc13.locate3( Center.x - Dist < 1 ? 1 : Center.x - Dist, Center.y - Dist < 1 ? 1 : Center.y - Dist, Center.z );
			x2y2 = Misc13.locate3( Center.x + Dist > Game.maxx ? Game.maxx : Center.x + Dist, Center.y + Dist > Game.maxy ? Game.maxy : Center.y + Dist, Center.z );
			return Misc13.block( x1y1, x2y2 );
		}

		public static int transform_dir( dynamic direction = null ) {
			dynamic _ = direction; // Was a switch-case, sorry for the mess.
			if ( _==1 || _==2 || _==4 || _==8 ) {
				return direction;
			} else if ( _==5 ) {
				return 16;
			} else if ( _==9 ) {
				return 32;
			} else if ( _==6 ) {
				return 64;
			} else if ( _==10 ) {
				return 128;
			};
		}

		public static dynamic TransformUsingVariable( dynamic input = null, dynamic inputmaximum = null, int scaling_modifier = 0 ) {
			dynamic inputToDegrees = null;
			dynamic size_factor = null;
			if ( scaling_modifier == null ) {
				scaling_modifier = 0;
			}
			inputToDegrees = input / inputmaximum * 180;
			size_factor = ( -Math.cos( inputToDegrees ) + 1 ) / 2;
			return size_factor + scaling_modifier;
		}

		public static string trim( dynamic text = null, dynamic max_length = null ) {
			if ( Misc13.isValid( max_length ) ) {
				text = Misc13.str_sub( text, 1, max_length );
			}
			return GlobalFuncs.trim_left( GlobalFuncs.trim_right( text ) );
		}

		public static string trim_left( dynamic text = null ) {
			dynamic i = null;
			i = null;
			foreach (dynamic _ in Misc13.iter_range( 1, text.Length ) ) {
				i = _;
				if ( Misc13.conv_text2ascii( text, i ) > 32 ) {
					return Misc13.str_sub( text, i, null );
				}
			};
			return "";
		}

		public static string trim_right( dynamic text = null ) {
			dynamic i = null;
			i = null;
			i = text.Length;
			while (i > 0) {
				if ( Misc13.conv_text2ascii( text, i ) > 32 ) {
					return Misc13.str_sub( text, 1, i + 1 );
				}
				i--;
			}
			return "";
		}

		public static void try_move_adjacent( dynamic AM = null ) {
			dynamic T = null;
			dynamic direction = null;
			T = GlobalFuncs.get_turf( AM );
			direction = null;
			foreach (dynamic _ in GlobalVars.cardinal ) {
				direction = _;
				if ( Misc13.isValid( AM.Move( Misc13.get_step( T, direction ) ) ) ) {
					break;
				}
			};
		}

		public static ByRsc ui_style2icon( dynamic ui_style = null ) {
			dynamic _ = ui_style; // Was a switch-case, sorry for the mess.
			if ( _=="Retro" ) {
				return new ByRsc(12);
			} else if ( _=="Plasmafire" ) {
				return new ByRsc(13);
			} else {
				return new ByRsc(14);
			};
		}

		public static ByTable ultra_range( int dist = 0, dynamic center = null, int orange = 0 ) {
			dynamic t_center = null;
			ByTable L = null;
			dynamic T = null;
			dynamic y = null;
			dynamic x = null;
			int c_dist = 0;
			if ( dist == null ) {
				dist = 0;
			}
			if ( center == null ) {
				center = Misc13.thread_user;
			}
			if ( orange == null ) {
				orange = 0;
			}
			if ( dist == 0 ) {
				if ( orange == 0 ) {
					return new ByTable(new object [] {center});
				} else {
					return new ByTable();
				}
			}
			t_center = GlobalFuncs.get_turf( center );
			if ( !Misc13.isValid( t_center ) ) {
				return new ByTable();
			}
			L = new ByTable();
			c_dist = 1;
			if ( orange == 0 ) {
				L += t_center;
				L += t_center.contents;
			}
			while (c_dist <= dist) {
				y = t_center.y + c_dist;
				x = t_center.x - c_dist + 1;
				foreach (dynamic _ in Misc13.iter_range( x, t_center.x + c_dist ) ) {
					x = _;
					T = Misc13.locate3( x, y, t_center.z );
					if ( Misc13.isValid( T ) ) {
						L += T;
						L += T.contents;
					}
				};
				y = t_center.y + c_dist - 1;
				x = t_center.x + c_dist;
				foreach (dynamic _ in Misc13.iter_range( t_center.y - c_dist, y ) ) {
					y = _;
					T = Misc13.locate3( x, y, t_center.z );
					if ( Misc13.isValid( T ) ) {
						L += T;
						L += T.contents;
					}
				};
				y = t_center.y - c_dist;
				x = t_center.x + c_dist - 1;
				foreach (dynamic _ in Misc13.iter_range( t_center.x - c_dist, x ) ) {
					x = _;
					T = Misc13.locate3( x, y, t_center.z );
					if ( Misc13.isValid( T ) ) {
						L += T;
						L += T.contents;
					}
				};
				y = t_center.y - c_dist + 1;
				x = t_center.x - c_dist;
				foreach (dynamic _ in Misc13.iter_range( y, t_center.y + c_dist ) ) {
					y = _;
					T = Misc13.locate3( x, y, t_center.z );
					if ( Misc13.isValid( T ) ) {
						L += T;
						L += T.contents;
					}
				};
				c_dist++;
			}
			return L;
		}

		public static dynamic unix2date( dynamic timestamp = null, string seperator = null ) {
			int year = 0;
			int dayInSeconds = 0;
			int daysInYear = 0;
			int daysInLYear = 0;
			dynamic days = null;
			dynamic tmpDays = null;
			ByTable monthsInDays = null;
			int month = 0;
			dynamic day = null;
			int mDays = 0;
			int monthIndex = 0;
			dynamic m = null;
			if ( seperator == null ) {
				seperator = "-";
			}
			if ( timestamp < 0 ) {
				return 0;
			}
			year = 1970;
			dayInSeconds = 86400;
			daysInYear = 365;
			daysInLYear = daysInYear + 1;
			days = Misc13.round( timestamp / dayInSeconds );
			tmpDays = days + 1;
			monthsInDays = new ByTable();
			month = 1;
			while (tmpDays > daysInYear) {
				year++;
				if ( GlobalFuncs.isLeap( year ) ) {
					tmpDays -= daysInLYear;
				} else {
					tmpDays -= daysInYear;
				}
			}
			if ( GlobalFuncs.isLeap( year ) ) {
				monthsInDays = new ByTable(new object [] {-1,30,59,90,120,151,181,212,243,273,304,334});
			} else {
				monthsInDays = new ByTable(new object [] {0,31,59,90,120,151,181,212,243,273,304,334});
			}
			mDays = 0;
			monthIndex = 0;
			m = null;
			foreach (dynamic _ in monthsInDays ) {
				m = _;
				monthIndex++;
				if ( tmpDays > m ) {
					mDays = m;
					month = monthIndex;
				}
			};
			day = tmpDays - mDays;
			return "" + year + seperator + ( month < 10 ? "0" + month : month ) + seperator + ( day < 10 ? "0" + day : day );
		}

		public static void updateallghostimages(  ) {
			dynamic O = null;
			O = null;
			foreach (dynamic _ in GlobalVars.player_list ) {
				O = _;
				if ( !( O is Mob_Dead_Observer ) ) {
					continue;
				}
				O.updateghostimages();
			};
		}

		public static int UpdateTime(  ) {
			GlobalVars.CMinutes = Game.realtime / 10 / 60;
			return 1;
		}

		public static dynamic view_or_range( dynamic distance = null, dynamic center = null, dynamic type = null ) {
			dynamic _default = null;
			if ( distance == null ) {
				distance = Game.view;
			}
			if ( center == null ) {
				center = Misc13.thread_user;
			}
			dynamic _ = type; // Was a switch-case, sorry for the mess.
			if ( _=="view" ) {
				_default = Misc13.view( distance, center );
			} else if ( _=="range" ) {
				_default = Misc13.range( distance, center );
			};
			return null;
			return _default;
		}

		public static int vol_by_throwforce_and_or_w_class( dynamic I = null ) {
			if ( !Misc13.isValid( I ) ) {
				return 0;
			}
			if ( Misc13.isValid( I.throwforce ) && Misc13.isValid( I.w_class ) ) {
				return GlobalFuncs.Clamp( ( I.throwforce + I.w_class ) * 5, 30, 100 );
			} else if ( Misc13.isValid( I.w_class ) ) {
				return GlobalFuncs.Clamp( I.w_class * 8, 20, 100 );
			} else {
				return 0;
			}
		}

		public static dynamic wabbajack( dynamic M = null ) {
			dynamic Robot = null;
			dynamic W = null;
			dynamic new_mob = null;
			dynamic randomize = null;
			dynamic robot = null;
			dynamic D = null;
			dynamic Slime = null;
			dynamic beast = null;
			dynamic animal = null;
			Preferences A = null;
			dynamic H = null;
			ByTable all_species = null;
			dynamic speciestype = null;
			dynamic S = null;
			if ( M is Mob_Living ) {
				if ( M is Mob_Living && M.stat != 2 ) {
					if ( Misc13.isValid( M.notransform ) ) {
						return null;
					}
					M.notransform = 1;
					M.canmove = 0;
					M.icon = null;
					M.overlays.Cut();
					M.invisibility = 101;
					if ( M is Mob_Living_Silicon_Robot ) {
						Robot = M;
						if ( Misc13.isValid( Robot.mmi ) ) {
							GlobalFuncs.qdel( Robot.mmi );
						}
						Robot.notify_ai( 1 );
					} else {
						W = null;
						foreach (dynamic _ in M ) {
							W = _;
							if ( !( W is Ent_Item ) ) {
								continue;
							}
							if ( W is Ent_Item_Weapon_Implant ) {
								GlobalFuncs.qdel( W );
								continue;
							}
							W.layer = Misc13.initial( W.layer );
							W.loc = M.loc;
							W.dropped( M );
						};
					}
					new_mob = null;
					randomize = Rand.pick(new object [] { "monkey", "robot", "slime", "xeno", "humanoid", "animal" });
					dynamic _ = randomize; // Was a switch-case, sorry for the mess.
					if ( _=="monkey" ) {
						new_mob = new Mob_Living_Carbon_Monkey( M.loc );
						new_mob.languages |= 1;
					} else if ( _=="robot" ) {
						robot = Rand.pick(new object [] { "cyborg", "syndiborg", "drone" });
						dynamic _ = robot; // Was a switch-case, sorry for the mess.
						if ( _=="cyborg" ) {
							new_mob = new Mob_Living_Silicon_Robot( M.loc );
						} else if ( _=="syndiborg" ) {
							new_mob = new Mob_Living_Silicon_Robot_Syndicate( M.loc );
						} else if ( _=="drone" ) {
							new_mob = new Mob_Living_SimpleAnimal_Drone( M.loc );
							D = new_mob;
							D.update_drone_hack();
						};
						if ( new_mob is Mob_Living_Silicon ) {
							new_mob.gender = M.gender;
							new_mob.invisibility = 0;
							new_mob.job = "Cyborg";
							Robot = new_mob;
							Robot.mmi = new Ent_Item_Device_Mmi( new_mob );
							Robot.mmi.transfer_identity( M );
						} else {
							new_mob.languages |= 1;
						}
					} else if ( _=="slime" ) {
						new_mob = new Mob_Living_SimpleAnimal_Slime( M.loc );
						if ( Misc13.isValid( Rand.chance( 50 ) ) ) {
							Slime = new_mob;
							Slime.is_adult = 1;
						}
						new_mob.languages |= 1;
					} else if ( _=="xeno" ) {
						if ( Misc13.isValid( Rand.chance( 50 ) ) ) {
							new_mob = new Mob_Living_Carbon_Alien_Humanoid_Hunter( M.loc );
						} else {
							new_mob = new Mob_Living_Carbon_Alien_Humanoid_Sentinel( M.loc );
						}
						new_mob.languages |= 1;
					} else if ( _=="animal" ) {
						if ( Misc13.isValid( Rand.chance( 50 ) ) ) {
							beast = Rand.pick(new object [] { "carp", "bear", "mushroom", "statue", "bat", "goat", "killertomato", "spiderbase", "spiderhunter", "blobbernaut", "magicarp", "chaosmagicarp" });
							dynamic _ = beast; // Was a switch-case, sorry for the mess.
							if ( _=="carp" ) {
								new_mob = new Mob_Living_SimpleAnimal_Hostile_Carp( M.loc );
							} else if ( _=="bear" ) {
								new_mob = new Mob_Living_SimpleAnimal_Hostile_Bear( M.loc );
							} else if ( _=="mushroom" ) {
								new_mob = new Mob_Living_SimpleAnimal_Hostile_Mushroom( M.loc );
							} else if ( _=="statue" ) {
								new_mob = new Mob_Living_SimpleAnimal_Hostile_Statue( M.loc );
							} else if ( _=="bat" ) {
								new_mob = new Mob_Living_SimpleAnimal_Hostile_Retaliate_Bat( M.loc );
							} else if ( _=="goat" ) {
								new_mob = new Mob_Living_SimpleAnimal_Hostile_Retaliate_Goat( M.loc );
							} else if ( _=="killertomato" ) {
								new_mob = new Mob_Living_SimpleAnimal_Hostile_Killertomato( M.loc );
							} else if ( _=="spiderbase" ) {
								new_mob = new Mob_Living_SimpleAnimal_Hostile_Poison_GiantSpider( M.loc );
							} else if ( _=="spiderhunter" ) {
								new_mob = new Mob_Living_SimpleAnimal_Hostile_Poison_GiantSpider_Hunter( M.loc );
							} else if ( _=="blobbernaut" ) {
								new_mob = new Mob_Living_SimpleAnimal_Hostile_Blob_Blobbernaut( M.loc );
							} else if ( _=="magicarp" ) {
								new_mob = new Mob_Living_SimpleAnimal_Hostile_Carp_Ranged( M.loc );
							} else if ( _=="chaosmagicarp" ) {
								new_mob = new Mob_Living_SimpleAnimal_Hostile_Carp_Ranged_Chaos( M.loc );
							};
						} else {
							animal = Rand.pick(new object [] { "parrot", "corgi", "crab", "pug", "cat", "mouse", "chicken", "cow", "lizard", "chick", "fox", "butterfly" });
							dynamic _ = animal; // Was a switch-case, sorry for the mess.
							if ( _=="parrot" ) {
								new_mob = new Mob_Living_SimpleAnimal_Parrot( M.loc );
							} else if ( _=="corgi" ) {
								new_mob = new Mob_Living_SimpleAnimal_Pet_Dog_Corgi( M.loc );
							} else if ( _=="crab" ) {
								new_mob = new Mob_Living_SimpleAnimal_Crab( M.loc );
							} else if ( _=="pug" ) {
								new_mob = new Mob_Living_SimpleAnimal_Pet_Dog_Pug( M.loc );
							} else if ( _=="cat" ) {
								new_mob = new Mob_Living_SimpleAnimal_Pet_Cat( M.loc );
							} else if ( _=="mouse" ) {
								new_mob = new Mob_Living_SimpleAnimal_Mouse( M.loc );
							} else if ( _=="chicken" ) {
								new_mob = new Mob_Living_SimpleAnimal_Chicken( M.loc );
							} else if ( _=="cow" ) {
								new_mob = new Mob_Living_SimpleAnimal_Cow( M.loc );
							} else if ( _=="lizard" ) {
								new_mob = new Mob_Living_SimpleAnimal_Lizard( M.loc );
							} else if ( _=="fox" ) {
								new_mob = new Mob_Living_SimpleAnimal_Pet_Fox( M.loc );
							} else if ( _=="butterfly" ) {
								new_mob = new Mob_Living_SimpleAnimal_Butterfly( M.loc );
							} else {
								new_mob = new Mob_Living_SimpleAnimal_Chick( M.loc );
							};
						}
						new_mob.languages |= 1;
					} else if ( _=="humanoid" ) {
						new_mob = new Mob_Living_Carbon_Human( M.loc );
						A = new Preferences();
						A.copy_to.BTCall( new ByTable().set( "icon_updates", 0 ).set( 1, new_mob ) );
						H = new_mob;
						if ( Misc13.isValid( Rand.chance( 50 ) ) ) {
							all_species = new ByTable();
							speciestype = null;
							foreach (dynamic _ in Misc13.types( typeof(Species) ) - typeof(Species) ) {
								speciestype = _;
								S = speciestype();
								if ( !Misc13.isValid( S.dangerous_existence ) ) {
									all_species += speciestype;
								}
							};
							H.set_species.BTCall( new ByTable().set( "icon_update", 0 ).set( 1, Rand.pick( all_species ) ) );
							H.real_name = H.dna.species.random_name( H.gender, 1 );
						}
						H.update_body();
						H.update_hair();
						H.update_mutcolor();
						H.dna.update_dna_identity();
					} else {
						return null;
					};
					new_mob.attack_log = M.attack_log;
					M.attack_log += "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>" + M.real_name + " (" + M.ckey + ") became " + new_mob.real_name + ".</font>";
					new_mob.a_intent = "harm";
					if ( Misc13.isValid( M.mind ) ) {
						M.mind.transfer_to( new_mob );
					} else {
						new_mob.key = M.key;
					}
					new_mob.write( "<B>Your form morphs into that of a " + randomize + ".</B>" );
					GlobalFuncs.qdel( M );
					return new_mob;
				}
			}
		}

		public static void warning( dynamic msg = null ) {
			Game.log.write( "## WARNING: " + msg );
		}

		public static dynamic wear_female_version( dynamic t_color = null, dynamic icon = null, dynamic layer = null, dynamic type = null ) {
			dynamic index = null;
			dynamic female_clothing_icon = null;
			dynamic standing = null;
			index = t_color;
			female_clothing_icon = GlobalVars.female_clothing_icons[index];
			if ( !Misc13.isValid( female_clothing_icon ) ) {
				GlobalFuncs.generate_female_clothing( index, t_color, icon, type );
			}
			standing = typeof(Image).BTNew( new ByTable().set( "layer", -layer ).set( "icon", GlobalVars.female_clothing_icons["" + t_color] ) );
			return standing;
		}

		public static dynamic worldtime2text(  ) {
			return GlobalFuncs.gameTimestamp( "hh:mm" );
		}

		public static dynamic Wrap( dynamic val = null, dynamic min = null, dynamic max = null ) {
			dynamic d = null;
			dynamic t = null;
			d = max - min;
			t = Misc13.round( ( val - min ) / d );
			return val - t * d;
		}

		public static void xgibs( dynamic location = null, dynamic viruses = null ) {
			new Ent_Effect_Gibspawner_Xeno( location, viruses );
		}

	}
}