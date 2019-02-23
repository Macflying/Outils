using System;
using System.ComponentModel;
using System.Resources;

namespace Outils.Model.Enum
{
    /// <summary>
    /// Attribut permettant de définir une description localisée.
    /// </summary>
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        private ResourceManager _resourceManager;
        private readonly string _resourceKey;

        /// <summary>
        /// Constructeur d'instance.
        /// </summary>
        /// <param name="resourceKey">Clef de la ressource.</param>
        /// <param name="resourceType">Type permettant de retrouver la ressource via <see cref="ResourceManager"/>.</param>
        public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            _resourceManager = new ResourceManager(resourceType);
            _resourceKey = resourceKey;
        }

        /// <summary>
        /// Retourne la description stockée dans la ressource
        /// </summary>
        public override string Description
            => _resourceManager.GetString(_resourceKey) ?? _resourceKey;
    }
}