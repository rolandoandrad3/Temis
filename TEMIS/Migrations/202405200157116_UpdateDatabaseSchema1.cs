namespace TEMIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabaseSchema1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Casos",
                c => new
                    {
                        ID_Case = c.String(nullable: false, maxLength: 6),
                        Caso_Nombre = c.String(nullable: false, maxLength: 50),
                        Tipo_Facturacion = c.String(nullable: false, maxLength: 50),
                        PrecioCaso = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.ID_Case);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Casos");
        }
    }
}
