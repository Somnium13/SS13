// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_AirSensor : Obj_Machinery {

		public bool on = true;
		public dynamic id_tag = null;
		public double frequency = 1441;
		public RadioFrequency radio_connection = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon_state = "gsensor1";
		}

		// Function from file: atmos_control.dm
		public Obj_Machinery_AirSensor ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.SSair.atmos_machinery.Add( this );

			if ( GlobalVars.SSradio != null ) {
				this.set_frequency( this.frequency );
			}
			return;
		}

		// Function from file: atmos_control.dm
		public override dynamic Destroy(  ) {
			GlobalVars.SSair.atmos_machinery.Remove( this );

			if ( GlobalVars.SSradio != null ) {
				GlobalVars.SSradio.remove_object( this, this.frequency );
			}
			return base.Destroy();
		}

		// Function from file: atmos_control.dm
		public override void initialize(  ) {
			this.set_frequency( this.frequency );
			return;
		}

		// Function from file: atmos_control.dm
		public void set_frequency( double new_frequency = 0 ) {
			GlobalVars.SSradio.remove_object( this, this.frequency );
			this.frequency = new_frequency;
			this.radio_connection = GlobalVars.SSradio.add_object( this, this.frequency, GlobalVars.RADIO_ATMOSIA );
			return;
		}

		// Function from file: atmos_control.dm
		public override int? process_atmos(  ) {
			Signal signal = null;
			GasMixture air_sample = null;
			double total_moles = 0;
			dynamic gas_id = null;
			dynamic gas_name = null;

			
			if ( this.on ) {
				signal = new Signal();
				air_sample = this.return_air();
				signal.transmission_method = 1;
				signal.data = new ByTable()
					.Set( "sigtype", "status" )
					.Set( "id_tag", this.id_tag )
					.Set( "timestamp", Game13.time )
					.Set( "pressure", air_sample.return_pressure() )
					.Set( "temperature", air_sample.temperature )
					.Set( "gases", new ByTable() )
				;
				total_moles = air_sample.total_moles();

				foreach (dynamic _a in Lang13.Enumerate( air_sample.gases )) {
					gas_id = _a;
					
					gas_name = air_sample.gases[gas_id][3][2];
					signal.data["gases"][gas_name] = air_sample.gases[gas_id][1] / total_moles * 100;
				}
				this.radio_connection.post_signal( this, signal, GlobalVars.RADIO_ATMOSIA );
			}
			return null;
		}

		// Function from file: atmos_control.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.icon_state = "gsensor" + this.on;
			return false;
		}

	}

}