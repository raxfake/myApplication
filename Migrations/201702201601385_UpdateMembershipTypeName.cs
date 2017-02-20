namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("Update MEMBERSHIPTYPES set Name = 'Pay as you go' where DURATIONINMONTH = 0");
            Sql("Update MEMBERSHIPTYPES set Name = 'Monthly' where DURATIONINMONTH = 1");
            Sql("Update MEMBERSHIPTYPES set Name = 'Quarterly' where DURATIONINMONTH = 3");
            Sql("Update MEMBERSHIPTYPES set Name = 'Yearly' where DURATIONINMONTH = 12");
            
        }
        
        public override void Down()
        {
        }
    }
}
