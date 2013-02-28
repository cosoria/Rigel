namespace Rigel.Batch.Common.Config
{
    public interface IBatchSettings
    {
        //IPlayerImportSettings PlayerImportSettings { get; set; }
        //IGameImportSettings GameImportSettings { get; set; }
        //IScheduleSyncerSettings ScheduleSyncerSettings { get; set; }
        //IStandingsSyncerSettings StandingsSyncerSettings { get; set; }
        //IInjuryBuilderSettings InjuryBuilderSettings { get; set; }
    }

    public class BatchSettings : IBatchSettings
    {
        //public IPlayerImportSettings PlayerImportSettings { get; set; }
        //public IGameImportSettings GameImportSettings { get; set; }
        //public IScheduleSyncerSettings ScheduleSyncerSettings { get; set; }
        //public IStandingsSyncerSettings StandingsSyncerSettings { get; set; }
        //public IInjuryBuilderSettings InjuryBuilderSettings { get; set; }

        public BatchSettings(BatchSettingsSection configSection)
        {
            //PlayerImportSettings = new PlayerImportSettings(configSection.PlayerImportSettings);
            //GameImportSettings = new GameImportSettings(configSection.GameImportSettings);
            //ScheduleSyncerSettings = new ScheduleSyncerSettings(configSection.ScheduleSyncerSettings);
            //StandingsSyncerSettings = new StandingsSyncerSettings(configSection.StandingsSyncerSettings);
            //InjuryBuilderSettings = new InjuryBuilderSettings(configSection.InjuryBuilderSettings);
        }
    }
}