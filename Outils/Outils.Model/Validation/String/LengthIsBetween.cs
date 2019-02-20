using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outils.Model.Validation.String
{
    /// <summary>
    /// Règle vérifiant qu'un string possède au moins N caractères. Uniquement des espaces ne convient pas.
    /// </summary>
    public class LengthIsBetween : IValidationRule<string>
    {
        private int _minLength;
        private int _maxLength;
        /// <summary>
        /// Message d'erreur si le string est trop court.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Vérifie que le string possède au moins N caractère. Uniquement des espaces ne convient pas.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Check(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            return value.Length >= _minLength && value.Length <= _maxLength;
        }
        /// <summary>
        /// Constructeur d'instance.
        /// </summary>
        /// <param name="minLength">La longueur minimale pour le string.</param>
        /// <param name="maxLength">La longueur minimale pour le string.</param>
        public LengthIsBetween(int minLength = 0, int maxLength = int.MaxValue)
        {
            _minLength = minLength;
            _maxLength = maxLength;
        }
    }
}
