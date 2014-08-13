using System;
using System.Collections.Generic;

namespace Porter
{
	public class SourceAnalayzer
	{
		public SourceAnalayzer ()
		{
		}

		public string GetMethodsFrom(string objcSource)
		{
			var methods = new List<string> ();

			string[] lines = objcSource.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
			foreach (var line in lines) {
				if (IsMethodDeclaration (line))
					methods.Add (line);
			}

			return string.Join (Environment.NewLine, methods);
		}

		private bool IsMethodDeclaration(string line)
		{
			string l = line.Trim ();

			return l.StartsWith ("+") || l.StartsWith ("-");
		}
	}
}

