using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using SoundInTheory.DynamicImage.Design;
using SoundInTheory.DynamicImage.Util;

namespace SoundInTheory.DynamicImage
{
	[TypeConverter(typeof(IndexCollectionConverter))]
	public class IndexCollection : CustomStateManagedCollection<Index>
	{
		public IndexCollection()
		{

		}

		public IndexCollection(Index[] collection)
			: base(collection)
		{

		}

		internal string ConvertToString(string format, IFormatProvider provider)
		{
			if (this.Count == 0)
				return string.Empty;
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < this.Count; i++)
			{
				builder.AppendFormat(provider, "{0:" + format + "}", new object[] { this[i] });
				if (i != (this.Count - 1))
					builder.Append(" ");
			}
			return builder.ToString();
		}

		public static IndexCollection Parse(string source)
		{
			IFormatProvider cultureInfo = CultureInfo.InvariantCulture;
			TokenizerHelper helper = new TokenizerHelper(source, cultureInfo);
			IndexCollection ints = new IndexCollection();
			while (helper.NextToken())
			{
				int num = Convert.ToInt32(helper.GetCurrentToken(), cultureInfo);
				ints.Add(new Index(num));
			}
			return ints;
		}
	}
}