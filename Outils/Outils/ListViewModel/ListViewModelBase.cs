using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Outils.ViewModel.ListViewModel
{

    public abstract class ListViewModelBase<T> : NotifiableObjectBase
    {
        public ObservableCollection<T> List { get; } = new ObservableCollection<T>();

        public T SelectedItem { get; set; }
    }
}
