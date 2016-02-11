// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Transformer : Obj_Machinery {

		public bool transform_dead = false;
		public bool transform_standing = false;
		public int cooldown_duration = 900;
		public int cooldown_time = 0;
		public bool cooldown_state = false;
		public int robot_cell_charge = 5000;
		public dynamic force_borg_module = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 10;
			this.active_power_usage = 5000;
			this.icon = "icons/obj/recycling.dmi";
			this.icon_state = "separator-AO1";
			this.layer = 5;
		}

		// Function from file: transformer.dm
		public Obj_Machinery_Transformer ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Machinery_Conveyor_Auto( this.loc, GlobalVars.WEST );
			return;
		}

		// Function from file: transformer.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			ByTable modules = null;
			dynamic sel_mod = null;

			
			if ( !( Task13.User is Mob_Living_Silicon_Ai ) ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>This machine is way above your pay-grade.</span>" );
				return 0;
			}

			if ( !href_list.Contains( "act" ) ) {
				return 0;
			}

			dynamic _a = href_list["act"]; // Was a switch-case, sorry for the mess.
			if ( _a=="force_class" ) {
				modules = new ByTable(new object [] { "(Robot's Choice)" });
				modules.Add( GlobalFuncs.getAvailableRobotModules() );
				sel_mod = Interface13.Input( "Please, select a module!", "Robot", null, null, modules, InputType.Null | InputType.Any );

				if ( !Lang13.Bool( sel_mod ) ) {
					return null;
				}

				if ( sel_mod == "(Robot's Choice)" ) {
					this.force_borg_module = null;
				} else {
					this.force_borg_module = sel_mod;
				}
			}
			this.interact( Task13.User );
			return 1;
		}

		// Function from file: transformer.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			string data = null;
			Browser popup = null;

			data = "";

			if ( this.cooldown_state ) {
				data += "<b>Recalibrating.</b> Time left: " + ( this.cooldown_time - Game13.time ) / 10 + " seconds.";
			} else {
				data += "<p style=\"color:red;font-weight:bold;\"><blink>ROBOTICIZER ACTIVE.</blink></p>";
			}
			data += new Txt( @"
		<h2>Settings</h2>
		<ul>
			<li>
				<b>Next Borg's Module:</b>
				<a href=""?src=" ).Ref( this ).str( ";act=force_class\">" ).item( ( this.force_borg_module == null ? ((dynamic)( "Not Forced" )) : this.force_borg_module ) ).str( "</a>\n			</li>\n		</ul>\n	" ).ToString();
			popup = new Browser( user, "transformer", this.name, 400, 300 );
			popup.set_content( data );
			popup.set_title_image( ((Mob)user).browse_rsc_icon( this.icon, this.icon_state ) );
			popup.open();
			return null;
		}

		// Function from file: transformer.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.interact( user );
			return null;
		}

		// Function from file: transformer.dm
		public override dynamic process(  ) {
			bool old_cooldown_state = false;

			base.process();
			old_cooldown_state = this.cooldown_state;
			this.cooldown_state = this.cooldown_time > Game13.time;

			if ( this.cooldown_state != old_cooldown_state ) {
				this.update_icon();

				if ( !this.cooldown_state ) {
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/machines/Ping.ogg", 50, 0 );
				}
			}
			return null;
		}

		// Function from file: transformer.dm
		public void do_transform( Ent_Static H = null ) {
			dynamic R = null;

			
			if ( ( this.stat & 3 ) != 0 ) {
				return;
			}

			if ( this.cooldown_state ) {
				return;
			}

			if ( !this.transform_dead && Convert.ToInt32( ((dynamic)H).stat ) == 2 ) {
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/machines/buzz-sigh.ogg", 50, 0 );
				return;
			}

			if ( Lang13.Bool( GlobalFuncs.jobban_isbanned( H, "Cyborg" ) ) ) {
				this.visible_message( new Txt( "<span class='danger'>" ).The( this.name ).item().str( " throws an exception. Lifeform not compatible with factory.</span>" ).ToString() );
				return;
			}
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/welder.ogg", 50, 1 );
			((dynamic)H).emote( "scream", null, null, 1 );
			((dynamic)H).adjustBruteLoss( Num13.MaxInt( 0, ((int)( 80 - Convert.ToDouble( ((dynamic)H).getBruteLoss() ) )) ) );
			((Mob_Living_Carbon_Human)H).handle_regular_hud_updates();
			Task13.Sleep( 5 );
			R = ((dynamic)H).Robotize( 1 );

			if ( Lang13.Bool( R ) ) {
				R.cell.maxcharge = this.robot_cell_charge;
				R.cell.charge = this.robot_cell_charge;
				R.weakened = 5;
				((Mob_Living_Silicon_Robot)R).pick_module( this.force_borg_module );
				((Mob_Living_Silicon_Robot)R).updateicon();
			}
			Task13.Schedule( 50, (Task13.Closure)(() => {
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/machines/ding.ogg", 50, 0 );

				if ( Lang13.Bool( R ) ) {
					R.weakened = 0;
				}
				return;
			}));
			this.cooldown_time = Game13.time + this.cooldown_duration;
			this.cooldown_state = true;
			this.update_icon();
			return;
		}

		// Function from file: transformer.dm
		public override bool Bumped( Ent_Static AM = null, dynamic yes = null ) {
			double? move_dir = null;
			Ent_Static H = null;
			double? move_dir2 = null;

			
			if ( this.cooldown_state ) {
				return false;
			}

			if ( AM is Mob_Living_Carbon_Human ) {
				move_dir = Map13.GetDistance( this.loc, AM.loc );
				H = AM;

				if ( ( this.transform_standing || Lang13.Bool( ((dynamic)H).lying ) ) && move_dir == GlobalVars.EAST ) {
					AM.loc = this.loc;
					this.do_transform( AM );
				}
			} else if ( AM is Obj_Item ) {
				move_dir2 = Map13.GetDistance( this.loc, AM.loc );

				if ( move_dir2 == GlobalVars.EAST ) {
					AM.loc = this.loc;
				}
			}
			return false;
		}

		// Function from file: transformer.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			base.update_icon( (object)(location), (object)(target) );

			if ( ( this.stat & 3 ) != 0 || this.cooldown_time > Game13.time ) {
				this.icon_state = "separator-AO0";
			} else {
				this.icon_state = Lang13.Initial( this, "icon_state" );
			}
			return null;
		}

		// Function from file: transformer.dm
		public override dynamic power_change(  ) {
			base.power_change();
			this.update_icon();
			return null;
		}

	}

}