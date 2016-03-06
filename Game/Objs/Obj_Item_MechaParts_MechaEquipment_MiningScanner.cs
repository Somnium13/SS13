// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_MiningScanner : Obj_Item_MechaParts_MechaEquipment {

		public bool scanning = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "materials=3;engineering=2";
			this.equip_cooldown = 30;
			this.icon_state = "mecha_analyzer";
		}

		// Function from file: mining_tools.dm
		public Obj_Item_MechaParts_MechaEquipment_MiningScanner ( dynamic loc = null ) : base( (object)(loc) ) {
			GlobalVars.SSobj.processing.Or( this );
			return;
		}

		// Function from file: mining_tools.dm
		public override int? process( dynamic seconds = null ) {
			Ent_Static mecha = null;
			ByTable L = null;

			
			if ( !( this.loc != null ) ) {
				GlobalVars.SSobj.processing.Remove( this );
				GlobalFuncs.qdel( this );
			}

			if ( this.scanning ) {
				return null;
			}

			if ( this.loc is Obj_Mecha_Working ) {
				mecha = this.loc;

				if ( !Lang13.Bool( ((dynamic)mecha).occupant ) ) {
					return null;
				}
				L = new ByTable(new object [] { ((dynamic)mecha).occupant });
				this.scanning = true;
				GlobalFuncs.mineral_scan_pulse( L, GlobalFuncs.get_turf( this.loc ) );
				Task13.Schedule( Convert.ToInt32( this.equip_cooldown ), (Task13.Closure)(() => {
					this.scanning = false;
					return;
				}));
			}
			return null;
		}

		// Function from file: mining_tools.dm
		public override void detach( dynamic moveto = null ) {
			this.chassis.occupant_sight_flags &= 65519;

			if ( this.chassis.occupant != null ) {
				((dynamic)this.chassis.occupant).update_sight();
			}
			base.detach( (object)(moveto) ); return;
		}

		// Function from file: mining_tools.dm
		public override void attach( Obj_Mecha M = null ) {
			base.attach( M );
			M.occupant_sight_flags |= GlobalVars.SEE_TURFS;

			if ( M.occupant != null ) {
				((dynamic)M.occupant).update_sight();
			}
			return;
		}

	}

}