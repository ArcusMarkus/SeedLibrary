using SeedLibrary.Models;

namespace SeedLibrary.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SeedContext context)
        {
            // Look for any students.
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
                new Seed{Variety="Calima",Name="Bean",Year=2022,Date="Jan-Mar & Sep-Oct", Source= "Cool Farms",Depth="1/4 inch", Count=3, 
                Note ="Succession-plant for continued harvest." ,EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Seed{Variety="Mary Washington",Name="Asparagus",Year=2024,Date="Jan-Mar & Sep-Oct",Source= "Cool Farms", Depth="1/4 inch", Count=3, 
                Note ="Succession-plant for continued harvest." ,EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Seed{Variety="Detroit Dark Red",Name="Beet",Year=2024,Date="Jan-Mar & Sep-Oct",Source= "Cool Farms", Depth="1/4 inch", Count=3, 
                Note ="Succession-plant for continued harvest." ,EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Seed{Variety="Green Sprouting Calabrese",Name="Bok Choy",Year=2025,Date="Jan-Mar & Sep-Oct",Source= "Cool Farms", Depth="1/4 inch", Count=3, 
                Note ="Succession-plant for continued harvest." ,EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Seed{Variety="Catskill",Name="Broccoli",Year=2025,Date="Jan-Mar & Sep-Oct", Source= "Cool Farms",Depth="1/4 inch", Count=3, 
                Note ="Succession-plant for continued harvest." ,EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Seed{Variety="Red Cored Chantenay",Name="Carrot",Year=2020,Date="Jan-Mar & Sep-Oct",Source= "Cool Farms", Depth="1/4 inch", Count=3, 
                Note ="Succession-plant for continued harvest." ,EnrollmentDate=DateTime.Parse("2019-09-01")}
            };

            context.Seeds.AddRange(seeds);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{CourseID=1050,Title="Chemistry",Credits=3},
                new Course{CourseID=4022,Title="Microeconomics",Credits=3},
                new Course{CourseID=4041,Title="Macroeconomics",Credits=3},
                new Course{CourseID=1045,Title="Calculus",Credits=4},
                new Course{CourseID=3141,Title="Trigonometry",Credits=4},
                new Course{CourseID=2021,Title="Composition",Credits=3},
                new Course{CourseID=2042,Title="Literature",Credits=4}
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{SeedID=1,CourseID=1050,Grade=Grade.A},
                new Enrollment{SeedID=1,CourseID=4022,Grade=Grade.C},
                new Enrollment{SeedID=1,CourseID=4041,Grade=Grade.B},
                new Enrollment{SeedID=2,CourseID=1045,Grade=Grade.B},
                new Enrollment{SeedID=2,CourseID=3141,Grade=Grade.F},
                new Enrollment{SeedID=2,CourseID=2021,Grade=Grade.F},
                new Enrollment{SeedID=3,CourseID=1050},
                new Enrollment{SeedID=4,CourseID=1050},
                new Enrollment{SeedID=4,CourseID=4022,Grade=Grade.F},
                new Enrollment{SeedID=5,CourseID=4041,Grade=Grade.C},
                new Enrollment{SeedID=6,CourseID=1045},
                new Enrollment{SeedID=7,CourseID=3141,Grade=Grade.A},
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}