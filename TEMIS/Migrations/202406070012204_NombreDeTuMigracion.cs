namespace TEMIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NombreDeTuMigracion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Casos", "PrecioCaso", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Casos", "PrecioCaso", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
