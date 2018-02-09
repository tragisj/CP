using System.Collections.Generic;
using System.Linq;
using FNSB.Publicworks.Projects.DataLayer.Model;

namespace FNSB.Publicworks.Projects.DataLayer.Service
{
    public class ProjectManagerService
    {
        public publicworksEntities Ctx;

        public ProjectManagerService(publicworksEntities context)
        {
            Ctx = context;
        }

        public Dictionary<int, string> GetActiveProjectManagerDictionary()
        {
            var sec =
                from p in Ctx.Projects.Where(a => a.PPM_Project_Active == true)
                select new
                {
                    id = p.PPR_Recordid
                };

            var idlist = sec.Distinct();
            var dictionary = new Dictionary<int, string>();

            foreach (var item in idlist)
            {
                var fullname = Ctx.ProjectManagers.Find(item.id).FullName;
                dictionary.Add(item.id, fullname);
            }
            return dictionary;
        }
    }


}
