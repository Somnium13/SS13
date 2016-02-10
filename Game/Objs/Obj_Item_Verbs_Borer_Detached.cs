// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Verbs_Borer_Detached : Obj_Item_Verbs_Borer {

		public Obj_Item_Verbs_Borer_Detached ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: verbs_detached.dm
		[Verb]
		[VerbInfo( name: "Reproduce", desc: "Produce offspring in the form of an egg.", group: "Alien" )]
		public void borer_reproduce(  ) {
			Ent_Static B = null;

			B = this.loc;

			if ( !( B is Mob_Living_SimpleAnimal_Borer ) ) {
				return;
			}
			((Mob_Living_SimpleAnimal_Borer)B).reproduce();
			return;
		}

		// Function from file: verbs_detached.dm
		[Verb]
		[VerbInfo( name: "Hide", desc: "Allows to hide beneath tables or certain items. Toggled on or off.", group: "Alien" )]
		public void borer_hide(  ) {
			Ent_Static B = null;

			B = this.loc;

			if ( !( B is Mob_Living_SimpleAnimal_Borer ) ) {
				return;
			}
			((Mob_Living_SimpleAnimal_Borer)B).hide();
			return;
		}

		// Function from file: verbs_detached.dm
		[Verb]
		[VerbInfo( name: "Crawl through Vent", desc: "Enter an air vent and crawl through the pipe system.", group: "Alien" )]
		public void ventcrawl(  ) {
			Ent_Static B = null;

			B = this.loc;

			if ( !( B is Mob_Living_SimpleAnimal_Borer ) ) {
				return;
			}
			((Mob_Living_SimpleAnimal_Borer)B).ventcrawl();
			return;
		}

		// Function from file: verbs_detached.dm
		[Verb]
		[VerbInfo( name: "Infest", desc: "Infest a suitable humanoid host.", group: "Alien" )]
		public void infest(  ) {
			Ent_Static B = null;

			B = this.loc;

			if ( !( B is Mob_Living_SimpleAnimal_Borer ) ) {
				return;
			}
			((Mob_Living_SimpleAnimal_Borer)B).infest();
			return;
		}

	}

}