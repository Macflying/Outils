using Outils.ViewModel;
using Outils.ViewModel.ListViewModel;
using SandBox.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SandBox.View
{
    public class MainViewModel : ListViewModelBase<FailingTestViewModel>
    {
        public ICommand Add => new CommandHandler(Adding_Execute, List.Count < 10);

        public IEnumerable<FailingTestViewModel> ListeStartingData
        {
            get
            {
                return new List<FailingTestViewModel>()
                {
                    new FailingTestViewModel(),
                    new FailingTestViewModel(),
                    new FailingTestViewModel(),
                    new FailingTestViewModel(),
                    new FailingTestViewModel()

                };
            }
        }

        private void Adding_Execute()
        {
            List.Add(new FailingTestViewModel());
            NotifyPropertyChanged(nameof(Add));
        }

        public MainViewModel()
        {
            FailingTestViewModel.Deleting += FailingTestViewModel_Deleting;

            int i = 1;
            foreach (var item in ListeStartingData)
            {
                item.AssociatedBug.Number.Value = i;

                item.FailingClass.Name.Value = $"TestClass {i}";

                item.FailingClass.FailingMethod.Name.Value = $"TestMethod {i}";

                item.FailingClass.FailingMethod.ErrorMessage.Value = $"Error message for testing";

                List.Add(item);

                i++;
            }
        }

        private void FailingTestViewModel_Deleting(object sender, EventArgs e)
        {
            List.Remove((FailingTestViewModel)sender);
        }
    }
}
