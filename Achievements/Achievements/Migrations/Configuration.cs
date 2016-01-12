namespace Achievements.Migrations
{
    using Achievements.Helpers;
    using Achievements.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Achievements.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Achievements.Models.ApplicationDbContext context)
        {

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Student"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Student" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Teacher"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Teacher" };

                manager.Create(role);
            }


            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                //Admin
                var Admin = new ApplicationUser
                {
                    UserName = "Admin@admin.com",
                    Name = "Admin",
                    Prefix = "",
                    LastName = "Admin",
                    Gender = GenderEnum.Man,
                    Email = "Admin@admin.com",
                    BirthDate = DateTime.Parse("19/04/1959"),
                    City = "Amsterdam",
                    Job = "Administrator at AtlasCollege",
                    StudyStartYear = DateTime.Parse("01/01/2000"),
                    Study = ""
                };
                manager.Create(Admin, "Horizon!123");


                // Student

                var Student = new ApplicationUser
                {
                    UserName = "117097@horizoncollege.nl",
                    Name = "Raymond",
                    Prefix = "",
                    LastName = "Chang",
                    Gender = GenderEnum.Man,
                    Email = "raymondbdws@hotmail.com",
                    BirthDate = DateTime.Parse("07/11/1995"),
                    City = "Hoorn",
                    Job = "",
                    StudyStartYear = DateTime.Parse("01/07/2013"),
                    Study = "Application and Media developer",
                    Class = ClassEnum.M4B
                };
                manager.Create(Student, "Horizon!123");


                var Student2 = new ApplicationUser
                {
                    UserName = "127064@horizoncollege.nl",
                    Name = "Laura",
                    Prefix = "van",
                    LastName = "Dijk",
                    Gender = GenderEnum.Vrouw,
                    Email = "laura@hotmail.com",
                    BirthDate = DateTime.Parse("01/06/1997"),
                    City = "Rotterdam",
                    Job = "Student",
                    StudyStartYear = DateTime.Parse("01/07/2013"),
                    Study = "Application and Media developer",
                    Class = ClassEnum.H3A
                };
                manager.Create(Student2, "Horizon!123");

                var Student3 = new ApplicationUser
                {
                    UserName = "yoshio@horizoncollege.nl",
                    Name = "Yoshio",
                    Prefix = "",
                    LastName = "Schermer",
                    Gender = GenderEnum.Man,
                    Email = "Yoshio@hotmail.com",
                    BirthDate = DateTime.Parse("01/06/1995"),
                    City = "NibbixWoud",
                    Job = "Student",
                    StudyStartYear = DateTime.Parse("01/07/2013"),
                    Study = "Application and Media developer",
                    Class = ClassEnum.H5A
                };
                manager.Create(Student3, "Horizon!123");

                var Student4 = new ApplicationUser
                {
                    UserName = "barry@horizoncollege.nl",
                    Name = "Barry",
                    Prefix = "",
                    LastName = "Stavenuiter",
                    Gender = GenderEnum.Man,
                    Email = "barry@hotmail.com",
                    BirthDate = DateTime.Parse("01/06/1995"),
                    City = "Hoorn",
                    Job = "Student",
                    StudyStartYear = DateTime.Parse("01/07/2013"),
                    Study = "Application and Media developer",
                    Class = ClassEnum.H2B
                };
                manager.Create(Student4, "Horizon!123");
                //Teacher

                var Teacher = new ApplicationUser
                {
                    UserName = "Teacher@horizoncollege.nl",
                    Name = "Teacher",
                    Prefix = "",
                    LastName = "Teacher",
                    Gender = GenderEnum.Man,
                    Email = "teacher@hotmail.com",
                    BirthDate = DateTime.Parse("07/01/1987"),
                    City = "Hoorn",
                    Job = "Dutch teacher",
                    StudyStartYear = DateTime.Parse("01/01/2000"),
                    Study = ""
                };
                //manager.Create(Teacher, "Horizon!123");

                //manager.AddToRole(Student.Id, "Student");
                //manager.AddToRole(Student2.Id, "Student");
                //manager.AddToRole(Student3.Id, "Student");
                //manager.AddToRole(Student4.Id, "Student");
                //manager.AddToRole(Teacher.Id, "Teacher");
                Helpers.Users.CreateUserByRole(RoleEnum.Student, Teacher, "Horizon!123");
            }
        }
    }
}

