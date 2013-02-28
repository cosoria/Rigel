namespace Rigel.Batch.Common.Mail
{
    public interface IPostmaster
    {
        bool Send(IMailMessage message);
        void Initialize();
    }
}