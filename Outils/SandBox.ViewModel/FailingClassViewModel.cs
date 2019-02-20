using Outils.ViewModel.Validation;
using System.Collections.ObjectModel;

namespace SandBox.ViewModel
{
    public class FailingClassViewModel
    {
        public ValidatableObject<string> Name { get; } = ValidatableObject<string>.AutoValidatingObject();

        public FailingMethodViewModel FailingMethod { get; } = new FailingMethodViewModel();
    }
}