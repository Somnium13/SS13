// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Cooking_Icemachine : Obj_Machinery_Cooking {

		public dynamic beaker = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "icecream_vat";
		}

		// Function from file: icecreamvat.dm
		public Obj_Machinery_Cooking_Icemachine ( dynamic loc = null ) : base( (object)(loc) ) {
			this.reagents = new Reagents( 500 );
			this.reagents.my_atom = this;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: icecreamvat.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic _default = null;

			dynamic id = null;
			double? amount = null;
			dynamic id2 = null;
			double? amount2 = null;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Icecream C = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return _default;
			}
			this.add_fingerprint( Task13.User );
			Task13.User.set_machine( this );

			if ( Lang13.Bool( href_list["close"] ) ) {
				Interface13.Browse( Task13.User, null, "window=cream_master" );
				Task13.User.unset_machine();
			} else if ( Lang13.Bool( href_list["add"] ) && Lang13.Bool( href_list["amount"] ) && Lang13.Bool( this.beaker ) ) {
				id = href_list["add"];
				amount = String13.ParseNumber( href_list["amount"] );

				if ( ( amount ??0) > 0 ) {
					((Reagents)this.beaker.reagents).trans_id_to( this, id, amount );
				}
			} else if ( Lang13.Bool( href_list["remove"] ) && Lang13.Bool( href_list["amount"] ) ) {
				id2 = href_list["remove"];
				amount2 = String13.ParseNumber( href_list["amount"] );

				if ( ((Reagents)this.reagents).has_reagent( id2 ) ) {
					
					if ( Lang13.Bool( this.beaker ) ) {
						((Reagents)this.reagents).trans_id_to( this.beaker, id2, amount2 );
					} else {
						((Reagents)this.reagents).remove_reagent( id2, amount2 );
					}
				}
			} else if ( Lang13.Bool( href_list["main"] ) ) {
				this.attack_hand( Task13.User );
			} else if ( Lang13.Bool( href_list["eject"] ) && Lang13.Bool( this.beaker ) ) {
				((Reagents)this.reagents).trans_to( this.beaker, this.reagents.total_volume );
				this.beaker.loc = this.loc;
				this.beaker = null;
			} else if ( Lang13.Bool( href_list["synthcond"] ) && Lang13.Bool( href_list["type"] ) ) {
				
				switch ((int?)( String13.ParseNumber( href_list["type"] ) )) {
					case 2:
						_default = Rand13.Pick(new object [] { "cola", "dr_gibb", "space_up", "spacemountainwind" });
						break;
					case 3:
						_default = Rand13.Pick(new object [] { "kahlua", "vodka", "rum", "gin" });
						break;
					case 4:
						_default = "cream";
						break;
					case 5:
						_default = "water";
						break;
				}
				((Reagents)this.reagents).add_reagent( _default, 5 );
			} else if ( Lang13.Bool( href_list["createcup"] ) || Lang13.Bool( href_list["createcone"] ) ) {
				C = null;

				if ( Lang13.Bool( href_list["createcup"] ) ) {
					C = new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Icecream_Icecreamcup( this.loc );
				} else {
					C = new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Icecream_Icecreamcone( this.loc );
				}
				C.name = "" + this.generateName( ((Reagents)this.reagents).get_master_reagent_name() ) + " " + C.name;
				C.pixel_x = Rand13.Int( -8, 8 );
				C.pixel_y = -16;
				((Reagents)this.reagents).trans_to( C, 30 );
				((Reagents)this.reagents).clear_reagents();
				C.update_icon();
			}
			this.updateUsrDialog();
			return _default;
		}

		// Function from file: icecreamvat.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string dat = null;
			Browser popup = null;

			
			if ( a is Mob_Dead_Observer ) {
				GlobalFuncs.to_chat( a, "Your ghostly hand goes straight through." );
			}
			((Mob)a).set_machine( this );
			dat = "";

			if ( Lang13.Bool( this.beaker ) ) {
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";eject=1'>Eject container and end transfer.</A><BR>" ).ToString();

				if ( !Lang13.Bool( this.beaker.reagents.total_volume ) ) {
					dat += "Container is empty.<BR><HR>";
				} else {
					dat += this.showReagents( 1 );
				}
				dat += this.showReagents( 2 );
				dat += this.showToppings();
			} else {
				dat += "No container is loaded into the machine, external transfer offline.<BR>";
				dat += this.showReagents( 2 );
				dat += this.showToppings();
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";close=1'>Close</A>" ).ToString();
			}
			popup = new Browser( a, "cream_master", "Cream-Master Deluxe", 700, 400, this );
			popup.set_content( dat );
			popup.open();
			return null;
		}

		// Function from file: icecreamvat.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: icecreamvat.dm
		public override dynamic attack_ai( dynamic user = null ) {
			return this.attack_hand( user );
		}

		// Function from file: icecreamvat.dm
		public override dynamic takeIngredient( dynamic I = null, dynamic user = null ) {
			dynamic _default = null;

			
			if ( I is Obj_Item_Weapon_ReagentContainers_Glass ) {
				
				if ( !Lang13.Bool( this.beaker ) ) {
					
					if ( Lang13.Bool( user.drop_item( I, this ) ) ) {
						this.beaker = I;
						_default = 1;
						GlobalFuncs.to_chat( user, "<span class='notice'>You add the " + I.name + " to the " + this.name + ".</span>" );
						this.updateUsrDialog();
					}
				} else {
					GlobalFuncs.to_chat( user, "<span class='warning'>The " + this.name + " already has a beaker.</span>" );
				}
			} else if ( I is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Icecream ) {
				
				if ( !((Reagents)I.reagents).has_reagent( "sprinkles" ) ) {
					((Reagents)I.reagents).add_reagent( "sprinkles", 1 );
					I.overlays += new Image( "icons/obj/kitchen.dmi", this, "sprinkles" );
					I.name += " with sprinkles";
					I.desc += " It has sprinkles on top.";
					_default = 1;
				} else {
					_default = "<span class='warning'>The " + I.name + " already has sprinkles.</span>";
				}
			}
			return _default;
		}

		// Function from file: icecreamvat.dm
		public string showReagents( int container = 0 ) {
			string dat = null;
			Reagent R = null;
			Reagent R2 = null;

			dat = "";

			if ( container == 1 ) {
				dat += "The container has:<BR>";

				foreach (dynamic _a in Lang13.Enumerate( this.beaker.reagents.reagent_list, typeof(Reagent) )) {
					R = _a;
					
					dat += "" + R.volume + " unit(s) of " + R.name + " | ";
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";add=" ).item( R.id ).str( ";amount=5'>(5)</A> " ).ToString();
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";add=" ).item( R.id ).str( ";amount=10'>(10)</A> " ).ToString();
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";add=" ).item( R.id ).str( ";amount=15'>(15)</A> " ).ToString();
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";add=" ).item( R.id ).str( ";amount=" ).item( R.volume ).str( "'>(All)</A>" ).ToString();
					dat += "<BR>";
				}
			} else if ( container == 2 ) {
				dat += "<BR>The Cream-Master has:<BR>";

				if ( Lang13.Bool( this.reagents.total_volume ) ) {
					
					foreach (dynamic _b in Lang13.Enumerate( this.reagents.reagent_list, typeof(Reagent) )) {
						R2 = _b;
						
						dat += "" + R2.volume + " unit(s) of " + R2.name + " | ";
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";remove=" ).item( R2.id ).str( ";amount=5'>(5)</A> " ).ToString();
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";remove=" ).item( R2.id ).str( ";amount=10'>(10)</A> " ).ToString();
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";remove=" ).item( R2.id ).str( ";amount=15'>(15)</A> " ).ToString();
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";remove=" ).item( R2.id ).str( ";amount=" ).item( R2.volume ).str( "'>(All)</A>" ).ToString();
						dat += "<BR>";
					}
				} else {
					dat += "No reagents. <BR>";
				}
			} else {
				dat += "<BR>INVALID REAGENT CONTAINER. Make a bug report.<BR>";
			}
			return dat;
		}

		// Function from file: icecreamvat.dm
		public string showToppings(  ) {
			string dat = null;

			dat = "";

			if ( ( this.reagents.total_volume ??0) <= 500 ) {
				dat += "<HR>";
				dat += "<strong>Add fillings:</strong><BR>";
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";synthcond=1;type=2'>Soda</A><BR>" ).ToString();
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";synthcond=1;type=3'>Alcohol</A><BR>" ).ToString();
				dat += "<strong>Finish With:</strong><BR>";
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";synthcond=1;type=4'>Cream</A><BR>" ).ToString();
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";synthcond=1;type=5'>Water</A><BR>" ).ToString();
				dat += "<strong>Dispense in:</strong><BR>";
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";createcup=1'>Chocolate Cone</A><BR>" ).ToString();
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";createcone=1'>Cone</A><BR>" ).ToString();
			}
			dat += "</center>";
			return dat;
		}

		// Function from file: icecreamvat.dm
		public dynamic generateName( string reagentName = null ) {
			dynamic _default = null;

			_default = Rand13.Pick(new object [] { "Mr. ", "Mrs. ", "Super ", "Happy ", "Whippy " });
			_default += Rand13.Pick(new object [] { "Whippy", "Slappy", "Creamy", "Dippy", "Swirly", "Swirl" });

			if ( Lang13.Bool( reagentName ) ) {
				_default += " " + reagentName;
			}
			return _default;
		}

	}

}