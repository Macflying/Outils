using SandBox.ViewModel;
using System.Windows;

namespace SandBox.View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PersonnageViewModel();
        }
    }
}
