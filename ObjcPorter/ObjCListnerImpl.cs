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

			Console.WriteLine (sb);
		}

		public override void ExitProperty_declaration (ObjCParser.Property_declarationContext context)
		{
			var sb = new StringBuilder ();
			sb.Append ("@property");
			sb.Append (' ');

			var attributes = context.property_attributes_declaration ();
			if (attributes != null) {
				sb.Append (attributes.GetText ());
				sb.Append (' ');
			}

			var structDeclaration = context.struct_declaration ();
			sb.Append (structDeclaration.specifier_qualifier_list().GetText());
			sb.Append (' ');
			sb.Append (structDeclaration.struct_declarator_list ().GetText ());

			Console.WriteLine (sb);
		}
	}
}

