using System.ComponentModel;
using System.Web.UI;
using System.Windows.Media.Imaging;
using DotWarp;
using Meshellator;
using Nexus;
using Nexus.Graphics.Cameras;
using SoundInTheory.DynamicImage.Sources;
using SoundInTheory.DynamicImage.Util;

namespace SoundInTheory.DynamicImage
{
	public class RenderedLayer : Layer
	{
		#region Properties

		[Browsable(true), DefaultValue(400), Category("Layout"), Description("Width of the layer")]
		public int Width
		{
			get { return (int)(ViewState["Width"] ?? 400); }
			set { ViewState["Width"] = value; }
		}

		[Browsable(true), DefaultValue(300), Category("Layout"), Description("Height of the layer")]
		public int Height
		{
			get { return (int)(ViewState["Height"] ?? 300); }
			set { ViewState["Height"] = value; }
		}

		/// <summary>
		/// Shortcut route to Source/FileMeshSource
		/// </summary>
		[Category("Source"), Browsable(true), UrlProperty]
		public string SourceFileName
		{
			get { return (string) ViewState["SourceFileName"] ?? string.Empty; }
			set { ViewState["SourceFileName"] = value; }
		}

		#endregion

		protected override void CreateImage()
		{
			using (WarpSceneRenderer renderer = new WarpSceneRenderer(Width, Height))
			{
				Scene scene = MeshellatorLoader.ImportFromFile(FileSourceHelper.ResolveFileName(SourceFileName, null, false));
				Camera camera = new PerspectiveCamera
				{
					FarPlaneDistance = 100000,
					NearPlaneDistance = 1,
					FieldOfView = MathUtility.PI_OVER_4,
					LookDirection = new Vector3D(-1, -0.3f, 1),
					Position = new Point3D(3000, 1500, -1500),
					UpDirection = Vector3D.Up
				};

				BitmapSource renderedBitmap = renderer.Render(scene, camera);
				Bitmap = new FastBitmap(renderedBitmap);
			}
		}

		public override bool HasFixedSize
		{
			get { return true; }
		}
	}
}