using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using Application.Connection;
using Domain.Base.Entity;
using Infrastructure.Context.Configuration;
using Infrastructure.Context.Initialize;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Infrastructure.Context
{
    public class EfDbContext : IdentityDbContext
    {
        public Dictionary<Type, object> DbSets = new Dictionary<Type, object>();

        public EfDbContext()
            : base(new ConnectionString().Get())
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Database.CommandTimeout = TimeSpan.MaxValue.Milliseconds;

            Database.SetInitializer(new Initialize.InitializerDataBase());
        }


        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            if (DbSets.Keys.Contains(typeof(TEntity)))
            {
                return DbSets[typeof(TEntity)] as IDbSet<TEntity>;
            }
            IDbSet<TEntity> dbSet = base.Set<TEntity>();
            DbSets.Add(typeof(TEntity), dbSet);
            return dbSet;
        }

        /// <summary>
        /// Es el modelBuilder, metodo que se ejecuta para ponerte en contacto con la BD.
        /// Se hizo dinamico al recorrer los el assembly y buscar todos los tipos que hereden de BaseEntity y
        /// a su vez tengan el DataAnnotation [Table] la clase
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove(new PluralizingTableNameConvention());

            var typesToRegisterCore = Assembly.Load("Domain.Core").GetTypes()
                .Where(x => x.BaseType != null && x.BaseType.Name.Contains("BaseEntity"));

            foreach (var type in typesToRegisterCore)
            {
                foreach (var attr in Attribute.GetCustomAttributes(type))
                {
                    if (typeof(TableAttribute).IsAssignableFrom(attr.GetType()))
                    {
                        var table = (TableAttribute)attr;

                        if (table?.Name != null) // verifica si la table y el table.name es null
                            RegisterInvoke(modelBuilder, type, table.Name);
                    }
                }
            }

            ConfigurationContext.ConfiguracionApiFluent(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Invoca con Reflection un metodo que lo transforma en template generico, 
        /// o sea T y luego lo Invoca con el modelBuilder y el string de tabla
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="type"></param>
        /// <param name="table"></param>
        private void RegisterInvoke(DbModelBuilder modelBuilder, Type type, string table)
        {
            var method = this.GetType().GetMethod("RegisterEntity", BindingFlags.NonPublic | BindingFlags.Instance);
            var generic = method.MakeGenericMethod(type);
            generic.Invoke(this, new object[] { modelBuilder, table });
        }

        /// <summary>
        /// El metodo se llama en tiempo de ejecucion no tocarlo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelBuilder"></param>
        /// <param name="table"></param>
        private void RegisterEntity<T>(DbModelBuilder modelBuilder, string table) where T : class
        {
            modelBuilder.Entity<T>().ToTable(table);
        }
    }
}
