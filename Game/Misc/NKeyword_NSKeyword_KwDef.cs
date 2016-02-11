// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class NKeyword_NSKeyword_KwDef : NKeyword_NSKeyword {

		public NKeyword_NSKeyword_KwDef ( bool? inline = null ) : base( inline ) {
			
		}

		// Function from file: Keywords.dm
		public override int Parse( NParser parser = null ) {
			int _default = 0;

			Node_Statement_FunctionDefinition def = null;

			_default = GlobalVars.KW_PASS ?1:0;
			def = new Node_Statement_FunctionDefinition();
			parser.NextToken();

			if ( !((NScriptOptions)((dynamic)parser).options).IsValidID( ((dynamic)parser.curToken).value ) ) {
				parser.errors.Add( new ScriptError_InvalidID( parser.curToken ) );
				return GlobalVars.KW_FAIL ?1:0;
			}
			def.func_name = ((dynamic)parser.curToken).value;
			parser.NextToken();

			if ( !Lang13.Bool( ((dynamic)parser).CheckToken( "(", typeof(Token_Symbol) ) ) ) {
				return GlobalVars.KW_FAIL ?1:0;
			}

			if ( parser.curToken is Token_Symbol ) {
				
				dynamic _a = ((dynamic)parser.curToken).value; // Was a switch-case, sorry for the mess.
				if ( _a=="," ) {
					parser.NextToken();
				} else if ( _a==")" ) {
					throw new Exception("Failed to remove goto!"); // FIXME, GOTO;
				} else {
					parser.errors.Add( new ScriptError_BadToken( parser.curToken ) );
					return GlobalVars.KW_ERR;
				}
			} else if ( parser.curToken is Token_Word ) {
				def.parameters.Add( ((dynamic)parser.curToken).value );
				parser.NextToken();
			} else {
				parser.errors.Add( new ScriptError_InvalidID( parser.curToken ) );
				return GlobalVars.KW_ERR;
			}
			throw new Exception("Failed to remove goto!"); // FIXME, GOTO;

			if ( !Lang13.Bool( ((dynamic)parser).CheckToken( ")", typeof(Token_Symbol) ) ) ) {
				return GlobalVars.KW_FAIL ?1:0;
			}

			if ( parser.curToken is Token_End ) {
				parser.curBlock.statements.Add( def );
			} else if ( ((dynamic)parser.curToken).value == "{" && parser.curToken is Token_Symbol ) {
				def.block = new Node_BlockDefinition_FunctionBlock();
				parser.curBlock.statements.Add( def );
				parser.curBlock.functions[def.func_name] = def;
				((dynamic)parser).AddBlock( def.block );
			} else {
				parser.errors.Add( new ScriptError_BadToken( parser.curToken ) );
				return GlobalVars.KW_FAIL ?1:0;
			}
			return _default;
		}

	}

}