// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Ore_BluespaceCrystal : Obj_Item_Weapon_Ore {

		public double? blink_range = 8;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 1;
			this.origin_tech = "bluespace=4;materials=3";
			this.points = 50;
			this.icon = "icons/obj/telescience.dmi";
			this.icon_state = "bluespace_crystal";
		}

		// Function from file: bscrystal.dm
		public Obj_Item_Weapon_Ore_BluespaceCrystal ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.pixel_x = Rand13.Int( -5, 5 );
			this.pixel_y = Rand13.Int( -5, 5 );
			return;
		}

		// Function from file: bscrystal.dm
		public override bool throw_impact( dynamic target = null, Mob_Living_Carbon thrower = null ) {
			dynamic T = null;

			
			if ( !base.throw_impact( (object)(target), thrower ) ) {
				this.visible_message( "<span class='notice'>" + this + " fizzles and disappears upon impact!</span>" );
				T = GlobalFuncs.get_turf( target );
				GlobalFuncs.PoolOrNew( typeof(Obj_Effect_ParticleEffect_Sparks), T );
				GlobalFuncs.playsound( this.loc, "sparks", 50, 1 );

				if ( target is Mob_Living ) {
					this.blink_mob( target );
				}
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: bscrystal.dm
		public void blink_mob( dynamic L = null ) {
			GlobalFuncs.do_teleport( L, GlobalFuncs.get_turf( L ), this.blink_range, null, null, null, "sound/effects/phasein.ogg" );
			return;
		}

		// Function from file: bscrystal.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			((Ent_Static)user).visible_message( "<span class='warning'>" + user + " crushes " + this + "!</span>", "<span class='danger'>You crush " + this + "!</span>" );
			GlobalFuncs.PoolOrNew( typeof(Obj_Effect_ParticleEffect_Sparks), this.loc );
			GlobalFuncs.playsound( this.loc, "sparks", 50, 1 );
			this.blink_mob( user );
			((Mob)user).unEquip( this );
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}