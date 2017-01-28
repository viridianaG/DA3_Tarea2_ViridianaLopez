namespace Practica1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2damigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        productoID = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.productoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Productoes");
        }
    }
}
