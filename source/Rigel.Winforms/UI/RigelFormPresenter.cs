using Rigel.Core.Messaging;
using Rigel.UI;

namespace Rigel.Winforms.UI
{
    public class RigelFormPresenter : IFormPresenter
    {
        public IView View { get; private set; }
        public IMessenger Messenger { get { return Core.Messaging.Messenger.Instance; }}

        public RigelFormPresenter(IView view)
        {
            View = view;
        }
    }

    public class RigelFormPresenter<TModel> : RigelFormPresenter, IFormPresenter<TModel> where TModel:class, new()
    {
        public TModel Model { get; private set; }
        public new IView<TModel> View { get; private set; }

        public RigelFormPresenter(IView<TModel> view) : base(view)
        {
            Model = new TModel();
            View = view;
            View.Model = Model;
        }
    }
}