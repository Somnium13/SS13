// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Organ_External : Organ {

		public string icon_name = null;
		public int body_part = 0;
		public int icon_position = 0;
		public Obj_Item organ_item = null;
		public ByTable slots_to_drop = null;
		public string damage_state = "00";
		public double brute_dam = 0;
		public double burn_dam = 0;
		public double max_damage = 0;
		public bool max_size = false;
		public double last_dam = -1;
		public string display_name = null;
		public ByTable wounds = new ByTable();
		public int number_wounds = 0;
		public double perma_injury = 0;
		public bool destspawn = false;
		public bool amputated = false;
		public dynamic min_broken_damage = 30;
		public Organ_External parent = null;
		public ByTable children = null;
		public dynamic internal_organs = null;
		public string damage_msg = "<span class='warning'>You feel an intense pain</span>";
		public dynamic broken_description = null;
		public int open = 0;
		public bool stage = false;
		public bool cavity = false;
		public bool sabotaged = false;
		public string encased = null;
		public Obj_Item_Weapon hidden = null;
		public ByTable implants = new ByTable();
		public int wound_update_accuracy = 1;
		public bool has_fat = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "external";
		}

		// Function from file: organ_external.dm
		public Organ_External ( dynamic P = null ) {
			
			if ( Lang13.Bool( P ) ) {
				this.parent = P;

				if ( !( this.parent.children != null ) ) {
					this.parent.children = new ByTable();
				}
				this.parent.children.Add( this );
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: organ_external.dm
		public override Icon get_icon( string race_icon = null, bool? deform_icon = null ) {
			race_icon = race_icon ?? "";
			deform_icon = deform_icon ?? false;

			string fat = null;
			string icon_state = null;
			string baseicon = null;

			
			if ( Lang13.Bool( race_icon ) ) {
				race_icon = "_" + race_icon;
			}
			fat = "";

			if ( deform_icon == true && this.has_fat ) {
				fat = "_fat";
			}
			icon_state = "" + this.icon_name + race_icon + fat;
			baseicon = this.owner.race_icon;

			if ( ( this.status & 2048 ) != 0 ) {
				baseicon = this.owner.deform_icon;
			} else if ( this.is_peg() != 0 ) {
				baseicon = "icons/mob/human_races/o_peg.dmi";
			} else if ( this.is_robotic() != 0 ) {
				baseicon = "icons/mob/human_races/o_robot.dmi";
			}
			return new Icon( baseicon, icon_state );
		}

		// Function from file: organ_external.dm
		public override bool process(  ) {
			dynamic chemID = null;

			
			if ( this.owner.life_tick % this.wound_update_accuracy == 0 ) {
				this.update_wounds();
			}

			if ( this.owner.life_tick % 10 == 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.trace_chemicals )) {
					chemID = _a;
					
					this.trace_chemicals[chemID] = this.trace_chemicals[chemID] - 1;

					if ( Convert.ToDouble( this.trace_chemicals[chemID] ) <= 0 ) {
						this.trace_chemicals.Remove( chemID );
					}
				}
			}

			if ( ( this.status & 64 ) != 0 ) {
				
				if ( !this.destspawn && Lang13.Bool( GlobalVars.config.limbs_can_break ) ) {
					this.droplimb();
				}
				return false;
			}

			if ( this.parent != null ) {
				
				if ( ( this.parent.status & 64 ) != 0 ) {
					this.status |= 64;
					this.owner.update_body( true );
					return false;
				}
			}

			if ( Lang13.Bool( GlobalVars.config.bones_can_break ) && this.brute_dam > Convert.ToDouble( this.min_broken_damage * GlobalVars.config.organ_health_multiplier ) && !( ( this.status & 4224 ) != 0 ) ) {
				this.fracture();
			}

			if ( !this.is_broken() ) {
				this.perma_injury = 0;
			}
			this.update_germs();
			return false;
		}

		// Function from file: organ_external.dm
		public void embed( Obj_Item_Weapon W = null, bool? silent = null ) {
			silent = silent ?? false;

			Ent_Static H = null;

			
			if ( !( silent == true ) ) {
				this.owner.visible_message( new Txt( "<span class='danger'>" ).The( W ).item().str( " sticks in the wound!</span>" ).ToString() );
			}
			this.implants.Add( W );
			this.owner.embedded_flag = true;
			this.owner.verbs.Add( typeof(Mob).GetMethod( "yank_out_object" ) );
			W.add_blood( this.owner );

			if ( W.loc is Mob ) {
				H = W.loc;
				((Mob)H).drop_item( W, null, true );
			}
			W.loc = this.owner;
			return;
		}

		// Function from file: organ_external.dm
		public void process_grasp( dynamic c_hand = null, string hand_name = null ) {
			dynamic emote_scream = null;
			Effect_Effect_System_SparkSpread spark_system = null;

			
			if ( !Lang13.Bool( c_hand ) ) {
				return;
			}

			if ( this.is_broken() ) {
				this.owner.drop_item( c_hand );
				emote_scream = Rand13.Pick(new object [] { "screams in pain and", "lets out a sharp cry and", "cries out and" });
				this.owner.emote( "me", 1, "" + ( Lang13.Bool( this.owner.species ) && Lang13.Bool( this.owner.species.flags & 8 ) ? "" : emote_scream ) + " drops what they were holding in their " + hand_name + "!" );
			}

			if ( this.is_malfunctioning() ) {
				this.owner.u_equip( c_hand, true );
				this.owner.emote( "me", 1, "drops what they were holding, their " + hand_name + " malfunctioning!" );
				spark_system = new Effect_Effect_System_SparkSpread();
				spark_system.set_up( 5, 0, this.owner );
				spark_system.attach( this.owner );
				spark_system.start();
				Task13.Schedule( 10, (Task13.Closure)(() => {
					GlobalFuncs.qdel( spark_system );
					spark_system = null;
					return;
				}));

				if ( !( c_hand.loc is Tile ) || !( c_hand.loc is Obj_Structure_Closet ) ) {
					c_hand.loc = GlobalFuncs.get_turf( c_hand );
				}
			}
			return;
		}

		// Function from file: organ_external.dm
		public bool can_use_advanced_tools(  ) {
			return !( ( this.status & 7233 ) != 0 );
		}

		// Function from file: organ_external.dm
		public bool is_malfunctioning(  ) {
			return ( this.status & 128 ) != 0 && Rand13.PercentChance( ((int)( this.brute_dam + this.burn_dam )) );
		}

		// Function from file: organ_external.dm
		public bool is_broken(  ) {
			return ( this.status & 32 ) != 0 && !( ( this.status & 256 ) != 0 );
		}

		// Function from file: organ_external.dm
		public bool is_usable(  ) {
			return !( ( this.status & 3137 ) != 0 );
		}

		// Function from file: organ_external.dm
		public bool is_existing(  ) {
			return !( ( this.status & 65 ) != 0 );
		}

		// Function from file: organ_external.dm
		public bool is_organic(  ) {
			return !( ( this.status & 4224 ) != 0 );
		}

		// Function from file: organ_external.dm
		public int is_robotic(  ) {
			return this.status & 128;
		}

		// Function from file: organ_external.dm
		public int is_peg(  ) {
			return this.status & 4096;
		}

		// Function from file: organ_external.dm
		public bool has_infected_wound(  ) {
			Wound W = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.wounds, typeof(Wound) )) {
				W = _a;
				

				if ( W.germ_level > 100 ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: organ_external.dm
		public int get_damage(  ) {
			return Num13.MaxInt( ((int)( this.brute_dam + this.burn_dam - this.perma_injury )), ((int)( this.perma_injury )) );
		}

		// Function from file: organ_external.dm
		public void unmutate(  ) {
			this.status &= 63487;
			this.owner.update_body();
			return;
		}

		// Function from file: organ_external.dm
		public void mutate(  ) {
			this.status |= 2048;
			this.owner.update_body();
			return;
		}

		// Function from file: organ_external.dm
		public void fleshify(  ) {
			this.status &= 65503;
			this.status &= 65527;
			this.status &= 65279;
			this.status &= 65534;
			this.status &= 65531;
			this.status &= 65471;
			this.status &= 61439;
			this.status &= 65407;
			this.destspawn = false;
			return;
		}

		// Function from file: organ_external.dm
		public void peggify(  ) {
			Organ_External T = null;

			this.status &= 65503;
			this.status &= 65527;
			this.status &= 65534;
			this.status &= 65279;
			this.status &= 65531;
			this.status &= 65471;
			this.status &= 65407;
			this.status |= 4096;
			this.wounds.len = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.children, typeof(Organ_External) )) {
				T = _a;
				

				if ( T != null ) {
					
					if ( this.body_part == 128 || this.body_part == 256 ) {
						T.peggify();
					} else {
						T.droplimb( 1, true );
						T.status &= 65503;
						T.status &= 65527;
						T.status &= 65534;
						T.status &= 65279;
						T.status &= 65531;
						T.status &= 65471;
						T.status &= 65407;
						T.wounds.len = 0;
					}
				}
			}
			return;
		}

		// Function from file: organ_external.dm
		public void robotize(  ) {
			Organ_External T = null;

			this.status &= 65503;
			this.status &= 65527;
			this.status &= 65279;
			this.status &= 65534;
			this.status &= 65531;
			this.status &= 65471;
			this.status &= 61439;
			this.status |= 128;
			this.destspawn = false;

			foreach (dynamic _a in Lang13.Enumerate( this.children, typeof(Organ_External) )) {
				T = _a;
				

				if ( T != null ) {
					T.robotize();
				}
			}
			return;
		}

		// Function from file: organ_external.dm
		public void fracture(  ) {
			
			if ( ( this.status & 32 ) != 0 ) {
				return;
			}
			this.owner.visible_message( new Txt( "<span class='danger'>You hear a loud cracking sound coming from " ).the( this.owner ).item().str( ".</span>" ).ToString(), "<span class='danger'>Something feels like it shattered in your " + this.display_name + "!</span>", "<span class='danger'>You hear a sickening crack.</span>" );

			if ( Lang13.Bool( this.owner.species ) && !Lang13.Bool( this.owner.species.flags & 8 ) ) {
				this.owner.emote( "scream", null, null, true );
			}
			this.status |= 32;
			this.broken_description = Rand13.Pick(new object [] { "broken", "fracture", "hairline fracture" });
			this.perma_injury = this.brute_dam;

			if ( Rand13.PercentChance( 25 ) ) {
				this.release_restraints();
			}
			return;
		}

		// Function from file: organ_external.dm
		public int salve(  ) {
			int rval = 0;
			Wound W = null;

			rval = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.wounds, typeof(Wound) )) {
				W = _a;
				
				rval |= !W.salved ?1:0;
				W.salved = true;
			}
			return rval;
		}

		// Function from file: organ_external.dm
		public int clamp(  ) {
			int rval = 0;
			Wound W = null;

			rval = 0;
			this.status &= 65527;

			foreach (dynamic _a in Lang13.Enumerate( this.wounds, typeof(Wound) )) {
				W = _a;
				

				if ( W.v_internal ) {
					continue;
				}
				rval |= !W.clamped ?1:0;
				W.clamped = true;
			}
			return rval;
		}

		// Function from file: organ_external.dm
		public int disinfect(  ) {
			int rval = 0;
			Wound W = null;

			rval = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.wounds, typeof(Wound) )) {
				W = _a;
				

				if ( W.v_internal ) {
					continue;
				}
				rval |= !W.disinfected ?1:0;
				W.disinfected = true;
				W.germ_level = 0;
			}
			return rval;
		}

		// Function from file: organ_external.dm
		public int bandage(  ) {
			int rval = 0;
			Wound W = null;

			rval = 0;
			this.status &= 65527;

			foreach (dynamic _a in Lang13.Enumerate( this.wounds, typeof(Wound) )) {
				W = _a;
				

				if ( W.v_internal ) {
					continue;
				}
				rval |= !W.bandaged ?1:0;
				W.bandaged = true;
			}
			return rval;
		}

		// Function from file: organ_external.dm
		public void release_restraints(  ) {
			Interface13.Stat( null, new ByTable(new object [] { 128, 256, 512, 1024 }).Contains( Lang13.Bool( this.owner.handcuffed ) && this.body_part != 0 ) );

			if ( false ) {
				this.owner.visible_message( new Txt().The( this.owner.handcuffed.name ).item().str( " falls off of " ).item( this.owner.name ).str( "." ).ToString(), new Txt().The( this.owner.handcuffed.name ).item().str( " falls off you." ).ToString() );
				this.owner.drop_from_inventory( this.owner.handcuffed );
			}
			Interface13.Stat( null, new ByTable(new object [] { 32, 64, 8, 16 }).Contains( Lang13.Bool( this.owner.legcuffed ) && this.body_part != 0 ) );

			if ( false ) {
				this.owner.visible_message( new Txt().The( this.owner.legcuffed.name ).item().str( " falls off of " ).item( this.owner ).str( "." ).ToString(), new Txt().The( this.owner.legcuffed.name ).item().str( " falls off you." ).ToString() );
				this.owner.drop_from_inventory( this.owner.legcuffed );
			}
			return;
		}

		// Function from file: organ_external.dm
		public virtual Obj_Item generate_dropped_organ( Obj_Item current_organ = null ) {
			return current_organ;
		}

		// Function from file: organ_external.dm
		public void droplimb( int? _override = null, bool? no_explode = null, bool? spawn_limb = null ) {
			_override = _override ?? 0;
			no_explode = no_explode ?? false;
			spawn_limb = spawn_limb ?? true;

			dynamic implant = null;
			Organ_External O = null;
			Obj_Item organ = null;
			dynamic slot_id = null;
			Effect_Effect_System_SparkSpread spark_system = null;
			dynamic randomdir = null;

			
			if ( this.destspawn ) {
				return;
			}

			if ( this.body_part == 2 ) {
				return;
			}

			if ( Lang13.Bool( _override ) ) {
				this.status |= 64;
			}

			if ( ( this.status & 64 ) != 0 ) {
				this.status &= 65503;
				this.status &= 65527;
				this.status &= 65279;
				this.status &= 64511;

				foreach (dynamic _a in Lang13.Enumerate( this.implants )) {
					implant = _a;
					
					GlobalFuncs.qdel( implant );
				}

				foreach (dynamic _b in Lang13.Enumerate( this.children, typeof(Organ_External) )) {
					O = _b;
					
					O.droplimb( 1 );
				}
				organ = null;

				if ( spawn_limb == true ) {
					organ = this.generate_dropped_organ( this.organ_item );
				}

				if ( this.body_part == 4 ) {
					GlobalFuncs.to_chat( this.owner, "<span class='danger'>You are now sterile.</span>" );
				}

				if ( this.slots_to_drop != null && this.slots_to_drop.len != 0 ) {
					
					foreach (dynamic _c in Lang13.Enumerate( this.slots_to_drop )) {
						slot_id = _c;
						
						this.owner.u_equip( this.owner.get_item_by_slot( slot_id ), true );
					}
				}
				this.destspawn = true;

				if ( ( this.status & 128 ) != 0 && !( no_explode == true ) && this.sabotaged ) {
					this.owner.visible_message( new Txt( "<span class='danger'>" ).The( this.owner ).item().str( "'s " ).item( this.display_name ).str( " explodes violently!</span>" ).ToString(), "<span class='danger'>Your " + this.display_name + " explodes violently!</span>", "<span class='danger'>You hear an explosion followed by a scream!</span>" );
					GlobalFuncs.explosion( GlobalFuncs.get_turf( this.owner ), -1, -1, 2, 3 );
					spark_system = new Effect_Effect_System_SparkSpread();
					spark_system.set_up( 5, 0, this.owner );
					spark_system.attach( this.owner );
					spark_system.start();
					Task13.Schedule( 10, (Task13.Closure)(() => {
						GlobalFuncs.qdel( spark_system );
						spark_system = null;
						return;
					}));
				}

				if ( organ != null ) {
					this.owner.visible_message( "<span class='danger'>" + this.owner.name + "'s " + this.display_name + " flies off in an arc.</span>", "<span class='danger'>Your " + this.display_name + " goes flying off!</span>", "<span class='danger'>You hear a terrible sound of ripping tendons and flesh.</span>" );
					randomdir = Rand13.PickFromTable( GlobalVars.cardinal );
					Map13.Step( organ, Convert.ToInt32( randomdir ) );
				}
				this.owner.update_body( true );
				this.release_restraints();

				if ( this.vital ) {
					this.owner.death();
				}
			}
			return;
		}

		// Function from file: organ_external.dm
		public void setAmputatedTree(  ) {
			Organ_External O = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.children, typeof(Organ_External) )) {
				O = _a;
				
				O.amputated = this.amputated;
				O.setAmputatedTree();
			}
			return;
		}

		// Function from file: organ_external.dm
		public string damage_state_text(  ) {
			int tburn = 0;
			int tbrute = 0;

			
			if ( !this.is_existing() ) {
				return "--";
			}
			tburn = 0;
			tbrute = 0;

			if ( this.burn_dam == 0 ) {
				tburn = 0;
			} else if ( this.burn_dam < this.max_damage * 0.25 / 2 ) {
				tburn = 1;
			} else if ( this.burn_dam < this.max_damage * 0.75 / 2 ) {
				tburn = 2;
			} else {
				tburn = 3;
			}

			if ( this.brute_dam == 0 ) {
				tbrute = 0;
			} else if ( this.brute_dam < this.max_damage * 0.25 / 2 ) {
				tbrute = 1;
			} else if ( this.brute_dam < this.max_damage * 0.75 / 2 ) {
				tbrute = 2;
			} else {
				tbrute = 3;
			}
			return "" + tbrute + tburn;
		}

		// Function from file: organ_external.dm
		public bool update_icon(  ) {
			string n_is = null;

			n_is = this.damage_state_text();

			if ( n_is != this.damage_state ) {
				this.damage_state = n_is;
				return true;
			}
			return false;
		}

		// Function from file: organ_external.dm
		public void update_damages(  ) {
			int clamped = 0;
			Wound W = null;

			this.number_wounds = 0;
			this.brute_dam = 0;
			this.burn_dam = 0;
			this.status &= 65527;
			clamped = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.wounds, typeof(Wound) )) {
				W = _a;
				

				if ( W.damage_type == "cut" || W.damage_type == "bruise" ) {
					this.brute_dam += W.damage;
				} else if ( W.damage_type == "fire" ) {
					this.burn_dam += W.damage;
				}

				if ( this.is_organic() && W.bleeding() && !Lang13.Bool( this.owner.species.flags & 1 ) ) {
					W.bleed_timer--;
					this.status |= 8;
				}
				clamped |= W.clamped ?1:0;
				this.number_wounds += W.amount;
			}

			if ( this.open != 0 && !( clamped != 0 ) && this.is_organic() && !Lang13.Bool( this.owner.species.flags & 1 ) ) {
				this.status |= 8;
			}
			return;
		}

		// Function from file: organ_external.dm
		public void update_wounds(  ) {
			Wound W = null;
			double heal_amt = 0;

			
			if ( !this.is_organic() ) {
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.wounds, typeof(Wound) )) {
				W = _a;
				

				if ( W.damage <= 0 && W.created + 6000 <= Game13.time ) {
					this.wounds.Remove( W );
					continue;
				}

				if ( W.v_internal && !W.is_treated() && Convert.ToDouble( this.owner.bodytemperature ) >= 170 && !( Lang13.Bool( this.owner.species ) && Lang13.Bool( this.owner.species.flags & 1 ) ) ) {
					
					if ( !((Reagents)this.owner.reagents).has_reagent( "bicaridine" ) ) {
						W.open_wound( this.wound_update_accuracy * 0.1 );
						this.owner.vessel.remove_reagent( "blood", W.damage * this.wound_update_accuracy * 0.05 );
					}

					if ( !((Reagents)this.owner.reagents).has_reagent( "inaprovaline" ) ) {
						W.open_wound( this.wound_update_accuracy * 0.1 );
						this.owner.vessel.remove_reagent( "blood", W.damage * this.wound_update_accuracy * 0.05 );
					}
					this.owner.vessel.remove_reagent( "blood", W.damage * this.wound_update_accuracy * 0.11 );

					if ( Rand13.PercentChance( this.wound_update_accuracy ) ) {
						this.owner.custom_pain( "You feel a stabbing pain in your " + this.display_name + "!", true );
					}

					if ( ( ((Reagents)this.owner.reagents).get_reagent_amount( "bicaridine" ) ?1:0) >= 30 ) {
						W.damage = Num13.MaxInt( 0, ((int)( W.damage - 0.2 )) );
					}
				}
				heal_amt = 0;

				if ( W.damage < 15 ) {
					heal_amt += 0.2;
				}

				if ( W.is_treated() && W.damage < 50 ) {
					heal_amt += 0.3;
				}
				heal_amt = heal_amt * this.wound_update_accuracy;
				heal_amt = heal_amt * Convert.ToDouble( GlobalVars.config.organ_regeneration_multiplier );
				heal_amt = heal_amt / ( this.wounds.len + 1 );
				heal_amt = Num13.Round( heal_amt, 0.1 );
				W.heal_damage( heal_amt );

				if ( W.germ_level > 0 && W.salved && Rand13.PercentChance( 2 ) ) {
					W.germ_level = 0;
					W.disinfected = true;
				}
			}
			this.update_damages();

			if ( this.update_icon() ) {
				this.owner.UpdateDamageIcon();
			}
			return;
		}

		// Function from file: organ_external.dm
		public void handle_germ_effects(  ) {
			int antibiotics = 0;
			double fever_temperature = 0;
			dynamic target_organ = null;
			Organ_Internal I = null;
			ByTable candidate_organs = null;
			Organ_Internal I2 = null;
			Organ_External child = null;

			antibiotics = ((Reagents)this.owner.reagents).get_reagent_amount( "spaceacillin" ) ?1:0;

			if ( this.germ_level > 0 && this.germ_level < 100 && Rand13.PercentChance( 60 ) ) {
				this.germ_level--;
			}

			if ( this.germ_level >= 100 ) {
				fever_temperature = ( this.owner.species.heat_level_1 - this.owner.species.body_temperature - 5 ) * Num13.MinInt( ((int)( this.germ_level / 500 )), 1 ) + this.owner.species.body_temperature;
				this.owner.bodytemperature += ( ( fever_temperature - 293.41 ) / 150 + 1 <= 0 ? 0 : ( ( fever_temperature - 293.41 ) / 150 + 1 >= fever_temperature - Convert.ToDouble( this.owner.bodytemperature ) ? fever_temperature - Convert.ToDouble( this.owner.bodytemperature ) : ( fever_temperature - 293.41 ) / 150 + 1 ) );

				if ( Rand13.PercentChance( Num13.Floor( this.germ_level / 10 ) ) ) {
					
					if ( antibiotics < 5 ) {
						this.germ_level++;
					}

					if ( Rand13.PercentChance( 10 ) ) {
						this.owner.adjustToxLoss( 1 );
					}
				}
			}

			if ( this.germ_level >= 500 && antibiotics < 5 ) {
				target_organ = null;

				foreach (dynamic _a in Lang13.Enumerate( this.internal_organs, typeof(Organ_Internal) )) {
					I = _a;
					

					if ( I.germ_level > 0 && I.germ_level < Num13.MinInt( ((int)( this.germ_level )), 500 ) ) {
						
						if ( !Lang13.Bool( target_organ ) || I.germ_level > Convert.ToDouble( target_organ.germ_level ) ) {
							target_organ = I;
						}
					}
				}

				if ( !Lang13.Bool( target_organ ) ) {
					candidate_organs = new ByTable();

					foreach (dynamic _b in Lang13.Enumerate( this.internal_organs, typeof(Organ_Internal) )) {
						I2 = _b;
						

						if ( I2.germ_level < this.germ_level ) {
							candidate_organs.Add( I2 );
						}
					}

					if ( candidate_organs.len != 0 ) {
						target_organ = Rand13.PickFromTable( candidate_organs );
					}
				}

				if ( Lang13.Bool( target_organ ) ) {
					target_organ.germ_level++;
				}

				if ( this.children != null ) {
					
					foreach (dynamic _c in Lang13.Enumerate( this.children, typeof(Organ_External) )) {
						child = _c;
						

						if ( child.germ_level < this.germ_level && child.is_organic() ) {
							
							if ( child.germ_level < 200 || Rand13.PercentChance( 30 ) ) {
								child.germ_level++;
							}
						}
					}
				}

				if ( this.parent != null ) {
					
					if ( this.parent.germ_level < this.germ_level && this.parent.is_organic() ) {
						
						if ( this.parent.germ_level < 200 || Rand13.PercentChance( 30 ) ) {
							this.parent.germ_level++;
						}
					}
				}
			}

			if ( this.germ_level >= 1000 && antibiotics < 30 ) {
				
				if ( !( ( this.status & 1024 ) != 0 ) ) {
					this.status |= 1024;
					GlobalFuncs.to_chat( this.owner, "<span class='notice'>You can't feel your " + this.display_name + " anymore.</span>" );
					this.owner.update_body( true );
				}
				this.germ_level++;
				this.owner.adjustToxLoss( 1 );
			}
			return;
		}

		// Function from file: organ_external.dm
		public void handle_germ_sync(  ) {
			int antibiotics = 0;
			Wound W = null;
			Wound W2 = null;

			antibiotics = ((Reagents)this.owner.reagents).get_reagent_amount( "spaceacillin" ) ?1:0;

			foreach (dynamic _a in Lang13.Enumerate( this.wounds, typeof(Wound) )) {
				W = _a;
				

				if ( this.owner.germ_level > W.germ_level && W.infection_check() ) {
					W.germ_level++;
				}
			}

			if ( antibiotics < 5 ) {
				
				foreach (dynamic _b in Lang13.Enumerate( this.wounds, typeof(Wound) )) {
					W2 = _b;
					

					if ( W2.germ_level > this.germ_level ) {
						this.germ_level++;
						break;
					}
				}
			}
			return;
		}

		// Function from file: organ_external.dm
		public void update_germs(  ) {
			
			if ( !this.is_existing() || !this.is_organic() ) {
				this.germ_level = 0;
				return;
			}

			if ( Convert.ToDouble( this.owner.bodytemperature ) >= 170 ) {
				this.handle_germ_sync();
				this.handle_antibiotics();
				this.handle_germ_effects();
			}
			return;
		}

		// Function from file: organ_external.dm
		public bool need_process(  ) {
			
			if ( this.status != 0 && !this.is_organic() ) {
				return true;
			}

			if ( this.brute_dam != 0 || this.burn_dam != 0 ) {
				return true;
			}

			if ( this.last_dam != this.brute_dam + this.burn_dam ) {
				this.last_dam = this.brute_dam + this.burn_dam;
				return true;
			}
			this.last_dam = this.brute_dam + this.burn_dam;
			return false;
		}

		// Function from file: organ_external.dm
		public void createwound( string type = null, double? damage = null ) {
			type = type ?? "cut";

			dynamic W = null;
			dynamic W2 = null;
			int size = 0;
			dynamic size_names = null;
			dynamic wound_type = null;
			double local_damage = 0;
			bool internal_bleeding = false;
			Wound Wound = null;
			Wound_InternalBleeding I = null;
			Wound other = null;

			
			if ( !Lang13.Bool( damage ) || ( damage ??0) < 0 ) {
				return;
			}

			if ( this.wounds.len > 0 && Rand13.PercentChance( Num13.MaxInt( this.owner.number_wounds * 10 + 50, 100 ) ) ) {
				
				if ( ( type == "cut" || type == "bruise" ) && ( damage ??0) >= 5 ) {
					W = Rand13.PickFromTable( this.wounds );

					if ( Lang13.Bool( W.amount ) == true && ((Wound)W).started_healing() ) {
						((Wound)W).open_wound( damage );

						if ( Rand13.PercentChance( 25 ) ) {
							this.owner.visible_message( "<span class='warning'>The wound on " + this.owner.name + "'s " + this.display_name + " widens with a nasty ripping sound.</span>", "<span class='warning'>The wound on your " + this.display_name + " widens with a nasty ripping sound.</span>", "You hear a nasty ripping noise, as if flesh is being torn apart." );
						}
						return;
					}
				}
			}
			size = Num13.MinInt( Num13.MaxInt( 1, ((int)( ( damage ??0) / 10 )) ), 6 );
			size_names = new ByTable();

			switch ((string)( type )) {
				case "cut":
					size_names = Lang13.GetTypes( typeof(Wound_Cut) ) - typeof(Wound_Cut);
					break;
				case "bruise":
					size_names = Lang13.GetTypes( typeof(Wound_Bruise) ) - typeof(Wound_Bruise);
					break;
				case "fire":
					size_names = Lang13.GetTypes( typeof(Wound_Burn) ) - typeof(Wound_Burn);
					break;
			}
			size = Num13.MinInt( size, size_names.len );
			wound_type = size_names[size];
			W2 = Lang13.Call( wound_type, damage );
			local_damage = this.brute_dam + this.burn_dam + ( damage ??0);

			if ( ( damage ??0) > 10 && type != "fire" && local_damage > 20 && Rand13.PercentChance( ((int)( damage ??0 )) ) && this.is_organic() && !( Lang13.Bool( this.owner.species ) && Lang13.Bool( this.owner.species.flags & 1 ) ) ) {
				internal_bleeding = false;

				foreach (dynamic _b in Lang13.Enumerate( this.wounds, typeof(Wound) )) {
					Wound = _b;
					

					if ( Wound.v_internal ) {
						internal_bleeding = true;
						break;
					}
				}

				if ( !internal_bleeding ) {
					I = new Wound_InternalBleeding( 15 );
					this.wounds.Add( I );
					this.owner.custom_pain( "You feel something rip in your " + this.display_name + "!", true );
				}
			}

			foreach (dynamic _c in Lang13.Enumerate( this.wounds, typeof(Wound) )) {
				other = _c;
				

				if ( other.desc == W2.desc ) {
					other.damage += Convert.ToDouble( W2.damage );
					other.amount += 1;
					W2 = null;
					break;
				}
			}

			if ( Lang13.Bool( W2 ) ) {
				this.wounds.Add( W2 );
			}
			return;
		}

		// Function from file: organ_external.dm
		public void rejuvenate(  ) {
			Organ_Internal current_organ = null;
			Obj implanted_object = null;

			this.damage_state = "00";
			this.status = this.status & 4224;
			this.perma_injury = 0;
			this.brute_dam = 0;
			this.burn_dam = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.internal_organs, typeof(Organ_Internal) )) {
				current_organ = _a;
				
				current_organ.rejuvenate();
			}

			foreach (dynamic _b in Lang13.Enumerate( this.implants, typeof(Obj) )) {
				implanted_object = _b;
				

				if ( !( implanted_object is Obj_Item_Weapon_Implant ) ) {
					implanted_object.loc = this.owner.loc;
					this.implants.Remove( implanted_object );
				}
			}
			this.owner.updatehealth();
			return;
		}

		// Function from file: organ_external.dm
		public bool heal_damage( double brute = 0, double burn = 0, bool? _internal = null, bool? robo_repair = null ) {
			_internal = _internal ?? false;
			robo_repair = robo_repair ?? false;

			Wound W = null;
			bool result = false;

			
			if ( this.is_robotic() != 0 && !( robo_repair == true ) ) {
				return false;
			}

			if ( this.is_peg() != 0 ) {
				return false;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.wounds, typeof(Wound) )) {
				W = _a;
				

				if ( brute == 0 && burn == 0 ) {
					break;
				}

				if ( W.damage_type == "cut" || W.damage_type == "bruise" ) {
					brute = W.heal_damage( brute );
				} else if ( W.damage_type == "fire" ) {
					burn = W.heal_damage( burn );
				}
			}

			if ( _internal == true ) {
				this.status &= 65503;
				this.perma_injury = 0;
			}
			this.update_damages();
			this.owner.updatehealth();
			result = this.update_icon();
			return result;
		}

		// Function from file: organ_external.dm
		public virtual bool take_damage( double? brute = null, double? burn = null, bool? sharp = null, string edge = null, string used_weapon = null, ByTable forbidden_limbs = null ) {
			forbidden_limbs = forbidden_limbs ?? new ByTable();

			dynamic I = null;
			bool can_cut = false;
			double can_inflict = 0;
			double temp = 0;
			ByTable possible_points = null;
			dynamic target = null;
			bool result = false;

			
			if ( ( brute ??0) <= 0 && ( burn ??0) <= 0 ) {
				return false;
			}

			if ( !this.is_existing() ) {
				return false;
			}

			if ( !this.is_organic() ) {
				brute *= 0.66;
				burn *= ( ( this.status & 4096 ) != 0 ? 2 : 0.66 );
			}

			if ( this.body_part != 2 && this.body_part != 4 ) {
				
				if ( Lang13.Bool( GlobalVars.config.limbs_can_break ) && this.brute_dam >= this.max_damage * Convert.ToDouble( GlobalVars.config.organ_health_multiplier ) ) {
					
					if ( ( sharp == true || this.is_peg() != 0 ) && Rand13.PercentChance( ((int)( ( brute ??0) * 5 )) ) || ( brute ??0) > 20 && Rand13.PercentChance( ((int)( ( brute ??0) * 2 )) ) ) {
						this.droplimb( 1 );
						return false;
					}
				}
			}

			if ( this.internal_organs != null ) {
				
				if ( sharp == true && ( brute ??0) >= 5 || ( brute ??0) >= 10 ) {
					
					if ( Rand13.PercentChance( 5 ) ) {
						I = Rand13.PickFromTable( this.internal_organs );
						((Organ_Internal)I).take_damage( ( brute ??0) / 2 );
						brute -= ( brute ??0) / 2;
					}
				}
			}

			if ( this.is_broken() && Rand13.PercentChance( 40 ) && Lang13.Bool( brute ) ) {
				this.owner.emote( "scream", null, null, true );
			}

			if ( Lang13.Bool( used_weapon ) ) {
				this.add_autopsy_data( "" + used_weapon, ( brute ??0) + ( burn ??0) );
			}
			can_cut = ( Rand13.PercentChance( ((int)( ( brute ??0) * 2 )) ) || sharp == true ) && this.is_organic();

			if ( this.brute_dam + this.burn_dam + ( brute ??0) + ( burn ??0) < this.max_damage || !Lang13.Bool( GlobalVars.config.limbs_can_break ) ) {
				
				if ( Lang13.Bool( brute ) ) {
					
					if ( can_cut ) {
						this.createwound( "cut", brute );
					} else {
						this.createwound( "bruise", brute );
					}
				}

				if ( Lang13.Bool( burn ) ) {
					this.createwound( "fire", burn );
				}
			} else {
				can_inflict = this.max_damage * Convert.ToDouble( GlobalVars.config.organ_health_multiplier ) - ( this.brute_dam + this.burn_dam );

				if ( can_inflict != 0 ) {
					
					if ( ( brute ??0) > 0 ) {
						
						if ( can_cut ) {
							this.createwound( "cut", Num13.MinInt( ((int)( brute ??0 )), ((int)( can_inflict )) ) );
						} else {
							this.createwound( "bruise", Num13.MinInt( ((int)( brute ??0 )), ((int)( can_inflict )) ) );
						}
						temp = can_inflict;
						can_inflict = Num13.MaxInt( 0, ((int)( can_inflict - ( brute ??0) )) );
						brute = Num13.MaxInt( 0, ((int)( ( brute ??0) - temp )) );
					}

					if ( ( burn ??0) > 0 && can_inflict != 0 ) {
						this.createwound( "fire", Num13.MinInt( ((int)( burn ??0 )), ((int)( can_inflict )) ) );
						burn = Num13.MaxInt( 0, ((int)( ( burn ??0) - can_inflict )) );
					}
				}

				if ( Lang13.Bool( burn ) || Lang13.Bool( brute ) ) {
					
					if ( !this.is_organic() ) {
						this.droplimb( 1 );
					} else {
						possible_points = new ByTable();

						if ( this.parent != null ) {
							possible_points.Add( this.parent );
						}

						if ( this.children != null ) {
							possible_points.Add( this.children );
						}

						if ( forbidden_limbs.len != 0 ) {
							possible_points.Remove( forbidden_limbs );
						}

						if ( possible_points.len != 0 ) {
							target = Rand13.PickFromTable( possible_points );
							((Organ_External)target).take_damage( brute, burn, sharp, edge, used_weapon, forbidden_limbs + this );
						}
					}
				}
			}
			this.update_damages();
			this.owner.updatehealth();
			result = this.update_icon();
			return result;
		}

		// Function from file: organ_external.dm
		public void emp_act( int severity = 0 ) {
			int probability = 0;
			double? damage = null;

			
			if ( !( this.is_robotic() != 0 ) ) {
				return;
			}
			probability = 30;
			damage = 15;

			if ( severity == 2 ) {
				probability = 1;
				damage = 3;
			}

			if ( Rand13.PercentChance( probability ) ) {
				this.droplimb( 1 );
			} else {
				this.take_damage( damage, 0, true, null, "EMP" );
			}
			return;
		}

	}

}