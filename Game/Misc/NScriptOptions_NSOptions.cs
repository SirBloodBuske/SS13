// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class NScriptOptions_NSOptions : NScriptOptions {

		public ByTable symbols = new ByTable(new object [] { "(", ")", "[", "]", ";", ",", "{", "}" });
		public ByTable keywords = new ByTable()
											.Set( "if", typeof(NKeyword_NSKeyword_KwIf) )
											.Set( "else", typeof(NKeyword_NSKeyword_KwElse) )
											.Set( "elseif", typeof(NKeyword_NSKeyword_KwElseIf) )
											.Set( "while", typeof(NKeyword_NSKeyword_KwWhile) )
											.Set( "break", typeof(NKeyword_NSKeyword_KwBreak) )
											.Set( "continue", typeof(NKeyword_NSKeyword_KwContinue) )
											.Set( "return", typeof(NKeyword_NSKeyword_KwReturn) )
											.Set( "def", typeof(NKeyword_NSKeyword_KwDef) )
										;
		public ByTable assign_operators = new ByTable().Set( "=", null ).Set( "&=", "&" ).Set( "|=", "|" ).Set( "`=", "`" ).Set( "+=", "+" ).Set( "-=", "-" ).Set( "*=", "*" ).Set( "/=", "/" ).Set( "^=", "^" ).Set( "%=", "%" );
		public ByTable unary_operators = new ByTable().Set( "!", typeof(Node_Expression_Operator_Unary_LogicalNot) ).Set( "~", typeof(Node_Expression_Operator_Unary_BitwiseNot) ).Set( "-", typeof(Node_Expression_Operator_Unary_Minus) );
		public ByTable binary_operators = new ByTable()
											.Set( "==", typeof(Node_Expression_Operator_Binary_Equal) )
											.Set( "!=", typeof(Node_Expression_Operator_Binary_NotEqual) )
											.Set( ">", typeof(Node_Expression_Operator_Binary_Greater) )
											.Set( "<", typeof(Node_Expression_Operator_Binary_Less) )
											.Set( ">=", typeof(Node_Expression_Operator_Binary_GreaterOrEqual) )
											.Set( "<=", typeof(Node_Expression_Operator_Binary_LessOrEqual) )
											.Set( "&&", typeof(Node_Expression_Operator_Binary_LogicalAnd) )
											.Set( "||", typeof(Node_Expression_Operator_Binary_LogicalOr) )
											.Set( "&", typeof(Node_Expression_Operator_Binary_BitwiseAnd) )
											.Set( "|", typeof(Node_Expression_Operator_Binary_BitwiseOr) )
											.Set( "`", typeof(Node_Expression_Operator_Binary_BitwiseXor) )
											.Set( "+", typeof(Node_Expression_Operator_Binary_Add) )
											.Set( "-", typeof(Node_Expression_Operator_Binary_Subtract) )
											.Set( "*", typeof(Node_Expression_Operator_Binary_Multiply) )
											.Set( "/", typeof(Node_Expression_Operator_Binary_Divide) )
											.Set( "^", typeof(Node_Expression_Operator_Binary_Power) )
											.Set( "%", typeof(Node_Expression_Operator_Binary_Modulo) )
										;

		// Function from file: Options.dm
		public NScriptOptions_NSOptions (  ) {
			dynamic O = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.Enumerate( this.assign_operators + this.binary_operators + this.unary_operators )) {
				O = _a;
				

				if ( !( this.symbols.Find( O ) != 0 ) ) {
					this.symbols.Add( O );
				}
			}
			return;
		}

	}

}