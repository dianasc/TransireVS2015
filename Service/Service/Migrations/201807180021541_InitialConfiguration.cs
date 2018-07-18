namespace Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialConfiguration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Quantidade = c.Int(nullable: false),
                        PrecoUnitarioCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecoUnitarioVenda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataAtualizacao = c.DateTime(nullable: false),
                        Categoria_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categorias", t => t.Categoria_ID)
                .Index(t => t.Categoria_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "Categoria_ID", "dbo.Categorias");
            DropIndex("dbo.Produtoes", new[] { "Categoria_ID" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.Categorias");
        }
    }
}
