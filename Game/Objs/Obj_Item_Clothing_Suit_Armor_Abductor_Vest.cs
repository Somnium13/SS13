// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Armor_Abductor_Vest : Obj_Item_Clothing_Suit_Armor_Abductor {

		public int mode = 1;
		public bool stealth_active = false;
		public int combat_cooldown = 10;
		public dynamic disguise = null;
		public ByTable stealth_armor = new ByTable().Set( "melee", 15 ).Set( "bullet", 15 ).Set( "laser", 15 ).Set( "energy", 15 ).Set( "bomb", 15 ).Set( "bio", 15 ).Set( "rad", 15 );
		public ByTable combat_armor = new ByTable().Set( "melee", 50 ).Set( "bullet", 50 ).Set( "laser", 50 ).Set( "energy", 50 ).Set( "bomb", 50 ).Set( "bio", 50 ).Set( "rad", 50 );

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "armor";
			this.blood_overlay_type = "armor";
			this.origin_tech = "materials=5;biotech=4;powerstorage=5";
			this.armor = new ByTable().Set( "melee", 15 ).Set( "bullet", 15 ).Set( "laser", 15 ).Set( "energy", 15 ).Set( "bomb", 15 ).Set( "bio", 15 ).Set( "rad", 15 );
			this.action_button_name = "Activate";
			this.action_button_is_hands_free = true;
			this.icon = "icons/obj/abductor.dmi";
			this.icon_state = "vest_stealth";
		}

		public Obj_Item_Clothing_Suit_Armor_Abductor_Vest ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: abduction_gear.dm
		public override int? process( dynamic seconds = null ) {
			this.combat_cooldown++;

			if ( this.combat_cooldown == Lang13.Initial( this, "combat_cooldown" ) ) {
				GlobalVars.SSobj.processing.Remove( this );
			}
			return null;
		}

		// Function from file: abduction_gear.dm
		public override void ui_action_click(  ) {
			
			switch ((int)( this.mode )) {
				case 2:
					this.Adrenaline();
					break;
				case 1:
					
					if ( this.stealth_active ) {
						this.DeactivateStealth();
					} else {
						this.ActivateStealth();
					}
					break;
			}
			return;
		}

		// Function from file: abduction_gear.dm
		public override bool IsReflect( dynamic def_zone = null ) {
			this.DeactivateStealth();
			return false;
		}

		// Function from file: abduction_gear.dm
		public override bool hit_reaction( Mob_Living_Carbon owner = null, string attack_text = null, int? final_block_chance = null, dynamic damage = null, int? attack_type = null ) {
			this.DeactivateStealth();
			return false;
		}

		// Function from file: abduction_gear.dm
		public void Adrenaline(  ) {
			Ent_Static M = null;

			
			if ( this.loc is Mob_Living_Carbon_Human ) {
				
				if ( this.combat_cooldown != Lang13.Initial( this, "combat_cooldown" ) ) {
					((dynamic)this.loc).WriteMsg( "<span class='warning'>Combat injection is still recharging.</span>" );
				}
				M = this.loc;
				((dynamic)M).adjustStaminaLoss( -75 );
				((dynamic)M).SetParalysis( 0 );
				((dynamic)M).SetStunned( 0 );
				((dynamic)M).SetWeakened( 0 );
				this.combat_cooldown = 0;
				GlobalVars.SSobj.processing.Or( this );
			}
			return;
		}

		// Function from file: abduction_gear.dm
		public void DeactivateStealth(  ) {
			Ent_Static M = null;

			
			if ( !this.stealth_active ) {
				return;
			}
			this.stealth_active = false;

			if ( this.loc is Mob_Living_Carbon_Human ) {
				M = this.loc;
				Task13.Schedule( 0, (Task13.Closure)(() => {
					GlobalFuncs.anim( M.loc, M, "icons/mob/mob.dmi", null, "uncloak", null, M.dir );
					return;
				}));
				((dynamic)M).name_override = null;
				M.overlays.Cut();
				((dynamic)M).regenerate_icons();
			}
			return;
		}

		// Function from file: abduction_gear.dm
		public void ActivateStealth(  ) {
			Ent_Static M = null;

			
			if ( this.disguise == null ) {
				return;
			}
			this.stealth_active = true;

			if ( this.loc is Mob_Living_Carbon_Human ) {
				M = this.loc;
				Task13.Schedule( 0, (Task13.Closure)(() => {
					GlobalFuncs.anim( M.loc, M, "icons/mob/mob.dmi", null, "cloak", null, M.dir );
					return;
				}));
				((dynamic)M).name_override = this.disguise.name;
				M.icon = this.disguise.icon;
				M.icon_state = this.disguise.icon_state;
				M.overlays = this.disguise.overlays;
				((dynamic)M).update_inv_r_hand();
				((dynamic)M).update_inv_l_hand();
			}
			return;
		}

		// Function from file: abduction_gear.dm
		public void SetDisguise( dynamic entry = null ) {
			this.disguise = entry;
			return;
		}

		// Function from file: abduction_gear.dm
		public void flip_mode(  ) {
			Ent_Static H = null;
			Ent_Static H2 = null;

			
			switch ((int)( this.mode )) {
				case 1:
					this.mode = 2;
					this.DeactivateStealth();
					this.armor = this.combat_armor;
					this.icon_state = "vest_combat";

					if ( this.loc is Mob_Living_Carbon_Human ) {
						H = this.loc;
						((dynamic)H).update_inv_wear_suit();
					}
					return;
					break;
				case 2:
					this.mode = 1;
					this.armor = this.stealth_armor;
					this.icon_state = "vest_stealth";

					if ( this.loc is Mob_Living_Carbon_Human ) {
						H2 = this.loc;
						((dynamic)H2).update_inv_wear_suit();
					}
					return;
					break;
			}
			return;
		}

	}

}