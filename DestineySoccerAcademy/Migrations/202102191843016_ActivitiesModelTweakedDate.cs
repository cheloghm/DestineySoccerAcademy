namespace DestineySoccerAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivitiesModelTweakedDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activities", "CreateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activities", "CreateTime", c => c.DateTime(nullable: false));
        }
    }
}
