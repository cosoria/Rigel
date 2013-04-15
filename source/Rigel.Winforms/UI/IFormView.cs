using Rigel.UI;

namespace Rigel.Winforms.UI
{
    public interface IFormView : IView 
    {
    }

    public interface IFormView<TModel> : IFormView, IView<TModel> where TModel : class, new()
    {
    }
}