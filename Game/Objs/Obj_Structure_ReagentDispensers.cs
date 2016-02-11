// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_ReagentDispensers : Obj_Structure {

		public dynamic amount_per_transfer_from_this = 10;
		public ByTable possible_transfer_amounts = new ByTable(new object [] { 10, 25, 50, 100 });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pressure_resistance = 202.41;
			this.icon = "icons/obj/objects.dmi";
			this.icon_state = "watertank";
		}

		// Function from file: reagent_dispenser.dm
		public Obj_Structure_ReagentDispensers ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.create_reagents( 1000 );

			if ( !( this.possible_transfer_amounts != null ) ) {
				this.verbs.Remove( typeof(Obj_Structure_ReagentDispensers).GetMethod( "set_APTFT" ) );
			}
			return;
		}

		// Function from file: reagent_dispenser.dm
		public bool is_empty(  ) {
			return ( this.reagents.total_volume ??0) <= 0;
		}

		// Function from file: reagent_dispenser.dm
		public override bool blob_act( dynamic severity = null ) {
			
			if ( Rand13.PercentChance( 50 ) ) {
				new Obj_Effect_Effect_Water( this.loc );
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: reagent_dispenser.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((int?)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					return false;
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						new Obj_Effect_Effect_Water( this.loc );
						GlobalFuncs.qdel( this );
						return false;
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 5 ) ) {
						new Obj_Effect_Effect_Water( this.loc );
						GlobalFuncs.qdel( this );
						return false;
					}
					break;
			}
			return false;
		}

		// Function from file: reagent_dispenser.dm
		public override dynamic cultify(  ) {
			new Obj_Structure_ReagentDispensers_Bloodkeg( GlobalFuncs.get_turf( this ) );
			base.cultify();
			return null;
		}

		// Function from file: reagent_dispenser.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			Reagent R = null;

			base.examine( (object)(user), size );
			GlobalFuncs.to_chat( user, "<span class='info'>It contains:</span>" );

			if ( Lang13.Bool( this.reagents ) && this.reagents.reagent_list.len != 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.reagents.reagent_list, typeof(Reagent) )) {
					R = _a;
					
					GlobalFuncs.to_chat( user, "<span class='info'>" + R.volume + " units of " + R.name + "</span>" );
				}
			} else {
				GlobalFuncs.to_chat( user, "<span class='info'>Nothing.</span>" );
			}
			return null;
		}

		// Function from file: reagent_dispenser.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return null;
		}

		// Function from file: reagent_dispenser.dm
		[Verb]
		[VerbInfo( name: "Set transfer amount", group: "Object", access: VerbAccess.InView, range: 1 )]
		public void set_APTFT(  ) {
			dynamic N = null;

			N = Interface13.Input( "Amount per transfer from this:", "" + this, null, null, this.possible_transfer_amounts, InputType.Null | InputType.Any );

			if ( Lang13.Bool( N ) ) {
				this.amount_per_transfer_from_this = N;
			}
			return;
		}

	}

}