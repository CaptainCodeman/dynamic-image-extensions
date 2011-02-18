using System.ComponentModel;
using System.Web.UI;
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

		[DefaultValue(""), UrlProperty]
		public string TextureFileName
		{
			get { return (string)(ViewState["TextureFileName"] ?? string.Empty); }
			set { ViewState["TextureFileName"] = value; }
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