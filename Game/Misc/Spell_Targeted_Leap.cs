// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Spell_Targeted_Leap : Spell_Targeted {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Jump";
			this.desc = "Leap great distances!";
			this.panel = "Mutant Powers";
			this.range = -1;
			this.charge_max = 60;
			this.spell_flags = 64;
			this.duration = 10;
			this.cast_sound = "sound/weapons/thudswoosh.ogg";
			this.hud_state = "gen_leap";
			this.override_base = "genetic";
		}

		// Function from file: goon_powers.dm
		public override bool cast( ByTable targets = null, Mob user = null ) {
			Mob_Living target = null;
			bool failed_leap = false;
			dynamic M = null;
			double prevLayer = 0;
			int? i = null;
			Ent_Static container = null;
			int wiggle = 0;

			
			foreach (dynamic _b in Lang13.Enumerate( targets, typeof(Mob_Living) )) {
				target = _b;
				

				if ( target.loc is Mob || target.lying == true || target.stunned != 0 || Lang13.Bool( target.locked_to ) ) {
					GlobalFuncs.to_chat( target, "<span class='warning'>You can't jump right now!</span>" );
					continue;
				}
				failed_leap = false;

				if ( target.loc is Tile ) {
					
					if ( target.restrained() ) {
						
						foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( 1, target ) )) {
							M = _a;
							

							if ( M.pulling == target ) {
								
								if ( !((Mob)M).restrained() && !Task13.User.isUnconscious() && M.canmove && Task13.User.Adjacent( M ) ) {
									failed_leap = true;
								} else {
									((Mob)M).stop_pulling();
								}
							}
						}
					}

					if ( target.pinned.len != 0 ) {
						failed_leap = true;
					}
					target.visible_message( "<span class='warning'><b>" + target.name + "</b> takes a huge leap!</span>" );
					GlobalFuncs.playsound( target.loc, "sound/weapons/thudswoosh.ogg", 50, 1 );

					if ( failed_leap ) {
						target.Weaken( 5 );
						target.Stun( 5 );
						target.visible_message( new Txt( "<span class='warning'> " ).the( Task13.User ).item().str( " attempts to leap away but is slammed back down to the ground!</span>" ).ToString(), "<span class='warning'>You attempt to leap away but are suddenly slammed back down to the ground!</span>", "<span class='notice'>You hear the flexing of powerful muscles and suddenly a crash as a body hits the floor.</span>" );
						continue;
					}
					prevLayer = target.layer;
					target.layer = 9;
					i = null;
					i = 0;

					while (( i ??0) < ( this.duration ??0)) {
						Map13.Step( target, target.dir );

						if ( ( i ??0) < 5 ) {
							target.pixel_y += 8;
						} else {
							target.pixel_y -= 8;
						}
						Task13.Sleep( 1 );
						i++;
					}
					target.pixel_y = 0;

					if ( Lang13.Bool( ((dynamic)( target.mutations != null && Rand13.PercentChance( 66 ) )).Contains( 6 ) ) ) {
						target.visible_message( "<span class='warning'><b>" + target.name + "</b> crashes due to their heavy weight!</span>" );
						target.weakened += 10;
						target.stunned += 5;
					}
					target.layer = prevLayer;
				}

				if ( target.loc is Obj ) {
					container = target.loc;
					GlobalFuncs.to_chat( target, "<span class='warning'>You leap and slam your head against the inside of " + container + "! Ouch!</span>" );
					target.paralysis += 3;
					target.weakened += 5;
					container.visible_message( "<span class='warning'><b>" + container + "</b> emits a loud thump and rattles a bit.</span>" );
					GlobalFuncs.playsound( target.loc, "sound/effects/bang.ogg", 50, 1 );
					wiggle = 6;

					while (wiggle > 0) {
						wiggle--;
						container.pixel_x = Rand13.Int( -3, 3 );
						container.pixel_y = Rand13.Int( -3, 3 );
						Task13.Sleep( 1 );
					}
					container.pixel_x = 0;
					container.pixel_y = 0;
				}
			}
			return false;
		}

	}

}