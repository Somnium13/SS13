// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Foamedmetal : Obj_Structure {

		public int metal = 1;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.unacidable = true;
			this.icon = "icons/effects/effects.dmi";
			this.icon_state = "metalfoam";
		}

		// Function from file: effects_foam.dm
		public Obj_Structure_Foamedmetal ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.air_update_turf( true );
			return;
		}

		// Function from file: tgstation.dme
		public override bool CanAtmosPass( dynamic T = null ) {
			return !this.density;
		}

		// Function from file: effects_foam.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 1.5;

			return !this.density;
		}

		// Function from file: effects_foam.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			((Mob)user).changeNext_move( 8 );
			((Ent_Dynamic)user).do_attack_animation( this );

			if ( Rand13.PercentChance( Convert.ToInt32( A.force * 20 - this.metal * 25 ) ) ) {
				((Ent_Static)user).visible_message( "<span class='danger'>" + user + " smashes through the foamed metal!</span>", new Txt( "<span class='danger'>You smash through the foamed metal with " ).the( A ).item().str( "!</span>" ).ToString() );
				GlobalFuncs.qdel( this );
			} else {
				user.WriteMsg( "<span class='warning'>You hit the metal foam to no effect!</span>" );
			}
			return null;
		}

		// Function from file: effects_foam.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			((Mob)a).changeNext_move( 8 );
			((Ent_Dynamic)a).do_attack_animation( this );
			a.WriteMsg( "<span class='warning'>You hit the metal foam but bounce off it!</span>" );
			return null;
		}

		// Function from file: effects_foam.dm
		public override bool attack_slime( Mob_Living_SimpleAnimal_Slime user = null ) {
			user.changeNext_move( 8 );
			user.do_attack_animation( this );

			if ( !user.is_adult ) {
				this.attack_hand( user );
				return false;
			}

			if ( Rand13.PercentChance( 75 - this.metal * 25 ) ) {
				user.visible_message( "<span class='danger'>" + user + " smashes through the foamed metal!</span>", "<span class='danger'>You smash through the metal foam wall!</span>" );
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: effects_foam.dm
		public override bool attack_alien( dynamic user = null ) {
			((Mob)user).changeNext_move( 8 );
			((Ent_Dynamic)user).do_attack_animation( this );

			if ( Rand13.PercentChance( 75 - this.metal * 25 ) ) {
				((Ent_Static)user).visible_message( "<span class='danger'>" + user + " smashes through the foamed metal!</span>", "<span class='danger'>You smash through the metal foam wall!</span>" );
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: effects_foam.dm
		public override bool attack_hulk( Mob_Living_Carbon_Human hulk = null, bool? do_attack_animation = null ) {
			base.attack_hulk( hulk, true );
			hulk.changeNext_move( 8 );
			hulk.do_attack_animation( this );

			if ( Rand13.PercentChance( 75 - this.metal * 25 ) ) {
				hulk.visible_message( "<span class='danger'>" + hulk + " smashes through the foamed metal!</span>", "<span class='danger'>You smash through the metal foam wall!</span>" );
				GlobalFuncs.qdel( this );
			}
			return true;
		}

		// Function from file: effects_foam.dm
		public override bool attack_animal( Mob_Living user = null ) {
			user.changeNext_move( 8 );
			user.do_attack_animation( this );

			if ( Convert.ToDouble( ((dynamic)user).environment_smash ) >= 1 ) {
				user.do_attack_animation( this );
				user.WriteMsg( "<span class='notice'>You smash apart the foam wall.</span>" );
				GlobalFuncs.qdel( this );
				return false;
			}
			return false;
		}

		// Function from file: effects_foam.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			this.attack_hand( a );
			return null;
		}

		// Function from file: effects_foam.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			base.bullet_act( (object)(P), (object)(def_zone) );

			if ( this.metal == 1 || Rand13.PercentChance( 50 ) ) {
				GlobalFuncs.qdel( this );
			}
			return null;
		}

		// Function from file: effects_foam.dm
		public override bool blob_act( dynamic severity = null ) {
			GlobalFuncs.qdel( this );
			return false;
		}

		// Function from file: effects_foam.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			GlobalFuncs.qdel( this );
			return false;
		}

		// Function from file: effects_foam.dm
		public void updateicon(  ) {
			
			if ( this.metal == 1 ) {
				this.icon_state = "metalfoam";
			} else {
				this.icon_state = "ironfoam";
			}
			return;
		}

		// Function from file: effects_foam.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			Ent_Static T = null;

			T = this.loc;
			base.Move( (object)(NewLoc), Dir, step_x, step_y );
			this.move_update_air( T );
			return false;
		}

		// Function from file: effects_foam.dm
		public override dynamic Destroy(  ) {
			this.density = false;
			this.air_update_turf( true );
			return base.Destroy();
		}

	}

}