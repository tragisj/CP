using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Conversion.Properties;

namespace Publicworks.Conversion
{
    public class AdminConversion
    {

        public List<AgencyAdminPerson> GetProjectMgrFirstLast()
        {
            using (SqlConnection sqlConn = new SqlConnection(Settings.Default.PSQL_DB))
            using (SqlCommand sqlCmd = sqlConn.CreateCommand())
            {
                sqlConn.Open();
                sqlCmd.CommandText = @"SELECT DISTINCT firstname, lastname FROM Publicworks.ProjectManagers";
                sqlCmd.CommandType = CommandType.Text;

                List<AgencyAdminPerson> pmList = new List<AgencyAdminPerson>();

                using (var reader = sqlCmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var ap = new AgencyAdminPerson
                            {
                                First = reader[0].ToString().TrimEnd(),
                                Last = reader[1].ToString().TrimEnd(),
                            };
                            pmList.Add(ap);
                        }
                        return pmList;
                    }
                    return null;
                }
            }
        }

        public List<AgencyAdminPerson> GetArchitectFirstLast()
        {
            using (SqlConnection sqlConn = new SqlConnection(Settings.Default.PSQL_DB))
            using (SqlCommand sqlCmd = sqlConn.CreateCommand())
            {
                sqlConn.Open();
                sqlCmd.CommandText = @"SELECT DISTINCT firstname, lastname FROM Publicworks.ArchitectEngineers";
                sqlCmd.CommandType = CommandType.Text;

                List<AgencyAdminPerson> list = new List<AgencyAdminPerson>();

                using (var reader = sqlCmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var ap = new AgencyAdminPerson
                            {
                                First = reader[0].ToString().TrimEnd(),
                                Last = reader[1].ToString().TrimEnd(),
                            };
                            list.Add(ap);
                        }
                        return list;
                    }
                    return null;
                }
            }
        }

        public List<AgencyAdminPerson> GetSecretaryFirstLast()
        {
            using (SqlConnection sqlConn = new SqlConnection(Settings.Default.PSQL_DB))
            using (SqlCommand sqlCmd = sqlConn.CreateCommand())
            {
                sqlConn.Open();
                sqlCmd.CommandText = @"SELECT DISTINCT firstname, lastname FROM Publicworks.Secretary";
                sqlCmd.CommandType = CommandType.Text;

                List<AgencyAdminPerson> list = new List<AgencyAdminPerson>();

                using (var reader = sqlCmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var ap = new AgencyAdminPerson
                            {
                                First = reader[0].ToString().TrimEnd(),
                                Last = reader[1].ToString().TrimEnd(),
                            };
                            list.Add(ap);
                        }
                        return list;
                    }
                    return null;
                }
            }
        }

        public List<AgencyAdminPerson> GetUserFirstLast()
        {
            using (SqlConnection sqlConn = new SqlConnection(Settings.Default.PSQL_DB))
            using (SqlCommand sqlCmd = sqlConn.CreateCommand())
            {
                sqlConn.Open();
                sqlCmd.CommandText = @"SELECT DISTINCT firstname, lastname FROM Publicworks.Users";
                sqlCmd.CommandType = CommandType.Text;

                List<AgencyAdminPerson> list = new List<AgencyAdminPerson>();

                using (var reader = sqlCmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var ap = new AgencyAdminPerson
                            {
                                First = reader[0].ToString().TrimEnd(),
                                Last = reader[1].ToString().TrimEnd(),
                            };
                            list.Add(ap);
                        }
                        return list;
                    }
                    return null;
                }
            }
        }


        public List<AgencyName> GetConsultantName()
        {
            using (SqlConnection sqlConn = new SqlConnection(Settings.Default.PSQL_DB))
            using (SqlCommand sqlCmd = sqlConn.CreateCommand())
            {
                sqlConn.Open();
                sqlCmd.CommandText = @"SELECT DISTINCT consultantname FROM Publicworks.Consultants";
                sqlCmd.CommandType = CommandType.Text;

                List<AgencyName> list = new List<AgencyName>();

                using (var reader = sqlCmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var ap = new AgencyName
                            {
                                Name = reader[0].ToString().TrimEnd()
                            };
                            list.Add(ap);
                        }
                        return list;
                    }
                    return null;
                }
            }
        }

        public List<AgencyName> GetContractorName()
        {
            using (SqlConnection sqlConn = new SqlConnection(Settings.Default.PSQL_DB))
            using (SqlCommand sqlCmd = sqlConn.CreateCommand())
            {
                sqlConn.Open();
                sqlCmd.CommandText = @"SELECT DISTINCT contractorname FROM Publicworks.Contractors";
                sqlCmd.CommandType = CommandType.Text;

                List<AgencyName> list = new List<AgencyName>();

                using (var reader = sqlCmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var ap = new AgencyName
                            {
                                Name = reader[0].ToString().TrimEnd()
                            };
                            list.Add(ap);
                        }
                        return list;
                    }
                    return null;
                }
            }
        }

        public List<AgencyName> GetProjectTypeName()
        {
            using (SqlConnection sqlConn = new SqlConnection(Settings.Default.PSQL_DB))
            using (SqlCommand sqlCmd = sqlConn.CreateCommand())
            {
                sqlConn.Open();
                sqlCmd.CommandText = @"SELECT DISTINCT category FROM Publicworks.ProjectTypes";
                sqlCmd.CommandType = CommandType.Text;

                List<AgencyName> list = new List<AgencyName>();

                using (var reader = sqlCmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var ap = new AgencyName
                            {
                                Name = reader[0].ToString().TrimEnd()
                            };
                            list.Add(ap);
                        }
                        return list;
                    }
                    return null;
                }
            }
        }
    }

    public class AgencyAdminPerson
    {
        public string First { get; set; }
        public string Last { get; set; }

    }

    public class AgencyName
    {
        public string Name { get; set; }

    }



}
