// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Event_BluespaceAnomaly : Event {

		public dynamic impact_area = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.announceWhen = 5;
		}

		public Event_BluespaceAnomaly ( Obj_Item_MechaParts_MechaEquipment_Tool_CableLayer tlistener = null, string tprocname = null ) : base( tlistener, tprocname ) {
			
		}

		// Function from file: bluespaceanomaly.dm
		public override bool start(  ) {
			dynamic T = null;
			dynamic chosen = null;
			ByTable possible = null;
			Obj_Item_Beacon W = null;
			dynamic FROM = null;
			dynamic TO = null;
			ByTable flashers = null;
			Mob_Living_Carbon_Human M = null;
			double y_distance = 0;
			double x_distance = 0;
			Ent_Dynamic A = null;
			Tile newloc = null;
			Ent_Dynamic M2 = null;
			Obj blueeffect = null;

			T = Rand13.PickFromTable( GlobalFuncs.get_area_turfs( this.impact_area ) );

			if ( Lang13.Bool( T ) ) {
				possible = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.beacons, typeof(Obj_Item_Beacon) )) {
					W = _a;
					
					possible.Add( W );
				}

				if ( possible.len > 0 ) {
					chosen = Rand13.PickFromTable( possible );
				}

				if ( Lang13.Bool( chosen ) ) {
					FROM = T;
					TO = GlobalFuncs.get_turf( chosen );
					GlobalFuncs.playsound( TO, "sound/effects/phasein.ogg", 100, 1 );
					flashers = new ByTable();

					foreach (dynamic _b in Lang13.Enumerate( Map13.FetchViewers( null, TO ), typeof(Mob_Living_Carbon_Human) )) {
						M = _b;
						

						if ( M.eyecheck() <= 0 ) {
							Icon13.Flick( "e_flash", M.flash );
							flashers.Add( M );
						}
					}
					y_distance = Convert.ToDouble( TO.y - FROM.y );
					x_distance = Convert.ToDouble( TO.x - FROM.x );

					foreach (dynamic _c in Lang13.Enumerate( Map13.FetchInRange( FROM, 12 ), typeof(Ent_Dynamic) )) {
						A = _c;
						

						if ( A is Obj_Item_Beacon ) {
							continue;
						}

						if ( Lang13.Bool( A.anchored ) && ( A is Obj_Machinery || A is Obj_Structure ) ) {
							continue;
						}

						if ( A is Obj_Structure_Disposalpipe ) {
							continue;
						}

						if ( A is Obj_Structure_Cable ) {
							continue;
						}

						if ( A is Dynamic_LightingOverlay ) {
							continue;
						}
						newloc = Map13.GetTile( ((int)( A.x + x_distance )), ((int)( A.y + y_distance )), Convert.ToInt32( TO.z ) );
						A.forceMove( newloc );
						Task13.Schedule( 0, (Task13.Closure)(() => {
							
							if ( A is Mob && !false ) {
								M2 = A;

								if ( Lang13.Bool( ((dynamic)M2).client ) ) {
									blueeffect = new Obj( this );
									blueeffect.screen_loc = "WEST,SOUTH to EAST,NORTH";
									blueeffect.icon = "icons/effects/effects.dmi";
									blueeffect.icon_state = "shieldsparkles";
									blueeffect.layer = 17;
									blueeffect.mouse_opacity = 0;
									((dynamic)M2).client.screen += blueeffect;
									Task13.Sleep( 20 );
									((dynamic)M2).client.screen -= blueeffect;
									GlobalFuncs.qdel( blueeffect );
								}
							}
							return;
						}));
					}
				}
			}
			return false;
		}

		// Function from file: bluespaceanomaly.dm
		public override void announce(  ) {
			GlobalFuncs.command_alert( "Bluespace anomaly detected in the vicinity of " + GlobalFuncs.station_name() + ". " + this.impact_area.name + " has been affected.", "Anomaly Alert" );
			return;
		}

		// Function from file: bluespaceanomaly.dm
		public override void setup(  ) {
			ByTable safe_areas = null;
			ByTable danger_areas = null;

			safe_areas = new ByTable(new object [] { 
				typeof(Zone_TurretProtected_Ai), 
				typeof(Zone_TurretProtected_AiUpload), 
				typeof(Zone_Engineering), 
				typeof(Zone_Solar), 
				typeof(Zone_Holodeck), 
				typeof(Zone_Shuttle_Arrival), 
				typeof(Zone_Shuttle_Escape_Station), 
				typeof(Zone_Shuttle_EscapePod1_Station), 
				typeof(Zone_Shuttle_EscapePod2_Station), 
				typeof(Zone_Shuttle_EscapePod3_Station), 
				typeof(Zone_Shuttle_EscapePod5_Station), 
				typeof(Zone_Shuttle_Mining_Station), 
				typeof(Zone_Shuttle_Transport1_Station), 
				typeof(Zone_Shuttle_Specops_Station)
			 });
			danger_areas = new ByTable(new object [] { typeof(Zone_Engineering_BreakRoom), typeof(Zone_Engineering_Ce) });
			this.impact_area = Lang13.FindObj( Rand13.PickFromTable( GlobalVars.the_station_areas - safe_areas + danger_areas ) );
			return;
		}

	}

}