using System.Data;

namespace Domain.Base.Entity
{
    public class BaseParametroSP
    {
        public string Nombre { get; set; }
        public DbType TipoParametro { get; set; }
        public object Valor { get; set; }
        public ParameterDirection Direccion { get; set; }
    }
}
