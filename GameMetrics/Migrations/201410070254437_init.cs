namespace GameMetrics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Engagement", "Achievement", c => c.Int(nullable: false));
            DropColumn("dbo.Engagement", "HighScore");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Engagement", "HighScore", c => c.String());
            DropColumn("dbo.Engagement", "Achievement");
        }
    }
}
