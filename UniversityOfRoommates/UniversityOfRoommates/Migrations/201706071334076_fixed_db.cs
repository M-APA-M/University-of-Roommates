namespace UniversityOfRoommates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixed_db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Affittoes",
                c => new
                    {
                        idStanza = c.Int(nullable: false),
                        idCasa = c.Int(nullable: false),
                        codiceFiscale = c.String(nullable: false, maxLength: 128),
                        inizioContratto = c.DateTime(nullable: false),
                        fineContratto = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.idStanza, t.idCasa, t.codiceFiscale })
                .ForeignKey("dbo.Stanzas", t => new { t.idStanza, t.idCasa }, cascadeDelete: true)
                .ForeignKey("dbo.Utentes", t => t.codiceFiscale, cascadeDelete: true)
                .Index(t => new { t.idStanza, t.idCasa })
                .Index(t => t.codiceFiscale);
            
            CreateTable(
                "dbo.Stanzas",
                c => new
                    {
                        idStanza = c.Int(nullable: false),
                        idCasa = c.Int(nullable: false),
                        postiLetto = c.Int(nullable: false),
                        metratura = c.Double(nullable: false),
                        foto = c.Binary(),
                        prezzo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.idStanza, t.idCasa })
                .ForeignKey("dbo.Casas", t => t.idCasa, cascadeDelete: true)
                .Index(t => t.idCasa);
            
            CreateTable(
                "dbo.Casas",
                c => new
                    {
                        idCasa = c.Int(nullable: false, identity: true),
                        codiceFiscale = c.String(maxLength: 128),
                        longitudine = c.Decimal(nullable: false, precision: 18, scale: 2),
                        latitudine = c.Decimal(nullable: false, precision: 18, scale: 2),
                        indirizzo = c.String(),
                        civico = c.String(),
                        cap = c.Int(nullable: false),
                        numeroServizi = c.Int(nullable: false),
                        metraturaInterna = c.Double(nullable: false),
                        metraturaEsterna = c.Double(nullable: false),
                        postoAuto = c.Boolean(nullable: false),
                        descrizioneServizi = c.String(),
                    })
                .PrimaryKey(t => t.idCasa)
                .ForeignKey("dbo.Proprietarios", t => t.codiceFiscale)
                .Index(t => t.codiceFiscale);
            
            CreateTable(
                "dbo.FotoCasas",
                c => new
                    {
                        idCasa = c.Int(nullable: false),
                        idFoto = c.Int(nullable: false),
                        linkFoto = c.String(),
                    })
                .PrimaryKey(t => new { t.idCasa, t.idFoto })
                .ForeignKey("dbo.Casas", t => t.idCasa, cascadeDelete: true)
                .Index(t => t.idCasa);
            
            CreateTable(
                "dbo.Proprietarios",
                c => new
                    {
                        codiceFiscale = c.String(nullable: false, maxLength: 128),
                        iban = c.String(),
                        paypalMe = c.String(),
                        cartaIdentità = c.Binary(),
                    })
                .PrimaryKey(t => t.codiceFiscale)
                .ForeignKey("dbo.Utentes", t => t.codiceFiscale)
                .Index(t => t.codiceFiscale);
            
            CreateTable(
                "dbo.Utentes",
                c => new
                    {
                        codiceFiscale = c.String(nullable: false, maxLength: 128),
                        nome = c.String(),
                        cognome = c.String(),
                        sesso = c.Boolean(nullable: false),
                        ddn = c.DateTime(nullable: false),
                        cittàProvenienza = c.String(),
                        email = c.String(),
                        cell = c.String(),
                    })
                .PrimaryKey(t => t.codiceFiscale);
            
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
                        Utente_codiceFiscale = c.String(maxLength: 128),
                        Utente_codiceFiscale1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.idCreditiDebiti)
                .ForeignKey("dbo.Utentes", t => t.codiceFiscaleCreditore)
                .ForeignKey("dbo.Utentes", t => t.codiceFiscaleDebitore)
                .ForeignKey("dbo.Utentes", t => t.Utente_codiceFiscale)
                .ForeignKey("dbo.Utentes", t => t.Utente_codiceFiscale1)
                .Index(t => t.codiceFiscaleCreditore)
                .Index(t => t.codiceFiscaleDebitore)
                .Index(t => t.Utente_codiceFiscale)
                .Index(t => t.Utente_codiceFiscale1);
            
            CreateTable(
                "dbo.Eventoes",
                c => new
                    {
                        idCasa = c.Int(nullable: false),
                        idEvento = c.Int(nullable: false),
                        codiceFiscale = c.String(),
                        descrizione = c.String(),
                        data = c.DateTime(nullable: false),
                        giorno = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idCasa, t.idEvento })
                .ForeignKey("dbo.GestioneCasas", t => t.idCasa, cascadeDelete: true)
                .Index(t => t.idCasa);
            
            CreateTable(
                "dbo.GestioneCasas",
                c => new
                    {
                        idCasa = c.Int(nullable: false),
                        noteComuni = c.String(),
                    })
                .PrimaryKey(t => t.idCasa)
                .ForeignKey("dbo.Casas", t => t.idCasa)
                .Index(t => t.idCasa);
            
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
                .ForeignKey("dbo.Utentes", t => t.codiceFiscale)
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Interesses", "codiceFiscale", "dbo.Utentes");
            DropForeignKey("dbo.Eventoes", "idCasa", "dbo.GestioneCasas");
            DropForeignKey("dbo.GestioneCasas", "idCasa", "dbo.Casas");
            DropForeignKey("dbo.Affittoes", "codiceFiscale", "dbo.Utentes");
            DropForeignKey("dbo.Affittoes", new[] { "idStanza", "idCasa" }, "dbo.Stanzas");
            DropForeignKey("dbo.Stanzas", "idCasa", "dbo.Casas");
            DropForeignKey("dbo.Casas", "codiceFiscale", "dbo.Proprietarios");
            DropForeignKey("dbo.Proprietarios", "codiceFiscale", "dbo.Utentes");
            DropForeignKey("dbo.DebitiCreditis", "Utente_codiceFiscale1", "dbo.Utentes");
            DropForeignKey("dbo.DebitiCreditis", "Utente_codiceFiscale", "dbo.Utentes");
            DropForeignKey("dbo.DebitiCreditis", "codiceFiscaleDebitore", "dbo.Utentes");
            DropForeignKey("dbo.DebitiCreditis", "codiceFiscaleCreditore", "dbo.Utentes");
            DropForeignKey("dbo.FotoCasas", "idCasa", "dbo.Casas");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Interesses", new[] { "codiceFiscale" });
            DropIndex("dbo.GestioneCasas", new[] { "idCasa" });
            DropIndex("dbo.Eventoes", new[] { "idCasa" });
            DropIndex("dbo.DebitiCreditis", new[] { "Utente_codiceFiscale1" });
            DropIndex("dbo.DebitiCreditis", new[] { "Utente_codiceFiscale" });
            DropIndex("dbo.DebitiCreditis", new[] { "codiceFiscaleDebitore" });
            DropIndex("dbo.DebitiCreditis", new[] { "codiceFiscaleCreditore" });
            DropIndex("dbo.Proprietarios", new[] { "codiceFiscale" });
            DropIndex("dbo.FotoCasas", new[] { "idCasa" });
            DropIndex("dbo.Casas", new[] { "codiceFiscale" });
            DropIndex("dbo.Stanzas", new[] { "idCasa" });
            DropIndex("dbo.Affittoes", new[] { "codiceFiscale" });
            DropIndex("dbo.Affittoes", new[] { "idStanza", "idCasa" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Interesses");
            DropTable("dbo.GestioneCasas");
            DropTable("dbo.Eventoes");
            DropTable("dbo.DebitiCreditis");
            DropTable("dbo.Utentes");
            DropTable("dbo.Proprietarios");
            DropTable("dbo.FotoCasas");
            DropTable("dbo.Casas");
            DropTable("dbo.Stanzas");
            DropTable("dbo.Affittoes");
        }
    }
}
