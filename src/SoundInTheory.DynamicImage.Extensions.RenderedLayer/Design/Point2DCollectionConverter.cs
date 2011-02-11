using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace SoundInTheory.DynamicImage.Design
{
	public sealed class Point2DCollectionConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value == null)
				throw base.GetConvertFromException(value);

			string source = value as string;
			if (source != null)
				return Point2DCollection.Parse(source);
			return base.ConvertFrom(context, culture, value);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
				return true;

			return ((destinationType == typeof(string)) || base.CanConvertTo(context, destinationType));
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if ((destinationType != null) && (value is Point2DCollection))
			{
				Point2DCollection points = (Point2DCollection) value;
				if (destinationType == typeof(InstanceDescriptor))
				{
					ConstructorInfo ci = typeof(Point2DCollection).GetConstructor(new[] { typeof(Point2D[]) });
					return new InstanceDescriptor(ci, new object[] { points.ToArray() });
				}
				if (destinationType == typeof(string))
					return points.ConvertToString(null, culture);
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}