// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Bookcase_Random_Reference : Obj_Structure_Bookcase_Random {

		public int ref_book_prob = 20;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.category = "Reference";
		}

		public Obj_Structure_Bookcase_Random_Reference ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: random_books.dm
		public override void initialize(  ) {
			
			while (this.book_count > 0 && Rand13.PercentChance( this.ref_book_prob )) {
				this.book_count--;
				new Obj_Item_Weapon_Book_Manual_Random( this );
			}
			base.initialize();
			return;
		}

	}

}