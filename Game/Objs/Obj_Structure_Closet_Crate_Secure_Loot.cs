// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Crate_Secure_Loot : Obj_Structure_Closet_Crate_Secure {

		public string code = null;
		public dynamic lastattempt = null;
		public int attempts = 10;
		public int? codelen = 4;

		// Function from file: abandoned_crates.dm
		public Obj_Structure_Closet_Crate_Secure_Loot ( dynamic loc = null ) : base( (object)(loc) ) {
			ByTable digits = null;
			int? i = null;
			dynamic dig = null;
			int loot = 0;
			double i2 = 0;
			double i3 = 0;
			double i4 = 0;
			double i5 = 0;
			dynamic newitem = null;
			double i6 = 0;
			double i7 = 0;
			dynamic newcoin = null;
			double i8 = 0;
			dynamic newitem2 = null;
			double i9 = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			digits = new ByTable(new object [] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "z" });
			this.code = "";
			i = null;
			i = 0;

			while (( i ??0) < ( this.codelen ??0)) {
				dig = Rand13.PickFromTable( digits );
				this.code += dig;
				digits.Remove( dig );
				i++;
			}
			loot = Rand13.Int( 1, 100 );

			dynamic _i = loot; // Was a switch-case, sorry for the mess.
			if ( 1<=_i&&_i<=5 ) {
				new Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Rum( this );
				new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Ambrosia( this );
				new Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Whiskey( this );
				new Obj_Item_Weapon_Lighter( this );
			} else if ( 6<=_i&&_i<=10 ) {
				new Obj_Item_Weapon_Bedsheet( this );
				new Obj_Item_Weapon_Kitchen_Knife( this );
				new Obj_Item_Weapon_Wirecutters( this );
				new Obj_Item_Weapon_Screwdriver( this );
				new Obj_Item_Weapon_Weldingtool( this );
				new Obj_Item_Weapon_Hatchet( this );
				new Obj_Item_Weapon_Crowbar( this );
			} else if ( 11<=_i&&_i<=15 ) {
				new Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Bluespace( this );
			} else if ( 16<=_i&&_i<=20 ) {
				
				foreach (dynamic _a in Lang13.IterateRange( 1, 10 )) {
					i2 = _a;
					
					new Obj_Item_Weapon_Ore_Diamond( this );
				}
			} else if ( 21<=_i&&_i<=25 ) {
				
				foreach (dynamic _b in Lang13.IterateRange( 1, 5 )) {
					i3 = _b;
					
					new Obj_Item_Weapon_Poster_Contraband( this );
				}
			} else if ( 26<=_i&&_i<=30 ) {
				
				foreach (dynamic _c in Lang13.IterateRange( 1, 3 )) {
					i4 = _c;
					
					new Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Noreact( this );
				}
			} else if ( 31<=_i&&_i<=35 ) {
				new Obj_Item_Seeds_Cashseed( this );
			} else if ( 36<=_i&&_i<=40 ) {
				new Obj_Item_Weapon_Melee_Baton( this );
			} else if ( 41<=_i&&_i<=45 ) {
				new Obj_Item_Clothing_Under_Shorts_Red( this );
				new Obj_Item_Clothing_Under_Shorts_Blue( this );
			} else if ( 46<=_i&&_i<=50 ) {
				new Obj_Item_Clothing_Under_Chameleon( this );

				foreach (dynamic _d in Lang13.IterateRange( 1, 7 )) {
					i5 = _d;
					
					new Obj_Item_Clothing_Tie_Horrible( this );
				}
			} else if ( 51<=_i&&_i<=52 ) {
				new Obj_Item_Weapon_Melee_ClassicBaton( this );
			} else if ( 53<=_i&&_i<=54 ) {
				new Obj_Item_Toy_Balloon( this );
			} else if ( 55<=_i&&_i<=56 ) {
				newitem = Rand13.PickFromTable( Lang13.GetTypes( typeof(Obj_Item_Toy_Prize) ) - typeof(Obj_Item_Toy_Prize) );
				Lang13.Call( newitem, this );
			} else if ( 57<=_i&&_i<=58 ) {
				new Obj_Item_Toy_Syndicateballoon( this );
			} else if ( 59<=_i&&_i<=60 ) {
				new Obj_Item_Weapon_Gun_Energy_KineticAccelerator_Hyper( this );
				new Obj_Item_Clothing_Suit_Space( this );
				new Obj_Item_Clothing_Head_Helmet_Space( this );
			} else if ( 61<=_i&&_i<=62 ) {
				
				foreach (dynamic _e in Lang13.IterateRange( 1, 5 )) {
					i6 = _e;
					
					new Obj_Item_Clothing_Head_Kitty( this );
					new Obj_Item_Clothing_Tie_Petcollar( this );
				}
			} else if ( 63<=_i&&_i<=64 ) {
				
				foreach (dynamic _f in Lang13.IterateRange( 1, Rand13.Int( 4, 7 ) )) {
					i7 = _f;
					
					newcoin = Rand13.Pick(new object [] { typeof(Obj_Item_Weapon_Coin_Silver), typeof(Obj_Item_Weapon_Coin_Silver), typeof(Obj_Item_Weapon_Coin_Silver), typeof(Obj_Item_Weapon_Coin_Iron), typeof(Obj_Item_Weapon_Coin_Iron), typeof(Obj_Item_Weapon_Coin_Iron), typeof(Obj_Item_Weapon_Coin_Gold), typeof(Obj_Item_Weapon_Coin_Diamond), typeof(Obj_Item_Weapon_Coin_Plasma), typeof(Obj_Item_Weapon_Coin_Uranium) });
					Lang13.Call( newcoin, this );
				}
			} else if ( 65<=_i&&_i<=66 ) {
				new Obj_Item_Clothing_Suit_Ianshirt( this );
				new Obj_Item_Clothing_Suit_Hooded_IanCostume( this );
			} else if ( 67<=_i&&_i<=68 ) {
				
				foreach (dynamic _g in Lang13.IterateRange( 1, Rand13.Int( 4, 7 ) )) {
					i8 = _g;
					
					newitem2 = Rand13.PickFromTable( Lang13.GetTypes( typeof(Obj_Item_Weapon_StockParts) ) - typeof(Obj_Item_Weapon_StockParts) - typeof(Obj_Item_Weapon_StockParts_Subspace) );
					Lang13.Call( newitem2, this );
				}
			} else if ( 69<=_i&&_i<=70 ) {
				
				foreach (dynamic _h in Lang13.IterateRange( 1, 5 )) {
					i9 = _h;
					
					new Obj_Item_Weapon_Ore_BluespaceCrystal( this );
				}
			} else if ( 71<=_i&&_i<=72 ) {
				new Obj_Item_Weapon_Pickaxe_Drill( this );
			} else if ( 73<=_i&&_i<=74 ) {
				new Obj_Item_Weapon_Pickaxe_Drill_Jackhammer( this );
			} else if ( 75<=_i&&_i<=76 ) {
				new Obj_Item_Weapon_Pickaxe_Diamond( this );
			} else if ( 77<=_i&&_i<=78 ) {
				new Obj_Item_Weapon_Pickaxe_Drill_Diamonddrill( this );
			} else if ( 79<=_i&&_i<=80 ) {
				new Obj_Item_Weapon_Cane( this );
				new Obj_Item_Clothing_Head_Collectable_Tophat( this );
			} else if ( 81<=_i&&_i<=82 ) {
				new Obj_Item_Weapon_Gun_Energy_Plasmacutter( this );
			} else if ( 83<=_i&&_i<=84 ) {
				new Obj_Item_Toy_Katana( this );
			} else if ( 85<=_i&&_i<=86 ) {
				new Obj_Item_Weapon_Defibrillator_Compact( this );
			} else if ( _i==87 ) {
				new Obj_Item_WeedExtract( this );
			} else if ( _i==88 ) {
				new Obj_Item_Organ_Internal_Brain( this );
			} else if ( _i==89 ) {
				new Obj_Item_Organ_Internal_Brain_Alien( this );
			} else if ( _i==90 ) {
				new Obj_Item_Organ_Internal_Heart( this );
			} else if ( _i==91 ) {
				new Obj_Item_Device_Soulstone_Anybody( this );
			} else if ( _i==92 ) {
				new Obj_Item_Weapon_Katana( this );
			} else if ( _i==93 ) {
				new Obj_Item_Weapon_Dnainjector_Xraymut( this );
			} else if ( _i==94 ) {
				new Obj_Item_Weapon_Storage_Backpack_Clown( this );
				new Obj_Item_Clothing_Under_Rank_Clown( this );
				new Obj_Item_Clothing_Shoes_ClownShoes( this );
				new Obj_Item_Device_Pda_Clown( this );
				new Obj_Item_Clothing_Mask_Gas_ClownHat( this );
				new Obj_Item_Weapon_Bikehorn( this );
				new Obj_Item_Toy_Crayon_Rainbow( this );
				new Obj_Item_Weapon_ReagentContainers_Spray_Waterflower( this );
			} else if ( _i==95 ) {
				new Obj_Item_Clothing_Under_Rank_Mime( this );
				new Obj_Item_Clothing_Shoes_Sneakers_Black( this );
				new Obj_Item_Device_Pda_Mime( this );
				new Obj_Item_Clothing_Gloves_Color_White( this );
				new Obj_Item_Clothing_Mask_Gas_Mime( this );
				new Obj_Item_Clothing_Head_Beret( this );
				new Obj_Item_Clothing_Suit_Suspenders( this );
				new Obj_Item_Toy_Crayon_Mime( this );
				new Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Bottleofnothing( this );
			} else if ( _i==96 ) {
				new Obj_Item_Weapon_HandTele( this );
			} else if ( _i==97 ) {
				new Obj_Item_Clothing_Mask_Balaclava();
				new Obj_Item_Weapon_Gun_Projectile_Automatic_Pistol( this );
				new Obj_Item_AmmoBox_Magazine_M10mm( this );
			} else if ( _i==98 ) {
				new Obj_Item_Weapon_Katana_Cursed( this );
			} else if ( _i==99 ) {
				new Obj_Item_Weapon_Storage_Belt_Champion( this );
				new Obj_Item_Clothing_Mask_Luchador( this );
			} else if ( _i==100 ) {
				new Obj_Item_Clothing_Head_Bearpelt( this );
			}
			return;
		}

		// Function from file: abandoned_crates.dm
		public void boom( dynamic user = null ) {
			Ent_Dynamic AM = null;
			dynamic T = null;

			user.WriteMsg( "<span class='danger'>The crate's anti-tamper system activates!</span>" );

			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Ent_Dynamic) )) {
				AM = _a;
				
				GlobalFuncs.qdel( AM );
			}
			T = GlobalFuncs.get_turf( this );
			GlobalFuncs.explosion( T, -1, -1, 1, 1 );
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: abandoned_crates.dm
		public override void togglelock( dynamic user = null ) {
			
			if ( this.locked ) {
				this.boom( user );
			} else {
				base.togglelock( (object)(user) );
			}
			return;
		}

		// Function from file: abandoned_crates.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			ByTable guess = null;
			int bulls = 0;
			int cows = 0;
			int? i = null;
			string a = null;
			dynamic i2 = null;
			int a2 = 0;

			
			if ( this.locked ) {
				
				if ( A is Obj_Item_Weapon_Card_Emag ) {
					this.boom( user );
				}

				if ( A is Obj_Item_Device_Multitool ) {
					user.WriteMsg( "<span class='notice'>DECA-CODE LOCK REPORT:</span>" );

					if ( this.attempts == 1 ) {
						user.WriteMsg( "<span class='warning'>* Anti-Tamper Bomb will activate on next failed access attempt.</span>" );
					} else {
						user.WriteMsg( "<span class='notice'>* Anti-Tamper Bomb will activate after " + this.attempts + " failed access attempts.</span>" );
					}

					if ( this.lastattempt != null ) {
						guess = new ByTable();
						bulls = 0;
						cows = 0;
						i = null;
						i = 1;

						while (( i ??0) < ( this.codelen ??0) + 1) {
							a = String13.SubStr( this.lastattempt, i ??0, ( i ??0) + 1 );
							guess.Add( a );
							guess[a] = i;
							i++;
						}

						foreach (dynamic _a in Lang13.Enumerate( guess )) {
							i2 = _a;
							
							a2 = String13.FindIgnoreCase( this.code, i2, 1, 0 );

							if ( a2 == Convert.ToInt32( guess[i2] ) ) {
								bulls++;
							} else if ( a2 != 0 ) {
								cows++;
							}
						}
						user.WriteMsg( "<span class='notice'>Last code attempt had " + bulls + " correct digits at correct positions and " + cows + " correct digits at incorrect positions.</span>" );
					}
				} else {
					base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
				}
			} else {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: abandoned_crates.dm
		public override bool attack_animal( Mob_Living user = null ) {
			this.boom( user );
			return false;
		}

		// Function from file: abandoned_crates.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			dynamic input = null;

			
			if ( this.locked ) {
				a.WriteMsg( "<span class='notice'>The crate is locked with a Deca-code lock.</span>" );
				input = Interface13.Input( Task13.User, "Enter " + this.codelen + " digits.", "Deca-Code Lock", "", null, InputType.Str );

				if ( ((Mob)a).canUseTopic( this, true ) ) {
					
					if ( input == this.code ) {
						a.WriteMsg( "<span class='notice'>The crate unlocks!</span>" );
						this.locked = false;
						this.overlays.Cut();
						this.overlays.Add( "securecrateg" );
					} else if ( input == null || Lang13.Length( input ) != this.codelen ) {
						a.WriteMsg( "<span class='notice'>You leave the crate alone.</span>" );
					} else {
						a.WriteMsg( "<span class='warning'>A red light flashes.</span>" );
						this.lastattempt = GlobalFuncs.replacetext( input, 0, "z" );
						this.attempts--;

						if ( this.attempts == 0 ) {
							this.boom( a );
						}
					}
				}
			} else {
				return base.attack_hand( (object)(a), b, c );
			}
			return null;
		}

	}

}