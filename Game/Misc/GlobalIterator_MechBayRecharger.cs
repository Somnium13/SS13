// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GlobalIterator_MechBayRecharger : GlobalIterator {

		public double? max_charge = 45;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.delay = 20;
			this.check_for_null = false;
		}

		public GlobalIterator_MechBayRecharger ( ByTable arguments = null, bool? autostart = null ) : base( arguments, autostart ) {
			
		}

		// Function from file: mech_bay.dm
		public override bool process( Obj port = null, dynamic mecha = null ) {
			double delta = 0;

			
			if ( !( port != null ) ) {
				return false;
			}

			if ( Lang13.Bool( GlobalFuncs.get_turf( ((dynamic)port).recharge_floor ).Contains( Lang13.Bool( mecha ) && Lang13.Bool( mecha ) ) ) ) {
				
				if ( !Lang13.Bool( mecha.cell ) ) {
					return false;
				}
				delta = Num13.MinInt( ((int)( this.max_charge ??0 )), Convert.ToInt32( mecha.cell.maxcharge - mecha.cell.charge ) );

				if ( delta > 0 ) {
					((Obj_Mecha)mecha).give_power( delta );
					((Obj_Machinery)port).f_use_power( delta * 150 );
				} else {
					((Obj_Mecha)mecha).occupant_message( "<span class='notice'><b>Fully charged.</b></span>" );
					((dynamic)port).stop_charge();
				}
			} else {
				((dynamic)port).stop_charge();
			}
			return false;
		}

	}

}