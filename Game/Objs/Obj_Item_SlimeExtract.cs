// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_SlimeExtract : Obj_Item {

		public int Uses = 1;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 1;
			this.w_class = 1;
			this.throw_speed = 3;
			this.throw_range = 6;
			this.origin_tech = "biotech=3";
			this.icon = "icons/mob/slimes.dmi";
			this.icon_state = "grey slime extract";
		}

		// Function from file: xenobiology.dm
		public Obj_Item_SlimeExtract ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.create_reagents( 100 );
			return;
		}

		// Function from file: xenobiology.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Slimepotion_Enhancer ) {
				
				if ( this.Uses >= 5 ) {
					user.WriteMsg( "<span class='warning'>You cannot enhance this extract further!</span>" );
					return base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
				}
				user.WriteMsg( "<span class='notice'>You apply the enhancer to the slime extract. It may now be reused one more time.</span>" );
				this.Uses++;
				GlobalFuncs.qdel( A );
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

	}

}