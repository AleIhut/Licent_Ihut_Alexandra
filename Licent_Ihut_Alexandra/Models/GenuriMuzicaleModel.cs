using Microsoft.AspNetCore.Mvc.RazorPages;
using Licent_Ihut_Alexandra.Data;
namespace Licent_Ihut_Alexandra.Models

{
    public class GenuriMuzicaleModel : PageModel
    {
        public List<GenMuzicalAsignat> GenMuzicalAsignatList;
        public void PopulateGenMuzicalAsignat(Licent_Ihut_AlexandraContext context, Sonorizare sonorizare) 
        {
            var allGenuriMuzicale = context.GenMuzical;
            var sonorizareGenuriMuzicale = new HashSet<int>(
                sonorizare.SonorizareGenuriMuzicale.Select(c => c.GenMuzicalID)); //
            GenMuzicalAsignatList = new List<GenMuzicalAsignat>(); 
            foreach (var cat in allGenuriMuzicale)
            {
                GenMuzicalAsignatList.Add(new GenMuzicalAsignat
                {
                    GenMuzicalID = cat.ID,
                    Nume = cat.GenMuzicalNume, 
                    Asignat = sonorizareGenuriMuzicale.Contains(cat.ID) }); }
        }
        public void UpdateSonorizareGenuriMuzicale(Licent_Ihut_AlexandraContext context, string[] selectedGenuriMuzicale, Sonorizare sonorizareToUpdate)
        {
            if (selectedGenuriMuzicale == null) { sonorizareToUpdate.SonorizareGenuriMuzicale = new List<SonorizareGenMuzical>(); return; }
            var selectedGenuriMuzicaleHS = new HashSet<string>(selectedGenuriMuzicale); var sonorizareGenuriMuzicale = new HashSet<int>(sonorizareToUpdate.SonorizareGenuriMuzicale.Select(c => c.GenMuzical.ID)); foreach (var cat in context.GenMuzical)
            {
                if (selectedGenuriMuzicaleHS.Contains(cat.ID.ToString())) { if (!sonorizareGenuriMuzicale.Contains(cat.ID)) { sonorizareToUpdate.SonorizareGenuriMuzicale.Add(new SonorizareGenMuzical { SonorizareID = sonorizareToUpdate.ID, GenMuzicalID = cat.ID }); } }
                else
                {
                    if (sonorizareGenuriMuzicale.Contains(cat.ID))
                    {
                        SonorizareGenMuzical courseToRemove = sonorizareToUpdate.SonorizareGenuriMuzicale
            .SingleOrDefault(i => i.GenMuzicalID == cat.ID); context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
