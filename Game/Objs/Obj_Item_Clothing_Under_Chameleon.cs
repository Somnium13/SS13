// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Under_Chameleon : Obj_Item_Clothing_Under {

		public ByTable clothing_choices = new ByTable();
		public bool malfunctioning = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "bl_suit";
			this.item_color = "black";
			this.action_button_name = "Change";
			this.origin_tech = "syndicate=3";
			this.random_sensor = false;
			this.armor = new ByTable().Set( "melee", 10 ).Set( "bullet", 10 ).Set( "laser", 10 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.icon_state = "black";
		}

		// Function from file: chameleon.dm
		public Obj_Item_Clothing_Under_Chameleon ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic U = null;
			dynamic V = null;
			dynamic U2 = null;
			dynamic V2 = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.Enumerate( Lang13.GetTypes( typeof(Obj_Item_Clothing_Under_Color) ) - typeof(Obj_Item_Clothing_Under_Color) )) {
				U = _a;
				
				V = Lang13.Call( U );
				this.clothing_choices.Add( V );
			}

			foreach (dynamic _b in Lang13.Enumerate( Lang13.GetTypes( typeof(Obj_Item_Clothing_Under_Rank) ) - typeof(Obj_Item_Clothing_Under_Rank) )) {
				U2 = _b;
				
				V2 = Lang13.Call( U2 );
				this.clothing_choices.Add( V2 );
			}
			return;
		}

		// Function from file: chameleon.dm
		[VerbInfo( access: VerbAccess.InUserContents, range: 127 )]
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic A = null;

			A = Interface13.Input( "Select Colour to change it to", "BOOYEA", A, null, this.clothing_choices, InputType.Any );

			if ( !Lang13.Bool( A ) ) {
				return null;
			}

			if ( Task13.User.stat != 0 ) {
				return null;
			}

			if ( this.malfunctioning ) {
				Task13.User.WriteMsg( "<span class='danger'>Your jumpsuit is malfunctioning!</span>" );
				return null;
			}
			this.desc = null;
			this.permeability_coefficient = 081;
			this.desc = A.desc;
			this.name = A.name;
			this.icon_state = A.icon_state;
			this.item_state = A.item_state;
			this.item_color = A.item_color;
			this.suit_color = A.suit_color;
			Task13.User.update_inv_w_uniform();
			return null;
		}

		// Function from file: chameleon.dm
		public override double emp_act( int severity = 0 ) {
			Ent_Static M = null;
			Ent_Static M2 = null;

			this.name = "psychedelic";
			this.desc = "Groovy!";
			this.icon_state = "psyche";
			this.item_color = "psyche";
			this.malfunctioning = true;

			if ( this.loc is Mob ) {
				M = this.loc;
				((dynamic)M).update_inv_w_uniform();
				((dynamic)M).WriteMsg( "<span class='danger'>Your jumpsuit malfunctions!</span>" );
			}
			Task13.Schedule( 200, (Task13.Closure)(() => {
				this.name = "Black Jumpsuit";
				this.icon_state = "black";
				this.item_state = "bl_suit";
				this.item_color = "black";
				this.malfunctioning = false;

				if ( this.loc is Mob ) {
					M2 = this.loc;
					((dynamic)M2).update_inv_w_uniform();
					((dynamic)M2).WriteMsg( "<span class='notice'>Your jumpsuit is functioning normally again.</span>" );
				}
				return;
			}));
			base.emp_act( severity );
			return 0;
		}

		// Function from file: chameleon.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Clothing_Under_Chameleon ) {
				user.WriteMsg( "&lt;span class='notice'>Nothing happens.</span>" );
				return null;
			}

			if ( A is Obj_Item_Clothing_Under ) {
				
				if ( this.clothing_choices.Find( A ) != 0 ) {
					user.WriteMsg( "<span class='notice'>Pattern is already recognised by the suit.</span>" );
					return null;
				}
				this.clothing_choices.Add( A );
				user.WriteMsg( "<span class='notice'>Pattern absorbed by the suit.</span>" );
			}
			return null;
		}

	}

}