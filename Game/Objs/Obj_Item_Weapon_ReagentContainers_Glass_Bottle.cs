// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Glass_Bottle : Obj_Item_Weapon_ReagentContainers_Glass {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "atoxinbottle";
			this.possible_transfer_amounts = new ByTable(new object [] { 5, 10, 15, 25, 30 });
			this.starting_materials = new ByTable().Set( "$glass", 1000 );
			this.melt_temperature = 1773.1500244140625;
			this.origin_tech = "materials=1";
			this.icon_state = "bottle";
		}

		// Function from file: bottle.dm
		public Obj_Item_Weapon_ReagentContainers_Glass_Bottle ( dynamic loc = null, dynamic altvol = null ) : base( (object)(loc) ) {
			altvol = altvol ?? 30;

			this.volume = altvol;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: bottle.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			Image filling = null;
			int percent = 0;
			Image lid = null;

			this.overlays.len = 0;

			if ( Lang13.Bool( this.reagents.total_volume ) ) {
				filling = new Image( "icons/obj/reagentfillings.dmi", this, "" + this.icon_state + "5" );
				percent = Num13.Floor( ( this.reagents.total_volume ??0) / Convert.ToDouble( this.volume ) * 100 );

				dynamic _a = percent; // Was a switch-case, sorry for the mess.
				if ( 0<=_a&&_a<=24 ) {
					filling.icon_state = "" + this.icon_state + "5";
				} else if ( 25<=_a&&_a<=41 ) {
					filling.icon_state = "" + this.icon_state + "10";
				} else if ( 42<=_a&&_a<=58 ) {
					filling.icon_state = "" + this.icon_state + "15";
				} else if ( 59<=_a&&_a<=74 ) {
					filling.icon_state = "" + this.icon_state + "20";
				} else if ( 75<=_a&&_a<=91 ) {
					filling.icon_state = "" + this.icon_state + "25";
				} else if ( 92<=_a&&_a<=Double.PositiveInfinity ) {
					filling.icon_state = "" + this.icon_state + "30";
				}
				filling.icon += GlobalFuncs.mix_color_from_reagents( this.reagents.reagent_list );
				this.overlays.Add( filling );
			}

			if ( !Lang13.Bool( this.is_open_container() ) ) {
				lid = new Image( this.icon, this, "lid_" + Lang13.Initial( this, "icon_state" ) );
				this.overlays.Add( lid );
			}
			return null;
		}

		// Function from file: bottle.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			base.attack_hand( (object)(a), (object)(b), (object)(c) );
			this.update_icon();
			return null;
		}

		// Function from file: bottle.dm
		public override dynamic dropped( dynamic user = null ) {
			base.dropped( (object)(user) );
			this.update_icon();
			return null;
		}

		// Function from file: bottle.dm
		public override bool pickup( Mob user = null ) {
			base.pickup( user );
			this.update_icon();
			return false;
		}

		// Function from file: bottle.dm
		public override void on_reagent_change(  ) {
			this.update_icon();
			return;
		}

		// Function from file: bottle.dm
		public override dynamic mop_act( Obj_Item_Weapon_Mop M = null, dynamic user = null ) {
			
			if ( Lang13.Bool( base.mop_act( M, (object)(user) ) ) ) {
				
				if ( ( this.reagents.total_volume ??0) >= 1 ) {
					
					if ( ( M.reagents.total_volume ??0) >= 1 ) {
						GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>You dip " ).the( M ).item().str( "'s tip into " ).the( this ).item().str( " but don't soak anything up.</span>" ).ToString() );
						return 1;
					} else {
						((Reagents)this.reagents).trans_to( M, 1 );
						GlobalFuncs.to_chat( user, "<span class='notice'>You barely manage to wet " + M + "</span>" );
						GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/slosh.ogg", 25, 1 );
					}
				} else {
					GlobalFuncs.to_chat( user, "<span class='notice'>Nothing left to wet " + M + " with!</span>" );
				}
				return 1;
			}
			return null;
		}

	}

}