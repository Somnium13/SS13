// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Dna : Game_Data {

		public string unique_enzymes = null;
		public dynamic struc_enzymes = null;
		public dynamic uni_identity = null;
		public string blood_type = null;
		public dynamic species = new Species_Human();
		public ByTable features = new ByTable(new object [] { "FFF" });
		public dynamic real_name = null;
		public ByTable mutations = new ByTable();
		public ByTable temporary_mutations = new ByTable();
		public ByTable previous = new ByTable();
		public Mob_Living_Carbon holder = null;

		// Function from file: dna.dm
		public Dna ( Mob_Living_Carbon new_holder = null ) {
			
			if ( new_holder != null ) {
				this.holder = new_holder;
			}
			return;
		}

		// Function from file: dna.dm
		public void initialize_dna( dynamic newblood_type = null ) {
			
			if ( Lang13.Bool( newblood_type ) ) {
				this.blood_type = newblood_type;
			}
			this.unique_enzymes = this.generate_unique_enzymes();
			this.uni_identity = this.generate_uni_identity();
			this.struc_enzymes = this.generate_struc_enzymes();
			this.features = GlobalFuncs.random_features();
			return;
		}

		// Function from file: dna.dm
		public void update_dna_identity(  ) {
			this.uni_identity = this.generate_uni_identity();
			this.unique_enzymes = this.generate_unique_enzymes();
			return;
		}

		// Function from file: dna.dm
		public bool is_same_as( dynamic D = null ) {
			
			if ( this.uni_identity == D.uni_identity && this.struc_enzymes == D.struc_enzymes && this.real_name == D.real_name ) {
				
				if ( this.species.type == D.species.type && this.features == D.features && this.blood_type == D.blood_type ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: dna.dm
		public ByTable species_get_spans(  ) {
			ByTable spans = null;

			spans = new ByTable();

			if ( Lang13.Bool( this.species ) ) {
				spans.Or( this.species.get_spans() );
			}
			return spans;
		}

		// Function from file: dna.dm
		public ByTable mutations_get_spans(  ) {
			ByTable spans = null;
			Mutation_Human M = null;

			spans = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( this.mutations, typeof(Mutation_Human) )) {
				M = _a;
				
				spans.Or( M.get_spans() );
			}
			return spans;
		}

		// Function from file: dna.dm
		public dynamic mutations_say_mods( dynamic message = null ) {
			Mutation_Human M = null;

			
			if ( Lang13.Bool( message ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.mutations, typeof(Mutation_Human) )) {
					M = _a;
					
					message = M.say_mod( message );
				}
				return message;
			}
			return null;
		}

		// Function from file: dna.dm
		public void update_ui_block( int blocknumber = 0 ) {
			Mob_Living_Carbon H = null;

			
			if ( !( blocknumber != 0 ) || !( this.holder is Mob_Living_Carbon_Human ) ) {
				return;
			}
			H = this.holder;

			switch ((int)( blocknumber )) {
				case 1:
					GlobalFuncs.setblock( this.uni_identity, blocknumber, GlobalFuncs.sanitize_hexcolor( ((dynamic)H).hair_color ) );
					break;
				case 2:
					GlobalFuncs.setblock( this.uni_identity, blocknumber, GlobalFuncs.sanitize_hexcolor( ((dynamic)H).facial_hair_color ) );
					break;
				case 3:
					GlobalFuncs.setblock( this.uni_identity, blocknumber, GlobalFuncs.construct_block( GlobalVars.skin_tones.Find( ((dynamic)H).skin_tone ), GlobalVars.skin_tones.len ) );
					break;
				case 4:
					GlobalFuncs.setblock( this.uni_identity, blocknumber, GlobalFuncs.sanitize_hexcolor( ((dynamic)H).eye_color ) );
					break;
				case 5:
					GlobalFuncs.setblock( this.uni_identity, blocknumber, GlobalFuncs.construct_block( ( H.gender != GlobalVars.MALE ?1:0) + 1, 2 ) );
					break;
				case 6:
					GlobalFuncs.setblock( this.uni_identity, blocknumber, GlobalFuncs.construct_block( GlobalVars.facial_hair_styles_list.Find( ((dynamic)H).facial_hair_style ), GlobalVars.facial_hair_styles_list.len ) );
					break;
				case 7:
					GlobalFuncs.setblock( this.uni_identity, blocknumber, GlobalFuncs.construct_block( GlobalVars.hair_styles_list.Find( ((dynamic)H).hair_style ), GlobalVars.hair_styles_list.len ) );
					break;
			}
			return;
		}

		// Function from file: dna.dm
		public string generate_unique_enzymes(  ) {
			string _default = null;

			_default = "";

			if ( this.holder is Mob_Living_Carbon ) {
				this.real_name = this.holder.real_name;
				_default += Num13.Md5( this.holder.real_name );
			} else {
				_default += GlobalFuncs.random_string( 32, GlobalVars.hex_characters );
			}
			return _default;
		}

		// Function from file: dna.dm
		public string generate_struc_enzymes(  ) {
			ByTable sorting = null;
			string result = null;
			Mutation_Human A = null;
			dynamic B = null;

			sorting = new ByTable( 19 );
			result = "";

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.good_mutations + GlobalVars.bad_mutations + GlobalVars.not_good_mutations, typeof(Mutation_Human) )) {
				A = _a;
				

				if ( A.name == "Monkified" && this.holder is Mob_Living_Carbon_Monkey ) {
					sorting[A.dna_block] = GlobalFuncs.num2hex( A.lowest_value + Rand13.Int( 0, 1536 ), 3 );
					this.mutations.Or( A );
				} else {
					sorting[A.dna_block] = GlobalFuncs.random_string( 3, new ByTable(new object [] { "0", "1", "2", "3", "4", "5", "6" }) );
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( sorting )) {
				B = _b;
				
				result += B;
			}
			return result;
		}

		// Function from file: dna.dm
		public string generate_uni_identity(  ) {
			string _default = null;

			ByTable L = null;
			Mob_Living_Carbon H = null;
			int? i = null;

			_default = "";
			L = new ByTable( 7 );
			L[5] = GlobalFuncs.construct_block( ( this.holder.gender != GlobalVars.MALE ?1:0) + 1, 2 );

			if ( this.holder is Mob_Living_Carbon_Human ) {
				H = this.holder;

				if ( !( GlobalVars.hair_styles_list.len != 0 ) ) {
					GlobalFuncs.init_sprite_accessory_subtypes( typeof(SpriteAccessory_Hair), GlobalVars.hair_styles_list, GlobalVars.hair_styles_male_list, GlobalVars.hair_styles_female_list );
				}
				L[7] = GlobalFuncs.construct_block( GlobalVars.hair_styles_list.Find( ((dynamic)H).hair_style ), GlobalVars.hair_styles_list.len );
				L[1] = GlobalFuncs.sanitize_hexcolor( ((dynamic)H).hair_color );

				if ( !( GlobalVars.facial_hair_styles_list.len != 0 ) ) {
					GlobalFuncs.init_sprite_accessory_subtypes( typeof(SpriteAccessory_FacialHair), GlobalVars.facial_hair_styles_list, GlobalVars.facial_hair_styles_male_list, GlobalVars.facial_hair_styles_female_list );
				}
				L[6] = GlobalFuncs.construct_block( GlobalVars.facial_hair_styles_list.Find( ((dynamic)H).facial_hair_style ), GlobalVars.facial_hair_styles_list.len );
				L[2] = GlobalFuncs.sanitize_hexcolor( ((dynamic)H).facial_hair_color );
				L[3] = GlobalFuncs.construct_block( GlobalVars.skin_tones.Find( ((dynamic)H).skin_tone ), GlobalVars.skin_tones.len );
				L[4] = GlobalFuncs.sanitize_hexcolor( ((dynamic)H).eye_color );
			}
			i = null;
			i = 1;

			while (( i ??0) <= 7) {
				
				if ( Lang13.Bool( L[i] ) ) {
					_default += L[i];
				} else {
					_default += GlobalFuncs.random_string( 3, GlobalVars.hex_characters );
				}
				i++;
			}
			return _default;
		}

		// Function from file: dna.dm
		public void remove_mutation_group( ByTable group = null ) {
			Mutation_Human HM = null;

			
			if ( !( group != null ) ) {
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( group, typeof(Mutation_Human) )) {
				HM = _a;
				
				HM.force_lose( this.holder );
			}
			return;
		}

		// Function from file: dna.dm
		public void remove_all_mutations(  ) {
			this.remove_mutation_group( this.mutations );
			return;
		}

		// Function from file: dna.dm
		public int check_mutation( string mutation_name = null ) {
			dynamic HM = null;

			HM = GlobalVars.mutations_list[mutation_name];
			return this.mutations.Find( HM );
		}

		// Function from file: dna.dm
		public void remove_mutation( dynamic mutation_name = null ) {
			Mutation_Human HM = null;

			HM = GlobalVars.mutations_list[mutation_name];
			HM.on_losing( this.holder );
			return;
		}

		// Function from file: dna.dm
		public void add_mutation( dynamic mutation_name = null ) {
			Mutation_Human HM = null;

			HM = GlobalVars.mutations_list[mutation_name];
			HM.on_acquiring( this.holder );
			return;
		}

		// Function from file: dna.dm
		public void copy_dna( dynamic new_dna = null ) {
			new_dna.unique_enzymes = this.unique_enzymes;
			new_dna.struc_enzymes = this.struc_enzymes;
			new_dna.uni_identity = this.uni_identity;
			new_dna.blood_type = this.blood_type;
			new_dna.features = this.features;
			new_dna.species = Lang13.Call( this.species.type );
			new_dna.real_name = this.real_name;
			new_dna.mutations = this.mutations;
			return;
		}

		// Function from file: dna.dm
		public void transfer_identity( dynamic destination = null, bool? transfer_SE = null ) {
			transfer_SE = transfer_SE ?? false;

			destination.dna.unique_enzymes = this.unique_enzymes;
			destination.dna.uni_identity = this.uni_identity;
			destination.dna.blood_type = this.blood_type;
			((Mob)destination).set_species( this.species.type, false );
			destination.dna.features = this.features;
			destination.dna.real_name = this.real_name;
			destination.dna.temporary_mutations = this.temporary_mutations;

			if ( transfer_SE == true ) {
				destination.dna.struc_enzymes = this.struc_enzymes;
			}
			return;
		}

	}

}