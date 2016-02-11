// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class NParser_NSParser : NParser {

		public int expecting = 2;
		public NScriptOptions_NSOptions options = null;

		// Function from file: Parser.dm
		public NParser_NSParser ( ByTable tokens = null, NScriptOptions_NSOptions options = null ) {
			this.tokens = tokens;
			this.options = options;
			this.curBlock = this.global_block;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: Parser.dm
		public override Node_BlockDefinition_GlobalBlock Parse(  ) {
			dynamic kw = null;
			Base_Data ntok = null;

			
			if ( !( this.tokens != null ) ) {
				Task13.Crash( "" + "code/modules/scripting/Parser/Parser.dm" + ":" + 78 + ":Assertion Failed: " + "tokens" );
			}

			while (this.index <= this.tokens.len) {
				this.curToken = this.tokens[this.index];

				dynamic _a = this.curToken.type; // Was a switch-case, sorry for the mess.
				if ( _a==typeof(Token_Keyword) ) {
					kw = this.options.keywords[((dynamic)this.curToken).value];
					kw = Lang13.Call( kw );

					if ( Lang13.Bool( kw ) ) {
						
						if ( !Lang13.Bool( kw.Parse( this ) ) ) {
							return null;
						}
					}
				} else if ( _a==typeof(Token_Word) ) {
					ntok = null;

					if ( this.index + 1 > this.tokens.len ) {
						this.errors.Add( new ScriptError_BadToken( this.curToken ) );
						this.index++;
						continue;
					}
					ntok = this.tokens[this.index + 1];

					if ( !( ntok is Token_Symbol ) ) {
						this.errors.Add( new ScriptError_BadToken( ntok ) );
						this.index++;
						continue;
					}

					if ( ((dynamic)ntok).value == "(" ) {
						this.ParseFunctionStatement();
					} else if ( this.options.assign_operators.Find( ((dynamic)ntok).value ) != 0 ) {
						this.ParseAssignment();
					} else {
						this.errors.Add( new ScriptError_BadToken( ntok ) );
						this.index++;
						continue;
					}

					if ( !( this.curToken is Token_End ) ) {
						this.errors.Add( new ScriptError_ExpectedToken( ";", this.curToken ) );
						this.index++;
						continue;
					}
				} else if ( _a==typeof(Token_Symbol) ) {
					
					if ( ((dynamic)this.curToken).value == "}" ) {
						
						if ( !this.EndBlock() ) {
							this.errors.Add( new ScriptError_BadToken( this.curToken ) );
							this.index++;
							continue;
						}
					} else {
						this.errors.Add( new ScriptError_BadToken( this.curToken ) );
						this.index++;
						continue;
					}
				} else if ( _a==typeof(Token_End) ) {
					this.warnings.Add( new ScriptError_BadToken( this.curToken ) );
					this.index++;
					continue;
				} else {
					this.errors.Add( new ScriptError_BadToken( this.curToken ) );
					return null;
				}
				this.index++;
			}
			return this.global_block;
		}

		// Function from file: Parser.dm
		public void ParseFunctionStatement(  ) {
			Node_Statement_FunctionCall stmt = null;
			int loops = 0;
			dynamic P = null;

			
			if ( !( this.curToken is Token_Word ) ) {
				this.errors.Add( new ScriptError( "Bad identifier in function call." ) );
				return;
			}
			stmt = new Node_Statement_FunctionCall();
			stmt.func_name = ((dynamic)this.curToken).value;
			this.NextToken();

			if ( !this.CheckToken( "(", typeof(Token_Symbol) ) ) {
				return;
			}
			loops = 0;
			loops++;

			if ( loops >= 800 ) {
				this.errors.Add( new ScriptError( "Cannot find ending params." ) );
				return;
			}

			if ( !( this.curToken != null ) ) {
				this.errors.Add( new ScriptError_EndOfFile() );
				return;
			}

			if ( this.curToken is Token_Symbol && ((dynamic)this.curToken).value == ")" ) {
				this.curBlock.statements.Add( stmt );
				this.NextToken();
				return;
			}
			P = this.ParseParamExpression( true );
			stmt.parameters.Add( P );

			if ( this.curToken is Token_Symbol && ((dynamic)this.curToken).value == "," ) {
				this.NextToken();
			}
			throw new Exception("Failed to remove goto!"); // FIXME, GOTO;
			return;
		}

		// Function from file: Parser.dm
		public void ParseAssignment(  ) {
			string name = null;
			dynamic t = null;
			Node_Statement_VariableAssignment stmt = null;

			name = ((dynamic)this.curToken).value;

			if ( !this.options.IsValidID( name ) ) {
				this.errors.Add( new ScriptError_InvalidID( this.curToken ) );
				return;
			}
			this.NextToken();
			t = this.options.binary_operators[this.options.assign_operators[((dynamic)this.curToken).value]];
			stmt = new Node_Statement_VariableAssignment();
			stmt.var_name = new Node_Identifier( name );
			this.NextToken();

			if ( Lang13.Bool( t ) ) {
				stmt.value = Lang13.Call( t );
				stmt.value.exp = new Node_Expression_Value_Variable( stmt.var_name );
				stmt.value.exp2 = this.ParseExpression();
			} else {
				stmt.value = this.ParseExpression();
			}
			this.curBlock.statements.Add( stmt );
			return;
		}

		// Function from file: Parser.dm
		public bool EndBlock(  ) {
			
			if ( this.curBlock == this.global_block ) {
				return false;
			}
			this.curBlock = this.blocks.Pop();
			return true;
		}

		// Function from file: Parser.dm
		public void AddBlock( dynamic B = null ) {
			this.blocks.Push( this.curBlock );
			this.curBlock = B;
			return;
		}

		// Function from file: Parser.dm
		public bool CheckToken( string val = null, Type type = null, bool? err = null, bool? skip = null ) {
			err = err ?? true;
			skip = skip ?? true;

			
			if ( ((dynamic)this.curToken).value != val || !Lang13.Bool( ((dynamic)type).IsInstanceOfType( this.curToken ) ) ) {
				
				if ( err == true ) {
					this.errors.Add( new ScriptError_ExpectedToken( val, this.curToken ) );
				}
				return false;
			}

			if ( skip == true ) {
				this.NextToken();
			}
			return true;
		}

		// Function from file: Expressions.dm
		public dynamic ParseParamExpression( bool? check_functions = null ) {
			check_functions = check_functions ?? false;

			bool? cf = null;

			cf = check_functions;
			return this.ParseExpression( new ByTable(new object [] { ",", ")" }), null, cf );
		}

		// Function from file: Expressions.dm
		public Node_Expression_Operator_Unary_Group ParseParenExpression(  ) {
			
			if ( !this.CheckToken( "(", typeof(Token_Symbol) ) ) {
				return null;
			}
			return new Node_Expression_Operator_Unary_Group( this.ParseExpression( new ByTable(new object [] { ")" }) ) );
		}

		// Function from file: Expressions.dm
		public Node_Expression_FunctionCall ParseFunctionExpression(  ) {
			Node_Expression_FunctionCall exp = null;
			int loops = 0;

			exp = new Node_Expression_FunctionCall();
			exp.func_name = ((dynamic)this.curToken).value;
			this.NextToken();
			this.NextToken();
			loops = 0;
			loops++;

			if ( loops >= 800 ) {
				this.errors.Add( new ScriptError( "Too many nested expressions." ) );
			} else {
				
				if ( this.curToken is Token_Symbol && ((dynamic)this.curToken).value == ")" ) {
					return exp;
				}
				exp.parameters.Add( this.ParseParamExpression() );

				if ( this.errors.len != 0 ) {
					return exp;
				}

				if ( ((dynamic)this.curToken).value == "," && this.curToken is Token_Symbol ) {
					this.NextToken();
				}

				if ( this.curToken is Token_End ) {
					this.errors.Add( new ScriptError_ExpectedToken( ")" ) );
					return exp;
				}
				throw new Exception("Failed to remove goto!"); // FIXME, GOTO;
			}
			return null;
		}

		// Function from file: Expressions.dm
		public dynamic ParseExpression( ByTable end = null, ByTable ErrChars = null, bool? check_functions = null ) {
			end = end ?? new ByTable(new object [] { typeof(Token_End) });
			ErrChars = ErrChars ?? new ByTable(new object [] { "{", "}" });
			check_functions = check_functions ?? false;

			dynamic _default = null;

			Stack opr = null;
			Stack val = null;
			int loop = 0;
			dynamic ntok = null;
			dynamic curOperator = null;
			Base_Data preToken = null;
			int old_expect = 0;
			Node_Expression_FunctionCall fex = null;
			dynamic kw = null;
			dynamic N = null;

			opr = new Stack();
			val = new Stack();
			this.expecting = 2;
			loop = 0;
			loop++;

			if ( loop > 800 ) {
				this.errors.Add( new ScriptError( "Too many nested tokens." ) );
				return _default;
			}

			if ( this.EndOfExpression( end ) ) {
				
			} else if ( this.curToken is Token_Symbol && ErrChars.Find( ((dynamic)this.curToken).value ) != 0 ) {
				this.errors.Add( new ScriptError_BadToken( this.curToken ) );
			} else if ( this.index > this.tokens.len ) {
				this.errors.Add( new ScriptError_EndOfFile() );
			} else {
				ntok = null;

				if ( this.index + 1 <= this.tokens.len ) {
					ntok = this.tokens[this.index + 1];
				}

				if ( this.curToken is Token_Symbol && ((dynamic)this.curToken).value == "(" ) {
					
					if ( this.expecting != 2 ) {
						this.errors.Add( new ScriptError_ExpectedToken( "operator", this.curToken ) );
						this.NextToken();
						throw new Exception("Failed to remove goto!"); // FIXME, GOTO;
					}
					val.Push( this.ParseParenExpression() );
				} else if ( this.curToken is Token_Symbol ) {
					curOperator = null;

					if ( this.expecting == 1 ) {
						curOperator = this.GetBinaryOperator( this.curToken );

						if ( !Lang13.Bool( curOperator ) ) {
							this.errors.Add( new ScriptError_ExpectedToken( "operator", this.curToken ) );
							this.NextToken();
							throw new Exception("Failed to remove goto!"); // FIXME, GOTO;
						}
					} else {
						curOperator = this.GetUnaryOperator( this.curToken );

						if ( !Lang13.Bool( curOperator ) ) {
							this.errors.Add( new ScriptError_ExpectedToken( "expression", this.curToken ) );
							this.NextToken();
							throw new Exception("Failed to remove goto!"); // FIXME, GOTO;
						}
					}

					if ( Lang13.Bool( opr.Top() ) && this.Precedence( opr.Top(), curOperator ) ) {
						this.Reduce( opr, val );
						throw new Exception("Failed to remove goto!"); // FIXME, GOTO;
					}
					opr.Push( curOperator );
					this.expecting = 2;
				} else if ( Lang13.Bool( ntok ) && ntok.value == "(" && ntok is Token_Symbol && this.curToken is Token_Word ) {
					
					if ( !( check_functions == true ) ) {
						preToken = this.curToken;
						old_expect = this.expecting;
						fex = this.ParseFunctionExpression();

						if ( old_expect != 2 ) {
							this.errors.Add( new ScriptError_ExpectedToken( "operator", preToken ) );
							this.NextToken();
							throw new Exception("Failed to remove goto!"); // FIXME, GOTO;
						}
						val.Push( fex );
					} else {
						this.errors.Add( new ScriptError_ParameterFunction( this.curToken ) );
						throw new Exception("Failed to remove goto!"); // FIXME, GOTO;
					}
				} else if ( this.curToken is Token_Keyword ) {
					kw = this.options.keywords[((dynamic)this.curToken).value];
					kw = new ByTable().Set( "inline", 1 ).Apply( kw );

					if ( Lang13.Bool( kw ) ) {
						
						if ( !Lang13.Bool( kw.Parse( this ) ) ) {
							return _default;
						}
					} else {
						this.errors.Add( new ScriptError_BadToken( this.curToken ) );
					}
				} else if ( this.curToken is Token_End ) {
					this.errors.Add( new ScriptError_BadToken( this.curToken ) );
					this.NextToken();
					throw new Exception("Failed to remove goto!"); // FIXME, GOTO;
				} else {
					
					if ( this.expecting != 2 ) {
						this.errors.Add( new ScriptError_ExpectedToken( "operator", this.curToken ) );
						this.NextToken();
						throw new Exception("Failed to remove goto!"); // FIXME, GOTO;
					}
					val.Push( this.GetExpression( this.curToken ) );
					this.expecting = 1;
				}
				this.NextToken();
				throw new Exception("Failed to remove goto!"); // FIXME, GOTO;
			}

			while (Lang13.Bool( opr.Top() )) {
				this.Reduce( opr, val );
			}
			_default = val.Pop();

			if ( Lang13.Bool( val.Top() ) ) {
				N = val.Pop();
				this.errors.Add( new ScriptError( "Error parsing expression. Unexpected value left on stack: " + N.ToString() + "." ) );
				return null;
			}
			return _default;
		}

		// Function from file: Expressions.dm
		public bool EndOfExpression( ByTable end = null ) {
			
			if ( !( this.curToken != null ) ) {
				return true;
			}

			if ( this.curToken is Token_Symbol && end.Find( ((dynamic)this.curToken).value ) != 0 ) {
				return true;
			}

			if ( this.curToken is Token_End && end.Find( typeof(Token_End) ) != 0 ) {
				return true;
			}
			return false;
		}

		// Function from file: Expressions.dm
		public void Reduce( Stack opr = null, Stack val = null ) {
			Game_Data O = null;
			Game_Data B = null;

			O = opr.Pop();

			if ( !( O != null ) ) {
				return;
			}

			if ( !( O is Node_Expression_Operator ) ) {
				this.errors.Add( new ScriptError( "Error reducing expression - invalid operator." ) );
				return;
			}

			if ( O is Node_Expression_Operator_Binary ) {
				B = O;
				((dynamic)B).exp2 = val.Pop();
				((dynamic)B).exp = val.Pop();
				val.Push( B );
			} else {
				((dynamic)O).exp = val.Pop();
				val.Push( O );
			}
			return;
		}

		// Function from file: Expressions.dm
		public dynamic GetUnaryOperator( Base_Data O = null ) {
			return this.GetOperator( O, typeof(Node_Expression_Operator_Unary), this.options.unary_operators );
		}

		// Function from file: Expressions.dm
		public dynamic GetBinaryOperator( Base_Data O = null ) {
			return this.GetOperator( O, typeof(Node_Expression_Operator_Binary), this.options.binary_operators );
		}

		// Function from file: Expressions.dm
		public dynamic GetOperator( dynamic O = null, Type type = null, ByTable L = null ) {
			type = type ?? typeof(Node_Expression_Operator);

			
			if ( Lang13.Bool( ((dynamic)type).IsInstanceOfType( O ) ) ) {
				return O;
			}

			if ( O is Token ) {
				O = O.value;
			}

			if ( O is string ) {
				
				if ( L.Find( O ) != 0 ) {
					O = L[O];
				} else {
					return null;
				}
			}

			if ( O is Type ) {
				O = Lang13.Call( O );
			} else {
				return null;
			}
			return O;
		}

		// Function from file: Expressions.dm
		public Base_Data GetExpression( Base_Data T = null ) {
			Base_Data A = null;
			Node_Expression_Value_Variable E = null;
			Stack S = null;
			Node_Expression_Value_Variable V = null;

			
			if ( !( T != null ) ) {
				return null;
			}

			if ( T is Node_Expression ) {
				return T;
			}

			dynamic _a = T.type; // Was a switch-case, sorry for the mess.
			if ( _a==typeof(Token_Word) ) {
				return new Node_Expression_Value_Variable( ((dynamic)T).value );
			} else if ( _a==typeof(Token_Accessor) ) {
				A = T;
				E = null;
				S = new Stack();

				while (((dynamic)A).v_object is Token_Accessor) {
					S.Push( A );
					A = ((dynamic)A).v_object;
				}

				if ( !( ((dynamic)A).v_object is string ) ) {
					Task13.Crash( "" + "code/modules/scripting/Parser/Expressions.dm" + ":" + 70 + ":Assertion Failed: " + "istext(A.object)" );
				}

				while (A != null) {
					V = new Node_Expression_Value_Variable();
					V.id = new Node_Identifier( ((dynamic)A).member );

					if ( E != null ) {
						V.v_object = E;
					} else {
						V.v_object = new Node_Identifier( ((dynamic)A).v_object );
					}
					E = V;
					A = S.Pop();
				}
				return E;
			} else if ( _a==typeof(Token_Number) || _a==typeof(Token_String) ) {
				return new Node_Expression_Value_Literal( ((dynamic)T).value );
			}
			return null;
		}

		// Function from file: Expressions.dm
		public bool Precedence( dynamic top = null, dynamic input = null ) {
			
			if ( top is Node_Expression_Operator ) {
				top = top.precedence;
			}

			if ( input is Node_Expression_Operator ) {
				input = input.precedence;
			}

			if ( Convert.ToDouble( top ) >= Convert.ToDouble( input ) ) {
				return true;
			}
			return false;
		}

	}

}