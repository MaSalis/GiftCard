using GiftCard.Core.BusinessLayer;
using GiftCard.Core.Entities;
using GiftCard.Core.Mock.Repositories;
using GiftCard.Core.Mock.Storage;
using GiftCard.Core.Repositories;
using System;
using Xunit;

namespace GiftCard.WPF.Test
{
    public class GiftCardTests
    {
        [Fact]
        public void ShouldCreateCardBeOK()
        {
            //ARRANGE
            MockStorage.Initialize();

            //Creazione del repository
            ICardRepository cardRepo = new CardRepositoryMock();
            
            //Creazione del business layer
            MainBusinessLayer layer = new MainBusinessLayer(cardRepo);
           

            var newCard = new Card
            {
                Sender = "giulio",
                Receiver = "pietro",
                Msg = "ciao",
                Amount = 12,
                ExpirationDate = new DateTime(2022, 3, 4)

            };

            //ACT - Eseguo l'operazione da testare
            var result = layer.CreateCard(newCard);

            //ASSERT - Verifica del risultato ottenuto
            Assert.True(result.Success);
        }

        [Fact]

        public void ShouldCreateCardWithInvalidDateBeWrong()
        {
            MockStorage.Initialize();

            //Creazione del repository
            ICardRepository cardRepo = new CardRepositoryMock();

            //Creazione del business layer
            MainBusinessLayer layer = new MainBusinessLayer(cardRepo);
            

            var newCard = new Card
            {
                Sender = "giulio",
                Receiver = "pietro",
                Msg = "ciao",
                Amount = 12,
                ExpirationDate = new DateTime(2021,2,4)

            };

            //ACT - Eseguo l'operazione da testare
            var result = layer.CreateCard(newCard);

            //ASSERT - Verifica del risultato ottenuto
            Assert.False(result.Success);

        }

        
    }
}
