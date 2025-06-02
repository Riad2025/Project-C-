using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace revisionIsgaG2
{
    internal class Note
    {
        public int Id { get; set; }
        public int IdEtudiant { get; set; }
        public int IdExamen { get; set; }
        public double Valeur { get; set; } // Note sur 20
        public DateTime DateEnregistrement { get; set; } = DateTime.Now;

    }
}
