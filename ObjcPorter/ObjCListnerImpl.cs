using System;
using System.Text;

namespace ObjcPorter
{
	public class ObjCListnerImpl : ObjCBaseListener
	{
		public ObjCListnerImpl ()
		{
		}

		public override void ExitInstance_method_definition (ObjCParser.Instance_method_definitionContext context)
		{
			var sb = new StringBuilder ();
			sb.Append ('-');
			ObjCParser.Method_definitionContext md = context.method_definition();
			ObjCParser.Method_typeContext method_typeContext = md.method_type ();

			sb.Append (method_typeContext != null ? method_typeContext.GetText () : string.Empty);
			string selector = md.method_selector ().GetText ();
			sb.Append (selector);

			var declaratorList = md.init_declarator_list ();
			if (declaratorList != null) {
				sb.Append (' ');
				sb.Append (declaratorList.GetText ());
			}

			Console.WriteLine (sb);
		}
	}
}

