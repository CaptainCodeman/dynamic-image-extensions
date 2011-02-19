using System;
using System.ComponentModel;
using System.Globalization;
using SoundInTheory.DynamicImage.Design;
using SoundInTheory.DynamicImage.Util;

namespace SoundInTheory.DynamicImage
{
	[TypeConverter(typeof(Point2DConverter))]
	public class Point2D : DataBoundObject
	{
		public static Point2D Zero
		{
			get { return new Point2D(0, 0); }
		}

		public float X
		{
			get { return (float)(ViewState["X"] ?? 0.0f); }
			set { ViewState["X"] = value; }
		}

		public float Y
		{
			get { return (float)(ViewState["Y"] ?? 0.0f); }
			set { ViewState["Y"] = value; }
		}

		public Point2D(float x, float y)
		{
			X = x;
			Y = y;
		}

		internal string ConvertToString(string format, IFormatProvider provider)
		{
			char numericListSeparator = TokenizerHelper.GetNumericListSeparator(provider);
			return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}", new object[] { numericListSeparator, this.X, this.Y });
		}

		public override string ToString()
		{
			return string.Format("{{X:{0} Y:{1}}}", X, Y);
		}

		public static Point2D Parse(string source)
		{
			IFormatProvider cultureInfo = CultureInfo.InvariantCulture;
			TokenizerHelper helper = new TokenizerHelper(source, cultureInfo);
			string str = helper.NextTokenRequired();
			Point2D pointd = new Point2D(Convert.ToSingle(str, cultureInfo), Convert.ToSingle(helper.NextTokenRequired(), cultureInfo));
			helper.LastTokenRequired();
			return pointd;
		}
	}
}