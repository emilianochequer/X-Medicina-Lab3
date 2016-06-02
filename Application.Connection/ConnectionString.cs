namespace Application.Connection
{
    public class ConnectionString
    {
        private const string Usuario = @"sa";
        private const string Password = @"Desarroll0";

        public virtual string Server { get; set; } = @"DIMEI5-CDAUD";
        public virtual string DataBase { get; set; } = @"MEDICDB";

        public virtual string Get()
        {
            return $"Data Source={Server};Initial Catalog={DataBase};User Id={Usuario};Password={Password};";
        }
    }
}
