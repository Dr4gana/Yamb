namespace Yamb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Igrac : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Igraci",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Igraci");
        }
    }
}
