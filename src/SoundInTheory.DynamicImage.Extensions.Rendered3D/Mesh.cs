using System;
using System.ComponentModel;
using System.Web.UI;

namespace SoundInTheory.DynamicImage
{
	public class Mesh : DataBoundObject
	{
		private Point3DCollection _positions;
		private Vector3DCollection _normals;
		private Point2DCollection _textureCoordinates;
		private IndexCollection _indices;
		private Material _material;

		[Browsable(true), NotifyParentProperty(true)]
		public Point3DCollection Positions
		{
			get
			{
				if (_positions == null)
				{
					_positions = new Point3DCollection();
					if (((IStateManager)this).IsTrackingViewState)
						((IStateManager)_positions).TrackViewState();
				}
				return _positions;
			}
			set
			{
				if (_positions != null)
					throw new Exception("You can only set new positions if one does not already exist");

				_positions = value;
				if (((IStateManager)this).IsTrackingViewState)
					((IStateManager)_positions).TrackViewState();
			}
		}

		[Browsable(true), NotifyParentProperty(true)]
		public Vector3DCollection Normals
		{
			get
			{
				if (_normals == null)
				{
					_normals = new Vector3DCollection();
					if (((IStateManager)this).IsTrackingViewState)
						((IStateManager)_normals).TrackViewState();
				}
				return _normals;
			}
			set
			{
				if (_normals != null)
					throw new Exception("You can only set new normals if one does not already exist");

				_normals = value;
				if (((IStateManager)this).IsTrackingViewState)
					((IStateManager)_normals).TrackViewState();
			}
		}

		[Browsable(true), NotifyParentProperty(true)]
		public Point2DCollection TextureCoordinates
		{
			get
			{
				if (_textureCoordinates == null)
				{
					_textureCoordinates = new Point2DCollection();
					if (((IStateManager)this).IsTrackingViewState)
						((IStateManager)_textureCoordinates).TrackViewState();
				}
				return _textureCoordinates;
			}
			set
			{
				if (_textureCoordinates != null)
					throw new Exception("You can only set new texture coordinates if one does not already exist");

				_textureCoordinates = value;
				if (((IStateManager)this).IsTrackingViewState)
					((IStateManager)_textureCoordinates).TrackViewState();
			}
		}

		[Browsable(true), NotifyParentProperty(true)]
		public IndexCollection Indices
		{
			get
			{
				if (_indices == null)
				{
					_indices = new IndexCollection();
					if (((IStateManager)this).IsTrackingViewState)
						((IStateManager)_indices).TrackViewState();
				}
				return _indices;
			}
			set
			{
				if (_indices != null)
					throw new Exception("You can only set new indices if one does not already exist");

				_indices = value;
				if (((IStateManager)this).IsTrackingViewState)
					((IStateManager)_indices).TrackViewState();
			}
		}

		[Browsable(true), PersistenceMode(PersistenceMode.InnerProperty), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true)]
		public Material Material
		{
			get
			{
				if (_material == null)
				{
					_material = new Material();
					if (((IStateManager)this).IsTrackingViewState)
						((IStateManager)_material).TrackViewState();
				}
				return _material;
			}
			set
			{
				if (_material != null)
					throw new Exception("You can only set a new material if one does not already exist");

				_material = value;
				if (((IStateManager)this).IsTrackingViewState)
					((IStateManager)_material).TrackViewState();
			}
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
				{
					Pair pair = (Pair)triplet.Second;
					if (pair.First != null)
						((IStateManager)Positions).LoadViewState(pair.First);
					if (pair.Second != null)
						((IStateManager)Normals).LoadViewState(pair.Second);
				}
				if (triplet.Third != null)
				{
					Triplet pair = (Triplet)triplet.Third;
					if (pair.First != null)
						((IStateManager)Indices).LoadViewState(pair.First);
					if (pair.Second != null)
						((IStateManager)Material).LoadViewState(pair.Second);
					if (pair.Third != null)
						((IStateManager)TextureCoordinates).LoadViewState(pair.Third);
				}
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
			if (_positions != null || _normals != null)
				triplet.Second = new Pair();
			if (_positions != null)
				((Pair) triplet.Second).First = ((IStateManagedObject)_positions).SaveViewState(saveAll);
			if (_normals != null)
				((Pair)triplet.Second).Second = ((IStateManagedObject)_normals).SaveViewState(saveAll);
			if (_indices != null || _material != null || _textureCoordinates != null)
				triplet.Third = new Triplet();
			if (_indices != null)
				((Triplet)triplet.Third).First = ((IStateManagedObject)_indices).SaveViewState(saveAll);
			if (_material != null)
				((Triplet)triplet.Third).Second = ((IStateManagedObject)_material).SaveViewState(saveAll);
			if (_textureCoordinates != null)
				((Triplet)triplet.Third).Third = ((IStateManagedObject)_textureCoordinates).SaveViewState(saveAll);
			return (triplet.First == null && triplet.Second == null && triplet.Third == null) ? null : triplet;
		}

		/// <summary>
		/// Tracks view state changes to the <see cref="ImageLayer" /> object.
		/// </summary>
		protected override void TrackViewState()
		{
			base.TrackViewState();
			if (_positions != null)
				((IStateManager)_positions).TrackViewState();
			if (_normals != null)
				((IStateManager)_normals).TrackViewState();
			if (_indices != null)
				((IStateManager)_indices).TrackViewState();
			if (_material != null)
				((IStateManager)_material).TrackViewState();
			if (_textureCoordinates != null)
				((IStateManager)_textureCoordinates).TrackViewState();
		}

		#endregion
	}
}