using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace revisionIsgaG2
{
    internal class EtudiantDao
    {
        string filename = "C:\\Users\\Hp\\Desktop\\RIAD_ABDERRAHIM\\etudiants.csv";
        public void addEtudiant(int id, string nom,string prenom,string password )
        {
            StreamWriter sw = new StreamWriter(filename,true);
            sw.WriteLine(id+","+nom+","+prenom + "," +password);
            sw.Close();

        }

        public List<Etudiant> alletudiants()
        {
            List<Etudiant> ets = new List<Etudiant>();
            StreamReader sw = new StreamReader(filename);
            string line = sw.ReadLine();
            while (line != null)
            {
                string[] d = line.Split(',');
                if (d.Length >= 4)
                {
                    Etudiant et = new Etudiant
                    {
                        Id = Int32.Parse(d[0]),
                        Nom = d[1],
                        Prenom = d[2],
                        Password = d[3]
                    };
                    ets.Add(et);
                }
                else
                {
                    // Log or handle invalid data here.
                }
                line = sw.ReadLine();
            }
            sw.Close();
            return ets;
        }

        public Etudiant findById(int ide)
        {
            Etudiant et = null;
            StreamReader sw = new StreamReader(filename);
            string line = sw.ReadLine();
            while (line != null)
            {
                string[] d = line.Split(',');
                if (d.Length >= 4 && Int32.Parse(d[0]) == ide)
                {
                    et = new Etudiant
                    {
                        Id = Int32.Parse(d[0]),
                        Nom = d[1],
                        Prenom = d[2],
                        Password = d[3]
                    };
                    break;
                }
                line = sw.ReadLine();
            }
            sw.Close();
            return et;
        }
        public void deleteEtudiant(int id)
        {
            if (!File.Exists(filename))
                return;

            List<string> lines = File.ReadAllLines(filename).ToList();
            lines = lines.Where(line =>
            {
                string[] parts = line.Split(',');
                return parts.Length < 1 || Int32.Parse(parts[0]) != id;
            }).ToList();

            File.WriteAllLines(filename, lines);
        }
        public void updateEtudiant(int id, string nom, string prenom, string password)
        {
            if (!File.Exists(filename))
                return;

            List<string> lines = File.ReadAllLines(filename).ToList();
            bool modified = false;
            for (int i = 0; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length >= 4 && Int32.Parse(parts[0]) == id)
                {
                    lines[i] = $"{id},{nom},{prenom},{password}";
                    modified = true;
                    break;
                }
            }
            if (modified)
            {
                File.WriteAllLines(filename, lines);
            }
        }
        public Etudiant FindByCredentials(string nom, string password)
        {
            var etudiants = alletudiants();
            return etudiants.FirstOrDefault(e =>
                e.Nom.Equals(nom, StringComparison.OrdinalIgnoreCase) &&
                e.Password == password); // À adapter selon votre système de mot de passe
        }
        public List<Etudiant> GetEtudiantsByModule(int moduleId)
        {
            var examenDao = new ExamenDao();
            var etudiants = new List<Etudiant>();

            // Utilisation d'une jointure en mémoire
            var query = from examen in examenDao.allExams()
                        where examen.Idm == moduleId
                        join etudiant in alletudiants() on examen.Ide equals etudiant.Id
                        select etudiant;

            return query.Distinct().ToList();
        }
    }
}
