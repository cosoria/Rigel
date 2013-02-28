namespace Rigel.Batch.Common.Config
{
    public interface IConfigurationManager
    {
        T GetConfigSetting<T>(string key);
        IErrorNotificationSettings ErrorNotificationSettings { get; }
        IBatchSettings BatchSettings { get; }
    }
}