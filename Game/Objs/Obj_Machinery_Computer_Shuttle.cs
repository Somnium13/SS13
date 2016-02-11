// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Shuttle : Obj_Machinery_Computer {

		public int auth_need = 3;
		public ByTable authorized = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.light_color = "#7DE1E1";
			this.icon_state = "shuttle";
		}

		public Obj_Machinery_Computer_Shuttle ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: shuttle.dm
		public override int emag( dynamic user = null ) {
			string choice = null;

			
			if ( !( this.emagged != 0 ) ) {
				new Obj_Effect_Effect_Sparks( GlobalFuncs.get_turf( this ) );
				GlobalFuncs.playsound( this.loc, "sparks", 50, 1 );
				choice = Interface13.Alert( user, "Would you like to launch the shuttle?", "Shuttle control", "Launch", "Cancel" );

				if ( GlobalVars.emergency_shuttle.location == 1 ) {
					
					switch ((string)( choice )) {
						case "Launch":
							GlobalFuncs.to_chat( typeof(Game13), "<span class='notice'><B>Alert: Shuttle launch time shortened to 10 seconds!</B></span>" );
							GlobalVars.emergency_shuttle.settimeleft( 10 );
							this.emagged = 1;
							return 1;
							break;
						case "Cancel":
							return 0;
							break;
					}
				}
			}
			return 0;
		}

		// Function from file: shuttle.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic pda = null;
			ByTable cardaccess = null;
			string choice = null;

			
			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( !( a is Obj_Item_Weapon_Card ) || !( GlobalVars.ticker != null ) || GlobalVars.emergency_shuttle.location != 1 || !Lang13.Bool( b ) ) {
				return null;
			}

			if ( a is Obj_Item_Weapon_Card_Id || a is Obj_Item_Device_Pda ) {
				
				if ( a is Obj_Item_Device_Pda ) {
					pda = a;
					a = pda.id;
				}

				if ( !Lang13.Bool( a.access ) ) {
					GlobalFuncs.to_chat( b, "The access level of " + a.registered_name + "'s card is not high enough. " );
					return null;
				}
				cardaccess = a.access;

				if ( !( cardaccess is ByTable ) || !( cardaccess.len != 0 ) ) {
					GlobalFuncs.to_chat( b, "The access level of " + a.registered_name + "'s card is not high enough. " );
					return null;
				}

				if ( !Lang13.Bool( a.access.Contains( GlobalVars.access_heads ) ) ) {
					GlobalFuncs.to_chat( b, "The access level of " + a.registered_name + "'s card is not high enough. " );
					return 0;
				}
				choice = Interface13.Alert( b, new Txt( "Would you like to (un)authorize a shortened launch time? " ).item( this.auth_need - this.authorized.len ).str( " authorization" ).s().str( " are still needed. Use abort to cancel all authorizations." ).ToString(), "Shuttle Launch", "Authorize", "Repeal", "Abort" );

				if ( GlobalVars.emergency_shuttle.location != 1 && ((Mob)b).get_active_hand() != a ) {
					return 0;
				}

				switch ((string)( choice )) {
					case "Authorize":
						this.authorized.Remove( a.registered_name );
						this.authorized.Add( a.registered_name );

						if ( this.auth_need - this.authorized.len > 0 ) {
							GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( b ) + " has authorized early shuttle launch" );
							GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "" + b.ckey + " has authorized early shuttle launch" ) ) );
							GlobalFuncs.to_chat( typeof(Game13), "<span class='notice'><B>Alert: " + ( this.auth_need - this.authorized.len ) + " authorizations needed until shuttle is launched early</B></span>" );
						} else {
							GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( b ) + " has launched the shuttle" );
							GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "" + b.ckey + " has launched the shuttle early" ) ) );
							GlobalFuncs.to_chat( typeof(Game13), "<span class='notice'><B>Alert: Shuttle launch time shortened to 10 seconds!</B></span>" );
							GlobalVars.emergency_shuttle.online = true;
							GlobalVars.emergency_shuttle.settimeleft( 10 );
							Lang13.Delete( this.authorized );
							this.authorized = null;
							this.authorized = new ByTable();
						}
						break;
					case "Repeal":
						this.authorized.Remove( a.registered_name );
						GlobalFuncs.to_chat( typeof(Game13), "<span class='notice'><B>Alert: " + ( this.auth_need - this.authorized.len ) + " authorizations needed until shuttle is launched early</B></span>" );
						break;
					case "Abort":
						GlobalFuncs.to_chat( typeof(Game13), "<span class='notice'><B>All authorizations to shortening time for shuttle launch have been revoked!</B></span>" );
						this.authorized.len = 0;
						this.authorized = new ByTable();
						break;
				}
			}
			return null;
		}

	}

}