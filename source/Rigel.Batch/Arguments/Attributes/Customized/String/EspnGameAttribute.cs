namespace Rigel.Batch.Arguments.Attributes.Customized.String
{
    public class EspnGamesAttribute : StringAttribute
    {
        #region Fields/Constants

        private const string CONFIG_KEY = "EspnGames";
        private const string HELP_TEXT = "Espn games can be one game or a CSV list of games.";
        private const string INVALID_VALUE = "'{0}' is not a valid espn game setting.";

        #endregion

        #region Property overrides

        public override string HelpText
        {
            get { return HELP_TEXT; }
        }

        public override string InvalidValueText
        {
            get { return INVALID_VALUE; }
        }

        public override string ConfigurationKey
        {
            get { return CONFIG_KEY; }
        }

        #endregion
    }
}