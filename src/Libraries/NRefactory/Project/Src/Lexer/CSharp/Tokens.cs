// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="none" email=""/>
//     <version>$Revision$</version>
// </file>

// this file was autogenerated by a tool.
using System;
using System.Collections;

namespace ICSharpCode.NRefactory.Parser.CSharp
{
	public sealed class Tokens
	{
		// ----- terminal classes -----
		public const int EOF                  = 0;
		public const int Identifier           = 1;
		public const int Literal              = 2;

		// ----- special character -----
		public const int Assign               = 3;
		public const int Plus                 = 4;
		public const int Minus                = 5;
		public const int Times                = 6;
		public const int Div                  = 7;
		public const int Mod                  = 8;
		public const int Colon                = 9;
		public const int DoubleColon          = 10;
		public const int Semicolon            = 11;
		public const int Question             = 12;
		public const int Comma                = 13;
		public const int Dot                  = 14;
		public const int OpenCurlyBrace       = 15;
		public const int CloseCurlyBrace      = 16;
		public const int OpenSquareBracket    = 17;
		public const int CloseSquareBracket   = 18;
		public const int OpenParenthesis      = 19;
		public const int CloseParenthesis     = 20;
		public const int GreaterThan          = 21;
		public const int LessThan             = 22;
		public const int Not                  = 23;
		public const int LogicalAnd           = 24;
		public const int LogicalOr            = 25;
		public const int BitwiseComplement    = 26;
		public const int BitwiseAnd           = 27;
		public const int BitwiseOr            = 28;
		public const int Xor                  = 29;
		public const int Increment            = 30;
		public const int Decrement            = 31;
		public const int Equal                = 32;
		public const int NotEqual             = 33;
		public const int GreaterEqual         = 34;
		public const int LessEqual            = 35;
		public const int ShiftLeft            = 36;
		public const int PlusAssign           = 37;
		public const int MinusAssign          = 38;
		public const int TimesAssign          = 39;
		public const int DivAssign            = 40;
		public const int ModAssign            = 41;
		public const int BitwiseAndAssign     = 42;
		public const int BitwiseOrAssign      = 43;
		public const int XorAssign            = 44;
		public const int ShiftLeftAssign      = 45;
		public const int Pointer              = 46;

		// ----- keywords -----
		public const int Abstract             = 47;
		public const int As                   = 48;
		public const int Base                 = 49;
		public const int Bool                 = 50;
		public const int Break                = 51;
		public const int Byte                 = 52;
		public const int Case                 = 53;
		public const int Catch                = 54;
		public const int Char                 = 55;
		public const int Checked              = 56;
		public const int Class                = 57;
		public const int Const                = 58;
		public const int Continue             = 59;
		public const int Decimal              = 60;
		public const int Default              = 61;
		public const int Delegate             = 62;
		public const int Do                   = 63;
		public const int Double               = 64;
		public const int Else                 = 65;
		public const int Enum                 = 66;
		public const int Event                = 67;
		public const int Explicit             = 68;
		public const int Extern               = 69;
		public const int False                = 70;
		public const int Finally              = 71;
		public const int Fixed                = 72;
		public const int Float                = 73;
		public const int For                  = 74;
		public const int Foreach              = 75;
		public const int Goto                 = 76;
		public const int If                   = 77;
		public const int Implicit             = 78;
		public const int In                   = 79;
		public const int Int                  = 80;
		public const int Interface            = 81;
		public const int Internal             = 82;
		public const int Is                   = 83;
		public const int Lock                 = 84;
		public const int Long                 = 85;
		public const int Namespace            = 86;
		public const int New                  = 87;
		public const int Null                 = 88;
		public const int Object               = 89;
		public const int Operator             = 90;
		public const int Out                  = 91;
		public const int Override             = 92;
		public const int Params               = 93;
		public const int Private              = 94;
		public const int Protected            = 95;
		public const int Public               = 96;
		public const int Readonly             = 97;
		public const int Ref                  = 98;
		public const int Return               = 99;
		public const int Sbyte                = 100;
		public const int Sealed               = 101;
		public const int Short                = 102;
		public const int Sizeof               = 103;
		public const int Stackalloc           = 104;
		public const int Static               = 105;
		public const int String               = 106;
		public const int Struct               = 107;
		public const int Switch               = 108;
		public const int This                 = 109;
		public const int Throw                = 110;
		public const int True                 = 111;
		public const int Try                  = 112;
		public const int Typeof               = 113;
		public const int Uint                 = 114;
		public const int Ulong                = 115;
		public const int Unchecked            = 116;
		public const int Unsafe               = 117;
		public const int Ushort               = 118;
		public const int Using                = 119;
		public const int Virtual              = 120;
		public const int Void                 = 121;
		public const int Volatile             = 122;
		public const int While                = 123;

