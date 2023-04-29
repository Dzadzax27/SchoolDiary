namespace SchoolDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class naziv_migracije : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Studenti",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Razred = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Studenti");
        }
    }
}
