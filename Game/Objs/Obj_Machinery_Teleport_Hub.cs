// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Teleport_Hub : Obj_Machinery_Teleport {

		public double accurate = 0;
		public dynamic power_station = null;
		public bool calibrated = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.idle_power_usage = 10;
			this.active_power_usage = 2000;
			this.icon_state = "tele0";
		}

		// Function from file: teleporter.dm
		public Obj_Machinery_Teleport_Hub ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.link_power_station();
			this.component_parts = new ByTable();
			this.component_parts.Add( new Obj_Item_Weapon_Circuitboard_TeleporterHub( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_Ore_BluespaceCrystal_Artificial( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_Ore_BluespaceCrystal_Artificial( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_Ore_BluespaceCrystal_Artificial( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_MatterBin( null ) );
			this.RefreshParts();
			return;
		}

		// Function from file: teleporter.dm
		public override void power_change(  ) {
			base.power_change();
			this.update_icon();
			return;
		}

		// Function from file: teleporter.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( Lang13.Bool( this.panel_open ) ) {
				this.icon_state = "tele-o";
			} else if ( this.is_ready() ) {
				this.icon_state = "tele1";
			} else {
				this.icon_state = "tele0";
			}
			return false;
		}

		// Function from file: teleporter.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( this.default_deconstruction_screwdriver( user, "tele-o", "tele0", A ) ) {
				return null;
			}

			if ( this.exchange_parts( user, A ) ) {
				return null;
			}
			this.default_deconstruction_crowbar( A );
			return null;
		}

		// Function from file: teleporter.dm
		public override bool Bumped( dynamic AM = null ) {
			
			if ( this.z == 2 ) {
				AM.WriteMsg( "You can't use this here." );
			}

			if ( this.is_ready() ) {
				this.teleport( AM );
				this.f_use_power( 5000 );
			}
			return false;
		}

		// Function from file: teleporter.dm
		public bool is_ready(  ) {
			bool _default = false;

			_default = !Lang13.Bool( this.panel_open ) && !( ( this.stat & 3 ) != 0 ) && Lang13.Bool( this.power_station ) && Lang13.Bool( this.power_station.engaged ) && !Lang13.Bool( this.power_station.stat & 3 );
			return _default;
		}

		// Function from file: teleporter.dm
		public void teleport( dynamic M = null, dynamic T = null ) {
			dynamic com = null;
			dynamic human = null;

			com = this.power_station.teleporter_console;

			if ( !Lang13.Bool( com ) ) {
				return;
			}

			if ( !Lang13.Bool( com.target ) ) {
				this.visible_message( "<span class='alert'>Cannot authenticate locked on coordinates. Please reinstate coordinate matrix.</span>" );
				return;
			}

			if ( M is Ent_Dynamic ) {
				
				if ( GlobalFuncs.do_teleport( M, com.target ) ) {
					
					if ( !this.calibrated && Rand13.PercentChance( ((int)( 30 - this.accurate * 10 )) ) ) {
						
						if ( M is Mob_Living_Carbon_Human ) {
							human = M;

							if ( Lang13.Bool( human.dna ) && human.dna.species.id == "human" ) {
								M.WriteMsg( "<span class='italics'>You hear a buzzing in your ears.</span>" );
								((Mob)human).set_species( typeof(Species_Fly) );
							}
							((Mob_Living)human).apply_effect( Rand13.Int( ((int)( 120 - this.accurate * 40 )), ((int)( 180 - this.accurate * 60 )) ), "irradiate", 0 );
						}
					}
					this.calibrated = false;
				}
			}
			return;
		}

		// Function from file: teleporter.dm
		public dynamic link_power_station(  ) {
			
			if ( Lang13.Bool( this.power_station ) ) {
				return null;
			}

			foreach (dynamic _a in Lang13.Enumerate( new ByTable(new object [] { GlobalVars.NORTH, GlobalVars.EAST, GlobalVars.SOUTH, GlobalVars.WEST }) )) {
				this.dir = Convert.ToInt32( _a );
				
				this.power_station = Lang13.FindIn( typeof(Obj_Machinery_Teleport_Station), Map13.GetStep( this, this.dir ) );

				if ( Lang13.Bool( this.power_station ) ) {
					break;
				}
			}
			return this.power_station;
		}

		// Function from file: teleporter.dm
		public override void RefreshParts(  ) {
			double A = 0;
			Obj_Item_Weapon_StockParts_MatterBin M = null;

			A = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_MatterBin) )) {
				M = _a;
				
				A += Convert.ToDouble( M.rating );
			}
			this.accurate = A;
			return;
		}

		// Function from file: teleporter.dm
		public override dynamic Destroy(  ) {
			
			if ( Lang13.Bool( this.power_station ) ) {
				this.power_station.teleporter_hub = null;
				this.power_station = null;
			}
			return base.Destroy();
		}

		// Function from file: teleporter.dm
		public override void initialize(  ) {
			this.link_power_station();
			return;
		}

		// Function from file: observer.dm
		public override void attack_ghost( Mob user = null ) {
			Ent_Static l = null;
			dynamic com = null;

			l = this.loc;
			com = Lang13.FindIn( typeof(Obj_Machinery_Computer_Teleporter), Map13.GetTile( l.x - 2, l.y, l.z ) );

			if ( Lang13.Bool( com ) && Lang13.Bool( com.locked ) ) {
				user.loc = GlobalFuncs.get_turf( com.locked );
			}
			return;
		}

	}

}