// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Artifact : Obj_Machinery {

		public int icon_num = 0;
		public dynamic my_effect = null;
		public dynamic secondary_effect = null;
		public bool being_used = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/xenoarchaeology.dmi";
			this.icon_state = "ano00";
		}

		// Function from file: artifact_unknown.dm
		public Obj_Machinery_Artifact ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic effecttype = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			effecttype = Rand13.PickFromTable( Lang13.GetTypes( typeof(ArtifactEffect) ) - typeof(ArtifactEffect) );
			this.my_effect = Lang13.Call( effecttype, this );

			if ( Rand13.PercentChance( 75 ) ) {
				effecttype = Rand13.PickFromTable( Lang13.GetTypes( typeof(ArtifactEffect) ) - typeof(ArtifactEffect) );
				this.secondary_effect = Lang13.Call( effecttype, this );

				if ( Rand13.PercentChance( 75 ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			}
			this.icon_num = Rand13.Int( 0, 11 );
			this.icon_state = "ano" + this.icon_num + "0";

			if ( this.icon_num == 7 || this.icon_num == 8 ) {
				this.name = "large crystal";
				this.desc = Rand13.Pick(new object [] { "It shines faintly as it catches the light.", "It appears to have a faint inner glow.", "It seems to draw you inward as you look it at.", "Something twinkles faintly as you look at it.", "It's mesmerizing to behold." });

				if ( Rand13.PercentChance( 50 ) ) {
					this.my_effect.trigger = 6;
				}
			} else if ( this.icon_num == 9 ) {
				this.name = "alien computer";
				this.desc = "It is covered in strange markings.";

				if ( Rand13.PercentChance( 75 ) ) {
					this.my_effect.trigger = 0;
				}
			} else if ( this.icon_num == 10 ) {
				this.desc = "A large alien device, there appear to be some kind of vents in the side.";

				if ( Rand13.PercentChance( 50 ) ) {
					this.my_effect.trigger = Rand13.Int( 6, 12 );
				}
			} else if ( this.icon_num == 11 ) {
				this.name = "sealed alien pod";
				this.desc = "A strange alien device.";

				if ( Rand13.PercentChance( 25 ) ) {
					this.my_effect.trigger = Rand13.Int( 1, 4 );
				}
			}
			return;
		}

		// Function from file: artifact_unknown.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			base.Move( (object)(NewLoc), Dir, step_x, step_y );

			if ( Lang13.Bool( this.my_effect ) ) {
				((ArtifactEffect)this.my_effect).UpdateMove();
			}

			if ( Lang13.Bool( this.secondary_effect ) ) {
				((ArtifactEffect)this.secondary_effect).UpdateMove();
			}
			return false;
		}

		// Function from file: artifact_unknown.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((int?)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.qdel( this );
					} else {
						
						if ( this.my_effect.trigger == 5 || this.my_effect.trigger == 7 ) {
							((ArtifactEffect)this.my_effect).ToggleActivate();
						}

						if ( Lang13.Bool( this.secondary_effect ) && ( this.secondary_effect.trigger == 5 || this.secondary_effect.trigger == 7 ) && Rand13.PercentChance( 25 ) ) {
							((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
						}
					}
					break;
				case 3:
					
					if ( this.my_effect.trigger == 5 || this.my_effect.trigger == 7 ) {
						((ArtifactEffect)this.my_effect).ToggleActivate();
					}

					if ( Lang13.Bool( this.secondary_effect ) && ( this.secondary_effect.trigger == 5 || this.secondary_effect.trigger == 7 ) && Rand13.PercentChance( 25 ) ) {
						((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
					}
					break;
			}
			return false;
		}

		// Function from file: artifact_unknown.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			
			if ( Proj is Obj_Item_Projectile_Bullet || Proj is Obj_Item_Projectile_Hivebotbullet ) {
				
				if ( this.my_effect.trigger == 5 ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 5 && Rand13.PercentChance( 25 ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			} else if ( Proj is Obj_Item_Projectile_Beam || Proj is Obj_Item_Projectile_Ion || Proj is Obj_Item_Projectile_Energy ) {
				
				if ( this.my_effect.trigger == 6 ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 6 && Rand13.PercentChance( 25 ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			}
			return null;
		}

		// Function from file: artifact_unknown.dm
		public override bool Bumped( Ent_Static AM = null, dynamic yes = null ) {
			bool warn = false;

			base.Bumped( AM, (object)(yes) );

			if ( AM is Obj ) {
				
				if ( Convert.ToDouble( ((dynamic)AM).throwforce ) >= 10 ) {
					
					if ( this.my_effect.trigger == 5 ) {
						((ArtifactEffect)this.my_effect).ToggleActivate();
					}

					if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 5 && Rand13.PercentChance( 25 ) ) {
						((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
					}
				}
			} else if ( AM is Mob_Living_Carbon_Human && !( ((dynamic)AM).gloves is Obj_Item_Clothing_Gloves ) ) {
				warn = false;

				if ( this.my_effect.trigger == 0 && Rand13.PercentChance( 50 ) ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
					warn = true;
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 0 && Rand13.PercentChance( 25 ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
					warn = true;
				}

				if ( Lang13.Bool( this.my_effect.effect ) == false && Rand13.PercentChance( 50 ) ) {
					((ArtifactEffect)this.my_effect).DoEffectTouch( AM );
					warn = true;
				}

				if ( Lang13.Bool( this.secondary_effect ) && Lang13.Bool( this.secondary_effect.effect ) == false && Lang13.Bool( this.secondary_effect.activated ) && Rand13.PercentChance( 50 ) ) {
					((ArtifactEffect)this.secondary_effect).DoEffectTouch( AM );
					warn = true;
				}

				if ( warn ) {
					GlobalFuncs.to_chat( AM, "<b>You accidentally touch " + this + ".<b>" );
				}
			}
			base.Bumped( AM, (object)(yes) );
			return false;
		}

		// Function from file: artifact_unknown.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_ReagentContainers_Glass && Lang13.Bool( ((Ent_Static)a).is_open_container() ) || a is Obj_Item_Weapon_ReagentContainers_Dropper ) {
				
				if ( ((Reagents)a.reagents).has_reagent( "hydrogen", 1 ) || ((Reagents)a.reagents).has_reagent( "water", 1 ) ) {
					
					if ( this.my_effect.trigger == 1 ) {
						((ArtifactEffect)this.my_effect).ToggleActivate();
					}

					if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 1 && Rand13.PercentChance( 25 ) ) {
						((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
					}
				} else if ( ((Reagents)a.reagents).has_reagent( "sacid", 1 ) || ((Reagents)a.reagents).has_reagent( "pacid", 1 ) || ((Reagents)a.reagents).has_reagent( "diethylamine", 1 ) ) {
					
					if ( this.my_effect.trigger == 2 ) {
						((ArtifactEffect)this.my_effect).ToggleActivate();
					}

					if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 2 && Rand13.PercentChance( 25 ) ) {
						((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
					}
				} else if ( ((Reagents)a.reagents).has_reagent( "plasma", 1 ) || ((Reagents)a.reagents).has_reagent( "thermite", 1 ) ) {
					
					if ( this.my_effect.trigger == 3 ) {
						((ArtifactEffect)this.my_effect).ToggleActivate();
					}

					if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 3 && Rand13.PercentChance( 25 ) ) {
						((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
					}
				} else if ( ((Reagents)a.reagents).has_reagent( "toxin", 1 ) || ((Reagents)a.reagents).has_reagent( "cyanide", 1 ) || ((Reagents)a.reagents).has_reagent( "amatoxin", 1 ) || ((Reagents)a.reagents).has_reagent( "neurotoxin", 1 ) ) {
					
					if ( this.my_effect.trigger == 4 ) {
						((ArtifactEffect)this.my_effect).ToggleActivate();
					}

					if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 4 && Rand13.PercentChance( 25 ) ) {
						((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
					}
				}
			} else if ( a is Obj_Item_Weapon_Melee_Baton && Lang13.Bool( a.status ) || a is Obj_Item_Weapon_Melee_Energy || a is Obj_Item_Weapon_Melee_Cultblade || a is Obj_Item_Weapon_Card_Emag || a is Obj_Item_Device_Multitool ) {
				
				if ( this.my_effect.trigger == 6 ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 6 && Rand13.PercentChance( 25 ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			} else if ( a is Obj_Item_Weapon_Match && Lang13.Bool( a.lit ) || a is Obj_Item_Weapon_Weldingtool && a.welding || a is Obj_Item_Weapon_Lighter && Lang13.Bool( a.lit ) ) {
				
				if ( this.my_effect.trigger == 7 ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 7 && Rand13.PercentChance( 25 ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			} else {
				base.attackby( (object)(a), (object)(b), (object)(c) );

				if ( this.my_effect.trigger == 5 && Convert.ToDouble( a.force ) >= 10 ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 5 && Rand13.PercentChance( 25 ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			}
			return null;
		}

		// Function from file: artifact_unknown.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Mob_Dead_Observer ) {
				GlobalFuncs.to_chat( a, "<span class='rose'>Your ghostly hand goes right through!</span>" );
				return null;
			}

			if ( Map13.GetDistance( a, this ) > 1 ) {
				GlobalFuncs.to_chat( a, "<span class='warning'>You can't reach " + this + " from here.</span>" );
				return null;
			}

			if ( a is Mob_Living_Carbon_Human && Lang13.Bool( a.gloves ) ) {
				GlobalFuncs.to_chat( a, "<b>You touch " + this + "</b> with your gloved hands, " + Rand13.Pick(new object [] { "but nothing of note happens", "but nothing happens", "but nothing interesting happens", "but you notice nothing different", "but nothing seems to have happened" }) + "." );
				return null;
			}
			this.add_fingerprint( a );

			if ( this.my_effect.trigger == 0 ) {
				GlobalFuncs.to_chat( a, "<b>You touch " + this + ".<b>" );
				((ArtifactEffect)this.my_effect).ToggleActivate();
			} else {
				GlobalFuncs.to_chat( a, "<b>You touch " + this + ",</b> " + Rand13.Pick(new object [] { "but nothing of note happens", "but nothing happens", "but nothing interesting happens", "but you notice nothing different", "but nothing seems to have happened" }) + "." );
			}

			if ( Rand13.PercentChance( 25 ) && Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 0 ) {
				((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
			}

			if ( Lang13.Bool( this.my_effect.effect ) == false ) {
				((ArtifactEffect)this.my_effect).DoEffectTouch( a );
			}

			if ( Lang13.Bool( this.secondary_effect ) && Lang13.Bool( this.secondary_effect.effect ) == false && Lang13.Bool( this.secondary_effect.activated ) ) {
				((ArtifactEffect)this.secondary_effect).DoEffectTouch( a );
			}
			return null;
		}

		// Function from file: artifact_unknown.dm
		public override dynamic process(  ) {
			Ent_Static L = null;
			bool trigger_cold = false;
			bool trigger_hot = false;
			bool trigger_plasma = false;
			bool trigger_oxy = false;
			bool trigger_co2 = false;
			bool trigger_nitro = false;
			dynamic T = null;
			GasMixture env = null;

			L = this.loc;

			if ( L == null || !( L is Tile ) ) {
				return null;
			}

			if ( Lang13.Bool( this.my_effect ) ) {
				this.my_effect.process();
			}

			if ( Lang13.Bool( this.secondary_effect ) ) {
				this.secondary_effect.process();
			}

			if ( this.pulledby != null ) {
				
				if ( !this.Adjacent( this.pulledby ) ) {
					
					if ( this.pulledby.pulling == this ) {
						this.pulledby.__CallVerb("Stop Pulling" );
					}
					this.pulledby = null;
				} else if ( Lang13.Bool( this.pulledby.stat ) || this.pulledby.sleeping != 0 || this.pulledby.lying == true || this.pulledby.weakened != 0 || this.pulledby.stunned != 0 ) {
					
					if ( this.pulledby.pulling == this ) {
						this.pulledby.__CallVerb("Stop Pulling" );
					}
					this.pulledby = null;
				} else {
					this.Bumped( this.pulledby );
				}
			}
			trigger_cold = false;
			trigger_hot = false;
			trigger_plasma = false;
			trigger_oxy = false;
			trigger_co2 = false;
			trigger_nitro = false;

			if ( this.my_effect.trigger >= 7 && this.my_effect.trigger <= 12 || this.my_effect.trigger >= 7 && this.my_effect.trigger <= 12 ) {
				T = GlobalFuncs.get_turf( this );
				env = ((Ent_Static)T).return_air();

				if ( env != null ) {
					
					if ( ( env.temperature ??0) < 225 ) {
						trigger_cold = true;
					} else if ( ( env.temperature ??0) > 375 ) {
						trigger_hot = true;
					}

					if ( Convert.ToDouble( env.toxins ) >= 10 ) {
						trigger_plasma = true;
					}

					if ( Convert.ToDouble( env.oxygen ) >= 10 ) {
						trigger_oxy = true;
					}

					if ( Convert.ToDouble( env.carbon_dioxide ) >= 10 ) {
						trigger_co2 = true;
					}

					if ( Convert.ToDouble( env.nitrogen ) >= 10 ) {
						trigger_nitro = true;
					}
				}
			}

			if ( trigger_cold ) {
				
				if ( this.my_effect.trigger == 8 && !Lang13.Bool( this.my_effect.activated ) ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 8 && !Lang13.Bool( this.secondary_effect.activated ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			} else {
				
				if ( this.my_effect.trigger == 8 && Lang13.Bool( this.my_effect.activated ) ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 8 && !Lang13.Bool( this.secondary_effect.activated ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			}

			if ( trigger_hot ) {
				
				if ( this.my_effect.trigger == 7 && !Lang13.Bool( this.my_effect.activated ) ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 7 && !Lang13.Bool( this.secondary_effect.activated ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			} else {
				
				if ( this.my_effect.trigger == 7 && Lang13.Bool( this.my_effect.activated ) ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 7 && !Lang13.Bool( this.secondary_effect.activated ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			}

			if ( trigger_plasma ) {
				
				if ( this.my_effect.trigger == 9 && !Lang13.Bool( this.my_effect.activated ) ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 9 && !Lang13.Bool( this.secondary_effect.activated ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			} else {
				
				if ( this.my_effect.trigger == 9 && Lang13.Bool( this.my_effect.activated ) ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 9 && !Lang13.Bool( this.secondary_effect.activated ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			}

			if ( trigger_oxy ) {
				
				if ( this.my_effect.trigger == 10 && !Lang13.Bool( this.my_effect.activated ) ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 10 && !Lang13.Bool( this.secondary_effect.activated ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			} else {
				
				if ( this.my_effect.trigger == 10 && Lang13.Bool( this.my_effect.activated ) ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 10 && !Lang13.Bool( this.secondary_effect.activated ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			}

			if ( trigger_co2 ) {
				
				if ( this.my_effect.trigger == 11 && !Lang13.Bool( this.my_effect.activated ) ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 11 && !Lang13.Bool( this.secondary_effect.activated ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			} else {
				
				if ( this.my_effect.trigger == 11 && Lang13.Bool( this.my_effect.activated ) ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 11 && !Lang13.Bool( this.secondary_effect.activated ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			}

			if ( trigger_nitro ) {
				
				if ( this.my_effect.trigger == 12 && !Lang13.Bool( this.my_effect.activated ) ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 12 && !Lang13.Bool( this.secondary_effect.activated ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			} else {
				
				if ( this.my_effect.trigger == 12 && Lang13.Bool( this.my_effect.activated ) ) {
					((ArtifactEffect)this.my_effect).ToggleActivate();
				}

				if ( Lang13.Bool( this.secondary_effect ) && this.secondary_effect.trigger == 12 && !Lang13.Bool( this.secondary_effect.activated ) ) {
					((ArtifactEffect)this.secondary_effect).ToggleActivate( false );
				}
			}
			return null;
		}

	}

}