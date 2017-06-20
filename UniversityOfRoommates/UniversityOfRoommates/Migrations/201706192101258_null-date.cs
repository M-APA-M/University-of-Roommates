namespace UniversityOfRoommates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nulldate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "ddn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ddn", c => c.DateTime(nullable: false));
        }
    }
}
