using Rigel.Core.Messaging;

namespace Rigel.Core.UI
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