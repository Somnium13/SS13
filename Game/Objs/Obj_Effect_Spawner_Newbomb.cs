// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Spawner_Newbomb : Obj_Effect_Spawner {

		public int btype = 0;
		public int btemp1 = 1500;
		public int btemp2 = 1000;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/mob/screen_gen.dmi";
			this.icon_state = "x";
		}

		// Function from file: bombspawner.dm
		public Obj_Effect_Spawner_Newbomb ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj_Item_Device_TransferValve V = null;
			Obj_Item_Weapon_Tank_Internals_Plasma PT = null;
			Obj_Item_Weapon_Tank_Internals_Oxygen OT = null;
			Obj_Item_Device_Assembly_Signaler S = null;
			Obj_Item_Device_TransferValve V2 = null;
			Obj_Item_Weapon_Tank_Internals_Plasma PT2 = null;
			Obj_Item_Weapon_Tank_Internals_Oxygen OT2 = null;
			Obj_Item_Device_Assembly_ProxSensor P = null;
			Obj_Item_Device_TransferValve V3 = null;
			Obj_Item_Weapon_Tank_Internals_Plasma PT3 = null;
			Obj_Item_Weapon_Tank_Internals_Oxygen OT3 = null;
			Obj_Item_Device_Assembly_Timer T = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			switch ((int)( this.btype )) {
				case 0:
					V = new Obj_Item_Device_TransferValve( this.loc );
					PT = new Obj_Item_Weapon_Tank_Internals_Plasma( V );
					OT = new Obj_Item_Weapon_Tank_Internals_Oxygen( V );
					S = new Obj_Item_Device_Assembly_Signaler( V );
					V.tank_one = PT;
					V.tank_two = OT;
					V.attached_device = S;
					S.holder = V;
					S.toggle_secure();
					PT.master = V;
					OT.master = V;
					PT.air_contents.temperature = this.btemp1 + 273.41;
					OT.air_contents.temperature = this.btemp2 + 273.41;
					V.update_icon();
					break;
				case 1:
					V2 = new Obj_Item_Device_TransferValve( this.loc );
					PT2 = new Obj_Item_Weapon_Tank_Internals_Plasma( V2 );
					OT2 = new Obj_Item_Weapon_Tank_Internals_Oxygen( V2 );
					P = new Obj_Item_Device_Assembly_ProxSensor( V2 );
					V2.tank_one = PT2;
					V2.tank_two = OT2;
					V2.attached_device = P;
					P.holder = V2;
					P.toggle_secure();
					PT2.master = V2;
					OT2.master = V2;
					PT2.air_contents.temperature = this.btemp1 + 273.41;
					OT2.air_contents.temperature = this.btemp2 + 273.41;
					V2.update_icon();
					break;
				case 2:
					V3 = new Obj_Item_Device_TransferValve( this.loc );
					PT3 = new Obj_Item_Weapon_Tank_Internals_Plasma( V3 );
					OT3 = new Obj_Item_Weapon_Tank_Internals_Oxygen( V3 );
					T = new Obj_Item_Device_Assembly_Timer( V3 );
					V3.tank_one = PT3;
					V3.tank_two = OT3;
					V3.attached_device = T;
					T.holder = V3;
					T.toggle_secure();
					PT3.master = V3;
					OT3.master = V3;
					T.time = 30;
					PT3.air_contents.temperature = this.btemp1 + 273.41;
					OT3.air_contents.temperature = this.btemp2 + 273.41;
					V3.update_icon();
					break;
			}
			GlobalFuncs.qdel( this );
			return;
		}

	}

}