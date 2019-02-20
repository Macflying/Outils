using Outils.ViewModel.Validation;

namespace SandBox.ViewModel
{
    public class FailingMethodViewModel
    {
        public ValidatableObject<string> Name { get; } = ValidatableObject<string>.AutoValidatingObject();

        public ValidatableObject<string> ErrorMessage { get; } = ValidatableObject<string>.AutoValidatingObject();
    }
}