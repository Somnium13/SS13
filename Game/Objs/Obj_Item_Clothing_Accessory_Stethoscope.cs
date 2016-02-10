// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Accessory_Stethoscope : Obj_Item_Clothing_Accessory {

		protected override void __FieldInit() {
			base.__FieldInit();

			this._color = "stethoscope";
			this.origin_tech = "biotech=1";
			this.icon_state = "stethoscope";
		}

		public Obj_Item_Clothing_Accessory_Stethoscope ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: accessory.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			dynamic body_part = null;
			string their = null;
			string sound = null;
			string sound_strength = null;

			
			if ( M is Mob_Living_Carbon_Human && user is Mob_Living ) {
				
				if ( user.a_intent == "help" ) {
					body_part = GlobalFuncs.parse_zone( ((dynamic)user.zone_sel).selecting );

					if ( Lang13.Bool( body_part ) ) {
						their = "their";

						dynamic _a = M.gender; // Was a switch-case, sorry for the mess.
						if ( _a=="male" ) {
							their = "his";
						} else if ( _a=="female" ) {
							their = "her";
						}
						sound = "pulse";
						sound_strength = null;

						if ( ((Mob)M).isDead() ) {
							sound_strength = "cannot hear";
							sound = "anything";
						} else {
							sound_strength = "hear a weak";

							dynamic _b = body_part; // Was a switch-case, sorry for the mess.
							if ( _b=="chest" ) {
								
								if ( Convert.ToDouble( M.oxyloss ) < 50 ) {
									sound_strength = "hear a healthy";
								}
								sound = "pulse and respiration";
							} else if ( _b=="eyes" || _b=="mouth" ) {
								sound_strength = "cannot hear";
								sound = "anything";
							} else {
								sound_strength = "hear a weak";
							}
						}
						((Ent_Static)user).visible_message( "" + user + " places " + this + " against " + M + "'s " + body_part + " and listens attentively.", "You place " + this + " against " + their + " " + body_part + ". You " + sound_strength + " " + sound + "." );
						return null;
					}
				}
			}
			return base.attack( (object)(M), (object)(user), def_zone, eat_override );
		}

	}

}