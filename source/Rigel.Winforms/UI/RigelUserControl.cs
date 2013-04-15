using System.Windows.Forms;
using Rigel.Core.Messaging;

namespace Rigel.Winforms.UI
{
    public class RigelUserControl: UserControl, IFormView
    {
        public IMessenger Messenger { get { return Core.Messaging.Messenger.Instance; }}
    }

    public class RigelUserControl<TModel> : RigelUserControl, IFormView<TModel> where TModel : class, new()
    {
        public TModel Model { get; set; }
    }
}