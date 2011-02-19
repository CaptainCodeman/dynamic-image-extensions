namespace SoundInTheory.DynamicImage.Fluent
{
	public class RenderedLayerBuilder : BaseLayerBuilder<RenderedLayer, RenderedLayerBuilder>
	{
		public RenderedLayerBuilder Width(int width)
		{
			Layer.Width = width;
			return this;
		}

		public RenderedLayerBuilder Height(int height)
		{
			Layer.Height = height;
			return this;
		}

		public RenderedLayerBuilder SourceFileName(string fileName)
		{
			Layer.SourceFileName = fileName;
			return this;
		}

		public RenderedLayerBuilder Lighting(bool enabled)
		{
			Layer.LightingEnabled = enabled;
			return this;
		}
	}
}