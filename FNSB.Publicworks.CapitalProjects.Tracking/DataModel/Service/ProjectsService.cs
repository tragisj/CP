using System;
using System.Data;
using System.Linq;

namespace FNSB.Publicworks.Projects.DataLayer.Service
{
    public class ProjectsService
    {
        /// <summary>
        /// Use to Query the supplied project datatable for the filter value
        /// </summary>
        /// <param name="table"></param>
        /// <param name="search"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public Boolean ProjectFilterResults(DataTable table, String search, int status)
        {
            
            //'var results = from myRow in myDataTable.AsEnumerable()
            //'where myRow.Field<int>("RowNo") == 1
            //'select myRow;

           switch (status)
            {
                case 0:

                    var sra = from data in table.AsEnumerable()
                    where (data.Field<string>("ppm_project_number")).Contains(search)
                        || data.Field<string>("ppm_project_name").Contains(search)
                        && (data.Field<Boolean>("ppm_project_active"))
                    select data;
                    return sra.Any();

                case 1:
                    var sri = from data in table.AsEnumerable()
                    where (data.Field<string>("ppm_project_number")).Contains(search)
                        || data.Field<string>("ppm_project_name").Contains(search)
                        && (!data.Field<Boolean>("ppm_project_active"))
                    select data;
                    return sri.Any();

                default:
                    var srAny = from data in table.AsEnumerable()
                    where (data.Field<string>("ppm_project_number")).Contains(search)
                        || data.Field<string>("ppm_project_name").Contains(search)
                    select data;
                    return srAny.Any();
            }
        }
    }
}
