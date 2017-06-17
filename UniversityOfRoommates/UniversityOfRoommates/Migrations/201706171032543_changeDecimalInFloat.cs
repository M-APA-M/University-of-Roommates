namespace UniversityOfRoommates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDecimalInFloat : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Affittoes", new[] { "idStanza", "nomeCasa", "longitude", "latitude" }, "dbo.Stanzas");
            DropForeignKey("dbo.FotoCasas", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.Casas");
            DropForeignKey("dbo.Stanzas", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.Casas");
            DropForeignKey("dbo.GestioneCasas", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.Casas");
            DropForeignKey("dbo.Eventoes", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.GestioneCasas");
            DropIndex("dbo.Affittoes", new[] { "idStanza", "nomeCasa", "longitude", "latitude" });
            DropIndex("dbo.Stanzas", new[] { "nomeCasa", "longitude", "latitude" });
            DropIndex("dbo.FotoCasas", new[] { "nomeCasa", "longitude", "latitude" });
            DropIndex("dbo.Eventoes", new[] { "nomeCasa", "longitude", "latitude" });
            DropIndex("dbo.GestioneCasas", new[] { "nomeCasa", "longitude", "latitude" });
            DropPrimaryKey("dbo.Affittoes");
            DropPrimaryKey("dbo.Stanzas");
            DropPrimaryKey("dbo.Casas");
            DropPrimaryKey("dbo.FotoCasas");
            DropPrimaryKey("dbo.Eventoes");
            DropPrimaryKey("dbo.GestioneCasas");
            AlterColumn("dbo.Affittoes", "longitude", c => c.Single(nullable: false));
            AlterColumn("dbo.Affittoes", "latitude", c => c.Single(nullable: false));
            AlterColumn("dbo.Stanzas", "longitude", c => c.Single(nullable: false));
            AlterColumn("dbo.Stanzas", "latitude", c => c.Single(nullable: false));
            AlterColumn("dbo.Casas", "longitudine", c => c.Single(nullable: false));
            AlterColumn("dbo.Casas", "latitudine", c => c.Single(nullable: false));
            AlterColumn("dbo.FotoCasas", "longitude", c => c.Single(nullable: false));
            AlterColumn("dbo.FotoCasas", "latitude", c => c.Single(nullable: false));
            AlterColumn("dbo.Eventoes", "longitude", c => c.Single(nullable: false));
            AlterColumn("dbo.Eventoes", "latitude", c => c.Single(nullable: false));
            AlterColumn("dbo.GestioneCasas", "longitude", c => c.Single(nullable: false));
            AlterColumn("dbo.GestioneCasas", "latitude", c => c.Single(nullable: false));
            AddPrimaryKey("dbo.Affittoes", new[] { "idStanza", "nomeCasa", "longitude", "latitude", "UserName" });
            AddPrimaryKey("dbo.Stanzas", new[] { "idStanza", "nomeCasa", "longitude", "latitude" });
            AddPrimaryKey("dbo.Casas", new[] { "nomeCasa", "longitudine", "latitudine" });
            AddPrimaryKey("dbo.FotoCasas", new[] { "nomeCasa", "longitude", "latitude", "idFoto" });
            AddPrimaryKey("dbo.Eventoes", new[] { "nomeCasa", "longitude", "latitude", "idEvento" });
            AddPrimaryKey("dbo.GestioneCasas", new[] { "nomeCasa", "longitude", "latitude" });
            CreateIndex("dbo.Affittoes", new[] { "idStanza", "nomeCasa", "longitude", "latitude" });
            CreateIndex("dbo.Stanzas", new[] { "nomeCasa", "longitude", "latitude" });
            CreateIndex("dbo.FotoCasas", new[] { "nomeCasa", "longitude", "latitude" });
            CreateIndex("dbo.Eventoes", new[] { "nomeCasa", "longitude", "latitude" });
            CreateIndex("dbo.GestioneCasas", new[] { "nomeCasa", "longitude", "latitude" });
            AddForeignKey("dbo.Affittoes", new[] { "idStanza", "nomeCasa", "longitude", "latitude" }, "dbo.Stanzas", new[] { "idStanza", "nomeCasa", "longitude", "latitude" }, cascadeDelete: true);
            AddForeignKey("dbo.FotoCasas", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.Casas", new[] { "nomeCasa", "longitudine", "latitudine" }, cascadeDelete: true);
            AddForeignKey("dbo.Stanzas", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.Casas", new[] { "nomeCasa", "longitudine", "latitudine" }, cascadeDelete: true);
            AddForeignKey("dbo.GestioneCasas", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.Casas", new[] { "nomeCasa", "longitudine", "latitudine" });
            AddForeignKey("dbo.Eventoes", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.GestioneCasas", new[] { "nomeCasa", "longitude", "latitude" }, cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eventoes", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.GestioneCasas");
            DropForeignKey("dbo.GestioneCasas", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.Casas");
            DropForeignKey("dbo.Stanzas", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.Casas");
            DropForeignKey("dbo.FotoCasas", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.Casas");
            DropForeignKey("dbo.Affittoes", new[] { "idStanza", "nomeCasa", "longitude", "latitude" }, "dbo.Stanzas");
            DropIndex("dbo.GestioneCasas", new[] { "nomeCasa", "longitude", "latitude" });
            DropIndex("dbo.Eventoes", new[] { "nomeCasa", "longitude", "latitude" });
            DropIndex("dbo.FotoCasas", new[] { "nomeCasa", "longitude", "latitude" });
            DropIndex("dbo.Stanzas", new[] { "nomeCasa", "longitude", "latitude" });
            DropIndex("dbo.Affittoes", new[] { "idStanza", "nomeCasa", "longitude", "latitude" });
            DropPrimaryKey("dbo.GestioneCasas");
            DropPrimaryKey("dbo.Eventoes");
            DropPrimaryKey("dbo.FotoCasas");
            DropPrimaryKey("dbo.Casas");
            DropPrimaryKey("dbo.Stanzas");
            DropPrimaryKey("dbo.Affittoes");
            AlterColumn("dbo.GestioneCasas", "latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.GestioneCasas", "longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Eventoes", "latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Eventoes", "longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FotoCasas", "latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FotoCasas", "longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Casas", "latitudine", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Casas", "longitudine", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Stanzas", "latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Stanzas", "longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Affittoes", "latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Affittoes", "longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddPrimaryKey("dbo.GestioneCasas", new[] { "nomeCasa", "longitude", "latitude" });
            AddPrimaryKey("dbo.Eventoes", new[] { "nomeCasa", "longitude", "latitude", "idEvento" });
            AddPrimaryKey("dbo.FotoCasas", new[] { "nomeCasa", "longitude", "latitude", "idFoto" });
            AddPrimaryKey("dbo.Casas", new[] { "nomeCasa", "longitudine", "latitudine" });
            AddPrimaryKey("dbo.Stanzas", new[] { "idStanza", "nomeCasa", "longitude", "latitude" });
            AddPrimaryKey("dbo.Affittoes", new[] { "idStanza", "nomeCasa", "longitude", "latitude", "UserName" });
            CreateIndex("dbo.GestioneCasas", new[] { "nomeCasa", "longitude", "latitude" });
            CreateIndex("dbo.Eventoes", new[] { "nomeCasa", "longitude", "latitude" });
            CreateIndex("dbo.FotoCasas", new[] { "nomeCasa", "longitude", "latitude" });
            CreateIndex("dbo.Stanzas", new[] { "nomeCasa", "longitude", "latitude" });
            CreateIndex("dbo.Affittoes", new[] { "idStanza", "nomeCasa", "longitude", "latitude" });
            AddForeignKey("dbo.Eventoes", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.GestioneCasas", new[] { "nomeCasa", "longitude", "latitude" }, cascadeDelete: true);
            AddForeignKey("dbo.GestioneCasas", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.Casas", new[] { "nomeCasa", "longitudine", "latitudine" });
            AddForeignKey("dbo.Stanzas", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.Casas", new[] { "nomeCasa", "longitudine", "latitudine" }, cascadeDelete: true);
            AddForeignKey("dbo.FotoCasas", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.Casas", new[] { "nomeCasa", "longitudine", "latitudine" }, cascadeDelete: true);
            AddForeignKey("dbo.Affittoes", new[] { "idStanza", "nomeCasa", "longitude", "latitude" }, "dbo.Stanzas", new[] { "idStanza", "nomeCasa", "longitude", "latitude" }, cascadeDelete: true);
        }
    }
}
