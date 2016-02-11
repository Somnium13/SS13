// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Card_Emag : Obj_Item_Weapon_Card {

		public dynamic energy = -1;
		public dynamic max_energy = -1;
		public dynamic recharge_ticks = 0;
		public dynamic recharge_rate = 0;
		public int nticks = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "card-id";
			this.origin_tech = "magnets=2;syndicate=2";
			this.icon_state = "emag";
		}

		// Function from file: cards_ids.dm
		public Obj_Item_Weapon_Card_Emag ( dynamic loc = null, bool? disable_tuning = null ) : base( (object)(loc) ) {
			disable_tuning = disable_tuning ?? false;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( disable_tuning == true ) {
				return;
			}

			if ( GlobalVars.config.emag_energy != -1 ) {
				this.max_energy = GlobalVars.config.emag_energy;

				if ( Lang13.Bool( GlobalVars.config.emag_starts_charged ) ) {
					this.energy = this.max_energy;
				}
			}

			if ( GlobalVars.config.emag_recharge_rate != 0 ) {
				this.recharge_rate = GlobalVars.config.emag_recharge_rate;
			}

			if ( Convert.ToDouble( GlobalVars.config.emag_recharge_ticks ) > 0 ) {
				this.recharge_ticks = GlobalVars.config.emag_recharge_ticks;
			}
			return;
		}

		// Function from file: cards_ids.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			dynamic A2 = null;

			A2 = A;

			if ( !( flag == true ) ) {
				return false;
			}
			((Ent_Static)A2).emag_act( user );
			return false;
		}

		// Function from file: cards_ids.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			return null;
		}

		// Function from file: cards_ids.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			string _class = null;

			base.examine( (object)(user), size );

			if ( this.energy == -1 ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class=\"info\">" ).The( this.name ).item().str( " has a tiny fusion generator for power.</span>" ).ToString() );
			} else {
				_class = "info";

				if ( Convert.ToDouble( this.energy / this.max_energy ) < 0.1 ) {
					_class = "warning";
				}
				GlobalFuncs.to_chat( user, "<span class=\"" + _class + "\">This " + this.name + " has " + this.energy + "MJ left in its capacitor (" + this.max_energy + "MJ capacity).</span>" );
			}

			if ( Lang13.Bool( this.recharge_rate ) && Lang13.Bool( this.recharge_ticks ) ) {
				GlobalFuncs.to_chat( user, "<span class=\"info\">A small label on a thermocouple notes that it recharges at a rate of " + this.recharge_rate + "MJ for every " + ( Convert.ToDouble( this.recharge_ticks ) <= 1 ? "" : "" + this.recharge_ticks + " " ) + "oscillator tick" + ( Convert.ToDouble( this.recharge_ticks ) > 1 ? "s" : "" ) + ".</span>" );
			}
			return null;
		}

		// Function from file: cards_ids.dm
		public bool canUse( dynamic user = null, Obj_Machinery M = null ) {
			int cost = 0;

			
			if ( Convert.ToDouble( this.energy ) < 0 ) {
				return true;
			}
			cost = M.getEmagCost( user, this );

			if ( cost == 0 ) {
				return true;
			}

			if ( Convert.ToDouble( this.energy ) >= cost ) {
				this.energy -= cost;

				if ( Convert.ToDouble( this.energy ) < Convert.ToDouble( this.max_energy ) && Lang13.Bool( this.recharge_rate ) && Lang13.Bool( this.recharge_ticks ) ) {
					
					if ( !GlobalVars.processing_objects.Contains( this ) ) {
						GlobalVars.processing_objects.Add( this );
					}
				}
				return true;
			}
			return false;
		}

		// Function from file: cards_ids.dm
		public override dynamic process(  ) {
			
			if ( this.loc != null && this.loc.timestopped ) {
				return null;
			}

			if ( Convert.ToDouble( this.energy ) < Convert.ToDouble( this.max_energy ) ) {
				
				if ( this.nticks >= Convert.ToDouble( this.recharge_ticks ) ) {
					this.nticks = 0;
					this.energy = Num13.MinInt( Convert.ToInt32( this.energy + this.recharge_rate ), Convert.ToInt32( this.max_energy ) );
				}
				this.nticks++;
			} else {
				this.nticks = 0;
				GlobalVars.processing_objects.Remove( this );
			}
			return null;
		}

	}

}