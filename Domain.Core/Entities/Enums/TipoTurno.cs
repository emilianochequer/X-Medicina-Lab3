using System.ComponentModel;

namespace Domain.Core.Entities.Enums
{
    public enum TipoTurno
    {
        [Description(@"Turno Mañana")]
        TurnoMañana = 1,

        [Description(@"Turno Tarde")]
        TurnoTarde = 2,

        [Description(@"Turno Noche")]
        TurnoNoche = 3,

        [Description(@"Turno Completo")]
        TurnoCompleto = 4,
    }
}
