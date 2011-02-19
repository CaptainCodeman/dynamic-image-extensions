using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using SoundInTheory.DynamicImage.Design;
using SoundInTheory.DynamicImage.Util;

namespace SoundInTheory.DynamicImage
{
	[TypeConverter(typeof(Vector3DCollectionConverter))]
	public class Vector3DCollection : CustomStateManagedCollection<Vector3D>
	{
		public Vector3DCollection()
		{
			
		}

		public Vector3DCollection(Vector3D[] points)
			: base(points)
		{
			
		}

		public static Vector3DCollection Parse(string source)
		{
			IFormatProvider englishUSCulture = CultureInfo.InvariantCulture;
			TokenizerHelper helper = new TokenizerHelper(source, englishUSCulture);
			Vector3DCollection pointds = new Vector3DCollection();
			while (helper.NextToken())
			{
				Vector3D pointd = new Vector3D(
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