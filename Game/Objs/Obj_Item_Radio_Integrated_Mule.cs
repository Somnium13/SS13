// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Radio_Integrated_Mule : Obj_Item_Radio_Integrated {

		public ByTable botlist = null;
		public dynamic active = null;
		public dynamic botstatus = null;
		public ByTable beacons = null;
		public double beacon_freq = 1400;
		public double control_freq = 1447;

		// Function from file: radio.dm
		public Obj_Item_Radio_Integrated_Mule ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 5, (Task13.Closure)(() => {
				
				if ( GlobalVars.radio_controller != null ) {
					GlobalVars.radio_controller.add_object( this, this.control_freq, GlobalVars.RADIO_MULEBOT );
					GlobalVars.radio_controller.add_object( this, this.beacon_freq, GlobalVars.RADIO_NAVBEACONS );
					Task13.Schedule( 10, (Task13.Closure)(() => {
						this.post_signal( this.beacon_freq, "findbeacon", "delivery", null, null, null, null, GlobalVars.RADIO_NAVBEACONS );
						return;
					}));
				}
				return;
			}));
			return;
		}

		// Function from file: radio.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			Ent_Static PDA = null;
			string cmd = null;
			dynamic dest = null;

			base.Topic( href, href_list, (object)(hclient) );
			PDA = this.hostpda;
			cmd = "command";

			if ( Lang13.Bool( this.active ) ) {
				cmd = "command " + this.active.suffix;
			}

			dynamic _a = href_list["op"]; // Was a switch-case, sorry for the mess.
			if ( _a=="control" ) {
				this.active = Lang13.FindObj( href_list["bot"] );
				this.post_signal( this.control_freq, cmd, "bot_status", null, null, null, null, GlobalVars.RADIO_MULEBOT );
			} else if ( _a=="scanbots" ) {
				this.botlist = null;
				this.post_signal( this.control_freq, "command", "bot_status", null, null, null, null, GlobalVars.RADIO_MULEBOT );
			} else if ( _a=="botlist" ) {
				this.active = null;
			} else if ( _a=="unload" ) {
				this.post_signal( this.control_freq, cmd, "unload", null, null, null, null, GlobalVars.RADIO_MULEBOT );
				this.post_signal( this.control_freq, cmd, "bot_status", null, null, null, null, GlobalVars.RADIO_MULEBOT );
			} else if ( _a=="setdest" ) {
				
				if ( this.beacons != null ) {
					dest = Interface13.Input( "Select Bot Destination", "Mulebot " + this.active.suffix + " Interlink", this.active.destination, null, this.beacons, InputType.Null | InputType.Any );

					if ( Lang13.Bool( dest ) ) {
						this.post_signal( this.control_freq, cmd, "target", "destination", dest, null, null, GlobalVars.RADIO_MULEBOT );
						this.post_signal( this.control_freq, cmd, "bot_status", null, null, null, null, GlobalVars.RADIO_MULEBOT );
					}
				}
			} else if ( _a=="retoff" ) {
				this.post_signal( this.control_freq, cmd, "autoret", "value", 0, null, null, GlobalVars.RADIO_MULEBOT );
				this.post_signal( this.control_freq, cmd, "bot_status", null, null, null, null, GlobalVars.RADIO_MULEBOT );
			} else if ( _a=="reton" ) {
				this.post_signal( this.control_freq, cmd, "autoret", "value", 1, null, null, GlobalVars.RADIO_MULEBOT );
				this.post_signal( this.control_freq, cmd, "bot_status", null, null, null, null, GlobalVars.RADIO_MULEBOT );
			} else if ( _a=="pickoff" ) {
				this.post_signal( this.control_freq, cmd, "autopick", "value", 0, null, null, GlobalVars.RADIO_MULEBOT );
				this.post_signal( this.control_freq, cmd, "bot_status", null, null, null, null, GlobalVars.RADIO_MULEBOT );
			} else if ( _a=="pickon" ) {
				this.post_signal( this.control_freq, cmd, "autopick", "value", 1, null, null, GlobalVars.RADIO_MULEBOT );
				this.post_signal( this.control_freq, cmd, "bot_status", null, null, null, null, GlobalVars.RADIO_MULEBOT );
			} else if ( _a=="stop" || _a=="go" || _a=="home" ) {
				this.post_signal( this.control_freq, cmd, href_list["op"], null, null, null, null, GlobalVars.RADIO_MULEBOT );
				this.post_signal( this.control_freq, cmd, "bot_status", null, null, null, null, GlobalVars.RADIO_MULEBOT );
			}
			((dynamic)PDA).cartridge.unlock();
			return null;
		}

		// Function from file: radio.dm
		public override bool receive_signal( Game_Data signal = null, bool? receive_method = null, dynamic receive_param = null ) {
			dynamic b = null;

			
			if ( ((dynamic)signal).data["type"] == "mulebot" ) {
				
				if ( !( this.botlist != null ) ) {
					this.botlist = new ByTable();
				}

				if ( !this.botlist.Contains( ((dynamic)signal).source ) ) {
					this.botlist.Add( ((dynamic)signal).source );
				}

				if ( this.active == ((dynamic)signal).source ) {
					b = ((dynamic)signal).data;
					this.botstatus = b.Copy();
				}
			} else if ( Lang13.Bool( ((dynamic)signal).data["beacon"] ) ) {
				
				if ( !( this.beacons != null ) ) {
					this.beacons = new ByTable();
				}
				this.beacons[((dynamic)signal).data["beacon"]] = ((dynamic)signal).source;
			}
			return false;
		}

		// Function from file: radio.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( GlobalVars.radio_controller != null ) {
				GlobalVars.radio_controller.remove_object( this, this.control_freq );
				GlobalVars.radio_controller.remove_object( this, this.beacon_freq );
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}