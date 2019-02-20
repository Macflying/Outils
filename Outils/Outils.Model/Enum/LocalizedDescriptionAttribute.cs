using System;
using System.ComponentModel;
using System.Resources;

namespace Outils.Model.Enum
{
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        ResourceManager _resourceManager;
        string _resourceKey;

        public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            _resourceManager = new ResourceManager(resourceType);
            _resourceKey = resourceKey;
        }

        public override string Description
            => _resourceManager.GetString(_resourceKey) ?? _resourceKey;
    }
}
