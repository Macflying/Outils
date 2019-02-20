using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Outils.ViewModel
{
    /// <summary>
    /// Implementation pour INotfyPropertyChanged.
    /// </summary>
    public abstract class NotifiableObjectBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Méthode lançant PropertyChanged pour une propriété.
        /// </summary>
        /// <param name="propertyName">Le nom de la propriété dont on souhaite notifier un changement.</param>
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Met à jour la valeur d'une propriété et lance PropertyChanged.
        /// </summary>
        /// <typeparam name="T">Le type de la propriété à valuer.</typeparam>
        /// <param name="field">Le champs correspondant portant la valeur de la propriété.</param>
        /// <param name="value">La valeur à affécter.</param>
        /// <param name="propertyName">Le nom de la propriété</param>
        /// <returns>true si la propriété a été modifiée, false sinon.</returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            NotifyPropertyChanged(propertyName);
            return true;
        }
    }
}
