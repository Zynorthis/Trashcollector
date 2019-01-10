namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TrashCollector.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TrashCollector.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TrashCollector.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.States.AddOrUpdate(
                s => s.State,
                new States { State = "Alabama", StateAbbrivation = "AL" },
                new States { State = "Alaska", StateAbbrivation = "AK" },
                new States { State = "Arizona", StateAbbrivation = "AZ" },
                new States { State = "Arkansas", StateAbbrivation = "AR" },
                new States { State = "California", StateAbbrivation = "CA" },
                new States { State = "Colorado", StateAbbrivation = "CO" },
                new States { State = "Connecticut", StateAbbrivation = "CT" },
                new States { State = "Delaware", StateAbbrivation = "DE" },
                new States { State = "Florida", StateAbbrivation = "FL" },
                new States { State = "Georgia", StateAbbrivation = "GA" },
                new States { State = "Hawaii", StateAbbrivation = "HI" },
                new States { State = "Idaho", StateAbbrivation = "ID" },
                new States { State = "Illinois", StateAbbrivation = "IL" },
                new States { State = "Indiana", StateAbbrivation = "IN" },
                new States { State = "Iowa", StateAbbrivation = "IA" },
                new States { State = "Kansas", StateAbbrivation = "KS" },
                new States { State = "Kentucky", StateAbbrivation = "KY" },
                new States { State = "Louisiana", StateAbbrivation = "LA" },
                new States { State = "Maine", StateAbbrivation = "ME" },
                new States { State = "Maryland", StateAbbrivation = "MD" },
                new States { State = "Massachusetts", StateAbbrivation = "MA" },
                new States { State = "Michigan", StateAbbrivation = "MI" },
                new States { State = "Minnesota", StateAbbrivation = "MN" },
                new States { State = "Mississippi", StateAbbrivation = "MS" },
                new States { State = "Missouri", StateAbbrivation = "MO" },
                new States { State = "Montana", StateAbbrivation = "MT" },
                new States { State = "Nebraska", StateAbbrivation = "NE" },
                new States { State = "Nevada", StateAbbrivation = "NV" },
                new States { State = "New Hampshire", StateAbbrivation = "NH" },
                new States { State = "New Jersey", StateAbbrivation = "NJ" },
                new States { State = "New Mexico", StateAbbrivation = "NM" },
                new States { State = "New York", StateAbbrivation = "NY" },
                new States { State = "North Carolina", StateAbbrivation = "NC" },
                new States { State = "North Dakota", StateAbbrivation = "ND" },
                new States { State = "Ohio", StateAbbrivation = "OH" },
                new States { State = "Oklahoma", StateAbbrivation = "OK" },
                new States { State = "Oregon", StateAbbrivation = "OR" },
                new States { State = "Pennsylvania", StateAbbrivation = "PA" },
                new States { State = "Rhode Island", StateAbbrivation = "RI" },
                new States { State = "South Carolina", StateAbbrivation = "SC" },
                new States { State = "South Dakota", StateAbbrivation = "SD" },
                new States { State = "Tennessee", StateAbbrivation = "TN" },
                new States { State = "Texas", StateAbbrivation = "TX" },
                new States { State = "Utah", StateAbbrivation = "UT" },
                new States { State = "Vermont", StateAbbrivation = "VT" },
                new States { State = "Virginia", StateAbbrivation = "VA" },
                new States { State = "Washington", StateAbbrivation = "WA" },
                new States { State = "West Virgina", StateAbbrivation = "WV" },
                new States { State = "Wisconsin", StateAbbrivation = "WI" },
                new States { State = "Wyoming", StateAbbrivation = "WY" }
            );
        }
    }
}
