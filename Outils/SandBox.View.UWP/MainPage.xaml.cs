using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SandBox.View.UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            listBox.ItemsSource = new ObservableCollection<Personnage>()
            {
                new Personnage("zroglub", "l'impitoyable"),
                new Personnage("Cloé", "Milbor"),
                new Personnage("Arnaud", "Milbor"),
                new Personnage("Léo", "Milbor")
            };
        }

        private class Personnage
        {
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public Personnage(string nom, string prenom)
            {
                Nom = nom;
                Prenom = prenom;
            }
        }
    }
}
