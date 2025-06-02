using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace revisionIsgaG2
{
    internal class EnseignantDao
    {
        string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "enseignants.csv");

        public void AddEnseignant(int id, string nom, string prenom, string specialite,string password)
        {
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine($"{id},{nom},{prenom},{specialite},{password}");
            }
        }

        public List<Enseignant> allEnseignants()
        {
            List<Enseignant> enseignants = new List<Enseignant>();

            if (!File.Exists(filename))
                return enseignants;

            foreach (string line in File.ReadAllLines(filename))
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 5)
                {
                    enseignants.Add(new Enseignant
                    {
                        Id = int.Parse(parts[0]),
                        Nom = parts[1],
                        Prenom = parts[2],
                        Specialite = parts[3],
                        Password = parts[4]
                    });
                }
            }
            return enseignants;
        }

        public Enseignant findById(int id)
        {
            return allEnseignants().FirstOrDefault(e => e.Id == id);
        }

        public void updateEnseignant(int id, string nom, string prenom, string specialite,string password)
        {
            var enseignants = allEnseignants();
            var ens = enseignants.FirstOrDefault(e => e.Id == id);
            if (ens != null)
            {
                ens.Nom = nom;
                ens.Prenom = prenom;
                ens.Specialite = specialite;
                ens.Password = password;
                SaveAll(enseignants);
            }
        }

        public void deleteEnseignant(int id)
        {
            var enseignants = allEnseignants();
            enseignants.RemoveAll(e => e.Id == id);
            SaveAll(enseignants);
        }

        private void SaveAll(List<Enseignant> enseignants)
        {
            File.WriteAllLines(filename, enseignants.Select(e => $"{e.Id},{e.Nom},{e.Prenom},{e.Specialite},{e.Password}"));
        }
        public void CreateAdmin(string username, string password)
        {

            File.WriteAllText(filename, $"{username},{password}");
        }
        public Enseignant FindByCredentials(string nom, string password)
        {
            var enseignants = allEnseignants();
            return enseignants.FirstOrDefault(e =>
                e.Nom.Equals(nom, StringComparison.OrdinalIgnoreCase) &&
                e.Password == password); // À adapter selon votre système de mot de passe
        }

        internal void addEnseignant(int v, string text1, string text2, string text3, string text4)
        {
            throw new NotImplementedException();
        }
    }
}

