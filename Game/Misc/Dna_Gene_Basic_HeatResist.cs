// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Dna_Gene_Basic_HeatResist : Dna_Gene_Basic {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Heat Resistance";
			this.activation_messages = new ByTable(new object [] { "Your skin is icy to the touch." });
			this.deactivation_messages = new ByTable(new object [] { "Your skin stops feeling icy." });
			this.drug_activation_messages = new ByTable();
			this.drug_deactivation_messages = new ByTable();
			this.mutation = 106;
		}

		// Function from file: powers.dm
		public Dna_Gene_Basic_HeatResist (  ) {
			this.block = GlobalVars.COLDBLOCK;
			return;
		}

		// Function from file: powers.dm
		public override dynamic OnDrawUnderlays( Mob_Living_Carbon_Human M = null, string g = null, string fat = null ) {
			return "cold" + fat + "_s";
		}

		// Function from file: powers.dm
		public override bool can_activate( dynamic M = null, bool? flags = null ) {
			int _prob = 0;

			
			if ( ( ( flags == true ?1:0) & 1 ) != 0 ) {
				return !M.active_genes.Contains( typeof(Dna_Gene_Basic_ColdResist) );
			}
			_prob = 15;

			if ( Lang13.Bool( M.mutations.Contains( 2 ) ) ) {
				_prob = 5;
			}

			if ( GlobalFuncs.probinj( _prob, ( flags == true ?1:0) & 1 ) ) {
				return true;
			}
			return false;
		}

	}

}