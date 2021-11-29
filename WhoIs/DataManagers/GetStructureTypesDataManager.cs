using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIs.Helpers;
using WhoIs.Models;

namespace WhoIs.DataManagers
{
    public class GetStructureTypesDataManager: BaseDataManager
    {
        public static List<SquadronTypeModel> GetSquadronTypes()
        {
            var result = new List<SquadronTypeModel>();

            var getSquadCmd = @"select st.ID as ID, st.Name as Name From SquadronTypes st";

            SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, getSquadCmd);

            while (reader.Read())
            {
                result.Add(new SquadronTypeModel
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Name = Convert.ToString(reader["Name"])
                });

            }

            reader.Close();

            return result;
        }

        public static List<PilotTypeModel> GetPilotTypes()
        {
            var result = new List<PilotTypeModel>();

            var getPilotCmd = @"sselect pt.ID as ID, pt.Name as Name From PilotTypes pt";

            SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, getPilotCmd);

            while (reader.Read())
            {
                result.Add(new PilotTypeModel
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Name = Convert.ToString(reader["Name"])
                });

            }

            reader.Close();

            return result;
        }
    }
}
