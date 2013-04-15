using System;
using System.Web;
using Rigel.Core.Messaging;
using Rigel.UI;

namespace Rigel.Web.UI
{
    public interface IWebView : IView 
    {
        HttpContextBase ApplicationHttpContext { get; }
        
        event EventHandler OnInitView;
        event EventHandler OnLoadView;
        event EventHandler OnPreRenderView;
        event EventHandler OnUnloadView;
        event EventHandler OnErrorOcurred;
    }


    public interface IWebView<TModel> : IWebView, IView<TModel> where TModel : class, new()
    {
    }
}