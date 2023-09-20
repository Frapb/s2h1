using System.Collections.Generic;
using System.Linq;
namespace s2h1
{

    internal class BusinessLogic
    {
        private List<User> users = new List<User>();

        private List<Record> records = new List<Record>();
        public BusinessLogic()
        {
            // наполнение обеих коллекций тестовыми данными }
            users.Add(new User(1, "Ryhor", "Vikhrau"));
            users.Add(new User(2, "Akexander", "Sivkov"));
            users.Add(new User(3, "Egor", "Liapin"));
            users.Add(new User(4, "Ivan", "Brdu"));
            users.Add(new User(5, "Ryhor", "Vikhrau"));
            users.Add(new User(6, "Mihail", "Avsianikov"));
            users.Add(new User(7, "Mihfrrail", "Avsfrfrianikov"));
            records.Add(new Record(users[1], "I want buy something"));
            records.Add(new Record(users[2], "I want buy something"));
            records.Add(new Record(users[3], "I want buy somethfwmfwnmfing"));
            records.Add(new Record(users[5], "I want buy somefeeefthing"));
            records.Add(new Record(users[4], "I wanfefet buy something"));
            records.Add(new Record(users[3], "I wanfefret buy something"));
            records.Add(new Record(users[2], "I want ferebuy something"));
        }
        public List<User> GetUsersBySurname(String surname)
        {
            var cloud = from user in users
                        where user.Surname == surname
                        select user;
            return cloud.ToList();

        }
        public User GetUserByID(int id)
        {
            var cloud = (from user in users
                         where user.ID == id
                         select user).Single();
            return cloud;

        }
        public List<User> GetUsersBySubstring(String substring)
        {
            var cloud = from user in users
                        where (user.Surname.Contains(substring) || user.Name.Contains(substring))
                        select user;
            return cloud.ToList();

        }
        public List<String> GetAllUniqueNames()
        {

            return (from users in users select users.Name).Distinct().ToList();

        }
        public Dictionary<int, User> GetUsersDictionary()
        {
            return (from user in users select user).ToDictionary(user => user.ID, user => user);
        }
        public int GetMaxID()
        {
            return users.Max(user => user.ID);
        }


        public List<User> GetOrderedUsers()
        {

            return users.OrderBy(user => user.ID).ToList();
        }

        public List<User> GetDescendingOrderedUsers()
        {

            return users.OrderByDescending(user => user.ID).ToList();
        }
        public List<User> GetReversedUsers()
        {
            return (from user in users select user).OrderBy(user => user.ID).Reverse().ToList();

        }
       
        public List<User> GetUsersPage(int pageSize, int pageIndex) 
        {
            return (from user in users select user).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
        }

    }
}


