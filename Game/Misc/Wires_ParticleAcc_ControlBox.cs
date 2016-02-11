// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Wires_ParticleAcc_ControlBox : Wires_ParticleAcc {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.wire_count = 5;
			this.holder_type = typeof(Obj_Machinery_ParticleAccelerator_ControlBox);
		}

		public Wires_ParticleAcc_ControlBox ( Obj holder = null ) : base( holder ) {
			
		}

		// Function from file: particle_accelerator.dm
		public override void UpdateCut( double? index = null, bool mended = false ) {
			Obj C = null;
			int? i = null;

			C = this.holder;

			switch ((int?)( index )) {
				case 1:
					
					if ( Lang13.Bool( ((dynamic)C).active ) == !mended ) {
						((dynamic)C).toggle_power();
					}
					break;
				case 2:
					i = null;
					i = 1;

					while (( i ??0) < 3) {
						((dynamic)C).remove_strength();
						i++;
					}
					break;
				case 4:
					((dynamic)C).interface_control = mended;
					break;
				case 8:
					((dynamic)C).strength_upper_limit = ( mended ? 2 : 3 );

					if ( Convert.ToDouble( ((dynamic)C).strength_upper_limit ) < Convert.ToDouble( ((dynamic)C).strength ) ) {
						((dynamic)C).remove_strength();
					}
					break;
			}
			return;
		}

		// Function from file: particle_accelerator.dm
		public override void UpdatePulsed( double? index = null ) {
			Obj C = null;

			C = this.holder;

			switch ((int?)( index )) {
				case 1:
					((dynamic)C).toggle_power();
					break;
				case 2:
					((dynamic)C).add_strength();
					break;
				case 4:
					((dynamic)C).interface_control = !Lang13.Bool( ((dynamic)C).interface_control );
					break;
				case 8:
					C.visible_message( new Txt().icon( C ).str( "<b>" ).item( C ).str( "</b> makes a large whirring noise." ).ToString() );
					break;
			}
			return;
		}

		// Function from file: particle_accelerator.dm
		public override bool CanUse( dynamic L = null ) {
			Obj C = null;

			C = this.holder;

			if ( Convert.ToInt32( ((dynamic)C).construction_state ) == 2 ) {
				return true;
			}
			return false;
		}

	}

}