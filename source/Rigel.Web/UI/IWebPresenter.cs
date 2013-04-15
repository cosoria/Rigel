using System.Web;
using Rigel.UI;

namespace Rigel.Web.UI
{
    public interface IWebPresenter : IPresenter 
    {
        new IWebView View { get; }

        HttpContextBase ApplicationHttpContext { get; }
        HttpRequestBase Request { get; }
        HttpResponseBase Response { get; }
        HttpServerUtilityBase Server { get; }
    }

    public interface IWebPresenter<TModel> : IWebPresenter, IPresenter<TModel> where TModel:class, new()
    {
        new IWebView<TModel> View { get; }
    }
}