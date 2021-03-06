// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Resonator : Obj_Item_Weapon {

		public bool cooldown = false;
		public int fieldsactive = 0;
		public int burst_time = 50;
		public int fieldlimit = 3;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "resonator";
			this.force = 8;
			this.throwforce = 10;
			this.origin_tech = "magnets=2;combat=2";
			this.icon = "icons/obj/mining.dmi";
			this.icon_state = "resonator";
		}

		public Obj_Item_Weapon_Resonator ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: equipment_locker.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			
			if ( proximity_flag == true ) {
				
				if ( !this.check_allowed_items( target, true ) ) {
					return false;
				}
				this.CreateResonance( target, user );
			}
			return false;
		}

		// Function from file: equipment_locker.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.burst_time == 50 ) {
				this.burst_time = 30;
				user.WriteMsg( "<span class='info'>You set the resonator's fields to detonate after 3 seconds.</span>" );
			} else {
				this.burst_time = 50;
				user.WriteMsg( "<span class='info'>You set the resonator's fields to detonate after 5 seconds.</span>" );
			}
			return null;
		}

		// Function from file: equipment_locker.dm
		public void CreateResonance( dynamic target = null, dynamic creator = null ) {
			dynamic T = null;

			T = GlobalFuncs.get_turf( target );

			if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Effect_Resonance), T ) ) ) {
				return;
			}

			if ( this.fieldsactive < this.fieldlimit ) {
				GlobalFuncs.playsound( this, "sound/weapons/resonator_fire.ogg", 50, 1 );
				new Obj_Effect_Resonance( T, creator, this.burst_time );
				this.fieldsactive++;
				Task13.Schedule( this.burst_time, (Task13.Closure)(() => {
					this.fieldsactive--;
					return;
				}));
			}
			return;
		}

	}

}