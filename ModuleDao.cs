using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace revisionIsgaG2
{
    internal class ModuleDao
    {
        string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "modules.csv");

        public void addModule(int id, string lib, double coiff, int idEnseignant)
        {
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine($"{id},{lib},{coiff},{idEnseignant}");
            }
        }

        public Module findModuleById(int id)
        {
            return allmodules().FirstOrDefault(m => m.Id == id);
        }

        public List<Module> allmodules()
        {
            List<Module> modules = new List<Module>();

            if (!File.Exists(filename))
                return modules;

            foreach (string line in File.ReadAllLines(filename))
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 4)
                {
                    modules.Add(new Module
                    {
                        Id = int.Parse(parts[0]),
                        Lib = parts[1],
                        Coiff = double.Parse(parts[2]),
                        IdEnseignant = int.Parse(parts[3])
                    });
                }
            }
            return modules;
        }

        public void updateModule(int id, string lib, double coiff, int idEnseignant)
        {
            var modules = allmodules();
            var mod = modules.FirstOrDefault(m => m.Id == id);
            if (mod != null)
            {
                mod.Lib = lib;
                mod.Coiff = coiff;
                mod.IdEnseignant = idEnseignant;
                SaveAll(modules);
            }
        }

        public void deleteModule(int id)
        {
            var modules = allmodules();
            modules.RemoveAll(m => m.Id == id);
            SaveAll(modules);
        }

        private void SaveAll(List<Module> modules)
        {
            File.WriteAllLines(filename, modules.Select(m => $"{m.Id},{m.Lib},{m.Coiff},{m.IdEnseignant}"));
        }
        public List<Module> GetModulesByEnseignant(int enseignantId)
        {
            return allmodules().Where(m => m.IdEnseignant == enseignantId).ToList();
        }
    }
}



