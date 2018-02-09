using System;

namespace FNSB.Publicworks.Projects.DataLayer.Model
{
    public partial class ProjectManager
    {
        public string FullName
        {
            get
            {//first check for empty values
                if (firstname == String.Empty)
                {
                    return lastname;
                }
                if (lastname == String.Empty)
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
                if (firstname == String.Empty)
                {
                    return lastname;
                }
                if (lastname == String.Empty)
                {
                    return firstname;
                }
                //return full name reversed with comma seperator
                return String.Format("{0}, {1}", lastname, firstname);
            }
        }
    }
}
