// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Crate : Obj_Structure_Closet {

		public bool rigged = false;
		public string sound_effect_open = "sound/machines/click.ogg";
		public string sound_effect_close = "sound/machines/click.ogg";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_opened = "crateopen";
			this.icon_closed = "crate";
			this.icon = "icons/obj/storage.dmi";
			this.icon_state = "crate";
		}

		public Obj_Structure_Closet_Crate ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: crates.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			Obj O = null;
			Obj O2 = null;

			
			switch ((double?)( severity )) {
				case 1:
					
					foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj) )) {
						O = _a;
						
						GlobalFuncs.qdel( O );
					}
					GlobalFuncs.qdel( this );
					return false;
					break;
				case 2:
					
					foreach (dynamic _b in Lang13.Enumerate( this.contents, typeof(Obj) )) {
						O2 = _b;
						

						if ( Rand13.PercentChance( 50 ) ) {
							GlobalFuncs.qdel( O2 );
						}
					}
					GlobalFuncs.qdel( this );
					return false;
					break;
				case 3:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.qdel( this );
					}
					return false;
					break;
			}
			return false;
		}

		// Function from file: crates.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( this.opened ) {
				return base.attackby( (object)(a), (object)(b), (object)(c) );
			} else if ( a is Obj_Item_Stack_PackageWrap ) {
				return null;
			} else if ( a is Obj_Item_Stack_CableCoil ) {
				
				if ( this.rigged ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>" + this + " is already rigged!</span>" );
					return null;
				}

				if ( Lang13.Bool( b.drop_item( a ) ) ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You rig " + this + ".</span>" );
					GlobalFuncs.qdel( a );
					a = null;
					this.rigged = true;
				}
				return null;
			} else if ( a is Obj_Item_Device_Radio_Electropack ) {
				
				if ( this.rigged ) {
					
					if ( Lang13.Bool( b.drop_item( a, this.loc ) ) ) {
						GlobalFuncs.to_chat( b, "<span class='notice'>You attach " + a + " to " + this + ".</span>" );
					}
					return null;
				}
			} else if ( a is Obj_Item_Weapon_Wirecutters ) {
				
				if ( this.rigged ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You cut away the wiring.</span>" );
					GlobalFuncs.playsound( this.loc, "sound/items/Wirecutter.ogg", 100, 1 );
					this.rigged = false;
					return null;
				}
			} else if ( !this.place( b, a ) ) {
				return this.attack_hand( b );
			}
			return null;
		}

		// Function from file: crates.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: crates.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic L = null;

			
			if ( !this.Adjacent( a ) ) {
				return null;
			}

			if ( this.opened ) {
				this.close();
			} else {
				
				if ( this.rigged && Lang13.Bool( Lang13.FindIn( typeof(Obj_Item_Device_Radio_Electropack), this ) ) ) {
					
					if ( a is Mob_Living ) {
						L = a;

						if ( Lang13.Bool( ((Mob_Living)L).electrocute_act( 17, this ) ) ) {
							return null;
						}
					}
				}
				this.open();
			}
			return null;
		}

		// Function from file: crates.dm
		public override int insert( Ent_Dynamic AM = null, bool? include_mobs = null ) {
			include_mobs = include_mobs ?? false;

			Ent_Dynamic L = null;
			Ent_Dynamic B = null;

			
			if ( this.contents.len >= this.storage_capacity ) {
				return -1;
			}

			if ( include_mobs == true && AM is Mob_Living ) {
				L = AM;

				if ( Lang13.Bool( L.locked_to ) ) {
					return 0;
				}
			} else if ( AM is Obj ) {
				
				if ( AM.density || Lang13.Bool( AM.anchored ) || AM is Obj_Structure_Closet ) {
					return 0;
				}
			} else {
				return 0;
			}

			if ( AM is Obj_Structure_Bed ) {
				B = AM;

				if ( B.locked_atoms.len != 0 ) {
					return 0;
				}
			}
			AM.forceMove( this );
			return 1;
		}

		// Function from file: crates.dm
		public override bool close(  ) {
			
			if ( !this.opened ) {
				return false;
			}

			if ( !this.can_close() ) {
				return false;
			}
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), this.sound_effect_close, 15, 1, -3 );
			this.take_contents();
			this.icon_state = this.icon_closed;
			this.opened = false;
			this.density = true;
			return true;
		}

		// Function from file: crates.dm
		public override bool open(  ) {
			
			if ( this.opened ) {
				return false;
			}

			if ( !this.can_open() ) {
				return false;
			}
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), this.sound_effect_open, 15, 1, -3 );
			this.dump_contents();
			this.icon_state = this.icon_opened;
			this.opened = true;
			this.density = false;
			return true;
		}

	}

}