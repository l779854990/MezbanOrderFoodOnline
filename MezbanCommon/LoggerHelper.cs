using log4net;

namespace MezbanCommon
{
    public class LoggerHelper
    {
        public static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
