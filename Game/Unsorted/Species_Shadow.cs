// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Species_Shadow : Species {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "???";
			this.id = "shadow";
			this.darksight = 8;
			this.invis_sight = 5;
			this.sexes = false;
			this.blacklisted = true;
			this.ignored_by = new ByTable(new object [] { typeof(Mob_Living_SimpleAnimal_Hostile_Faithless) });
			this.meat = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Slab_Human_Mutant_Shadow);
			this.specflags = new ByTable(new object [] { 256, 1024, 128, 4096 });
			this.dangerous_existence = true;
		}

		// Function from file: species_types.dm
		public override void spec_life( Mob_Living H = null ) {
			double light_amount = 0;
			Ent_Static T = null;

			light_amount = 0;

			if ( H.loc is Tile ) {
				T = H.loc;
				light_amount = ((Tile)T).get_lumcount();

				if ( light_amount > 2 ) {
					H.take_overall_damage( 1, 1 );
				} else if ( light_amount < 2 ) {
					H.heal_overall_damage( 1, 1 );
				}
			}
			return;
		}

	}

}