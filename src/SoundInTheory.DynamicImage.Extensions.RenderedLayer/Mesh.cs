using System;
using System.ComponentModel;
using System.Web.UI;

namespace SoundInTheory.DynamicImage
{
	public class Mesh : DataBoundObject
	{
		private Point3DCollection _positions;
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
					((IStateManager)Positions).LoadViewState(triplet.Second);
				if (triplet.Third != null)
				{
					Pair pair = (Pair)triplet.Third;
					if (pair.First != null)
						((IStateManager)Indices).LoadViewState(pair.First);
					if (pair.Second != null)
						((IStateManager)Material).LoadViewState(pair.Second);
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
			if (_positions != null)
				triplet.Second = ((IStateManagedObject)_positions).SaveViewState(saveAll);
			if (_indices != null || _material != null)
				triplet.Third = new Pair();
			if (_indices != null)
				((Pair)triplet.Third).First = ((IStateManagedObject)_indices).SaveViewState(saveAll);
			if (_material != null)
				((Pair)triplet.Third).Second = ((IStateManagedObject)_material).SaveViewState(saveAll);
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
			if (_indices != null)
				((IStateManager)_indices).TrackViewState();
			if (_material != null)
				((IStateManager)_material).TrackViewState();
		}

		#endregion
	}
}