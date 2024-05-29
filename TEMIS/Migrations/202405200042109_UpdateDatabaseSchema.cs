namespace TEMIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabaseSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID_Cliente = c.String(nullable: false, maxLength: 6),
                        PrimNombre = c.String(nullable: false, maxLength: 50),
                        SegNombre = c.String(nullable: false, maxLength: 50),
                        PrimAprellido = c.String(nullable: false, maxLength: 50),
                        SegAprellido = c.String(nullable: false, maxLength: 50),
                        DUI = c.String(nullable: false, maxLength: 10),
                        Client_Edad = c.String(nullable: false, maxLength: 3),
                        Nacionalidad = c.String(nullable: false, maxLength: 50),
                        Ocupacion = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(nullable: false, maxLength: 500),
                        Telefonoo = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID_Cliente);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
