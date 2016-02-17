// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class WritingStyle_Pen : WritingStyle {

		// Function from file: pen.dm
		public WritingStyle_Pen (  ) {
			this.addReplacement( GlobalFuncs.REG_BBTAG( "*" ), "<li>" );
			Console.WriteLine("~");
			this.addReplacement( GlobalFuncs.REG_BBTAG( "hr" ), "<HR>" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "small" ), "<span style=\"font-size:15px\">" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "/small" ), "</span>" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "tiny" ), "<span style=\"font-size:10px\">" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "/tiny" ), "</span>" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "list" ), "<ul>" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "/list" ), "</ul>" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "agency" ), "<span style=\"font-family:Agency FB\">" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "/agency" ), "</span>" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "algerian" ), "<span style=\"font-family:Algerian\">" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "/algerian" ), "</span>" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "arial" ), "<span style=\"font-family:Arial\">" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "/arial" ), "</span>" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "arialb" ), "<span style=\"font-family:Arial Black\">" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "/arialb" ), "</span>" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "calibri" ), "<span style=\"font-family:Calibri\">" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "/calibri" ), "</span>" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "courier" ), "<span style=\"font-family:Courier\">" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "/courier" ), "</span>" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "helvetica" ), "<span style=\"font-family:Helvetica\">" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "/helvetica" ), "</span>" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "impact" ), "<span style=\"font-family:Impact\">" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "/impact" ), "</span>" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "palatino" ), "<span style=\"font-family:Palatino Linotype\">" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "/palatino" ), "</span>" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "tnr" ), "<span style=\"font-family:Times New Roman\">" );
			this.addReplacement( GlobalFuncs.REG_BBTAG( "/tnr" ), "</span>" );
			this.addExpression( ":" + GlobalFuncs.REG_BBTAG( "img" ) + "(" + "[^\\[]+" + ")" + GlobalFuncs.REG_BBTAG( "/img" ) + ":gi", typeof(SpeechFilterAction_Bbcode_Img), new ByTable() );

			Console.WriteLine("/");
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}