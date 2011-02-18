using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using SoundInTheory.DynamicImage.Design;
using SoundInTheory.DynamicImage.Util;

namespace SoundInTheory.DynamicImage
{
	[TypeConverter(typeof(Point2DCollectionConverter))]
	public class Point2DCollection : CustomStateManagedCollection<Point2D>
	{
		public Point2DCollection()
		{
			
		}

		public Point2DCollection(Point2D[] points)
			: base(points)
		{
			
		}

		public static Point2DCollection Parse(string source)
		{
			IFormatProvider englishUSCulture = CultureInfo.InvariantCulture;
			TokenizerHelper helper = new TokenizerHelper(source, englishUSCulture);
			Point2DCollection pointds = new Point2DCollection();
			while (helper.NextToken())
			{
				Point2D pointd = new Point2D(
					Convert.ToSingle(helper.GetCurrentToken(), englishUSCulture),
					Convert.ToSingle(helper.NextTokenRequired(), englishUSCulture));
				pointds.Add(pointd);
			}
			return pointds;
		}

		internal string ConvertToString(string format, IFormatProvider provider)
		{
			if (this.Count == 0)
			{
				return string.Empty;
			}
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < this.Count; i++)
			{
				builder.AppendFormat(provider, "{0:" + format + "}", new object[] { this[i] });
				if (i != (this.Count - 1))
				{
					builder.Append(" ");
				}
			}
			return builder.ToString();
		}
	}
}