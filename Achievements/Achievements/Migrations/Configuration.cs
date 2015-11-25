namespace Achievements.Migrations
{
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
           
            //if (!context.Roles.Any(r => r.Name == "Admin"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole { Name = "Admin" };

            //    manager.Create(role);
            //}
            //if (!context.Roles.Any(r => r.Name == "Student"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole { Name = "Student" };

            //    manager.Create(role);
            //}
            //if (!context.Roles.Any(r => r.Name == "Teacher"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole { Name = "Teacher" };

            //    manager.Create(role);
            //}


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
               
              
                //Student
              
                var Student = new ApplicationUser
                {
                    UserName = "117097",
                    Name = "Raymond",
                    Prefix = "",
                    LastName = "Chang",
                    Gender = GenderEnum.Man,
                    Email = "raymondbdws@hotmail.com",
                    BirthDate = DateTime.Parse("07/11/1995"),
                    City = "Hoorn",
                    Job = "",
                    StudyStartYear = DateTime.Parse("01/07/2013"),
                    Study = "Application and Media developer"
                };
                manager.Create(Student, "Horizon!123");


                //Teacher
         
                var Teacher = new ApplicationUser
                {
                    UserName = "R0002",
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
                manager.Create(Teacher, "Horizon!123");



                manager.AddToRole(Admin.Id, "Admin");
                manager.AddToRole(Student.Id, "Student");
                manager.AddToRole(Teacher.Id, "Teacher");
                
            }
        }
    }
}
