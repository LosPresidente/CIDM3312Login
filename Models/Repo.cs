using System.Collections.Generic;

namespace Midterm.Models{
    public static class Repo{
        private static List<LoginViewModel> users = new List<LoginViewModel>()
        {
            new LoginViewModel("cat@cat.cat", "Catcatcat"),
            new LoginViewModel("dog@dog.dog", "Dogdogdog"),
            new LoginViewModel("rat@rat.rat", "Ratratrat")
            
        
        };
        
        public static IEnumerable<LoginViewModel> Users {
            get{
                return users;
            }
        }

        public static void AddUsers(LoginViewModel user){
            users.Add(user);
        }
    }
}