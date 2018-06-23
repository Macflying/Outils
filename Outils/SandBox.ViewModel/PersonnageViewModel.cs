using Outils;
using Outils.Model.Validation.String;
using Outils.ViewModel.Validation;
using SandBox.Model;

namespace SandBox.ViewModel
{
    public class PersonnageViewModel : NotifiableObject
    {
        #region Nom
        private ValidatableObject<string> _nom;
        /// <summary>
        /// Le nom du personnage.
        /// </summary>
        public ValidatableObject<string> Nom
        {
            get { return _nom; }
            set { SetField(ref _nom, value); }
        }
        #endregion Nom

        #region Description
        private ValidatableObject<string> _description;
        /// <summary>
        /// Une description du personnage.
        /// </summary>
        public ValidatableObject<string> Description
        {
            get { return _description; }
            set { SetField(ref _description, value); }
        }
        #endregion Description

        public PersonnageViewModel()
        {
            Nom = new ValidatableObject<string>(true);
            Nom.ValidationRules.Add(new IsNotNullOrWhiteSpaceRule() { Message = "Le champ ne peut être laissé vide."});

            Description = new ValidatableObject<string>(true);
            Description.ValidationRules.Add(new IsNCharactersLongAtLeastRule(10) { Message = "Au moins 10 caractères."});
        }
    }
}
