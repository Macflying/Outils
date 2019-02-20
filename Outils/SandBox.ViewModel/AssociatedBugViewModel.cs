using Outils.ViewModel;
using Outils.ViewModel.Validation;
using SandBox.Model;
using System.Collections.Generic;

namespace SandBox.ViewModel
{
    public class AssociatedBugViewModel : NotifiableObjectBase
    {
        public ValidatableObject<int> Number { get; } = ValidatableObject<int>.AutoValidatingObject();

        public ValidatableObject<string> Link { get; } = ValidatableObject<string>.AutoValidatingObject();

        private BugState _state;

        public BugState State
        {
            get { return _state; }
            set { SetField(ref _state, value); }
        }

        public BugState[] LisBugStates => (BugState[])typeof(BugState).GetEnumValues();
    }
}