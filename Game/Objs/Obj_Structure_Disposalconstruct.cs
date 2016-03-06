// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Disposalconstruct : Obj_Structure {

		public dynamic ptype = 0;
		public int dpdir = 0;
		public string base_state = "pipe-s";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pressure_resistance = 506.625;
			this.icon = "icons/obj/atmospherics/pipes/disposal.dmi";
			this.icon_state = "conpipe-s";
		}

		// Function from file: disposal-construction.dm
		public Obj_Structure_Disposalconstruct ( dynamic loc = null, dynamic pipe_type = null, double? direction = null ) : base( (object)(loc) ) {
			direction = direction ?? 1;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Lang13.Bool( pipe_type ) ) {
				this.ptype = pipe_type;
			}
			this.dir = ((int)( direction ??0 ));
			return;
		}

		// Function from file: disposal-construction.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
        
            string nicetype = null;
			bool ispipe = false;
			Ent_Static T = null;
			dynamic CP = null;
			dynamic pdir = null;
			dynamic W = null;
			Type pipetype = null;
			dynamic P = null;
			dynamic SortP = null;
			Obj_Machinery_Disposal_Bin B = null;
			Obj_Structure_Disposaloutlet P2 = null;
			Obj_Machinery_Disposal_DeliveryChute P3 = null;

			nicetype = "pipe";
			ispipe = this.is_pipe();
			this.add_fingerprint( user );

			dynamic _a = this.ptype; // Was a switch-case, sorry for the mess.
			if ( _a==6 ) {
				nicetype = "disposal bin";
			} else if ( _a==7 ) {
				nicetype = "disposal outlet";
			} else if ( _a==8 ) {
				nicetype = "delivery chute";
			} else if ( _a==9 || _a==10 ) {
				nicetype = "sorting pipe";
			} else {
				nicetype = "pipe";
			}
			T = this.loc;

			if ( Lang13.Bool( ((dynamic)T).intact ) && T is Tile_Simulated_Floor ) {
				user.WriteMsg( "<span class='warning'>You can only attach the " + nicetype + " if the floor plating is removed!</span>" );
				return null;
			}

			if ( !ispipe && T is Tile_Simulated_Wall ) {
				user.WriteMsg( "<span class='warning'>You can't build " + nicetype + "s on walls, only disposal pipes!</span>" );
				return null;
			}
			CP = Lang13.FindIn( typeof(Obj_Structure_Disposalpipe), T );

			if ( A is Obj_Item_Weapon_Wrench ) {
				
				if ( Lang13.Bool( this.anchored ) ) {
					this.anchored = 0;

					if ( ispipe ) {
						this.level = 2;
					}
					this.density = false;
					user.WriteMsg( "<span class='notice'>You detach the " + nicetype + " from the underfloor.</span>" );
				} else {
					
					if ( !this.is_pipe() ) {
						
						if ( Lang13.Bool( CP ) ) {
							
							if ( !( CP is Obj_Structure_Disposalpipe_Trunk ) ) {
								user.WriteMsg( "<span class='warning'>The " + nicetype + " requires a trunk underneath it in order to work!</span>" );
								return null;
							}
						} else {
							user.WriteMsg( "<span class='warning'>The " + nicetype + " requires a trunk underneath it in order to work!</span>" );
							return null;
						}
					} else if ( Lang13.Bool( CP ) ) {
						this.update();
						pdir = CP.dpdir;

						if ( CP is Obj_Structure_Disposalpipe_Broken ) {
							pdir = CP.dir;
						}

						if ( Lang13.Bool( pdir & this.dpdir ) ) {
							user.WriteMsg( "<span class='warning'>There is already a " + nicetype + " at that location!</span>" );
							return null;
						}
					}
					this.anchored = 1;

					if ( ispipe ) {
						this.level = 1;
					}
					this.density = false;
					user.WriteMsg( "<span class='notice'>You attach the " + nicetype + " to the underfloor.</span>" );
				}
				GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 100, 1 );
				this.update();
			} else if ( A is Obj_Item_Weapon_Weldingtool ) {
				
				if ( Lang13.Bool( this.anchored ) ) {
					W = A;

					if ( ((Obj_Item_Weapon_Weldingtool)W).remove_fuel( 0, user ) ) {
						GlobalFuncs.playsound( this.loc, "sound/items/welder2.ogg", 100, 1 );
						user.WriteMsg( "<span class='notice'>You start welding the " + nicetype + " in place...</span>" );

						if ( GlobalFuncs.do_after( user, 20 / A.toolspeed, null, this ) ) {
							
							if ( !( this.loc != null ) || !((Obj_Item_Weapon_Weldingtool)W).isOn() ) {
								return null;
							}
							user.WriteMsg( "<span class='notice'>The " + nicetype + " has been welded in place.</span>" );
							this.update();

							if ( ispipe ) {
								pipetype = this.dpipetype();
								P = Lang13.Call( pipetype, this.loc, this );
								P.updateicon();
								this.transfer_fingerprints_to( P );

								if ( this.ptype == 9 || this.ptype == 10 ) {
									SortP = P;
									((Obj_Structure_Disposalpipe_Sortjunction)SortP).updatedir();
								}
							} else if ( this.ptype == 6 ) {                                
								B = new Obj_Machinery_Disposal_Bin( this.loc, this );
								B.mode = 0;
								this.transfer_fingerprints_to( B );
							} else if ( this.ptype == 7 ) {
								P2 = new Obj_Structure_Disposaloutlet( this.loc, this );
								this.transfer_fingerprints_to( P2 );
							} else if ( this.ptype == 8 ) {
								P3 = new Obj_Machinery_Disposal_DeliveryChute( this.loc, this );
								this.transfer_fingerprints_to( P3 );
							}
							return null;
						}
					}
				} else {
					user.WriteMsg( "<span class='warning'>You need to attach it to the plating first!</span>" );
					return null;
				}
			}
			return null;
		}

		// Function from file: disposal-construction.dm
		public override bool AltClick( Mob user = null ) {
			base.AltClick( user );

			if ( user.incapacitated() ) {
				user.WriteMsg( "<span class='warning'>You can't do that right now!</span>" );
				return false;
			}

			if ( !( Map13.GetDistance( this, user ) <= 1 ) ) {
				return false;
			} else {
				this.__CallVerb("Rotate Pipe" );
			}
			return false;
		}

		// Function from file: disposal-construction.dm
		public override void hide( bool h = false ) {
			this.invisibility = ( h && this.level == 1 ? 101 : 0 );
			this.update();
			return;
		}

		// Function from file: disposal-construction.dm
		public bool can_place(  ) {
			Obj_Structure_Disposalconstruct DC = null;

			
			if ( this.is_pipe() ) {
				return true;
			}

			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_turf( this ), typeof(Obj_Structure_Disposalconstruct) )) {
				DC = _a;
				

				if ( DC == this ) {
					continue;
				}

				if ( !DC.is_pipe() ) {
					return false;
				}
			}
			return true;
		}

		// Function from file: disposal-construction.dm
		public bool is_pipe(  ) {
			return !( Convert.ToDouble( this.ptype ) >= 6 && Convert.ToDouble( this.ptype ) <= 8 );
		}

		// Function from file: disposal-construction.dm
		public Type dpipetype(  ) {
			
			dynamic _a = this.ptype; // Was a switch-case, sorry for the mess.
			if ( _a==0 || _a==1 ) {
				return typeof(Obj_Structure_Disposalpipe_Segment);
			} else if ( _a==2 || _a==3 || _a==4 ) {
				return typeof(Obj_Structure_Disposalpipe_Junction);
			} else if ( _a==5 ) {
				return typeof(Obj_Structure_Disposalpipe_Trunk);
			} else if ( _a==6 ) {
				return typeof(Obj_Machinery_Disposal_Bin);
			} else if ( _a==7 ) {
				return typeof(Obj_Structure_Disposaloutlet);
			} else if ( _a==8 ) {
				return typeof(Obj_Machinery_Disposal_DeliveryChute);
			} else if ( _a==9 || _a==10 ) {
				return typeof(Obj_Structure_Disposalpipe_Sortjunction);
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

			dynamic _a = this.ptype; // Was a switch-case, sorry for the mess.
			if ( _a==0 ) {
				this.base_state = "pipe-s";
				this.dpdir = this.dir | flip;
			} else if ( _a==1 ) {
				this.base_state = "pipe-c";
				this.dpdir = this.dir | right;
			} else if ( _a==2 ) {
				this.base_state = "pipe-j1";
				this.dpdir = this.dir | right | flip;
			} else if ( _a==3 ) {
				this.base_state = "pipe-j2";
				this.dpdir = this.dir | left | flip;
			} else if ( _a==4 ) {
				this.base_state = "pipe-y";
				this.dpdir = this.dir | left | right;
			} else if ( _a==5 ) {
				this.base_state = "pipe-t";
				this.dpdir = this.dir;
			} else if ( _a==6 ) {
				
				if ( Lang13.Bool( this.anchored ) ) {
					this.base_state = "disposal";
				} else {
					this.base_state = "condisposal";
				}
			} else if ( _a==7 ) {
				this.base_state = "outlet";
				this.dpdir = this.dir;
			} else if ( _a==8 ) {
				this.base_state = "intake";
				this.dpdir = this.dir;
			} else if ( _a==9 ) {
				this.base_state = "pipe-j1s";
				this.dpdir = this.dir | right | flip;
			} else if ( _a==10 ) {
				this.base_state = "pipe-j2s";
				this.dpdir = this.dir | left | flip;
			}

			if ( this.is_pipe() ) {
				this.icon_state = "con" + this.base_state;
			} else {
				this.icon_state = this.base_state;
			}
			this.alpha = ( this.invisibility != 0 ? 0 : 255 );
			return;
		}

		// Function from file: disposal-construction.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );
			user.WriteMsg( "<span class='notice'>Alt-click to rotate it clockwise.</span>" );
			return 0;
		}

		// Function from file: disposal-construction.dm
		[Verb]
		[VerbInfo( name: "Flip Pipe", group: "Object", access: VerbAccess.InView, range: 1 )]
		public void flip(  ) {
			
			if ( Task13.User.stat != 0 || !Task13.User.canmove || Task13.User.restrained() ) {
				return;
			}

			if ( Lang13.Bool( this.anchored ) ) {
				Task13.User.WriteMsg( "<span class='warning'>You must unfasten the pipe before flipping it!</span>" );
				return;
			}
			this.dir = Num13.Rotate( this.dir, 180 );

			dynamic _a = this.ptype; // Was a switch-case, sorry for the mess.
			if ( _a==2 ) {
				this.ptype = 3;
			} else if ( _a==3 ) {
				this.ptype = 2;
			} else if ( _a==9 ) {
				this.ptype = 10;
			} else if ( _a==10 ) {
				this.ptype = 9;
			}
			this.update();
			return;
		}

		// Function from file: disposal-construction.dm
		[Verb]
		[VerbInfo( name: "Rotate Pipe", group: "Object", access: VerbAccess.InView, range: 1 )]
		public void rotate(  ) {
			
			if ( Task13.User.stat != 0 || !Task13.User.canmove || Task13.User.restrained() ) {
				return;
			}

			if ( Lang13.Bool( this.anchored ) ) {
				Task13.User.WriteMsg( "<span class='warning'>You must unfasten the pipe before rotating it!</span>" );
				return;
			}
			this.dir = Num13.Rotate( this.dir, -90 );
			this.update();
			return;
		}

	}

}