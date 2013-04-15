using Rigel.UI;

namespace Rigel.Winforms.UI
{
    public interface IFormPresenter : IPresenter 
    {
    }

    public interface IFormPresenter<TModel> : IFormPresenter, IPresenter<TModel> where TModel:class, new()
    {
    }
}