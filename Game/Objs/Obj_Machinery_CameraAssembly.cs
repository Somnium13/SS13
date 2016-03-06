// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_CameraAssembly : Obj_Machinery {

		public ByTable possible_upgrades = new ByTable(new object [] { typeof(Obj_Item_Device_Assembly_ProxSensor), typeof(Obj_Item_Stack_Sheet_Mineral_Plasma), typeof(Obj_Item_Device_Analyzer) });
		public ByTable upgrades = new ByTable();
		public int state = 1;
		public bool busy = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/monitors.dmi";
			this.icon_state = "camera1";
		}

		// Function from file: camera_assembly.dm
		public Obj_Machinery_CameraAssembly ( dynamic loc = null, dynamic ndir = null, dynamic building = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Lang13.Bool( building ) ) {
				this.dir = Convert.ToInt32( ndir );
			}
			return;
		}

		// Function from file: camera_assembly.dm
		public bool weld( dynamic WT = null, dynamic user = null ) {
			
			if ( this.busy ) {
				return false;
			}

			if ( !((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 0, user ) ) {
				return false;
			}
			user.WriteMsg( new Txt( "<span class='notice'>You start to weld " ).the( this ).item().str( "...</span>" ).ToString() );
			GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 50, 1 );
			this.busy = true;

			if ( GlobalFuncs.do_after( user, 20, null, this ) ) {
				this.busy = false;

				if ( !((Obj_Item_Weapon_Weldingtool)WT).isOn() ) {
					return false;
				}
				return true;
			}
			this.busy = false;
			return false;
		}

		// Function from file: camera_assembly.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic C = null;
			string input = null;
			ByTable tempnetwork = null;
			Obj_Machinery_Camera C2 = null;
			dynamic A2 = null;
			dynamic U = null;

			
			switch ((int)( this.state )) {
				case 1:
					
					if ( A is Obj_Item_Weapon_Weldingtool ) {
						
						if ( this.weld( A, user ) ) {
							user.WriteMsg( "<span class='notice'>You weld the assembly securely into place.</span>" );
							this.anchored = 1;
							this.state = 2;
						}
						return null;
					} else if ( A is Obj_Item_Weapon_Wrench ) {
						GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 50, 1 );
						user.WriteMsg( "<span class='notice'>You unattach the assembly from its place.</span>" );
						new Obj_Item_Wallframe_Camera( GlobalFuncs.get_turf( this ) );
						GlobalFuncs.qdel( this );
						return null;
					}
					break;
				case 2:
					
					if ( A is Obj_Item_Stack_CableCoil ) {
						C = A;

						if ( Lang13.Bool( C.use( 2 ) ) ) {
							user.WriteMsg( "<span class='notice'>You add wires to the assembly.</span>" );
							this.state = 3;
						} else {
							user.WriteMsg( "<span class='warning'>You need two lengths of cable to wire a camera!</span>" );
							return null;
						}
						return null;
					} else if ( A is Obj_Item_Weapon_Weldingtool ) {
						
						if ( this.weld( A, user ) ) {
							user.WriteMsg( "<span class='notice'>You unweld the assembly from its place.</span>" );
							this.state = 1;
							this.anchored = 1;
						}
						return null;
					}
					break;
				case 3:
					
					if ( A is Obj_Item_Weapon_Screwdriver ) {
						GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 50, 1 );
						input = GlobalFuncs.stripped_input( Task13.User, "Which networks would you like to connect this camera to? Seperate networks with a comma. No Spaces!\nFor example: SS13,Security,Secret ", "Set Network", "SS13" );

						if ( !Lang13.Bool( input ) ) {
							Task13.User.WriteMsg( "<span class='warning'>No input found, please hang up and try your call again!</span>" );
							return null;
						}
						tempnetwork = GlobalFuncs.splittext( input, "," );

						if ( tempnetwork.len < 1 ) {
							Task13.User.WriteMsg( "<span class='warning'>No network found, please hang up and try your call again!</span>" );
							return null;
						}
						this.state = 4;
						C2 = new Obj_Machinery_Camera( this.loc );
						this.loc = C2;
						C2.assembly = this;
						C2.dir = this.dir;
						C2.network = tempnetwork;
						A2 = GlobalFuncs.get_area_master( this );
						C2.c_tag = "" + A2.name + " (" + Rand13.Int( 1, 999 ) + ")";
					} else if ( A is Obj_Item_Weapon_Wirecutters ) {
						new Obj_Item_Stack_CableCoil( GlobalFuncs.get_turf( this ), 2 );
						GlobalFuncs.playsound( this.loc, "sound/items/Wirecutter.ogg", 50, 1 );
						user.WriteMsg( "<span class='notice'>You cut the wires from the circuits.</span>" );
						this.state = 2;
						return null;
					}
					break;
			}

			if ( GlobalFuncs.is_type_in_list( A, this.possible_upgrades ) && !GlobalFuncs.is_type_in_list( A, this.upgrades ) ) {
				
				if ( !((Mob)user).unEquip( A ) ) {
					return null;
				}
				user.WriteMsg( new Txt( "<span class='notice'>You attach " ).the( A ).item().str( " into the assembly inner circuits.</span>" ).ToString() );
				this.upgrades.Add( A );
				A.loc = this;
				return null;
			} else if ( A is Obj_Item_Weapon_Crowbar && this.upgrades.len != 0 ) {
				U = Lang13.FindIn( typeof(Obj), this.upgrades );

				if ( Lang13.Bool( U ) ) {
					user.WriteMsg( "<span class='notice'>You unattach an upgrade from the assembly.</span>" );
					GlobalFuncs.playsound( this.loc, "sound/items/Crowbar.ogg", 50, 1 );
					U.loc = GlobalFuncs.get_turf( this );
					this.upgrades.Remove( U );
				}
				return null;
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

	}

}