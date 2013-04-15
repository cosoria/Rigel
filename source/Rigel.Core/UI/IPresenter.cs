using Rigel.Core.Messaging;

namespace Rigel.UI
{
    public interface IPresenter
    {
        IView View { get; }
        IMessenger Messenger { get; }
    }

    public interface IPresenter<TModel> : IPresenter where TModel: class, new()
    {
        TModel Model { get; }
        new IView<TModel> View { get; }
    }
}