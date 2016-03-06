// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Processor : Obj_Machinery {

		public bool broken = false;
		public bool processing = false;
		public dynamic rating_speed = 1;
		public dynamic rating_amount = 1;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 5;
			this.active_power_usage = 50;
			this.icon = "icons/obj/kitchen.dmi";
			this.icon_state = "processor";
			this.layer = 2.9;
		}

		// Function from file: processor.dm
		public Obj_Machinery_Processor ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable();
			this.component_parts.Add( new Obj_Item_Weapon_Circuitboard_Processor( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_MatterBin( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_Manipulator( null ) );
			this.RefreshParts();
			return;
		}

		// Function from file: processor.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			double total_time = 0;
			dynamic O = null;
			dynamic P = null;
			int offset = 0;
			dynamic O2 = null;
			dynamic P2 = null;

			
			if ( this.stat != 0 ) {
				return null;
			}

			if ( this.processing ) {
				a.WriteMsg( "<span class='warning'>The processor is in the process of processing!</span>" );
				return 1;
			}

			if ( this.contents.len == 0 ) {
				a.WriteMsg( "<span class='warning'>The processor is empty!</span>" );
				return 1;
			}
			this.processing = true;
			((Ent_Static)a).visible_message( "" + a + " turns on " + this + ".", "<span class='notice'>You turn on " + this + ".</span>", "<span class='italics'>You hear a food processor.</span>" );
			GlobalFuncs.playsound( this.loc, "sound/machines/blender.ogg", 50, 1 );
			this.f_use_power( 500 );
			total_time = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.contents )) {
				O = _a;
				
				P = this.select_recipe( O );

				if ( !Lang13.Bool( P ) ) {
					GlobalFuncs.log_admin( "DEBUG: " + O + " in processor havent suitable recipe. How do you put it in?" );
					continue;
				}
				total_time += Convert.ToDouble( P.time );
			}
			offset = ( Rand13.PercentChance( 50 ) ? -2 : 2 );
			Icon13.Animate( new ByTable().Set( 1, this ).Set( "pixel_x", this.pixel_x + offset ).Set( "time", 0.2 ).Set( "loop", total_time / Convert.ToDouble( this.rating_speed ) * 5 ) );
			Task13.Sleep( ((int)( total_time / Convert.ToDouble( this.rating_speed ) )) );

			foreach (dynamic _b in Lang13.Enumerate( this.contents )) {
				O2 = _b;
				
				P2 = this.select_recipe( O2 );

				if ( !Lang13.Bool( P2 ) ) {
					GlobalFuncs.log_admin( "DEBUG: " + O2 + " in processor havent suitable recipe. How do you put it in?" );
					continue;
				}
				((FoodProcessorProcess)P2).process_food( this.loc, O2, this );
			}
			this.pixel_x = Convert.ToInt32( Lang13.Initial( this, "pixel_x" ) );
			this.processing = false;
			this.visible_message( new Txt().the( this ).item().str( " finishes processing." ).ToString() );
			return null;
		}

		// Function from file: processor.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic what = null;
			dynamic G = null;
			dynamic P = null;

			
			if ( this.processing ) {
				user.WriteMsg( "<span class='warning'>The processor is in the process of processing!</span>" );
				return 1;
			}

			if ( this.default_deconstruction_screwdriver( user, "processor1", "processor", A ) ) {
				return null;
			}

			if ( this.exchange_parts( user, A ) ) {
				return null;
			}

			if ( this.default_pry_open( A ) ) {
				return null;
			}

			if ( this.default_unfasten_wrench( user, A ) ) {
				return null;
			}
			this.default_deconstruction_crowbar( A );
			what = A;

			if ( A is Obj_Item_Weapon_Grab ) {
				G = A;

				if ( !((Ent_Static)user).Adjacent( G.affecting ) ) {
					return null;
				}

				if ( G.affecting.buckled != null || Lang13.Bool( G.affecting.buckled_mob ) ) {
					user.WriteMsg( "<span class='warning'>" + G.affecting + " is attached to somthing!</span>" );
					return null;
				}
				what = G.affecting;
			}
			P = this.select_recipe( what );

			if ( !Lang13.Bool( P ) ) {
				user.WriteMsg( "<span class='warning'>That probably won't blend!</span>" );
				return 1;
			}
			((Ent_Static)user).visible_message( "" + user + " put " + what + " into " + this + ".", "You put the " + what + " into " + this + "." );
			user.drop_item();
			what.loc = this;
			return null;
		}

		// Function from file: processor.dm
		public void empty(  ) {
			Obj O = null;
			dynamic M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj) )) {
				O = _a;
				
				O.loc = this.loc;
			}

			foreach (dynamic _b in Lang13.Enumerate( this )) {
				M = _b;
				
				M.loc = this.loc;
			}
			return;
		}

		// Function from file: processor.dm
		public dynamic select_recipe( dynamic X = null ) {
			dynamic Type = null;
			dynamic P = null;

			
			foreach (dynamic _a in Lang13.Enumerate( Lang13.GetTypes( typeof(FoodProcessorProcess) ) - typeof(FoodProcessorProcess) - typeof(FoodProcessorProcess_Mob) )) {
				Type = _a;
				
				P = Lang13.Call( Type );

				if ( !Lang13.Bool( ((dynamic)P.input).IsInstanceOfType( X ) ) ) {
					continue;
				}
				return P;
			}
			return 0;
		}

		// Function from file: processor.dm
		public override void RefreshParts(  ) {
			Obj_Item_Weapon_StockParts_MatterBin B = null;
			Obj_Item_Weapon_StockParts_Manipulator M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_MatterBin) )) {
				B = _a;
				
				this.rating_amount = B.rating;
			}

			foreach (dynamic _b in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_Manipulator) )) {
				M = _b;
				
				this.rating_speed = M.rating;
			}
			return;
		}

		// Function from file: processor.dm
		[Verb]
		[VerbInfo( name: "Eject Contents", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public void eject(  ) {
			
			if ( Task13.User.stat != 0 || !Task13.User.canmove || Task13.User.restrained() ) {
				return;
			}
			this.empty();
			this.add_fingerprint( Task13.User );
			return;
		}

	}

}