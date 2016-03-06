// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Clipboard : Obj_Item_Weapon {

		public dynamic haspen = null;
		public dynamic toppaper = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "clipboard";
			this.w_class = 2;
			this.throw_speed = 3;
			this.slot_flags = 512;
			this.burn_state = 0;
			this.icon = "icons/obj/bureaucracy.dmi";
			this.icon_state = "clipboard";
		}

		// Function from file: clipboard.dm
		public Obj_Item_Weapon_Clipboard ( dynamic loc = null ) : base( (object)(loc) ) {
			this.update_icon();
			return;
		}

		// Function from file: clipboard.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			dynamic W = null;
			dynamic P = null;
			dynamic P2 = null;
			dynamic newtop = null;
			dynamic P3 = null;
			dynamic P4 = null;

			base.Topic( href, href_list, (object)(hsrc) );

			if ( Task13.User.stat != 0 || Task13.User.restrained() ) {
				return null;
			}

			if ( Task13.User.contents.Find( this ) != 0 ) {
				
				if ( Lang13.Bool( href_list["pen"] ) ) {
					
					if ( Lang13.Bool( this.haspen ) ) {
						this.haspen.loc = Task13.User.loc;
						Task13.User.put_in_hands( this.haspen );
						this.haspen = null;
					}
				}

				if ( Lang13.Bool( href_list["addpen"] ) ) {
					
					if ( !Lang13.Bool( this.haspen ) ) {
						
						if ( Task13.User.get_active_hand() is Obj_Item_Weapon_Pen ) {
							W = Task13.User.get_active_hand();

							if ( !Task13.User.unEquip( W ) ) {
								return null;
							}
							W.loc = this;
							this.haspen = W;
							Task13.User.WriteMsg( "<span class='notice'>You slot " + W + " into " + this + ".</span>" );
						}
					}
				}

				if ( Lang13.Bool( href_list["write"] ) ) {
					P = Lang13.FindObj( href_list["write"] );

					if ( P is Obj_Item && P.loc == this ) {
						
						if ( Lang13.Bool( Task13.User.get_active_hand() ) ) {
							((Ent_Static)P).attackby( Task13.User.get_active_hand(), Task13.User );
						}
					}
				}

				if ( Lang13.Bool( href_list["remove"] ) ) {
					P2 = Lang13.FindObj( href_list["remove"] );

					if ( P2 is Obj_Item && P2.loc == this ) {
						P2.loc = Task13.User.loc;
						Task13.User.put_in_hands( P2 );

						if ( P2 == this.toppaper ) {
							this.toppaper = null;
							newtop = Lang13.FindIn( typeof(Obj_Item_Weapon_Paper), this );

							if ( Lang13.Bool( newtop ) && newtop != P2 ) {
								this.toppaper = newtop;
							} else {
								this.toppaper = null;
							}
						}
					}
				}

				if ( Lang13.Bool( href_list["read"] ) ) {
					P3 = Lang13.FindObj( href_list["read"] );

					if ( P3 is Obj_Item_Weapon_Paper && P3.loc == this ) {
						Task13.User.__CallVerb("Examine", P3 );
					}
				}

				if ( Lang13.Bool( href_list["top"] ) ) {
					P4 = Lang13.FindObj( href_list["top"] );

					if ( P4 is Obj_Item && P4.loc == this ) {
						this.toppaper = P4;
						Task13.User.WriteMsg( "<span class='notice'>You move " + P4.name + " to the top.</span>" );
					}
				}
				this.attack_self( Task13.User );
				this.update_icon();
			}
			return null;
		}

		// Function from file: clipboard.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			string dat = null;
			dynamic P = null;

			dat = "<title>Clipboard</title>";

			if ( Lang13.Bool( this.haspen ) ) {
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";pen=1'>Remove Pen</A><BR><HR>" ).ToString();
			} else {
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";addpen=1'>Add Pen</A><BR><HR>" ).ToString();
			}

			if ( Lang13.Bool( this.toppaper ) ) {
				P = this.toppaper;
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";write=" ).Ref( P ).str( "'>Write</A> <A href='?src=" ).Ref( this ).str( ";remove=" ).Ref( P ).str( "'>Remove</A> - <A href='?src=" ).Ref( this ).str( ";read=" ).Ref( P ).str( "'>" ).item( P.name ).str( "</A><BR><HR>" ).ToString();

				foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj_Item_Weapon_Paper) )) {
					P = _a;
					

					if ( P == this.toppaper ) {
						continue;
					}
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";write=" ).Ref( P ).str( "'>Write</A> <A href='?src=" ).Ref( this ).str( ";remove=" ).Ref( P ).str( "'>Remove</A> <A href='?src=" ).Ref( this ).str( ";top=" ).Ref( P ).str( "'>Move to top</A> - <A href='?src=" ).Ref( this ).str( ";read=" ).Ref( P ).str( "'>" ).item( P.name ).str( "</A><BR>" ).ToString();
				}
			}
			Interface13.Browse( user, dat, "window=clipboard" );
			GlobalFuncs.onclose( user, "clipboard" );
			this.add_fingerprint( Task13.User );
			return null;
		}

		// Function from file: clipboard.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Weapon_Paper ) {
				
				if ( !((Mob)user).unEquip( A ) ) {
					return null;
				}
				A.loc = this;
				this.toppaper = A;
				user.WriteMsg( new Txt( "<span class='notice'>You clip the paper onto " ).the( this ).item().str( ".</span>" ).ToString() );
				this.update_icon();
			} else if ( Lang13.Bool( this.toppaper ) ) {
				((Ent_Static)this.toppaper).attackby( Task13.User.get_active_hand(), Task13.User );
				this.update_icon();
			}
			return null;
		}

		// Function from file: clipboard.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.overlays.Cut();

			if ( Lang13.Bool( this.toppaper ) ) {
				this.overlays.Add( this.toppaper.icon_state );
				this.overlays.Add( this.toppaper.overlays );
			}

			if ( Lang13.Bool( this.haspen ) ) {
				this.overlays.Add( "clipboard_pen" );
			}
			this.overlays.Add( "clipboard_over" );
			return false;
		}

	}

}