using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outils.Model.Functional
{
    /// <summary>
    /// Classe abstraite étant soit un <see cref="Left{TLeft, TRight}"/> soit un <see cref="Right{TLeft, TRight}"/>.
    /// Par convention, si une erreur doit être transportée, on la transportera dans un <see cref="Right{TLeft, TRight}"/>
    /// </summary>
    /// <typeparam name="TLeft">L'un des type de contenu pouvant être tenu par <see cref="Either{TLeft, TRight}"/>. De préférence le type par "défaut".</typeparam>
    /// <typeparam name="TRight">L'un des type de contenu pouvant être tenu par <see cref="Either{TLeft, TRight}"/>. De préférence le type "Erreur" le cas échéant.</typeparam>
    public abstract class Either<TLeft, TRight>
    {
        /// <summary>
        /// Constructeur implicite vers un <see cref="Left{TLeft, TRight}"/>.
        /// </summary>
        /// <param name="content">Le contenu de Either.</param>
        public static implicit operator Either<TLeft, TRight>(TLeft content) =>
            new Left<TLeft, TRight>(content);

        /// <summary>
        /// Constructeur implicite vers un <see cref="Right{TLeft, TRight}"/>.
        /// </summary>
        /// <param name="content">Le contenu de Either.</param>
        public static implicit operator Either<TLeft, TRight>(TRight content) =>
            new Right<TLeft, TRight>(content);
    }

    public class Left<TLeft, TRight> : Either<TLeft, TRight>
    {
        private TLeft _content;

        public Left(TLeft content)
        {
            _content = content;
        }

        public static implicit operator TLeft(Left<TLeft, TRight> obj) =>
            obj._content;
    }

    public class Right<TLeft, TRight> : Either<TLeft, TRight>
    {
        private TRight _content;

        public Right(TRight content)
        {
            _content = content;
        }

        public static implicit operator TRight(Right<TLeft, TRight> obj) =>
            obj._content;
    }

}
