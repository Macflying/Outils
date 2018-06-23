namespace Outils.Model.Validation
{
    /// <summary>
    /// Contrat pour vérifier qu'un objet vérifie une règle.
    /// </summary>
    /// <typeparam name="T">Le type de l'objet à vérifier.</typeparam>
    public interface IValidationRule<in T>
    {
        /// <summary>
        /// Message lié à la validation (typiquement, le message d'erreur à afficher).
        /// </summary>
        string Message { get; }
        /// <summary>
        /// Règle de validation pour un objet.
        /// </summary>
        /// <param name="value">L'objet à valider.</param>
        /// <returns>true si l'objet est valide, false sinon.</returns>
        bool Check(T value);
    }
}
