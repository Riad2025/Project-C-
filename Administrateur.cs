using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace revisionIsgaG2
    {
        public class Administrateur
        {
            private int id;
            private string username;
            private string password;
            private string role; // "superadmin" ou "admin"

            public int Id { get => id; set => id = value; }
            public string Username { get => username; set => username = value; }
            public string Password { get => password; set => password = value; }
            public string Role { get => role; set => role = value; }
        }
    }
