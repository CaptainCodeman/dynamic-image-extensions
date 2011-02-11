using System;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using Meshellator;
using SoundInTheory.DynamicImage.Util;

namespace SoundInTheory.DynamicImage
{
	public class InlineSceneSource : SceneSource
	{
		private MeshCollection _meshes;

		[Browsable(true), PersistenceMode(PersistenceMode.InnerProperty), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true)]
		public MeshCollection Meshes
		{
			get
			{
				if (_meshes == null)
				{
					_meshes = new MeshCollection();
					if (((IStateManager)this).IsTrackingViewState)
						((IStateManager)_meshes).TrackViewState();
				}
				return _meshes;
			}
			set
			{
				if (_meshes != null)
					throw new Exception("You can only set new meshes if one does not already exist");

				_meshes = value;
				if (((IStateManager)this).IsTrackingViewState)
					((IStateManager)_meshes).TrackViewState();
			}
		}

		public override Scene GetScene(ISite site, bool designMode)
		{
			Scene scene = new Scene();

			foreach (Mesh mesh in Meshes)
			{
				Meshellator.Mesh meshellatorMesh = new Meshellator.Mesh();
				scene.Meshes.Add(meshellatorMesh);

				meshellatorMesh.Positions.AddRange(mesh.Positions.Select(p => new Nexus.Point3D(p.X, p.Y, p.Z)));
				meshellatorMesh.Indices.AddRange(mesh.Indices.Select(i => i.Value));

				MeshUtility.CalculateNormals(meshellatorMesh, false);

				Meshellator.Material meshellatorMaterial = new Meshellator.Material();
				meshellatorMaterial.DiffuseColor = ConversionUtility.ToNexusColorRgbF(mesh.Material.DiffuseColor);
				meshellatorMaterial.DiffuseTextureName = mesh.Material.TextureName;
				meshellatorMaterial.Shininess = mesh.Material.Shininess;
				meshellatorMaterial.SpecularColor = ConversionUtility.ToNexusColorRgbF(mesh.Material.SpecularColor);
				meshellatorMaterial.Transparency = mesh.Material.Transparency;
				
				meshellatorMesh.Material = meshellatorMaterial;
				scene.Materials.Add(meshellatorMaterial);
			}

			return scene;
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
				Pair triplet = (Pair)savedState;
				if (triplet.First != null)
					base.LoadViewState(triplet.First);
				if (triplet.Second != null)
					((IStateManager)Meshes).LoadViewState(triplet.Second);
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
			Pair triplet = new Pair();
			triplet.First = base.SaveViewState(saveAll);
			if (_meshes != null)
				triplet.Second = ((IStateManagedObject)_meshes).SaveViewState(saveAll);
			return (triplet.First == null && triplet.Second == null) ? null : triplet;
		}

		/// <summary>
		/// Tracks view state changes to the <see cref="ImageLayer" /> object.
		/// </summary>
		protected override void TrackViewState()
		{
			base.TrackViewState();
			if (_meshes != null)
				((IStateManager)_meshes).TrackViewState();
		}

		#endregion
	}
}