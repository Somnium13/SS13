// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease_FakeGbs : Disease {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "GBS";
			this.max_stages = 5;
			this.spread_text = "On contact";
			this.spread_flags = 32;
			this.cure_text = "Synaptizine & Sulfur";
			this.cures = new ByTable(new object [] { "synaptizine", "sulfur" });
			this.agent = "Gravitokinetic Bipotential SADS-";
			this.viable_mobtypes = new ByTable(new object [] { typeof(Mob_Living_Carbon_Human), typeof(Mob_Living_Carbon_Monkey) });
			this.desc = "If left untreated death will occur.";
			this.severity = "BIOHAZARD THREAT!";
		}

		// Function from file: fake_gbs.dm
		public override void stage_act(  ) {
			base.stage_act();

			switch ((int?)( this.stage )) {
				case 2:
					
					if ( Rand13.PercentChance( 1 ) ) {
						((Mob)this.affected_mob).emote( "sneeze" );
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 5 ) ) {
						((Mob)this.affected_mob).emote( "cough" );
					} else if ( Rand13.PercentChance( 5 ) ) {
						((Mob)this.affected_mob).emote( "gasp" );
					}

					if ( Rand13.PercentChance( 10 ) ) {
						this.affected_mob.WriteMsg( "<span class='danger'>You're starting to feel very weak...</span>" );
					}
					break;
				case 4:
					
					if ( Rand13.PercentChance( 10 ) ) {
						((Mob)this.affected_mob).emote( "cough" );
					}
					break;
				case 5:
					
					if ( Rand13.PercentChance( 10 ) ) {
						((Mob)this.affected_mob).emote( "cough" );
					}
					break;
			}
			return;
		}

	}

}