// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpacevineMutation_Toxicity : SpacevineMutation {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "toxic";
			this.hue = "#ff00ff";
			this.severity = 10;
			this.quality = 2;
		}

		// Function from file: spacevine.dm
		public override void on_eat( Obj_Effect_Spacevine holder = null, Mob_Living_SimpleAnimal_Hostile_Retaliate_Goat eater = null ) {
			eater.adjustToxLoss( 5 );
			return;
		}

		// Function from file: spacevine.dm
		public override void on_cross( Obj_Effect_Spacevine holder = null, Ent_Dynamic crosser = null ) {
			
			if ( crosser is Mob_Living_Silicon ) {
				return;
			}

			if ( Rand13.PercentChance( ((int)( this.severity ??0 )) ) && crosser is Mob_Living ) {
				((dynamic)crosser).WriteMsg( "<span class='alert'>You accidently touch the vine and feel a strange sensation.</span>" );
				((Mob_Living)crosser).adjustToxLoss( 5 );
			}
			return;
		}

	}

}