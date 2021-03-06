// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_DnaScannernew : Obj_Machinery {

		public bool locked = false;
		public dynamic damage_coeff = null;
		public double scan_level = 0;
		public dynamic precision_coeff = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 50;
			this.active_power_usage = 300;
			this.icon = "icons/obj/Cryogenic2.dmi";
			this.icon_state = "scanner";
		}

		// Function from file: dna_scanner.dm
		public Obj_Machinery_DnaScannernew ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable();
			this.component_parts.Add( new Obj_Item_Weapon_Circuitboard_Clonescanner( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_ScanningModule( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_Manipulator( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_MicroLaser( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_ConsoleScreen( null ) );
			this.component_parts.Add( new Obj_Item_Stack_CableCoil( null, 1 ) );
			this.component_parts.Add( new Obj_Item_Stack_CableCoil( null, 1 ) );
			this.RefreshParts();
			return;
		}

		// Function from file: dna_scanner.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( Lang13.Bool( base.attack_hand( (object)(a), true, false ) ) ) {
				return null;
			}
			this.toggle_open( a );
			return null;
		}

		// Function from file: dna_scanner.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic G = null;
			Ent_Static M = null;

			
			if ( !Lang13.Bool( this.occupant ) && this.default_deconstruction_screwdriver( user, this.icon_state, this.icon_state, A ) ) {
				this.update_icon();
				return null;
			}

			if ( this.exchange_parts( user, A ) ) {
				return null;
			}

			if ( this.default_pry_open( A ) ) {
				return null;
			}

			if ( this.default_deconstruction_crowbar( A ) ) {
				return null;
			}

			if ( A is Obj_Item_Weapon_Grab ) {
				G = A;

				if ( !( G.affecting is Mob ) ) {
					return null;
				}

				if ( !Lang13.Bool( this.state_open ) ) {
					user.WriteMsg( "<span class='notice'>Open the scanner first.</span>" );
					return null;
				}
				M = G.affecting;
				M.loc = this.loc;
				user.__CallVerb("Stop Pulling" );
				GlobalFuncs.qdel( G );
			}
			return null;
		}

		// Function from file: dna_scanner.dm
		public override bool relaymove( Mob user = null, int? direction = null ) {
			
			if ( user.stat != 0 || this.locked ) {
				return false;
			}
			this.open_machine();
			return false;
		}

		// Function from file: dna_scanner.dm
		public override bool open_machine( int? dump = null ) {
			
			if ( Lang13.Bool( this.state_open ) ) {
				return false;
			}
			base.open_machine( dump );
			return true;
		}

		// Function from file: dna_scanner.dm
		public override dynamic close_machine( Ent_Static target = null ) {
			dynamic console = null;

			
			if ( !Lang13.Bool( this.state_open ) ) {
				return 0;
			}
			base.close_machine( target );

			if ( Lang13.Bool( this.occupant ) ) {
				
				if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Machinery_Computer_Cloning), Map13.GetStep( this, ((int)( GlobalVars.NORTH )) ) ) ) || Lang13.Bool( Lang13.FindIn( typeof(Obj_Machinery_Computer_Cloning), Map13.GetStep( this, ((int)( GlobalVars.SOUTH )) ) ) ) || Lang13.Bool( Lang13.FindIn( typeof(Obj_Machinery_Computer_Cloning), Map13.GetStep( this, ((int)( GlobalVars.EAST )) ) ) ) || Lang13.Bool( Lang13.FindIn( typeof(Obj_Machinery_Computer_Cloning), Map13.GetStep( this, ((int)( GlobalVars.WEST )) ) ) ) ) {
					
					if ( !Lang13.Bool( this.occupant.suiciding ) && !Lang13.Bool( this.occupant.disabilities & 128 ) ) {
						((Mob)this.occupant).notify_ghost_cloning( "Your corpse has been placed into a cloning scanner. Re-enter your corpse if you want to be cloned!", null, this );
					}
				}

				foreach (dynamic _a in Lang13.Enumerate( new ByTable(new object [] { GlobalVars.NORTH, GlobalVars.EAST, GlobalVars.SOUTH, GlobalVars.WEST }) )) {
					this.dir = Convert.ToInt32( _a );
					
					console = Lang13.FindIn( typeof(Obj_Machinery_Computer_ScanConsolenew), Map13.GetStep( this, this.dir ) );

					if ( Lang13.Bool( console ) ) {
						((Obj_Machinery_Computer_ScanConsolenew)console).on_scanner_close();
						break;
					}
				}
			}
			return 1;
		}

		// Function from file: dna_scanner.dm
		public override void container_resist( Mob user = null ) {
			Mob user2 = null;
			int breakout_time = 0;

			user2 = Task13.User;
			breakout_time = 2;

			if ( Lang13.Bool( this.state_open ) || !this.locked ) {
				this.state_open = 1;
				return;
			}
			user2.changeNext_move( 100 );
			((dynamic)user2).last_special = Game13.time + 100;
			user2.WriteMsg( "<span class='notice'>You lean on the back of " + this + " and start pushing the door open... (this will take about " + breakout_time + " minutes.)</span>" );
			user2.visible_message( "<span class='italics'>You hear a metallic creaking from " + this + "!</span>" );

			if ( GlobalFuncs.do_after( user2, breakout_time * 600, null, this ) ) {
				
				if ( !( user2 != null ) || user2.stat != 0 || user2.loc != this || Lang13.Bool( this.state_open ) || !this.locked ) {
					return;
				}
				this.locked = false;
				this.visible_message( "<span class='warning'>" + user2 + " successfully broke out of " + this + "!</span>" );
				user2.WriteMsg( "<span class='notice'>You successfully break out of " + this + "!</span>" );
				this.open_machine();
			}
			return;
		}

		// Function from file: dna_scanner.dm
		public void toggle_open( dynamic user = null ) {
			
			if ( Lang13.Bool( this.panel_open ) ) {
				user.WriteMsg( "<span class='notice'>Close the maintenance panel first.</span>" );
				return;
			}

			if ( Lang13.Bool( this.state_open ) ) {
				this.close_machine();
				return;
			} else if ( this.locked ) {
				user.WriteMsg( "<span class='notice'>The bolts are locked down, securing the door shut.</span>" );
				return;
			}
			this.open_machine();
			return;
		}

		// Function from file: dna_scanner.dm
		public override void power_change(  ) {
			base.power_change();
			this.update_icon();
			return;
		}

		// Function from file: dna_scanner.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( ( this.stat & 3 ) != 0 ) {
				this.icon_state = Lang13.Initial( this, "icon_state" ) + ( Lang13.Bool( this.state_open ) ? "_open" : "" ) + "_unpowered";
				return false;
			}

			if ( ( this.stat & 8 ) != 0 || Lang13.Bool( this.panel_open ) ) {
				this.icon_state = Lang13.Initial( this, "icon_state" ) + ( Lang13.Bool( this.state_open ) ? "_open" : "" ) + "_maintenance";
				return false;
			}

			if ( Lang13.Bool( this.occupant ) ) {
				this.icon_state = Lang13.Initial( this, "icon_state" ) + "_occupied";
				return false;
			}
			this.icon_state = Lang13.Initial( this, "icon_state" ) + ( Lang13.Bool( this.state_open ) ? "_open" : "" );
			return false;
		}

		// Function from file: dna_scanner.dm
		public override void RefreshParts(  ) {
			Obj_Item_Weapon_StockParts_ScanningModule P = null;
			Obj_Item_Weapon_StockParts_Manipulator P2 = null;
			Obj_Item_Weapon_StockParts_MicroLaser P3 = null;

			this.scan_level = 0;
			this.damage_coeff = 0;
			this.precision_coeff = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_ScanningModule) )) {
				P = _a;
				
				this.scan_level += Convert.ToDouble( P.rating );
			}

			foreach (dynamic _b in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_Manipulator) )) {
				P2 = _b;
				
				this.precision_coeff = P2.rating;
			}

			foreach (dynamic _c in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_MicroLaser) )) {
				P3 = _c;
				
				this.damage_coeff = P3.rating;
			}
			return;
		}

	}

}