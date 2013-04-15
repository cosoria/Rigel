using Rigel.Core.Messaging;

namespace Rigel.UI
{
    public interface IView
    {
        IMessenger Messenger { get; }
    }

    public interface IView<TModel> : IView where TModel:class, new()
    {
        TModel Model { get; set; }
    }
}