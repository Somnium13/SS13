// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class EffectSystem_TrailFollow_Steam : EffectSystem_TrailFollow {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.effect_type = typeof(Obj_Effect_ParticleEffect_Steam);
		}

		// Function from file: effects_other.dm
		public override void start(  ) {
			dynamic I = null;

			
			if ( !this.on ) {
				this.on = true;
				this.processing = true;

				if ( !Lang13.Bool( this.oldposition ) ) {
					this.oldposition = GlobalFuncs.get_turf( this.holder );
				}
			}

			if ( this.processing ) {
				this.processing = false;

				if ( Convert.ToDouble( this.number ) < 3 ) {
					I = GlobalFuncs.PoolOrNew( typeof(Obj_Effect_ParticleEffect_Steam), this.oldposition );
					this.number++;
					I.dir = this.holder.dir;
					this.oldposition = GlobalFuncs.get_turf( this.holder );
					Task13.Schedule( 10, (Task13.Closure)(() => {
						GlobalFuncs.qdel( I );
						this.number--;
						return;
					}));
				}
				Task13.Schedule( 2, (Task13.Closure)(() => {
					
					if ( this.on ) {
						this.processing = true;
						this.start();
					}
					return;
				}));
			}
			return;
		}

	}

}