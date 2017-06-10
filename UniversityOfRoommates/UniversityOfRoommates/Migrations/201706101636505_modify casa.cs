namespace UniversityOfRoommates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifycasa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DebitiCreditis", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DebitiCreditis", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Eventoes", "nick", "dbo.AspNetUsers");
            DropIndex("dbo.DebitiCreditis", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.DebitiCreditis", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Eventoes", new[] { "nick" });
            CreateTable(
                "dbo.Utentes",
                c => new
                    {
                        nick = c.String(nullable: false, maxLength: 128),
                        pass = c.String(),
                        nome = c.String(),
                        cognome = c.String(),
                        sesso = c.Boolean(nullable: false),
                        ddn = c.DateTime(nullable: false),
                        cittàProvenienza = c.String(),
                        email = c.String(),
                        cell = c.String(),
                    })
                .PrimaryKey(t => t.nick);
            
            AddColumn("dbo.Casas", "provincia", c => c.String());
            AddColumn("dbo.Casas", "city", c => c.String());
            AddColumn("dbo.DebitiCreditis", "Utente_nick", c => c.String(maxLength: 128));
            AddColumn("dbo.DebitiCreditis", "Utente_nick1", c => c.String(maxLength: 128));
            AlterColumn("dbo.Eventoes", "nick", c => c.String());
            CreateIndex("dbo.DebitiCreditis", "Utente_nick");
            CreateIndex("dbo.DebitiCreditis", "Utente_nick1");
            AddForeignKey("dbo.DebitiCreditis", "Utente_nick", "dbo.Utentes", "nick");
            AddForeignKey("dbo.DebitiCreditis", "Utente_nick1", "dbo.Utentes", "nick");
            DropColumn("dbo.AspNetUsers", "nome");
            DropColumn("dbo.AspNetUsers", "cognome");
            DropColumn("dbo.AspNetUsers", "sesso");
            DropColumn("dbo.AspNetUsers", "ddn");
            DropColumn("dbo.AspNetUsers", "cittàProvenienza");
            DropColumn("dbo.AspNetUsers", "cell");
            DropColumn("dbo.DebitiCreditis", "ApplicationUser_Id");
            DropColumn("dbo.DebitiCreditis", "ApplicationUser_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DebitiCreditis", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.DebitiCreditis", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "cell", c => c.String());
            AddColumn("dbo.AspNetUsers", "cittàProvenienza", c => c.String());
            AddColumn("dbo.AspNetUsers", "ddn", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "sesso", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "cognome", c => c.String());
            AddColumn("dbo.AspNetUsers", "nome", c => c.String());
            DropForeignKey("dbo.DebitiCreditis", "Utente_nick1", "dbo.Utentes");
            DropForeignKey("dbo.DebitiCreditis", "Utente_nick", "dbo.Utentes");
            DropIndex("dbo.DebitiCreditis", new[] { "Utente_nick1" });
            DropIndex("dbo.DebitiCreditis", new[] { "Utente_nick" });
            AlterColumn("dbo.Eventoes", "nick", c => c.String(maxLength: 128));
            DropColumn("dbo.DebitiCreditis", "Utente_nick1");
            DropColumn("dbo.DebitiCreditis", "Utente_nick");
            DropColumn("dbo.Casas", "city");
            DropColumn("dbo.Casas", "provincia");
            DropTable("dbo.Utentes");
            CreateIndex("dbo.Eventoes", "nick");
            CreateIndex("dbo.DebitiCreditis", "ApplicationUser_Id1");
            CreateIndex("dbo.DebitiCreditis", "ApplicationUser_Id");
            AddForeignKey("dbo.Eventoes", "nick", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.DebitiCreditis", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.DebitiCreditis", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
