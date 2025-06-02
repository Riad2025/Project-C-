using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace revisionIsgaG2
{
    internal class ExamenDao
    {
        ModuleDao moduleDao = new ModuleDao();
        private readonly string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "exams.csv");

        public void addExam(Examen examen)
        {
            File.AppendAllText(filename,
               $"{examen.Id},{examen.Date:yyyy-MM-dd},{examen.Note.ToString(CultureInfo.InvariantCulture)}," +
               $"{examen.Ide},{examen.Idm},{examen.EstValide},{examen.EstPublie}{Environment.NewLine}");
        }
        

        public Examen findExamById(int id)
        {
            Examen ex = null;
            StreamReader streamReader = new StreamReader(filename);
            string line = streamReader.ReadLine();
            while (line != null)
            {
                string[] dd = line.Split(',');
                if (Int32.Parse(dd[0]) == id)
                {
                    ex = new Examen();
                    ex.Id = id;
                    ex.Date = DateTime.Parse(dd[1]);
                    ex.Note = Double.Parse(dd[2]);
                    ex.Ide = Int32.Parse(dd[3]);
                    ex.Idm = Int32.Parse(dd[4]);
                    break;
                }
            }
            streamReader.Close();

            return ex;
        }

        public void ValidateExam(int examId)
        {
            var exams = allExams();
            var exam = exams.FirstOrDefault(e => e.Id == examId);

            if (exam != null)
            {
                exam.EstValide = true;
                SaveAllExams(exams);
            }
        }
        
        public List<Examen> findExamByIdEM(int ide, int idm)
        {

            List<Examen> exms = new List<Examen>();

            StreamReader streamReader = new StreamReader(filename);
            string line = streamReader.ReadLine();
            while (line != null)
            {
                string[] dd = line.Split(',');
                if (Int32.Parse(dd[3]) == ide && Int32.Parse(dd[4]) == idm)
                {
                    Examen ex = new Examen();
                    ex.Id = Int32.Parse(dd[0]);
                    ex.Date = DateTime.Parse(dd[1]);
                    ex.Note = Double.Parse(dd[2]);
                    ex.Ide = Int32.Parse(dd[3]);
                    ex.Idm= Int32.Parse(dd[4]);

                    exms.Add(ex);
                }
            }
            streamReader.Close();

            return exms;
        }

        public List<Examen> findExam4Etudiant(int ide)
        {
            List<Examen> exms = new List<Examen>();

            StreamReader streamReader = new StreamReader(filename);
            string line = streamReader.ReadLine();
            while (line != null)
            {
                string[] dd = line.Split(',');
                if (Int32.Parse(dd[3]) == ide)
                {
                    Examen ex = new Examen();
                    ex.Id = Int32.Parse(dd[0]);
                    ex.Date = DateTime.Parse(dd[1]);
                    ex.Note = Double.Parse(dd[2]);
                    ex.Ide = Int32.Parse(dd[3]);
                    ex.Idm = Int32.Parse(dd[4]);

                    exms.Add(ex);
                }
            }
            streamReader.Close();

            return exms;
        }


        public double moyenne(int ide)
        {
            double moy = 0;
            double cc = 0;


            List<Examen> exs = findExam4Etudiant(ide);

            foreach (Examen ex in exs)
            {
                Module m = moduleDao.findModuleById(ex.Idm);
                moy = moy + m.Coiff * ex.Note;
                cc += m.Coiff;
            }

            moy = moy / cc;


            return moy;

        }
        public void updateExam(int id, DateTime date, double note, int ide, int idm)
        {
            var exams = allExams();
            var exam = exams.FirstOrDefault(e => e.Id == id);
            if (exam != null)
            {
                exam.Date = date;
                exam.Note = note;
                exam.Ide = ide;
                exam.Idm = idm;
                // Conserve les états existants !
                exam.EstValide = exam.EstValide;
                exam.EstPublie = exam.EstPublie;
                SaveAllExams(exams);
            }
        }
        public void deleteExam(int id)
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
        // Nouvelle méthode pour sauvegarder
        private void SaveAllExams(List<Examen> exams)
        {
            var lines = exams.Select(e =>
                $"{e.Id},{e.Date},{e.Note},{e.Ide},{e.Idm},{e.EstValide},{e.EstPublie}");
            File.WriteAllLines(filename, lines);
        }

        public List<Examen> allExams()
        {
            List<Examen> exams = new List<Examen>();
            if (!File.Exists(filename))
                return exams;

            try
            {
                var lines = File.ReadAllLines(filename);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split(',');
                    if (parts.Length < 5) continue;

                    var exam = new Examen
                    {
                        Id = int.Parse(parts[0]),
                        Date = DateTime.Parse(parts[1]),
                        Note = double.Parse(parts[2]),
                        Ide = int.Parse(parts[3]),
                        Idm = int.Parse(parts[4])
                    };

                    // Lire les états si ils existent
                    if (parts.Length > 5) exam.EstValide = bool.Parse(parts[5]);
                    if (parts.Length > 6) exam.EstPublie = bool.Parse(parts[6]);

                    exams.Add(exam);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de lecture du fichier: {ex.Message}");
            }
            return exams;
        }
        public void PublierExamens()
        {
            var exams = allExams();
            var aPublier = exams.Where(e => e.EstValide && !e.EstPublie).ToList();

            foreach (var exam in aPublier)
            {
                exam.EstPublie = true;
            }

            SaveAllExams(exams);
        }

        internal string GetFilePath()
        {
            throw new NotImplementedException();
        }

        internal object GetById(int idExamen)
        {
            throw new NotImplementedException();
        }

        public List<Examen> GetExamensByEnseignant(int enseignantId)
        {
            var modulesEnseignes = new ModuleDao().GetModulesByEnseignant(enseignantId)
                .Select(m => m.Id).ToList();

            return allExams().Where(e => modulesEnseignes.Contains(e.Idm)).ToList();
        }

        public List<double> GetNotesByModule(int moduleId)
        {
            return allExams()
                .Where(e => e.Idm == moduleId)
                .Select(e => e.Note)
                .ToList();
        }

        public void AddOrUpdateNote(int moduleId, int etudiantId, double note)
        {
            try
            {
                var exams = allExams();
                var existingExam = exams.FirstOrDefault(e => e.Idm == moduleId && e.Ide == etudiantId);

                if (existingExam != null)
                {
                    // Mise à jour
                    existingExam.Note = note;
                    existingExam.Date = DateTime.Now;
                }
                else
                {
                    // Création
                    exams.Add(new Examen
                    {
                        Id = exams.DefaultIfEmpty(new Examen { Id = 0 }).Max(e => e.Id) + 1,
                        Idm = moduleId,
                        Ide = etudiantId,
                        Note = note,
                        Date = DateTime.Now,
                        EstValide = false,
                        EstPublie = false
                    });
                }

                SaveAllExams(exams);
            }
            catch (Exception ex)
            {
                // Journaliser l'erreur
                Console.WriteLine($"Erreur dans AddOrUpdateNote: {ex.Message}");
                throw; // Relancer l'exception pour la gestion dans la couche UI
            }
        }
        public List<Examen> GetExamensByEtudiant(int etudiantId)
        {
            return allExams().Where(e => e.Ide == etudiantId).ToList();
        }

        public List<(int Idm, double Note, DateTime Date, bool EstPublie)> GetNotesByEtudiant(int etudiantId)
        {
            return allExams()
                .Where(e => e.Ide == etudiantId)
                .Select(e => (e.Idm, e.Note, e.Date, e.EstPublie))
                .ToList();
        }
    }


}


