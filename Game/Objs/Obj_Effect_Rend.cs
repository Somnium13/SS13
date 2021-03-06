// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Rend : Obj_Effect {

		public Type spawn_path = typeof(Mob_Living_SimpleAnimal_Cow);
		public int spawn_amt_left = 20;
		public bool spawn_fast = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.unacidable = true;
			this.anchored = 1;
			this.icon = "icons/obj/biomass.dmi";
			this.icon_state = "rift";
		}

		// Function from file: artefact.dm
		public Obj_Effect_Rend ( dynamic loc = null, Type spawn_type = null, int spawn_amt = 0, string desc = null, bool spawn_fast = false ) : base( (object)(loc) ) {
			this.spawn_path = spawn_type;
			this.spawn_amt_left = spawn_amt;
			this.desc = desc;
			this.spawn_fast = spawn_fast;
			GlobalVars.SSobj.processing.Or( this );
			return;
		}

		// Function from file: artefact.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Weapon_Nullrod ) {
				((Ent_Static)user).visible_message( new Txt( "<span class='danger'>" ).item( user ).str( " seals " ).the( this ).item().str( " with " ).the( A ).item().str( ".</span>" ).ToString() );
				GlobalFuncs.qdel( this );
				return null;
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: artefact.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( !this.spawn_fast ) {
				
				if ( Lang13.Bool( Lang13.FindIn( typeof(Mob), this.loc ) ) ) {
					return null;
				}
			}
			Lang13.Call( this.spawn_path, this.loc );
			this.spawn_amt_left--;

			if ( this.spawn_amt_left <= 0 ) {
				GlobalFuncs.qdel( this );
			}
			return null;
		}

	}

}