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
using System.Windows.Input;

namespace GiftCard.WPF.ViewModels
{
    public class CreateCardViewModel :ViewModelBase
    {
        public ICommand CreateCommand { get; set; }

        private string _Sender;
        public string Sender
        {
            get { return _Sender; }
            set
            {
                _Sender = value; RaisePropertyChanged();
            }
        }

        private string _Receiver;
        public string Receiver
        {
            get { return _Receiver; }
            set
            {
                _Receiver = value; RaisePropertyChanged();
            }
        }

        private string _Msg;
        public string Msg
        {
            get { return _Msg; }
            set
            {
                _Msg = value; RaisePropertyChanged();
            }
        }

        private double _Amount;
        public double Amount
        {
            get { return _Amount; }
            set
            {
                _Amount = value; RaisePropertyChanged();
            }
        }

        private DateTime _ExpirationDate;
        public DateTime ExpirationDate
        {
            get { return _ExpirationDate; }
            set
            {
                _ExpirationDate = value; RaisePropertyChanged();
            }
        }

        
        public CreateCardViewModel()
        {
            CreateCommand = new RelayCommand(()=> ExecuteCreate(), () => CanExecuteCreate());
            if (!IsInDesignMode)
            {
                PropertyChanged += (s, e) =>
                {
                    (CreateCommand as RelayCommand).RaiseCanExecuteChanged();
                };
            }
        }

        private bool CanExecuteCreate()
        {
            //Il pulsante create è abilitato soltanto se tutti i campi sono valorizzati
            return !string.IsNullOrEmpty(Sender) &&
                !string.IsNullOrEmpty(Receiver) &&
                !string.IsNullOrEmpty(Msg) &&
                !string.IsNullOrEmpty(Amount.ToString()) &&
                !string.IsNullOrEmpty(ExpirationDate.ToString());
        }

        private void ExecuteCreate()
        {
            //Recupero i dati dalle proprietà del view
            //model e creo una nuova entità
            var entity = new Card
            {
                Sender = Sender,
                Receiver = Receiver,
                Amount = Amount,
                ExpirationDate = ExpirationDate,
                Msg = Msg
                
            };

            //Inizializzo il business layer
            var layer = new MainBusinessLayer(new CardRepositoryMock());
            //Richiamo l'operazione del layer
            var response = layer.CreateCard(entity);

            if (!response.Success)
            {
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Something wrong",
                    Content = response.Message,
                    Icon = System.Windows.MessageBoxImage.Warning
                });
                return;
            }
            else
            {
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Creazione completata",
                    Content = response.Message,
                    Icon = System.Windows.MessageBoxImage.Information
                });
            }
            Messenger.Default.Send(new CloseCreateCardMessage());
        }
    }
}

