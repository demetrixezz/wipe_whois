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
    public class CheckDataManager: BaseDataManager
    {
        public static CheckSquadModel CheckSquad(string squadName)
        {
            var result = new CheckSquadModel();

            result.Name = squadName;

            SquadDbModel squadModel = null;

            var SquadNameParam = new SqlParameter("SquadNameParam", squadName);

            var getSquadCmd = @"select * from Squadrons where [Name] = @SquadNameParam";

            SqlDataReader getSquadReader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, getSquadCmd, SquadNameParam);
            while (getSquadReader.Read())
            {
                squadModel = new SquadDbModel();
                squadModel.ID = Convert.ToInt32(getSquadReader["ID"]);
                squadModel.Name = Convert.ToString(getSquadReader["Name"]);
                squadModel.SquadTypes = new List<int>();
            }

            getSquadReader.Close();

            if (squadModel == null)
            {
                result.IsSquadInDB = false;
                return result;
            }

            else
                result.IsSquadInDB = true;

            var SquadIDParam = new SqlParameter("SquadIDParam", squadModel.ID);

            var getSquadronTypesCmd = @"select sit.SquadronTypeId as sqt from SquadronInType sit where sit.SquadronId = @SquadIDParam;";

            SqlDataReader getSquadronTypesReader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, getSquadronTypesCmd, SquadIDParam);
            while (getSquadronTypesReader.Read())
            {
                squadModel.SquadTypes.Add(Convert.ToInt32(getSquadronTypesReader["sqt"]));
            }
            getSquadronTypesReader.Close();

            if (squadModel.SquadTypes.Count() > 0)
            {
                result.noSquadTypes = false;
                if (squadModel.SquadTypes.Contains(1))
                    result.IsFederal = true;

                if (squadModel.SquadTypes.Contains(2))
                    result.IsEmpire = true;

                if (squadModel.SquadTypes.Contains(3))
                    result.IsAlly = true;

                if (squadModel.SquadTypes.Contains(4))
                    result.IsSuspicious = true;

                if (squadModel.SquadTypes.Contains(5))
                    result.IsEnemy = true;
            }
            else
                result.noSquadTypes = true;

            return result;
        }


        public static CheckPilotModel CheckPilot(string pilotName)
        {
            var result = new CheckPilotModel();

            result.Name = pilotName;

            PilotDbModel pilotModel = null;

            var PilotNameParam = new SqlParameter("PilotNameParam", pilotName);

            var getPilotCmd = @"select * from Pilots where [Name] = @PilotNameParam";

            SqlDataReader getPilotReader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, getPilotCmd, PilotNameParam);
            while (getPilotReader.Read())
            {
                pilotModel = new PilotDbModel();
                pilotModel.ID = Convert.ToInt32(getPilotReader["ID"]);
                pilotModel.Name = Convert.ToString(getPilotReader["Name"]);
                pilotModel.PilotTypes = new List<int>();
            }

            getPilotReader.Close();

            if (pilotModel == null)
            {
                result.IsPilotInDB = false;
                return result;
            }

            else
                result.IsPilotInDB = true;

            var PilotIDParam = new SqlParameter("PilotIDParam", pilotModel.ID);

            var getPilotIDParamTypesCmd = @"select pit.PilotTypeId as pt from PilotInType pit where pit.PilotId = @PilotIDParam;";

            SqlDataReader getSquadronTypesReader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, getPilotIDParamTypesCmd, PilotIDParam);
            while (getSquadronTypesReader.Read())
            {
                pilotModel.PilotTypes.Add(Convert.ToInt32(getSquadronTypesReader["pt"]));
            }
            getSquadronTypesReader.Close();

            if (pilotModel.PilotTypes.Count() > 0)
            {
                result.noPilotTypes = false;

                if (pilotModel.PilotTypes.Contains(1))
                    result.IsFriend = true;

                if (pilotModel.PilotTypes.Contains(2))
                    result.IsEnemy = true;

                if (pilotModel.PilotTypes.Contains(3))
                    result.IsWorstEnemy = true;

                if (pilotModel.PilotTypes.Contains(4))
                    result.IsObserver = true;

                if (pilotModel.PilotTypes.Contains(5))
                    result.IsGuest = true;

                if (pilotModel.PilotTypes.Contains(6))
                    result.IsClogger = true;

                if (pilotModel.PilotTypes.Contains(7))
                    result.IsCheater = true;

                if (pilotModel.PilotTypes.Contains(8))
                    result.IsSpear = true;

                if (pilotModel.PilotTypes.Contains(9))
                    result.IsOther = true;
            }
            else
                result.noPilotTypes = true;

            return result;
        }
    }
}
