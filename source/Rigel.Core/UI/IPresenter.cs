namespace Rigel.Core.UI
{
    public interface IPresenter
    {
        IView View { get; }
    }

    public interface IPresenter<TModel>  where TModel: class
    {
        IView<TModel> View { get; }
    }
}