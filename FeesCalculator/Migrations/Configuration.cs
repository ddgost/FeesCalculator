namespace FeesCalculator.Migrations
{
    using Model;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Type = Model.Type;

    internal sealed class Configuration : DbMigrationsConfiguration<AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppContext context)
        {
            var utilities = new List<Utility>
            {
            new Utility
            {
                Id = 1,
                Name = "Centralne ogrzewanie - opłata stała",
                Type = Type.CO,
                IsFixed = true,
                Value = 31.11m,
            },
            new Utility
            {
                Id = 2,
                Name = "Wywóz nieczystości",
                Type = Type.Other,
                IsFixed = true,
                Value = 22.08m,
            },
            new Utility
            {
                Id = 3,
                Name = "Zimna woda i ścieki",
                Type = Type.Zw,
                IsFixed = false,
                Value = 10.56m,
            },
            new Utility
            {
                Id = 4,
                Name = "Ciepła woda",
                Type = Type.Cw,
                IsFixed = false,
                Value = 21.36m,
            },
            new Utility
            {
                Id = 5,
                Name = "Centralne ogrzewanie - opłata zmienna",
                Type = Type.CO,
                IsFixed = false,
                Value = 62.56m,
            },
            new Utility
            {
                Id = 6,
                Name = "Energia elektryczna - sprzedaż",
                Type = Type.Elec,
                IsFixed = false,
                Value = 0.2414m,
            },
            new Utility
            {
                Id = 7,
                Name = "Energia elektryczna - opłata przesyłowa stała",
                Type = Type.Elec,
                IsFixed = true,
                Value = 6.10m,
            },
            new Utility
            {
                Id = 8,
                Name = "Energia elektryczna - opłata przesyłowa zmienna",
                Type = Type.Elec,
                IsFixed = false,
                Value = 0.2285m,
            },
            new Utility
            {
                Id = 9,
                Name = "Energia elektryczna - opłata jakościowa",
                Type = Type.Elec,
                IsFixed = false,
                Value = 0.0127m,
            },
            new Utility
            {
                Id = 10,
                Name = "Energia elektryczna - opłata OZE",
                Type = Type.Elec,
                IsFixed = false,
                Value = 0.0037m,
            },
            new Utility
            {
                Id = 11,
                Name = "Energia elektryczna - opłata abonamentowa",
                Type = Type.Elec,
                IsFixed = true,
                Value = 0.58m,
            },
            new Utility
            {
                Id = 12,
                Name = "Energia elektryczna - opłata przejściowa",
                Type = Type.Elec,
                IsFixed = true,
                Value = 6.50m,
            }
            };
            utilities.ForEach(utility => context.Utilities.AddOrUpdate(x => x.Id, utility));
            context.SaveChanges();
            var monthlyConsumptions = new List<MonthlyConsumption>
            {
                new MonthlyConsumption
                {
                    Id = 1,
                    NameofMonth = "grudzień 2018",
                    NumberofPeople = 4,
                    CwCurrentValue = 278.38m,
                    CwChange = 2.25m,
                    CwPerPerson = 12.02m,
                    ZwCurrentValue = 372.63m,
                    ZwChange = 4.33m,
                    ZwPerPerson = 17.37m,
                    COCurrentValue = 101.83m,
                    COChange = 1.03m,
                    COPerPerson = 16.11m,
                    ElecCurrentValue = 6869.8m,
                    ElecChange = 175.3m,
                    ElecPerPerson = 30.27m,
                    OtherCurrentValue = 64.36m,
                    OtherPerPerson = 16.09m,
                    SumPerPerson = 105.15m,
                },
                new MonthlyConsumption
                {
                    Id = 2,
                    NameofMonth = "styczeń 2019",
                    NumberofPeople = 4,
                    CwCurrentValue = 280.69m,
                    CwChange = 2.31m,
                    CwPerPerson = 12.34m,
                    ZwCurrentValue = 376.69m,
                    ZwChange = 4.06m,
                    ZwPerPerson = 16.82m,
                    COCurrentValue = 103.66m,
                    COChange = 1.83m,
                    COPerPerson = 28.62m,
                    ElecCurrentValue = 7019.7m,
                    ElecChange = 149.9m,
                    ElecPerPerson = 26.47m,
                    OtherCurrentValue = 45.92m,
                    OtherPerPerson = 11.48m,
                    SumPerPerson = 109.02m,
                }
            };
            monthlyConsumptions.ForEach(monthlyConsumption => context.MonthlyConsumptions.AddOrUpdate(y => y.Id, monthlyConsumption));
            context.SaveChanges();
        }
    }
}
