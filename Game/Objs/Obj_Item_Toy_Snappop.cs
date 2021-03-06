// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Toy_Snappop : Obj_Item_Toy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 1;
			this.icon = "icons/obj/toy.dmi";
			this.icon_state = "snappop";
		}

		public Obj_Item_Toy_Snappop ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: toys.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			Ent_Dynamic M = null;
			EffectSystem_SparkSpread s = null;

			
			if ( O is Mob_Living_Carbon_Human ) {
				M = O;

				if ( ((dynamic)M).m_intent == "run" ) {
					((dynamic)M).WriteMsg( "<span class='danger'>You step on the snap pop!</span>" );
					s = new EffectSystem_SparkSpread();
					s.set_up( 2, 0, this );
					s.start();
					new Obj_Effect_Decal_Cleanable_Ash( this.loc );
					this.visible_message( "<span class='danger'>The " + this.name + " explodes!</span>", "<span class='italics'>You hear a snap!</span>" );
					GlobalFuncs.playsound( this, "sound/effects/snap.ogg", 50, 1 );
					GlobalFuncs.qdel( this );
				}
			}
			return null;
		}

		// Function from file: toys.dm
		public override bool throw_impact( dynamic target = null, Mob_Living_Carbon thrower = null ) {
			
			if ( !base.throw_impact( (object)(target), thrower ) ) {
				this.pop_burst();
			}
			return false;
		}

		// Function from file: toys.dm
		public override bool fire_act( bool? air = null, dynamic exposed_temperature = null, double? exposed_volume = null ) {
			this.pop_burst();
			return false;
		}

		// Function from file: toys.dm
		public void pop_burst(  ) {
			EffectSystem_SparkSpread s = null;

			s = new EffectSystem_SparkSpread();
			s.set_up( 3, 1, this );
			s.start();
			new Obj_Effect_Decal_Cleanable_Ash( this.loc );
			this.visible_message( "<span class='warning'>The " + this.name + " explodes!</span>", "<span class='italics'>You hear a snap!</span>" );
			GlobalFuncs.playsound( this, "sound/effects/snap.ogg", 50, 1 );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}