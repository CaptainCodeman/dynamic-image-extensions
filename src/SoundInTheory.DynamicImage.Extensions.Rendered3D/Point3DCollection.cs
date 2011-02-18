using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using SoundInTheory.DynamicImage.Design;
using SoundInTheory.DynamicImage.Util;

namespace SoundInTheory.DynamicImage
{
	[TypeConverter(typeof(Point3DCollectionConverter))]
	public class Point3DCollection : CustomStateManagedCollection<Point3D>
	{
		public Point3DCollection()
		{
			
		}

		public Point3DCollection(Point3D[] points)
			: base(points)
		{
			
		}

		public static Point3DCollection Parse(string source)
		{
			IFormatProvider englishUSCulture = CultureInfo.InvariantCulture;
			TokenizerHelper helper = new TokenizerHelper(source, englishUSCulture);
			Point3DCollection pointds = new Point3DCollection();
			while (helper.NextToken())
			{
				Point3D pointd = new Point3D(
					Convert.ToSingle(helper.GetCurrentToken(), englishUSCulture),
					Convert.ToSingle(helper.NextTokenRequired(), englishUSCulture),
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