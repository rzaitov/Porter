using System;
using System.IO;

namespace ObjcPorter
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if (args.Length == 0) {
				Console.WriteLine ("objcporter path/to/objcfile");
				return;
			}

			string path = args [0];
			string fileContent = File.ReadAllText (path);

			var extruder = new InterfaceExtruder (fileContent);
			extruder.Extrude ();
		}
	}
}
