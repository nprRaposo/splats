namespace Splats.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SerieImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Serie", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Serie", "ImageUrl");
        }
    }
}
