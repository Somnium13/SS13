// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Materials : Game_Data {

		public dynamic holder = null;
		public dynamic storage = null;

		// Function from file: materials.dm
		public Materials ( dynamic newholder = null ) {
			this.holder = newholder;
			this.storage = new ByTable();

			if ( !Lang13.Bool( GlobalVars.material_list ) ) {
				GlobalFuncs.initialize_materials();
			}

			if ( !( this.storage.len != 0 ) ) {
				this.storage = GlobalVars.initial_materials.Copy();
			}
			return;
		}

		// Function from file: materials.dm
		public bool getMaterial( dynamic mat_id = null ) {
			
			if ( !Lang13.Bool( GlobalVars.material_list.Contains( mat_id ) ) ) {
				Game13.log.WriteMsg( "## WARNING: " + ( "getMaterial(): Unknown material " + mat_id + "!" ) );
				return false;
			}
			return Lang13.Bool( GlobalVars.material_list[mat_id] );
		}

		// Function from file: materials.dm
		public bool getAmount( dynamic mat_id = null ) {
			
			if ( !Lang13.Bool( this.storage.Contains( mat_id ) ) ) {
				Game13.log.WriteMsg( "## WARNING: " + ( "getAmount(): Unknown material " + mat_id + "!" ) );
				return false;
			}
			return Lang13.Bool( this.storage[mat_id] );
		}

		// Function from file: materials.dm
		public void removeAmount( dynamic mat_id = null, int amount = 0 ) {
			
			if ( !Lang13.Bool( this.storage.Contains( mat_id ) ) ) {
				Game13.log.WriteMsg( "## WARNING: " + ( "removeAmount(): Unknown material " + mat_id + "!" ) );
				return;
			}
			this.addAmount( mat_id, -amount );
			return;
		}

		// Function from file: materials.dm
		public double getValue(  ) {
			double value = 0;
			dynamic mat_id = null;
			dynamic mat = null;

			value = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.storage )) {
				mat_id = _a;
				
				mat = this.getMaterial( mat_id );
				value += Convert.ToDouble( mat.value * this.storage[mat_id] );
			}
			return value;
		}

		// Function from file: materials.dm
		public double getVolume(  ) {
			double volume = 0;
			dynamic mat_id = null;

			volume = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.storage )) {
				mat_id = _a;
				
				volume += Convert.ToDouble( this.storage[mat_id] );
			}
			return volume;
		}

		// Function from file: materials.dm
		public void addFrom( Materials mats = null, bool? zero_after = null ) {
			zero_after = zero_after ?? false;

			dynamic mat_id = null;

			
			if ( mats == null ) {
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.storage )) {
				mat_id = _a;
				

				if ( Convert.ToDouble( mats.storage[mat_id] ) > 0 ) {
					this.storage[mat_id] += mats.storage[mat_id];

					if ( zero_after == true ) {
						mats.storage[mat_id] = 0;
					}
				}
			}
			return;
		}

		// Function from file: materials.dm
		public void removeFrom( Materials mats = null ) {
			this.addFrom( mats, true );
			return;
		}

		// Function from file: materials.dm
		public void addAmount( dynamic mat_id = null, double amount = 0 ) {
			
			if ( !Lang13.Bool( this.storage.Contains( mat_id ) ) ) {
				Game13.log.WriteMsg( "## WARNING: " + ( "addAmount(): Unknown material " + mat_id + "!" ) );
				return;
			}
			this.storage[mat_id] = Num13.MaxInt( 0, Convert.ToInt32( this.storage[mat_id] + amount ) );
			return;
		}

		// Function from file: materials.dm
		public override dynamic resetVariables( string args = null, params object[] _ ) {
			ByTable _args = new ByTable( new object[] { args } ).Extend(_);

			string newargs = null;

			
			if ( Lang13.Bool( _args[1] ) ) {
				newargs = _args[1] + "storage";
			} else {
				newargs = "storage";
			}
			newargs.Apply( Lang13.BindFunc( base, "resetVariables" ) );

			if ( !Lang13.Bool( GlobalVars.initial_materials ) ) {
				GlobalFuncs.initialize_materials();
			}
			this.storage = GlobalVars.initial_materials.Copy();
			return null;
		}

		// Function from file: materials.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			this.holder = null;
			return null;
		}

	}

}