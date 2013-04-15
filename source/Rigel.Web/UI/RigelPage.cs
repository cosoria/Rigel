using System;
using System.Web;
using System.Web.UI;
using Rigel.Core.Messaging;
using Rigel.UI;

namespace Rigel.Web.UI
{
    public class RigelPage : Page, IWebView
    {
        public HttpContextBase ApplicationHttpContext { get { return new HttpContextWrapper(this.Context); }}
        public IMessenger Messenger { get { return Core.Messaging.Messenger.Instance; }}

        public event EventHandler OnInitView;
        public event EventHandler OnLoadView;
        public event EventHandler OnPreRenderView;
        public event EventHandler OnUnloadView;
        public event EventHandler OnErrorOcurred;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (OnInitView != null)
            {
                OnInitView(this, e);
            }
        }

        protected override void OnError(EventArgs e)
        {
            base.OnError(e);
            if (OnErrorOcurred != null)
            {
                OnErrorOcurred(this, e);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (OnLoadView != null)
            {
                OnLoadView(this, e);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (OnPreRenderView != null)
            {
                OnPreRenderView(this, e);
            }
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (OnUnloadView != null)
            {
                OnUnloadView(this, e);
            }
        }
    }

    public class RigelPage<TModel> : RigelPage, IWebView<TModel> where TModel : class, new()
    {
        public TModel Model { get; set; }
    }
}