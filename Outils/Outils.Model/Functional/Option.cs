using System;
using System.Collections.Generic;
using System.Linq;

namespace Outils.Model.Functional
{
    /// <summary>
    /// Structure encapsulant un objet ou rien.
    /// </summary>
    /// <typeparam name="T">Le type de l'objet à encapsuler.</typeparam>
    public struct Option<T> : IEquatable<Option<T>>
    {
        private IEnumerable<T> _content;

        /// <summary>
        /// True si l'option contient une valeur, false sinon.
        /// </summary>
        public bool HasSome => _content.Any();

        /// <summary>
        /// True si l'option ne contient aucune valeur, false sinon.
        /// </summary>
        public bool HasNone => !_content.Any();

        #region Factory

        private Option(IEnumerable<T> content) => _content = content;

        /// <summary>
        /// Crée une Option contenant <paramref name="value"/> si non-null, None sinon.
        /// </summary>
        /// <param name="value">La valeur à contenir par l'Option.</param>
        /// <returns>Une Option contenant <paramref name="value"/> si non-null, None sinon.</returns>
        public static Option<T> Some(T value) 
            => value != null ?
                new Option<T>(new T[1] { value })
                : None;

        /// <summary>
        /// Une Option sans valeur.
        /// </summary>
        public static Option<T> None => new Option<T>(new T[0]);

        #endregion Factory

        /// <summary>
        /// Effectue une <paramref name="action"/> avec la valeur de l'Option si elle en a une.
        /// </summary>
        /// <param name="action"></param>
        public void Do(Action<T> action)
        {
            if (action == null) return;
            foreach (var item in _content)
                action(item);
        }

        /// <summary>
        /// Retourne l'Option si elle contient une valeur et qu'elle passe le test du <paramref name="predicate"/>.
        /// Retourne None sinon.
        /// </summary>
        /// <param name="predicate">Le test que la valeur de l'Option doit passer si elle existe.</param>
        /// <returns>
        /// L'Option si elle contient une valeur et qu'elle passe le test du <paramref name="predicate"/>.
        /// None sinon.</returns>
        public Option<T> When(Func<T, bool> predicate)
        {
            foreach (var item in _content.Where(predicate))
                return this;
            return None;
        }

        /// <summary>
        /// Réduit l'Option à sa valeur si elle existe, à <paramref name="whenNone"/> sinon.
        /// </summary>
        /// <param name="whenNone">La valeur à retourner si l'option n'a pas de valeur.</param>
        /// <returns>L'Option à sa valeur si elle existe, à <paramref name="whenNone"/> sinon.</returns>
        public T Reduce(T whenNone)
        {
            return HasSome ? _content.First() : whenNone;
        }

        public static implicit operator Option<T>(T value) => Some(value);

        #region Equality

        public override bool Equals(object obj)
        {
            return obj is Option<T> && Equals((Option<T>)obj);
        }

        public bool Equals(Option<T> other)
        {
            if (other == null) return false;
            if (other.HasSome != HasSome) return false;
            if (HasNone) return true;
            return _content.First().Equals(other._content.First());
        }

        public override int GetHashCode()
        {
            if (HasSome)
                return -738640473 + _content.First().GetHashCode();

            return typeof(T).GetHashCode() + 1;
        }

        public static bool operator ==(Option<T> option1, Option<T> option2)
        {
            return option1.Equals(option2);
        }

        public static bool operator !=(Option<T> option1, Option<T> option2)
        {
            return !(option1 == option2);
        }

        #endregion Equality
    }
}