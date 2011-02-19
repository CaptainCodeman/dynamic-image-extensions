using System;
using System.Collections;
using Nexus.Graphics.Cameras;

namespace SoundInTheory.DynamicImage
{
	public class CameraCollection : CustomStateManagedCollection<Camera>
	{
		#region Static stuff

		static CameraCollection()
		{
			_knownTypes = new[]
			{
				typeof(PerspectiveCamera),
				typeof(OrthographicCamera)
			};
		}

		#endregion

		#region Properties

		public Camera SingleSource
		{
			get { return (Count > 0) ? (Camera)((IList)this)[0] : null; }
			set { ((IList)this).Insert(0, value); }
		}

		#endregion

		#region Methods

		public override int Add(Camera camera)
		{
			if (Count > 0)
				throw new InvalidOperationException("Only one camera can be specified");
			return base.Add(camera);
		}

		protected override object CreateKnownType(int index)
		{
			switch (index)
			{
				case 0:
					return new PerspectiveCamera();
				case 1 :
					return new OrthographicCamera();
			}
			throw new ArgumentOutOfRangeException("index", "Type index is out of bounds.");
		}

		#endregion
	}
}