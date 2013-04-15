using System.Web;
using Rigel.Core.Messaging;
using Rigel.UI;

namespace Rigel.Web.UI
{
    public class RigelWebPresenter : IWebPresenter
    {
        IView IPresenter.View { get { return View; }}

        public IWebView View { get; private set; }
        public HttpContextBase ApplicationHttpContext { get; private set; }
        public HttpRequestBase Request { get { return ApplicationHttpContext.Request; }}
        public HttpResponseBase Response { get { return ApplicationHttpContext.Response; }}
        public HttpServerUtilityBase Server { get { return ApplicationHttpContext.Server; }}
        public IMessenger Messenger { get { return Core.Messaging.Messenger.Instance; }}

        public RigelWebPresenter(IWebView view) : this(view, new HttpContextWrapper(HttpContext.Current))
        {
        }

        public RigelWebPresenter(IWebView view, HttpContextBase applicationHttpContext)
        {
            View = view;
            ApplicationHttpContext = applicationHttpContext;
        }
    }

    public class RigelWebPresenter<TModel> : RigelWebPresenter, IPresenter<TModel> where TModel : class, new()
    {
        public TModel Model { get; private set; }
        public new IView<TModel> View { get; private set; }

        public RigelWebPresenter(IWebView<TModel> view) : this(view, new HttpContextWrapper(HttpContext.Current))
        {
        }

        public RigelWebPresenter(IWebView<TModel> view, HttpContextBase applicationHttpContext)
            : base(view, applicationHttpContext)
        {
            Model = new TModel();
            View = view;
            View.Model = Model;
        }
    }
}