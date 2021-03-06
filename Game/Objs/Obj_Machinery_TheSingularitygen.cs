// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_TheSingularitygen : Obj_Machinery {

		public int energy = 0;
		public Type creation_type = typeof(Obj_Singularity);

		protected override void __FieldInit() {
			base.__FieldInit();

			this.use_power = 0;
			this.icon = "icons/obj/singularity.dmi";
			this.icon_state = "TheSingGen";
		}

		public Obj_Machinery_TheSingularitygen ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: generator.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Weapon_Wrench ) {
				
				if ( !Lang13.Bool( this.anchored ) && !this.isinspace() ) {
					((Ent_Static)user).visible_message( "" + user.name + " secures " + this.name + " to the floor.", "<span class='notice'>You secure the " + this.name + " to the floor.</span>", "<span class='italics'>You hear a ratchet.</span>" );
					GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 75, 1 );
					this.anchored = 1;
				} else if ( Lang13.Bool( this.anchored ) ) {
					((Ent_Static)user).visible_message( "" + user.name + " unsecures " + this.name + " from the floor.", "<span class='notice'>You unsecure the " + this.name + " from the floor.</span>", "<span class='italics'>You hear a ratchet.</span>" );
					GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 75, 1 );
					this.anchored = 0;
				}
				return null;
			}
			return base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
		}

		// Function from file: generator.dm
		public override int? process( dynamic seconds = null ) {
			dynamic T = null;
			dynamic S = null;

			T = GlobalFuncs.get_turf( this );

			if ( this.energy >= 200 ) {
				S = Lang13.Call( this.creation_type, T, 50 );
				this.transfer_fingerprints_to( S );

				if ( this != null ) {
					GlobalFuncs.qdel( this );
				}
			}
			return null;
		}

	}

}