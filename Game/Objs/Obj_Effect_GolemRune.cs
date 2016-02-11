// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_GolemRune : Obj_Effect {

		public ByTable ghosts = new ByTable( 0 );

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.unacidable = true;
			this.icon = "icons/obj/rune.dmi";
			this.icon_state = "golem";
		}

		// Function from file: slime.dm
		public Obj_Effect_GolemRune ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.processing_objects.Add( this );
			return;
		}

		// Function from file: slime.dm
		public override dynamic attack_ghost( Mob_Dead_Observer user = null ) {
			
			if ( !( user != null ) ) {
				return null;
			}
			this.volunteer( user );
			return null;
		}

		// Function from file: slime.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic O = null;

			
			if ( href_list.Contains( "signup" ) ) {
				O = Lang13.FindObj( href_list["signup"] );
				this.volunteer( O );
			}
			return null;
		}

		// Function from file: slime.dm
		public void volunteer( dynamic O = null ) {
			
			if ( this.ghosts.Contains( O ) ) {
				this.ghosts.Remove( O );
				GlobalFuncs.to_chat( O, "<span class='warning'>You are no longer signed up to be a golem.</span>" );
			} else {
				
				if ( !this.check_observer( O ) ) {
					GlobalFuncs.to_chat( O, "<span class='warning'>You are not eligable.</span>" );
					return;
				}
				this.ghosts.Add( O );
				GlobalFuncs.to_chat( O, "<span class='notice'>You are signed up to be a golem.</span>" );
			}
			return;
		}

		// Function from file: slime.dm
		public bool check_observer( dynamic O = null ) {
			
			if ( !Lang13.Bool( O ) ) {
				return false;
			}

			if ( !Lang13.Bool( O.client ) ) {
				return false;
			}

			if ( Lang13.Bool( O.mind ) && Lang13.Bool( O.mind.current ) && Convert.ToInt32( O.mind.current.stat ) != 2 ) {
				return false;
			}
			return true;
		}

		// Function from file: slime.dm
		public void announce_to_ghosts(  ) {
			Mob_Dead_Observer O = null;
			dynamic A = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Dead_Observer) )) {
				O = _a;
				

				if ( O.client != null ) {
					A = GlobalFuncs.get_area( this );

					if ( Lang13.Bool( A ) ) {
						GlobalFuncs.to_chat( O, new Txt( "<span class=\"recruit\">Golem rune created in " ).item( A.name ).str( ". (<a href='?src=" ).Ref( O ).str( ";jump=" ).Ref( this ).str( "'>Teleport</a> | <a href='?src=" ).Ref( this ).str( ";signup=" ).Ref( O ).str( "'>Sign Up</a>)</span>" ).ToString() );
					}
				}
			}
			return;
		}

		// Function from file: slime.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Mob_Dead_Observer ghost = null;
			Mob_Dead_Observer O = null;
			Mob_Living_Carbon_Human G = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Mob_Dead_Observer) )) {
				O = _a;
				

				if ( !this.check_observer( O ) ) {
					continue;
				}
				ghost = O;
				break;
			}

			if ( !( ghost != null ) ) {
				GlobalFuncs.to_chat( a, "The rune fizzles uselessly. There is no spirit nearby." );
				return null;
			}
			G = new Mob_Living_Carbon_Human();
			G.dna.mutantrace = "adamantine";
			G.real_name = "Adamantine Golem (" + Rand13.Int( 1, 1000 ) + ")";
			G.equip_to_slot_or_del( new Obj_Item_Clothing_Under_Golem( G ), 14 );
			G.equip_to_slot_or_del( new Obj_Item_Clothing_Suit_Golem( G ), 13 );
			G.equip_to_slot_or_del( new Obj_Item_Clothing_Shoes_Golem( G ), 12 );
			G.equip_to_slot_or_del( new Obj_Item_Clothing_Mask_Gas_Golem( G ), 2 );
			G.equip_to_slot_or_del( new Obj_Item_Clothing_Gloves_Golem( G ), 10 );
			G.forceMove( this.loc );
			G.key = ghost.key;
			GlobalFuncs.to_chat( G, "You are an adamantine golem. You move slowly, but are highly resistant to heat and cold as well as blunt trauma. You are unable to wear clothes, but can still use most tools. Serve " + a + ", and assist them in completing their goals at any cost." );
			GlobalFuncs.qdel( this );

			if ( GlobalVars.ticker.mode.name == "sandbox" ) {
				G.CanBuild();
				GlobalFuncs.to_chat( G, "Sandbox tab enabled." );
			}
			return null;
		}

		// Function from file: slime.dm
		public override dynamic process(  ) {
			
			if ( this.ghosts.len > 0 ) {
				this.icon_state = "golem2";
			} else {
				this.icon_state = "golem";
			}
			return null;
		}

	}

}