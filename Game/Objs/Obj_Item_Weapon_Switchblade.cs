// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Switchblade : Obj_Item_Weapon {

		public bool extended = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 64;
			this.force = 3;
			this.w_class = 2;
			this.throwforce = 5;
			this.throw_speed = 3;
			this.throw_range = 6;
			this.materials = new ByTable().Set( "$metal", 12000 );
			this.origin_tech = "materials=1";
			this.hitsound = "sound/weapons/genhit.ogg";
			this.attack_verb = new ByTable(new object [] { "stubbed", "poked" });
			this.icon_state = "switchblade";
		}

		public Obj_Item_Weapon_Switchblade ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: weaponry.dm
		public override int suicide_act( Mob_Living_Carbon_Human user = null ) {
			user.visible_message( new Txt( "<span class='suicide'>" ).item( user ).str( " is slitting " ).his_her_its_their().str( " own throat with the " ).item( this.name ).str( "! It looks like " ).he_she_it_they().str( "'s trying to commit suicide.</span>" ).ToString() );
			return 1;
		}

		// Function from file: weaponry.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.extended = !this.extended;
			GlobalFuncs.playsound( this.loc, "sound/weapons/batonextend.ogg", 50, 1 );

			if ( this.extended ) {
				this.force = 20;
				this.w_class = 3;
				this.throwforce = 23;
				this.icon_state = "switchblade_ext";
				this.attack_verb = new ByTable(new object [] { "slashed", "stabbed", "sliced", "torn", "ripped", "diced", "cut" });
				this.hitsound = "sound/weapons/bladeslice.ogg";
			} else {
				this.force = 3;
				this.w_class = 2;
				this.throwforce = 5;
				this.icon_state = "switchblade";
				this.attack_verb = new ByTable(new object [] { "stubbed", "poked" });
				this.hitsound = "sound/weapons/genhit.ogg";
			}
			return null;
		}

	}

}