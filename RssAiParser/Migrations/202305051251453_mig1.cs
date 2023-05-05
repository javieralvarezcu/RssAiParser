namespace RssAiParser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OriginalNews",
                c => new
                    {
                        Url = c.String(nullable: false, maxLength: 128),
                        Titular = c.String(),
                        Subtitulo = c.String(),
                        Cuerpo = c.String(),
                        ProdDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Url);
            
            CreateTable(
                "dbo.ParsedNews",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Titular = c.String(),
                        Subtitulo = c.String(),
                        Cuerpo = c.String(),
                        ParsingDate = c.DateTime(),
                        OriginalId = c.String(),
                        Original_Url = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OriginalNews", t => t.Original_Url)
                .Index(t => t.Original_Url);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParsedNews", "Original_Url", "dbo.OriginalNews");
            DropIndex("dbo.ParsedNews", new[] { "Original_Url" });
            DropTable("dbo.ParsedNews");
            DropTable("dbo.OriginalNews");
        }
    }
}