		public const int maxToken = 124;
		static BitArray NewSet(params int[] values)
		{
			BitArray bitArray = new BitArray(maxToken);
			foreach (int val in values) {
			bitArray[val] = true;
			}
			return bitArray;
		}
		public static BitArray OverloadableUnaryOp = NewSet(Plus, Not, BitwiseComplement, Increment, Decrement, True, False);
		public static BitArray OverloadableBinaryOp = NewSet(Plus, Minus, Times, Div, Mod, BitwiseAnd, BitwiseOr, Xor, ShiftLeft, Equal, NotEqual, GreaterThan, LessThan, GreaterEqual, LessEqual);
		public static BitArray TypeKW = NewSet(Char, Bool, Object, String, Sbyte, Byte, Short, Ushort, Int, Uint, Long, Ulong, Float, Double, Decimal);
		public static BitArray UnaryHead = NewSet(Plus, Minus, Not, BitwiseComplement, Times, Increment, Decrement, BitwiseAnd);
		public static BitArray AssnStartOp = NewSet(Plus, Minus, Not, BitwiseComplement, Times);
		public static BitArray CastFollower = NewSet(Identifier, Literal, OpenParenthesis, New, This, Base, Null, Checked, Unchecked, Typeof, Sizeof, Plus, Not, BitwiseComplement, Increment, Decrement, True, False);
		public static BitArray AssgnOps = NewSet(Assign, PlusAssign, MinusAssign, TimesAssign, DivAssign, ModAssign, BitwiseAndAssign, BitwiseOrAssign, ShiftLeftAssign);
		public static BitArray UnaryOp = NewSet(Plus, Minus, Not, BitwiseComplement, Times, Increment, Decrement, BitwiseAnd);
		public static BitArray TypeDeclarationKW = NewSet(Class, Interface, Struct, Enum, Delegate);

		static string[] tokenList = new string[] {
			// ----- terminal classes -----
			"<EOF>",
			"<Identifier>",
			"<Literal>",
			// ----- special character -----
			"=",
			"+",
			"-",
			"*",
			"/",
			"%",
			":",
			"::",
			";",
			"?",
			",",
			".",
			"{",
			"}",
			"[",
			"]",
			"(",
			")",
			">",
			"<",
			"!",
			"&&",
			"||",
			"~",
			"&",
			"|",
			"^",
			"++",
			"--",
			"==",
			"!=",
			">=",
			"<=",
			"<<",
			"+=",
			"-=",
			"*=",
			"/=",
			"%=",
			"&=",
			"|=",
			"^=",
			"<<=",
			"->",
			// ----- keywords -----
			"abstract",
			"as",
			"base",
			"bool",
			"break",
			"byte",
			"case",
			"catch",
			"char",
			"checked",
			"class",
			"const",
			"continue",
			"decimal",
			"default",
			"delegate",
			"do",
			"double",
			"else",
			"enum",
			"event",
			"explicit",
			"extern",
			"false",
			"finally",
			"fixed",
			"float",
			"for",
			"foreach",
			"goto",
			"if",
			"implicit",
			"in",
			"int",
			"interface",
			"internal",
			"is",
			"lock",
			"long",
			"namespace",
			"new",
			"null",
			"object",
			"operator",
			"out",
			"override",
			"params",
			"private",
			"protected",
			"public",
			"readonly",
			"ref",
			"return",
			"sbyte",
			"sealed",
			"short",
			"sizeof",
			"stackalloc",
			"static",
			"string",
			"struct",
			"switch",
			"this",
			"throw",
			"true",
			"try",
			"typeof",
			"uint",
			"ulong",
			"unchecked",
			"unsafe",
			"ushort",
			"using",
			"virtual",
			"void",
			"volatile",
			"while",
		};
		public static string GetTokenString(int token)
		{
			if (token >= 0 && token < tokenList.Length) {
				return tokenList[token];
			}
			throw new System.NotSupportedException("Unknown token:" + token);
		}
	}
}
