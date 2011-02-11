using System.ComponentModel;
using System.Windows.Media;

namespace SoundInTheory.DynamicImage
{
	public class Material : DataBoundObject
	{
		[DefaultValue(typeof(Colors), "Gray")]
		public Color DiffuseColor
		{
			get { return (Color) (ViewState["DiffuseColor"] ?? Colors.Gray); }
			set { ViewState["DiffuseColor"] = value; }
		}

		[DefaultValue(typeof(Colors), "White")]
		public Color SpecularColor
		{
			get { return (Color)(ViewState["SpecularColor"] ?? Colors.White); }
			set { ViewState["SpecularColor"] = value; }
		}

		[DefaultValue("")]
		public string TextureName
		{
			get { return (string)(ViewState["TextureName"] ?? string.Empty); }
			set { ViewState["TextureName"] = value; }
		}

		[DefaultValue(16)]
		public int Shininess
		{
			get { return (int)(ViewState["Shininess"] ?? 16); }
			set { ViewState["Shininess"] = value; }
		}

		[DefaultValue(1.0f)]
		public float Transparency
		{
			get { return (float)(ViewState["Transparency"] ?? 1.0f); }
			set { ViewState["Transparency"] = value; }
		}
	}
}