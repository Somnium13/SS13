// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Melee_Energy_Sword : Obj_Item_Weapon_Melee_Energy {

		public string base_state = "sword";
		public string active_state = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 3;
			this.throwforce = 5;
			this.throw_speed = 1;
			this.throw_range = 5;
			this.w_class = 2;
			this.origin_tech = "magnets=3;syndicate=4";
			this.attack_verb = new ByTable(new object [] { "attacked", "slashed", "stabbed", "sliced", "torn", "ripped", "diced", "cut" });
			this.icon_state = "sword0";
		}

		// Function from file: energy.dm
		public Obj_Item_Weapon_Melee_Energy_Sword ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this._color = Rand13.Pick(new object [] { "red", "blue", "green", "purple" });

			if ( !Lang13.Bool( this.active_state ) ) {
				this.active_state = this.base_state + this._color;
			}
			this.update_icon();
			return;
		}

		// Function from file: energy.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( a is Obj_Item_Weapon_Melee_Energy_Sword ) {
				
				if ( a == this ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You try to attach the end of the energy sword to... itself. You're not very smart, are you?</span>" );

					if ( b is Mob_Living_Carbon_Human ) {
						((Mob_Living)b).adjustBrainLoss( 10 );
					}
				} else {
					GlobalFuncs.to_chat( b, "<span class='notice'>You attach the ends of the two energy swords, making a single double-bladed weapon! You're cool.</span>" );
					new Obj_Item_Weapon_Dualsaber( b.loc );
					GlobalFuncs.qdel( a );
					a = null;
					GlobalFuncs.qdel( this );
				}
			}
			return null;
		}

		// Function from file: energy.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( this.active && Lang13.Bool( this._color ) ) {
				this.icon_state = this.active_state;
			} else {
				this.icon_state = "" + this.base_state + this.active;
			}
			return null;
		}

		// Function from file: energy.dm
		public void toggleActive( dynamic user = null, string togglestate = null ) {
			togglestate = togglestate ?? "";

			
			switch ((string)( togglestate )) {
				case "on":
					this.active = true;
					break;
				case "off":
					this.active = false;
					break;
				default:
					this.active = !this.active;
					break;
			}

			if ( this.active ) {
				this.force = 30;
				this.w_class = 4;
				this.sharpness = 1.5;
				this.hitsound = "sound/weapons/blade1.ogg";
				GlobalFuncs.playsound( user, "sound/weapons/saberon.ogg", 50, 1 );
				GlobalFuncs.to_chat( user, "<span class='notice'> " + this + " is now active.</span>" );
			} else {
				this.force = 3;
				this.w_class = 2;
				this.sharpness = 0;
				GlobalFuncs.playsound( user, "sound/weapons/saberoff.ogg", 50, 1 );
				this.hitsound = "sound/weapons/empty.ogg";
				GlobalFuncs.to_chat( user, "<span class='notice'> " + this + " can now be concealed.</span>" );
			}
			this.update_icon();
			return;
		}

		// Function from file: energy.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( Lang13.Bool( user.mutations.Contains( 5 ) ) && Rand13.PercentChance( 50 ) && this.active ) {
				GlobalFuncs.to_chat( user, "<span class='danger'>You accidentally cut yourself with " + this + ".</span>" );
				((Mob_Living)user).take_organ_damage( 5, 5 );
				return null;
			}
			this.toggleActive( user );
			this.add_fingerprint( user );
			return null;
		}

		// Function from file: energy.dm
		public override bool IsShield(  ) {
			
			if ( this.active ) {
				return true;
			}
			return false;
		}

	}

}