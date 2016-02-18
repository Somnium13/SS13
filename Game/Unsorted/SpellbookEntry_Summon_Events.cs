// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpellbookEntry_Summon_Events : SpellbookEntry_Summon {

		public int times = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Summon Events";
			this.desc = "Give Murphy's law a little push and replace all events with special wizard ones that will confound and confuse everyone. Multiple castings increase the rate of these events.";
			this.log_name = "SE";
		}

		// Function from file: spellbook.dm
		public override string GetInfo(  ) {
			string _default = null;

			_default = base.GetInfo();

			if ( this.times > 0 ) {
				_default += "You cast it " + this.times + " times.<br>";
			}
			return _default;
		}

		// Function from file: spellbook.dm
		public override bool Buy( Mob user = null, Obj_Item_Weapon_Spellbook book = null ) {
			GlobalFuncs.feedback_add_details( "wizard_spell_learned", this.log_name );
			GlobalFuncs.summonevents();
			this.times++;
			GlobalFuncs.playsound( GlobalFuncs.get_turf( user ), "sound/magic/CastSummon.ogg", 50, 1 );
			user.WriteMsg( "<span class='notice'>You have cast summon events.</span>" );
			return true;
		}

		// Function from file: spellbook.dm
		public override bool IsAvailible(  ) {
			
			if ( !Lang13.Bool( GlobalVars.ticker.mode ) ) {
				return false;
			}
			return GlobalVars.ticker.mode.name != "ragin' mages" && !GlobalVars.config.no_summon_events;
		}

	}

}