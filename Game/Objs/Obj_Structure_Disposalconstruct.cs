// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Disposalconstruct : Obj_Structure {

		public int ptype = 0;
		public int dpdir = 0;
		public string base_state = "pipe-s";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pressure_resistance = 506.625;
			this.starting_materials = new ByTable().Set( "$iron", 1850 );
			this.w_type = 4;
			this.icon = "icons/obj/pipes/disposal.dmi";
			this.icon_state = "conpipe-s";
		}

		public Obj_Structure_Disposalconstruct ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: disposal-construction.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string nicetype = null;
			bool ispipe = false;
			Ent_Static T = null;
			dynamic CP = null;
			dynamic pdir = null;
			dynamic W = null;
			Type pipetype = null;
			dynamic P = null;
			dynamic SortP = null;
			dynamic sort_P = null;
			Obj_Machinery_Disposal P2 = null;
			Obj_Structure_Disposaloutlet P3 = null;
			dynamic Trunk = null;
			Obj_Machinery_Disposal_DeliveryChute P4 = null;

			nicetype = "pipe";
			ispipe = false;
			this.add_fingerprint( b );

			switch ((int)( this.ptype )) {
				case 6:
					nicetype = "disposal bin";
					break;
				case 7:
					nicetype = "disposal outlet";
					break;
				case 8:
					nicetype = "delivery chute";
					break;
				case 9:
				case 10:
					nicetype = "sorting pipe";
					ispipe = true;
					break;
				case 11:
				case 12:
					nicetype = "wrap sorting pipe";
					ispipe = true;
					break;
				default:
					nicetype = "pipe";
					ispipe = true;
					break;
			}
			T = this.loc;

			if ( Lang13.Bool( ((dynamic)T).intact ) ) {
				GlobalFuncs.to_chat( b, "You can only attach the " + nicetype + " if the floor plating is removed." );
				return null;
			}
			CP = Lang13.FindIn( typeof(Obj_Structure_Disposalpipe), T );

			if ( this.ptype >= 6 && this.ptype <= 8 ) {
				
				if ( Lang13.Bool( CP ) ) {
					
					if ( !( CP is Obj_Structure_Disposalpipe_Trunk ) && !Lang13.Bool( this.anchored ) ) {
						GlobalFuncs.to_chat( b, "The " + nicetype + " requires a trunk underneath it in order to work." );
						return null;
					}
				} else if ( !Lang13.Bool( this.anchored ) ) {
					GlobalFuncs.to_chat( b, "The " + nicetype + " requires a trunk underneath it in order to work." );
					return null;
				}
			} else if ( Lang13.Bool( CP ) ) {
				this.update();
				pdir = CP.dpdir;

				if ( CP is Obj_Structure_Disposalpipe_Broken ) {
					pdir = CP.dir;
				}

				if ( Lang13.Bool( pdir & this.dpdir ) ) {
					GlobalFuncs.to_chat( b, "There is already a " + nicetype + " at that location." );
					return null;
				}
			}

			if ( a is Obj_Item_Weapon_Wrench ) {
				
				if ( Lang13.Bool( this.anchored ) ) {
					this.anchored = 0;

					if ( ispipe ) {
						this.level = 2;
						this.density = false;
					} else {
						this.density = true;
					}
					GlobalFuncs.to_chat( b, "You detach the " + nicetype + " from the underfloor." );
				} else {
					this.anchored = 1;

					if ( ispipe ) {
						this.level = 1;
						this.density = false;
					} else {
						this.density = true;
					}
					GlobalFuncs.to_chat( b, "You attach the " + nicetype + " to the underfloor." );
				}
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Ratchet.ogg", 100, 1 );
				this.update();
			} else if ( a is Obj_Item_Weapon_Weldingtool ) {
				
				if ( Lang13.Bool( this.anchored ) ) {
					W = a;

					if ( Lang13.Bool( W.remove_fuel( 0, b ) ) ) {
						GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/welder2.ogg", 100, 1 );
						GlobalFuncs.to_chat( b, "Welding the " + nicetype + " in place." );

						if ( GlobalFuncs.do_after( b, this, 20 ) ) {
							
							if ( !( this != null ) || !((Obj_Item_Weapon_Weldingtool)W).isOn() ) {
								return null;
							}
							GlobalFuncs.to_chat( b, "The " + nicetype + " has been welded in place!" );
							this.update();

							if ( ispipe ) {
								pipetype = this.dpipetype();
								P = Lang13.Call( pipetype, this.loc );
								this.transfer_fingerprints_to( P );
								P.base_icon_state = this.base_state;
								P.dir = this.dir;
								P.dpdir = this.dpdir;
								P.updateicon();

								switch ((int)( this.ptype )) {
									case 9:
									case 10:
										SortP = P;
										((Obj_Structure_Disposalpipe_Sortjunction)SortP).updatedir();
										break;
									case 11:
									case 12:
										sort_P = P;
										((Ent_Dynamic)sort_P).update_dir();
										break;
								}
							} else if ( this.ptype == 6 ) {
								P2 = new Obj_Machinery_Disposal( this.loc );
								this.transfer_fingerprints_to( P2 );
								P2.mode = 0;
							} else if ( this.ptype == 7 ) {
								P3 = new Obj_Structure_Disposaloutlet( this.loc );
								this.transfer_fingerprints_to( P3 );
								P3.dir = this.dir;
								Trunk = CP;
								Trunk.linked = P3;
							} else if ( this.ptype == 8 ) {
								P4 = new Obj_Machinery_Disposal_DeliveryChute( this.loc );
								this.transfer_fingerprints_to( P4 );
								P4.dir = this.dir;
							}
							GlobalFuncs.qdel( this );
							return null;
						}
					} else {
						GlobalFuncs.to_chat( b, "You need more welding fuel to complete this task." );
						return null;
					}
				} else {
					GlobalFuncs.to_chat( b, "You need to attach it to the plating first!" );
					return null;
				}
			}
			return null;
		}

		// Function from file: disposal-construction.dm
		public override void hide( bool? h = null ) {
			this.invisibility = ( h == true && this.level == 1 ? 101 : 0 );
			this.update();
			return;
		}

		// Function from file: disposal-construction.dm
		public Type dpipetype(  ) {
			
			switch ((int)( this.ptype )) {
				case 0:
				case 1:
					return typeof(Obj_Structure_Disposalpipe_Segment);
					break;
				case 2:
				case 3:
				case 4:
					return typeof(Obj_Structure_Disposalpipe_Junction);
					break;
				case 5:
					return typeof(Obj_Structure_Disposalpipe_Trunk);
					break;
				case 6:
					return typeof(Obj_Machinery_Disposal);
					break;
				case 7:
					return typeof(Obj_Structure_Disposaloutlet);
					break;
				case 8:
					return typeof(Obj_Machinery_Disposal_DeliveryChute);
					break;
				case 9:
				case 10:
					return typeof(Obj_Structure_Disposalpipe_Sortjunction);
					break;
				case 11:
				case 12:
					return typeof(Obj_Structure_Disposalpipe_Wrapsortjunction);
					break;
			}
			return null;
		}

		// Function from file: disposal-construction.dm
		public void update(  ) {
			int flip = 0;
			int left = 0;
			int right = 0;

			flip = Num13.Rotate( this.dir, 180 );
			left = Num13.Rotate( this.dir, 90 );
			right = Num13.Rotate( this.dir, -90 );

			switch ((int)( this.ptype )) {
				case 0:
					this.base_state = "pipe-s";
					this.dpdir = this.dir | flip;
					break;
				case 1:
					this.base_state = "pipe-c";
					this.dpdir = this.dir | right;
					break;
				case 2:
					this.base_state = "pipe-j1";
					this.dpdir = this.dir | right | flip;
					break;
				case 3:
					this.base_state = "pipe-j2";
					this.dpdir = this.dir | left | flip;
					break;
				case 4:
					this.base_state = "pipe-y";
					this.dpdir = this.dir | left | right;
					break;
				case 5:
					this.base_state = "pipe-t";
					this.dpdir = this.dir;
					break;
				case 6:
					
					if ( Lang13.Bool( this.anchored ) ) {
						this.base_state = "disposal";
					} else {
						this.base_state = "condisposal";
					}
					break;
				case 7:
					this.base_state = "outlet";
					this.dpdir = this.dir;
					break;
				case 8:
					this.base_state = "intake";
					this.dpdir = this.dir;
					break;
				case 9:
				case 11:
					this.base_state = "pipe-j1s";
					this.dpdir = this.dir | right | flip;
					break;
				case 10:
				case 12:
					this.base_state = "pipe-j2s";
					this.dpdir = this.dir | left | flip;
					break;
			}

			if ( this.ptype < 6 || this.ptype > 8 ) {
				this.icon_state = "con" + this.base_state;
			} else {
				this.icon_state = this.base_state;
			}

			if ( this.invisibility != 0 ) {
				//this.icon -= "#00000080"; FIXME wat?
			}
			return;
		}

		// Function from file: disposal-construction.dm
		[Verb]
		[VerbInfo( name: "Flip Pipe", group: "Object", access: VerbAccess.InView, range: 1 )]
		public void flip(  ) {
			
			if ( Task13.User.isUnconscious() ) {
				return;
			}

			if ( Lang13.Bool( this.anchored ) ) {
				GlobalFuncs.to_chat( Task13.User, "You must unfasten the pipe before flipping it." );
				return;
			}
			this.dir = Num13.Rotate( this.dir, 180 );

			switch ((int)( this.ptype )) {
				case 2:
					this.ptype = 3;
					break;
				case 3:
					this.ptype = 2;
					break;
				case 9:
					this.ptype = 10;
					break;
				case 10:
					this.ptype = 9;
					break;
				case 11:
					this.ptype = 12;
					break;
				case 12:
					this.ptype = 11;
					break;
			}
			this.update();
			return;
		}

		// Function from file: disposal-construction.dm
		[Verb]
		[VerbInfo( name: "Rotate Pipe", group: "Object", access: VerbAccess.InView, range: 1 )]
		public void rotate(  ) {
			
			if ( Task13.User.isUnconscious() ) {
				return;
			}

			if ( Lang13.Bool( this.anchored ) ) {
				GlobalFuncs.to_chat( Task13.User, "You must unfasten the pipe before rotating it." );
				return;
			}
			this.dir = Num13.Rotate( this.dir, -90 );
			this.update();
			return;
		}

	}

}