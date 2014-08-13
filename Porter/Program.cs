using System;
using System.IO;

namespace Porter
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string path = args [0];
			string sourceCode = File.ReadAllText (path);

			SourceAnalayzer engine = new SourceAnalayzer ();
			string methodList = engine.GetMethodsFrom (sourceCode);

			Console.WriteLine (methodList);
		}
	}
}
