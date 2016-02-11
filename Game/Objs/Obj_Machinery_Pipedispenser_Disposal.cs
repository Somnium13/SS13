// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Pipedispenser_Disposal : Obj_Machinery_Pipedispenser {

		// Function from file: pipe_dispenser.dm
		public Obj_Machinery_Pipedispenser_Disposal ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable(new object [] { 
				new Obj_Item_Weapon_Circuitboard_Pipedispenser_Disposal(), 
				new Obj_Item_Weapon_StockParts_MatterBin(), 
				new Obj_Item_Weapon_StockParts_MatterBin(), 
				new Obj_Item_Weapon_StockParts_Capacitor(), 
				new Obj_Item_Weapon_StockParts_ScanningModule(), 
				new Obj_Item_Weapon_StockParts_ScanningModule(), 
				new Obj_Item_Weapon_StockParts_Manipulator(), 
				new Obj_Item_Weapon_StockParts_Manipulator()
			 });
			this.RefreshParts();
			return;
		}

		// Function from file: pipe_dispenser.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			double? p_type = null;
			Obj_Structure_Disposalconstruct C = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}
			Task13.User.set_machine( this );
			this.add_fingerprint( Task13.User );

			if ( Lang13.Bool( href_list["dmake"] ) ) {
				
				if ( !Lang13.Bool( this.anchored ) || !Task13.User.canmove || Lang13.Bool( Task13.User.stat ) || Task13.User.restrained() || !GlobalFuncs.in_range( this.loc, Task13.User ) ) {
					Interface13.Browse( Task13.User, null, "window=pipedispenser" );
					return null;
				}

				if ( !this.wait ) {
					p_type = String13.ParseNumber( href_list["dmake"] );
					C = new Obj_Structure_Disposalconstruct( this.loc );

					switch ((int?)( p_type )) {
						case 0:
							C.ptype = 0;
							break;
						case 1:
							C.ptype = 1;
							break;
						case 2:
							C.ptype = 2;
							break;
						case 3:
							C.ptype = 4;
							break;
						case 4:
							C.ptype = 5;
							break;
						case 5:
							C.ptype = 6;
							C.density = true;
							break;
						case 6:
							C.ptype = 7;
							C.density = true;
							break;
						case 7:
							C.ptype = 8;
							C.density = true;
							break;
					}
					C.add_fingerprint( Task13.User );
					C.update();
					this.wait = true;
					Task13.Schedule( 15, (Task13.Closure)(() => {
						this.wait = false;
						return;
					}));
				}
			}
			return null;
		}

		// Function from file: pipe_dispenser.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string dat = null;

			
			if ( Lang13.Bool( base.attack_hand( (object)(a), (object)(b), (object)(c) ) ) ) {
				return null;
			}
			dat = new Txt( "<b>Disposal Pipes</b><br><br>\n<A href='?src=" ).Ref( this ).str( ";dmake=" ).item( 0 ).str( "'>Pipe</A><BR>\n<A href='?src=" ).Ref( this ).str( ";dmake=" ).item( 1 ).str( "'>Bent Pipe</A><BR>\n<A href='?src=" ).Ref( this ).str( ";dmake=" ).item( 2 ).str( "'>Junction</A><BR>\n<A href='?src=" ).Ref( this ).str( ";dmake=" ).item( 3 ).str( "'>Y-Junction</A><BR>\n<A href='?src=" ).Ref( this ).str( ";dmake=" ).item( 4 ).str( "'>Trunk</A><BR>\n<A href='?src=" ).Ref( this ).str( ";dmake=" ).item( 5 ).str( "'>Bin</A><BR>\n<A href='?src=" ).Ref( this ).str( ";dmake=" ).item( 6 ).str( "'>Outlet</A><BR>\n<A href='?src=" ).Ref( this ).str( ";dmake=" ).item( 7 ).str( "'>Chute</A><BR>\n" ).ToString();
			Interface13.Browse( a, "<HEAD><TITLE>" + this + "</TITLE></HEAD><TT>" + dat + "</TT>", "window=pipedispenser" );
			return null;
		}

		// Function from file: pipe_dispenser.dm
		public override bool MouseDrop_T( Ent_Static O = null, dynamic user = null, bool? needs_opened = null, bool? show_message = null, bool? move_them = null ) {
			
			if ( !user.canmove || Lang13.Bool( user.stat ) || ((Mob)user).restrained() ) {
				return false;
			}

			if ( !( O is Obj_Structure_Disposalconstruct ) || Map13.GetDistance( user, this ) > 1 || Map13.GetDistance( this, O ) > 2 ) {
				return false;
			}

			if ( Lang13.Bool( ((dynamic)O).anchored ) ) {
				return false;
			}
			GlobalFuncs.qdel( O );
			return false;
		}

	}

}