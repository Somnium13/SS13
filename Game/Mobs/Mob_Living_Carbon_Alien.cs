// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_Carbon_Alien : Mob_Living_Carbon {

		public int storedPlasma = 250;
		public int max_plasma = 500;
		public dynamic wear_id = null;
		public bool has_fine_manipulation = false;
		public int move_delay_add = 0;
		public double heal_rate = 2.5;
		public int plasma_rate = 5;
		public bool oxygen_alert = false;
		public int toxins_alert = 0;
		public int fire_alert = 0;
		public double heat_protection = 0.5;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.voice_name = "alien";
			this.mob_bump_flag = 4;
			this.mob_swap_flags = 63;
			this.mob_push_flags = 55;
			this.meat_type = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Xenomeat);
			this.status_flags = 12;
			this.icon = "icons/mob/alien.dmi";
		}

		public Mob_Living_Carbon_Alien ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: say.dm
		public override bool hivecheck(  ) {
			return true;
		}

		// Function from file: say.dm
		public override bool handle_inherent_channels( Game_Data speech = null, string message_mode = null ) {
			
			if ( !base.handle_inherent_channels( speech, message_mode ) ) {
				
				if ( message_mode == "alientalk" ) {
					
					if ( this.hivecheck() ) {
						this.alien_talk( ((dynamic)speech).message );
					}
					return true;
				}
				return false;
			}
			return false;
		}

		// Function from file: say.dm
		public override bool say( dynamic message = null, string speaking = null, Ent_Dynamic radio = null ) {
			bool _default = false;

			_default = base.say( (object)(message), "A", radio );

			if ( _default ) {
				GlobalFuncs.playsound( this.loc, "hiss", 25, 1, 1 );
			}
			return _default;
		}

		// Function from file: death.dm
		public override void dust(  ) {
			this.death( true );
			this.monkeyizing = true;
			this.canmove = false;
			this.icon = null;
			this.invisibility = 101;
			this.dropBorers( true );
			GlobalFuncs.anim( null, this, "icons/mob/mob.dmi", null, "dust-a", 15 );
			new Obj_Effect_Decal_Remains_Xeno( this.loc );
			GlobalVars.dead_mob_list.Remove( this );
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: death.dm
		public override dynamic gib( bool? animation = null, bool? meat = null ) {
			this.death( true );
			this.monkeyizing = true;
			this.canmove = false;
			this.icon = null;
			this.invisibility = 101;
			GlobalFuncs.anim( null, this, "icons/mob/mob.dmi", null, "gibbed-a", 15 );
			GlobalFuncs.xgibs( this.loc, this.viruses );
			GlobalVars.dead_mob_list.Remove( this );
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: alien.dm
		public override bool has_eyes(  ) {
			return false;
		}

		// Function from file: alien.dm
		public override dynamic electrocute_act( dynamic shock_damage = null, dynamic source = null, double? base_siemens_coeff = null, bool? def_zone = null ) {
			base_siemens_coeff = base_siemens_coeff ?? 1;

			dynamic damage = null;
			Effect_Effect_System_SparkSpread SparkSpread = null;

			damage = shock_damage * base_siemens_coeff;

			if ( Convert.ToDouble( damage ) <= 0 ) {
				damage = 0;
			}

			if ( !this.take_overall_damage( 0, damage, "" + source ) ) {
				return 0;
			}
			this.visible_message( "<span class='warning'>" + this + " was shocked by the " + source + "!</span>", "<span class='danger'>You feel a powerful shock course through your body!</span>", "<span class='warning'>You hear a heavy electrical crack.</span>", "<span class='notice'>" + this + " starts raving!</span>", "<span class='notice'>You feel butterflies in your stomach!</span>", "<span class='warning'>You hear a policeman whistling!</span>" );
			this.Stun( 10 );
			this.Weaken( 10 );
			SparkSpread = new Effect_Effect_System_SparkSpread();
			SparkSpread.set_up( 5, 1, this.loc );
			SparkSpread.start();
			return damage / 2;
		}

		// Function from file: alien.dm
		public override void setDNA( dynamic newDNA = null ) {
			return;
		}

		// Function from file: alien.dm
		public override Dna getDNA(  ) {
			return null;
		}

		// Function from file: alien.dm
		public override void Stun( dynamic amount = null ) {
			
			if ( ( this.status_flags & 1 ) != 0 ) {
				this.stunned = Num13.MaxInt( Num13.MaxInt( ((int)( this.stunned )), Convert.ToInt32( amount ) ), 0 );
			} else {
				this.move_delay_add = Num13.MinInt( this.move_delay_add + Num13.Floor( Convert.ToDouble( amount / 2 ) ), 10 );
			}
			return;
		}

		// Function from file: alien.dm
		public override dynamic Stat(  ) {
			double timeleft = 0;

			
			if ( Interface13.IsStatPanelActive( "Status" ) ) {
				Interface13.Stat( null, "Intent: " + this.a_intent );
				Interface13.Stat( null, "Move Mode: " + this.m_intent );
			}
			base.Stat();

			if ( Interface13.IsStatPanelActive( "Status" ) ) {
				Interface13.Stat( null, "Plasma Stored: " + this.getPlasma() + "/" + this.max_plasma );

				if ( GlobalVars.emergency_shuttle != null ) {
					
					if ( GlobalVars.emergency_shuttle.online && GlobalVars.emergency_shuttle.location < 2 ) {
						timeleft = GlobalVars.emergency_shuttle.timeleft();

						if ( timeleft != 0 ) {
							Interface13.Stat( null, "ETA-" + timeleft / 60 % 60 + ":" + GlobalFuncs.add_zero( String13.NumberToString( timeleft % 60 ), 2 ) );
						}
					}
				}
			}
			return null;
		}

		// Function from file: alien.dm
		public override double? Process_Spaceslipping( double? prob_slip = null ) {
			return 0;
		}

		// Function from file: alien.dm
		public override dynamic IsAdvancedToolUser(  ) {
			return this.has_fine_manipulation;
		}

		// Function from file: alien.dm
		public override bool handle_fire(  ) {
			
			if ( base.handle_fire() ) {
				return false;
			}
			this.bodytemperature += 10;
			return false;
		}

		// Function from file: alien.dm
		public override void updatehealth(  ) {
			
			if ( ( this.status_flags & 4096 ) != 0 ) {
				this.health = this.maxHealth;
				this.stat = 0;
			} else {
				this.health = this.maxHealth - this.getOxyLoss() - this.getFireLoss() - this.getBruteLoss() - this.getCloneLoss();
			}
			return;
		}

		// Function from file: alien.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			Ent_Dynamic MB = null;
			Game_Data X2 = null;

			MB = O;

			if ( MB is Obj_Machinery_Bot_Mulebot ) {
				((Obj_Machinery_Bot_Mulebot)MB).RunOverCreature( this, "#00ff00" );
				X2 = GlobalFuncs.getFromPool( typeof(Obj_Effect_Decal_Cleanable_Blood_Xeno), this.loc );
				((dynamic)X2).New( this.loc );
			}
			return null;
		}

		// Function from file: alien.dm
		public override int eyecheck(  ) {
			return 2;
		}

		// Function from file: alien_powers.dm
		public bool powerc( dynamic X = null, bool? Y = null ) {
			
			if ( Lang13.Bool( this.stat ) ) {
				GlobalFuncs.to_chat( this, "<span class='alien'>You must be conscious to do this.</span>" );
				return false;
			} else if ( Lang13.Bool( X ) && this.getPlasma() < Convert.ToDouble( X ) ) {
				GlobalFuncs.to_chat( this, "<span class='alien'>Not enough plasma stored.</span>" );
				return false;
			} else if ( Y == true && ( !( this.loc is Tile ) || this.loc is Tile_Space ) ) {
				GlobalFuncs.to_chat( this, "<span class='alien'>Bad place for a garden!</span>" );
				return false;
			} else {
				return true;
			}
			return false;
		}

		// Function from file: alien.dm
		public void RemoveInfectionImages(  ) {
			Image I = null;

			
			if ( this.client != null ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.client.images, typeof(Image) )) {
					I = _a;
					

					if ( GlobalFuncs.dd_hasprefix_case( I.icon_state, "infected" ) != 0 ) {
						this.client.images.Remove( I );
					}
				}
			}
			return;
		}

		// Function from file: alien.dm
		public void AddInfectionImages(  ) {
			Mob_Living C = null;
			dynamic A = null;
			Image I = null;

			
			if ( this.client != null ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.mob_list, typeof(Mob_Living) )) {
					C = _a;
					

					if ( ( C.status_flags & 32768 ) != 0 ) {
						A = Lang13.FindIn( typeof(Obj_Item_AlienEmbryo), C );
						I = new Image( "icons/mob/alien.dmi", C, "infected" + A.stage );
						this.client.images.Add( I );
					}
				}
			}
			return;
		}

		// Function from file: alien.dm
		public void handle_mutations_and_radiation(  ) {
			
			if ( this.getFireLoss() != 0 ) {
				
				if ( this.mutations.Contains( 106 ) || Rand13.PercentChance( 5 ) ) {
					this.adjustFireLoss( -1 );
				}
			}

			if ( this.radiation != 0 ) {
				
				if ( this.radiation > 100 ) {
					this.radiation = 100;
				}

				if ( this.radiation < 0 ) {
					this.radiation = 0;
				}

				dynamic _a = this.radiation; // Was a switch-case, sorry for the mess.
				if ( 1<=_a&&_a<=49 ) {
					this.radiation--;

					if ( Rand13.PercentChance( 25 ) ) {
						this.adjustToxLoss( 1 );
					}
				} else if ( 50<=_a&&_a<=74 ) {
					this.radiation -= 2;
					this.adjustToxLoss( 1 );

					if ( Rand13.PercentChance( 5 ) ) {
						this.radiation -= 5;
					}
				} else if ( 75<=_a&&_a<=100 ) {
					this.radiation -= 3;
					this.adjustToxLoss( 3 );
				}
			}
			return;
		}

		// Function from file: alien.dm
		public virtual void handle_environment( GasMixture environment = null ) {
			dynamic loc_temp = null;
			Ent_Static M = null;
			dynamic heat_turf = null;
			double thermal_protection = 0;

			
			if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Effect_Alien_Weeds), this.loc ) ) ) {
				
				if ( Convert.ToDouble( this.health ) < Convert.ToDouble( this.maxHealth - this.getCloneLoss() ) ) {
					this.adjustBruteLoss( -this.heal_rate );
					this.adjustFireLoss( -this.heal_rate );
					this.adjustOxyLoss( -this.heal_rate );
				}
				this.adjustToxLoss( this.plasma_rate );
			}

			if ( !( environment != null ) || Lang13.Bool( this.flags & 128 ) ) {
				return;
			}
			loc_temp = 273.41;

			if ( this.loc is Obj_Mecha ) {
				M = this.loc;
				loc_temp = ((dynamic)M).return_temperature();
			} else if ( GlobalFuncs.get_turf( this ) is Tile_Space ) {
				heat_turf = GlobalFuncs.get_turf( this );
				loc_temp = heat_turf.temperature;
			} else if ( this.loc is Obj_Machinery_Atmospherics_Unary_CryoCell ) {
				loc_temp = ((dynamic)this.loc).air_contents.temperature;
			} else {
				loc_temp = environment.temperature;
			}

			if ( !this.on_fire ) {
				
				if ( Convert.ToDouble( loc_temp ) > Convert.ToDouble( this.bodytemperature ) ) {
					thermal_protection = this.heat_protection;

					if ( thermal_protection < 1 ) {
						this.bodytemperature += ( 1 - thermal_protection ) * Convert.ToDouble( ( loc_temp - this.bodytemperature ) / 80 );
					}
				} else {
					this.bodytemperature += ( loc_temp - this.bodytemperature ) / 80;
				}
			}

			if ( Convert.ToDouble( this.bodytemperature ) > 360.41 ) {
				this.fire_alert = Num13.MaxInt( this.fire_alert, 1 );

				dynamic _a = this.bodytemperature; // Was a switch-case, sorry for the mess.
				if ( 360<=_a&&_a<=400 ) {
					this.apply_damage( 2, "fire" );
					this.fire_alert = Num13.MaxInt( this.fire_alert, 2 );
				} else if ( 400<=_a&&_a<=460 ) {
					this.apply_damage( 4, "fire" );
					this.fire_alert = Num13.MaxInt( this.fire_alert, 2 );
				} else if ( 460<=_a&&_a<=Double.PositiveInfinity ) {
					
					if ( this.on_fire ) {
						this.apply_damage( 8, "fire" );
						this.fire_alert = Num13.MaxInt( this.fire_alert, 2 );
					} else {
						this.apply_damage( 4, "fire" );
						this.fire_alert = Num13.MaxInt( this.fire_alert, 2 );
					}
				}
			}
			return;
		}

		// Function from file: alien.dm
		public int getPlasma(  ) {
			return this.storedPlasma;
		}

		// Function from file: alien.dm
		public void updatePlasmaHUD(  ) {
			
			if ( this.hud_used != null ) {
				
				if ( !( this.hud_used.vampire_blood_display != null ) ) {
					this.hud_used.plasma_hud();
				}
				((dynamic)this.hud_used.vampire_blood_display).maptext_width = 64;
				((dynamic)this.hud_used.vampire_blood_display).maptext_height = 32;
				((dynamic)this.hud_used.vampire_blood_display).maptext = "<div align='left' valign='top' style='position:relative; top:0px; left:6px'> P:<font color='#E9DAE9' size='1'>" + this.storedPlasma + "</font><br>  / <font color='#BE7DBE' size='1'>" + this.max_plasma + "</font></div>";
			}
			return;
		}

		// Function from file: alien.dm
		public override bool adjustToxLoss( dynamic amount = null ) {
			this.storedPlasma = Num13.MinInt( Num13.MaxInt( ((int)( this.storedPlasma + Convert.ToDouble( amount ) )), 0 ), this.max_plasma );
			this.updatePlasmaHUD();
			return false;
		}

		// Function from file: handle_hypothermia.dm
		public override int undergoing_hypothermia(  ) {
			return 0;
		}

		// Function from file: mind.dm
		public override void mind_initialize(  ) {
			base.mind_initialize();
			this.mind.assigned_role = "Alien";
			return;
		}

		// Function from file: ventcrawl.dm
		public override bool ventcrawl_carry(  ) {
			return true;
		}

		// Function from file: ventcrawl.dm
		public override bool can_ventcrawl(  ) {
			return true;
		}

		// Function from file: other_mobs.dm
		public override void RestrainedClickOn( Ent_Static A = null ) {
			return;
		}

		// Function from file: other_mobs.dm
		public override void UnarmedAttack( Ent_Static A = null, bool proximity_flag = false, string _params = null ) {
			
			if ( A is Mob ) {
				this.delayNextAttack( 10 );
			}
			A.attack_alien( this );
			return;
		}

		// Function from file: powers.dm
		[Verb]
		[VerbInfo( name: "Crawl Through Vent (Alien)", desc: "Enter an air vent and crawl through the pipe system.", group: "Alien" )]
		public void ventcrawl(  ) {
			dynamic pipe = null;

			pipe = this.start_ventcrawl();

			if ( Lang13.Bool( pipe ) ) {
				this.handle_ventcrawl( pipe );
			}
			return;
		}

	}

}