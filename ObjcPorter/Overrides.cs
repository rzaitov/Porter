using System;
using System.Text;

public partial class ObjCParser
{
	public partial class Method_selectorContext
	{
		public override string GetText ()
		{
			if (this.ChildCount == 0)
				return string.Empty;

			var sb = new StringBuilder ();
			for (int i = 0; i < this.ChildCount; i++)
				sb.Append (this.GetChild (i).GetText ());

			return sb.ToString ();
		}
	}
}

