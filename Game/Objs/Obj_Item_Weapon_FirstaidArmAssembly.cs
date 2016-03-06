// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_FirstaidArmAssembly : Obj_Item_Weapon {

		public int build_step = 0;
		public string created_name = "Medibot";
		public string skin = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/aibots.dmi";
			this.icon_state = "firstaid_arm";
		}

		// Function from file: construction.dm
		public Obj_Item_Weapon_FirstaidArmAssembly ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 5, (Task13.Closure)(() => {
				
				if ( Lang13.Bool( this.skin ) ) {
					this.overlays.Add( new Image( "icons/obj/aibots.dmi", "kit_skin_" + this.skin ) );
				}
				return;
			}));
			return;
		}

		// Function from file: construction.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			string t = null;
			dynamic T = null;
			Mob_Living_SimpleAnimal_Bot_Medbot S = null;

			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Weapon_Pen ) {
				t = GlobalFuncs.stripped_input( user, "Enter new robot name", this.name, this.created_name, 26 );

				if ( !Lang13.Bool( t ) ) {
					return null;
				}

				if ( !( Map13.GetDistance( this, Task13.User ) <= 1 ) && this.loc != Task13.User ) {
					return null;
				}
				this.created_name = t;
			} else {
				
				switch ((int)( this.build_step )) {
					case 0:
						
						if ( A is Obj_Item_Device_Healthanalyzer ) {
							
							if ( !((Mob)user).unEquip( A ) ) {
								return null;
							}
							GlobalFuncs.qdel( A );
							this.build_step++;
							user.WriteMsg( "<span class='notice'>You add the health sensor to " + this + ".</span>" );
							this.name = "First aid/robot arm/health analyzer assembly";
							this.overlays.Add( new Image( "icons/obj/aibots.dmi", "na_scanner" ) );
						}
						break;
					case 1:
						
						if ( A is Obj_Item_Device_Assembly_ProxSensor ) {
							
							if ( !((Mob)user).unEquip( A ) ) {
								return null;
							}
							GlobalFuncs.qdel( A );
							this.build_step++;
							user.WriteMsg( "<span class='notice'>You complete the Medibot. Beep boop!</span>" );
							T = GlobalFuncs.get_turf( this );
							S = new Mob_Living_SimpleAnimal_Bot_Medbot( T );
							S.skin = this.skin;
							S.name = this.created_name;
							((Mob)user).unEquip( this, 1 );
							GlobalFuncs.qdel( this );
						}
						break;
				}
			}
			return null;
		}

	}

}