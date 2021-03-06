// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Statue_Bananium : Obj_Structure_Statue {

		public bool spam_flag = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.hardness = 3;
			this.mineralType = "bananium";
		}

		public Obj_Structure_Statue_Bananium ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: statues.dm
		public void honk(  ) {
			
			if ( !this.spam_flag ) {
				this.spam_flag = true;
				GlobalFuncs.playsound( this.loc, "sound/items/bikehorn.ogg", 50, 1 );
				Task13.Schedule( 20, (Task13.Closure)(() => {
					this.spam_flag = false;
					return;
				}));
			}
			return;
		}

		// Function from file: statues.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			this.honk();
			base.attack_paw( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: statues.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			this.honk();
			base.attack_hand( (object)(a), b, c );
			return null;
		}

		// Function from file: statues.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			this.honk();
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: statues.dm
		public override bool Bumped( dynamic AM = null ) {
			this.honk();
			base.Bumped( (object)(AM) );
			return false;
		}

	}

}