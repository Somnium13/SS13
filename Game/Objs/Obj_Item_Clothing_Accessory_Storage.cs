// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Accessory_Storage : Obj_Item_Clothing_Accessory {

		public int slots = 3;
		public Obj_Item_Weapon_Storage_Internal hold = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this._color = "webbing";
			this.accessory_exclusion = 2;
			this.icon_state = "webbing";
		}

		// Function from file: storage.dm
		public Obj_Item_Clothing_Accessory_Storage ( dynamic loc = null ) : base( (object)(loc) ) {
			this.hold = new Obj_Item_Weapon_Storage_Internal( this );
			this.hold.master_item = this;
			this.hold.storage_slots = this.slots;
			return;
		}

		// Function from file: storage.dm
		public override dynamic emp_act( int severity = 0 ) {
			this.hold.emp_act( severity );
			return null;
		}

		// Function from file: storage.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			this.hold.attackby( a, b );
			return 1;
		}

		// Function from file: storage.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic T = null;
			Obj_Item I = null;

			GlobalFuncs.to_chat( user, "<span class='notice'>You empty " + this + ".</span>" );
			T = GlobalFuncs.get_turf( this );
			this.hold.hide_from( user );

			foreach (dynamic _a in Lang13.Enumerate( this.hold.contents, typeof(Obj_Item) )) {
				I = _a;
				
				this.hold.remove_from_storage( I, T );
			}
			this.add_fingerprint( user );
			return null;
		}

		// Function from file: storage.dm
		public override int on_accessory_interact( dynamic user = null, bool? delayed = null ) {
			this.hold.attack_hand( user );
			return 1;
		}

		// Function from file: storage.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( this.loc == a ) {
				this.hold.attack_hand( a );
				return null;
			}
			return base.attack_hand( (object)(a), (object)(b), (object)(c) );
		}

	}

}