// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Gibber : Obj_Machinery {

		public bool operating = false;
		public bool dirty = false;
		public int gibtime = 40;
		public dynamic occupant = null;
		public bool opened = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 20;
			this.active_power_usage = 500;
			this.machine_flags = 30;
			this.icon = "icons/obj/kitchen.dmi";
			this.icon_state = "grinder";
		}

		// Function from file: gibber.dm
		public Obj_Machinery_Gibber ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable(new object [] { 
				new Obj_Item_Weapon_Circuitboard_Gibber(), 
				new Obj_Item_Weapon_StockParts_MatterBin(), 
				new Obj_Item_Weapon_StockParts_MatterBin(), 
				new Obj_Item_Weapon_StockParts_Capacitor(), 
				new Obj_Item_Weapon_StockParts_Capacitor(), 
				new Obj_Item_Weapon_StockParts_ScanningModule(), 
				new Obj_Item_Weapon_StockParts_ScanningModule(), 
				new Obj_Item_Weapon_StockParts_Manipulator(), 
				new Obj_Item_Weapon_StockParts_Manipulator(), 
				new Obj_Item_Weapon_StockParts_Manipulator(), 
				new Obj_Item_Weapon_StockParts_Manipulator(), 
				new Obj_Item_Weapon_StockParts_MicroLaser_High(), 
				new Obj_Item_Weapon_StockParts_MicroLaser_High(), 
				new Obj_Item_Weapon_StockParts_MicroLaser_High(), 
				new Obj_Item_Weapon_StockParts_MicroLaser_High()
			 });
			this.RefreshParts();
			return;
		}

		// Function from file: gibber.dm
		public override bool MouseDrop_T( Ent_Static O = null, dynamic user = null, bool? needs_opened = null, bool? show_message = null, bool? move_them = null ) {
			
			if ( O != user || !( user is Mob_Living_Carbon_Human ) || Lang13.Bool( user.stat ) || user.weakened != 0 || Lang13.Bool( user.stunned ) || user.paralysis != 0 || Lang13.Bool( user.locked_to ) || Map13.GetDistance( user, this ) > 1 ) {
				return false;
			}

			if ( !Lang13.Bool( this.anchored ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>" + this + " must be anchored first!</span>" );
				return false;
			}

			if ( Lang13.Bool( this.occupant ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>" + this + " is full! Empty it first.</span>" );
				return false;
			}

			if ( ((Mob)user).abiotic( true ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>Subject may not have abiotic items on.</span>" );
				return false;
			}
			this.add_fingerprint( user );
			((Ent_Static)user).visible_message( "<span class='warning'>" + user + " starts climbing into the " + this + ".</span>", "<span class='warning'>You start climbing into the " + this + ".</span>", null, "<span class='warning'>" + user + " starts dancing like a ballerina!</span>" );

			if ( GlobalFuncs.do_after( user, this, 30 ) && Lang13.Bool( user ) && !Lang13.Bool( this.occupant ) && !( this.loc == null ) ) {
				((Ent_Static)user).visible_message( "<span class='warning'>" + user + " climbs into the " + this + "</span>", "<span class='warning'>You climb into the " + this + ".</span>", null, "<span class='warning'>" + this + " consumes " + user + "!</span>" );

				if ( Lang13.Bool( user.client ) ) {
					user.client.perspective = GlobalVars.EYE_PERSPECTIVE ?1:0;
					user.client.eye = this;
				}
				user.loc = this;
				this.occupant = user;
				this.update_icon();
			}
			return false;
		}

		// Function from file: gibber.dm
		public void startautogibbing( Ent_Dynamic victim = null ) {
			dynamic sourcename = null;
			dynamic sourcejob = null;
			dynamic sourcenutriment = null;
			double? sourcetotalreagents = null;
			dynamic totalslabs = null;
			ByTable allmeat = null;
			double i = 0;
			dynamic newmeat = null;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Human human_meat = null;
			Obj_Item_Organ_Brain B = null;
			Tile Tx = null;
			Game_Data O = null;
			Game_Data O2 = null;
			double i2 = 0;
			Ent_Static meatslab = null;
			Tile Tx2 = null;
			Game_Data O3 = null;

			
			if ( this.operating ) {
				return;
			}

			if ( !( victim != null ) ) {
				this.visible_message( "<span class='warning'>You hear a loud metallic grinding sound.</span>", null, null, "<span class='warning'>You fainly hear a guitar solo.</span>" );
				return;
			}
			this.f_use_power( 1000 );
			this.visible_message( "<span class='warning'>You hear a loud squelchy grinding sound.</span>", null, null, "<span class='warning'>You hear a band performance.</span>" );
			this.operating = true;
			this.update_icon();
			sourcename = ((dynamic)victim).real_name;
			sourcejob = ((dynamic)victim).job;
			sourcenutriment = ((dynamic)victim).nutrition / 15;

			if ( Lang13.Bool( victim.reagents ) ) {
				sourcetotalreagents = victim.reagents.total_volume;
			}
			totalslabs = ((dynamic)victim).size;
			allmeat = new ByTable( totalslabs );

			foreach (dynamic _a in Lang13.IterateRange( 1, totalslabs )) {
				i = _a;
				
				newmeat = null;

				if ( victim is Mob_Living_Carbon_Human ) {
					human_meat = new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Human();
					human_meat.name = sourcename + newmeat.name;
					human_meat.subjectname = sourcename;
					human_meat.subjectjob = sourcejob;
					newmeat = human_meat;
				} else {
					newmeat = ((Mob_Living)victim).drop_meat( this );
				}

				if ( newmeat == null ) {
					return;
				}
				((Reagents)newmeat.reagents).add_reagent( "nutriment", sourcenutriment / totalslabs );

				if ( Lang13.Bool( victim.reagents ) ) {
					((Reagents)victim.reagents).trans_to( newmeat, Num13.Round( ( sourcetotalreagents ??0) / Convert.ToDouble( totalslabs ), 1 ) );
				}
				allmeat[i] = newmeat;
			}
			((dynamic)victim).attack_log += "[" + GlobalFuncs.time_stamp() + "] Was auto-gibbed by <B>" + this + "</B>";
			GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<B>" + this + "</B> auto-gibbed <B>" + GlobalFuncs.key_name( victim ) + "</B>" ) ) );
			((dynamic)victim).death( 1 );

			if ( victim is Mob_Living_Carbon_Human || victim is Mob_Living_Carbon_Monkey || victim is Mob_Living_Carbon_Alien ) {
				B = new Obj_Item_Organ_Brain( this.loc );
				B.transfer_identity( victim );
				Tx = Map13.GetTile( this.x - 2, this.y, this.z );
				B.loc = this.loc;
				B.throw_at( Tx, 2, 3 );

				if ( victim is Mob_Living_Carbon_Alien ) {
					O = GlobalFuncs.getFromPool( typeof(Obj_Effect_Decal_Cleanable_Blood_Gibs_Xeno), Tx );
					((dynamic)O).New( Tx, 2 );
				} else {
					O2 = GlobalFuncs.getFromPool( typeof(Obj_Effect_Decal_Cleanable_Blood_Gibs), Tx );
					((dynamic)O2).New( Tx, 2 );
				}
			}
			GlobalFuncs.qdel( victim );
			Task13.Schedule( this.gibtime, (Task13.Closure)(() => {
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/gib2.ogg", 50, 1 );
				this.operating = false;

				foreach (dynamic _b in Lang13.IterateRange( 1, totalslabs )) {
					i2 = _b;
					
					meatslab = allmeat[i2];
					Tx2 = Map13.GetTile( ((int)( this.x - i2 )), this.y, this.z );
					meatslab.loc = this.loc;
					((dynamic)meatslab).throw_at( Tx2, i2, 3 );

					if ( !Tx2.density ) {
						O3 = GlobalFuncs.getFromPool( typeof(Obj_Effect_Decal_Cleanable_Blood_Gibs), Tx2 );
						((dynamic)O3).New( Tx2, i2 );
					}
				}
				this.operating = false;
				this.update_icon();
				return;
			}));
			return;
		}

		// Function from file: gibber.dm
		public void startgibbing( dynamic user = null ) {
			dynamic sourcename = null;
			string sourcejob = null;
			double sourcenutriment = 0;
			double? sourcetotalreagents = null;
			int totalslabs = 0;
			ByTable allmeat = null;
			double i = 0;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Human newmeat = null;
			double i2 = 0;
			Ent_Static meatslab = null;
			Tile Tx = null;
			Game_Data O = null;

			
			if ( this.operating ) {
				return;
			}

			if ( !Lang13.Bool( this.occupant ) ) {
				this.visible_message( "<span class='warning'>You hear a loud metallic grinding sound.</span>", null, null, "<span class='warning'>You fainly hear a guitar solo.</span>" );
				return;
			}
			this.f_use_power( 1000 );
			this.visible_message( "<span class='warning'>You hear a loud squelchy grinding sound.</span>", null, null, "<span class='warning'>You hear a band performance.</span>" );
			this.operating = true;
			this.update_icon();
			sourcename = this.occupant.real_name;
			sourcejob = this.occupant.job;
			sourcenutriment = this.occupant.nutrition / 15;

			if ( Lang13.Bool( this.occupant.reagents ) ) {
				sourcetotalreagents = this.occupant.reagents.total_volume;
			}
			totalslabs = Convert.ToInt32( this.occupant.size );
			allmeat = new ByTable( totalslabs );

			foreach (dynamic _a in Lang13.IterateRange( 1, totalslabs )) {
				i = _a;
				
				newmeat = new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Human();
				newmeat.name = sourcename + newmeat.name;
				newmeat.subjectname = sourcename;
				newmeat.subjectjob = sourcejob;
				((Reagents)newmeat.reagents).add_reagent( "nutriment", sourcenutriment / totalslabs );

				if ( Lang13.Bool( this.occupant.reagents ) ) {
					((Reagents)this.occupant.reagents).trans_to( newmeat, Num13.Round( ( sourcetotalreagents ??0) / totalslabs, 1 ) );
				}
				allmeat[i] = newmeat;
			}
			this.occupant.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] Was gibbed by <B>" + GlobalFuncs.key_name( user ) + "</B>" );
			user.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] Gibbed <B>" + GlobalFuncs.key_name( this.occupant ) + "</B>" );
			GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<B>" + GlobalFuncs.key_name( user ) + "</B> gibbed <B>" + GlobalFuncs.key_name( this.occupant ) + "</B>" ) ) );

			if ( !( user is Mob_Living_Carbon ) ) {
				this.occupant.LAssailant = null;
			} else {
				this.occupant.LAssailant = user;
			}
			((Mob)this.occupant).death( true );
			((Mob)this.occupant).ghostize();
			GlobalFuncs.qdel( this.occupant );
			this.occupant = null;
			Task13.Schedule( this.gibtime, (Task13.Closure)(() => {
				this.operating = false;

				foreach (dynamic _b in Lang13.IterateRange( 1, totalslabs )) {
					i2 = _b;
					
					meatslab = allmeat[i2];
					Tx = Map13.GetTile( ((int)( this.x - i2 )), this.y, this.z );
					meatslab.loc = this.loc;
					((dynamic)meatslab).throw_at( Tx, i2, 3 );

					if ( !Tx.density ) {
						O = GlobalFuncs.getFromPool( typeof(Obj_Effect_Decal_Cleanable_Blood_Gibs), Tx );
						((dynamic)O).New( Tx, i2 );
					}
				}
				this.operating = false;
				this.update_icon();
				return;
			}));
			return;
		}

		// Function from file: gibber.dm
		public void go_out(  ) {
			Ent_Dynamic x = null;

			
			if ( !Lang13.Bool( this.occupant ) ) {
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Ent_Dynamic) )) {
				x = _a;
				

				if ( Lang13.Bool( this.component_parts.Contains( x ) ) ) {
					continue;
				}
				x.forceMove( this.loc );
			}

			if ( Lang13.Bool( this.occupant.client ) ) {
				this.occupant.client.eye = this.occupant.client.mob;
				this.occupant.client.perspective = GlobalVars.MOB_PERSPECTIVE ?1:0;
			}
			this.occupant.loc = this.loc;
			this.occupant = null;
			this.update_icon();
			return;
		}

		// Function from file: gibber.dm
		public void handleGrab( dynamic G = null, dynamic user = null ) {
			Ent_Static M = null;

			
			if ( !Lang13.Bool( this.anchored ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>" + this + " must be anchored first!</span>" );
				return;
			}

			if ( Lang13.Bool( this.occupant ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>" + this + " is full! Empty it first.</span>" );
				return;
			}

			if ( !( G is Obj_Item_Weapon_Grab ) || !( G.affecting is Mob_Living_Carbon_Human ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>This item is not suitable for " + this + "!</span>" );
				return;
			}

			if ( ((Mob)G.affecting).abiotic( true ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>Subject may not have abiotic items on.</span>" );
				return;
			}
			((Ent_Static)user).visible_message( "<span class='warning'>" + user + " starts to put " + G.affecting + " into the gibber!</span>", null, null, "<span class='warning'>" + user + " starts dancing with " + G.affecting + " near the gibber!</span>" );
			this.add_fingerprint( user );

			if ( GlobalFuncs.do_after( user, this, 30 ) && Lang13.Bool( G ) && Lang13.Bool( G.affecting ) && !Lang13.Bool( this.occupant ) ) {
				((Ent_Static)user).visible_message( "<span class='warning'>" + user + " stuffs " + G.affecting + " into the gibber!</span>", null, null, "<span class='warning'>" + G.affecting + " suddenly disappears! How did he do that?</span>" );
				M = G.affecting;

				if ( Lang13.Bool( ((dynamic)M).client ) ) {
					((dynamic)M).client.perspective = GlobalVars.EYE_PERSPECTIVE ?1:0;
					((dynamic)M).client.eye = this;
				}
				M.loc = this;
				this.occupant = M;
				GlobalFuncs.returnToPool( G );
				this.update_icon();
			}
			return;
		}

		// Function from file: gibber.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}

			if ( !Lang13.Bool( this.anchored ) ) {
				GlobalFuncs.to_chat( a, "<span class='warning'>" + this + " must be anchored first!</span>" );
				return null;
			}

			if ( this.operating ) {
				GlobalFuncs.to_chat( a, "<span class='warning'>" + this + " is locked and running</span>" );
				return null;
			}

			if ( !Lang13.Bool( this.occupant ) ) {
				GlobalFuncs.to_chat( a, "<span class='warning'>" + this + " is empty!</span>" );
				return null;
			} else {
				this.startgibbing( a );
			}
			return null;
		}

		// Function from file: gibber.dm
		public override dynamic relaymove( Mob M = null, double? direction = null ) {
			this.go_out();
			return null;
		}

		// Function from file: gibber.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: gibber.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			this.overlays.len = 0;

			if ( this.dirty ) {
				this.overlays.Add( new Image( "icons/obj/kitchen.dmi", "grbloody" ) );
			}

			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}

			if ( !Lang13.Bool( this.occupant ) ) {
				this.overlays.Add( new Image( "icons/obj/kitchen.dmi", "grjam" ) );
			} else if ( this.operating ) {
				this.overlays.Add( new Image( "icons/obj/kitchen.dmi", "gruse" ) );
			} else {
				this.overlays.Add( new Image( "icons/obj/kitchen.dmi", "gridle" ) );
			}
			return null;
		}

		// Function from file: gibber.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( this.operating ) {
				GlobalFuncs.to_chat( b, "<span class='notice'>" + this + " is currently gibbing something!</span>" );
				return null;
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( a is Obj_Item_Weapon_Grab ) {
				this.handleGrab( a, b ); return null;
			} else {
				GlobalFuncs.to_chat( b, "<span class='warning'>This item is not suitable for the gibber!</span>" );
			}
			return null;
		}

		// Function from file: gibber.dm
		[Verb]
		[VerbInfo( name: "Empty Gibber", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public void eject(  ) {
			
			if ( Task13.User.isUnconscious() ) {
				return;
			}
			this.go_out();
			this.add_fingerprint( Task13.User );
			return;
		}

	}

}