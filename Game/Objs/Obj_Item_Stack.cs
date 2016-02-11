// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack : Obj_Item {

		public ByTable recipes = null;
		public string singular_name = null;
		public string irregular_plural = null;
		public double? amount = 1;
		public int perunit = 3750;
		public double? max_amount = null;
		public bool redeemed = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "materials=1";
		}

		// Function from file: stack.dm
		public Obj_Item_Stack ( dynamic loc = null, int? amount = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Lang13.Bool( amount ) ) {
				this.amount = amount;
			}
			this.update_materials();
			return;
		}

		// Function from file: stack.dm
		public override bool verb_pickup( Mob user = null ) {
			dynamic I = null;

			I = user.get_active_hand();

			if ( Lang13.Bool( I ) && this.can_stack_with( I ) ) {
				((Obj_Item)I).preattack( this, user, true );
				return false;
			}
			return base.verb_pickup( user );
		}

		// Function from file: stack.dm
		public override bool preattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, dynamic click_parameters = null ) {
			dynamic S = null;
			int to_transfer = 0;

			
			if ( !( proximity_flag == true ) ) {
				return false;
			}

			if ( this.can_stack_with( target ) ) {
				S = target;

				if ( ( this.amount ??0) >= ( this.max_amount ??0) ) {
					GlobalFuncs.to_chat( user, new Txt().The( this ).item().str( " cannot hold anymore " ).item( ( Lang13.Bool( this.irregular_plural ) && ( this.amount ??0) > 1 ? this.irregular_plural : new Txt().item( this.singular_name ).s().ToString() ) ).str( "." ).ToString() );
					return true;
				}

				if ( ((Mob)user).get_inactive_hand() == S ) {
					to_transfer = 1;
				} else {
					to_transfer = Num13.MinInt( Convert.ToInt32( S.amount ), ((int)( ( this.max_amount ??0) - ( this.amount ??0) )) );
				}
				this.amount += to_transfer;
				this.update_materials();
				GlobalFuncs.to_chat( user, new Txt( "You add " ).item( to_transfer ).str( " " ).item( ( to_transfer > 1 && Lang13.Bool( S.irregular_plural ) ? S.irregular_plural : new Txt().item( S.singular_name ).s().ToString() ) ).str( " to " ).the( this ).item().str( ". It now contains " ).item( this.amount ).str( " " ).item( ( Lang13.Bool( this.irregular_plural ) && ( this.amount ??0) > 1 ? this.irregular_plural : new Txt().item( this.singular_name ).s().ToString() ) ).str( "." ).ToString() );

				if ( Lang13.Bool( S ) && user.machine == S ) {
					Task13.Schedule( 0, (Task13.Closure)(() => {
						this.interact( user );
						return;
					}));
				}
				S.use( to_transfer );

				if ( this != null && user.machine == this ) {
					Task13.Schedule( 0, (Task13.Closure)(() => {
						this.interact( user );
						return;
					}));
				}
				this.update_icon();
				S.update_icon();
				return true;
			}
			return base.preattack( (object)(target), (object)(user), proximity_flag, (object)(click_parameters) );
		}

		// Function from file: stack.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Ent_Static F = null;

			
			if ( ((Mob)a).get_inactive_hand() == this ) {
				F = new ByTable().Set( 1, a ).Set( "amount", 1 ).Apply( this.type );
				((dynamic)F).copy_evidences( this );
				((Mob)a).put_in_hands( F );
				this.add_fingerprint( a );
				F.add_fingerprint( a );
				this.use( 1 );

				if ( this != null && Task13.User.machine == this ) {
					Task13.Schedule( 0, (Task13.Closure)(() => {
						this.interact( Task13.User );
						return;
					}));
				}
			} else {
				base.attack_hand( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: stack.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			ByTable recipes_list = null;
			dynamic srl = null;
			StackRecipe R = null;
			double? multiplier = null;
			Ent_Dynamic AM = null;
			dynamic O = null;
			dynamic S = null;
			dynamic A = null;
			Obj_Item_Stack oldsrc = null;
			Obj_Item I = null;
			dynamic C = null;

			base.Topic( href, href_list, (object)(hclient) );

			if ( Task13.User.restrained() || Lang13.Bool( Task13.User.stat ) || Task13.User.get_active_hand() != this ) {
				return null;
			}

			if ( Lang13.Bool( href_list["sublist"] ) && !Lang13.Bool( href_list["make"] ) ) {
				this.list_recipes( Task13.User, String13.ParseNumber( href_list["sublist"] ) );
			}

			if ( Lang13.Bool( href_list["make"] ) ) {
				
				if ( ( this.amount ??0) < 1 ) {
					GlobalFuncs.returnToPool( this );
				}
				recipes_list = this.recipes;

				if ( Lang13.Bool( href_list["sublist"] ) ) {
					srl = recipes_list[String13.ParseNumber( href_list["sublist"] )];
					recipes_list = srl.recipes;
				}
				R = recipes_list[String13.ParseNumber( href_list["make"] )];
				multiplier = String13.ParseNumber( href_list["multiplier"] );

				if ( !Lang13.Bool( multiplier ) ) {
					multiplier = 1;
				}

				if ( ( this.amount ??0) < ( R.req_amount ??0) * ( multiplier ??0) ) {
					
					if ( ( R.req_amount ??0) * ( multiplier ??0) > 1 ) {
						GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='warning'>You haven't got enough " ).item( this ).str( " to build " ).the( ( R.req_amount ??0) * ( multiplier ??0) ).item().str( " " ).item( R.title ).s().str( "!</span>" ).ToString() );
					} else {
						GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='warning'>You haven't got enough " ).item( this ).str( " to build " ).the( R.title ).item().str( "!</span>" ).ToString() );
					}
					return null;
				}

				if ( R.one_per_turf == true && Lang13.Bool( Lang13.FindIn( R.result_type, Task13.User.loc ) ) ) {
					
					foreach (dynamic _a in Lang13.Enumerate( Task13.User.loc, typeof(Ent_Dynamic) )) {
						AM = _a;
						

						if ( AM is Obj_Structure_Bed_Chair_Vehicle ) {
							continue;
						} else if ( Lang13.Bool( ((dynamic)R.result_type).IsInstanceOfType( AM ) ) ) {
							GlobalFuncs.to_chat( Task13.User, "<span class='warning'>There is another " + R.title + " here!</span>" );
							return null;
						}
					}
				}

				if ( R.on_floor == true && Task13.User.loc is Tile_Space ) {
					GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='warning'>" ).The( R.title ).item().str( " must be constructed on the floor!</span>" ).ToString() );
					return null;
				}

				if ( Lang13.Bool( R.time ) ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='notice'>Building " + R.title + " ...</span>" );

					if ( !GlobalFuncs.do_after( Task13.User, GlobalFuncs.get_turf( this ), R.time ) ) {
						return null;
					}
				}

				if ( ( this.amount ??0) < ( R.req_amount ??0) * ( multiplier ??0) ) {
					return null;
				}
				O = null;

				if ( Lang13.Bool( ((dynamic)R.result_type).IsSubclassOf( typeof(Obj_Item_Stack) ) ) ) {
					O = GlobalFuncs.drop_stack( R.result_type, Task13.User.loc, ( ( R.max_res_amount ??0) > 1 ? ( R.res_amount ??0) * ( multiplier ??0) : 1 ), Task13.User );
					S = O;
					((Obj_Item_Stack)S).update_materials();
				} else {
					O = Lang13.Call( R.result_type, Task13.User.loc );
				}
				O.dir = Task13.User.dir;

				if ( R.start_unanchored == true ) {
					A = O;
					A.anchored = 0;
				}
				this.use( ( R.req_amount ??0) * ( multiplier ??0) );

				if ( ( this.amount ??0) <= 0 ) {
					oldsrc = this;
					Task13.User.before_take_item( oldsrc );
					GlobalFuncs.returnToPool( oldsrc );

					if ( O is Obj_Item ) {
						Task13.User.put_in_hands( O );
					}
				}
				((Ent_Static)O).add_fingerprint( Task13.User );

				if ( O is Obj_Item_Weapon_Storage ) {
					
					foreach (dynamic _b in Lang13.Enumerate( O, typeof(Obj_Item) )) {
						I = _b;
						
						GlobalFuncs.qdel( I );
					}
				}

				if ( O is Obj_Item_Weapon_Handcuffs_Cable ) {
					C = O;
					C._color = this._color;
					C.update_icon();
				}
			}

			if ( this != null && Task13.User.machine == this ) {
				Task13.Schedule( 0, (Task13.Closure)(() => {
					this.interact( Task13.User );
					return;
					return;
				}));
			}
			return null;
		}

		// Function from file: stack.dm
		public virtual dynamic copy_evidences( Ent_Static from = null ) {
			this.blood_DNA = from.blood_DNA;
			this.fingerprints = from.fingerprints;
			this.fingerprintshidden = from.fingerprintshidden;
			this.fingerprintslast = from.fingerprintslast;
			return null;
		}

		// Function from file: stack.dm
		public virtual bool can_stack_with( dynamic other_stack = null ) {
			
			if ( other_stack is Type ) {
				return this.type == other_stack;
			}
			return this.type == other_stack.type;
		}

		// Function from file: stack.dm
		public void update_materials(  ) {
			dynamic matID = null;

			
			if ( Lang13.Bool( this.amount ) && this.starting_materials != null ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.starting_materials )) {
					matID = _a;
					
					((dynamic)this.materials).storage[matID] = Num13.MaxInt( 0, Convert.ToInt32( this.starting_materials[matID] * this.amount ) );
				}
			}
			return;
		}

		// Function from file: stack.dm
		public void add_to_stacks( dynamic usr = null ) {
			Obj_Item_Stack item = null;

			
			foreach (dynamic _a in Lang13.Enumerate( usr.loc, typeof(Obj_Item_Stack) )) {
				item = _a;
				

				if ( this == item ) {
					continue;
				}

				if ( !this.can_stack_with( item ) ) {
					continue;
				}

				if ( ( item.amount ??0) >= ( item.max_amount ??0) ) {
					continue;
				}
				this.preattack( item, usr, true );
				break;
			}
			return;
		}

		// Function from file: stack.dm
		public virtual bool use( double? amount = null ) {
			bool _default = false;

			Mob R = null;

			
			if ( !Lang13.Bool( Lang13.IsNumber( this.amount ) ) ) {
				Task13.Crash( "" + "code/game/objects/items/stacks/stack.dm" + ":" + 198 + ":Assertion Failed: " + "isnum(src.amount)" );
			}

			if ( ( this.amount ??0) >= ( amount ??0) ) {
				this.amount -= amount ??0;
				this.update_materials();
			} else {
				return false;
			}
			_default = true;

			if ( ( this.amount ??0) <= 0 ) {
				
				if ( Task13.User != null ) {
					
					if ( Task13.User is Mob_Living_Silicon_Robot ) {
						R = Task13.User;

						if ( Lang13.Bool( ((dynamic)R).module ) ) {
							((dynamic)R).module.modules -= this;
						}

						if ( ((dynamic)R).module_active == this ) {
							((dynamic)R).module_active = null;
						}

						if ( ((dynamic)R).module_state_1 == this ) {
							((Mob_Living_Silicon_Robot)R).uneq_module( ((dynamic)R).module_state_1 );
							((dynamic)R).module_state_1 = null;
							((dynamic)R).inv1.icon_state = "inv1";
						} else if ( ((dynamic)R).module_state_2 == this ) {
							((Mob_Living_Silicon_Robot)R).uneq_module( ((dynamic)R).module_state_2 );
							((dynamic)R).module_state_2 = null;
							((dynamic)R).inv2.icon_state = "inv2";
						} else if ( ((dynamic)R).module_state_3 == this ) {
							((Mob_Living_Silicon_Robot)R).uneq_module( ((dynamic)R).module_state_3 );
							((dynamic)R).module_state_3 = null;
							((dynamic)R).inv3.icon_state = "inv3";
						}
					}
					Task13.User.before_take_item( this );
				}
				Task13.Schedule( 0, (Task13.Closure)(() => {
					GlobalFuncs.returnToPool( this );
					return;
				}));
			}
			return _default;
		}

		// Function from file: stack.dm
		public void list_recipes( dynamic user = null, double? recipes_sublist = null ) {
			ByTable recipe_list = null;
			dynamic srl = null;
			string t1 = null;
			int? i = null;
			dynamic E = null;
			dynamic srl2 = null;
			string stack_name = null;
			StackRecipe R = null;
			int max_multiplier = 0;
			dynamic title = null;
			bool can_build = false;
			ByTable multipliers = null;
			dynamic n = null;

			
			if ( !Lang13.Bool( Lang13.IsNumber( this.amount ) ) ) {
				Task13.Crash( "" + "code/game/objects/items/stacks/stack.dm" + ":" + 47 + ":Assertion Failed: " + "isnum(amount)" );
			}

			if ( !( this.recipes != null ) ) {
				return;
			}

			if ( !( this != null ) || ( this.amount ??0) <= 0 ) {
				Interface13.Browse( user, null, "window=stack" );
			}
			((Mob)user).set_machine( this );
			recipe_list = this.recipes;

			if ( Lang13.Bool( recipes_sublist ) && Lang13.Bool( recipe_list[recipes_sublist] ) && recipe_list[recipes_sublist] is StackRecipeList ) {
				srl = recipe_list[recipes_sublist];
				recipe_list = srl.recipes;
			}
			t1 = "<HTML><HEAD><title>Constructions from " + this + "</title></HEAD><body><TT>Amount Left: " + this.amount + "<br>";
			i = null;
			i = 1;

			while (( i ??0) <= recipe_list.len) {
				E = recipe_list[i];

				if ( E == null ) {
					t1 += "<hr>";
				} else {
					
					if ( ( i ??0) > 1 && !( recipe_list[( i ??0) - 1] == null ) ) {
						t1 += "<br>";
					}

					if ( E is StackRecipeList ) {
						srl2 = E;
						stack_name = ( Lang13.Bool( this.irregular_plural ) && Convert.ToDouble( srl2.req_amount ) > 1 ? this.irregular_plural : new Txt().item( this.singular_name ).s().ToString() );

						if ( ( this.amount ??0) >= Convert.ToDouble( srl2.req_amount ) ) {
							t1 += new Txt( "<a href='?src=" ).Ref( this ).str( ";sublist=" ).item( i ).str( "'>" ).item( srl2.title ).str( " (" ).item( srl2.req_amount ).str( " " ).item( stack_name ).str( ")</a>" ).ToString();
						} else {
							t1 += new Txt().item( srl2.title ).str( " (" ).item( srl2.req_amount ).str( " " ).item( stack_name ).s().str( ")<br>" ).ToString();
						}
					}

					if ( E is StackRecipe ) {
						R = E;
						max_multiplier = Num13.Floor( ( this.amount ??0) / ( R.req_amount ??0) );
						title = null;
						can_build = true;
						can_build = can_build && max_multiplier > 0;

						if ( ( R.res_amount ??0) > 1 ) {
							title += new Txt().item( R.res_amount ).str( "x " ).item( R.title ).s().ToString();
						} else {
							title += "" + R.title;
						}
						title += " (" + R.req_amount + " " + ( Lang13.Bool( this.irregular_plural ) && ( this.amount ??0) > 1 ? this.irregular_plural : new Txt().item( this.singular_name ).s().ToString() );

						if ( can_build ) {
							t1 += new Txt( "<A href='?src=" ).Ref( this ).str( ";sublist=" ).item( recipes_sublist ).str( ";make=" ).item( i ).str( "'>" ).item( title ).str( "</A>)" ).ToString();
						} else {
							t1 += "" + title;
							i++;
							continue;
						}

						if ( ( R.max_res_amount ??0) > 1 && max_multiplier > 1 ) {
							max_multiplier = Num13.MinInt( max_multiplier, Num13.Floor( ( R.max_res_amount ??0) / ( R.res_amount ??0) ) );
							t1 += " |";
							multipliers = new ByTable(new object [] { 5, 10, 25 });

							foreach (dynamic _a in Lang13.Enumerate( multipliers )) {
								n = _a;
								

								if ( max_multiplier >= Convert.ToDouble( n ) ) {
									t1 += new Txt( " <A href='?src=" ).Ref( this ).str( ";make=" ).item( i ).str( ";multiplier=" ).item( n ).str( "'>" ).item( n * R.res_amount ).str( "x</A>" ).ToString();
								}
							}

							if ( !multipliers.Contains( max_multiplier ) ) {
								t1 += new Txt( " <A href='?src=" ).Ref( this ).str( ";make=" ).item( i ).str( ";multiplier=" ).item( max_multiplier ).str( "'>" ).item( max_multiplier * ( R.res_amount ??0) ).str( "x</A>" ).ToString();
							}
						}
					}
				}
				i++;
			}
			t1 += "</TT></body></HTML>";
			Interface13.Browse( user, t1, "window=stack" );
			GlobalFuncs.onclose( user, "stack" );
			return;
		}

		// Function from file: stack.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.list_recipes( user );
			return null;
		}

		// Function from file: stack.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			string be = null;

			base.examine( (object)(user), size );
			be = "are";

			if ( this.amount == 1 ) {
				be = "is";
			}
			GlobalFuncs.to_chat( user, "<span class='info'>There " + be + " " + this.amount + " " + ( Lang13.Bool( this.irregular_plural ) && ( this.amount ??0) > 1 ? this.irregular_plural : new Txt().item( this.singular_name ).s().ToString() ) + " in the stack.</span>" );
			return null;
		}

		// Function from file: stack.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( Task13.User != null && Task13.User.machine == this ) {
				Interface13.Browse( Task13.User, null, "window=stack" );
			}
			this.loc = null;
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}