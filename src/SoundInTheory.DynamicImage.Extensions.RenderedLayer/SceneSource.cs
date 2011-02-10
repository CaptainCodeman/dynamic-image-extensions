using System.Collections.Generic;
using System.ComponentModel;
using Meshellator;
using SoundInTheory.DynamicImage.Caching;

namespace SoundInTheory.DynamicImage
{
	public abstract class SceneSource : DataBoundObject
	{
		public abstract Scene GetScene(ISite site, bool designMode);

		public virtual void PopulateDependencies(List<Dependency> dependencies) { }
	}
}