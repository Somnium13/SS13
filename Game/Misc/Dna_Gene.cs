// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Dna_Gene : Dna {

		public string name = "BASE GENE";
		public string desc = "Oh god who knows what this does.";
		public dynamic block = 0;
		public int flags = 0;
		public bool genetype = false;

		// Function from file: gene.dm
		public virtual dynamic OnDrawUnderlays( Mob_Living_Carbon_Human M = null, string g = null, string fat = null ) {
			return 0;
		}

		// Function from file: gene.dm
		public virtual dynamic OnSay( Mob M = null, dynamic message = null ) {
			return message;
		}

		// Function from file: gene.dm
		public void OnMobDeath( dynamic M = null ) {
			return;
		}

		// Function from file: gene.dm
		public virtual void OnMobLife( Mob_Living M = null ) {
			return;
		}

		// Function from file: gene.dm
		public virtual bool deactivate( dynamic M = null, dynamic connected = null, int? flags = null ) {
			M.active_genes.Remove( this.type );
			return true;
		}

		// Function from file: gene.dm
		public virtual bool can_deactivate( Mob_Living M = null, int? flags = null ) {
			
			if ( ( ( flags ??0) & 4 ) != 0 ) {
				return false;
			}
			return true;
		}

		// Function from file: gene.dm
		public virtual bool activate( dynamic M = null, dynamic connected = null, bool? flags = null ) {
			return false;
		}

		// Function from file: gene.dm
		public virtual bool can_activate( dynamic M = null, bool? flags = null ) {
			return false;
		}

	}

}