namespace TEMIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabaseSchema3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Casos", "PrecioCaso", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Casos", "PrecioCaso", c => c.String(nullable: false, maxLength: 2));
        }
    }
}
