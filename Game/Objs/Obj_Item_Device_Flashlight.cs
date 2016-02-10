// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Flashlight : Obj_Item_Device {

		public bool on = false;
		public int brightness_on = 4;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "flashlight";
			this.origin_tech = "engineering=1";
			this.w_class = 2;
			this.slot_flags = 512;
			this.starting_materials = new ByTable().Set( "$iron", 50 ).Set( "$glass", 20 );
			this.w_type = 5;
			this.melt_temperature = 1783.1500244140625;
			this.action_button_name = "Toggle Light";
			this.icon = "icons/obj/lighting.dmi";
			this.icon_state = "flashlight";
		}

		public Obj_Item_Device_Flashlight ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: flashlight.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			dynamic H = null;
			dynamic eye_protection = null;

			this.add_fingerprint( user );

			if ( this.on && ((dynamic)user.zone_sel).selecting == "eyes" ) {
				Interface13.Stat( null, user.mutations.Contains( 5 ) );

				if ( ( false || ((Mob_Living)user).getBrainLoss() >= 60 ) && Rand13.PercentChance( 50 ) ) {
					return base.attack( (object)(M), (object)(user), def_zone, eat_override );
				}

				if ( !Lang13.Bool( user.dexterity_check() ) ) {
					GlobalFuncs.to_chat( user, "<span class='notice'>You don't have the dexterity to do this!</span>" );
					return null;
				}
				H = M;

				if ( M is Mob_Living_Carbon_Human ) {
					eye_protection = ((Mob_Living_Carbon_Human)H).get_body_part_coverage( 2048 );

					if ( Lang13.Bool( eye_protection ) ) {
						GlobalFuncs.to_chat( user, "<span class='notice'>You're going to need to remove their " + eye_protection + " first.</span>" );
						return null;
					}
				}

				if ( M == user ) {
					
					if ( !Lang13.Bool( M.blinded ) ) {
						Icon13.Flick( "flash", M.flash );
						((Ent_Static)M).visible_message( new Txt( "<span class='notice'>" ).item( M ).str( " directs " ).item( this ).str( " to " ).his_her_its_their().str( " eyes.</span>" ).ToString(), "<span class='notice'>You wave the light in front of your eyes! Trippy!</span>" );
					} else {
						((Ent_Static)M).visible_message( new Txt( "<span class='notice'>" ).item( M ).str( " directs " ).item( this ).str( " to " ).his_her_its_their().str( " eyes.</span>" ).ToString(), "<span class='notice'>You wave the light in front of your eyes.</span>" );
					}
					return null;
				}
				((Ent_Static)user).visible_message( "<span class='notice'>" + user + " directs " + this + " to " + M + "'s eyes.</span>", "<span class='notice'>You direct " + this + " to " + M + "'s eyes.</span>" );

				if ( M is Mob_Living_Carbon_Human || M is Mob_Living_Carbon_Monkey ) {
					
					if ( Convert.ToInt32( M.stat ) == 2 || ( M.sdisabilities & 1 ) != 0 ) {
						GlobalFuncs.to_chat( user, "<span class='notice'>" + M + " pupils does not react to the light!</span>" );
					} else {
						Interface13.Stat( null, M.mutations.Contains( 3 ) );

						if ( Convert.ToInt32( M.stat ) == 2 || ( M.sdisabilities & 1 ) != 0 ) {
							Icon13.Flick( "flash", M.flash );
							GlobalFuncs.to_chat( user, "<span class='notice'>" + M + " pupils give an eerie glow!</span>" );
						} else if ( !Lang13.Bool( M.blinded ) ) {
							Icon13.Flick( "flash", M.flash );
							GlobalFuncs.to_chat( user, "<span class='notice'>" + M + "'s pupils narrow.</span>" );
						}
					}
				}
			} else {
				return base.attack( (object)(M), (object)(user), def_zone, eat_override );
			}
			return null;
		}

		// Function from file: flashlight.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( !( user.loc is Tile ) ) {
				GlobalFuncs.to_chat( user, "You cannot turn the light on while in this " + user.loc + "." );
				return 0;
			}
			this.on = !this.on;
			this.update_brightness( user );
			return 1;
		}

		// Function from file: flashlight.dm
		public void update_brightness( dynamic user = null ) {
			
			if ( this.on ) {
				this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + "-on";
				this.set_light( this.brightness_on );
			} else {
				this.icon_state = Lang13.Initial( this, "icon_state" );
				this.set_light( 0 );
			}
			return;
		}

		// Function from file: flashlight.dm
		public override bool initialize( bool? suppress_icon_check = null ) {
			base.initialize( suppress_icon_check );

			if ( this.on ) {
				this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + "-on";
				this.set_light( this.brightness_on );
			} else {
				this.icon_state = Lang13.Initial( this, "icon_state" );
				this.set_light( 0 );
			}
			return false;
		}

	}

}