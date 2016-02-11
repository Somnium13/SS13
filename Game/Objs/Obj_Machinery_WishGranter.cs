// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_WishGranter : Obj_Machinery {

		public int charges = 1;
		public int insisting = 0;
		public ByTable wish_whispers = new ByTable(new object [] { 
											"I want the station to disappear.", 
											"Humanity is corrupt, mankind must be destroyed.", 
											"I want to be rich.", 
											"I want to rule the world.", 
											"I want to uncover the truth.", 
											"I want immortality.", 
											"I want to become a god.", 
											"I want my valids."
										 });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.use_power = 0;
			this.anchored = 1;
			this.icon = "icons/obj/device.dmi";
			this.icon_state = "syndbeacon";
		}

		public Obj_Machinery_WishGranter ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: wishgranter.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Objective_Silence silence = null;
			int obj_count = 0;
			Objective OBJ = null;

			Task13.User.set_machine( this );

			if ( this.charges <= 0 ) {
				GlobalFuncs.to_chat( a, new Txt( "<span class='notice'>" ).the( this ).item().str( " lies silent.</span>" ).ToString() );
				return null;
			} else if ( !( a is Mob_Living_Carbon_Human ) ) {
				GlobalFuncs.to_chat( a, new Txt( "<span class='sinister'>You feel a dark stirring inside of " ).the( this ).item().str( ", something you want nothing of! Your instincts are better than any man's.</span>" ).ToString() );
				return null;
			} else if ( GlobalFuncs.is_special_character( a ) != 0 ) {
				GlobalFuncs.to_chat( a, new Txt( "<span class='sinister'>Even to a heart as dark as yours, you know nothing good will come out of messing with " ).the( this ).item().str( "! Something instinctual pulls you away.</span>" ).ToString() );
			} else if ( !( this.insisting != 0 ) ) {
				((Ent_Static)a).visible_message( "<span class='sinister'>" + a + " touches " + this + " delicately, causing it to stir.</span>", "<span class='sinister'>Your first touch makes " + this + " stir, listening to you. Are you still sure about this ?</span>" );
				this.insisting++;
			} else {
				new ByTable()
					.Set( 1, Rand13.PickFromTable( this.wish_whispers ) )
					.Set( "heard", new Txt( "kneels before " ).the( this ).item().str( " and mumbles sinisterly," ).ToString() )
					.Set( "unheard", new Txt( "kneels before " ).the( this ).item().str( " and mumbles something sinisterly." ).ToString() )
					.Set( "allow_lastwords", 0 )
				.Apply( a.__CallVerb("Whisper" );
				Task13.Schedule( 10, (Task13.Closure)(() => {
					GlobalFuncs.message_admins( new Txt().item( a ).str( " has interacted with " ).the( this ).item().str( " (Wish Granter) and is now its powerful avatar!" ).ToString() );
					((Ent_Static)a).visible_message( new Txt( "<span class='sinister'>" ).item( a ).str( " clenches in pain before " ).the( this ).item().str( " and then raises back up with a demonic and soulless expression!</span>" ).ToString(), new Txt( "<span class='sinister'>" ).the( this ).item().str( " answers and your head pounds for a moment before your vision clears. You are the avatar of " ).item( this ).str( ", and your power is LIMITLESS! And it's all yours. You need to make sure no one can take it from you! No one must know, first!</span>" ).ToString(), "<span class='sinister'>You hear a demonic hum, this can't be good!</span>" );
					this.charges--;
					this.insisting = 0;

					if ( !Lang13.Bool( a.mutations.Contains( 4 ) ) ) {
						((Dna)a.dna).SetSEState( GlobalVars.HULKBLOCK, true );
					}

					if ( !Lang13.Bool( a.mutations.Contains( 9 ) ) ) {
						a.mutations.Add( 9 );
					}

					if ( !Lang13.Bool( a.mutations.Contains( 3 ) ) ) {
						a.mutations.Add( 3 );
						a.sight |= 28;
						a.see_in_dark = 8;
						a.see_invisible = 45;
					}

					if ( !Lang13.Bool( a.mutations.Contains( 2 ) ) ) {
						a.mutations.Add( 2 );
					}

					if ( !Lang13.Bool( a.mutations.Contains( 106 ) ) ) {
						a.mutations.Add( 106 );
					}

					if ( !Lang13.Bool( a.mutations.Contains( 1 ) ) ) {
						a.mutations.Add( 1 );
					}
					((Mob)a).update_mutations();
					GlobalVars.ticker.mode.traitors.Add( a.mind );
					a.mind.special_role = new Txt( "Avatar of " ).the( this ).item().ToString();
					silence = new Objective_Silence();
					silence.owner = a.mind;
					a.mind.objectives += silence;
					obj_count = 1;

					foreach (dynamic _a in Lang13.Enumerate( a.mind.objectives, typeof(Objective) )) {
						OBJ = _a;
						
						GlobalFuncs.to_chat( a, "<B>Objective #" + obj_count + "</B>: " + OBJ.explanation_text );
						obj_count++;
					}
					GlobalFuncs.to_chat( a, "<span class='sinister'>You have a very bad feeling about this!</span>" );
					return;
				}));
			}
			return null;
		}

	}

}