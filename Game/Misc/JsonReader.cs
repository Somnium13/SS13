// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class JsonReader : Game_Data {

		public ByTable v_string = new ByTable(new object [] { "'", "\"" });
		public ByTable symbols = new ByTable(new object [] { "{", "}", "[", "]", ":", "\"", "'", "," });
		public ByTable sequences = new ByTable().Set( "b", 8 ).Set( "t", 9 ).Set( "n", 10 ).Set( "f", 12 ).Set( "r", 13 );
		public ByTable tokens = null;
		public dynamic json = null;
		public int? i = 1;

		// Function from file: JSON Reader.dm
		public void die( dynamic T = null ) {
			
			if ( !Lang13.Bool( T ) ) {
				T = this.get_token();
			}
			Task13.Crash( "Unexpected token: " + T.value + " " + this.json + " index:" + this.i + " ." );
			return;
		}

		// Function from file: JSON Reader.dm
		public ByTable read_array(  ) {
			ByTable _default = null;

			ByTable L = null;
			dynamic T = null;

			this.read_token( "[", typeof(JsonToken_Symbol) );
			_default = new ByTable();
			L = _default;

			while (( this.i ??0) <= this.tokens.len) {
				L.len++;
				L[L.len] = this.read_value();
				T = this.get_token();
				this.check_type( typeof(JsonToken_Symbol) );

				dynamic _a = T.value; // Was a switch-case, sorry for the mess.
				if ( _a=="," ) {
					this.next_token();
					continue;
				} else if ( _a=="]" ) {
					this.next_token();
					return _default;
				} else {
					this.die();
					this.next_token();
				}
				Task13.Crash( "Unterminated array." );
			}
			return _default;
		}

		// Function from file: JSON Reader.dm
		public dynamic read_value(  ) {
			Base_Data T = null;

			T = this.get_token();

			if ( T != null ) {
				
				dynamic _c = T.type; // Was a switch-case, sorry for the mess.
				if ( _c==typeof(JsonToken_Text) || _c==typeof(JsonToken_Number) ) {
					this.next_token();
					return ((dynamic)T).value;
				} else if ( _c==typeof(JsonToken_Word) ) {
					this.next_token();

					dynamic _a = ((dynamic)T).value; // Was a switch-case, sorry for the mess.
					if ( _a=="true" ) {
						return GlobalVars.TRUE;
					} else if ( _a=="false" ) {
						return GlobalVars.FALSE;
					} else if ( _a=="null" ) {
						return null;
					}
				} else if ( _c==typeof(JsonToken_Symbol) ) {
					
					dynamic _b = ((dynamic)T).value; // Was a switch-case, sorry for the mess.
					if ( _b=="[" ) {
						return this.read_array();
					} else if ( _b=="{" ) {
						return this.ReadObject( this.tokens.Copy( this.i ) );
					}
				}
			}
			this.die();
			return null;
		}

		// Function from file: JSON Reader.dm
		public JsonToken_Text read_key(  ) {
			string _char = null;

			_char = this.get_char();

			if ( _char == "\"" || _char == "'" ) {
				return this.read_string( _char );
			}
			return null;
		}

		// Function from file: JSON Reader.dm
		public void check_value( params object[] _ ) {
			ByTable _args = new ByTable( new object[] {  } ).Extend(_);

			dynamic T = null;

			T = this.get_token();

			if ( !Lang13.Bool( _args.Find( T.value ) ) ) {
				Task13.Crash( "" + "code/modules/nano/JSON Reader.dm" + ":" + 164 + ":Assertion Failed: " + "args.Find(T.value)" );
			}
			return;
		}

		// Function from file: JSON Reader.dm
		public void check_type( params object[] _ ) {
			ByTable _args = new ByTable( new object[] {  } ).Extend(_);

			Base_Data T = null;
			dynamic type = null;

			T = this.get_token();

			foreach (dynamic _a in Lang13.Enumerate( _args )) {
				type = _a;
				

				if ( Lang13.Bool( type.IsInstanceOfType( T ) ) ) {
					return;
				}
			}
			Task13.Crash( "Bad token type: " + T.type + "." );
			return;
		}

		// Function from file: JSON Reader.dm
		public dynamic read_token( string val = null, Type type = null ) {
			dynamic T = null;

			T = this.get_token();

			if ( !( T.value == val && Lang13.Bool( ((dynamic)type).IsInstanceOfType( T ) ) ) ) {
				Task13.Crash( "Expected '" + val + "', found '" + T.value + "'." );
			}
			this.next_token();
			return T;
		}

		// Function from file: JSON Reader.dm
		public dynamic next_token(  ) {
			
			if ( ( ++this.i ??0) <= this.tokens.len ) {
				return this.tokens[this.i];
			}
			return null;
		}

		// Function from file: JSON Reader.dm
		public dynamic get_token(  ) {
			return this.tokens[this.i];
		}

		// Function from file: JSON Reader.dm
		public ByTable ReadObject( ByTable tokens = null ) {
			ByTable _default = null;

			dynamic K = null;
			dynamic S = null;

			this.tokens = tokens;
			_default = new ByTable();
			this.i = 1;
			this.read_token( "{", typeof(JsonToken_Symbol) );

			while (( this.i ??0) <= tokens.len) {
				K = this.get_token();
				this.check_type( typeof(JsonToken_Word), typeof(JsonToken_Text) );
				this.next_token();
				this.read_token( ":", typeof(JsonToken_Symbol) );
				_default[K.value] = this.read_value();
				S = this.get_token();
				this.check_type( typeof(JsonToken_Symbol) );

				if ( !Lang13.Bool( S ) ) {
					this.die();
					return _default;
				}

				dynamic _a = S.value; // Was a switch-case, sorry for the mess.
				if ( _a=="," ) {
					this.next_token();
					continue;
				} else if ( _a=="}" ) {
					this.next_token();
					return _default;
				} else {
					this.die();
				}
			}
			return _default;
		}

		// Function from file: JSON Reader.dm
		public ByTable ReadArray( ByTable tokens = null ) {
			this.tokens = tokens;
			this.i = 1;
			return this.read_array();
		}

		// Function from file: JSON Reader.dm
		public bool is_digit( string _char = null ) {
			int c = 0;

			c = String13.GetCharCode( _char, null );
			return 48 <= c && c <= 57 || _char == "+" || _char == "-";
		}

		// Function from file: JSON Reader.dm
		public bool is_whitespace( string _char = null ) {
			return _char == " " || _char == "	" || _char == "\n" || String13.GetCharCode( _char, null ) == 13;
		}

		// Function from file: JSON Reader.dm
		public string get_char(  ) {
			return String13.SubStr( this.json, this.i ??0, ( this.i ??0) + 1 );
		}

		// Function from file: JSON Reader.dm
		public void check_char( params object[] _ ) {
			ByTable _args = new ByTable( new object[] {  } ).Extend(_);

			
			if ( !Lang13.Bool( _args.Find( this.get_char() ) ) ) {
				Task13.Crash( "" + "code/modules/nano/JSON Reader.dm" + ":" + 91 + ":Assertion Failed: " + "args.Find(get_char())" );
			}
			return;
		}

		// Function from file: JSON Reader.dm
		public JsonToken_Number read_number(  ) {
			string val = null;
			string _char = null;

			val = "";
			_char = this.get_char();

			while (this.is_digit( _char ) || _char == "." || String13.ToLower( _char ) == "e") {
				val += _char;
				this.i++;
				_char = this.get_char();
			}
			this.i--;
			return new JsonToken_Number( String13.ParseNumber( val ) );
		}

		// Function from file: JSON Reader.dm
		public JsonToken_Text read_string( string delim = null ) {
			bool? escape = null;
			string val = null;
			string _char = null;

			escape = GlobalVars.FALSE;
			val = "";

			while (( ++this.i ??0) <= Lang13.Length( this.json )) {
				_char = this.get_char();

				if ( escape == true ) {
					escape = GlobalVars.FALSE;

					switch ((string)( _char )) {
						case "\\":
						case "'":
						case "\"":
						case "/":
						case "u":
							val += _char;
							break;
						default:
							
							if ( !( this.sequences.Find( _char ) != 0 ) ) {
								Task13.Crash( "" + "code/modules/nano/JSON Reader.dm" + ":" + 69 + ":Assertion Failed: " + "sequences.Find(char)" );
							}
							val += String13.GetCharFromCode( Convert.ToInt32( this.sequences[_char] ) );
							break;
					}
				} else if ( _char == delim ) {
					return new JsonToken_Text( val );
				} else if ( _char == "\\" ) {
					escape = GlobalVars.TRUE;
				} else {
					val += _char;
				}
			}
			Task13.Crash( "Unterminated string." );
			return null;
		}

		// Function from file: JSON Reader.dm
		public JsonToken_Word read_word(  ) {
			string val = null;
			string _char = null;

			val = "";

			while (( this.i ??0) <= Lang13.Length( this.json )) {
				_char = this.get_char();

				if ( this.is_whitespace( _char ) || this.symbols.Find( _char ) != 0 ) {
					this.i--;
					return new JsonToken_Word( val );
				}
				val += _char;
				this.i++;
			}
			return null;
		}

		// Function from file: JSON Reader.dm
		public ByTable ScanJson( dynamic json = null ) {
			ByTable _default = null;

			string _char = null;

			this.json = json;
			_default = new ByTable();
			this.i = 1;

			while (( this.i ??0) <= Lang13.Length( json )) {
				_char = this.get_char();

				if ( this.is_whitespace( _char ) ) {
					this.i++;
					continue;
				}

				if ( this.v_string.Find( _char ) != 0 ) {
					_default.Add( this.read_string( _char ) );
				} else if ( this.symbols.Find( _char ) != 0 ) {
					_default.Add( new JsonToken_Symbol( _char ) );
				} else if ( this.is_digit( _char ) ) {
					_default.Add( this.read_number() );
				} else {
					_default.Add( this.read_word() );
				}
				this.i++;
			}
			_default.Add( new JsonToken_Eof() );
			return _default;
		}

	}

}