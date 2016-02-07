// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Bluespacebodybag : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Bluespace body bag";
			this.desc = "A bluespace body bag, powered by experimental bluespace technology. It can hold loads of bodies and the largest of creatures.";
			this.id = "bluespacebodybag";
			this.req_tech = new ByTable().Set( "bluespace", 2 ).Set( "materials", 6 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 3000 ).Set( "$plasma", 2000 ).Set( "$diamond", 500 );
			this.reliability = 76;
			this.build_path = typeof(Obj_Item_Bodybag_Bluespace);
			this.category = new ByTable(new object [] { "Medical Designs" });
		}

	}

}