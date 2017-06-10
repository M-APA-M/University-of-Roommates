namespace UniversityOfRoommates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameintutto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DebitiCreditis", "Utente_nick", "dbo.Utentes");
            DropForeignKey("dbo.DebitiCreditis", "Utente_nick1", "dbo.Utentes");
            DropIndex("dbo.DebitiCreditis", new[] { "Utente_nick" });
            DropIndex("dbo.DebitiCreditis", new[] { "Utente_nick1" });
            RenameColumn(table: "dbo.Affittoes", name: "codiceFiscale", newName: "UserName");
            RenameColumn(table: "dbo.Casas", name: "codiceFiscale", newName: "UserName");
            RenameColumn(table: "dbo.Proprietarios", name: "nick", newName: "UserName");
            RenameColumn(table: "dbo.DebitiCreditis", name: "codiceFiscaleCreditore", newName: "UserNameCreditore");
            RenameColumn(table: "dbo.DebitiCreditis", name: "codiceFiscaleDebitore", newName: "UserNameDebitore");
            RenameColumn(table: "dbo.Interesses", name: "codiceFiscale", newName: "UserName");
            RenameIndex(table: "dbo.Affittoes", name: "IX_codiceFiscale", newName: "IX_UserName");
            RenameIndex(table: "dbo.Casas", name: "IX_codiceFiscale", newName: "IX_UserName");
            RenameIndex(table: "dbo.Proprietarios", name: "IX_nick", newName: "IX_UserName");
            RenameIndex(table: "dbo.DebitiCreditis", name: "IX_codiceFiscaleCreditore", newName: "IX_UserNameCreditore");
            RenameIndex(table: "dbo.DebitiCreditis", name: "IX_codiceFiscaleDebitore", newName: "IX_UserNameDebitore");
            RenameIndex(table: "dbo.Interesses", name: "IX_codiceFiscale", newName: "IX_UserName");
            AddColumn("dbo.DebitiCreditis", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.DebitiCreditis", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.Eventoes", "UserName", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "nome", c => c.String());
            AddColumn("dbo.AspNetUsers", "cognome", c => c.String());
            AddColumn("dbo.AspNetUsers", "sesso", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "ddn", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "cittàProvenienza", c => c.String());
            AddColumn("dbo.AspNetUsers", "cell", c => c.String());
            CreateIndex("dbo.DebitiCreditis", "ApplicationUser_Id");
            CreateIndex("dbo.DebitiCreditis", "ApplicationUser_Id1");
            CreateIndex("dbo.Eventoes", "UserName");
            AddForeignKey("dbo.DebitiCreditis", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.DebitiCreditis", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Eventoes", "UserName", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.DebitiCreditis", "Utente_nick");
            DropColumn("dbo.DebitiCreditis", "Utente_nick1");
            DropColumn("dbo.Eventoes", "nick");
            DropTable("dbo.Utentes");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Eventoes", "nick", c => c.String());
            AddColumn("dbo.DebitiCreditis", "Utente_nick1", c => c.String(maxLength: 128));
            AddColumn("dbo.DebitiCreditis", "Utente_nick", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Eventoes", "UserName", "dbo.AspNetUsers");
            DropForeignKey("dbo.DebitiCreditis", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.DebitiCreditis", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Eventoes", new[] { "UserName" });
            DropIndex("dbo.DebitiCreditis", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.DebitiCreditis", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "cell");
            DropColumn("dbo.AspNetUsers", "cittàProvenienza");
            DropColumn("dbo.AspNetUsers", "ddn");
            DropColumn("dbo.AspNetUsers", "sesso");
            DropColumn("dbo.AspNetUsers", "cognome");
            DropColumn("dbo.AspNetUsers", "nome");
            DropColumn("dbo.Eventoes", "UserName");
            DropColumn("dbo.DebitiCreditis", "ApplicationUser_Id1");
            DropColumn("dbo.DebitiCreditis", "ApplicationUser_Id");
            RenameIndex(table: "dbo.Interesses", name: "IX_UserName", newName: "IX_codiceFiscale");
            RenameIndex(table: "dbo.DebitiCreditis", name: "IX_UserNameDebitore", newName: "IX_codiceFiscaleDebitore");
            RenameIndex(table: "dbo.DebitiCreditis", name: "IX_UserNameCreditore", newName: "IX_codiceFiscaleCreditore");
            RenameIndex(table: "dbo.Proprietarios", name: "IX_UserName", newName: "IX_nick");
            RenameIndex(table: "dbo.Casas", name: "IX_UserName", newName: "IX_codiceFiscale");
            RenameIndex(table: "dbo.Affittoes", name: "IX_UserName", newName: "IX_codiceFiscale");
            RenameColumn(table: "dbo.Interesses", name: "UserName", newName: "codiceFiscale");
            RenameColumn(table: "dbo.DebitiCreditis", name: "UserNameDebitore", newName: "codiceFiscaleDebitore");
            RenameColumn(table: "dbo.DebitiCreditis", name: "UserNameCreditore", newName: "codiceFiscaleCreditore");
            RenameColumn(table: "dbo.Proprietarios", name: "UserName", newName: "nick");
            RenameColumn(table: "dbo.Casas", name: "UserName", newName: "codiceFiscale");
            RenameColumn(table: "dbo.Affittoes", name: "UserName", newName: "codiceFiscale");
            CreateIndex("dbo.DebitiCreditis", "Utente_nick1");
            CreateIndex("dbo.DebitiCreditis", "Utente_nick");
            AddForeignKey("dbo.DebitiCreditis", "Utente_nick1", "dbo.Utentes", "nick");
            AddForeignKey("dbo.DebitiCreditis", "Utente_nick", "dbo.Utentes", "nick");
        }
    }
}
