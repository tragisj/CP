using System;
using System.Linq;

namespace FNSB.Publicworks.Projects.DataLayer.Model
{
    public partial class Secretary
    {

        public string FullName
        {
            get
            {//first check for empty values
                if (string.IsNullOrEmpty(firstname))
                {
                    return lastname;
                }
                if (string.IsNullOrEmpty(lastname))
                {
                    return firstname;
                }
                //return full name
                return String.Format("{0} {1}", firstname, lastname);
            }
        }

        public string FullNameReversed
        {
            get
            {//first check for empty values
                if (string.IsNullOrEmpty(firstname))
                {
                    return lastname;
                }
                if (string.IsNullOrEmpty(lastname))
                {
                    return firstname;
                }
                //return full name reversed with comma seperator
                return String.Format("{0}, {1}", lastname, firstname);
            }
        }

        public int SecretariesProjectCount
        {
            get
            {
                int ap2 = Projects.Count(project => project.PPM_Project_Active == true);
                return ap2;
            }
        }

        public string Initials
        {
            get
            {
                //first check for empty values
                if (string.IsNullOrEmpty(firstname))
                {
                    return lastname.Substring(0, 1);
                }
                if (string.IsNullOrEmpty(lastname))
                {
                    return firstname.Substring(0, 1);
                }
                //return full name reversed with comma seperator
                return String.Format("{0}{1}", firstname.Substring(0, 1), lastname.Substring(0, 1));
            }
        }

        public string GetSecretaryFullNameById(int id, bool reversename)
        {

            var ctx = new publicworksEntities();
            var name = ctx.Secretaries.Find(id);

            if (name != null)
                if (!reversename)
                    return FullName;
            return FullNameReversed;
        }
    }
}
