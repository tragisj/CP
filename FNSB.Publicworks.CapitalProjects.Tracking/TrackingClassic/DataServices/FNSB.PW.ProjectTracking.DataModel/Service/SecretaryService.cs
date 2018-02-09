using System.Collections.Generic;
using System.Linq;
using FNSB.Publicworks.Projects.DataLayer.Model;

namespace FNSB.Publicworks.Projects.DataLayer.Service
{
    public class SecretaryService
    {
        private publicworksEntities _ctx;

        public SecretaryService(publicworksEntities context)
        {
            _ctx = context;
        }

        public Dictionary<int, string> GetActiveSecretariesDictionary()
        {
            var sec =
                from p in _ctx.Projects.Where(a => a.PPM_Project_Active == true)
                select new
                {
                    id = (int)p.PPS_Recordid
                };

            var idlist = sec.Distinct();
            var dictionary = new Dictionary<int, string>();

            foreach (var item in idlist)
            {
                var fullname = _ctx.Secretaries.Find(item.id).FullName;
                dictionary.Add(item.id, fullname);
            }
            return dictionary;
        }
            

    }
}
