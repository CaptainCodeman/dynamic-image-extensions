using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace SoundInTheory.DynamicImage.Design
{
	public sealed class Point2DConverter : TypeConverter
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
				return Point2D.Parse(source);

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
			if ((destinationType != null) && (value is Point2D))
			{
				Point2D point = (Point2D)value;
				if (destinationType == typeof(InstanceDescriptor))
				{
					ConstructorInfo ci = typeof(Point2D).GetConstructor(new Type[] { typeof(float), typeof(float) });
					return new InstanceDescriptor(ci, new object[] { point.X, point.Y });
				}
				else if (destinationType == typeof(string))
					return point.ConvertToString(null, culture);
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			return new PropertyDescriptorCollection(new[]
			{
				new FieldPropertyDescriptor(typeof (Point2D).GetField("X")),
				new FieldPropertyDescriptor(typeof (Point2D).GetField("Y"))
			});
		}
	}
}