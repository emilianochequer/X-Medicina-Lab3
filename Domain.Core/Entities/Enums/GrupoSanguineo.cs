using System.ComponentModel;

namespace Domain.Core.Entities.Enums
{
    public enum GrupoSanguineo
    {
        [Description("0+")]
        CeroPositivo = 1,

        [Description("0-")]
        CeroNegativo = 2,

        [Description("A+")]
        APositivo = 3,

        [Description("A-")]
        ANegativo = 4,

        [Description("B+")]
        BPositivo = 5,

        [Description("B-")]
        BNegativo = 6,

        [Description("AB+")]
        ABPositivo = 7,

        [Description("AB-")]
        ABNegativo = 8,
    }
}
