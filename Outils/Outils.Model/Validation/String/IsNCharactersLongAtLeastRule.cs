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
    public class IsNCharactersLongAtLeastRule : IValidationRule<string>
    {
        private int _length;
        /// <summary>
        /// Message d'erreur si le string est trop court.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Verifie que le string possède au moins N caractère. Uniquement des espaces ne convient pas.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Check(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            return value.Length >= _length;
        }
        /// <summary>
        /// Constructeur d'instance.
        /// </summary>
        /// <param name="length">La longueur minimale pour le string.</param>
        public IsNCharactersLongAtLeastRule(int length)
        {
            _length = length;
        }
    }
}
