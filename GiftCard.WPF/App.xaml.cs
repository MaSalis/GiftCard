using GalaSoft.MvvmLight.Messaging;
using GiftCard.Core.Mock.Storage;
using GiftCard.WPF.Messaging;
using GiftCard.WPF.ViewModels;
using GiftCard.WPF.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GiftCard.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Mi metto in ascolto di eventuali messaggi "DialogMessage"
            Messenger.Default.Register<DialogMessage>(this, OnDialogMessageReceived);
            Messenger.Default.Register<ShutDownApplicationMessage>(this, _ => Current.Shutdown());

            //Inizializzazione database fittizio
            MockStorage.Initialize();

            //Inizializzo la view di login
            CardListView view = new  CardListView();

            //Inizializzo il view model associato alla login
            CardListViewModel vm = new CardListViewModel();

            //Collego il vm alla view
            view.DataContext = vm;

            //Mostro la view
            view.Show();

            base.OnStartup(e);
        }


        
        private void OnDialogMessageReceived(DialogMessage message)
        {
            MessageBoxResult result = MessageBox.Show(
                message.Content,
                message.Title,
                message.Buttons, message.Icon);

            //Qui ho il risultato della selezione del pulsante
            //cliccato dall'utente => avvio la funzione di Callback
            //SOLAMENTE se è stata specificata (il default è che non 
            //è stata specificata, quindi è nulla!!!)
            if (message.Callback != null)
                message.Callback(result);
        }
    }
}
