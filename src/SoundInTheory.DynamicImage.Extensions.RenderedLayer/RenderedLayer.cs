using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DotWarp;
using Meshellator;
using SoundInTheory.DynamicImage.Caching;
using SoundInTheory.DynamicImage.Util;

namespace SoundInTheory.DynamicImage
{
	public class RenderedLayer : Layer
	{
		private SceneSourceCollection _source;
		private CameraCollection _camera;

		#region Properties

		[Category("Source"), Browsable(true), PersistenceMode(PersistenceMode.InnerProperty), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true)]
		public SceneSourceCollection Source
		{
			get
			{
				if (_source == null)
				{
					_source = new SceneSourceCollection();
					if (((IStateManager)this).IsTrackingViewState)
						((IStateManager)_source).TrackViewState();
				}
				return _source;
			}
			set
			{
				if (_source != null)
					throw new Exception("You can only set a new source if one does not already exist");

				_source = value;
				if (((IStateManager)this).IsTrackingViewState)
					((IStateManager)_source).TrackViewState();
			}
		}

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

		[DefaultValue(false)]
		public bool ReverseWindingOrder
		{
			get { return (bool)(ViewState["ReverseWindingOrder"] ?? false); }
			set { ViewState["ReverseWindingOrder"] = value; }
		}

		[Browsable(true), DefaultValue(typeof(Colors), "White"), TypeConverter(typeof(ColorConverter))]
		public Color BackgroundColour
		{
			get { return (Color) (ViewState["BackgroundColour"] ?? Colors.White); }
			set { ViewState["BackgroundColour"] = value; }
		}

		[DefaultValue(true)]
		public bool LightingEnabled
		{
			get { return (bool)(ViewState["LightingEnabled"] ?? true); }
			set { ViewState["LightingEnabled"] = value; }
		}

		/// <summary>
		/// Shortcut route to Source/FileMeshSource
		/// </summary>
		[Category("Source"), Browsable(true), UrlProperty]
		public string SourceFileName
		{
			set { Source.SingleSource = new FileSceneSource { FileName = value }; }
		}

		[Category("Camera"), Browsable(true), PersistenceMode(PersistenceMode.InnerProperty), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true)]
		public CameraCollection Camera
		{
			get
			{
				if (_camera == null)
				{
					_camera = new CameraCollection();
					if (((IStateManager)this).IsTrackingViewState)
						((IStateManager)_camera).TrackViewState();
				}
				return _camera;
			}
			set
			{
				if (_camera != null)
					throw new Exception("You can only set a new camera if one does not already exist");

				_camera = value;
				if (((IStateManager)this).IsTrackingViewState)
					((IStateManager)_camera).TrackViewState();
			}
		}

		public override bool HasFixedSize
		{
			get { return true; }
		}

		#endregion

		protected override void CreateImage()
		{
			Scene scene = Source.SingleSource.GetScene(Site, DesignMode);
			using (WarpSceneRenderer renderer = new WarpSceneRenderer(scene, Width, Height))
			{
				renderer.Initialize();

				renderer.Options.TriangleWindingOrderReversed = ReverseWindingOrder;
				renderer.Options.BackgroundColor = new Nexus.Color(BackgroundColour.A, BackgroundColour.R, BackgroundColour.G, BackgroundColour.B);
				renderer.Options.LightingEnabled = LightingEnabled;

				Nexus.Graphics.Cameras.Camera camera = (Camera != null && Camera.SingleSource != null)
					? Camera.SingleSource.GetNexusCamera(scene)
					: new AutoCamera().GetNexusCamera(scene);
				BitmapSource renderedBitmap = renderer.Render(camera);
				Bitmap = new FastBitmap(renderedBitmap);
			}
		}

		public override void PopulateDependencies(List<Dependency> dependencies)
		{
			base.PopulateDependencies(dependencies);
			Source.SingleSource.PopulateDependencies(dependencies);
		}

		public override void DataBind()
		{
			base.DataBind();
			Source.SingleSource.DataBind();
			Camera.SingleSource.DataBind();
		}

		#region View state implementation

		/// <summary>
		/// /// <summary>
		/// Loads the previously saved state of the <see cref="RenderedLayer" /> object.
		/// </summary>
		/// <param name="savedState">
		/// An object containing the saved view state values for the <see cref="RenderedLayer" /> object.
		/// </param>
		/// </summary>
		protected override void LoadViewState(object savedState)
		{
			if (savedState != null)
			{
				Triplet triplet = (Triplet)savedState;
				if (triplet.First != null)
					base.LoadViewState(triplet.First);
				if (triplet.Second != null)
					((IStateManager)Source).LoadViewState(triplet.Second);
				if (triplet.Third != null)
					((IStateManager)Camera).LoadViewState(triplet.Third);
			}
		}

		/// <summary>
		/// Saves the current view state of the <see cref="ImageLayer" /> object.
		/// </summary>
		/// <param name="saveAll"><c>true</c> if all values should be saved regardless
		/// of whether they are dirty; otherwise <c>false</c>.</param>
		/// <returns>An object that represents the saved state. The default is <c>null</c>.</returns>
		protected override object SaveViewState(bool saveAll)
		{
			Triplet triplet = new Triplet();
			triplet.First = base.SaveViewState(saveAll);
			if (_source != null)
				triplet.Second = ((IStateManagedObject)_source).SaveViewState(saveAll);
			if (_camera != null)
				triplet.Third = ((IStateManagedObject)_camera).SaveViewState(saveAll);
			return (triplet.First == null && triplet.Second == null && triplet.Third == null) ? null : triplet;
		}

		/// <summary>
		/// Tracks view state changes to the <see cref="ImageLayer" /> object.
		/// </summary>
		protected override void TrackViewState()
		{
			base.TrackViewState();
			if (_source != null)
				((IStateManager)_source).TrackViewState();
			if (_camera != null)
				((IStateManager)_camera).TrackViewState();
		}

		#endregion
	}
}