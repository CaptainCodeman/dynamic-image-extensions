using System.ComponentModel;
using SoundInTheory.DynamicImage.Design;

namespace SoundInTheory.DynamicImage
{
	[TypeConverter(typeof(IndexConverter))]
	public class Index : DataBoundObject
	{
		public int Value
		{
			get { return (int)(ViewState["Value"] ?? 0); }
			set { ViewState["Value"] = value; }
		}

		public Index(int value)
		{
			Value = value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}