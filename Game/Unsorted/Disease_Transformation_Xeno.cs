// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease_Transformation_Xeno : Disease_Transformation {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Xenomorph Transformation";
			this.cure_text = "Spaceacillin & Glycerol";
			this.cures = new ByTable(new object [] { "spaceacillin", "glycerol" });
			this.cure_chance = 5;
			this.agent = "Rip-LEY Alien Microbes";
			this.desc = "This disease changes the victim into a xenomorph.";
			this.severity = "BIOHAZARD THREAT!";
			this.stage1 = null;
			this.stage2 = new ByTable(new object [] { "Your throat feels scratchy.", "<span class='danger'>Kill...</span>" });
			this.stage3 = new ByTable(new object [] { "<span class='danger'>Your throat feels very scratchy.</span>", "Your skin feels tight.", "<span class='danger'>You can feel something move...inside.</span>" });
			this.stage4 = new ByTable(new object [] { 
				"<span class='danger'>Your skin feels very tight.</span>", 
				"<span class='danger'>Your blood boils!</span>", 
				"<span class='danger'>You can feel... something...inside you.</span>"
			 });
			this.stage5 = new ByTable(new object [] { "<span class='danger'>Your skin feels as if it's about to burst off!</span>" });
			this.new_form = typeof(Mob_Living_Carbon_Alien_Humanoid_Hunter);
		}

		// Function from file: transformation.dm
		public override void stage_act(  ) {
			base.stage_act();

			switch ((int?)( this.stage )) {
				case 3:
					
					if ( Rand13.PercentChance( 4 ) ) {
						this.affected_mob.WriteMsg( "<span class='danger'>You feel a stabbing pain in your head.</span>" );
						((Mob)this.affected_mob).Paralyse( 2 );
					}
					break;
				case 4:
					
					if ( Rand13.PercentChance( 20 ) ) {
						((Ent_Dynamic)this.affected_mob).say( Rand13.Pick(new object [] { "You look delicious.", "Going to... devour you...", "Hsssshhhhh!" }) );
					}
					break;
			}
			return;
		}

	}

}