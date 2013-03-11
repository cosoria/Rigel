namespace Rigel.UI
{
    public interface IView
    {
    }

    public interface IView<TModel> : IView where TModel:class 
    {
        TModel Model { get; }
        void SetModel(TModel model);
    }
}