using Microsoft.AspNetCore.Mvc.RazorPages;
using Licent_Ihut_Alexandra.Data;

namespace Licent_Ihut_Alexandra.Models
{
    public class CuloriRochitaPageModel : PageModel
    {
        public List<AssignedCuloareData> AssignedCuloareDataList;
        public void PopulateAssignedCuloareData(Licent_Ihut_AlexandraContext context, Hostes hostes)
        {
            var allCulori = context.Culoare;
            var hostesCulori = new HashSet<int>(hostes.HostesCulori.Select(c => c.CuloareID));
            AssignedCuloareDataList = new List<AssignedCuloareData>();
            foreach (var cat in allCulori) 
            { AssignedCuloareDataList.Add(new AssignedCuloareData
            { CuloareID = cat.ID, Name = cat.CuloareName, Assigned = hostesCulori.Contains(cat.ID) }); }
        }
        public void UpdateHostesCulori(Licent_Ihut_AlexandraContext context, string[] selectedCulori, Hostes hostesToUpdate)
        {
            if (selectedCulori == null) { hostesToUpdate.HostesCulori = new List<HostesCuloare>(); 
                return; }
            var selectedCuloriHS = new HashSet<string>(selectedCulori); var hostesCulori = new HashSet<int>(hostesToUpdate.HostesCulori.Select(c => c.Culoare.ID)); 
            foreach (var cat in context.Culoare)
            {
                if (selectedCuloriHS.Contains(cat.ID.ToString())) { if (!hostesCulori.Contains(cat.ID))
                    {
                        hostesToUpdate.HostesCulori.Add(new HostesCuloare { HostesID = hostesToUpdate.ID, CuloareID = cat.ID }); } }
                else
                {
                    if (hostesCulori.Contains(cat.ID))
                    {
                        HostesCuloare courseToRemove = hostesToUpdate.HostesCulori
            .SingleOrDefault(i => i.CuloareID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}

