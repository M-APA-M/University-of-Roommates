namespace UniversityOfRoommates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TESTuseaccountaspnetasour : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Affittoes",
                c => new
                    {
                        idStanza = c.Int(nullable: false),
                        nomeCasa = c.String(nullable: false, maxLength: 128),
                        longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        codiceFiscale = c.String(nullable: false, maxLength: 128),
                        inizioContratto = c.DateTime(nullable: false),
                        fineContratto = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.idStanza, t.nomeCasa, t.longitude, t.latitude, t.codiceFiscale })
                .ForeignKey("dbo.Stanzas", t => new { t.idStanza, t.nomeCasa, t.longitude, t.latitude }, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.codiceFiscale, cascadeDelete: true)
                .Index(t => new { t.idStanza, t.nomeCasa, t.longitude, t.latitude })
                .Index(t => t.codiceFiscale);
            
            CreateTable(
                "dbo.Stanzas",
                c => new
                    {
                        idStanza = c.Int(nullable: false),
                        nomeCasa = c.String(nullable: false, maxLength: 128),
                        longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        postiLetto = c.Int(nullable: false),
                        metratura = c.Double(nullable: false),
                        foto = c.Binary(),
                        prezzo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.idStanza, t.nomeCasa, t.longitude, t.latitude })
                .ForeignKey("dbo.Casas", t => new { t.nomeCasa, t.longitude, t.latitude }, cascadeDelete: true)
                .Index(t => new { t.nomeCasa, t.longitude, t.latitude });
            
            CreateTable(
                "dbo.Casas",
                c => new
                    {
                        nomeCasa = c.String(nullable: false, maxLength: 128),
                        longitudine = c.Decimal(nullable: false, precision: 18, scale: 2),
                        latitudine = c.Decimal(nullable: false, precision: 18, scale: 2),
                        codiceFiscale = c.String(maxLength: 128),
                        indirizzo = c.String(),
                        civico = c.String(),
                        cap = c.Int(nullable: false),
                        numeroServizi = c.Int(nullable: false),
                        metraturaInterna = c.Double(nullable: false),
                        metraturaEsterna = c.Double(nullable: false),
                        postoAuto = c.Boolean(nullable: false),
                        descrizioneServizi = c.String(),
                    })
                .PrimaryKey(t => new { t.nomeCasa, t.longitudine, t.latitudine })
                .ForeignKey("dbo.Proprietarios", t => t.codiceFiscale)
                .Index(t => t.codiceFiscale);
            
            CreateTable(
                "dbo.FotoCasas",
                c => new
                    {
                        nomeCasa = c.String(nullable: false, maxLength: 128),
                        longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        idFoto = c.Int(nullable: false),
                        linkFoto = c.String(),
                    })
                .PrimaryKey(t => new { t.nomeCasa, t.longitude, t.latitude, t.idFoto })
                .ForeignKey("dbo.Casas", t => new { t.nomeCasa, t.longitude, t.latitude }, cascadeDelete: true)
                .Index(t => new { t.nomeCasa, t.longitude, t.latitude });
            
            CreateTable(
                "dbo.Proprietarios",
                c => new
                    {
                        nick = c.String(nullable: false, maxLength: 128),
                        iban = c.String(),
                        paypalMe = c.String(),
                        cartaIdentità = c.Binary(),
                    })
                .PrimaryKey(t => t.nick)
                .ForeignKey("dbo.AspNetUsers", t => t.nick)
                .Index(t => t.nick);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        nome = c.String(),
                        cognome = c.String(),
                        sesso = c.Boolean(nullable: false),
                        ddn = c.DateTime(nullable: false),
                        cittàProvenienza = c.String(),
                        cell = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DebitiCreditis",
                c => new
                    {
                        idCreditiDebiti = c.Int(nullable: false, identity: true),
                        codiceFiscaleCreditore = c.String(maxLength: 128),
                        codiceFiscaleDebitore = c.String(maxLength: 128),
                        cifra = c.Double(nullable: false),
                        descrizione = c.String(),
                        data = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ApplicationUser_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.idCreditiDebiti)
                .ForeignKey("dbo.AspNetUsers", t => t.codiceFiscaleCreditore)
                .ForeignKey("dbo.AspNetUsers", t => t.codiceFiscaleDebitore)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id1)
                .Index(t => t.codiceFiscaleCreditore)
                .Index(t => t.codiceFiscaleDebitore)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id1);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Eventoes",
                c => new
                    {
                        nomeCasa = c.String(nullable: false, maxLength: 128),
                        longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        idEvento = c.Int(nullable: false),
                        nick = c.String(maxLength: 128),
                        descrizione = c.String(),
                        data = c.DateTime(nullable: false),
                        giorno = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.nomeCasa, t.longitude, t.latitude, t.idEvento })
                .ForeignKey("dbo.GestioneCasas", t => new { t.nomeCasa, t.longitude, t.latitude }, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.nick)
                .Index(t => new { t.nomeCasa, t.longitude, t.latitude })
                .Index(t => t.nick);
            
            CreateTable(
                "dbo.GestioneCasas",
                c => new
                    {
                        nomeCasa = c.String(nullable: false, maxLength: 128),
                        longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        noteComuni = c.String(),
                    })
                .PrimaryKey(t => new { t.nomeCasa, t.longitude, t.latitude })
                .ForeignKey("dbo.Casas", t => new { t.nomeCasa, t.longitude, t.latitude })
                .Index(t => new { t.nomeCasa, t.longitude, t.latitude });
            
            CreateTable(
                "dbo.Interesses",
                c => new
                    {
                        codiceFiscale = c.String(nullable: false, maxLength: 128),
                        p1 = c.String(),
                        p2 = c.String(),
                        p3 = c.String(),
                        p4 = c.String(),
                        p5 = c.String(),
                        p6 = c.String(),
                        p7 = c.String(),
                        p8 = c.String(),
                    })
                .PrimaryKey(t => t.codiceFiscale)
                .ForeignKey("dbo.AspNetUsers", t => t.codiceFiscale)
                .Index(t => t.codiceFiscale);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Interesses", "codiceFiscale", "dbo.AspNetUsers");
            DropForeignKey("dbo.Eventoes", "nick", "dbo.AspNetUsers");
            DropForeignKey("dbo.Eventoes", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.GestioneCasas");
            DropForeignKey("dbo.GestioneCasas", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.Casas");
            DropForeignKey("dbo.Affittoes", "codiceFiscale", "dbo.AspNetUsers");
            DropForeignKey("dbo.Affittoes", new[] { "idStanza", "nomeCasa", "longitude", "latitude" }, "dbo.Stanzas");
            DropForeignKey("dbo.Stanzas", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.Casas");
            DropForeignKey("dbo.Casas", "codiceFiscale", "dbo.Proprietarios");
            DropForeignKey("dbo.Proprietarios", "nick", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DebitiCreditis", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.DebitiCreditis", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DebitiCreditis", "codiceFiscaleDebitore", "dbo.AspNetUsers");
            DropForeignKey("dbo.DebitiCreditis", "codiceFiscaleCreditore", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FotoCasas", new[] { "nomeCasa", "longitude", "latitude" }, "dbo.Casas");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Interesses", new[] { "codiceFiscale" });
            DropIndex("dbo.GestioneCasas", new[] { "nomeCasa", "longitude", "latitude" });
            DropIndex("dbo.Eventoes", new[] { "nick" });
            DropIndex("dbo.Eventoes", new[] { "nomeCasa", "longitude", "latitude" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.DebitiCreditis", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.DebitiCreditis", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.DebitiCreditis", new[] { "codiceFiscaleDebitore" });
            DropIndex("dbo.DebitiCreditis", new[] { "codiceFiscaleCreditore" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Proprietarios", new[] { "nick" });
            DropIndex("dbo.FotoCasas", new[] { "nomeCasa", "longitude", "latitude" });
            DropIndex("dbo.Casas", new[] { "codiceFiscale" });
            DropIndex("dbo.Stanzas", new[] { "nomeCasa", "longitude", "latitude" });
            DropIndex("dbo.Affittoes", new[] { "codiceFiscale" });
            DropIndex("dbo.Affittoes", new[] { "idStanza", "nomeCasa", "longitude", "latitude" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Interesses");
            DropTable("dbo.GestioneCasas");
            DropTable("dbo.Eventoes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.DebitiCreditis");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Proprietarios");
            DropTable("dbo.FotoCasas");
            DropTable("dbo.Casas");
            DropTable("dbo.Stanzas");
            DropTable("dbo.Affittoes");
        }
    }
}
