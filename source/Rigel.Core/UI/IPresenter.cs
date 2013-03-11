namespace Rigel.UI
{
    public interface IPresenter
    {
        IView View { get; }
    }

    public interface IPresenter<TModel> : IPresenter where TModel: class
    {
        #pragma warning disable 108,114
        IView<TModel> View { get; }
        #pragma warning restore 108,114
    }
}