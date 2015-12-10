using Achievements.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Achievements.Helpers
{
    public enum RoleEnum
    {
        Admin,
        Teacher,
        Student
    }

    public static class Users
    {//CreateUserByRole(RoleEnum.Student, Application ser = new Application user, "password");
        public static void CreateUserByRole(RoleEnum role, ApplicationUser user, string password)
        {
            user.Id = Guid.NewGuid().ToString();

            using (var context = new ApplicationDbContext())
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        manager.Create(user, password);
                        context.SaveChanges();

                        manager.AddToRole(user.Id, Enum.GetName(typeof(RoleEnum), (int)role));
                        context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
    }
}