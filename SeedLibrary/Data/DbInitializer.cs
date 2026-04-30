using SeedLibrary.Models;

namespace SeedLibrary.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SeedContext context)
        {
            // Look for any seeds.
            if (context.Seeds.Any())
            {
                return;   // DB has been seeded
            }

            var seeds = new Seed[]
            {
                new Seed{Variety="Common",Name="Arugula", Year=2023,Date="Jan-Mar & Sep-Oct", Source= "Cool Farms", Depth="1/4 inch", Count=3, 
                Note ="Succession-plant for continued harvest." , 
                EnrollmentDate=DateTime.Parse("2019-09-01")},
                new Seed{Variety="Green Globe",Name="Artichoke",Year=2021,Date="Jan-Mar & Sep-Oct",Source= "Cool Farms", Depth="1/4 inch", Count=3, 
                Note ="Succession-plant for continued harvest." ,EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Seed{Variety="Calima",Name="Bean",Year=2022,Date="Jan-Mar & Sep-Oct", Source= "Rad Farms",Depth="1/4 inch", Count=3, 
                Note ="Succession-plant for continued harvest." ,EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Seed{Variety="Mary Washington",Name="Asparagus",Year=2024,Date="Jan-Mar & Sep-Oct",Source= "Rad Farms", Depth="1/4 inch", Count=3, 
                Note ="Succession-plant for continued harvest." ,EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Seed{Variety="Detroit Dark Red",Name="Beet",Year=2024,Date="Jan-Mar & Sep-Oct",Source= "Cool Farms", Depth="1/4 inch", Count=3, 
                Note ="Succession-plant for continued harvest." ,EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Seed{Variety="Green Sprouting Calabrese",Name="Bok Choy",Year=2025,Date="Jan-Mar & Sep-Oct",Source= "Cool Farms", Depth="1/4 inch", Count=3, 
                Note ="Succession-plant for continued harvest." ,EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Seed{Variety="Catskill",Name="Broccoli",Year=2025,Date="Jan-Mar & Sep-Oct", Source= "Rich Farms",Depth="1/4 inch", Count=3, 
                Note ="Succession-plant for continued harvest." ,EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Seed{Variety="Red Cored Chantenay",Name="Carrot",Year=2020,Date="Jan-Mar & Sep-Oct",Source= "A Farm", Depth="1/4 inch", Count=3, 
                Note ="Succession-plant for continued harvest." ,EnrollmentDate=DateTime.Parse("2019-09-01")}
            };

            context.Seeds.AddRange(seeds);
            context.SaveChanges();

        }
    }
}