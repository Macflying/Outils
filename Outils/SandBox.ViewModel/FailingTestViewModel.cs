using Outils.ViewModel;
using Outils.ViewModel.ListViewModel;
using System;
using System.Windows.Input;

namespace SandBox.ViewModel
{
    public class FailingTestViewModel : NotifiableObjectBase
    {
        public FailingClassViewModel FailingClass { get; } = new FailingClassViewModel();

        public AssociatedBugViewModel AssociatedBug { get; } = new AssociatedBugViewModel();

        public static event EventHandler Deleting;
        public ICommand Delete => new CommandHandler(DeleteFailingTestEntry_Execute, true);
        private void DeleteFailingTestEntry_Execute() => Deleting?.Invoke(this, null);
    }
}
