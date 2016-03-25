// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Power : Obj_Machinery {

		public dynamic powernet = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.use_power = 0;
			this.icon = "icons/obj/power.dmi";
		}

		public Obj_Machinery_Power ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: power.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic coil = null;
			Ent_Static T = null;

			
			if ( A is Obj_Item_Stack_CableCoil ) {
				coil = A;
				T = user.loc;

				if ( Lang13.Bool( ((dynamic)T).intact ) || !( T is Tile_Simulated_Floor ) ) {
					return null;
				}

				if ( Map13.GetDistance( this, user ) > 1 ) {
					return null;
				}
				((Obj_Item_Stack_CableCoil)coil).place_turf( T, user );
				return null;
			} else {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: terminal.dm
		public virtual bool can_terminal_dismantle(  ) {
			bool _default = false;

			_default = false;
			return _default;
		}

		// Function from file: power.dm
		public ByTable get_indirect_connections(  ) {
			ByTable _default = null;

			Obj_Structure_Cable C = null;

			_default = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Obj_Structure_Cable) )) {
				C = _a;
				

				if ( C.powernet != null ) {
					continue;
				}

				if ( C.d1 == 0 ) {
					_default.Add( C );
				}
			}
			return _default;
		}

		// Function from file: power.dm
		public ByTable get_marked_connections(  ) {
			ByTable _default = null;

			double? cdir = null;
			Tile T = null;
			dynamic card = null;
			Obj_Structure_Cable C = null;

			_default = new ByTable();

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.cardinal )) {
				card = _b;
				
				T = Map13.GetStep( this.loc, Convert.ToInt32( card ) );
				cdir = Map13.GetDistance( T, this.loc );

				foreach (dynamic _a in Lang13.Enumerate( T, typeof(Obj_Structure_Cable) )) {
					C = _a;
					

					if ( C.d1 == cdir || C.d2 == cdir ) {
						_default.Add( C );
					}
				}
			}
			return _default;
		}

		// Function from file: power.dm
		public ByTable get_connections(  ) {
			ByTable _default = null;

			double? cdir = null;
			Tile T = null;
			dynamic card = null;
			Obj_Structure_Cable C = null;

			_default = new ByTable();

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.cardinal )) {
				card = _b;
				
				T = Map13.GetStep( this.loc, Convert.ToInt32( card ) );
				cdir = Map13.GetDirection( T, this.loc );

				foreach (dynamic _a in Lang13.Enumerate( T, typeof(Obj_Structure_Cable) )) {
					C = _a;
					

					if ( C.powernet != null ) {
						continue;
					}

					if ( C.d1 == cdir || C.d2 == cdir ) {
						_default.Add( C );
					}
				}
			}
			return _default;
		}

		// Function from file: power.dm
		public virtual bool disconnect_from_network(  ) {
			
			if ( !Lang13.Bool( this.powernet ) ) {
				return false;
			}
			((Powernet)this.powernet).remove_machine( this );
			return true;
		}

		// Function from file: power.dm
		public virtual bool connect_to_network(  ) {
			Ent_Static T = null;
			dynamic C = null;

			T = this.loc;

			if ( !( T != null ) || !( T is Tile ) ) {
				return false;
			}
			C = ((dynamic)T).get_cable_node();

			if ( !Lang13.Bool( C ) || !Lang13.Bool( C.powernet ) ) {
				return false;
			}
			((Powernet)C.powernet).add_machine( this );
			return true;
		}

		// Function from file: power.dm
		public virtual void disconnect_terminal(  ) {
			return;
		}

		// Function from file: power.dm
		public virtual dynamic avail(  ) {
			
			if ( Lang13.Bool( this.powernet ) ) {
				return this.powernet.avail;
			} else {
				return 0;
			}
		}

		// Function from file: power.dm
		public virtual dynamic surplus(  ) {
			
			if ( Lang13.Bool( this.powernet ) ) {
				return this.powernet.avail - Convert.ToDouble( this.powernet.load );
			} else {
				return 0;
			}
		}

		// Function from file: power.dm
		public virtual void add_load( dynamic amount = null ) {
			
			if ( Lang13.Bool( this.powernet ) ) {
				this.powernet.load += amount;
			}
			return;
		}

		// Function from file: power.dm
		public void add_avail( double amount = 0 ) {
			
			if ( Lang13.Bool( this.powernet ) ) {
				this.powernet.newavail += amount;
			}
			return;
		}

		// Function from file: power.dm
		public override dynamic Destroy(  ) {
			this.disconnect_from_network();
			return base.Destroy();
		}

		// Function from file: swarmer.dm
		public override void swarmer_act( Mob_Living_SimpleAnimal_Hostile_Swarmer S = null ) {
			S.WriteMsg( "<span class='warning'>Disrupting the power grid would bring no benefit to us. Aborting.</span>" );
			return;
		}

	}

}