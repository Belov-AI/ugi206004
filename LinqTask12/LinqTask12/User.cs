using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTask12
{
    public class User
    {
        public string Login; 
        private int passwordHashCode;

        public User(string login, int hashcode) 
        { 
            Login = login; 
            passwordHashCode = hashcode; 
        }

        public bool IsPasswordCorrect(string password) 
        { 
            return password.GetHashCode() == passwordHashCode; 
        }
    }
}
