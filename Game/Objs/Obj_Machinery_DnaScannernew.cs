// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_DnaScannernew : Obj_Machinery {

		public bool locked = false;
		public dynamic occupant = null;
		public dynamic beaker = null;
		public dynamic injector_cooldown = 300;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 50;
			this.active_power_usage = 300;
			this.machine_flags = 6;
			this.light_color = "#7DE1E1";
			this.use_auto_lights = true;
			this.light_range_on = 3;
			this.light_power_on = 2;
			this.icon = "icons/obj/Cryogenic2.dmi";
			this.icon_state = "scanner_0";
		}

		// Function from file: dna_modifier.dm
		public Obj_Machinery_DnaScannernew ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable(new object [] { 
				new Obj_Item_Weapon_Circuitboard_Clonescanner(), 
				new Obj_Item_Weapon_StockParts_ScanningModule(), 
				new Obj_Item_Weapon_StockParts_Manipulator(), 
				new Obj_Item_Weapon_StockParts_MicroLaser(), 
				new Obj_Item_Weapon_StockParts_ConsoleScreen()
			 });
			this.RefreshParts();
			return;
		}

		// Function from file: dna_modifier.dm
		public override bool blob_act( dynamic severity = null ) {
			
			if ( Rand13.PercentChance( 75 ) ) {
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: dna_modifier.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			dynamic A = null;
			dynamic A2 = null;
			dynamic A3 = null;

			
			switch ((int?)( severity )) {
				case 1:
					
					foreach (dynamic _a in Lang13.Enumerate( this )) {
						A = _a;
						
						A.loc = this.loc;
						this.ex_act( severity );
					}
					GlobalFuncs.qdel( this );
					return false;
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						
						foreach (dynamic _b in Lang13.Enumerate( this )) {
							A2 = _b;
							
							A2.loc = this.loc;
							this.ex_act( severity );
						}
						GlobalFuncs.qdel( this );
						return false;
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 25 ) ) {
						
						foreach (dynamic _c in Lang13.Enumerate( this )) {
							A3 = _c;
							
							A3.loc = this.loc;
							this.ex_act( severity );
						}
						GlobalFuncs.qdel( this );
						return false;
					}
					break;
			}
			return false;
		}

		// Function from file: dna_modifier.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic G = null;

			
			if ( a is Obj_Item_Weapon_ReagentContainers_Glass ) {
				
				if ( Lang13.Bool( this.beaker ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>A beaker is already loaded into the machine.</span>" );
					return null;
				}

				if ( Lang13.Bool( b.drop_item( this.beaker, this ) ) ) {
					this.beaker = a;
					((Ent_Static)b).visible_message( new Txt().item( b ).str( " adds " ).a( a ).item().str( " to " ).the( this ).item().str( "!" ).ToString(), new Txt( "You add " ).a( a ).item().str( " to " ).the( this ).item().str( "!" ).ToString() );
					return null;
				}
			} else if ( a is Obj_Item_Weapon_Grab ) {
				G = a;

				if ( !( G.affecting is Mob ) ) {
					return null;
				}

				if ( Lang13.Bool( this.occupant ) ) {
					GlobalFuncs.to_chat( b, "<span class='notice'><B>The scanner is already occupied!</B></span>" );
					return null;
				}

				if ( Lang13.Bool( G.affecting.locked_to ) ) {
					return null;
				}
				this.put_in( G.affecting );
				this.add_fingerprint( b );
				GlobalFuncs.qdel( G );
				return 1;
			}
			return base.attackby( (object)(a), (object)(b), (object)(c) );
		}

		// Function from file: dna_modifier.dm
		public override dynamic MouseDrop( Mob over_object = null, dynamic src_location = null, Ent_Static over_location = null, dynamic src_control = null, dynamic over_control = null, string _params = null ) {
			Mob robit = null;
			Ent_Dynamic A = null;

			
			if ( !( Task13.User is Mob_Living_Carbon_Human ) && !( Task13.User is Mob_Living_Silicon_Robot ) || Task13.User.incapacitated() || Task13.User.lying == true ) {
				return null;
			}

			if ( !Lang13.Bool( this.occupant ) ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>The sleeper is unoccupied!</span>" );
				return null;
			}

			if ( Task13.User is Mob_Living_Silicon_Robot ) {
				robit = Task13.User;

				if ( robit is Mob_Living_Silicon_Robot && !( ((dynamic)robit).module is Obj_Item_Weapon_RobotModule_Medical ) ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='warning'>You do not have the means to do this!</span>" );
					return null;
				}
			}

			if ( !( over_location is Tile ) || over_location.density ) {
				return null;
			}

			if ( !this.Adjacent( over_location ) ) {
				return null;
			}

			if ( !( this.occupant == Task13.User ) && ( !this.Adjacent( Task13.User ) || !Task13.User.Adjacent( over_location ) ) ) {
				return null;
			}

			foreach (dynamic _a in Lang13.Enumerate( over_location.contents, typeof(Ent_Dynamic) )) {
				A = _a;
				

				if ( A.density ) {
					
					if ( A == this || A is Mob ) {
						continue;
					}
					return null;
				}
			}

			if ( this.occupant == Task13.User ) {
				this.visible_message( new Txt().item( Task13.User ).str( " climbs out of " ).the( this ).item().str( "." ).ToString() );
			} else {
				this.visible_message( new Txt().item( Task13.User ).str( " removes " ).item( this.occupant.name ).str( " from " ).the( this ).item().str( "." ).ToString() );
			}
			this.eject_occupant( over_location );
			return null;
		}

		// Function from file: dna_modifier.dm
		public override bool MouseDrop_T( Ent_Static O = null, dynamic user = null, bool? needs_opened = null, bool? show_message = null, bool? move_them = null ) {
			Mob robit = null;
			Ent_Static L = null;
			Mob_Living_Carbon_Slime M = null;

			
			if ( !( O is Mob ) ) {
				return false;
			}

			if ( O.loc == user || !( O.loc is Tile ) || !( user.loc is Tile ) ) {
				return false;
			}

			if ( ((Mob)user).incapacitated() || user.lying == true ) {
				return false;
			}

			if ( Lang13.Bool( ((dynamic)O).anchored ) || !this.Adjacent( user ) || !((Ent_Static)user).Adjacent( this ) || Lang13.Bool( user.contents.Find( this ) ) ) {
				return false;
			}

			if ( O is Mob_Living_SimpleAnimal || O is Mob_Living_Silicon ) {
				return false;
			}

			if ( !( user is Mob_Living_Carbon_Human ) && !( user is Mob_Living_Silicon_Robot ) ) {
				return false;
			}

			if ( user.loc == null ) {
				return false;
			}

			if ( Lang13.Bool( this.occupant ) ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>" ).The( this ).item().str( " is already occupied!</span>" ).ToString() );
				return false;
			}

			if ( O is Mob_Living_Carbon_Human_Manifested ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='notice'> For some reason, the scanner is unable to read that person's genes.</span>" );
				return false;
			}

			if ( user is Mob_Living_Silicon_Robot ) {
				robit = Task13.User;

				if ( robit is Mob_Living_Silicon_Robot && !( ((dynamic)robit).module is Obj_Item_Weapon_RobotModule_Medical ) ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>You do not have the means to do this!</span>" );
					return false;
				}
			}
			L = O;

			if ( !( L is Mob_Living ) || Lang13.Bool( ((dynamic)L).locked_to ) ) {
				return false;
			}

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( L, 1 ), typeof(Mob_Living_Carbon_Slime) )) {
				M = _a;
				

				if ( M.Victim == L ) {
					GlobalFuncs.to_chat( Task13.User, "" + L.name + " will not fit into the DNA Scanner because they have a slime latched onto their head." );
					return false;
				}
			}

			if ( L == user ) {
				this.visible_message( new Txt().item( user ).str( " climbs into " ).the( this ).item().str( "." ).ToString() );
			} else {
				this.visible_message( new Txt().item( user ).str( " places " ).item( L ).str( " into " ).the( this ).item().str( "." ).ToString() );
			}

			if ( user.pulling == L ) {
				((Mob)user).stop_pulling();
			}
			this.put_in( L );

			if ( user.pulling == L ) {
				user.pulling = null;
			}
			return false;
		}

		// Function from file: dna_modifier.dm
		public bool go_out( Ent_Static exit = null ) {
			exit = exit ?? this.loc;

			Ent_Dynamic x = null;
			dynamic C = null;

			
			if ( !Lang13.Bool( this.occupant ) || this.locked ) {
				return false;
			}
			((Ent_Dynamic)this.occupant).forceMove( exit );
			this.occupant.reset_view();
			this.occupant = null;
			this.icon_state = "scanner_0";

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Ent_Dynamic) )) {
				x = _a;
				

				if ( Lang13.Bool( this.component_parts.Contains( x ) ) || x == this.beaker ) {
					continue;
				}
				x.forceMove( this.loc );
			}

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.cardinal )) {
				this.dir = Convert.ToInt32( _b );
				
				C = Lang13.FindIn( typeof(Obj_Machinery_Computer_Cloning), Map13.GetStep( this, this.dir ) );

				if ( Lang13.Bool( C ) ) {
					C.update_icon();
				}
			}
			return true;
		}

		// Function from file: dna_modifier.dm
		public void put_in( Ent_Static M = null ) {
			dynamic C = null;
			Mob_Dead_Observer ghost = null;

			M.loc = this;
			((dynamic)M).reset_view();
			this.occupant = M;
			this.icon_state = "scanner_1";

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.cardinal )) {
				this.dir = Convert.ToInt32( _b );
				
				C = Lang13.FindIn( typeof(Obj_Machinery_Computer_Cloning), Map13.GetStep( this, this.dir ) );

				if ( Lang13.Bool( C ) ) {
					C.update_icon();

					if ( !Lang13.Bool( ((dynamic)M).client ) && Lang13.Bool( ((dynamic)M).mind ) ) {
						
						foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Dead_Observer) )) {
							ghost = _a;
							

							if ( ghost.mind == ((dynamic)M).mind ) {
								
								if ( ghost.client != null && ghost.can_reenter_corpse != 0 ) {
									ghost.WriteMsg( "sound/effects/adminhelp.ogg" );
									GlobalFuncs.to_chat( ghost, new Txt( "<span class='interface'><b><font size = 3>Your corpse has been placed into a cloning scanner. Return to your body if you want to be resurrected/cloned!</b> (Verbs -> Ghost -> Re-enter corpse, or <a href='?src=" ).Ref( ghost ).str( ";reentercorpse=1'>click here!</a>)</font></span>" ).ToString() );
								} else {
									ghost.canclone = M;
								}
								break;
							}
						}
					}
					break;
				}
			}
			return;
		}

		// Function from file: dna_modifier.dm
		public void eject_occupant( Ent_Static exit = null ) {
			exit = exit ?? this.loc;

			dynamic M = null;

			this.go_out( exit );

			if ( !Lang13.Bool( this.occupant ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this )) {
					M = _a;
					
					((Ent_Dynamic)M).forceMove( GlobalFuncs.get_turf( this ) );
				}
			}
			return;
		}

		// Function from file: dna_modifier.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			dynamic _default = null;

			this.go_out();
			_default = base.Destroy( (object)(brokenup) );
			return _default;
		}

		// Function from file: dna_modifier.dm
		public override int crowbarDestroy( dynamic user = null ) {
			
			if ( Lang13.Bool( this.occupant ) ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='warning'>You cannot disassemble " ).the( this ).item().str( ", it's occupado.</span>" ).ToString() );
				return 0;
			}
			return base.crowbarDestroy( (object)(user) );
		}

		// Function from file: dna_modifier.dm
		public override dynamic relaymove( Mob M = null, double? direction = null ) {
			
			if ( Lang13.Bool( M.stat ) ) {
				return null;
			}
			this.go_out();
			return null;
		}

		// Function from file: dna_modifier.dm
		public override bool allow_drop(  ) {
			return false;
		}

		// Function from file: dna_modifier.dm
		public override dynamic RefreshParts(  ) {
			int efficiency = 0;
			Obj_Item_Weapon_StockParts SP = null;

			efficiency = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts) )) {
				SP = _a;
				
				efficiency += SP.rating - 1;
			}
			this.injector_cooldown = Lang13.Initial( this, "injector_cooldown" ) - efficiency * 30;
			return null;
		}

		// Function from file: dna_modifier.dm
		[Verb]
		[VerbInfo( name: "Enter DNA Scanner", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public void move_inside(  ) {
			
			if ( Task13.User.incapacitated() || Task13.User.lying == true ) {
				return;
			}

			if ( !( Task13.User is Mob_Living_Carbon_Human ) && !( Task13.User is Mob_Living_Carbon_Monkey ) ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='notice'> Try as you might, you can not climb up into the scanner.</span>" );
				return;
			}

			if ( Task13.User is Mob_Living_Carbon_Human_Manifested ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='notice'> For some reason, the scanner is unable to read your genes.</span>" );
				return;
			}

			if ( Lang13.Bool( this.occupant ) ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='notice'> <B>The scanner is already occupied!</B></span>" );
				return;
			}
			Task13.User.stop_pulling();
			Task13.User.loc = this;
			Task13.User.reset_view();
			this.occupant = Task13.User;
			this.icon_state = "scanner_1";
			this.add_fingerprint( Task13.User );
			return;
		}

		// Function from file: dna_modifier.dm
		[Verb]
		[VerbInfo( name: "Eject DNA Scanner", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public void eject(  ) {
			
			if ( Task13.User.isUnconscious() || Task13.User is Mob_Living_SimpleAnimal ) {
				return;
			}
			this.eject_occupant();
			this.add_fingerprint( Task13.User );
			return;
		}

	}

}