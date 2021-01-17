namespace ProvaTecnica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalizaPessoa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pessoas", "DataNascimento", c => c.DateTime(nullable: false));
            AddColumn("dbo.Pessoas", "Cidade", c => c.String());
            AddColumn("dbo.Pessoas", "Estado", c => c.String());
            AddColumn("dbo.Pessoas", "Cpf", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pessoas", "Cpf");
            DropColumn("dbo.Pessoas", "Estado");
            DropColumn("dbo.Pessoas", "Cidade");
            DropColumn("dbo.Pessoas", "DataNascimento");
        }
    }
}
