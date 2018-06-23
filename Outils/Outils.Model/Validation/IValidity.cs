namespace Outils.Model.Validation
{
    /// <summary>
    /// Contrat permettant de connaitre l'état de validité d'un objet.
    /// </summary>
    public interface IValidity
    {
        /// <summary>
        /// L'objet est-il valide ?
        /// </summary>
        bool IsValid { get; }
    }
}
