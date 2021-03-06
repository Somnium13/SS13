// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Construction_Reversible : Construction {

		public int? index = null;

		// Function from file: construction_datum.dm
		public Construction_Reversible ( Game_Data atom = null ) : base( atom ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.index = this.steps.len;
			return;
		}

		// Function from file: construction_datum.dm
		public override bool custom_action( int? index = null, dynamic diff = null, dynamic used_atom = null, dynamic user = null ) {
			return true;
		}

		// Function from file: construction_datum.dm
		public override bool check_step( dynamic used_atom = null, dynamic user = null ) {
			int diff = 0;

			diff = this.is_right_key( used_atom );

			if ( diff != 0 ) {
				
				if ( this.custom_action( this.index, diff, used_atom, user ) ) {
					this.update_index( diff );
					return true;
				}
			}
			return false;
		}

		// Function from file: construction_datum.dm
		public override int is_right_key( dynamic used_atom = null ) {
			dynamic L = null;

			L = this.steps[this.index];

			if ( Lang13.Bool( L["key"].IsInstanceOfType( used_atom ) ) ) {
				return -1;
			} else if ( Lang13.Bool( L["backkey"] ) && Lang13.Bool( L["backkey"].IsInstanceOfType( used_atom ) ) ) {
				return 1;
			}
			return 0;
		}

		// Function from file: construction_datum.dm
		public void update_index( int diff = 0 ) {
			this.index += diff;

			if ( this.index == 0 ) {
				this.spawn_result();
			} else {
				this.set_desc( this.index );
			}
			return;
		}

	}

}