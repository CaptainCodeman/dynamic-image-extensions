using System;
using System.ComponentModel;
using System.Globalization;
using SoundInTheory.DynamicImage.Design;
using SoundInTheory.DynamicImage.Util;

namespace SoundInTheory.DynamicImage
{
	[TypeConverter(typeof(Vector3DConverter))]
	public class Vector3D : DataBoundObject
	{
		public static Vector3D Forward
		{
			get { return new Vector3D(0, 0, -1); }
		}

		public static Vector3D Up
		{
			get { return new Vector3D(0, 1, 0); }
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

		public float Z
		{
			get { return (float)(ViewState["Z"] ?? 0.0f); }
			set { ViewState["Z"] = value; }
		}

		public Vector3D(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		internal string ConvertToString(string format, IFormatProvider provider)
		{
			char numericListSeparator = TokenizerHelper.GetNumericListSeparator(provider);
			return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}{0}{3:" + format + "}", new object[] { numericListSeparator, this.X, this.Y, this.Z });
		}

		public override string ToString()
		{
			return string.Format("{{X:{0} Y:{1} Z:{2}}}", X, Y, Z);
		}

		public static Vector3D Parse(string source)
		{
			IFormatProvider cultureInfo = CultureInfo.InvariantCulture;
			TokenizerHelper helper = new TokenizerHelper(source, cultureInfo);
			string str = helper.NextTokenRequired();
			Vector3D pointd = new Vector3D(Convert.ToSingle(str, cultureInfo), Convert.ToSingle(helper.NextTokenRequired(), cultureInfo), Convert.ToSingle(helper.NextTokenRequired(), cultureInfo));
			helper.LastTokenRequired();
			return pointd;
		}
	}
}