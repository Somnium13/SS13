// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_RobotParts_RobotSuit : Obj_Item_RobotParts {

		public dynamic l_arm = null;
		public dynamic r_arm = null;
		public dynamic l_leg = null;
		public dynamic r_leg = null;
		public dynamic chest = null;
		public dynamic head = null;
		public dynamic created_name = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "robo_suit";
		}

		// Function from file: robot_parts.dm
		public Obj_Item_RobotParts_RobotSuit ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.updateicon();
			return;
		}

		// Function from file: robot_parts.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Obj_Item_Weapon_Ed209Assembly B = null;
			dynamic M = null;
			dynamic T = null;
			Mob_Living_Silicon_Robot O = null;
			dynamic P = null;
			Obj_Item L = null;
			dynamic cell_component = null;
			dynamic t = null;

			base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( a is Obj_Item_Stack_Sheet_Metal && !Lang13.Bool( this.l_arm ) && !Lang13.Bool( this.r_arm ) && !Lang13.Bool( this.l_leg ) && !Lang13.Bool( this.r_leg ) && !Lang13.Bool( this.chest ) && !Lang13.Bool( this.head ) ) {
				B = new Obj_Item_Weapon_Ed209Assembly();
				B.loc = GlobalFuncs.get_turf( this );
				GlobalFuncs.to_chat( b, "You armed the robot frame" );
				a.use( 1 );

				if ( ((Mob)b).get_inactive_hand() == this ) {
					((Mob)b).before_take_item( this );
					((Mob)b).put_in_inactive_hand( B );
				}
				GlobalFuncs.qdel( this );
			}

			if ( a is Obj_Item_RobotParts_LLeg ) {
				
				if ( Lang13.Bool( this.l_leg ) ) {
					return null;
				}

				if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					this.l_leg = a;
					this.updateicon();
				}
			}

			if ( a is Obj_Item_RobotParts_RLeg ) {
				
				if ( Lang13.Bool( this.r_leg ) ) {
					return null;
				}

				if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					this.r_leg = a;
					this.updateicon();
				}
			}

			if ( a is Obj_Item_RobotParts_LArm ) {
				
				if ( Lang13.Bool( this.l_arm ) ) {
					return null;
				}

				if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					this.l_arm = a;
					this.updateicon();
				}
			}

			if ( a is Obj_Item_RobotParts_RArm ) {
				
				if ( Lang13.Bool( this.r_arm ) ) {
					return null;
				}

				if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					this.r_arm = a;
					this.updateicon();
				}
			}

			if ( a is Obj_Item_RobotParts_Chest ) {
				
				if ( Lang13.Bool( this.chest ) ) {
					return null;
				}

				if ( Lang13.Bool( a.wires ) && Lang13.Bool( a.cell ) ) {
					
					if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
						this.chest = a;
						this.updateicon();
					}
				} else if ( !Lang13.Bool( a.wires ) ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You need to attach wires to it first!</span>" );
				} else {
					GlobalFuncs.to_chat( b, "<span class='notice'>You need to attach a cell to it first!</span>" );
				}
			}

			if ( a is Obj_Item_RobotParts_Head ) {
				
				if ( Lang13.Bool( this.head ) ) {
					return null;
				}

				if ( Lang13.Bool( a.flash2 ) && Lang13.Bool( a.flash1 ) ) {
					
					if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
						this.head = a;
						this.updateicon();
					}
				} else {
					GlobalFuncs.to_chat( b, "<span class='notice'>You need to attach a flash to it first!</span>" );
				}
			}

			if ( a is Obj_Item_Device_Mmi || a is Obj_Item_Device_Mmi_Posibrain ) {
				M = a;
				T = GlobalFuncs.get_turf( this );

				if ( this.check_completion() ) {
					
					if ( !( this.loc is Tile ) ) {
						GlobalFuncs.to_chat( b, "<span class='warning'>You can't put the " + a + " in, the frame has to be standing on the ground to be perfectly precise.</span>" );
						return null;
					}

					if ( !Lang13.Bool( M.brainmob ) ) {
						GlobalFuncs.to_chat( b, "<span class='warning'>Sticking an empty " + a + " into the frame would sort of defeat the purpose.</span>" );
						return null;
					}

					if ( !Lang13.Bool( M.brainmob.key ) ) {
						
						if ( !( GlobalFuncs.mind_can_reenter( M.brainmob.mind ) == true ) ) {
							GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>" ).The( a ).item().str( " is completely unresponsive; there's no point.</span>" ).ToString() );
							return null;
						}
					}

					if ( Convert.ToInt32( M.brainmob.stat ) == 2 ) {
						GlobalFuncs.to_chat( b, "<span class='warning'>Sticking a dead " + a + " into the frame would sort of defeat the purpose.</span>" );
						return null;
					}

					if ( GlobalVars.ticker.mode.head_revolutionaries.Contains( M.brainmob.mind ) ) {
						GlobalFuncs.to_chat( b, "<span class='warning'>The frame's firmware lets out a shrill sound, and flashes 'Abnormal Memory Engram'. It refuses to accept the " + a + ".</span>" );
						return null;
					}

					if ( Lang13.Bool( GlobalFuncs.jobban_isbanned( M.brainmob, "Cyborg" ) ) ) {
						GlobalFuncs.to_chat( b, "<span class='warning'>This " + a + " does not seem to fit.</span>" );
						return null;
					}

					if ( !Lang13.Bool( b.drop_item( a ) ) ) {
						return null;
					}
					O = new Mob_Living_Silicon_Robot( GlobalFuncs.get_turf( this.loc ), null, true );

					foreach (dynamic _b in Lang13.Enumerate( M.mommi_assembly_parts )) {
						P = _b;
						

						foreach (dynamic _a in Lang13.Enumerate( M.contents, typeof(Obj_Item) )) {
							L = _a;
							

							if ( L == P ) {
								L.loc = T;
								M.contents -= L;
							}
						}
					}

					if ( !( O != null ) ) {
						return null;
					}
					O.mmi = a;
					O.invisibility = 0;
					O.custom_name = this.created_name;
					O.updatename( "Default" );
					((Mind)M.brainmob.mind).transfer_to( O );

					if ( O.mind != null && Lang13.Bool( O.mind.special_role ) ) {
						O.mind.store_memory( "In case you look at this after being borged, the objectives are only here until I find a way to make them not show up for you, as I can't simply delete them without screwing up round-end reporting. --NeoFite" );
					}
					O.job = "Cyborg";
					O.cell = this.chest.cell;
					O.cell.loc = O;
					a.loc = O;

					if ( Lang13.Bool( O.cell ) ) {
						cell_component = O.components["power cell"];
						cell_component.wrapped = O.cell;
						cell_component.installed = 1;
					}
					GlobalFuncs.feedback_inc( "cyborg_birth", 1 );
					O.__CallVerb("Namepick" );
					GlobalFuncs.qdel( this );
				} else {
					GlobalFuncs.to_chat( b, "<span class='notice'>The MMI must go in after everything else!</span>" );
				}
			}

			if ( a is Obj_Item_Weapon_Pen ) {
				t = GlobalFuncs.stripped_input( b, "Enter new robot name", this.name, this.created_name, 26 );

				if ( !Lang13.Bool( t ) ) {
					return null;
				}

				if ( !GlobalFuncs.in_range( this, Task13.User ) && this.loc != Task13.User ) {
					return null;
				}
				this.created_name = t;
			}
			return null;
		}

		// Function from file: robot_parts.dm
		public bool check_completion(  ) {
			
			if ( Lang13.Bool( this.l_arm ) && Lang13.Bool( this.r_arm ) ) {
				
				if ( Lang13.Bool( this.l_leg ) && Lang13.Bool( this.r_leg ) ) {
					
					if ( Lang13.Bool( this.chest ) && Lang13.Bool( this.head ) ) {
						GlobalFuncs.feedback_inc( "cyborg_frames_built", 1 );
						return true;
					}
				}
			}
			return false;
		}

		// Function from file: robot_parts.dm
		public void updateicon(  ) {
			this.overlays.len = 0;

			if ( Lang13.Bool( this.l_arm ) ) {
				this.overlays.Add( "l_arm+o" );
			}

			if ( Lang13.Bool( this.r_arm ) ) {
				this.overlays.Add( "r_arm+o" );
			}

			if ( Lang13.Bool( this.chest ) ) {
				this.overlays.Add( "chest+o" );
			}

			if ( Lang13.Bool( this.l_leg ) ) {
				this.overlays.Add( "l_leg+o" );
			}

			if ( Lang13.Bool( this.r_leg ) ) {
				this.overlays.Add( "r_leg+o" );
			}

			if ( Lang13.Bool( this.head ) ) {
				this.overlays.Add( "head+o" );
			}
			return;
		}

		// Function from file: robot_parts.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );
			GlobalFuncs.qdel( this.l_arm );
			this.l_arm = null;
			GlobalFuncs.qdel( this.r_arm );
			this.r_arm = null;
			GlobalFuncs.qdel( this.l_leg );
			this.l_leg = null;
			GlobalFuncs.qdel( this.r_leg );
			this.r_leg = null;
			GlobalFuncs.qdel( this.chest );
			this.chest = null;
			GlobalFuncs.qdel( this.head );
			this.head = null;
			return null;
		}

	}

}