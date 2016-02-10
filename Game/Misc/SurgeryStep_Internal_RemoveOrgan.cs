// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SurgeryStep_Internal_RemoveOrgan : SurgeryStep_Internal {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.allowed_tools = new ByTable().Set( typeof(Obj_Item_Weapon_Hemostat), 100 ).Set( typeof(Obj_Item_Weapon_Wirecutters), 75 ).Set( typeof(Obj_Item_Weapon_Kitchen_Utensil_Fork), 20 );
			this.min_duration = 60;
			this.max_duration = 80;
		}

		// Function from file: organs_internal.dm
		public override bool? fail_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			Organ_External affected = null;

			affected = ((Mob_Living_Carbon_Human)target).get_organ( target_zone );
			((Ent_Static)user).visible_message( new Txt( "<span class='warning'>" ).item( user ).str( "'s hand slips, damaging the flesh in " ).item( target ).str( "'s " ).item( affected.display_name ).str( " with " ).the( tool ).item().str( "!</span>" ).ToString(), new Txt( "<span class='warning'>Your hand slips, damaging the flesh in " ).item( target ).str( "'s " ).item( affected.display_name ).str( " with " ).the( tool ).item().str( "!</span>" ).ToString() );
			affected.createwound( "bruise", 20 );
			return null;
		}

		// Function from file: organs_internal.dm
		public override bool end_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			dynamic affected = null;
			dynamic I = null;
			dynamic O = null;
			dynamic organ_blood = null;

			((Ent_Static)user).visible_message( new Txt( "<span class='notice'>" ).item( user ).str( " has removed " ).item( target ).str( "'s " ).item( target.op_stage.current_organ ).str( " with " ).the( tool ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You have removed " ).item( target ).str( "'s " ).item( target.op_stage.current_organ ).str( " with " ).the( tool ).item().str( ".</span>" ).ToString() );

			if ( Lang13.Bool( target.op_stage.current_organ ) ) {
				affected = ((Mob_Living_Carbon_Human)target).get_organ( target_zone );
				I = target.internal_organs_by_name[target.op_stage.current_organ];

				if ( Lang13.Bool( I ) && I is Organ_Internal ) {
					O = I.remove( user );

					if ( Lang13.Bool( O ) && O is Obj_Item_Organ ) {
						O.organ_data.rejecting = null;
						organ_blood = O.reagents.reagent_list["blood"];

						if ( !Lang13.Bool( organ_blood ) || !Lang13.Bool( organ_blood.data["blood_DNA"] ) ) {
							target.vessel.trans_to( O, 5, 1, true );
						}
						target.internal_organs_by_name[target.op_stage.current_organ] = null;
						target.internal_organs_by_name.Remove( target.op_stage.current_organ );
						target.internal_organs -= O.organ_data;
						affected.internal_organs -= O.organ_data;
						O.removed( target, user );
					}
				}
				target.op_stage.current_organ = null;
			}
			return false;
		}

		// Function from file: organs_internal.dm
		public override bool begin_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			((Ent_Static)user).visible_message( new Txt().item( user ).str( " starts removing " ).item( target ).str( "'s " ).item( target.op_stage.current_organ ).str( " with " ).the( tool ).item().str( "." ).ToString(), new Txt( "You start removing " ).item( target ).str( "'s " ).item( target.op_stage.current_organ ).str( " with " ).the( tool ).item().str( "." ).ToString() );
			((Mob_Living_Carbon_Human)target).custom_pain( "Someone's ripping out your " + target.op_stage.current_organ + "!", true );
			base.begin_step( (object)(user), (object)(target), target_zone, tool, (object)(surgery) );
			return false;
		}

		// Function from file: organs_internal.dm
		public override int can_use( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null ) {
			ByTable removable_organs = null;
			dynamic organ = null;
			Organ_Internal I = null;
			dynamic organ_to_remove = null;

			
			if ( !( base.can_use( (object)(user), (object)(target), target_zone, tool ) != 0 ) ) {
				return 0;
			}
			target.op_stage.current_organ = null;
			removable_organs = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( target.internal_organs_by_name )) {
				organ = _a;
				
				I = target.internal_organs_by_name[organ];

				if ( ( I.status & 1 ) != 0 && I.parent_organ == target_zone ) {
					removable_organs.Or( organ );
				}
			}
			organ_to_remove = Interface13.Input( user, "Which organ do you want to remove?", null, null, removable_organs, InputType.Null | InputType.Any );

			if ( !Lang13.Bool( organ_to_remove ) ) {
				return 0;
			}
			target.op_stage.current_organ = organ_to_remove;
			return base.can_use( (object)(user), (object)(target), target_zone, tool );
		}

	}

}