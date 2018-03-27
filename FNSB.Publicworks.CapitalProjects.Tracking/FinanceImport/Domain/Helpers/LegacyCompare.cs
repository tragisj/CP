using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace Publicworks.Finance.OneSolution.Domain.Helpers
{
    public class LegacyCompare
    { 
        public string LegacyFilePath { get; set; }
        public int LegacyFileLineCount { get; set; }
        public List<string> LegacyGlKeys { get; set; }



        public LegacyCompare(string legacyFilePath)
        {
            LegacyFilePath = legacyFilePath;
            LegacyFileLineCount = 0;
            LegacyGlKeys = new List<string>();
            using (TextFieldParser parser = new TextFieldParser(LegacyFilePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    LegacyGlKeys.Add(fields[2].TrimEnd());
                    LegacyFileLineCount++;
                }
            }
        }

        public List<string> LegacyFileSqlQueryGlKeyDifference(List<string> sqlQueryKeys, List<string> legacyFileKeys, bool sqlLeads = true)
        {


            var listr = new List<string>();

            if (sqlLeads)
            {
                //Loop SQL Query Keys  - return keys in SQL query not in legacy file
                foreach (var key in sqlQueryKeys)
                {
                    //does the Legacy key list contain the GLKey generated from running the SQL statement?
                    var cp = legacyFileKeys.Contains(key);

                    //No GLKey in the Legacy Key List
                    if (!cp)
                    {
                        listr.Add(key);
                    }
                }
            }
            else
            {
                //Loop SQL Legacy Keys - return keys in file not in sql query
                foreach (var key in legacyFileKeys)
                {
                    //does the SQL Query key list contain the GLKey generated from running the legacy file?
                    var cp = sqlQueryKeys.Contains(key);

                    //No GLKey in the Legacy Key List
                    if (!cp)
                    {
                        listr.Add(key);
                    }
                }
            }

            return listr;



        }
    }
}
