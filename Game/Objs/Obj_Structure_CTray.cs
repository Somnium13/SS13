// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_CTray : Obj_Structure {

		public Obj_Structure_Crematorium connected = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/stationobjs.dmi";
			this.icon_state = "cremat";
		}

		public Obj_Structure_CTray ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: morgue.dm
		public override bool MouseDrop_T( Ent_Static O = null, dynamic user = null, bool? needs_opened = null, bool? show_message = null, bool? move_them = null ) {
			dynamic B = null;

			
			if ( !( O is Ent_Dynamic ) || Lang13.Bool( ((dynamic)O).anchored ) || Map13.GetDistance( user, this ) > 1 || Map13.GetDistance( user, O ) > 1 || Lang13.Bool( user.contents.Find( this ) ) || Lang13.Bool( user.contents.Find( O ) ) ) {
				return false;
			}

			if ( !( O is Mob ) && !( O is Obj_Structure_Closet_BodyBag ) ) {
				return false;
			}
			O.loc = this.loc;

			if ( user != O ) {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( 3, user ) )) {
					B = _a;
					

					if ( Lang13.Bool( B.client ) && !Lang13.Bool( B.blinded ) ) {
						GlobalFuncs.to_chat( B, "<span class='warning'>" + user + " stuffs " + O + " into " + this + "!</span>" );
					}
				}
			}
			return false;
		}

		// Function from file: morgue.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic A = null;

			
			if ( this.connected != null ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.loc )) {
					A = _a;
					

					if ( !Lang13.Bool( A.anchored ) ) {
						A.loc = this.connected;
					}
				}
				this.connected.connected = null;
				this.connected.update();
				this.add_fingerprint( a );
				GlobalFuncs.qdel( this );
				return null;
			}
			return null;
		}

		// Function from file: morgue.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: morgue.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 1.5;
			air_group = air_group ?? false;

			
			if ( mover is Obj_Item_Weapon_Dummy ) {
				return true;
			} else {
				return base.CanPass( (object)(mover), (object)(target), height, air_group );
			}
		}

	}

}