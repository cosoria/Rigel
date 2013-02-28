namespace Rigel.Batch.Common
{
    public class BatchConstants
    {
        public static string DATE_FORMAT = "yyyy-MM-dd";

        public const string ERROR_NOTIFICATION_SETTINGS_SECTION = "ErrorNotificationSettings";
        public const string BATCH_SETTINGS_SECTION = "BatchSettings";

        public const string LOGS_DIR = "LOGS_DIR";
        public const string LOGS_FILE = "LOGS_FILE";

        public const int INFORMATIONAL_LEVEL = 1;
        public const int WARNING_LEVEL = 2;
        public const int ERROR_LEVEL = 3;

        public const string INFORMATIONAL = "info";
        public const string WARNING = "warning";
        public const string ERROR = "error";

        public static int GetErrorLevelFor(string level)
        {
            if (level.ToLower() == INFORMATIONAL)
            {
                return INFORMATIONAL_LEVEL;
            }
            else if (level.ToLower() == WARNING)
            {
                return WARNING_LEVEL;
            }
            else if (level.ToLower() == ERROR)
            {
                return ERROR_LEVEL;
            }
            return INFORMATIONAL_LEVEL;
        }
    }
}