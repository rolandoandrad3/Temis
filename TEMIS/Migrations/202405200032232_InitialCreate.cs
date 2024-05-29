namespace TEMIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abogados",
                c => new
                    {
                        ID_Abogados = c.String(nullable: false, maxLength: 6),
                        NombreAbogado = c.String(nullable: false, maxLength: 50),
                        ApellidosAbogado = c.String(nullable: false, maxLength: 50),
                        DUIAbogado = c.String(nullable: false, maxLength: 10),
                        EspecialidadAbogado = c.String(nullable: false, maxLength: 20),
                        TelefonoAbogado = c.String(nullable: false, maxLength: 15),
                        EmailAbogado = c.String(nullable: false, maxLength: 50),
                        CSJ = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID_Abogados);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Abogados");
        }
    }
}
