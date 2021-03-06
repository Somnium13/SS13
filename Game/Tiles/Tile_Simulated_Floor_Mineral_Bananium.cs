// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Floor_Mineral_Bananium : Tile_Simulated_Floor_Mineral {

		public bool spam_flag = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.floor_tile = typeof(Obj_Item_Stack_Tile_Mineral_Bananium);
			this.icons = new ByTable(new object [] { "bananium", "bananium_dam" });
			this.icon_state = "bananium";
		}

		public Tile_Simulated_Floor_Mineral_Bananium ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mineral_floor.dm
		public void squeek(  ) {
			
			if ( !this.spam_flag ) {
				this.spam_flag = true;
				GlobalFuncs.playsound( this, "clownstep", 50, 1 );
				Task13.Schedule( 10, (Task13.Closure)(() => {
					this.spam_flag = false;
					return;
				}));
			}
			return;
		}

		// Function from file: mineral_floor.dm
		public void honk(  ) {
			
			if ( !this.spam_flag ) {
				this.spam_flag = true;
				GlobalFuncs.playsound( this, "sound/items/bikehorn.ogg", 50, 1 );
				Task13.Schedule( 20, (Task13.Closure)(() => {
					this.spam_flag = false;
					return;
				}));
			}
			return;
		}

		// Function from file: mineral_floor.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			_default = base.attack_paw( (object)(a), (object)(b), (object)(c) );

			if ( !Lang13.Bool( _default ) ) {
				this.honk();
			}
			return _default;
		}

		// Function from file: mineral_floor.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			dynamic _default = null;

			_default = base.attack_hand( (object)(a), b, c );

			if ( !Lang13.Bool( _default ) ) {
				this.honk();
			}
			return _default;
		}

		// Function from file: mineral_floor.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic _default = null;

			_default = base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( !Lang13.Bool( _default ) ) {
				this.honk();
			}
			return _default;
		}

		// Function from file: mineral_floor.dm
		public override dynamic Entered( Ent_Dynamic Obj = null, Ent_Static oldloc = null ) {
			dynamic _default = null;

			_default = base.Entered( Obj, oldloc );

			if ( !Lang13.Bool( _default ) ) {
				
				if ( Obj is Mob ) {
					this.squeek();
				}
			}
			return _default;
		}

	}

}