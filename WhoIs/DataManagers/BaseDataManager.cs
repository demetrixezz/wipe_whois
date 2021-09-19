using System.Configuration;
using System.Reflection;

namespace WhoIs.DataManagers
{
    /// <summary>
    /// Base class for working with data
    /// </summary>
    public abstract class BaseDataManager
    {
        #region Fields and properties

        protected static string connectionString = ConfigurationManager.ConnectionStrings["WipeData"].ConnectionString;

        /// <summary>
        /// The logger
        /// </summary>
       // protected static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Constructors

        public BaseDataManager()
        {

        }

        #endregion
    }
}
