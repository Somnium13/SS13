// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Objective_Die : Objective {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.explanation_text = "Die a glorious death.";
		}

		public Objective_Die ( string text = null ) : base( text ) {
			
		}

		// Function from file: objective.dm
		public override dynamic check_completion(  ) {
			
			if ( !Lang13.Bool( ((dynamic)this.owner).current ) || Convert.ToInt32( ((dynamic)this.owner).current.stat ) == 2 || ((dynamic)this.owner).current is Mob_Living_Carbon_Brain || ((dynamic)this.owner).current is Mob_Living_SimpleAnimal_Borer ) {
				return 1;
			}

			if ( ((dynamic)this.owner).current is Mob_Living_Silicon && ((dynamic)this.owner).current != ((dynamic)this.owner).original ) {
				return 1;
			}
			return 0;
		}

	}

}