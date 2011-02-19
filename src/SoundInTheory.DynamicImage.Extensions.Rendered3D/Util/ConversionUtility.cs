using Nexus;

namespace SoundInTheory.DynamicImage.Util
{
	internal static class ConversionUtility
	{
		public static ColorRgbF ToNexusColorRgbF(System.Windows.Media.Color c)
		{
			return ColorRgbF.FromRgbColor(Color.FromArgb(c.A, c.R, c.G, c.B));
		}
	}
}