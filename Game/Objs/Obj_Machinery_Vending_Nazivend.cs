// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Vending_Nazivend : Obj_Machinery_Vending {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.vend_reply = "SIEG HEIL!";
			this.product_ads = "BESTRAFEN die Juden.;BESTRAFEN die Alliierten.";
			this.product_slogans = "Das Vierte Reich wird zuruckkehren!;ENTFERNEN JUDEN!;Billiger als die Juden jemals geben!;Rader auf dem adminbus geht rund und rund.;Warten Sie, warum wir wieder hassen Juden?- *BZZT*";
			this.products = new ByTable()
				.Set( typeof(Obj_Item_Clothing_Head_Stalhelm), 20 )
				.Set( typeof(Obj_Item_Clothing_Head_Panzer), 20 )
				.Set( typeof(Obj_Item_Clothing_Suit_Soldiercoat), 20 )
				.Set( typeof(Obj_Item_Clothing_Under_Soldieruniform), 20 )
				.Set( typeof(Obj_Item_Clothing_Shoes_Jackboots), 20 )
			;
			this.contraband = new ByTable().Set( typeof(Obj_Item_Clothing_Head_Naziofficer), 10 ).Set( typeof(Obj_Item_Clothing_Suit_Officercoat), 10 ).Set( typeof(Obj_Item_Clothing_Under_Officeruniform), 10 );
			this.pack = typeof(Obj_Structure_Vendomatpack_Nazivend);
			this.machine_flags = 63;
			this.icon_state = "nazi";
		}

		public Obj_Machinery_Vending_Nazivend ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: vending.dm
		public override int emag( dynamic user = null ) {
			Image dangerlay = null;

			
			if ( !( this.emagged != 0 ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>As you slide the emag on the machine, you can hear something unlocking inside, and the machine starts emitting an evil glow.</span>" );
				GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( user ) + " unlocked a Nazivend's DANGERMODE" );
				this.contraband[typeof(Obj_Item_Clothing_Head_Helmet_Space_Rig_Nazi)] = 3;
				this.contraband[typeof(Obj_Item_Clothing_Suit_Space_Rig_Nazi)] = 3;
				this.contraband[typeof(Obj_Item_Weapon_Gun_Energy_Plasma_MP40k)] = 4;
				this.build_inventory( this.contraband, true );
				this.emagged = 1;
				this.overlays = 0;
				dangerlay = new Image( this.icon, "" + this.icon_state + "-dangermode", 11 );
				this.overlays_vending[2] = dangerlay;
				this.update_icon();
				return 1;
			}
			return 0;
		}

	}

}