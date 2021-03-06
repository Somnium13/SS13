// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Kitchenspike : Obj_Structure {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.buckle_lying = 0;
			this.can_buckle = 1;
			this.icon = "icons/obj/kitchen.dmi";
			this.icon_state = "spike";
		}

		public Obj_Structure_Kitchenspike ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: kitchen_spike.dm
		public override dynamic user_unbuckle_mob( dynamic user = null ) {
			dynamic M = null;
			Matrix m180 = null;

			
			if ( Lang13.Bool( this.buckled_mob ) && this.buckled_mob.buckled == this ) {
				M = this.buckled_mob;

				if ( M != user ) {
					((Ent_Static)M).visible_message( "" + user.name + " tries to pull " + M.name + " free of the " + this + "!", "<span class='notice'>" + user.name + " is trying to pull you off the " + this + ", opening up fresh wounds!</span>", "<span class='italics'>You hear a squishy wet noise.</span>" );

					if ( !GlobalFuncs.do_after( user, 300, null, this ) ) {
						
						if ( Lang13.Bool( M ) && M.buckled != null ) {
							((Ent_Static)M).visible_message( "" + user.name + " fails to free " + M.name + "!", "<span class='notice'>" + user.name + " fails to pull you off of the " + this + ".</span>" );
						}
						return null;
					}
				} else {
					((Ent_Static)M).visible_message( "<span class='warning'>" + M.name + " struggles to break free from the " + this + "!</span>", "<span class='notice'>You struggle to break free from the " + this + ", exacerbating your wounds! (Stay still for two minutes.)</span>", "<span class='italics'>You hear a wet squishing noise..</span>" );
					((Mob_Living)M).adjustBruteLoss( 30 );

					if ( !GlobalFuncs.do_after( M, 1200, null, this ) ) {
						
						if ( Lang13.Bool( M ) && M.buckled != null ) {
							M.WriteMsg( "<span class='warning'>You fail to free yourself!</span>" );
						}
						return null;
					}
				}

				if ( !( M.buckled != null ) ) {
					return null;
				}
				m180 = Num13.Matrix( M.transform );
				m180.Turn( 180 );
				Icon13.Animate( new ByTable().Set( 1, M ).Set( "transform", m180 ).Set( "time", 3 ) );
				M.pixel_y = ((Mob_Living)M).get_standard_pixel_y_offset( 180 );
				((Mob_Living)M).adjustBruteLoss( 30 );
				this.visible_message( "<span class='danger'>" + M + " falls free of the " + this + "!</span>" );
				this.unbuckle_mob();
				((Mob)M).emote( "scream" );
				((Mob)M).AdjustWeakened( 10 );
			}
			return null;
		}

		// Function from file: kitchen_spike.dm
		public override bool user_buckle_mob( Ent_Static M = null, Mob user = null ) {
			return false;
		}

		// Function from file: kitchen_spike.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			Obj_Structure_KitchenspikeFrame F = null;
			dynamic G = null;
			Ent_Static H = null;
			dynamic pos = null;
			Matrix m180 = null;

			
			if ( A is Obj_Item_Weapon_Crowbar ) {
				
				if ( !Lang13.Bool( this.buckled_mob ) ) {
					GlobalFuncs.playsound( this.loc, "sound/items/Crowbar.ogg", 100, 1 );

					if ( GlobalFuncs.do_after( user, 20 / A.toolspeed, null, this ) ) {
						user.WriteMsg( "<span class='notice'>You pry the spikes out of the frame.</span>" );
						new Obj_Item_Stack_Rods( this.loc, 4 );
						F = new Obj_Structure_KitchenspikeFrame( this.loc );
						this.transfer_fingerprints_to( F );
						GlobalFuncs.qdel( this );
					}
				} else {
					user.WriteMsg( "<span class='notice'>You can't do that while something's on the spike!</span>" );
				}
				return null;
			}

			if ( A is Obj_Item_Weapon_Grab ) {
				G = A;

				if ( G.affecting is Mob_Living ) {
					
					if ( !Lang13.Bool( this.buckled_mob ) ) {
						
						if ( GlobalFuncs.do_mob( user, this, 120 ) ) {
							
							if ( Lang13.Bool( this.buckled_mob ) ) {
								return null;
							}

							if ( G.affecting.buckled != null ) {
								return null;
							}
							H = G.affecting;
							GlobalFuncs.playsound( this.loc, "sound/effects/splat.ogg", 25, 1 );
							H.visible_message( "<span class='danger'>" + user + " slams " + G.affecting + " onto the meat spike!</span>", "<span class='userdanger'>" + user + " slams you onto the meat spike!</span>", "<span class='italics'>You hear a squishy wet noise.</span>" );
							H.loc = this.loc;
							((dynamic)H).emote( "scream" );

							if ( H is Mob_Living_Carbon_Human ) {
								pos = GlobalFuncs.get_turf( H );
								((Ent_Static)pos).add_blood_floor( H );
							}
							((dynamic)H).adjustBruteLoss( 30 );
							((dynamic)H).buckled = this;
							H.dir = 2;
							this.buckled_mob = H;
							m180 = Num13.Matrix( H.transform );
							m180.Turn( 180 );
							Icon13.Animate( new ByTable().Set( 1, H ).Set( "transform", m180 ).Set( "time", 3 ) );
							H.pixel_y = Convert.ToInt32( ((dynamic)H).get_standard_pixel_y_offset( 180 ) );
							GlobalFuncs.qdel( G );
							return null;
						}
					}
				}
				user.WriteMsg( "<span class='danger'>You can't use that on the spike!</span>" );
				return null;
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: kitchen_spike.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( Task13.User );
		}

	}

}