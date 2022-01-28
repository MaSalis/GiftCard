using GalaSoft.MvvmLight.Messaging;
using GiftCard.WPF.Messaging;
using GiftCard.WPF.ViewModels;
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
    /// Interaction logic for CardListView.xaml
    /// </summary>
    public partial class CardListView : Window
    {
        public CardListView()
        {
            InitializeComponent();
            Messenger.Default.Register<ShowCreateCardMessage>(this, OnShowCreateCardExecuted);
            //Messenger.Default.Register<ShowUpdateEmployeeMessage>(this, OnShowUpdateEmployeeMessageReceived);
        }

        


        //private void OnShowUpdateEmployeeMessageReceived(ShowUpdateEmployeeMessage message)
        //{
        //    //Creazione della view, del vm, marriage e show
        //    UpdateEmployeeView view = new UpdateEmployeeView();
        //    UpdateEmployeeViewModel vm = new UpdateEmployeeViewModel(message.Entity);
        //    view.DataContext = vm;
        //    view.ShowDialog();
        //}

        private void OnShowCreateCardExecuted(ShowCreateCardMessage obj)
        {
            CreateCardView view = new CreateCardView();
            CreateCardViewModel vm = new CreateCardViewModel();
            view.DataContext = vm;
            view.ShowDialog();
        }
    }
}
