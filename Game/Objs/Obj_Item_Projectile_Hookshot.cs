// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Hookshot : Obj_Item_Projectile {

		public int? length = 1;
		public Ent_Static last_link = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 0;
			this.nodamage = true;
			this.kill_count = 15;
			this.icon = "icons/obj/projectiles_experimental.dmi";
			this.icon_state = "hookshot";
		}

		public Obj_Item_Projectile_Hookshot ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: hookshot.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			return false;
		}

		// Function from file: hookshot.dm
		public override double singularity_act( double? current_size = null, Obj_Machinery_Singularity S = null ) {
			return 0;
		}

		// Function from file: hookshot.dm
		public override dynamic cultify(  ) {
			return null;
		}

		// Function from file: hookshot.dm
		public override dynamic Bump( Obj Obstacle = null, dynamic yes = null ) {
			Obj_Item_Weapon_Gun_Hookshot hookshot = null;
			Obj AM = null;
			Chain chain_datum = null;
			int? max_chains = null;
			int? i = null;
			Ent_Static HC = null;
			Obj_Effect_Overlay_Chain C = null;
			int? i2 = null;
			Obj_Effect_Overlay_Chain C2 = null;
			Obj L = null;

			
			if ( this.bumped ) {
				return 0;
			}
			this.bumped = true;
			hookshot = this.shot_from;
			Task13.Schedule( 0, (Task13.Closure)(() => {
				
				if ( Obstacle is Tile ) {
					hookshot.clockwerk_chain( this.length );
				} else if ( Obstacle is Ent_Dynamic ) {
					AM = Obstacle;

					if ( Lang13.Bool( AM.anchored ) ) {
						hookshot.clockwerk_chain( this.length );
					} else if ( !( AM.tether != null ) && !( this.firer.tether != null ) && !( AM is Obj_Effect ) ) {
						
						if ( ( this.length ??0) <= 2 ) {
							AM.CtrlClick( this.firer );
							hookshot.cancel_chain();
							this.bullet_die();
							return;
						}
						chain_datum = new Chain();
						hookshot.chain_datum = chain_datum;
						chain_datum.hookshot = hookshot;
						chain_datum.extremity_A = this.firer;
						chain_datum.extremity_B = AM;
						max_chains = ( this.length ??0) - 1;
						i = null;
						i = 1;

						while (( i ??0) < ( max_chains ??0)) {
							HC = hookshot.links["" + i];

							if ( !( HC.loc != null ) || HC.loc == hookshot ) {
								max_chains = i;
								break;
							}
							C = new Obj_Effect_Overlay_Chain( HC.loc );
							C.chain_datum = chain_datum;
							chain_datum.links["" + i] = C;
							i++;
						}
						i2 = null;
						i2 = 1;

						while (( i2 ??0) < ( max_chains ??0)) {
							C2 = chain_datum.links["" + i2];

							if ( i2 == 1 ) {
								this.firer.tether = C2;
								C2.extremity_A = this.firer;

								if ( ( max_chains ??0) <= 2 ) {
									C2.extremity_B = AM;
									C2.update_overlays();
								} else {
									C2.extremity_B = chain_datum.links["" + ( ( i2 ??0) + 1 )];
								}
							} else if ( i2 == ( max_chains ??0) - 1 ) {
								C2.extremity_A = chain_datum.links["" + ( ( i2 ??0) - 1 )];
								C2.extremity_B = AM;
								AM.tether = C2;
								C2.update_overlays();
							} else {
								C2.extremity_A = chain_datum.links["" + ( ( i2 ??0) - 1 )];
								C2.extremity_B = chain_datum.links["" + ( ( i2 ??0) + 1 )];
							}
							i2++;
						}

						if ( this.firer is Mob && AM is Mob_Living ) {
							L = AM;
							GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<font color='red'>" + GlobalFuncs.key_name( this.firer ) + " hooked " + GlobalFuncs.key_name( L ) + " with a " + this.type + "</font>" ) ) );
							((dynamic)L).attack_log += "[" + GlobalFuncs.time_stamp() + "] <b>" + GlobalFuncs.key_name( this.firer ) + "</b> hooked <b>" + GlobalFuncs.key_name( L ) + "</b> with a <b>" + this.type + "</b>";
							this.firer.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <b>" + GlobalFuncs.key_name( this.firer ) + "</b> hooked <b>" + GlobalFuncs.key_name( L ) + "</b> with a <b>" + this.type + "</b>" );
						}
						hookshot.cancel_chain();
					} else {
						hookshot.rewind_chain();
					}
				} else {
					hookshot.rewind_chain();
				}
				return;
			}));
			this.bullet_die();
			return null;
		}

		// Function from file: hookshot.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			Obj_Item_Weapon_Gun_Hookshot hookshot = null;

			hookshot = this.shot_from;

			if ( hookshot != null ) {
				
				if ( !hookshot.clockwerk && !hookshot.rewinding ) {
					hookshot.rewind_chain();
				}
				hookshot.hook = null;
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: hookshot.dm
		public override void bullet_die(  ) {
			dynamic hookshot = null;

			hookshot = this.shot_from;
			hookshot.hook = null;
			Task13.Schedule( 0, (Task13.Closure)(() => {
				this.OnDeath();
				GlobalFuncs.returnToPool( this );
				return;
			}));
			return;
		}

		// Function from file: hookshot.dm
		public override void process_step(  ) {
			dynamic sleeptime = null;
			Obj_Item_Weapon_Gun_Hookshot hookshot = null;
			Obj_Item_Weapon_Gun_Hookshot hookshot2 = null;
			Ent_Static HC = null;
			Icon I = null;
			Icon J = null;
			Icon I2 = null;

			sleeptime = 1;

			if ( this.loc != null ) {
				
				if ( ( this.kill_count ??0) < 1 ) {
					hookshot = this.shot_from;

					if ( this.z != Convert.ToInt32( this.firer.z ) ) {
						hookshot.cancel_chain();
						this.bullet_die();
					}
					Task13.Schedule( 0, (Task13.Closure)(() => {
						hookshot.rewind_chain();
						return;
					}));
					this.bullet_die();
				}

				if ( this.dist_x > this.dist_y ) {
					sleeptime = this.bresenham_step( this.dist_x, this.dist_y, this.dx, this.dy );
				} else {
					sleeptime = this.bresenham_step( this.dist_y, this.dist_x, this.dy, this.dx );
				}

				if ( this.linear_movement ) {
					this.update_pixel();
					this.pixel_x = this.PixelX;
					this.pixel_y = this.PixelY;
				}
				this.bumped = false;

				if ( Lang13.Bool( sleeptime ) ) {
					hookshot2 = this.shot_from;
					HC = hookshot2.links["" + this.length];

					if ( !( HC != null ) ) {
						this.visible_message( "With a CLANG noise, the chain mysteriously snaps and rewinds back into the hookshot." );
						hookshot2.cancel_chain();
						this.bullet_die();
					}
					HC.loc = this.loc;
					HC.pixel_x = this.pixel_x;
					HC.pixel_y = this.pixel_y;

					if ( this.last_link != null ) {
						this.last_link.icon = GlobalVars.bullet_master["hookshot_chain_angle" + this.target_angle];
					}
					this.last_link = HC;
					this.length++;

					if ( ( this.length ??0) < ( hookshot2.maxlength ??0) ) {
						
						if ( !GlobalVars.bullet_master.Contains( "hookshot_chain_angle" + this.target_angle ) ) {
							I = new Icon( "icons/obj/projectiles_experimental.dmi", "hookshot_chain" );
							I.Turn( this.target_angle + 45 );
							GlobalVars.bullet_master["hookshot_chain_angle" + this.target_angle] = I;
							J = new Icon( "icons/obj/projectiles_experimental.dmi", "hookshot_pixel" );
							J.Turn( this.target_angle + 45 );
							GlobalVars.bullet_master["hookshot_head_angle" + this.target_angle] = J;
						}
						HC.icon = GlobalVars.bullet_master["hookshot_head_angle" + this.target_angle];
					} else {
						
						if ( !GlobalVars.bullet_master.Contains( "hookshot_head_angle" + this.target_angle ) ) {
							I2 = new Icon( "icons/obj/projectiles_experimental.dmi", "hookshot_pixel" );
							I2.Turn( this.target_angle + 45 );
							GlobalVars.bullet_master["hookshot_head_angle" + this.target_angle] = I2;
						}
						HC.icon = GlobalVars.bullet_master["hookshot_head_angle" + this.target_angle];
						Task13.Schedule( 0, (Task13.Closure)(() => {
							hookshot2.rewind_chain();
							return;
						}));
						this.bullet_die();
					}
				}
				Task13.Sleep( Convert.ToInt32( sleeptime ) );
			}
			return;
		}

	}

}