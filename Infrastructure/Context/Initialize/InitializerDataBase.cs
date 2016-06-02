using System.Data.Entity;

namespace Infrastructure.Context.Initialize
{
    public class InitializerDataBase : CreateDatabaseIfNotExists<EfDbContext>
    {
        protected override void Seed(EfDbContext context)
        {
            InitializeTablaCrecimiento.Cargar(context);

            base.Seed(context);
        }
    }
}
