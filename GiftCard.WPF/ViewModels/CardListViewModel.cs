using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GiftCard.Core.BusinessLayer;
using GiftCard.Core.Entities;
using GiftCard.Core.Mock.Repositories;
using GiftCard.Core.Repositories;
using GiftCard.WPF.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace GiftCard.WPF.ViewModels
{
    public class CardListViewModel : ViewModelBase
    {
        public ICommand CreateCard { get; set; }


        public ObservableCollection<CardRowViewModel> _CardsSource;
        private ICollectionView _Cards;
        public ICollectionView Cards
        {
            get { return _Cards; }
            set { _Cards = value; RaisePropertyChanged(); }
        }

        public ICommand LoadCardsCommand { get; set; }

        public CardListViewModel()
        {
            CreateCard = new RelayCommand(() => ExecuteShowCreateCard());
            LoadCardsCommand = new RelayCommand(() => ExecuteLoadCards());

            
            _CardsSource = new ObservableCollection<CardRowViewModel>();
            _Cards = new CollectionView(_CardsSource);

            LoadCardsCommand.Execute(null);
        }

        private void ExecuteLoadCards()
        {
            
            ICardRepository repo= new CardRepositoryMock();
            MainBusinessLayer layer = new MainBusinessLayer(repo);

            //Dipendenti provienienti dal repo
            var cards = layer.FetchAllCards();

            //Pulizia della lista sorgente
            _CardsSource.Clear();

            //Per ciascun dipendente creo una riga di tipo EmployeeRowViewModel
            foreach (Card c in cards)
            {
                var cardRow = new CardRowViewModel(c);
                _CardsSource.Add(cardRow);
            }


        }

        private void ExecuteShowCreateCard()
        {
            Messenger.Default.Send(new ShowCreateCardMessage());
        }
    }

}

