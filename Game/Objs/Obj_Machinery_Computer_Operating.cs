// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Operating : Obj_Machinery_Computer {

		public Mob_Living patient = null;
		public dynamic table = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_screen = "crew";
			this.icon_keyboard = "med_key";
			this.circuit = typeof(Obj_Item_Weapon_Circuitboard_Operating);
		}

		// Function from file: Operating.dm
		public Obj_Machinery_Computer_Operating ( dynamic location = null, dynamic C = null ) : base( (object)(location), (object)(C) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( GlobalVars.ticker != null ) {
				this.find_table();
			}
			return;
		}

		// Function from file: Operating.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			string dat = null;
			Browser popup = null;

			dat = "";

			if ( Lang13.Bool( this.table ) ) {
				dat += "<B>Patient information:</B><BR>";

				if ( ((Obj_Structure_Table_Optable)this.table).check_patient() ) {
					this.patient = this.table.patient;
					dat += this.get_patient_info();
				} else {
					this.patient = null;
					dat += "<B>No patient detected</B>";
				}
			} else {
				dat += "<B>Operating table not found.</B>";
			}
			popup = new Browser( user, "op", "Operating Computer", 400, 500 );
			popup.set_content( dat );
			popup.open();
			return null;
		}

		// Function from file: Operating.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( Lang13.Bool( base.attack_hand( (object)(a), b, c ) ) ) {
				return null;
			}
			this.interact( a );
			return null;
		}

		// Function from file: Operating.dm
		public string get_patient_info(  ) {
			string dat = null;
			Surgery procedure = null;
			dynamic surgery_step = null;

			dat = "\n				<div class='statusLabel'>Patient:</div> " + ( this.patient.stat != 0 ? "<span class='bad'>Non-Responsive</span>" : "<span class='good'>Stable</span>" ) + "<BR>\n				<div class='statusLabel'>Blood Type:</div> " + ((dynamic)this.patient).dna.blood_type + "\n\n				<BR>\n				<div class='line'><div class='statusLabel'>Health:</div><div class='progressBar'><div style='width: " + Num13.MaxInt( Convert.ToInt32( this.patient.health ), 0 ) + "%;' class='progressFill good'></div></div><div class='statusValue'>" + this.patient.health + "%</div></div>\n				<div class='line'><div class='statusLabel'>&gt; Brute Damage:</div><div class='progressBar'><div style='width: " + Num13.MaxInt( ((int)( this.patient.getBruteLoss() )), 0 ) + "%;' class='progressFill bad'></div></div><div class='statusValue'>" + this.patient.getBruteLoss() + "%</div></div>\n				<div class='line'><div class='statusLabel'>&gt; Resp. Damage:</div><div class='progressBar'><div style='width: " + Num13.MaxInt( Convert.ToInt32( this.patient.getOxyLoss() ), 0 ) + "%;' class='progressFill bad'></div></div><div class='statusValue'>" + this.patient.getOxyLoss() + "%</div></div>\n				<div class='line'><div class='statusLabel'>&gt; Toxin Content:</div><div class='progressBar'><div style='width: " + Num13.MaxInt( Convert.ToInt32( this.patient.getToxLoss() ), 0 ) + "%;' class='progressFill bad'></div></div><div class='statusValue'>" + this.patient.getToxLoss() + "%</div></div>\n				<div class='line'><div class='statusLabel'>&gt; Burn Severity:</div><div class='progressBar'><div style='width: " + Num13.MaxInt( ((int)( this.patient.getFireLoss() )), 0 ) + "%;' class='progressFill bad'></div></div><div class='statusValue'>" + this.patient.getFireLoss() + "%</div></div>\n\n				";

			if ( this.patient.surgeries.len != 0 ) {
				dat += "<BR><BR><B>Initiated Procedures</B><div class='statusDisplay'>";

				foreach (dynamic _a in Lang13.Enumerate( this.patient.surgeries, typeof(Surgery) )) {
					procedure = _a;
					
					dat += "" + GlobalFuncs.capitalize( procedure.name ) + "<BR>";
					surgery_step = procedure.get_surgery_step();
					dat += "Next step: " + GlobalFuncs.capitalize( surgery_step.name ) + "<BR>";
				}
				dat += "</div>";
			}
			return dat;
		}

		// Function from file: Operating.dm
		public void find_table(  ) {
			dynamic dir = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.cardinal )) {
				dir = _a;
				
				this.table = Lang13.FindIn( typeof(Obj_Structure_Table_Optable), Map13.GetStep( this, Convert.ToInt32( dir ) ) );

				if ( Lang13.Bool( this.table ) ) {
					this.table.computer = this;
					break;
				}
			}
			return;
		}

		// Function from file: Operating.dm
		public override void initialize(  ) {
			this.find_table();
			return;
		}

	}

}