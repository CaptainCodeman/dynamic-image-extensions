using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace SoundInTheory.DynamicImage.Design
{
	public sealed class Vector3DCollectionConverter : TypeConverter
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
				return Vector3DCollection.Parse(source);
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
			if ((destinationType != null) && (value is Vector3DCollection))
			{
				Vector3DCollection points = (Vector3DCollection)value;
				if (destinationType == typeof(InstanceDescriptor))
				{
					ConstructorInfo ci = typeof(Vector3DCollection).GetConstructor(new[] { typeof(Vector3D[]) });
					return new InstanceDescriptor(ci, new object[] { points.ToArray() });
				}
				if (destinationType == typeof(string))
					return points.ConvertToString(null, culture);
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}