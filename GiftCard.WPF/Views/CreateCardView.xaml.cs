using GalaSoft.MvvmLight.Messaging;
using GiftCard.WPF.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GiftCard.WPF.Views
{
    /// <summary>
    /// Interaction logic for CreateCardView.xaml
    /// </summary>
    public partial class CreateCardView : Window
    {
        public CreateCardView()
        {
            InitializeComponent();
            Messenger.Default.Register<CloseCreateCardMessage>(this, _ => Close());

            Closing += (s, e) =>
            {
                //Eseguo la de-registrazione da tutti i messaggi a cui mi sono 
                //registrato all'interno della view
                //e scollego anche il view model
                //questo per evitare conflitti con altre aperture di finestre
                Messenger.Default.Unregister(this);
                Messenger.Default.Unregister(DataContext);
            };
        }
    }
}
