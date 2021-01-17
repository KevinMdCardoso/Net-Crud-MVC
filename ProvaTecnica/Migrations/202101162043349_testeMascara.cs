namespace ProvaTecnica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testeMascara : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pessoas", "Cpf", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pessoas", "Cpf", c => c.String());
        }
    }
}
