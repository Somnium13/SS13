// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Decal_Cleanable_Blood : Obj_Effect_Decal_Cleanable {

		public ByTable viruses = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.random_icon_states = new ByTable(new object [] { "floor1", "floor2", "floor3", "floor4", "floor5", "floor6", "floor7" });
			this.blood_DNA = new ByTable();
			this.blood_state = "blood";
			this.bloodiness = 100;
			this.icon = "icons/effects/blood.dmi";
			this.icon_state = "floor1";
		}

		public Obj_Effect_Decal_Cleanable_Blood ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: humans.dm
		public override void replace_decal( Obj_Effect_Decal_Cleanable C = null ) {
			
			if ( C.blood_DNA != null ) {
				this.blood_DNA.Or( C.blood_DNA.Copy() );
			}
			base.replace_decal( C );
			return;
		}

		// Function from file: humans.dm
		public override dynamic Destroy(  ) {
			Disease D = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.viruses, typeof(Disease) )) {
				D = _a;
				
				D.cure( 0 );
			}
			this.viruses = null;
			return base.Destroy();
		}

	}

}