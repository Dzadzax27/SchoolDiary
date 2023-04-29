namespace SchoolDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nastavnici",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        KorisnickoIme = c.String(),
                        Sifra = c.String(),
                        DatumRodjenja = c.DateTime(nullable: false),
                        StrucnaSprema = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Nastavnici");
        }
    }
}
