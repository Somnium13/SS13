// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GlobalIterator_MechaInternalDamage : GlobalIterator {

		public GlobalIterator_MechaInternalDamage ( ByTable arguments = null, bool? autostart = null ) : base( arguments, autostart ) {
			
		}

		// Function from file: mecha.dm
		public override bool process( Obj port = null, dynamic mecha = null ) {
			GasMixture int_tank_air = null;
			GasMixture int_tank_air2 = null;
			GasMixture leaked_gas = null;

			
			if ( !Lang13.Bool( ((dynamic)port).hasInternalDamage() ) ) {
				return this.stop();
			}

			if ( Lang13.Bool( ((dynamic)port).hasInternalDamage( 1 ) ) ) {
				
				if ( !Lang13.Bool( ((dynamic)port).hasInternalDamage( 2 ) ) && Rand13.PercentChance( 5 ) ) {
					((Obj_Mecha)port).clearInternalDamage( 1 );
				}

				if ( Lang13.Bool( ((dynamic)port).internal_tank ) ) {
					
					if ( Convert.ToDouble( ((Obj_Machinery_PortableAtmospherics_Canister)((dynamic)port).internal_tank).return_pressure() ) > Convert.ToDouble( ((dynamic)port).internal_tank.maximum_pressure ) && !Lang13.Bool( ((dynamic)port).hasInternalDamage( 8 ) ) ) {
						((Obj_Mecha)port).setInternalDamage( 8 );
					}
					int_tank_air = ((Ent_Static)((dynamic)port).internal_tank).return_air();

					if ( int_tank_air != null && int_tank_air.return_volume() > 0 ) {
						int_tank_air.temperature = Num13.MinInt( ((int)( 6273.14990234375 )), ((int)( ( int_tank_air.temperature ??0) + Rand13.Int( 10, 15 ) )) );
					}
				}

				if ( Lang13.Bool( ((dynamic)port).cabin_air ) && ((GasMixture)((dynamic)port).cabin_air).return_volume() > 0 ) {
					((dynamic)port).cabin_air.temperature = Num13.MinInt( ((int)( 6273.14990234375 )), Convert.ToInt32( ((dynamic)port).cabin_air.return_temperature() + Rand13.Int( 10, 15 ) ) );

					if ( Convert.ToDouble( ((dynamic)port).cabin_air.return_temperature() ) > Convert.ToDouble( ((dynamic)port).max_temperature / 2 ) ) {
						((Obj_Mecha)port).take_damage( 4 / Num13.Round( Convert.ToDouble( ((dynamic)port).max_temperature / ((dynamic)port).cabin_air.return_temperature() ), 0.1 ), "fire" );
					}
				}
			}

			if ( Lang13.Bool( ((dynamic)port).hasInternalDamage( 2 ) ) ) {
				((dynamic)port).pr_int_temp_processor.stop();
			}

			if ( Lang13.Bool( ((dynamic)port).hasInternalDamage( 8 ) ) ) {
				
				if ( Lang13.Bool( ((dynamic)port).internal_tank ) ) {
					int_tank_air2 = ((Ent_Static)((dynamic)port).internal_tank).return_air();
					leaked_gas = int_tank_air2.remove_ratio( 0.1 );

					if ( port.loc != null && Lang13.HasCall( port.loc, "assume_air" ) ) {
						port.loc.assume_air( leaked_gas );
					} else {
						GlobalFuncs.qdel( leaked_gas );
						leaked_gas = null;
					}
				}
			}

			if ( Lang13.Bool( ((dynamic)port).hasInternalDamage( 4 ) ) ) {
				
				if ( Lang13.Bool( ((Obj_Mecha)port).get_charge() ) ) {
					((dynamic)port).spark_system.start();
					((dynamic)port).cell.charge -= Num13.MinInt( 20, Convert.ToInt32( ((dynamic)port).cell.charge ) );
					((dynamic)port).cell.maxcharge -= Num13.MinInt( 20, Convert.ToInt32( ((dynamic)port).cell.maxcharge ) );
				}
			}
			return false;
		}

	}

}