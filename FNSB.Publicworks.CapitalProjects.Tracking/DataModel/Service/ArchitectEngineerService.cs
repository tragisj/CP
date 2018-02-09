using System.Collections.Generic;
using System.Linq;
using FNSB.Publicworks.Projects.DataLayer.Model;

namespace FNSB.Publicworks.Projects.DataLayer.Service
{
    public class ArchitectEngineerService
    {
        private publicworksEntities _ctx;

        public ArchitectEngineerService(publicworksEntities context)
        {
            _ctx = context;
        }

        public Dictionary<int, string> GetActiveArchitectEngineerDictionary()
        {
            var arc =
                from p in _ctx.Projects.Where(a => a.PPM_Project_Active == true)
                select new
                {
                    id = (int)p.PPA_Recordid
                };

            var idlist = arc.Distinct();
            var dictionary = new Dictionary<int, string>();

            foreach (var item in idlist)
            {
                var fullname = _ctx.ArchitectEngineers.Find(item.id).FullName;
                dictionary.Add(item.id, fullname);
            }
            return dictionary;
        }


    }
}
