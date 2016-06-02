using System.ComponentModel;

namespace Domain.Core.Entities.Enums
{
    public enum DiaDeLaSemana
    {
        [Description("Lunes")]
        Monday = 1,

        [Description("Martes")]
        Tuesday = 2,

        [Description("Miércoles")]
        Wednesday = 3,

        [Description("Jueves")]
        Thursday = 4,

        [Description("Viernes")]
        Friday = 5,

        [Description("Sábado")]
        Saturday = 6,

        [Description("Domingo")]
        Sunday = 7
    }
}
