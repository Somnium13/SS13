// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Legcuffs_Bolas : Obj_Item_Weapon_Legcuffs {

		public bool dispenser = false;
		public string throw_sound = "sound/weapons/whip.ogg";
		public int trip_prob = 60;
		public Obj thrown_from = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.slot_flags = 512;
			this.throwforce = 2;
			this.w_class = 2;
			this.w_type = 4;
			this.attack_verb = new ByTable(new object [] { "lashed", "bludgeoned", "whipped" });
			this.force = 4;
			this.breakouttime = 50;
			this.throw_speed = 1;
			this.throw_range = 10;
			this.icon_state = "bolas";
		}

		public Obj_Item_Weapon_Legcuffs_Bolas ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: weapon.dm
		public override dynamic Bump( Obj Obstacle = null, dynamic yes = null ) {
			base.Bump( Obstacle );
			this.throw_failed();
			return null;
		}

		// Function from file: weapon.dm
		public virtual void throw_failed(  ) {
			
			if ( !( this.thrown_from != null ) || !( this.thrown_from is Mob_Living ) ) {
				GlobalFuncs.qdel( this );
			}
			return;
		}

		// Function from file: weapon.dm
		public override dynamic throw_impact( dynamic hit_atom = null, dynamic speed = null, Mob user = null ) {
			dynamic M = null;
			dynamic H = null;

			
			if ( hit_atom is Mob_Living && hit_atom != Task13.User ) {
				M = hit_atom;

				if ( M is Mob_Living_Carbon_Human ) {
					H = M;

					if ( H.m_intent == "run" ) {
						
						if ( Rand13.PercentChance( this.trip_prob ) ) {
							Map13.Step( H, Convert.ToInt32( H.dir ) );
							((Ent_Static)H).visible_message( "<span class='warning'>" + H + " was tripped by the bolas!</span>", "<span class='warning'>Your legs have been tangled!</span>" );
							((Mob)H).Stun( 2 );
							((Mob)H).Weaken( 4 );
							H.legcuffed = this;
							this.loc = H;
							((Mob)H).update_inv_legcuffed();

							if ( !Lang13.Bool( H.legcuffed ) ) {
								this.throw_failed();
							}
						}
					} else if ( Lang13.Bool( H.legcuffed ) ) {
						this.throw_failed();
						return null;
					} else {
						GlobalFuncs.to_chat( H, "<span class='notice'>You stumble over the thrown bolas</span>" );
						Map13.Step( H, Convert.ToInt32( H.dir ) );
						((Mob)H).Stun( 1 );
						this.throw_failed();
						return null;
					}
				} else {
					((Mob)M).Stun( 2 );
					this.throw_failed();
					return null;
				}
			}
			return null;
		}

		// Function from file: weapon.dm
		public override bool throw_at( dynamic target = null, double? range = null, dynamic speed = null, bool? _override = null ) {
			Mob H = null;
			dynamic target2 = null;
			Ent_Dynamic adjtarget = null;
			int xadjust = 0;
			int yadjust = 0;
			double scaler = 0;

			
			if ( !Lang13.Bool( range ) ) {
				return false;
			}

			if ( Task13.User != null && !( this.thrown_from is Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_MissileRack_Bolas ) ) {
				
				if ( Task13.User is Mob_Living_Carbon_Human ) {
					H = Task13.User;

					if ( H.mutations.Contains( 5 ) && Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.to_chat( H, "<span class='warning'>You smack yourself in the face while swinging the " + this + "!</span>" );
						H.Stun( 2 );
						H.drop_item( this );
						return false;
					}
				}
			}

			if ( !( this.thrown_from != null ) && Task13.User != null ) {
				this.thrown_from = Task13.User;
			}

			if ( !( this.thrown_from is Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_MissileRack_Bolas ) ) {
				GlobalFuncs.playsound( this, this.throw_sound, 20, 1 );
			}
			target2 = GlobalFuncs.get_turf( target );
			adjtarget = new Ent_Dynamic();
			xadjust = 0;
			yadjust = 0;
			scaler = 0;
			scaler = ( range ??0) / Num13.MaxInt( ((int)( Math.Abs( Convert.ToDouble( target2.x - this.x ) ) )), ((int)( Math.Abs( Convert.ToDouble( target2.y - this.y ) ) )), 1 );

			if ( Lang13.Bool( target2.x - this.x ) != false ) {
				xadjust = Num13.Floor( Convert.ToDouble( ( target2.x - this.x ) * scaler ) );
				adjtarget.x = this.x + xadjust;
			} else {
				adjtarget.x = this.x;
			}

			if ( Lang13.Bool( target2.y - this.y ) != false ) {
				yadjust = Num13.Floor( Convert.ToDouble( ( target2.y - this.y ) * scaler ) );
				adjtarget.y = this.y + yadjust;
			} else {
				adjtarget.y = this.y;
			}
			base.throw_at( (object)(GlobalFuncs.get_turf( adjtarget )), range, (object)(speed), _override );
			this.thrown_from = null;
			return false;
		}

		// Function from file: weapon.dm
		public override dynamic suicide_act( Mob_Living_Carbon_Human user = null ) {
			GlobalFuncs.to_chat( Map13.FetchViewers( null, user ), new Txt( "<span class='danger'>" ).item( user ).str( " is wrapping the " ).item( this.name ).str( " around " ).his_her_its_their().str( " neck! It looks like " ).he_she_it_they().str( "'s trying to commit suicide.</span>" ).ToString() );
			return 8;
		}

	}

}