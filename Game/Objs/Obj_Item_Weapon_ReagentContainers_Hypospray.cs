// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Hypospray : Obj_Item_Weapon_ReagentContainers {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "hypo";
			this.possible_transfer_amounts = null;
			this.flags = 4352;
			this.slot_flags = 512;
			this.icon = "icons/obj/syringe.dmi";
			this.icon_state = "hypo";
		}

		// Function from file: hypospray.dm
		public Obj_Item_Weapon_ReagentContainers_Hypospray ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "doctorsdelight", 30 );
			return;
		}

		// Function from file: hypospray.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			dynamic H = null;
			string inject_message = null;
			ByTable injected = null;
			Reagent R = null;
			string contained = null;
			dynamic trans = null;

			
			if ( !Lang13.Bool( this.reagents.total_volume ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>" + this + " is empty.</span>" );
				return null;
			}

			if ( !( M is Mob ) ) {
				return null;
			}

			if ( M is Mob_Living_Carbon_Human ) {
				H = M;

				if ( Lang13.Bool( H.species ) && ( H.species.chem_flags & 8 ) != 0 ) {
					GlobalFuncs.to_chat( user, new Txt( "<span classs='notice'>" ).The( this ).item().str( "'s needle fails to pierce " ).item( H ).ToString() );
					return null;
				}
			}
			inject_message = "<span class='notice'>You inject " + M + " with " + this + ".</span>";

			if ( M == user ) {
				inject_message = "<span class='notice'>You inject yourself with " + this + ".</span>";
			} else {
				Interface13.Stat( null, user.mutations.Contains( 5 ) );

				if ( M == user && Rand13.PercentChance( 50 ) ) {
					inject_message = "<span class='notice'>Oops! You inject yourself with " + this + " by accident.</span>";
					M = user;
				}
			}

			if ( Lang13.Bool( this.reagents.total_volume ) ) {
				GlobalFuncs.to_chat( user, inject_message );
				GlobalFuncs.to_chat( M, "<span class='warning'>You feel a tiny prick!</span>" );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/hypospray.ogg", 50, 1 );
				((Reagents)this.reagents).reaction( M, GlobalVars.INGEST );

				if ( Lang13.Bool( M.reagents ) ) {
					injected = new ByTable();

					foreach (dynamic _a in Lang13.Enumerate( this.reagents.reagent_list, typeof(Reagent) )) {
						R = _a;
						
						injected.Add( R.name );
					}
					contained = GlobalFuncs.english_list( injected );
					M.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been injected with " + this.name + " by " + user.name + " (" + user.ckey + "). Reagents: " + contained + "</font>" );
					user.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Used the " + this.name + " to inject " + M.name + " (" + M.key + "). Reagents: " + contained + "</font>" );
					GlobalFuncs.msg_admin_attack( "" + user.name + " (" + user.ckey + ") injected " + M.name + " (" + M.key + ") with " + this.name + ". Reagents: " + contained + " (INTENT: " + String13.ToUpper( user.a_intent ) + ") (<A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" + user.x + ";Y=" + user.y + ";Z=" + user.z + "'>JMP</a>)" );
					GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<font color='red'>" + user.name + " (" + user.ckey + ") injected " + M.name + " (" + M.ckey + ") with " + this.name + " Reagents: " + contained + "</font>" ) ) );

					if ( !( user is Mob_Living_Carbon ) ) {
						M.LAssailant = null;
					} else {
						M.LAssailant = user;
					}
					trans = ((Reagents)this.reagents).trans_to( M, this.amount_per_transfer_from_this );
					GlobalFuncs.to_chat( user, "<span class='notice'>" + trans + " units injected. " + this.reagents.total_volume + " units remaining in " + this + ".</span>" );
				}
			}
			return null;
		}

		// Function from file: hypospray.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

	}

}