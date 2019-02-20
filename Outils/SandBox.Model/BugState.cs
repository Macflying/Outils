using System.ComponentModel;
using Outils.Model.Enum;

namespace SandBox.Model
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum BugState
    {
        [Description("Proposé")]
        Proposed,
        [Description("Ouvert")]
        Opened,
        [Description("Résolu")]
        Resolved,
        [Description("Fermé")]
        Closed,
    }
}
