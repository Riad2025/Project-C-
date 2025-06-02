using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace revisionIsgaG2
{
    internal class Examen
    {
        int id;
        DateTime date;
        double note;

        int ide;
        int idm;
   
        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public double Note { get => note; set => note = value; }
        public int Ide { get => ide; set => ide = value; }
        public int Idm { get => idm; set => idm = value; }
        public bool EstValide { get; internal set; }
        public bool EstPublie { get; internal set; }
    }
}
