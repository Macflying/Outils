using System;
using System.ComponentModel;
using System.Reflection;

namespace Outils.Model.Enum
{
    /// <summary>
    /// Convertisseur pour représenter un enum par sa description si elle existe.
    /// </summary>
    public class EnumDescriptionTypeConverter : EnumConverter
    {
        /// <summary>
        /// Constructeur d'instance.
        /// </summary>
        /// <param name="type">Le type de l'énuméré.</param>
        public EnumDescriptionTypeConverter(Type type) : base(type) { }

        /// <summary>
        /// Convertit un enum vers sa description si elle existe sinon appel à ToString().
        /// </summary>
        /// <param name="context">Non utilisé.</param>
        /// <param name="culture">Information sur la culture.</param>
        /// <param name="value">La valeur de l'enum.</param>
        /// <param name="destinationType">Non utilisé.</param>
        /// <returns>Une chaîne de caractère représentant l'enum.</returns>
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string))
                return base.ConvertTo(context, culture, value, destinationType);

            if (value == null)
                return string.Empty;
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi == null)
                return string.Empty;

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 && !string.IsNullOrEmpty(attributes[0].Description)
                ? attributes[0].Description.ToString(culture)
                : value.ToString();
        }
    }
}