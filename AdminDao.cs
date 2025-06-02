using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace revisionIsgaG2
{
    public class AdminDao
    {
        private string adminFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "admins.csv");
        private ExamenDao examenDao = new ExamenDao();

        public bool AdminExists()
        {
            return File.Exists(adminFile);
        }

        // Créer le compte admin (à exécuter une seule fois)
        public void CreateAdmin(string username, string password)
        {
            if (AdminExists())
                throw new Exception("Un administrateur existe déjà");

            File.WriteAllText(adminFile, $"{username},{password}");
        }

        // Authentifier l'admin
        public bool Authenticate(string username, string password)
        {
            if (!AdminExists()) return false;

            string[] credentials = File.ReadAllText(adminFile).Split(',');
            return credentials[0] == username && credentials[1] == password;
        }

        // Changer le mot de passe
        public void ChangePassword(string newPassword)
        {
            if (!AdminExists()) return;

            string[] credentials = File.ReadAllText(adminFile).Split(',');
            File.WriteAllText(adminFile, $"{credentials[0]},{newPassword}");
        }

        // Fonctions spécifiques à l'administration
        public void ValiderExamen(int idExamen)
        {
            var examens = examenDao.allExams();
            var examen = examens.FirstOrDefault(e => e.Id == idExamen);
            if (examen != null)
            {
                examen.EstValide = true;
                SaveAllExamens(examens);
            }
        }

        public void PublierResultats()
        {
            var examens = examenDao.allExams();
            foreach (var examen in examens.Where(e => e.EstValide))
            {
                examen.EstPublie = true;
            }
            SaveAllExamens(examens);
        }

        private void SaveAllExamens(List<Examen> examens)
        {
            var lines = examens.Select(e =>
                $"{e.Id},{e.Date},{e.Note},{e.Ide},{e.Idm},{e.EstValide},{e.EstPublie}");
            File.WriteAllLines(examenDao.GetFilePath(), lines);
        }

        public string GenererPV(int idModule)
        {
            var module = new ModuleDao().findModuleById(idModule);
            var examens = examenDao.allExams()
                .Where(e => e.Idm == idModule)
                .OrderBy(e => e.Ide);

            string content = $"PROCÈS-VERBAL - {module.Lib}\n\n";
            content += "ID Étudiant | Note | Statut\n";
            content += "----------------------------\n";

            foreach (var e in examens)
            {
                content += $"{e.Ide} | {e.Note} | {(e.EstValide ? "Validé" : "Non validé")}\n";
            }

            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                $"PV_{module.Lib}_{DateTime.Now:yyyyMMdd}.txt");

            File.WriteAllText(fileName, content);
            return fileName;
        }
    }
}