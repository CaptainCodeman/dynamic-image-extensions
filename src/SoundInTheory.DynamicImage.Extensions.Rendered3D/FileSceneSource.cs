using System.ComponentModel;
using System.IO;
using System.Web.UI;
using Meshellator;
using SoundInTheory.DynamicImage.Sources;

namespace SoundInTheory.DynamicImage
{
	public class FileSceneSource : SceneSource
	{
		[Category("Source"), Browsable(true), UrlProperty]
		public string FileName
		{
			get { return (string) ViewState["FileName"] ?? string.Empty; }
			set { ViewState["FileName"] = value; }
		}

		public override Scene GetScene(ISite site, bool designMode)
		{
			string resolvedFileName = FileSourceHelper.ResolveFileName(FileName, site, designMode);
			if (File.Exists(resolvedFileName))
				return MeshellatorLoader.ImportFromFile(resolvedFileName);
			return null;
		}
	}
}