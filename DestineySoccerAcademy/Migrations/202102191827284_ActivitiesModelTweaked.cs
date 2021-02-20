namespace DestineySoccerAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivitiesModelTweaked : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Activities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
