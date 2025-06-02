using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace revisionIsgaG2
{
    internal class Enseignant
    {
        int id;
        string nom;
        string prenom;
        string specialite;
        string password;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Specialite { get => specialite; set => specialite = value; }
        public string Password { get => password; set => password = value; }
    }
}
