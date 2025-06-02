using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace revisionIsgaG2
{
    internal class Module
    {

        int id;
        string lib;
        double coiff;
        int idEnseignant;

        public int Id { get => id; set => id = value; }
        public string Lib { get => lib; set => lib = value; }
        public double Coiff { get => coiff; set => coiff = value; }
        public int IdEnseignant { get => idEnseignant; set => idEnseignant = value; }
    }
}
