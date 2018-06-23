using Outils.Model.Validation;
using System.Collections.Generic;
using System.Linq;

namespace Outils.ViewModel.Validation
{
    /// <summary>
    /// Classe permettant de notifier au visuel l'état de validation d'un objet.
    /// </summary>
    /// <typeparam name="T">Le type de l'objet pouvant être validé.</typeparam>
    public class ValidatableObject<T> : NotifiableObject, IValidity
    {
        #region IsValid
        private bool _isValid;
        /// <summary>
        /// L'objet est-il valide ?
        /// </summary>
        public bool IsValid
        {
            get { return _isValid; }
            set { SetField(ref _isValid, value); }
        }
        #endregion IsValid

        #region Value
        private T _innerValue;
        /// <summary>
        /// La valeur de l'objet.
        /// </summary>
        public T Value
        {
            get { return _innerValue; }
            set { if (SetField(ref _innerValue, value) && AutoValidation) Validate(); }
        }
        #endregion Value

        /// <summary>
        /// Liste des règles de validation pour l'objet.
        /// </summary>
        public List<IValidationRule<T>> ValidationRules { get; } = new List<IValidationRule<T>>();

        #region Errors
        private List<string> _errors = new List<string>();
        /// <summary>
        /// La liste des messages d'erreurs correspondant aux règles non-vérifiées par l'objet.
        /// </summary>
        public List<string> Errors
        {
            get => _errors;
            set { if (SetField(ref _errors, value))
                    NotifyPropertyChanged(nameof(FirstError)); }
        }
        public string FirstError { get { return Errors?.FirstOrDefault(); } }
        #endregion Errors

        /// <summary>
        /// Faut-il valider l'objet à chaque modification ?
        /// </summary>
        public bool AutoValidation { get; set; }

        /// <summary>
        /// Constructeur d'instance.
        /// </summary>
        /// <param name="autoValidation">Faut-il valider l'objet à chaque modification ?</param>
        public ValidatableObject(bool autoValidation)
        {
            AutoValidation = autoValidation;
        }

        /// <summary>
        /// Valide si l'objet passe chaque règles de validation.
        /// </summary>
        /// <returns>true si l'objet est valide pour toutes les règles de validation, false sinon.</returns>
        public bool Validate()
        {
            Errors.Clear();
            Errors = ValidationRules.Where(v => !v.Check(Value))
                    .Select(v => v.Message).ToList();
            IsValid = !Errors.Any();

            return IsValid;
        }
    }
}
