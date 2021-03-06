// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Shoes : Obj_Item_Clothing {

		public bool? chained = false;
		public string blood_state = "no blood whatsoever";
		public ByTable bloody_shoes = new ByTable().Set( "blood", 0 ).Set( "xeno", 0 ).Set( "oil", 0 ).Set( "no blood whatsoever", 0 );
		public bool can_hold_items = false;
		public dynamic held_item = null;
		public ByTable valid_held_items = new ByTable(new object [] { typeof(Obj_Item_Weapon_Kitchen_Knife), typeof(Obj_Item_Weapon_Pen), typeof(Obj_Item_Weapon_Switchblade) });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.body_parts_covered = 96;
			this.slot_flags = 128;
			this.permeability_coefficient = 0.5;
			this.icon = "icons/obj/clothing/shoes.dmi";
		}

		public Obj_Item_Clothing_Shoes ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: miscellaneous.dm
		public override int suicide_act( Mob_Living_Carbon_Human user = null ) {
			int? i = null;

			user.visible_message( "<span class='suicide'>" + user + " is bashing their own head in with " + this + "! Ain't that a kick in the head?</span>" );
			i = null;
			i = 0;

			while (( i ??0) < 3) {
				Task13.Sleep( 3 );
				GlobalFuncs.playsound( user, "sound/weapons/genhit2.ogg", 50, 1 );
				i++;
			}
			return 1;
		}

		// Function from file: miscellaneous.dm
		public virtual void step_action(  ) {
			return;
		}

		// Function from file: clothing.dm
		public override bool AltClick( Mob user = null ) {
			
			if ( user.incapacitated() || !Lang13.Bool( this.held_item ) || !this.can_hold_items ) {
				return false;
			}

			if ( !user.put_in_hands( this.held_item ) ) {
				user.WriteMsg( "<span class='notice'>You fumble for " + this.held_item + " and it falls on the floor.</span>" );
				return true;
				this.held_item = null;
			}
			user.visible_message( "<span class='warning'>" + user + " draws " + this.held_item + " from their shoes!</span>", "<span class='notice'>You draw " + this.held_item + " from " + this + ".</span>" );
			this.held_item = null;
			return false;
		}

		// Function from file: clothing.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( !this.can_hold_items ) {
				return null;
			}

			if ( Lang13.Bool( this.held_item ) ) {
				user.WriteMsg( "<span class='notice'>There's already something in " + this + ".</span>" );
				return null;
			}

			if ( GlobalFuncs.is_type_in_list( A, this.valid_held_items ) ) {
				
				if ( Convert.ToDouble( A.w_class ) > 2 ) {
					user.WriteMsg( "<span class='notice'>" + A + " is currently too big to fit into " + this + ". </span>" );
					return null;
				}

				if ( !Lang13.Bool( user.drop_item() ) ) {
					return null;
				}
				A.loc = this;
				this.held_item = A;
				user.WriteMsg( "<span class='notice'>You discreetly slip " + A + " into " + this + ". Alt-click " + this + " to remove it.</span>" );
			}
			return null;
		}

		// Function from file: clothing.dm
		public override bool clean_blood(  ) {
			Ent_Static M = null;

			base.clean_blood();
			this.bloody_shoes = new ByTable().Set( "blood", 0 ).Set( "xeno", 0 ).Set( "oil", 0 ).Set( "no blood whatsoever", 0 );
			this.blood_state = "no blood whatsoever";

			if ( this.loc is Mob ) {
				M = this.loc;
				((dynamic)M).update_inv_shoes();
			}
			return false;
		}

		// Function from file: clothing.dm
		public override ByTable worn_overlays( int? isinhands = null ) {
			isinhands = isinhands ?? GlobalVars.FALSE;

			ByTable _default = null;

			bool bloody = false;

			_default = new ByTable();

			if ( !Lang13.Bool( isinhands ) ) {
				bloody = false;

				if ( this.blood_DNA != null ) {
					bloody = true;
				} else {
					bloody = Lang13.Bool( this.bloody_shoes["blood"] );
				}

				if ( bloody ) {
					_default.Add( new Image( "icons/effects/blood.dmi", null, "shoeblood" ) );
				}
			}
			return _default;
		}

	}

}