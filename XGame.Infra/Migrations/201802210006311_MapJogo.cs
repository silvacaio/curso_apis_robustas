namespace XGame.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapJogo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jogo", "Nome", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Jogo", "Descricao", c => c.String(nullable: false, maxLength: 255, unicode: false));
            AlterColumn("dbo.Jogo", "Produtora", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Jogo", "Distribuidora", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Jogo", "Genero", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Jogo", "Site", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jogo", "Site", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Jogo", "Genero", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Jogo", "Distribuidora", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Jogo", "Produtora", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Jogo", "Descricao", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Jogo", "Nome", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
