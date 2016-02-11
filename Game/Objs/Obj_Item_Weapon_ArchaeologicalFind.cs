// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ArchaeologicalFind : Obj_Item_Weapon {

		public int? find_type = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/xenoarchaeology.dmi";
			this.icon_state = "ano01";
		}

		// Function from file: finds.dm
		public Obj_Item_Weapon_ArchaeologicalFind ( dynamic loc = null, bool? new_item_type = null ) : base( (object)(loc) ) {
			string item_type = null;
			string additional_desc = null;
			dynamic new_item = null;
			string source_material = null;
			bool apply_material_decorations = false;
			bool apply_image_decorations = false;
			string material_descriptor = null;
			bool apply_prefix = false;
			bool talkative = false;
			int chance = 0;
			dynamic type = null;
			ByTable possible_spawns = null;
			dynamic new_type = null;
			ByTable possible_spawns2 = null;
			dynamic new_type2 = null;
			dynamic possible_spawns3 = null;
			dynamic new_type3 = null;
			dynamic spawn_type = null;
			dynamic new_gun = null;
			Obj_Item_Weapon_Gun_Projectile new_gun2 = null;
			int? num_bullets = null;
			int? i = null;
			Type A = null;
			Obj_Item I = null;
			Obj_Item I2 = null;
			ByTable candidates = null;
			dynamic spawn_type2 = null;
			ByTable possible_spawns4 = null;
			dynamic new_type4 = null;
			ByTable possible_spawns5 = null;
			dynamic new_type5 = null;
			string decorations = null;
			ByTable descriptors = null;
			int? index = null;
			string engravings = null;
			dynamic T = null;

			this.AddToProfiler();

			if ( new_item_type == true ) {
				this.find_type = Lang13.IntNullable( new_item_type );
			} else {
				this.find_type = Rand13.Int( 1, 34 );
			}
			item_type = "object";
			this.icon_state = "unknown" + Rand13.Int( 1, 4 );
			additional_desc = "";
			source_material = "";
			apply_material_decorations = true;
			apply_image_decorations = false;
			material_descriptor = "";
			apply_prefix = true;

			if ( Rand13.PercentChance( 40 ) ) {
				material_descriptor = Rand13.Pick(new object [] { "rusted ", "dusty ", "archaic ", "fragile " });
			}
			source_material = Rand13.Pick(new object [] { "cordite", "quadrinium", "steel", "titanium", "aluminium", "ferritic-alloy", "plasteel", "duranium" });
			talkative = false;

			if ( Rand13.PercentChance( 5 ) ) {
				talkative = true;
			}

			switch ((int?)( this.find_type )) {
				case 1:
					item_type = "bowl";
					new_item = new Obj_Item_Weapon_ReagentContainers_Glass( this.loc );
					new_item.icon = "icons/obj/xenoarchaeology.dmi";
					new_item.icon_state = "bowl";
					apply_image_decorations = true;

					if ( Rand13.PercentChance( 20 ) ) {
						additional_desc = "There appear to be " + Rand13.Pick(new object [] { "dark", "faintly glowing", "pungent", "bright" }) + " " + Rand13.Pick(new object [] { "red", "purple", "green", "blue" }) + " stains inside.";
					}
					break;
				case 2:
					item_type = "urn";
					new_item = new Obj_Item_Weapon_ReagentContainers_Glass( this.loc );
					new_item.icon = "icons/obj/xenoarchaeology.dmi";
					new_item.icon_state = "urn";
					apply_image_decorations = true;

					if ( Rand13.PercentChance( 20 ) ) {
						additional_desc = "It " + Rand13.Pick(new object [] { "whispers faintly", "makes a quiet roaring sound", "whistles softly", "thrums quietly", "throbs" }) + " if you put it to your ear.";
					}
					break;
				case 3:
					item_type = "" + Rand13.Pick(new object [] { "fork", "spoon", "knife" });

					if ( Rand13.PercentChance( 25 ) ) {
						new_item = new Obj_Item_Weapon_Kitchen_Utensil_Fork( this.loc );
					} else if ( Rand13.PercentChance( 50 ) ) {
						new_item = new Obj_Item_Weapon_Kitchen_Utensil_Knife( this.loc );
					} else {
						new_item = new Obj_Item_Weapon_Kitchen_Utensil_Spoon( this.loc );
					}
					additional_desc = "" + Rand13.Pick(new object [] { "It's like no " + item_type + " you've ever seen before", "It's a mystery how anyone is supposed to eat with this", "You wonder what the creator's mouth was shaped like" }) + ".";
					break;
				case 4:
					item_type = "statuette";
					this.icon_state = "statuette";
					additional_desc = "It depicts a " + Rand13.Pick(new object [] { "small", "ferocious", "wild", "pleasing", "hulking" }) + " " + Rand13.Pick(new object [] { "alien figure", "rodent-like creature", "reptilian alien", "primate", "unidentifiable object" }) + " " + Rand13.Pick(new object [] { "performing unspeakable acts", "posing heroically", "in a fetal position", "cheering", "sobbing", "making a plaintive gesture", "making a rude gesture" }) + ".";
					break;
				case 5:
					item_type = "instrument";
					this.icon_state = "instrument";

					if ( Rand13.PercentChance( 30 ) ) {
						apply_image_decorations = true;
						additional_desc = "" + Rand13.Pick(new object [] { "You're not sure how anyone could have played this", "You wonder how many mouths the creator had", "You wonder what it sounds like", "You wonder what kind of music was made with it" }) + ".";
					}
					break;
				case 6:
					item_type = "" + Rand13.Pick(new object [] { "bladed knife", "serrated blade", "sharp cutting implement" });
					new_item = new Obj_Item_Weapon_Kitchen_Utensil_Knife_Large( this.loc );
					additional_desc = "" + Rand13.Pick(new object [] { "It doesn't look safe.", "It looks wickedly jagged", "There appear to be " + Rand13.Pick(new object [] { "dark red", "dark purple", "dark green", "dark blue" }) + " stains along the edges" }) + ".";
					break;
				case 7:
					chance = 10;

					foreach (dynamic _a in Lang13.Enumerate( Lang13.GetTypes( typeof(Obj_Item_Weapon_Coin) ) )) {
						type = _a;
						

						if ( Rand13.PercentChance( chance ) ) {
							new_item = Lang13.Call( type, this.loc );
							break;
						}
						chance += 10;
					}
					item_type = new_item.name;
					apply_prefix = false;
					apply_material_decorations = false;
					apply_image_decorations = true;
					break;
				case 8:
					item_type = "handcuffs";
					new_item = new Obj_Item_Weapon_Handcuffs( this.loc );
					additional_desc = "" + Rand13.Pick(new object [] { "They appear to be for securing two things together", "Looks kinky", "Doesn't seem like a children's toy" }) + ".";
					break;
				case 9:
					item_type = "" + Rand13.Pick(new object [] { "wicked", "evil", "byzantine", "dangerous" }) + " looking " + Rand13.Pick(new object [] { "device", "contraption", "thing", "trap" });
					apply_prefix = false;
					new_item = new Obj_Item_Weapon_Legcuffs_Beartrap( this.loc );
					additional_desc = "" + Rand13.Pick(new object [] { "It looks like it could take a limb off", "Could be some kind of animal trap", "There appear to be " + Rand13.Pick(new object [] { "dark red", "dark purple", "dark green", "dark blue" }) + " stains along part of it" }) + ".";
					break;
				case 10:
					item_type = "" + Rand13.Pick(new object [] { "cylinder", "tank", "chamber" });
					new_item = new Obj_Item_Weapon_Lighter( this.loc );
					additional_desc = "There is a tiny device attached.";

					if ( Rand13.PercentChance( 30 ) ) {
						apply_image_decorations = true;
					}
					break;
				case 11:
					item_type = "box";
					new_item = new Obj_Item_Weapon_Storage_Box( this.loc );
					new_item.icon = "icons/obj/xenoarchaeology.dmi";
					new_item.icon_state = "box";

					if ( Rand13.PercentChance( 30 ) ) {
						apply_image_decorations = true;
					}
					break;
				case 12:
					item_type = "" + Rand13.Pick(new object [] { "cylinder", "tank", "chamber" });

					if ( Rand13.PercentChance( 25 ) ) {
						new_item = new Obj_Item_Weapon_Tank_Air( this.loc );
					} else if ( Rand13.PercentChance( 50 ) ) {
						new_item = new Obj_Item_Weapon_Tank_Anesthetic( this.loc );
					} else {
						new_item = new Obj_Item_Weapon_Tank_Plasma( this.loc );
					}
					this.icon_state = Rand13.Pick(new object [] { "oxygen", "oxygen_fr", "oxygen_f", "plasma", "anesthetic" });
					additional_desc = "It " + Rand13.Pick(new object [] { "gloops", "sloshes" }) + " slightly when you shake it.";
					break;
				case 13:
					item_type = "tool";

					if ( Rand13.PercentChance( 25 ) ) {
						new_item = new Obj_Item_Weapon_Wrench( this.loc );
					} else if ( Rand13.PercentChance( 25 ) ) {
						new_item = new Obj_Item_Weapon_Crowbar( this.loc );
					} else {
						new_item = new Obj_Item_Weapon_Screwdriver( this.loc );
					}
					additional_desc = "" + Rand13.Pick(new object [] { "It doesn't look safe.", "You wonder what it was used for", "There appear to be " + Rand13.Pick(new object [] { "dark red", "dark purple", "dark green", "dark blue" }) + " stains on it" }) + ".";
					break;
				case 14:
					apply_material_decorations = false;
					possible_spawns = new ByTable();
					possible_spawns.Add( typeof(Obj_Item_Stack_Sheet_Metal) );
					possible_spawns.Add( typeof(Obj_Item_Stack_Sheet_Plasteel) );
					possible_spawns.Add( typeof(Obj_Item_Stack_Sheet_Glass_Glass) );
					possible_spawns.Add( typeof(Obj_Item_Stack_Sheet_Glass_Rglass) );
					possible_spawns.Add( typeof(Obj_Item_Stack_Sheet_Mineral_Plasma) );
					possible_spawns.Add( typeof(Obj_Item_Stack_Sheet_Mineral_Mythril) );
					possible_spawns.Add( typeof(Obj_Item_Stack_Sheet_Mineral_Gold) );
					possible_spawns.Add( typeof(Obj_Item_Stack_Sheet_Mineral_Silver) );
					possible_spawns.Add( typeof(Obj_Item_Stack_Sheet_Mineral_Enruranium) );
					possible_spawns.Add( typeof(Obj_Item_Stack_Sheet_Mineral_Sandstone) );
					possible_spawns.Add( typeof(Obj_Item_Stack_Sheet_Mineral_Silver) );
					new_type = Rand13.PickFromTable( possible_spawns );

					if ( new_type == typeof(Obj_Item_Stack_Sheet_Metal) ) {
						new_item = GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Metal), GlobalFuncs.get_turf( this ) );
					} else {
						new_item = Lang13.Call( new_type, GlobalFuncs.get_turf( this ) );
					}
					new_item.amount = Rand13.Int( 5, 45 );
					break;
				case 15:
					
					if ( Rand13.PercentChance( 75 ) ) {
						new_item = new Obj_Item_Weapon_Pen( this.loc );
					} else {
						new_item = new Obj_Item_Weapon_Pen_Sleepypen( this.loc );
					}

					if ( Rand13.PercentChance( 30 ) ) {
						apply_image_decorations = true;
					}
					break;
				case 16:
					apply_prefix = false;

					if ( Rand13.PercentChance( 25 ) ) {
						item_type = "smooth green crystal";
						this.icon_state = "Green lump";
					} else if ( Rand13.PercentChance( 33 ) ) {
						item_type = "irregular purple crystal";
						this.icon_state = "Phazon";
					} else if ( Rand13.PercentChance( 50 ) ) {
						item_type = "rough red crystal";
						this.icon_state = "changerock";
					} else {
						item_type = "smooth red crystal";
						this.icon_state = "smoothrock";
					}
					additional_desc = Rand13.Pick(new object [] { "It shines faintly as it catches the light.", "It appears to have a faint inner glow.", "It seems to draw you inward as you look it at.", "Something twinkles faintly as you look at it.", "It's mesmerizing to behold." });
					apply_material_decorations = false;

					if ( Rand13.PercentChance( 10 ) ) {
						apply_image_decorations = true;
					}
					break;
				case 17:
					apply_prefix = false;
					new_item = new Obj_Item_Weapon_Melee_Cultblade( this.loc );
					apply_material_decorations = false;
					apply_image_decorations = false;
					break;
				case 18:
					new_item = new Obj_Item_Beacon( this.loc );
					talkative = false;
					new_item.icon_state = "unknown" + Rand13.Int( 1, 4 );
					new_item.icon = "icons/obj/xenoarchaeology.dmi";
					new_item.desc = "";
					break;
				case 19:
					apply_prefix = false;
					new_item = new Obj_Item_Weapon_Claymore( this.loc );
					new_item.force = 10;
					item_type = new_item.name;
					break;
				case 20:
					apply_prefix = false;
					possible_spawns2 = new ByTable(new object [] { 
						typeof(Obj_Item_Clothing_Head_Culthood), 
						typeof(Obj_Item_Clothing_Head_Magus), 
						typeof(Obj_Item_Clothing_Head_Culthood_Alt), 
						typeof(Obj_Item_Clothing_Head_Helmet_Space_Cult)
					 });
					new_type2 = Rand13.PickFromTable( possible_spawns2 );
					new_item = Lang13.Call( new_type2, this.loc );
					break;
				case 21:
					apply_prefix = false;
					new_item = new Obj_Item_Device_Soulstone( this.loc );
					item_type = new_item.name;
					apply_material_decorations = false;
					break;
				case 22:
					
					if ( Rand13.PercentChance( 50 ) ) {
						new_item = GlobalFuncs.getFromPool( typeof(Obj_Item_Weapon_Shard), loc );
					} else {
						new_item = GlobalFuncs.getFromPool( typeof(Obj_Item_Weapon_Shard_Plasma), loc );
					}
					apply_prefix = false;
					apply_image_decorations = false;
					apply_material_decorations = false;
					break;
				case 23:
					apply_prefix = false;
					new_item = new Obj_Item_Stack_Rods( this.loc );
					apply_image_decorations = false;
					apply_material_decorations = false;
					break;
				case 24:
					possible_spawns3 = GlobalFuncs.existing_typesof( typeof(Obj_Item_Weapon_StockParts) );
					new_type3 = Rand13.PickFromTable( possible_spawns3 );
					new_item = Lang13.Call( new_type3, this.loc );
					item_type = new_item.name;
					apply_material_decorations = false;
					break;
				case 25:
					apply_prefix = false;
					new_item = new Obj_Item_Weapon_Katana( this.loc );
					new_item.force = 10;
					item_type = new_item.name;
					break;
				case 26:
					spawn_type = Rand13.Pick(new object [] { typeof(Obj_Item_Weapon_Gun_Energy_Laser_Practice), typeof(Obj_Item_Weapon_Gun_Energy_Laser), typeof(Obj_Item_Weapon_Gun_Energy_Xray), typeof(Obj_Item_Weapon_Gun_Energy_Laser_Captain) });

					if ( Lang13.Bool( spawn_type ) ) {
						new_gun = Lang13.Call( spawn_type, this.loc );
						new_item = new_gun;
						new_item.icon = "icons/obj/xenoarchaeology.dmi";
						new_item.icon_state = "egun" + Rand13.Int( 1, 6 );
						new_gun.desc = "This is an antique energy weapon, you're not sure if it will fire or not.";
						new_gun.charge_states = false;

						if ( Rand13.PercentChance( 5 ) ) {
							new_gun.power_supply.rigged = 1;
						}

						if ( Rand13.PercentChance( 10 ) ) {
							new_gun.power_supply.maxcharge = 0;
						}

						if ( Rand13.PercentChance( 15 ) ) {
							new_gun.power_supply.charge = Rand13.Int( 0, Convert.ToInt32( new_gun.power_supply.maxcharge ) );
						} else {
							new_gun.power_supply.charge = 0;
						}
					}
					item_type = "gun";
					break;
				case 27:
					new_gun2 = new Obj_Item_Weapon_Gun_Projectile( this.loc );
					new_item = new_gun2;
					new_item.icon_state = "gun" + Rand13.Int( 1, 4 );
					new_item.icon = "icons/obj/xenoarchaeology.dmi";
					new_gun2.caliber = Rand13.PickWeighted(new object [] { 32767, new ByTable().Set( "357", 1 ), 39320, new ByTable().Set( "75", 1 ), 58980, new ByTable().Set( "38", 1 ), 65535, new ByTable().Set( "12mm", 1 ) });
					new_gun2.max_shells = Rand13.Int( 1, 12 );

					if ( Rand13.PercentChance( 33 ) ) {
						num_bullets = Rand13.Int( 1, ((int)( new_gun2.max_shells ??0 )) );

						if ( ( num_bullets ??0) < new_gun2.loaded.len ) {
							new_gun2.loaded.len = 0;
							i = null;
							i = 1;

							while (( i ??0) <= ( num_bullets ??0)) {
								A = Lang13.FindClass( new_gun2.ammo_type );
								new_gun2.loaded.Add( Lang13.Call( A, new_gun2 ) );
								i++;
							}
						} else {
							
							foreach (dynamic _b in Lang13.Enumerate( new_gun2, typeof(Obj_Item) )) {
								I = _b;
								

								if ( new_gun2.loaded.len > ( num_bullets ??0) ) {
									
									if ( new_gun2.loaded.Contains( I ) ) {
										new_gun2.loaded.Remove( I );
										I.loc = null;
									}
								} else {
									break;
								}
							}
						}
					} else {
						
						foreach (dynamic _c in Lang13.Enumerate( new_gun2, typeof(Obj_Item) )) {
							I2 = _c;
							

							if ( new_gun2.loaded.Contains( I2 ) ) {
								new_gun2.loaded.Remove( I2 );
								I2.loc = null;
							}
						}
					}
					item_type = "gun";
					break;
				case 28:
					
					if ( Rand13.PercentChance( 50 ) ) {
						apply_image_decorations = false;
					}
					break;
				case 29:
					candidates = new ByTable().Set( "/obj/item/weapon/fossil/bone", 9 ).Set( "/obj/item/weapon/fossil/skull", 3 ).Set( "/obj/item/weapon/fossil/skull/horned", 2 );
					spawn_type2 = GlobalFuncs.pickweight( candidates );
					new_item = Lang13.Call( spawn_type2, this.loc );
					apply_prefix = false;
					additional_desc = "A fossilised part of an alien, long dead.";
					apply_image_decorations = false;
					apply_material_decorations = false;
					break;
				case 30:
					new_item = new Obj_Item_Weapon_Fossil_Shell( this.loc );
					apply_prefix = false;
					additional_desc = "A fossilised, pre-Stygian alien crustacean.";
					apply_image_decorations = false;
					apply_material_decorations = false;

					if ( Rand13.PercentChance( 10 ) ) {
						apply_image_decorations = true;
					}
					break;
				case 31:
					new_item = new Obj_Item_Weapon_Fossil_Plant( this.loc );
					item_type = new_item.name;
					additional_desc = "A fossilised shred of alien plant matter.";
					apply_image_decorations = false;
					apply_material_decorations = false;
					apply_prefix = false;
					break;
				case 32:
					apply_prefix = false;
					item_type = "humanoid " + Rand13.Pick(new object [] { "remains", "skeleton" });
					this.icon = "icons/effects/blood.dmi";
					this.icon_state = "remains";
					additional_desc = Rand13.Pick(new object [] { "They appear almost human.", "They are contorted in a most gruesome way.", "They look almost peaceful.", "The bones are yellowing and old, but remarkably well preserved.", "The bones are scored by numerous burns and partially melted.", "The are battered and broken, in some cases less than splinters are left.", "The mouth is wide open in a death rictus, the victim would appear to have died screaming." });
					apply_image_decorations = false;
					apply_material_decorations = false;
					break;
				case 33:
					apply_prefix = false;
					item_type = "" + Rand13.Pick(new object [] { "mechanical", "robotic", "cyborg" }) + " " + Rand13.Pick(new object [] { "remains", "chassis", "debris" });
					this.icon = "icons/effects/blood.dmi";
					this.icon_state = "remainsrobot";
					additional_desc = Rand13.Pick(new object [] { "Almost mistakeable for the remains of a modern cyborg.", "They are barely recognisable as anything other than a pile of waste metals.", "It looks like the battered remains of an ancient robot chassis.", "The chassis is rusting and old, but remarkably well preserved.", "The chassis is scored by numerous burns and partially melted.", "The chassis is battered and broken, in some cases only chunks of metal are left.", "A pile of wires and crap metal that looks vaguely robotic." });
					apply_image_decorations = false;
					apply_material_decorations = false;
					break;
				case 34:
					apply_prefix = false;
					item_type = "alien " + Rand13.Pick(new object [] { "remains", "skeleton" });
					this.icon = "icons/effects/blood.dmi";
					this.icon_state = "remainsxeno";
					additional_desc = Rand13.Pick(new object [] { "It looks vaguely reptilian, but with more teeth.", "They are faintly unsettling.", "There is a faint aura of unease about them.", "The bones are yellowing and old, but remarkably well preserved.", "The bones are scored by numerous burns and partially melted.", "The are battered and broken, in some cases less than splinters are left.", "This creature would have been twisted and monstrous when it was alive.", "It doesn't look human." });
					apply_image_decorations = false;
					apply_material_decorations = false;
					break;
				case 35:
					apply_material_decorations = false;
					possible_spawns4 = new ByTable();
					possible_spawns4.Add( typeof(Obj_Item_Clothing_Mask_Happy) );
					new_type4 = Rand13.PickFromTable( possible_spawns4 );
					new_item = Lang13.Call( new_type4, this.loc );
					break;
				case 36:
					apply_material_decorations = false;
					possible_spawns5 = new ByTable();
					possible_spawns5.Add( typeof(Obj_Item_Weapon_Dice_D20_Cursed) );
					new_type5 = Rand13.PickFromTable( possible_spawns5 );
					new_item = Lang13.Call( new_type5, this.loc );
					break;
			}
			decorations = "";

			if ( apply_material_decorations ) {
				source_material = Rand13.Pick(new object [] { "cordite", "quadrinium", "steel", "titanium", "aluminium", "ferritic-alloy", "plasteel", "duranium" });
				this.desc = "A " + ( Lang13.Bool( material_descriptor ) ? "" + material_descriptor + " " : "" ) + item_type + " made of " + source_material + ", all craftsmanship is of " + Rand13.Pick(new object [] { "the lowest", "low", "average", "high", "the highest" }) + " quality.";
				descriptors = new ByTable();

				if ( Rand13.PercentChance( 30 ) ) {
					descriptors.Add( "is encrusted with " + ( Rand13.Pick(new object [] { "", "synthetic ", "multi-faceted ", "uncut ", "sparkling " }) + Rand13.Pick(new object [] { "rubies", "emeralds", "diamonds", "opals", "lapiz lazuli" }) ) );
				}

				if ( Rand13.PercentChance( 30 ) ) {
					descriptors.Add( "is studded with " + Rand13.Pick(new object [] { "gold", "silver", "aluminium", "titanium" }) );
				}

				if ( Rand13.PercentChance( 30 ) ) {
					descriptors.Add( "is encircled with bands of " + Rand13.Pick(new object [] { "quadrinium", "cordite", "ferritic-alloy", "plasteel", "duranium" }) );
				}

				if ( Rand13.PercentChance( 30 ) ) {
					descriptors.Add( "menaces with spikes of " + Rand13.Pick(new object [] { "solid plasma", "uranium", "white pearl", "black steel" }) );
				}

				if ( descriptors.len > 0 ) {
					decorations = "It ";
					index = null;
					index = 1;

					while (( index ??0) <= descriptors.len) {
						
						if ( ( index ??0) > 1 ) {
							
							if ( index == descriptors.len ) {
								decorations += " and ";
							} else {
								decorations += ", ";
							}
						}
						decorations += descriptors[index];
						index++;
					}
					decorations += ".";
				}

				if ( Lang13.Bool( decorations ) ) {
					this.desc += " " + decorations;
				}
			}
			engravings = "";

			if ( apply_image_decorations ) {
				engravings = "" + Rand13.Pick(new object [] { "Engraved", "Carved", "Etched" }) + " on the item is " + Rand13.Pick(new object [] { "an image of", "a frieze of", "a depiction of" }) + " " + Rand13.Pick(new object [] { "an alien humanoid", "an amorphic blob", "a short, hairy being", "a rodent-like creature", "a robot", "a primate", "a reptilian alien", "an unidentifiable object", "a statue", "a starship", "unusual devices", "a structure" }) + " " + Rand13.Pick(new object [] { "surrounded by", "being held aloft by", "being struck by", "being examined by", "communicating with" }) + " " + Rand13.Pick(new object [] { "alien humanoids", "amorphic blobs", "short, hairy beings", "rodent-like creatures", "robots", "primates", "reptilian aliens" });

				if ( Rand13.PercentChance( 50 ) ) {
					engravings += ", " + Rand13.Pick(new object [] { "they seem to be enjoying themselves", "they seem extremely angry", "they look pensive", "they are making gestures of supplication", "the scene is one of subtle horror", "the scene conveys a sense of desperation", "the scene is completely bizarre" });
				}
				engravings += ".";

				if ( Lang13.Bool( this.desc ) ) {
					this.desc += " ";
				}
				this.desc += engravings;
			}

			if ( apply_prefix ) {
				this.name = "" + Rand13.Pick(new object [] { "Strange", "Ancient", "Alien", "" }) + " " + item_type;
			} else {
				this.name = item_type;
			}

			if ( Lang13.Bool( this.desc ) ) {
				this.desc += " ";
			}
			this.desc += additional_desc;

			if ( !Lang13.Bool( this.desc ) ) {
				this.desc = "This item is completely " + Rand13.Pick(new object [] { "alien", "bizarre" }) + ".";
			}

			if ( Lang13.Bool( new_item ) ) {
				new_item.name = this.name;
				new_item.desc = this.desc;

				if ( talkative && new_item is Obj_Item_Weapon ) {
					new_item.listening_to_players = true;
					new_item.heard_words = new ByTable();

					if ( Rand13.PercentChance( 25 ) ) {
						new_item.speaking_to_players = true;
						GlobalVars.processing_objects.Add( new_item );
					}
				}
				T = GlobalFuncs.get_turf( this );

				if ( T is Tile_Unsimulated_Mineral ) {
					T.last_find = new_item;
				}
				GlobalFuncs.qdel( this );
			} else if ( talkative ) {
				this.listening_to_players = true;

				if ( Rand13.PercentChance( 25 ) ) {
					
					if ( !( this.heard_words != null ) ) {
						this.heard_words = new ByTable();
					}
					this.speaking_to_players = true;
					GlobalVars.processing_objects.Add( this );
				}
			}
			return;
		}

	}

}