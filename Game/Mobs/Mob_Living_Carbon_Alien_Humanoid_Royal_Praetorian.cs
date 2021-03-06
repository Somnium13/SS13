// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_Carbon_Alien_Humanoid_Royal_Praetorian : Mob_Living_Carbon_Alien_Humanoid_Royal {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.caste = "p";
			this.maxHealth = 250;
			this.health = 250;
			this.icon_state = "alienp";
		}

		// Function from file: praetorian.dm
		public Mob_Living_Carbon_Alien_Humanoid_Royal_Praetorian ( dynamic loc = null ) : base( (object)(loc) ) {
			this.real_name = this.name;
			this.internal_organs.Add( new Obj_Item_Organ_Internal_Alien_Plasmavessel_Large() );
			this.internal_organs.Add( new Obj_Item_Organ_Internal_Alien_Resinspinner() );
			this.internal_organs.Add( new Obj_Item_Organ_Internal_Alien_Acid() );
			this.internal_organs.Add( new Obj_Item_Organ_Internal_Alien_Neurotoxin() );
			this.AddSpell( new Obj_Effect_ProcHolder_Spell_AoeTurf_Repulse_Xeno( this ) );
			this.AddAbility( new Obj_Effect_ProcHolder_Alien_Royal_Praetorian_Evolve() );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: praetorian.dm
		public override dynamic movement_delay(  ) {
			dynamic _default = null;

			_default = base.movement_delay();
			_default += 1;
			return _default;
		}

		// Function from file: mind.dm
		public override void mind_initialize(  ) {
			base.mind_initialize();
			this.mind.special_role = "Praetorian";
			return;
		}

	}

}