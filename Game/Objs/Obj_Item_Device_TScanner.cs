// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_TScanner : Obj_Item_Device {

		public bool on = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.slot_flags = 512;
			this.w_class = 2;
			this.item_state = "electronic";
			this.materials = new ByTable().Set( "$metal", 150 );
			this.origin_tech = "magnets=1;engineering=1";
			this.icon_state = "t-ray0";
		}

		public Obj_Item_Device_TScanner ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: scanners.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( !this.on ) {
				GlobalVars.SSobj.processing.Remove( this );
				return null;
			}
			this.scan();
			return null;
		}

		// Function from file: scanners.dm
		public virtual void scan(  ) {
			dynamic T = null;
			Obj O = null;
			dynamic L = null;
			Ent_Static U = null;

			
			foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInRange( this.loc, 2 ) )) {
				T = _b;
				

				foreach (dynamic _a in Lang13.Enumerate( T.contents, typeof(Obj) )) {
					O = _a;
					

					if ( O.level != 1 ) {
						continue;
					}
					L = Lang13.FindIn( typeof(Mob_Living), O );

					if ( O.invisibility == 101 ) {
						O.invisibility = 0;

						if ( Lang13.Bool( L ) ) {
							this.flick_sonar( O );
						}
						Task13.Schedule( 10, (Task13.Closure)(() => {
							
							if ( O != null && O.loc != null ) {
								U = O.loc;

								if ( Lang13.Bool( ((dynamic)U).intact ) ) {
									O.invisibility = 101;
								}
							}
							return;
						}));
					} else if ( Lang13.Bool( L ) ) {
						this.flick_sonar( O );
					}
				}
			}
			return;
		}

		// Function from file: scanners.dm
		public void flick_sonar( Obj pipe = null ) {
			Image I = null;
			ByTable nearby = null;
			dynamic M = null;

			I = new Image( "icons/effects/effects.dmi", pipe, "blip", pipe.layer + 1 );
			I.alpha = 128;
			nearby = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, pipe ) )) {
				M = _a;
				

				if ( Lang13.Bool( M.client ) ) {
					nearby.Or( M.client );
				}
			}
			GlobalFuncs.flick_overlay( I, nearby, 8 );
			return;
		}

		// Function from file: scanners.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.on = !this.on;
			this.icon_state = String13.SubStr( this.icon_state, 1, Lang13.Length( this.icon_state ) ) + ( "" + this.on );

			if ( this.on ) {
				GlobalVars.SSobj.processing.Or( this );
			}
			return null;
		}

	}

}