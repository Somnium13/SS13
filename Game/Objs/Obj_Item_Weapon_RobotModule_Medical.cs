// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_RobotModule_Medical : Obj_Item_Weapon_RobotModule {

		// Function from file: robot_modules.dm
		public Obj_Item_Weapon_RobotModule_Medical ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.modules.Add( new Obj_Item_Device_Healthanalyzer( this ) );
			this.modules.Add( new Obj_Item_Weapon_ReagentContainers_Borghypo( this ) );
			this.modules.Add( new Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Large( this ) );
			this.modules.Add( new Obj_Item_Weapon_ReagentContainers_Dropper( this ) );
			this.modules.Add( new Obj_Item_Weapon_ReagentContainers_Syringe( this ) );
			this.modules.Add( new Obj_Item_Weapon_SurgicalDrapes( this ) );
			this.modules.Add( new Obj_Item_Weapon_Retractor( this ) );
			this.modules.Add( new Obj_Item_Weapon_Hemostat( this ) );
			this.modules.Add( new Obj_Item_Weapon_Cautery( this ) );
			this.modules.Add( new Obj_Item_Weapon_Surgicaldrill( this ) );
			this.modules.Add( new Obj_Item_Weapon_Scalpel( this ) );
			this.modules.Add( new Obj_Item_Weapon_CircularSaw( this ) );
			this.modules.Add( new Obj_Item_Weapon_Extinguisher_Mini( this ) );
			this.modules.Add( new Obj_Item_Roller_Robo( this ) );
			this.add_module( new Obj_Item_Stack_Medical_Gauze_Cyborg() );
			this.emag = new Obj_Item_Weapon_ReagentContainers_Spray( this );
			this.emag.reagents.add_reagent( "facid", 250 );
			this.emag.name = "Fluacid spray";
			this.fix_modules();
			return;
		}

		// Function from file: robot_modules.dm
		public override void respawn_consumable( dynamic R = null, double? coeff = null ) {
			coeff = coeff ?? 1;

			base.respawn_consumable( (object)(R), coeff );

			if ( Lang13.Bool( R.emagged ) && this.emag is Obj_Item_Weapon_ReagentContainers_Spray ) {
				this.emag.reagents.add_reagent( "facid", ( coeff ??0) * 2 );
			}
			return;
		}

	}

}