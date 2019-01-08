namespace FeesCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MonthlyConsumptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameofMonth = c.String(),
                        NumberofPeople = c.Int(nullable: false),
                        CwCurrentValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CwChange = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CwPerPerson = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ZwCurrentValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ZwChange = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ZwPerPerson = c.Decimal(nullable: false, precision: 18, scale: 2),
                        COCurrentValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        COChange = c.Decimal(nullable: false, precision: 18, scale: 2),
                        COPerPerson = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ElecCurrentValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ElecChange = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ElecPerPerson = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherCurrentValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherPerPerson = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SumPerPerson = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Utilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        IsFixed = c.Boolean(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 4),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Utilities");
            DropTable("dbo.MonthlyConsumptions");
        }
    }
}
