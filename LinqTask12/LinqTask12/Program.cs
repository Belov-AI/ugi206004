using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTask12
{
    class Program
    {
        static void Main(string[] args)
        {
            var logins = new[] { "peter", "ann", "john", "michael" };
            var hashes = new[] { 1, 2, 3, 4, 5 };

            var users = GetUsersDictionary(logins, hashes);
        }
        
        static Dictionary<string, User> GetUsersDictionary(string[] logins, int[] hashcodes)
        {
            return logins
                .Zip(hashcodes, (login, hashcode) => new User(login, hashcode))
                .ToDictionary(user => user.Login, user => user);
        }
    }
}
