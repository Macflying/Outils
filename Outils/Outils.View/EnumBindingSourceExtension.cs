using System;
using System.Windows.Markup;

namespace Outils.View
{
    /// <summary>
    /// Permet de fournir un source de donnée à partir d'un type enum (pour un ItemsSource par exemple)
    /// </summary>
    [MarkupExtensionReturnType(typeof(Array))]
    public class EnumBindingSourceExtension : MarkupExtension
    {
        private Type _enumType;

        /// <summary>
        /// Récupère le type de l'énuméré.
        /// </summary>
        public Type EnumType
        {
            get { return _enumType; }
            set
            {
                if (value == null)
                    return;
                if (value == _enumType)
                    return;

                Type enumType = Nullable.GetUnderlyingType(value) ?? value;
                if (!enumType.IsEnum)
                    throw new ArgumentException("Type must be for an Enum.");

                _enumType = value;
            }
        }

        /// <summary>
        /// Constructeur vide privé.
        /// </summary>
        private EnumBindingSourceExtension() { }

        /// <summary>
        /// Constructeur d'instance.
        /// </summary>
        /// <param name="enumType">Le type de l'énuméré.</param>
        public EnumBindingSourceExtension(Type enumType)
        {
            EnumType = enumType;
        }

        /// <summary>
        /// Produit un tableau représentant les valeurs de l'énuméré.
        /// </summary>
        /// <param name="serviceProvider">Non utilisé.</param>
        /// <returns>Un tableau représentant les valeurs de l'énuméré.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_enumType == null)
                throw new InvalidOperationException("The EnumType must be specified.");

            Type actualEnumType = Nullable.GetUnderlyingType(_enumType) ?? _enumType;
            Array enumValues = Enum.GetValues(actualEnumType);

            if (actualEnumType == _enumType)
                return enumValues;

            Array tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
            enumValues.CopyTo(tempArray, 1);
            return tempArray;
        }
    }
}