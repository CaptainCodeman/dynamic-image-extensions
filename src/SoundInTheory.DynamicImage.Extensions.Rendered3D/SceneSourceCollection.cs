using System;
using System.Collections;

namespace SoundInTheory.DynamicImage
{
	public class SceneSourceCollection : CustomStateManagedCollection<SceneSource>
	{
		#region Static stuff

		static SceneSourceCollection()
		{
			_knownTypes = new[]
			{
				typeof(FileSceneSource)
			};
		}

		#endregion

		#region Properties

		public SceneSource SingleSource
		{
			get { return (SceneSource)((IList)this)[0]; }
			set { ((IList)this).Insert(0, value); }
		}

		#endregion

		#region Methods

		public override int Add(SceneSource imageSource)
		{
			if (this.Count > 0)
				throw new InvalidOperationException("Only one source can be specified");
			return base.Add(imageSource);
		}

		protected override object CreateKnownType(int index)
		{
			switch (index)
			{
				case 0:
					return new FileSceneSource();
			}
			throw new ArgumentOutOfRangeException("Type index is out of bounds.");
		}

		#endregion
	}
}