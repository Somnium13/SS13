// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		public int ingMax = 12;
		public ByTable ingredients = new ByTable();
		public int ingredients_placement = 1;
		public string customname = "custom";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bitesize = 4;
			this.volume = 80;
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

		// Function from file: customizables.dm
		public override dynamic Destroy(  ) {
			dynamic _default = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.ingredients )) {
				_default = _a;
				
				GlobalFuncs.qdel( _default );
			}
			return base.Destroy();
		}

		// Function from file: customizables.dm
		public override void initialize_slice( dynamic slice = null, double reagents_per_slice = 0 ) {
			base.initialize_slice( (object)(slice), reagents_per_slice );
			slice.name = "" + this.customname + " " + Lang13.Initial( slice, "name" );
			slice.filling_color = this.filling_color;
			slice.update_overlays( this );
			return;
		}

		// Function from file: customizables.dm
		public override void update_overlays( dynamic S = null ) {
			Image I = null;
			Image TOP = null;

			I = new Image( this.icon, "" + Lang13.Initial( this, "icon_state" ) + "_filling" );

			if ( S.filling_color == "#FFFFFF" ) {
				I.color = Rand13.Pick(new object [] { "#FF0000", "#0000FF", "#008000", "#FFFF00" });
			} else {
				I.color = S.filling_color;
			}

			switch ((int)( this.ingredients_placement )) {
				case 2:
					I.pixel_x = Rand13.Int( -1, 1 );
					I.pixel_y = Rand13.Int( -1, 1 );
					break;
				case 3:
					I.pixel_x = Rand13.Int( -1, 1 );
					I.pixel_y = this.ingredients.len * 2 - 1;
					break;
				case 4:
					I.pixel_x = Rand13.Int( -1, 1 );
					I.pixel_y = this.ingredients.len * 2 - 1;
					this.overlays.Cut( this.ingredients.len );
					TOP = new Image( this.icon, "" + this.icon_state + "_top" );
					TOP.pixel_y = this.ingredients.len * 2 + 3;
					this.overlays.Add( I );
					this.overlays.Add( TOP );
					return;
					break;
				case 1:
					this.overlays.Cut();
					I.color = this.filling_color;
					break;
				case 5:
					I.pixel_y = Rand13.Int( -8, 3 );
					I.pixel_x = I.pixel_y;
					break;
			}
			this.overlays.Add( I );
			return;
		}

		// Function from file: customizables.dm
		public void mix_filling_color( dynamic S = null ) {
			ByTable rgbcolor = null;
			ByTable customcolor = null;
			ByTable ingcolor = null;

			
			if ( this.ingredients.len == 1 ) {
				this.filling_color = S.filling_color;
			} else {
				rgbcolor = new ByTable(new object [] { 0, 0, 0, 0 });
				customcolor = GlobalFuncs.GetColors( this.filling_color );
				ingcolor = GlobalFuncs.GetColors( S.filling_color );
				rgbcolor[1] = ( customcolor[1] + ingcolor[1] ) / 2;
				rgbcolor[2] = ( customcolor[2] + ingcolor[2] ) / 2;
				rgbcolor[3] = ( customcolor[3] + ingcolor[3] ) / 2;
				rgbcolor[4] = ( customcolor[4] + ingcolor[4] ) / 2;
				this.filling_color = String13.ColorCode( Convert.ToInt32( rgbcolor[1] ), Convert.ToInt32( rgbcolor[2] ), Convert.ToInt32( rgbcolor[3] ), Convert.ToInt32( rgbcolor[4] ) );
			}
			return;
		}

		// Function from file: customizables.dm
		public virtual void initialize_custom_food( Obj_Item BASE = null, dynamic I = null, dynamic user = null ) {
			Obj_Item RC = null;
			Obj O = null;

			
			if ( BASE is Obj_Item_Weapon_ReagentContainers ) {
				RC = BASE;
				RC.reagents.trans_to( this, RC.reagents.total_volume );
			}

			foreach (dynamic _a in Lang13.Enumerate( BASE.contents, typeof(Obj) )) {
				O = _a;
				
				this.contents.Add( O );
			}

			if ( Lang13.Bool( I ) && Lang13.Bool( user ) ) {
				this.attackby( I, user );
			}
			((Mob)user).unEquip( BASE );
			GlobalFuncs.qdel( BASE );
			return;
		}

		// Function from file: customizables.dm
		public void update_name( dynamic S = null ) {
			Obj_Item I = null;
			dynamic M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.ingredients, typeof(Obj_Item) )) {
				I = _a;
				

				if ( !Lang13.Bool( ((dynamic)I.type).IsInstanceOfType( S ) ) ) {
					this.customname = "custom";
					break;
				}
			}

			if ( this.ingredients.len == 1 ) {
				
				if ( S is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat ) {
					M = S;

					if ( Lang13.Bool( M.subjectname ) ) {
						this.customname = "" + M.subjectname;
					} else if ( Lang13.Bool( M.subjectjob ) ) {
						this.customname = "" + M.subjectjob;
					} else {
						this.customname = S.name;
					}
				} else {
					this.customname = S.name;
				}
			}
			this.name = "" + this.customname + " " + Lang13.Initial( this, "name" );
			return;
		}

		// Function from file: customizables.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic _default = null;

			dynamic S = null;
			string txt = null;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable S2 = null;

			
			if ( A is Obj_Item_Weapon_ReagentContainers_Food_Snacks ) {
				S = A;

				if ( Convert.ToDouble( A.w_class ) > 2 ) {
					user.WriteMsg( "<span class='warning'>The ingredient is too big for " + this + "!</span>" );
				} else if ( this.ingredients.len >= this.ingMax || ( this.reagents.total_volume ??0) >= ( this.volume ??0) ) {
					user.WriteMsg( "<span class='warning'>You can't add more ingredients to " + this + "!</span>" );
				} else {
					
					if ( !((Mob)user).unEquip( A ) ) {
						return _default;
					}

					if ( S.trash != null ) {
						Lang13.Call( S.trash, GlobalFuncs.get_turf( user ) );
						S.trash = null;
					}
					this.ingredients.Add( S );
					S.loc = this;
					this.mix_filling_color( S );
					((Reagents)S.reagents).trans_to( this, Num13.MinInt( ((int)( S.reagents.total_volume ??0 )), 15 ) );
					this.update_overlays( S );
					user.WriteMsg( "<span class='notice'>You add the " + A.name + " to the " + this.name + ".</span>" );
					this.update_name( S );
				}
			} else if ( A is Obj_Item_Weapon_Pen ) {
				txt = GlobalFuncs.stripped_input( user, "What would you like the food to be called?", "Food Naming", "", 30 );

				if ( Lang13.Bool( txt ) ) {
					this.ingMax = this.ingredients.len;
					user.WriteMsg( "<span class='notice'>You add a last touch to the dish by renaming it.</span>" );
					this.customname = txt;

					if ( this is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable_Sandwich ) {
						S2 = this;

						if ( Lang13.Bool( ((dynamic)S2).finished ) ) {
							this.name = "" + this.customname + " sandwich";
							return _default;
						}
					}
					this.name = "" + this.customname + " " + Lang13.Initial( this, "name" );
				}
			} else {
				_default = base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return _default;
		}

		// Function from file: customizables.dm
		public override double examine( dynamic user = null ) {
			string ingredients_listed = null;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks ING = null;
			string size = null;

			base.examine( (object)(user) );
			ingredients_listed = "";

			foreach (dynamic _a in Lang13.Enumerate( this.ingredients, typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks) )) {
				ING = _a;
				
				ingredients_listed += "" + ING.name + ", ";
			}
			size = "standard";

			if ( this.ingredients.len < 2 ) {
				size = "small";
			}

			if ( this.ingredients.len > 5 ) {
				size = "big";
			}

			if ( this.ingredients.len > 8 ) {
				size = "monster";
			}
			user.WriteMsg( "It contains " + ( this.ingredients.len != 0 ? "" + ingredients_listed : "no ingredient, " ) + "making a " + size + "-sized " + Lang13.Initial( this, "name" ) + "." );
			return 0;
		}

	}

}