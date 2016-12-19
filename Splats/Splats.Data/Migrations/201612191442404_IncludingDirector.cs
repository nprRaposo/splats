namespace Splats.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludingDirector : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Director",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Serie", "DirectorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Serie", "DirectorId");
            AddForeignKey("dbo.Serie", "DirectorId", "dbo.Director", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Serie", "DirectorId", "dbo.Director");
            DropIndex("dbo.Serie", new[] { "DirectorId" });
            DropColumn("dbo.Serie", "DirectorId");
            DropTable("dbo.Director");
        }
    }
}
