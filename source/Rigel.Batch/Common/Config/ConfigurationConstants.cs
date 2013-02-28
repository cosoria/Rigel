namespace Rigel.Batch.Common.Config
{
    public class ConfigurationConstants
    {
        public const string ENVIRONMENT = "ENVIRONMENT";
        public const string CURRENT_SEASON = "CURRENT_SEASON";
        public const string CURRENT_SEASON_OF_DATA = "CURRENT_SEASON_OF_DATA";
        public const string NUMBER_OF_STANDINGS_RESULTS = "NUMBER_OF_STANDINGS_RESULTS";
        public const string SHOW_ERRORS = "SHOW_ERRORS";
        public const string ENABLE_PERFORMANCE_LOGGING = "ENABLE_PERFORMANCE_LOGGING";

        public const string ERROR_NOTIFICATION_SETTINGS_SECTION = "ErrorNotificationSettings";
        public const string BATCH_SETTINGS_SECTION = "BatchSettings";

        public const string CLEAR_CACHE_LOCATION = "ClearCacheLocation";
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

        public class CustomDrafts
        {
            public const string PINT_DRAFT_ID = "PINT_DRAFT_ID";
            public const string COPPERNBLUE_DRAFT_ID = "COPPERNBLUE_DRAFT_ID";
            public const string FROMTHERINK_DRAFT_ID = "FROMTHERINK_DRAFT_ID";
        }
    }
}