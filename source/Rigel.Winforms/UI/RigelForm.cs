using System.Windows.Forms;
using Rigel.Core.Messaging;

namespace Rigel.Winforms.UI
{
    public class RigelForm : Form, IFormView 
    {
        public IMessenger Messenger { get { return Core.Messaging.Messenger.Instance; }}
    }

    public class RigelForm<TModel> : RigelForm, IFormView<TModel> where TModel : class, new()
    {
        public TModel Model { get; set; }
    }
}