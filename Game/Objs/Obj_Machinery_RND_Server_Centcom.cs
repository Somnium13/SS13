// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_RND_Server_Centcom : Obj_Machinery_RND_Server {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.server_id = -1;
		}

		public Obj_Machinery_RND_Server_Centcom ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: server.dm
		public override int? process( dynamic seconds = null ) {
			return 26;
		}

		// Function from file: server.dm
		public override void initialize(  ) {
			ByTable no_id_servers = null;
			ByTable server_ids = null;
			Obj_Machinery_RND_Server S = null;
			Obj_Machinery_RND_Server S2 = null;
			int num = 0;

			base.initialize();
			no_id_servers = new ByTable();
			server_ids = new ByTable();

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_RND_Server) )) {
				S = _b;
				

				switch ((int?)( S.server_id )) {
					case -1:
						continue;
						break;
					case 0:
						no_id_servers.Add( S );
						break;
					default:
						server_ids.Add( S.server_id );
						break;
				}
			}

			foreach (dynamic _c in Lang13.Enumerate( no_id_servers, typeof(Obj_Machinery_RND_Server) )) {
				S2 = _c;
				
				num = 1;

				while (!Lang13.Bool( S2.server_id )) {
					
					if ( server_ids.Contains( num ) ) {
						num++;
					} else {
						S2.server_id = num;
						server_ids.Add( num );
					}
				}
				no_id_servers.Remove( S2 );
			}
			return;
		}

	}

}