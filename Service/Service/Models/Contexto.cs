using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Models
{

    public class Contexto : DbContext
    {
        public Contexto()
            : base("LojaVirtualContext")
        {
            Database.SetInitializer<Contexto>(new CreateDatabaseIfNotExists<Contexto>());
            Database.SetInitializer(new LojaVirtualInitializer());
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }

    public class LojaVirtualInitializer : DropCreateDatabaseAlways<Contexto>
    {
        protected override void Seed(Contexto context)
        {
            IList<Categoria> defaultCategoria = new List<Categoria>();

            defaultCategoria.Add(new Categoria() { Nome = "Móveis", Ativo = true });
            defaultCategoria.Add(new Categoria() { Nome = "Eletrodomésticos", Ativo = true });
            defaultCategoria.Add(new Categoria() { Nome = "Eletrônicos", Ativo = true });

            context.Categorias.AddRange(defaultCategoria);

            base.Seed(context);
        }
    }

}
