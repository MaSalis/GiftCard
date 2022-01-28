using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GiftCard.Core.BusinessLayer;
using GiftCard.Core.Entities;
using GiftCard.Core.Mock.Repositories;
using GiftCard.WPF.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GiftCard.WPF.ViewModels
{
    public class CardRowViewModel : ViewModelBase
    {
        private Card item;

        private string _Receiver;
        public string Receiver
        {
            get { return _Receiver; }
            set { _Receiver = value; RaisePropertyChanged(); }
        }

        private string _Sender;
        public string Sender
        {
            get { return _Sender; }
            set { _Sender = value; RaisePropertyChanged(); }
        }

        private string _Msg;
        public string Msg
        {
            get { return _Msg; }
            set { _Msg = value; RaisePropertyChanged(); }
        }
        private double _Amount;
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; RaisePropertyChanged(); }
        }

        private bool viewChart = false;
        public bool ViewChart
        {
            get { return viewChart; }
            set { viewChart = value; RaisePropertyChanged(); }
        }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        
        public CardRowViewModel()
        {
            UpdateCommand = new RelayCommand(() => ExecuteUpdate());
            DeleteCommand = new RelayCommand(() => ExecuteDelete());
        }

        
        public CardRowViewModel(Card item): this()
        {
            this.item = item;
            Receiver = item.Receiver;
            Sender = item.Sender;
            Msg = item.Msg;
            Amount = item.Amount;

        }


        private void ExecuteDelete()
        {
            Messenger.Default.Send(new DialogMessage
            {
                Title = "Confirm delete",
                Content = "Are you sure?",
                Icon = MessageBoxImage.Question,
                Buttons = MessageBoxButton.YesNo,
                Callback = OnMessageBoxResultReceived
            });
        }

        private void OnMessageBoxResultReceived(MessageBoxResult result)
        {
            //Solo se l'utente ha cliccato sì
            if (result == MessageBoxResult.Yes)
            {
                var layer = new MainBusinessLayer(new CardRepositoryMock());

                //Cancello l'elemento selezionato
                var response = layer.DeleteCard(item);

                //se la response è ok
                if (!response.Success)
                {
                    Messenger.Default.Send(new DialogMessage
                    {
                        Title = "Errore",
                        Content = response.Message,
                        Icon = MessageBoxImage.Error,
                        Buttons = MessageBoxButton.OK
                    });
                    return;
                }
                else
                {
                    Messenger.Default.Send(new DialogMessage
                    {
                        Title = "Deletion Confirmed",
                        Content = response.Message,
                        Icon = MessageBoxImage.Information
                    });
                }
            }
        }

        private void ExecuteUpdate()
        {
            Messenger.Default.Send(new ShowUpdateCardMessage { Entity = item });
        }
    }
}

