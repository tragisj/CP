using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicworks.Conversion
{
    class Program
    {
        static void Main(string[] args)
        {

            var ac = new Publicworks.Conversion.AdminConversion();
            List<AgencyAdminPerson> arclist = ac.GetArchitectFirstLast();
            List<AgencyAdminPerson> pmlist = ac.GetProjectMgrFirstLast();
            List<AgencyAdminPerson> seclist = ac.GetSecretaryFirstLast();
            List<AgencyAdminPerson> userlist = ac.GetUserFirstLast();
            List<AgencyName> consultantlist = ac.GetConsultantName();
            List<AgencyName> contractorlist = ac.GetContractorName();

            var pc = new Publicworks.Conversion.ProjectConversion();
            List<ProjectData> corelist = pc.GetProjectCore();

            Console.WriteLine(arclist.ToList());

        }
    }

}
