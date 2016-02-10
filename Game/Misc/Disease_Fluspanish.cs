// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease_Fluspanish : Disease {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Spanish inquisition Flu";
			this.max_stages = 3;
			this.spread = "Airborne";
			this.cure = "Spaceacillin & Anti-bodies to the common flu";
			this.cure_id = "spaceacillin";
			this.cure_chance = 10;
			this.agent = "1nqu1s1t10n flu virion";
			this.affected_species = new ByTable(new object [] { "Human" });
			this.permeability_mod = 0.75;
			this.desc = "If left untreated the subject will burn to death for being a heretic.";
			this.severity = "Serious";
		}

		public Disease_Fluspanish ( bool? process = null, Disease_Advance D = null ) : base( process, D ) {
			
		}

	}

}