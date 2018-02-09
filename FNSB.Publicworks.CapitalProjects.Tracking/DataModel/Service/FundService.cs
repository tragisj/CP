
using System.Collections;
using System.Linq;
using FNSB.Publicworks.Projects.DataLayer.Model;

namespace FNSB.Publicworks.Projects.DataLayer.Service
{
    public class FundService
    {
        private publicworksEntities _db;

        public FundService(publicworksEntities dbContext)
        {
            _db = dbContext;
        }
        /// <summary>
        /// Query to return the entire collection of fund records that are children of active projects
        /// </summary>
        /// <returns>IEnumerable of Active Fund Records Sorted by JLKey</returns>
        public IEnumerable AllActiveFunds()
        {
            return _db.Funds.Where(f => (bool) f.Project.PPM_Project_Active).OrderBy(o => o.ppf_glkey);
        }

        /// <summary>
        ///  Query to return the entire collection of fund records that are children of inactive projects
        /// </summary>
        /// <returns>IEnumerable of Inactive Fund Records Sorted by JLKey</returns>
        public IEnumerable AllInactiveProjects()
        {
            return _db.Funds.Where(f => (bool) !f.Project.PPM_Project_Active).OrderBy(o => o.ppf_glkey);
        }

    }
}
