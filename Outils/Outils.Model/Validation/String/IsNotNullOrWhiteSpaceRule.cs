using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outils.Model.Validation.String
{
    /// <summary>
    /// Règle vérifiant qu'un string n'est ni null, ni vide ou composé uniquement d'espace.
    /// </summary>
    public class IsNotNullOrWhiteSpaceRule : IValidationRule<string>
    {
        /// <summary>
        /// Message d'erreur en cas de string ne respectant pas la règle.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Vérifie si un string n'est ni null, ni vide ou composé uniquement d'espace.
        /// </summary>
        /// <param name="value">La valeur à tester</param>
        /// <returns>true si le string est valide, false sinon.</returns>
        public bool Check(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
