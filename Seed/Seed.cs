using Uranus.Data;
using Uranus.Models;

namespace Uranus.Seed
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.UserCourses.Any())
            {
                var userCourses = new List<UserCourse>()
                {
                    new UserCourse()
                    {
                        User = new User() {
                            Name = "Jalol ALimov",
                            Login = "jalolalimov"
                        }
                    }
                };
                dataContext.UserCourses.AddRange(userCourses);
                dataContext.SaveChanges();
            }
        }
    }
}
