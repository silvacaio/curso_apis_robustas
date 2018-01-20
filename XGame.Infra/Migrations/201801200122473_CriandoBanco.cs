namespace XGame.Infra.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class CriandoBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jogador",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PrimeiroNome = c.String(nullable: false, maxLength: 50, unicode: false),
                        UltimoNome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "index",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: UK_JOGADOR_EMAIL, IsUnique: True }")
                                },
                            }),
                        Senha = c.String(nullable: false, maxLength: 50, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jogo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        Produtora = c.String(maxLength: 100, unicode: false),
                        Distribuidora = c.String(maxLength: 100, unicode: false),
                        Genero = c.String(maxLength: 100, unicode: false),
                        Site = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plataforma",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Plataforma");
            DropTable("dbo.Jogo");
            DropTable("dbo.Jogador",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Email",
                        new Dictionary<string, object>
                        {
                            { "index", "IndexAnnotation: { Name: UK_JOGADOR_EMAIL, IsUnique: True }" },
                        }
                    },
                });
        }
    }
}
