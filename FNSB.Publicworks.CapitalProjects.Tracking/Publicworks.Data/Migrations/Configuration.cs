using System.Collections.Generic;
using Publicworks.Entities.Funds;

namespace Publicworks.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Publicworks.Data.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Publicworks.Data.Context.ApplicationDbContext";
        }

        protected override void Seed(Publicworks.Data.Context.ApplicationDbContext context)
        {

            //var bids = new List<BidSchedule>
            //{
            //    new BidSchedule
            //    {
            //        GeneralLedgerKey = "123324",

                   
            //    }

            //}


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
