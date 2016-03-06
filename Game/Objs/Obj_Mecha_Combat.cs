// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Mecha_Combat : Obj_Mecha {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 30;
			this.damage_absorption = new ByTable().Set( "brute", 061 ).Set( "fire", 1 ).Set( "bullet", 061 ).Set( "laser", 0.85 ).Set( "energy", 1 ).Set( "bomb", 0.8 );
		}

		public Obj_Mecha_Combat ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: combat.dm
		public override void go_out( bool? forced = null, Ent_Static newloc = null ) {
			
			if ( this.occupant != null && Lang13.Bool( ((dynamic)this.occupant).client ) ) {
				((dynamic)this.occupant).client.mouse_pointer_icon = Lang13.Initial( ((dynamic)this.occupant).client, "mouse_pointer_icon" );
			}
			base.go_out( forced, newloc );
			return;
		}

		// Function from file: combat.dm
		public override bool mmi_moved_inside( dynamic mmi_as_oc = null, dynamic user = null ) {
			
			if ( base.mmi_moved_inside( (object)(mmi_as_oc), (object)(user) ) ) {
				
				if ( Lang13.Bool( ((dynamic)this.occupant).client ) ) {
					((dynamic)this.occupant).client.mouse_pointer_icon = new File( "icons/mecha/mecha_mouse.dmi" );
				}
				return true;
			} else {
				return false;
			}
		}

		// Function from file: combat.dm
		public override bool moved_inside( Mob H = null ) {
			
			if ( base.moved_inside( H ) ) {
				
				if ( H.client != null ) {
					H.client.mouse_pointer_icon = new File( "icons/mecha/mecha_mouse.dmi" );
				}
				return true;
			} else {
				return false;
			}
		}

		// Function from file: combat.dm
		public override void CheckParts( Game_Data holder = null ) {
			dynamic C = null;
			dynamic SM = null;
			dynamic DR = null;

			C = Lang13.FindIn( typeof(Obj_Item_Weapon_StockParts_Capacitor), holder );
			SM = Lang13.FindIn( typeof(Obj_Item_Weapon_StockParts_ScanningModule), holder );
			this.step_energy_drain = 20 - Convert.ToDouble( SM.rating * 5 );
			DR = this.damage_absorption["energy"];
			this.damage_absorption["energy"] = DR - C.rating / 10;
			GlobalFuncs.qdel( C );
			GlobalFuncs.qdel( SM );
			return;
		}

	}

}