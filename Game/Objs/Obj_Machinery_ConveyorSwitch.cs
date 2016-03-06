// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_ConveyorSwitch : Obj_Machinery {

		public int position = 0;
		public int last_pos = -1;
		public bool operated = true;
		public bool convdir = false;
		public dynamic id = "";
		public ByTable conveyors = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/recycling.dmi";
			this.icon_state = "switch-off";
		}

		// Function from file: conveyor2.dm
		public Obj_Machinery_ConveyorSwitch ( dynamic newloc = null, dynamic newid = null ) : base( (object)(newloc) ) {
			Obj_Machinery_Conveyor C = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( !Lang13.Bool( this.id ) ) {
				this.id = newid;
			}
			this.update();
			Task13.Schedule( 5, (Task13.Closure)(() => {
				this.conveyors = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Conveyor) )) {
					C = _a;
					

					if ( C.id == this.id ) {
						this.conveyors.Add( C );
					}
				}
				return;
			}));
			return;
		}

		// Function from file: conveyor2.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			Obj_Item_ConveyorSwitchConstruct C = null;

			
			if ( A is Obj_Item_Weapon_Crowbar ) {
				C = new Obj_Item_ConveyorSwitchConstruct( this.loc );
				C.id = this.id;
				this.transfer_fingerprints_to( C );
				user.WriteMsg( "<span class='notice'>You deattach the conveyor switch.</span>" );
				GlobalFuncs.qdel( this );
			}
			return null;
		}

		// Function from file: conveyor2.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			Obj_Machinery_ConveyorSwitch S = null;

			this.add_fingerprint( a );

			if ( this.position == 0 ) {
				
				if ( this.convdir ) {
					this.position = this.convdir ?1:0;
				} else if ( this.last_pos < 0 ) {
					this.position = 1;
					this.last_pos = 0;
				} else {
					this.position = -1;
					this.last_pos = 0;
				}
			} else {
				this.last_pos = this.position;
				this.position = 0;
			}
			this.operated = true;
			this.update();

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_ConveyorSwitch) )) {
				S = _a;
				

				if ( S.id == this.id ) {
					S.position = this.position;
					S.update();
				}
			}
			return null;
		}

		// Function from file: conveyor2.dm
		public override int? process( dynamic seconds = null ) {
			Obj_Machinery_Conveyor C = null;

			
			if ( !this.operated ) {
				return null;
			}
			this.operated = false;

			foreach (dynamic _a in Lang13.Enumerate( this.conveyors, typeof(Obj_Machinery_Conveyor) )) {
				C = _a;
				
				C.operating = this.position;
				C.update_move_direction();
			}
			return null;
		}

		// Function from file: conveyor2.dm
		public void update(  ) {
			
			if ( this.position < 0 ) {
				this.icon_state = "switch-rev";
			} else if ( this.position > 0 ) {
				this.icon_state = "switch-fwd";
			} else {
				this.icon_state = "switch-off";
			}
			return;
		}

	}

}