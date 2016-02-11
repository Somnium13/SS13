// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Controller_Process_PowerMachinery : Controller_Process {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.schedule_interval = 17;
		}

		public Controller_Process_PowerMachinery ( dynamic scheduler = null ) : base( (object)(scheduler) ) {
			
		}

		// Function from file: power.dm
		public override bool doWork(  ) {
			Obj_Structure_Cable PC = null;
			Powernet powerNetwork = null;
			double? i = null;
			Obj M = null;
			int time_start = 0;
			int time_end = 0;
			PowerConnection C = null;
			int time_start2 = 0;
			int time_end2 = 0;
			dynamic e = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.cable_list, typeof(Obj_Structure_Cable) )) {
				PC = _a;
				

				if ( PC.build_status ) {
					
					if ( PC.rebuild_from() ) {
						this.scheck();
					}
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.powernets, typeof(Powernet) )) {
				powerNetwork = _b;
				

				if ( powerNetwork is Powernet && !( powerNetwork.disposed == true ) ) {
					powerNetwork.reset();
					this.scheck();
					continue;
				}
				GlobalVars.powernets.Remove( powerNetwork );
			}

			foreach (dynamic _c in Lang13.IterateRange( 1, GlobalVars.power_machines.len )) {
				i = _c;
				

				if ( ( i ??0) > GlobalVars.power_machines.len ) {
					break;
				}

				try {
					
					if ( GlobalVars.power_machines[i] is Obj_Machinery ) {
						M = GlobalVars.power_machines[i];

						if ( M.timestopped ) {
							continue;
						}

						if ( !Lang13.Bool( M.gcDestroyed ) ) {
							time_start = Game13.timeofday;

							if ( Lang13.Bool( ((dynamic)M).check_rebuild() ) ) {
								this.scheck();
							}

							if ( M.process() == 26 ) {
								((dynamic)M).inMachineList = 0;
								GlobalVars.power_machines.Remove( M );
								continue;
							}

							if ( M != null && Lang13.Bool( ((dynamic)M).use_power ) ) {
								((Obj_Machinery)M).auto_use_power();
							}

							if ( M is Obj_Machinery ) {
								time_end = Game13.timeofday;

								if ( !GlobalVars.power_machinery_profiling.Contains( M.type ) ) {
									GlobalVars.power_machinery_profiling[M.type] = 0;
								}
								GlobalVars.power_machinery_profiling[M.type] += time_end - time_start;
							} else if ( !GlobalVars.power_machines.Remove( M ) ) {
								GlobalVars.power_machines.Cut( ((int?)( i )), ((int)( ( i ??0) + 1 )) );
							}
						} else {
							
							if ( M != null ) {
								((dynamic)M).inMachineList = 0;
							}

							if ( !GlobalVars.power_machines.Remove( M ) ) {
								GlobalVars.power_machines.Cut( ((int?)( i )), ((int)( ( i ??0) + 1 )) );
							}
						}
					} else if ( GlobalVars.power_machines[i] is PowerConnection ) {
						C = GlobalVars.power_machines[i];
						time_start2 = Game13.timeofday;

						if ( C.check_rebuild() ) {
							this.scheck();
						}

						if ( /*[I CANNOT CONVERT SOME RANDOM SHIT TO AN INT: void]*/ 0 == 26 ) {
							C.inMachineList = false;
							GlobalVars.power_machines.Remove( C );
							continue;
						}

						if ( C is PowerConnection ) {
							time_end2 = Game13.timeofday;

							if ( !GlobalVars.power_machinery_profiling.Contains( C.type ) ) {
								GlobalVars.power_machinery_profiling[C.type] = 0;
							}
							GlobalVars.power_machinery_profiling[C.type] += time_end2 - time_start2;
						} else if ( !GlobalVars.power_machines.Remove( C ) ) {
							GlobalVars.power_machines.Cut( ((int?)( i )), ((int)( ( i ??0) + 1 )) );
						}
					}
				} catch (Exception __) {
					e = __;
					Game13.Error( e );
					continue;
				}
				this.scheck();
			}
			return false;
		}

		// Function from file: power.dm
		public override void setup(  ) {
			this.name = "power";
			return;
		}

	}

}