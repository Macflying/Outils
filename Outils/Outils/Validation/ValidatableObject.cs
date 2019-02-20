using Outils.Model.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Outils.ViewModel.Validation
{
    /// <summary>
    /// Classe permettant de notifier au visuel l'état de validation d'un objet.
    /// </summary>
    /// <typeparam name="T">Le type de l'objet pouvant être validé.</typeparam>
    public class ValidatableObject<T> : NotifiableObjectBase, IValidity, IEquatable<ValidatableObject<T>>
        where T : IEquatable<T>
    {
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
        /// Faut-il valider l'objet à chaque modification ?
        /// </summary>
        private bool AutoValidation { get; }

        #region IsValid

        private bool _isValid = true;

        /// <summary>
        /// L'objet est-il valide ?
        /// </summary>
        public bool IsValid
        {
            get { return _isValid; }
            private set { SetField(ref _isValid, value); }
        }

        #endregion IsValid

        /// <summary>
        /// Liste des règles de validation pour l'objet.
        /// </summary>
        public List<IValidationRule<T>> ValidationRules { get; } = new List<IValidationRule<T>>();

        #region Errors

        private List<string> _errors = new List<string>();

        /// <summary>
        /// La liste des messages d'erreurs correspondant aux règles non-vérifiées par l'objet.
        /// </summary>
        public ReadOnlyCollection<string> Errors
        {
            get; private set;
        }

        public string FirstError { get { return Errors?.FirstOrDefault(); } }

        #endregion Errors

        #region Factory

        /// <summary>
        /// Constructeur d'instance.
        /// </summary>
        /// <param name="autoValidation">Faut-il valider l'objet à chaque modification ?</param>
        private ValidatableObject(bool autoValidation)
        {
            AutoValidation = autoValidation;
        }

        /// <summary>
        /// Construit un ValidatableObject qui validera la valeur à chaque modification de cette dernière.
        /// </summary>
        /// <param name="validationRules">Les règle de validation de <list type="'objet."</param>
        /// <returns>Un ValidatableObject qui validera la valeur à chaque modification de cette dernière.</returns>
        public static ValidatableObject<T> AutoValidatingObject(IEnumerable<IValidationRule<T>> validationRules = null)
        {
            var vo = new ValidatableObject<T>(true);
            if (validationRules != null)
                vo.ValidationRules.AddRange(validationRules);
            return vo;
        }

        /// <summary>
        /// Construit un ValidatableObject qu'il faut valider manuellement avec <see cref="Validate"/>.
        /// </summary>
        /// <param name="validationRules">Les règle de validation de <list type="'objet."</param>
        /// <returns>Un ValidatableObject qu'il faut valider manuellement avec <see cref="Validate"/>.</returns>
        public static ValidatableObject<T> ManuallyValidatingObject(IEnumerable<IValidationRule<T>> validationRules = null)
        {
            var vo = new ValidatableObject<T>(false);
            if (validationRules != null)
            vo.ValidationRules.AddRange(validationRules);
            return vo;
        }

        #endregion Factory

        /// <summary>
        /// Valide si l'objet passe chaque règles de validation.
        /// </summary>
        /// <returns>true si l'objet est valide pour toutes les règles de validation, false sinon.</returns>
        public bool Validate()
        {
            Errors = new ReadOnlyCollection<string>
                    (ValidationRules.Where(v => !v.Check(Value))
                    .Select(v => v.Message).ToList());

            NotifyPropertyChanged(nameof(Errors));
            NotifyPropertyChanged(nameof(FirstError));

            IsValid = !Errors.Any();

            return IsValid;
        }

        #region Equality

        public static bool operator !=(ValidatableObject<T> vo1, ValidatableObject<T> vo2)
        {
            return !(vo1 == vo2);
        }

        public static bool operator ==(ValidatableObject<T> vo1, ValidatableObject<T> vo2)
        {
            if ((object)vo1 == null || (object)vo2 == null)
                return Object.Equals(vo1, vo2);
            return vo1.Equals(vo2);
        }

        /// <summary>
        /// Vérifie l'égalité.
        /// </summary>
        /// <param name="obj">Objet à comparer avec this.</param>
        /// <returns>true si obj est égal à this, false sinon.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            var objAsVO = obj as ValidatableObject<T>;

            return Equals(objAsVO);
        }

        /// <summary>
        /// Vérifie l'égalité.
        /// </summary>
        /// <param name="other">Objet à comparer avec this.</param>
        /// <returns>true si other est égal à this, false sinon.</returns>
        public bool Equals(ValidatableObject<T> other)
        {
            #region Comparaison sur Value

            if (other == null) return false;
            if (!other.Value.Equals(Value)) return false;

            #endregion Comparaison sur Value

            #region Comparaison sur les règles de validation

            if (other.ValidationRules == null && ValidationRules == null) return true;
            if (other.ValidationRules.Count == 0 && ValidationRules.Count == 0) return true;
            if (other.ValidationRules.Count != ValidationRules.Count) return false;
            if (!other.ValidationRules.All(ValidationRules.Contains)) return false;

            #endregion Comparaison sur les règles de validation

            return true;
        }

        /// <summary>
        /// HashCode pour un ValidatableObject.
        /// </summary>
        /// <returns>HashCode pour un ValidatableObject.</returns>
        public override int GetHashCode()
        {
            int hash = 1;
            foreach (var item in ValidationRules)
                hash *= item.GetHashCode();

            return Value.GetHashCode() ^ hash;
        }
        #endregion Equality

        /// <summary>
        /// Affichage de l'objet sous-jasent.
        /// </summary>
        /// <returns>Un string représentant l'objet sous-jasent.</returns>
        public override string ToString()
        {
            return Value?.ToString();
        }

        /// <summary>
        /// Conversion implicite vers l'objet sous-jasent.
        /// </summary>
        /// <param name="vo">this</param>
        public static implicit operator T(ValidatableObject<T> vo) => vo.Value;
    }
}