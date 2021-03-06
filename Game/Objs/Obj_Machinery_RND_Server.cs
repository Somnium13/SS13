// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_RND_Server : Obj_Machinery_RND {

		public Research files = null;
		public int health = 100;
		public ByTable id_with_upload = new ByTable();
		public ByTable id_with_download = new ByTable();
		public string id_with_upload_string = "";
		public string id_with_download_string = "";
		public double? server_id = 0;
		public double heat_gen = 100;
		public int heating_power = 40000;
		public dynamic delay = 10;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 30 });
			this.icon_state = "server";
		}

		// Function from file: server.dm
		public Obj_Machinery_RND_Server ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable();
			this.component_parts.Add( new Obj_Item_Weapon_Circuitboard_Rdserver( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_ScanningModule( null ) );
			this.component_parts.Add( new Obj_Item_Stack_CableCoil( null, 1 ) );
			this.component_parts.Add( new Obj_Item_Stack_CableCoil( null, 1 ) );
			this.RefreshParts();
			this.initialize();
			return;
		}

		// Function from file: server.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( this.disabled ) {
				return null;
			}

			if ( this.shocked ) {
				this.shock( a, 50 );
			}
			return null;
		}

		// Function from file: server.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( this.disabled ) {
				return null;
			}

			if ( this.shocked ) {
				this.shock( user, 50 );
			}

			if ( this.default_deconstruction_screwdriver( user, "server_o", "server", A ) ) {
				return null;
			}

			if ( this.exchange_parts( user, A ) ) {
				return null;
			}

			if ( Lang13.Bool( this.panel_open ) ) {
				
				if ( A is Obj_Item_Weapon_Crowbar ) {
					this.griefProtection();
					this.default_deconstruction_crowbar( A );
					return 1;
				}
			}
			return null;
		}

		// Function from file: server.dm
		public void produce_heat( double heat_amt = 0 ) {
			Ent_Static L = null;
			GasMixture env = null;
			double transfer_moles = 0;
			GasMixture removed = null;
			double? heat_capacity = null;

			
			if ( !( ( this.stat & 3 ) != 0 ) ) {
				L = this.loc;

				if ( L is Tile_Simulated ) {
					env = L.return_air();

					if ( Convert.ToDouble( env.temperature ) < heat_amt + 273.41 ) {
						transfer_moles = env.total_moles() * 0.25;
						removed = env.remove( transfer_moles );

						if ( removed != null ) {
							heat_capacity = removed.heat_capacity();

							if ( heat_capacity == 0 || heat_capacity == null ) {
								heat_capacity = 1;
							}
							removed.temperature = Num13.MinInt( Convert.ToInt32( ( removed.temperature * heat_capacity + this.heating_power ) / heat_capacity ), 1000 );
						}
						env.merge( removed );
						this.air_update_turf();
					}
				}
			}
			return;
		}

		// Function from file: server.dm
		public void griefProtection(  ) {
			Obj_Machinery_RND_Server_Centcom C = null;
			dynamic v = null;
			Tech T = null;
			dynamic v2 = null;
			dynamic D = null;

			
			foreach (dynamic _c in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_RND_Server_Centcom) )) {
				C = _c;
				

				foreach (dynamic _a in Lang13.Enumerate( this.files.known_tech )) {
					v = _a;
					
					T = this.files.known_tech[v];
					C.files.AddTech2Known( T );
				}

				foreach (dynamic _b in Lang13.Enumerate( this.files.known_designs )) {
					v2 = _b;
					
					D = this.files.known_designs[v2];
					C.files.AddDesign2Known( D );
				}
				C.files.RefreshResearch();
			}
			return;
		}

		// Function from file: server.dm
		public override bool blob_act( dynamic severity = null ) {
			this.griefProtection();
			base.blob_act( (object)(severity) );
			return false;
		}

		// Function from file: server.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			this.griefProtection();
			base.ex_act( severity, (object)(target) );
			return false;
		}

		// Function from file: server.dm
		public override double emp_act( int severity = 0 ) {
			this.griefProtection();
			base.emp_act( severity );
			return 0;
		}

		// Function from file: server.dm
		public override int? process( dynamic seconds = null ) {
			GasMixture environment = null;
			int updateRD = 0;
			dynamic v = null;
			dynamic T = null;

			environment = this.loc.return_air();

			dynamic _a = environment.temperature; // Was a switch-case, sorry for the mess.
			if ( 0<=_a&&_a<=273.41 ) {
				this.health = Num13.MinInt( 100, this.health + 1 );
			} else if ( 273.41<=_a&&_a<=313.41 ) {
				this.health = Num13.MaxInt( 0, Num13.MinInt( this.health, 100 ) );
			} else if ( 313.41<=_a&&_a<=343.41 ) {
				this.health = Num13.MaxInt( 0, this.health - 1 );
			}

			if ( this.health <= 0 ) {
				updateRD = 0;
				this.files.known_designs = new ByTable();

				foreach (dynamic _b in Lang13.Enumerate( this.files.known_tech )) {
					v = _b;
					
					T = this.files.known_tech[v];

					if ( Rand13.PercentChance( 1 ) ) {
						updateRD++;
						T.level--;
					}
				}

				if ( updateRD != 0 ) {
					this.files.RefreshResearch();
				}
			}

			if ( Lang13.Bool( this.delay ) ) {
				this.delay--;
			} else {
				this.produce_heat( this.heat_gen );
				this.delay = Lang13.Initial( this, "delay" );
			}
			return null;
		}

		// Function from file: server.dm
		public override void initialize(  ) {
			ByTable temp_list = null;
			dynamic N = null;
			dynamic N2 = null;

			
			if ( !( this.files != null ) ) {
				this.files = new Research(  );
			}

			if ( !( this.id_with_upload.len != 0 ) ) {
				temp_list = new ByTable();
				temp_list = GlobalFuncs.splittext( this.id_with_upload_string, ";" );

				foreach (dynamic _a in Lang13.Enumerate( temp_list )) {
					N = _a;
					
					this.id_with_upload.Add( String13.ParseNumber( N ) );
				}
			}

			if ( !( this.id_with_download.len != 0 ) ) {
				temp_list = new ByTable();
				temp_list = GlobalFuncs.splittext( this.id_with_download_string, ";" );

				foreach (dynamic _b in Lang13.Enumerate( temp_list )) {
					N2 = _b;
					
					this.id_with_download.Add( String13.ParseNumber( N2 ) );
				}
			}
			return;
		}

		// Function from file: server.dm
		public override void RefreshParts(  ) {
			double tot_rating = 0;
			Obj_Item_Weapon_StockParts SP = null;

			tot_rating = 0;

			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj_Item_Weapon_StockParts) )) {
				SP = _a;
				
				tot_rating += Convert.ToDouble( SP.rating );
			}
			this.heat_gen /= Num13.MaxInt( 1, ((int)( tot_rating )) );
			return;
		}

		// Function from file: server.dm
		public override dynamic Destroy(  ) {
			this.griefProtection();
			return base.Destroy();
		}

		// Function from file: ninjaDrainAct.dm
		public override dynamic ninjadrain_act( Obj_Item_Clothing_Suit_Space_SpaceNinja S = null, Ent_Static H = null, Obj_Item_Clothing_Gloves_SpaceNinja G = null ) {
			dynamic _default = null;

			dynamic location = null;
			Mob_Living_Silicon_Ai AI = null;
			Tech current_data = null;
			Tech analyzing_data = null;

			
			if ( !( S != null ) || !( H != null ) || !( G != null ) ) {
				return "INVALID";
			}
			_default = "RDHACKFAIL";
			((dynamic)H).WriteMsg( new Txt( "<span class='notice'>Hacking " ).the( this ).item().str( "...</span>" ).ToString() );
			Task13.Schedule( 0, (Task13.Closure)(() => {
				location = GlobalFuncs.get_turf( H );

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon_Ai) )) {
					AI = _a;
					
					AI.WriteMsg( "<span class='userdanger'>Network Alert: Hacking attempt detected" + ( Lang13.Bool( location ) ? " in " + location : ". Unable to pinpoint location" ) + "</span>." );
				}
				return;
			}));

			if ( this.files != null && this.files.known_tech.len != 0 ) {
				
				foreach (dynamic _c in Lang13.Enumerate( S.stored_research, typeof(Tech) )) {
					current_data = _c;
					
					((dynamic)H).WriteMsg( new Txt( "<span class='notice'>Checking " ).the( current_data.name ).item().str( " database.</span>" ).ToString() );

					if ( GlobalFuncs.do_after( H, S.s_delay, null, this ) && G.candrain && this != null ) {
						
						foreach (dynamic _b in Lang13.Enumerate( this.files.known_tech, typeof(Tech) )) {
							analyzing_data = _b;
							

							if ( current_data.id == analyzing_data.id ) {
								
								if ( analyzing_data.level > current_data.level ) { 
									((dynamic)H).WriteMsg( "<span class='notice'>Database:</span> <b>UPDATED</b>." );
									current_data.level = analyzing_data.level;
									_default = "RDHACK";
								}
								break;
							}
						}
					} else {
						break;
					}
				}
			}
			((dynamic)H).WriteMsg( "<span class='notice'>Data analyzed. Process finished.</span>" );
			return _default;
		}

	}

}