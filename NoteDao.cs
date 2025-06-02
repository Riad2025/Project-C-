using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using revisionIsgaG2;

internal class NoteDao
{
    private const string FichierNotes = "notes.csv";
    private static int _dernierId = 0;

    // Initialisation automatique  
    static NoteDao()
    {
        if (File.Exists(FichierNotes))
        {
            var derniereLigne = File.ReadLines(FichierNotes).LastOrDefault();
            if (!string.IsNullOrEmpty(derniereLigne))
            {
                _dernierId = int.Parse(derniereLigne.Split(',')[0]);
            }
        }
    }

    // Ajouter une nouvelle note  
    public static void AjouterNote(Note note)
    {
        note.Id = ++_dernierId;
        var ligne = $"{note.Id},{note.IdEtudiant},{note.IdExamen},{note.Valeur},{note.DateEnregistrement:yyyy-MM-dd HH:mm}";
        File.AppendAllLines(FichierNotes, new[] { ligne });
    }

    // Obtenir toutes les notes  
    public List<Note> ObtenirToutesNotes()
    {
        if (!File.Exists(FichierNotes))
            return new List<Note>();

        return File.ReadAllLines(FichierNotes)
            .Select(l => l.Split(','))
            .Select(p => new Note
            {
                Id = int.Parse(p[0]),
                IdEtudiant = int.Parse(p[1]),
                IdExamen = int.Parse(p[2]),
                Valeur = double.Parse(p[3]),
                DateEnregistrement = DateTime.Parse(p[4])
            }).ToList();
    }

    // Obtenir les notes d'un étudiant  
    public List<Note> ObtenirNotesEtudiant(int idEtudiant)
    {
        return ObtenirToutesNotes()
            .Where(n => n.IdEtudiant == idEtudiant)
            .ToList();
    }

    // Obtenir les notes d'un examen  
    public List<Note> ObtenirNotesExamen(int idExamen)
    {
        return ObtenirToutesNotes()
            .Where(n => n.IdExamen == idExamen)
            .ToList();
    }

    // Mettre à jour une note  
    public void MettreAJourNote(Note note)
    {
        var notes = ObtenirToutesNotes();
        var noteExistante = notes.FirstOrDefault(n => n.Id == note.Id);

        if (noteExistante != null)
        {
            noteExistante.Valeur = note.Valeur;
            SauvegarderToutesNotes(notes);
        }
    }

    // Sauvegarde de toutes les notes  
    private void SauvegarderToutesNotes(List<Note> notes)
    {
        var lignes = notes.Select(n =>
            $"{n.Id},{n.IdEtudiant},{n.IdExamen},{n.Valeur},{n.DateEnregistrement:yyyy-MM-dd HH:mm}");
        File.WriteAllLines(FichierNotes, lignes);
    }
}
