using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ObjcPorter
{
	public class InterfaceExtruder
	{
		readonly string content;

		ObjCLexer lexer;
		CommonTokenStream tokens;
		ObjCParser parser;

		ObjCListnerImpl listner;
		ParseTreeWalker walker;

		public InterfaceExtruder (string objcFileContent)
		{
			content = objcFileContent;
			var input = new AntlrInputStream (content);
			lexer = new ObjCLexer (input);
			tokens = new CommonTokenStream (lexer);
			parser = new ObjCParser (tokens);

			listner = new ObjCListnerImpl ();
			walker = new ParseTreeWalker ();
		}

		public void Extrude()
		{
			walker.Walk (listner, parser.translation_unit ());
		}
	}
}

